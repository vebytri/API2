using API2.Models;
using API2.Repository;
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
    public class Persons_oldController : ControllerBase
    {
        private readonly PersonRepository personRepository;
        public Persons_oldController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpPost]
        public ActionResult Post(Person person)
        {
            var post = personRepository.Insert(person);
            if (post>0)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("Maaf terjadikesalahan ketika insert");
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            var get = personRepository.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak ditemukan");
            }
        }
        [Route("{nik}")]
        public ActionResult Get(int nik)
        {
            var get = personRepository.Get(nik);
            if (get!=null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak dapat ditemukan");
            }
        }
        [HttpDelete("{nik}")]
        public ActionResult Delete(int nik)
        {
            var del = personRepository.Delete(nik);
            if (del ==1)
            {
                return Ok(del);
            }
            else
            {
                return NotFound("Maaf Data tidak ditemukan");
            }
        }
        [HttpPut]
        public ActionResult Put(Person person)
        {
            var update = personRepository.Update(person);
            if (update!=0)
            {
                return Ok(update);
            }
            else
            {
                return NotFound("Update gagal, data tidak ditemukan");
            }
        }
    }
}
