using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class PlaneRepository : IPlaneRepository
    {
        //AMContext aMContext = new AMContext();
        //principe D : inversion de dependence ==> injection de dependence
        AMContext aMContext;
        
        public PlaneRepository(AMContext aMContext)
        {
            this.aMContext = aMContext;
        }
        public void Add(Plane plane)
        {
            aMContext.Add(plane);
            
        }

        public void Delete(Plane plane)
        {
            aMContext.Remove(plane);
            
        }

        public Plane Get(int id)
        {
            return aMContext.Find<Plane>(id);
        }

        public IList<Plane> GetAll()
        {
            return aMContext.Set<Plane>().ToList();
        }

        public void Save()
        {
            aMContext.SaveChanges(true); 
        }

        public void Update(Plane plane)
        {
            aMContext.Update(plane);
            
        }
    }
}
