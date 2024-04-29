using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class Service<T> : IService<T> where T : class
    {

        IRepository<T> repository;
        readonly IUnitOfWork unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<T>();

        }
        public void Add(T t)
        {
            repository.Add(t);
            unitOfWork.Save();
        }

        public void Delete(T t)
        {
            repository.Delete(t);
            unitOfWork.Save();
        }

        public T Get(object id)
        {
            return repository.Get(id);
        }

        public IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(T t)
        {
            repository.Update(t);
            unitOfWork.Save();
        }
    }
}
