using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV
{
    class RedPrice
    {

        public string Isin { get; set; }
        public string DescripcionInstrumento { get; set; }
        public System.DateTime FechaCotizacion { get; set; }
        public System.DateTime FechaReport { get; set; }

        public RedPrice( )
        {
        }
        public RedPrice(string descripcionInstrumento, DateTime fechaCotizacion, DateTime fechaReport)
        {
            //this.Isin = isin;
            this.DescripcionInstrumento = descripcionInstrumento;
            this.FechaCotizacion = fechaCotizacion;
            this.FechaReport = fechaReport;
        }
    }

    /// <summary>
    /// Interaction logic for RatiosCarteraRV_UC.xaml
    /// </summary>
    public partial class RatiosCarteraRV_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        List<RedPrice> PriceErrorsDetected = new List<RedPrice>();
        public double Ancho;

        public RatiosCarteraRV_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;
            Ancho = 1034;

            var rat = RatiosCarteraRV_DA.GetTemp_RatiosCarteraRV(plantilla.CodigoIc).ToList();
            this.myGrid.ItemsSource = rat;
            populateHeaderLabels(fecha);

            #region Detect dif Price
            foreach (Temp_RatiosCarteraRV item in rat)
            {
                if (_fecha != item.FechaCotizacion && item.FechaCotizacion != null)
                {
                    PriceErrorsDetected.Add(new RedPrice(item.DescripcionInstrumento, (DateTime)item.FechaCotizacion, _fecha));
                }
            }
            myErrorGrid.ItemsSource = PriceErrorsDetected;

            if(PriceErrorsDetected.Count>0)
            {
                ErrorPrices.Visibility = System.Windows.Visibility.Visible;
            }
            #endregion
        }

        private void populateHeaderLabels(DateTime fecha)
        {
            this.labelValorAño.Content = fecha.Year.ToString();
            this.labelBpaAño.Content = fecha.Year.ToString();
            this.labelBpaPrevision.Content = (fecha.Year+1).ToString();
            this.labelRentabilidadDividendoAño.Content = fecha.Year.ToString();
            this.labelRentabilidadDividendoPrevision.Content = (fecha.Year + 1).ToString();
            this.labelPerAño.Content = fecha.Year.ToString();
            this.labelPerPrevision.Content = (fecha.Year + 1).ToString();
        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((Reports_IICs.DataModels.Temp_PRO_11)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var pro11_Sel_object = (Temp_PRO_11)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            Temp_PRO_11 pro11_temp = dbcontext.Temp_PRO_11.FirstOrDefault(p => p.Id == id);
            if (pro11_temp != null)
            {
                //pro11_temp.Cambio = pro11_Sel_object.Cambio;                
            }
            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception )
            {

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
                if (_fecha!= ((Reports_IICs.DataModels.Temp_RatiosCarteraRV)row.Item).FechaCotizacion)
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
