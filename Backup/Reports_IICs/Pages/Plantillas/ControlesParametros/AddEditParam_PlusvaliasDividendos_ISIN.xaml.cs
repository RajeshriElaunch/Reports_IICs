using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditParam_PlusvaliasDividendos_ISIN.xaml
    /// </summary>
    public partial class AddEditParam_PlusvaliasDividendos_ISIN : MetroWindow
    {

        public string Isin;

        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        //private AddEditParamEvolucionMercadosValidation _addeditmaster = new AddEditParamEvolucionMercadosValidation();

        public AddEditParam_PlusvaliasDividendos_ISIN(string isin)
        {
            Isin = isin;
            InitializeComponent();
            Loaded += OnLoaded;
            //grid.DataContext = _addeditmaster;

            //_addeditmaster.ListaCodigo = listacodigo;
            //_addeditmaster.Isin = isin;
            //_addeditmaster.Descripcion = descripcion;

            
            if (string.IsNullOrEmpty(Isin)) txtBoxIsin.Focus();

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
            Isin = this.txtBoxIsin.Text;
            //Descripcion = this.textBoxDescripcion.Text;
            //_addeditmaster = new AddEditParamEvolucionMercadosValidation();
            //grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Isin != null) txtBoxIsin.Text = Isin.ToString();
            //if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();

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
