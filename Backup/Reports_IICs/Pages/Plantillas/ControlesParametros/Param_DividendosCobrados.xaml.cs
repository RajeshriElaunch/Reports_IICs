﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_DividendosCobrados.xaml
    /// </summary>
    public partial class Param_DividendosCobrados : UserControl
    {
        public Parametros_DividendosCobrados parametros;
        public int _noOfErrorsOnScreen = 0;
        private Param_GraficoBenchMarkValidation _addeditmaster = new Param_GraficoBenchMarkValidation();
        public bool Cancel = true;

        public Param_DividendosCobrados()
        {
            InitializeComponent();
        }

        public Param_DividendosCobrados(Parametros_DividendosCobrados param)
        {
            InitializeComponent();
            parametros = param;
            Loaded += OnLoaded;

            grid.DataContext = _addeditmaster;
            //if (param != null)
            //{
            //    _addeditmaster.Indice = param.Indice;
            //    _addeditmaster.Descripcion = param.Descripcion;
            //}
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            //parametros.Descripcion = this.txtBoxDescripcion.Text;
            //parametros.Indice = this.txtBoxIndice.Text;
            parametros.FechaUltimaReunion = this.DpFechaUltimaReunion.SelectedDate.Value;
            _addeditmaster = new Param_GraficoBenchMarkValidation();
            grid.DataContext = _addeditmaster;
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
            //if (parametros != null && parametros.Descripcion != null) txtBoxDescripcion.Text = parametros.Descripcion;
            if (parametros != null && parametros.FechaUltimaReunion != null) DpFechaUltimaReunion.Text = parametros.FechaUltimaReunion.ToString();


            Loaded -= OnLoaded;
        }

    }
}
