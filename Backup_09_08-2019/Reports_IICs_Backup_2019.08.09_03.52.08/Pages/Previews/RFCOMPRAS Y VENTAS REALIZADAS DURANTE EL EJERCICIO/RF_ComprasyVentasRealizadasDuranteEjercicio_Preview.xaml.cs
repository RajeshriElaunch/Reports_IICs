using Reports_IICs.DataModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO
{
    /// <summary>
    /// Lógica de interacción para RF_ComprasyVentasRealizadasDuranteEjercicio_Preview.xaml
    /// </summary>
    public partial class RF_ComprasyVentasRealizadasDuranteEjercicio_Preview : WizardPage
    {
        public RF_ComprasyVentasRealizadasDuranteEjercicio_Preview()
        {
            InitializeComponent();
        }

        public RF_ComprasyVentasRealizadasDuranteEjercicio_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTA FIJA: COMPRAS Y VENTAS REALIZADAS DURANTE EJERCICIO " + fecha.Year;  //+ isinDesc;
            //this.PreviewWizardPage.labelTitulo.Content = "";
            ////var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha, isinDesc);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha, string isinDesc)
        {

            TextBlock MyTextBlockBLANK4 = new TextBlock();
            MyTextBlockBLANK4.Inlines.Add(new Run() { Text = " ", FontWeight = FontWeights.Bold });
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockBLANK4);

            TextBlock MyTextBlockIsinDesc = new TextBlock();
            MyTextBlockIsinDesc.TextAlignment = TextAlignment.Center;

            MyTextBlockIsinDesc.Inlines.Add(new Run() { Text = isinDesc, FontWeight = FontWeights.Bold });
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockIsinDesc);

            TextBlock MyTextBlockBLANK5 = new TextBlock();
            MyTextBlockBLANK5.Inlines.Add(new Run() { Text = " ", FontWeight = FontWeights.Bold });
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockBLANK5);


            TextBlock MyTextBlockBLANK = new TextBlock();
            MyTextBlockBLANK.Inlines.Add(new Run() { Text = " ", FontWeight = FontWeights.Bold });

            TextBlock MyTextBlock = new TextBlock();
            MyTextBlock.TextAlignment = TextAlignment.Left;

            MyTextBlock.Inlines.Add(new Run() { Text = "RENTA FIJA:COMPRAS EJERCICIO " + fecha.Year.ToString(), FontWeight = FontWeights.Bold });
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlock);
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockBLANK); 
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RF_ComprasyVentasRealizadasDuranteEjercicio_UC(plantilla, isin, fecha,true));
            TextBlock MyTextBlockBLANK2 = new TextBlock();
            MyTextBlockBLANK2.Inlines.Add(new Run() { Text = " ", FontWeight = FontWeights.Bold });

            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockBLANK2);
            TextBlock MyTextBlockVENTAS = new TextBlock();
            MyTextBlockVENTAS.TextAlignment = TextAlignment.Left;

            MyTextBlockVENTAS.Inlines.Add(new Run() { Text = "RENTA FIJA:VENTAS Y AMORTIZACIONES EJERCICIO " + fecha.Year.ToString(), FontWeight = FontWeights.Bold });
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockVENTAS);
            TextBlock MyTextBlockBLANK3 = new TextBlock();
            MyTextBlockBLANK3.Inlines.Add(new Run() { Text = " ", FontWeight = FontWeights.Bold });

            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlockBLANK3);
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RF_ComprasyVentasRealizadasDuranteEjercicio_UC(plantilla, isin, fecha,false));


            this.PreviewWizardPage.MyStackPanelVertical.Width = 451;
        }

    }
}
