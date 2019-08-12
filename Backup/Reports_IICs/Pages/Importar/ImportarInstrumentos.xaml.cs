using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Importar
{
    /// <summary>
    /// Interaction logic for ImportarInstrumentos.xaml
    /// </summary>
    public partial class ImportarInstrumentos : UserControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataTable _dt = new DataTable();
               
        private List<Instrumentos_Importados> _listaInstrumentos;
        private List<string> _listaErrores;

        public ImportarInstrumentos()
        {
            InitializeComponent();
        }

        private void ButtonExaminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                //limpiamos el registro de errores cuando cargan un nuevo documento

                _listaInstrumentos = new List<Instrumentos_Importados>();
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
                        foreach (var a in datosExcel)
                        {
                            var instr = new Instrumentos_Importados();
                            if (!string.IsNullOrEmpty(a["Isin"]))
                            {
                                instr.ISIN = a["Isin"].ToString().Trim().ToUpper();

                                if(instr.ISIN.ToUpper() == "ES0115056139")
                                {

                                }

                                instr.IdTipoInstrumento = Utils.GetIdInstrumentoTipoByCod(a["Tipo"]);
                                instr.IdTipoInstrumento2 = Utils.GetIdInstrumentoTipoByCod(a["Tipo2"]);
                                instr.IdTipoInstrumento3 = Utils.GetIdInstrumentoTipoByCod(a["Tipo3"]);

                                //Permitimos null pero no un valor erróneo
                                int? idSector = null;
                                if (!string.IsNullOrEmpty(a["Sector"]))
                                {
                                    idSector = Utils.GetIdInstrumentoSectorByDesc(a["Sector"]);
                                }

                                instr.IdSector = idSector;
                                instr.Emergente = Utils.ParseSiNoToBoolean(a["Emergente"]);

                                //Permitimos null pero no un valor erróneo
                                int? idCategoria = null;
                                if (!string.IsNullOrEmpty(a["Categoría"]))
                                {
                                    idCategoria = Utils.GetIdInstrumentoCategoriaByCod(a["Categoría"]);
                                }
                                instr.IdCategoria = idCategoria;
                                instr.IdEmpresa = Utils.GetIdInstrumentoEmpresaByCod(a["Empresa"]);
                                instr.IdInstrumento = Utils.GetIdInstrumentoByCod(a["Instrumento"]);
                                instr.IdZona = Utils.GetIdInstrumentoZonaByCod(a["Zona"]);
                                instr.IdPais = Utils.GetIdInstrumentoPaisByCod(a["País"]);
                                instr.TickerBloomberg = a["TICKER BLOOMBERG"];
                                if (!string.IsNullOrEmpty(a["PUNTUACIÓN SMALL-BIG"]))
                                    instr.PuntuacionSmallBig = Convert.ToDecimal(a["PUNTUACIÓN SMALL-BIG"]);
                                if (!string.IsNullOrEmpty(a["PUNTUACIÓN VALUE-GROWTH"]))
                                    instr.PuntaucionValueGrowth = Convert.ToDecimal(a["PUNTUACIÓN VALUE-GROWTH"]);
                                if (!string.IsNullOrEmpty(a["PUNTUACIÓN UTA"]))
                                    instr.PuntuacionUta = Convert.ToDecimal(a["PUNTUACIÓN UTA"]);
                                instr.CoreTrading = a["CORE/TRADING"].ToString();

                                _listaInstrumentos.Add(instr);
                            }
                        }

                        validar();

                        Thread.Sleep(millisecondsTimeout);
                        //});
                    }, new Pages.Informes.ProgressDialog.ProgressDialogSettings(true, false, false));

                    if (result.OperationFailed == true)
                    {
                        log.Error("Error Importando instrumentos " + result.Error, result.Error.InnerException);
                        
                        string message = string.Empty;
                        if (!string.IsNullOrEmpty(result.Error.Message))
                        {
                            message = result.Error.Message;
                            _listaErrores.Add(message);
                        }
                        else
                        {
                            message = "Se Ha producido un error al importar instrumentos";
                        }
                        //RadWindow.Alert(new DialogParameters { Content = message, Header = "Error:" });
                    }

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
                    RadWindow.Alert(new TextBlock { Text = string.Join(Environment.NewLine, _listaErrores), TextWrapping = TextWrapping.Wrap, Width = 400 });
                }

                /*
                _dt = Utils.RecuperarDatosExcel();

                if (_dt != null && _dt.Rows.Count > 0)
                {
                    this.DataGridInstrumentos.ItemsSource = _dt.DefaultView;
                    int millisecondsTimeout = 500;
                    Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Comprobando Instrumentos", () =>
                    {
                        //Comprobamos que los valores del excel son válidos
                        InstrumentosImportados_VM.ComprobarInstrumentosValidos(ref _tieneDatos, _dt, ref _errores);
                        Thread.Sleep(millisecondsTimeout);
                    });

                    if (_errores.Count == 0)
                    {
                        this.ButtonGuardar.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        //mostrar errores
                        string mensajeError = "El documento tiene valores no permitidos. Corríjalos antes de realizar la importación." + Environment.NewLine;
                        for (int i = 0; i < _errores.Count; i++)
                        {
                            mensajeError += "Columna '" + _errores[i].Item1 + "' valor '" + _errores[i].Item2 + "'." + Environment.NewLine;
                        }
                        //MessageBox.Show(mensajeError, "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Reports_IICs.ViewModels.Reports.Report_VM.ShowErrorWindow("Importación de instrumentos", mensajeError);
                    }
                }
                else
                {
                    MessageBox.Show(Resource.DocumentoNoValido_Mens, Resource.HeaderGVC_MessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                }*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(Resource.DocumentoNoValido_Mens + ex.Message, Resource.HeaderGVC_MessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void validar()
        {
            //validaciones
            //isins
            List<string> incorrectos = _listaInstrumentos.GroupBy(x => x.ISIN.ToUpper()).Where(g => g.Count() > 1).Select(s => s.Key).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS están duplicados: {0}", string.Join(",", incorrectos)));

            //tipos
            incorrectos = _listaInstrumentos.Where(w => w.IdTipoInstrumento == "0" 
                                                    || w.IdTipoInstrumento == null).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Tipo", string.Join(",", incorrectos)));

            //sectores
            incorrectos = _listaInstrumentos.Where(w => w.IdSector == 0).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Sector", string.Join(",", incorrectos)));

            //emergentes
            incorrectos = _listaInstrumentos.Where(w => w.Emergente == null).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Emergente", string.Join(",", incorrectos)));

            //categorias
            incorrectos = _listaInstrumentos.Where(w => w.IdCategoria == 0).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Categoría", string.Join(",", incorrectos)));

            //ids empresa
            incorrectos = _listaInstrumentos.Where(w => w.IdEmpresa == 0).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Empresa", string.Join(",", incorrectos)));

            //ids instrumento
            incorrectos = _listaInstrumentos.Where(w => w.IdInstrumento == "0" || string.IsNullOrEmpty(w.IdInstrumento)).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Instrumento", string.Join(",", incorrectos)));

            //ids zona
            incorrectos = _listaInstrumentos.Where(w => w.IdZona == 0).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "Zona", string.Join(",", incorrectos)));

            //ids pais
            incorrectos = _listaInstrumentos.Where(w => w.IdPais == 0).Select(s => s.ISIN.ToUpper()).ToList();
            if (incorrectos.Count() > 0)
                _listaErrores.Add(string.Format("Los siguientes ISINS tienen datos no permitidos en la columna '{0}': {1}", "País", string.Join(",", incorrectos)));
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            string mensaje = string.Empty;
            if (_listaErrores.Count() > 0)
            {
                mensaje = "No puede importar el documento hasta que no corrija los errores. " + _listaErrores.ToString();
                RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
            }
            else
            {
                //Guardamos los instrumentos
                bool guardado = false;

                int millisecondsTimeout = 500;
                Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Importando", () =>
                {
                    guardado = InstrumentosImportados_DA.GuardarInstrumentosImportados(_listaInstrumentos);
                    Thread.Sleep(millisecondsTimeout);
                });

                if (guardado)
                {
                    //Actualizamos la variable local
                    VariablesGlobales.SetVariablesGlobales(null);
                    mensaje = "La importación ha finalizado correctamente.";
                    RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
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
                    string mensaje = string.Empty;
                    if(InstrumentosImportados_VM.GuardarInstrumentosImportados(_dt))
                    {
                        mensaje = "La importación ha finalizado correctamente.";
                        RadWindow.Prompt(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
                    }
                    else
                    {
                        mensaje = "Se ha producido un error y no ha sido posible realizar la importación.";
                        RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });
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
                    //MessageBox.Show(mensajeError, "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Reports_IICs.ViewModels.Reports.Report_VM.ShowErrorWindow("Importación de instrumentos", mensajeError);
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado ningún registro válido en el documento.", "Importación de instrumentos", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            */
        }
    }
}
