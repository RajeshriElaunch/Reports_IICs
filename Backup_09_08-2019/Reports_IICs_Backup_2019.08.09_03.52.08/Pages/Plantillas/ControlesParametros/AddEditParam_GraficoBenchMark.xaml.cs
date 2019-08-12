using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditParam_GraficoBenchMark.xaml
    /// </summary>
    public partial class AddEditParam_GraficoBenchMark : MetroWindow
    {
        public string Indice;
        public string Descripcion;

        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditParam_GraficoBenchMarkValidation _addeditmaster = new AddEditParam_GraficoBenchMarkValidation();

        public AddEditParam_GraficoBenchMark(string indice, string descripcion, List<string> listacodigo)
        {
            Indice = indice;
            Descripcion = descripcion;
            InitializeComponent();

            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;

            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Indice = indice;
            _addeditmaster.Descripcion = descripcion;

            if (string.IsNullOrEmpty(Indice)) txtBoxIndice.Focus();

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
        Indice = this.txtBoxIndice.Text;
        Descripcion = this.textBoxDescripcion.Text;
        _addeditmaster = new AddEditParam_GraficoBenchMarkValidation();
        grid.DataContext = _addeditmaster;
        e.Handled = true;
        this.Close();
    }

    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {

        if (Indice != null) txtBoxIndice.Text = Indice.ToString();
        if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();

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
