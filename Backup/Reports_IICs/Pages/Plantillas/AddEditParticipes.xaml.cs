using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para AddEditParticipes.xaml
    /// </summary>
    public partial class AddEditParticipes : MetroWindow
    {
        public string NIFNIE;
        public string NombreYapellidos;
        public string Tipo;
        public string Codigo;

        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditParticipesValidation _addeditmaster = new AddEditParticipesValidation();

        public AddEditParticipes(string nifnie, string nombreyapellidos, string tipoCuenta, string codigoCuenta,List<string> listacodigo)
        {
            NIFNIE = nifnie;
            NombreYapellidos = nombreyapellidos;
            Tipo = tipoCuenta;
            Codigo = codigoCuenta;
            NombreYapellidos = nombreyapellidos;
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            //_addeditmaster.plantilla = plantilla;
            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Codigo = nifnie;
            
            if (string.IsNullOrEmpty(NIFNIE)) textBoxNifNie.Focus();
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
            NIFNIE = this.textBoxNifNie.Text;
            NombreYapellidos = this.textBoxNombreYApellidos.Text;
            Tipo = this.textBoxTipo.Text;
            Codigo = this.textBoxCodigo.Text;
            _addeditmaster = new AddEditParticipesValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (NIFNIE != null) textBoxNifNie.Text  = NIFNIE.ToString();
            if (NombreYapellidos != null) textBoxNombreYApellidos.Text = NombreYapellidos.ToString();
            if (Tipo != null) textBoxTipo.Text = Tipo.ToString();
            if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();

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
            //Tiene que rellenar obligatoriamente el NIF o los datos de la cuenta (tipo y código)
            if (!string.IsNullOrEmpty(this.textBoxNifNie.Text) ||
                (!string.IsNullOrEmpty(this.textBoxTipo.Text) && !string.IsNullOrEmpty(this.textBoxCodigo.Text))
                )
            {
                NIFNIE = this.textBoxNifNie.Text;
                NombreYapellidos = this.textBoxNombreYApellidos.Text;
                Tipo = this.textBoxTipo.Text;
                Codigo = this.textBoxCodigo.Text;
                Cancel = false;
                this.Close();
            }
            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = !Cancel;
        }
    }
}
