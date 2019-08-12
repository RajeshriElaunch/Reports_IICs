using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class DesgloseGastos_DA
    {
        public static DesgloseGastos_Cuentas GetCuentas()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.DesgloseGastos_Cuentas.FirstOrDefault();
        }

        public static decimal GetComisionFijaPagada(string codigoIC)
        {
            decimal result = 0;
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var comFijaPagada = dbContext.Parametros_VariacionPatrimonialB.Where(w => w.CodigoIC == codigoIC).Select(s => s.ComisionFijaPagada).FirstOrDefault();
            if(comFijaPagada != null)
            {
                result = Convert.ToDecimal(comFijaPagada);
            }

            return result;
        }

        public static bool HasComisionFijaPagada(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var comFijaPagada = dbContext.Parametros_VariacionPatrimonialB.Where(w => w.CodigoIC == codigoIC).Select(s => s.ComisionFijaPagada).FirstOrDefault();
            if (comFijaPagada != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
