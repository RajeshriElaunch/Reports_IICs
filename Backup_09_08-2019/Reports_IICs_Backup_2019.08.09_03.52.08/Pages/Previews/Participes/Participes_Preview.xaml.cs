using System;
using System.Linq;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Participes
{
    /// <summary>
    /// Lógica de interacción para Participes_Preview.xaml
    /// </summary>
    public partial class Participes_Preview : WizardPage
    {
        public Participes_Preview()
        {
            InitializeComponent();
        }

        public Participes_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            var SelectIsin = plantilla.Plantillas_Isins.Where(c => c.Isin == isin);

            var LSelectIsin = SelectIsin.ToList();
            if (LSelectIsin != null)
            {
                string isinText = LSelectIsin.Count() > 0 ? ": " + LSelectIsin[0].Descripcion : string.Empty;
                this.PreviewWizardPage.labelTitulo.Content = "PARTICIPES" + isinText;

            }

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new Participes_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 351;
        }


    }
}
