using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.DataModels;
using System.Text.RegularExpressions;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditParamIndicePreconfiguradoNovarex.xaml
    /// </summary>
    public partial class AddEditParamIndicePreconfiguradoNovarex : MetroWindow
    {

        //public string Isin;
        public string Descripcion;

        public bool Cancel = true;

        public int _noOfErrorsOnScreen = 0;
        //  private AddEditParamEvolucionMercadosValidation _addeditmaster = new AddEditParamEvolucionMercadosValidation();

        public Parametros_IndicePreconfiguradoNovarex parametros = new Parametros_IndicePreconfiguradoNovarex();

        public AddEditParamIndicePreconfiguradoNovarex()
        {
            InitializeComponent();
            this.lblTipoActivo.Visibility = Visibility.Collapsed;
            this.CbTipoActivo.Visibility = Visibility.Collapsed;
            this.lblZonaGeografica.Visibility = Visibility.Collapsed;
            this.CbZonaGeografica.Visibility = Visibility.Collapsed;
            this.lblDivisa.Visibility = Visibility.Collapsed;
            this.CblblDivisa.Visibility = Visibility.Collapsed;
            this.lblCuenta.Visibility = Visibility.Collapsed;
            this.txtBoxCuenta.Visibility = Visibility.Collapsed;
            cargarSugerenciasDescripcion();
        }

        /// <summary>
        /// 
        /// </summary>
        private void cargarSugerenciasDescripcion()
        {     
            var lista = new List<string> {
                "TOTAL RENTA VARIABLE ESPAÑOLA",
                "TOTAL RENTA VARIABLE RESTO ZONA EURO",
                "TOTAL RENTA VARIABLE SUIZA",
                "TOTAL RENTA VARIABLE EEUU",
                "TOTAL RENTA VARIABLE JAPÓN",
                "TOTAL RENTA VARIABLE SUIZA",
                "TOTAL RENTA VARIABLE EMERGENTES",
                "TOTAL RETORNO ABSOLUTO",
                "TOTAL RENTA FIJA DOLAR USA",
                "TOTAL RENTA FIJA EURO",
                "TESORERÍA USD"};

            CbDescripcion.IsDropDownOpen = true;
            CbDescripcion.IsEditable = true;
            CbDescripcion.ItemsSource = lista;
        }

        public AddEditParamIndicePreconfiguradoNovarex(Parametros_IndicePreconfiguradoNovarex param, List<string> listacodigo)
        {
           
            Descripcion = param.Descripcion;
            InitializeComponent();
            cargarSugerenciasDescripcion();

            this.lblTipoActivo.Visibility = Visibility.Collapsed;
            this.CbTipoActivo.Visibility = Visibility.Collapsed;
            this.lblZonaGeografica.Visibility = Visibility.Collapsed;
            this.CbZonaGeografica.Visibility = Visibility.Collapsed;
            this.lblDivisa.Visibility = Visibility.Collapsed;
            this.CblblDivisa.Visibility = Visibility.Collapsed;
            this.lblCuenta.Visibility = Visibility.Collapsed;
            this.txtBoxCuenta.Visibility = Visibility.Collapsed;
            parametros = param;
            Loaded += OnLoaded;

            if(parametros.IdIndicesPreconfiguradosNovarex!=null)
            {
                //Estamos en un Indice Fijo Solo editable Descripcion e Indice Referencia
                this.CblblDivisa.IsEnabled = false;
                this.CbTipoActivo.IsEnabled = false;
                this.CbTipoformula.IsEnabled = false;
                this.CbZonaGeografica.IsEnabled = false;

            }
            //grid.DataContext = _addeditmaster;

            //_addeditmaster.ListaCodigo = listacodigo;
            //_addeditmaster.Isin = isin;
            //_addeditmaster.Descripcion = descripcion;

            //if (string.IsNullOrEmpty(Isin)) textBoxIsin.Focus();
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
            if (parametros != null)
            {
                if (parametros.Descripcion != null) CbDescripcion.Text = parametros.Descripcion.ToString();
                //if (parametros.IdTipoFormula != null)
                    CbTipoformula.SelectedValue = parametros.IdTipoFormula;
                if (parametros.IndiceReferencia != null) txtBoxIndiceReferencia.Text = parametros.IndiceReferencia;
                if (parametros.IdInstrumento != null) CbTipoActivo.SelectedValue = parametros.IdInstrumento;
                if (parametros.IdInstrumentoZona != null) CbZonaGeografica.SelectedValue = parametros.IdInstrumentoZona.Value;
                //if (parametros.Divisa != null)
                //{
                //    var divisas = Reports_IICs.ViewModels.Instrumentos.VM_Instrumentos.GetDivisas();
                //    var diviselected = divisas.Where(c => c.Descripcion == parametros.Divisa).FirstOrDefault();
                //    if(diviselected !=null) CblblDivisa.SelectedValue = diviselected.Codigo;

                //}

                if (parametros.Divisa != null) CblblDivisa.SelectedValue = parametros.Divisa;
                if (parametros.Formula != null) txtBoxCuenta.Text = parametros.Formula.ToString();

            }

            Loaded -= OnLoaded;
        }

        private void AddElement_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (this.CbTipoformula.SelectedValue!=null && this.CbTipoformula.SelectedValue.ToString() == "1")
            {
                if (this.CblblDivisa.SelectedValue == null && this.CbTipoActivo.SelectedValue==null && this.CbZonaGeografica.SelectedValue == null)
                    {
                    _noOfErrorsOnScreen = 0;
                    _noOfErrorsOnScreen = _noOfErrorsOnScreen + 1;
                    }
                else
                {
                    _noOfErrorsOnScreen = 0;
                }
            }

            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;

           
        }


        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
           // Isin = this.textBoxIsin.Text;
            Descripcion = this.CbDescripcion.Text;
            //_addeditmaster = new AddEditParamEvolucionMercadosValidation();
            //grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }


        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);
        }

        private void CbTipoformula_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                var p = e.AddedItems[0] as Reports_IICs.DataModels.Formulas_Tipos;


                if (p.Id == 1)
                {
                    this.lblTipoActivo.Visibility = Visibility.Visible;
                    this.CbTipoActivo.Visibility = Visibility.Visible;
                    this.lblZonaGeografica.Visibility = Visibility.Visible;
                    this.CbZonaGeografica.Visibility = Visibility.Visible;
                    this.lblDivisa.Visibility = Visibility.Visible;
                    this.CblblDivisa.Visibility = Visibility.Visible;
                    this.lblCuenta.Visibility = Visibility.Collapsed;
                    this.txtBoxCuenta.Visibility = Visibility.Collapsed;
                    this.txtBoxCuenta.Text = "";
                }
                else
                {
                    this.lblTipoActivo.Visibility = Visibility.Collapsed;
                    this.CbTipoActivo.Visibility = Visibility.Collapsed;
                    this.CbTipoActivo.SelectedIndex = -1;
                    this.lblZonaGeografica.Visibility = Visibility.Collapsed;
                    this.CbZonaGeografica.Visibility = Visibility.Collapsed;
                    this.CbZonaGeografica.SelectedIndex = -1;
                    this.lblDivisa.Visibility = Visibility.Collapsed;
                    this.CblblDivisa.Visibility = Visibility.Collapsed;
                    this.CblblDivisa.SelectedIndex = -1;
                    this.lblCuenta.Visibility = Visibility.Visible;
                    this.txtBoxCuenta.Visibility = Visibility.Visible;
                }

            }

        }

        private void textBoxFormula_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = new AddEditFormula();
            window.Formula = txtBoxCuenta.Text;

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

                    //parametrosDistriPatriNovarex.Remove(param_DistriPatriNovarex);

                    //Parametros_DistribucionPatrimonioNovarex temp_item = new Parametros_DistribucionPatrimonioNovarex();
                    //temp_item.Formula = window.Formula;
                    //temp_item.Descripcion = window.Descripcion;
                    //parametrosDistriPatriNovarex.Add(temp_item);
                    //this.myDistriPatrimNovarexGrid.ItemsSource = null;
                    //this.myDistriPatrimNovarexGrid.ItemsSource = parametrosDistriPatriNovarex;
                    txtBoxCuenta.Text = window.Formula;
                    #endregion
                }
            }
        }

    }
}
