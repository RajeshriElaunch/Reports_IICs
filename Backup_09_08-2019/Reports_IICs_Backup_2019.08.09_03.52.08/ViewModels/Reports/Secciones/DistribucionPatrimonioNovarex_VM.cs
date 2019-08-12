using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.DistribucionPatrimonioNovarex;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class DistribucionPatrimonioNovarex_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                #region cartera       
                //var pro = Reports_DA.GetPRO11(plantilla.CodigoIc, fechaInforme).ToList();            
                //var proRF = Reports_DA.GetPRO11_RF(plantilla.CodigoIc, fechaInforme).ToList();
                //var proRV = Reports_DA.GetPRO11_RV(plantilla.CodigoIc, fechaInforme).ToList();

                //No tenemos en cuenta los DERIVADOS para esta sección
                var proSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, null, null, null, null, false, false, true, false).ToList();
                var proRvSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "RVA", null, null, null, false, false, true, false).ToList();
                var proRfSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "RFI", null, null, null, false, false, true, false).ToList();

                var repoDeuda = proSinDer.Where(w => w.tipo.Equals("MM") && w.mercado.Equals("REPOR")).Sum(s => s.efeact);

                var efeActPro = proSinDer.Sum(s => s.efeact);
                var efeActProRF = proRfSinDer.Sum(s => s.efeact);
                var efeActProRV = proRvSinDer.Sum(s => s.efeact);
                var retornoAbsolutoSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "RAB", null, null, null, false, false, true, false).Sum(s => s.efeact);
                var rab = proSinDer.Where(w => w.tipo.Equals("MM") && w.mercado.Equals("REPOR")).Sum(s => s.efeact);

                var garantizadosEstructuradosSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "GAR", null, null, null, false, false, true, false).Sum(s => s.efeact);
                //Reunión 08-08-2016 - No mostramos ni divisas ni commodities
                //var divisas = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "DIV", null, null, null).Sum(s => s.efeact);
                //var commodities = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "COM", null, null, null).Sum(s => s.efeact);

                //var otrosSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "OTR", null, null, null, false, false, true).Sum(s => s.efeact);
                //Ahora la línea OTROS englobara aquella parte de la cartera que NO fuera Derivados (Tipo=DER) y que fuera Instrumento = DIV + COM+OTR+RFM+RVM+GBL 
                var listOtros = new List<string> { "DIV", "COM", "OTR", "RFM", "RVM", "GLO" };
                var otrosSinDer = Reports_DA.GetCarteraFiltrada2(plantilla, fechaInforme, listOtros, null, null, false, false, true, true).Sum(s => s.efeact);

                //var totalCartera = efeActProRV + repoDeuda + efeActProRF + retornoAbsoluto + garantizadosEstructurados + divisas + commodities + otros;
                var totalCartera = efeActProRV + repoDeuda + efeActProRF + retornoAbsolutoSinDer + garantizadosEstructuradosSinDer + otrosSinDer;

                #endregion cartera

                #region tesoreria

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fechaInforme);

                    //Cuenta 57
                    var cta57 = Utils.CalculateFormulaCuentas("[57]", plantilla.CodigoIc, string.Empty, fechaInforme);

                    var tmpCartera = getNuevoTemp_DistribucionPatrimonioNovarex_Cartera(plantilla.CodigoIc, efeActProRV, repoDeuda, efeActProRF, retornoAbsolutoSinDer, garantizadosEstructuradosSinDer, otrosSinDer, totalPatrimonio);
                    listaTmp.Add(tmpCartera);

                    //Recorrer también para cada parámetro. Habra que hacer la cuenta de la fórmula guardada en el 
                    //parametro y llamar al pro06 para cada cuenta que haya en los parametros
                    var tes = DistribucionPatrimonioNovarex_DA.GetCuentasTesoreriaDepositos(plantilla.CodigoIc);

                    decimal totalTesoreria = 0;
                    foreach (var item in tes)
                    {
                        var result = Utils.CalculateFormulaCuentas(item.Formula, plantilla.CodigoIc, string.Empty, fechaInforme);
                        if (result > 0)
                        {
                            var tmpTesoreria = getNuevoTemp_DistribucionPatrimonioNovarex_Tesoreria(plantilla.CodigoIc, item.Descripcion, result, totalPatrimonio);
                            listaTmp.Add(tmpTesoreria);
                            totalTesoreria = totalTesoreria + result;
                        }
                    }

                    //Cuentas pendientes de liquidar
                    //var ctasPtesLiq = totalPatrimonio - totalCartera - cta57;
                    var ctasPtesLiq = totalPatrimonio - totalCartera - totalTesoreria;
                    var tmpTesoreriaCtasPtesLiq = getNuevoTemp_DistribucionPatrimonioNovarex_Tesoreria(plantilla.CodigoIc, "CUENTAS PENDIENTES DE LIQUIDAR", ctasPtesLiq, totalPatrimonio);
                    listaTmp.Add(tmpTesoreriaCtasPtesLiq);
                //}

                #endregion tesoreria

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Report GetReport_Temp_DistribucionPatrimonioNovarex(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new Report_DistribucionPatrimonioNovarex();
            //rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;

            return rep;
        }
        private static Temp_DistribucionPatrimonioNovarex_Cartera getNuevoTemp_DistribucionPatrimonioNovarex_Cartera(string codigoIC, decimal rv, decimal repo, decimal rf,
            decimal retornoAbsoluto, decimal garantizadosEstructurados, decimal otros, decimal totalPatrimonio)
        {
            Temp_DistribucionPatrimonioNovarex_Cartera tmp = new Temp_DistribucionPatrimonioNovarex_Cartera();

            tmp.CodigoIC = codigoIC;
            tmp.RentaVariable = rv;
            tmp.RentaVariablePorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(rv, totalPatrimonio)), 3);
            tmp.RepoDeuda = repo;
            tmp.RepoDeudaPorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(repo, totalPatrimonio)), 3);
            tmp.RentaFija = rf;
            tmp.RentaFijaPorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(rf, totalPatrimonio)), 3);
            tmp.RetornoAbsoluto = retornoAbsoluto;
            if (retornoAbsoluto > 0)
                tmp.RetornoAbsolutoPorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(retornoAbsoluto, totalPatrimonio)), 3);
            tmp.GarantizadosEstructurados = garantizadosEstructurados;
            if (garantizadosEstructurados > 0)
                tmp.GarantizadosEstructuradosPorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(garantizadosEstructurados, totalPatrimonio)), 3);
            //tmp.Divisas = divisas;
            //if (divisas > 0)
            //    tmp.DivisasPorc = decimal.Round(Utils.GetPorcentaje(divisas, totalPatrimonio), 3);
            //tmp.Commodities = commodities;
            //if (commodities > 0)
            //    tmp.CommoditiesPorc = decimal.Round(Utils.GetPorcentaje(commodities, totalPatrimonio), 3);
            tmp.Otros = otros;
            if (otros > 0)
                tmp.OtrosPorc = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(otros, totalPatrimonio)), 3);

            tmp.TotalPatrimonio = totalPatrimonio;

            return tmp;
        }

        private static Temp_DistribucionPatrimonioNovarex_Tesoreria getNuevoTemp_DistribucionPatrimonioNovarex_Tesoreria(string codigoIC, string descripcion, decimal patrimonio, decimal totalPatrimonio)
        {
            Temp_DistribucionPatrimonioNovarex_Tesoreria tmp = new Temp_DistribucionPatrimonioNovarex_Tesoreria();

            tmp.CodigoIC = codigoIC;
            tmp.Descripcion = descripcion;
            tmp.Patrimonio = patrimonio;
            tmp.PorcentajePatrimonio = decimal.Round(Convert.ToDecimal(Utils.GetPorcentaje(patrimonio, totalPatrimonio)), 3);

            return tmp;
        }

    }
}
