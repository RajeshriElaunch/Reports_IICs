using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Plantillas;

namespace Reports_IICs.Pages.Informes
{
    /// <summary>
    /// Lógica de interacción para ChooseReport.xaml
    /// </summary>
    public partial class ChooseReportIsin : MetroWindow
    {
        public string Isin = null;
       
        public bool Aceptar = true;
        private int _noOfErrorsOnScreen = 0;
        private ChooseReportValidation _addeditmaster = new ChooseReportValidation(true);
        private PlantillasPage_VM DataSource = new PlantillasPage_VM();        


        public ChooseReportIsin(Plantilla plantilla)
        {
            InitializeComponent();
            grid.DataContext = _addeditmaster;

            ComboBoxIsin.ItemsSource = plantilla.Plantillas_Isins;
            ComboBoxIsin.DisplayMemberPath = "Isin";
            ComboBoxIsin.SelectedValuePath = "Isin";
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
            Aceptar = false;

            Isin = ComboBoxIsin.SelectedValue.ToString();

            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void ButtonMostrar_Click(object sender, RoutedEventArgs e)
        {
            Aceptar = false;

            Isin = ComboBoxIsin.SelectedValue.ToString();

            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void ComboBoxIsin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)

            {

                // Whatever code you want if enter key is pressed goes here
            }

            if (e.Key == Key.Escape)

            {
                this.Close();
                // Whatever code you want if enter key is pressed goes here
            }


        }
    }
}
