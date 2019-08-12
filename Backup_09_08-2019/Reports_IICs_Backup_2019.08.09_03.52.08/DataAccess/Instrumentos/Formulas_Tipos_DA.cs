using Reports_IICs.DataModels;
using System.Data.Entity;

namespace Reports_IICs.DataAccess.Instrumentos
{
    class Formulas_Tipos_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static DbSet<Formulas_Tipos> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Formulas_Tipos;
        }
    }
}
