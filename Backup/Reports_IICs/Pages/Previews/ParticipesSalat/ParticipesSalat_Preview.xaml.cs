using System;
using System.Linq;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para ParticipesSalat_Preview.xaml
    /// </summary>
    public partial class ParticipesSalat_Preview : WizardPage
    {
        public ParticipesSalat_Preview()
        {
            InitializeComponent();
        }

        public ParticipesSalat_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            
            InitializeComponent();
            var SelectIsin = plantilla.Plantillas_Isins.Where(c => c.Isin == isin);

            var LSelectIsin = SelectIsin.ToList();
            if (LSelectIsin != null)
            {
                string isinText = LSelectIsin.Count() > 0 ? ": " + LSelectIsin[0].Descripcion : string.Empty;
                this.PreviewWizardPage.labelTitulo.Content = "PARTICIPES SALAT" + isinText;

            }

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new ParticipesSalat_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 800;
        }

    }
}
