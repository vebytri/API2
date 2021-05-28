using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Models
{   [Table("TB_R_Profiling")]
    public class Profiling
    {
        [Key]
        public int NIK { get; set; }
        public int Education_id { get; set; }
        public virtual Acount Account { get; set; }
        public virtual Education Edu { get; set; }

    }
}
