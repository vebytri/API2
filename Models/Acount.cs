using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Models
{   [Table("TB_M_Acoount")]
    public class Acount
    {
        [Key]
        public int NIK { get; set; }
        public string  Password { get; set; }
        public virtual Person Personn { get; set; }
        public virtual Profiling Profilingg { get; set; }
    }
}
