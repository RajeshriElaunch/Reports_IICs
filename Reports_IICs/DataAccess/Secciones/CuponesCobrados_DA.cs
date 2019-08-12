using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class CuponesCobrados_DA
    {
        public static void Insert_Temp(string codigoIC, IOrderedEnumerable<Temp_CuponesCobrados> listaCuponesCobrados)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    //Si hubiera datos para este CodigoIC los borramos antes de insertar
                    dbContext.Temp_CuponesCobrados.RemoveRange(dbContext.Temp_CuponesCobrados.Where(d => d.CodigoIC == codigoIC));

                    dbContext.Temp_CuponesCobrados.AddRange(listaCuponesCobrados);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
