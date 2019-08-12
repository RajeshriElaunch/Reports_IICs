using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Reports_IICs.DataAccess.Bloomberg;

namespace Reports_IICs.Pages.Importar
{
    /// <summary>
    /// Interaction logic for ImportarBloomberg.xaml
    /// </summary>
    public partial class ImportarBloomberg : UserControl
    {
        private DataTable _dt = new DataTable();
        private List<Bloomberg> _listaBloomberg;
        private List<string> _listaErrores;
        private int? _año;
        private int? _columnaEstimacion;
        private const string _cadenaNula = "#N/A";
        //private List<string> _caracteresBorrar = new List<string>() { "u", "*-", "*+", "*", "(P)" };
        /// <summary>
        /// Caracteres especiales que  no deben tenerse en cuenta para recuperar la equivalencia de ratings
        /// </summary>
        private Dictionary<string, string> _replacements  = new Dictionary<string, string> {
            { "u", "" },
            { "*-", "" },
            { "*+", "" },
            { "*", "" },
            { "(P)", "" }
        };

        public ImportarBloomberg()
        {
            InitializeComponent();
        }

        private void ButtonExaminar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;


            _listaBloomberg = new List<Bloomberg>();
            _listaErrores = new List<string>();


            //IQueryable<LinqToExcel.Row> datosExcel = null;
            IEnumerable<LinqToExcel.Row> datosExcel = null;

            int millisecondsTimeout = 500;
            Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Leyendo Excel", () =>
            {
                datosExcel = Utils.GetExcelDatos(ref _listaErrores);
                Thread.Sleep(millisecondsTimeout);
            });


