using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class PlusvaliasDividendos_DA
    {
        public static IQueryable<Parametros_PlusvaliasDividendos> GetIsinsConjuntos(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Parametros_PlusvaliasDividendos.Where(p => p.CodigoIC == codigoIC);
        }

        public static int? GetIdIsinsConjunto(string codigoIC, string isin)
        {
            var dbContext = new Reports_IICSEntities();
            var par = dbContext.Parametros_PlusvaliasDividendos_ISINS.Where(p => p.Parametros_PlusvaliasDividendos.CodigoIC == codigoIC && p.ISIN == isin).FirstOrDefault();
            if(par!= null)
            {
                return par.Id_Parametros_PlusvaliasDividendos;
            }
            else
            {
                return null;
            }
        }

        public static IQueryable<PlusvaliasDividendos_Cuentas> GetCuentasAjustes()
        {
            var dbContext = new Reports_IICSEntities();
            var cuentas = dbContext.PlusvaliasDividendos_Cuentas;
            return cuentas;
        }

        public static decimal GetTotalPlusvaliasMinusvalias(string codigoIC)
        {
            decimal output = 0;

            var dbContext = new Reports_IICSEntities();
            var total = dbContext.Temp_PlusvaliasDividendos.Where(w => w.CodigoIC == codigoIC).Sum(s => s.PlusvaliasMinusvalias);

            if (total != null)
                output = (decimal)total;

            return output;
        }
    }
}
