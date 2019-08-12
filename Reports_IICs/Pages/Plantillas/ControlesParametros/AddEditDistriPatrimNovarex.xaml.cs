using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    /// <summary>
    /// Lógica de interacción para AddEditDistriPatrimNovarex.xaml
    /// </summary>
    public partial class AddEditDistriPatrimNovarex : MetroWindow
    {
        public string Formula;
        public string Descripcion;

        public bool Cancel = true;
        private int _noOfErrorsOnScreen = 0;
        private AddEditDistriPatrimNovarexValidation _addeditmaster = new AddEditDistriPatrimNovarexValidation();

        public AddEditDistriPatrimNovarex(string descripcion, string formula, List<string> listacodigo)
        {
            Formula = formula;
            Descripcion = descripcion;
            InitializeComponent();
            Loaded += OnLoaded;
            grid.DataContext = _addeditmaster;

            _addeditmaster.ListaCodigo = listacodigo;
            _addeditmaster.Formula = formula;
            _addeditmaster.Descripcion = descripcion;
            if (string.IsNullOrEmpty(Descripcion)) textBoxDescripcion.Focus();
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
            Descripcion = this.textBoxDescripcion.Text;
            _addeditmaster = new AddEditDistriPatrimNovarexValidation();
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (Formula != null) textBoxFormula.Text = Formula.ToString();
            if (Descripcion != null) textBoxDescripcion.Text = Descripcion.ToString();

            Loaded -= OnLoaded;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void textBoxFormula_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void textBoxFormula_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = new AddEditFormula();
            window.Formula = textBoxFormula.Text;

            if (window != null)
            {
                if (Application.Current.MainWindow != window)
                {
                    window.Owner = Application.Current.MainWindow;
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (window.Owner as MetroWindow);
                    ownerMetroWindow.Height = window.Height;
                    ownerMetroWindow.Width = window.Width;
                    ownerMetroWindow.MinHeight = window.MinHeight;
                    ownerMetroWindow.MinWidth = window.MinWidth;
                    if (!ownerMetroWindow.IsOverlayVisible())
                        ownerMetroWindow.ShowOverlayAsync();
                }

                #region Create Custom object to take values

                //plantilla_isins = (Plantillas_Isins)this.RadGridViewIsin.SelectedItem;
                //wcodigo = plantilla_isins.Isin;
                //wdescripcion = plantilla_isins.Descripcion;


                #endregion


                window.ShowDialog();

                window.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                if (ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!window.Cancel)
                {
                    #region Retrieve Values from window

                    //parametrosDistriPatriNovarex.Remove(param_DistriPatriNovarex);

                    //Parametros_DistribucionPatrimonioNovarex temp_item = new Parametros_DistribucionPatrimonioNovarex();
                    //temp_item.Formula = window.Formula;
                    //temp_item.Descripcion = window.Descripcion;
                    //parametrosDistriPatriNovarex.Add(temp_item);
                    //this.myDistriPatrimNovarexGrid.ItemsSource = null;
                    //this.myDistriPatrimNovarexGrid.ItemsSource = parametrosDistriPatriNovarex;
                   textBoxFormula.Text = window.Formula;
                    #endregion
                }
            }
        }
    }
}
