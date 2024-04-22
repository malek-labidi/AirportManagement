using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(object id);
        void Update(T entity);
        void Delete(T t);
        IList<T> GetAll();
        void Save();
    }
}
