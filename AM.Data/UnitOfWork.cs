using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AMContext aMContext;

        public UnitOfWork(AMContext aMContext)
        {
            this.aMContext = aMContext;
        }
        public void Dispose()
        {
            aMContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(aMContext);
        }

        public void Save()
        {
            aMContext.SaveChanges();
        }
    }
}
