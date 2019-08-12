using Reports_IICs.DataModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Interaction logic for Param_OperacionesRentaVariable_II.xaml
    /// </summary>
    public partial class Param_OperacionesRentaVariable_II : UserControl
    {
        public Parametros_OperacionesRentaVariable_II parametros;
        public int _noOfErrorsOnScreen = 0;
        //private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();
        public bool Cancel = true;
        public Param_OperacionesRentaVariable_II()
        {
            InitializeComponent();
        }

        public Param_OperacionesRentaVariable_II(Parametros_OperacionesRentaVariable_II param)
        {
            InitializeComponent();
            parametros = param;
            Loaded += OnLoaded;

            //grid.DataContext = _addeditmaster;
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            //parametros.Descripcion = this.txtBoxDescripcion.Text;
            parametros.FechaUltimoInforme = this.DpFechaUltimaReunion.SelectedDate.Value;
            decimal? efectMin = null;
            if (!string.IsNullOrEmpty(TxtEfectivoMinimo.Text))
            {
                efectMin = Convert.ToDecimal(TxtEfectivoMinimo);
            }
            parametros.EfectivoMinimo = efectMin;
            //_addeditmaster = new Param_GraficoBenchMarkValidation();
            //grid.DataContext = _addeditmaster;
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
            //if (parametros != null && parametros.Indice != null) txtBoxIndice.Text = parametros.Indice;
            
            if (parametros != null && parametros.FechaUltimoInforme!= null) DpFechaUltimaReunion.Text = parametros.FechaUltimoInforme.ToString();
            if (parametros != null && parametros.EfectivoMinimo != null) TxtEfectivoMinimo.Text = parametros.EfectivoMinimo.ToString();

            Loaded -= OnLoaded;
        }
    }
}
