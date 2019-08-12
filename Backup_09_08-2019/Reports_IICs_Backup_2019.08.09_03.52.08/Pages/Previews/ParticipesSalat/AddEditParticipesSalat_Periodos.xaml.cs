using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Secciones;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para AddEditParticipesSalat_Periodos.xaml
    /// </summary>
    public partial class AddEditParticipesSalat_Periodos : MetroWindow
    {
        public ParticipesSalat_Periodos_Lineas Param_Linea;
        //public string Titular;

        //public DateTime Fecha;
        public bool Cancel = true;
        private bool first = false;
        private int _noOfErrorsOnScreen = 0;

        private int _idPeriodo = 0;
        public decimal? ImporteInvertido;
        public decimal Valor;
        public decimal? Saldo;
        public decimal Resultado;
        private DateTime _fechaFinPeriodo;

        public AddEditParticipesSalat_Periodos()
        {
            InitializeComponent();
        }

        public AddEditParticipesSalat_Periodos(int idPeriodo, ParticipesSalat_Periodos_Lineas param,bool First, DateTime fechaFinPeriodo)
        {
            _idPeriodo = idPeriodo;
            Param_Linea = param;
            _fechaFinPeriodo = fechaFinPeriodo;

            InitializeComponent();
            Loaded += OnLoaded;
            first = First;

            if (first)
            {
                /*
                 //textBoxTitular.Visibility = Visibility.Collapsed;
                 labelImporteInvEnSiCav.Visibility = Visibility.Visible;
                 textBoxImporteInvEnSiCav.Visibility = Visibility.Visible;
                 RowImporteInvertidoEnSicav.Height = GridLength.Auto;
                 labelImporteInvEnSiCav.Height = 26;
                 textBoxImporteInvEnSiCav.Height = 26;

                 labelValorEnSiCav.Visibility = Visibility.Visible;
                 txtBoxValorEnSiCav.Visibility = Visibility.Visible;
                 RowValorEnSicav.Height = GridLength.Auto;
                 labelValorEnSiCav.Height = 26;
                 txtBoxValorEnSiCav.Height = 26;

                 RowValorSicavEfectivo.Height = new GridLength(0);

                 labelAportacionesNetasRealizadas.Visibility = Visibility.Collapsed;
                 txtBoxAportacionesNetasRealizadas.Visibility = Visibility.Collapsed;
                 RowAportacionesNetasRealizadas.Height = new GridLength(0);
                 labelAportacionesNetasRealizadas.Height = 0;
                 txtBoxAportacionesNetasRealizadas.Height = 0;

                 labelSaldoEfectivo.Visibility = Visibility.Visible;
                 txtBoxSaldoEfectivo.Visibility = Visibility.Visible;
                 */
                labelImporteInvEnSiCav.Visibility = Visibility.Visible;
                textBoxImporteInvEnSiCav.Visibility = Visibility.Visible;
                RowImporteInvertidoEnSicav.Height = GridLength.Auto;
                labelImporteInvEnSiCav.Height = 26;
                textBoxImporteInvEnSiCav.Height = 26;

                labelValorEnSiCav.Visibility = Visibility.Visible;
                txtBoxValorEnSiCav.Visibility = Visibility.Visible;
                RowValorEnSicav.Height = GridLength.Auto;
                labelValorEnSiCav.Height = 26;
                txtBoxValorEnSiCav.Height = 26;

                RowValorSicavEfectivo.Height = GridLength.Auto;

                labelAportacionesNetasRealizadas.Visibility = Visibility.Collapsed;
                txtBoxAportacionesNetasRealizadas.Visibility = Visibility.Collapsed;
                //RowAportacionesNetasRealizadas.Height = new GridLength(0);
                labelAportacionesNetasRealizadas.Height = 0;
                txtBoxAportacionesNetasRealizadas.Height = 0;

                labelSaldoEfectivo.Visibility = Visibility.Visible;
                txtBoxSaldoEfectivo.Visibility = Visibility.Visible;
            }
            else
            {
                labelImporteInvEnSiCav.Visibility = Visibility.Collapsed;
                textBoxImporteInvEnSiCav.Visibility = Visibility.Collapsed;
                RowImporteInvertidoEnSicav.Height = new GridLength(0);
                labelImporteInvEnSiCav.Height = 0;
                textBoxImporteInvEnSiCav.Height = 0;

                labelValorEnSiCav.Visibility = Visibility.Visible;
                txtBoxValorEnSiCav.Visibility = Visibility.Visible;
                RowValorEnSicav.Height = GridLength.Auto;
                labelValorEnSiCav.Height = 26;
                txtBoxValorEnSiCav.Height = 26;

                RowValorSicavEfectivo.Height = GridLength.Auto;

                labelAportacionesNetasRealizadas.Visibility = Visibility.Visible;
                txtBoxAportacionesNetasRealizadas.Visibility = Visibility.Visible;
                RowAportacionesNetasRealizadas.Height = GridLength.Auto;
                labelAportacionesNetasRealizadas.Height = 26;
                txtBoxAportacionesNetasRealizadas.Height = 26;

                labelSaldoEfectivo.Visibility = Visibility.Visible;
                txtBoxSaldoEfectivo.Visibility = Visibility.Visible;
            }

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

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Param_Linea
            Cancel = false;

            //Param_Linea.Titular = textBoxTitular.Text;
            if (this.ComboBoxTitular.SelectedValue != null)
            {
                Param_Linea.IdParametroParticipeSalat = (int)this.ComboBoxTitular.SelectedValue;
                Param_Linea.IdParticipesSalatPeriodo = _idPeriodo;
                Param_Linea.IdTitular = ((Reports_IICs.DataModels.ParticipesSalat_Participes)ComboBoxTitular.SelectedItem).Id;
                Param_Linea.Titular = ((Reports_IICs.DataModels.ParticipesSalat_Participes)ComboBoxTitular.SelectedItem).NombreApellidos;
            }
            //Param_Linea.IdentificadorTitular = textBoxTitularIdentificador.Text;

            if (first)
            {
                decimal impInv = (string.IsNullOrEmpty(textBoxImporteInvEnSiCav.Text)) ? 0 : Convert.ToDecimal(textBoxImporteInvEnSiCav.Text);
                Param_Linea.ImporteInvertido = impInv;
                decimal valor = (string.IsNullOrEmpty(txtBoxValorEnSiCav.Text)) ? 0 : Convert.ToDecimal(txtBoxValorEnSiCav.Text);
                Param_Linea.Valor = valor;
                //Param_Linea.ValorMasEfectPeriodoAnt = (string.IsNullOrEmpty(txtBoxValorEnSiCavEfectivo.Text)) ? 0 : Convert.ToDecimal(txtBoxValorEnSiCavEfectivo.Text);

                decimal valMasEfec = ParticipesSalat_DA.Get_ValorSicavMasEfec_PeriodAnt(_fechaFinPeriodo, Convert.ToInt32(Param_Linea.IdParametroParticipeSalat));
                Param_Linea.ValorMasEfectPeriodoAnt = valMasEfec;

                // Param_Linea.ValorMasEfectPeriodoAnt = Convert.ToDecimal(txtBoxValorEnSicav.Text);
                decimal saldo = (string.IsNullOrEmpty(txtBoxSaldoEfectivo.Text)) ? 0 : Convert.ToDecimal(txtBoxSaldoEfectivo.Text);
                Param_Linea.Saldo = saldo;

                //Param_Linea.Resultado = (string.IsNullOrEmpty(txtBoxResultado.Text)) ? 0 : Convert.ToDecimal(txtBoxResultado.Text);
                Param_Linea.Resultado = valor - impInv;

            }
            else
            {
                decimal impInv = (string.IsNullOrEmpty(txtBoxAportacionesNetasRealizadas.Text)) ? 0 : Convert.ToDecimal(txtBoxAportacionesNetasRealizadas.Text);
                Param_Linea.ImporteInvertido = impInv;
                decimal valor = (string.IsNullOrEmpty(txtBoxValorEnSiCav.Text)) ? 0 : Convert.ToDecimal(txtBoxValorEnSiCav.Text);
                Param_Linea.Valor = valor;

                decimal valMasEfec = ParticipesSalat_DA.Get_ValorSicavMasEfec_PeriodAnt(_fechaFinPeriodo, Convert.ToInt32(Param_Linea.IdParametroParticipeSalat));
                Param_Linea.ValorMasEfectPeriodoAnt = valMasEfec;

                decimal saldo = (string.IsNullOrEmpty(txtBoxSaldoEfectivo.Text)) ? 0 : Convert.ToDecimal(txtBoxSaldoEfectivo.Text);
                Param_Linea.Saldo = saldo;

                //Param_Linea.Resultado = (string.IsNullOrEmpty(txtBoxResultado.Text)) ? 0 : Convert.ToDecimal(txtBoxResultado.Text);
                Param_Linea.Resultado = valor + saldo - valMasEfec - impInv;

            }

            //Guardamos la línea en la DB
            new Reports_IICs.DataAccess.Managers.ParticipesSalat_Periodos_Lineas_MNG().Save(Param_Linea, null);

            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if(Param_Linea!= null)
            {
                //if (Param_Linea.Titular != null) textBoxTitular.Text = Param_Linea.Titular;
                /*******************PONER CORRECTAMENTE LA SIGUIENTE LÍNEA************************/
                if (Param_Linea.IdParametroParticipeSalat != null) ComboBoxTitular.SelectedValue = Param_Linea.IdTitular;
                //if (Param_Linea.IdentificadorTitular != null) textBoxTitular.Text = Param_Linea.IdentificadorTitular;
                textBoxImporteInvEnSiCav.Text = String.Format("{0:N2}", Param_Linea.ImporteInvertido);
                if (first)
                {
                    txtBoxValorEnSiCav.Text = String.Format("{0:N2}", Param_Linea.Valor);
                }
                else
                {
                    txtBoxValorEnSiCav.Text = String.Format("{0:N2}", Param_Linea.Valor);
                    //Compartimos campo
                    //Lo que en el primer y único bloque es "IMPORTE INVERTIDO EN LA SICAV
                    //en los demás periodos es APORTACIONES NETAS REALIZADAS
                    txtBoxAportacionesNetasRealizadas.Text = String.Format("{0:N2}", Param_Linea.ImporteInvertido);
                }
                    
                 txtBoxSaldoEfectivo.Text = String.Format("{0:N2}", Param_Linea.Saldo);

                  ImporteInvertido = Param_Linea.ImporteInvertido;
                  Valor = Param_Linea.Valor;
                  Saldo= Param_Linea.Saldo;
                  Resultado = Param_Linea.Resultado;
            }
           
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
