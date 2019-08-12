using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.Indice_Preconfigurado_NOVAREX
{

   
    /// <summary>
    /// Lógica de interacción para IndicePreconfiguradoNovarex_UC.xaml
    /// </summary>
    public partial class IndicePreconfiguradoNovarex_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        public IndicePreconfiguradoNovarex_UC()
        {
            InitializeComponent();
        }

        public IndicePreconfiguradoNovarex_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.Report_IndicePreconfiguradoNovarex_DA.GetTemp_IndicePreconfiguradoNovarex(plantilla.CodigoIc, isin);

            this.myGrid.ItemsSource = renta;

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();
        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_Temp_IndicePreconfiguradoNovarex)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                T_Temp_IndicePreconfiguradoNovarex RentaCartera_temp = Report_IndicePreconfiguradoNovarex_DA.Get_Temp_IndicePreconfiguradoNovarexById(id);
                if (RentaCartera_temp != null)
                {
                    decimal Total = 0;

                    #region Calculate SumTotal Euros
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {
                        if (tempRentaCartera_Sel_object.Id == ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id)
                        {
                            Total = Total + tempRentaCartera_Sel_object.Euros;
                        }
                        else
                        {
                            Total = Total + ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Euros;
                        }
                    }
                    #endregion

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {
                            int tmp_id = ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id;
                            decimal VLFin = ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Euros;
                            decimal tmp_RentabilidadPeriodo = (VLFin / Total) * 100;
                            decimal? tmp_IndexNovarex =  ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).IndexNovarex;

                            ((T_Temp_IndicePreconfiguradoNovarex)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Porcentaje = tmp_RentabilidadPeriodo;

                            #region update Object
                            RentaCartera_temp = Report_IndicePreconfiguradoNovarex_DA.Get_Temp_IndicePreconfiguradoNovarexById(tmp_id);

                            RentaCartera_temp.Euros = VLFin; // int.Parse(VLFin.ToString());
                            RentaCartera_temp.Porcentaje = tmp_RentabilidadPeriodo;
                            RentaCartera_temp.IndexNovarex = tmp_IndexNovarex;

                            #endregion

                            #region update Database
                            // tmp_RentabilidadPeriodo = (VLFin / Total);
                            var RentaParticipeToSave = dbcontext.Temp_IndicePreconfiguradoNovarex.Where(c => c.Id == tmp_id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.Euros = VLFin;
                                RentaParticipeToSave.Porcentaje = tmp_RentabilidadPeriodo;
                                RentaParticipeToSave.IndexNovarex = tmp_IndexNovarex;
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
