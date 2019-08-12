using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoComposicionPatrimonio;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoDistrExpoMercDivisas_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_GraficoCompPatrimonioDivisas> listaTmp = new List<Temp_GraficoCompPatrimonioDivisas>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    //No mostramos derivados
                    //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).Where(w=>!w.tipo.Equals("DE")).ToList();
                    //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();

                    //Para los gráficos de Distribución Exposición Mercado no tenemos en cuenta los instrumentos MMO
                    var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, false, true);
                    var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);

                    //No queremos Mercado Monetario / Liquidez (IdInstrumento = 4)
                    var instrumentosMMOLiq = VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("MMO")).Select(s => s.ISIN.ToUpper()).ToList();
                    cartera = cartera.Where(p => !instrumentosMMOLiq.Contains(p.isin.ToUpper())).ToList();

                    var isins = cartera.Select(s => s.isin.ToUpper()).ToList();

                    foreach (var item in cartera)
                    {
                        //var grafTemp = getNuevoTemp_GraficoExposMercDivisas(plantilla.CodigoIc, isin.Isin, item.div, item.TPC2);
                        var grafTemp = getNuevoTemp_GraficoExposMercDivisas(plantilla.CodigoIc, null, item.div, item.efeact*100/totalPatrimonio);
                        listaTmp.Add(grafTemp);
                    }

                    //04/05/2017 - Jaume - ahora no tiene que llegar al 100%
                    //Nos aseguramos que llega al 100% y si no, insertamos la diferencia
                    //var totalPatr = cartera.Sum(s => s.TPC2);
                    //if (totalPatr < 100)
                    //{
                    //    var diferencia = 100 - totalPatr;
                    //    var grafTemp = getNuevoTemp_GraficoExposMercDivisas(plantilla.CodigoIc, isin.Isin, "OTROS", diferencia);
                    //    listaTmp.Add(grafTemp);
                    //}
                //}

                //Reports_DA.Insert_Temp_GraficoCompPatrimonioDivisas(plantilla.CodigoIc, lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoExposMercDivisas getNuevoTemp_GraficoExposMercDivisas(string codigoIC, string isin, string divisa, decimal? porcentajePatrimonio)
        {
            Temp_GraficoExposMercDivisas tmpGraf = new Temp_GraficoExposMercDivisas();            

            tmpGraf.CodigoIC = codigoIC;
            tmpGraf.Isin = isin;
            tmpGraf.Divisa = divisa;
            tmpGraf.PorcentajePatrimonio = porcentajePatrimonio;

            return tmpGraf;
        }

        //public static Report GetReportGraficosComposicionPatrimonioDivisas(string codigoIC, string isin, string isinDesc, DateTime fecha)
        //{
        //    Report rep = new ReportGraficoCompPatrimonioDivisas(isinDesc, codigoIC);

        //    rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    rep.ReportParameters["Isin"].Value = isin;
        //    // rep.ReportParameters["Fecha"].Value = fecha;

        //    return rep;
        //}

        public static Report GetReportGraficosComposicionPatrimonioDivisas(string codigoIC, string isin, string isinDesc, DateTime fecha, decimal? porcentajeTotal)
        {
            
            Report rep = new Report_BARS_GraficoCompPatrimonioDivisas(isinDesc, codigoIC, porcentajeTotal);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            // rep.ReportParameters["Fecha"].Value = fecha;
            rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
            return rep;
            

        }

    }
}
