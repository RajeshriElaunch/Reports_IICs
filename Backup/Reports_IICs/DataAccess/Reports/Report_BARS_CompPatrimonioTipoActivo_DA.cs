using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public static class Report_BARS_CompPatrimonioTipoActivo_DA
    {
        public static decimal? GetTotalPorcentaje(string codigoIC, string isin)
        {
            var dbContext = new Reports_IICSEntities();
            var temp = dbContext.Temp_GraficoExposMercTipoActivo.Where(p => p.CodigoIC == codigoIC).ToList();
            if (!string.IsNullOrEmpty(isin))
            {
                temp = temp.Where(w => w.Isin.ToUpper().Equals(isin.ToUpper())).ToList();
            }

            return temp.Sum(c => c.PorcentajePatrimonio);

            //return dbContext.Temp_GraficoCompPatrimonioTipoActivo.Where(p => p.CodigoIC == codigoIC && p.Isin == isin).Sum(c => c.PorcentajePatrimonio);
        }
    }
}
