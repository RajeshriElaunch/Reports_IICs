using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO
{
    /// <summary>
    /// Lógica de interacción para RF_ComprasyVentasRealizadasDuranteEjercicio_UC.xaml
    /// </summary>
    public partial class RF_ComprasyVentasRealizadasDuranteEjercicio_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        private bool paint_line;
        private string _isin;
        private bool _Escompra;

        public RF_ComprasyVentasRealizadasDuranteEjercicio_UC()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            if (e.AddedItems.Count > 0)
            {

                if (((Reports_IICs.ViewModels.Plantillas.Action)((object[])e.AddedItems)[0]).Name == "Eliminar")
                {
                    bool? dialogResult = null;
                    Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
                    parameters.Content = "¿Esta seguro que desea eliminar?";

                    parameters.Closed = (w, a) =>
                    {
                        dialogResult = a.DialogResult;
                    };

                    parameters.Header = "Eliminar";

                    Telerik.Windows.Controls.RadWindow.Confirm(parameters);

                    if (dialogResult == true)
                    {

                        T_RFComprasyVentasRealizadasEjercicio selectedItem = (T_RFComprasyVentasRealizadasEjercicio)this.myGrid.SelectedItem;

                        using (dbcontext = new Reports_IICSEntities())
                        {
                            var compra_temp = dbcontext.Temp_RFComprasVentasEjercicio.FirstOrDefault(p => p.Id == selectedItem.Id);

                            if (compra_temp != null)
                            {

                                dbcontext.Temp_RFComprasVentasEjercicio.Remove(compra_temp);
                            }
                            try
                            {
                                dbcontext.SaveChanges();
                                var renta = DataAccess.Reports.RFComprasyVentasRealizadasDuranteEjercicio_DA.GetTemp_RFComprasyVentasRealizadasEjercicio(_plantilla.CodigoIc, _isin, _Escompra);
                                
                                this.myGrid.ItemsSource = renta;

                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                    else
                    {
                        //cancel
                        //e.Cancel = true;


                    }

                }
            }
         }

        public RF_ComprasyVentasRealizadasDuranteEjercicio_UC(Plantilla plantilla, string isin, DateTime fecha,bool Escompra)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _isin = isin;
            _fecha = fecha;
            _Escompra = Escompra;
            paint_line = true;
            var renta = DataAccess.Reports.RFComprasyVentasRealizadasDuranteEjercicio_DA.GetTemp_RFComprasyVentasRealizadasEjercicio(plantilla.CodigoIc, isin, Escompra);
            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            this.myGrid.ItemsSource = renta;


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_RFComprasyVentasRealizadasEjercicio)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRFComprasYVentasRealizadasEjercicio_Sel_object = (T_RFComprasyVentasRealizadasEjercicio)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var compra_temp = dbcontext.Temp_RFComprasVentasEjercicio.FirstOrDefault(p => p.Id == id);

                if (compra_temp != null)
                {
                    compra_temp.Cantidad = tempRFComprasYVentasRealizadasEjercicio_Sel_object.Cantidad;
                    compra_temp.Precio = tempRFComprasYVentasRealizadasEjercicio_Sel_object.Precio;
                   

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

                if (!((T_RFComprasyVentasRealizadasEjercicio)row.Item).Visto)
                {
                    if(paint_line)
                    {
                        //Paint Cell color RED

                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");

                        //row.Background = brush;
                        //row.BorderBrush = brush;

                        Thickness myThickness = new Thickness();
                        myThickness.Bottom = 0;
                        myThickness.Left = 0;
                        myThickness.Right = 0;
                        myThickness.Top = 2;

                        row.BorderThickness = myThickness;
                        //row.Cells[1].Background = brush;

                        var ColorBrush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFFFFF");
                        //row.Cells[1].Foreground = ColorBrush;
                        // row.Foreground = ColorBrush;

                        paint_line = false;
                    }



                }

            }
        }

    }
}
