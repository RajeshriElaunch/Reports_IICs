using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_GraficoBenchMark.xaml
    /// </summary>
    public partial class Param_GraficoBenchMark : UserControl
    {
        public List<Parametros_GraficoBenchmark_Indices> Indices = new List<Parametros_GraficoBenchmark_Indices>();
        private Parametros_GraficoBenchmark Parametro;
        public int _noOfErrorsOnScreen = 0;
        private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();
        public bool Cancel = true;
        public Param_GraficoBenchMark(Parametros_GraficoBenchmark param, List<Parametros_GraficoBenchmark_Indices> indices)
        {
            // Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

            InitializeComponent();
            Parametro = param;
            Indices = indices;
            //parametrosGrBenchmarkInd = param;
            Loaded += OnLoaded;

            if (indices != null)
            {
                //myEvoMercadosGrid.ItemsSource = param.Parametros_GraficoBenchmark_Indices;
                //parametrosGrBenchmarkInd = param.Parametros_GraficoBenchmark_Indices.ToList();
                myEvoMercadosGrid.ItemsSource = indices;
            }
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));
                
            //grid.DataContext = _addeditmaster;
            //if(param!=null)
            //{
            //    _addeditmaster.Indice = param.Indice;
            //    _addeditmaster.Descripcion = param.Descripcion;
            //}
            
        }


        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            //parametros.Descripcion = this.txtBoxDescripcion.Text;
            //parametros.Indice = this.txtBoxIndice.Text;
            Parametro.FechaInicio = this.DpFechainicio.SelectedDate.Value;
            _addeditmaster = new Param_GraficoBenchMarkValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
           // this.Close();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //if (parametros!= null && parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            //if (parametros != null && parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;
            if (Parametro != null && Parametro.FechaInicio != null) DpFechainicio.Text = Parametro.FechaInicio.ToString();
            if (Indices != null) myEvoMercadosGrid.ItemsSource = Indices;

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

                    Parametros_GraficoBenchmark_Indices param_GrBenchmark = new Parametros_GraficoBenchmark_Indices();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myEvoMercadosGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myEvoMercadosGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }
                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_GraficoBenchmark_Indices)selectedrow).Indice);
                    #endregion

                    string wIndice = string.Empty;
                    string wdescripcion = string.Empty;
                    #region Create Custom object to take values

                    param_GrBenchmark = (Parametros_GraficoBenchmark_Indices)this.myEvoMercadosGrid.SelectedItem;
                    wIndice = param_GrBenchmark.Indice;
                    wdescripcion = param_GrBenchmark.Descripcion;


                    #endregion


                    var window = new AddEditParam_GraficoBenchMark(wIndice, wdescripcion, ListadoNoselected);

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

                            Indices.Remove(param_GrBenchmark);

                            Parametros_GraficoBenchmark_Indices temp_item = new Parametros_GraficoBenchmark_Indices();
                            temp_item.Indice = window.Indice;
                            temp_item.Descripcion = window.Descripcion;
                            Indices.Add(temp_item);
                            this.myEvoMercadosGrid.ItemsSource = null;
                            this.myEvoMercadosGrid.ItemsSource = Indices;

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

                        Parametros_GraficoBenchmark_Indices param_GrBenchMark = new Parametros_GraficoBenchmark_Indices();
                        param_GrBenchMark = (Parametros_GraficoBenchmark_Indices)this.myEvoMercadosGrid.SelectedItem;
                        Indices.Remove(param_GrBenchMark);

                        this.myEvoMercadosGrid.ItemsSource = null;
                        this.myEvoMercadosGrid.ItemsSource = Indices;

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

            var windowEvoMerca = new AddEditParam_GraficoBenchMark(string.Empty, string.Empty, ListadoNoselected);
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
                    //int idParent = 0;
                    //if(Indices != null && Indices.Count>0)
                    //{
                    //    //idParent = parametrosGrBenchmarkInd.FirstOrDefault().IdParametrosGraficoBenchmark;
                    //}
                       

                    Parametros_GraficoBenchmark_Indices temp_item = new Parametros_GraficoBenchmark_Indices();
                    temp_item.Indice = windowEvoMerca.Indice;
                    temp_item.Descripcion = windowEvoMerca.Descripcion;
                    //temp_item.IdParametrosGraficoBenchmark = idParent;

                    Indices.Add(temp_item);
                    this.myEvoMercadosGrid.ItemsSource = null;
                    this.myEvoMercadosGrid.ItemsSource = Indices;

                    #endregion
                }
            }
            #endregion
            #endregion
        }
    }
}
