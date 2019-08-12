using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionPatrimConjuntoGuissona_DA
    {
        public static string GetTituloInforme(string codigoIC)
        {
            string titulo = "EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA";
            var dbContext = new Reports_IICSEntities();
            var obj = dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona.Where(e => e.CodigoIC == codigoIC).FirstOrDefault();

            if (obj != null)
                titulo = obj.Titulo;
            return titulo;
        }

        public static IQueryable<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> GetFondos(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var fondos = dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Where(e => e.CodigoIC == codigoIC);
            return fondos;
        }

        public static IQueryable<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> GetFondo(string Isin)
        {
            var dbContext = new Reports_IICSEntities();
            var fondos = dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Where(e => e.IsinFondo == Isin);
            return fondos;
        }

        public static Temp_EvolucionPatrimonioConjuntoGuissona Get_Temp_EvolucionPatrimonioConjuntoGuissonaById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(r => r.Id == id).FirstOrDefault();
        }

        

        //public static void Insert_Temp(string codigoIC, List<Temp_EvolucionPatrimonioConjuntoGuissona> listaValLiq, List<Temp_EvolucionPatrimonioConjuntoGuissona_Fondos> listaDatosFondos)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.RemoveRange(dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(p => p.CodigoIC == codigoIC));
        //            dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.AddRange(listaValLiq);

        //            dbContext.Temp_EvolucionPatrimonioConjuntoGuissona_Fondos.RemoveRange(dbContext.Temp_EvolucionPatrimonioConjuntoGuissona_Fondos.Where(p => p.CodigoIC == codigoIC));
        //            dbContext.Temp_EvolucionPatrimonioConjuntoGuissona_Fondos.AddRange(listaDatosFondos);

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
