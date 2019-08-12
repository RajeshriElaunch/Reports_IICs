using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class EvolPatrValLiq_DA
    {
        public static ReportPatrimonio_ValorLiquidativo_Result GetTemp(string codigoIC, string isin)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            var result = dbcontext.ReportPatrimonio_ValorLiquidativo(isin, codigoIC).FirstOrDefault();
            return result;
        }
    }
}