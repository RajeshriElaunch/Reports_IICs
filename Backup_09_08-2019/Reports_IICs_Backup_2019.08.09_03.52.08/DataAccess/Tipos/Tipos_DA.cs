using Reports_IICs.DataModels;
using System.Data.Entity;

namespace Reports_IICs.DataAccess.Tipos
{
    public class Tipos_DA
    {
        public static DbSet<Reports_IICs.DataModels.Tipos> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Tipos;
        }
    }
}
