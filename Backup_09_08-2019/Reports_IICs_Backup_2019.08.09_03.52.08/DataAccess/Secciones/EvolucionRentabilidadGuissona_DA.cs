using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionRentabilidadGuissona_DA
    {
        public static string GetTituloInforme(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var titulo = dbContext.Parametros_EvolucionRentabilidadGuissona.Where(e => e.CodigoIC == codigoIC).FirstOrDefault().Titulo;
            return titulo;
        }

        public static IQueryable<Parametros_EvolucionRentabilidadGuissona_Fondos> GetFondos(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var fondos = dbContext.Parametros_EvolucionRentabilidadGuissona_Fondos.Where(e => e.CodigoIC == codigoIC);
            return fondos;
        }

        //public static void Insert_Temp(string codigoIC, List<Temp_EvolucionRentabilidadGuissona> listaTmp, List<Temp_EvolucionRentabilidadGuissona_TAE> listaTaes, List<Temp_EvolucionRentabilidadGuissona_Fondos> listaDatosFondos)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_EvolucionRentabilidadGuissona.RemoveRange(dbContext.Temp_EvolucionRentabilidadGuissona.Where(e => e.CodigoIC == codigoIC));
        //            dbContext.Temp_EvolucionRentabilidadGuissona_TAE.RemoveRange(dbContext.Temp_EvolucionRentabilidadGuissona_TAE.Where(e => e.CodigoIC == codigoIC));
        //            dbContext.Temp_EvolucionRentabilidadGuissona_Fondos.RemoveRange(dbContext.Temp_EvolucionRentabilidadGuissona_Fondos.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_EvolucionRentabilidadGuissona.AddRange(listaTmp);
        //            dbContext.Temp_EvolucionRentabilidadGuissona_TAE.AddRange(listaTaes);
        //            dbContext.Temp_EvolucionRentabilidadGuissona_Fondos.AddRange(listaDatosFondos);
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

        public static Temp_EvolucionRentabilidadGuissona Get_Temp_EvolucionRentabilidadGuissonaById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_EvolucionRentabilidadGuissona.Where(r => r.Id == id).FirstOrDefault();
        }

        public static Temp_EvolucionRentabilidadGuissona_TAE Get_Temp_EvolucionRentabilidadGuissona_TAE(string CodigoIc,string Isin)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_EvolucionRentabilidadGuissona_TAE.Where(r => r.CodigoIC == CodigoIc && r.IsinFondo == Isin).FirstOrDefault();
        }

        public static IQueryable<Parametros_EvolucionRentabilidadGuissona_Fondos> GetFondo(string Isin)
        {
            var dbContext = new Reports_IICSEntities();
            var fondos = dbContext.Parametros_EvolucionRentabilidadGuissona_Fondos.Where(e => e.IsinFondo == Isin);
            return fondos;
        }

        public static EvolucionRentabilidadGuissona_Old GetOld(string codigoIC, string isin, DateTime fecha)
        {
            var tmp = new EvolucionRentabilidadGuissona_Old();
            var dbContext = new Reports_IICSEntities();
            tmp = dbContext.EvolucionRentabilidadGuissona_Old.Where(t => t.CodigoIC == codigoIC && t.IsinFondo == isin && t.Fecha == fecha).FirstOrDefault();

            return tmp;
        }
    }
}
