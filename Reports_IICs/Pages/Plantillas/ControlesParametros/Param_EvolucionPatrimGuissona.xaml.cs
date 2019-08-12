using Reports_IICs.DataModels;
using System.Windows;
using System.Windows.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_EvolucionPatrimGuissona.xaml
    /// </summary>
    public partial class Param_EvolucionPatrimGuissona : UserControl
    {
        private Parametros_EvolucionPatrimGuissona parametros;
        public int _noOfErrorsOnScreen = 0;
        private Param_EvolucionPatrimGuissonaValidation _addeditmaster = new Param_EvolucionPatrimGuissonaValidation();

        public Param_EvolucionPatrimGuissona(Parametros_EvolucionPatrimGuissona param)
        {
            InitializeComponent();
            parametros = param;
            Loaded += OnLoaded;

            grid.DataContext = _addeditmaster;
            if (param != null)
            {
                _addeditmaster.TasaGestionAnual = param.TasaGestionAnual;
                _addeditmaster.ComisionDepositaria = param.ComisionDepositaria;
            }

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
            if (parametros!=null) txtBoxTasaGestionAnual.Text = parametros.TasaGestionAnual.ToString();
            if (parametros !=null) txtBoxComisionDepositaria.Text = parametros.ComisionDepositaria.ToString();
            
            Loaded -= OnLoaded;
        }
    }
}
