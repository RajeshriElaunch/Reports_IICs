using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RatiosCarteraRV_DA
    {
        public static IQueryable<Temp_RatiosCarteraRV> GetTemp_RatiosCarteraRV(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //if (!string.IsNullOrEmpty(isin))
            //{
            //    return dbContext.Temp_RatiosCarteraRV.Where(r => r.CodigoIC == codigoIC && r.Isin == isin);
            //}
            //else
            //{
                return dbContext.Temp_RatiosCarteraRV.Where(r => r.CodigoIC == codigoIC);
            //}
        }

        //public static void Insert_Temp(Plantilla plantilla, List<Temp_RatiosCarteraRV> listaTemp)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_RatiosCarteraRV.RemoveRange(dbContext.Temp_RatiosCarteraRV.Where(p => p.CodigoIC == plantilla.CodigoIc));

        //            dbContext.Temp_RatiosCarteraRV.AddRange(listaTemp);
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
