using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class GraficoCompCartRF_DA
    {
        public static string GetCategoriaBySector(string sector)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Sectores.Where(s => s.Descripcion.Equals(sector)).Select(s => s.Instrumentos_Categorias.Descripcion).FirstOrDefault();
        }

        public static List<RatingsEquivalencia> GetRatingsEquivalencias()
        {
            var dbContext = new Reports_IICSEntities();
            //haciéndolo con entity no estaba devolviendo los datos correctamente
            //var output = dbContext.RatingsEquivalencias.ToList();
            var output = Reports_DA.GetRatingsEquivalencias();
            return output;
        }
    }
}
