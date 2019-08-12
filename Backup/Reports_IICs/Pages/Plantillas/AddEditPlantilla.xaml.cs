using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.ViewModels.Plantillas;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.ViewModels;
using MahApps.Metro.Controls.Dialogs;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.Pages.Plantillas.ControlesParametros;
using System.Text.RegularExpressions;
using Reports_IICs.Managers;
using Reports_IICs.Helpers;

namespace Reports_IICs.Pages.Plantillas
{


    /// <summary>
    /// Lógica de interacción para AddEditPlantilla.xaml
    /// </summary>
    public partial class AddEditPlantilla : MetroWindow
    {
        public string Codigo;
        public string Descripcion;
        public string codigoIc;
        public Plantilla _plantilla = new Plantilla();
        private int _noOfErrorsOnScreen = 0;
        private AddEditPlantillaValidation _addeditmaster = new AddEditPlantillaValidation();

        //decimal? ReferenciaTAE;

        private PlantillasPage_VM DataSource = new PlantillasPage_VM();
        private Tipos_VM Dstipos = new Tipos_VM();

        public bool Cancel = true;

        public AddEditPlantilla(Plantilla plantilla, List<string> listacodigo)
        {
            InitializeComponent();
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            _plantilla = plantilla;
            LayoutRoot.DataContext = _addeditmaster;

            Loaded += OnLoaded;
            populateData();
            _addeditmaster.plantilla = new Plantilla();
            _addeditmaster.plantilla = plantilla;
            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Codigo = _plantilla.CodigoIc;
            this.FechaCreacion.SelectedDate = DateTime.Today;

            if (_plantilla != null && string.IsNullOrEmpty(_plantilla.CodigoIc)) textBoxICC.Focus();

        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void AddElement_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private async void CloseCustomDialog(object sender, RoutedEventArgs e)
        {
            var dialog = (BaseMetroDialog)this.Resources["CustomCloseDialogTest"];

            await this.HideMetroDialogAsync(dialog);
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            /*
            Cancel = false;
            _plantilla.CodigoIc = textBoxICC.Text;
            _plantilla.Descripcion = textBoxDescription.Text;
            _plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
            _plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;

            if (!string.IsNullOrEmpty(textBoxReferenciaTae.Text)) _plantilla.ReferenciaTAE = decimal.Parse(textBoxReferenciaTae.Text);

            //#region validaciones

            string ErrorsMessage = string.Empty;
            if (_plantilla.Plantillas_Secciones.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo una sección.\n";
            if (_plantilla.Plantillas_Indices_Referencia.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo un índice.\n";
            if (_plantilla.Plantillas_Participes.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo una Participe.\n";
            if ((int)ComboBoxTipo.SelectedValue==2 && _plantilla.Plantillas_Isins.Count==0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo un ISIN.\n";
            if (!string.IsNullOrEmpty(ErrorsMessage))
             {
                //GBSecciones.Style = (System.Windows.Style)this.Resources["Validation.ErrorTemplate"];
                Cancel = true;
                #region show Dialog with errors
                //var mySettings = new MetroDialogSettings();
                //var dialog = (BaseMetroDialog)this.Resources["CustomCloseDialogTest"];
                

                //await this.ShowMetroDialogAsync(dialog);
                //var textBlock = dialog.FindChild<TextBlock>("MessageTextBlock");
                //textBlock.Text = ErrorsMessage;
                //await dialog.WaitUntilUnloadedAsync();

                RadWindow.Alert(new DialogParameters {  Content = ErrorsMessage, Header = "Se han generado los siguientes errores:" });


                #endregion
            }
            else
            {
                _addeditmaster = new AddEditPlantillaValidation();
                LayoutRoot.DataContext = _addeditmaster;
                e.Handled = true;
                this.Close();
            }
            #endregion
            */
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            //if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();
            //if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();
            if (_plantilla != null)
            {
                textBoxICC.Text = _plantilla.CodigoIc;
                textBoxDescription.Text = _plantilla.Descripcion;
                textBoxReferenciaTae.Text = _plantilla.ReferenciaTAE.ToString();
                comboBoxPerfilRiesgo.SelectedItem = _plantilla.PerfilRiesgo;
                if (_plantilla.CodigoIc != null) FechaCreacion.Text = _plantilla.FechaCreacion.ToString();
                this.RadGridViewIndices.ItemsSource = _plantilla.Plantillas_Indices_Referencia;
                this.RadGridViewIsin.ItemsSource = _plantilla.Plantillas_Isins;
                this.RadGridViewParticipes.ItemsSource = _plantilla.Plantillas_Participes;
                this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);

                ////Añadimos la descripción manualmente porque las Estrategias no existen como tal, son Tipos de Instrumento
                //foreach (var estrat in _plantilla.Plantillas_Estrategias)
                //{
                //    estrat.Descripcion = estrat.Instrumentos_Tipos.Descripcion;
                //}
                this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias;

                if (_plantilla.IdTipo != null)
                {
                    ComboBoxTipo.SelectedValue = _plantilla.IdTipo;
                }
                else
                {
                    ComboBoxTipo.SelectedValue = (int?)1;
                }

                //#region validation groupbox


                //#endregion

            }
            Loaded -= OnLoaded;
        }

        private void populateData()
        {
            //#region Preparing Colums 

            Telerik.Windows.Controls.GridViewDataColumn C_id = new Telerik.Windows.Controls.GridViewDataColumn();
            C_id.Header = "Id";
            C_id.Name = "Id";
            C_id.DataMemberBinding = new System.Windows.Data.Binding("Id");
            C_id.IsReadOnly = true;
            C_id.IsVisible = false;


            Telerik.Windows.Controls.GridViewDataColumn C_ISIN = new Telerik.Windows.Controls.GridViewDataColumn();
            C_ISIN.Header = "ISIN";
            C_ISIN.Name = "ISIN";
            C_ISIN.DataMemberBinding = new System.Windows.Data.Binding("Isin");
            C_ISIN.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            C_ISIN.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_Descripcion = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Descripcion.Header = "Descripción";
            C_Descripcion.Name = "Descripcion";
            C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
            C_Descripcion.DataMemberBinding = new System.Windows.Data.Binding("Descripcion");
            C_Descripcion.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_Identificador = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Identificador.Header = "Dni";
            C_Identificador.Name = "Dni";
            C_Identificador.DataMemberBinding = new System.Windows.Data.Binding("Identificador");
            //C_Identificador.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            C_Identificador.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_Nombre = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Nombre.Header = "Nombre";
            C_Nombre.Name = "Nombre";
            C_Nombre.DataMemberBinding = new System.Windows.Data.Binding("Titular");
            //C_Nombre.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            C_Nombre.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_Codigo = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Codigo.Header = "Código";
            C_Codigo.Name = "Codigo";
            C_Codigo.DataMemberBinding = new System.Windows.Data.Binding("Codigo");
            //C_Nombre.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
            C_Codigo.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_Descripcioncodigo = new Telerik.Windows.Controls.GridViewDataColumn();
            C_Descripcioncodigo.Header = "Descripción";
            C_Descripcioncodigo.Name = "Descripcion";
            C_Descripcioncodigo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
            C_Descripcioncodigo.DataMemberBinding = new System.Windows.Data.Binding("DescripcionCodigo");
            C_Descripcioncodigo.IsReadOnly = true;

            Telerik.Windows.Controls.GridViewDataColumn C_DescripcionEstrategia = new Telerik.Windows.Controls.GridViewDataColumn();
            C_DescripcionEstrategia.Header = "Descripción";
            C_DescripcionEstrategia.Name = "Descripcion";
            //C_DescripcionEstrategia.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
            C_DescripcionEstrategia.DataMemberBinding = new System.Windows.Data.Binding("Descripcion");
            C_DescripcionEstrategia.IsReadOnly = true;


            //#region remove colums before insert

            Telerik.Windows.Controls.RadGridView GridtoRemove = new Telerik.Windows.Controls.RadGridView();

            for (int i = 0; i < this.RadGridViewIsin.Columns.Count; i++)
            {

                if (this.RadGridViewIsin.Columns[i].UniqueName != "DeleteRow")
                {
                    if (this.RadGridViewIsin.Columns[i].UniqueName != "EditRow")
                    {
                        this.RadGridViewIsin.Columns.RemoveAt(i);
                        i--;
                    }

                }

            }

            //#endregion

            //#endregion

            //#region ISIN
            this.RadGridViewIsin.AutoGenerateColumns = false;
            this.RadGridViewIsin.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.RadGridViewIsin.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            this.RadGridViewIsin.Columns.Add(C_id);
            this.RadGridViewIsin.Columns.Add(C_ISIN);
            this.RadGridViewIsin.Columns.Add(C_Descripcion);
            this.RadGridViewIsin.ItemsSource = _plantilla.Plantillas_Isins;
            //#endregion

            //#region Secciones
            this.RadGridViewSecciones.AutoGenerateColumns = false;
            this.RadGridViewSecciones.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.RadGridViewSecciones.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            //this.RadGridViewSecciones.Columns.Add(C_id);
            //this.RadGridViewSecciones.Columns.Add(C_ISIN);
            //this.RadGridViewSecciones.Columns.Add(C_Descripcion);
            this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
            //#endregion

            //#region Participes
            this.RadGridViewParticipes.AutoGenerateColumns = false;
            this.RadGridViewParticipes.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.RadGridViewParticipes.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            this.RadGridViewParticipes.Columns.Add(C_id);
            //this.RadGridViewParticipes.Columns.Add(C_Identificador);
            this.RadGridViewParticipes.Columns.Add(C_Nombre);
            this.RadGridViewParticipes.ItemsSource = _plantilla.Plantillas_Participes;
            //#endregion

            //#region Indices

            this.RadGridViewIndices.AutoGenerateColumns = false;
            this.RadGridViewIndices.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.RadGridViewIndices.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            this.RadGridViewIndices.Columns.Add(C_id);
            this.RadGridViewIndices.Columns.Add(C_Codigo);
            this.RadGridViewIndices.Columns.Add(C_Descripcioncodigo);
            this.RadGridViewIndices.ItemsSource = _plantilla.Plantillas_Indices_Referencia;
            //#endregion

            //#region Secciones
            //this.RadGridViewEstrategias.AutoGenerateColumns = false;
            //this.RadGridViewEstrategias.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            //this.RadGridViewEstrategias.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            //this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias.OrderBy(c => c.Instrumentos_Tipos.Descripcion);
            //#endregion

            //#region Estrategias

            this.RadGridViewEstrategias.AutoGenerateColumns = false;
            this.RadGridViewEstrategias.GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            this.RadGridViewEstrategias.NewRowPosition = Telerik.Windows.Controls.GridView.GridViewNewRowPosition.None;

            this.RadGridViewEstrategias.Columns.Add(C_DescripcionEstrategia);
            this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias;
            //#endregion

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {

            string ErrorsMessage = string.Empty;
            if (this.ComboBoxTipo.SelectedItem == null) ErrorsMessage = ErrorsMessage + "Debe seleccionar un Tipo en el desplegable.\n";
            if (_plantilla.Plantillas_Secciones.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo una sección.\n";
            //if (_plantilla.Plantillas_Indices_Referencia.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo un índice.\n";
            //if (_plantilla.Plantillas_Participes.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo una Participe.\n";
            if (_plantilla.Plantillas_Isins.Count == 0) ErrorsMessage = ErrorsMessage + "La plantilla debe contener mínimo un ISIN.\n";
            if (!string.IsNullOrEmpty(ErrorsMessage))
            {
                //GBSecciones.Style = (System.Windows.Style)this.Resources["Validation.ErrorTemplate"];
                Cancel = true;
                #region show Dialog with errors
                //var mySettings = new MetroDialogSettings();
                //var dialog = (BaseMetroDialog)this.Resources["CustomCloseDialogTest"];


                //await this.ShowMetroDialogAsync(dialog);
                //var textBlock = dialog.FindChild<TextBlock>("MessageTextBlock");
                //textBlock.Text = ErrorsMessage;
                //await dialog.WaitUntilUnloadedAsync();

                RadWindow.Alert(new DialogParameters { Content = ErrorsMessage, Header = "Se han generado los siguientes errores:" });


                #endregion
            }
            else
            {
                Cancel = false;
                _plantilla.CodigoIc = textBoxICC.Text;
                _plantilla.Descripcion = textBoxDescription.Text;
                _plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
                _plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;
                string tae = textBoxReferenciaTae.Text;
                _plantilla.ReferenciaTAE = !string.IsNullOrEmpty(tae) ? decimal.Parse(tae) : Convert.ToDecimal(null);
                var perfilRiesgo = Convert.ToInt32(this.comboBoxPerfilRiesgo.SelectedItem);
                _plantilla.PerfilRiesgo = perfilRiesgo;

                try
                {

                    new PlantillaManager().Save(_plantilla, string.Empty);
                    this.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }


            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
            
        }

        private void AddNewIsin(object sender, RoutedEventArgs e)
        {

            //#region Add new Row

            //#region showWindow
            //int IdInserted = 0;


            Plantillas_Isins plantilla_isins = new Plantillas_Isins();

            //#region default

            //#region Fill List with List of Codes

            var rows = this.RadGridViewIsin.ChildrenOfType<GridViewRow>();
            List<string> ListaCodigo = new List<string>();

            /*
            foreach (GridViewRow item in rows)
            {
                ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion

            
            #region pass values to Plantilla

            _plantilla.CodigoIc = textBoxICC.Text;
            _plantilla.Descripcion = textBoxDescription.Text;
            _plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
            _plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;

            if (!string.IsNullOrEmpty(textBoxReferenciaTae.Text)) _plantilla.ReferenciaTAE = decimal.Parse(textBoxReferenciaTae.Text);

            #endregion
            */
            var window = new AddEditIsin(string.Empty, string.Empty, ListaCodigo);

            if (window != null)
            {
                //if (Application.Current.MainWindow != window)
                //{
                //    window.Owner = Application.Current.MainWindow;
                //    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //    var ownerMetroWindow = (window.Owner as MetroWindow);
                //    ownerMetroWindow.Height = window.Height;
                //    ownerMetroWindow.Width = window.Width;
                //    ownerMetroWindow.MinHeight = window.MinHeight;
                //    ownerMetroWindow.MinWidth = window.MinWidth;

                //    if (!ownerMetroWindow.IsOverlayVisible())
                //        ownerMetroWindow.ShowOverlayAsync();
                //}

                //window.ShowDialog();

                //window.Owner = Application.Current.MainWindow;
                //var ownerMetroWindow2 = (window.Owner as MetroWindow);

                //if (ownerMetroWindow2.IsOverlayVisible())
                //    ownerMetroWindow2.HideOverlayAsync();

                //if (!window.Cancel)

                Utils.ShowDialogWindow(window);

                if (window.DialogResult != null && (bool)window.DialogResult)
                {
                    //#region Retrieve Values from window

                    plantilla_isins.Isin = window.Isin;
                    plantilla_isins.Descripcion = window.Descripcion;
                    plantilla_isins.CodigoIc = _plantilla.CodigoIc;
                    _plantilla.Plantillas_Isins.Add(plantilla_isins);
                    
                    //try
                    //{
                    //    Plantilla plantilla_updated;
                    //    if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc,out plantilla_updated))
                    //    {
                    this.RadGridViewIsin.ItemsSource = null;
                    this.RadGridViewIsin.ItemsSource = _plantilla.Plantillas_Isins;
                    //_plantilla = plantilla_updated;
                    //    }
                    //    else
                    //    {
                    //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                    //    }
                    //}
                    //catch
                    //{

                    //}

                    //#endregion
                    //#region go to last row after insert
                    //this.radGridViewPlantilla.ScrollIntoViewAsync(this.radGridViewPlantilla.Items[this.radGridViewPlantilla.Items.Count - 1], //the row
                    //this.radGridViewPlantilla.Columns[this.radGridViewPlantilla.Columns.Count - 1], //the column
                    //new Action<FrameworkElement>((f) =>
                    //{
                    //    (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                    //}));
                    //#endregion
                }
            }
            //#endregion



            //#endregion

            //#endregion

        }
 
        private void AddNewParticipe(object sender, RoutedEventArgs e)
        {
            #region Add new Row

            #region showWindow
            //int IdInserted = 0;


            Plantillas_Participes plantilla_participes = new Plantillas_Participes();

            #region default

            #region Fill List with List of Codes

                var rows = this.RadGridViewParticipes.ChildrenOfType<GridViewRow>();
                List<string> ListaCodigo = new List<string>();
                foreach (GridViewRow item in rows)
                {
                    ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                }

            #endregion

            //#region pass values to Plantilla

            //_plantilla.CodigoIc = textBoxICC.Text;
            //_plantilla.Descripcion = textBoxDescription.Text;
            //_plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
            //_plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;

            //if (!string.IsNullOrEmpty(textBoxReferenciaTae.Text)) _plantilla.ReferenciaTAE = decimal.Parse(textBoxReferenciaTae.Text);

            //#endregion

            var window = new AddEditParticipes(string.Empty, string.Empty, string.Empty, string.Empty, ListaCodigo);

            if (window != null)
            {
                //if (Application.Current.MainWindow != window)
                //{
                //    window.Owner = Application.Current.MainWindow;
                //    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //    var ownerMetroWindow = (window.Owner as MetroWindow);
                //    ownerMetroWindow.Height = window.Height;
                //    ownerMetroWindow.Width = window.Width;
                //    ownerMetroWindow.MinHeight = window.MinHeight;
                //    ownerMetroWindow.MinWidth = window.MinWidth;

                //    if (!ownerMetroWindow.IsOverlayVisible())
                //        ownerMetroWindow.ShowOverlayAsync();
                //}

                //window.ShowDialog();

                //window.Owner = Application.Current.MainWindow;
                //var ownerMetroWindow2 = (window.Owner as MetroWindow);

                //if (ownerMetroWindow2.IsOverlayVisible())
                //    ownerMetroWindow2.HideOverlayAsync();

                //if (!window.Cancel)
                Utils.ShowDialogWindow(window);

                if (window.DialogResult != null && (bool)window.DialogResult)
                {
                    #region Retrieve Values from window
                    plantilla_participes.Identificador = window.NIFNIE;
                    plantilla_participes.Titular = window.NombreYapellidos;
                    plantilla_participes.TipoCuenta = window.Tipo;
                    plantilla_participes.CodigoCuenta  = window.Codigo;
                    plantilla_participes.CodigoIc = _plantilla.CodigoIc;

                    _plantilla.Plantillas_Participes.Add(plantilla_participes);

                    //try
                    //{
                    //    Plantilla plantilla_updated;
                    //    if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                    //    {
                    this.RadGridViewParticipes.ItemsSource = null;
                    this.RadGridViewParticipes.ItemsSource = _plantilla.Plantillas_Participes;
                    //        _plantilla = plantilla_updated;
                    //    }
                    //    else
                    //    {
                    //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                    //    }
                    //}
                    //catch
                    //{

                    //}

                    #endregion
                    #region go to last row after insert
                    //this.radGridViewPlantilla.ScrollIntoViewAsync(this.radGridViewPlantilla.Items[this.radGridViewPlantilla.Items.Count - 1], //the row
                    //this.radGridViewPlantilla.Columns[this.radGridViewPlantilla.Columns.Count - 1], //the column
                    //new Action<FrameworkElement>((f) =>
                    //{
                    //    (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                    //}));
                    #endregion
                }
            }
            #endregion

            #endregion

            #endregion
        }
        private void AddNewIndice(object sender, RoutedEventArgs e)
        {
            #region Add new Row
                #region showWindow
                //int IdInserted = 0;


                Plantillas_Indices_Referencia plantilla_indices_referencia = new Plantillas_Indices_Referencia();

            #region default

            #region Fill List with List of Codes

            var rows = this.RadGridViewIndices.ChildrenOfType<GridViewRow>();
            List<string> ListaCodigo = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[2])).Value.ToString());

            }

