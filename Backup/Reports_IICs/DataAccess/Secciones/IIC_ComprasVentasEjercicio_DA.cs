using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class IIC_ComprasVentasEjercicio_DA
    {
        public static void Insert_Temp(Plantilla plantilla, List<Temp_IIC_ComprasVentasEjercicio> listaTmp)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_IIC_ComprasVentasEjercicio.RemoveRange(dbContext.Temp_IIC_ComprasVentasEjercicio.Where(p => p.CodigoIC == plantilla.CodigoIc));
                    dbContext.Temp_IIC_ComprasVentasEjercicio.AddRange(listaTmp);

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            dbContext = new Reports_IICSEntities();
            var obj = dbContext.Parametros_IIC_ComprasVentasEjercicio.Where(w => w.CodigoIC == codigoIC).FirstOrDefault();

            //UPDATE
            if (obj == null)
            {
                obj = new Parametros_IIC_ComprasVentasEjercicio();
            }

            obj.CodigoIC = codigoIC;
            obj.FechaUltimaReunion = fecha;

            dbContext.SaveChanges();
        }
    }
}
