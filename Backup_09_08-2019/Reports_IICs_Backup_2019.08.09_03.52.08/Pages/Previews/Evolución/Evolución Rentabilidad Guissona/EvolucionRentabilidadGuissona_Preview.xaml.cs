using Reports_IICs.DataModels;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Rentabilidad_Guissona
{
    /// <summary>
    /// Lógica de interacción para EvolucionRentabilidadGuissona_Preview.xaml
    /// </summary>
    public partial class EvolucionRentabilidadGuissona_Preview : WizardPage
    {
        public EvolucionRentabilidadGuissona_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTABILIDAD GUISSONA";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);

        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new EvolucionRentabilidadGuissona_UC(plantilla, isin, fecha));



            var pW = System.Windows.SystemParameters.PrimaryScreenWidth;


            if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1350)
            {
                if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
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
                if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }

        private void PreviewWizardPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var pW = e.NewSize.Width;


            if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1350)
            {
                if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
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
                if (((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((EvolucionRentabilidadGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }
    }
}
