using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Reports.CARTERA_RF;
using System;
using System.Collections.Generic;
using Telerik.Reporting;


namespace Reports_IICs.ViewModels.Reports.Secciones
{ 
    public static class Cartera_RF_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var carteraRF = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "RFI", "VAL", false);

                foreach (var item in carteraRF)
                {
                    var tmp = getNuevoTemp(plantilla.CodigoIc, item);
                    listaTmp.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_CarteraRF getNuevoTemp(string codigoIC, usp_gestio_pro_11_Result item)
        {
            var tmp = new Temp_CarteraRF();

            tmp.CodigoIC = codigoIC;
            tmp.Valor = item.descr;
            tmp.Divisa = item.div;
            tmp.Dias = item.diasvto;
            tmp.Vencimiento = item.datvto;
            tmp.Nominal = item.nomina;
            tmp.EfectivoCompra = item.efecos;
            tmp.TirCompra = item.tircom;
            tmp.TirMercado = item.valact;
            tmp.Intereses = item.interes;
            tmp.PlusvaliasMinusvalias = item.plusva;
            tmp.EfectivoActual = item.efeact;
            tmp.PorcentajePat = item.TPC2;

            return tmp;
        }

        public static Report GetReportCarteraRF(string codigoIC, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            //sqlDataSource.SelectCommand = "Get_Temp_CarteraRF";
            //sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            //sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);
            ReportCARTERA_RF rep = new ReportCARTERA_RF();
            rep.ReportParameters["FechaReporte"].Value = fecha;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            //Report_Cartera rep = new Report_Cartera(codigoIC, fecha, plantilla);
            //rep.DataSource = sqlDataSource;

            return rep;
        }

    }
}
