using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace Reports_IICs.Pages.Previews.Dividendos_Cobrados
{
    /// <summary>
    /// Lógica de interacción para DividendosCobrados_UC.xaml
    /// </summary>
    public partial class DividendosCobrados_UC : UserControl
    {

        private Plantilla _plantilla;
        protected DateTime _fecha;
        public DividendosCobrados_UC()
        {
            InitializeComponent();
        }

        public DividendosCobrados_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.DividendosCobrados_DA.GetTemp_DividendosCobrados(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta.OrderBy(c=>c.Fecha);


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_DividendosCobrados)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempDividendosCobrados_Sel_object = (T_DividendosCobrados)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var divicobrado_temp = dbcontext.Temp_DividendosCobrados.FirstOrDefault(p => p.Id == id);

                if (divicobrado_temp != null)
                {
                    divicobrado_temp.ImporteBruto = tempDividendosCobrados_Sel_object.ImporteBruto;
                   
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
                //if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio != null && ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin != null)
                //{
                //    if (!((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                //    {
                //        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = String.Format("{0:P2}", (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio - decimal.Parse(((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin)) / ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio * -1);
                //    }
                //    else
                //    {
                //        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = "-";
                //    }

                //}

                //if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                //{
                //    ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin = "Vendido";

                //}
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
