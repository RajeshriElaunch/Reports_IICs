
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionIndBench_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_EvolucionIndBench> listaTmp = new List<Temp_EvolucionIndBench>();
                foreach (var indice in plantilla.Plantillas_Indices_Referencia)
                {
                    try
                    {
                        //para pruebas 212 y ES0115091037
                        //201 y ES0169764034
                        //202 y ES0133812034
                        //204   ES0116945033
                        //string codIc = "204";
                        //string cod = "ES0116945033";
                        //DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fecha));
                        DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fecha), typeof(Temp_EvolucionIndBench));

                        string tipo = "D";//cuando es índice
                        if (indice.IdTipoIndiceReferencia == 1)
                            tipo = "B"; //Benchmark

                        var pro03Result_ini = Reports_DA.GetPRO03(indice.Codigo, string.Empty, tipo, fechaInicio).FirstOrDefault();
                        var pro03Result_fin = Reports_DA.GetPRO03(indice.Codigo, string.Empty, tipo, fecha).FirstOrDefault();
                        //var pro03Result_ini = Reports_DA.GetPRO03(cod, string.Empty, string.Empty, fechaInicio).FirstOrDefault();
                        //var pro03Result_fin = Reports_DA.GetPRO03(cod, string.Empty, string.Empty, fecha).FirstOrDefault();

                        if (pro03Result_ini != null && pro03Result_fin != null)
                        {
                            Temp_EvolucionIndBench tmp = getNuevoTemp_EvolucionMercados(plantilla.CodigoIc, indice, pro03Result_ini, pro03Result_fin);
                            if (tmp != null)
                            {
                                listaTmp.Add(tmp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //EvolucionIndBench_DA.Insert_Temp_EvolucionIndBench(plantilla.CodigoIc, lista);
                //Temp_Table_Manager<Temp_EvolucionIndBench> ttm = new Temp_Table_Manager<Temp_EvolucionIndBench>();
                //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_EvolucionIndBench getNuevoTemp_EvolucionMercados(string codigoIC, Plantillas_Indices_Referencia indice, usp_gestio_pro_03_Result pro03_ini, usp_gestio_pro_03_Result pro03_fin)
        {
            Temp_EvolucionIndBench tmp = new Temp_EvolucionIndBench();

            var noDate = new DateTime();
            if (pro03_ini.Fecha != noDate && pro03_fin.Fecha != noDate)
            {

                tmp.CodigoIC = codigoIC;
                tmp.Isin = indice.Codigo;
                tmp.Descripcion = indice.DescripcionCodigo;
                var cotizaDivDesde = pro03_ini.cotdiv;
                tmp.CotizaDivDesde = cotizaDivDesde;
                var cotizaDivHasta = pro03_fin.cotdiv;
                tmp.CotizaDivHasta = cotizaDivHasta;
                tmp.VarCotizaDivisa = decimal.Round(Utils.PorcentajeVariacion(cotizaDivDesde, cotizaDivHasta), 2);

                var cotizaEurDesde = Convert.ToDecimal(pro03_ini.coteur);
                var cotizaEurHasta = Convert.ToDecimal(pro03_fin.coteur);
                //tmp.VarCotizaEuros = decimal.Round(Utils.PorcentajeVariacion(cotizaEurDesde, cotizaEurHasta), 2);
                tmp.FechaDesde = pro03_ini.Fecha;
                tmp.FechaHasta = pro03_fin.Fecha;

                return tmp;
            }
            else return null;
            
        }

        //public static Report GetReportEvolucionIndBench(string codigoIC, DateTime fecha)
        //{
        //    Report rep = new ReportEvolucionIndicesBenchMarkPRO_03();

        //    rep.ReportParameters["CodigoIC"].Value = codigoIC;
        //    //rep.ReportParameters["Isin"].Value = isin;
        //    //rep.ReportParameters["Fecha"].Value = fecha;

        //    return rep;
        //}

    }
}
