using System;
using System.Windows;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Patrimonio_Guissona
{
    /// <summary>
    /// Lógica de interacción para EvolucionPatrimonioGuissona_Preview.xaml
    /// </summary>
    public partial class EvolucionPatrimonioGuissona_Preview : WizardPage
    {
        public EvolucionPatrimonioGuissona_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA";

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);


        }


        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new EvolucionPatrimonioGuissona_UC(plantilla, isin, fecha));



            var pW = System.Windows.SystemParameters.PrimaryScreenWidth;


            if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1350)
            {
                if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
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
                if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW - 100;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }

        private void PreviewWizardPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var pW = e.NewSize.Width;


            if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > 1350)
            {
                if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
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
                if (((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho > pW)
                {
                    this.GridScroll.Width = pW - 120;
                    this.PreviewWizardPage.MyStackPanelVertical.Width = pW;
                }
                else
                {
                    this.PreviewWizardPage.MyStackPanelVertical.Width = ((EvolucionPatrimonioGuissona_UC)(this.PreviewWizardPage.MyStackPanelVertical.Children[0])).Ancho;
                }

            }

        }


    }
}
