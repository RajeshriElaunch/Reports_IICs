using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.SUSCRIPCIONES_REEMBOLSOS
{
    /// <summary>
    /// Lógica de interacción para SuscripcionesReembolsos_UC.xaml
    /// </summary>
    public partial class SuscripcionesReembolsos_UC : UserControl
    {

        private Plantilla _plantilla;
        protected DateTime _fecha;
        public SuscripcionesReembolsos_UC()
        {
            InitializeComponent();
        }

        public SuscripcionesReembolsos_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

           

            var rentaRem = DataAccess.Reports.Report_SuscripcionesReembolsos_DA.GetTemp_SuscripcionesReembolsos(plantilla.CodigoIc, isin, "REINTEGRO");
            var rentaSubs = DataAccess.Reports.Report_SuscripcionesReembolsos_DA.GetTemp_SuscripcionesReembolsos(plantilla.CodigoIc, isin, "SUSCRIPCION");
            this.myGridSubs.ItemsSource = rentaSubs;
            this.myGridReembolso.ItemsSource = rentaRem;

           
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_SuscripcionesReembolsos)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempSuscripcionesReembolsos_Sel_object = (T_SuscripcionesReembolsos)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var suscriReembolsos_temp = dbcontext.Temp_SuscripcionesReembolsos.FirstOrDefault(p => p.Id == id);

                if (suscriReembolsos_temp != null)
                {
                    suscriReembolsos_temp.Importe = tempSuscripcionesReembolsos_Sel_object.Importe;

                }
                try
                {
                    dbcontext.SaveChanges();

                }
                catch (Exception)
                {

                }

            }


        }

        private void myGrid_DataLoaded(object sender, EventArgs e)
        {
            ((RadGridView)sender).ExpandAllGroups();

        }

        private void myGrid_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;


            if (row != null)

            {

            }
        }

        private void myGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {


            //if (e.Cell.Column.Name == "Cotizacion")
            //{
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            //}


        }
    }
}
