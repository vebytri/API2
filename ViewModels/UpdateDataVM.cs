using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.ViewModels
{
    interface UpdateDataVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public int NIK { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
    }
}
