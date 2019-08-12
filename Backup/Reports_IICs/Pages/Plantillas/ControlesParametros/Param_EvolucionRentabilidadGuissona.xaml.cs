using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Instrumentos;


namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_EvolucionRentabilidadGuissona.xaml
    /// </summary>
    public partial class Param_EvolucionRentabilidadGuissona : UserControl
    {
        public Parametros_EvolucionRentabilidadGuissona parametrosEvoRentabilidadGuissona;
        public List<Parametros_EvolucionRentabilidadGuissona_Fondos> parametrosEvoRentabGuissona_Fondos;
        
        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();
        //private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();

        public Param_EvolucionRentabilidadGuissona(Parametros_EvolucionRentabilidadGuissona paramEvo,List<Parametros_EvolucionRentabilidadGuissona_Fondos> fondos)
        {
            //Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            InitializeComponent();
            parametrosEvoRentabilidadGuissona = paramEvo;
            int i = 0;
            foreach (var item in fondos)
            {
                if (item.Id == 0)
                {
                    fondos.RemoveAt(i);
                    break;
                }
                i++;
            }
            parametrosEvoRentabGuissona_Fondos = fondos;
            Loaded += OnLoaded;
            myEvolucionRentabilidadGuissonaGrid.ItemsSource = fondos;

            if (parametrosEvoRentabilidadGuissona != null && string.IsNullOrEmpty(parametrosEvoRentabilidadGuissona.Titulo)) textBoxTitulo.Focus();

            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

        }

      
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            //if (parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;
            if (parametrosEvoRentabilidadGuissona != null && parametrosEvoRentabilidadGuissona.Titulo != null) textBoxTitulo.Text = parametrosEvoRentabilidadGuissona.Titulo;

            Loaded -= OnLoaded;
        }

        private void myEvolucionRentabilidadGuissonaGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

            var selectedValue = this.myEvolucionRentabilidadGuissonaGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_EvolucionRentabilidadGuissona_Fondos param_fondos = new Parametros_EvolucionRentabilidadGuissona_Fondos();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myEvolucionRentabilidadGuissonaGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myEvolucionRentabilidadGuissonaGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }
                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_EvolucionRentabilidadGuissona_Fondos)selectedrow).IsinFondo);
                    #endregion

                    string wCodigoIC = string.Empty;
                    string wCodigoICFondo = string.Empty;
                    string wIsinFondo = string.Empty;
                    string wdescripcion = string.Empty;
                    decimal wReferenciaTae = 0;
                    DateTime wFechaDescripcion;
                    #region Create Custom object to take values

                    param_fondos = (Parametros_EvolucionRentabilidadGuissona_Fondos)this.myEvolucionRentabilidadGuissonaGrid.SelectedItem;
                    wCodigoIC = param_fondos.CodigoIC;
                    wCodigoICFondo = param_fondos.CodigoICFondo;
                    wdescripcion = param_fondos.Descripcion;
                    wFechaDescripcion = param_fondos.FechaConstitucion;
                    wIsinFondo = param_fondos.IsinFondo;
                    wReferenciaTae = param_fondos.ReferenciaTAE;
                    #endregion


                    var window = new AddEditEvolucionRentabGuissona_Fondos(wCodigoIC, wCodigoICFondo, wdescripcion, ListadoNoselected, wFechaDescripcion, wIsinFondo, wReferenciaTae);

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

                            parametrosEvoRentabGuissona_Fondos.Remove(param_fondos);

                            Parametros_EvolucionRentabilidadGuissona_Fondos temp_item = new Parametros_EvolucionRentabilidadGuissona_Fondos();
                            temp_item.CodigoICFondo = window.CodigoICFondo;
                            temp_item.Descripcion = window.Descripcion;
                            temp_item.FechaConstitucion = window.FechaConstitucion;
                            temp_item.IsinFondo = window.IsinFondo;
                            temp_item.CodigoIC = window.CodigoIC;
                            temp_item.ReferenciaTAE = window.ReferenciaTAE;
                            parametrosEvoRentabGuissona_Fondos.Add(temp_item);
                            this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = null;
                            this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = parametrosEvoRentabGuissona_Fondos;

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

                        Parametros_EvolucionRentabilidadGuissona_Fondos param_RentabGuissona = new Parametros_EvolucionRentabilidadGuissona_Fondos();
                        param_RentabGuissona = (Parametros_EvolucionRentabilidadGuissona_Fondos)this.myEvolucionRentabilidadGuissonaGrid.SelectedItem;
                        parametrosEvoRentabGuissona_Fondos.Remove(param_RentabGuissona);

                        this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = null;
                        this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = parametrosEvoRentabGuissona_Fondos;

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

            var rows = this.myEvolucionRentabilidadGuissonaGrid.ChildrenOfType<GridViewRow>();

            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion

            var windowEvoRentabGuissona = new AddEditEvolucionRentabGuissona_Fondos(string.Empty, string.Empty, string.Empty, ListadoNoselected,DateTime.Now, string.Empty,0);
            if (windowEvoRentabGuissona != null)
            {
                if (Application.Current.MainWindow != windowEvoRentabGuissona)
                {
                    windowEvoRentabGuissona.Owner = Application.Current.MainWindow;
                    windowEvoRentabGuissona.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (windowEvoRentabGuissona.Owner as MetroWindow);
                    ownerMetroWindow.Height = windowEvoRentabGuissona.Height;
                    ownerMetroWindow.Width = windowEvoRentabGuissona.Width;
                    ownerMetroWindow.MinHeight = windowEvoRentabGuissona.MinHeight;
                    ownerMetroWindow.MinWidth = windowEvoRentabGuissona.MinWidth;
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
                
                windowEvoRentabGuissona.ShowDialog();

                windowEvoRentabGuissona.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (windowEvoRentabGuissona.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!windowEvoRentabGuissona.Cancel)
                {
                    #region Retrieve Values from window

                    Parametros_EvolucionRentabilidadGuissona_Fondos temp_item = new Parametros_EvolucionRentabilidadGuissona_Fondos();

                    temp_item.CodigoIC = windowEvoRentabGuissona.CodigoIC;
                    temp_item.CodigoICFondo = windowEvoRentabGuissona.CodigoICFondo;
                    temp_item.Descripcion = windowEvoRentabGuissona.Descripcion;
                    temp_item.FechaConstitucion = windowEvoRentabGuissona.FechaConstitucion;
                    temp_item.IsinFondo = windowEvoRentabGuissona.IsinFondo;
                    temp_item.ReferenciaTAE = windowEvoRentabGuissona.ReferenciaTAE;

                    parametrosEvoRentabGuissona_Fondos.Add(temp_item);
                    this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = null;
                    this.myEvolucionRentabilidadGuissonaGrid.ItemsSource = parametrosEvoRentabGuissona_Fondos;

                    #endregion
                }
            }
            #endregion
            #endregion
        }
   

    }
}
