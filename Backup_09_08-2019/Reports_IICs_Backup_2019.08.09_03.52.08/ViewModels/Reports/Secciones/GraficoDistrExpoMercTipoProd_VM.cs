using Reports_IICs.DataAccess.Instrumentos;
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
    public static class GraficoDistrExpoMercTipoProd_VM
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                List<string> isinsFaltan = new List<string>();
                var listaGrafCompPatrimonioTipoActtemp = new List<Temp_GraficoExposMercTipoProducto>();
                //listaTmp será la lista definitiva (agrupada) que se guardará en la tabla temporal
                //var listaTmp = new List<Temp_GraficoCompPatrimonioTipoProducto>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    try
                    {
                        //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).Where(w => !w.tipo.Equals("DE")).ToList();
                        //var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();

                        //Para los gráficos de Distribución Exposición Mercado no tenemos en cuenta los instrumentos MMO
                        var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, false, true);

                        var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);
                        var totalCart = cartera.Sum(s => s.efeact);
                        string cuentasAjustesDerivados = "[441000]+[44105]+[5300020]+[5310003]+[4130020]+[4130022]";
                        var totalAjustesDerivados = Utils.CalculateFormulaCuentas(cuentasAjustesDerivados, plantilla.CodigoIc, null, fecha);
                        //var liquidez = (totalPatrimonio - totalCart - totalAjustesDerivados) / totalPatrimonio;


                    //Hacemos este foreach porque el tipo de activo que nos sirve para realizar las operaciones es el que tenemos en 
                    //instrumentos importados, no el que viene del procedimiento
                    foreach (var item in cartera)
                    {
                        try
                        {
                            //Recuperamos la información del instrumento de pro11
                            var instr = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(item.isin);
                            if (instr != null)
                            {
                                //if (item.TPC2 != null
                                //    //&& item.TPC2 > 0
                                //    )
                                //{
                                //var graficoCompPatrimonioTipoProdTemp = getNuevoTemp_GraficoExposMercTipoProducto(plantilla.CodigoIc, null, instr.Instrumento.Descripcion, instr.Instrumentos_Tipos.Descripcion, item.TPC2);
                                var graficoCompPatrimonioTipoProdTemp = getNuevoTemp_GraficoExposMercTipoProducto(plantilla.CodigoIc, null, instr.Instrumento.Descripcion, instr.Instrumentos_Tipos.Descripcion, item.efeact);
                                listaGrafCompPatrimonioTipoActtemp.Add(graficoCompPatrimonioTipoProdTemp);
                                //}
                            }
                            else
                            {
                                log.Error("Error Instrumento no encontrado para el isin: " + item.isin);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }

                        ////Cálculos
                        var distinctTipos = listaGrafCompPatrimonioTipoActtemp.GroupBy(ac => new
                        {
                            ac.DescInstrumento,
                            ac.DescTipoInstrumento
                        })
                            .Select(ac => new Temp_GraficoExposMercTipoProducto
                            {
                                DescInstrumento = ac.Key.DescInstrumento,
                                DescTipoInstrumento = ac.Key.DescTipoInstrumento,
                                PorcentajePatrimonio = ac.Sum(acs => Convert.ToDecimal(acs.PorcentajePatrimonio)) * 100 / totalPatrimonio
                            });

                        foreach (var tipo in distinctTipos)
                        {
                            //if (tipo.PorcentajePatrimonio > 0)
                            //{
                            var definitivo = getNuevoTemp_GraficoExposMercTipoProducto(plantilla.CodigoIc, null, tipo.DescInstrumento, tipo.DescTipoInstrumento, tipo.PorcentajePatrimonio / 100);
                            listaTmp.Add(definitivo);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}

                //listaDefinitiva = listaDefinitiva.OrderBy(l => l.Patrimonio).ToList();
                //GraficoCompCartTipoProd_DA.Insert_Temp_GraficoCompPatrimonioTipoProducto(plantilla.CodigoIc, listaDefinitiva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoExposMercTipoProducto getNuevoTemp_GraficoExposMercTipoProducto(string codigoIC, string isin, string descInstrumento, string descTipoInstrumento, decimal? porcentajePatrimonio)
        {
            Temp_GraficoExposMercTipoProducto tmpGraf = new Temp_GraficoExposMercTipoProducto();

            tmpGraf.CodigoIC = codigoIC;
            tmpGraf.Isin = isin;            
            tmpGraf.DescInstrumento = descInstrumento;
            tmpGraf.DescTipoInstrumento = descTipoInstrumento;
            tmpGraf.PorcentajePatrimonio = Convert.ToDecimal(porcentajePatrimonio);

            return tmpGraf;
        }

        //public static Report GetReportGraficosCompPatrimonioTipodeProducto(string codigoIC, string isin, DateTime fecha, string isinDesc)
        //{
        //    Telerik.Reporting.Report rep = new Report_BARS_CompPatrimonioTipodeProducto(isin, codigoIC, fecha, isinDesc);

        //    if (isin != null) rep.ReportParameters["Isin"].Value = isin;
        //    if (codigoIC != null) rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    return rep;
        //}

        public static Report GetReportGraficosCompPatrimonioTipodeProducto(string codigoIC, string isin, DateTime fecha, string isinDesc, decimal? porcentajeTotal)
        {
            Telerik.Reporting.Report rep = new Report_BARS_CompPatrimonioTipodeProducto(isin, codigoIC, fecha, isinDesc, porcentajeTotal);

            //Telerik.Reporting.Report rep = new Report_BARS_CompPatrimonioTipodeProducto(isin, codigoIC, fecha, isinDesc);
            //if (isin != null)
                rep.ReportParameters["Isin"].Value = isin;

            //if (codigoIC != null)
                rep.ReportParameters["CodigoIC"].Value = codigoIC;
            //if (porcentajeTotal != null)
                rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;

            return rep;
        }

    }
}
