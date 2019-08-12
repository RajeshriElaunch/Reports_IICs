using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;


namespace Reports_IICs.Pages.Previews.OPERACIONES_RENTA_VARIABLE__II_
{
    /// <summary>
    /// Lógica de interacción para OperacionesRentaVariable_UC.xaml
    /// </summary>
    public partial class OperacionesRentaVariable_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        public OperacionesRentaVariable_UC()
        {
            InitializeComponent();
        }

        public OperacionesRentaVariable_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;
            
            var operRentaVarCompras = DataAccess.Reports.ReportOperacionesRentaVariable_II_DA.GetTemp_OperacionesRentaVariable_II(plantilla.CodigoIc, "COMPRA");
            var operRentaVarVentas = DataAccess.Reports.ReportOperacionesRentaVariable_II_DA.GetTemp_OperacionesRentaVariable_II(plantilla.CodigoIc, "VENTA");
            this.myGridCompra.ItemsSource = operRentaVarCompras;
            this.myGridVenta.ItemsSource = operRentaVarVentas;

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_OperacionesRentaVariable_II)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var sel = (T_OperacionesRentaVariable_II)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var rentaVariable_temp = dbcontext.Temp_OperacionesRentaVariable_II.FirstOrDefault(p => p.Id == id);

                if (rentaVariable_temp != null)
                {
                    rentaVariable_temp.Fecha = sel.Fecha;
                    rentaVariable_temp.Cantidad = sel.Cantidad;
                    rentaVariable_temp.Precio = sel.Precio;
                    rentaVariable_temp.EfectivoEuros = sel.EfectivoEuros;
                    rentaVariable_temp.PrecioEuros = sel.PrecioEuros;

                    //campos autocalculados
                    actualizarTotalesEnPantalla(sel);

                    rentaVariable_temp.CosteMedio = sel.CosteMedio;
                    rentaVariable_temp.GanPerVsCosMed = sel.GanPerVsCosMed;
                }
                try
                {
                    dbcontext.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private void actualizarTotalesEnPantalla(T_OperacionesRentaVariable_II sel)
        {
            //Actualizamos los totales en pantalla (Preview)
            if (sel != null)
            {
                sel.EfectivoEuros = sel.PrecioEuros * sel.Cantidad;
                if (sel.CosteMedio != 0)
                {
                    sel.GanPerVsCosMed = (sel.PrecioEuros / sel.CosteMedio)-1;
                }
                else
                {
                    sel.GanPerVsCosMed = null;
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
