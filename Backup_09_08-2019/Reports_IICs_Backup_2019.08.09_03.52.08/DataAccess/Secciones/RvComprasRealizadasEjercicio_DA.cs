using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RvComprasRealizadasEjercicio_DA
    {
        public static IQueryable<Temp_RVComprasRealizadasEjercicio> GetTemp_RVComprasRealizadasEjercicioById(int id)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
           
              return dbContext.Temp_RVComprasRealizadasEjercicio.Where(r => r.Id == id);
           
        }

        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            dbContext = new Reports_IICSEntities();
            var obj = dbContext.Parametros_RVComprasRealizadasEjercicio.Where(w => w.CodigoIC == codigoIC).FirstOrDefault();

            //UPDATE
            if (obj == null)
            {
                obj = new Parametros_RVComprasRealizadasEjercicio();
            }

            obj.CodigoIC = codigoIC;
            obj.FechaUltimaReunion = fecha;

            dbContext.SaveChanges();
        }

        //public static void Insert_Temp(string codigoIC, List<Temp_RVComprasRealizadasEjercicio> lista)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_RVComprasRealizadasEjercicio.RemoveRange(dbContext.Temp_RVComprasRealizadasEjercicio.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_RVComprasRealizadasEjercicio.AddRange(lista);
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
