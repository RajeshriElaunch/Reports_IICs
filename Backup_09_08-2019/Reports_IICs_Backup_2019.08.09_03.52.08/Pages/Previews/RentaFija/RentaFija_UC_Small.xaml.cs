using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;


namespace Reports_IICs.Pages.Previews.RentaFija
{
    /// <summary>
    /// Lógica de interacción para RentaFija_UC.xaml
    /// </summary>
    public partial class RentaFija_UC_Small : UserControl
    {

        private Plantilla _plantilla;
        private List<Temp_RentaFija> _temp;
        protected DateTime _fecha;
        public RentaFija_UC_Small()
        {
            InitializeComponent();
        }

        public RentaFija_UC_Small(Plantilla plantilla, DateTime fecha, string titulo, int grupo, List<Temp_RentaFija> temp)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;
            var fechaIni = Utils.GetFechaInicio(plantilla, fecha);

            this.LabelTitulo.Content = titulo;

            _temp = temp.Where(w => w.Grupo == grupo).ToList();

            //Los items del Grid serán del tipo T_RentaFija
            var lista = new List<T_RentaFija>();
            foreach (var item in _temp)
            {
                var obj = new T_RentaFija();

                Utils.CopyPropertyValues(item, obj);
                lista.Add(obj);
            }

            this.myGrid.ItemsSource = lista;


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            //int id = ((T_RentaFija)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var sel = (T_RentaFija)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            try
            {
                RentaFija_DA.UpdateTempById(sel);
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

        
    }

    public partial class TotalConverter : IValueConverter
    {
        #region IValueConverter Members  

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = value as Temp_RentaFija;
            if (temp == null)
            {
                //throw new ArgumentException("value must be a Club", "value");
            }

            return temp.PosicionCartera + temp.PosicionesCerradas;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
