using API2.Context;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class where Context : MyContext
    {
        private readonly MyContext conn;
        private readonly DbSet<Entity> entities;

        public GeneralRepository(MyContext conn)
        {
            this.conn = conn;
            entities = conn.Set<Entity>();
        }

        public int Delete(Key key)
        {
            if (entities.Find(key) != null)
            {
                conn.Remove(entities.Find(key));
                var result = conn.SaveChanges();
                return result;
            }
            throw new ArgumentNullException("Entity");
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public int Insert(Entity entity)
        {
            entities.Add(entity);
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            if(entity !=null)
            {
                conn.Entry(entity).State = EntityState.Modified;
                var result = conn.SaveChanges();
                return result;
            }
            throw new ArgumentNullException("Entity");
        }
    }
}
