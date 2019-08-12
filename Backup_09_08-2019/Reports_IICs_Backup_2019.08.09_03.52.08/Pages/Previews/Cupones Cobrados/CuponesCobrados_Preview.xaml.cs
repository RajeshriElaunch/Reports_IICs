using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.Cupones_Cobrados
{
    /// <summary>
    /// Lógica de interacción para CuponesCobrados_Preview.xaml
    /// </summary>
    public partial class CuponesCobrados_Preview : WizardPage
    {
        public CuponesCobrados_Preview()
        {
            InitializeComponent();
        }

        public CuponesCobrados_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();

            this.PreviewWizardPage.labelTitulo.Content = "CUPONES NETOS COBRADOS DURANTE EJERCICIO " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new CuponesCobrados_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 361;
        }
    }
}
