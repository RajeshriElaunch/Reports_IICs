using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.IIC_ComprasVentasEjercicio
{
    /// <summary>
    /// Lógica de interacción para IIC_ComprasVentasEjercicio_UC.xaml
    /// </summary>
    public partial class IIC_ComprasVentasEjercicio_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public IIC_ComprasVentasEjercicio_UC()
        {
            InitializeComponent();
        }

        public IIC_ComprasVentasEjercicio_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

           
            var IIC_EjercicioCompras = DataAccess.Reports.Report_IIC_ComprasVentasEjercicio_DA.GetTemp_IIC_ComprasVentasEjercicio(plantilla.CodigoIc, isin, "Compra").OrderBy(c=>c.Fecha);
            var IIC_EjercicioVentas = DataAccess.Reports.Report_IIC_ComprasVentasEjercicio_DA.GetTemp_IIC_ComprasVentasEjercicio(plantilla.CodigoIc, isin, "Venta").OrderBy(c => c.Fecha);
            this.myGridCompra.ItemsSource = IIC_EjercicioCompras;
            this.myGridVenta.ItemsSource = IIC_EjercicioVentas;
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_IIC_ComprasVentasEjercicio)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempOperacionesRentaVariable_Sel_object = (T_IIC_ComprasVentasEjercicio)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var rentaVariable_temp = dbcontext.Temp_IIC_ComprasVentasEjercicio.FirstOrDefault(p => p.Id == id);

                if (rentaVariable_temp != null)
                {
                    rentaVariable_temp.Cantidad = tempOperacionesRentaVariable_Sel_object.Cantidad;
                    rentaVariable_temp.Precio = tempOperacionesRentaVariable_Sel_object.Precio;
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
