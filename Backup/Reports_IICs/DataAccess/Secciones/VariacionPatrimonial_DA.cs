using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class VariacionPatrimonial_DA
    {
        public static List<VariacionPatrimonial_Cuentas> GetCuentas()
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.VariacionPatrimonial_Cuentas.ToList();
        }
    }
}
