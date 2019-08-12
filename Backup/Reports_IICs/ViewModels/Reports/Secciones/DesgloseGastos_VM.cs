using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.DesgloseGastos;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class DesgloseGastos_VM
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var cuentas = DesgloseGastos_DA.GetCuentas();
                decimal comFija, comFijaPagada, comVariable, comDepositario, gastosTasaRegistrosOficiales, gastosAdmisionCotizacionBolsa,
                    gastosDiferenciaPeriodificaciones, gastosBancarios, gastosRegistroLibroAccionistas, auditoriaCuentas, otros,
                    impuestoSobreSociedades, patrimonioFechaInf;

                //la com. fija pagada es un parámetro de la sección

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                var fechaIni = Utils.GetFechaInicio(plantilla, fechaInforme, typeof(Temp_DesgloseGastos));

                bool creadaAñoInf = Utils.CreadaAñoInforme(plantilla, fechaInforme);
                if (creadaAñoInf)
                {
                    comFija = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnComisionFija, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    comFijaPagada = DesgloseGastos_DA.GetComisionFijaPagada(plantilla.CodigoIc);
                    comVariable = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnComisionVariable, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    comDepositario = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnComisionDepositario, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    gastosTasaRegistrosOficiales = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnGastosTasaRegistrosOficiales, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    gastosAdmisionCotizacionBolsa = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnGastosAdmisionCotizacionBolsa, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    gastosDiferenciaPeriodificaciones = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnGastosDiferenciaPeriodificaciones, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    gastosBancarios = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnGastosBancarios, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    gastosRegistroLibroAccionistas = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnGastosRegistroLibroAccionistas, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    auditoriaCuentas = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnAuditoriaCuentas, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    otros = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnOtros, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    impuestoSobreSociedades = Utils.CalculateFormulaCuentasAcumulado(cuentas.FnImpuestoSobreSociedades, plantilla.CodigoIc, null, fechaIni, fechaInforme);
                    patrimonioFechaInf = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fechaInforme);
                }
                else
                {
                    comFija = Utils.CalculateFormulaCuentas(cuentas.FnComisionFija, plantilla.CodigoIc, null, fechaInforme);
                    comFijaPagada = DesgloseGastos_DA.GetComisionFijaPagada(plantilla.CodigoIc);
                    comVariable = Utils.CalculateFormulaCuentas(cuentas.FnComisionVariable, plantilla.CodigoIc, null, fechaInforme);
                    comDepositario = Utils.CalculateFormulaCuentas(cuentas.FnComisionDepositario, plantilla.CodigoIc, null, fechaInforme);
                    gastosTasaRegistrosOficiales = Utils.CalculateFormulaCuentas(cuentas.FnGastosTasaRegistrosOficiales, plantilla.CodigoIc, null, fechaInforme);
                    gastosAdmisionCotizacionBolsa = Utils.CalculateFormulaCuentas(cuentas.FnGastosAdmisionCotizacionBolsa, plantilla.CodigoIc, null, fechaInforme);
                    gastosDiferenciaPeriodificaciones = Utils.CalculateFormulaCuentas(cuentas.FnGastosDiferenciaPeriodificaciones, plantilla.CodigoIc, null, fechaInforme);
                    gastosBancarios = Utils.CalculateFormulaCuentas(cuentas.FnGastosBancarios, plantilla.CodigoIc, null, fechaInforme);
                    gastosRegistroLibroAccionistas = Utils.CalculateFormulaCuentas(cuentas.FnGastosRegistroLibroAccionistas, plantilla.CodigoIc, null, fechaInforme);
                    auditoriaCuentas = Utils.CalculateFormulaCuentas(cuentas.FnAuditoriaCuentas, plantilla.CodigoIc, null, fechaInforme);
                    otros = Utils.CalculateFormulaCuentas(cuentas.FnOtros, plantilla.CodigoIc, null, fechaInforme);
                    impuestoSobreSociedades = Utils.CalculateFormulaCuentas(cuentas.FnImpuestoSobreSociedades, plantilla.CodigoIc, null, fechaInforme);
                    patrimonioFechaInf = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fechaInforme);
                }

                var tmp = getNuevoTemp_VariacionPatrimonialB(plantilla, null, comFija, comFijaPagada, comVariable, comDepositario, gastosTasaRegistrosOficiales, gastosAdmisionCotizacionBolsa, gastosDiferenciaPeriodificaciones, gastosBancarios, gastosRegistroLibroAccionistas, auditoriaCuentas, otros, impuestoSobreSociedades, patrimonioFechaInf);
                listaTmp.Add(tmp);
                //}
            }
            catch (Exception ex)
            {
                Log.Error("Error DesgloseGastos_VM/Insert_Temp", ex);
                throw;
            }
        }

        private static decimal getDiferenciaSaldoCuenta(string codigoIC, string isin, string cuenta, DateTime fechaInforme)
        {
            var fechaAñoAnt = new DateTime(fechaInforme.Year - 1, 12, 31);
            var saldoFechaAñoAnt = Utils.CalculateFormulaCuentas(cuenta, codigoIC, isin, fechaAñoAnt);
            var saldoFechaInf = Utils.CalculateFormulaCuentas(cuenta, codigoIC, isin, fechaInforme);

            return saldoFechaInf - saldoFechaAñoAnt;
        }

        private static Temp_DesgloseGastos getNuevoTemp_VariacionPatrimonialB(Plantilla plantilla, string isin, decimal comFija, decimal comFijaPagada, decimal comVariable, decimal comDepositario, decimal gastosTasaRegistrosOficiales, decimal gastosAdmisionCotizacionBolsa, decimal gastosDiferenciaPeriodificaciones, decimal gastosBancarios, decimal gastosRegistroLibroAccionistas, decimal auditoriaCuentas, decimal otros, decimal impuestoSobreSociedades, decimal patrimonioFechaInf)
        {
            Temp_DesgloseGastos tmp = new Temp_DesgloseGastos();

            tmp.CodigoIC = plantilla.CodigoIc;
            tmp.Isin = isin;

            var param = plantilla.Parametros_VariacionPatrimonialB.FirstOrDefault();
            tmp.ComFijaPagada = comFijaPagada;
            tmp.ComFijaDevengada = decimal.Round(comFija - comFijaPagada, 0);
            tmp.ComVariable = comVariable;
            tmp.ComDepositario = comDepositario;
            tmp.GastosTasaRegistrosOficiales = gastosTasaRegistrosOficiales;
            tmp.GastosAdmisionCotizacionBolsa = gastosAdmisionCotizacionBolsa;
            tmp.GastosDiferenciaPeriodificaciones = gastosDiferenciaPeriodificaciones;
            tmp.GastosBancarios = gastosBancarios;
            tmp.GastosRegistroLibroAccionistas = gastosRegistroLibroAccionistas;
            tmp.AuditoriaCuentas = auditoriaCuentas;
            tmp.Otros = otros;
            tmp.ImpuestoSobreSociedades = impuestoSobreSociedades;
            tmp.PatrimonioFechaInforme = patrimonioFechaInf;

            return tmp;
        }

        public static string Validar(string codigoIC)
        {
            string resultado = validarFijaPagada(codigoIC);

            return resultado;
        }

        private static string validarFijaPagada(string codigoIC)
        {
            string resultado = null;

            //El parámetro de comisión fija pagada puede que tenga que ser distinto cada generación/mes 
            //Si en la configuración de esta sección han marcado el check que indica que este parámetro es necesario
            //mostraremos la alerta para que el usuario sea consciente que es posible que tenga que actualizar su valor
            var needed = DesgloseGastos_DA.HasComisionFijaPagada(codigoIC);

            if (needed)
            {
                resultado += Environment.NewLine;
                resultado += Resource.AlertaVarPatrBFijaPagada;
            }

            return resultado;
        }


        public static Report GetReport(string codigoIC, int idSeccion, string isin, DateTime fechainforme)
        {            
            Report rep = new ReportDesgloseGastos(codigoIC, idSeccion, isin, fechainforme);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["FechaInforme"].Value = fechainforme;
            rep.ReportParameters["IdSeccion"].Value = idSeccion;
            return rep;
        }
    }
}