            #endregion

            //#region pass values to Plantilla

            //_plantilla.CodigoIc = textBoxICC.Text;
            //_plantilla.Descripcion = textBoxDescription.Text;
            //_plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
            //_plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;

            //if (!string.IsNullOrEmpty(textBoxReferenciaTae.Text)) _plantilla.ReferenciaTAE = decimal.Parse(textBoxReferenciaTae.Text);

            //#endregion
            var window = new AddEditIndices (string.Empty, string.Empty,null, ListaCodigo);

                if (window != null)
                {
                //if (Application.Current.MainWindow != window)
                //{
                //    window.Owner = Application.Current.MainWindow;
                //    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //    var ownerMetroWindow = (window.Owner as MetroWindow);
                //    ownerMetroWindow.Height = window.Height;
                //    ownerMetroWindow.Width = window.Width;
                //    ownerMetroWindow.MinHeight = window.MinHeight;
                //    ownerMetroWindow.MinWidth = window.MinWidth;
                //    if (!ownerMetroWindow.IsOverlayVisible())
                //            ownerMetroWindow.ShowOverlayAsync();
                //}

                //window.ShowDialog();

                //window.Owner = Application.Current.MainWindow;
                //var ownerMetroWindow2 = (window.Owner as MetroWindow);

                //if (ownerMetroWindow2.IsOverlayVisible())
                //    ownerMetroWindow2.HideOverlayAsync();

                //if (!window.Cancel)
                Utils.ShowDialogWindow(window);

                if (window.DialogResult != null && (bool)window.DialogResult)
                {
                        #region Retrieve Values from window
                        
                        
                        plantilla_indices_referencia.Codigo  = window.Codigo;
                        plantilla_indices_referencia.DescripcionCodigo = window.Descripcion;
                        if(window.ComboBoxTipo.SelectedValue!=null) plantilla_indices_referencia.IdTipoIndiceReferencia = (int)window.ComboBoxTipo.SelectedValue;
                        plantilla_indices_referencia.CodigoIc = _plantilla.CodigoIc;
                    _plantilla.Plantillas_Indices_Referencia.Add(plantilla_indices_referencia);

                        
                        //try
                        //{
                        //    Plantilla plantilla_updated;
                        //    if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc,out plantilla_updated))
                        //    {
                                this.RadGridViewIndices.ItemsSource = null;
                                this.RadGridViewIndices.ItemsSource = _plantilla.Plantillas_Indices_Referencia;
                        //    _plantilla = plantilla_updated;
                        //    }
                        //    else
                        //    {
                        //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                        //    }
                        //}
                        //catch
                        //{

                        //}
                    #endregion
                    #region go to last row after insert
                    //this.radGridViewPlantilla.ScrollIntoViewAsync(this.radGridViewPlantilla.Items[this.radGridViewPlantilla.Items.Count - 1], //the row
                    //this.radGridViewPlantilla.Columns[this.radGridViewPlantilla.Columns.Count - 1], //the column
                    //new Action<FrameworkElement>((f) =>
                    //{
                    //    (f as GridViewRow).IsSelected = true; // the callback method; if it is not necessary, you may set that parameter to null;
                    //}));
                    #endregion
                }
                }
                #endregion



                #endregion
            #endregion
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reports_IICs.DataModels.Indices_Referencia_Tipos isIndicesReferencia = new Indices_Referencia_Tipos();
            Reports_IICs.DataModels.Seccione isSeccione = new Seccione();

