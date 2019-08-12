using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using log4net;
using LinqToExcel;
using MahApps.Metro.Controls;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Reports_IICs.DataAccess;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Pages.Informes.ProgressDialog;
using Reports_IICs.Resources;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using Telerik.Windows.Controls;
using static Reports_IICs.Helpers.VariablesGlobales;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataColumn = System.Data.DataColumn;
using DataTable = System.Data.DataTable;
using Panel = Telerik.Reporting.Panel;
using Window = System.Windows.Window;

namespace Reports_IICs.Helpers
{
    public static class Utils
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public enum Elemento
        {
            Plantillas,
            BloombergImportados,
            Secciones,
            Instrumentos,
            InstrumentosCategorias,
            InstrumentosEmpresas,
            InstrumentosImportados,
            InstrumentosPaises,
            InstrumentosTipos,
            InstrumentosZonas,
            InstrumentosSectores,
            InstrumentosDivisas,
            ParametrosGenerales
        }

        public static DataTable RecuperarDatosExcel()
        {
            int? columnaEstimacion = null;
            int? año = null;
            return RecuperarDatosExcel(1, ref columnaEstimacion, ref año, false);
        }
        
        public static IEnumerable<Row> GetExcelDatos(ref List<string> listaErrores)
        {
            OpenFileDialog openfile = new OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "(.xlsx)|*.xlsx"
            };
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                string filePath = openfile.FileName;

                var excelFile = new ExcelQueryFactory(filePath);
                
                bool existe = excelFile.GetWorksheetNames().Any(w => w == "dades");
                
