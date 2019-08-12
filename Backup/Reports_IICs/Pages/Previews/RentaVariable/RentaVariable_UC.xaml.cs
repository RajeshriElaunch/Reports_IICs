using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Managers;
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


namespace Reports_IICs.Pages.Previews.RentaVariable
{
    /// <summary>
    /// Lógica de interacción para RentaVariable_UC.xaml
    /// </summary>
    public partial class RentaVariable_UC : UserControl
    {
        private Plantilla _plantilla;
        private List<usp_gestio_pro_13_Result> _pro13;
        protected DateTime _fecha;
        protected DateTime _fechaIni;
        private int filaIndex = 0;
        private int _grupo;
        private List<GridViewMaskedInputColumn> _celsActualizan;
        private List<GridViewBoundColumnBase> _celsActualizanNewFila;
        public RentaVariable_UC()
        {
            InitializeComponent();
        }

        public RentaVariable_UC(Plantilla plantilla, string isin, DateTime fecha, string titulo, string grupo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            try
            {
                InitializeComponent();

                MainWindow main = (MainWindow)Application.Current.MainWindow;

                _celsActualizan = new List<GridViewMaskedInputColumn>() {
                this.NumTit,
                this.PrecioIni,
                this.PrecioAjustado,
                this.PrecioFin,
                this.PrecioFinEuros,
                this.Efectivo,
                this.TipoCambioIni
                };

                _celsActualizanNewFila = new List<GridViewBoundColumnBase>() {
                this.NumTit,
                this.PrecioIni,
                this.TipoCambioIni,
                this.PrecioAjustado,
                this.PrecioFin,
                this.PrecioFinEuros,
                this.Efectivo,
                this.ISIN
                };

                _plantilla = plantilla;
                _fecha = fecha;
                _grupo = Utils.GetGrupoInt(grupo);
                _fechaIni = Utils.GetFechaInicio(plantilla, fecha);

                //Aquí tenemos que llamar a GetPRO13 en vez de cogerlo de las VariablesGlobales 
                //porque es una preview y no se ha cargado el procedimiento
                if(VariablesGlobales.Pro13_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_13_Result), plantilla, fecha);
                }
                _pro13 = VariablesGlobales.Pro13_Local;
                //_pro13 = Reports_DA.GetPRO13(plantilla, _fechaIni, fecha);

                this.LabelTitulo.Content = titulo;

                var obj = DataAccess.Secciones.RentaVariable_DA.GetGrupoRV(plantilla.CodigoIc, isin, instrumentosIds, tiposInstrumentoIds, grupo);

