using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API2.Models
{   [Table("TB_M_Acount")]
    public class Acount
    {
        [Key]
        public int NIK { get; set; }
        [JsonIgnore]
        public string  Password { get; set; }
        public virtual Person Personn { get; set; }
        public virtual Profiling Profilingg { get; set; }
        public virtual ICollection<AcountRole> AcountRole { get; set; }
    }
}
