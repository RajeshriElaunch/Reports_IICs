using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.Variacion_Patrimonial_B
{
    /// <summary>
    /// Lógica de interacción para VariacionPatrimonialB_Preview.xaml
    /// </summary>
    public partial class VariacionPatrimonialB_Preview : WizardPage
    {
        public VariacionPatrimonialB_Preview()
        {
            InitializeComponent();
        }

        public VariacionPatrimonialB_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "VARIACIÓN PATRIMONIAL B " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new VariacionPatrimonialB_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 581;
        }
    }
}
