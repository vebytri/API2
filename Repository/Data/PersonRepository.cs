using API2.Context;
using API2.Models;
using API2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace API2.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {
        MyContext conn;
        public IConfiguration configuration;
        public PersonRepository(MyContext myContext, IConfiguration config) : base(myContext) {
            this.conn = myContext;
            this.configuration=config;
        }
       
        //generate controller
        public int Register(RegisterVM register)
        { var result = 0;
            var cekPerson = conn.Persons.FirstOrDefault(p => p.Email == register.Email);
            if (cekPerson==null)
            {
                Person person = new Person
                {

                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    BirthDate = register.BirthDate,
                    Phone = register.Phone,
                    Email = register.Email,
                    Salary = register.Salary
                };
                conn.Add(person);
                result = conn.SaveChanges();
                Acount account = new Acount
                {
                    NIK = person.NIK,
                    Password = BC.HashPassword(register.Password)
                };
                conn.Add(account);
                result = conn.SaveChanges();
                Education education = new Education
                {
                    Degree = register.Degree,
                    GPA = register.GPA,
                    Universityid = register.UniversityId
                };
                conn.Add(education);
                result = conn.SaveChanges();
                Profiling profiling = new Profiling
                {
                    NIK = account.NIK,
                    Educationid = education.Educationid
                };
                conn.Add(profiling);
                AcountRole acountrole = new AcountRole
                {
                    NIK = account.NIK,
                    RoleId = 1
                };
                conn.Add(acountrole);
                result = conn.SaveChanges();
            }
            
            return result;
        }
        public RegisterVM GetProfileById(int nik)
        {
            var all =
                 (
                   from a in conn.Persons
                   join pa in conn.Acounts on a.NIK equals pa.NIK
                   join ap in conn.Profilings on pa.NIK equals ap.NIK
                   join ue in conn.Educations on ap.Educationid equals ue.Educationid
                   join ep in conn.Universities on ue.Universityid equals ep.Universityid
                   select new RegisterVM
                   {
                       NIK = a.NIK,
                       FirstName = a.FirstName,
                       LastName = a.LastName,
                       Phone = a.Phone,
                       BirthDate = a.BirthDate,
                       Email = a.Email,
                       Salary = a.Salary,
                       Degree = ue.Degree,
                       GPA = ue.GPA,
                       UniversityId = ep.Universityid,
                       Password= pa.Password
                   }
                 ).ToList();
            return all.Single(a => a.NIK == nik);
        }
        public IEnumerable<RegisterVM> GetAllProfiles()
        {
            //Acount acount =new Acount();
            //Profiling profiling = new Profiling();
            //Education education = new Education();
            //University university = new University();

            var all = 
                (
                  from p in conn.Persons
                  join a in conn.Acounts on p.NIK equals a.NIK
                  join pf in conn.Profilings on a.NIK equals pf.NIK
                  join ed in conn.Educations on pf.Educationid equals ed.Educationid
                  join un in conn.Universities on ed.Universityid equals un.Universityid
                  join ar in conn.AcountRoles on a.NIK equals ar.NIK
                  join r in conn.Roles on ar.RoleId equals r.Id
                  select new RegisterVM
                  {
                   NIK = a.NIK,
                   FirstName =p.FirstName,
                   LastName  =p.LastName,
                   Phone =p.Phone,
                   BirthDate =p.BirthDate,
                   Salary= p.Salary,
                   Email= p.Email,
                   Password =a.Password,
                   Degree=  ed.Degree,
                   GPA =ed.GPA,
                   UniversityId =un.Universityid,
                  // RoleId=ar.RoleId
                   }
                ).ToList();
            return all;
        }
        //public RegisterVM GetReg(int nik)
        //{
        //Acount acount =new Acount();
        //Profiling profiling = new Profiling();
        //Education education = new Education();
        //University university = new University();

        //    var all = (
        //          from a in conn.Persons
        //          join pa in conn.Acounts on a.NIK equals pa.NIK

        //          from b in conn.Acounts
        //          join ap in conn.Profilings on b.NIK equals ap.NIK

        //          from c in conn.Universities
        //          join ue in conn.Educations on c.Universityid equals ue.Universityid
        //          from d in conn.Educations
        //          join ep in conn.Profilings on d.Educationid equals ep.Educationid
        //          select new { a, pa, b, ap, c, ue, d, ep }
        //        ).ToListAsync();
        //    return (RegisterVM)all;
        //}
        public int Login(LoginVM LoginVM)
        {
            var check = conn.Persons.FirstOrDefault(e => e.Email == LoginVM.Email);

            if (check != null && BC.Verify(LoginVM.Password,check.Account.Password))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int ChangePassword (ChangePasswordVM changePassword)
        {

            return 0;
        }
        public string GenerateToken(LoginVM Login)
        {
            var check = conn.Persons.FirstOrDefault(e => e.Email == Login.Email);
            var check2nd = conn.AcountRoles.Single(e => e.NIK == check.NIK);
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub,configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("Email",Login.Email.ToString()),
                    new Claim("role",check2nd.Roles.Name.ToString()),
                   // new Claim(ClaimTypes.Role, check2nd.Roles.Name.ToString())
        };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: signin);
            return new JwtSecurityTokenHandler().WriteToken(token);
            //var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            //var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecret));
            //var myIssuer = "aa";
            //var myAudience = "bb";

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //new Claim("Email",Login.Email.ToString()),
            //new Claim("RoleId",check2nd.Roles.Name),

            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    Issuer = myIssuer,
            //    Audience = myAudience,
            //    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
        }

        public int DeleteData(int nik)
        {
            if (conn.Persons.Find(nik) != null)
            {
                conn.Remove(conn.Profilings.Find(nik));
                var res = conn.SaveChanges();
                conn.Remove(conn.AcountRoles.Find(nik,1));
                res += conn.SaveChanges();
                conn.Remove(conn.Acounts.Find(nik));
                res += conn.SaveChanges();
                conn.Remove(conn.Persons.Find(nik));
                res += conn.SaveChanges();

                return res;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateData(RegisterVM register)
        {
            
            
            Person person = new Person
            {
                NIK = register.NIK,
                FirstName = register.FirstName,
                LastName = register.LastName,
                BirthDate = register.BirthDate,
                Phone = register.Phone,
                Email = register.Email,
                Salary = register.Salary
            };
            try
            {
                conn.Update(person);
                var result=conn.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        
    }


}
