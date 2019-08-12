using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RentabilidadCarteraV2_DA
    {
        public static Temp_RentabilidadCarteraV2 Get_Temp_RentabilidadCarteraV2ById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentabilidadCarteraV2.Where(r => r.Id == id).FirstOrDefault();
        }

        public static Parametros_Rentabilidad_CarteraII GetParametroPlantillaRentabilidadCarteraII(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var parametro = dbContext.Parametros_Rentabilidad_CarteraII.Where(p => p.CodigoIC == codigoIC).FirstOrDefault();

            return parametro;
        }


        //public static void Insert_Temp_RentabilidadCarteraV2(string codigoIC, List<Temp_RentabilidadCarteraV2> lista)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_RentabilidadCarteraV2.RemoveRange(dbContext.Temp_RentabilidadCarteraV2.Where(e => e.CodigoIC == codigoIC));

        //            dbContext.Temp_RentabilidadCarteraV2.AddRange(lista);
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public static IQueryable<string> GetDistinctIndices(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            //Sólo necesitamos los que son isins --> Los que tienen EsIndice = false
            return dbContext.Temp_RentabilidadCarteraV2.Where(r => r.CodigoIC == codigoIC && r.EsIndice).Select(s => s.Isin).Distinct();
        }

        public static IQueryable<string> GetDistinctIsins(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            //Sólo necesitamos los que son isins --> Los que tienen EsIndice = false
            return dbContext.Temp_RentabilidadCarteraV2.Where(r => r.CodigoIC == codigoIC && !r.EsIndice).Select(s => s.Isin).Distinct();
        }

        public static decimal? GetRentabilidadAcumuladaByFecha(DateTime fecha, string codigoIC)
        {
            decimal? valor = null;
            var dbContext = new Reports_IICSEntities();
            //Sólo necesitamos los que son isins --> Los que tienen EsIndice = false
            var rentAcum = dbContext.RentabilidadIndiceNovarexAcumuladas.Where(w => w.Fecha == fecha && w.CodigoIc == codigoIC).FirstOrDefault();
            if(rentAcum!= null)
            {
                valor = rentAcum.RentabilidadAcumulada;
            }

            return valor;
        }

        public static void InsertRentabilidadAcumulada(List<RentabilidadIndiceNovarex> listRentAcum)
        {
            try
            {
                var dbContext = new Reports_IICSEntities();
                //Primero borramos los datos existentes
                dbContext.RentabilidadIndiceNovarexes.RemoveRange(dbContext.RentabilidadIndiceNovarexes);
                dbContext.RentabilidadIndiceNovarexes.AddRange(listRentAcum);
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
