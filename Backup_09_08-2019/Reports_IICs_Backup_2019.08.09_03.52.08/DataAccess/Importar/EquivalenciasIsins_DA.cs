using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Importar
{
    public static class EquivalenciasIsins_DA
    {
        public static bool Save(List<RentaVariable_Equivalencias> lista)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //Primero borramos los existentes
            dbContext.RentaVariable_Equivalencias.RemoveRange(dbContext.RentaVariable_Equivalencias);
            dbContext.RentaVariable_Equivalencias.AddRange(lista);

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<RentaVariable_Equivalencias> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.RentaVariable_Equivalencias;
        }
    }
}
