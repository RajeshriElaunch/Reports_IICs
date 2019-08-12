using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Dividendos_Cobrados;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class DividendosCobrados_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                DateTime fechaHasta = fechaInforme;
                DateTime fechaDesde = Utils.GetFechaInicio(plantilla, fechaInforme);

                string tipo = "DIVIDENDO";
                //List<Temp_DividendosCobrados> listaTmp = new List<Temp_DividendosCobrados>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                try
                {
                    var pro10Result = Reports_DA.GetPRO10(plantilla.CodigoIc, fechaDesde, fechaHasta, tipo).ToList();

                    //Pintamos primero todos los Dividendos 
                    foreach (var item in pro10Result.Where(w => w.TIPMOV.Equals("Dividendo")))
                    {                        
                        Temp_DividendosCobrados dividendosCobrados = new Temp_DividendosCobrados();
                        //Copiamos el contenido de pro04Result en pro04temp
                        dividendosCobrados.CodigoIC = plantilla.CodigoIc;
                        //dividendosCobrados.Isin = isin.Isin;
                        dividendosCobrados.Isin = item.isin;
                        //dividendosCobrados.Isin = string.Empty;
                        dividendosCobrados.Fecha = item.FECHA;
                        string cantidad = item.cantid != null ? decimal.Floor(Convert.ToDecimal(item.cantid)).ToString() : string.Empty;
                        dividendosCobrados.NombreValor = string.Format("Dividendo {0} {1}", cantidad, item.descr);
                        dividendosCobrados.ImporteBruto = item.impbru;
                        dividendosCobrados.ImporteNeto = item.IMPORTE;
                        listaTmp.Add(dividendosCobrados);
                    }

                    //Pintamos una línea que agrupe todos los AJUSTES. Le cambiamos el signo
                    var impAjustes = -(pro10Result.Where(w => w.TIPMOV.Equals("Ajustes")).Sum(s => s.impbru));
                    Temp_DividendosCobrados tmp = new Temp_DividendosCobrados();
                    tmp.CodigoIC = plantilla.CodigoIc;
                    //tmp.Isin = isin.Isin;
                    tmp.Isin = string.Empty;
                    tmp.NombreValor = Resources.Resource.DividendosCobrados_VM_Ajustes;
                    tmp.ImporteBruto = impAjustes;
                    listaTmp.Add(tmp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //}
                //try
                //{
                //    //Reports_DA.Insert_Temp_DividendosCobrados(plantilla.CodigoIc, listaDividendosCobrados.OrderBy(d => d.Fecha));
                //    Temp_Table_Manager<Temp_DividendosCobrados> ttm = new Temp_Table_Manager<Temp_DividendosCobrados>();
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

        public static string Validar(Plantilla plantilla, DateTime fechaInforme)
        {
            try
            {
                string resultado = null;

                //Recuperar el total de DIVIDENDOS (BRUTOS) COBRADOS
                var totalDiv = DividendosCobrados_DA.GetTotalDividendosBrutos(plantilla.CodigoIc);
                //Recuperar INGRESOS FINANCIEROS RV TOTAL de la sección 5 (VARIACIÓN PATRIMONIAL A)
                var totalIF = VariacionPatrimonialA_DA.GetTotalIngresosFinancierosRV(plantilla.CodigoIc);

                //Examinamos la diferencia
                var diferencia = totalDiv - totalIF;

                if (diferencia != 0)
                {
                    //resultado += Environment.NewLine;
                    //resultado += string.Format(Resource.AlertaDivCobIngrFinanRV, Math.Abs(diferencia));

                    //PRUEBA NOVAREX 31/08/
                    //Si hay diferencia informamos también del saldo de la cuenta 7600002: "El saldo de la cuenta 7600002 es: ----" (Comprobar que sale positivo)
                    var saldoCta = -Utils.CalculateFormulaCuentas("[7600002]", plantilla.CodigoIc, null, fechaInforme);

                    //Si la diferencia coincide con saldoCta no tenemos que mostrar la alerta
                    if (saldoCta != diferencia)
                    {
                        resultado += Environment.NewLine;
                        resultado += string.Format(Resource.AlertaDivCobIngrFinanRV, Math.Abs(diferencia));

                        resultado += Environment.NewLine;
                        resultado += string.Format(Resource.AlertaDividendosCobradosCta7600002, Math.Abs(saldoCta));
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Report GetReportDividendosCobrados(Plantilla pl)
        {
            //plantilla.CodigoIc
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            sqlDataSource.SelectCommand = "Get_Temp_DividendosCobrados";
            sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, pl.CodigoIc);
            Report rep = new ReportDividendosCobradosPRO_10();
            rep.ReportParameters["CodigoIC"].Value = pl.CodigoIc;
            var filtroFecha = pl.Parametros_DividendosCobrados.Select(c => c.FechaUltimaReunion).FirstOrDefault();

            DateTime FechaUltimaReunion = new DateTime(1900, 1, 1);
            if (filtroFecha != null)
                FechaUltimaReunion = pl.Parametros_DividendosCobrados.Select(c => c.FechaUltimaReunion).FirstOrDefault().Value;
            rep.ReportParameters["FechaUltimaReunion"].Value = FechaUltimaReunion;

            //Report_DividendosCobrados rep = new Report_DividendosCobrados();
            //rep.DataSource = sqlDataSource;

            return rep;
        }

        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            DividendosCobrados_DA.UpdateFechaUltimaReunion(codigoIC, fecha);
        }

    }
}
