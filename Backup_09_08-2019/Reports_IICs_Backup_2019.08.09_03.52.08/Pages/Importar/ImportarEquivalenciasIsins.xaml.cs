using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Telerik.Windows.Controls;
using Reports_IICs.DataAccess.Importar;

namespace Reports_IICs.Pages.Importar
{
    /// <summary>
    /// Interaction logic for ImportarBloomberg.xaml
    /// </summary>
    public partial class ImportarEquivalenciasIsins : UserControl
    {
        List<LinqToExcel.Row> _datosExcel;
        private List<RentaVariable_Equivalencias> _listaEq;
        private List<string> _listaErrores;
        private Dictionary<int, string> _columnasValidar = new Dictionary<int, string>() {
        { 0, "Nombre" },
        { 1, "IsinDerechos" },
        { 2, "OldIsin" },
        { 3, "NewIsin" },
        { 4, "FechaIniDerechos" },
        { 5, "FechaSuscripcion" },
        { 6, "FechaEquiparacion" },
        { 7, "FactorAjuste" },
        { 8, "TipoOperacion" }
        };

        public ImportarEquivalenciasIsins()
        {
            InitializeComponent();
        }

        private void ButtonExaminar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            _listaEq = new List<RentaVariable_Equivalencias>();
            _listaErrores = new List<string>();

            _datosExcel = null;

            int millisecondsTimeout = 500;
            Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Leyendo Excel", () =>
            {
                try
                {
                    _datosExcel = Utils.GetExcelDatos(ref _listaErrores).ToList();
                    validarColumnas();
                    validar();
                    Thread.Sleep(millisecondsTimeout);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            });

            //if (datosExcel != null)
            if(_listaErrores.Count() == 0)
            {                
                millisecondsTimeout = 500;
                result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Validando Excel", () =>
                {
                    foreach (var a in _datosExcel)
                    {
                        var eq = new RentaVariable_Equivalencias();

                        eq.Nombre = a["Nombre"].ToString();
                        eq.OldIsin = a["OldIsin"].ToString().ToUpper();
                        eq.NewIsin = a["NewIsin"].ToString().ToUpper();
                        eq.IsinDerechos = a["IsinDerechos"].ToString().ToUpper();
                        eq.FechaEquiparacion = !string.IsNullOrEmpty(a["FechaEquiparacion"].ToString()) ? Convert.ToDateTime(a["FechaEquiparacion"].ToString()) : (DateTime?)null;
                        eq.FechaIniDerechos = !string.IsNullOrEmpty(a["FechaIniDerechos"].ToString()) ? Convert.ToDateTime(a["FechaIniDerechos"].ToString()) : (DateTime?)null;
                        eq.FechaSuscripcion= !string.IsNullOrEmpty(a["FechaSuscripcion"].ToString()) ? Convert.ToDateTime(a["FechaSuscripcion"].ToString()) : (DateTime?)null;
                        var fact = Utils.CheckDecimal(a["FactorAjuste"]);
                        if (fact != null)
                        {
                            eq.FactorAjuste = (decimal)fact;
                        }
                        eq.TipoOperacion = a["TipoOperacion"].ToString().ToUpper();
                        _listaEq.Add(eq);
                    }
                    
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
                string mensaje = string.Join(Environment.NewLine, _listaErrores);
                this.ButtonGuardar.Visibility = System.Windows.Visibility.Hidden;
                Utils.ShowDialog(mensaje);
                //RadWindow.Alert(new DialogParameters { Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, Header = Resource.HeaderGVC_MessageBox });
            }
        }
        
        private void validarColumnas()
        {
            if (_datosExcel != null && _datosExcel.Count() >0)
            {
                var colsExcel = _datosExcel.FirstOrDefault().ColumnNames.ToList();
                foreach(var col in _columnasValidar)
                {
                    if(colsExcel[col.Key] != col.Value)
                    {
                        _listaErrores.Add(string.Format(Resource.ColumnaExcelErronea, col.Value));
                    }
                }
            }
        }
        private void validar()
        {
            validarValores("OldIsin", true, typeof(string));
            validarValores("NewIsin", true, typeof(string));
            validarValores("TipoOperacion", true, typeof(string));
            /*
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
            */
        }

        private void validarValores(string nombreCol, bool obligatorio, Type tipoRequerido = null)
        {
            string textoColFormErr = "La columna {0} tiene valores no permitidos:";
            string errorTmp = string.Empty;

            //Buscamos las filas que tengan un valor no permitido para la columna            
            var errs = new List<LinqToExcel.Row>();
            if (obligatorio)
            {
                errs = _datosExcel.Where(w => string.IsNullOrEmpty(w[nombreCol])).ToList();
            }

            if (tipoRequerido != null)
            {
                if (tipoRequerido == typeof(decimal))
                {
                    errs = _datosExcel.Where(w => !Utils.IsDecimal(w[nombreCol])).ToList();
                }
            }

            if (errs.Count() > 0)
            {
                string mens = string.Format(textoColFormErr, nombreCol);

                foreach (var item in errs)
                {
                    mens += Environment.NewLine;
                    mens += "- " + Utils.SpaceSeparatedStringFromList(new List<string>()
                    {
                        item["Nombre"],
                        item["OldIsin"],
                        item["NewIsin"]
                    });
                }

                _listaErrores.Add(mens);
            }
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            string mensaje = string.Empty;
            if (_listaErrores.Count() > 0)
            {
                mensaje = "No puede importar el documento hasta que no corrija los errores. " + _listaErrores.ToString();
                RadWindow.Alert(new DialogParameters { Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, Header = Resource.HeaderGVC_MessageBox });                
            }
            else
            {
                //Guardamos los instrumentos
                bool guardado = false;

                int millisecondsTimeout = 500;
                Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Importando", () =>
                {
                    guardado = EquivalenciasIsins_DA.Save(_listaEq);
                    Thread.Sleep(millisecondsTimeout);
                });
                if (guardado)
                {
                    //Actualizamos la variable local
                    VariablesGlobales.SetVariablesGlobales(typeof(RentaVariable_Equivalencias));
                    mensaje = "La importación ha finalizado correctamente.";
                    RadWindow.Alert(new DialogParameters { Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, Header = Resource.HeaderGVC_MessageBox });                    
                }
                else
                {
                    this.ButtonGuardar.Visibility = System.Windows.Visibility.Hidden;
                    mensaje = "Se ha producido un error y no ha sido posible realizar la importación.";
                    RadWindow.Alert(new DialogParameters { Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, Header = Resource.HeaderGVC_MessageBox });
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
