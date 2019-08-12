using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.RVCOMPRAS_REALIZADAS_DURANTE_EL_EJERCICIO
{
    /// <summary>
    /// Lógica de interacción para RV_ComprarRealizadasDuranteEjercicio_UC.xaml
    /// </summary>
    public partial class RV_ComprarRealizadasDuranteEjercicio_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        public RV_ComprarRealizadasDuranteEjercicio_UC()
        {
            InitializeComponent();
        }

        public RV_ComprarRealizadasDuranteEjercicio_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.RVComprasRealizadasEjercicio_DA.GetTemp_RVComprasRealizadasEjercicio(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;
            

            foreach (var item in this.myGrid.Columns)
            {
                if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            }
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_RVComprasRealizadasEjercicio)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRVComprasRealizadasEjercicio_Sel_object = (T_RVComprasRealizadasEjercicio)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var compra_temp = dbcontext.Temp_RVComprasRealizadasEjercicio.FirstOrDefault(p => p.Id == id);

                if (compra_temp != null)
                {
                    compra_temp.Cantidad = tempRVComprasRealizadasEjercicio_Sel_object.Cantidad;
                    compra_temp.Precio = tempRVComprasRealizadasEjercicio_Sel_object.Precio;
                    if(!string.IsNullOrEmpty(tempRVComprasRealizadasEjercicio_Sel_object.CotizacionFechaFin))
                    {
                        if (!tempRVComprasRealizadasEjercicio_Sel_object.Vendido) compra_temp.CotizacionFechaFin = decimal.Parse(tempRVComprasRealizadasEjercicio_Sel_object.CotizacionFechaFin);
                    }
                    
                    compra_temp.DividendosCobrados = tempRVComprasRealizadasEjercicio_Sel_object.DividendosCobrados;
                    if(!string.IsNullOrEmpty(tempRVComprasRealizadasEjercicio_Sel_object.CotizacionFechaFin))
                    {
                        if (tempRVComprasRealizadasEjercicio_Sel_object.Vendido)
                        {
                            tempRVComprasRealizadasEjercicio_Sel_object.Variacion = "-";
                        }
                        else
                        {
                            tempRVComprasRealizadasEjercicio_Sel_object.Variacion = String.Format("{0:P2}", (tempRVComprasRealizadasEjercicio_Sel_object.Precio - decimal.Parse(tempRVComprasRealizadasEjercicio_Sel_object.CotizacionFechaFin)) / tempRVComprasRealizadasEjercicio_Sel_object.Precio * -1);
                        }
                           
                    }
                    
                }
                try
                {
                    dbcontext.SaveChanges();
                    //var renta = DataAccess.Reports.RVComprasRealizadasEjercicio_DA.GetTemp_RVComprasRealizadasEjercicio(_plantilla.CodigoIc, null);

                    //this.myGrid.ItemsSource = renta;
                   
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
                if(((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio!= null && ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin!=null)
                {
                    if (!((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                    {
                        var precio = ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio;
                        var cotFechaFin = ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin;

                        //((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = String.Format("{0:P2}", (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio - decimal.Parse(((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin)) / ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio * -1) ;

                        string variacion = "-";
                        if (precio != null && precio != 0 && !string.IsNullOrEmpty(cotFechaFin))
                        {
                           if(precio>0) variacion = String.Format("{0:P2}", Convert.ToDecimal(cotFechaFin) / precio * -1);
                        }

                        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = variacion;

                    }
                    else
                    {
                        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = "-";
                    }
                       
                }
                
                if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                {
                    ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin = "Vendido";
                   
                }
            }
        }

        private void myGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {
           

           if( e.Cell.Column.Name == "Cotizacion" )
            {
               if( ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
                {
                    e.Cancel = true;
                }
            }

          
        }
    }
}
