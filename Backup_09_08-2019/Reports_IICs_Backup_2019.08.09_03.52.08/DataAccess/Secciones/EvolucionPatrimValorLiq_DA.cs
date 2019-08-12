using Reports_IICs.DataModels;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class EvolucionPatrimValorLiq_DA
    {
        //public static void Insert_Temp(Plantilla plantilla, List<Temp_EvolucionPatrValLiq> listaTemp)
        //{
        //    using (var dbContext = new Reports_IICSEntities())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_EvolucionPatrValLiq.RemoveRange(dbContext.Temp_EvolucionPatrValLiq.Where(p => p.CodigoIc == plantilla.CodigoIc));

        //            dbContext.Temp_EvolucionPatrValLiq.AddRange(listaTemp);
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        public static double? GetValorLiqFechaInforme(string codigoIC, DateTime fechaInforme)
        {
            var dbContext = new Reports_IICSEntities();
            var obj = dbContext.Temp_EvolucionPatrGuissonaValLiq.Where(e => e.CodigoIc == codigoIC && e.Fecha == fechaInforme).FirstOrDefault();

            if (obj != null)
            {
                var valLiq = obj.ValorLiquidativo;
                return Convert.ToDouble(valLiq);
            }
            else
            {
                return null;
            }
        }

        
    }
}
