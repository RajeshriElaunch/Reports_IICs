using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class VariacionPatrimonialA_DA
    {
        public static decimal? GetDescuadrePrecios(string codigoIC)
        {
            decimal? resultado = null;

            var dbContext = new Reports_IICSEntities();
            var tempOtros = dbContext.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == codigoIC && w.CodsInstrumento == "OTROS");

            if (tempOtros != null)
            {
                resultado = tempOtros.TotalPrecios;
            }

            return resultado;
        }

        //test ACC 01/04/2019 start-----------------------------------------------------
               
            public static decimal? GetPatrimonioIni(string codigoIC)
            {
                decimal? resultado = null;

                var dbContext = new Reports_IICSEntities();
                var tempPatrAnt = dbContext.Temp_VariacionPatrimonialA_Totales.FirstOrDefault(w => w.CodigoIC == codigoIC);

                if (tempPatrAnt != null)
                {
                    resultado = tempPatrAnt.TotalPatrimonioAnt;
                }

                return resultado;
            }
            //test ACC 01/04/2019 end-----------------------------------------------------
            public static List<Temp_VariacionPatrimonialA> GetTemp(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_VariacionPatrimonialA.Where(w => w.CodigoIC == codigoIC).ToList();            
        }

        public static List<VariacionPatrimonialA_Cuentas> GetCuentas(bool esFondo)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.VariacionPatrimonialA_Cuentas.Where(w => w.EsFondo == esFondo).ToList();
        }

        public static decimal GetSuscripcionesAmpliaciones(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var obj = dbContext.Temp_VariacionPatrimonialA_Totales.FirstOrDefault(w => w.CodigoIC == codigoIC);

            decimal output = 0;
            if (obj != null)
            {
                output = obj.SuscripcionesAmpliaciones;
            }

            return output;
        }

        /// <summary>
        /// Devuelve el total patrimonio del año anterior insertado en su tabla temporal
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <returns></returns>
        public static decimal GetTotalPatrimonioAnt(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            var obj = dbContext.Temp_VariacionPatrimonialA_Totales.FirstOrDefault(w => w.CodigoIC == codigoIC);

            decimal output = 0;
            if (obj != null)
            {
                output = obj.TotalPatrimonioAnt;
            }

            return output;
        }

        public static decimal GetTotalIngresosFinancierosRV(string codigoIC)
        {
            decimal output = 0;
            
            var dbContext = new Reports_IICSEntities();
            var total = dbContext.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == codigoIC 
                                                    && w.CodsInstrumento== "RENTA VARIABLE"
                                                    && w.CodsTipoInstrumento == null
                                                    && w.CodsCategoria== null
                                                    && w.CodsEmpresa == null);

            if (total?.TotalIngresos != null)
                output = (decimal)total.TotalIngresos;
            

            return output;
        }

        public static Get_VariacionPatrimonialA_Totales_Result Get_VariacionPatrimonialA_Totales(string codigoIC)
        {
            try
            {
                var dbContext = new Reports_IICSEntities();
                var totales = dbContext.Get_VariacionPatrimonialA_Totales(codigoIC);
                return totales.FirstOrDefault();
            }
            catch (System.Exception )
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                //Log.Error("Error VariacionPatrimonialA_DA/Get_VariacionPatrimonialA_Totales_Result", ex);
                // Compliance                                           
                throw;
            }
        }
    }
}
