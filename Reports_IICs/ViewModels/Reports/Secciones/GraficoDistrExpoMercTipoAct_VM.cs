using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoComposicionPatrimonio;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoDistrExpoMercTipoAct_VM
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var listaGrafCompPatrimonioTipoActtemp = new List<Temp_GraficoExposMercTipoActivo>();
                //listaTmp será la lista definitiva (agrupada) que se guardará en la tabla temporal
                //var listaDefinitiva = new List<Temp_GraficoCompPatrimonioTipoActivo>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).Where(w => !w.tipo.Equals("DE"));
                    //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha);

                    //Para los gráficos de Distribución Exposición Mercado no tenemos en cuenta los instrumentos MMO
                    var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, false, true);

                var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);

                //Hacemos este foreach porque el tipo de activo que nos sirve para realizar las operaciones es el que tenemos en 
                //instrumentos importados, no el que viene del procedimiento
                foreach (var item in cartera)
                    {
                        //Recuperamos la información del instrumento de pro11
                        var instr = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(item.isin);
                        if (instr != null)
                        {
                            //var graficoCompPatrimonioTipoActTemp = getNuevoTemp_GraficoExposMercTipoActivo(plantilla.CodigoIc, isin.Isin, instr.Instrumento.Id, instr.Instrumento.Descripcion, item.TPC2);
                            var graficoCompPatrimonioTipoActTemp = getNuevoTemp_GraficoExposMercTipoActivo(plantilla.CodigoIc, null, instr.Instrumento.Id, instr.Instrumento.Descripcion, item.efeact * 100 / totalPatrimonio);
                            listaGrafCompPatrimonioTipoActtemp.Add(graficoCompPatrimonioTipoActTemp);
                        }
                        else
                        {
                            log.Error("Error Instrumento no encontrado para el isin: " + item.isin);
                        }
                    }

                    ////Calculos
                    var instrPorTipoActivo = listaGrafCompPatrimonioTipoActtemp.GroupBy(g => g.IdInstrumento);
                    decimal porcPatrTiposNoMM = 0;
                    //Hacemos los cálculos del % Patrimonio para todos los tipos menos para MM: Mercado Monetario
                    foreach (var tipoAct in instrPorTipoActivo)
                    {
                        //El porcentaje de patrimonio viene calculado, sólo tenemos que sumarlo
                        //En el caso de MM: Mercado Monetario el cálculo será la diferencia entre la suma 
                        //del porcentaje del resto de tipos y el 100%
                        if (tipoAct.Where(t => !t.IdInstrumento.Equals(Resource.MMOLiq)).Count() > 0)
                        {
                            var porcPatr = tipoAct.Sum(s => s.PorcentajePatrimonio);
                            //porcPatr = decimal.Round(porcPatr, 0);
                            var descInstr = tipoAct.Select(s => s.IdInstrumento).FirstOrDefault();
                            var desdcTipoInstr = tipoAct.Select(s => s.TipoActivo).FirstOrDefault();
                            var definitivoPorTipoActivo = getNuevoTemp_GraficoExposMercTipoActivo(plantilla.CodigoIc, null, descInstr, desdcTipoInstr, porcPatr);
                            if (definitivoPorTipoActivo.PorcentajePatrimonio != 0)
                            {
                                listaTmp.Add(definitivoPorTipoActivo);
                                porcPatrTiposNoMM += porcPatr;
                            }
                        }
                    }
                    /*
                    //Ahora calculamos el % Patrimonio para MM: Mercado Monetario
                    var porcPatrMM = 100 - porcPatrTiposNoMM;
                    var descTipoActivoMM = Resource.MMO;
                    var definitivoMM = getNuevoTemp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, isin, descTipoActivoMM, porcPatrMM);
                    if (definitivoMM.PorcentajePatrimonio != 0)
                    {
                        listaTmp.Add(definitivoMM);
                    }
                    */
                //}

                //listaDefinitiva = listaDefinitiva.OrderBy(l => l.PorcentajePatrimonio).ToList();
                //Reports_DA.Insert_Temp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, listaDefinitiva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoExposMercTipoActivo getNuevoTemp_GraficoExposMercTipoActivo(string codigoIC, string isin, string idInstrumento, string descTipoInstrumento, decimal? porcentajePatrimonio)
        {
            Temp_GraficoExposMercTipoActivo tmpGraf = new Temp_GraficoExposMercTipoActivo();

            tmpGraf.CodigoIC = codigoIC;
            tmpGraf.Isin = isin;
            tmpGraf.IdInstrumento = idInstrumento;
            tmpGraf.TipoActivo = descTipoInstrumento;
            tmpGraf.PorcentajePatrimonio = Convert.ToDecimal(porcentajePatrimonio);

            return tmpGraf;
        }

        public static Report GetReportGraficosComposicionPatrimonioTipoActivo(string codigoIC, string isin, string isinDesc, DateTime fecha, decimal? porcentajeTotal)
        {
            Report rep = new Report_BARS_CompPatrimonioTipoActivo(isinDesc, codigoIC, porcentajeTotal);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            //rep.ReportParameters["Fecha"].Value = fecha;
            rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
            return rep;
        }

        //public static Report GetReportGraficosComposicionPatrimonioTipoActivo(string codigoIC, string isin, string isinDesc, DateTime fecha)
        //{
        //    Report rep = new ReportCompPatrimonioTipoActivo(isinDesc, codigoIC);

        //    rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    rep.ReportParameters["Isin"].Value = isin;
        //    //rep.ReportParameters["Fecha"].Value = fecha;

        //    return rep;
        //}

    }
}
