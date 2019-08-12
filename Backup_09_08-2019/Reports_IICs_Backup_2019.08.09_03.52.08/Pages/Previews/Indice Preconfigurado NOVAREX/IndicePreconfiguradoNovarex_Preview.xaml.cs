using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.Indice_Preconfigurado_NOVAREX
{
    /// <summary>
    /// Lógica de interacción para IndicePreconfiguradoNovarex_Preview.xaml
    /// </summary>
    public partial class IndicePreconfiguradoNovarex_Preview : WizardPage
    {
        public IndicePreconfiguradoNovarex_Preview()
        {
            InitializeComponent();
        }

        public IndicePreconfiguradoNovarex_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = Reports_IICs.Resources.Resource.Report_IndicePreconfiguradoNovarex + " A " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new IndicePreconfiguradoNovarex_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 412;
        }
    }
}
