using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public interface IPlaneRepository
    {
        /*
         * Add : Permet d’ajouter un objet Plane dans la BDD,  
         * Get: Permet de récupérer un objet Plane de la BDD,   
         * Update: Permet de mettre à jour un objet Plane dans la BDD,   
         * Delete: Permet de supprimer un objet Plane de la BDD,   
         * GetAll: Permet de récupérer tous les enregistrements Plane à partir de la BDD. 
         * */
        void Add(Plane plane);
        Plane Get(int id);
        void Update(Plane plane);
        void Delete(Plane plane);
        IList<Plane> GetAll();
        void Save();

    }
}
