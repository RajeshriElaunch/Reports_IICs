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
    public static class GraficoDistrPatrTipoAct_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var listaGrafCompCarteraTipoActtemp = new List<Temp_GraficoCompPatrimonioTipoActivo>();
                //listaTmp será la lista definitiva (agrupada) que se guardará en la tabla temporal
                //var listaDefinitiva = new List<Temp_GraficoCompCarteraTipoActivo>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                try
                {
                    //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();

                    //Para los gráficos de Distribución Patrimonio no tenemos en cuenta los DERIVADOS
                    var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, true, false);

                    var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);

                    //Hacemos este foreach porque el tipo de activo que nos sirve para realizar las operaciones es el que tenemos en 
                    //instrumentos importados, no el que viene del procedimiento
                    foreach (var item in cartera)
                    {
                        try
                        {
                            //Recuperamos la información del instrumento de pro11
                            var instr = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(item.isin.ToUpper());
                            //Es el peso del EfectivoActual en el EfectivoActual Total
                            //OJO: NO COGER TPC1 --> VIENE MAL
                            //var porcCart = Utils.GetPorcentaje(item.efeact, cartera.Sum(s => s.efeact));
                            //var graficoCompCarteraTipoActTemp = getNuevoTemp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, null, Convert.ToInt32(instr.IdInstrumento), instr.Instrumento.Descripcion, item.TPC2);
                            var graficoCompCarteraTipoActTemp = getNuevoTemp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, null, Convert.ToInt32(instr.IdInstrumento), instr.Instrumento.Descripcion, item.efeact);
                            listaGrafCompCarteraTipoActtemp.Add(graficoCompCarteraTipoActTemp);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    ////Calculos
                    var instrPorTipoActivo = listaGrafCompCarteraTipoActtemp.GroupBy(g => g.TipoActivo);
                    decimal? porcPatrTiposNoMM = 0;
                    //Hacemos los cálculos del % Patrimonio para todos los tipos menos para MM: Mercado Monetario
                    foreach (var tipoAct in instrPorTipoActivo)
                    {
                        try
                        {
                            //El porcentaje de patrimonio viene calculado, sólo tenemos que sumarlo
                            //En el caso de MM: Mercado Monetario el cálculo será la diferencia entre la suma 
                            //del porcentaje del resto de tipos y el 100%
                            if (tipoAct.Where(t => !t.TipoActivo.Equals(Resource.MMOLiq)).Count() > 0)
                            {
                                //var porcCart = tipoAct.Sum(s => s.PorcentajeCartera ?? 0);
                                var porcCart = tipoAct.Sum(s => s.PorcentajePatrimonio) * 100 / totalPatrimonio;
                                //porcCart = decimal.Round(porcCart, 0);
                                var descTipoActivo = tipoAct.Select(s => s.TipoActivo).FirstOrDefault();
                                var definitivoPorTipoActivo = getNuevoTemp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, null, tipoAct.FirstOrDefault().IdInstrumento, descTipoActivo, porcCart);
                                var porcCartera = definitivoPorTipoActivo.PorcentajePatrimonio;
                                if (porcCartera > 0)
                                {
                                    listaTmp.Add(definitivoPorTipoActivo);
                                    porcPatrTiposNoMM += porcCart;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    //Ahora calculamos el % Patrimonio para MM: Mercado Monetario
                    var porcPatrMM = 100 - porcPatrTiposNoMM;
                    var descTipoActivoMM = Resource.MMOLiq;
                    var definitivoMM = getNuevoTemp_GraficoCompPatrimonioTipoActivo(plantilla.CodigoIc, null, 4, descTipoActivoMM, porcPatrMM);
                    var porcCarteraMM = definitivoMM.PorcentajePatrimonio;
                    if (porcCarteraMM > 0)
                    {
                        listaTmp.Add(definitivoMM);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //}

                
                //listaDefinitiva = listaDefinitiva.OrderBy(l => l.PorcentajePatrimonio).ToList();
                //Reports_DA.Insert_Temp_GraficoCompCarteraTipoActivo(plantilla.CodigoIc, listaDefinitiva);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private static Temp_GraficoCompPatrimonioTipoActivo getNuevoTemp_GraficoCompPatrimonioTipoActivo(string codigoIC, string isin, int idInstrumento, string tipoActivo, decimal? porcentajePatr)
        {
            Temp_GraficoCompPatrimonioTipoActivo tmpGraf = new Temp_GraficoCompPatrimonioTipoActivo();
            
            //codigoIC = "214";
            //isin = "ES0139957031";
            //tipoActivo = "Renta Fija";
            //idInstrumento = 2;
            //porcentajeCartera = Convert.ToDecimal("0,00005624395182051280783739900");

            tmpGraf.CodigoIC = codigoIC;
            tmpGraf.Isin = isin;
            tmpGraf.TipoActivo = tipoActivo;
            //nos aseguramos que no pase de 27 decimales
            tmpGraf.PorcentajePatrimonio = Convert.ToDecimal(porcentajePatr);
            tmpGraf.IdInstrumento = idInstrumento;

            return tmpGraf;
        }

        public static Report GetReport(string codigoIC, string isin, string isinDesc, DateTime fecha)
        {
            Report rep = new ReportCompPatrimonioTipoActivo(isinDesc, codigoIC);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            //rep.ReportParameters["Fecha"].Value = fecha;

            return rep;
        }

        //public static Report GetReportGraficosComposicionPatrimonioTipoActivo(string codigoIC, string isin, string isinDesc, DateTime fecha, decimal? porcentajeTotal)
        //{
        //    Report rep = new Report_BARS_CompPatrimonioTipoActivo(isinDesc, codigoIC, porcentajeTotal);

        //    rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    rep.ReportParameters["Isin"].Value = isin;
        //    //rep.ReportParameters["Fecha"].Value = fecha;
        //    rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
        //    return rep;
        //}

    }

}
