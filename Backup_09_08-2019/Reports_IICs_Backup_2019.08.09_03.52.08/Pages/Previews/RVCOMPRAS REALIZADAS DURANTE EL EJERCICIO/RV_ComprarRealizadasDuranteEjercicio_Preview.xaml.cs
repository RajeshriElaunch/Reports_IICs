using Reports_IICs.DataModels;
using System;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RVCOMPRAS_REALIZADAS_DURANTE_EL_EJERCICIO
{
    /// <summary>
    /// Lógica de interacción para RV_ComprarRealizadasDuranteEjercicio_Preview.xaml
    /// </summary>
    public partial class RV_ComprarRealizadasDuranteEjercicio_Preview : WizardPage
    {
        public RV_ComprarRealizadasDuranteEjercicio_Preview()
        {
            InitializeComponent();
        }

        public RV_ComprarRealizadasDuranteEjercicio_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTA VARIABLE: COMPRAS REALIZADAS DURANTE EJERCICIO " + fecha.Year ;  //+ isinDesc;

            ////var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }


        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RV_ComprarRealizadasDuranteEjercicio_UC(plantilla, isin, fecha));
            this.PreviewWizardPage.MyStackPanelVertical.Width = 751;
        }

    }
}
