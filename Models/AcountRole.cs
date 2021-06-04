using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Models
{
    [Table("TB_R_AcountRole")]
    public class AcountRole
    {
        public int NIK { get; set; }
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }
        public virtual Acount Acount { get; set; }
    }
}
