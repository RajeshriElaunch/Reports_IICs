using MahApps.Metro.Controls;
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
    /// Lógica de interacción para Param_PlusvaliasDividendos.xaml
    /// </summary>
    public partial class Param_PlusvaliasDividendos : UserControl
    {
        public List<Parametros_PlusvaliasDividendos> parametrosPlusvaliasDividendos;

        //public List<Parametros_PlusvaliasDividendos_ISINS> parametrosPlusvaliasDividendos_ISINS;

        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();

        public Param_PlusvaliasDividendos(List<Parametros_PlusvaliasDividendos> paramDivi)
        {
            //Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);
            InitializeComponent();

            parametrosPlusvaliasDividendos = paramDivi;

            //int i = 0;
            //foreach (var item in isins)
            //{
            //    if (item.Id == 0)
            //    {
            //        isins.RemoveAt(i);
            //        break;
            //    }
            //    i++;
            //}

            //parametrosPlusvaliasDividendos = isins;

            Loaded += OnLoaded;
            myPlusvaliasDividendosGrid.ItemsSource = parametrosPlusvaliasDividendos;

            //if (parametrosPlusvaliasDividendos != null && string.IsNullOrEmpty(parametrosPlusvaliasDividendos.Descripcion)) textBoxTitulo.Focus();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));


        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            //if (parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;
            //if (parametrosPlusvaliasDividendos != null && parametrosPlusvaliasDividendos.Descripcion != null) textBoxTitulo.Text = parametrosPlusvaliasDividendos.Descripcion;

            Loaded -= OnLoaded;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedValue = this.myPlusvaliasDividendosGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_PlusvaliasDividendos param_PlDivi = new Parametros_PlusvaliasDividendos();

                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myPlusvaliasDividendosGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myPlusvaliasDividendosGrid.SelectedItem;
                    //List<string> ListadoNoselected = new List<string>();
                    //foreach (GridViewRow item in rows)
                    //{
                    //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    //}
                    //ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)selectedrow).IsinFondo);
                    #endregion

                    string wCodigoIC = string.Empty;
                   
                    string wIsinFondo = string.Empty;
                    string wdescripcion = string.Empty;

                    string wIsin = string.Empty;

                   

                    #region Create Custom object to take values

                    param_PlDivi = (Parametros_PlusvaliasDividendos)this.myPlusvaliasDividendosGrid.SelectedItem;

                    wCodigoIC = param_PlDivi.CodigoIC;
                    wdescripcion = param_PlDivi.Descripcion;
                    var param_isins = param_PlDivi.Parametros_PlusvaliasDividendos_ISINS.ToList();

                    //wFechaDescripcion = param_isins.FechaConstitucion;
                    //wCodigoICFondo = param_isins.CodigoICFondo;
                    //wIsinFondo = param_isins.IsinFondo;

                    //wIsin = param_isins.;


                    #endregion


                    var window = new AddEditParam_PlusvaliasDividendos(param_PlDivi,param_isins);

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

                            parametrosPlusvaliasDividendos.Remove(param_PlDivi);

                            Parametros_PlusvaliasDividendos temp_item = new Parametros_PlusvaliasDividendos();

                            //temp_item.CodigoIC = window.CodigoIC;

                            temp_item = window.parametroPlDivi;
                            temp_item.Parametros_PlusvaliasDividendos_ISINS = window.parametrosisins;

                            parametrosPlusvaliasDividendos.Add(temp_item);
                            this.myPlusvaliasDividendosGrid.ItemsSource = null;
                            this.myPlusvaliasDividendosGrid.ItemsSource = parametrosPlusvaliasDividendos;

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

                        Parametros_PlusvaliasDividendos param_PlusvaliasDividendos = new Parametros_PlusvaliasDividendos();

                        param_PlusvaliasDividendos = (Parametros_PlusvaliasDividendos)this.myPlusvaliasDividendosGrid.SelectedItem;

                        int l = 0;

                        var LineasPlusvalias = param_PlusvaliasDividendos.Parametros_PlusvaliasDividendos_ISINS.ToList();

                        foreach (var item in LineasPlusvalias)
                        {
                            param_PlusvaliasDividendos.Parametros_PlusvaliasDividendos_ISINS.Remove(item);
                            l++;
                        } 

                        parametrosPlusvaliasDividendos.Remove(param_PlusvaliasDividendos);

                        this.myPlusvaliasDividendosGrid.ItemsSource = null;
                        this.myPlusvaliasDividendosGrid.ItemsSource = parametrosPlusvaliasDividendos;

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

            var rows = this.myPlusvaliasDividendosGrid.ChildrenOfType<GridViewRow>();

            //List<string> ListadoNoselected = new List<string>();
            //foreach (GridViewRow item in rows)
            //{
            //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            //}

            #endregion

            Parametros_PlusvaliasDividendos param_PlDivi = new Parametros_PlusvaliasDividendos();
            List<Parametros_PlusvaliasDividendos_ISINS> param_isins = new List<Parametros_PlusvaliasDividendos_ISINS>();

            param_PlDivi.Descripcion = this.textBoxTitulo.Text;
            var windowEvoPatrimConjGuissona = new AddEditParam_PlusvaliasDividendos(param_PlDivi, param_isins);

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

                    Parametros_PlusvaliasDividendos temp_item = new Parametros_PlusvaliasDividendos();
                    temp_item = windowEvoPatrimConjGuissona.parametroPlDivi;
                    temp_item.Parametros_PlusvaliasDividendos_ISINS = windowEvoPatrimConjGuissona.parametrosisins;

                    parametrosPlusvaliasDividendos.Add(temp_item);
                    this.myPlusvaliasDividendosGrid.ItemsSource = null;
                    this.myPlusvaliasDividendosGrid.ItemsSource = parametrosPlusvaliasDividendos;

                    #endregion
                }
            }
            #endregion
            #endregion
        }


        private void myIndicePlusvaliasDividendosGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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
              
                #endregion
            }
            else
            {
                //cancel
                e.Cancel = true;


            }

        }

        private void myPlusvaliasDividendosGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {


            //if (e.Cell.Column.Name == "Cotizacion")
            //{
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            //}


        }

        private void textBoxTitulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(((System.Windows.Controls.TextBox)e.OriginalSource).Text!=null)
            {
                if(string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    btn_ADD.IsEnabled = false;

                }
                else
                {
                    btn_ADD.IsEnabled = true;

                }

            }
           
        }
    }
}
