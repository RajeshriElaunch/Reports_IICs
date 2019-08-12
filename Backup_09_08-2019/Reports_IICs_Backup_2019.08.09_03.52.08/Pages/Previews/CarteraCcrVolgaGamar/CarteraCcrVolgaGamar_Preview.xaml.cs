using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.CarteraCcrVolgaGamar
{
    /// <summary>
    /// Lógica de interacción para CarteraCcrVolgaGamar_Preview.xaml
    /// </summary>
    public partial class CarteraCcrVolgaGamar_Preview : WizardPage
    {
        public CarteraCcrVolgaGamar_Preview()
        {
            InitializeComponent();
        }

        public CarteraCcrVolgaGamar_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = Resource.TituloReportCarteraCcrVolgaGamar;
            
            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isinPlantilla, DateTime fecha)
        {
            var fechaIni = Utils.GetFechaInicio(plantilla, fecha);
            string titulo = string.Empty;
            string grupo = string.Empty;
            List<string> instrumentosIds;
            List<string> tiposInstrumentoIds;

            instrumentosIds = new List<string>() { "1", "20" };
            tiposInstrumentoIds = new List<string>() { "1" };

            #region Grupo1
            titulo = string.Format(Resource.RVGrupo01, fechaIni.ToShortDateString(), fecha.Year.ToString());
            //grupo = "-01";
            grupo = "1";
            //this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaVariable_UC(plantilla, isinPlantilla, fecha, titulo, grupo, instrumentosIds, tiposInstrumentoIds));
            #endregion
            /*
            #region Grupo2
            titulo = string.Format(Resource.RVGrupo02, fechaIni.ToShortDateString(), fecha.Year.ToString());
            //grupo = "-02";
            grupo = "-02";
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaVariable_UC(plantilla, isinPlantilla, fecha, titulo, grupo, instrumentosIds, tiposInstrumentoIds));
            #endregion

            #region Grupo3
            titulo = string.Format(Resource.RVGrupo03, fecha.Year);
            grupo = "3";
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaVariable_UC(plantilla, isinPlantilla, fecha, titulo, grupo, instrumentosIds, tiposInstrumentoIds));
            #endregion

            #region Grupo4
            titulo = string.Format(Resource.RVGrupo04, fecha.Year, fecha.Year);
            grupo = "4";
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaVariable_UC(plantilla, isinPlantilla, fecha, titulo, grupo, instrumentosIds, tiposInstrumentoIds));
            #endregion

            #region Grupo5
            titulo = Resource.RVGrupo05;
            instrumentosIds = null;
            tiposInstrumentoIds = new List<string>() { "3" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo6
            titulo = Resource.RVGrupo06;
            instrumentosIds = new List<string>() { "3" }; 
            tiposInstrumentoIds = new List<string>() { "2" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo7
            titulo = Resource.RVGrupo07;
            instrumentosIds = null;
            tiposInstrumentoIds = new List<string>() { "5" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo8
            titulo = Resource.RVGrupo08;
            instrumentosIds = null;
            tiposInstrumentoIds = new List<string>() { "11" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo9
            titulo = Resource.RVGrupo09;
            instrumentosIds = null;
            tiposInstrumentoIds = new List<string>() { "12" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo10
            titulo = Resource.RVGrupo10;
            instrumentosIds = new List<string>() { "3" };
            tiposInstrumentoIds = new List<string>() { "4" };
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo11
            titulo = Resource.RVGrupo11;
            instrumentosIds = new List<string>() { "12" };
            tiposInstrumentoIds = null;
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo12
            titulo = Resource.RVGrupo12;
            instrumentosIds = new List<string>() { "13" };
            tiposInstrumentoIds = null;
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion

            #region Grupo13
            titulo = Resource.RVGrupo13;
            instrumentosIds = new List<string>() { "15" };
            tiposInstrumentoIds = null;
            getSubreportSmall(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            #endregion
    */
        }

        private void getSubreportSmall(Plantilla plantilla, string isinPlantilla, DateTime fecha, string titulo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            //var subr = new RentaVariable_UC_Small(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            //if (subr.Visible)
            //{
            //    this.PreviewWizardPage.MyStackPanelVertical.Children.Add(subr);
            //}
        }
    }
}
