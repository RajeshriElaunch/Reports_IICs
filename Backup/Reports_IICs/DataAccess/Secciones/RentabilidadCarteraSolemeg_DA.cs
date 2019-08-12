using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class RentabilidadCarteraSolemeg_DA
    {
        public static IQueryable<RentabilidadCarteraSolemeg> Get_RentabilidadCarteraSolemeg(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var cartera_old = dbContext.RentabilidadCarteraSolemegs.Where(r => r.CodigoIC == codigoIC);

            return cartera_old;
        }
    }
}