                this.myGrid.ItemsSource = obj;
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
            //Sólo guardamos si se ha modificado el valor
            //Si pulsan Esc o no cambia el valor, no guardamos
            if (e.EditAction == GridViewEditAction.Commit && Utils.CellHasChanged(e.OldData, e.NewData))
            {
                this.ParentOfType<RentaVariable_Preview>().HasChanged = true;
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
                            var item = new usp_gestio_pro_13_Result();
                            //Si no ha sido añadido en la Preview
                            if (sel.Grupo != null)
                            {
                                item = getItemPro13Sel(temp);
                            }
                            else
                            {
                                item = new usp_gestio_pro_13_Result();
                            }
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

                            //actualizamos los datos de la tabla Temp con los datos introducidos por pantalla
                            Utils.CopyPropertyValues(sel, temp, "Id");
                            temp.CambioI = sel.TipoCambioIni;
                            temp.CambioO = sel.TipoCambioIni;
                            temp.CambioC = sel.TipoCambioFin;
                            temp.CambioF = sel.TipoCambioFin;
                            temp.PrecioCompra = sel.PrecioIni;
                            temp.PrecioVenta = sel.PrecioFin;
                            temp.IdInstrumento = InstrumentosImportados_DA.GetIdInstrumentoImportadoByIsin(sel.Isin);
                            temp.IdTipoInstrumento = InstrumentosImportados_DA.GetIdTipoInstrumentoImportadoByIsin(sel.Isin);
                            temp.IdCategoria = InstrumentosImportados_DA.GetIdCategoriaInstrumentoImportadoByIsin(sel.Isin);
                            temp.IdEmpresa = InstrumentosImportados_DA.GetIdEmpresaInstrumentoImportadoByIsin(sel.Isin);
                            temp.PrecioI = sel.PrecioIni;
                            temp.PrecioO = sel.PrecioIni != null ? (decimal)sel.PrecioIni : 0;
                            temp.PrecioC = sel.PrecioFin;
                            temp.PrecioF = sel.PrecioFin != null ? (decimal)sel.PrecioFin : 0;
                            temp.PrecioFEUR = sel.PrecioFinEuros != null ? (decimal)sel.PrecioFinEuros : 0;
                            //ACC 19/01/2019 a 23/01/2019 START----------------
                            temp.PrecioFEUR = sel.PrecioFin * sel.TipoCambioFin;
                            temp.Efectivo = sel.PrecioFin * sel.TipoCambioFin * sel.NumTit;
                            temp.BoPPrecio =(sel.PrecioFin-sel.PrecioIni)*sel.TipoCambioFin*sel.NumTit;
                            temp.BoPDivisa = sel.PrecioIni * (sel.TipoCambioFin - sel.TipoCambioIni)*sel.NumTit;
                            temp.BoPTotal = (sel.PrecioFin * sel.TipoCambioFin - sel.PrecioIni*sel.TipoCambioIni) * sel.NumTit;

                            //ACC 19/01/2019 a 23/01/2019 END-------------------
                            new Temp_RentaVariable_MNG().Save(temp, null);

                            //actualizamos la tabla RentaVariable_PrecioAjustado que es donde se guardan
                            //los cambios de la Preview
                            var prev = new RentaVariable_PrecioAjustado();
                            Utils.CopyPropertyValues(sel, prev, "Id");
                            prev.Ejercicio = _fecha.Year;
                            prev.FechaInforme = _fecha;
                            prev.IsVisible = true; //Este campo siempre a true menos cuando lo eliminen
                            if (sel.NumTit != null)
                            {
                                prev.NumeroTitulos = Convert.ToDecimal(sel.NumTit);
                            }
                            prev.TipoCambioIni = sel.TipoCambioIni;
                            prev.TipoCambioFin = sel.TipoCambioFin;
                            //prev.PrecioFin = sel.PrecioFin;
                            //prev.PrecioFinEuros = sel.PrecioFinEuros;

                            //ACC 19/01/2019 START----------------

                            prev.PrecioFin = sel.PrecioFin;
                            prev.PrecioFinEuros = sel.PrecioFin * sel.TipoCambioFin;
                            
                            
                            //ACC 19/01/2019 END-------------------

                            //Si es del grupo 4 (en el combo) tenemos que guardarlo en RentaVariable_PrecioAjustado_NumO también
                            //if(sel.GrupoNuevo == 4)
                            //{
                            //Puede que esta línea "sel" sea la agrupación de varios movimientos
                            //Recuperamos todos y los asociamos a este precio ajustado
                            var grupo = Utils.GetPro13SeccRv(_plantilla, _fecha).Where(w =>
                                    w.Grupo == sel.Grupo
                                    && w.Isin.ToUpper() == sel.Isin.ToUpper()).ToList();

                            foreach (var itemGrupo in grupo)
                            {
                                var obj = new RentaVariable_PrecioAjustado_NumO();
                                obj.NumO = itemGrupo.NumO;
                                prev.RentaVariable_PrecioAjustado_NumO.Add(obj);
                                //Probamos a añadir el parent al child
                                //obj.RentaVariable_PrecioAjustado = prev;
                            }
                            //}

                            RentaVariable_DA.SavePrecioAjustado(prev, temp);
                            //new RentaVariable_PrecioAjustado_MNG().Save(prev, null);




                        }
                    }

                }
                //Si es una fila nueva que estamos añadiendo en la Preview            
                else
                {
                    var selNew = ((Reports_IICs.DataAccess.Secciones.T_RentaVariable)(((Telerik.Windows.Controls.DataControl)sender).Items.CurrentItem));

                    if (selNew.GrupoNuevo != null)
                    {
                        //Asignamos TipoO y Estado
                        selNew.Estado = Utils.GetEstadoByGrupo((Int32)selNew.GrupoNuevo);
                        selNew.TipoO = Utils.GetTipoOByGrupo((Int32)selNew.GrupoNuevo);
                    }

                    var nombreCol = ((Telerik.Windows.Controls.GridView.GridViewDataControl)(((Telerik.Windows.Controls.DataControl)sender))).CurrentColumn.Name;
                    if (_celsActualizanNewFila.Select(s => s.Name).Contains(nombreCol))
                    {
                        var item = getUsp13Ficticio(selNew);

                        //Actualizamos los totales en pantalla (Preview)
                        actualizarTotalesEnPantalla(selNew, item);
                    }

                    //Si tenemos los datos necesarios, guardamos
                    if (!string.IsNullOrEmpty(selNew.CodigoIC)
                        && !string.IsNullOrEmpty(selNew.Isin)
                        && !string.IsNullOrEmpty(selNew.Descripcion)
                        && selNew.GrupoNuevo != null)
                    {

                        var prev = new RentaVariable_PrecioAjustado();
                        Utils.CopyPropertyValues(selNew, prev);
                        prev.Added = true;
                        prev.IsVisible = true;
                        prev.FechaInforme = _fecha;

                        if (selNew.NumTit != null)
                        {
                            prev.NumeroTitulos = Convert.ToDecimal(selNew.NumTit);
                        }
                        prev.TipoCambioIni = selNew.TipoCambioIni;
                        prev.TipoCambioFin = selNew.TipoCambioFin;

                        //var mng = new RentaVariable_PrecioAjustado_MNG();
                        //mng.FechaInforme = _fecha;
                        //mng.Save(prev, null);

                        var temp = new Temp_RentaVariable();
                        Utils.CopyPropertyValues(prev, temp, "Id");
                        temp.NumTit = prev.NumeroTitulos;
                        temp.CambioI = prev.TipoCambioIni;
                        temp.CambioO = prev.TipoCambioIni;
                        temp.CambioC = prev.TipoCambioFin;
                        temp.CambioF = prev.TipoCambioFin;
                        temp.PrecioCompra = prev.PrecioIni;
                        temp.PrecioVenta = prev.PrecioFin;
                        temp.IdInstrumento = InstrumentosImportados_DA.GetIdInstrumentoImportadoByIsin(prev.Isin);
                        temp.IdTipoInstrumento = InstrumentosImportados_DA.GetIdTipoInstrumentoImportadoByIsin(prev.Isin);
                        temp.IdCategoria = InstrumentosImportados_DA.GetIdCategoriaInstrumentoImportadoByIsin(prev.Isin);
                        temp.IdEmpresa = InstrumentosImportados_DA.GetIdEmpresaInstrumentoImportadoByIsin(prev.Isin);
                        temp.Efectivo = selNew.Efectivo;
                        temp.BoPDivisa = selNew.BoPDivisa;
                        temp.BoPPrecio = selNew.BoPPrecio;
                        temp.BoPTotal = selNew.BoPTotal;
                        temp.BoPTotalPorcentaje = selNew.BoPTotalPorcentaje;
                        int idTemp = RentaVariable_DA.SavePrecioAjustado(prev, temp);
                        //Actualizamos el Id que se le ha asignado en la tabla temporar 
                        //para poder actualizarlo si hacen modificaciones en la Preview
                        selNew.Id = idTemp;
                    }
                }
                
            }
        }

        /// <summary>
        /// Montamos un usp_gestio_pro_13_Result para poder actualizar los totales
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="tipoO"></param>
        private usp_gestio_pro_13_Result getUsp13Ficticio(T_RentaVariable selNew)
        {
            var usp13 = new usp_gestio_pro_13_Result();
            var cartIni = new usp_gestio_pro_11_Result();
            var cartFin = new usp_gestio_pro_11_Result();            

            //Para el grupo 3 no necesitamos recuperar la cartera
            //Los valores que necesitamos se tienen que introducir manualmente en la Preview
            if (!string.IsNullOrEmpty(selNew.Isin) && _grupo != 3)
            {
                usp13.Isin = selNew.Isin;
                //Si no tenemos cargado el PRO11 lo cargamos
                if (VariablesGlobales.Pro11_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_11_Result), _plantilla, _fecha);
                }

                cartIni = Reports_DA.GetPRO11(_plantilla, _fechaIni).Where(w => w.isin.ToUpper() == selNew.Isin.ToUpper()).FirstOrDefault();
                cartFin = VariablesGlobales.Pro11_Local.Where(w => w.isin.ToUpper() == selNew.Isin.ToUpper()).FirstOrDefault();

                //Si no han introducido descripción la buscamos cuando rellenen el ISIN
                if (string.IsNullOrEmpty(selNew.Descripcion))
                {
                    var desc = string.Empty;
                    if (cartIni != null)
                        desc = cartIni.descr;
                    else if (cartFin != null)
                        desc = cartFin.descr;

                    selNew.Descripcion = desc;
                }
            }

            //Asignamos Estado y TipoO
            usp13.Estado = Utils.GetEstadoByGrupo(_grupo);
            usp13.TipoO = Utils.GetTipoOByGrupo(_grupo);

            switch (_grupo)
            {                
                case 1:
                    
                    if (!string.IsNullOrEmpty(selNew.Isin))
                    {
                        if (cartFin != null)
                            usp13.PrecioF = cartFin.valact;
                        if(cartIni != null)
                            usp13.PrecioI = cartIni.valact;
                        if (cartFin != null)
                            usp13.CambioF = cartFin.cambio;
                        if (cartIni != null)
                            usp13.CambioI = cartIni.cambio;

                        //Actualizamos estos campos en pantalla
                        selNew.PrecioIni = usp13.PrecioI;
                        selNew.TipoCambioIni = usp13.CambioI;
                        selNew.PrecioFin = usp13.PrecioF;
                        selNew.TipoCambioFin = usp13.CambioF;
                    }
                    break;
                case 2:
                    
                    if (!string.IsNullOrEmpty(selNew.Isin))
                    {
                        if (cartIni != null)
                            usp13.PrecioI = cartIni.valact;
                        usp13.PrecioC = selNew.PrecioFin;
                        if (cartIni != null)
                            usp13.CambioI = cartIni.cambio;
                        usp13.CambioC = selNew.TipoCambioFin;

                        //Actualizamos estos campos en pantalla
                        selNew.PrecioIni = usp13.PrecioI;
                        selNew.TipoCambioIni = usp13.CambioI;
                        selNew.PrecioFin = usp13.PrecioC;
                        selNew.TipoCambioFin = usp13.CambioC;
                    }
                    break;
                case 3:
                    
                    if (!string.IsNullOrEmpty(selNew.Isin))
                    {
                        if (selNew.PrecioIni != null)
                        {
                            usp13.PrecioO = Convert.ToDecimal(selNew.PrecioIni);
                        }
                        usp13.PrecioC = selNew.PrecioFin;
                        usp13.CambioO = selNew.TipoCambioIni;
                        usp13.CambioC = selNew.TipoCambioFin;

                        //Actualizamos estos campos en pantalla
                        selNew.PrecioIni = usp13.PrecioO;
                        selNew.TipoCambioIni = usp13.CambioO;
                        selNew.PrecioFin = usp13.PrecioC;
                        selNew.TipoCambioFin = usp13.CambioC;
                    }
                    break;
                case 4:
                    
                    if (!string.IsNullOrEmpty(selNew.Isin))
                    {
                        if(cartFin != null)
                            usp13.PrecioF = cartFin.valact;
                        usp13.PrecioC = selNew.PrecioFin;
                        if (cartFin != null)
                            usp13.CambioF = cartFin.cambio;
                        usp13.CambioO = selNew.TipoCambioIni;

                        //Actualizamos estos campos en pantalla
                        selNew.PrecioIni = usp13.PrecioC;
                        selNew.TipoCambioIni = usp13.CambioO;
                        selNew.PrecioFin = usp13.PrecioF;
                        selNew.TipoCambioFin = usp13.CambioF;
                    }
                    break;
            }

            selNew.Estado = usp13.Estado;
            selNew.TipoO = usp13.TipoO;            

            if (selNew.PrecioFin != null && selNew.TipoCambioFin != null)
            {
                selNew.PrecioFinEuros = selNew.PrecioFin * selNew.TipoCambioFin;
            }

            return usp13;
        }
        
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
                if (string.IsNullOrEmpty(item.Isin))
                    item.Isin = sel.Isin;
                if (string.IsNullOrEmpty(item.Estado))
                    item.Estado = sel.Estado;
                if (string.IsNullOrEmpty(item.TipoO))
                    item.TipoO = sel.TipoO;
                if (item.CambioC == null)
                    item.CambioC = sel.TipoCambioFin;
                if (item.CambioF == null)
                    item.CambioF = sel.TipoCambioFin;
                if (item.CambioI == null)
                    item.CambioI = sel.TipoCambioIni;
                if (item.CambioO == null)
                    item.CambioO = sel.TipoCambioIni;
                if (item.PrecioO == 0)
                    item.PrecioO = sel.PrecioIni != null ? Convert.ToDecimal(sel.PrecioIni) : 0;
                if (item.PrecioOA == 0)
                    item.PrecioOA = sel.PrecioIni != null ? Convert.ToDecimal(sel.PrecioIni) : 0;
                if (item.PrecioI == null)
                    item.PrecioI = sel.PrecioIni;

                /*
                item.CambioF = Convert.ToDecimal(1.0841988854);
                item.CambioI = Convert.ToDecimal(1.1690027238);
                item.CambioO = Convert.ToDecimal(1.1690027238);
                item.PrecioI = Convert.ToDecimal(3.39894319684383);
                item.PrecioO = Convert.ToDecimal(3.39894319684383);
                item.PrecioOA = Convert.ToDecimal(3.39894319684383);
                //item.TipoO = "M";
                //item.Estado = "OPEN";
                item.PrecioF = Convert.ToDecimal(4.296);
                item.PrecioFEUR = Convert.ToDecimal(4.6577184116784);
                */

                sel.TipoCambioFin = item.CambioF;
                sel.PrecioFinEuros = sel.PrecioFin * sel.TipoCambioFin;

                //Tenemos en cuenta el cambio que haya en la Preview
                item.CambioI = sel.TipoCambioIni;
                item.CambioO = sel.TipoCambioIni;
                item.CambioF = sel.TipoCambioFin;
                item.CambioC = sel.TipoCambioFin;                
                item.IdInstrumento = InstrumentosImportados_DA.GetIdInstrumentoImportadoByIsin(sel.Isin);
                item.IdTipoInstrumento = InstrumentosImportados_DA.GetIdTipoInstrumentoImportadoByIsin(sel.Isin);
                item.IdCategoria = InstrumentosImportados_DA.GetIdCategoriaInstrumentoImportadoByIsin(sel.Isin);
                item.IdEmpresa = InstrumentosImportados_DA.GetIdEmpresaInstrumentoImportadoByIsin(sel.Isin);
                item.PrecioI = sel.PrecioIni;
                item.PrecioO = sel.PrecioIni != null ? (decimal)sel.PrecioIni : 0;
                item.PrecioC = sel.PrecioFin;
                item.PrecioF = sel.PrecioFin != null ? (decimal)sel.PrecioFin : 0;
                item.PrecioFEUR = sel.PrecioFinEuros != null ? (decimal)sel.PrecioFinEuros : 0;


                sel.Efectivo = RentaVariable_VM.CalcularEfectivo(item, sel.NumTit, sel.PrecioFinEuros);
                sel.BoPDivisa = RentaVariable_VM.calcularPLDiv(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
                sel.BoPPrecio = RentaVariable_VM.CalcularPLPrecio(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
                sel.BoPTotal = RentaVariable_VM.calcularPLEur(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);
                sel.BoPTotalPorcentaje = RentaVariable_VM.calcularPLPct(item, sel.NumTit, sel.PrecioAjustado, sel.PrecioFin);                
            }
        }

        //private Temp_RentaVariable actualizarTempTable(Temp_RentaVariable temp, T_RentaVariable sel)
        //{
        //    temp.NumTit = Convert.ToDecimal(sel.NumTit);
        //    temp.PrecioIni = sel.PrecioIni;
        //    temp.PrecioAjustado = sel.PrecioAjustado;
        //    temp.PrecioFin = sel.PrecioFin;
        //    temp.PrecioFinEuros = sel.PrecioFinEuros;
        //    temp.Efectivo = sel.Efectivo;
        //    temp.BoPDivisa = sel.BoPDivisa;
        //    temp.BoPPrecio = sel.BoPPrecio;
        //    temp.BoPTotal = sel.BoPTotal;
        //    temp.BoPTotalPorcentaje = sel.BoPTotalPorcentaje;
        //    temp.CambioI = sel.TipoCambioIni;
        //    temp.CambioO = sel.TipoCambioIni;
        //    temp.CambioC = sel.TipoCambioFin;
        //    temp.CambioF = sel.TipoCambioFin;
        //    return temp;
        //}
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
            var item = new T_RentaVariable() { };
            item.CodigoIC = _plantilla.CodigoIc;
            item.GrupoNuevo = _grupo;
            e.NewObject = item;
        }

    //    private bool? mostrarMensajeEliminar(string desc)
    //    {
    //        bool? dialogResult = null;
    //        Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
    //        string message = "¿Está seguro que desea eliminar " + desc + "?";
    //        double width = 400;
    //        parameters.Content = new TextBlock()
    //        {
    //            Text = message,
    //            Width = width,
    //            TextWrapping = TextWrapping.Wrap
    //        };
               

    //        parameters.Closed = (w, a) =>
    //        {
    //            dialogResult = a.DialogResult;
    //        };

    //        parameters.Header = "Eliminar";

    //        Telerik.Windows.Controls.RadWindow.Confirm(parameters);

    //        /*
    //        bool? dialogResult = null;
    //        //Telerik.Windows.Controls.DialogParameters parameters = new Telerik.Windows.Controls.DialogParameters();
    //        //parameters.Content = "¿Está seguro que desea eliminar " + desc + "?";    

    //        string message = "¿Está seguro que desea eliminar " + desc + "?";
    //        double width = 400;
    //        var closed = new EventHandler<WindowClosedEventArgs>();
    //        Telerik.Windows.Controls.DialogParameters parameters = new DialogParameters
    //        {
    //            Content = new TextBlock()
    //            {
    //                Text = message,
    //                Width = width,
    //                TextWrapping = TextWrapping.Wrap
    //            },
    //            //Closed =  closed,
    //            Owner = Application.Current.MainWindow
    //        };



            

    //        //Telerik.Windows.Controls.RadWindow.Confirm(parameters);

    //        RadWindow.Confirm(new DialogParameters
    //        {
    //            Content = new TextBlock()
    //            {
    //                Text = message,
    //                Width = width,
    //                TextWrapping = TextWrapping.Wrap
    //            },
    //            Closed = closed,
    //            Owner = Application.Current.MainWindow
    //        });

    //*/
    //        return dialogResult;
    //    }

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
                    //var itemBorrar = new RentaVariable_Deleted();
                    //Utils.CopyPropertyValues(item, itemBorrar);
                    var itemBorrar = new RentaVariable_PrecioAjustado();
                    Utils.CopyPropertyValues(item, itemBorrar);                    
                    itemBorrar.Ejercicio = _fecha.Year;
                    itemBorrar.IsVisible = false;
                    itemBorrar.FechaInforme = _fecha;
                    if (((T_RentaVariable)item).NumTit != null)
                        itemBorrar.NumeroTitulos = Convert.ToDecimal(((T_RentaVariable)item).NumTit);                    

                    //Lo marcamos como es visible = false en RentaVariable_PrecioAjustado_MNG
                    //Que es donde guardamos las modificaciones de la Preview
                    var mng = new RentaVariable_PrecioAjustado_MNG();
                    mng.FechaInforme = _fecha;
                    mng.Save(itemBorrar, null);

                    //Lo eliminamos de la tabla temporal
                    var temp = new Temp_RentaVariable();
                    Utils.CopyPropertyValues(item, temp);
                    new Temp_RentaVariable_MNG().Delete(temp);                    

                    //Lo eliminamos del grid
                    this.myGrid.Items.Remove(item);
                    
                }
            }
        }

        private void myGrid_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
        {
            /*
            var sel = (T_RentaVariable)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            //int id = ((T_RentaVariable)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;

            //Opción añadir nueva fila
            if (sel == null)
            {
                var added = (T_RentaVariable)((System.Windows.FrameworkElement)(((Telerik.Windows.Controls.GridView.GridViewDataControl)(((Telerik.Windows.Controls.DataControl)sender))).CurrentCell)).DataContext;
                RentaVariable_Added temp = new RentaVariable_Added();
                Utils.CopyPropertyValues(added, temp);
                temp.CodigoIC = _plantilla.CodigoIc;

                var selGrupo = ((Reports_IICs.DataAccess.Secciones.T_RentaVariable)e.Row.Item).GrupoNuevo;
                //Si han seleccionado grupo en el desplegable guardamos el que hayan seleccionado
                //en caso contrario guardamos el grupo del bloque "_grupo"
                temp.Grupo = selGrupo != null ? Convert.ToInt32(selGrupo) : _grupo;
                temp.Ejercicio = _fecha.Year;

                //añadimos un nuevo RentaVariable_Added 
                //y recuperamos su id por si vuelven a editarlo
                if (!string.IsNullOrEmpty(temp.CodigoIC)
                    && !string.IsNullOrEmpty(temp.Isin)
                    && !string.IsNullOrEmpty(temp.Descripcion)
                    && (temp.Grupo != 0))
                {
                    try
                    {
                        RentaVariable_DA.Insert_or_Update_RentaVariable_Added(temp);
                    }
                    catch (Exception ex)
                    {
                        RadWindow.Alert(new TextBlock { Text = ex.Message, TextWrapping = TextWrapping.Wrap, Width = 400 });
                    }
                }
                else
                {
                    RadWindow.Alert(new TextBlock { Text = "Faltan datos para poder guardar la fila.", TextWrapping = TextWrapping.Wrap, Width = 400 });
                }
            }
            */
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
