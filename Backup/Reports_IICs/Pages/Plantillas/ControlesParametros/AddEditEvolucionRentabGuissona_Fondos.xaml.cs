using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditEvolucionRentabGuissona_Fondos.xaml
    /// </summary>
    public partial class AddEditEvolucionRentabGuissona_Fondos : MetroWindow
    {
        public string CodigoIC;
        public string CodigoICFondo;
        public string IsinFondo;
        public string Descripcion;
        public decimal ReferenciaTAE;
        public DateTime FechaConstitucion;
        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditEvolucionRentabGuissona_FondosValidation _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();


        public AddEditEvolucionRentabGuissona_Fondos(string codigoIC, string codigoICFondo, string descripcion, List<string> listacodigo, DateTime fechaConstitucion, string isinFondo, decimal referenciaTAE)
        {
            CodigoIC= codigoIC;
            CodigoICFondo = codigoICFondo;
            Descripcion = descripcion;
            FechaConstitucion = fechaConstitucion;
            ReferenciaTAE = referenciaTAE;
            IsinFondo = isinFondo;
            InitializeComponent();
           
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;

            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.IsinFondo = isinFondo;
            _addeditmaster.Descripcion = descripcion;
           
            if (string.IsNullOrEmpty(CodigoICFondo)) textBoxCodigoFondo.Focus();
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

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            CodigoICFondo = this.textBoxCodigoFondo.Text;
            Descripcion = this.textBoxDescripcion.Text;
            FechaConstitucion = DpFechaConstitucion.SelectedDate.Value;
            IsinFondo = this.textBoxIsinFondo.Text.Trim();
            ReferenciaTAE = Convert.ToDecimal(this.textBoxReferenciaTAE.Text);

            _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            
            if (CodigoICFondo != null) textBoxCodigoFondo.Text  = CodigoICFondo.ToString();
            if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();
            if (DpFechaConstitucion.SelectedDate!= null) DpFechaConstitucion.SelectedDate = FechaConstitucion;
            if (IsinFondo != null) textBoxIsinFondo.Text = IsinFondo.ToString();
            textBoxReferenciaTAE.Text = ReferenciaTAE.ToString();


            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

    }
}