                if (existe)
                {
                    return excelFile.Worksheet("dades").ToList().Where(w => !IsEmptyRow(w));
                }
                listaErrores.Add(Resource.HojaDades);
                return null;
            }
            return null;
        }

        /// <summary>
        /// Devuelve falso si es una fila entera sin valores. Como se utiliza para importar diferentes plantillas, daremos por válido
        /// cuando tenga al menos un sólo valor.
        /// </summary>
        /// <param name="fila"></param>
        /// <returns></returns>
        private static bool IsEmptyRow(Row fila)
        {
            bool resultado = true;

            foreach (var colName in fila.ColumnNames)
            {
                var aaa = fila[colName].Value.ToString();
                if (!string.IsNullOrEmpty(aaa))
                {
                    resultado = false;
                    break;//pasamos a la siguiente columna (cell)
                }
            }

            return resultado;
        }

        /// <summary>
        /// Fila en la que se encuentra la cabecera
        /// </summary>
        /// <param name="filaCabecera"></param>
        /// <param name="columnaEstimacion"></param>
        /// <param name="año"></param>
        /// <param name="esBloomberg"></param>
        /// <returns></returns>
        private static DataTable RecuperarDatosExcel(int filaCabecera, ref int? columnaEstimacion, ref int? año, bool esBloomberg)
        {
            DataTable dt = new DataTable();

            try
            {

                OpenFileDialog openfile = new OpenFileDialog
                {
                    DefaultExt = ".xlsx",
                    Filter = "(.xlsx)|*.xlsx"
                };
                //openfile.ShowDialog();

                var browsefile = openfile.ShowDialog();

                if (browsefile == true)
                {
                    string filePath = openfile.FileName;

                    Application excelApp = new Application();
                    //Static File From Base Path...........
                    //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    //Dynamic File Using Uploader...........
                    Workbook excelBook = excelApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Worksheet excelSheet = (Worksheet)excelBook.Worksheets.Item[1];

                    //int iTotalColumns = excelSheet.UsedRange.Columns.Count;
                    //int iTotalRows = excelSheet.UsedRange.Rows.Count;
                    //These two lines do the magic.
                    excelSheet.Columns.ClearFormats();
                    excelSheet.Rows.ClearFormats();
                    Range excelRange = excelSheet.UsedRange;


                    int millisecondsTimeout = 500;
                    MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;
                    ProgressDialogResult result = ProgressDialog.Execute(main, "Leyendo Excel", () =>
                    {
                        string strCellData = "";
                        double douCellData;
                        int rowCnt = 0;
                        int colCnt = 0;

                        #region process Excel
                        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            try
                            {
                                string strColumn = "";
                                var obj = (excelRange.Cells[filaCabecera, colCnt] as
                                    Range);
                                if (obj != null)
                                {
                                    strColumn =
                                        (string) (excelRange.Cells[filaCabecera, colCnt] as
                                            Range).Value2;
                                }
                                dt.Columns.Add(strColumn, typeof(string));
                            }
                            catch (Exception ex)
                            {
                                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                                Log.Error("Error Utils/RecuperarDatosExcel", ex);
                                // Compliance                                           
                                throw;
                            }
                        }

                        dt.Columns.Add("CHECK", typeof(string));


                        for (rowCnt = filaCabecera + 1; rowCnt <= excelRange.Rows.Count; rowCnt++)
                        {
                            string strData = "";
                            for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                            {
                                var obj =
                                    (excelRange.Cells[rowCnt, colCnt] as Range);
                                try
                                {
                                    if ((excelRange.Cells[rowCnt, colCnt] as Range) != null)
                                    {
                                        strCellData = Convert.ToString((excelRange.Cells[rowCnt, colCnt] as Range).Value2);
                                        strData += strCellData + "|";
                                    }
                                }
                                catch (Exception)
                                {
                                    if (obj == null) continue;
                                    douCellData = obj.Value2;
                                    strData += douCellData + "|";
                                }
                            }

                            strData = strData + "OK|";
                            strData = strData.Remove(strData.Length - 1, 1);
                            if (!string.IsNullOrEmpty(strData.Replace("|", "")))
                            {
                                dt.Rows.Add(strData.Split('|'));
                            }
                        }
                        #endregion
                        Thread.Sleep(millisecondsTimeout);
                    });

                    //Si hay que recuperar el valor de una celda en concreto lo hacemos ahora
                    if (esBloomberg)
                    {
                        if (excelSheet.Range["B1"].Value != null)
                        {
                            columnaEstimacion = Convert.ToInt32(excelSheet.Range["B1"].Value.ToString());
                        }
                        if (excelSheet.Range["D1"].Value != null)
                        {
                            año = Convert.ToInt32(excelSheet.Range["D1"].Value.ToString());
                        }
                    }

                    excelBook.Close(false);
                    excelApp.Quit();
                }

                return dt;
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Utils/RecuperarDatosExcel", ex);
                // Compliance                                           
                throw;                
            }
        }

        /// <summary>
        /// Nos permite copiar el contenido de una objeto en otro
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="notCopyProperty"></param>
        public static void CopyPropertyValues(object source, object destination, string notCopyProperty)
        {
            List<string> propExcluir = new List<string> { "Count", "Comparer" };

            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    try
                    {
                        //Busca que el objeto pertenezca el namespace Hubble
                        if (destProperty.PropertyType.Name.Contains("ICollection") ||
                            (!string.IsNullOrEmpty(destProperty.PropertyType.FullName) &&
                             !destProperty.PropertyType.FullName.Contains("System."))
                        )
                        {
                            //deberia hacer recursividad en los objetos hijos pero bue...
                            //PropertyInfo[] propsChild = pTo.GetType().GetProperties();
                            //foreach (PropertyInfo pToChild in propsChild)
                            //{

                            //}

                            continue;
                        }

                        if (destProperty.Name == sourceProperty.Name &&
                            destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType) &&
                            destProperty.Name != notCopyProperty &&
                            !propExcluir.Contains(destProperty.Name) //Propiedades que no pueden copiarse
                        )
                        {
                            destProperty.SetValue(destination, sourceProperty.GetValue(
                                source, new object[] { }), new object[] { });

                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                        //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                        Log.Error("Error Utils/CopyPropertyValues", ex);
                        // Compliance                                           
                        throw;
                    }
                }
            }
        }


        public static void CopyPropertyValues(object source, object destination)
        {
            CopyPropertyValues(source, destination, string.Empty);
        }


        /// <summary>
        /// Devuelve la fecha de inicio para un informe que lo necesite. Corresponde a la fecha de creación 
        /// de la Sicav o Fondo siempre y cuando la creación sea en el mismo año que el de la fecha de 
        /// generación del informe. Si no es del mismo año la fecha corresponde al 01/01/[Año de generación 
        /// del informe].
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="fechaFin">Fecha de solicitud del informe.</param>
        /// /// <param name="seccion"></param>
        /// <returns></returns>
        public static DateTime GetFechaInicio(Plantilla plantilla, DateTime fechaFin, Type seccion = null)
        {
            DateTime fechaInicio = Convert.ToDateTime(plantilla.FechaCreacion);
            if (fechaInicio.Year != fechaFin.Year)
            {
                //fechaInicio = new DateTime(fechaFin.Year - 1, 12, 31);
                //A partir de ahora cogeremos como fecha de inicio el 01/01
                fechaInicio = new DateTime(fechaFin.Year, 1, 1);
            }


            //En algunas secciones necesitamos que la fecha de inicio sea 31/12 en vez del 01/01
            //Si es la fecha de creación no tenemos que restar 1 día
            if (seccion != null
                && fechaInicio != Convert.ToDateTime(plantilla.FechaCreacion)
                &&
                (
                seccion == typeof(Temp_EvolucionMercados)
                || seccion == typeof(Temp_EvolucionPatrValLiq)
                || seccion == typeof(Temp_EvolucionPatrGuissonaValLiq)
                || seccion == typeof(Temp_EvolucionIndBench)
                || seccion == typeof(Temp_VariacionPatrimonialA)
                || seccion == typeof(Temp_DesgloseGastos)
                ))
            {
                fechaInicio = fechaInicio.AddDays(-1);
            }

            return fechaInicio;
        }

        public static DateTime GetFechaInicio(string codigoIC, DateTime fechaFin)
        {
            var plantilla = Plantillas_DA.GetPlantilla(codigoIC);
            return GetFechaInicio(plantilla, fechaFin);
        }

        public static DateTime GetFechaInicio(string codigoIC, DateTime fechaFin, int idSeccion)
        {
            var plantilla = Plantillas_DA.GetPlantilla(codigoIC);
            Type tipo;

            switch(idSeccion)
            {
                case 5:
                    tipo = typeof(Temp_VariacionPatrimonialA);
                    break;
                //Deberíamos crear, cuando se pueda, VariablesGlobales.TablasSeccionesTipos con el resto de tipos
                default:
                    tipo = null;
                    break;
            }

            return GetFechaInicio(plantilla, fechaFin, tipo);
            
        }


        public static bool EsFondo(int idTipo)
        {
            if (idTipo == 2)//FONDO
            {
                return true;
            }
            return false;
        }

        public static decimal? CheckDecimal(string valor)
        {
            decimal valorConvertido;
            if (Decimal.TryParse(valor, out valorConvertido))
            {
                return valorConvertido;
            }
            return null;
        }

        public static int? CheckInt(string valor)
        {
            int valorConvertido;
            if (int.TryParse(valor, out valorConvertido))
            {
                return valorConvertido;
            }
            return null;
        }

        /// <summary>
        /// Según el caso pasaremos Bpa0 y BpaPrevision1, BpaPrevision1 y BpaPrevision2 o BpaPrevision2 y BpaPrevision3
        /// </summary>
        /// <param name="valorIni"></param>
        /// <param name="valorFin"></param>
        /// <returns></returns>
        public static decimal? GetVariacionBpa(decimal? valorIni, decimal? valorFin)
        {
            decimal? resultado = null;

            if (valorIni != 0)
            {
                resultado = (valorFin - valorIni) / valorIni;
            }
            return resultado;
        }

        public static decimal? GetVariacion(decimal? valorIni, decimal? valorFin)
        {
            decimal? resultado = null;

            if (valorIni != 0)
            {
                resultado = ((valorFin * 100) / valorIni) - 100;                
            }

            return resultado;
        }

        public static decimal? GetVariacionTipoCambio(string divisa, DateTime fechaIni, DateTime fechaFin)
        {
            decimal? resultado = null;
                    
            var divIni = Reports_DA.GetTipoCambioDivisa(divisa, fechaIni).FirstOrDefault();
            var divFin = Reports_DA.GetTipoCambioDivisa(divisa, fechaFin).FirstOrDefault();

            if (divIni != null && divFin != null)
            {
                var cotDivIni = divIni.TipoCambio;
                var cotDivFin = divFin.TipoCambio;

                if (cotDivIni != 0)
                    resultado = cotDivFin / cotDivIni;
            }

                return resultado;
        }

        public static decimal? ValidarValorEnRango(decimal? valor, decimal? min, decimal? max)
        {
            decimal? resultado = null;

            if ((min == null || valor >= min) && (max == null || valor <= max))
            {
                resultado = valor;
            }

            return resultado;
        }
        
        public static decimal PorcentajeVariacion(decimal valorIni, decimal valorFin)
        {
            if (valorIni == valorFin)
                return 0;
            return ((valorFin - valorIni) * 100) / valorIni;
        }

        /// <summary>
        /// Devuelve la última versión (AssemblyFileVersion) almacenada en la base de datos (Tabla Versiones)
        /// </summary>
        /// <returns>AssemblyFileVersion</returns>
        public static string GetLatestVersion()
        {
            return Versiones_DA.GetLatestVersion();
        }


        public static string GetIsinDescripcion(Plantilla plantilla, string isin, DateTime fechaGeneracion)
        {
            var isins = GetIsinsPlantillaByFecha(plantilla.CodigoIc, fechaGeneracion);
            var isinObject = isins.Where(i => i.Isin == isin).FirstOrDefault();
            string desc = isinObject != null ? isinObject.Descripcion : string.Empty;
            return desc;
        }

        
        public static List<Plantillas_Isins_Hist> GetIsinsPlantillaByFecha(string codigoIC, DateTime fechaGeneracion)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //Tendremos que juntar las fechas que están en Plantillas_Secciones desde antes de la fecha solicitada
            var isinsPlantilla = dbContext.Plantillas_Isins.Where(s => s.CodigoIc == codigoIC && s.FechaModificacion < fechaGeneracion);
            //con las que se encuentran en el histórico y pertenecían a la plantilla en dicha fecha
            var isinsHistorico = dbContext.Plantillas_Isins_Hist.Where(s => s.CodigoIc == codigoIC && s.FechaInicio < fechaGeneracion && s.FechaFin > fechaGeneracion);

            var lista = new List<Plantillas_Isins_Hist>();

            foreach (var isin in isinsPlantilla)
            {
                var hist = new Plantillas_Isins_Hist();
                CopyPropertyValues(isin, hist);
                lista.Add(hist);
            }

            foreach (var isin in isinsHistorico)
            {
                var hist = new Plantillas_Isins_Hist();
                CopyPropertyValues(isin, hist);
                lista.Add(hist);
            }

            return lista.ToList();
        }

        /// <summary>
        /// Indica si una plantilla tiene alguna sección con preview
        /// </summary>
        /// <param name="plantilla"></param>
        /// <returns></returns>
        public static bool TienePreviews(Plantilla plantilla)
        {
            var num = plantilla.Plantillas_Secciones.Where(s => s.Seccione.TienePreview).Count();
            //var seccionesPreview = Reports_DA.GetSeccionesConPreviews();
            //int plantillasConPrev = plantilla.Plantillas_Secciones.Where(p => seccionesPreview.Contains(p.IdSeccion)).Count();
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public static decimal? ConvertToBase100(decimal? base100Value, decimal? valueToConvert)
        {
            var result = valueToConvert * 1 / base100Value;
            return result;
        }

        public static decimal? ConvertToBase100(decimal? base100Value, decimal? valueToConvert, decimal? inibase100Value)
        {
            var result = valueToConvert * inibase100Value / base100Value;
            return result;
        }

        public static double? GetTae(double? valLiqFechaInf, DateTime fechaInforme, DateTime fechaCreacion, decimal referenciaTae)
        {
            if (valLiqFechaInf != null)
            {
                double dias = fechaInforme.Subtract(fechaCreacion).Days;
                double refTae = Convert.ToDouble(referenciaTae);
                var tae = Convert.ToDouble(valLiqFechaInf) / refTae;
                double exp = (365 / dias);
                tae = Math.Pow(tae, exp) - 1;
                //fechaInforme = new DateTime(2015, 12, 31);
                //fechaCreacion = new DateTime(1998, 3, 3);
                return tae;
            }
            return null;
        }

        public static IOrderedEnumerable<DateTime> GetFechasEvolucionRentabilidadGuissona(DateTime fechaConstitucion, DateTime fechaInforme)
        {
            List<DateTime> fechas = new List<DateTime>();

            for (int i = fechaConstitucion.Year; i <= fechaInforme.Year; i++)
            {
                //Si anterior al año del informe añadimos el último día del año
                if (i < fechaInforme.Year)
                {
                    fechas.Add(new DateTime(i, 12, 31));
                }
                //Si no añadimos la fecha informe
                else
                {
                    fechas.Add(fechaInforme);
                }
            }
            var fechasOrdenadas = fechas.OrderBy(f => f.Date);
            return fechasOrdenadas;
        }

        public static decimal CalculateFormula(string argExpression)
        {
            /****************Basic Expression Evaluator *************/

            argExpression = argExpression.Replace("[", "");
            argExpression = argExpression.Replace("]", "");
            //NCalc no coge la coma decimal
            argExpression = argExpression.Replace(",", ".");
            //pass string in the evaluation object declaration.
            //Expression z = new Expression(argExpression);
            //command to evaluate the value of the string expression
            try
            {
                var result = Evaluate(argExpression);
                //Double results = Convert.ToDouble(result.ToString());
                var results = Convert.ToDecimal(result.ToString(CultureInfo.CurrentCulture));

                return results;
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Utils/CalculateFormula", ex);
                // Compliance                                           
                throw;
            }

            /*******************************************************************/
        }

        /// <summary>
        /// Hace la diferencia de la fórmula entre la fecha de informe y la fecha de inicio
        /// </summary>
        /// <param name="argExpression"></param>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaInforme"></param>
        /// <returns></returns>
        public static decimal CalculateFormulaCuentasAcumulado(string argExpression, string codigoIC, string isin, DateTime fechaInicio, DateTime fechaInforme)
        {
            var saldoIni = CalculateFormulaCuentas(argExpression, codigoIC, isin, fechaInicio);
            var saldoFin = CalculateFormulaCuentas(argExpression, codigoIC, isin, fechaInforme);

            return saldoFin - saldoIni;
        }
        

        /// <summary>
        /// Devuelve el resultado de una fórmula de cuentas. Recupera el saldo de cada cuenta y resuelve las operaciones
        /// </summary>
        /// <param name="argExpression">La cuenta ha de venir entre corchetes. Admite operaciones aritméticas.</param>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static decimal CalculateFormulaCuentas(string argExpression, string codigoIC, string isin, DateTime fecha)
        {
             decimal result =0;
            if (argExpression!=null)
            {
                //Recuperamos todas las cuentas (texto entre corchetes [])
                ICollection<string> matches = Regex.Matches(argExpression.Replace(Environment.NewLine, ""), @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();
                var formula = argExpression;
                //Tenemos que sustituir el numero de cuenta por el valor total que acumule esa cuenta
                foreach (string match in matches)
                {
                    var pro06 = Reports_DA.GetPRO06(codigoIC, isin, match, fecha);
                    if (pro06 != null)
                    {
                        var patrim = pro06.Rows[0][0].ToString().Replace(".", ",");
                        if (string.IsNullOrEmpty(patrim))
                        {
                            patrim = "0";
                        }
                        formula = formula.Replace("[" + match + "]", patrim);
                    }

                }

                 result = CalculateFormula(formula);
            }
            else
            {
                Log.Info("CalculateFormulaCuentas argExpression es null cas inesperat");
            }

           

            return result;
        }


        /// <summary>
        /// Devuelve el resultado de una fórmula de cuentas. Recupera el saldo de cada cuenta y resuelve las operaciones
        /// </summary>
        /// <param name="argExpression"></param>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static decimal CalculateFormulaCuentasSignoCambiado(string argExpression, string codigoIC, string isin, DateTime fecha)
        {
            //Recuperamos todas las cuentas (texto entre corchetes [])
            ICollection<string> matches = Regex.Matches(argExpression.Replace(Environment.NewLine, ""), @"\[([^]]*)\]").Cast<Match>().Select(x => x.Groups[1].Value).ToList();
            var formula = argExpression;
                        
            //Tenemos que sustituir el numero de cuenta por el valor total que acumule esa cuenta
            foreach (string match in matches)
            {

                var pro06 = Reports_DA.GetPRO06(codigoIC, isin, match, fecha);
                if (pro06 != null)
                {
                    var patrim = pro06.Rows[0][0].ToString().Replace(".", ",");
                    if (string.IsNullOrEmpty(patrim))
                    {
                        patrim = "0";
                    }
                    else
                    {
                        patrim = (decimal.Parse("-1") * decimal.Parse(patrim)).ToString(CultureInfo.CurrentCulture);
                    }
                    
                    formula = formula.Replace("[" + match + "]", patrim);
                }

            }

            var result = CalculateFormula(formula);

            return result;
        }

        private static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }

        public static decimal? GetPorcentaje(decimal valor, decimal total)
        {
            if (total != 0)
            {
                if (valor != 0)
                {
                    var result = (valor * 100) / total;
                    return result;
                }
                return null;
            }
            return 0;
        }

        /// <summary>
        /// Devuelve el patrimonio total a la fecha solicitada
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static decimal GetPatrimonio(string codigoIC, string isin, DateTime fecha)
        {
            try
            {
                decimal result = 0;
                DataTable dt = Reports_DA.GetPRO12(codigoIC, isin, fecha);
                if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["patrimonio"].ToString()))
                {
                    result = dt.AsEnumerable().Sum(r => r.Field<decimal>("patrimonio"));
                    //result = Convert.ToDecimal(Utils.CheckDecimal(dt.Rows[0]["patrimonio"].ToString()));
                }

                return result;
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Utils/GetPatrimonio", ex);
                // Compliance                                           
                throw;
            }
        }
        

        /// <summary>
        /// Devuelve todos los días entre dos fechas (ambas incluidas).
        /// </summary>
        /// <param name="fechaIni"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<DateTime?> GetDiasEntreFechas(DateTime fechaIni, DateTime fechaFin)
        {
            var selectedDates = new List<DateTime?>();
            for (var fecha = fechaIni; fecha <= fechaFin; fecha = fecha.AddDays(1))
            {
                selectedDates.Add(fecha);
            }

            return selectedDates;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }        

        public static IEnumerable<string> GetIsinsPlantilla(Plantilla plantilla)
        {
            return plantilla.Plantillas_Isins.Select(s => s.Isin.ToUpper());
        }

        public static List<GenericProcs> ExcluirIsinsPlantilla(Plantilla plantilla, IEnumerable<GenericProcs> proc)
        {
            return proc.Where(w => !plantilla.Plantillas_Isins.Select(s => s.Isin).Contains(w.Isin, StringComparer.CurrentCultureIgnoreCase)).ToList();
        }

        public static List<string> ExcluirIsinsPlantilla(Plantilla plantilla, List<string> listaIsins)
        {
            return listaIsins.Where(w => !plantilla.Plantillas_Isins.Select(s => s.Isin).Contains(w, StringComparer.CurrentCultureIgnoreCase)).ToList();
        }

        public static void WriteLog(string message)
        {
            Log.Error(message);
        }

        public static void WriteTextDoc(string message)
        {
            // create the output text buffer
            var buffer = new StringBuilder();
            // add text
            buffer.AppendLine(message);
            // write to file
            File.AppendAllText("C:\\Users\\Usuario\\Desktop\\temp\\pruebas\\pruebas.txt", buffer.ToString());
        }

        public static decimal GetMediaPonderada()
        {
            return 0;
        }

        public static string GetIdInstrumentoByCod(string cod)
        {
            var lista = Instrumentos_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Id;
        }

        public static string GetDescInstrumentoByCod(string cod)
        {
            var lista = Instrumentos_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Descripcion;
        }

        public static string GetDescInstrumentosTipoByCod(string cod)
        {
            var lista = InstrumentosTipos_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Descripcion;
        }

        public static string GetDescInstrumentosCategoriaByCod(string cod)
        {
            var lista = InstrumentosCategorias_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Descripcion;
        }

        public static string GetDescInstrumentosEmpresaByCod(string cod)
        {
            var lista = InstrumentosEmpresas_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Descripcion;
        }

        public static string GetIdInstrumentoTipoByCod(string cod)
        {
            var lista = InstrumentosTipos_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            return obj?.Id;
        }

        public static int GetIdInstrumentoCategoriaByCod(string cod)
        {
            var lista = InstrumentosCategorias_Local;

            var obj = lista.FirstOrDefault(w => w.Codigo == cod);

            if (obj != null)
            {
                return obj.Id;
            }
            return new int();
        }

        public static int GetIdInstrumentoEmpresaByCod(string cod)
        {
            var lista = InstrumentosEmpresas_Local;

            var obj = lista.Where(w => w.Codigo == cod).FirstOrDefault();

            if (obj != null)
            {
                return obj.Id;
            }
            return new int();
        }

        public static int GetIdInstrumentoSectorByDesc(string desc)
        {
            var lista = InstrumentosSectores_Local;

            var obj = lista.Where(w => w.Descripcion == desc).FirstOrDefault();

            if (obj != null)
            {
                return obj.Id;
            }
            return new int();
        }

        public static int GetIdInstrumentoZonaByCod(string cod)
        {
            var lista = InstrumentosZonas_Local;

            var obj = lista.Where(w => w.Codigo == cod).FirstOrDefault();

            if (obj != null)
            {
                return obj.Id;
            }
            return new int();
        }

        public static int GetIdInstrumentoPaisByCod(string cod)
        {
            var lista = InstrumentosPaises_Local;

            var obj = lista.Where(w => w.Codigo == cod).FirstOrDefault();

            if (obj != null)
            {
                return obj.Id;
            }
            return new int();
        }

        public static Boolean? ParseSiNoToBoolean(string texto)
        {
            if (texto.Equals("Sí", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (texto.Equals("No", StringComparison.CurrentCultureIgnoreCase))
                return false;
            return null;
        }

        public static decimal SumarNulos(decimal? valor1, decimal? valor2)
        {
            return (valor1 != null ? Convert.ToDecimal(valor1) : 0) + (valor2 != null ? Convert.ToDecimal(valor2) : 0);
        }

        public static bool EqualsIgnoreCase(string a, string b)
        {
            int resultado = string.Compare(a, b, StringComparison.InvariantCultureIgnoreCase);
            //return Regex.IsMatch(a, b, RegexOptions.IgnoreCase);
            if (resultado == 0)
                return true;
            return false;
        }


        /// <summary>
        /// Convierte el string que recuperamos de BIA para el campo grupo a un int
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static int GetGrupoInt(string grupo)
        {
            int resultado = 0;
            List<string> subStrings = new List<string> { "1", "2", "3", "4" };

            if (!string.IsNullOrEmpty(grupo))
            {
                switch (subStrings.FirstOrDefault(grupo.Contains))
                {
                    case "1":
                        resultado = 1;
                        break;
                    case "2":
                        resultado = 2;
                        break;
                    case "3":
                        resultado = 3;
                        break;
                    case "4":
                        resultado = 4;
                        break;
                }
            }
            return resultado;
        }

        public static void ChangeGroup(usp_gestio_pro_13_Result item, int grupoNew)
        {
            switch(grupoNew)
            {
                case 1:
                    item.Estado = "OPEN";
                    item.TipoO = "C";
                    item.FechaC = null;
                    item.ClamovF = null;
                    item.TipMovF = null;
                    item.PrecioC = null;
                    item.CambioC = null;
                    item.TipoC = "";
                    item.NumC = null;
                    break;
                case 2:
                    item.Estado = "CLOSE";
                    item.TipoO = "C";
                    break;
                case 3:
                    item.Estado = "CLOSE";
                    item.TipoO = "M";
                    break;
                case 4:
                    item.Estado = "OPEN";
                    item.TipoO = "M";
                    item.FechaC = null;
                    item.ClamovF = null;
                    item.TipMovF = null;
                    item.PrecioC = null;
                    item.CambioC = null;
                    item.TipoC = "";
                    item.NumC = null;
                    break;
            }

            //En los grupos 1 y 4 CambioC es NULL. Si vamos de uno de estos grupos y vamos a 2 ó 3 cogeremos ese valor de CambioF
            if(GetGrupoInt(item.Grupo) == 1 || GetGrupoInt(item.Grupo) == 4)
            {
                item.CambioC = item.CambioF;
                item.PrecioC = item.PrecioF;
            }

            item.GrupoNuevo = grupoNew;
        }

        

        public static string CommaSeparatedStringFromList(List<string> lista)
        {
            var resultado = string.Join(", ", lista);
            return resultado;
        }

        public static string SpaceSeparatedStringFromList(List<string> lista)
        {
            var resultado = string.Join(" ", lista);
            return resultado;
        }

        public static void PruebasExcel()
        {
            var plantilla = new Plantilla {CodigoIc = "214"};
            SetVariablesGlobales();
            var objToExcel = Reports_DA.GetPRO09(plantilla, new DateTime(2017, 1, 1), new DateTime(2017, 12, 31)).ToList();

            DataTable dt = ConvertToDataTable(objToExcel);
            UtilsExcel.Export2Excel(dt);
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ConvertListToDataTable<T>(IList<T> thisList, string nombreColumna)
        {
            DataTable dt = new DataTable();

            if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                DataColumn dc = new DataColumn(nombreColumna);
                dt.Columns.Add(dc);

                foreach (T item in thisList)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item;
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                PropertyInfo[] propertyInfo = typeof(T).GetProperties();
                foreach (PropertyInfo pi in propertyInfo)
                {
                    DataColumn dc = new DataColumn(pi.Name, pi.PropertyType);
                    dt.Columns.Add(dc);
                }

                for (int item = 0; item < thisList.Count(); item++)
                {
                    DataRow dr = dt.NewRow();
                    for (int property = 0; property < propertyInfo.Length; property++)
                    {
                        dr[property] = propertyInfo[property].GetValue(thisList[item], null);
                    }
                    dt.Rows.Add(dr);
                }
            }

            dt.AcceptChanges();

            return dt;
        }


        public static string FormatErrorSeccion(string seccion, string nombrePlantilla, DateTime fechaGeneracion)
        {
            return string.Format(Resource.ErrorSeccion + "{0} para {1} a {2}", seccion, nombrePlantilla, fechaGeneracion.ToShortDateString());
        }

        /// <summary>
        /// No podemos almacenar más de 20 decimales en la base de datos y en ocasiones tenemos que comparar
        /// cálculos hechos por la aplicación (sín límite de decimales) con algún dato almacenado en la bd.
        /// Si es "num" es distinto de null lo redondearemos a 20 decimales
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static decimal? RoundTo20(decimal? num)
        {
            if (num != null)
            {
                num = decimal.Round((decimal)num, 20);
            }

            return num;
        }

        /// <summary>
        /// Cuando haces SUM de valores NULL devuelve 0. Este método sustituye a SUM para LINQ
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static decimal? NullableSum(this IEnumerable<decimal?> values)
        {
            return values.Aggregate((decimal?)0, (sum, value) => sum + value);
        }

        public static List<usp_gestio_pro_13_Result> GetPro13SeccRv(Plantilla plantilla, DateTime fecha)
        {
            if (Pro13_Local == null)
            {
                SetVariablesGlobales(typeof(usp_gestio_pro_13_Result), plantilla, fecha);
            }
            var resultado = new List<usp_gestio_pro_13_Result>();

            if (Pro13_Local != null)
                resultado =  Pro13_Local.Where(w =>
                    //Permitimos los TipMovO = 805 cuando cumplan otras condiciones
                        (w.TipMovO != "805" || (w.TipMovO == "805" && w.TipMovF == "700" && w.EfectivoFEUR >
                                                Convert.ToDecimal(ConfigurationManager.AppSettings["13_EfectivoFEUR"])))
                        && (w.TipMovO != "816" || (w.TipMovO == "816" && w.TipMovF == "700"))
                        && (w.TipMovO != "817" || (w.TipMovO == "817" && w.TipMovF == "700"))
                ).ToList();

            return resultado;
        }

        public static void SendEmail(string subject, string body, string to, string equipo, string codigoIC = null, DateTime? fechaInforme = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("erroresreports@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                body += Environment.NewLine;
                body += "Código IC: " + codigoIC;
                body += Environment.NewLine;
                body += "Fecha Informe: ";
                body += fechaInforme != null ? Convert.ToDateTime(fechaInforme).ToShortDateString() : string.Empty;
                body += Environment.NewLine;
                body += "Equipo: " + equipo;

                mail.Body = body;

                smtpServer.Port = 587;
                //Para enviar el email de forma anónima
                smtpServer.Credentials = new NetworkCredential("erroresreports", "passErRep17");
                smtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Log.Error("Error Utils/SendEmail", ex);
                throw;
            }
        }

        public static void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static string GetEquipo()
        {
            string localIp = string.Empty;
            string domain = IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string nombreHost = Dns.GetHostName();

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                    break;
                }
            }
            string ipWidHost = string.Format("[Domain-{0} : Host-{1} : IP-{2}]", domain, nombreHost, localIp);

            return ipWidHost;
        }

        public static string GetErrorProcAndParams(string nombreProc, List<SqlParameter> listaParametros)
        {
            string output = string.Empty;

            output += string.Format("Procedimiento: {0}", nombreProc);

            foreach (var param in listaParametros)
            {
                output += Environment.NewLine;
                output += string.Format("{0}: {1}", param.ParameterName, param.Value.ToString());
            }

            return output;
        }


        /// <summary>
        /// Teniendo en cuenta el indicador "Clases" de la tabla Plantillas_Isins devolveremos los isins 
        /// asignados a esta plantilla o una una lista con un elemento nulo en caso de que el 
        /// indicador sea "False"
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="seccion" />
        /// <returns></returns>
        public static List<Plantillas_Isins> GetPlantillasIsinsClases(Plantilla plantilla, Seccione seccion)
        {
            var output = new List<Plantillas_Isins>();

            if (seccion.Clases)
            {
                output = plantilla.Plantillas_Isins.ToList();
            }
            else
            {
                output.Add(new Plantillas_Isins
                {
                    CodigoIc = plantilla.CodigoIc,
                    Isin = null,
                    Descripcion = string.Empty
                });
            }

            return output;
        }

        public static bool ShowDialogPopup(string mensaje)
        {
            bool output = false;

            RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 },
                        delegate (object windowSender, WindowClosedEventArgs args)
                        {
                            if (args.DialogResult == true)
                            {
                                output = true;
                            }
                            else
                            {
                                output = false;
                            }
                        });

            return output;
        }

        public static void ShowDialogWindow(Window window)
        {
            if (window != null)
            {
                if (System.Windows.Application.Current.MainWindow != window)
                {
                    window.Owner = System.Windows.Application.Current.MainWindow;
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (window.Owner as MetroWindow);
                    if (ownerMetroWindow != null)
                    {
                        ownerMetroWindow.Height = window.Height;
                        ownerMetroWindow.Width = window.Width;
                        ownerMetroWindow.MinHeight = window.MinHeight;
                        ownerMetroWindow.MinWidth = window.MinWidth;
                        if (!ownerMetroWindow.IsOverlayVisible())
                            ownerMetroWindow.ShowOverlayAsync();
                    }
                }

                window.ShowDialog();

                window.Owner = System.Windows.Application.Current.MainWindow;
                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                if (ownerMetroWindow2 != null && ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();                
            }            
        }

        public static void ShowDialog(string mensaje)
        {
            //RadWindow.Alert(new TextBlock { Text = mens, TextWrapping = TextWrapping.Wrap, Width = 400 });
            RadWindow radWindow = new RadWindow();
            radWindow.Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 };
            //radWindow.Content = mensaje;
            radWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //radWindow.Width = 400;            
            radWindow.Header = "Reports IICs";
            radWindow.Owner = (MainWindow)System.Windows.Application.Current.MainWindow;
            radWindow.Padding = new Thickness(10,20,10,20);
            radWindow.ResizeMode = ResizeMode.NoResize;       
            
            radWindow.ShowDialog();
        }

        public static bool NotNullAndNotZero(decimal? valor)
        {
            if (valor != null && valor != 0)
                return true;
            return false;
        }

        public static bool IsDecimal(string valor)
        {
            decimal num;
            return decimal.TryParse(valor, out num);
        }

        public static string GetEstadoByGrupo(int grupo)
        {
            string output;

            if (grupo == 1
                            || grupo == 4)
            {
                output = "OPEN";
            }
            else
            {
                output = "CLOSE";
            }

            return output;
        }
        public static string GetTipoOByGrupo(int grupo)
        {
            string output;

            if (grupo == 1
                || grupo == 2)
            {
                output = "C";
            }
            else
            {
                output = "M";
            }

            return output;
        }

        /// <summary>
        /// Nos dice si el codigoIC pertenece a CCR, Volga o Gamar
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <returns></returns>
        public static bool EsCCR_Volga_Gamar(string codigoIC)
        {
            var cods = new List<string> { "384", "386", "396", "421" };
            if (cods.Contains(codigoIC))
                return true;
            return false;
        }

        /// <summary>
        /// Lo utilizamos para centrar paneles en los reports. Sobre todo porque hay algunas secciones que se pueden mostrar en Portrait o en Lanscape (las de CCR, VOLGA y GAMAR siempre en Landscape pero cuando se generan para otras plantillas puede que se muestren en Portrait)
        /// </summary>
        /// <param name="codigoIc"></param>
        /// <param name="rep"></param>
        /// <param name="pnl"></param>
        public static void CenterPanel(string codigoIc, Report rep, Panel pnl)
        {
            //double anchoPortrait = 21;
            double anchoLandscape = 29.7;
            double ancho = anchoLandscape; //por defecto

            double x = Convert.ToDouble(ancho - pnl.Width.Value) / 2;
            x = x - (rep.PageSettings.Margins.Left.Value / 10);//Dividmos entre 10 porque viene en mm y estamos trabajando en cms
            pnl.Location = new PointU(Unit.Cm(x), pnl.Location.Y);
        }

        public static bool CreadaAñoInforme(Plantilla plantilla, DateTime fechaInforme)
        {
            if (plantilla.FechaCreacion.Year == fechaInforme.Year)
                return true;
            return false;
        }

        /// <summary>
        /// Elimina los ceros decimales a la derecha
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static decimal RemoveTrailingZeros(decimal num)
        {
            return Convert.ToDecimal(num.ToString("0.####################"));
        }

        public static bool EsDesarrollo()
        {
            var con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Reports_IICs.Properties.Settings.ReportsIICS_Reports"].ConnectionString);
            var con2 = new Reports_IICSEntities().Database.Connection;

            //192.168.253.20 es el servidor de producción
            //Si no tenemos las dos conexiones apuntando a la base de datos de real, indicaremos que estamos en desarrollo
            if (con1.DataSource != "192.168.253.20" || con2.DataSource != "192.168.253.20")
                return true;
            return false;
        }

        /// <summary>
        /// Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool CellHasChanged(object oldValue, object newValue)
        {
            //Para comparar correctamente no tenemos en cuenta los ceros decimales de la derecha
            if (oldValue != null && oldValue.GetType() == typeof(decimal))
            {
                oldValue = Utils.RemoveTrailingZeros(Convert.ToDecimal(oldValue));
            }
            if (newValue != null && newValue.GetType() == typeof(decimal))
            {
                newValue = Utils.RemoveTrailingZeros(Convert.ToDecimal(newValue));
            }

            if (oldValue == null)
                oldValue = string.Empty;

            if (newValue == null)
                newValue = string.Empty;

            if (oldValue.ToString() != newValue.ToString())
                return true;
            else
                return false;
        }
    }
}
