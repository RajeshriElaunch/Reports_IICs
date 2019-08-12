using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Resources;
using Reports_IICs.ViewModels.Reports.Secciones;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RentaFija
{
    /// <summary>
    /// Lógica de interacción para RentaFija_Preview.xaml
    /// </summary>
    public partial class RentaFija_Preview : WizardPage
    {
        public RentaFija_Preview()
        {
            InitializeComponent();
        }

        public RentaFija_Preview(Plantilla plantilla, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RENTA FIJA";

            ////var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, fecha);
        }

        private void populateData(Plantilla plantilla, DateTime fecha)
        {
            var temp = RentaFijaVM.GetTemp(plantilla.CodigoIc).ToList();
            
            var fechaIni = Utils.GetFechaInicio(plantilla, fecha);
            string titulo = string.Empty;
            
            #region Grupo1
            titulo = string.Format(Resource.RfGrupo01, fechaIni.ToShortDateString(), fecha.Year.ToString());
            int grupo = 1;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo2
            titulo = string.Format(Resource.RfGrupo02, fechaIni.ToShortDateString(), fecha.Year.ToString());
            grupo = 2;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo3
            titulo = string.Format(Resource.RfGrupo03, fechaIni.ToShortDateString(), fecha.Year.ToString());
            grupo = 3;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo4
            titulo = string.Format(Resource.RfGrupo04, fecha.Year.ToString(), fecha.Year.ToString());
            grupo = 4;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo5
            titulo = string.Format(Resource.RfGrupo05, fecha.Year.ToString());
            grupo = 5;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo6
            titulo = Resource.RfGrupo06;
            grupo = 6;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC_Small(plantilla, fecha, titulo, grupo, temp));
            #endregion

            #region Grupo7
            titulo = Resource.RfGrupo07;
            grupo = 7;
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaFija_UC_Small(plantilla, fecha, titulo, grupo, temp));
            #endregion            
        }

        private void getSubreportSmall(Plantilla plantilla, string isinPlantilla, DateTime fecha, string titulo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            /*
            var subr = new RentaVariable_UC_Small(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            if (subr.Visible)
            {
                this.PreviewWizardPage.MyStackPanelVertical.Children.Add(subr);
            }
            */
        }
    }
}
