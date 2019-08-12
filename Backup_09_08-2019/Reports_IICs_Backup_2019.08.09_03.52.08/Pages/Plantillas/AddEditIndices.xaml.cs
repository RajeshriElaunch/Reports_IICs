using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;


namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para AddEditIndices.xaml
    /// </summary>
    public partial class AddEditIndices : MetroWindow
    {
        public string Codigo;
        public string Descripcion;
        public int? Tipo;
        private int _noOfErrorsOnScreen = 0;
        private AddEditIndicesValidation _addeditmaster = new AddEditIndicesValidation();

        public bool Cancel = true;

        public AddEditIndices(string codigo, string descripcion, int? tipo,List<string> listacodigo)
        {
            InitializeComponent();
            Codigo = codigo;
            Descripcion = descripcion;
            Tipo = tipo;
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            //_addeditmaster.plantilla = plantilla;
            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Codigo = codigo;

            if (string.IsNullOrEmpty(Codigo)) textBoxCodigo.Focus();
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

            Codigo = this.textBoxCodigo.Text;
            Descripcion = this.textBoxDescription.Text;
            if(this.ComboBoxTipo.SelectedValue!=null) Tipo = (int)this.ComboBoxTipo.SelectedValue;
            _addeditmaster = new AddEditIndicesValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();
            if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();
            if (Tipo != null)
            {
                ComboBoxTipo.SelectedValue = Tipo;
            }
            else
            {
                //Valor por Defecto Benchmark
                ComboBoxTipo.SelectedValue = 1;

            }
            Loaded -= OnLoaded;
        }


        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Codigo = this.textBoxCodigo.Text;
            Descripcion = this.textBoxDescription.Text;
            if(this.ComboBoxTipo.SelectedValue!=null) Tipo = (int)this.ComboBoxTipo.SelectedValue;
            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void ComboBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = !Cancel;
        }
    }
}
