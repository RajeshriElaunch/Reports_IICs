using log4net;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace Reports_IICs.Pages.Previews.RentaVariable
{
    /// <summary>
    /// Lógica de interacción para RentaVariable_UC_Small.xaml
    /// </summary>
    public partial class RentaVariable_UC_Small : UserControl
    {

        private Plantilla _plantilla;
        private string _isin;
        private List<string> _instrumentosIds;
        private List<string> _tiposInstrumentoIds;
        protected DateTime _fecha;
        public bool Visible = false;
        private ObservableCollection<T_RentaVariable> Llistaobj;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RentaVariable_UC_Small()
        {
            InitializeComponent();
        }

        public RentaVariable_UC_Small(Plantilla plantilla, string isin, DateTime fecha, string titulo, List<string> instrumentosIds, List<string> tiposInstrumentoIds)
        {
            InitializeComponent();

            _plantilla = plantilla;
            _isin = isin;
            _fecha = fecha;
            _instrumentosIds = instrumentosIds;
            _tiposInstrumentoIds = tiposInstrumentoIds;
            this.LabelTitulo.Content = titulo;

            var obj = DataAccess.Secciones.RentaVariable_DA.GetGrupoRV(plantilla.CodigoIc, isin, instrumentosIds, tiposInstrumentoIds);

            

            if (obj.Count() > 0)
            {
                Llistaobj = obj;
                this.Visible = true;
                this.myGrid.ItemsSource = obj;
            }


            //foreach (var item in this.myGrid.Columns)
            //{
            //    if (item.Name == "Cotizacion") item.Header = "Cotización " + String.Format("{0:dd/MM/yyyy}", fecha);
            //}

        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_RentaVariable)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var sel = (T_RentaVariable)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var temp = dbcontext.Temp_RentaVariable.FirstOrDefault(p => p.Id == id);
               
                string CodsTipoInstrumento = string.Empty;
                string CodsInstrumento = string.Empty;

                if (temp != null)
                {
                    temp.PosicionCartera = sel.PosicionCartera;
                    temp.PosicionesCerradas = sel.PosicionesCerradas;
                    sel.BoPTotal = sel.PosicionCartera + sel.PosicionesCerradas;
                    temp.BoPTotal = sel.BoPTotal;
                }
                try
                {
                    dbcontext.SaveChanges();
                    //Aqui tinc que actualitzar Variacion patrimonial A
                    var obj = DataAccess.Secciones.RentaVariable_DA.GetGrupoRV(_plantilla.CodigoIc, _isin, _instrumentosIds, _tiposInstrumentoIds);

                    if (obj.Count() > 0)
                    {
                        //HEM DE FER EL SUMATORI
                        var sumTOTAL_RA = obj.Sum(s => s.BoPTotal);
                        var sumCartera_RA = obj.Sum(s => s.PosicionCartera);
                        var sumPosCerradas_RA = obj.Sum(s=> s.PosicionesCerradas);
                        switch (_tiposInstrumentoIds[0])
                        {
                            case "2"://IIC
                                #region  IIC
                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento = "IIc";
                                #endregion
                                break;
                            case "5"://PATRIMONIALISTA
                                #region  PATRIMONIALISTA


                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento  = "PATRIMONIALISTA";
                                #endregion
                                break;
                            case "11"://CCCP
                                #region  CCCP


                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento = "CCCP";
                                #endregion
                                break;
                            case "12"://PERSISTENCIA
                                #region  PERSISTENCIA


                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento = "PERSISTENCIA";
                                #endregion
                                break;
                            case "13"://Divisas
                                #region  Divisas


                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento = "Divisas";
                                #endregion
                                break;
                            case "15"://Commodities
                                #region  Commodities
                                
                                CodsInstrumento = "RETORNO ABSOLUTO";
                                CodsTipoInstrumento = "Commodities";
                                #endregion
                                break;
                        }

                        var obj2 = dbcontext.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == _plantilla.CodigoIc && w.CodsTipoInstrumento == CodsTipoInstrumento && w.CodsInstrumento== CodsInstrumento);                        
                        obj2.TotalPrecios  = sumTOTAL_RA.Value;
                        obj2.Cartera = sumCartera_RA.Value; //sumTOTAL_RA.Value;
                        obj2.Ventas = sumPosCerradas_RA.Value;

                        dbcontext.SaveChanges();

                        #region ACTUALITZEM OTROS
                        var tempVP = VariacionPatrimonialA_DA.GetTemp(_plantilla.CodigoIc);

                        var RentaVariableValoresobj = tempVP.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                                        && w.CodsTipoInstrumento == "VALORES"
                                                        && w.CodsCategoria == null
                                                        && w.CodsEmpresa == null).FirstOrDefault();
                        var RentaVariableIICobj = tempVP.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                                       && w.CodsTipoInstrumento == "IIC"
                                                       && w.CodsCategoria == null
                                                       && w.CodsEmpresa == null).FirstOrDefault();

                        var RentaVariableDerivadosobj = tempVP.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                                      && w.CodsTipoInstrumento == "DERIVADOS"
                                                      && w.CodsCategoria == null
                                                      && w.CodsEmpresa == null).FirstOrDefault();

                        var RentaVariableValores = RentaVariableValoresobj != null ? (RentaVariableValoresobj.TotalPrecios ?? 0) : 0;
                        var RentaVariableIIC = RentaVariableIICobj != null ? (RentaVariableIICobj.TotalPrecios ?? 0) : 0;
                        var RentaVariableDerivados = RentaVariableDerivadosobj != null ? (RentaVariableDerivadosobj.TotalPrecios ?? 0) : 0;
                        var TotalRendimientos = dbcontext.Temp_VariacionPatrimonialA.FirstOrDefault(p => p.CodigoIC == _plantilla.CodigoIc && p.CodsInstrumento == "TOTAL RENDIMIENTOS").TotalPrecios;
                            //var RentaVariableValores = dbcontext.Temp_VariacionPatrimonialA.FirstOrDefault(p => p.CodigoIC == _plantilla.CodigoIc && p.CodsInstrumento == "RENTA VARIABLE" && p.CodsTipoInstrumento == "VALORES" && p.CodsCategoria == string.Empty && p.CodsEmpresa == string.Empty).TotalIngresos;
                            //var RentaVariableIIC = dbcontext.Temp_VariacionPatrimonialA.FirstOrDefault(p => p.CodigoIC == _plantilla.CodigoIc && p.CodsInstrumento == "RENTA VARIABLE" && p.CodsTipoInstrumento == "IIC" && p.CodsCategoria == string.Empty && p.CodsEmpresa == string.Empty).TotalIngresos;

                            decimal? RentaFijaVP = 0;
                            var objFija = dbcontext.Temp_VariacionPatrimonialA.Where(a => a.CodigoIC == _plantilla.CodigoIc && a.CodsInstrumento == "RENTA FIJA");
                            foreach (var item in objFija)
                            {
                                RentaFijaVP = RentaFijaVP + item.TotalPrecios;
                            }
                            decimal? RetornoAbsolutoVP = 0;
                            var objRabsoluto = dbcontext.Temp_VariacionPatrimonialA.Where(a => a.CodigoIC == _plantilla.CodigoIc && a.CodsInstrumento == "RETORNO ABSOLUTO");
                            foreach (var item in objRabsoluto)
                            {
                                RetornoAbsolutoVP = RetornoAbsolutoVP + item.TotalPrecios;
                            }

                            decimal? MercadoMonetarioVP = 0;
                            var objMmonetario = dbcontext.Temp_VariacionPatrimonialA.Where(a => a.CodigoIC == _plantilla.CodigoIc && a.CodsInstrumento == "MERCADO MONETARIO");
                            foreach (var item in objMmonetario)
                            {
                                MercadoMonetarioVP = MercadoMonetarioVP + item.TotalPrecios;
                            }

                            var SumatorioMenosOtros = RentaVariableValores + RentaVariableIIC + RentaVariableDerivados + RentaFijaVP + RetornoAbsolutoVP + MercadoMonetarioVP;
                            var OtrosActualizar = TotalRendimientos - SumatorioMenosOtros;                   
                            var objOtros = dbcontext.Temp_VariacionPatrimonialA.FirstOrDefault(w => w.CodigoIC == _plantilla.CodigoIc && w.CodsInstrumento == "OTROS");                        
                            objOtros.TotalPrecios = OtrosActualizar;
                            dbcontext.SaveChanges();
                        #endregion
                    }

                }
                catch (Exception ex)
                {
                    //dbContextTransaction.Rollback();

                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    log.Error("Error Actualizando campo", ex);
                    // Compliance                                           
                    throw;
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


            //if (e.Cell.Column.Name == "Cotizacion")
            //{
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            //}


        }
    }
}
