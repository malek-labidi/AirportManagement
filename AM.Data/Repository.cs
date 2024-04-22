using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        AMContext aMContext;
        public Repository(AMContext aMContext)
        {
            this.aMContext = aMContext;
        }
        public void Add(T entity)
        {
            aMContext.Add(entity);
        }

        public void Delete(T t)
        {
            aMContext.Remove(t);
        }

        public T Get(object id)
        {
            return aMContext.Find<T>(id);
        }

        public IList<T> GetAll()
        {
            return aMContext.Set<T>().ToList(); 
        }

        public void Save()
        {
           aMContext.SaveChanges();
        }

        public void Update(T entity)
        {
            aMContext.Update(entity);
        }
    }
}
