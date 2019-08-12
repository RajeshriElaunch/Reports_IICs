using MahApps.Metro.Controls;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Instrumentos;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_EvolucionMercados.xaml
    /// </summary>
    public partial class Param_EvolucionMercados : UserControl
    {
        public List<Parametros_EvolucionMercados> parametrosEvoMerca;
        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();
        //private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();

        public Param_EvolucionMercados(List<Parametros_EvolucionMercados> param)
        {
            // Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            InitializeComponent();

            if (param.Count() > 0)
                parametrosEvoMerca = param;
            else
                //Si no tiene parámetros cargamos los parámetros por defecto
                parametrosEvoMerca = EvolucionMercados_DA.GetParametrosPorDefecto();


            Loaded += OnLoaded;

            //myEvoMercadosGrid.ItemsSource = param;
            myEvoMercadosGrid.ItemsSource = parametrosEvoMerca;
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            //grid.DataContext = _addeditmaster;
            //if (param != null)
            //{
            //    _addeditmaster.Indice = param.Indice;
            //    _addeditmaster.Descripcion = param.Descripcion;
            //}

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            //if (parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;


            Loaded -= OnLoaded;
        }

        private void myEvoMercadosGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        {

            bool? dialogResult = null;
            Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
            parameters.Content = "¿Esta seguro que desea eliminar?";

            parameters.Closed = (w, a) =>
            {
                dialogResult = a.DialogResult;
            };

            parameters.Header = "Eliminar";

            Telerik.Windows.Controls.RadWindow.Confirm(parameters);

            if (dialogResult == true)
            {
                #region Delete
                //switch (_elemento)
                //{
                //    case Utils.Elemento.Secciones:
                //        Seccione SecciontoDelete = (Seccione)e.Items.FirstOrDefault();
                //        Secciones_DA.Delete(SecciontoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos:
                //        Instrumento InstrumentotoDelete = (Instrumento)e.Items.FirstOrDefault();
                //        Instrumentos_DA.Delete(InstrumentotoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos_Categorias:
                //        Instrumentos_Categorias CategoriatoDelete = (Instrumentos_Categorias)e.Items.FirstOrDefault();
                //        InstrumentosCategorias_DA.Delete(CategoriatoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos_Empresas:
                //        Instrumentos_Empresas EmpresatoDelete = (Instrumentos_Empresas)e.Items.FirstOrDefault();
                //        InstrumentosEmpresas_DA.Delete(EmpresatoDelete);
                //        break;

                //    case Utils.Elemento.Instrumentos_Paises:
                //        Instrumentos_Paises PaisestoDelete = (Instrumentos_Paises)e.Items.FirstOrDefault();
                //        InstrumentosPaises_DA.Delete(PaisestoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos_Tipos:
                //        Instrumentos_Tipos tipotoDelete = (Instrumentos_Tipos)e.Items.FirstOrDefault();
                //        InstrumentosTipos_DA.Delete(tipotoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos_Zonas:
                //        Instrumentos_Zonas zonatoDelete = (Instrumentos_Zonas)e.Items.FirstOrDefault();
                //        InstrumentosZonas_DA.Delete(zonatoDelete);
                //        break;
                //    case Utils.Elemento.Instrumentos_Sectores:
                //        Instrumentos_Sectores sectortoDelete = (Instrumentos_Sectores)e.Items.FirstOrDefault();
                //        InstrumentosSectores_DA.Delete(sectortoDelete);
                //        break;
                //}
                #endregion
            }
            else
            {
                //cancel
                e.Cancel = true;


            }

        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedValue = this.myEvoMercadosGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_EvolucionMercados param_EvoMerca = new Parametros_EvolucionMercados();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myEvoMercadosGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myEvoMercadosGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }
                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_EvolucionMercados)selectedrow).Isin);
                    #endregion

                    string wIsin = string.Empty;
                    string wdescripcion = string.Empty;
                    #region Create Custom object to take values

                    param_EvoMerca = (Parametros_EvolucionMercados)this.myEvoMercadosGrid.SelectedItem;
                    wIsin = param_EvoMerca.Isin;
                    wdescripcion = param_EvoMerca.Descripcion;


                    #endregion


                    var window = new AddEditParamEvolucionMercados(wIsin, wdescripcion, ListadoNoselected);

                    if (window != null)
                    {
                        if (Application.Current.MainWindow != window)
                        {
                            window.Owner = Application.Current.MainWindow;
                            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            var ownerMetroWindow = (window.Owner as MetroWindow);
                            ownerMetroWindow.Height = window.Height;
                            ownerMetroWindow.Width = window.Width;
                            ownerMetroWindow.MinHeight = window.MinHeight;
                            ownerMetroWindow.MinWidth = window.MinWidth;
                            if (!ownerMetroWindow.IsOverlayVisible())
                                ownerMetroWindow.ShowOverlayAsync();
                        }

                        #region Create Custom object to take values

                        //plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                        //wcodigo = plantilla_isins.Isin;
                        //wdescripcion = plantilla_isins.Descripcion;


                        #endregion


                        window.ShowDialog();

                        window.Owner = Application.Current.MainWindow;
                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                        if (ownerMetroWindow2.IsOverlayVisible())
                            ownerMetroWindow2.HideOverlayAsync();

                        if (!window.Cancel)
                        {
                            #region Retrieve Values from window
                            
                            parametrosEvoMerca.Remove(param_EvoMerca);

                            Parametros_EvolucionMercados temp_item = new Parametros_EvolucionMercados();
                            temp_item.Isin = window.Isin;
                            temp_item.Descripcion = window.Descripcion;
                            parametrosEvoMerca.Add(temp_item);
                            this.myEvoMercadosGrid.ItemsSource = null;
                            this.myEvoMercadosGrid.ItemsSource = parametrosEvoMerca;

                            #endregion
                        }
                    }
                    #endregion

                    #endregion
                }
                #endregion

                #region Eliminar

                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Eliminar")
                {
                    bool? dialogResult = null;
                    Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
                    parameters.Content = "¿Esta seguro que desea eliminar?";

                    parameters.Closed = (w, a) =>
                    {
                        dialogResult = a.DialogResult;
                    };

                    parameters.Header = "Eliminar";

                    Telerik.Windows.Controls.RadWindow.Confirm(parameters);

                    if (dialogResult == true)
                    {
                        #region Delete
                       
                        Parametros_EvolucionMercados param_EvoMerca = new Parametros_EvolucionMercados();
                        param_EvoMerca = (Parametros_EvolucionMercados)this.myEvoMercadosGrid.SelectedItem;
                        parametrosEvoMerca.Remove(param_EvoMerca);
                        
                        this.myEvoMercadosGrid.ItemsSource = null;
                        this.myEvoMercadosGrid.ItemsSource = parametrosEvoMerca;
                        
                        #endregion
                    }
                    else
                    {
                        //cancel
                        //e.Cancel = true;


                    }

                }
                #endregion

            }

        }


        private void AddNewRow(object sender, RoutedEventArgs e)
        {

            #region Add new Row
            #region showWindow

            #region Fill List with List of Codes

            var rows = this.myEvoMercadosGrid.ChildrenOfType<GridViewRow>();
            
            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }
           
            #endregion

            var windowEvoMerca = new AddEditParamEvolucionMercados(string.Empty, string.Empty, ListadoNoselected);
            if (windowEvoMerca != null)
            {
                if (Application.Current.MainWindow != windowEvoMerca)
                {
                    windowEvoMerca.Owner = Application.Current.MainWindow;
                    windowEvoMerca.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (windowEvoMerca.Owner as MetroWindow);
                    ownerMetroWindow.Height = windowEvoMerca.Height;
                    ownerMetroWindow.Width = windowEvoMerca.Width;
                    ownerMetroWindow.MinHeight = windowEvoMerca.MinHeight;
                    ownerMetroWindow.MinWidth = windowEvoMerca.MinWidth;
                    if (!ownerMetroWindow.IsOverlayVisible())
                        ownerMetroWindow.ShowOverlayAsync();
                }

                #region Create Custom object to take values
                //switch (_elemento)
                //{
                //    case Utils.Elemento.Secciones:
                //        //SecciontoUpdate = (Seccione)this.radGridViewListado.SelectedItem;
                //        //window.Codigo = SecciontoUpdate.Id.ToString();
                //        //window.Descripcion = SecciontoUpdate.DescripcionLarga;

                //        break;

                //}
                #endregion



                windowEvoMerca.ShowDialog();

                windowEvoMerca.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (windowEvoMerca.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!windowEvoMerca.Cancel)
                {
                    #region Retrieve Values from window
                    
                    Parametros_EvolucionMercados temp_item = new Parametros_EvolucionMercados();
                    temp_item.Isin = windowEvoMerca.Isin;
                    temp_item.Descripcion = windowEvoMerca.Descripcion;
                    parametrosEvoMerca.Add(temp_item);
                    this.myEvoMercadosGrid.ItemsSource = null;
                    this.myEvoMercadosGrid.ItemsSource = parametrosEvoMerca;

                    #endregion
                }
            }
            #endregion
            #endregion
        }
    }
    }
