using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class IndicePreconfiguradoNovarex_DA
    {
        public static IQueryable<IndicesPreconfiguradosNovarex> GetIndicesFijos()
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.IndicesPreconfiguradosNovarexes;
        }

        public static IQueryable<Parametros_IndicePreconfiguradoNovarex> GetIndicesPlantilla(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Parametros_IndicePreconfiguradoNovarex.Where(i => i.CodigoIC == codigoIC);
        }

        public static void InsertRentabilidadAcumulada(decimal rentabilidadAcumulada, DateTime fecha, string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();

            var entity = dbContext.RentabilidadIndiceNovarexAcumuladas.Where(r => r.Fecha == fecha && r.CodigoIc== codigoIC).FirstOrDefault();

            bool esNuevo = entity != null ? false : true;

            if (esNuevo)
                entity = new RentabilidadIndiceNovarexAcumulada();

            entity.Fecha = fecha;
            entity.RentabilidadAcumulada = rentabilidadAcumulada;
            entity.CodigoIc = codigoIC;

            if (esNuevo)
            {
                dbContext.RentabilidadIndiceNovarexAcumuladas.Add(entity);
            }

            dbContext.SaveChanges();
        }

        public static DateTime From(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day);
        }

        public static DateTime To(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }
    }
}
