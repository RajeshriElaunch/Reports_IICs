using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.Models
{
    public class EntityPlantillaManagerRepository : IPlantillaRepository
    {

        private Reports_IICSEntities _db = new Reports_IICSEntities();

        public Plantilla GetByCodigoIC(string codigoIC)
        {
            return _db.Plantillas.FirstOrDefault(d => d.CodigoIc == codigoIC);
        }

        public IEnumerable<Plantilla> GetAll()
        {
            return _db.Plantillas.ToList();
        }

        public void CreateNew(Plantilla objToCreate)
        {
            //_db.AddToContacts(contactToCreate);            
            //_db.SaveChanges();
            //   return contactToCreate;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Delete(string codigoIC)
        {
            var objToDel = GetByCodigoIC(codigoIC);
            _db.Plantillas.Remove(objToDel);
            _db.SaveChanges();
        }

    }
}
