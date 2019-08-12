using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.Participes
{
    /// <summary>
    /// Lógica de interacción para Participes_UC.xaml
    /// </summary>
    public partial class Participes_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public Participes_UC()
        {
            InitializeComponent();
        }

        public Participes_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.ParticipesReport_DA.GetTemp_Participes(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;

            #region Generate %
           
            /*
            using (dbcontext = new Reports_IICSEntities())
            {
               
                    decimal Total = 0;

                    #region Calculate SumTotal NºParticipaciones
                    for (int i = 0; i < renta.Count; i++)
                    {
                       
                        Total = Total + ((T_Participes)(renta)[i]).NumeroParticipaciones;
                        
                    }
                    #endregion

                    #region Update 
                    for (int i = 0; i < (renta).Count; i++)
                    {
                        T_Participes RentaCartera_temp = new T_Participes();
                        try
                        {
                            int tmp_id = ((T_Participes)(renta)[i]).Id;
                            decimal VLFin = ((T_Participes)(renta)[i]).NumeroParticipaciones;
                            decimal tmp_RentabilidadPeriodo = (VLFin / Total) * 100;
                            ((T_Participes)(renta)[i]).PorcentajeParticipacion = tmp_RentabilidadPeriodo;

                            #region update Object
                            RentaCartera_temp = Participes_DA.Get_Temp_ParticipesById(tmp_id);

                            RentaCartera_temp.NumeroParticipaciones = VLFin; // int.Parse(VLFin.ToString());
                            RentaCartera_temp.PorcentajeParticipacion = tmp_RentabilidadPeriodo;
                            #endregion

                            #region update Database
                            // tmp_RentabilidadPeriodo = (VLFin / Total);
                            var RentaParticipeToSave = dbcontext.Temp_Participes.Where(c => c.Id == tmp_id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.NumeroParticipaciones = VLFin;
                                RentaParticipeToSave.PorcentajeParticipacion = tmp_RentabilidadPeriodo;
                            }

                            dbcontext.SaveChanges();
                            #endregion
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    #endregion

                
            }
            */

            #endregion


            //this.radGridView1.Rows[0].Cells[0].Value = newValue;


            //this.myGrid.Columns[2].Header = Utils.GetUltimoDiaAñoAnterior(_fecha);
            //this.myGrid.Columns[3].Header = _fecha;

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_Participes)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                T_Participes RentaCartera_temp = Participes_DA.Get_Temp_ParticipesById(id);
                if (RentaCartera_temp != null)
                {
                    decimal Total = 0;

                    #region Calculate SumTotal NºParticipaciones
                        for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                        {
                            if (tempRentaCartera_Sel_object.Id == ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id)
                            {
                                Total = Total + tempRentaCartera_Sel_object.NumeroParticipaciones;
                            }
                            else
                            {
                                Total = Total + ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).NumeroParticipaciones; 
                            }
                        }
                    #endregion

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {
                        
                        try
                        {
                            int tmp_id = ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id;
                            decimal VLFin = ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).NumeroParticipaciones;
                            decimal tmp_RentabilidadPeriodo = (VLFin / Total)*100;
                            ((T_Participes)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).PorcentajeParticipacion = tmp_RentabilidadPeriodo;

                            #region update Object
                                RentaCartera_temp = Participes_DA.Get_Temp_ParticipesById(tmp_id);

                            RentaCartera_temp.NumeroParticipaciones = VLFin; // int.Parse(VLFin.ToString());
                                RentaCartera_temp.PorcentajeParticipacion = tmp_RentabilidadPeriodo;
                            #endregion

                            #region update Database
                               // tmp_RentabilidadPeriodo = (VLFin / Total);
                                var RentaParticipeToSave = dbcontext.Temp_Participes.Where(c => c.Id == tmp_id).FirstOrDefault();
                                if(RentaParticipeToSave!= null)
                                {
                                    RentaParticipeToSave.NumeroParticipaciones = VLFin;
                                    RentaParticipeToSave.PorcentajeParticipacion = tmp_RentabilidadPeriodo;
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
