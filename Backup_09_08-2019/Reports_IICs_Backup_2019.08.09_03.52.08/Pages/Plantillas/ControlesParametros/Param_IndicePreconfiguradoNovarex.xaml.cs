using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Instrumentos;
using Reports_IICs.ViewModels.Plantillas;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_IndicePreconfiguradoNovarex.xaml
    /// </summary>
    public partial class Param_IndicePreconfiguradoNovarex : UserControl
    {
        public int _noOfErrorsOnScreen = 0;
        public Parametros_IndicePreconfiguradoNovarex parametros;
        public List<Parametros_IndicePreconfiguradoNovarex> parametrosIndicePreConfNovarex;
        public Parametros_IndicePreconfiguradoNovarex_Otros parametroOtros;
        private VM_Instrumentos DataSource = new VM_Instrumentos();
        private PlantillasPage_VM DataSourceplantilla = new PlantillasPage_VM();

        public Param_IndicePreconfiguradoNovarex()
        {
            InitializeComponent();
          
            
        }
       
        public Param_IndicePreconfiguradoNovarex(List<Parametros_IndicePreconfiguradoNovarex> param, Parametros_IndicePreconfiguradoNovarex_Otros paramOtros)
        {
            InitializeComponent();

            parametrosIndicePreConfNovarex = param;
            parametroOtros = paramOtros;


            this.myIndicePreConfNovarexGrid.ItemsSource = param;
            if(paramOtros != null)
            {
                this.txtBoxIndiceRvOtros.Text = paramOtros.IndiceRvOtros;
                this.txtBoxIndiceRfOtros.Text = paramOtros.IndiceRfOtros;
                this.txtBoxIndiceRepo.Text = paramOtros.IndiceRepoTesDepOtros;
            }

            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));


            Loaded += OnLoaded;
        }
        

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (parametros != null)
            {
                
                
            }

            Loaded -= OnLoaded;
        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }


        private void myIndicePreConfNovarexGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
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

            var selectedValue = this.myIndicePreConfNovarexGrid.SelectedItem;

            if (e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    Parametros_IndicePreconfiguradoNovarex param_IndicePreconfiguradoNovarex = new Parametros_IndicePreconfiguradoNovarex();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myIndicePreConfNovarexGrid.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myIndicePreConfNovarexGrid.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    foreach (GridViewRow item in rows)
                    {
                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    }
                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Parametros_IndicePreconfiguradoNovarex )selectedrow).Descripcion);
                    #endregion

                    string wIref = string.Empty;
                    string wdescripcion = string.Empty;
                    #region Create Custom object to take values

                    param_IndicePreconfiguradoNovarex = (Parametros_IndicePreconfiguradoNovarex)this.myIndicePreConfNovarexGrid.SelectedItem;
                    wIref = param_IndicePreconfiguradoNovarex.IndiceReferencia;
                    wdescripcion = param_IndicePreconfiguradoNovarex.Descripcion;
                    
                    #endregion
                    
                    var window = new AddEditParamIndicePreconfiguradoNovarex(param_IndicePreconfiguradoNovarex, ListadoNoselected);

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

                            parametrosIndicePreConfNovarex.Remove(param_IndicePreconfiguradoNovarex);

                            Parametros_IndicePreconfiguradoNovarex temp_item = new Parametros_IndicePreconfiguradoNovarex();

                            temp_item.Descripcion = window.CbDescripcion.Text;
                            temp_item.Divisa = (window.CblblDivisa.SelectedValue == null) ? "" : window.CblblDivisa.SelectedValue.ToString();
                            temp_item.Formula = window.txtBoxCuenta.Text;
                            temp_item.IdInstrumento = (window.CbTipoActivo.SelectedValue == null) ? null : window.CbTipoActivo.SelectedValue.ToString();
                            temp_item.IdInstrumentoZona = (window.CbZonaGeografica.SelectedValue == null) ? (int?)null : int.Parse(window.CbZonaGeografica.SelectedValue.ToString());
                            temp_item.IdTipoFormula = (window.CbTipoformula.SelectedValue == null) ? 0 : int.Parse(window.CbTipoformula.SelectedValue.ToString());
                            temp_item.IndiceReferencia = window.txtBoxIndiceReferencia.Text;
                            temp_item.IdIndicesPreconfiguradosNovarex = window.parametros.IdIndicesPreconfiguradosNovarex;
                            //temp_item.Descripcion = window.Descripcion;
                            parametrosIndicePreConfNovarex.Add(temp_item);
                            this.myIndicePreConfNovarexGrid.ItemsSource = null;
                            this.myIndicePreConfNovarexGrid.ItemsSource = parametrosIndicePreConfNovarex;
                            

                            #endregion
                        }
                    }
                    #endregion

                    #endregion
                }
                #endregion

                #region Eliminar

                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Eliminar")
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

                        Parametros_IndicePreconfiguradoNovarex param_IndicePreconfiguradoNovarex = new Parametros_IndicePreconfiguradoNovarex();
                        param_IndicePreconfiguradoNovarex = (Parametros_IndicePreconfiguradoNovarex)this.myIndicePreConfNovarexGrid.SelectedItem;
                        parametrosIndicePreConfNovarex.Remove(param_IndicePreconfiguradoNovarex);

                        this.myIndicePreConfNovarexGrid.ItemsSource = null;
                        this.myIndicePreConfNovarexGrid.ItemsSource = parametrosIndicePreConfNovarex;

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
           
            var rows = this.myIndicePreConfNovarexGrid.ChildrenOfType<GridViewRow>();

            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion
            Parametros_IndicePreconfiguradoNovarex pIndPreConfNovarex = new Parametros_IndicePreconfiguradoNovarex();
            var windowEvoMerca = new AddEditParamIndicePreconfiguradoNovarex(pIndPreConfNovarex, ListadoNoselected);
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

                    Parametros_IndicePreconfiguradoNovarex temp_item = new Parametros_IndicePreconfiguradoNovarex();
                    
                   
                    temp_item.Descripcion = windowEvoMerca.CbDescripcion.Text;
                    temp_item.Divisa = (windowEvoMerca.CblblDivisa.SelectedValue==null)? "" : windowEvoMerca.CblblDivisa.SelectedValue.ToString();
                    temp_item.Formula = windowEvoMerca.txtBoxCuenta.Text;
                    temp_item.IdInstrumento = (windowEvoMerca.CbTipoActivo.SelectedValue==null) ? null : windowEvoMerca.CbTipoActivo.SelectedValue.ToString();
                    temp_item.IdInstrumentoZona = (windowEvoMerca.CbZonaGeografica.SelectedValue==null) ? (int?)null : int.Parse(windowEvoMerca.CbZonaGeografica.SelectedValue.ToString());
                    temp_item.IdTipoFormula = (windowEvoMerca.CbTipoformula.SelectedValue==null) ? 0 : int.Parse(windowEvoMerca.CbTipoformula.SelectedValue.ToString());
                    temp_item.IndiceReferencia = windowEvoMerca.txtBoxIndiceReferencia.Text;
                    temp_item.IdIndicesPreconfiguradosNovarex = windowEvoMerca.parametros.IdIndicesPreconfiguradosNovarex;
                    parametrosIndicePreConfNovarex.Add(temp_item);
                    this.myIndicePreConfNovarexGrid.ItemsSource = null;
                    this.myIndicePreConfNovarexGrid.ItemsSource = parametrosIndicePreConfNovarex;

                    #endregion
                }
            }
            #endregion
            #endregion
        }

        private void myIndicePreConfNovarexGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {
            var row = e.Row as GridViewRow;
            if (e.Cell.Column.Name == "DeleteRow")
            {
                if (row != null)

                {
                    #region select datasource
                    if (row.DataContext != null)
                    {
                        Parametros_IndicePreconfiguradoNovarex Indiceselected = ((Reports_IICs.DataModels.Parametros_IndicePreconfiguradoNovarex)row.DataContext);

                        if (Indiceselected != null)
                        {
                            //var Indicesfijos = IndicePreconfiguradoNovarex_DA.GetIndicesFijos();
                            //var IsFijo = Indicesfijos.Where(c => c.Id == Indiceselected.IdIndicesPreconfiguradosNovarex);

                            #region elegir datasource del Grid
                            if(Indiceselected.IdIndicesPreconfiguradosNovarex == null)
                            {
                                ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSourceplantilla.Actions;
                                
                            }
                            else
                            {
                                ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSourceplantilla.ActionsOnlyEdit;
                            }
                           
                            #endregion
                        }
                        else
                        {
                            #region element just created not saved in entity yet
                            //if (((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).IdSeccion != null)
                            //{
                            //    var sec = DataSource.Secciones.Where(c => c.Id == (int)((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).IdSeccion).FirstOrDefault();
                            //    if (sec != null)
                            //    {
                            //        if (!sec.TieneParametrosPrevios)
                            //        {
                            //            ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsOnlyDelete;
                            //        }
                            //        else
                            //        {
                            //            ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsParam;
                            //        }
                            //    }
                            //}

                            #endregion
                        }
                    }
                    #endregion
                }
            }
        }

        private void txtBoxIndiceRvOtros_LostFocus(object sender, RoutedEventArgs e)
        {
            updateIndex();
        }

        private void txtBoxIndiceRfOtros_LostFocus(object sender, RoutedEventArgs e)
        {
            updateIndex();
        }

        private void txtBoxIndiceRepo_LostFocus(object sender, RoutedEventArgs e)
        {
            updateIndex();
        }

        private void updateIndex()
        {
            if (parametroOtros == null)
                parametroOtros = new DataModels.Parametros_IndicePreconfiguradoNovarex_Otros();

            parametroOtros.IndiceRvOtros = this.txtBoxIndiceRvOtros.Text;
            parametroOtros.IndiceRfOtros = this.txtBoxIndiceRfOtros.Text;
            parametroOtros.IndiceRepoTesDepOtros = this.txtBoxIndiceRepo.Text;
        }
    }
}
