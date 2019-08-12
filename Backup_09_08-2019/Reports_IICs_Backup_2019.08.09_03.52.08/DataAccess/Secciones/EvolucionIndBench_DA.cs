using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionIndBench_DA
    {
        public static void Insert_Temp_EvolucionIndBench(string codigoIC, List<Temp_EvolucionIndBench> lista)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_EvolucionIndBench.RemoveRange(dbContext.Temp_EvolucionIndBench.Where(e => e.CodigoIC == codigoIC));

                    dbContext.Temp_EvolucionIndBench.AddRange(lista);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
