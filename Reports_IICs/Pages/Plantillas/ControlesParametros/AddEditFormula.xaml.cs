using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditFormula.xaml
    /// </summary>
    public partial class AddEditFormula : MetroWindow
    {
        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditEvolucionRentabGuissona_FondosValidation _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();
        private List<string> TipoValor = new List<string>();
        public string Formula;

        public AddEditFormula()
        {
            InitializeComponent();
            TipoValor.Add("FIJO");
            TipoValor.Add("CUENTA");

            cb_ValueType.ItemsSource = TipoValor;
            cb_ValueType.SelectedIndex = 0;
            Loaded += OnLoaded;
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
            
            Formula = this.textBoxFormula.Text;
            _addeditmaster = new AddEditEvolucionRentabGuissona_FondosValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            
            if (Formula != null) textBoxFormula.Text = Formula.ToString();

            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void btn_suma_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + "+";
        }

        private void btn_resta_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + "-";
        }

        private void btn_multi_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + "*";
        }

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        private void btn_dividir_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + "/";
        }

        private void btn_AbreParantesis_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + "(";
        }

        private void btn_CierrarParentesis_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = textBoxFormula.Text + ")";
        }

        private void btn_Undo_Click(object sender, RoutedEventArgs e)
        {
          if(textBoxFormula.Text.Length>0)   textBoxFormula.Text = textBoxFormula.Text.Substring(0, textBoxFormula.Text.Length - 1);
           
        }

        private void btn_addValue_Click(object sender, RoutedEventArgs e)
        {
            if(cb_ValueType.SelectedValue.ToString() == "FIJO") textBoxFormula.Text = textBoxFormula.Text + txtValue.Text;
            if(cb_ValueType.SelectedValue.ToString() == "CUENTA") textBoxFormula.Text = textBoxFormula.Text + "[" + txtValue.Text + "]";
        }
    }
}
