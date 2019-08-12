using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class GraficoCompCartRV_DA
    {
        //public static void Insert_Temp(Plantilla plantilla, List<Temp_GraficoCompCarteraRV> listaTemp)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_GraficoCompCarteraRV.RemoveRange(dbContext.Temp_GraficoCompCarteraRV.Where(p => p.CodigoIC == plantilla.CodigoIc));
                    
        //            dbContext.Temp_GraficoCompCarteraRV.AddRange(listaTemp);
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public static string GetCategoriaBySector(string sector)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Sectores.Where(s => s.Descripcion.Equals(sector)).Select(s => s.Instrumentos_Categorias.Descripcion).FirstOrDefault(); 
        }
    }
}
