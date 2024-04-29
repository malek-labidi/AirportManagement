using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(object id);
        //T Get(string id);
        //T Get(int id);
        void Update(T entity);
        void Delete(T t);
        IList<T> GetAll();
      //  void Save();
    }
}
