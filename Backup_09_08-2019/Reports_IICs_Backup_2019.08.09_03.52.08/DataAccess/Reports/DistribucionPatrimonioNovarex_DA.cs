using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public static class DistribucionPatrimonioNovarex_DA
    {
        public static IQueryable<DistribucionPatrimonioNovarex_CuentasTesoreria> GetCuentasTesoreriaDepositos(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            var tes = dbContext.DistribucionPatrimonioNovarex_CuentasTesoreria;
            return tes;
        }
    }
}
