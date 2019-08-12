using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;

namespace Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV2
{
    /// <summary>
    /// Lógica de interacción para RentabilidadCarteraV2_UC.xaml
    /// </summary>
    public partial class RentabilidadCarteraV2_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public double Ancho;
        public RentabilidadCarteraV2_UC()
        {
            InitializeComponent();
        }

        public  RentabilidadCarteraV2_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            Ancho = 0;
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.RentabilidadCartera_DA.GetTemp_RentabilidadCarteraV2(plantilla.CodigoIc, null);

            var ColumNum = renta.GroupBy(p => p.Isin).Count();
            var ListaIsin = renta.Where(r => r.CodigoIC== plantilla.CodigoIc && !r.EsIndice.Value).Select(s => s.Isin).Distinct();

            List<string> ListaFull = new List<string>();
            foreach (var item in ListaIsin)
            {
                ListaFull.Add(item);
            }
            

            var indices = renta.Where(r => r.CodigoIC == plantilla.CodigoIc && r.EsIndice.Value).Select(s => s.Isin).Distinct();

            foreach (var item in indices)
            {
                ListaFull.Add(item);
            }


            //this.myGrid.ItemsSource = renta.Where(c=>c.Isin==ListaIsin.FirstOrDefault());

            int i = 1;
           

            foreach (string cisin in ListaFull)
            {
                RadGridView RadGrid1 = new RadGridView();

                if (i==1)
                {
                    #region First Grid
                   

                    Telerik.Windows.Controls.GridViewDataColumn C_id = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_id.Name = "Id";
                    C_id.DataMemberBinding = new System.Windows.Data.Binding("Id");
                    C_id.IsVisible = false;


                    Telerik.Windows.Controls.GridViewDataColumn C_Descripcion = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Descripcion.Name = "Descripcion";
                    C_Descripcion.Width = 60;
                    C_Descripcion.DataMemberBinding = new System.Windows.Data.Binding("ValLiquiDescrip");
                    //C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
                    C_Descripcion.IsReadOnly = true;

                    Telerik.Windows.Controls.GridViewDataColumn C_Fecha = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Fecha.Name = "Fecha";
                    C_Fecha.Width = 70;
                    //C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_Fecha.DataMemberBinding = new System.Windows.Data.Binding("Fecha");
                    C_Fecha.DataFormatString = "{0:dd/MM/yyyy}";
                    C_Fecha.IsReadOnly = true;

                    Telerik.Windows.Controls.GridViewDataColumn C_ValorLiquidativo = new Telerik.Windows.Controls.GridViewDataColumn();
                    var p = renta.Where(c => c.Isin == cisin).FirstOrDefault();
                  
                    C_ValorLiquidativo.Name = "ValorLiquidativo";
                    C_ValorLiquidativo.Header = "V.L." + "(" + p.DescripcionIndice + ")";
                    C_ValorLiquidativo.Width = 100;
                    C_ValorLiquidativo.TextAlignment = TextAlignment.Right;
                    //C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_ValorLiquidativo.DataMemberBinding = new System.Windows.Data.Binding("ValorLiquidativo");

                    Telerik.Windows.Controls.GridViewDataColumn C_RentabilidadPeriodo = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_RentabilidadPeriodo.Name = "RentabilidadPeriodo";
                    C_RentabilidadPeriodo.Header = "Rentabilidad periodo";
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_RentabilidadPeriodo.DataMemberBinding = new System.Windows.Data.Binding("RentabilidadPeriodo");
                    C_RentabilidadPeriodo.DataFormatString = "{0:N2}";
                    C_RentabilidadPeriodo.Width = 112;
                    C_RentabilidadPeriodo.IsReadOnly = true;
                    C_RentabilidadPeriodo.TextAlignment = TextAlignment.Right;

                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.Isin == cisin);
                    RadGrid1.Columns.Add(C_id);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    RadGrid1.Columns.Add(C_Fecha);
                    RadGrid1.Columns.Add(C_ValorLiquidativo);
                    RadGrid1.Columns.Add(C_RentabilidadPeriodo);
                    RadGrid1.MinWidth = 284;
                    RadGrid1.ShowGroupPanel = false;
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    RadGrid1.Width = 284;
                    RadGrid1.FontSize = 10;
                    #endregion

                    this.GridList.Children.Add(RadGrid1);
                    Ancho = Ancho + RadGrid1.Width;
                }
                else
                {
                    #region Dynamic Grid


                    Telerik.Windows.Controls.GridViewDataColumn C_id_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_id_Dynamic.Name = "Id";
                    C_id_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("Id");
                    C_id_Dynamic.IsVisible = false;


                    Telerik.Windows.Controls.GridViewDataColumn C_Descripcion_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Descripcion_Dynamic.Name = "Descripcion";
                    C_Descripcion_Dynamic.Width = 60;
                    C_Descripcion_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("ValLiquiDescrip");
                    //C_Descripcion.EditorStyle = (System.Windows.Style)this.Resources["Max3GroupCodeStyle"];
                    C_Descripcion_Dynamic.IsReadOnly = true;

                    //Telerik.Windows.Controls.GridViewDataColumn C_Fecha = new Telerik.Windows.Controls.GridViewDataColumn();

                    //C_Fecha.Name = "Fecha";
                    //C_Fecha.Width = 60;
                    ////C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    //C_Fecha.DataMemberBinding = new System.Windows.Data.Binding("Fecha");
                    //C_Fecha.IsReadOnly = true;

                    Telerik.Windows.Controls.GridViewDataColumn C_ValorLiquidativo_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();
                   
                    C_ValorLiquidativo_Dynamic.Name = "ValorLiquidativo";
                    C_ValorLiquidativo_Dynamic.Header = "V.L." + "(" + cisin + ")";
                    C_ValorLiquidativo_Dynamic.Width = 100;
                    //C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_ValorLiquidativo_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("ValorLiquidativo");
                    C_ValorLiquidativo_Dynamic.TextAlignment = TextAlignment.Right;
                    Telerik.Windows.Controls.GridViewDataColumn C_RentabilidadPeriodo_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_RentabilidadPeriodo_Dynamic.Name = "RentabilidadPeriodo";
                    C_RentabilidadPeriodo_Dynamic.Header = "Rentabilidad periodo";
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_RentabilidadPeriodo_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("RentabilidadPeriodo");
                    C_RentabilidadPeriodo_Dynamic.DataFormatString = "{0:N2}";
                    C_RentabilidadPeriodo_Dynamic.Width = 112;
                    C_RentabilidadPeriodo_Dynamic.IsReadOnly = true;
                    C_RentabilidadPeriodo_Dynamic.TextAlignment = TextAlignment.Right;
                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.Isin == cisin);
                    RadGrid1.Columns.Add(C_id_Dynamic);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    //RadGrid1.Columns.Add(C_Fecha);
                    RadGrid1.Columns.Add(C_ValorLiquidativo_Dynamic);
                    RadGrid1.Columns.Add(C_RentabilidadPeriodo_Dynamic);
                    RadGrid1.MinWidth = 214;
                    RadGrid1.ShowGroupPanel = false;
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    RadGrid1.Width = 214;
                    RadGrid1.FontSize = 10;
                    #endregion
                    // RadGrid1.ItemsSource = renta.Where(c => c.Isin == cisin);
                    this.GridList.Children.Add(RadGrid1);
                    Ancho = Ancho + RadGrid1.Width;
                }

                i = i + 1;
            }



            //this.radGridView1.Rows[0].Cells[0].Value = newValue;


            //this.myGrid.Columns[2].Header = Utils.GetUltimoDiaAñoAnterior(_fecha);
            //this.myGrid.Columns[3].Header = _fecha;
            
        }

        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_RentabilidadCarteraV2)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            using (dbContext = new Reports_IICSEntities())
            {
                Temp_RentabilidadCarteraV2 RentaCartera_temp = RentabilidadCarteraV2_DA.Get_Temp_RentabilidadCarteraV2ById(id);
                if (RentaCartera_temp != null)
                {
                    bool updateRestofRows = false;
                    int finish_position = 0;
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {
                        #region Update
                        if (tempRentaCartera_Sel_object.Id == ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id)
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
                                int tmp_id = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id;
                                decimal VLFin = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).ValorLiquidativo;
                                decimal VLinicio = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).ValorLiquidativo;
                                decimal tmp_RentabilidadPeriodo = ((VLFin - VLinicio) / VLinicio) * 100;
                                ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).RentabilidadPeriodo = tmp_RentabilidadPeriodo;

                                #region update Database
                                try
                                {
                                    RentaCartera_temp = dbContext.Temp_RentabilidadCarteraV2.FirstOrDefault(p => p.Id == tmp_id);
                                    RentaCartera_temp.ValorLiquidativo = VLFin;
                                    RentaCartera_temp.RentabilidadPeriodo = tmp_RentabilidadPeriodo;
                                    dbContext.SaveChanges();

                                }
                                catch (Exception)
                                {

                                }

                                int tmp_id_Above = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).Id;
                                decimal VLFin_Above = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).ValorLiquidativo;
                                decimal tmp_RentabilidadPeriodo_Above = 0;
                                if (i > 1)
                                {
                                    decimal VLinicio_Above = ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 2]).ValorLiquidativo;
                                    tmp_RentabilidadPeriodo_Above = ((VLFin_Above - VLinicio_Above) / VLinicio_Above) * 100;

                                    ((T_RentabilidadCarteraV2)(((Telerik.Windows.Controls.DataControl)sender).Items)[i - 1]).RentabilidadPeriodo = tmp_RentabilidadPeriodo_Above;

                                }

                                try
                                {
                                    RentaCartera_temp = dbContext.Temp_RentabilidadCarteraV2.FirstOrDefault(p => p.Id == tmp_id_Above);
                                    RentaCartera_temp.ValorLiquidativo = VLFin_Above;
                                    if (i > 1) RentaCartera_temp.RentabilidadPeriodo = tmp_RentabilidadPeriodo_Above;
                                    dbContext.SaveChanges();
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
