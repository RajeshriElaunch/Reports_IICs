using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.ViewModels.Reports.Secciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace Reports_IICs.Pages.Previews.CarteraCcrVolgaGamar
{
    /// <summary>
    /// Lógica de interacción para RentaVariable_UC.xaml
    /// </summary>
    public partial class CarteraCcrVolgaGamar_UC : UserControl
    {

        private Plantilla _plantilla;
        private List<usp_gestio_pro_13_Result> _pro13;
        protected DateTime _fecha;
        private int filaIndex = 0;
        private int _grupo;
        private List<GridViewMaskedInputColumn> _celsActualizan;
        public CarteraCcrVolgaGamar_UC()
        {
            InitializeComponent();
        }

        public CarteraCcrVolgaGamar_UC(Plantilla plantilla, string isin, DateTime fecha, string titulo, string grupo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            InitializeComponent();

            try
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;

                _celsActualizan = new List<GridViewMaskedInputColumn>() {
                this.NumTit,
                this.PrecioCompra,
                this.PrecioAjustado,
                this.PrecioFin,
                this.PrecioFinEuros,
                this.Efectivo
                };

                _plantilla = plantilla;
                _fecha = fecha;
                _grupo = Utils.GetGrupoInt(grupo);
                var fechaIni = Utils.GetFechaInicio(plantilla, fecha);

                //Aquí tenemos que llamar a GetPRO13 en vez de cogerlo de las VariablesGlobales 
                //porque es una preview y no se ha cargado el procedimiento
                _pro13 = Reports_DA.GetPRO13(plantilla, fechaIni, fecha);

                this.LabelTitulo.Content = titulo;

                var obj = DataAccess.Secciones.RentaVariable_DA.GetGrupoRV(plantilla.CodigoIc, isin, instrumentosIds, tiposInstrumentoIds, grupo);

                this.myGrid.ItemsSource = obj;


                //foreach (var item in this.myGrid.Columns)
                //{
                //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
                //}

                //Para que cuando hagan click en el botón Eliminar no tengan que hacerlo dos veces la primera vez
                //this.myGrid.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// También puede editar el Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            var sel = (T_RentaVariable)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            if (sel != null)
            {
                int id = sel.Id;
                var temp = RentaVariable_DA.GetTempById(id);

                //Cuando no es una fila que están añadiendo
                //ni una fila que fue añadida manualmente y están modificando
                //cuando algún movimiento no viene del PRO, tiene el campo "Grupo" a null
                if (sel != null && (!string.IsNullOrEmpty(sel.Grupo) || sel.GrupoNuevo != null))
                {
                    if (temp != null)
                    {

                        //Los campos NumTit y PrecioAjustado, cuando son modificados en la preview, 
                        //se conservan aunque se vuelva a generar
                        //var objPrecAj = getPrecioAjStored(sender, sel);

                        //Creamos un parámetro usp_gestio_pro_13_Result que es el que necesitan los procedimientos de cálculos
                        var item = getItemPro13Sel(temp);

                        //Sólo actualizamos los totales de la Preview para los registros que no se han añadido manualmente
                        //y sólo cuando se modifica alguna de las celdas en la lista acordada "_celsActualizan"
                        //Los añadidos manualmente no podemos porque necesitaríamos Estado, TipoO, PrecioI, PrecioO, PrecioOA, PrecioF, CambioF, CambioC...
                        var col = ((Telerik.Windows.Controls.GridView.GridViewDataControl)sender).CurrentColumn;

                        if (item != null 
                            && col.GetType() == typeof(GridViewMaskedInputColumn)
                            && _celsActualizan.Contains((GridViewMaskedInputColumn)col))
                        {
                            //Actualizamos los totales en pantalla (Preview)
                            actualizarTotalesEnPantalla(sel, item);
                        }



                        //if (sel.NumTit.HasValue && sel.NumTit != 0)
                        //{
                        //Recalculamos las 4 columnas de totales
                        //Sólo recalculamos las 4 columnas de totales si modifican NumTit o PrecioAjustado
                        //if (temp.NumTit != sel.NumTit || temp.PrecioAjustado != sel.PrecioAjustado)
                        //{
                        /*
                        if (item != null)
                        {
                            //Actualizamos los totales en pantalla (Preview)
                            actualizarTotalesEnPantalla(sel, item);
                        }*/
                        //}
                        //}

                        //actualizamos los datos de la tabla Temp con los datos introducidos por pantalla
                        Utils.CopyPropertyValues(sel, temp, "Id");

                        //Hay que actualizar el PrecioAjustado en su tabla especial

                        ////Si lo dejan a null lo eliminamos de RentaVariable_PrecioAjustado
                        //o si el grupo es el mismo que viene del pro13 (Grupo)
                        //GrupoNuevo es donde almacenaremos el nuevo grupo que establezcan en la Preview
                        //RentaVariable_DA.SavePrecioAjustado(sel, temp, _fecha);
                        /*
                        if ((sel.NumTit.HasValue && sel.PrecioAjustado.HasValue) || sel.GrupoNuevo != Utils.GetGrupoInt(temp.Grupo))
                        {
                            var newPrecAj = new RentaVariable_PrecioAjustado();

                            Utils.CopyPropertyValues(sel, newPrecAj, "Id");
                            newPrecAj.NumeroTitulos = Convert.ToDecimal(sel.NumTit);
                            newPrecAj.PrecioAjustado = Convert.ToDecimal(sel.PrecioAjustado);
                            newPrecAj.Grupo = sel.GrupoNuevo;

                            if (objPrecAj != null)
                            {
                                dbcontext.RentaVariable_PrecioAjustado.Remove(objPrecAj);
                            }

                            dbcontext.RentaVariable_PrecioAjustado.Add(newPrecAj);

                            try
                            {
                                dbcontext.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (!sel.PrecioAjustado.HasValue)
                        {
                            if (objPrecAj != null)
                            {
                                dbcontext.RentaVariable_PrecioAjustado.Remove(objPrecAj);
                            }
                            try
                            {
                                dbcontext.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        */
                    }

                }
                //Si es una fila que nueva que estamos añadiendo en la Preview
                //o una fila que fue añadida manualmente y están modificando
                else
                {
                    //var obj = new RentaVariable_Added();
                    //Utils.CopyPropertyValues(sel, obj);
                    //obj.Ejercicio = _fecha.Year;
                    //if (temp != null && temp.GrupoNuevo != null)
                    //{
                    //    obj.Grupo = Convert.ToInt32(temp.GrupoNuevo);
                    //}
                    //else
                    //    obj.Grupo = _grupo;

                    //RentaVariable_DA.Insert_or_Update_RentaVariable_Added(obj);

                    
                }
            }
        }

        //private RentaVariable_PrecioAjustado getPrecioAjStored(object sender, T_RentaVariable sel)
        //{
        //    //Los campos NumTit y PrecioAjustado, cuando son modificados en la preview, 
        //    //se conservan aunque se vuelva a generar
        //    var objPrecAj = dbcontext.RentaVariable_PrecioAjustado.Where(w =>
        //                        w.CodigoIC == sel.CodigoIC
        //                        && w.Isin == sel.Isin
        //                        //&& w.NumO == sel.NumO
        //                        //&& w.TipoO == sel.TipoO
        //                        //&& w.NumC == sel.NumC
        //                        //&& w.TipoC == sel.TipoC
        //                        ).FirstOrDefault();

        //    return objPrecAj;
        //}

        private usp_gestio_pro_13_Result getItemPro13Sel(Temp_RentaVariable temp)
        {            
            //Creamos un parámetro usp_gestio_pro_13_Result que es el que necesitan los procedimientos de cálculos
            var item = _pro13.Where(w => w.Isin.ToUpper() == temp.Isin.ToUpper()
                                        && w.Grupo.Trim() == temp.Grupo.Trim()
                                        //&& (
                                        //    (temp.FechaCompra != null && w.FechaO == temp.FechaCompra)
                                        //    ||
                                        //    (temp.FechaVenta != null && w.FechaC == temp.FechaVenta)
                                        //    )
                                        ).GroupBy(g => new
                                        {
                                            g.Isin,
                                            //g.FechaC,
                                            //g.FechaO,
                                            g.Estado,
                                            g.Grupo,
                                            g.TipoO
                                            //g.NumO,
                                            //g.TipoC,
                                            //g.NumC
                                        }).Select(s => new usp_gestio_pro_13_Result
                                        {
                                            Isin = s.Key.Isin.ToUpper(),
                                            Estado = s.Key.Estado,
                                            Grupo = s.Key.Grupo,
                                            TipoO = s.Key.TipoO,
                                            //NumO = s.Key.NumO,
                                            //TipoC = s.Key.TipoC,
                                            //NumC = s.Key.NumC,
                                            /*
                                            PrecioF = s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioFEUR = s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioI = s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioO = s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioC = s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioF = s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioI = s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioO = s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioC = s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit)//Media ponderada 
                                            */
                                            CambioC = s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioF = s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioI = s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            CambioO = s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioC = s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioF = s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioFEUR = s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioI = s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioO = s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit),//Media ponderada 
                                            PrecioOA = s.Sum(a => a.PrecioOA * a.NumTit) / s.Sum(a => a.NumTit)//Media ponderada 
                                        }).FirstOrDefault();

            return item;
        }

        private void actualizarTotalesEnPantalla(T_RentaVariable sel, usp_gestio_pro_13_Result item)
        {
            //Actualizamos los totales en pantalla (Preview)
            if (item != null)
            {                
                sel.Efectivo = RentaVariable_VM.CalcularEfectivo(item, sel.NumTit, sel.PrecioFinEuros);
                sel.BoPDivisa = RentaVariable_VM.calcularPLDiv(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
                sel.BoPPrecio = RentaVariable_VM.CalcularPLPrecio(item, sel.NumTit, sel.PrecioAjustado);
                sel.BoPTotal = RentaVariable_VM.calcularPLEur(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
                sel.BoPTotalPorcentaje = RentaVariable_VM.calcularPLPct(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
            }
        }

        private Temp_RentaVariable actualizarTempTable(Temp_RentaVariable temp, T_RentaVariable sel)
        {
            temp.NumTit = Convert.ToDecimal(sel.NumTit);
            temp.PrecioIni = sel.PrecioIni;
            temp.PrecioAjustado = sel.PrecioAjustado;
            temp.PrecioFin = sel.PrecioFin;
            temp.PrecioFinEuros = sel.PrecioFinEuros;
            temp.Efectivo = sel.Efectivo;
            temp.BoPDivisa = sel.BoPDivisa;
            temp.BoPPrecio = sel.BoPPrecio;
            temp.BoPTotal = sel.BoPTotal;
            temp.BoPTotalPorcentaje = sel.BoPTotalPorcentaje;
            return temp;
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
                //if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio != null && ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin != null)
                //{
                //    if (!((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                //    {
                //        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = String.Format("{0:P2}", (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio - decimal.Parse(((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin)) / ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Precio * -1);
                //    }
                //    else
                //    {
                //        ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Variacion = "-";
                //    }

                //}

                //if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).Vendido)
                //{
                //    ((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)row.Item).CotizacionFechaFin = "Vendido";

                //}
            }
        }

        private void myGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {
            this.myGrid.SelectedItem = null;
            this.myGrid.SelectedItem = e.Row.Item;
            var sel = (T_RentaVariable)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            

            int? id = null;

            //Cuando es una fila creada manualmente el Id es 0. 
            if (sel != null && sel.Id != 0)
                id = sel.Id;

            //Sólo permitimos editar la columna "Nombre" cuando estemos añadiendo una nueva fila
            //manualmente en la preview
            if (id != null && e.Cell.Column.Name == "Nombre")
            {
                e.Cancel = true;
                
            }

            //if (e.Cell.Column.Name == "Cotizacion")
            //{
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            //}


        }

        //private void myGrid_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        //{
        //    //store the items to be deleted
        //    itemsToBeDeleted = e.Items;

        //    //cancel the event so the item is not deleted
        //    //and wait for the user confirmation
        //    e.Cancel = true;
        //    //open the Confirm dialog
        //    RadWindow.Confirm("¿Seguro que quieres eliminar la fila?", this.OnRadWindowClosed);
        //}

        //private void OnRadWindowClosed(object sender, WindowClosedEventArgs e)
        //{
        //    //check whether the user confirmed
        //    bool shouldDelete = e.DialogResult.HasValue ? e.DialogResult.Value : false;
        //    if (shouldDelete)
        //    {
        //        foreach (var item in itemsToBeDeleted)
        //        {
        //            myGrid.Items.Remove(item);
        //        }
        //    }
        //}

        

        private void myGrid_AddingNewDataItem(object sender, GridViewAddingNewEventArgs e)
        {
            e.NewObject = new T_RentaVariable() {  };
        }




        private bool? mostrarMensajeEliminar(string desc)
        {
            bool? dialogResult = null;
            Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
            string message = "¿Está seguro que desea eliminar " + desc + "?";
            double width = 400;
            parameters.Content = new TextBlock()
            {
                Text = message,
                Width = width,
                TextWrapping = TextWrapping.Wrap
            };
               

            parameters.Closed = (w, a) =>
            {
                dialogResult = a.DialogResult;
            };

            parameters.Header = "Eliminar";

            Telerik.Windows.Controls.RadWindow.Confirm(parameters);

            /*
            bool? dialogResult = null;
            //Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
            //parameters.Content = "¿Está seguro que desea eliminar " + desc + "?";    

            string message = "¿Está seguro que desea eliminar " + desc + "?";
            double width = 400;
            var closed = new EventHandler<WindowClosedEventArgs>();
            Telerik.Windows.Controls.DialogParameters parameters = new DialogParameters
            {
                Content = new TextBlock()
                {
                    Text = message,
                    Width = width,
                    TextWrapping = TextWrapping.Wrap
                },
                //Closed =  closed,
                Owner = Application.Current.MainWindow
            };



            

            //Telerik.Windows.Controls.RadWindow.Confirm(parameters);

            RadWindow.Confirm(new DialogParameters
            {
                Content = new TextBlock()
                {
                    Text = message,
                    Width = width,
                    TextWrapping = TextWrapping.Wrap
                },
                Closed = closed,
                Owner = Application.Current.MainWindow
            });

    */
            return dialogResult;
        }

        /// <summary>
        /// Esto lo hacemos porque cuando el Grid no tiene el foco, no detecta el primer click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myGrid_SelectionChanging(object sender, SelectionChangingEventArgs e)
        {
            
        }        

        private void myGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {/*
            //var celda = myGrid.CurrentCell; //para comprobar si es celda con botón Eliminar
            //var boton = celda.ChildrenOfType<RadButton>();
            //Necesitamos este método porque a veces no reconoce la fila correcta cuando hacemos
            //click en el botón Eliminar del grid
            int selectedColumnIndex = -1;
            int selectedRowIndex = -1;
            var grid = sender as RadGridView;
            if (grid != null)
            {
                var pos = e.GetPosition(grid);
                var temp = pos.X;
                #region posición columna
                
                for (var i = 0; i < grid.Columns.Count; i++)
                {
                    var colDef = grid.Columns[i];
                    temp -= colDef.ActualWidth;
                    if (temp <= -1)
                    {
                        selectedColumnIndex = i;
                        break;
                    }
                }
                #endregion

                temp = pos.Y;
                int cont = 0;
                foreach (var item in grid.Items)
                {
                    if (item == null)
                        continue;
                    GridViewRow row = myGrid.ItemContainerGenerator.ContainerFromItem(item) as GridViewRow;

                    temp -= row.ActualHeight;
                    if (temp <= -1)
                    {
                        selectedRowIndex = cont;
                        break;
                    }
                    cont++;
                    
                }

                this.myGrid.SelectedItem = this.myGrid.Items[selectedRowIndex-1];

                //var celda = myGrid.CurrentCell;

                var fila = this.myGrid.SelectedItem;

                //if (grid != null
                //    && celda != null)
                if (fila != null)
                {
                    //la columna del botón Eliminar
                    if (selectedColumnIndex == 0)
                    {
                        var desc = ((T_RentaVariable)fila).Nombre.ToString().Trim();
                        bool? eliminar = mostrarMensajeEliminar(desc);
                        if (eliminar != null && Convert.ToBoolean(eliminar))
                        {

                            myGrid.Items.Remove(fila);
                        }
                    }
                }
            }*/
        }

        private void myGrid_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            //var it = this.myGrid.Items[fila];
            //int row = 0;
            //int col = 0;
            //var grid = sender as GridViewDataControl;

            //GetRowColumn(grid, e.poso)
            //Funciona correctamente si encontramos el evento en el que situarlo.
            //no puede ser este evento
            //var grid = sender as GridViewDataControl;
            
        }

        private void myGrid_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            //store the items to be deleted
            itemsToBeDeleted = e.Items;

            //cancel the event so the item is not deleted
            //and wait for the user confirmation
            e.Cancel = true;
            //open the Confirm dialog
            if (itemsToBeDeleted.FirstOrDefault() != null)
            {
                var obj = (T_RentaVariable)itemsToBeDeleted.FirstOrDefault();
                var nombre = !string.IsNullOrEmpty((obj).Descripcion) ? (obj).Descripcion.Trim() : string.Empty;
                string mensaje = string.Format("¿Seguro que quieres eliminar {0}?. Este registro no volverá a aparecer en futuras generaciones.", nombre);

                RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, this.OnRadWindowClosed);

                //bool? dialogResult = null;
                //Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
                ////parameters.Content = "¿Esta seguro que desea eliminar?";
                //parameters.Content = new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 };

                //parameters.Closed = (w, a) =>
                //{
                //    dialogResult = a.DialogResult;
                //};

                //parameters.Header = "Eliminar";

                //Telerik.Windows.Controls.RadWindow.Confirm(parameters);

                //if (dialogResult == true)
                //{
                //    var itemBorrar = new RentaVariable_Deleted();
                //    Utils.CopyPropertyValues(obj, itemBorrar);
                //    RentaVariable_DA.DeleteRVItems(itemBorrar);
                //}
            }
        }

        protected IEnumerable<Object> itemsToBeDeleted;

        private void OnRadWindowClosed(object sender, WindowClosedEventArgs e)
        {
            //check whether the user confirmed
            bool shouldDelete = e.DialogResult.HasValue ? e.DialogResult.Value : false;
            if (shouldDelete)
            {
                foreach (var item in itemsToBeDeleted)
                {
                    //myGrid.Items.Remove(club);
                    //var itemBorrar = new RentaVariable_Deleted();
                    //Utils.CopyPropertyValues(item, itemBorrar);
                    //itemBorrar.Grupo = _grupo;
                    //itemBorrar.Ejercicio = _fecha.Year;
                    
                    //Lo eliminamos de la tabla
                    //RentaVariable_DA.DeleteRVItems(itemBorrar);

                    //Lo eliminamos del grid
                    this.myGrid.Items.Remove(item);
                    
                }
            }
        }

        private void myGrid_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
        {
            var sel = (T_RentaVariable)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            //int id = ((T_RentaVariable)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;

            //Opción añadir nueva fila
            if (sel == null)
            {
                var added = (T_RentaVariable)((System.Windows.FrameworkElement)(((Telerik.Windows.Controls.GridView.GridViewDataControl)(((Telerik.Windows.Controls.DataControl)sender))).CurrentCell)).DataContext;
                //RentaVariable_Added temp = new RentaVariable_Added();
                //Utils.CopyPropertyValues(added, temp);
                //temp.CodigoIC = _plantilla.CodigoIc;

                //var selGrupo = ((Reports_IICs.DataAccess.Secciones.T_RentaVariable)e.Row.Item).GrupoNuevo;
                ////Si han seleccionado grupo en el desplegable guardamos el que hayan seleccionado
                ////en caso contrario guardamos el grupo del bloque "_grupo"
                //temp.Grupo = selGrupo != null ? Convert.ToInt32(selGrupo) : _grupo;
                //temp.Ejercicio = _fecha.Year;

                ////añadimos un nuevo RentaVariable_Added 
                ////y recuperamos su id por si vuelven a editarlo
                //if (!string.IsNullOrEmpty(temp.CodigoIC)
                //    && !string.IsNullOrEmpty(temp.Isin)
                //    && !string.IsNullOrEmpty(temp.Descripcion)
                //    && (temp.Grupo != 0))
                //{
                //    try
                //    {
                //        RentaVariable_DA.Insert_or_Update_RentaVariable_Added(temp);
                //    }
                //    catch (Exception ex)
                //    {
                //        RadWindow.Alert(new TextBlock { Text = ex.Message, TextWrapping = TextWrapping.Wrap, Width = 400 });
                //    }
                //}
                //else
                //{
                //    RadWindow.Alert(new TextBlock { Text = "Faltan datos para poder guardar la fila.", TextWrapping = TextWrapping.Wrap, Width = 400 });
                //}
            }
        }

        //public static void GetRowColumn(this Grid @this, Point position, out int row, out int column)
        //{
        //    column = -1;
        //    double total = 0;
        //    foreach (ColumnDefinition clm in @this.ColumnDefinitions)
        //    {
        //        if (position.X < total)
        //        {
        //            break;
        //        }
        //        column++;
        //        total += clm.ActualWidth;
        //    }
        //    row = -1;
        //    total = 0;
        //    foreach (RowDefinition rowDef in @this.RowDefinitions)
        //    {
        //        if (position.Y < total)
        //        {
        //            break;
        //        }
        //        row++;
        //        total += rowDef.ActualHeight;
        //    }
        //}

        //private void myGrid_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        //{
        //    var row = e.Row as GridViewRow;
        //    if (row != null)
        //    {
        //        this.AddHandler(GridViewRow.MouseLeftButtonDownEvent,
        //        new MouseButtonEventHandler(GridViewRow_MouseLeftButtonDown), true);
        //    }
        //}




    }
}
