using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Diversificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class DiversificacionAsset_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //Consultamos la cartera para cada divisa de cada instrumento
                var parametros = DiversificacionAsset_DA.GetParametros(plantilla.CodigoIc);
                //var patrimonioTotal = Reports_DA.GetCarteraPorInstrumentoYZona(plantilla.CodigoIc, fechaInforme, null, null).Sum(s => s.efeact);
                //var patrimonioTotal = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, null, null, null, null).Sum(s => s.efeact);            

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    try
                    {
                        var patrimonioTotal = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fechaInforme);

                        //Aquí acumularemos el patrimonio en euros que mostramos
                        decimal patrimEurosMostrado = 0;
                        var patrimEuros = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, null, null, null, "EUR").Sum(s => s.efeact);

                        foreach (var instr in parametros.Parametros_Diversificacion_Instrumentos)
                        {
                            var patrimonioInstrum = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, instr.Instrumento.Codigo, null, null, null).Sum(s => s.efeact);
                            decimal patrimInstrumMostrado = 0;

                            foreach (var divisa in instr.Parametros_Diversificacion_Instrumentos_Divisas)
                            {
                                try
                                {
                                    var carteraDivisa = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, instr.Instrumento.Codigo, null, null, divisa.Instrumentos_Divisas.Codigo, true, false, false, false).Sum(s => s.efeact);
                                    patrimInstrumMostrado = patrimInstrumMostrado + carteraDivisa;

                                    if (divisa.Instrumentos_Divisas.Codigo.Equals("EUR"))
                                    {
                                        patrimEurosMostrado = patrimEurosMostrado + carteraDivisa;
                                    }
                                    var porcGrupo = Convert.ToDecimal(Utils.GetPorcentaje(carteraDivisa, patrimonioInstrum));
                                    var porcPatrim = Convert.ToDecimal(Utils.GetPorcentaje(carteraDivisa, patrimonioTotal));
                                    var tmp = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, instr.IdInstrumento, divisa.IdDivisa, divisa.Instrumentos_Divisas.Descripcion, carteraDivisa, porcGrupo, porcPatrim);
                                    listaTmp.Add(tmp);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }

                            //Para cada instrumento ademas de las divisas configuradas que tenga tenemos que incluir
                            //Emergentes
                            var emergentes = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, instr.Instrumento.Codigo, null, true).Sum(s => s.efeact);
                            var tmpEmergentes = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, instr.IdInstrumento, null, "EMERGENTES", emergentes, Convert.ToDecimal(Utils.GetPorcentaje(emergentes, patrimonioInstrum)), Convert.ToDecimal(Utils.GetPorcentaje(emergentes, patrimonioTotal)));
                            listaTmp.Add(tmpEmergentes);

                            //Otros
                            var otros = patrimonioInstrum - patrimInstrumMostrado - emergentes;
                            var tmpOtros = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, instr.IdInstrumento, null, "OTROS", otros, Convert.ToDecimal(Utils.GetPorcentaje(otros, patrimonioInstrum)), Convert.ToDecimal(Utils.GetPorcentaje(otros, patrimonioTotal)));
                            listaTmp.Add(tmpOtros);
                        }


                        //FRANCO SUIZO
                        var liq2 = Utils.CalculateFormulaCuentas("[5700014]", plantilla.CodigoIc, string.Empty, fechaInforme);
                        //DÓLAR ESTADOUNIDENSE
                        var liq3 = Utils.CalculateFormulaCuentas("[5700010]", plantilla.CodigoIc, string.Empty, fechaInforme);
                        //var liq2 = Utils.GetSaldoCuenta(plantilla.CodigoIc, isin, "5700014", fechaInforme);
                        //var liq3 = Utils.GetSaldoCuenta(plantilla.CodigoIc, isin, "5700010", fechaInforme);

                        //EURO
                        //var liq1 = patrimEuros - patrimEurosMostrado;
                        //más rápido y efectivo que patrimEurosMostrado --> hacemos lo siguiente
                        var totalMostrado = listaTmp.Where(w => w.GetType() == new Temp_Diversificacion().GetType()).Select(s => (Temp_Diversificacion)s).Sum(s => s.Patrimonio);
                        //var liq1 = patrimonioTotal - patrimEurosMostrado - liq2 - liq3;
                        var liq1 = patrimonioTotal - totalMostrado - liq2 - liq3;

                        var totalLiq = liq1 + liq2 + liq3;

                        var tmpLiq1 = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, null, null, Instrumentos_divisas_DA.GetDivisaPorCodigo("EUR").Descripcion, liq1, Convert.ToDecimal(Utils.GetPorcentaje(liq1, totalLiq)), Convert.ToDecimal(Utils.GetPorcentaje(liq1, patrimonioTotal)));
                        listaTmp.Add(tmpLiq1);
                        var tmpLiq2 = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, null, null, Instrumentos_divisas_DA.GetDivisaPorCodigo("CHF").Descripcion, liq2, Convert.ToDecimal(Utils.GetPorcentaje(liq2, totalLiq)), Convert.ToDecimal(Utils.GetPorcentaje(liq2, patrimonioTotal)));
                        listaTmp.Add(tmpLiq2);
                        var tmpLiq3 = getNuevoTemp_Diversificacion(plantilla.CodigoIc, string.Empty, null, null, Instrumentos_divisas_DA.GetDivisaPorCodigo("USD").Descripcion, liq3, Convert.ToDecimal(Utils.GetPorcentaje(liq3, totalLiq)), Convert.ToDecimal(Utils.GetPorcentaje(liq3, patrimonioTotal)));
                        listaTmp.Add(tmpLiq3);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static Temp_Diversificacion getNuevoTemp_Diversificacion(string codigoIC, string isin, string idInstrumento, int? idDivisa, string divisaDesc, decimal patrimonio, decimal porcGrupo, decimal porcP)
        {
            var tmp = new Temp_Diversificacion();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.IdInstrumento = idInstrumento;
            tmp.IdDivisa = idDivisa;
            tmp.DivisaDesc = divisaDesc;
            tmp.Patrimonio = patrimonio;
            tmp.PorcentajeGrupo = porcGrupo;
            tmp.PorcentajeP = porcP;

            return tmp;
        }

        public static Report GetReportDiversificacion(string codigoIC, string isin)
        {
            Report rep = new ReportDiversificacion();

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["ISIN"].Value = isin;
            return rep;
        }
    }
}
