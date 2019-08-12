using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public static class Report_BARS_CompPatrimonioDivisas_DA
    {
        public static decimal? GetTotalPorcentaje(string codigoIC, string isin)
        {
            var dbContext = new Reports_IICSEntities();
            //return dbContext.Temp_GraficoCompPatrimonioDivisas.Where(p => p.CodigoIC == codigoIC && p.Isin == isin).Sum(c => c.Patrimonio);

            var temp = dbContext.Temp_GraficoExposMercDivisas.Where(p => p.CodigoIC == codigoIC).ToList();
            if (!string.IsNullOrEmpty(isin))
            {
                temp = temp.Where(w => w.Isin.ToUpper().Equals(isin.ToUpper())).ToList();
            }

            return temp.Sum(c => c.PorcentajePatrimonio);

            //var tmp = dbContext.Temp_GraficoCompPatrimonioDivisas.Where(w => w.Isin.Equals(isin) && w.CodigoIC.Equals(codigoIC)).ToList();
            //if(tmp.Count > 0)
            //{
            //    return tmp.Sum(s => s.Patrimonio);
            //}
            //else
            //{
            //    return null;
            //}

            //System.Nullable<float> totalPorcentaje = (from prod in dbContext.Temp_GraficoCompPatrimonioDivisas where prod.Isin==isin && prod.CodigoIC == codigoIC
            //                         select (float)prod.Patrimonio)
            //                         .Sum();

            //return Convert.ToDecimal(totalPorcentaje);

        }
    }
}
