using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API2.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        //generate controller
        public PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }
        public int Delete(int nik)
        {
            if (conn.Persons.Find(nik) != null)
            {
                    conn.Remove(conn.Persons.Find(nik));
                    var res = conn.SaveChanges();
                    return res;
            }
            else
            {
                return 0;
            }
        }
        public IEnumerable<Person> Get()
        {
            return conn.Persons.ToList();
        }
        public Person Get(int nik)
        {
            return conn.Persons.Find(nik);
        }
        public int Insert(Person person)
        {
            try
            {
                conn.Persons.Add(person);
                var result = conn.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Update(Person person)
        {
            try
            {
                conn.Entry(person).State = EntityState.Modified;
                var result = conn.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
