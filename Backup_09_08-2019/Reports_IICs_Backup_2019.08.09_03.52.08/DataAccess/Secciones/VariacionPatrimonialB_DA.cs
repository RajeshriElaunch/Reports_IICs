using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class VariacionPatrimonialB_DA
    {
        public static List<Temp_VariacionPatrimonialB> GetTemp(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_VariacionPatrimonialB.Where(w => w.CodigoIC == codigoIC).ToList();
        }
    }
}
