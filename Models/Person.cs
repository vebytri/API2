using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Models
{   [Table("TB_M_Person")]
    public class Person
    {   [Key]
        public int NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [JsonIgnore]
        public int Salary { get; set; }
        public string Email { get; set; }
        public virtual Acount Account { get; set; }
    }
}
