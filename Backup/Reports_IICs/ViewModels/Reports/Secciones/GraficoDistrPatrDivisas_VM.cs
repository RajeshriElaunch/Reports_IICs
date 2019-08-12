using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoComposicionPatrimonio;
using System;
using System.Collections.Generic;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoDistrPatrDivisas_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    try
                    {
                        var patrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);
                        //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();                               

                        //Para los gráficos de Distribución Patrimonio no tenemos en cuenta los DERIVADOS
                        var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, true, false);
                        decimal porcPatrInsertado = 0;

                        foreach (var item in cartera)
                        {

                            //Es el peso del EfectivoActual en el EfectivoActual Total
                            //OJO: NO COGER TPC1 --> VIENE MAL
                            //var porcCart = Utils.GetPorcentaje(item.efeact, cartera.Sum(s => s.efeact));
                            var grafTemp = getNuevoTemp_GraficoCompPatrimonioDivisas(plantilla.CodigoIc, null, item.div, item.TPC2);
                            if (item.TPC2 != null)
                            {
                                porcPatrInsertado = porcPatrInsertado + Convert.ToDecimal(item.TPC2);
                            }
                            listaTmp.Add(grafTemp);
                        }

                        //Tenemos que insertar también las cuentas de tesorería, que no vienen en el procedimiento
                        var ctasTesorNoEur = GraficoDistrPatrDivisas_DA.GetCtasTesorNoEur();
                        foreach (var cta in ctasTesorNoEur)
                        {
                            var saldoCta = Utils.CalculateFormulaCuentas("[" + cta.NumeroCuenta + "]", plantilla.CodigoIc, null, fecha);
                            if (saldoCta != 0)
                            {
                                var tpc = saldoCta * 100 / patrimonio;
                                var grafTemp = getNuevoTemp_GraficoCompPatrimonioDivisas(plantilla.CodigoIc, null, cta.Divisa, tpc);
                                porcPatrInsertado = porcPatrInsertado + tpc;
                                listaTmp.Add(grafTemp);
                            }
                        }

                        //Calculamos la tesorería por diferencia
                        if (porcPatrInsertado < 100)
                        {
                            var porcTesoreriaEuros = 100 - porcPatrInsertado;
                            var grafTemp = getNuevoTemp_GraficoCompPatrimonioDivisas(plantilla.CodigoIc, null, "EUR", porcTesoreriaEuros);
                            listaTmp.Add(grafTemp);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}

                //Reports_DA.Insert_Temp_GraficoCompCarteraDivisas(plantilla.CodigoIc, lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoCompPatrimonioDivisas getNuevoTemp_GraficoCompPatrimonioDivisas(string codigoIC, string isin, string divisa, decimal? porcentajePatr)
        {
            Temp_GraficoCompPatrimonioDivisas tmpGraf = new Temp_GraficoCompPatrimonioDivisas();

            tmpGraf.CodigoIC = codigoIC;
            tmpGraf.Isin = isin;
            tmpGraf.Divisa = divisa;
            tmpGraf.Patrimonio = Convert.ToDecimal(porcentajePatr);

            return tmpGraf;
        }

        //public static Report GetReportGraficosComposicionCarteraDivisas(string codigoIC, string isin, string isinDesc, DateTime fecha)
        //{
        //    Report rep = new ReportGraficoCompCarteraDivisas(isinDesc, codigoIC);

        //    rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    rep.ReportParameters["Isin"].Value = isin;
        //    // rep.ReportParameters["Fecha"].Value = fecha;

        //    return rep;
        //}

        public static Report GetReportGraficosComposicionPatrimonioDivisas(string codigoIC, string isin, string isinDesc, DateTime fecha, decimal? porcentajeTotal)
        {
            /*
            Report rep = new Report_BARS_GraficoCompPatrimonioDivisas(isinDesc, codigoIC, porcentajeTotal);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            // rep.ReportParameters["Fecha"].Value = fecha;
            rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
            return rep;
            */

            Report rep = new ReportGraficoCompPatrimonioDivisas(isinDesc, codigoIC);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            // rep.ReportParameters["Fecha"].Value = fecha;

            return rep;

        }
    }
}
