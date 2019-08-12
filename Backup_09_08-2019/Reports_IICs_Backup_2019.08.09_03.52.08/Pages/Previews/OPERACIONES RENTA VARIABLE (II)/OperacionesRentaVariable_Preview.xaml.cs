using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;

namespace Reports_IICs.Pages.Previews.OPERACIONES_RENTA_VARIABLE__II_
{
    /// <summary>
    /// Lógica de interacción para OperacionesRentaVariable_Preview.xaml
    /// </summary>
    public partial class OperacionesRentaVariable_Preview : WizardPage
    {
        public OperacionesRentaVariable_Preview()
        {
            InitializeComponent();
        }

        public OperacionesRentaVariable_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = ReportFunctions.TituloReportOperacionesRentaVariable_II() + " A " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new OperacionesRentaVariable_UC(plantilla, isin, fecha));
            //this.PreviewWizardPage.MyStackPanelVertical.Width = 462;
        }
    }
}
