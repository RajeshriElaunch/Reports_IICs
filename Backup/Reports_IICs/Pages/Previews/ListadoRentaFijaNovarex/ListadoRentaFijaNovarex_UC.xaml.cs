using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.ListadoRentaFijaNovarex
{
    /// <summary>
    /// Lógica de interacción para ListadoRentaFijaNovarex_UC.xaml
    /// </summary>
    public partial class ListadoRentaFijaNovarex_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public ListadoRentaFijaNovarex_UC()
        {
            InitializeComponent();
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        public ListadoRentaFijaNovarex_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.ListadoRentaFijaNovarex_DA.GetTemp_ListadoRentaFijaNovarex(plantilla.CodigoIc);

            this.myGrid.ItemsSource = renta;
            #region Calculate Media
            double VidaMedia = 0;
            double totalPesos = 0;
            //DateTime origin = new DateTime(2014, 12, 31);
            DateTime origin = _fecha;
            double Tir = 0;
            double Tirtotal = 0;
            #region Calculate SumTotal VidaMedia
            for (int i = 0; i < renta.Count; i++)
            {
                // VidaMedia = VidaMedia + DifTotalYears(origin,((T_ListadoRentaFijaNovarex)(renta)[i]).Amortizacion.Value);

                var pesos = ((T_ListadoRentaFijaNovarex)(renta)[i]).EfectivoEuros;
                totalPesos = totalPesos + Convert.ToDouble(pesos);
                TimeSpan DifDays= (((T_ListadoRentaFijaNovarex)(renta)[i]).Amortizacion.Value- origin);
                Tir = Convert.ToDouble(((T_ListadoRentaFijaNovarex)(renta)[i]).TIR.Value);
                Tirtotal = Tirtotal + Tir * Convert.ToDouble(pesos);

                VidaMedia = VidaMedia + (DifDays.Days*Convert.ToDouble(pesos));

            }
            double Tirmp = Tirtotal / totalPesos;
            double stotal = (VidaMedia / totalPesos) / 365;
            #endregion
            this.Txt_TirmediaPonderada.Text = String.Format("{0:N3}", Tirmp) + "%";
            this.Txt_VidamediaPonderada.Text = String.Format("{0:N2}", stotal)  + " AÑOS";
            #endregion
        }



        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_ListadoRentaFijaNovarex)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_ListadoRentaFijaNovarex)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                T_ListadoRentaFijaNovarex RentaCartera_temp = ListadoRentaFijaNovarex_DA.Get_Temp_ListadoRentaFijaNovarexById(id);
                if (RentaCartera_temp != null)
                {
                   
                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {
                           
                            #region update Object
                           

                            RentaCartera_temp.TIR = tempRentaCartera_Sel_object.TIR; 
                            RentaCartera_temp.EfectivoEuros = tempRentaCartera_Sel_object.EfectivoEuros;
                            #endregion

                            #region update Database
                            
                            var RentaParticipeToSave = dbcontext.Temp_ListadoRentaFijaNovarex.Where(c => c.Id == id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.TIR = RentaCartera_temp.TIR.Value;
                                RentaParticipeToSave.EfectivoEuros = RentaCartera_temp.EfectivoEuros;
                            }

                            dbcontext.SaveChanges();
                            #endregion
                        }
                        catch (Exception)
                        {

                        }

                    }
                    #endregion

                }
            }

            #region Calculate Media
            var renta = DataAccess.Reports.ListadoRentaFijaNovarex_DA.GetTemp_ListadoRentaFijaNovarex(_plantilla.CodigoIc);

            double VidaMedia = 0;
            double totalPesos = 0;
            //DateTime origin = new DateTime(2014, 12, 31);
            DateTime origin = _fecha;
            double Tir = 0;
            double Tirtotal = 0;
            #region Calculate SumTotal VidaMedia
            for (int i = 0; i < renta.Count; i++)
            {

                // VidaMedia = VidaMedia + DifTotalYears(origin,((T_ListadoRentaFijaNovarex)(renta)[i]).Amortizacion.Value);

                var pesos = ((T_ListadoRentaFijaNovarex)(renta)[i]).EfectivoEuros;
                totalPesos = totalPesos + Convert.ToDouble(pesos);
                TimeSpan DifDays = (((T_ListadoRentaFijaNovarex)(renta)[i]).Amortizacion.Value - origin);
                Tir = Convert.ToDouble(((T_ListadoRentaFijaNovarex)(renta)[i]).TIR.Value);
                Tirtotal = Tirtotal + Tir * Convert.ToDouble(pesos);

                VidaMedia = VidaMedia + (DifDays.Days * Convert.ToDouble(pesos));

            }
            double Tirmp = Tirtotal / totalPesos;
            double stotal = (VidaMedia / totalPesos) / 365;
            #endregion
            this.Txt_TirmediaPonderada.Text = String.Format("{0:N3}", Tirmp) + "%";
            this.Txt_VidamediaPonderada.Text = String.Format("{0:N2}", stotal) + " AÑOS";
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

    }

   
}
