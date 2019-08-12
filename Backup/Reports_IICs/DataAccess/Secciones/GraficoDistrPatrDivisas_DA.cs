using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class GraficoDistrPatrDivisas_DA
    {
        public static IEnumerable<GraficoCompPatrimonioDivisas_CtasTesorNoEur> GetCtasTesorNoEur()
        {
            var dbContext = new Reports_IICSEntities();
            var cuentas = dbContext.GraficoCompPatrimonioDivisas_CtasTesorNoEur;
            return cuentas;
        }
    }
}
