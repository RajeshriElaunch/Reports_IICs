using System;
using System.Linq;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;


namespace Reports_IICs.Pages.Previews.ListadoRentaFijaNovarex
{
    /// <summary>
    /// Lógica de interacción para ListadoRentaFijaNovarex_Preview.xaml
    /// </summary>
    public partial class ListadoRentaFijaNovarex_Preview : WizardPage
    {
        public ListadoRentaFijaNovarex_Preview()
        {
            InitializeComponent();
        }

        public ListadoRentaFijaNovarex_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            var SelectIsin = plantilla.Plantillas_Isins.Where(c => c.Isin == isin);

            var LSelectIsin = SelectIsin.ToList();
            if (LSelectIsin != null)
            {
                string isinText = LSelectIsin.Count() > 0 ? ": " + LSelectIsin[0].Descripcion : string.Empty;
                this.PreviewWizardPage.labelTitulo.Content = "TITULOS DE RENTA FIJA DE LA CARTERA DE NOVAREX SICAV A " + String.Format("{0:d}", fecha);

            }

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new ListadoRentaFijaNovarex_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 411;
        }

    }

   
}
