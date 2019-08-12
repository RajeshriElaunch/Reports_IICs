using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System.Linq;
using System;
using Reports_IICs.Helpers;
using System.Collections.Generic;
using Telerik.Reporting;
using Reports_IICs.Reports.EvolucionMercados;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionMercados_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var parametros = EvolucionMercados_DA.GetParametros(plantilla.CodigoIc);

                //List<Temp_EvolucionMercados> lista = new List<Temp_EvolucionMercados>();
                foreach (var param in parametros)
                {
                    try
                    {
                        //FECHA VALIDADA POR LA GESTORA
                        var fechaIni = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fecha), typeof(Temp_EvolucionMercados));
                        var pro03Result_ini = Reports_DA.GetPRO03(param.Isin, string.Empty, string.Empty, fechaIni).FirstOrDefault();
                        var pro03Result_fin = Reports_DA.GetPRO03(param.Isin, string.Empty, string.Empty, fecha).FirstOrDefault();

                        if (pro03Result_ini != null && pro03Result_fin != null)
                        {
                            Temp_EvolucionMercados tmp = getNuevoTemp_EvolucionMercados(plantilla.CodigoIc, param.Isin, pro03Result_ini, pro03Result_fin, param);
                            listaTmp.Add(tmp);
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //EvolucionMercados_DA.Insert_Temp_EvolucionMercados(plantilla.CodigoIc, lista);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_EvolucionMercados getNuevoTemp_EvolucionMercados(string codigoIC, string isin, usp_gestio_pro_03_Result pro03_ini, usp_gestio_pro_03_Result pro03_fin, Parametros_EvolucionMercados param)
        {
            Temp_EvolucionMercados tmp = new Temp_EvolucionMercados();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.Descripcion = param.Descripcion;
            var cotizaDivDesde = pro03_ini.cotdiv;
            tmp.CotizaDivDesde = cotizaDivDesde;
            var cotizaDivHasta = pro03_fin.cotdiv;
            tmp.CotizaDivHasta = cotizaDivHasta;
            tmp.VarCotizaDivisa = decimal.Round(Utils.PorcentajeVariacion(cotizaDivDesde, cotizaDivHasta),2);

            var cotizaEurDesde = Convert.ToDecimal(pro03_ini.coteur);
            var cotizaEurHasta = Convert.ToDecimal(pro03_fin.coteur);

            //No mostramos la VAR% EUR para los 3 siguientes casos
            if (param.Isin != "EUR"
                && param.Isin != "EUR/GBP"
                && param.Isin != "EUR/JPY")
            {
                tmp.VarCotizaEuros = decimal.Round(Utils.PorcentajeVariacion(cotizaEurDesde, cotizaEurHasta), 2);
            }
            tmp.FechaCotizacionDesde = pro03_ini.Fecha;
            tmp.FechaCotizacionHasta = pro03_fin.Fecha;

            return tmp;
        }

        public static Report GetReportEvolucionMercados(string codigoIC, DateTime fechaDesde, DateTime fechaHasta)
        {
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            //sqlDataSource.SelectCommand = "Get_Temp_EvolucionMercados";
            //sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            //sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);
            Report rep = new ReportEvolucionMercados();
            rep.ReportParameters["FechaDesde"].Value = fechaDesde;
            rep.ReportParameters["FechaHasta"].Value = fechaHasta;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            //rep.DataSource = sqlDataSource;

            return rep;
        }

    }
}
