using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RentabilidadCarteraV1_DA
    {
        //public static void Insert_Temp_RentabilidadCarteraV1(string codigoIC, List<Temp_RentabilidadCarteraV1> lista)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_RentabilidadCarteraV1.RemoveRange(dbContext.Temp_RentabilidadCarteraV1.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_RentabilidadCarteraV1.AddRange(lista);
        //            dbContext.SaveChanges();
        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            dbContextTransaction.Rollback();

        //            throw ex;
        //        }
        //    }
        //}

        public static IQueryable<string> GetTempIsins(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentabilidadCarteraV1.Where(r => r.CodigoIC == codigoIC).Select(s => s.Isin).Distinct();
        }

        public static IQueryable<string> GetDistinctIndices(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentabilidadCarteraV1.Where(r => r.CodigoIC == codigoIC).Select(s => s.Isin).Distinct();
        }

        public static Temp_RentabilidadCarteraV1 Get_Temp_RentabilidadCarteraV1ById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentabilidadCarteraV1.Where(r => r.Id == id).FirstOrDefault();
        }

    }
}
