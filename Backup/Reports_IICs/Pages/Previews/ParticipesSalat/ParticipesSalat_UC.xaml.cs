using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.ViewModels.Plantillas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    /// <summary>
    /// Lógica de interacción para ParticipesSalat_UC.xaml
    /// </summary>
    public partial class ParticipesSalat_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;
        public List<ParticipesSalat_Aportaciones> parametrosParticipesSalat_Aportaciones = new List<ParticipesSalat_Aportaciones>();
        private PlantillasPage_VM DataSource = new PlantillasPage_VM();
        public Reports_IICs.DataModels.ParticipesSalat parametrosParticipesSalat = new DataModels.ParticipesSalat();
        public List<ParticipesSalat_Periodos> parametrosParticipesSalat_Periodos = new List<ParticipesSalat_Periodos>();


        public ParticipesSalat_UC()
        {
            InitializeComponent();
            
        }
        public void SaveData(object sender, System.EventArgs e)
        {
            
            GuardarParticipeSalat();
        }

        public ParticipesSalat_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;

            this.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnSelectionChanged));

            var renta = DataAccess.Reports.ParticipesSalatReport_DA.GetTemp_Participes();
            parametrosParticipesSalat = new ParticipesSalat_MNG().Get();

            this.myGrid.ItemsSource = renta;

            var rentaParticipeSalat = DataAccess.Reports.ParticipesReport_DA.GetTemp_ParticipesSalat(plantilla.CodigoIc, isin);

            Txt_APortaciones.Text = "APORTACIONES(" + (DateTime.Now.Year-1) + "-" + DateTime.Now.Year + ")";
            Txt_Valor.Text="VALOR A " + DateTime.Now.ToShortDateString();

            Txt_APortacionesValue.IsReadOnly = true;
            Txt_Resultado.IsReadOnly = true;
            Txt_ResultadoValue.IsReadOnly = true;
            Txt_ValorValue.Text = "0";
            Txt_APortacionesValue.Text = "0";
            Txt_ResultadoValue.Text = "0";

            if (rentaParticipeSalat.Count>0)
            {
                txt_TituloInforme.Text = rentaParticipeSalat.FirstOrDefault().TituloInforme;

               if (rentaParticipeSalat.SingleOrDefault().ParticipesSalat_Aportaciones!=null)
                {
                    this.myGridAportacionesDesglose.ItemsSource = rentaParticipeSalat.SingleOrDefault().ParticipesSalat_Aportaciones.ToList();
                    parametrosParticipesSalat_Aportaciones = rentaParticipeSalat.SingleOrDefault().ParticipesSalat_Aportaciones.ToList();

                    decimal SumAportaciones = parametrosParticipesSalat_Aportaciones.GroupBy(c => c.IdParticipeSalat).SelectMany(cl => cl.Select(d => d.Aportacion)).Sum();

                    Txt_APortacionesValue.Text = String.Format("{0:N2}", SumAportaciones);
                }
               
                Txt_APortaciones.Text = rentaParticipeSalat.FirstOrDefault().Aportaciones_EvolCart_Text;

                //rentaParticipeSalat.FirstOrDefault().Valor_EvolCartera = (Txt_ValorValue.Text != null) ? Convert.ToDecimal(Txt_ValorValue.Text) : 0;
                Txt_Valor.Text = String.Format("{0:N2}", rentaParticipeSalat.FirstOrDefault().Valor_EvolCart_Text); 
                Txt_ValorValue.Text = String.Format("{0:N2}", rentaParticipeSalat.FirstOrDefault().Valor_EvolCartera);
                //rentaParticipeSalat.FirstOrDefault().CodigoIC = _plantilla.CodigoIc;
                txt_EvolucionCarteras.Text = String.Format("{0:N2}", rentaParticipeSalat.FirstOrDefault().EvolucionCarteras_Text);
                Txt_ResultadoAcumuladoValor.Text = String.Format("{0:N2}", rentaParticipeSalat.FirstOrDefault().TotalPeriodos);
                Txt_TotalPeriodos.Text = String.Format("{0:N2}", rentaParticipeSalat.FirstOrDefault().TotalPeriodos_Text);

                int i = 1;
                if(rentaParticipeSalat.FirstOrDefault().ParticipesSalat_Periodos!=null && rentaParticipeSalat.FirstOrDefault().ParticipesSalat_Periodos.Count>0)
                {
                    ParticipesSalat_Periodos ParamParticipesSalat_Periodos = new ParticipesSalat_Periodos();
                    //Aunque tengamos guardado un periodo por cada fecha de generación sólo tenemos que mostrar uno por año
                    var periodos = rentaParticipeSalat.FirstOrDefault().ParticipesSalat_Periodos.GroupBy(x => x.FechaSaldo.Year, (key, g) => g.OrderByDescending(e => e.FechaSaldo).Where(w=>w.FechaSaldo <= _fecha).First());


                    List<ParticipesSalat_Periodos_Lineas> ParamParticipesSalat_Periodos_Lineas = new List<ParticipesSalat_Periodos_Lineas>();

                    //foreach (Temp_ParticipesSalat_Periodos itemPeriodo in rentaParticipeSalat.FirstOrDefault().Temp_ParticipesSalat_Periodos)
                    //foreach (ParticipesSalat_Periodos itemPeriodo in rentaParticipeSalat.FirstOrDefault().ParticipesSalat_Periodos.OrderBy(o=>o.FechaSaldo == _fecha).ThenBy(t =>t.FechaSaldo))
                    foreach (ParticipesSalat_Periodos itemPeriodo in periodos.OrderBy(t => t.FechaSaldo))
                    {
                        //if(i==1)
                        if(itemPeriodo.FechaSaldo != _fecha && GridList.Children.Count == 0)
                        {

                            #region First
                            ParamParticipesSalat_Periodos = itemPeriodo;
                            ParamParticipesSalat_Periodos_Lineas = itemPeriodo.ParticipesSalat_Periodos_Lineas.ToList();
                            this.GridList.Children.Add(new Param_ParticipesSalat_Periodos_First(ParamParticipesSalat_Periodos, ParamParticipesSalat_Periodos_Lineas,plantilla.CodigoIc));
                            var p = (Param_ParticipesSalat_Periodos_First)this.GridList.Children[this.GridList.Children.Count - 1];
                            
                            p.HasAddedaNewRow += new EventHandler(SaveData);
                            #endregion
                        }
                        else
                        {
                            #region Other
                            ParamParticipesSalat_Periodos = itemPeriodo;
                            ParamParticipesSalat_Periodos_Lineas = itemPeriodo.ParticipesSalat_Periodos_Lineas.ToList();
                            this.GridList.Children.Add(new Param_ParticipesSalat_Periodos(ParamParticipesSalat_Periodos, ParamParticipesSalat_Periodos_Lineas));
                            var p = (Param_ParticipesSalat_Periodos)this.GridList.Children[this.GridList.Children.Count - 1];

                            p.HasAddedaNewRow += new EventHandler(SaveData);
                            #endregion
                        }
                        //itemPeriodo.Temp_ParticipesSalat_Periodos_Lineas
                        i++;
                    }
                }
            }
            
        }

     

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedValue = this.myGridAportacionesDesglose.SelectedItem;
            decimal AportacionBeforeToUpdate = 0;

            if (selectedValue!=null && e.AddedItems.Count > 0)
            {

                #region Editar
                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Editar")
                {
                    #region showWindow

                    ParticipesSalat_Aportaciones param_ParticipesSalat_Aportaciones = new ParticipesSalat_Aportaciones();
                    #region default

                    #region Fill List with List of Codes

                    var rows = this.myGridAportacionesDesglose.ChildrenOfType<GridViewRow>();
                    var selectedrow = this.myGridAportacionesDesglose.SelectedItem;
                    List<string> ListadoNoselected = new List<string>();
                    //foreach (GridViewRow item in rows)
                    //{
                    //    ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

                    //}
                    //ListadoNoselected.Remove(((Reports_IICs.DataModels.Temp_ParticipesSalat_Aportaciones)selectedrow).Titular);
                    #endregion

                    string wAportacion = string.Empty;
                    int wIdTitular = 0;
                    //string wTitular = string.Empty;
                    //int? wIdParametroParticipeSalat = ((Temp_ParticipesSalat_Aportaciones)selectedrow).IdTempParticipeSalat;
                    int? wIdParametroParticipeSalat = ((ParticipesSalat_Aportaciones)selectedrow).IdParticipeSalat;


                    DateTime wFecha = DateTime.Now;
                    #region Create Custom object to take values

                        param_ParticipesSalat_Aportaciones = (ParticipesSalat_Aportaciones)this.myGridAportacionesDesglose.SelectedItem;
                        if(param_ParticipesSalat_Aportaciones!= null)
                        {
                            wAportacion = param_ParticipesSalat_Aportaciones.Aportacion.ToString();
                        //wTitular = param_ParticipesSalat_Aportaciones.Titular;
                        wIdTitular = param_ParticipesSalat_Aportaciones.IdTitular;
                        wIdParametroParticipeSalat = param_ParticipesSalat_Aportaciones.IdParticipeSalat;
                        wFecha = param_ParticipesSalat_Aportaciones.Fecha;
                            AportacionBeforeToUpdate= param_ParticipesSalat_Aportaciones.Aportacion;
                        }

                    #endregion

                    var window = new AddEditAportaciones(wAportacion, wIdTitular, ListadoNoselected, wFecha);
                    

                    if (window != null)
                    {
                        Utils.ShowDialogWindow(window);

                        if (window.DialogResult != null && (bool)window.DialogResult)
                        {
                            #region Retrieve Values from window

                            parametrosParticipesSalat_Aportaciones.Remove(param_ParticipesSalat_Aportaciones);

                            ParticipesSalat_Aportaciones temp_item = new ParticipesSalat_Aportaciones();
                            temp_item.Aportacion = Convert.ToDecimal(window.Aportacion);
                            temp_item.Titular = window.Titular;
                            temp_item.IdParticipeSalat = window.IdParticipe;
                            temp_item.Fecha = window.Fecha;

                            //Guardamos en DB la aportación
                            new ParticipesSalat_Aportaciones_MNG().Save(temp_item, null);

                            parametrosParticipesSalat_Aportaciones.Add(temp_item);
                            this.myGridAportacionesDesglose.ItemsSource = null;
                            this.myGridAportacionesDesglose.ItemsSource = parametrosParticipesSalat_Aportaciones;
                            parametrosParticipesSalat.ParticipesSalat_Aportaciones = parametrosParticipesSalat_Aportaciones;
                            #endregion

                            #region Update total data Aportaciones

                            decimal tmpAportacion = Convert.ToDecimal(Txt_APortacionesValue.Text) - AportacionBeforeToUpdate;
                             tmpAportacion = tmpAportacion + temp_item.Aportacion;
                           
                            Txt_APortacionesValue.Text = String.Format("{0:N2}", tmpAportacion);
                            decimal tmpValor = Convert.ToDecimal(Txt_ValorValue.Text);
                            
                            decimal tmpResultado = tmpValor - tmpAportacion;
                            Txt_ResultadoValue.Text = String.Format("{0:N2}", tmpResultado); // tmpResultado.ToString();

                            #endregion

                            this.myGridAportacionesDesglose.SelectedItem = null;
                        }
                        else
                        {
                            this.myGridAportacionesDesglose.SelectedItem = null;
                        }
                    }
                    #endregion

                    #endregion
                }
                #endregion

                #region Eliminar

                if (((Reports_IICs.ViewModels.Instrumentos.Action)((object[])e.AddedItems)[0]).Name == "Eliminar")
                {
                    //bool? dialogResult = null;
                    //Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
                    //parameters.Content = "¿Esta seguro que desea eliminar?";

                    //parameters.Closed = (w, a) =>
                    //{
                    //    dialogResult = a.DialogResult;
                    //};

                    //parameters.Header = "Eliminar";

                    //Telerik.Windows.Controls.RadWindow.Confirm(parameters);

                    string mensaje = "¿Esta seguro que desea eliminar?";
                    //if (dialogResult == true)
                    if(Utils.ShowDialogPopup(mensaje))
                    {
                        #region Delete

                        ParticipesSalat_Aportaciones param_ParticipesSalat_Aportaciones = new ParticipesSalat_Aportaciones();
                        param_ParticipesSalat_Aportaciones = (ParticipesSalat_Aportaciones)this.myGridAportacionesDesglose.SelectedItem;

                            #region Update total data Aportaciones

                            decimal tmpAportacion = Convert.ToDecimal(Txt_APortacionesValue.Text) - param_ParticipesSalat_Aportaciones.Aportacion;
                        
                            Txt_APortacionesValue.Text = String.Format("{0:N2}", tmpAportacion);
                        decimal tmpValor = Convert.ToDecimal(Txt_ValorValue.Text);

                            decimal tmpResultado = tmpValor - tmpAportacion;
                            Txt_ResultadoValue.Text = String.Format("{0:N2}", tmpResultado);

                        #endregion

                        parametrosParticipesSalat_Aportaciones.Remove(param_ParticipesSalat_Aportaciones);
                        
                        this.myGridAportacionesDesglose.ItemsSource = null;
                        this.myGridAportacionesDesglose.ItemsSource = parametrosParticipesSalat_Aportaciones;
                        parametrosParticipesSalat.ParticipesSalat_Aportaciones = parametrosParticipesSalat_Aportaciones;

                        this.myGridAportacionesDesglose.SelectedItem = null;

                        //Borramos en DB la aportación
                        new ParticipesSalat_Aportaciones_MNG().Delete(param_ParticipesSalat_Aportaciones.Id);
                        #endregion
                    }
                    else
                    {
                        //cancel
                        //e.Cancel = true;
                        
                    }

                }
                #endregion

               
            }

            GuardarParticipeSalat();
        }
        
        private void AddNewEvolucion(object sender, RoutedEventArgs e)
        {
            if (this.GridList.Children.Count>0)
            {
                ParticipesSalat_Periodos ParamParticipesSalat_Periodos = new ParticipesSalat_Periodos();
                List<ParticipesSalat_Periodos_Lineas> ParamParticipesSalat_Periodos_Lineas = new List<ParticipesSalat_Periodos_Lineas>();

                ParamParticipesSalat_Periodos.IdTempParticipeSalat = parametrosParticipesSalat.Id;
                ParamParticipesSalat_Periodos.Descripcion = "EVOLUCIÓN SICAV";
                ParamParticipesSalat_Periodos.FechaSaldo = DateTime.Now;
                this.GridList.Children.Add(new Param_ParticipesSalat_Periodos(ParamParticipesSalat_Periodos, ParamParticipesSalat_Periodos_Lineas));
                var p = (Param_ParticipesSalat_Periodos)this.GridList.Children[this.GridList.Children.Count - 1];

                p.HasAddedaNewRow += new EventHandler(SaveData);
                //this.Height = 300;
                //this.Width = 732;
                new ParticipesSalat_Periodos_MNG().Save(ParamParticipesSalat_Periodos, null);
            }
            else
            {
                ParticipesSalat_Periodos ParamParticipesSalat_Periodos = new ParticipesSalat_Periodos();
                //ParamParticipesSalat_Periodos.IdTempParticipeSalat
                List<ParticipesSalat_Periodos_Lineas> ParamParticipesSalat_Periodos_Lineas = new List<ParticipesSalat_Periodos_Lineas>();

                ParamParticipesSalat_Periodos.IdTempParticipeSalat = parametrosParticipesSalat.Id;
                ParamParticipesSalat_Periodos.FechaSaldo = DateTime.Now;
                ParamParticipesSalat_Periodos.Descripcion = "EVOLUCIÓN SICAV";
                this.GridList.Children.Add(new Param_ParticipesSalat_Periodos_First(ParamParticipesSalat_Periodos, ParamParticipesSalat_Periodos_Lineas, _plantilla.CodigoIc));
                var p = (Param_ParticipesSalat_Periodos_First)this.GridList.Children[this.GridList.Children.Count - 1];

                p.HasAddedaNewRow += new EventHandler(SaveData);
                //this.Height = 300;
                //this.Width = 702;
                new ParticipesSalat_Periodos_MNG().Save(ParamParticipesSalat_Periodos, null);
            }
            //GuardarParticipeSalat();

            #region update object id
            int i = 0;

            var ps = new ParticipesSalat_MNG().Get();

            var LPeriods = (ps != null)? ps.ParticipesSalat_Periodos.ToList():null;

            //El periodo autocalculado, que es el último periodo hasta la fecha de generación,
            //siempre lo ponemos al final
            //Del resto de periodos, pondremos el más antiguo al principio, con un control específico por ser el primero
            //var fechaPrimerPeriodo = LPeriods.Where(w => w.FechaSaldo != _fecha).Select(s => s.FechaSaldo).Min();
            foreach (Reports_IICs.DataModels.ParticipesSalat_Periodos item in LPeriods)
            {
                var tipoItem = this.GridList.Children[i].GetType();
                if (tipoItem == typeof(Param_ParticipesSalat_Periodos_First))
                {
                    ((Param_ParticipesSalat_Periodos_First)this.GridList.Children[i]).paramParticipesSalat_Periodos.Id = item.Id;
                }
                else if (tipoItem == typeof(Param_ParticipesSalat_Periodos))
                {
                    ((Param_ParticipesSalat_Periodos)this.GridList.Children[i]).paramParticipesSalat_Periodos.Id = item.Id;
                }
                
                //if (i == 0) ((Param_ParticipesSalat_Periodos_First)this.GridList.Children[i]).paramParticipesSalat_Periodos.Id = item.Id;
                //if (i >0) ((Param_ParticipesSalat_Periodos)this.GridList.Children[i]).paramParticipesSalat_Periodos.Id = item.Id;
                i++;
            }

            
            #endregion
        }

        private void AddNewAportacion(object sender, RoutedEventArgs e)
        {

            #region Add new Row
            #region showWindow

            #region Fill List with List of Codes
            
            var rows = this.myGridAportacionesDesglose.ChildrenOfType<GridViewRow>();

            List<string> ListadoNoselected = new List<string>();
            foreach (GridViewRow item in rows)
            {
                ListadoNoselected.Add(((Telerik.Windows.Controls.GridView.GridViewCell)(item.Cells[1])).Value.ToString());

            }

            #endregion

            var window = new AddEditAportaciones(string.Empty, null, ListadoNoselected, DateTime.Now);
                     
            if (window != null)
            {
                Utils.ShowDialogWindow(window);             

                if (window.DialogResult != null && (bool)window.DialogResult)
                {
                    #region Retrieve Values from window

                    ParticipesSalat_Aportaciones temp_item = new ParticipesSalat_Aportaciones();
                    temp_item.IdParticipeSalat = parametrosParticipesSalat.Id;
                    temp_item.Aportacion = Convert.ToDecimal(window.Aportacion);
                    temp_item.Titular = window.Titular;
                    temp_item.IdTitular = window.IdParticipe;
                    temp_item.Fecha = window.Fecha;
                    if (parametrosParticipesSalat_Aportaciones == null)
                        parametrosParticipesSalat_Aportaciones = new List<ParticipesSalat_Aportaciones>();
                    parametrosParticipesSalat_Aportaciones.Add(temp_item);

                    //Guardamos en DB la aportación
                    new ParticipesSalat_Aportaciones_MNG().Save(temp_item, null);

                    decimal tmpAportacion = Convert.ToDecimal(Txt_APortacionesValue.Text) + temp_item.Aportacion;
                    Txt_APortacionesValue.Text = String.Format("{0:N2}", tmpAportacion);
                    if (!string.IsNullOrEmpty(Txt_ValorValue.Text))
                    {
                        decimal tmpValor = Convert.ToDecimal(Txt_ValorValue.Text);
                        Txt_ValorValue.Text = String.Format("{0:N2}", tmpValor);
                        decimal tmpResultado = tmpValor - tmpAportacion;
                        Txt_ResultadoValue.Text = String.Format("{0:N2}", tmpResultado);
                    }


                    myGridAportacionesDesglose.ItemsSource = null;
                    myGridAportacionesDesglose.ItemsSource = parametrosParticipesSalat_Aportaciones;

                    //_plantilla.Temp_ParticipesSalat.Add();

                    #endregion

                    //GuardarParticipeSalat();
                }
            }
            #endregion
            #endregion

            
        }

        public void GuardarParticipeSalat()
        {
            if (_plantilla != null)
            {
                recalcularResultadoAcumulado();

                parametrosParticipesSalat_Periodos = new List<ParticipesSalat_Periodos>();

                int? idSalat = 0;
                var obj = new ParticipesSalat_MNG().Get();
                var ParticipeExist = new Reports_IICs.DataModels.ParticipesSalat();
                if (obj != null)
                {
                    Utils.CopyPropertyValues(obj, ParticipeExist);
                    idSalat = obj.Id;
                }
                //if (ParticipeExist != null)
                //{
                //    parametrosParticipesSalat = ParticipeExist;

                //    idSalat = parametrosParticipesSalat.Id;
                //}

                #region partícipes
                parametrosParticipesSalat.ParticipesSalat_Participes.Clear();

                foreach (var item in (ObservableCollection<T_ParticipesSalat>)myGrid.ItemsSource)
                {
                    var part = new ParticipesSalat_Participes();
                    Utils.CopyPropertyValues(item, part);
                    parametrosParticipesSalat.ParticipesSalat_Participes.Add(part);
                }
                
                #endregion

                #region periodos

                #region delete before
                //int n = 0;
                //var periodstoDel = parametrosParticipesSalat.Temp_ParticipesSalat_Periodos;
                //foreach (var item in periodstoDel)
                //{
                //    parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.ToList().RemoveAt(n);
                //    n++;
                //}
                #endregion

                if (this.GridList.Children.Count > 0)
                {
                    foreach (var item in this.GridList.Children)
                    {
                        if (item is Param_ParticipesSalat_Periodos_First)
                        {
                            #region First
                            var pParticipesSalat_Periodos_First = (Param_ParticipesSalat_Periodos_First)item;

                            ParticipesSalat_Periodos temp_Part_Periodos = new ParticipesSalat_Periodos();


                            if (pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos != null)
                            {
                                temp_Part_Periodos.Descripcion = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.Descripcion;
                                temp_Part_Periodos.FechaSaldo = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.FechaSaldo;

                                if (pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.IdTempParticipeSalat != 0)
                                {
                                    temp_Part_Periodos.IdTempParticipeSalat = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.IdTempParticipeSalat;

                                }
                                else
                                {
                                    if (idSalat != 0) temp_Part_Periodos.IdTempParticipeSalat = idSalat.Value;
                                }
                                temp_Part_Periodos.ParticipesSalat = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.ParticipesSalat;

                                foreach (var itemPerLinea in pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos_Lineas)
                                {
                                    temp_Part_Periodos.ParticipesSalat_Periodos_Lineas.Add(itemPerLinea);
                                }


                                //parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.Add(temp_Part_Periodos);
                                parametrosParticipesSalat_Periodos.Add(temp_Part_Periodos);
                            }

                            #endregion

                        }
                        else
                        {
                            #region OtHER
                            if (item is Param_ParticipesSalat_Periodos)
                            {
                                var pParticipesSalat_Periodos = (Param_ParticipesSalat_Periodos)item;



                                ParticipesSalat_Periodos temp_Part_Periodos = new ParticipesSalat_Periodos();


                                if (pParticipesSalat_Periodos.paramParticipesSalat_Periodos != null)
                                {

                                    temp_Part_Periodos.Descripcion = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.Descripcion;
                                    temp_Part_Periodos.FechaSaldo = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.FechaSaldo;
                                    temp_Part_Periodos.IdTempParticipeSalat = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.IdTempParticipeSalat;
                                    temp_Part_Periodos.ParticipesSalat = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.ParticipesSalat;

                                    foreach (var itemPerLinea in pParticipesSalat_Periodos.paramParticipesSalat_Periodos_Lineas)
                                    {
                                        temp_Part_Periodos.ParticipesSalat_Periodos_Lineas.Add(itemPerLinea);
                                    }


                                    //parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.Add(temp_Part_Periodos);
                                    parametrosParticipesSalat_Periodos.Add(temp_Part_Periodos);
                                }
                            }
                            #endregion
                        }
                    }
                    // parametrosParticipesSalat.Temp_ParticipesSalat_Periodos
                }
                #endregion


                parametrosParticipesSalat.Aportaciones_EvolCart_Text = Txt_APortaciones.Text;
                parametrosParticipesSalat.Valor_EvolCartera = (Txt_ValorValue != null && !string.IsNullOrEmpty(Txt_ValorValue.Text)) ? Convert.ToDecimal(Txt_ValorValue.Text) : 0;
                parametrosParticipesSalat.Valor_EvolCart_Text = Txt_Valor.Text;
                //parametrosParticipesSalat.CodigoIC = _plantilla.CodigoIc;
                parametrosParticipesSalat.EvolucionCarteras_Text = txt_EvolucionCarteras.Text;

                int index = 0;

                #region Periodos

                foreach (var itemPeriodo in parametrosParticipesSalat_Periodos)
                {
                    if (parametrosParticipesSalat.ParticipesSalat_Periodos.Count > 0 && parametrosParticipesSalat.ParticipesSalat_Periodos.Count >= (index + 1))
                    {
                        parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].Descripcion = itemPeriodo.Descripcion;
                        parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].FechaSaldo = itemPeriodo.FechaSaldo;

                        var PeriodosLineas = parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas;

                        int i = 0;
                        foreach (var item in PeriodosLineas)
                        {
                            parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas.ToList().RemoveAt(i);
                            i++;
                        }
                        parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas = itemPeriodo.ParticipesSalat_Periodos_Lineas.OrderBy(c => c.Id).ToList();


                    }
                    else
                    {
                        itemPeriodo.IdTempParticipeSalat = (idSalat == 0) ? 0 : idSalat.Value;

                        parametrosParticipesSalat.ParticipesSalat_Periodos.Add(itemPeriodo);
                    }
                    index++;
                }

                //parametrosParticipesSalat.Temp_ParticipesSalat_Periodos = parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.OrderBy(c => c.Temp_ParticipesSalat_Periodos_Lineas.OrderBy(b=>b.Id)).ToList();



                parametrosParticipesSalat.TituloInforme = txt_TituloInforme.Text;
                if (!string.IsNullOrEmpty(Txt_ResultadoAcumuladoValor.Text))
                {
                    parametrosParticipesSalat.TotalPeriodos = Convert.ToDecimal(Txt_ResultadoAcumuladoValor.Text);
                }
                parametrosParticipesSalat.TotalPeriodos_Text = Txt_TotalPeriodos.Text;

                #endregion

                #region Add ID Participe if update

                foreach (var item in parametrosParticipesSalat_Aportaciones)
                {
                    item.IdParticipeSalat = (idSalat == 0) ? 0 : idSalat.Value;
                }
                #endregion

                #region Aportaciones
                var AportToDelete = parametrosParticipesSalat.ParticipesSalat_Aportaciones;
                int k = 0;
                foreach (var item in AportToDelete)
                {
                    parametrosParticipesSalat.ParticipesSalat_Aportaciones.ToList().RemoveAt(k);
                    k++;
                }

                parametrosParticipesSalat.ParticipesSalat_Aportaciones = parametrosParticipesSalat_Aportaciones;
                #endregion

                //var ps = new ParticipesSalat_MNG().Get();

                //if (ps == null)
                //{
                //    ps = new DataModels.ParticipesSalat();
                //}
                //Utils.CopyPropertyValues(parametrosParticipesSalat, ps);
                //else
                //{
                //    _plantilla.ParticipesSalats.Remove(ParticipeExist);
                //    _plantilla.Temp_ParticipesSalat.Add(parametrosParticipesSalat);
                //}
                try
                {
                    //Guardamos lo generado en este momento
                    new ParticipesSalat_MNG().Save(parametrosParticipesSalat, null);
                    //new PlantillaManager().Save(_plantilla, string.Empty);
                    //Plantilla plantilla_updated;
                    //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                    //{

                    //    _plantilla = plantilla_updated;
                    //}
                    //else
                    //{
                    //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                    //RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });                    
                }

            }

            recalcularResultadoAcumulado();
        }
       
        private void GuardarParticipeSalat(object sender, RoutedEventArgs e)
        {

            
            parametrosParticipesSalat_Periodos = new List<ParticipesSalat_Periodos>();

            int? idSalat=0;
            var ParticipeExist = new ParticipesSalat_MNG().Get();

            if(ParticipeExist!=null)
            {
                parametrosParticipesSalat = ParticipeExist;

                 idSalat = parametrosParticipesSalat.Id;
            }

            #region periodos

            #region delete before
            //int n = 0;
            //var periodstoDel = parametrosParticipesSalat.Temp_ParticipesSalat_Periodos;
            //foreach (var item in periodstoDel)
            //{
            //    parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.ToList().RemoveAt(n);
            //    n++;
            //}
            #endregion

            if (this.GridList.Children.Count>0)
            {
                foreach (var item in this.GridList.Children)
                {
                    if (item is Param_ParticipesSalat_Periodos_First)
                    {
                        #region First
                        var pParticipesSalat_Periodos_First = (Param_ParticipesSalat_Periodos_First)item;

                        ParticipesSalat_Periodos temp_Part_Periodos = new ParticipesSalat_Periodos();


                        if(pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos!=null)
                        {
                            temp_Part_Periodos.Descripcion = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.Descripcion;
                            temp_Part_Periodos.FechaSaldo = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.FechaSaldo;
                            temp_Part_Periodos.IdTempParticipeSalat = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.IdTempParticipeSalat;
                            temp_Part_Periodos.ParticipesSalat = pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos.ParticipesSalat;

                            foreach (var itemPerLinea in pParticipesSalat_Periodos_First.paramParticipesSalat_Periodos_Lineas)
                            {
                                temp_Part_Periodos.ParticipesSalat_Periodos_Lineas.Add(itemPerLinea);
                            }
                            

                            //parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.Add(temp_Part_Periodos);
                            parametrosParticipesSalat_Periodos.Add(temp_Part_Periodos);
                        }

                        #endregion

                    }
                    else
                    {
                        #region OtHER
                        if (item is Param_ParticipesSalat_Periodos)
                        {
                            var pParticipesSalat_Periodos = (Param_ParticipesSalat_Periodos)item;

                           

                            ParticipesSalat_Periodos temp_Part_Periodos = new ParticipesSalat_Periodos();


                            if (pParticipesSalat_Periodos.paramParticipesSalat_Periodos != null)
                            {
                                
                                temp_Part_Periodos.Descripcion = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.Descripcion;
                                temp_Part_Periodos.FechaSaldo = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.FechaSaldo;
                                temp_Part_Periodos.IdTempParticipeSalat = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.IdTempParticipeSalat;
                                temp_Part_Periodos.ParticipesSalat = pParticipesSalat_Periodos.paramParticipesSalat_Periodos.ParticipesSalat;

                                foreach (var itemPerLinea in pParticipesSalat_Periodos.paramParticipesSalat_Periodos_Lineas)
                                {
                                    temp_Part_Periodos.ParticipesSalat_Periodos_Lineas.Add(itemPerLinea);
                                }


                                //parametrosParticipesSalat.Temp_ParticipesSalat_Periodos.Add(temp_Part_Periodos);
                                parametrosParticipesSalat_Periodos.Add(temp_Part_Periodos);
                            }
                        }
                        #endregion
                    }
                }
               // parametrosParticipesSalat.Temp_ParticipesSalat_Periodos
            }
            #endregion


            parametrosParticipesSalat.Aportaciones_EvolCart_Text = Txt_APortaciones.Text;
            parametrosParticipesSalat.Valor_EvolCartera = (Txt_ValorValue.Text!=null)?Convert.ToDecimal(Txt_ValorValue.Text):0;
            parametrosParticipesSalat.Valor_EvolCart_Text = Txt_Valor.Text;
            //parametrosParticipesSalat.CodigoIC = _plantilla.CodigoIc;
            parametrosParticipesSalat.EvolucionCarteras_Text = txt_EvolucionCarteras.Text;

            int index = 0;

            foreach (var itemPeriodo in parametrosParticipesSalat_Periodos)
            {
                if (parametrosParticipesSalat.ParticipesSalat_Periodos.Count > 0 && parametrosParticipesSalat.ParticipesSalat_Periodos.Count >= (index + 1))
                {
                    parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].Descripcion = itemPeriodo.Descripcion;
                    parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].FechaSaldo = itemPeriodo.FechaSaldo;

                    var PeriodosLineas = parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas;

                    int i = 0;
                    foreach (var item in PeriodosLineas)
                    {
                        parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas.ToList().RemoveAt(i);
                        i++;
                    }
                    parametrosParticipesSalat.ParticipesSalat_Periodos.ToList()[index].ParticipesSalat_Periodos_Lineas = itemPeriodo.ParticipesSalat_Periodos_Lineas;

                   
                }
                else
                {
                    itemPeriodo.IdTempParticipeSalat = (idSalat == 0) ? 0 : idSalat.Value;
                    parametrosParticipesSalat.ParticipesSalat_Periodos.Add(itemPeriodo);
                }
                index++;
            }


            parametrosParticipesSalat.TituloInforme = txt_TituloInforme.Text;
            parametrosParticipesSalat.TotalPeriodos = Convert.ToDecimal(Txt_ResultadoAcumuladoValor.Text);
            parametrosParticipesSalat.TotalPeriodos_Text = Txt_TotalPeriodos.Text;

            #region Add ID Participe if update
           
            foreach (var item in parametrosParticipesSalat_Aportaciones)
            {
                item.IdParticipeSalat = (idSalat == 0) ? 0 : idSalat.Value;
            }
            #endregion

            var AportToDelete = parametrosParticipesSalat.ParticipesSalat_Aportaciones;
            int k=0;
            foreach (var item in AportToDelete)
            {
                parametrosParticipesSalat.ParticipesSalat_Aportaciones.ToList().RemoveAt(k);
                k++;
            }
            
            parametrosParticipesSalat.ParticipesSalat_Aportaciones = parametrosParticipesSalat_Aportaciones;

            if (ParticipeExist == null)
            {
                ParticipeExist = new DataModels.ParticipesSalat();
            }

            Utils.CopyPropertyValues(parametrosParticipesSalat, ParticipeExist);            

                //if(ParticipeExist==null)
                //{
                //    _plantilla.ParticipesSalat.Add(parametrosParticipesSalat);
                //}
                //else
                //{
                //    _plantilla.ParticipesSalat.Remove(ParticipeExist);
                //    _plantilla.ParticipesSalat.Add(parametrosParticipesSalat);
                //}
            try
                {
                //new PlantillaManager().Save(_plantilla, string.Empty);
                new ParticipesSalat_MNG().Save(ParticipeExist, null);

                //Plantilla plantilla_updated;
                //if (DataSource.GuardarPlantilla(_plantilla, _plantilla.CodigoIc, out plantilla_updated))
                //{

                //    _plantilla = plantilla_updated;
                //}
                //else
                //{
                //    RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });

                //}
            }
            catch
            {
                RadWindow.Alert(new DialogParameters { Content = "Se Ha producido un error al Grabar la Plantilla", Header = "Error:" });
            }
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);
        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempRentaCartera_Sel_object = (T_ParticipesSalat)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                T_ParticipesSalat RentaCartera_temp = ParticipesSalat_DA.Get_Temp_ParticipesSalatById(id);
                if (RentaCartera_temp != null)
                {
                    decimal Total = 0;

                    #region Calculate SumTotal NºParticipaciones
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {
                        if (tempRentaCartera_Sel_object.Id == ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id)
                        {
                            Total = Total + tempRentaCartera_Sel_object.NumeroParticipaciones;
                        }
                        else
                        {
                            Total = Total + ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).NumeroParticipaciones;
                        }
                    }
                    #endregion

                    #region Update 
                    for (int i = 0; i < (((Telerik.Windows.Controls.DataControl)sender).Items).Count; i++)
                    {

                        try
                        {
                            int tmp_id = ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).Id;
                            decimal VLFin = ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).NumeroParticipaciones;
                            decimal tmp_RentabilidadPeriodo = (VLFin / Total) * 100;
                            ((T_ParticipesSalat)(((Telerik.Windows.Controls.DataControl)sender).Items)[i]).PorcentajeParticipacion = tmp_RentabilidadPeriodo;

                            #region update Object
                            RentaCartera_temp = ParticipesSalat_DA.Get_Temp_ParticipesSalatById(tmp_id);

                            RentaCartera_temp.NumeroParticipaciones = decimal.Parse(VLFin.ToString());
                            RentaCartera_temp.PorcentajeParticipacion = tmp_RentabilidadPeriodo;
                            #endregion

                            #region update Database
                            // tmp_RentabilidadPeriodo = (VLFin / Total);
                            var RentaParticipeToSave = dbcontext.ParticipesSalat_Participes.Where(c => c.Id == tmp_id).FirstOrDefault();
                            if (RentaParticipeToSave != null)
                            {
                                RentaParticipeToSave.NumeroParticipaciones = decimal.Parse(VLFin.ToString());
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

        private void Txt_ValorValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal tmpAportacion = (string.IsNullOrEmpty(Txt_APortacionesValue.Text.ToString()) == true) ? 0 : Convert.ToDecimal(Txt_APortacionesValue.Text);

            if (!string.IsNullOrEmpty(Txt_ValorValue.Text))
            {
                decimal tmpValor = Convert.ToDecimal(Txt_ValorValue.Text);

                decimal tmpResultado = tmpValor - tmpAportacion;

                if (Txt_ResultadoValue != null) Txt_ResultadoValue.Text = String.Format("{0:N2}", tmpResultado);                
                GuardarParticipeSalat();
            }
        }

        private void Txt_APortacionesValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal tmpAportacion = Convert.ToDecimal(Txt_APortacionesValue.Text);

            decimal tmpValor = (string.IsNullOrEmpty(Txt_ValorValue.Text)==true)?0:Convert.ToDecimal(Txt_ValorValue.Text);

            decimal tmpResultado = tmpValor - tmpAportacion;

            if (Txt_ResultadoValue != null) Txt_ResultadoValue.Text = String.Format("{0:N2}", tmpResultado);
            GuardarParticipeSalat();
        }

        private void EditEvoCartera_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt_EvolucionCarteras.Focus();
        }

        private void txt_TituloInforme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.Changes.Count > 0 && _plantilla!=null)
            {
                if (string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    this.txt_TituloInforme.Text = "TITULO INFORME";
                }
                GuardarParticipeSalat();
            }
            
        }

        private void txt_EvolucionCarteras_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (e.Changes.Count > 0 && _plantilla != null)
            {
                if (string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    this.txt_EvolucionCarteras.Text = "EVOLUCIÓN CARTERAS";
                }
                GuardarParticipeSalat();
            }
        }

        private void Txt_APortaciones_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            if (e.Changes.Count > 0 && _plantilla != null)
            {
                if (string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    this.Txt_APortaciones.Text = "APORTACIONES";
                }
                GuardarParticipeSalat();
            }
        }

        private void Txt_Valor_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (e.Changes.Count > 0 && _plantilla != null)
            {
                if (string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    this.Txt_Valor.Text = "VALOR A";
                }
                GuardarParticipeSalat();
            }
        }

        private void Txt_TotalPeriodos_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (e.Changes.Count > 0 && _plantilla != null)
            {
                if (string.IsNullOrEmpty(((System.Windows.Controls.TextBox)e.OriginalSource).Text))
                {
                    this.Txt_Valor.Text = "TOTAL";
                }
                GuardarParticipeSalat();                
            }


        }

        private void Txt_ResultadoAcumuladoValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            GuardarParticipeSalat();
        }

        private void IMG_Pencil_TotalPeriodos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Txt_TotalPeriodos.Focusable = true;
            Txt_TotalPeriodos.Focus();
            Keyboard.Focus(Txt_TotalPeriodos);
            //Txt_TotalPeriodos.Focus();
            //Txt_TotalPeriodos.SelectAll();
        }

        private void IMG_Pencil_ResultadoAcumuladoValor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Txt_TotalPeriodos.Focus();
            Txt_TotalPeriodos.SelectAll();
        }

        private void recalcularResultadoAcumulado()
        {
            if (_plantilla != null)
            {
                decimal resultadoAport = !string.IsNullOrEmpty(Txt_ResultadoValue.Text) ? Convert.ToDecimal(Txt_ResultadoValue.Text) : 0;
                this.Txt_ResultadoAcumuladoValor.Text = ParticipesSalat_DA.GetResultadoAcumulado(_plantilla.CodigoIc, resultadoAport).ToString();
            }
        }
        
    }
}
