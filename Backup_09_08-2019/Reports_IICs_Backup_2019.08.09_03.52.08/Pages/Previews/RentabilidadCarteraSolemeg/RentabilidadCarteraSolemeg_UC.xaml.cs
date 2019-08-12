using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.RentabilidadCarteraSolemeg
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraSolemeg_UC.xaml
    /// </summary>
    public partial class RentabilidadCarteraSolemeg_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        private string _isin;
        public RentabilidadCarteraSolemeg_UC()
        {
            InitializeComponent();
        }

       
        public RentabilidadCarteraSolemeg_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;
            _isin = isin;

            var operGrupo1 = Report_RentabilidadCarteraSolemeg_DA.GetTemp_RentabilidadCarteraSolemeg(plantilla.CodigoIc, isin, 1);
            var operGrupo2 = Report_RentabilidadCarteraSolemeg_DA.GetTemp_RentabilidadCarteraSolemeg(plantilla.CodigoIc, isin, 2);
            var operGrupo3 = Report_RentabilidadCarteraSolemeg_DA.GetTemp_RentabilidadCarteraSolemegGroup3(plantilla.CodigoIc, isin, 3);

            this.myGridGrupo1.ItemsSource = operGrupo1;
            this.myGridGrupo2.ItemsSource = operGrupo2;
            this.myGridGrupo3.ItemsSource = operGrupo3;

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            string CodigoICAux = string.Empty;
            int grupoAux = 0;
            string IsinAux = string.Empty;

            int id = ((T_RentabilidadCarteraSolemeg)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentabilidadCarteraSolemeg_Sel_object = (T_RentabilidadCarteraSolemeg)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                #region Temp_RentabilidadCarteraSolemeg
                var rentaVariable_temp = dbcontext.Temp_RentabilidadCarteraSolemeg.FirstOrDefault(p => p.Id == id);

                if (rentaVariable_temp != null)
                {
                    CodigoICAux = rentaVariable_temp.CodigoIC;
                    grupoAux = rentaVariable_temp.Grupo;
                    IsinAux = rentaVariable_temp.ISIN;

                    rentaVariable_temp.NumeroTitulos = tempRentabilidadCarteraSolemeg_Sel_object.NumeroTitulos;
                    rentaVariable_temp.PrecioCompraOriginal = tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraOriginal;
                    rentaVariable_temp.PrecioCompraSolemeg = tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraSolemeg;
                    rentaVariable_temp.PrecioActual = tempRentabilidadCarteraSolemeg_Sel_object.PrecioActual;
                    rentaVariable_temp.Vendido = tempRentabilidadCarteraSolemeg_Sel_object.Vendido;

                }
                try
                {
                    dbcontext.SaveChanges();

                }
                catch (Exception)
                {

                }
                #endregion

                #region RentabilidadCarteraSolemegs
                var rentaCartera_temp = dbcontext.RentabilidadCarteraSolemegs.FirstOrDefault(p => p.CodigoIC == CodigoICAux && p.Grupo== grupoAux && p.ISIN == IsinAux);

                if (rentaCartera_temp != null)
                {
                   
                    rentaCartera_temp.Vendido = tempRentabilidadCarteraSolemeg_Sel_object.Vendido.Value;

                }
                try
                {
                    dbcontext.SaveChanges();

                }
                catch (Exception)
                {

                }
                #endregion
            }

            #region Correct %
          
                tempRentabilidadCarteraSolemeg_Sel_object.RentabilidadOrigen = (tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraOriginal > 0) ? ((tempRentabilidadCarteraSolemeg_Sel_object.PrecioActual - tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraOriginal) / tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraOriginal) : 0;
                tempRentabilidadCarteraSolemeg_Sel_object.RentabilidadSolemeg = (tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraSolemeg > 0) ? ((tempRentabilidadCarteraSolemeg_Sel_object.PrecioActual - tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraSolemeg) / tempRentabilidadCarteraSolemeg_Sel_object.PrecioCompraSolemeg) : 0;
            #endregion

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
