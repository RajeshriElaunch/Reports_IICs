using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public class GraficoIBenchmark_DA
    {
        private static Reports_IICSEntities dbContext;

        public static bool Generada(string codigoIC)
        {
            bool generada = false;

            dbContext = new Reports_IICSEntities();
            if (dbContext.Temp_GraficoIBenchmark.Where(t => t.CodigoIc == codigoIC).Count() > 0)
            {
                generada = true;
            }

            return generada;
        }
       
        //public static void Insert_Temp(Plantilla plantilla, List<Temp_GraficoIBenchmark> listaTemp)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_GraficoIBenchmark.RemoveRange(dbContext.Temp_GraficoIBenchmark.Where(p => p.CodigoIc == plantilla.CodigoIc));

        //            dbContext.Temp_GraficoIBenchmark.AddRange(listaTemp);
        //            dbContext.SaveChanges();
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    string error = validationError.ErrorMessage + " " + validationError.PropertyName;
        //                }
        //            }

        //            throw dbEx;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
        
        public static Parametros_GraficoBenchmark GetParametroPlantilla(string codigoIC)
        {
            dbContext = new Reports_IICSEntities();
            var parametro = dbContext.Parametros_GraficoBenchmark.Where(p => p.CodigoIc == codigoIC).FirstOrDefault();
            
            return parametro;
        }

        public static IQueryable<Parametros_GraficoBenchmark_Indices> GetIndices(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var resultado = dbContext.Parametros_GraficoBenchmark_Indices.Where(e => e.CodigoIC == codigoIC);
            return resultado;
        }

        public static IQueryable<Temp_GraficoIBenchmark> GetTemp(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var resultado = dbContext.Temp_GraficoIBenchmark.Where(w=> w.CodigoIc == codigoIC);
            return resultado;
        }        


    }
}
