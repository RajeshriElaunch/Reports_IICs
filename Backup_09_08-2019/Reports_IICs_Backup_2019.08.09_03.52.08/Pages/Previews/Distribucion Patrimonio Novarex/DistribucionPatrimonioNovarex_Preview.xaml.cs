using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.Distribucion_Patrimonio_Novarex
{
    /// <summary>
    /// Lógica de interacción para DistribucionPatrimonioNovarex_Preview.xaml
    /// </summary>
    public partial class DistribucionPatrimonioNovarex_Preview : WizardPage
    {
        public DistribucionPatrimonioNovarex_Preview()
        {
            InitializeComponent();
        }

        public DistribucionPatrimonioNovarex_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();

            this.PreviewWizardPage.labelTitulo.Content = Reports_IICs.Resources.Resource.Report_DistribucionPatrimonioNovarex + " A " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new DistribucionPatrimonioNovarex_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 402;
        }

    }
}
