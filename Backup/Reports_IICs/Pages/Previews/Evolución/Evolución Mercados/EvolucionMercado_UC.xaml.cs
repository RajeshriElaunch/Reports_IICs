using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.Helpers;
using Reports_IICs.DataAccess.Secciones;

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados
{
    class RedPrice
    {

        public string Isin { get; set; }
        public string DescripcionInstrumento { get; set; }
        public System.DateTime? FechaCotizacion { get; set; }
        public System.DateTime? FechaReport { get; set; }

        public RedPrice()
        {
        }
        public RedPrice(string isin, string descripcionInstrumento, DateTime? fechaCotizacion, DateTime? fechaReport)
        {
            this.Isin = isin;
            this.DescripcionInstrumento = descripcionInstrumento;
            this.FechaCotizacion = fechaCotizacion;
            this.FechaReport = fechaReport;
        }
    }

    /// <summary>
    /// Lógica de interacción para EvolucionMercado_UC.xaml
    /// </summary>
    public partial class EvolucionMercado_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        //List<Temp_EvolucionMercados> _evo = new List<Temp_EvolucionMercados>();
        List<RedPrice> PriceErrorsDetected = new List<RedPrice>();

        public EvolucionMercado_UC()
        {
            InitializeComponent();
        }

        public EvolucionMercado_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            getData();

        }

        private void getData()
        {
            var evo = EvolucionMercados.Get_Temp_EvolucionMercados(_plantilla.CodigoIc);
            //var evo = EvolucionMercados_DA.GetTemp_EvolucionMercados(_plantilla.CodigoIc, null);
            this.myGrid.ItemsSource = evo;
            //this.myGrid.ItemsSource = EvolucionMercados.Get_Temp_EvolucionMercados(_plantilla.CodigoIc);
            //this.clubsGrid.ItemsSource = EvolucionMercados.GetClubs();

            //FECHA VALIDADA POR LA GESTORA
            this.myGrid.Columns[2].Header = String.Format("{0:dd/MM/yyyy}", Utils.GetFechaInicio(_plantilla, _fecha, typeof(Temp_EvolucionMercados)));
            this.myGrid.Columns[3].Header = String.Format("{0:dd/MM/yyyy}", _fecha); 


            #region Detect dif Price
            DateTime? DateTimeNull = null;

            foreach (EvolucionMercados item in evo)
            {
                if (Utils.GetFechaInicio(_plantilla, _fecha, typeof(Temp_EvolucionMercados)) != item.FechaCotizacionDesde)
                {
                    PriceErrorsDetected.Add(new RedPrice(item.Isin, item.Descripcion, item.FechaCotizacionDesde, DateTimeNull));
                }

                if (_fecha != item.FechaCotizacionHasta)
                {
                    PriceErrorsDetected.Add(new RedPrice(item.Isin, item.Descripcion, DateTimeNull, item.FechaCotizacionHasta));
                }
            }
            myErrorGrid.ItemsSource = PriceErrorsDetected;

            if (PriceErrorsDetected.Count > 0)
            {
                ErrorPrices.Visibility = System.Windows.Visibility.Visible;
            }
            #endregion
        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((EvolucionMercados)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempEvoMercados_Sel_object = (EvolucionMercados)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            
            Temp_EvolucionMercados EvoMercados_temp = new Temp_EvolucionMercados();
           
            EvoMercados_temp.Id = id;
            EvoMercados_temp.CodigoIC = tempEvoMercados_Sel_object.CodigoIC;
            EvoMercados_temp.CotizaDivDesde = tempEvoMercados_Sel_object.CotizaDivDesde;
            EvoMercados_temp.CotizaDivHasta = tempEvoMercados_Sel_object.CotizaDivHasta;
            EvoMercados_temp.Descripcion = tempEvoMercados_Sel_object.Descripcion;
            EvoMercados_temp.FechaCotizacionDesde = tempEvoMercados_Sel_object.FechaCotizacionDesde;
            EvoMercados_temp.FechaCotizacionHasta = tempEvoMercados_Sel_object.FechaCotizacionHasta;
            EvoMercados_temp.Isin = tempEvoMercados_Sel_object.Isin;

            var VarCotizacionDiv = decimal.Round(Utils.PorcentajeVariacion(tempEvoMercados_Sel_object.CotizaDivDesde, tempEvoMercados_Sel_object.CotizaDivHasta), 2);
            EvoMercados_temp.VarCotizaDivisa = VarCotizacionDiv;
            EvoMercados_temp.VarCotizaEuros = tempEvoMercados_Sel_object.VarCotizaEuros;

            ((EvolucionMercados)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).VarCotizaDivisa = VarCotizacionDiv;
            ((EvolucionMercados)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).VarCotizaEuros = tempEvoMercados_Sel_object.VarCotizaEuros;
            var fila = this.myGrid.Items.IndexOf(this.myGrid.SelectedItem);


            try
            {
                EvolucionMercados_DA.Update_GetTemp_EvolucionMercados_Item(EvoMercados_temp);                
            }
            catch (Exception ex)
            {
                throw ex;
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
                if (_fecha != ((EvolucionMercados)row.Item).FechaCotizacionHasta)
                {
                    //Paint Cell color RED

                    var converter = new System.Windows.Media.BrushConverter();
                    var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");

                    row.Cells[2].Background = brush;

                    var ColorBrush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFFFFF");
                    row.Cells[2].Foreground = ColorBrush;


                }
                
                if (Utils.GetFechaInicio(_plantilla, _fecha, typeof(Temp_EvolucionMercados)) != ((EvolucionMercados)row.Item).FechaCotizacionDesde)
                {
                    //Paint Cell color RED

                    var converter = new System.Windows.Media.BrushConverter();
                    var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");

                    row.Cells[1].Background = brush;

                    var ColorBrush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFFFFF");
                    row.Cells[1].Foreground = ColorBrush;


                }

            }
        }

        private void myErrorGrid_RowLoaded(object sender, RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;


            if (row != null)

            {

                //Paint Cell color RED

                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#c86464");

                row.Cells[0].Background = brush;
                row.Cells[1].Background = brush;
                row.Cells[2].Background = brush;
                row.Cells[3].Background = brush;

                var ColorBrush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFFFFF");
                row.Cells[0].Foreground = ColorBrush;
                row.Cells[1].Foreground = ColorBrush;
                row.Cells[2].Foreground = ColorBrush;
                row.Cells[3].Foreground = ColorBrush;



            }

        }

    }
}
