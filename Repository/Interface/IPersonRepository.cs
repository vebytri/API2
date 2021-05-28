using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get();
        Person Get(int nik);
        int Insert(Person person);
        int Update(Person person);
        int Delete(int nik);
    }
}
