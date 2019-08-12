using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para AddEditIsin.xaml
    /// </summary>
    public partial class AddEditIsin : MetroWindow
    {
        public string Isin;
        public string Descripcion;
        public DateTime FechaModificacion;
        private int _noOfErrorsOnScreen = 0;
        private AddEditIsinValidation _addeditmaster = new AddEditIsinValidation();

        public bool Cancel = true;
        public AddEditIsin(string isin, string descripcion, List<string> listacodigo)
        {
            InitializeComponent();
            Isin = isin;
            Descripcion = descripcion;
            FechaModificacion = DateTime.Now;
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;
            //_addeditmaster.plantilla = plantilla;
            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Codigo = isin;
            if (string.IsNullOrEmpty(Isin)) textBoxIsin.Focus();
          
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
            Isin = this.textBoxIsin.Text;
            Descripcion = this.textBoxDescription.Text;
            _addeditmaster = new AddEditIsinValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }
            
        
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Isin != null) textBoxIsin.Text = Isin.ToString();
            if (Descripcion != null) textBoxDescription.Text = Descripcion.ToString();

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
            Isin = this.textBoxIsin.Text;
            Descripcion = this.textBoxDescription.Text;
            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = !Cancel;
        }
    }
}
