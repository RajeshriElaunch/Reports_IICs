using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Reports_IICs.ViewModels.Instrumentos
{
    public class InstrumentosTipos_VM
    {
        public InstrumentosTipos_VM()
        {
            this.DataItemsRV = InstrumentosTipos_DA.GetTiposEspecialesRV().ToList();
        }

        /// <summary>
        /// Los tipos de instrumento especiales para la sección RV
        /// </summary>
        public List<Instrumentos_Tipos> DataItemsRV { get; private set; }

        public static DbSet<Instrumentos_Tipos> GetAll()
        {
            return InstrumentosTipos_DA.GetAll();
        }
    }
}
