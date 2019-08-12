using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Instrumentos;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditParam_PlusvaliasDividendos.xaml
    /// </summary>
    /// 
   
    public partial class AddEditParam_PlusvaliasDividendos : MetroWindow
    {

        public List<Parametros_PlusvaliasDividendos_ISINS> parametrosisins;
        public Parametros_PlusvaliasDividendos parametroPlDivi;

        public int _noOfErrorsOnScreen = 0;
        private VM_Instrumentos DataSource = new VM_Instrumentos();
        public bool Cancel = true;
        private int idPlusValiaDivi = 0;
        public AddEditParam_PlusvaliasDividendos(Parametros_PlusvaliasDividendos selectedPL,List<Parametros_PlusvaliasDividendos_ISINS> param)
        {
            
            // Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            InitializeComponent();

            parametrosisins = param;
            parametroPlDivi = selectedPL;
            idPlusValiaDivi = parametroPlDivi.Id;

            Loaded += OnLoaded;

            myPlusvaliasDividendosGrid.ItemsSource = param;
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            if (parametroPlDivi.Descripcion != null) txtBoxDescripcion.Text = parametroPlDivi.Descripcion;
            
            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo = this.textBoxCodigo.Text;
            //Descripcion = this.textBoxDescription.Text;
            //Tipo = (int)this.ComboBoxTipo.SelectedValue;
            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void myPlusvaliasDividendosGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedValue = this.myPlusvaliasDividendosGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_PlusvaliasDividendos_ISINS param_PlusvaliasDividendos_ISIN = new Parametros_PlusvaliasDividendos_ISINS();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myPlusvaliasDividendosGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myPlusvaliasDividendosGrid.SelectedItem;
                    //List<string> ListadoNoselected = new List<string>();
                    //foreach (GridViewRow item in rows)
                    //{
                    //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    //}
                    //ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_DistribucionPatrimonioNovarex)selectedrow).Descripcion);
                    #endregion

                    string wISIN = string.Empty;
                    
                    //string wdescripcion = string.Empty;
                    #region Create Custom object to take values

                    param_PlusvaliasDividendos_ISIN = (Parametros_PlusvaliasDividendos_ISINS)this.myPlusvaliasDividendosGrid.SelectedItem;
                    wISIN = param_PlusvaliasDividendos_ISIN.ISIN;

                    //wdescripcion = param_PlusvaliasDividendos_ISIN.Descripcion;

                    #endregion

                    var window = new AddEditParam_PlusvaliasDividendos_ISIN(wISIN);

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

                            parametrosisins.Remove(param_PlusvaliasDividendos_ISIN);

                            Parametros_PlusvaliasDividendos_ISINS temp_item = new Parametros_PlusvaliasDividendos_ISINS();
                            temp_item.ISIN = window.Isin;
                            //temp_item.Descripcion = window.Descripcion;

                            parametrosisins.Add(temp_item);
                            this.myPlusvaliasDividendosGrid.ItemsSource = null;
                            this.myPlusvaliasDividendosGrid.ItemsSource = parametrosisins;

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

                        Parametros_PlusvaliasDividendos_ISINS param_PlusvaliasDividendos_ISIN = new Parametros_PlusvaliasDividendos_ISINS();
                        param_PlusvaliasDividendos_ISIN = (Parametros_PlusvaliasDividendos_ISINS)this.myPlusvaliasDividendosGrid.SelectedItem;
                        parametrosisins.Remove(param_PlusvaliasDividendos_ISIN);

                        this.myPlusvaliasDividendosGrid.ItemsSource = null;
                        this.myPlusvaliasDividendosGrid.ItemsSource = parametrosisins;

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

            //var rows = this.myPlusvaliasDividendosGrid.ChildrenOfType<GridViewRow>();

            //List<string> ListadoNoselected = new List<string>();
            //foreach (GridViewRow item in rows)
            //{
            //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            //}

            #endregion

            var windowEvoMerca = new AddEditParam_PlusvaliasDividendos_ISIN(string.Empty);
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

                    Parametros_PlusvaliasDividendos_ISINS temp_item = new Parametros_PlusvaliasDividendos_ISINS();
                    temp_item.ISIN = windowEvoMerca.Isin;
                    if (idPlusValiaDivi > 0) temp_item.Id_Parametros_PlusvaliasDividendos = idPlusValiaDivi;
                    //temp_item.Descripcion = windowEvoMerca.Descripcion;
                    parametrosisins.Add(temp_item);
                    this.myPlusvaliasDividendosGrid.ItemsSource = null;
                    this.myPlusvaliasDividendosGrid.ItemsSource = parametrosisins;

                    #endregion
                }
            }
            #endregion
            #endregion
        }

    }
}
