using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.Gráficos_Burbujas
{
    /// <summary>
    /// Lógica de interacción para Burbujas_SmallBig_UC.xaml
    /// </summary>
    public partial class Burbujas_SmallBig_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public Burbujas_SmallBig_UC()
        {
            InitializeComponent();
        }

        public Burbujas_SmallBig_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;

            getData();
        }

        private void getData()
        {
           
            var renta = DataAccess.Reports.Burbujas_SmallBig_DA.GetTemp_Burbujas_SmallBig(_plantilla.CodigoIc, null);

            this.myGrid.ItemsSource = renta;


        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Burbujas_SmallBig)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempBurbujas_SmallBig_Sel_object = (T_Burbujas_SmallBig)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            Temp_Burbujas Burbujas_SmallBig_temp = new Temp_Burbujas();

            Burbujas_SmallBig_temp.Id = id;

            Burbujas_SmallBig_temp.CodigoIC = tempBurbujas_SmallBig_Sel_object.CodigoIC;
            Burbujas_SmallBig_temp.CapitalizacionBursatilEuros = tempBurbujas_SmallBig_Sel_object.CapitalizacionBursatilEuros;
            Burbujas_SmallBig_temp.DescripcionInstrumento = tempBurbujas_SmallBig_Sel_object.DescripcionInstrumento;
            Burbujas_SmallBig_temp.DescuentoFundamental = tempBurbujas_SmallBig_Sel_object.DescuentoFundamental;
            Burbujas_SmallBig_temp.FechaCotizacion = tempBurbujas_SmallBig_Sel_object.FechaCotizacion;
            Burbujas_SmallBig_temp.Isin = tempBurbujas_SmallBig_Sel_object.Isin;
            Burbujas_SmallBig_temp.PorcentajeCartera = tempBurbujas_SmallBig_Sel_object.PorcentajeCartera;
            Burbujas_SmallBig_temp.PuntuacionSmallBig = tempBurbujas_SmallBig_Sel_object.PuntuacionSmallBig;
            Burbujas_SmallBig_temp.PuntuacionValueGrowth = tempBurbujas_SmallBig_Sel_object.PuntuacionValueGrowth;
            Burbujas_SmallBig_temp.PuntuacionUta = tempBurbujas_SmallBig_Sel_object.PuntuacionUta;
            Burbujas_SmallBig_temp.TickerBloomberg = tempBurbujas_SmallBig_Sel_object.TickerBloomberg;
            Burbujas_SmallBig_temp.Visible = tempBurbujas_SmallBig_Sel_object.Visible.Value;

            //var fila = this.myGrid.Items.IndexOf(this.myGrid.SelectedItem);


            try
            {
                DataAccess.Reports.Burbujas_SmallBig_DA.Update_GetTemp_Burbujas_SmallBig_Item(Burbujas_SmallBig_temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void myGrid_DataLoaded(object sender, EventArgs e)
        {
           // ((RadGridView)sender).ExpandAllGroups();

        }

        private void myGrid_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;


            if (row != null)

            {
              

            }
        }

        private void myErrorGrid_RowLoaded(object sender, RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;


            if (row != null)

            {

                //Paint Cell color RED

                //var converter = new System.Windows.Media.BrushConverter();
                //var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");

                //row.Cells[0].Background = brush;
                //row.Cells[1].Background = brush;
                //row.Cells[2].Background = brush;
                //row.Cells[3].Background = brush;

                //var ColorBrush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFFFFF");
                //row.Cells[0].Foreground = ColorBrush;
                //row.Cells[1].Foreground = ColorBrush;
                //row.Cells[2].Foreground = ColorBrush;
                //row.Cells[3].Foreground = ColorBrush;



            }

        }
    }
}
