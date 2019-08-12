using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Secciones
{
    /// <summary>
    /// Lógica de interacción para AddEditSeccion.xaml
    /// </summary>
   
    public partial class AddEditSeccion : MetroWindow
    {
        private int _noOfErrorsOnScreen = 0;
        private AddEditSeccionValidation _addeditmaster = new AddEditSeccionValidation();

        //public string Codigo;
        public string Descripcion;
        public List<string> ListaCodigo = new List<string>();
        public int IdCategoria;

        public bool Cancel = true;
        public AddEditSeccion(string descripcion, int idcategoria)
        {
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            _addeditmaster.Descripcion = descripcion;
            IdCategoria = idcategoria;
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
            AddEditSeccionValidation cust = grid.DataContext as AddEditSeccionValidation;

            //Codigo = this.textBoxCodigo.Text;
            Descripcion = this.textBoxDescription.Text;
            if (comboBox_Category.Visibility == Visibility.Visible) IdCategoria = (int)this.comboBox_Category.SelectedValue;
            Cancel = false;


            _addeditmaster = new AddEditSeccionValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            //if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();
            if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();
            if(comboBox_Category.Visibility == Visibility.Visible) comboBox_Category.SelectedValue = IdCategoria;
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
