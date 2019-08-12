using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;


namespace Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV1
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraV1_UC.xaml
    /// </summary>
    public partial class RentabilidadCarteraV1_UC : UserControl
    {

        private Plantilla _plantilla;
        protected DateTime _fecha;

        public RentabilidadCarteraV1_UC()
        {
            InitializeComponent();
        }

        public RentabilidadCarteraV1_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.RentabilidadCartera_DA.GetTemp_RentabilidadCarteraV1(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;

            //this.radGridView1.Rows[0].Cells[0].Value = newValue;
           

            //this.myGrid.Columns[2].Header = Utils.GetUltimoDiaAñoAnterior(_fecha);
            //this.myGrid.Columns[3].Header = _fecha;

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            
            int id = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_RentabilidadCarteraV1)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            
           
            using (dbcontext = new Reports_IICSEntities())
            {
                Temp_RentabilidadCarteraV1 RentaCartera_temp = RentabilidadCarteraV1_DA.Get_Temp_RentabilidadCarteraV1ById(id);
                if (RentaCartera_temp != null)
                {
                    bool updateRestofRows = false;
                    int finish_position = 0;
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {
                        #region Update
                        if (tempRentaCartera_Sel_object.Id == ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id)
                        {
                            updateRestofRows = true;
                            finish_position = i;
                            finish_position = finish_position + 1;
                        }
                        #endregion

                        #region Update Rest of the grid
                        if (updateRestofRows && i > 0)
                        {
                            if (i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count)
                            {
                                int tmp_id = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id;
                                decimal VLFin = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).ValorLiquidativo;
                                decimal VLinicio = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).ValorLiquidativo;
                                decimal tmp_RentabilidadPeriodo = ((VLFin - VLinicio) / VLinicio)* 100;
                                ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).RentabilidadPeriodo = tmp_RentabilidadPeriodo;

                                #region update Database
                                try
                                {
                                    RentaCartera_temp = dbcontext.Temp_RentabilidadCarteraV1.FirstOrDefault(p => p.Id == tmp_id);
                                    RentaCartera_temp.ValorLiquidativo = VLFin;
                                    RentaCartera_temp.RentabilidadPeriodo = tmp_RentabilidadPeriodo;
                                    dbcontext.SaveChanges();
                                }
                                catch (Exception)
                                {

                                }

                                int tmp_id_Above = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).Id;
                                decimal VLFin_Above = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).ValorLiquidativo;
                                decimal tmp_RentabilidadPeriodo_Above = 0;
                                if (i > 1)
                                {
                                    decimal VLinicio_Above = ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 2]).ValorLiquidativo;
                                    tmp_RentabilidadPeriodo_Above = ((VLFin_Above - VLinicio_Above) / VLinicio_Above) * 100;

                                    ((T_RentabilidadCarteraV1)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).RentabilidadPeriodo = tmp_RentabilidadPeriodo_Above;

                                }

                                try
                                {
                                    RentaCartera_temp = dbcontext.Temp_RentabilidadCarteraV1.FirstOrDefault(p => p.Id == tmp_id_Above);
                                    RentaCartera_temp.ValorLiquidativo = VLFin_Above;
                                    if (i > 1) RentaCartera_temp.RentabilidadPeriodo = tmp_RentabilidadPeriodo_Above;
                                    dbcontext.SaveChanges();
                                }
                                catch (Exception)
                                {

                                }

                                #endregion
                            }
                            if (i == finish_position)
                            {
                                updateRestofRows = false;
                                break;
                            }
                        }
                        #endregion


                    }


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
               

            }
        }

    }
}
