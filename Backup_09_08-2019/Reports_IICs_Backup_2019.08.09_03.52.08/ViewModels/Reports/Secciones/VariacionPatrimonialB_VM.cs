using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class VariacionPatrimonialB_VM
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var cuentas = VariacionPatrimonial_DA.GetCuentas();

                //Variables que utilizaremos para calcular los totales
                decimal? varPrecAcum = 0;
                decimal? ingFinAcum = 0;
                decimal? otrRendAcum = 0;
                decimal? varPrecTotRend = 0;
                decimal? ingFinTotRend = 0;
                decimal? otrRendTotRend = 0;

                foreach (var cuenta in cuentas)
                {
                    var prueba = Utils.CalculateFormulaCuentasSignoCambiado(cuenta.CuentasVariacionPrecios, plantilla.CodigoIc, null, fechaInforme);
                    var tmp = new Temp_VariacionPatrimonialB()
                    {
                        CodigoIC = plantilla.CodigoIc,
                        Descripcion = cuenta.Descripcion,
                        VariacionPrecios = cuenta.CuentasVariacionPrecios != null ? Utils.CalculateFormulaCuentasSignoCambiado(cuenta.CuentasVariacionPrecios, plantilla.CodigoIc, null, fechaInforme) : 0,
                        IngresosFinancieros = cuenta.CuentasIngresosFinancieros != null ? Utils.CalculateFormulaCuentasSignoCambiado(cuenta.CuentasIngresosFinancieros, plantilla.CodigoIc, null, fechaInforme) : 0,
                        OtrosRendimientos = cuenta.CuentasOtrosRendimientos != null ? Utils.CalculateFormulaCuentasSignoCambiado(cuenta.CuentasOtrosRendimientos, plantilla.CodigoIc, null, fechaInforme) : 0
                    };

                    if (!tmp.Descripcion.Trim().Equals("TOTAL RENDIMIENTOS", StringComparison.CurrentCultureIgnoreCase))
                    {
                        varPrecAcum += tmp.VariacionPrecios;
                        ingFinAcum += tmp.IngresosFinancieros;
                        otrRendAcum += tmp.OtrosRendimientos;
                    }
                    else
                    {
                        varPrecTotRend = tmp.VariacionPrecios;
                        ingFinTotRend = tmp.IngresosFinancieros;
                        otrRendTotRend = tmp.OtrosRendimientos;
                    }
                    listaTmp.Add(tmp);
                }

                //Se calcula: TOTAL RENDIMIENTOS - Sumatorio del resto
                var tmpOtros = new Temp_VariacionPatrimonialB()
                {
                    CodigoIC = plantilla.CodigoIc,
                    Descripcion = "OTROS",
                    VariacionPrecios = varPrecTotRend - varPrecAcum,
                    IngresosFinancieros = ingFinTotRend - ingFinAcum,
                    OtrosRendimientos = otrRendTotRend - otrRendAcum
                };

                listaTmp.Add(tmpOtros);
                //OTROS se calcula por diferencia. Necesitamos el resto de datos para poder calcular OTROS   

            }
            catch (Exception ex)
            {
                Log.Error("Error VariacionPatrimonialB_VM/Insert_Temp", ex);
                throw;
            }
        }

        public static string Validar(string codigoIC, Seccione seccion, DateTime fecha)
        {
            try
            {
                string resultado = null;

                resultado += validarTotales(codigoIC, seccion);

                return resultado;
            }
            catch (Exception ex)
            {
                Log.Error("Error VariacionPatrimonialB_VM/Validar", ex);
                throw;
            }
        }

        private static string validarTotales(string codigoIC, Seccione seccion)
        {
            string resultado = null;
            //decimal colTotal = 0;
            //decimal filaTotalRendimientos = 0;

            //Como la recuperación de datos para esta sección funciona de forma distinta para cada línea
            //Vamos a ir haciendo los cálculos por partes
            //Para calcular la colTotal tenemos que sumar TotalPrecios + TotalIngresos + Otros para cada instrumento
            //pero no todos los datos están en la misma línea siempre

            var temp = VariacionPatrimonialB_DA.GetTemp(codigoIC);

            //Todos los que no son "TOTAL RENDIMIENTOS"
            decimal totalCol = 0;
            var cols = temp.Where(w => !Utils.EqualsIgnoreCase(w.Descripcion, "TOTAL RENDIMIENTOS")).ToList();
            if (cols != null)
            {
                totalCol = cols.Sum(s => s.VariacionPrecios ?? 0 + s.IngresosFinancieros ?? 0 + s.OtrosRendimientos ?? 0);
            }

            //La fila "TOTAL RENDIMIENTOS"
            decimal totalFila = 0;
            var fila = temp.Where(w => Utils.EqualsIgnoreCase(w.Descripcion, "TOTAL RENDIMIENTOS")).FirstOrDefault();
            if (fila != null)
            {
                totalFila = fila.VariacionPrecios ?? 0 + fila.IngresosFinancieros ?? 0 + fila.OtrosRendimientos ?? 0;
            }

            //Comprobamos si existe diferencia entre colTotal y filaTotalRendimientos
            var diferencia = totalCol - totalFila;
            //Si no coinciden tenemos que mostrar alerta
            if (decimal.Round(diferencia, 2) != 0)
            {
                try
                {
                    resultado += Environment.NewLine;
                    //var aaa = string.Format("aaaaa {0:N2}", diferencia);
                    resultado += string.Format(Resource.AlertaVarPatrADescuadreColTotalFilaTotal, Math.Abs(diferencia));
                }
                catch (Exception ex)
                {
                    Log.Error("Error VariacionPatrimonialA_VM/validarTotales", ex);
                    throw;
                }
            }
            
            return resultado;
        }

        public static Temp_VariacionPatrimonialB getTemp(List<Temp_VariacionPatrimonialB> temp, string descripcion)
        {
            return temp.Where(w => Utils.EqualsIgnoreCase(w.Descripcion, descripcion)).FirstOrDefault();
        }
    }
}
