using Reports_IICs.DataModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_RatiosCarteraRV.xaml
    /// </summary>


    public partial class Param_RatiosCarteraRV : UserControl
    {
        private Parametros_RatiosCarteraRV parametros;
        public int _noOfErrorsOnScreen = 0;
        private Param_RatiosCarteraRVValidation _addeditmaster = new Param_RatiosCarteraRVValidation();
        public Param_RatiosCarteraRV(Parametros_RatiosCarteraRV param)        
        {
            InitializeComponent();            
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;

            //Valores por defecto
            if (param == null)
            {
                param = new Parametros_RatiosCarteraRV();
                param.PorcentajeCarteraMinMostrar = 0;                
                param.BpaAñoInformeMaximo = null;
                param.BpaAñoInformeMinimo = null;
                param.BpaPrevisionMaximo = null;
                param.BpaPrevisionMinimo = null;
                param.DescuentoFundamentalMaximo = null;
                param.DescuentoFundamentalMinimo = -100;
                param.DeudaNetaCapitalizacionMaximo = null;
                param.DeudaNetaCapitalizacionMinimo = null;
                param.PerAñoInformeMaximo = 40;
                param.PerAñoInformeMinimo = 0;
                param.PerPrevisionMaximo = 40;
                param.PerPrevisionMinimo = 0;
                param.PrecioVcMaximo = 10;
                param.PrecioVcMinimo = 0;
                param.RentabilidadesAñoInformeMaximo = 15;
                param.RentabilidadesAñoInformeMinimo = 0;
                param.RentabilidadesPrevisionMaximo = 15;
                param.RentabilidadesPrevisionMinimo = 0;
                param.ValorFundamentalMaximo = null;
                param.ValorFundamentalMinimo = 0;
            }

            parametros = param;

            _addeditmaster.BpaAñoInformeMaximo = param.BpaAñoInformeMaximo.ToString();
            _addeditmaster.BpaAñoInformeMinimo = param.BpaAñoInformeMinimo.ToString();
            _addeditmaster.BpaPrevisionMaximo = param.BpaPrevisionMaximo.ToString();
            _addeditmaster.BpaPrevisionMinimo = param.BpaPrevisionMinimo.ToString();
            _addeditmaster.DescuentoFundamentalMaximo = param.DescuentoFundamentalMaximo.ToString();
            _addeditmaster.DescuentoFundamentalMinimo = param.DescuentoFundamentalMinimo.ToString();
            _addeditmaster.DeudaNetaCapitalizacionMaximo = param.DeudaNetaCapitalizacionMaximo.ToString();
            _addeditmaster.DeudaNetaCapitalizacionMinimo = param.DeudaNetaCapitalizacionMinimo.ToString();
            _addeditmaster.PerAñoInformeMaximo = param.PerAñoInformeMaximo.ToString();
            _addeditmaster.PerAñoInformeMinimo = param.PerAñoInformeMinimo.ToString();
            _addeditmaster.PerPrevisionMaximo = param.PerPrevisionMaximo.ToString();
            _addeditmaster.PerPrevisionMinimo = param.PerPrevisionMinimo.ToString();
            _addeditmaster.PrecioVcMaximo = param.PrecioVcMaximo.ToString();
            _addeditmaster.PrecioVcMinimo = param.PrecioVcMinimo.ToString();
            _addeditmaster.RentabilidadesAñoInformeMaximo = param.RentabilidadesAñoInformeMaximo.ToString();
            _addeditmaster.RentabilidadesAñoInformeMinimo = param.RentabilidadesAñoInformeMinimo.ToString();
            _addeditmaster.RentabilidadesPrevisionMaximo = param.RentabilidadesPrevisionMaximo.ToString();
            _addeditmaster.RentabilidadesPrevisionMinimo = param.RentabilidadesPrevisionMinimo.ToString();
            //_addeditmaster.ValorFundamentalMaximo = param.ValorFundamentalMaximo.ToString();
            _addeditmaster.ValorFundamentalMinimo = param.ValorFundamentalMinimo.ToString();
        }


        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            //Esto sería necesario si quisiéramos que los textobox tuvieran obligatoriamente un valor
            //if (e.Action == ValidationErrorEventAction.Added)
            //    _noOfErrorsOnScreen++;
            //else
            //    _noOfErrorsOnScreen--;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (parametros == null) parametros = new Parametros_RatiosCarteraRV();
            if (parametros.PorcentajeCarteraMinMostrar != null) txtBoxPorcentajeCarteraMinMostrar.Text = parametros.PorcentajeCarteraMinMostrar.ToString();
            //if (parametros.PorcentajeCarteraMaxMostrar != null) txtBoxPorcentajeCarteraMaxMostrar.Text = parametros.PorcentajeCarteraMaxMostrar.ToString();
            if (parametros.BpaAñoInformeMaximo != null) txtBoxBpaAñoInformeMaximo.Text = parametros.BpaAñoInformeMaximo.ToString();
            if (parametros.BpaAñoInformeMinimo != null) txtBoxBpaAñoInformeMinimo.Text = parametros.BpaAñoInformeMinimo.ToString();
            if (parametros.BpaPrevisionMaximo != null) txtBoxBpaPrevisionMaximo.Text = parametros.BpaPrevisionMaximo.ToString();
            if (parametros.BpaPrevisionMinimo != null) txtBoxBpaPrevisionMinimo.Text = parametros.BpaPrevisionMinimo.ToString();
            if (parametros.DescuentoFundamentalMaximo != null) txtBoxDescuentoFundamentalMaximo.Text = parametros.DescuentoFundamentalMaximo.ToString();
            if (parametros.DescuentoFundamentalMinimo != null) txtBoxDescuentoFundamentalMinimo.Text = parametros.DescuentoFundamentalMinimo.ToString();
            if (parametros.DeudaNetaCapitalizacionMaximo != null) txtBoxDeudaNetaCapitalizacionMaximo.Text = parametros.DeudaNetaCapitalizacionMaximo.ToString();
            if (parametros.DeudaNetaCapitalizacionMinimo != null) txtBoxDeudaNetaCapitalizacionMinimo.Text = parametros.DeudaNetaCapitalizacionMinimo.ToString();
            if (parametros.PerAñoInformeMaximo != null) txtBoxPerAñoInformeMaximo.Text = parametros.PerAñoInformeMaximo.ToString();
            if (parametros.PerAñoInformeMinimo != null) txtBoxPerAñoInformeMinimo.Text = parametros.PerAñoInformeMinimo.ToString();
            if (parametros.PerPrevisionMaximo != null) txtBoxPerPrevisionMaximo.Text = parametros.PerPrevisionMaximo.ToString();
            if (parametros.PerPrevisionMinimo != null) txtBoxPerPrevisionMinimo.Text = parametros.PerPrevisionMinimo.ToString();
            if (parametros.PrecioVcMaximo != null) txtBoxPrecioVcMaximo.Text = parametros.PrecioVcMaximo.ToString();
            if (parametros.PrecioVcMinimo != null) txtBoxPrecioVcMinimo.Text = parametros.PrecioVcMinimo.ToString();
            if (parametros.RentabilidadesAñoInformeMaximo != null) txtBoxRentabilidadesAñoInformeMaximo.Text = parametros.RentabilidadesAñoInformeMaximo.ToString();
            if (parametros.RentabilidadesAñoInformeMinimo != null) txtBoxRentabilidadesAñoInformeMinimo.Text = parametros.RentabilidadesAñoInformeMinimo.ToString();
            if (parametros.RentabilidadesPrevisionMaximo != null) txtBoxRentabilidadesPrevisionMaximo.Text = parametros.RentabilidadesPrevisionMaximo.ToString();
            if (parametros.RentabilidadesPrevisionMinimo != null) txtBoxRentabilidadesPrevisionMinimo.Text = parametros.RentabilidadesPrevisionMinimo.ToString();
            //if (parametros.ValorFundamentalMaximo != null) txtBoxValorFundamentalMaximo.Text = parametros.ValorFundamentalMaximo.ToString();
            if (parametros.ValorFundamentalMinimo != null) txtBoxValorFundamentalMinimo.Text = parametros.ValorFundamentalMinimo.ToString();


            Loaded -= OnLoaded;
        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        
    }
}
