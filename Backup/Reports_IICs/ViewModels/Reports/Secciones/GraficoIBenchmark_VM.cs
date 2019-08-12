using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoBenchmark;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoIBenchmark_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_GraficoIBenchmark> listaTmp = new List<Temp_GraficoIBenchmark>();


                var fechaFin = fechaInforme;
                decimal? base100Ini = 0;
                //Llamada para recuperar los datos con el Benchmark
                var bench = GraficoIBenchmark_DA.GetParametroPlantilla(plantilla.CodigoIc);
                var indices = GraficoIBenchmark_DA.GetIndices(plantilla.CodigoIc);
                // var fechaFin = new DateTime(2015,7, 30);
                var fechaInicio = bench != null && bench.FechaInicio != null ? Convert.ToDateTime(bench.FechaInicio) : plantilla.FechaCreacion;
                //var fechaInicio = new DateTime(2009, 1, 1);
                //foreach (var isin in plantilla.Plantillas_Isins)
                //{

                //Cuando hay clases sólo pintamos la primera, que es la predeterminada
                var isin = plantilla.Plantillas_Isins.FirstOrDefault();

                if (isin != null)
                {
                    try
                    {
                        //Llamada para recuperar los datos con el índice
                        var proc15 = Reports_DA.GetPRO15(plantilla.CodigoIc, isin.Isin, fechaInicio, fechaFin).ToList().OrderBy(c => c.fecha);
                        if (proc15.Count() > 0)
                        {
                            var a = proc15.Max(m => m.fecha);
                            var b = proc15.Min(m => m.fecha);
                            var base100Value_proc15 = proc15.First().valliq;
                            base100Ini = base100Value_proc15;
                            //Pasaremos el resultado a base 100 - El primer valor será 100

                            //var base100Value_proc15 = proc15.First().valliq;
                            foreach (var item in proc15)
                            {

                                //guardaremos el ISIN como NO referencia
                                bool esReferencia = false;
                                Temp_GraficoIBenchmark tmp = getNuevoTemp_GraficoIBenchmark(plantilla.CodigoIc, isin.Isin, item.fecha, base100Value_proc15, item.valliq, esReferencia, base100Ini);
                                listaTmp.Add(tmp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                //}

                //if (bench != null)
                //{
                foreach (var item in indices)
                {
                    try
                    {
                        #region proc16
                        var proc16 = Reports_DA.GetPRO16(item.Indice, fechaInicio, fechaFin).ToList().OrderBy(c => c.Fecha).ToList();
                        //Pasaremos el resultado a base 100 - El primer valor será 100
                        if (proc16.Count > 0)
                        {
                            var base100Value_proc16 = proc16.First().coteur;

                            //Si no tiene datos el proc15 o tiene pero la primera coteur es 0
                            //Ponemos la primera del proc16 para no realizar una división entre 0
                            if (base100Ini == 0)
                                base100Ini = base100Value_proc16;

                            foreach (var itemProc16 in proc16)
                            {
                                //guardaremos el Benchmark como referencia
                                bool esReferencia = true;
                                Temp_GraficoIBenchmark tmp = getNuevoTemp_GraficoIBenchmark(plantilla.CodigoIc, item.Indice, itemProc16.Fecha, base100Value_proc16, itemProc16.coteur, esReferencia, base100Ini);
                                listaTmp.Add(tmp);
                            }
                        }

                        #endregion
                    }
                    catch (Exception)
                    {

                    }
                }
                //}

                //try
                //{
                //    //GraficoIBenchmark_DA.Insert_Temp(plantilla, listaTemp);
                //    Temp_Table_Manager<Temp_GraficoIBenchmark> ttm = new Temp_Table_Manager<Temp_GraficoIBenchmark>();
                //    ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
                //}
                //catch(Exception ex)
                //{
                //    throw ex;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_GraficoIBenchmark getNuevoTemp_GraficoIBenchmark(string codigoIC, string isin, DateTime fecha, decimal? base100Value, decimal? valorLiquidativo, bool esReferencia)
        {
            Temp_GraficoIBenchmark tmp = new Temp_GraficoIBenchmark();

            //Copiamos el contenido de pro04Result en pro04temp
            tmp.CodigoIc = codigoIC;
            tmp.Isin = isin;
            tmp.Fecha = fecha;
            tmp.ValorLiquidativo = Utils.ConvertToBase100(base100Value, valorLiquidativo);
            tmp.EsReferencia = esReferencia;

            return tmp;
        }

        private static Temp_GraficoIBenchmark getNuevoTemp_GraficoIBenchmark(string codigoIC, string isin, DateTime fecha, decimal? base100Value, decimal? valorLiquidativo, bool esReferencia, decimal? base100IniValue)
        {
            Temp_GraficoIBenchmark tmp = new Temp_GraficoIBenchmark();

            //Copiamos el contenido de pro04Result en pro04temp
            tmp.CodigoIc = codigoIC;
            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.Fecha = fecha;
            tmp.ValorLiquidativo = Utils.ConvertToBase100(base100Value, valorLiquidativo,base100IniValue);
            tmp.EsReferencia = esReferencia;

            return tmp;
        }

        public static Report GetReport(string codigoIC, string isin, DateTime fecha, string descPlantilla, double days, string isinDesc)
        {
            Telerik.Reporting.Report rep = new ReportBenchMarkPRO_25(codigoIC, isin, isinDesc, days);

            rep.ReportParameters["NombrePlantilla"].Value = descPlantilla;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            //rep.ReportParameters["Isin"].Value = isin;
            //rep.ReportParameters["IsinDesc"].Value = isinDesc;
            //rep.ReportParameters["Days"].Value = days;

            //rep.DataSource = Cartera_DA.GetTemp_GraficoIBenchmark(codigoIC, isin, fecha).ToList();
            return rep;
        }


    }
}
