using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RfComprasVentasEjercicio_DA
    {
        public static void Insert_Temp(string codigoIC, List<Temp_RFComprasVentasEjercicio> lista)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_RFComprasVentasEjercicio.RemoveRange(dbContext.Temp_RFComprasVentasEjercicio.Where(e => e.CodigoIC == codigoIC));

                    dbContext.Temp_RFComprasVentasEjercicio.AddRange(lista);
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
