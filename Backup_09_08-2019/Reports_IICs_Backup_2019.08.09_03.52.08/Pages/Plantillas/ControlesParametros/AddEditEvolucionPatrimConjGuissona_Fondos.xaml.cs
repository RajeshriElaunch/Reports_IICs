using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditEvolucionPatrimConjGuissona_Fondos.xaml
    /// </summary>
    public partial class AddEditEvolucionPatrimConjGuissona_Fondos : MetroWindow
    {

        public string CodigoIC;
        public string CodigoICFondo;
        public string IsinFondo;
        public string Descripcion;
        public DateTime FechaConstitucion;
        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditEvolucionRentabGuissona_FondosValidation _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();

        public AddEditEvolucionPatrimConjGuissona_Fondos(string codigoIC, string codigoICFondo, string descripcion, List<string> listacodigo, DateTime fechaConstitucion,string isinFondo)
        {
            CodigoIC = codigoIC;
            CodigoICFondo = codigoICFondo;
            Descripcion = descripcion;
            IsinFondo = isinFondo;
            FechaConstitucion = fechaConstitucion;
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;

            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.IsinFondo = isinFondo;
            _addeditmaster.Descripcion = descripcion;
            if (string.IsNullOrEmpty(CodigoICFondo)) textBoxCodigoICFondo.Focus();
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
            CodigoICFondo = this.textBoxCodigoICFondo.Text;
            IsinFondo = this.textBoxIsinFondo.Text;
            Descripcion = this.textBoxDescripcion.Text;
            FechaConstitucion = DpFechaConstitucion.SelectedDate.Value;
            _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (CodigoICFondo != null) textBoxCodigoICFondo.Text = CodigoICFondo.ToString();
            if (IsinFondo != null) this.textBoxIsinFondo.Text = IsinFondo.ToString();
            if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();
            if (DpFechaConstitucion.SelectedDate != null) DpFechaConstitucion.SelectedDate = FechaConstitucion;
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
