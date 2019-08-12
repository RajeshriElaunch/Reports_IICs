using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;

namespace Reports_IICs.Pages.Previews.COMPRA_VENTA
{
    /// <summary>
    /// Lógica de interacción para CompraVentaRespectoPrecioAdquisicion_UC.xaml
    /// </summary>
    public partial class CompraVentaRespectoPrecioAdquisicion_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;        

        public CompraVentaRespectoPrecioAdquisicion_UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Los ids con el orden que utiliza el procedimiento que muestra los datos en el report
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <param name="idsOrdenados"></param>
        public CompraVentaRespectoPrecioAdquisicion_UC(Plantilla plantilla, string isin, DateTime fecha, List<int> idsOrdenados)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;            

            var renta = DataAccess.Reports.CompraVentaRespectoPrecioAdquisicion_DA.GetTemp_CompraVentaRespectoPrecioAdquisicion(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;

            //this.radGridView1.Rows[0].Cells[0].Value = newValue;


            //this.myGrid.Columns[2].Header = Utils.GetUltimoDiaAñoAnterior(_fecha);
            //this.myGrid.Columns[3].Header = _fecha;
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        public event EventHandler CellEditEnded;


        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            var tempCompraVenta_Sel_object = (T_CompraVentaPrecAdq)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            try
            {
                CompraVentaPrecAdq_DA.Update_DatoAlmacenadosPreview(tempCompraVenta_Sel_object);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            /*
            int id = ((T_CompraVentaPrecAdq)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempCompraVenta_Sel_object = (T_CompraVentaPrecAdq)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            decimal? titulos = tempCompraVenta_Sel_object.TitulosNew;
            decimal? Adquisicion = tempCompraVenta_Sel_object.AdquisicionNew;
            decimal? Efectivo = tempCompraVenta_Sel_object.EfectivoNew; //(titulos * Adquisicion) * -1;

            tempCompraVenta_Sel_object.Perdida = (tempCompraVenta_Sel_object.EfectivoNew < 0? tempCompraVenta_Sel_object.EfectivoNew : 0);
            tempCompraVenta_Sel_object.Beneficio = (tempCompraVenta_Sel_object.EfectivoNew > 0 ? tempCompraVenta_Sel_object.EfectivoNew : 0);

            using (dbcontext = new Reports_IICSEntities())
            {
                //Actualizamos la tabla temporal que se utilizará para pintar el report
                T_CompraVentaPrecAdq CompraVenta_temp = new T_CompraVentaPrecAdq();
                 CompraVenta_temp = CompraVentaPrecAdq_DA.Get_Temp_CompraVentaPrecAdqById(id);
                
                if (CompraVenta_temp != null)
                {
                    try
                    {
                        #region update Object
                        CompraVenta_temp.Titulos = titulos;
                        CompraVenta_temp.Adquisicion = Adquisicion;
                        CompraVenta_temp.Efectivo = 0;
                        CompraVenta_temp.Efectivo = Efectivo;
                        #endregion

                        #region update Database

                        var CompraVentaToSave = dbcontext.Temp_CompraVentaPrecAdq.Where(c => c.Id == id).FirstOrDefault();
                        if (CompraVentaToSave != null)
                        {
                            CompraVentaToSave.Titulos = titulos;
                            CompraVentaToSave.Adquisicion = Adquisicion;
                            CompraVentaToSave.Efectivo = Efectivo;
                        }

                        dbcontext.SaveChanges();

                        
                        #endregion
                    }
                    catch (Exception ex)
                    {

                    }
                }

                
            }
            */
            if (CellEditEnded != null)
            {
                CellEditEnded(this, new EventArgs());
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

    }
}
