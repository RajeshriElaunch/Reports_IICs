using Reports_IICs.DataModels;
using System;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV1
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraV1_Preview.xaml
    /// </summary>
    public partial class RentabilidadCarteraV1_Preview : WizardPage
    {
        public RentabilidadCarteraV1_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();

            //var SelectIsin = plantilla.Plantillas_Isins.Where(c => c.Isin == isin);


            //var LSelectIsin = SelectIsin.ToList();
            //if(LSelectIsin!=null)
            //{
            //    this.PreviewWizardPage.labelTitulo.Content = "RENTABILIDAD CARTERA: " + LSelectIsin[0].Descripcion; 

            //}

            this.PreviewWizardPage.labelTitulo.Content = "RENTABILIDAD CARTERA: " + isinDesc;

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentabilidadCarteraV1_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 181;
        }
    }
}
