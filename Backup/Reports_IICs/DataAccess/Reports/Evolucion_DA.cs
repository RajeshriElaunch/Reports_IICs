using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class Evolucion_DA
    {
        private static Reports_IICSEntities dbContext;


        public static IQueryable<Temp_EvolucionPatrValLiq> GetTemp_EvolucionPatrValLiq(string codigoIC, string isin, DateTime fecha)
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Temp_EvolucionPatrValLiq.Where(p => p.CodigoIc == codigoIC && p.Isin == isin);
        }

        

    }
}
