using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Pages.Previews.Changes;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.RentaVariable
{
    /// <summary>
    /// Lógica de interacción para RentaVariable_Preview.xaml
    /// </summary>
    public partial class RentaVariable_Preview : WizardPage
    {
        public bool HasChanged = false;        

        Plantilla _plantilla;
        DateTime _fechaInforme;
        string _isin;
        public RentaVariable_Preview()
        {
            InitializeComponent();
        }

        public RentaVariable_Preview(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _isin = isin;
            _fechaInforme = fecha;
            this.PreviewWizardPage.labelTitulo.Content = "RENTA VARIABLE";

            ////var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();

            populateData(plantilla, isin, fecha);
        }

        private void populateData(Plantilla plantilla, string isinPlantilla, DateTime fecha)
        {
            this.PreviewWizardPage.MyStackPanelVertical.Children.Clear();

            var fechaIni = Utils.GetFechaInicio(plantilla, fecha);
            string titulo = string.Empty;
            string grupo = string.Empty;
            List<string> instrumentosIds;
            List<string> tiposInstrumentoIds;

            instrumentosIds = new List<string>() { "1", "20", "19" };
            //tiposInstrumentoIds = new List<string>() { "1", "2" };
            tiposInstrumentoIds = null;

            #region Grupo1
            titulo = string.Format(Resource.RVGrupo01, fechaIni.ToShortDateString(), fecha.Year.ToString());
            //grupo = "-01";
            grupo = "1";
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new RentaVariable_UC(plantilla, isinPlantilla, fecha, titulo, grupo, instrumentosIds, tiposInstrumentoIds));
            #endregion

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
        }

        private void RadButtonCambios_Click(object sender, RoutedEventArgs e)
        {
            var window = new PreviewChangesWindow(13, _plantilla.CodigoIc, _fechaInforme);
            window.ShowDialog();

            //Cuando se cierre la ventana actualizamos si ha habido cambios
            if (window.HasChanged)
            {
                populatePreview(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualizar">La primera vez que cargamos este UserControl: actualizar = false
        /// cuando queramos recargar el usercontrol: actualizar = true</param>
        private void populatePreview(bool actualizar)
        {
            mostrarBotonCambios();
            populateData(_plantilla, _isin, _fechaInforme);
            //getColumnasYSource(actualizar);
        }

        /// <summary>
        /// Si la tabla de la Preview correspondiente tiene algún cambio guardado para este código IC
        /// Mostraremos el botón que nos permite ver esos cambios (true)
        /// En caso contrario lo ocultamos (false)
        /// </summary>
        /// <returns></returns>
        private void mostrarBotonCambios()
        {
            int filas = new Preview_RentaVariable_MNG().GetByCodigoIC(_plantilla.CodigoIc).Count();
                    
            if (filas > 0)
                this.StackPanelCambios.Visibility = Visibility.Visible;
            else
                this.StackPanelCambios.Visibility = Visibility.Collapsed;
        }
        

        private void getSubreportSmall(Plantilla plantilla, string isinPlantilla, DateTime fecha, string titulo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            var subr = new RentaVariable_UC_Small(plantilla, isinPlantilla, fecha, titulo, instrumentosIds, tiposInstrumentoIds);
            if (subr.Visible)
            {
                this.PreviewWizardPage.MyStackPanelVertical.Children.Add(subr);
            }
        }

        
    }
}
