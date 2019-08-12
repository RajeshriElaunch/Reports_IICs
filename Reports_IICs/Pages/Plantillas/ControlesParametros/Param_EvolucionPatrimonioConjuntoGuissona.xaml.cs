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
    /// Lógica de interacción para Param_EvolucionPatrimonioConjuntoGuissona.xaml
    /// </summary>
    public partial class Param_EvolucionPatrimonioConjuntoGuissona : UserControl
    {

        public Parametros_EvolucionPatrimonioConjuntoGuissona parametrosEvolucionPatrimonioConjuntoGuissona;
        public List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> parametrosEvPatrimonioConjuntoGuissona_Fondos;

        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();
        //private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();

        public Param_EvolucionPatrimonioConjuntoGuissona(Parametros_EvolucionPatrimonioConjuntoGuissona paramEvo, List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> fondos)
        {
            //Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            InitializeComponent();
            parametrosEvolucionPatrimonioConjuntoGuissona = paramEvo;
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
            parametrosEvPatrimonioConjuntoGuissona_Fondos = fondos;
            Loaded += OnLoaded;
            myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = fondos;
           
            if (parametrosEvolucionPatrimonioConjuntoGuissona != null && string.IsNullOrEmpty(parametrosEvolucionPatrimonioConjuntoGuissona.Titulo)) textBoxTitulo.Focus();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            //if (parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;
            if (parametrosEvolucionPatrimonioConjuntoGuissona!=null && parametrosEvolucionPatrimonioConjuntoGuissona.Titulo != null) textBoxTitulo.Text = parametrosEvolucionPatrimonioConjuntoGuissona.Titulo;

            Loaded -= OnLoaded;
        }

        
        private void myEvolucionPatrimonioConjuntoGuissona_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

            var selectedValue = this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos param_fondos = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myEvolucionPatrimonioConjuntoGuissonaGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }
                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)selectedrow).IsinFondo);
                    #endregion

                    string wCodigoIC = string.Empty;
                    string wCodigoICFondo = string.Empty;
                    string wIsinFondo = string.Empty;
                    string wdescripcion = string.Empty;
                    DateTime wFechaDescripcion;
                    #region Create Custom object to take values

                    param_fondos = (Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;
                    wCodigoIC = param_fondos.CodigoIC;
                    wdescripcion = param_fondos.Descripcion;
                    wFechaDescripcion = param_fondos.FechaConstitucion;
                    wCodigoICFondo = param_fondos.CodigoICFondo;
                    wIsinFondo = param_fondos.IsinFondo;
                    #endregion


                    var window = new AddEditEvolucionPatrimConjGuissona_Fondos(wCodigoIC, wCodigoICFondo, wdescripcion, ListadoNoselected, wFechaDescripcion, wIsinFondo);

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

                            parametrosEvPatrimonioConjuntoGuissona_Fondos.Remove(param_fondos);

                            Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos temp_item = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();
                            temp_item.Id = param_fondos.Id;
                            temp_item.CodigoIC = window.CodigoIC;
                            temp_item.Descripcion = window.Descripcion;
                            temp_item.FechaConstitucion = window.FechaConstitucion;
                            temp_item.CodigoICFondo = window.CodigoICFondo;
                            temp_item.IsinFondo = window.IsinFondo;

                            parametrosEvPatrimonioConjuntoGuissona_Fondos.Add(temp_item);
                            this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                            this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = parametrosEvPatrimonioConjuntoGuissona_Fondos;

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

                        Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos param_RentabGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();
                        param_RentabGuissona = (Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)this.myEvolucionPatrimonioConjuntoGuissonaGrid.SelectedItem;

                        parametrosEvPatrimonioConjuntoGuissona_Fondos.Remove(param_RentabGuissona);

                        this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                        this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = parametrosEvPatrimonioConjuntoGuissona_Fondos;

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

            var rows = this.myEvolucionPatrimonioConjuntoGuissonaGrid.ChildrenOfType<GridViewRow>();

            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion

            var windowEvoPatrimConjGuissona = new AddEditEvolucionPatrimConjGuissona_Fondos(string.Empty, string.Empty, string.Empty, ListadoNoselected, DateTime.Now,string.Empty);
            if (windowEvoPatrimConjGuissona != null)
            {
                if (Application.Current.MainWindow != windowEvoPatrimConjGuissona)
                {
                    windowEvoPatrimConjGuissona.Owner = Application.Current.MainWindow;
                    windowEvoPatrimConjGuissona.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (windowEvoPatrimConjGuissona.Owner as MetroWindow);
                    ownerMetroWindow.Height = windowEvoPatrimConjGuissona.Height;
                    ownerMetroWindow.Width = windowEvoPatrimConjGuissona.Width;
                    ownerMetroWindow.MinHeight = windowEvoPatrimConjGuissona.MinHeight;
                    ownerMetroWindow.MinWidth = windowEvoPatrimConjGuissona.MinWidth;
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



                windowEvoPatrimConjGuissona.ShowDialog();

                windowEvoPatrimConjGuissona.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (windowEvoPatrimConjGuissona.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!windowEvoPatrimConjGuissona.Cancel)
                {
                    #region Retrieve Values from window

                    Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos temp_item = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();
                    temp_item.CodigoICFondo = windowEvoPatrimConjGuissona.CodigoICFondo;
                    temp_item.Descripcion = windowEvoPatrimConjGuissona.Descripcion;
                    temp_item.FechaConstitucion = windowEvoPatrimConjGuissona.FechaConstitucion;
                    temp_item.IsinFondo = windowEvoPatrimConjGuissona.IsinFondo;
                    temp_item.CodigoIC = windowEvoPatrimConjGuissona.CodigoIC;

                    parametrosEvPatrimonioConjuntoGuissona_Fondos.Add(temp_item);
                    this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = null;
                    this.myEvolucionPatrimonioConjuntoGuissonaGrid.ItemsSource = parametrosEvPatrimonioConjuntoGuissona_Fondos;

                    #endregion
                }
            }
            #endregion
            #endregion
        }
    }
}
