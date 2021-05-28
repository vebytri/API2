using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//base interface for general interface
namespace API2.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get();//show all data
        Entity Get(Key key); //show 1 data
        int Insert(Entity entity);//insert data
        int Update(Entity entity);//update data
        int Delete(Key key);//delete data
    }
}
