using Reports_IICs.DataModels;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para Param_VariacionPatrimonialB.xaml
    /// </summary>
    public partial class Param_VariacionPatrimonialB : UserControl
    {
        public Parametros_VariacionPatrimonialB parametros;
        public int _noOfErrorsOnScreen = 0;
        public Plantilla _plantilla;

        // private Param_EvolucionPatrimGuissonaValidation _addeditmaster = new Param_EvolucionPatrimGuissonaValidation();


        public Param_VariacionPatrimonialB(Plantilla plantilla)
        {
            InitializeComponent();
            _plantilla = plantilla;
            lblComisionFijaPagada.Visibility = Visibility.Hidden;
            txtBoxComisionFijaPagada.Visibility = Visibility.Hidden;
        }

        public Param_VariacionPatrimonialB(Parametros_VariacionPatrimonialB param, Plantilla plantilla)
        {
            InitializeComponent();
            _plantilla = plantilla;
            lblComisionFijaPagada.Visibility = Visibility.Hidden;
            txtBoxComisionFijaPagada.Visibility = Visibility.Hidden;
            parametros = param;
            Loaded += OnLoaded;

            //grid.DataContext = _addeditmaster;
            //if (param != null)
            //{
            //    _addeditmaster.TasaGestionAnual = param.TasaGestionAnual;
            //    _addeditmaster.ComisionDepositaria = param.ComisionDepositaria;
            //}
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
            if (parametros != null && parametros.ComisionFijaPagada != null)
            {
                lblComisionFijaPagada.Visibility = Visibility.Visible;
                txtBoxComisionFijaPagada.Visibility = Visibility.Visible;
                if (parametros.ComisionFijaPagada != null) CBShowComiFijaPagada.IsChecked = true;
                txtBoxComisionFijaPagada.Text = parametros.ComisionFijaPagada.ToString();
               
            }
           
            Loaded -= OnLoaded;
        }

        //private void ShowComiFijaPagada_Checked(object sender, RoutedEventArgs e)
        //{
        //    if(CBShowComiFijaPagada.IsChecked.Value == true)
        //    {
        //        lblComisionFijaPagada.Visibility = Visibility.Visible;
        //        txtBoxComisionFijaPagada.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        lblComisionFijaPagada.Visibility = Visibility.Hidden;
        //        txtBoxComisionFijaPagada.Visibility = Visibility.Hidden;
        //        parametros.ComisionFijaPagada = 0;
        //        txtBoxComisionFijaPagada.Text = "";
        //    }
            
        //}

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);            
        }

        //private void ShowComiFijaPagada_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    /*
        //    if (CBShowComiFijaPagada.IsChecked.Value == true)
        //    {
        //        ShowComision = true;
        //        lblComisionFijaPagada.Visibility = Visibility.Visible;
        //        txtBoxComisionFijaPagada.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        ShowComision = false;
        //        lblComisionFijaPagada.Visibility = Visibility.Hidden;
        //        txtBoxComisionFijaPagada.Visibility = Visibility.Hidden;
        //        parametros.ComisionFijaPagada = 0;
        //        txtBoxComisionFijaPagada.Text = "";
        //    }*/

        //}

        private void CBShowComiFijaPagada_Changed(object sender, RoutedEventArgs e)
        {
            if (CBShowComiFijaPagada.IsChecked.Value == true)
            {
                lblComisionFijaPagada.Visibility = Visibility.Visible;
                txtBoxComisionFijaPagada.Visibility = Visibility.Visible;
            }
            else
            {
                lblComisionFijaPagada.Visibility = Visibility.Hidden;
                txtBoxComisionFijaPagada.Visibility = Visibility.Hidden;
                //parametros.ComisionFijaPagada = 0;
                txtBoxComisionFijaPagada.Text = "";
            }

            actualizarParamPlantilla();
        }

        private void actualizarParamPlantilla()
        {
            _plantilla.Parametros_VariacionPatrimonialB.Clear();

            if (CBShowComiFijaPagada.IsChecked.Value == true && !string.IsNullOrEmpty(txtBoxComisionFijaPagada.Text))
            {
                var param = new Parametros_VariacionPatrimonialB();
                param.ComisionFijaPagada = Convert.ToDecimal(txtBoxComisionFijaPagada.Text);
                //param.CodigoIC = _plantilla.CodigoIc;
                
                _plantilla.Parametros_VariacionPatrimonialB.Add(param);
            }
        }

        private void txtBoxComisionFijaPagada_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualizarParamPlantilla();
        }
    }
}