            if ((e.AddedItems.Count > 0) && (((object[])e.AddedItems)[0].GetType().Equals(isIndicesReferencia.GetType())))
            {
                //do nothing
            }
            else
            {

                if ((e.AddedItems.Count > 0) && (((object[])e.AddedItems)[0].GetType().Equals(isSeccione.GetType())))
                {
                    //do nothing
                }
                else
                {
                    #region Choose RadGridview
                    switch (((System.Windows.FrameworkElement)e.Source).Name)
                    {
                        case "RadGridViewIsin":
                            #region Isin

                            var selectedValue = this.RadGridViewIsin.SelectedItem;

                            if (e.AddedItems.Count > 0)
                            {

                                #region Editar
                                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                                {
                                    #region showWindow

                                    Plantillas_Isins plantilla_isins = new Plantillas_Isins();
                                    #region default

                                    #region Fill List with List of Codes

                                    var rows = this.RadGridViewIsin.ChildrenOfType<GridViewRow>();
                                    var selectedrow = this.RadGridViewIsin.SelectedItem;
                                    List<string> ListadoNoselected = new List<string>();
                                    foreach (GridViewRow item in rows)
                                    {
                                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                    }
                                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Plantillas_Isins)selectedrow).Isin);
                                    #endregion

                                    string wcodigo = string.Empty;
                                    string wdescripcion = string.Empty;
                                    #region Create Custom object to take values

                                    plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                                    wcodigo = plantilla_isins.Isin;
                                    wdescripcion = plantilla_isins.Descripcion;


                                    #endregion


                                    var window = new AddEditIsin(wcodigo, wdescripcion, ListadoNoselected);

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

                                        plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                                        wcodigo = plantilla_isins.Isin;
                                        wdescripcion = plantilla_isins.Descripcion;


                                        #endregion


                                        window.ShowDialog();

                                        window.Owner = Application.Current.MainWindow;
                                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                        if (ownerMetroWindow2.IsOverlayVisible())
                                            ownerMetroWindow2.HideOverlayAsync();

                                        if (!window.Cancel)
                                        {
                                            #region Retrieve Values from window

                                            _plantilla.Plantillas_Isins.Remove(plantilla_isins);

                                            plantilla_isins.Isin = window.Isin;
                                            plantilla_isins.Descripcion = window.Descripcion;
                                            plantilla_isins.CodigoIc = _plantilla.CodigoIc;
                                            _plantilla.Plantillas_Isins.Add(plantilla_isins);

                                           
                                            try
                                            {
                                                //Plantilla plantilla_updated;
                                                //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                                                //{
                                                //    this.RadGridViewIsin.ItemsSource = null;
                                                //    this.RadGridViewIsin.ItemsSource = _plantilla.Plantillas_Isins;
                                                //    _plantilla = plantilla_updated;

                                                //}
                                                //else
                                                //{
                                                //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                                                //}
                                            }
                                            catch(Exception ex)
                                            {
                                                throw ex;
                                            }

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
                                        Plantillas_Isins plantilla_isins = new Plantillas_Isins();
                                        plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                                        _plantilla.Plantillas_Isins.Remove(plantilla_isins);
                                        this.RadGridViewIsin.ItemsSource = null;
                                        this.RadGridViewIsin.ItemsSource = _plantilla.Plantillas_Isins;


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
                            #endregion

                            break;
                        case "RadGridViewParticipes":
                            #region Participes
                            var ParticipeSelectedValue = this.RadGridViewParticipes.SelectedItem;

                            if (e.AddedItems.Count > 0)
                            {

                                #region Editar
                                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                                {
                                    #region showWindow

                                    Plantillas_Participes plantilla_participes = new Plantillas_Participes();
                                    #region default

                                    #region Fill List with List of Codes

                                    var rows = this.RadGridViewParticipes.ChildrenOfType<GridViewRow>();
                                    var selectedrow = this.RadGridViewParticipes.SelectedItem;
                                    List<string> ListadoNoselected = new List<string>();
                                    foreach (GridViewRow item in rows)
                                    {
                                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                                    }
                                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Plantillas_Participes)selectedrow).Identificador);
                                    #endregion

                                    string wIdentificador = string.Empty;
                                    string wTitular = string.Empty;
                                    string wTipo = string.Empty;
                                    string wCodigo = string.Empty;

                                    #region Create Custom object to take values

                                    plantilla_participes = (Plantillas_Participes)this.RadGridViewParticipes.SelectedItem;
                                    wIdentificador = plantilla_participes.Identificador;
                                    wTitular = plantilla_participes.Titular;
                                    wTipo = plantilla_participes.TipoCuenta;
                                    wCodigo = plantilla_participes.CodigoCuenta;


                                    #endregion


                                    var window = new AddEditParticipes(wIdentificador, wTitular, wTipo, wCodigo, ListadoNoselected);

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

                                        plantilla_participes = (Plantillas_Participes)this.RadGridViewParticipes.SelectedItem;
                                        wIdentificador = plantilla_participes.Identificador;
                                        wTitular = plantilla_participes.Titular;
                                        wTipo = plantilla_participes.TipoCuenta;
                                        wCodigo = plantilla_participes.CodigoCuenta;

                                        //actualizarParticipesSalat();


                                        #endregion


                                        window.ShowDialog();

                                        window.Owner = Application.Current.MainWindow;
                                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                        if (ownerMetroWindow2.IsOverlayVisible())
                                            ownerMetroWindow2.HideOverlayAsync();

                                        if (!window.Cancel)
                                        {
                                            #region Retrieve Values from window

                                            plantilla_participes = (Plantillas_Participes)this.RadGridViewParticipes.SelectedItem;
                                            wIdentificador = plantilla_participes.Identificador;
                                            wTitular = plantilla_participes.Titular;
                                            wTipo = plantilla_participes.TipoCuenta;
                                            wCodigo = plantilla_participes.CodigoCuenta;

                                            _plantilla.Plantillas_Participes.Remove(plantilla_participes);

                                            plantilla_participes.Identificador = window.NIFNIE;
                                            plantilla_participes.Titular = window.NombreYapellidos;
                                            plantilla_participes.TipoCuenta = window.Tipo;
                                            plantilla_participes.CodigoCuenta = window.Codigo;
                                            plantilla_participes.CodigoIc = _plantilla.CodigoIc;

                                            //actualizarParticipesSalat();
                                            _plantilla.Plantillas_Participes.Add(plantilla_participes);
                                            
                                            try
                                            {
                                                //Plantilla plantilla_updated;
                                                //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                                                //{
                                                //    this.RadGridViewParticipes.ItemsSource = null;
                                                //    this.RadGridViewParticipes.ItemsSource = _plantilla.Plantillas_Participes;
                                                //    _plantilla = plantilla_updated;
                                                //}
                                                //else
                                                //{
                                                //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                                                //}
                                            }
                                            catch
                                            {

                                            }

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
                                        Plantillas_Participes plantilla_participes = new Plantillas_Participes();

                                        plantilla_participes = (Plantillas_Participes)this.RadGridViewParticipes.SelectedItem;
                                        _plantilla.Plantillas_Participes.Remove(plantilla_participes);
                                        this.RadGridViewParticipes.ItemsSource = null;
                                        this.RadGridViewParticipes.ItemsSource = _plantilla.Plantillas_Participes;


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
                            #endregion
                            break;
                        case "RadGridViewIndices":
                            #region Indices
                            var IndicesSelectedValue = this.RadGridViewIndices.SelectedItem;

                            if (e.AddedItems.Count > 0)
                            {

                                #region Editar
                                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                                {
                                    #region showWindow

                                    Plantillas_Indices_Referencia plantilla_indices = new Plantillas_Indices_Referencia();
                                    #region default

                                    #region Fill List with List of Codes

                                    var rows = this.RadGridViewIndices.ChildrenOfType<GridViewRow>();
                                    var selectedrow = this.RadGridViewIndices.SelectedItem;
                                    List<string> ListadoNoselected = new List<string>();
                                    foreach (GridViewRow item in rows)
                                    {
                                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[2])).Value.ToString());

                                    }
                                    ListadoNoselected.Remove(((Reports_IICs.DataModels.Plantillas_Indices_Referencia)selectedrow).Codigo);
                                    #endregion

                                    string wCodigo = string.Empty;
                                    string wDescripcion = string.Empty;
                                    int? wtipo = null;

                                    #region Create Custom object to take values

                                    plantilla_indices = (Plantillas_Indices_Referencia)this.RadGridViewIndices.SelectedItem;
                                    wCodigo = plantilla_indices.Codigo;
                                    wDescripcion = plantilla_indices.DescripcionCodigo;
                                    wtipo = plantilla_indices.IdTipoIndiceReferencia;
                                    #endregion


                                    var window = new AddEditIndices(wCodigo, wDescripcion, wtipo, ListadoNoselected);

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

                                        plantilla_indices = (Plantillas_Indices_Referencia)this.RadGridViewIndices.SelectedItem;
                                        wCodigo = plantilla_indices.Codigo;
                                        wDescripcion = plantilla_indices.DescripcionCodigo;
                                        wtipo = plantilla_indices.IdTipoIndiceReferencia;
                                        #endregion


                                        window.ShowDialog();

                                        window.Owner = Application.Current.MainWindow;
                                        var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                        if (ownerMetroWindow2.IsOverlayVisible())
                                            ownerMetroWindow2.HideOverlayAsync();

                                        if (!window.Cancel)
                                        {
                                            #region Retrieve Values from window

                                            plantilla_indices = (Plantillas_Indices_Referencia)this.RadGridViewIndices.SelectedItem;

                                            wCodigo = plantilla_indices.Codigo;
                                            wDescripcion = plantilla_indices.DescripcionCodigo;
                                            wtipo = plantilla_indices.IdTipoIndiceReferencia;
                                            _plantilla.Plantillas_Indices_Referencia.Remove(plantilla_indices);

                                            plantilla_indices.Codigo = window.Codigo;
                                            plantilla_indices.DescripcionCodigo = window.Descripcion;
                                            plantilla_indices.IdTipoIndiceReferencia = window.Tipo;
                                            plantilla_indices.CodigoIc = _plantilla.CodigoIc;
                                            _plantilla.Plantillas_Indices_Referencia.Add(plantilla_indices);
                                            
                                            try
                                            {
                                                //Plantilla plantilla_updated;
                                                //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                                                //{
                                                //    this.RadGridViewIndices.ItemsSource = null;
                                                //    this.RadGridViewIndices.ItemsSource = _plantilla.Plantillas_Indices_Referencia;
                                                //    _plantilla = plantilla_updated;
                                                //}
                                                //else
                                                //{
                                                //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                                                //}
                                            }
                                            catch
                                            {

                                            }
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
                                        Plantillas_Indices_Referencia plantilla_indices = new Plantillas_Indices_Referencia();

                                        plantilla_indices = (Plantillas_Indices_Referencia)this.RadGridViewIndices.SelectedItem;
                                        _plantilla.Plantillas_Indices_Referencia.Remove(plantilla_indices);
                                        this.RadGridViewIndices.ItemsSource = null;
                                        this.RadGridViewIndices.ItemsSource = _plantilla.Plantillas_Indices_Referencia;


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
                            #endregion
                            break;
                        case "RadGridViewSecciones":
                            #region Secciones
                            var SeccionesSelectedValue = this.RadGridViewSecciones.SelectedItem;

                            if (e.AddedItems.Count > 0)
                            {

                                #region Editar
                                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Parámetros")
                                {
                                    #region showWindow

                                    Plantillas_Secciones plantilla_seccion = new Plantillas_Secciones();
                                    #region default

                                    #region Fill List with List of Codes

                                    var rows = this.RadGridViewSecciones.ChildrenOfType<GridViewRow>();
                                    var selectedrow = (Plantillas_Secciones)this.RadGridViewSecciones.SelectedItem;
                                    var selectedSeccion = Secciones_DA.GetAll().Where(c => c.Id == selectedrow.IdSeccion).FirstOrDefault();
                                    List<string> ListadoNoselected = new List<string>();
                                    foreach (GridViewRow item in rows)
                                    {
                                        ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());
                                        
                                    }
                                    ListadoNoselected.Remove(selectedSeccion.Descripcion);
                                    #endregion

                                    //string wCodigo = string.Empty;
                                    //string wDescripcion = string.Empty;
                                    int? wSeccionId = null;

                                    #region Create Custom object to take values

                                    plantilla_seccion = (Plantillas_Secciones)this.RadGridViewSecciones.SelectedItem;
                                    //wCodigo = plantilla_seccion.Codigo;
                                    //wDescripcion = plantilla_seccion.DescripcionCodigo;
                                    wSeccionId = plantilla_seccion.IdSeccion;
                                    
                                    Parametros_GraficoBenchmark paramBenchmark = new Parametros_GraficoBenchmark();
                                    if (_plantilla.Parametros_GraficoBenchmark != null && _plantilla.Parametros_GraficoBenchmark.Count>0) paramBenchmark = _plantilla.Parametros_GraficoBenchmark.Where(c=>c.CodigoIc== plantilla_seccion.CodigoIc).FirstOrDefault();

                                    Parametros_RatiosCarteraRV paramCarteraRv = new Parametros_RatiosCarteraRV();
                                    if (_plantilla.Parametros_RatiosCarteraRV != null && _plantilla.Parametros_RatiosCarteraRV.Count > 0) paramCarteraRv = _plantilla.Parametros_RatiosCarteraRV.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    Parametros_EvolucionPatrimGuissona paramEvoPatriGuissona = new Parametros_EvolucionPatrimGuissona();
                                    if (_plantilla.Parametros_EvolucionPatrimGuissona != null && _plantilla.Parametros_EvolucionPatrimGuissona.Count > 0) paramEvoPatriGuissona = _plantilla.Parametros_EvolucionPatrimGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    Parametros_EvolucionRentabilidadGuissona paramEvoRentabGuissona = new Parametros_EvolucionRentabilidadGuissona();
                                    if (_plantilla.Parametros_EvolucionRentabilidadGuissona != null && _plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0) paramEvoRentabGuissona = _plantilla.Parametros_EvolucionRentabilidadGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    Parametros_EvolucionPatrimonioConjuntoGuissona paramEvoPatriConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();
                                    if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona != null && _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0) paramEvoPatriConjGuissona = _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    var paramIndicePreconfiguradoNovarex = new Parametros_IndicePreconfiguradoNovarex();
                                    if (_plantilla.Parametros_IndicePreconfiguradoNovarex!= null && _plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0) paramIndicePreconfiguradoNovarex= _plantilla.Parametros_IndicePreconfiguradoNovarex.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    var paramIndicePreconfiguradoNovarex_Otros = new Parametros_IndicePreconfiguradoNovarex_Otros();
                                    if (_plantilla.Parametros_IndicePreconfiguradoNovarex_Otros != null && _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Count > 0) paramIndicePreconfiguradoNovarex_Otros = _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();

                                    Parametros_DistribucionPatrimonioNovarex paramDistriPatrimNovarex = new Parametros_DistribucionPatrimonioNovarex();
                                    if (_plantilla.Parametros_DistribucionPatrimonioNovarex != null && _plantilla.Parametros_DistribucionPatrimonioNovarex.Count > 0) paramDistriPatrimNovarex = _plantilla.Parametros_DistribucionPatrimonioNovarex.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    //Parametros_VariacionPatrimonialB paramVariaPatrimonialB = new Parametros_VariacionPatrimonialB();
                                    //if (_plantilla.Parametros_VariacionPatrimonialB != null && _plantilla.Parametros_VariacionPatrimonialB.Count > 0) paramVariaPatrimonialB = _plantilla.Parametros_VariacionPatrimonialB.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                    var paramCompraVentaPrecAdq = new Parametros_CompraVentaPrecAdq();
                                    if (_plantilla.Parametros_CompraVentaPrecAdq!= null && _plantilla.Parametros_CompraVentaPrecAdq.Count > 0) paramCompraVentaPrecAdq = _plantilla.Parametros_CompraVentaPrecAdq.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();


                                    #endregion

                                    // var window = new AddEditSeccion(ListadoNoselected, wSeccionId, paramBenchmark, paramCarteraRv, _plantilla.Parametros_EvolucionMercados.ToList(), paramEvoPatriGuissona, paramEvoRentabGuissona, _plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.ToList(),paramEvoPatriConjGuissona, _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.ToList());
                                    //var window = new AddEditSeccionMulti(ListadoNoselected, wSeccionId, Plantilla, paramBenchmark, paramCarteraRv, _plantilla.Parametros_EvolucionMercados.ToList());
                                    var window = new AddEditSeccionMulti(ListadoNoselected, wSeccionId, ref _plantilla);
                                    if (window != null)
                                    {
                                        //if (Application.Current.MainWindow != window)
                                        //{
                                        //    window.Owner = Application.Current.MainWindow;
                                        //    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                        //    var ownerMetroWindow = (window.Owner as MetroWindow);
                                        //    ownerMetroWindow.Height = window.Height;
                                        //    ownerMetroWindow.Width = window.Width;
                                        //    ownerMetroWindow.MinHeight = window.MinHeight;
                                        //    ownerMetroWindow.MinWidth = window.MinWidth;
                                        //    if (!ownerMetroWindow.IsOverlayVisible())
                                        //        ownerMetroWindow.ShowOverlayAsync();
                                        //}

                                        #region Create Custom object to take values

                                        plantilla_seccion = (Plantillas_Secciones)this.RadGridViewSecciones.SelectedItem;
                                        //wCodigo = plantilla_indices.Codigo;
                                        //wDescripcion = plantilla_indices.DescripcionCodigo;
                                        wSeccionId = plantilla_seccion.IdSeccion;
                                        #endregion


                                        //window.ShowDialog();

                                        //window.Owner = Application.Current.MainWindow;
                                        //var ownerMetroWindow2 = (window.Owner as MetroWindow);

                                        //if (ownerMetroWindow2.IsOverlayVisible())
                                        //    ownerMetroWindow2.HideOverlayAsync();

                                        //if (!window.Cancel)
                                        //{
                                        Utils.ShowDialogWindow(window);

                                        if (window.DialogResult != null && (bool)window.DialogResult)
                                        {
                                            #region Retrieve Values from window

                                            plantilla_seccion = (Plantillas_Secciones)this.RadGridViewSecciones.SelectedItem;

                                            //wCodigo = plantilla_indices.Codigo;
                                            //wDescripcion = plantilla_indices.DescripcionCodigo;
                                            wSeccionId = plantilla_seccion.IdSeccion;
                                            _plantilla.Plantillas_Secciones.Remove(plantilla_seccion);

                                            if (window.ParamGraficoBenchmark == null) window.ParamGraficoBenchmark = new Parametros_GraficoBenchmark();
                                            window.ParamGraficoBenchmark.CodigoIc = _plantilla.CodigoIc;
                                            if (window.ParamRatiosCarteraRV == null)window.ParamRatiosCarteraRV = new Parametros_RatiosCarteraRV();
                                            window.ParamRatiosCarteraRV.CodigoIC = _plantilla.CodigoIc;
                                            //window.ParamEvoPatriGuissona.CodigoIC = _plantilla.CodigoIc;
                                            if (window.ParamEvolucionPatrimGuissona == null) window.ParamEvolucionPatrimGuissona = new Parametros_EvolucionPatrimGuissona();
                                            window.ParamEvolucionPatrimGuissona.CodigoIC = _plantilla.CodigoIc;
                                            if (window.ParamEvoRentabiGuissona == null) window.ParamEvoRentabiGuissona = new Parametros_EvolucionRentabilidadGuissona();
                                            window.ParamEvoRentabiGuissona.CodigoIC = _plantilla.CodigoIc;
                                            if (window.ParamEvoPatriConjGuissona == null) window.ParamEvoPatriConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();
                                            window.ParamEvoPatriConjGuissona.CodigoIC = _plantilla.CodigoIc;

                                            //if (window.ParamVariaPatrimonialB == null) window.ParamVariaPatrimonialB = new Parametros_VariacionPatrimonialB();
                                            //window.ParamVariaPatrimonialB.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamIndicePreconfiguradoNovarex == null) window.ParamIndicePreconfiguradoNovarex = new List<Parametros_IndicePreconfiguradoNovarex>();
                                            if (window.ParamIndicePreconfiguradoNovarexOtros == null) window.ParamIndicePreconfiguradoNovarexOtros = new Parametros_IndicePreconfiguradoNovarex_Otros();

                                            if (window.ParamPlusvaliasDividendosList == null) window.ParamPlusvaliasDividendosList = new List<Parametros_PlusvaliasDividendos>();
                                            
                                            if (window.ParamRFComprasVentasEjercicio == null) window.ParamRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();
                                                window.ParamRFComprasVentasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamCarteraRF == null) window.ParamCarteraRF = new Parametros_CarteraRF();
                                                window.ParamCarteraRF.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamCompraVentaPrecAdq == null) window.ParamCompraVentaPrecAdq = new Parametros_CompraVentaPrecAdq();
                                                window.ParamCompraVentaPrecAdq.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamDividendosCobrados == null) window.ParamDividendosCobrados = new Parametros_DividendosCobrados();
                                                window.ParamDividendosCobrados.CodigoIC  = _plantilla.CodigoIc;

                                            if (window.ParamRentabilidadCarteraII == null) window.ParamRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                                                window.ParamRentabilidadCarteraII.CodigoIC = _plantilla.CodigoIc;

                                            if (_plantilla.Parametros_IndicePreconfiguradoNovarex!= null && _plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0)
                                                _plantilla.Parametros_IndicePreconfiguradoNovarex.Remove(paramIndicePreconfiguradoNovarex);

                                            if (_plantilla.Parametros_IndicePreconfiguradoNovarex_Otros  == null) window.ParamIndicePreconfiguradoNovarexOtros= new Parametros_IndicePreconfiguradoNovarex_Otros();
                                            window.ParamIndicePreconfiguradoNovarexOtros.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamIIC_ComprasVentasEjercicio == null) window.ParamIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                                            window.ParamIIC_ComprasVentasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamOperacionesRentaVariable_II== null) window.ParamOperacionesRentaVariable_II = new Parametros_OperacionesRentaVariable_II();
                                            window.ParamOperacionesRentaVariable_II.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamGraficoCompPatrimonioTipoProducto== null) window.ParamGraficoCompPatrimonioTipoProducto= new Parametros_GraficoCompPatrimonioTipoProducto();
                                            window.ParamGraficoCompPatrimonioTipoProducto.CodigoIC = _plantilla.CodigoIc;

