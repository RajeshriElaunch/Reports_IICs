using Reports_IICs.DataModels;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV
{
    /// <summary>
    /// Interaction logic for RatiosCarteraRV_Preview.xaml
    /// </summary>
    public partial class RatiosCarteraRV_Preview : WizardPage
    {
        public RatiosCarteraRV_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "Ratios Cartera RV";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RatiosCarteraRV_UC(plantilla, isin, fecha));

            var pW = System.Windows.SystemParameters.PrimaryScreenWidth;


            if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1034)
            {
                if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = 1035;
                }

            }
            else
            {
                if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

           
        }

        private void PreviewWizardPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var pW = e.NewSize.Width;


            if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1034)
            {
                if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = 1035;
                }

            }
            else
            {
                if (((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((RatiosCarteraRV_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }

    }
}
