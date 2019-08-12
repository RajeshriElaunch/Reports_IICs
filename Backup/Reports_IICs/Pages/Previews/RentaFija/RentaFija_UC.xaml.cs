using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;


namespace Reports_IICs.Pages.Previews.RentaFija
{
    /// <summary>
    /// Lógica de interacción para RentaFija_UC.xaml
    /// </summary>
    public partial class RentaFija_UC : UserControl
    {

        private Plantilla _plantilla;
        private List<Temp_RentaFija> _temp;
        protected DateTime _fecha;
        public RentaFija_UC()
        {
            InitializeComponent();
        }

        public RentaFija_UC(Plantilla plantilla, DateTime fecha, string titulo, int grupo, List<Temp_RentaFija> temp)
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

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
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


        //private List<usp_gestio_pro_13_Result> getItemPro13Sel(Temp_RentaFija temp)
        
        private void myGrid_DataLoaded(object sender, EventArgs e)
        {
            ((RadGridView)sender).ExpandAllGroups();
        }
        
    }
}
