using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Cupones_Cobrados;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class CuponesCobrados_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                DateTime fechaHasta = fechaInforme;
                DateTime fechaDesde = Utils.GetFechaInicio(plantilla, fechaInforme);

                string tipo = "Cupon";
                //List<Temp_CuponesCobrados> listaTmp = new List<Temp_CuponesCobrados>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    var pro10Result = Reports_DA.GetPRO10(plantilla.CodigoIc, fechaDesde, fechaHasta, tipo).ToList();
                    foreach (var item in pro10Result)
                    {
                        Temp_CuponesCobrados cuponesCobrados = new Temp_CuponesCobrados();
                        //Copiamos el contenido de pro04Result en pro04temp
                        cuponesCobrados.CodigoIC = plantilla.CodigoIc;
                        cuponesCobrados.Isin = null;
                        cuponesCobrados.Fecha = item.FECHA;
                        string cantidad = item.cantid != null ? decimal.Floor(Convert.ToDecimal(item.cantid)).ToString() : string.Empty;
                        cuponesCobrados.NombreValor = string.Format("Cupón {0} {1}", cantidad, item.descr);
                        cuponesCobrados.ImporteNeto = item.IMPORTE;

                        listaTmp.Add(cuponesCobrados);
                    }
                //}
                //try
                //{
                //    //CuponesCobrados_DA.Insert_Temp(plantilla.CodigoIc, listaCuponesCobrados.OrderBy(d => d.Fecha));
                //    Temp_Table_Manager<Temp_CuponesCobrados> ttm = new Temp_Table_Manager<Temp_CuponesCobrados>();
                //    ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
                //}

                //catch (Exception ex)
                //{
                //    throw ex;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Report GetReportCuponesCobrados(string codigoIC, DateTime fechaInforme)
        {
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            sqlDataSource.SelectCommand = "Get_Temp_DividendosCobrados";
            sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);
            sqlDataSource.Parameters.Add("@Isin", System.Data.DbType.String, null);
            Report rep = new ReportCuponesCobrados();
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = null;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            //Report_DividendosCobrados rep = new Report_DividendosCobrados();
            //rep.DataSource = sqlDataSource;

            return rep;
        }
    }
}
