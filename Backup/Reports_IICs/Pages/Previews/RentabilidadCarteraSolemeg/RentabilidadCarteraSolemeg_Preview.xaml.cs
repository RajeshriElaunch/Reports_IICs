using Reports_IICs.DataModels;
using System;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RentabilidadCarteraSolemeg
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraSolemeg_Preview.xaml
    /// </summary>
    public partial class RentabilidadCarteraSolemeg_Preview : WizardPage
    {
        public RentabilidadCarteraSolemeg_Preview()
        {
            InitializeComponent();
        }

        public RentabilidadCarteraSolemeg_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTABILIDAD CARTERA DESDE ORIGEN SOLEMEG A " + fecha.Year;  

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentabilidadCarteraSolemeg_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 662;
        }

    }
}
