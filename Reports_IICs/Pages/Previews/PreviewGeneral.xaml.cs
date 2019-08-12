using Reports_IICs.DataModels;
using Reports_IICs.Resources;
using System;
using Telerik.Windows.Controls;
using System.Windows;
using Reports_IICs.DataAccess.Managers;
using System.Linq;
using Reports_IICs.Pages.Previews.Changes;

namespace Reports_IICs.Pages.Previews
{
    /// <summary>
    /// Interaction logic for PreviewGeneral.xaml
    /// </summary>
    public partial class PreviewGeneral : WizardPage
    {
        private Plantilla _plantilla;
        private DateTime _fecha;
        public int IdSeccion;
        //public bool HasChanged = false;

        private bool _hasChanged = false;
        public bool HasChanged
        {
            get { return _hasChanged; }
            set
            {
                _hasChanged = value;
                // Run some function or event here
                mostrarBotonCambios();
                //if (value)
                //    this.RadButtonCambios.Visibility = Visibility.Visible;
                //else
                //    this.RadButtonCambios.Visibility = Visibility.Hidden;
            }
        }
        public PreviewGeneral(Plantilla plantilla, DateTime fecha, int idSeccion)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;
            IdSeccion = idSeccion;

            this.PreviewWizardPage.labelTitulo.Content = getTitulo();

            getPreview(plantilla, fecha);
        }

        private string getTitulo()
        {
            string output = string.Empty;

            switch (IdSeccion)
            {
                case 13:
                    output = "RENTA VARIABLE";
                    break;
                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                    output = Resource.TituloReportCompraVentaRespectoPrecioAdquisicion;
                    break;
                case 21://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                    output = Resource.TituloReportRentaFija;
                    break;
                case 37://CARTERA RV CCR-VOLGA-GAMAR
                    output = "DETALLE CARTERA";
                    break;
            }

            return output;
        }

        private void getPreview(Plantilla plantilla, DateTime fecha)
        {
            //switch (_idSeccion)
            //{
            //    case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN

            //        break;
            //    case 37://CARTERA RV CCR-VOLGA-GAMAR

            //        break;
            //}

            this.PreviewWizardPage.MyStackPanelVertical.Children.Clear();
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new PreviewGeneral_UC(plantilla, IdSeccion, fecha));
            mostrarBotonCambios();
        }

        private void mostrarBotonCambios()
        {
            int filas = 0;


            switch (IdSeccion)
            {
                case 14:
                    filas = new Preview_CompraVentaPrecAdq_MNG().GetByCodigoIC(_plantilla.CodigoIc).Count();
                    break;
                case 21:
                    var dbContext = new Reports_IICSEntities();
                    var source = dbContext.Get_PreviewChanges_RentaFija(_plantilla.CodigoIc, _fecha).ToList();
                    filas = source.Count();
                    //filas = new Preview_RentaFija_MNG().GetByCodigoIC(_plantilla.CodigoIc).Count();
                    break;
            }
            

            //Si acabamos de editar algún valor o tenemos almacenados cambios de la Preview, mostramos el botón
            if (filas > 0)
                this.StackPanelCambios.Visibility = Visibility.Visible;
            else
                this.StackPanelCambios.Visibility = Visibility.Collapsed;
        }

        private void RadButtonCambios_Click(object sender, RoutedEventArgs e)
        {
            var window = new PreviewChangesWindow(IdSeccion, _plantilla.CodigoIc, _fecha);
            window.ShowDialog();

            //Cuando se cierre la ventana actualizamos
            //Cuando se cierre la ventana actualizamos si ha habido cambios
            if (window.HasChanged)
            {
                //populatePreview(true);
                getPreview(_plantilla, _fecha);
            }
            //populatePreview(true);
        }
    }
}
