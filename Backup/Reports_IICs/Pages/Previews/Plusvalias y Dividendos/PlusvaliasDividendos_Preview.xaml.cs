using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.Plusvalias_y_Dividendos
{
    /// <summary>
    /// Lógica de interacción para PlusvaliasDividendos_Preview.xaml
    /// </summary>
    public partial class PlusvaliasDividendos_Preview : WizardPage
    {
        public PlusvaliasDividendos_Preview()
        {
            InitializeComponent();
        }

        public PlusvaliasDividendos_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "PLUSVALÍAS Y DIVIDENDOS " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }
        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new PlusvaliasDividendos_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 501;
        }
    }
}
