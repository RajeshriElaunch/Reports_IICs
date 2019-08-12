using Reports_IICs.DataModels;
using Reports_IICs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs_Tests.Models
{
    class InMemoryPlantillaRepository : IPlantillaRepository
    {
        private List<Plantilla> _db = new List<Plantilla>();

        public Exception ExceptionToThrow { get; set; }
        //public List<Contact> Items { get; set; }

        public void SaveChanges(Plantilla objToUpdate)
        {

            foreach (Plantilla obj in _db)
            {
                if (obj.CodigoIc == objToUpdate.CodigoIc)
                {
                    _db.Remove(obj);
                    _db.Add(objToUpdate);
                    break;
                }
            }
        }

        public void Add(Plantilla objToAdd)
        {
            _db.Add(objToAdd);
        }

        public Plantilla GetByCodigoIC(string codigoIC)
        {
            return _db.FirstOrDefault(d => d.CodigoIc == codigoIC);
        }

        public void CreateNew(Plantilla objToCreate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(objToCreate);
            // return contactToCreate;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Plantilla> GetAll()
        {
            return _db.ToList();
        }


        public void Delete(string codigoIC)
        {
            _db.Remove(GetByCodigoIC(codigoIC));
        }

    }
}
