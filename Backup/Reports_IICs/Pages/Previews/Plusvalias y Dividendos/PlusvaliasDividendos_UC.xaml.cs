using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Previews.Plusvalias_y_Dividendos
{
    /// <summary>
    /// Lógica de interacción para PlusvaliasDividendos_UC.xaml
    /// </summary>
    public partial class PlusvaliasDividendos_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public PlusvaliasDividendos_UC()
        {
            InitializeComponent();
        }

        public PlusvaliasDividendos_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.ReportPlusvaliasDividendos_DA.GetTemp_PlusvaliasDividendos(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta.OrderByDescending(c=>c.Total);


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_PlusvaliasDividendos)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempPlusvaliasDividendos_Sel_object = (T_PlusvaliasDividendos)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var plusvaliasDividendos_temp = dbcontext.Temp_PlusvaliasDividendos.FirstOrDefault(p => p.Id == id);

                if (plusvaliasDividendos_temp != null)
                {
                    plusvaliasDividendos_temp.DividendosNetos = tempPlusvaliasDividendos_Sel_object.DividendosNetos;
                    plusvaliasDividendos_temp.PlusvaliasMinusvalias = tempPlusvaliasDividendos_Sel_object.PlusvaliasMinusvalias;
                   
                }
                try
                {
                    dbcontext.SaveChanges();
                    tempPlusvaliasDividendos_Sel_object.Total = ((tempPlusvaliasDividendos_Sel_object.DividendosNetos == null) ? 0 : tempPlusvaliasDividendos_Sel_object.DividendosNetos) + ((tempPlusvaliasDividendos_Sel_object.PlusvaliasMinusvalias == null) ? 0 : tempPlusvaliasDividendos_Sel_object.PlusvaliasMinusvalias);

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
