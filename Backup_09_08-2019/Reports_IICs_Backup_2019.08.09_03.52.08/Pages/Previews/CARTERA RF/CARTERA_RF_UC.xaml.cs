using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.CARTERA_RF
{
    /// <summary>
    /// Lógica de interacción para CARTERA_RF_UC.xaml
    /// </summary>
    public partial class CARTERA_RF_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();
        public CARTERA_RF_UC()
        {
            InitializeComponent();
        }

        public CARTERA_RF_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRF(plantilla.CodigoIc);

            this.myGrid.ItemsSource = renta;

            var rentaCPLazo = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRFCPLAZO(plantilla.CodigoIc,fecha);

            this.myGridCPLAZO.ItemsSource = rentaCPLazo;

            var rentaLPLazo = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRFLPLAZO(plantilla.CodigoIc,fecha);
            this.myGridLPlazo.ItemsSource = rentaLPLazo;

        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Temp_CarteraRF)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_Temp_CarteraRF)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            if (e.Cell.Column.Name== "Minusvalias")
            {
                tempRentaCartera_Sel_object.Plusvalias = 0;
            }

            if (e.Cell.Column.Name == "Plusvalias")
            {
                tempRentaCartera_Sel_object.Minusvalias = 0;
            }
               

            using (dbcontext = new Reports_IICSEntities())
            {
                T_Temp_CarteraRF RentaCartera_temp = CarteraRF_DA.Get_Temp_CarteraRFById(id);
                if (RentaCartera_temp != null)
                {

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {

                            #region update Object

                            RentaCartera_temp.Dias = tempRentaCartera_Sel_object.Dias;
                            RentaCartera_temp.Divisa = tempRentaCartera_Sel_object.Divisa;
                            RentaCartera_temp.EfectivoActual = tempRentaCartera_Sel_object.EfectivoActual;
                            RentaCartera_temp.EfectivoCompra = tempRentaCartera_Sel_object.EfectivoCompra;
                            RentaCartera_temp.Intereses = tempRentaCartera_Sel_object.Intereses;
                            RentaCartera_temp.Nominal = tempRentaCartera_Sel_object.Nominal;
                            RentaCartera_temp.Plusvalias = tempRentaCartera_Sel_object.Plusvalias;
                            RentaCartera_temp.Minusvalias = tempRentaCartera_Sel_object.Minusvalias;
                            
                            RentaCartera_temp.PorcentajePat = tempRentaCartera_Sel_object.PorcentajePat;
                            RentaCartera_temp.TirCompra = tempRentaCartera_Sel_object.TirCompra;
                            RentaCartera_temp.TirMercado = tempRentaCartera_Sel_object.TirMercado;
                            RentaCartera_temp.Valor = tempRentaCartera_Sel_object.Valor;
                            RentaCartera_temp.Vencimiento = tempRentaCartera_Sel_object.Vencimiento;

                           
                            #endregion

                            #region update Database

                            var RentaParticipeToSave = dbcontext.Temp_CarteraRF.Where(c => c.Id == id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.Dias = RentaCartera_temp.Dias;
                                RentaParticipeToSave.Divisa = RentaCartera_temp.Divisa;
                                RentaParticipeToSave.EfectivoActual = RentaCartera_temp.EfectivoActual;
                                RentaParticipeToSave.EfectivoCompra = RentaCartera_temp.EfectivoCompra;
                                RentaParticipeToSave.Intereses = RentaCartera_temp.Intereses;
                                RentaParticipeToSave.Nominal = RentaCartera_temp.Nominal;
                                RentaParticipeToSave.PlusvaliasMinusvalias = (RentaCartera_temp.Plusvalias>0)? RentaCartera_temp.Plusvalias : RentaCartera_temp.Minusvalias*-1;
                                RentaParticipeToSave.PorcentajePat = RentaCartera_temp.PorcentajePat;
                                RentaParticipeToSave.TirCompra = RentaCartera_temp.TirCompra;
                                RentaParticipeToSave.TirMercado = RentaCartera_temp.TirMercado;
                                RentaParticipeToSave.Valor = RentaCartera_temp.Valor;
                                RentaParticipeToSave.Vencimiento = RentaCartera_temp.Vencimiento;
                                
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
            var rentaCPLazo = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRFCPLAZO(_plantilla.CodigoIc, _fecha);

            this.myGridCPLAZO.ItemsSource = rentaCPLazo;

            var rentaLPLazo = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRFLPLAZO(_plantilla.CodigoIc, _fecha);
            this.myGridLPlazo.ItemsSource = rentaLPLazo;

            
        }

        private void myGridCPLAZO_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Temp_CarteraRF)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_Temp_CarteraRF)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            if (e.Cell.Column.Name == "MinusvaliasCplazo")
            {
                tempRentaCartera_Sel_object.Plusvalias = 0;
            }

            if (e.Cell.Column.Name == "PlusvaliasCplazo")
            {
                tempRentaCartera_Sel_object.Minusvalias = 0;
            }


            using (dbcontext = new Reports_IICSEntities())
            {
                T_Temp_CarteraRF RentaCartera_temp = CarteraRF_DA.Get_Temp_CarteraRFById(id);
                if (RentaCartera_temp != null)
                {

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {

                            #region update Object

                            RentaCartera_temp.Dias = tempRentaCartera_Sel_object.Dias;
                            RentaCartera_temp.Divisa = tempRentaCartera_Sel_object.Divisa;
                            RentaCartera_temp.EfectivoActual = tempRentaCartera_Sel_object.EfectivoActual;
                            RentaCartera_temp.EfectivoCompra = tempRentaCartera_Sel_object.EfectivoCompra;
                            RentaCartera_temp.Intereses = tempRentaCartera_Sel_object.Intereses;
                            RentaCartera_temp.Nominal = tempRentaCartera_Sel_object.Nominal;
                            RentaCartera_temp.Plusvalias = tempRentaCartera_Sel_object.Plusvalias;
                            RentaCartera_temp.Minusvalias = tempRentaCartera_Sel_object.Minusvalias;

                            RentaCartera_temp.PorcentajePat = tempRentaCartera_Sel_object.PorcentajePat;
                            RentaCartera_temp.TirCompra = tempRentaCartera_Sel_object.TirCompra;
                            RentaCartera_temp.TirMercado = tempRentaCartera_Sel_object.TirMercado;
                            RentaCartera_temp.Valor = tempRentaCartera_Sel_object.Valor;
                            RentaCartera_temp.Vencimiento = tempRentaCartera_Sel_object.Vencimiento;


                            #endregion

                            #region update Database

                            var RentaParticipeToSave = dbcontext.Temp_CarteraRF.Where(c => c.Id == id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.Dias = RentaCartera_temp.Dias;
                                RentaParticipeToSave.Divisa = RentaCartera_temp.Divisa;
                                RentaParticipeToSave.EfectivoActual = RentaCartera_temp.EfectivoActual;
                                RentaParticipeToSave.EfectivoCompra = RentaCartera_temp.EfectivoCompra;
                                RentaParticipeToSave.Intereses = RentaCartera_temp.Intereses;
                                RentaParticipeToSave.Nominal = RentaCartera_temp.Nominal;
                                RentaParticipeToSave.PlusvaliasMinusvalias = (RentaCartera_temp.Plusvalias > 0) ? RentaCartera_temp.Plusvalias : RentaCartera_temp.Minusvalias * -1;
                                RentaParticipeToSave.PorcentajePat = RentaCartera_temp.PorcentajePat;
                                RentaParticipeToSave.TirCompra = RentaCartera_temp.TirCompra;
                                RentaParticipeToSave.TirMercado = RentaCartera_temp.TirMercado;
                                RentaParticipeToSave.Valor = RentaCartera_temp.Valor;
                                RentaParticipeToSave.Vencimiento = RentaCartera_temp.Vencimiento;

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

            var renta = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRF(_plantilla.CodigoIc);

            this.myGrid.ItemsSource = renta;


        }

        private void myGridLPlazo_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_Temp_CarteraRF)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_Temp_CarteraRF)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            if (e.Cell.Column.Name == "MinusvaliasLplazo")
            {
                tempRentaCartera_Sel_object.Plusvalias = 0;
            }

            if (e.Cell.Column.Name == "PlusvaliasLplazo")
            {
                tempRentaCartera_Sel_object.Minusvalias = 0;
            }


            using (dbcontext = new Reports_IICSEntities())
            {
                T_Temp_CarteraRF RentaCartera_temp = CarteraRF_DA.Get_Temp_CarteraRFById(id);
                if (RentaCartera_temp != null)
                {

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {

                            #region update Object

                            RentaCartera_temp.Dias = tempRentaCartera_Sel_object.Dias;
                            RentaCartera_temp.Divisa = tempRentaCartera_Sel_object.Divisa;
                            RentaCartera_temp.EfectivoActual = tempRentaCartera_Sel_object.EfectivoActual;
                            RentaCartera_temp.EfectivoCompra = tempRentaCartera_Sel_object.EfectivoCompra;
                            RentaCartera_temp.Intereses = tempRentaCartera_Sel_object.Intereses;
                            RentaCartera_temp.Nominal = tempRentaCartera_Sel_object.Nominal;
                            RentaCartera_temp.Plusvalias = tempRentaCartera_Sel_object.Plusvalias;
                            RentaCartera_temp.Minusvalias = tempRentaCartera_Sel_object.Minusvalias;

                            RentaCartera_temp.PorcentajePat = tempRentaCartera_Sel_object.PorcentajePat;
                            RentaCartera_temp.TirCompra = tempRentaCartera_Sel_object.TirCompra;
                            RentaCartera_temp.TirMercado = tempRentaCartera_Sel_object.TirMercado;
                            RentaCartera_temp.Valor = tempRentaCartera_Sel_object.Valor;
                            RentaCartera_temp.Vencimiento = tempRentaCartera_Sel_object.Vencimiento;


                            #endregion

                            #region update Database

                            var RentaParticipeToSave = dbcontext.Temp_CarteraRF.Where(c => c.Id == id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.Dias = RentaCartera_temp.Dias;
                                RentaParticipeToSave.Divisa = RentaCartera_temp.Divisa;
                                RentaParticipeToSave.EfectivoActual = RentaCartera_temp.EfectivoActual;
                                RentaParticipeToSave.EfectivoCompra = RentaCartera_temp.EfectivoCompra;
                                RentaParticipeToSave.Intereses = RentaCartera_temp.Intereses;
                                RentaParticipeToSave.Nominal = RentaCartera_temp.Nominal;
                                RentaParticipeToSave.PlusvaliasMinusvalias = (RentaCartera_temp.Plusvalias > 0) ? RentaCartera_temp.Plusvalias : RentaCartera_temp.Minusvalias * -1;
                                RentaParticipeToSave.PorcentajePat = RentaCartera_temp.PorcentajePat;
                                RentaParticipeToSave.TirCompra = RentaCartera_temp.TirCompra;
                                RentaParticipeToSave.TirMercado = RentaCartera_temp.TirMercado;
                                RentaParticipeToSave.Valor = RentaCartera_temp.Valor;
                                RentaParticipeToSave.Vencimiento = RentaCartera_temp.Vencimiento;

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

            var renta = DataAccess.Reports.CarteraRF_DA.GetTemp_CarteraRF(_plantilla.CodigoIc);

            this.myGrid.ItemsSource = renta;


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
            if (e.Cell.Column.Name == "Cotizacion")
            {
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            }
        }
    }
}
