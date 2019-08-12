using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.DataModels;
using System.Text.RegularExpressions;
using System;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_CompraVentaPrecAdq.xaml
    /// </summary>
    public partial class Param_CompraVentaPrecAdq : UserControl
    {
        public Parametros_CompraVentaPrecAdq parametros;
        public int _noOfErrorsOnScreen = 0;
        private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();
        public bool Cancel = true;

        public Param_CompraVentaPrecAdq()
        {
            InitializeComponent();
        }

        public Param_CompraVentaPrecAdq(Parametros_CompraVentaPrecAdq param)
        {
            InitializeComponent();
            parametros = param;
            Loaded += OnLoaded;

            grid.DataContext = _addeditmaster;
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            parametros.EfectivoMinimo = Convert.ToDecimal(this.TxtEfectivoMinimo.Text);
            _addeditmaster = new Param_GraficoBenchMarkValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
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
            if (parametros != null) TxtEfectivoMinimo.Text = parametros.EfectivoMinimo.ToString();


            Loaded -= OnLoaded;
        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

    }
}
