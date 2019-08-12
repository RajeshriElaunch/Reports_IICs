using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class SuscripcionesReembolsos_DA
    {
        public static void Insert_Temp(string codigoIC, IOrderedEnumerable<Temp_SuscripcionesReembolsos> listaSuscripcionesReembolsos)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_SuscripcionesReembolsos.RemoveRange(dbContext.Temp_SuscripcionesReembolsos.Where(d => d.CodigoIC == codigoIC));

                    dbContext.Temp_SuscripcionesReembolsos.AddRange(listaSuscripcionesReembolsos);
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