            //if (datosExcel != null)
            if (_listaErrores.Count() == 0)
            {
                millisecondsTimeout = 500;
                result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Validando Excel", () =>
                {
                    int i = 0;
                    foreach (var a in datosExcel)
                    {
                        var bloom = new Bloomberg();

                        if (i == 0)
                        {
                            _columnaEstimacion = Utils.CheckInt(a["COLUMNA ESTIMACIÓN"]);
                            _año = Utils.CheckInt(a["AÑO"]);
                        }
                        if (_columnaEstimacion != null && _año != null)
                        {
                            bloom.ColumnaEstimacion = Convert.ToInt32(_columnaEstimacion);
                            bloom.Año = Convert.ToInt32(_año);
                            bloom.ISIN = a["Isin"].ToString().Trim().ToUpper();
                            bloom.Capitalizacion = Utils.CheckDecimal(a["Capitalización (millones)"]);
                            bloom.Bpa0 = Utils.CheckDecimal(a["Bpa 0"]);
                            bloom.BpaPrevision1 = Utils.CheckDecimal(a["Bpa previsión 1"]);
                            bloom.BpaPrevision2 = Utils.CheckDecimal(a["Bpa previsión 2"]);
                            bloom.BpaPrevision3 = Utils.CheckDecimal(a["Bpa previsión 3"]);
                            bloom.RentabilidadDividendo1 = Utils.CheckDecimal(a["Rentabilidad dividendo 1"].ToString().Replace("%",""));
                            bloom.RentabilidadDividendo2 = Utils.CheckDecimal(a["Rentabilidad dividendo 2"].ToString().Replace("%", ""));
                            bloom.RentabilidadDividendo3 = Utils.CheckDecimal(a["Rentabilidad dividendo 3"].ToString().Replace("%", ""));
                            bloom.Per1 = Utils.CheckDecimal(a["Per 1"]);
                            bloom.Per2 = Utils.CheckDecimal(a["Per 2"]);
                            bloom.Per3 = Utils.CheckDecimal(a["Per 3"]);
                            bloom.DeudaNetaCapitalizacion = Utils.CheckDecimal(a["Deuda neta / capitalización"]);
                            bloom.PrecioVc = Utils.CheckDecimal(a["Precio / VC"]);
                            bloom.ValorFundamental = Utils.CheckDecimal(a["Valor fundamental"]);
                            bloom.GvcBloomberg = a["GVC o Bloomberg"] == "G" || a["GVC o Bloomberg"] == "B" ? a["GVC o Bloomberg"] : null;
                            bloom.DescuentoFundamental = Utils.CheckDecimal(a["Descuento fundamental"].ToString().Replace("%", ""));
                            bloom.Precio = Utils.CheckDecimal(a["precio"]);

                            bloom.MoodyDate = getRatingDate(a["Moody date"]);
                            bloom.SPDate = getRatingDate(a["S&P date"]);
                            bloom.FitchDate = getRatingDate(a["fitch date"]);

                            bloom.MoodyRating = getRatingString(a["rating Moody"]);
                            bloom.SPRating = getRatingString(a["rating S&P"]);
                            bloom.FitchRating = getRatingString(a["rating Fitch"]);

                            i++;
                            _listaBloomberg.Add(bloom);
                        }
                    }

                    validar();
                    Thread.Sleep(millisecondsTimeout);
                });
                if (_listaErrores.Count() > 0)
                {
                    //Mostramos errores
                    //mostrar errores
                    string mensajeError = "El documento tiene valores no permitidos. Corríjalos antes de realizar la importación." + Environment.NewLine;
                    foreach (var mens in _listaErrores)
                    {
                        mensajeError += mens + Environment.NewLine;
                    }
                    //MessageBox.Show(mensajeError, "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Reports_IICs.ViewModels.Reports.ReportVM.ShowErrorWindow("Importación de instrumentos", mensajeError);
                }
                else
                {
                    this.ButtonGuardar.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                //Concatenamos todos los mensajes de la _listaErrores separados por un salto de línea
                //RadWindow.Alert(new TextBlock { Text = string.Join(Environment.NewLine, _listaErrores), TextWrapping = TextWrapping.Wrap, Width = 400 });
                Utils.ShowDialog(string.Join(Environment.NewLine, _listaErrores));
            }
        }

        private string getRatingString(string input)
        {            
            if (input.Contains(_cadenaNula))
                return null;
            else
            {                
                //Tenemos que eliminar los caracteres especials _caracteresBorrar de valor
                var output = _replacements.Aggregate(input, (current, replacement) => current.Replace(replacement.Key, replacement.Value)).Trim();
                return output;
            }                
        }

        private DateTime? getRatingDate(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Contains(_cadenaNula))
                return null;
            else
            {
                var output = Convert.ToDateTime(input);
                return output;
            }
        }

        private void validar()
        {
            //Columna estimación
            if(_columnaEstimacion == null)
                _listaErrores.Add("El campo 'COLUMNA ESTIMACIÓN' no es correcto");

            //Año
            if (_año == null)
                _listaErrores.Add("El campo 'AÑO' no es correcto");

            //isins
            List <string> incorrectos = _listaBloomberg.GroupBy(x => x.ISIN.ToUpper()).Where(g => g.Count() > 1).Select(s => s.Key).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS están duplicados: {0}", string.Join(",", incorrectos)));

            //GvcBloomberg
            incorrectos = _listaBloomberg.Where(w => string.IsNullOrEmpty(w.GvcBloomberg)).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "GVC o Bloomberg", string.Join(",", incorrectos)));
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            string mensaje = string.Empty;
            if (_listaErrores.Count() > 0)
            {
                mensaje = "No puede importar el documento hasta que no corrija los documentos. " + _listaErrores.ToString();
                //RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
                Utils.ShowDialog(mensaje);
            }
            else
            {
                //Guardamos los instrumentos
                bool guardado = false;

                int millisecondsTimeout = 500;
                Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Importando", () =>
                {
                    guardado = ImportarBloomberg_DA.GuardarBloombergs(_listaBloomberg);
                    Thread.Sleep(millisecondsTimeout);
                });
                if (guardado)
                {
                    //Actualizamos la variable local
                    VariablesGlobales.SetVariablesGlobales(null);
                    mensaje = "La importación ha finalizado correctamente.";
                    //RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
                    Utils.ShowDialog(mensaje);
                }
                else
                {
                    this.ButtonGuardar.Visibility = System.Windows.Visibility.Hidden;
                    mensaje = "Se ha producido un error y no ha sido posible realizar la importación.";
                    //RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
                    Reports_IICs.ViewModels.Reports.ReportVM.ShowErrorWindow("Importación de instrumentos", mensaje);
                }
            }
            /*
            if (_tieneDatos)
            {
                //Si no hay errores guardamos los instrumentos importados
                if (_errores.Count == 0)
                {
                    try
                    {
                        Bloomberg_VM.GuardarBloomberg(_dt, _año, _columnaEstimacion);
                        MessageBox.Show("La importación ha finalizado correctamente.", "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Se ha producido un error y no se han podido guardar los datos. " + ex.Message, "Importación de Bloomberg", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    //mostrar errores
                    string mensajeError = "El documento tiene valores no permitidos. Corríjalos antes de realizar la importación." + Environment.NewLine;
                    for (int i = 0; i < _errores.Count; i++)
                    {
                        mensajeError += "Columna '" + _errores[i].Item1 + "' valor '" + _errores[i].Item2 + "'." + Environment.NewLine;
                    }
                    // MessageBox.Show(mensajeError, "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Reports_IICs.ViewModels.Reports.Report_VM.ShowErrorWindow("Importación de instrumentos", mensajeError);
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado ningún registro válido en el documento.", "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Information);
            }*/
        }

        List<string> IsinList = new List<string>();

        private void DataGridBloomberg_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = e.Row;


            if (row != null)

            {
                if(IsinList.Exists(x=>x.ToString().ToLower()== ((System.Data.DataRowView)e.Row.DataContext).Row.ItemArray[0].ToString().ToLower()))
                {
                    var converter = new System.Windows.Media.BrushConverter();
                    var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");
                    
                    row.Background = brush;
                    string value = "El Código Isin ya existe";
                    (((System.Data.DataRowView)e.Row.DataContext).Row).BeginEdit();
                        DataRowView dvr = (DataRowView)e.Row.DataContext;
                        dvr["CHECK"] = value;
                        e.Row.DataContext = dvr;
                    
                    (((System.Data.DataRowView)e.Row.DataContext).Row).EndEdit();
                    this.ButtonGuardar.IsEnabled = false;
                }
                else
                {
                    IsinList.Add(((System.Data.DataRowView)e.Row.DataContext).Row.ItemArray[0].ToString());
                }

            }
        }
    }
}
