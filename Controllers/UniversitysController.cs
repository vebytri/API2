using API2.Base;
using API2.Models;
using API2.Repository.Data;
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
    public class UniversitysController : BaseController<University, UniversityRepository, int>
    {
        public UniversitysController(UniversityRepository university) : base(university) { }
    }
}
