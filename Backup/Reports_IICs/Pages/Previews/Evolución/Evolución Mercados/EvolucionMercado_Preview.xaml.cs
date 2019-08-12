using Reports_IICs.DataModels;
using System;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados
{
    /// <summary>
    /// Lógica de interacción para EvolucionMercado_Preview.xaml
    /// </summary>
    public partial class EvolucionMercado_Preview : WizardPage
    {
        public EvolucionMercado_Preview()
        {
            InitializeComponent();
        }

        public EvolucionMercado_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "Evolución de los mercados";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new EvolucionMercado_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 602;

        }
    }
}
