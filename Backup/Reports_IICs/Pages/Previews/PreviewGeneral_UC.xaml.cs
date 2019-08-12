using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Pages.Previews.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;
using static Reports_IICs.Pages.Previews.ColumnaGrid;

namespace Reports_IICs.Pages.Previews
{
    /// <summary>
    /// Interaction logic for PreviewGeneral_UC.xaml
    /// </summary>
    public partial class PreviewGeneral_UC : UserControl
    {
        private int _idSeccion;
        private DateTime _fecha;
        private Plantilla _plantilla;
        private object _selItem;


        //public enum TipoColumnaGrid
        //{
        //    Texto,
        //    Fecha,
        //    Decimal0,
        //    Decimal1,
        //    Decimal2,
        //    Decimal3,
        //    Decimal4,
        //    Decimal8
        //};
        public PreviewGeneral_UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Si la tabla de la Preview correspondiente tiene algún cambio guardado para este código IC
        /// Mostraremos el botón que nos permite ver esos cambios (true)
        /// En caso contrario lo ocultamos (false)
        /// </summary>
        /// <returns></returns>


        public PreviewGeneral_UC(Plantilla plantilla, int idSeccion, DateTime fecha)
        {
            InitializeComponent();

            _fecha = fecha;
            _plantilla = plantilla;
            _idSeccion = idSeccion;

            populatePreview(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualizar">La primera vez que cargamos este UserControl: actualizar = false
        /// cuando queramos recargar el usercontrol: actualizar = true</param>
        private void populatePreview(bool actualizar)
        {
            //mostrarBotonCambios();
            getColumnasYSource(actualizar);
        }

        private void getColumnasYSource(bool actualizar)
        {
            this.myRadGridView.ItemsSource = null;

            switch (_idSeccion)
            {
                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN                    
                    //En esta Preview en vez de este Grid tendremos un Grid por cada Isin
                    this.myRadGridView.Visibility = Visibility.Collapsed;

                    var tipos = new List<string>() { "Cartera", "COMPRA", "AMPLIACION", "EQUIPARACION", "VENTA" };
                    //var source14 = new Temp_CompraVentaPrecAdq_MNG().GetByCodigoIC(_plantilla.CodigoIc).OrderBy(o=>o.FechaNew).ToList();
                    var source14 = CompraVentaRespectoPrecioAdquisicion_DA.GetTemp_Ordenado(_plantilla.CodigoIc);
                    removeGridsAddedDynamically();
                    var listaIsins = source14.Select(s => s.Isin).Distinct();
                    foreach (var isin in listaIsins)
                    {
                        List<ColumnaGrid> cols = new List<Previews.ColumnaGrid>();
                        cols.Add(new Previews.ColumnaGrid("Id", TipoColumnaGrid.Texto, false));
                        cols.Add(new Previews.ColumnaGrid("CodigoIC", TipoColumnaGrid.Texto, false));
                        cols.Add(new Previews.ColumnaGrid("IsinPlantilla", TipoColumnaGrid.Texto, false));
                        cols.Add(new Previews.ColumnaGrid("IsinNew", TipoColumnaGrid.Texto, true, false, "ISIN"));
                        cols.Add(new Previews.ColumnaGrid("FechaNew", TipoColumnaGrid.Fecha, true, false, "Fecha"));
                        //new Previews.ColumnaGrid("TipoNew", TipoColumnaGrid.Texto, true, false, "Tipo"));
                        cols.Add(new Previews.ColumnaGrid("TipoNew", TipoColumnaGrid.Texto, true, false, "Tipo", tipos));
                        cols.Add(new Previews.ColumnaGrid("TitulosNew", TipoColumnaGrid.Decimal0, true, false, "Títulos"));
                        cols.Add(new Previews.ColumnaGrid("DescripcionValorNew", TipoColumnaGrid.Texto, true, false, "Descripción"));
                        cols.Add(new Previews.ColumnaGrid("AdquisicionNew", TipoColumnaGrid.Decimal2, true, false, "Adquisición"));
                        //Este campo calculado lo tenemos en ModelUpdates.cs
                        //Ponemos por tanto ReadOnly = true
                        cols.Add(new Previews.ColumnaGrid("EfectivoNew", TipoColumnaGrid.Decimal2, true, true, "Efectivo"));

                        var myGrid2 = addGrid(cols);

                        myGrid2.ItemsSource = source14.Where(w => w.Isin.ToUpper() == isin.ToUpper()).ToList();
                    }

                    break;
                case 21://RENTA FIJA
                    var gruposRF = new List<object>() { 1, 2, 3, 4, 5, 6, 7 };
                    var temp = new Temp_RentaFija_MNG().GetByCodigoIC(_plantilla.CodigoIc).OrderBy(o => o.GrupoNew).ToList();

                    //Sólo añadimos las columnas cuando cargamos el control por primera vez
                    //Si estamos recargando el control no las añadimos de nuevo
                    if (!actualizar)
                    {
                        //Esta sección tiene un gridview para los grupo 1 al 5 y otro con menos columnas para el resto                                                     
                        //Así que tenemos que añadir otro GridView       
                        //Añadimos las columnas y el ItemsSource del primer GridView
                        addColToGrid(new Previews.ColumnaGrid("Id", TipoColumnaGrid.Decimal0, false), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("CodigoIC", TipoColumnaGrid.Texto, false), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("IsinPlantilla", TipoColumnaGrid.Texto, false), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("IsinNew", TipoColumnaGrid.Texto, true, false, null), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("GrupoNew", TipoColumnaGrid.Decimal0, true, false, null, gruposRF), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("DescripcionNew", TipoColumnaGrid.Texto, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("NumTitNew", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("EfectivoIniNew", TipoColumnaGrid.Decimal4, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("EfectivoFinNew", TipoColumnaGrid.Decimal4, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("BoPDivisaNew", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("BoPPrecioNew", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("BoPTotalNew", TipoColumnaGrid.Decimal0, true, true, null, null), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("BoPTotalPorcentajeNew", TipoColumnaGrid.Decimal4, true, true, null, null), ref myRadGridView);
                    }
                    this.myRadGridView.ItemsSource = temp.Where(w => w.GrupoNew <= 5).ToList();

                    //Agrupamos por Grupo
                    var descriptor = new GroupDescriptor();
                    descriptor.Member = "GruponEW";
                    //descriptor.DisplayContent = "GrupoDesc";
                    this.myRadGridView.GroupDescriptors.Add(descriptor);

                    //Añadimos las columnas y el ItemsSource del segundo GridView
                    //sólo si tiene datos 
                    var source21 = temp.Where(w => w.GrupoNew > 5).ToList();

                    removeGridsAddedDynamically();

                    if (source21.Count() > 0)
                    {
                        List<ColumnaGrid> cols = new List<Previews.ColumnaGrid>();
                        cols.Add(new ColumnaGrid("Id", TipoColumnaGrid.Decimal0, false));
                        cols.Add(new ColumnaGrid("CodigoIC", TipoColumnaGrid.Texto, false));
                        cols.Add(new ColumnaGrid("IsinPlantilla", TipoColumnaGrid.Texto, false));
                        cols.Add(new ColumnaGrid("IsinNew", TipoColumnaGrid.Texto, true, false, "ISIN"));
                        //cols.Add(new ColumnaGrid("Grupo", TipoColumnaGrid.Decimal0, true));
                        cols.Add(new ColumnaGrid("GrupoNew", TipoColumnaGrid.Decimal0, true, false, null, gruposRF));
                        cols.Add(new ColumnaGrid("DescripcionNew", TipoColumnaGrid.Texto, true));
                        cols.Add(new ColumnaGrid("PosicionCarteraNew", TipoColumnaGrid.Decimal2, true));
                        cols.Add(new ColumnaGrid("PosicionesCerradasNew", TipoColumnaGrid.Decimal2, true));
                        cols.Add(new ColumnaGrid("BoPTotalNew", TipoColumnaGrid.Decimal2, true, true, null, null));

                        var myGrid2 = addGrid(cols);
                        myGrid2.ItemsSource = source21;

                        //Agrupamos por Grupo
                        descriptor = new GroupDescriptor();

                        descriptor.Member = "Grupo";
                        //var fechaIni = Utils.GetFechaInicio(_plantilla, _fecha, typeof(Temp_RentaFija));
                        //string descGrupo = string.Empty;
                        //descriptor.DisplayContent = ReportFunctions.TituloGrupoRF(Convert.ToInt64(descriptor.()), fechaIni, _fecha);

                        /*
                        var descr = new GroupDescriptor<Temp_RentaFija, int, int>();

                        descr.GroupingExpression = task => Convert.ToInt32(task.Grupo);
                        descr.GroupSortingExpression = grouping => grouping.Key;
                        descr.DisplayContent = task =>
                        //ReportFunctions.TituloGrupoRF( Convert.ToInt64(grouping.), fechaIni, _fecha);
                        */

                        myGrid2.GroupDescriptors.Add(descriptor);
                    }
                    break;
                case 37://CARTERA RV CCR-VOLGA-GAMAR
                        //Sólo añadimos las columnas cuando cargamos el control por primera vez
                        //Si estamos recargando el control no las añadimos de nuevo
                    if (!actualizar)
                    {
                        addColToGrid(new Previews.ColumnaGrid("CodigoIC", TipoColumnaGrid.Texto, false), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("Grupo", TipoColumnaGrid.Texto, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("Subgrupo", TipoColumnaGrid.Texto, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("Valor", TipoColumnaGrid.Texto, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("Cantidad", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("CosteMedio", TipoColumnaGrid.Decimal2, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("EfectivoCompra", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("ValorActual", TipoColumnaGrid.Decimal2, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("Plusvalias", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("EfectivoActual", TipoColumnaGrid.Decimal0, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("TPCCartera", TipoColumnaGrid.Decimal2, true), ref myRadGridView);
                        addColToGrid(new Previews.ColumnaGrid("TPCPatrimonio", TipoColumnaGrid.Decimal2, true), ref myRadGridView);
                    }
                    this.myRadGridView.ItemsSource = new Temp_CarteraCcrVolgaGamar_MNG().GetByCodigoIC(_plantilla.CodigoIc).ToList();
                    break;
            }
        }

        private void removeGridsAddedDynamically()
        {
            //Eliminamos los grids que se habían añadido dinámicamente
            foreach (var rgv in this.myStackPanel.ChildrenOfType<RadGridView>().Where(w => w.Name != "myRadGridView"))
            {
                this.myStackPanel.Children.Remove(rgv);
            }
        }

        private void myGrid_Grouping(object sender, GridViewGroupingEventArgs e)
        {
            RadWindow.Alert(new TextBlock { Text = "Método Grouping", TextWrapping = TextWrapping.Wrap, Width = 400 });
            //if (e.Action == . System.ComponentModel.CollectionChangeAction.Add)
            //{
            //    e.GroupDescriptor.DisplayContent = string.Format("Grouped by {0}", e.GroupDescriptor.Member);
            //}
        }

        private RadGridView addGrid(List<ColumnaGrid> columnas)
        {
            var rgv = new RadGridView();

            rgv.AutoExpandGroups = true;
            rgv.AutoGenerateColumns = false;
            rgv.MinWidth = 200;
            rgv.ShowColumnFooters = true;
            rgv.ShowGroupPanel = false;
            rgv.RowIndicatorVisibility = Visibility.Collapsed;
            rgv.IsLocalizationLanguageRespected = false;
            rgv.FontSize = 10;
            //rgv.ColumnWidth = 1;
            rgv.SelectionUnit = GridViewSelectionUnit.FullRow;
            rgv.CanUserDeleteRows = true;
            rgv.CanUserInsertRows = true;
            rgv.GroupRenderMode = GroupRenderMode.Flat;
            rgv.NewRowPosition = GridViewNewRowPosition.Bottom;
            rgv.AddingNewDataItem += this.myGrid_AddingNewDataItem;
            rgv.Deleting += this.myGrid_Deleting;

            //rgv.RowEditEnded += this.myGrid_RowEditEnded;
            //rgv.DataLoaded += this.myGrid_DataLoaded;
            rgv.CellEditEnded += this.myGrid_CellEditEnded;
            rgv.Grouping += this.myGrid_Grouping;

            //Añadimos la columna "Eliminar"
            var colElim = new MyButtonColumn()
            {
                Header = "Eliminar"
            };
            //Ponemos el tamaño de la columna
            colElim.Width = 60;
            rgv.Columns.Add(colElim);



            foreach (var item in columnas)
            {
                addColToGrid(item, ref rgv);
            }

            this.myStackPanel.Children.Add(rgv);

            return rgv;
        }

        //private void addColToGrid(string dataMemberBinding, TipoColumnaGrid tipo, bool isVisible, RadGridView grid, bool isReadOnly = false, string header = null)
        private void addColToGrid(ColumnaGrid cg, ref RadGridView grid)
        {
            var column = new GridViewBoundColumnBase();

            //Comprobamos si tiene que ser combobox
            if (cg.ItemsSource == null)
                column = new GridViewDataColumn();
            else
                column = new GridViewComboBoxColumn();

            column.DataMemberBinding = new Binding(cg.DataMemberBinding);
            column.Header = string.IsNullOrEmpty(cg.Header) ? cg.DataMemberBinding.Replace("New", "") : cg.Header;
            column.UniqueName = cg.DataMemberBinding;
            column.IsVisible = cg.IsVisible;
            column.IsReadOnly = cg.IsReadOnly != null ? Convert.ToBoolean(cg.IsReadOnly) : false;

            if (column.GetType() == typeof(GridViewComboBoxColumn))
            {
                ((GridViewComboBoxColumn)column).ItemsSource = cg.ItemsSource;
            }

            switch (cg.Tipo)
            {
                case TipoColumnaGrid.Texto:
                    column.TextAlignment = TextAlignment.Left;
                    break;
                case TipoColumnaGrid.Fecha:
                    column.TextAlignment = TextAlignment.Center;
                    column.DataFormatString = "{0:dd/MM/yyyy}";
                    break;
                case TipoColumnaGrid.Decimal0:
                case TipoColumnaGrid.Decimal1:
                case TipoColumnaGrid.Decimal2:
                case TipoColumnaGrid.Decimal3:
                case TipoColumnaGrid.Decimal4:
                case TipoColumnaGrid.Decimal8:
                    column.TextAlignment = TextAlignment.Right;
                    if (cg.Tipo == TipoColumnaGrid.Decimal0)
                        column.DataFormatString = "{0:N0}";
                    if (cg.Tipo == TipoColumnaGrid.Decimal1)
                        column.DataFormatString = "{0:N1}";
                    else if (cg.Tipo == TipoColumnaGrid.Decimal2)
                        column.DataFormatString = "{0:N2}";
                    else if (cg.Tipo == TipoColumnaGrid.Decimal3)
                        column.DataFormatString = "{0:N3}";
                    else if (cg.Tipo == TipoColumnaGrid.Decimal4)
                        column.DataFormatString = "{0:N4}";
                    else if (cg.Tipo == TipoColumnaGrid.Decimal8)
                        column.DataFormatString = "{0:N8}";

                    break;
            }

            grid.Columns.Add(column);
            grid.FontSize = 10;
        }

        private void myGrid_AddingNewDataItem(object sender, GridViewAddingNewEventArgs e)
        {
            //e.NewObject = new T_RentaVariable() { };
            e.Cancel = true;
            switch (_idSeccion)
            {
                case 13://RENTA VARIABLE 
                    e.NewObject = new Temp_RentaVariable() { };
                    break;
                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                    //var temp14 = new Temp_CompraVentaPrecAdq() ;this.myGrid.items
                    var temp14 = (Temp_CompraVentaPrecAdq)((RadGridView)sender).Items.AddNew();
                    //var temp14 = new Temp_CompraVentaPrecAdq();
                    //Si el grid tiene ya alguna fila aprovechamos para crear la nueva fila con los datos de su grupo                    
                    if (((Telerik.Windows.Controls.GridView.BaseItemsControl)sender).HasItems)
                    {
                        var item = (Temp_CompraVentaPrecAdq)((Telerik.Windows.Controls.DataControl)sender).Items[0];

                        temp14.CodigoIC = item.CodigoIC;
                        temp14.Isin = item.Isin;
                        temp14.IsinNew = item.Isin;
                        temp14.DescripcionValor = item.DescripcionValor;
                        temp14.DescripcionValorNew = item.DescripcionValor;
                        temp14.Added = true;
                        temp14.IsVisible = true;
                    }
                    //sour14.Add(temp14);
                    //((RadGridView)sender).ItemsSource = sour14;
                    //((RadGridView)sender).Items.AddNewItem(temp14);
                    //((RadGridView)sender).Items.Add(temp14);
                    //e.NewObject = temp14;      

                    break;
                case 21://RENTA FIJA
                    var temp21 = (Temp_RentaFija)((RadGridView)sender).Items.AddNew();
                    temp21.CodigoIC = _plantilla.CodigoIc;
                    temp21.Added = true;
                    temp21.IsVisible = true;
                    e.NewObject = temp21;
                    break;
                case 37://CARTERA RV CCR-VOLGA-GAMAR
                    e.NewObject = new Temp_CarteraCcrVolgaGamar() { };
                    break;
            }

            ((RadGridView)sender).Items.CommitNew();
        }

        protected IEnumerable<Object> itemsToBeDeleted;
        private void myGrid_Deleting(object sender, GridViewDeletingEventArgs e)
        {
            //store the items to be deleted
            itemsToBeDeleted = e.Items;
            var item = e.Items.FirstOrDefault();
            _selItem = item;

            if (item != null)
            {
                //cancel the event so the item is not deleted
                //and wait for the user confirmation
                e.Cancel = true;
                //open the Confirm dialog

                var nombre = getItemDesc(item);
                string mensaje = string.Format("¿Seguro que quieres eliminar {0}?. Este registro no volverá a aparecer en futuras generaciones.", nombre);

                RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 },
                        delegate (object windowSender, WindowClosedEventArgs args)
                        {
                            if (args.DialogResult == true)
                            {
                                //Ofrecemos la posibilidad de guardar un Comentario antes de eliminar (aunque también podemos hacerlo desde el botón RadButtonComentario)
                                showComentario(sender, e);
                                eliminar((RadGridView)sender);
                            }
                        });

                //RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, this.OnRadWindowClosed);

                /*
                var obj = (T_RentaVariable)itemsToBeDeleted.FirstOrDefault();
                var nombre = !string.IsNullOrEmpty((obj).Descripcion) ? (obj).Descripcion.Trim() : string.Empty;
                string mensaje = string.Format("¿Seguro que quieres eliminar {0}?. Este registro no volverá a aparecer en futuras generaciones.", nombre);

                RadWindow.Confirm(new TextBlock { Text = mensaje, TextWrapping = TextWrapping.Wrap, Width = 400 }, this.OnRadWindowClosed);
                */
            }
        }

        private string getItemDesc(object item)
        {
            string output = string.Empty;
            switch (_idSeccion)
            {
                case 13://RENTA VARIABLE 
                    output = ((Temp_RentaVariable)item).Descripcion;
                    break;
                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                    output = !string.IsNullOrEmpty(((Temp_CompraVentaPrecAdq)item).DescripcionValorNew) ?
                        ((Temp_CompraVentaPrecAdq)item).DescripcionValorNew :
                        ((Temp_CompraVentaPrecAdq)item).DescripcionValor;
                    break;
                case 21://RENTA FIJA
                    output = !string.IsNullOrEmpty(((Temp_RentaFija)item).DescripcionNew) ?
                        ((Temp_RentaFija)item).DescripcionNew :
                        ((Temp_RentaFija)item).Descripcion;
                    break;
                case 37://CARTERA RV CCR-VOLGA-GAMAR
                    output = ((Temp_CarteraCcrVolgaGamar)item).Valor;
                    break;
            }

            return output.Trim();
        }

        private void eliminar(RadGridView rgv)
        {
            //check whether the user confirmed
            //bool shouldDelete = e.DialogResult.HasValue ? e.DialogResult.Value : false;
            //if (shouldDelete)
            //{
            foreach (var item in itemsToBeDeleted)
            {
                int id = 0;
                //Buscamos en este control los Grids que tengan Items de tipo Temp_CompraVentaPrecAdq
                var grids = this.ChildrenOfType<RadGridView>();

                #region sólo para las secciones que guardemos que una fila ha sido eliminada
                switch (_idSeccion)
                {
                    case 13://RENTA VARIABLE 
                            /*
                            var itemBorrar = new RentaVariable_Deleted();
                            Utils.CopyPropertyValues((Temp_RentaVariable)item, itemBorrar);
                            itemBorrar.Grupo = Utils.GetGrupoInt(((Temp_RentaVariable)item).Grupo);
                            itemBorrar.Ejercicio = _fecha.Year;

                            //Lo eliminamos de la tabla
                            RentaVariable_DA.DeleteRVItems(itemBorrar);
                            */
                        id = ((Temp_RentaVariable)item).Id;
                        if (id > 0)
                        {
                            new Temp_RentaVariable_MNG().Delete(id);
                        }
                        break;
                    case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN   
                        id = ((Temp_CompraVentaPrecAdq)item).Id;
                        if (id > 0)
                        {
                            //Lo borramos de la table temporal
                            new Temp_CompraVentaPrecAdq_MNG().Delete(((Temp_CompraVentaPrecAdq)item).Id);

                            //Lo borramos (guardamos como IsVisible = false) de la tabla de la Preview
                            var prev14 = new Preview_CompraVentaPrecAdq();
                            Utils.CopyPropertyValues(item, prev14, "Id");
                            prev14.IsVisible = false;
                            prev14.FechaInforme = _fecha;
                            new Preview_CompraVentaPrecAdq_MNG().Save(prev14, null);

                            //Lo borramos del grid


                            foreach (var gr in grids)
                            {
                                foreach (var it in gr.Items)
                                {
                                    if (it == item)
                                    {
                                        gr.Items.Remove(it);
                                        return;
                                    }
                                }
                            }
                        }
                        break;
                    case 21://RENTA FIJA
                        id = ((Temp_RentaFija)item).Id;
                        if (id > 0)
                        {
                            //Lo borramos de la table temporal
                            new Temp_RentaFija_MNG().Delete(((Temp_RentaFija)item).Id);

                            //Lo borramos (guardamos como IsVisible = false) de la tabla de la Preview
                            var prev21 = new Preview_RentaFija();
                            Utils.CopyPropertyValues(item, prev21, "Id");
                            prev21.IsVisible = false;
                            prev21.FechaInforme = _fecha;
                            new Preview_RentaFija_MNG().Save(prev21, null);

                            //Lo borramos del grid                            

                            foreach (var gr in grids)
                            {
                                foreach (var it in gr.Items)
                                {
                                    if (it == item)
                                    {
                                        gr.Items.Remove(it);
                                        return;
                                    }
                                }
                            }
                        }
                        break;
                    case 37://CARTERA RV CCR-VOLGA-GAMAR
                        new Temp_CarteraCcrVolgaGamar_MNG().Delete(((Temp_CarteraCcrVolgaGamar)item).Id);
                        //BindData();

                        break;
                }


                #endregion

                #region general
                //Lo eliminamos del grid (esto se hace para cualquier sección)
                rgv.Items.Remove(item);
                #endregion
            }
        }
        //}


        //private void OnRadWindowClosed(object sender, WindowClosedEventArgs e)
        //{

        //}

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();
        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            //var sel = (TempTableBase)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            //var sel = ((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            //var sel = (((Telerik.Windows.Controls.DataControl)sender)).Items.CurrentItem;
            //using (dbcontext)

            {
                //Sólo guardamos si se ha modificado el valor
                //Si pulsan Esc o no cambia el valor, no guardamos
                if (e.EditAction == GridViewEditAction.Commit && Utils.CellHasChanged(e.OldData, e.NewData))
                {
                    var sel = e.Cell.ParentRow.Item;

                    if (sel != null)
                    {
                        try
                        {
                            switch (_idSeccion)
                            {
                                case 13://RENTA VARIABLE 
                                    new Temp_RentaVariable_MNG().Save((Temp_RentaVariable)sel, null);
                                    break;
                                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                        //Guardamos los datos en la tabla temp
                                    var temp14 = new Temp_CompraVentaPrecAdq();
                                    Utils.CopyPropertyValues(sel, temp14);
                                    if (string.IsNullOrEmpty(temp14.CodigoIC))
                                        temp14.CodigoIC = _plantilla.CodigoIc;

                                    if (string.IsNullOrEmpty(temp14.Isin))
                                        temp14.Isin = temp14.IsinNew;

                                    if (string.IsNullOrEmpty(temp14.Tipo))
                                        temp14.Tipo = temp14.TipoNew;

                                    //Tiene que tener rellenos los campos obligatorios
                                    if (!string.IsNullOrEmpty(temp14.IsinNew)
                                        && !string.IsNullOrEmpty(temp14.TipoNew)
                                        && temp14.TitulosNew != null
                                        && temp14.DescripcionValorNew != null)
                                    {
                                        new Temp_CompraVentaPrecAdq_MNG().Save(temp14, null);
                                        //Asignamos el Id (por si no lo tuviera en caso de ser Nuevo)
                                        ((Temp_CompraVentaPrecAdq)sel).Id = temp14.Id;
                                        //Los datos que se modifiquen aquí se conserverán en sucesivas generaciones
                                        //Los guardamos en la tabla de la Preview, no en la Temp. 
                                        var prev = new Preview_CompraVentaPrecAdq();
                                        Utils.CopyPropertyValues(temp14, prev, "Id");
                                        prev.FechaInforme = _fecha;
                                        prev.IsVisible = true;
                                        new Preview_CompraVentaPrecAdq_MNG().Save(prev, null);

                                    }
                                    break;
                                case 21://RENTA FIJA

                                    //Guardamos los datos en la tabla temp
                                    var temp21 = (Temp_RentaFija)sel;
                                    if (string.IsNullOrEmpty(temp21.CodigoIC))
                                        temp21.CodigoIC = _plantilla.CodigoIc;

                                    //if (string.IsNullOrEmpty(temp21.IsinPlantilla))
                                    //    temp21.IsinPlantilla = temp21.IsinPlantilla;

                                    if (string.IsNullOrEmpty(temp21.Isin))
                                        temp21.Isin = temp21.IsinNew;

                                    //Tiene que tener rellenos los campos obligatorios
                                    if (temp21.GrupoNew != null
                                        &&
                                        (
                                            (
                                                //Los 5 primeros grupos tienen unos campos obligatorios diferentes
                                                temp21.GrupoNew != null && (int)temp21.GrupoNew <= 5
                                                && !string.IsNullOrEmpty(temp21.IsinNew)
                                                && !string.IsNullOrEmpty(temp21.DescripcionNew)
                                                && temp21.EfectivoIniNew != null
                                                && temp21.EfectivoFinNew != null
                                            //&& temp21.BoPDivisaNew != null
                                            //&& temp21.BoPPrecioNew != null
                                            )
                                            ||
                                            (
                                                temp21.GrupoNew != null && (int)temp21.GrupoNew > 5
                                                && !string.IsNullOrEmpty(temp21.IsinNew)
                                                && !string.IsNullOrEmpty(temp21.DescripcionNew)
                                                && temp21.PosicionCarteraNew != null
                                                && temp21.PosicionesCerradasNew != null
                                            )
                                            ||
                                            (
                                                temp21.GrupoNew != null && (int)temp21.GrupoNew == 7
                                                // && !string.IsNullOrEmpty(temp21.IsinNew)                                                
                                                && temp21.PosicionCarteraNew != null
                                                && temp21.PosicionesCerradasNew != null
                                            )
                                        )

                                        )
                                    {
                                        temp21.BoPPrecioNew = temp21.EfectivoFinNew - temp21.EfectivoIniNew;
                                        temp21.BoPTotal = temp21.BoPDivisaNew + temp21.BoPPrecioNew;
                                        new Temp_RentaFija_MNG().Save(temp21, null);
                                        //Asignamos el Id (por si no lo tuviera en caso de ser Nuevo)
                                        ((Temp_RentaFija)sel).Id = temp21.Id;
                                        ////ACTUALITZACIÓ VARIACIÓ PATRIMONIAL

                                        //string CodsTipoInstrumento = string.Empty;
                                        //var tempRF = RentaFija_DA.GetTemp(_plantilla.CodigoIc);
                                        //decimal? RentaFijaValorP = 0; //Valores: Precio
                                        //decimal? RentaFijaValorC = 0; //Valores: Cartera
                                        //decimal? RentaFijaValorV = 0; //Valores: Ventas
                                        //decimal? RentaFijaValorD = 0; //Valores: Divisa
                                        //decimal? RentaFijaValorT = 0; //Valores: Total

                                        //decimal? RentaFijaIICP = 0; //IIC: Precio
                                        //decimal? RentaFijaIICC = 0; //IIC: Cartera
                                        //decimal? RentaFijaIICV = 0; //IIC: Ventas
                                        //decimal? RentaFijaIICD = 0; //IIC: Divisa
                                        //decimal? RentaFijaIICT = 0; //IIC: Total

                                        ////falta afegir derivados, que es seleccionen per la columna "Grupo" i l'identificador és "7"

                                        //var objFija = dbcontext.Temp_RentaFija.Where(a => a.CodigoIC == _plantilla.CodigoIc && a.CodTipoInstrumento == "VAL");
                                        //foreach (var item in objFija)
                                        //{
                                        //    RentaFijaValorP = RentaFijaValorP + item.BoPPrecio;
                                        //    RentaFijaValorC = RentaFijaValorC + item.PosicionCartera;
                                        //    RentaFijaValorV = RentaFijaValorV + item.PosicionesCerradas;
                                        //    RentaFijaValorD = RentaFijaValorD + item.BoPDivisa;
                                        //    RentaFijaValorT = RentaFijaValorT + item.BoPTotal;
                                        //}

                                        //var objFija2 = dbcontext.Temp_RentaFija.Where(a => a.CodigoIC == _plantilla.CodigoIc && a.CodTipoInstrumento == "IIC");
                                        //foreach (var item in objFija2)
                                        //{
                                        //    RentaFijaIICP = RentaFijaIICP + item.BoPPrecioNew;
                                        //    RentaFijaIICC = RentaFijaIICC + item.PosicionCarteraNew;
                                        //    RentaFijaIICV = RentaFijaIICV + item.PosicionesCerradasNew;
                                        //    RentaFijaIICD = RentaFijaIICD + item.BoPDivisaNew;
                                        //    RentaFijaIICT = RentaFijaIICT + item.BoPTotal;
                                        //}

                                        //var objFijaVVP = _plantilla.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == _plantilla.CodigoIc && w.CodsInstrumento == "RENTA FIJA" && w.CodsTipoInstrumento == "VALORES");
                                        //var objFijaIVP = _plantilla.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == _plantilla.CodigoIc && w.CodsInstrumento == "RENTA FIJA" && w.CodsTipoInstrumento == "IIC");
                                        //objFijaVVP.BoPPrecio = RentaFijaValorP;
                                        //objFijaVVP.Cartera = RentaFijaValorC;
                                        //objFijaVVP.Ventas = RentaFijaValorV;
                                        //objFijaVVP.BoPDivisa = RentaFijaValorD;
                                        //objFijaVVP.TotalPrecios = RentaFijaValorT;

                                        //objFijaIVP.BoPPrecio = RentaFijaIICP;
                                        //objFijaIVP.Cartera = RentaFijaIICC;
                                        //objFijaIVP.Ventas = RentaFijaIICV;
                                        //objFijaIVP.BoPDivisa = RentaFijaIICV;
                                        //objFijaIVP.TotalPrecios = RentaFijaIICT;
                                        dbcontext.SaveChanges();

                                        //////END ACTUALITZACIÓ VARIACIÓ PATRIMONIAL

                                        //Los datos que se modifiquen aquí se conserverán en sucesivas generaciones
                                        //Los guardamos en la tabla de la Preview, no en la Temp. 
                                        var prev = new Preview_RentaFija();
                                        Utils.CopyPropertyValues(temp21, prev, "Id");
                                        // Utils.CopyPropertyValues(temp21, _plantilla.Preview_RentaFija.Select(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == prev.FechaInforme && s.Isin == prev.Isin).FirstOrDefault(), "Id");
                                        
                                        var existitem = _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin && s.Grupo == prev.Grupo).FirstOrDefault();
                                        if (existitem !=null)
                                            
                                        {                                            
                                            //_plantilla.Preview_RentaFija.Remove(prev);
                                            //_plantilla.Preview_RentaFija.Add(prev);

                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().PosicionCarteraNew = prev.PosicionCarteraNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().PosicionesCerradasNew = prev.PosicionesCerradasNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().BoPPrecioNew = prev.EfectivoFinNew - prev.EfectivoIniNew*((prev.EfectivoFin-prev.BoPPrecio)/prev.EfectivoIni);
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().BoPDivisaNew = prev.EfectivoIniNew * (((prev.EfectivoFin - prev.BoPPrecio) / prev.EfectivoIni)-1);
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().EfectivoIniNew = prev.EfectivoIniNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().EfectivoFinNew = prev.EfectivoFinNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().IsinNew = prev.IsinNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().NumTitNew = prev.NumTitNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().GrupoNew = prev.GrupoNew;
                                            _plantilla.Preview_RentaFija.Where(s => s.CodigoIC == prev.CodigoIC && s.FechaInforme == _fecha && s.Isin == prev.Isin).FirstOrDefault().DescripcionNew = prev.DescripcionNew;
                                           
                                        }
                                        if (existitem == null)
                                        {                                            
                                            _plantilla.Preview_RentaFija.Add(prev);
                                        }
                                        




                                        prev.FechaInforme = _fecha;
                                        prev.IsVisible = true;
                                        new Preview_RentaFija_MNG().Save(prev, null);

                                    }
                                    
                                    break;
                                case 37://CARTERA RV CCR-VOLGA-GAMAR
                                    new Temp_CarteraCcrVolgaGamar_MNG().Save((Temp_CarteraCcrVolgaGamar)sel, null);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    //fila nueva
                    else
                    {
                        try
                        {
                            switch (_idSeccion)
                            {
                                case 13://RENTA VARIABLE 

                                    break;
                                case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                    var prev = new Preview_CompraVentaPrecAdq();
                                    //prev = Utils.CopyPropertyValues()
                                    prev.IsVisible = true;
                                    new Preview_CompraVentaPrecAdq_MNG().Save(prev, null);
                                    break;
                                case 21://RENTA FIJA
                                    break;
                                case 37://CARTERA RV CCR-VOLGA-GAMAR

                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    this.ParentOfType<PreviewGeneral>().HasChanged = true;
                }
            }
        }



        private void showComentario(object sender, RoutedEventArgs e)
        {
            string comentario = null;

            switch (_idSeccion)
            {
                case 21:

                    //Comprobamos si este item ya tenía un comentario guardado en su tabla Preview
                    var prev = new Preview_RentaFija();
                    Utils.CopyPropertyValues(_selItem, prev, "Id");
                    var obj = new Preview_RentaFija_MNG().Get(prev);
                    if (obj != null)
                    {
                        comentario = obj.Comentario;
                    }

                    break;
            }

            RadWindow.Prompt(new DialogParameters
            {
                Header = "Comentario",
                DefaultPromptResultValue = comentario,  //En caso de que ya tuviera un comentario lo mostramos
                Closed = new EventHandler<WindowClosedEventArgs>(OnPromptClosed),
                Owner = Application.Current.MainWindow
            });
        }

        private void OnPromptClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult != null && (bool)e.DialogResult)
            {
                //Guardamos el comentario en la tabla Preview para la fila en la que se ha escrito el comentario

                string comentario = e.PromptResult;

                //Guardamos el Comentario en la tabla de la Preview
                switch (_idSeccion)
                {
                    case 21:
                        var temp21 = (Temp_RentaFija)_selItem;
                        temp21.Comentario = comentario;
                        new Temp_RentaFija_MNG().Save(temp21, null);

                        //Los datos que se modifiquen aquí se conserverán en sucesivas generaciones
                        //Los guardamos en la tabla de la Preview, no en la Temp. 
                        var prev = new Preview_RentaFija();
                        Utils.CopyPropertyValues(temp21, prev, "Id");
                        prev.FechaInforme = _fecha;
                        prev.IsVisible = true;
                        new Preview_RentaFija_MNG().Save(prev, null);

                        break;
                }
            }
        }

        private void RadButtonComentario_Click(object sender, RoutedEventArgs e)
        {
            //Primero seleccionamos el item
            switch (_idSeccion)
            {
                case 21:
                    //Guardamos la fila del botón para utilizar los datos que necesitemos en OnPromptClosed
                    _selItem = (Temp_RentaFija)((System.Windows.FrameworkElement)sender).DataContext;
                    break;
            }

            showComentario(sender, e);
        }
    }
}