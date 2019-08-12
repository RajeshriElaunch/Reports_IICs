using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class OperacionesRV_II_DA
    {
        public static Parametros_OperacionesRentaVariable_II GetParametros(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Parametros_OperacionesRentaVariable_II.Where(w => w.CodigoIC== codigoIC).FirstOrDefault();
        }
    }
}
