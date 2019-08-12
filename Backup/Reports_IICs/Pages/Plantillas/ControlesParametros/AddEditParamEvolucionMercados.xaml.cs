using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditParamEvolucionMercados.xaml
    /// </summary>
    public partial class AddEditParamEvolucionMercados : MetroWindow
    {
        public string Isin;
        public string Descripcion;

        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditParamEvolucionMercadosValidation _addeditmaster = new AddEditParamEvolucionMercadosValidation();


        public AddEditParamEvolucionMercados(string isin, string descripcion, List<string> listacodigo)
        {
            Isin = isin;
            Descripcion = descripcion;
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            
            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Isin = isin;
            _addeditmaster.Descripcion = descripcion;
            
            if (string.IsNullOrEmpty(Isin)) textBoxIsin.Focus();
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
            Isin = this.textBoxIsin.Text;
            Descripcion = this.textBoxDescripcion.Text;
            _addeditmaster = new AddEditParamEvolucionMercadosValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Isin != null) textBoxIsin.Text = Isin.ToString();
            if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();

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
