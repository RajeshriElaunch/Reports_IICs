using System;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.IIC_ComprasVentasEjercicio
{
    /// <summary>
    /// Lógica de interacción para IIC_ComprasVentasEjercicio_Preview.xaml
    /// </summary>
    public partial class IIC_ComprasVentasEjercicio_Preview : WizardPage
    {
        public IIC_ComprasVentasEjercicio_Preview()
        {
            InitializeComponent();
        }
        public IIC_ComprasVentasEjercicio_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
           
            this.PreviewWizardPage.labelTitulo.Content = Reports_IICs.Resources.Resource.Report_IIC_VentasEjercicio + " A " + fecha.Year;  //+ isinDesc;

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new IIC_ComprasVentasEjercicio_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 462;
        }
    }
}
