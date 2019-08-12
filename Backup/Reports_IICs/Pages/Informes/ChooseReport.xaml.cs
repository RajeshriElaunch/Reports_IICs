using MahApps.Metro.Controls;
using System;
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
    public partial class ChooseReport : MetroWindow
    {
        public Plantilla Plantilla = new Plantilla();
        public DateTime? Fecha = null;
       
        public bool Aceptar = true;
        private int _noOfErrorsOnScreen = 0;
        private ChooseReportValidation _addeditmaster = new ChooseReportValidation(true);
        private PlantillasPage_VM DataSource = new PlantillasPage_VM();
        bool showDate;


        public ChooseReport(bool showdate)
        {
            InitializeComponent();
            grid.DataContext = _addeditmaster;
            showDate = showdate;
            _addeditmaster.ShowDate = showDate;

            CalendarDateRange cdr = new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.Today.AddYears(50));
            FechaReport.BlackoutDates.Add(cdr);
            

            if (showDate!=true) labelFechaReport.Visibility = Visibility.Hidden;
            if (showDate != true) FechaReport.Visibility = Visibility.Hidden;
            if (showDate != true) ComboBoxCodigo.ItemsSource = DataSource.Generaciones;
        }
        private void ComboBoxCodigo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

            if (showDate)
            {
                Fecha = this.FechaReport.SelectedDate;
            }
            Plantilla = (Plantilla)ComboBoxCodigo.SelectedItem;

            _addeditmaster = new ChooseReportValidation(showDate);
            grid.DataContext = _addeditmaster;
            e.Handled = true;
            this.Close();
        }

        private void ButtonMostrar_Click(object sender, RoutedEventArgs e)
        {
            Aceptar = false;
           

            //Codigo = this.textBoxCodigo.Text;
            Fecha = this.FechaReport.SelectedDate;
            Plantilla = (Plantilla)ComboBoxCodigo.SelectedItem;

            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
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
