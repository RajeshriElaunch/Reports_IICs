using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.Models
{
    public interface IPlantillaRepository
    {
        void CreateNew(Plantilla contactToCreate);
        void Delete(string codigoIC);
        Plantilla GetByCodigoIC(string codigoIC);
        IEnumerable<Plantilla> GetAll();
        int SaveChanges();

    }
}
