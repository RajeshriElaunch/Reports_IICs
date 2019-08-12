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


namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Rentabilidad_Guissona
{
    /// <summary>
    /// Lógica de interacción para EvolucionRentabilidadGuissona_UC.xaml
    /// </summary>
    public partial class EvolucionRentabilidadGuissona_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public double Ancho;

        public EvolucionRentabilidadGuissona_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            Ancho = 0;
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.RentabilidadCarteraGuissona_DA.GetTemp_RentabilidadCarteraGuissona(plantilla.CodigoIc, null);

            var ColumNum = renta.GroupBy(p => p.IsinFondo).Count();
            var ListaIsin = renta.Where(r => r.CodigoIC == plantilla.CodigoIc).Select(s => s.IsinFondo).Distinct();

            List<string> ListaFull = new List<string>();
            foreach (var item in ListaIsin)
            {
                ListaFull.Add(item);
            }


            //var indices = renta.Where(r => r.CodigoIC == plantilla.CodigoIc).Select(s => s.IsinFondo).Distinct();

            //foreach (var item in indices)
            //{
            //    ListaFull.Add(item);
            //}


            //this.myGrid.ItemsSource = renta.Where(c=>c.Isin==ListaIsin.FirstOrDefault());

            int i = 1;


            foreach (string cisin in ListaFull)
            {
                DateTime FechaConstitucion = new DateTime();
                string DescripFondo = string.Empty;
                string taeValue = string.Empty;
                var fondo = EvolucionRentabilidadGuissona_DA.GetFondo(cisin).FirstOrDefault();
                if(fondo!=null )
                {
             
                        FechaConstitucion = fondo.FechaConstitucion;
                        DescripFondo = fondo.Descripcion;
                   
                }

                var tae = EvolucionRentabilidadGuissona_DA.Get_Temp_EvolucionRentabilidadGuissona_TAE(plantilla.CodigoIc, cisin);

                if (tae != null)
                {
                    taeValue = String.Format("{0:P2}", tae.Tae);
                }

                RadGridView RadGrid1 = new RadGridView();

                if (i == 1)
                {
                    #region First Grid
                    
                    Telerik.Windows.Controls.GridViewDataColumn C_id = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_id.Name = "Id";
                    C_id.DataMemberBinding = new System.Windows.Data.Binding("Id");
                    C_id.IsVisible = false;
                    
                    Telerik.Windows.Controls.GridViewDataColumn C_Fecha = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Fecha.Name = "Fecha";
                    C_Fecha.Width = 90;
                    C_Fecha.Header = "\n" + "Fecha Constitución";
                    //C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_Fecha.DataMemberBinding = new System.Windows.Data.Binding("Fecha");
                    C_Fecha.DataFormatString = "{0:yyyy}";
                    C_Fecha.IsReadOnly = true;
                    C_Fecha.HeaderTextAlignment = TextAlignment.Center;
                    C_Fecha.TextAlignment = TextAlignment.Center;
                    C_Fecha.Footer = "TAE " + String.Format("{0:dd/MM/yyyy}", fecha);
                    C_Fecha.FooterTextAlignment = TextAlignment.Center;
                    C_Fecha.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_Fecha.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_Fecha.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"];

                    Telerik.Windows.Controls.GridViewDataColumn C_PorcentajeRentabilidad = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_PorcentajeRentabilidad.Name = "PorcentajeRentabilidad";
                    C_PorcentajeRentabilidad.Header = DescripFondo + "\n" + String.Format("{0:dd/MM/yyyy}", FechaConstitucion); 
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_PorcentajeRentabilidad.DataMemberBinding = new System.Windows.Data.Binding("PorcentajeRentabilidad");
                    C_PorcentajeRentabilidad.DataFormatString = "{0:N2}";
                    C_PorcentajeRentabilidad.Width = 90;//DescripFondo.Length*10 + 2;
                    C_PorcentajeRentabilidad.IsReadOnly = false;

                    C_PorcentajeRentabilidad.HeaderTextAlignment = TextAlignment.Center;
                    C_PorcentajeRentabilidad.TextAlignment = TextAlignment.Center;
                    C_PorcentajeRentabilidad.Footer = taeValue;
                    C_PorcentajeRentabilidad.FooterTextAlignment = TextAlignment.Center;
                    C_PorcentajeRentabilidad.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_PorcentajeRentabilidad.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_PorcentajeRentabilidad.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"];

                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.IsinFondo == cisin);
                    RadGrid1.Columns.Add(C_id);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    RadGrid1.Columns.Add(C_Fecha);
                    RadGrid1.Columns.Add(C_PorcentajeRentabilidad);

                    RadGrid1.MinWidth = 182;
                    RadGrid1.IsFilteringAllowed = false;
                    RadGrid1.CanUserSortColumns = false;
                    RadGrid1.CanUserSortGroups = false;
                    RadGrid1.ShowGroupPanel = false;
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    RadGrid1.Width = 183;
                    RadGrid1.ShowColumnFooters = true;

                    #endregion

                    ScrollViewer.SetHorizontalScrollBarVisibility(RadGrid1, ScrollBarVisibility.Hidden);
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
                    
                    Telerik.Windows.Controls.GridViewDataColumn C_PorcentajeRentabilidad_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_PorcentajeRentabilidad_Dynamic.Name = "PorcentajeRentabilidad";
                    C_PorcentajeRentabilidad_Dynamic.Header = DescripFondo + "\n" + String.Format("{0:dd/MM/yyyy}", FechaConstitucion);
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_PorcentajeRentabilidad_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("PorcentajeRentabilidad");
                    C_PorcentajeRentabilidad_Dynamic.DataFormatString = "{0:N2}";
                    C_PorcentajeRentabilidad_Dynamic.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_PorcentajeRentabilidad_Dynamic.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_PorcentajeRentabilidad_Dynamic.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"];
                    //if (DescripFondo.Length * 10 + 2 < 100)
                    //{
                    C_PorcentajeRentabilidad_Dynamic.Width = 90;
                    //}
                    //else
                    //{
                    //    C_PorcentajeRentabilidad_Dynamic.Width = DescripFondo.Length * 10 + 2;
                    //}

                    //C_PorcentajeRentabilidad_Dynamic.Width = DescripFondo.Length * 10 +2;
                    C_PorcentajeRentabilidad_Dynamic.IsReadOnly = false;
                    C_PorcentajeRentabilidad_Dynamic.HeaderTextAlignment = TextAlignment.Center;
                    C_PorcentajeRentabilidad_Dynamic.TextAlignment = TextAlignment.Center;
                    C_PorcentajeRentabilidad_Dynamic.Footer = taeValue;
                    C_PorcentajeRentabilidad_Dynamic.FooterTextAlignment = TextAlignment.Center;

                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.IsinFondo == cisin);
                    RadGrid1.Columns.Add(C_id_Dynamic);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    //RadGrid1.Columns.Add(C_Fecha);
                   
                    RadGrid1.Columns.Add(C_PorcentajeRentabilidad_Dynamic);
                  

                    //if (DescripFondo.Length * 10 + 2 < 100)
                    //{
                        RadGrid1.MinWidth = 92;
                    //}
                    //else
                    //{
                    //    RadGrid1.MinWidth = DescripFondo.Length * 10 + 2;
                    //}
                    RadGrid1.IsFilteringAllowed = false;
                    RadGrid1.CanUserSortColumns = false;
                    RadGrid1.CanUserSortGroups = false;
                    RadGrid1.ShowGroupPanel = false;
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    //if (DescripFondo.Length * 10 + 3<100 )
                    //{
                        RadGrid1.Width = 92;
                    //}
                    //else
                    //{
                    //    RadGrid1.Width = DescripFondo.Length * 10 + 3;
                    //}
                   
                    RadGrid1.ShowColumnFooters = true;
                    #endregion
                    // RadGrid1.ItemsSource = renta.Where(c => c.Isin == cisin);
                    ScrollViewer.SetHorizontalScrollBarVisibility(RadGrid1, ScrollBarVisibility.Hidden);
                    this.GridList.Children.Add(RadGrid1);
                    Ancho = Ancho + RadGrid1.Width;
                }

                i = i + 1;
            }


        }

        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_RentabilidadCarteraGuissona)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_RentabilidadCarteraGuissona)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            using (dbContext = new Reports_IICSEntities())
            {
                Temp_EvolucionRentabilidadGuissona RentaCartera_temp = EvolucionRentabilidadGuissona_DA.Get_Temp_EvolucionRentabilidadGuissonaById(id);
                if (RentaCartera_temp != null)
                {
                    try
                    {
                        #region update Object
                        RentaCartera_temp.PorcentajeRentabilidad = tempRentaCartera_Sel_object.PorcentajeRentabilidad;
                        #endregion

                        #region update Database

                        var CompraVentaToSave = dbContext.Temp_EvolucionRentabilidadGuissona.Where(c => c.Id == id).FirstOrDefault();
                        if (CompraVentaToSave != null)
                        {
                            CompraVentaToSave.PorcentajeRentabilidad = tempRentaCartera_Sel_object.PorcentajeRentabilidad;
                        }

                        dbContext.SaveChanges();


                        #endregion
                    }
                    catch (Exception)
                    {

                    }


                }

            }

            //if (CellEditEnded != null)
            //{
            //    CellEditEnded(this, new EventArgs());
            //}


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
