using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages
{
    /// <summary>
    /// Lógica de interacción para AddEditMaster.xaml
    /// </summary>
    public partial class AddEditMaster : MetroWindow
    {
        private int _noOfErrorsOnScreen = 0;
        private AddEditMasterValidation _addeditmaster = new AddEditMasterValidation();

        public string Codigo;
        public string Descripcion;
        
       
        public bool Cancel = true;
        public AddEditMaster(string editmode, List<string> ListaCodigo,string codigo,string descripcion)
        {
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            _addeditmaster.Editmode = editmode;
            _addeditmaster.ListaCodigo = ListaCodigo;
            _addeditmaster.Codigo = codigo;
            _addeditmaster.Descripcion = descripcion;
            
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
            AddEditMasterValidation cust = grid.DataContext as AddEditMasterValidation;

            Codigo = this.textBoxCodigo.Text;
            Descripcion = this.textBoxDescription.Text;
            Cancel = false;
            

            _addeditmaster = new AddEditMasterValidation();
            grid.DataContext = _addeditmaster;

            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Codigo != null) textBoxCodigo.Text = Codigo.ToString();
            if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();
            
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
