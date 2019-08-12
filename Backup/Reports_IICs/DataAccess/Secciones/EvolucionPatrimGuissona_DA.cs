using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionPatrimGuissona_DA
    {
        public static void Insert_Temp(Plantilla plantilla, List<Temp_EvolucionPatrGuissonaValLiq> listaValLiq, List<Temp_EvolucionPatrGuissonaIndBench> listaIndBench, Temp_EvolucionPatrGuissonaRentabilidad rent)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_EvolucionPatrGuissonaValLiq.RemoveRange(dbContext.Temp_EvolucionPatrGuissonaValLiq.Where(p => p.CodigoIc == plantilla.CodigoIc));
                    dbContext.Temp_EvolucionPatrGuissonaValLiq.AddRange(listaValLiq);

                    dbContext.Temp_EvolucionPatrGuissonaIndBench.RemoveRange(dbContext.Temp_EvolucionPatrGuissonaIndBench.Where(e => e.CodigoIC == plantilla.CodigoIc));
                    dbContext.Temp_EvolucionPatrGuissonaIndBench.AddRange(listaIndBench);

                    dbContext.Temp_EvolucionPatrGuissonaRentabilidad.RemoveRange(dbContext.Temp_EvolucionPatrGuissonaRentabilidad.Where(e => e.CodigoIc == plantilla.CodigoIc));
                    dbContext.Temp_EvolucionPatrGuissonaRentabilidad.Add(rent);

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Parametros_EvolucionPatrimGuissona GetParametrosRentabilidad(string codigoIC)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                return dbContext.Parametros_EvolucionPatrimGuissona.Where(g => g.CodigoIC == codigoIC).FirstOrDefault();
            }
        }
    }
}
