using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace Reports_IICs.Pages.Previews.Cupones_Cobrados
{
    /// <summary>
    /// Lógica de interacción para CuponesCobrados_UC.xaml
    /// </summary>
    public partial class CuponesCobrados_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        public CuponesCobrados_UC()
        {
            InitializeComponent();
        }

        public CuponesCobrados_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.ReportCuponesCobrados_DA.GetTemp_CuponesCobrados(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_CuponesCobrados)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempCuponesCobrados_Sel_object = (T_CuponesCobrados)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var cupocobrado_temp = dbcontext.Temp_CuponesCobrados.FirstOrDefault(p => p.Id == id);

                if (cupocobrado_temp != null)
                {
                    cupocobrado_temp.ImporteNeto = tempCuponesCobrados_Sel_object.ImporteNeto;

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
