using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.SUSCRIPCIONES_REEMBOLSOS
{
    /// <summary>
    /// Lógica de interacción para SuscripcionesReembolsos_Preview.xaml
    /// </summary>
    public partial class SuscripcionesReembolsos_Preview : WizardPage
    {
        public SuscripcionesReembolsos_Preview()
        {
            InitializeComponent();
        }

        public SuscripcionesReembolsos_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();

            this.PreviewWizardPage.labelTitulo.Content = "SUSCRIPCIONES-REEMBOLSOS A " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new SuscripcionesReembolsos_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 362;
        }
    }
}
