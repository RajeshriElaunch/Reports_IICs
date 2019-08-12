using System;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Gráficos_Burbujas
{
    /// <summary>
    /// Lógica de interacción para Burbujas_SmallBig_Preview.xaml
    /// </summary>
    public partial class Burbujas_SmallBig_Preview : WizardPage
    {
        public Burbujas_SmallBig_Preview()
        {
            InitializeComponent();
        }

        public Burbujas_SmallBig_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "Grafico Burbujas SmallBig";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new Burbujas_SmallBig_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 914;

        }
    }
}