                                            if (window.ParamRVComprasRealizadasEjercicio  == null) window.ParamRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                                            window.ParamRVComprasRealizadasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                            if (_plantilla.Parametros_GraficoBenchmark != null && _plantilla.Parametros_GraficoBenchmark.Count > 0) _plantilla.Parametros_GraficoBenchmark.Remove(paramBenchmark);
                                            if (_plantilla.Parametros_RatiosCarteraRV != null && _plantilla.Parametros_RatiosCarteraRV.Count > 0) _plantilla.Parametros_RatiosCarteraRV.Remove(paramCarteraRv);
                                            if (_plantilla.Parametros_EvolucionPatrimGuissona != null && _plantilla.Parametros_EvolucionPatrimGuissona.Count > 0) _plantilla.Parametros_EvolucionPatrimGuissona.Remove(paramEvoPatriGuissona);
                                            if (_plantilla.Parametros_EvolucionRentabilidadGuissona != null && _plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0) _plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(paramEvoRentabGuissona);
                                            if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona != null && _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0) _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(paramEvoPatriConjGuissona);

                                            

                                            if (_plantilla.Parametros_DistribucionPatrimonioNovarex != null && _plantilla.Parametros_DistribucionPatrimonioNovarex.Count > 0)
                                                _plantilla.Parametros_DistribucionPatrimonioNovarex.Remove(paramDistriPatrimNovarex);

                                            //if (_plantilla.Parametros_VariacionPatrimonialB != null && _plantilla.Parametros_VariacionPatrimonialB.Count > 0) _plantilla.Parametros_VariacionPatrimonialB.Remove(paramVariaPatrimonialB);

                                            //if (window.ParamVariaPatrimonialB.ComisionFijaPagada != null) _plantilla.Parametros_VariacionPatrimonialB.Add(window.ParamVariaPatrimonialB);

                                            //if (_plantilla.Parametros_IndicePreconfiguradoNovarex != null && _plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0) _plantilla.Parametros_IndicePreconfiguradoNovarex.Remove(paramIndicePreconfiguradoNovarex);

                                            //if (window.ParamIndicePreconfiguradoNovarex != null) _plantilla.Parametros_IndicePreconfiguradoNovarex = window.ParamIndicePreconfiguradoNovarex.ToList();
                                            if (window.ParamPlusvaliasDividendosList != null) _plantilla.Parametros_PlusvaliasDividendos = window.ParamPlusvaliasDividendosList;

                                            if (window.ParamCarteraRF != null) _plantilla.Parametros_CarteraRF.Add(window.ParamCarteraRF);
                                            if (window.ParamCompraVentaPrecAdq != null) _plantilla.Parametros_CompraVentaPrecAdq.Add(window.ParamCompraVentaPrecAdq);
                                            if (window.ParamRFComprasVentasEjercicio != null) _plantilla.Parametros_RFComprasVentasEjercicio.Add(window.ParamRFComprasVentasEjercicio);
                                            if (window.ParamDividendosCobrados != null) _plantilla.Parametros_DividendosCobrados.Add(window.ParamDividendosCobrados);
                                            if (window.ParamRentabilidadCarteraII != null) _plantilla.Parametros_Rentabilidad_CarteraII.Add(window.ParamRentabilidadCarteraII);
                                            if (window.ParamIIC_ComprasVentasEjercicio != null) _plantilla.Parametros_IIC_ComprasVentasEjercicio.Add(window.ParamIIC_ComprasVentasEjercicio);
                                            if (window.ParamOperacionesRentaVariable_II != null) _plantilla.Parametros_OperacionesRentaVariable_II.Add(window.ParamOperacionesRentaVariable_II);
                                            if (window.ParamGraficoCompPatrimonioTipoProducto != null) _plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Add(window.ParamGraficoCompPatrimonioTipoProducto);
                                            if (window.ParamRVComprasRealizadasEjercicio != null) _plantilla.Parametros_RVComprasRealizadasEjercicio.Add(window.ParamRVComprasRealizadasEjercicio);



                                            //if (window.ParamGraficoBenchmark.Parametros_GraficoBenchmark_Indices !=null) _plantilla.Parametros_GraficoBenchmark.Add(window.ParamGraficoBenchmark);
                                            if(window.ParamRatiosCarteraRV.BpaAñoInformeMaximo != null) _plantilla.Parametros_RatiosCarteraRV.Add(window.ParamRatiosCarteraRV);
                                            //if(window.ParamEvoPatriGuissona.ComisionDepositaria != null) _plantilla.Parametros_EvolucionPatrimGuissona.Add(window.ParamEvoPatriGuissona);

                                            if (window.ParamGraficoBenchmark.FechaInicio != null) _plantilla.Parametros_GraficoBenchmark.Add(window.ParamGraficoBenchmark);

                                            if (window.ParamEvolucionPatrimGuissona.ComisionDepositaria != null) _plantilla.Parametros_EvolucionPatrimGuissona.Add(window.ParamEvolucionPatrimGuissona);
                                            if (window.ParamEvoRentabiGuissona.Titulo != null) _plantilla.Parametros_EvolucionRentabilidadGuissona.Add(window.ParamEvoRentabiGuissona);                                            
                                            if (window.ParamEvoPatriConjGuissona.Titulo != null) _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Add(window.ParamEvoPatriConjGuissona);


                                            List<Parametros_EvolucionRentabilidadGuissona_Fondos> temp_RentaFondo = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();

                                            foreach (var item in window.ParamEvoRentabiGuissona_Fondos)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_RentaFondo.Add(item);
                                            }
                                            _plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos = temp_RentaFondo;

                                            var temp_GrafBenchIndices = new List<Parametros_GraficoBenchmark_Indices>();

                                            foreach (var item in window.ParamGraficoBenchmark_Indices)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_GrafBenchIndices.Add(item);
                                            }
                                            _plantilla.Parametros_GraficoBenchmark_Indices = temp_GrafBenchIndices;


                                            /*
                                            List<Parametros_IndicePreconfiguradoNovarex> temp_IndPreNovarex = new List<Parametros_IndicePreconfiguradoNovarex>();

                                            foreach (var item in window.ParamIndicePreconfiguradoNovarex)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_IndPreNovarex.Add(item);
                                            }
                                            _plantilla.Parametros_IndicePreconfiguradoNovarex  = temp_IndPreNovarex;

                                        */


                                            List<Parametros_EvolucionMercados> temp_EvoMerca = new List<Parametros_EvolucionMercados>();

                                            foreach (var item in window.ParamEvolucionMercados)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_EvoMerca.Add(item);
                                            }
                                            _plantilla.Parametros_EvolucionMercados = temp_EvoMerca;


                                            List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> temp_RentaPatriConjFondo = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();

                                            //foreach (var item in window.ParamEvoPatrimConjGuissona_Fondos)
                                            foreach (var item in window.ParamEvoPatriConjGuissona_Fondos)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_RentaPatriConjFondo.Add(item);
                                            }
                                            _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos = temp_RentaPatriConjFondo;

                                            var temp_IndicePreconfiguradoNovarex = new List<Parametros_IndicePreconfiguradoNovarex>();


                                            foreach (var item in window.ParamIndicePreconfiguradoNovarex)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_IndicePreconfiguradoNovarex.Add(item);
                                            }
                                            _plantilla.Parametros_IndicePreconfiguradoNovarex= temp_IndicePreconfiguradoNovarex;

                                            if (window.ParamIndicePreconfiguradoNovarexOtros != null) _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Add(window.ParamIndicePreconfiguradoNovarexOtros);


                                            List<Parametros_DistribucionPatrimonioNovarex> temp_DistriPatriNovarex = new List<Parametros_DistribucionPatrimonioNovarex>();

                                            
                                            foreach (var item in window.ParamDistribPatriNovarex)
                                            {
                                                item.CodigoIC = _plantilla.CodigoIc;
                                                temp_DistriPatriNovarex.Add(item);
                                            }
                                            _plantilla.Parametros_DistribucionPatrimonioNovarex = temp_DistriPatriNovarex;

                                            //plantilla_seccion.IdSeccion = window.SeccionId;
                                            plantilla_seccion.IdSeccion = window.SeccionId.Value;
                                            plantilla_seccion.CodigoIc = _plantilla.CodigoIc;
                                            //_plantilla.Plantillas_Secciones.Add(plantilla_seccion);
                                            _plantilla.Plantillas_Secciones.Add(plantilla_seccion);

                                            this.RadGridViewSecciones.ItemsSource = null;
                                            this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
                                            
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
                                        //Plantillas_Secciones plantilla_seccion = new Plantillas_Secciones();
                                        var plantilla_seccion = (Plantillas_Secciones)this.RadGridViewSecciones.SelectedItem;

                                        Parametros_CarteraRF paramCarteraRF = new Parametros_CarteraRF();
                                        if (_plantilla.Parametros_CarteraRF != null && _plantilla.Parametros_CarteraRF.Count > 0)
                                            paramCarteraRF = _plantilla.Parametros_CarteraRF.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                        Parametros_GraficoBenchmark paramBenchmark = new Parametros_GraficoBenchmark();
                                        if (_plantilla.Parametros_GraficoBenchmark != null && _plantilla.Parametros_GraficoBenchmark.Count > 0) paramBenchmark = _plantilla.Parametros_GraficoBenchmark.Where(c => c.CodigoIc == plantilla_seccion.CodigoIc).FirstOrDefault();
                                        
                                        Parametros_PlusvaliasDividendos paramPlusvaliasDividendos = new Parametros_PlusvaliasDividendos();
                                        if (_plantilla.Parametros_PlusvaliasDividendos != null && _plantilla.Parametros_PlusvaliasDividendos.Count > 0) paramPlusvaliasDividendos = _plantilla.Parametros_PlusvaliasDividendos.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                        Parametros_VariacionPatrimonialB paramVariaPatrimonialB = new Parametros_VariacionPatrimonialB();
                                        if (_plantilla.Parametros_VariacionPatrimonialB != null && _plantilla.Parametros_VariacionPatrimonialB.Count > 0) paramVariaPatrimonialB = _plantilla.Parametros_VariacionPatrimonialB.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();                                        
                                        
                                        Parametros_EvolucionRentabilidadGuissona paramEvoRentabGuissona = new Parametros_EvolucionRentabilidadGuissona();
                                        if (_plantilla.Parametros_EvolucionRentabilidadGuissona != null && _plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0) paramEvoRentabGuissona = _plantilla.Parametros_EvolucionRentabilidadGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();


                                        Parametros_EvolucionPatrimGuissona paramEvoPatriGuissona = new Parametros_EvolucionPatrimGuissona();
                                        if (_plantilla.Parametros_EvolucionPatrimGuissona != null && _plantilla.Parametros_EvolucionPatrimGuissona.Count > 0) paramEvoPatriGuissona = _plantilla.Parametros_EvolucionPatrimGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                        Parametros_EvolucionPatrimonioConjuntoGuissona paramEvoPatriConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();
                                        if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona != null && _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0) paramEvoPatriConjGuissona = _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();

                                        Parametros_RatiosCarteraRV paramCarteraRv = new Parametros_RatiosCarteraRV();
                                        if (_plantilla.Parametros_RatiosCarteraRV != null && _plantilla.Parametros_RatiosCarteraRV.Count > 0) paramCarteraRv = _plantilla.Parametros_RatiosCarteraRV.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc).FirstOrDefault();



                                        List<Parametros_EvolucionMercados> paramEvoMerca = new List<Parametros_EvolucionMercados>();
                                        if (_plantilla.Parametros_EvolucionMercados != null && _plantilla.Parametros_EvolucionMercados.Count > 0)
                                        {
                                            foreach (var item in _plantilla.Parametros_EvolucionMercados.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc))
                                            {
                                                paramEvoMerca.Add(item);
                                            } 
                                        }

                                        var paramIndicePreconfiguradoNovarex = new List<Parametros_IndicePreconfiguradoNovarex>();
                                        if (_plantilla.Parametros_IndicePreconfiguradoNovarex!= null && _plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0)
                                        {
                                            foreach (var item in _plantilla.Parametros_IndicePreconfiguradoNovarex.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc))
                                            {
                                                paramIndicePreconfiguradoNovarex.Add(item);
                                            }
                                        }

                                        var paramIndOtros = new Parametros_IndicePreconfiguradoNovarex_Otros();
                                        if (_plantilla.Parametros_IndicePreconfiguradoNovarex_Otros != null && _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Count > 0) paramIndOtros = _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();

                                        List<Parametros_DistribucionPatrimonioNovarex> paramDistriPatriNovarex = new List<Parametros_DistribucionPatrimonioNovarex>();
                                        if (_plantilla.Parametros_DistribucionPatrimonioNovarex != null && _plantilla.Parametros_DistribucionPatrimonioNovarex.Count > 0)
                                        {
                                            foreach (var item in _plantilla.Parametros_DistribucionPatrimonioNovarex.Where(c => c.CodigoIC == plantilla_seccion.CodigoIc))
                                            {
                                                paramDistriPatriNovarex.Add(item);
                                            }
                                        }
                                        
                                        _plantilla.Plantillas_Secciones.Remove(plantilla_seccion);
                                        this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
                                        switch (plantilla_seccion.IdSeccion)
                                        {
                                            case 6:
                                            case 46:
                                                #region VARIACIÓN PATRIMONIAL B
                                                if (_plantilla.Parametros_VariacionPatrimonialB != null && _plantilla.Parametros_VariacionPatrimonialB.Count > 0) _plantilla.Parametros_VariacionPatrimonialB.Remove(paramVariaPatrimonialB);
                                                #endregion
                                                break;
                                            case 9:
                                                #region EVOLUCIÓN MERCADOS
                                                if (_plantilla.Parametros_EvolucionMercados != null && _plantilla.Parametros_EvolucionMercados.Count > 0)
                                                {
                                                    foreach (var item in paramEvoMerca)
                                                    {
                                                        _plantilla.Parametros_EvolucionMercados.Remove(item);
                                                    }
                                                }
                                                #endregion
                                                break;
                                            case 10:
                                                #region ÍNDICE PRECONFIGURADO (NOVAREX)
                                                
                                                if (_plantilla.Parametros_IndicePreconfiguradoNovarex!= null && _plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0)
                                                {
                                                    foreach (var item in paramIndicePreconfiguradoNovarex)
                                                    {
                                                        _plantilla.Parametros_IndicePreconfiguradoNovarex.Remove(item);
                                                    }
                                                }

                                                if (_plantilla.Parametros_IndicePreconfiguradoNovarex_Otros!= null && _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Count > 0) _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Remove(paramIndOtros);

                                                #endregion
                                                break;
                                            case 12:
                                                #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                                                if (_plantilla.Parametros_DistribucionPatrimonioNovarex != null && _plantilla.Parametros_DistribucionPatrimonioNovarex.Count > 0)
                                                {
                                                    foreach (var item in paramDistriPatriNovarex)
                                                    {
                                                        _plantilla.Parametros_DistribucionPatrimonioNovarex.Remove(item);
                                                    }
                                                }
                                                #endregion
                                                break;                                           
                                            case 17:
                                                #region PLUSVALÍAS Y DIVIDENDOS
                                                if (_plantilla.Parametros_PlusvaliasDividendos  != null && _plantilla.Parametros_PlusvaliasDividendos.Count > 0) _plantilla.Parametros_PlusvaliasDividendos.Remove(paramPlusvaliasDividendos);
                                                #endregion
                                                break;
                                            case 24://CARTERA RF
                                                if (_plantilla.Parametros_CarteraRF!= null && _plantilla.Parametros_CarteraRF.Count > 0) _plantilla.Parametros_CarteraRF.Remove(paramCarteraRF);
                                                break;
                                            case 25://GRÁFICO I (BENCHMARK)
                                            case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                                                #region GRÁFICO I (BENCHMARK)
                                                if (_plantilla.Parametros_GraficoBenchmark != null && _plantilla.Parametros_GraficoBenchmark.Count > 0) _plantilla.Parametros_GraficoBenchmark.Remove(paramBenchmark);
                                                #endregion
                                                break;
                                            case 27:
                                                #region  EVOLUCIÓN RENTABILIDAD GUISSONA
                                               
                                                if (_plantilla.Parametros_EvolucionRentabilidadGuissona != null && _plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0) _plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(paramEvoRentabGuissona);
                                                #endregion
                                                break;
                                            case 28:
                                                #region  EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                                if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona != null && _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0) _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(paramEvoPatriConjGuissona);
                                                #endregion
                                                break;
                                            case 29:
                                                #region EVOLUCIÓN PATRIMONIO GUISSONA
                                                if (_plantilla.Parametros_EvolucionPatrimGuissona != null && _plantilla.Parametros_EvolucionPatrimGuissona.Count > 0) _plantilla.Parametros_EvolucionPatrimGuissona.Remove(paramEvoPatriGuissona);
                                                #endregion
                                                break;
                                            case 36:
                                                #region RATIOS CARTERA RV (¿SECTORIALS?)
                                                    if (_plantilla.Parametros_RatiosCarteraRV != null && _plantilla.Parametros_RatiosCarteraRV.Count > 0) _plantilla.Parametros_RatiosCarteraRV.Remove(paramCarteraRv);
                                                #endregion
                                            break;
                                        }
                                        try
                                        {
                                            Plantilla plantilla_updated;
                                            if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                                            {
                                                this.RadGridViewSecciones.ItemsSource = null;
                                                this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
                                                _plantilla = plantilla_updated;
                                            }
                                            else
                                            {
                                                RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                                            }
                                         }
                                        catch(Exception ex)
                                        {
                                            RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });
                                            throw ex;
                                        }
                                        
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
                            #endregion
                            break;
                    }
                    #endregion
                }

            }
        }

        private void ComboBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // mostrarIsin(((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id);
        }

        private void mostrarIsin(int? codigoIc)
        {
            //if (codigoIc == 2)
            //{
            //    if(this.Cabezeraisin!=null) this.Cabezeraisin.Visibility = System.Windows.Visibility.Visible;
            //    if (this.StackPanelIsin!=null) this.StackPanelIsin.Visibility = System.Windows.Visibility.Visible;
            //}
            //else
            //{
            //    if (this.Cabezeraisin != null) this.Cabezeraisin.Visibility = System.Windows.Visibility.Collapsed;
            //    if (this.StackPanelIsin != null) this.StackPanelIsin.Visibility = System.Windows.Visibility.Collapsed;
            //}
        }


        private void AddNewSeccion(object sender, RoutedEventArgs e)
        {
            //#region Add new Row
            //#region showWindow
            //int IdInserted = 0;

            //#region default

            //#region Fill List with List of Codes


            var rows = this.RadGridViewSecciones.ChildrenOfType<GridViewRow>();
            List<string> ListaCodigo = new List<string>();

            foreach (var item in _plantilla.Plantillas_Secciones)
            {
                if (item.Seccione != null) ListaCodigo.Add(item.Seccione.Descripcion);
            }
            foreach (GridViewRow item in rows)
            {
                ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            //#endregion
            //Parametros_GraficoBenchmark paramBenchmark = new Parametros_GraficoBenchmark();

            //Parametros_RatiosCarteraRV paramCarteraRv = new Parametros_RatiosCarteraRV();

            //Parametros_EvolucionPatrimGuissona paramEvoPatriGuissona = new Parametros_EvolucionPatrimGuissona();

            //Parametros_EvolucionRentabilidadGuissona paramEvoRentabGuissona = new Parametros_EvolucionRentabilidadGuissona();

            //Parametros_EvolucionPatrimonioConjuntoGuissona paramEvoParamConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();

            //Parametros_EvolucionRentabilidadGuissona_Fondos paramEvoRentabGuissonaFondos = new Parametros_EvolucionRentabilidadGuissona_Fondos();

            //Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos paramEvoPatrimConjGuissonaFondos = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();

            //#region pass values to Plantilla

            //_plantilla.CodigoIc = textBoxICC.Text;
            //_plantilla.Descripcion = textBoxDescription.Text;
            //_plantilla.FechaCreacion = Convert.ToDateTime(FechaCreacion.SelectedDate);
            //_plantilla.IdTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;

            //if (!string.IsNullOrEmpty(textBoxReferenciaTae.Text)) _plantilla.ReferenciaTAE = decimal.Parse(textBoxReferenciaTae.Text);

            //#endregion

            //var window = new AddEditSeccionMulti(ListaCodigo,null, Plantilla, paramBenchmark, paramCarteraRv, _plantilla.Parametros_EvolucionMercados.ToList());
            var window = new AddEditSeccionMulti(ListaCodigo, null, ref _plantilla);
            //if (window != null)
            //{
            //    if (Application.Current.MainWindow != window)
            //    {
            //        window.Owner = Application.Current.MainWindow;
            //        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //        var ownerMetroWindow = (window.Owner as MetroWindow);
            //        ownerMetroWindow.Height = window.Height; 
            //        ownerMetroWindow.Width = window.Width;
            //        ownerMetroWindow.MinHeight = window.MinHeight;
            //        ownerMetroWindow.MinWidth = window.MinWidth;
            //        if (!ownerMetroWindow.IsOverlayVisible())
            //            ownerMetroWindow.ShowOverlayAsync();
            //    }

            //    window.ShowDialog();

            //    window.Owner = Application.Current.MainWindow;
            //    var ownerMetroWindow2 = (window.Owner as MetroWindow);

            //    if (ownerMetroWindow2.IsOverlayVisible())
            //        ownerMetroWindow2.HideOverlayAsync();

            //    if (!window.Cancel)
            //{
            if (window != null)
            {
                Utils.ShowDialogWindow(window);

                if (window.DialogResult != null && (bool)window.DialogResult)
                {
                    bool IsnotAddUpdateGraficoBenchmark = true;
                    bool IsnotAddUpdateEvolucionPatrimGuissona = true;
                    bool IsnotAddUpdateEvolucionRentabGuissona = true;
                    bool IsnotAddUpdateEvolucionPatrimConjGuissona = true;


                    foreach (DataItem item in window.Dataitems.DataItems.CheckedItems)
                    {
                        Plantillas_Secciones plantilla_seccion = new Plantillas_Secciones();
                        #region Retrieve Values from window
                        plantilla_seccion.IdSeccion = item.Seccion.Id;
                        plantilla_seccion.CodigoIc = _plantilla.CodigoIc;
                        //plantilla_seccion.Seccione = item.Seccion;


                        #region has config params?
                        if (window.StackConfigParam.Children.Count > 0)
                        {
                            switch (item.Seccion.Id)
                            {
                                case 6:
                                case 46:
                                    #region VARIACIÓN PATRIMONIAL B
                                    //Parametros_VariacionPatrimonialB temp_paramVPatri = new Parametros_VariacionPatrimonialB();
                                    //foreach (var param in window.StackConfigParam.Children)
                                    //{
                                    //    if (param is Param_VariacionPatrimonialB)
                                    //    {
                                    //        temp_paramVPatri.ComisionFijaPagada = (string.IsNullOrEmpty(((Param_VariacionPatrimonialB)param).txtBoxComisionFijaPagada.Text))? (decimal?)null :decimal.Parse(((Param_VariacionPatrimonialB)param).txtBoxComisionFijaPagada.Text);
                                    //    }
                                    //}
                                    //temp_paramVPatri.CodigoIC = _plantilla.CodigoIc;

                                    //_plantilla.Parametros_VariacionPatrimonialB.Add(temp_paramVPatri);
                                    #endregion
                                    break;
                                case 8:
                                    #region RENTABILIDAD CARTERA (II)

                                    Parametros_Rentabilidad_CarteraII temp_paramRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_Rentabilidad_carteraII)
                                        {
                                            if (((Param_Rentabilidad_carteraII)param).parametros != null)
                                            {
                                                temp_paramRentabilidadCarteraII.FechaInicio = ((Param_Rentabilidad_carteraII)param).parametros.FechaInicio;
                                            }
                                            else
                                            {
                                                if ((Param_Rentabilidad_carteraII)param != null)
                                                {
                                                    temp_paramRentabilidadCarteraII.FechaInicio = ((Param_Rentabilidad_carteraII)param).DpFechaInicio.SelectedDate;
                                                }

                                            }
                                        }
                                    }
                                    temp_paramRentabilidadCarteraII.CodigoIC = _plantilla.CodigoIc;

                                    _plantilla.Parametros_Rentabilidad_CarteraII.Add(temp_paramRentabilidadCarteraII);

                                    #endregion
                                    break;
                                case 9:
                                    #region EVOLUCIÓN MERCADOS
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_EvolucionMercados)
                                        {
                                            var pEvoMercados = (Param_EvolucionMercados)param;

                                            _plantilla.Parametros_EvolucionMercados.Clear();
                                            foreach (var itemEvoMerca in pEvoMercados.parametrosEvoMerca)
                                            {
                                                if (itemEvoMerca.CodigoIC == null)
                                                {
                                                    itemEvoMerca.CodigoIC = _plantilla.CodigoIc;
                                                    _plantilla.Parametros_EvolucionMercados.Add(itemEvoMerca);
                                                }
                                            }


                                        }
                                    }
                                    #endregion
                                    break;
                                case 10:
                                    #region ÍNDICE PRECONFIGURADO (NOVAREX)

                                    //// Parametros_IndicePreconfiguradoNovarex temp_paramIndicePreconfiguradoNovarex = new Parametros_IndicePreconfiguradoNovarex();
                                    // List<Parametros_IndicePreconfiguradoNovarex> temp_paramIndicePreconfiguradoNovarexList = new List<Parametros_IndicePreconfiguradoNovarex>();

                                    // foreach (var param in window.StackConfigParam.Children)
                                    // {
                                    //     if (param is Param_IndicePreconfiguradoNovarex)
                                    //     {
                                    //         temp_paramIndicePreconfiguradoNovarexList = ((Param_IndicePreconfiguradoNovarex)param).parametrosIndicePreConfNovarex;

                                    //     }
                                    // }

                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_IndicePreconfiguradoNovarex)
                                        {
                                            var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)param;

                                            _plantilla.Parametros_IndicePreconfiguradoNovarex.Clear();
                                            foreach (var itemIndicePreconfiguradoNovarex in pIndicePreconfiguradoNovarex.parametrosIndicePreConfNovarex)
                                            {
                                                if (itemIndicePreconfiguradoNovarex.CodigoIC == null)
                                                {
                                                    itemIndicePreconfiguradoNovarex.CodigoIC = _plantilla.CodigoIc;
                                                    _plantilla.Parametros_IndicePreconfiguradoNovarex.Add(itemIndicePreconfiguradoNovarex);
                                                }
                                            }

                                            _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Clear();
                                            _plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Add(pIndicePreconfiguradoNovarex.parametroOtros);
                                        }

                                    }


                                    #endregion
                                    break;
                                case 12:
                                    #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_DistriPatrimNovarex)
                                        {
                                            var pDistriPatrimNovarex = (Param_DistriPatrimNovarex)param;

                                            _plantilla.Parametros_DistribucionPatrimonioNovarex.Clear();
                                            foreach (var itemDistriPatrimNovarex in pDistriPatrimNovarex.parametrosDistriPatriNovarex)
                                            {
                                                if (itemDistriPatrimNovarex.CodigoIC == null)
                                                {
                                                    itemDistriPatrimNovarex.CodigoIC = _plantilla.CodigoIc;
                                                    _plantilla.Parametros_DistribucionPatrimonioNovarex.Add(itemDistriPatrimNovarex);
                                                }
                                            }


                                        }
                                    }
                                    #endregion
                                    break;
                                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                    #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                    var temp = new Parametros_CompraVentaPrecAdq();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_CompraVentaPrecAdq)
                                        {
                                            if (param != null && ((Param_CompraVentaPrecAdq)param).parametros != null)
                                            {
                                                temp.EfectivoMinimo = ((Param_CompraVentaPrecAdq)param).parametros.EfectivoMinimo;
                                            }
                                            else
                                            {
                                                if (param != null)
                                                {
                                                    var pEfect = Utils.CheckDecimal(((Param_CompraVentaPrecAdq)param).TxtEfectivoMinimo.Text);
                                                    if (pEfect != null)
                                                    {
                                                        temp.EfectivoMinimo = Convert.ToDecimal(pEfect);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    temp.CodigoIC = _plantilla.CodigoIc;
                                    _plantilla.Parametros_CompraVentaPrecAdq.Add(temp);

                                    #endregion
                                    break;
                                case 16:
                                    #region DIVIDENDOS COBRADOS

                                    Parametros_DividendosCobrados temp_paramDividendosCobrados = new Parametros_DividendosCobrados();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_DividendosCobrados)
                                        {
                                            if (((Param_DividendosCobrados)param).parametros != null)
                                            {
                                                temp_paramDividendosCobrados.FechaUltimaReunion = ((Param_DividendosCobrados)param).parametros.FechaUltimaReunion;
                                            }

                                        }
                                    }
                                    temp_paramDividendosCobrados.CodigoIC = _plantilla.CodigoIc;

                                    _plantilla.Parametros_DividendosCobrados.Add(temp_paramDividendosCobrados);



                                    #endregion
                                    break;
                                case 17:
                                    #region PLUSVALÍAS Y DIVIDENDOS

                                    Parametros_PlusvaliasDividendos temp_param_pl = new Parametros_PlusvaliasDividendos();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_PlusvaliasDividendos)
                                        {

                                            //temp_param_pl.Descripcion = ((Param_PlusvaliasDividendos)param).textBoxTitulo.Text;
                                            ////temp_param.Indice = ((Param_GraficoBenchMark)param).txtBoxIndice.Text;
                                            //temp_param_pl = ((Param_PlusvaliasDividendos)param).parametrosPlusvaliasDividendos[0];

                                            var pDistriPatrimNovarex = (Param_PlusvaliasDividendos)param;

                                            _plantilla.Parametros_PlusvaliasDividendos.Clear();
                                            foreach (var itemDistriPatrimNovarex in ((Param_PlusvaliasDividendos)param).parametrosPlusvaliasDividendos)
                                            {
                                                if (itemDistriPatrimNovarex.CodigoIC == null)
                                                {
                                                    itemDistriPatrimNovarex.CodigoIC = _plantilla.CodigoIc;

                                                }
                                                _plantilla.Parametros_PlusvaliasDividendos.Add(itemDistriPatrimNovarex);
                                            }
                                        }
                                    }



                                    #endregion
                                    break;
                                case 18:
                                    #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO

                                    Parametros_RVComprasRealizadasEjercicio temp_paramRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_RVComprasRealizadasEjercicio)
                                        {
                                            if (((Param_RVComprasRealizadasEjercicio)param).parametros != null)
                                            {
                                                temp_paramRVComprasRealizadasEjercicio.FechaUltimaReunion = ((Param_RVComprasRealizadasEjercicio)param).parametros.FechaUltimaReunion;
                                            }
                                            else
                                            {
                                                if ((Param_RVComprasRealizadasEjercicio)param != null)
                                                {
                                                    temp_paramRVComprasRealizadasEjercicio.FechaUltimaReunion = ((Param_RVComprasRealizadasEjercicio)param).DpFechaUltimaReunion.SelectedDate;
                                                }

                                            }

                                        }
                                    }
                                    temp_paramRVComprasRealizadasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                    _plantilla.Parametros_RVComprasRealizadasEjercicio.Add(temp_paramRVComprasRealizadasEjercicio);



                                    #endregion
                                    break;
                                case 19:
                                    #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO

                                    Parametros_IIC_ComprasVentasEjercicio temp_paramIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_IIC_ComprasVentasEjercicio)
                                        {
                                            if (((Param_IIC_ComprasVentasEjercicio)param).parametros != null)
                                            {
                                                temp_paramIIC_ComprasVentasEjercicio.FechaUltimaReunion = ((Param_IIC_ComprasVentasEjercicio)param).parametros.FechaUltimaReunion;
                                            }
                                            else
                                            {
                                                if ((Param_IIC_ComprasVentasEjercicio)param != null)
                                                {
                                                    temp_paramIIC_ComprasVentasEjercicio.FechaUltimaReunion = ((Param_IIC_ComprasVentasEjercicio)param).DpFechaUltimaReunion.SelectedDate;
                                                }

                                            }
                                        }
                                    }
                                    temp_paramIIC_ComprasVentasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                    _plantilla.Parametros_IIC_ComprasVentasEjercicio.Add(temp_paramIIC_ComprasVentasEjercicio);



                                    #endregion
                                    break;
                                case 20:
                                    #region RF: COMPRAS Y VENTAS EJERCICIO

                                    Parametros_RFComprasVentasEjercicio temp_paramRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_RFComprasVentasEjercicio)
                                        {

                                            temp_paramRFComprasVentasEjercicio.FechaAnterior = ((Param_RFComprasVentasEjercicio)param).DpFechaAnterior.SelectedDate;

                                        }
                                    }
                                    temp_paramRFComprasVentasEjercicio.CodigoIC = _plantilla.CodigoIc;

                                    _plantilla.Parametros_RFComprasVentasEjercicio.Add(temp_paramRFComprasVentasEjercicio);

                                    #endregion
                                    break;
                                case 24://CARTERA RF
                                    #region CARTERA RF
                                    var tempCRF = new Parametros_CarteraRF();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_CarteraRF)
                                        {
                                            if (((Param_CarteraRF)param).parametros != null)
                                            {
                                                tempCRF.VencimCortoMedioPlazo = ((Param_CarteraRF)param).parametros.VencimCortoMedioPlazo;
                                            }
                                            else
                                            {
                                                if ((Param_CarteraRF)param != null)
                                                {
                                                    int? vto = null;
                                                    if (!string.IsNullOrEmpty(((Param_CarteraRF)param).TextBox1.Text))
                                                    {
                                                        vto = Int32.Parse(((Param_CarteraRF)param).TextBox1.Text);
                                                    }
                                                    tempCRF.VencimCortoMedioPlazo = vto;
                                                }
                                            }
                                        }
                                    }

                                    tempCRF.CodigoIC = _plantilla.CodigoIc;
                                    _plantilla.Parametros_CarteraRF.Add(tempCRF);

                                    #endregion
                                    break;
                                case 25://GRÁFICO I (BENCHMARK)
                                case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                                    #region GRÁFICO I (BENCHMARK)

                                    Parametros_GraficoBenchmark temp_param = new Parametros_GraficoBenchmark();
                                    var temp_paramGrafBencIndices = new List<Parametros_GraficoBenchmark_Indices>();

                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_GraficoBenchMark)
                                        {

                                            //temp_param.Descripcion = ((Param_GraficoBenchMark)param).txtBoxDescripcion.Text;
                                            //temp_param.Indice = ((Param_GraficoBenchMark)param).txtBoxIndice.Text;
                                            if (((Param_GraficoBenchMark)param).DpFechainicio.SelectedDate != null)
                                                temp_param.FechaInicio = ((Param_GraficoBenchMark)param).DpFechainicio.SelectedDate.Value;
                                            temp_paramGrafBencIndices = ((Param_GraficoBenchMark)param).Indices;
                                        }
                                    }
                                    temp_param.CodigoIc = _plantilla.CodigoIc;

                                    var temp_paramGrafBenchIndiceswithCodeIc = new List<Parametros_GraficoBenchmark_Indices>();

                                    foreach (var itemInd in temp_paramGrafBencIndices)
                                    {
                                        itemInd.CodigoIC = _plantilla.CodigoIc;
                                        temp_paramGrafBenchIndiceswithCodeIc.Add(itemInd);
                                    }

                                    IsnotAddUpdateGraficoBenchmark = false;
                                    //Como este parámetro se utiliza para dos secciones, si ya existieran parámetros los eliminamos
                                    //y añadimos los nuevos
                                    if (_plantilla.Parametros_GraficoBenchmark.Count() > 0)
                                        _plantilla.Parametros_GraficoBenchmark.Clear();
                                   _plantilla.Parametros_GraficoBenchmark.Add(temp_param);
                                    _plantilla.Parametros_GraficoBenchmark_Indices = temp_paramGrafBenchIndiceswithCodeIc;
                                    #endregion
                                    break;
                                case 27:
                                    #region  EVOLUCIÓN RENTABILIDAD GUISSONA

                                    Parametros_EvolucionRentabilidadGuissona temp_paramEvoRentabGuissona = new Parametros_EvolucionRentabilidadGuissona();
                                    List<Parametros_EvolucionRentabilidadGuissona_Fondos> temp_paramEvoRentabGuissonaFondos = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_EvolucionRentabilidadGuissona)
                                        {

                                            temp_paramEvoRentabGuissona.Titulo = ((Param_EvolucionRentabilidadGuissona)param).textBoxTitulo.Text;
                                            temp_paramEvoRentabGuissonaFondos = ((Param_EvolucionRentabilidadGuissona)param).parametrosEvoRentabGuissona_Fondos;
                                        }

                                    }

                                    //Remove element create before
                                    if (_plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0)
                                    {
                                        _plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(_plantilla.Parametros_EvolucionRentabilidadGuissona.Where(c => c.Titulo == temp_paramEvoRentabGuissona.Titulo).FirstOrDefault());
                                    }

                                    ////Remove element create before
                                    //if (_plantilla.EvolucionRentabGuissona_Fondos.Count > 0)
                                    //{
                                    //    _plantilla.EvolucionRentabGuissona_Fondos.Remove(_plantilla.EvolucionRentabGuissona_Fondos.Where(c => c.Codigo == temp_paramEvoRentabGuissonaFondos.FirstOrDefault().Codigo).FirstOrDefault());
                                    //}


                                    temp_paramEvoRentabGuissona.CodigoIC = _plantilla.CodigoIc;

                                    List<Parametros_EvolucionRentabilidadGuissona_Fondos> temp_paramEvoRentabGuissonaFondoswithCodeIc = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();

                                    foreach (var itemFondo in temp_paramEvoRentabGuissonaFondos)
                                    {
                                        itemFondo.CodigoIC = _plantilla.CodigoIc;
                                        temp_paramEvoRentabGuissonaFondoswithCodeIc.Add(itemFondo);
                                    }


                                    IsnotAddUpdateEvolucionRentabGuissona = false;
                                    _plantilla.Parametros_EvolucionRentabilidadGuissona.Add(temp_paramEvoRentabGuissona);
                                    _plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos = temp_paramEvoRentabGuissonaFondoswithCodeIc;

                                    #endregion
                                    break;
                                case 28:
                                    #region  EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA


                                    Parametros_EvolucionPatrimonioConjuntoGuissona temp_paramEvoPatrimConjuntoGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();

                                    List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> temp_paramEvoEvoPatrimConjuntoGuissonaFondos = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {

                                        if (param is Param_EvolucionPatrimonioConjuntoGuissona)
                                        {

                                            temp_paramEvoPatrimConjuntoGuissona.Titulo = ((Param_EvolucionPatrimonioConjuntoGuissona)param).textBoxTitulo.Text;
                                            temp_paramEvoEvoPatrimConjuntoGuissonaFondos = ((Param_EvolucionPatrimonioConjuntoGuissona)param).parametrosEvPatrimonioConjuntoGuissona_Fondos;
                                        }

                                    }

                                    //Remove element create before
                                    if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0)
                                    {
                                        _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Where(c => c.Titulo == temp_paramEvoPatrimConjuntoGuissona.Titulo).FirstOrDefault());
                                    }

                                    ////Remove element create before
                                    //if (_plantilla.EvolucionRentabGuissona_Fondos.Count > 0)
                                    //{
                                    //    _plantilla.EvolucionRentabGuissona_Fondos.Remove(_plantilla.EvolucionRentabGuissona_Fondos.Where(c => c.Codigo == temp_paramEvoRentabGuissonaFondos.FirstOrDefault().Codigo).FirstOrDefault());
                                    //}

                                    temp_paramEvoPatrimConjuntoGuissona.CodigoIC = _plantilla.CodigoIc;

                                    List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> temp_paramEvoPatrimConjGuissonaFondoswithCodeIc = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();

                                    foreach (var itemFondo in temp_paramEvoEvoPatrimConjuntoGuissonaFondos)
                                    {
                                        itemFondo.CodigoIC = _plantilla.CodigoIc;
                                        temp_paramEvoPatrimConjGuissonaFondoswithCodeIc.Add(itemFondo);
                                    }

                                    IsnotAddUpdateEvolucionPatrimConjGuissona = false;

                                    _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Add(temp_paramEvoPatrimConjuntoGuissona);
                                    _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos = temp_paramEvoPatrimConjGuissonaFondoswithCodeIc;

                                    #endregion
                                    break;
                                case 29:
                                    #region  EVOLUCIÓN PATRIMONIO GUISSONA

                                    Parametros_EvolucionPatrimGuissona temp_paramEvoPatriConGuissona = new Parametros_EvolucionPatrimGuissona();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_EvolucionPatrimGuissona)
                                        {
                                            temp_paramEvoPatriConGuissona.ComisionDepositaria = decimal.Parse(((Param_EvolucionPatrimGuissona)param).txtBoxComisionDepositaria.Text);
                                            temp_paramEvoPatriConGuissona.TasaGestionAnual = decimal.Parse(((Param_EvolucionPatrimGuissona)param).txtBoxTasaGestionAnual.Text);
                                        }
                                    }


                                    //Remove element create before
                                    if (_plantilla.Parametros_EvolucionPatrimGuissona.Count > 0)
                                    {
                                        _plantilla.Parametros_EvolucionPatrimGuissona.Remove(_plantilla.Parametros_EvolucionPatrimGuissona.Where(c => c.ComisionDepositaria == temp_paramEvoPatriConGuissona.ComisionDepositaria).FirstOrDefault());
                                    }


                                    temp_paramEvoPatriConGuissona.CodigoIC = _plantilla.CodigoIc;
                                    IsnotAddUpdateEvolucionPatrimGuissona = false;
                                    _plantilla.Parametros_EvolucionPatrimGuissona.Add(temp_paramEvoPatriConGuissona);
                                    #endregion
                                    break;
                                case 35://OPERACIONES RENTA VARIABLE (II)
                                    #region OPERACIONES RENTA VARIABLE (II)
                                    var temp35 = new Parametros_OperacionesRentaVariable_II();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_OperacionesRentaVariable_II)
                                        {
                                            if (((Param_OperacionesRentaVariable_II)param).parametros != null)
                                            {
                                                temp35.FechaUltimoInforme = ((Param_OperacionesRentaVariable_II)param).parametros.FechaUltimoInforme;
                                                temp35.EfectivoMinimo = ((Param_OperacionesRentaVariable_II)param).parametros.EfectivoMinimo;
                                            }
                                            else
                                            {
                                                if ((Param_OperacionesRentaVariable_II)param != null)
                                                {
                                                    temp35.FechaUltimoInforme = ((Param_OperacionesRentaVariable_II)param).DpFechaUltimaReunion.SelectedDate;
                                                    if (((Param_OperacionesRentaVariable_II)param) != null)
                                                    {
                                                        decimal? efectMin = Utils.CheckDecimal(((Param_OperacionesRentaVariable_II)param).TxtEfectivoMinimo.Text);
                                                        temp35.EfectivoMinimo = efectMin;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    temp35.CodigoIC = _plantilla.CodigoIc;
                                    _plantilla.Parametros_OperacionesRentaVariable_II.Add(temp35);

                                    #endregion
                                    break;
                                case 36:
                                    #region RATIOS CARTERA RV (¿SECTORIALS?)
                                    Parametros_RatiosCarteraRV temp_paramRV = new Parametros_RatiosCarteraRV();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_RatiosCarteraRV)
                                        {

                                            #region temp_paramRV
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxBpaAñoInformeMaximo.Text))
                                                temp_paramRV.BpaAñoInformeMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxBpaAñoInformeMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxBpaAñoInformeMinimo.Text))
                                                temp_paramRV.BpaAñoInformeMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxBpaAñoInformeMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxBpaPrevisionMaximo.Text))
                                                temp_paramRV.BpaPrevisionMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxBpaPrevisionMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxBpaPrevisionMinimo.Text))
                                                temp_paramRV.BpaPrevisionMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxBpaPrevisionMinimo.Text);

                                            temp_paramRV.CodigoIC = _plantilla.CodigoIc;
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxDescuentoFundamentalMaximo.Text))
                                                temp_paramRV.DescuentoFundamentalMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxDescuentoFundamentalMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxDescuentoFundamentalMinimo.Text))
                                                temp_paramRV.DescuentoFundamentalMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxDescuentoFundamentalMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxDeudaNetaCapitalizacionMaximo.Text))
                                                temp_paramRV.DeudaNetaCapitalizacionMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxDeudaNetaCapitalizacionMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxDeudaNetaCapitalizacionMinimo.Text))
                                                temp_paramRV.DeudaNetaCapitalizacionMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxDeudaNetaCapitalizacionMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPerAñoInformeMaximo.Text))
                                                temp_paramRV.PerAñoInformeMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPerAñoInformeMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPerAñoInformeMinimo.Text))
                                                temp_paramRV.PerAñoInformeMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPerAñoInformeMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPerPrevisionMaximo.Text))
                                                temp_paramRV.PerPrevisionMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPerPrevisionMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPerPrevisionMinimo.Text))
                                                temp_paramRV.PerPrevisionMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPerPrevisionMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPrecioVcMaximo.Text))
                                                temp_paramRV.PrecioVcMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPrecioVcMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxPrecioVcMinimo.Text))
                                                temp_paramRV.PrecioVcMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxPrecioVcMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesAñoInformeMaximo.Text))
                                                temp_paramRV.RentabilidadesAñoInformeMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesAñoInformeMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesAñoInformeMinimo.Text))
                                                temp_paramRV.RentabilidadesAñoInformeMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesAñoInformeMinimo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesPrevisionMaximo.Text))
                                                temp_paramRV.RentabilidadesPrevisionMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesPrevisionMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesPrevisionMinimo.Text))
                                                temp_paramRV.RentabilidadesPrevisionMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxRentabilidadesPrevisionMinimo.Text);
                                            //if(!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxValorFundamentalMaximo.Text))
                                            //temp_paramRV.ValorFundamentalMaximo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxValorFundamentalMaximo.Text);
                                            if (!string.IsNullOrEmpty(((Param_RatiosCarteraRV)(param)).txtBoxValorFundamentalMinimo.Text))
                                                temp_paramRV.ValorFundamentalMinimo = decimal.Parse(((Param_RatiosCarteraRV)(param)).txtBoxValorFundamentalMinimo.Text);
                                            #endregion

                                        }
                                    }
                                    _plantilla.Parametros_RatiosCarteraRV.Add(temp_paramRV);
                                    #endregion
                                    break;
                                case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                    #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                    var tempGraf = new Parametros_GraficoCompPatrimonioTipoProducto();
                                    foreach (var param in window.StackConfigParam.Children)
                                    {
                                        if (param is Param_GraficoCompPatrimonioTipoProducto)
                                        {
                                            if (((Param_GraficoCompPatrimonioTipoProducto)param).parametros != null)
                                            {
                                                tempGraf.PorcEstrategiasRA = ((Param_GraficoCompPatrimonioTipoProducto)param).parametros.PorcEstrategiasRA;
                                            }
                                            //else
                                            //{
                                            //    if ((Param_OperacionesRentaVariable_II)param != null)
                                            //    {
                                            //        temp.FechaUltimoInforme = ((Param_OperacionesRentaVariable_II)param).DpFechaUltimaReunion.SelectedDate;
                                            //        temp.EfectivoMinimo = decimal.Parse(((Param_OperacionesRentaVariable_II)param).TxtEfectivoMinimo.Text);
                                            //    }
                                            //}
                                        }
                                    }

                                    //tempGraf.CodigoIC = _plantilla.CodigoIc;
                                    _plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Add(tempGraf);

                                    #endregion
                                    break;
                            }

                        }

                        #endregion

                        #region Remove param inserted before

                        #region GraficoBenchmark
                        if (IsnotAddUpdateEvolucionRentabGuissona)
                        {
                            //Remove element create before
                            #region EvolucionRentabGuissona_Fondos
                            if (_plantilla.Parametros_GraficoBenchmark_Indices.Count > 0)
                            {
                                var p = new Parametros_GraficoBenchmark_Indices();

                                foreach (var itemGrafB in _plantilla.Parametros_GraficoBenchmark_Indices)
                                {
                                    if (String.IsNullOrEmpty(itemGrafB.CodigoIC))
                                    {
                                        p = itemGrafB;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_GraficoBenchmark_Indices.Remove(p);

                            }


                            #endregion

                            #region EvolucionRentabGuissona
                            if (_plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0)
                            {
                                Parametros_EvolucionRentabilidadGuissona p = new Parametros_EvolucionRentabilidadGuissona();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionRentabilidadGuissona)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(p);

                            }


                            #endregion
                        }
                        #endregion

                        #region EvolucionGrafBenchmark
                        if (IsnotAddUpdateGraficoBenchmark)
                        {
                            //Remove element create before
                            #region GraficoBenchmark_Indices
                            if (_plantilla.Parametros_GraficoBenchmark_Indices.Count > 0)
                            {
                                var p = new Parametros_GraficoBenchmark_Indices();

                                foreach (var itemGrafB in _plantilla.Parametros_GraficoBenchmark_Indices)
                                {
                                    if (String.IsNullOrEmpty(itemGrafB.CodigoIC))
                                    {
                                        p = itemGrafB;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_GraficoBenchmark_Indices.Remove(p);

                            }


                            #endregion

                            #region GraficoBenchmark
                            if (_plantilla.Parametros_GraficoBenchmark.Count > 0)
                            {
                                var p = new Parametros_GraficoBenchmark();

                                foreach (var itemGrafB in _plantilla.Parametros_GraficoBenchmark)
                                {
                                    if (String.IsNullOrEmpty(itemGrafB.CodigoIc))
                                    {
                                        p = itemGrafB;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_GraficoBenchmark.Remove(p);

                            }


                            #endregion
                        }
                        #endregion

                        #region EvolucionRentabGuissona
                        if (IsnotAddUpdateEvolucionRentabGuissona)
                        {
                            //Remove element create before
                            #region EvolucionRentabGuissona_Fondos
                            if (_plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Count > 0)
                            {
                                Parametros_EvolucionRentabilidadGuissona_Fondos p = new Parametros_EvolucionRentabilidadGuissona_Fondos();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Remove(p);

                            }


                            #endregion

                            #region EvolucionRentabGuissona
                            if (_plantilla.Parametros_EvolucionRentabilidadGuissona.Count > 0)
                            {
                                Parametros_EvolucionRentabilidadGuissona p = new Parametros_EvolucionRentabilidadGuissona();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionRentabilidadGuissona)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(p);

                            }


                            #endregion
                        }
                        #endregion

                        #region EvolucionPatrimConjGuissona
                        if (IsnotAddUpdateEvolucionPatrimConjGuissona)
                        {
                            //Remove element create before
                            #region EvolucionPatrimConjGuissona_Fondos
                            if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Count > 0)
                            {
                                Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos p = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Remove(p);

                            }


                            #endregion

                            #region EvolucionPatrimConjGuissona
                            if (_plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count > 0)
                            {
                                Parametros_EvolucionPatrimonioConjuntoGuissona p = new Parametros_EvolucionPatrimonioConjuntoGuissona();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(p);

                            }


                            #endregion

                        }
                        #endregion

                        #region EvolucionPatrimGuissona
                        if (IsnotAddUpdateEvolucionPatrimGuissona)
                        {
                            //Remove element create before
                            if (_plantilla.Parametros_EvolucionPatrimGuissona.Count > 0)
                            {
                                Parametros_EvolucionPatrimGuissona p = new Parametros_EvolucionPatrimGuissona();

                                foreach (var itemEPatriG in _plantilla.Parametros_EvolucionPatrimGuissona)
                                {
                                    if (String.IsNullOrEmpty(itemEPatriG.CodigoIC))
                                    {
                                        p = itemEPatriG;
                                        break;
                                    }

                                }

                                _plantilla.Parametros_EvolucionPatrimGuissona.Remove(p);

                            }

                        }
                        #endregion

                        #endregion

                        _plantilla.Plantillas_Secciones.Add(plantilla_seccion);

                        #endregion

                    }

                    //this.RadGridViewSecciones.ItemsSource = null;
                    //this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);

                    //try
                    //{
                    //    Plantilla plantilla_updated;
                    //    if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                    //    {
                    this.RadGridViewSecciones.ItemsSource = null;
                    this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
                    //        _plantilla = plantilla_updated;
                    //    }
                    //    else
                    //    {
                    //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                    //    }
                    //}
                    //catch
                    //{

                    //}

                }
            }
            //#endregion


            //#endregion
            //#endregion

            // _addeditmaster.plantilla = Plantilla;
            // _addeditmaster.SeccionesRows = _plantilla.Plantillas_Secciones.Count();
            //// this.checkedBindingGroup.UpdateSources();
            // DependencyProperty SeccionesRowsProperty =
            // DependencyProperty.Register("SeccionesRows", typeof(int?), typeof(AddEditPlantillaValidation), null);

            // this.checkedBindingGroup.SetValue(SeccionesRowsProperty, _plantilla.Plantillas_Secciones.Count());
            // this.checkedBindingGroup.ValidateWithoutUpdate();
        }

        private void AddNewEstrategia(object sender, RoutedEventArgs e)
        {
            var rows = this.RadGridViewEstrategias.ChildrenOfType<GridViewRow>();
            List<string> ListaCodigo = new List<string>();

            //foreach (var item in _plantilla.Plantillas_Estrategias)
            //{
            //    //if (item.Instrumentos_Tipos != null) ListaCodigo.Add(item.Instrumentos_Tipos.Descripcion);
            //}


            //var window = new AddEditSeccionMulti(ListaCodigo,null, Plantilla, paramBenchmark, paramCarteraRv, _plantilla.Parametros_EvolucionMercados.ToList());
            var window = new AddEditEstrategia(_plantilla);
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

                window.ShowDialog();

                window.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!window.Cancel)
                {

                    foreach (var item in window.Dataitems.DataItemsCombo.CheckedItems)
                    {
                        var plEstrat = (Plantillas_Estrategias)item.Item;
                        //var plEstrat = new Plantillas_Estrategias();
                        //    #region Retrieve Values from window
                        //plEstrat.IdTipoInstrumento = ((Plantillas_Estrategias)item.Item).IdTipoInstrumento;
                        //plEstrat.CodigoIC = _plantilla.CodigoIc;
                        ////plEstrat.Instrumentos_Tipos = (Instrumentos_Tipos)item.Item;

                        _plantilla.Plantillas_Estrategias.Add(plEstrat);
                    }
                        
                        this.RadGridViewEstrategias.ItemsSource = null;
                        this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias;
                        //        Plantilla = plantilla_updated;
                        //    }
                        //    else
                        //    {
                        //        RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                        //    }
                        //}
                        //catch
                        //{

                        //}

                    
                }
                //#endregion


                //#endregion
                //#endregion


            }
        }

        private void SortSeccion(object sender, RoutedEventArgs e)
        {
            
            #region showWindow


            //Plantillas_Secciones plantilla_seccion = new Plantillas_Secciones();

            #region default

            #region Fill List with List of Codes
            var rows = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
            //var rows = this.RadGridViewSecciones.ChildrenOfType<GridViewRow>();

            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            List<string> ListaCodigo = new List<string>();
            foreach (Plantillas_Secciones item in rows)
            {
                //var temp_secciones = dbContext.Secciones.Where(n => n.Id == item.IdSeccion).FirstOrDefault();
                var temp_secciones = _plantilla.Plantillas_Secciones.Where(n => n.IdSeccion == item.IdSeccion).FirstOrDefault();
                //ListaCodigo.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());
                if (temp_secciones != null)
                {
                    string desc = string.Empty;
                    if (temp_secciones.Seccione != null)
                    {
                        desc = temp_secciones.Seccione.Descripcion;
                    }
                    else
                    {
                        var sec = VariablesGlobales.Secciones_Local.Where(w => w.Id == item.IdSeccion).FirstOrDefault();
                        if(sec != null)
                        {
                            desc = sec.Descripcion;
                        }
                    }
                    ListaCodigo.Add(desc);
                }
                
            }

            #endregion

            var window = new SortSeccion(ListaCodigo);

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

                window.ShowDialog();
                
                window.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!window.Cancel)
                {
                    #region Retrieve Values from window

                    //_plantilla.Plantillas_Secciones.Clear();
                    int order = 1;
                    foreach (var item in window.SeccionesList.Items)
                    {
                        
                        Reports_IICs.DataModels.Seccione current = PlantillasPage_VM.GetSecciones().Where(c => c.Descripcion == item.ToString()).FirstOrDefault();
                       
                        if(current!= null)
                        {
                            _plantilla.Plantillas_Secciones.Where(c => c.IdSeccion == current.Id).FirstOrDefault().Orden = order;
                        }
                        
                        order++;                        
                    }

                    this.RadGridViewSecciones.ItemsSource = null;
                    this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);

                    #region save
                    try
                    {
                        //Plantilla plantilla_updated;
                        //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                        //{
                        //    this.RadGridViewSecciones.ItemsSource = null;
                        //    this.RadGridViewSecciones.ItemsSource = _plantilla.Plantillas_Secciones.OrderBy(c => c.Orden);
                        //    _plantilla = plantilla_updated;
                        //}
                        //else
                        //{
                        //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                        //}
                    }
                    catch
                    {

                    }
                    #endregion

                    #endregion

                }
                
            }
            #endregion

            #endregion

            

        }

        private void RadGridViewSecciones_RowLoaded(object sender, RowLoadedEventArgs e)
        {
               
        }
        private void RadGridViewTipos_RowLoaded(object sender, RowLoadedEventArgs e)
        {

        }

        private void RadGridViewSecciones_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {
            var row = e.Row as GridViewRow;
            if(e.Cell.Column.Name == "DeleteRow")
            {
                if (row != null)

                {
                    
                    #region select datasource
                    if(row.DataContext!= null)
                    {
                        Seccione secselected = ((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).Seccione;

                        if (secselected != null )
                        {
                            #region elegir datasource del Grid
                            if (!secselected.TieneParametrosPrevios)
                            {
                                ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsOnlyDelete; 
                            }
                            else
                            {
                                ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsParam;
                            }
                            #endregion
                        }
                        else
                        {
                            #region element just created not saved in entity yet
                            if(((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).IdSeccion!=null)
                            {
                                var sec = DataSource.Secciones.Where(c => c.Id == (int)((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).IdSeccion).FirstOrDefault();
                                if(sec!=null)
                                { 
                                    if(!sec.TieneParametrosPrevios)
                                    {
                                        ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsOnlyDelete;
                                    }
                                    else
                                    {
                                        ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsParam;
                                    }
                                }
                            }

                            #endregion
                        }
                    }

                  
                    #endregion
                }
            }
            

        }

        //private void actualizarParticipesSalat()
        //{
        //    //Al principio estaba montado para hacer con parámetros
        //    //finalmente se hará con los partícipes, así que para no cambiar todo
        //    //Copiamos los partícipes a Parametros_ParticipesSalat
        //    var listaParam = new List<Plantillas_Participes>();

        //    foreach (var part in _plantilla.Plantillas_Participes)
        //    {
        //        //Sólo añadimos los titulares que tienen los datos de cuenta
        //        if (!string.IsNullOrEmpty(part.TipoCuenta) && !string.IsNullOrEmpty(part.CodigoCuenta))
        //        {
        //            var param = new Plantillas_Participes();
        //            param.CodigoCuenta = part.CodigoCuenta;
        //            param.CodigoIc = part.CodigoIc;
        //            param.Titular = part.Titular;
        //            param.TipoCuenta = part.TipoCuenta;

        //            listaParam.Add(param);
        //        }
        //    }

        //    ParticipesSalat_DA.InsertParametros(listaParam);
        //}
        private void RadGridViewEstrategias_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {
            var row = e.Row as GridViewRow;
            if (e.Cell.Column.Name == "DeleteRowEstrategia")
            {
                if (row != null)

                {

                    //#region select datasource
                    //if (row.DataContext != null)
                    //{
                    //    var objSelected = ((Reports_IICs.DataModels.Plantillas_Estrategias)row.DataContext).Instrumentos_Tipos;

                    //    if (objSelected != null)
                    //    {
                    //        #region elegir datasource del Grid
                    //        ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.Actions;                            
                    //        #endregion
                    //    }
                    //    else
                    //    {
                    //        #region element just created not saved in entity yet
                    //        if (((Reports_IICs.DataModels.Plantillas_Estrategias)row.DataContext).IdTipoInstrumento != null)
                    //        {
                    //            var sec = DataSource.Secciones.Where(c => c.Id == (int)((Reports_IICs.DataModels.Plantillas_Secciones)row.DataContext).IdSeccion).FirstOrDefault();
                    //            if (sec != null)
                    //            {
                    //                if (!sec.TieneParametrosPrevios)
                    //                {
                    //                    ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsOnlyDelete;
                    //                }
                    //                else
                    //                {
                    //                    ((Telerik.Windows.Controls.GridViewComboBoxColumn)e.Cell.Column).ItemsSource = DataSource.ActionsParam;
                    //                }
                    //            }
                    //        }

                    //        #endregion
                    //    }
                    //}


                    //#endregion
                }
            }


        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,-]+").IsMatch(e.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(e.RemovedItems.Count != 0)
            //{

            //}
            //#region Delete
            string texto = ((RadComboBox)sender).Text;
            if (!string.IsNullOrEmpty(texto) &&  texto.Equals("Eliminar"))
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
                    var sel = (Plantillas_Estrategias)this.RadGridViewEstrategias.SelectedItem;
                    _plantilla.Plantillas_Estrategias.Remove(sel);

                    this.RadGridViewEstrategias.ItemsSource = null;
                    this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias;
                    //((RadComboBox)sender).SelectedValue = ((RadComboBox)sender).EmptyText;
                }
                //_plantilla.Plantillas_Estrategias.Remove(estrat);
                //this.RadGridViewEstrategias.ItemsSource = _plantilla.Plantillas_Estrategias;

                
            }                        
        }
    }
}
