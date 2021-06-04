using API2.Base;
using API2.Context;
using API2.Models;
using API2.Repository.Data;
using API2.ViewModels;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class PersonsController : BaseController<Person, PersonRepository, int>
    {
        //private readonly MyContext conn;
        PersonRepository repo;
        public IConfiguration _configuration;
        public PersonsController(PersonRepository person) : base(person) {
            this.repo = person;
        }
        [HttpPost]
        [Route("register")]
        public ActionResult Register(RegisterVM register)
        {
            
            var get = repo.Register(register);
           
            if(get>0)
            {
                return Ok("Berhasil Mendaftar");
            }
            else
            {
                return NotFound("Email telah di daftarkan");
            }
        }
        //[Authorize(Roles = "Employee,Admin")]
        [HttpGet]
        [Route("getall")]
        public ActionResult GetAllProfiles( )
        {

            var get = repo.GetAllProfiles();

            if (get !=null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak ditemukan");
            }
        }
        [HttpGet("GetProfileById/{nik}")]
        //gunakan jika menggunakan policy di stratup
        // [Authorize(Policy = "admin")]
      //  [Authorize(Roles = "Employee,Admin")]
        public ActionResult GetProfileById(int nik)
        {
            var get = repo.GetProfileById(nik);

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak ada");
            }
        }
        [HttpPost("Login")]
        public ActionResult Login(LoginVM LoginVM)
        {
            var get = repo.Login(LoginVM);
            {
                if (get > 0)
                {
                    return Ok($"Berhasil Login \nToken :{repo.GenerateToken(LoginVM)}");
                }
                else
                {
                    return NotFound("email atau password salah");
                }
            }
        }


    }
}
