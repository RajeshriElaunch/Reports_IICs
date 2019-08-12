using Reports_IICs.DataModels;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV2
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraV2_Preview.xaml
    /// </summary>
    public partial class RentabilidadCarteraV2_Preview : WizardPage
    {
        public RentabilidadCarteraV2_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTABILIDAD CARTERA (II)";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentabilidadCarteraV2_UC(plantilla, isin, fecha));

           

            var pW = System.Windows.SystemParameters.PrimaryScreenWidth;
           

            if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho>1350)
            {
                if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = 1350;
                }
                   
            }
            else
            {
                if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }
               
            }
            
        }

        private void PreviewWizardPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var pW = e.NewSize.Width;
           

            if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1350)
            {
                if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = 1350;
                }

            }
            else
            {
                if (((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((RentabilidadCarteraV2_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }
    }
}
