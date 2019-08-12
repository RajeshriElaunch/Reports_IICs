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
    public static class GraficoDistrPatrTipoProd_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try

            {
                List<string> isinsFaltan = new List<string>();
                var listaGrafCompCarteraTipoActtemp = new List<Temp_GraficoCompPatrimonioTipoProducto>();
                //listaTmp será la lista definitiva (agrupada) que se guardará en la tabla temporal
                //var listaTmp = new List<Temp_GraficoCompCarteraTipoProducto>();

                //Para los gráficos de Distribución Patrimonio no tenemos en cuenta los DERIVADOS
                var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, null, null, null, null, false, false, true, false);

                var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fecha);

                //Hacemos este foreach porque el tipo de activo que nos sirve para realizar las operaciones es el que tenemos en 
                //instrumentos importados, no el que viene del procedimiento
                foreach (var item in cartera)
                {
                    try
                    {
                        //Es el peso del EfectivoActual en el EfectivoActual Total
                        //OJO: NO COGER TPC1 --> VIENE MAL
                        //var porcCart = decimal.Round(Utils.GetPorcentaje(item.efeact, pro11Result.Sum(s=>s.efeact)), 2);
                        //var porcCart = Utils.GetPorcentaje(item.efeact, pro11Result.Sum(s => s.efeact));

                        //var graficoCompCarteraTipoProdTemp = getNuevoTemp_GraficoCompPatrimonioTipoProducto(plantilla.CodigoIc, isin, instr.IdInstrumento, instr.Instrumento.Descripcion, instr.IdTipoInstrumento, instr.Instrumentos_Tipos.Descripcion, item.TPC2);
                        //var graficoCompCarteraTipoProdTemp = getNuevoTemp_GraficoCompPatrimonioTipoProducto(plantilla, null, item.isin.ToUpper(), item.TPC2);
                        var graficoCompCarteraTipoProdTemp = getNuevoTemp(plantilla, null, item.isin.ToUpper(), item.efeact);

                        listaGrafCompCarteraTipoActtemp.Add(graficoCompCarteraTipoProdTemp);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }               
                

                ////Cálculos
                var distinctTipos = listaGrafCompCarteraTipoActtemp.GroupBy(ac => new
                {
                    ac.IdInstrumento,
                    ac.DescInstrumento,
                    ac.IdTipoInstrumento,
                    ac.DescTipoInstrumento
                })
                    .Select(ac => new Temp_GraficoCompPatrimonioTipoProducto
                    {
                        IdInstrumento = ac.Key.IdInstrumento,
                        DescInstrumento = ac.Key.DescInstrumento,
                        IdTipoInstrumento = ac.Key.IdTipoInstrumento,
                        DescTipoInstrumento = ac.Key.DescTipoInstrumento,
                        //Patrimonio = ac.Sum(acs => acs.Patrimonio) / 100
                        Patrimonio = (ac.Sum(acs => acs.Patrimonio)*100/totalPatrimonio) / 100
                    });

                string descInstrMMO = "Mercado Monetario / Liquidez";

                decimal patrimInsertado = 0;
                foreach (var tipo in distinctTipos)
                {
                    try
                    {
                        string descIntr = tipo.DescInstrumento;
                        if (tipo.IdInstrumento == "4")
                        {
                            descIntr = descInstrMMO;
                        }
                        var definitivo = getNuevoTemp(plantilla, null, null, tipo.Patrimonio, tipo.IdInstrumento, descIntr, tipo.IdTipoInstrumento, tipo.DescTipoInstrumento);
                        var porcPatr = Convert.ToDecimal(definitivo.Patrimonio);
                        if (porcPatr > 0)
                        {
                            listaTmp.Add(definitivo);
                            patrimInsertado = patrimInsertado + porcPatr;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //tiene que sumar 100%. Calculamos tesorería por diferencia
                if (patrimInsertado < 1)
                {
                    var diferencia = 1 - patrimInsertado;
                    string desc = "Tesorería / op. pendientes liquidar";
                    //dentro del grupo MMO
                    string idInstrum = "4";
                    var tmp = getNuevoTemp(plantilla, null, null, diferencia, idInstrum, descInstrMMO, null, desc);
                    listaTmp.Add(tmp);
                }

                //Si tiene estrategias pintaremos una línea "Estrategias" dentro de RAB
                if (plantilla.Plantillas_Estrategias.Count > 0 && plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Count > 0)
                {
                    var porc = plantilla.Parametros_GraficoCompPatrimonioTipoProducto.FirstOrDefault().PorcEstrategiasRA / 100;
                    //dentro del grupo RAB
                    var instr = VariablesGlobales.Instrumentos_Local.Where(w => w.Codigo == "RAB").FirstOrDefault();
                    string descTipo = "Estrategias";
                    var tmp = getNuevoTemp(plantilla, null, null, porc, instr.Id, instr.Descripcion, null, descTipo);
                    listaTmp.Add(tmp);
                }

                #region ajustes finales            
                //Si la plantilla tiene Estrategias hacemos los cálculos para descontar el % del parámetro de la sección del resto de líneas
                if (plantilla.Plantillas_Estrategias.Count > 0 && plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Count > 0)
                {
                    try
                    {
                        //No tenemos que mostrar el tipo PAT pero utilizamos su % para los cálculos
                        var lista = (List<Temp_GraficoCompPatrimonioTipoProducto>)(listaTmp.Where(w => w.GetType() == new Temp_GraficoCompPatrimonioTipoProducto().GetType()).Select(s => (Temp_GraficoCompPatrimonioTipoProducto)s).ToList());
                        var pat = lista.Where(w => w.IdTipoInstrumento == "5").FirstOrDefault();

                        //% Patrimonialista
                        decimal porcPat = 0;
                        if (pat != null)
                        {
                            porcPat = pat.Patrimonio;
                            //Tenemos que restar al item MMO/VAL (parametro - porcPat)
                            var mmoVal = lista.Where(w => w.IdInstrumento == "4" && w.IdTipoInstrumento == "1").FirstOrDefault();
                            var totalARestar = plantilla.Parametros_GraficoCompPatrimonioTipoProducto.FirstOrDefault().PorcEstrategiasRA / 100 - porcPat;
                            //Si el total a restar es mayor que lo que tenemos en mmoVal, restamos lo que falte a "Tesorería / op. pendientes liquidar"
                            if (mmoVal != null && totalARestar < mmoVal.Patrimonio)
                            {
                                mmoVal.Patrimonio = mmoVal.Patrimonio - totalARestar;
                            }
                            else
                            {
                                var tesor = lista.Where(w => w.IdInstrumento == "4" && w.IdTipoInstrumento == null).FirstOrDefault();
                                if (tesor != null)
                                {
                                    if (mmoVal != null)
                                    {
                                        var pendiente = totalARestar - mmoVal.Patrimonio;
                                        tesor.Patrimonio = tesor.Patrimonio - pendiente;
                                        mmoVal.Patrimonio = 0;
                                    }
                                    else
                                    {
                                        tesor.Patrimonio = tesor.Patrimonio - totalARestar;
                                    }


                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                //listaDefinitiva = listaDefinitiva.OrderBy(l => l.Patrimonio).ToList();
                //GraficoCompCartTipoProd_DA.Insert_Temp_GraficoCompCarteraTipoProducto(plantilla.CodigoIc, listaDefinitiva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoCompPatrimonioTipoProducto getNuevoTemp(Plantilla plantilla, string isinPlantilla, string isin, decimal? porcentajePatr, string idInstrumento = null, string descInstumento = null, string idTipoInstrumento = null, string descTipoInstrumento = null)
        {
            Temp_GraficoCompPatrimonioTipoProducto tmpGraf = new Temp_GraficoCompPatrimonioTipoProducto();
            
            //Recuperamos la información del instrumento de pro11
            Instrumentos_Importados instr = null;
            if(!string.IsNullOrEmpty(isin))
                instr = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(isin);

            tmpGraf.CodigoIC = plantilla.CodigoIc;
            tmpGraf.IsinPlantilla = isinPlantilla;

            if (!string.IsNullOrEmpty(idInstrumento) && !string.IsNullOrEmpty(descTipoInstrumento))
            {
                tmpGraf.IdInstrumento = idInstrumento;
                tmpGraf.DescInstrumento = descInstumento;
            }
            else
            {
                tmpGraf.IdInstrumento = instr.IdInstrumento;
                tmpGraf.DescInstrumento = instr.Instrumento.Descripcion;
            }

            if (!string.IsNullOrEmpty(idTipoInstrumento) || !string.IsNullOrEmpty(descTipoInstrumento))
            {
                tmpGraf.IdTipoInstrumento = idTipoInstrumento;
                tmpGraf.DescTipoInstrumento = descTipoInstrumento;
            }
            else if(instr != null)
            {
                //Si hay estrategias en la plantilla y el tipo2 del instrumento es PAT, tenemos en cuenta el tipo2
                if (plantilla.Plantillas_Estrategias.Count > 0 && instr.IdTipoInstrumento2 == "5") //PAT
                {
                    tmpGraf.IdTipoInstrumento = instr.IdTipoInstrumento2;
                    tmpGraf.DescTipoInstrumento = instr.Instrumentos_Tipos1.Descripcion;
                }
                else
                {
                    tmpGraf.IdTipoInstrumento = instr.IdTipoInstrumento;
                    tmpGraf.DescTipoInstrumento = instr.Instrumentos_Tipos.Descripcion;
                }
            }

            tmpGraf.Patrimonio = Convert.ToDecimal(porcentajePatr);

            //Quieren que "Tesorería / op. pendientes liquidar" aparezca el último dentro de su grupo
            if (tmpGraf.IdInstrumento == "4" && tmpGraf.IdTipoInstrumento == null)
                tmpGraf.Orden = 2;
            else
                tmpGraf.Orden = 1;
                

                return tmpGraf;
        }

        public static Report GetReport(string codigoIC, string isin, DateTime fecha, string isinDesc)
        {
            Report rep = new ReportCompPatrimonioTipodeProducto();

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            //rep.ReportParameters["Fecha"].Value = fecha;

            return rep;
        }

        //public static Report GetReportGraficosCompPatrimonioTipodeProducto(string codigoIC, string isin, DateTime fecha, string isinDesc, decimal? porcentajeTotal)
        //{
        //    Telerik.Reporting.Report rep = new Report_BARS_CompPatrimonioTipodeProducto(isin, codigoIC, fecha, isinDesc, porcentajeTotal);

        //    //Telerik.Reporting.Report rep = new Report_BARS_CompPatrimonioTipodeProducto(isin, codigoIC, fecha, isinDesc);
        //    if (isin != null) rep.ReportParameters["Isin"].Value = isin;
        //    if (codigoIC != null) rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    if (porcentajeTotal != null) rep.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
            
        //    return rep;
        //}

    }
}
