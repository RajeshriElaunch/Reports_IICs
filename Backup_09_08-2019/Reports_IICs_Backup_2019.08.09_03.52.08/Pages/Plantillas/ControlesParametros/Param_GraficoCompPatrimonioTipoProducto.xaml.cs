using Reports_IICs.DataModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Interaction logic for Param_GraficoCompPatrimonioTipoProducto.xaml
    /// </summary>
    public partial class Param_GraficoCompPatrimonioTipoProducto : UserControl
    {
        public Parametros_GraficoCompPatrimonioTipoProducto parametros;
        public int _noOfErrorsOnScreen = 0;
        //private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();
        public bool Cancel = true;
        public Param_GraficoCompPatrimonioTipoProducto()
        {
            InitializeComponent();
        }

        public Param_GraficoCompPatrimonioTipoProducto(Parametros_GraficoCompPatrimonioTipoProducto param)
        {
            InitializeComponent();
            parametros = param;
            Loaded += OnLoaded;

            //grid.DataContext = _addeditmaster;
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            
            if (TxtPorcEstrategiasRA.Number != null)
            {
                parametros.PorcEstrategiasRA = Convert.ToDecimal(TxtPorcEstrategiasRA.Number);
            }
            
            e.Handled = true;
            // this.Close();
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
            if (parametros != null) TxtPorcEstrategiasRA.Text = parametros.PorcEstrategiasRA.ToString();

            Loaded -= OnLoaded;
        }
    }
}
