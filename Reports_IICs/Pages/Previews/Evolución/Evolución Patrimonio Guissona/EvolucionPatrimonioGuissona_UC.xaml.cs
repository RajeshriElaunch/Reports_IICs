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

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Patrimonio_Guissona
{
    /// <summary>
    /// Lógica de interacción para EvolucionPatrimonioGuissona_UC.xaml
    /// </summary>
    public partial class EvolucionPatrimonioGuissona_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public double Ancho;

        public EvolucionPatrimonioGuissona_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            Ancho = 0;
            InitializeComponent();

            _plantilla = plantilla;
            _fecha = fecha;

            var renta = DataAccess.Reports.EvolucionPatrimonioConjuntoGuissona.GetTemp_EvolucionPatrimonioConjuntoGuissona(plantilla.CodigoIc, null);

            var ColumNum = renta.GroupBy(p => p.IsinFondo).Count();
            var ListaIsin = renta.Where(r => r.CodigoIC == plantilla.CodigoIc).Select(s => s.IsinFondo).Distinct();

            List<string> ListaFull = new List<string>();
            foreach (var item in ListaIsin)
            {
                ListaFull.Add(item);
            }
            
            int i = 1;
            
            foreach (string cisin in ListaFull)
            {
                DateTime FechaConstitucion = new DateTime();
                string DescripFondo = string.Empty;
                string taeValue = string.Empty;
                var fondo = EvolucionPatrimConjuntoGuissona_DA.GetFondo(cisin).FirstOrDefault();
                if (fondo != null)
                {
                    FechaConstitucion = fondo.FechaConstitucion;
                    DescripFondo = fondo.Descripcion;
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
                    C_Fecha.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_Fecha.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_Fecha.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"];
                    //C_Fecha.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_Fecha.DataMemberBinding = new System.Windows.Data.Binding("Fecha");
                    C_Fecha.DataFormatString = "{0:dd/MM/yyyy}";
                    C_Fecha.IsReadOnly = true;
                    C_Fecha.HeaderTextAlignment = TextAlignment.Center;
                    C_Fecha.TextAlignment = TextAlignment.Center;
                    C_Fecha.Footer = "TAE " + String.Format("{0:dd/MM/yyyy}", fecha);
                    C_Fecha.FooterTextAlignment = TextAlignment.Center;

                    Telerik.Windows.Controls.GridViewDataColumn C_Patrimonio = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Patrimonio.Name = "Patrimonio";
                    C_Patrimonio.Header = DescripFondo + "\n" + String.Format("{0:dd/MM/yyyy}", FechaConstitucion);
                    C_Patrimonio.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_Patrimonio.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_Patrimonio.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"]; 
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_Patrimonio.DataMemberBinding = new System.Windows.Data.Binding("Patrimonio");
                    C_Patrimonio.DataFormatString = "{0:N2}";
                    C_Patrimonio.Width = 90; //DescripFondo.Length * 10 + 2; 
                    C_Patrimonio.IsReadOnly = false;

                    C_Patrimonio.HeaderTextAlignment = TextAlignment.Center;
                    C_Patrimonio.TextAlignment = TextAlignment.Center;
                    //C_PorcentajeRentabilidad.Footer = taeValue;
                    //C_PorcentajeRentabilidad.FooterTextAlignment = TextAlignment.Center;

                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.IsinFondo == cisin);
                    RadGrid1.Columns.Add(C_id);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    RadGrid1.Columns.Add(C_Fecha);
                    RadGrid1.Columns.Add(C_Patrimonio);

                    RadGrid1.MinWidth =182;
                    RadGrid1.IsFilteringAllowed = false;
                    RadGrid1.CanUserSortColumns = false;
                    RadGrid1.CanUserSortGroups = false;
                    RadGrid1.ShowGroupPanel = false;
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    RadGrid1.Width = 183;
                    //RadGrid1.ShowColumnFooters = true;

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

                    Telerik.Windows.Controls.GridViewDataColumn C_Patrimonio_Dynamic = new Telerik.Windows.Controls.GridViewDataColumn();

                    C_Patrimonio_Dynamic.Name = "Patrimonio";
                    C_Patrimonio_Dynamic.Header = DescripFondo + "\n" + String.Format("{0:dd/MM/yyyy}", FechaConstitucion);
                    C_Patrimonio_Dynamic.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                    C_Patrimonio_Dynamic.CellStyle = (Style)this.Resources["MyCellStyle1"];
                    C_Patrimonio_Dynamic.FooterCellStyle = (Style)this.Resources["MyFooterCellStyle1"];
                    //C_RentabilidadPeriodo.EditorStyle = (System.Windows.Style)this.Resources["Max50GroupCodeStyle"];
                    C_Patrimonio_Dynamic.DataMemberBinding = new System.Windows.Data.Binding("Patrimonio");
                    C_Patrimonio_Dynamic.DataFormatString = "{0:N2}";

                    //if (DescripFondo.Length * 10 + 2 < 100)
                    //{
                        C_Patrimonio_Dynamic.Width = 90;
                    //}
                    //else
                    //{
                    //    C_Patrimonio_Dynamic.Width = DescripFondo.Length * 10 + 2;
                    //}

                    //C_PorcentajeRentabilidad_Dynamic.Width = DescripFondo.Length * 10 +2;
                    C_Patrimonio_Dynamic.IsReadOnly = false;
                    C_Patrimonio_Dynamic.HeaderTextAlignment = TextAlignment.Center;
                    C_Patrimonio_Dynamic.TextAlignment = TextAlignment.Center;
                    //C_PorcentajeRentabilidad_Dynamic.Footer = taeValue;
                    //C_PorcentajeRentabilidad_Dynamic.FooterTextAlignment = TextAlignment.Center;

                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.ItemsSource = renta.Where(c => c.IsinFondo == cisin);
                    RadGrid1.Columns.Add(C_id_Dynamic);
                    //RadGrid1.Columns.Add(C_Descripcion);
                    //RadGrid1.Columns.Add(C_Fecha);

                    RadGrid1.Columns.Add(C_Patrimonio_Dynamic);


                    //if (DescripFondo.Length * 10 + 2 < 100)
                    //{
                        RadGrid1.MinWidth = 90;
                    //}
                    //else
                    //{
                    //    RadGrid1.MinWidth = DescripFondo.Length * 10 + 2;
                    //}
                    RadGrid1.IsFilteringAllowed = false;
                    RadGrid1.CanUserSortColumns = false;
                    RadGrid1.CanUserSortGroups=  false;
                    RadGrid1.ShowGroupPanel = false;
                   
                    RadGrid1.RowIndicatorVisibility = Visibility.Collapsed;
                    RadGrid1.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                    RadGrid1.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                    RadGrid1.ColumnWidth = '*';
                    //if (DescripFondo.Length * 10 + 3 < 100)
                    //{
                        RadGrid1.Width = 90;
                    //}
                    //else
                    //{
                    //    RadGrid1.Width = DescripFondo.Length * 10 + 3;
                    //}

                    //RadGrid1.ShowColumnFooters = true;
                    #endregion
                    // RadGrid1.ItemsSource = renta.Where(c => c.Isin == cisin);
                    ScrollViewer.SetHorizontalScrollBarVisibility(RadGrid1, ScrollBarVisibility.Hidden);
                    this.GridList.Children.Add(RadGrid1);
                    Ancho = Ancho + RadGrid1.Width;
                }

                i = i + 1;
            }

            #region Column Total
                RadGridView RadGridTotal = new RadGridView();

                #region Dynamic Grid total


                Telerik.Windows.Controls.GridViewDataColumn C_id_Dynamic_total = new Telerik.Windows.Controls.GridViewDataColumn();

                C_id_Dynamic_total.Name = "Id";
                C_id_Dynamic_total.DataMemberBinding = new System.Windows.Data.Binding("Id");
                C_id_Dynamic_total.IsVisible = false;

                Telerik.Windows.Controls.GridViewDataColumn C_Patrimonio_Dynamic_total = new Telerik.Windows.Controls.GridViewDataColumn();

                C_Patrimonio_Dynamic_total.Name = "Patrimonio";
                C_Patrimonio_Dynamic_total.Header = "TOTAL GUISSONA\n";
                C_Patrimonio_Dynamic_total.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
                C_Patrimonio_Dynamic_total.CellStyle = (Style)this.Resources["MyCellStyle1"];

                C_Patrimonio_Dynamic_total.DataMemberBinding = new System.Windows.Data.Binding("Patrimonio");
                C_Patrimonio_Dynamic_total.DataFormatString = "{0:N2}";
            
                C_Patrimonio_Dynamic_total.Width = 90;
               
                C_Patrimonio_Dynamic_total.IsReadOnly = true;
                C_Patrimonio_Dynamic_total.HeaderTextAlignment = TextAlignment.Center;
                C_Patrimonio_Dynamic_total.TextAlignment = TextAlignment.Center;
               
                RadGridTotal.AutoGenerateColumns = false;
               
                RadGridTotal.Columns.Add(C_id_Dynamic_total);
                RadGridTotal.Columns.Add(C_Patrimonio_Dynamic_total);

            
                RadGridTotal.MinWidth = 91;
                RadGridTotal.IsFilteringAllowed = false;
                RadGridTotal.CanUserSortColumns = false;
                RadGridTotal.CanUserSortGroups = false;
                RadGridTotal.ShowGroupPanel = false;
                RadGridTotal.RowIndicatorVisibility = Visibility.Collapsed;
                RadGridTotal.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
                RadGridTotal.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
                RadGridTotal.ColumnWidth = '*';
                RadGridTotal.Width = 91;

            #endregion

                var IsinTofilter = renta.Where(r => r.CodigoIC == plantilla.CodigoIc).Select(s => s.IsinFondo).Distinct().FirstOrDefault();

                RadGridTotal.ItemsSource = GetTotalCalculated(plantilla.CodigoIc,IsinTofilter);
                ScrollViewer.SetHorizontalScrollBarVisibility(RadGridTotal, ScrollBarVisibility.Hidden);
                this.GridList.Children.Add(RadGridTotal);
                Ancho = Ancho + RadGridTotal.Width;
            #endregion
            
            #region Column Variacio

            RadGridView RadGridVariacio = new RadGridView();

            #region Dynamic Grid total


            Telerik.Windows.Controls.GridViewDataColumn C_id_Dynamic_variacio = new Telerik.Windows.Controls.GridViewDataColumn();

            C_id_Dynamic_variacio.Name = "Id";
            C_id_Dynamic_variacio.DataMemberBinding = new System.Windows.Data.Binding("Id");
            C_id_Dynamic_variacio.IsVisible = false;

            Telerik.Windows.Controls.GridViewDataColumn C_Patrimonio_Dynamic_variacio = new Telerik.Windows.Controls.GridViewDataColumn();

            C_Patrimonio_Dynamic_variacio.Name = "Patrimonio";
            C_Patrimonio_Dynamic_variacio.Header = "VARIACIÓN ANUAL\n";
            C_Patrimonio_Dynamic_variacio.HeaderCellStyle = (Style)this.Resources["MyHeaderCellStyle1"];
            C_Patrimonio_Dynamic_variacio.CellStyle = (Style)this.Resources["MyCellStyle1"];

            C_Patrimonio_Dynamic_variacio.DataMemberBinding = new System.Windows.Data.Binding("Patrimonio");
            C_Patrimonio_Dynamic_variacio.DataFormatString = "{0:N2}";

            C_Patrimonio_Dynamic_variacio.Width = 90;

            C_Patrimonio_Dynamic_variacio.IsReadOnly = true;
            C_Patrimonio_Dynamic_variacio.HeaderTextAlignment = TextAlignment.Center;
            C_Patrimonio_Dynamic_variacio.TextAlignment = TextAlignment.Center;

            RadGridVariacio.AutoGenerateColumns = false;

            RadGridVariacio.Columns.Add(C_id_Dynamic_variacio);
            RadGridVariacio.Columns.Add(C_Patrimonio_Dynamic_variacio);


            RadGridVariacio.MinWidth = 92;
            RadGridVariacio.IsFilteringAllowed = false;
            RadGridVariacio.CanUserSortColumns = false;
            RadGridVariacio.CanUserSortGroups = false;
            RadGridVariacio.ShowGroupPanel = false;
            RadGridVariacio.RowIndicatorVisibility = Visibility.Collapsed;
            RadGridVariacio.CellEditEnded += new EventHandler<Telerik.Windows.Controls.GridViewCellEditEndedEventArgs>(myGrid_CellEditEnded);
            RadGridVariacio.DataLoaded += new EventHandler<EventArgs>(myGrid_DataLoaded);
            RadGridVariacio.ColumnWidth = '*';
            RadGridVariacio.Width = 92;

            #endregion
            
            RadGridVariacio.ItemsSource = GetTotalVariacio(plantilla.CodigoIc,IsinTofilter);
            ScrollViewer.SetHorizontalScrollBarVisibility(RadGridVariacio, ScrollBarVisibility.Hidden);
            this.GridList.Children.Add(RadGridVariacio);
            Ancho = Ancho + RadGridVariacio.Width;
            #endregion
        }

        private  List<T_EvolucionPatrimonioConjuntoGuissona> GetTotalCalculated(string CodigoIc,string Isin)
        {

            var totalCalculated = dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(r => r.CodigoIC == CodigoIc).GroupBy(c => c.Fecha).SelectMany(cl => cl.Select(
                   csLine => new T_EvolucionPatrimonioConjuntoGuissona
                   {
                       IsinFondo = csLine.IsinFondo,
                       Fecha = csLine.Fecha,
                       Patrimonio = cl.Sum(c => c.Patrimonio),
                   })).ToList<T_EvolucionPatrimonioConjuntoGuissona>();

            
            return totalCalculated.Where(c => c.IsinFondo == Isin).ToList();

        }

        private List<T_EvolucionPatrimonioConjuntoGuissona> GetTotalVariacio(string CodigoIc, string Isin)
        {

            var totalVariacio = dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(r => r.CodigoIC == CodigoIc).GroupBy(c => c.Fecha).SelectMany(cl => cl.Select(
                    csLine => new T_EvolucionPatrimonioConjuntoGuissona
                    {
                        IsinFondo = csLine.IsinFondo,
                        Fecha = csLine.Fecha,
                        Patrimonio = cl.Sum(c => c.Patrimonio),
                    })).ToList<T_EvolucionPatrimonioConjuntoGuissona>();

            List<T_EvolucionPatrimonioConjuntoGuissona> TotalVariacioCalculated = new List<T_EvolucionPatrimonioConjuntoGuissona>();

            int k = 0;
            foreach (var item in totalVariacio.Where(c => c.IsinFondo == Isin))
            {
                T_EvolucionPatrimonioConjuntoGuissona tmpEvo = new T_EvolucionPatrimonioConjuntoGuissona();
                if (item.Patrimonio == 0 || item.Patrimonio == null)
                {
                    tmpEvo.Fecha = item.Fecha;
                    tmpEvo.Patrimonio = 0;
                    tmpEvo.IsinFondo = item.IsinFondo;
                }
                else
                {
                    if (k < totalVariacio.Where(c => c.IsinFondo == Isin).ToList().Count - 1)
                    {
                       if (k != 0 && (totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k - 1].Patrimonio == 0 || totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k - 1].Patrimonio == null))
                        {
                            tmpEvo.Fecha = item.Fecha;
                            tmpEvo.IsinFondo = item.IsinFondo;
                            tmpEvo.Patrimonio = 0;

                        }
                        else
                        {
                            tmpEvo.Fecha = item.Fecha;
                            tmpEvo.IsinFondo = item.IsinFondo;
                            if(k!=0)
                                tmpEvo.Patrimonio = totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k].Patrimonio - totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k - 1].Patrimonio;

                        }

                    }
                    else
                    {
                        tmpEvo.Fecha = item.Fecha;
                        tmpEvo.IsinFondo = item.IsinFondo;
                        if (k != 0)
                            tmpEvo.Patrimonio = totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k].Patrimonio - totalVariacio.Where(c => c.IsinFondo == Isin).ToList()[k - 1].Patrimonio;

                    }
                }

                if (tmpEvo.Patrimonio != null)
                {
                    TotalVariacioCalculated.Add(tmpEvo);
                }
                k++;
            }


            return TotalVariacioCalculated;

        }


        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_EvolucionPatrimonioConjuntoGuissona)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_EvolucionPatrimonioConjuntoGuissona)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;

            using (dbContext = new Reports_IICSEntities())
            {
                Temp_EvolucionPatrimonioConjuntoGuissona EvoPatri_temp = EvolucionPatrimConjuntoGuissona_DA.Get_Temp_EvolucionPatrimonioConjuntoGuissonaById(id);
                if (EvoPatri_temp != null)
                {
                    try
                    {
                        #region update Object
                        EvoPatri_temp.Patrimonio = tempRentaCartera_Sel_object.Patrimonio;
                        
                        
                        #endregion

                        #region update Database

                        var EvoPatriToSave = dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(c => c.Id == id).FirstOrDefault();
                        if (EvoPatriToSave != null)
                        {
                            EvoPatriToSave.Patrimonio = tempRentaCartera_Sel_object.Patrimonio;
                        }

                        dbContext.SaveChanges();

                        if (this.GridList.Children.Count > 0)
                        {
                            ((RadGridView)this.GridList.Children[this.GridList.Children.Count - 2]).ItemsSource = GetTotalCalculated(EvoPatri_temp.CodigoIC, EvoPatri_temp.IsinFondo);
                            ((RadGridView)this.GridList.Children[this.GridList.Children.Count - 1]).ItemsSource = GetTotalVariacio(EvoPatri_temp.CodigoIC, EvoPatri_temp.IsinFondo);
                        }

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
