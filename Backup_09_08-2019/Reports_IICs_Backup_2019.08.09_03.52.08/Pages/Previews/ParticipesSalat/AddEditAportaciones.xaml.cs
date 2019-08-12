using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para AddEditAportaciones.xaml
    /// </summary>
    public partial class AddEditAportaciones : MetroWindow
    {
        public string Aportacion;
        public string Titular;
        public int IdParticipe;//este es el Id del Partícipe

        public DateTime Fecha;
        //public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditAportacionesValidation _addeditmaster = new AddEditAportacionesValidation();        

        public AddEditAportaciones()
        {
            InitializeComponent();
            
        }

        public AddEditAportaciones(string aportacion, int? idParticipe, List<string> listacodigo, DateTime fecha)
        {
            Aportacion = aportacion;
            //Titular = titular;
            if(idParticipe != null)
            {
                IdParticipe = Convert.ToInt32(idParticipe);
            }
            
            Fecha = fecha;

            InitializeComponent();
            Loaded += OnLoaded;
            this.textBoxAportacion.Focus();
            grid.DataContext = _addeditmaster;

            //_addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Aportacion = string.IsNullOrEmpty(aportacion)? (decimal?)null : Convert.ToDecimal(aportacion);
            //_addeditmaster.Titular = titular;
            _addeditmaster.IdParametroParticipeSalat = idParticipe;
            //if (string.IsNullOrEmpty(CodigoICFondo)) textBoxCodigoICFondo.Focus();
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
            //Cancel = false;
            DialogResult = true;
            Aportacion = this.textBoxAportacion.Text;
            //Titular = this.textBoxTitular.Text;
            if (this.ComboBoxTitular.SelectedValue != null)
            {
                //Id del partícipe
                IdParticipe = (int)this.ComboBoxTitular.SelectedValue;
                Titular = this.ComboBoxTitular.Text;
                //Titular = ParticipesSalat_DA.GetParametros_ParticipesSalat(IdParametroParticipeSalat).FirstOrDefault().NombreTitulares;
            }

            Fecha = DpFecha.SelectedDate.Value;
            _addeditmaster = new AddEditAportacionesValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
      
            if (Aportacion != null) textBoxAportacion.Text = Aportacion.ToString();
            //if (Titular != null) this.textBoxTitular.Text = Titular.ToString();
            if (IdParticipe != null) this.ComboBoxTitular.SelectedValue = IdParticipe;

            if (Fecha != null) DpFecha.Text  = Fecha.ToString();
            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            //Cancel = true;
            DialogResult = false;
            this.Close();
           
            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

    }
}
