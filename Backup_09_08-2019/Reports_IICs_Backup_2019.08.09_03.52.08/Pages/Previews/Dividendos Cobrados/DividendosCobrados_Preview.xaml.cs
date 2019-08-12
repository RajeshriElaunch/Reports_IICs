using Reports_IICs.DataModels;
using System;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Dividendos_Cobrados
{
    /// <summary>
    /// Lógica de interacción para DividendosCobrados_Preview.xaml
    /// </summary>
    public partial class DividendosCobrados_Preview : WizardPage
    {
        public DividendosCobrados_Preview()
        {
            InitializeComponent();
        }

        public DividendosCobrados_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "DIVIDENDOS NETOS COBRADOS DURANTE EJERCICIO " + fecha.Year;  //+ isinDesc;

            ////var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new DividendosCobrados_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 361;
        }
    }
}
