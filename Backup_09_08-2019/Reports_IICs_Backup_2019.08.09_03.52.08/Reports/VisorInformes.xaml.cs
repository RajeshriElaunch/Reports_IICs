using Telerik.Reporting;
using System;
using Reports_IICs.DataModels;
using System.Linq;
using Reports_IICs.Helpers;
using Reports_IICs.ViewModels.Reports;
using Reports_IICs.ViewModels.Reports.Secciones;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.Reports.Disclaimer;

namespace Reports_IICs.Reports
{
    /// <summary>
    /// Interaction logic for VisorInformes.xaml
    /// </summary>
    public partial class VisorInformes
    {
        private static double CalculateStepSize(double range, double targetSteps)
        {
            // calculate an initial guess at step size
            double tempStep = range / targetSteps;

            // get the magnitude of the step size
            double mag = Math.Floor(Math.Log10(tempStep));
            double magPow = Math.Pow(10, mag);

            // calculate most significant digit of the new step size
            double magMsd = (int)(tempStep / magPow + 0.5);

            // promote the MSD to either 1, 2, or 5
            if (magMsd > 5.0)
                magMsd = 10.0f;
            else if (magMsd > 2.0)
                magMsd = 5.0f;
            else if (magMsd > 1.0)
                magMsd = 2.0f;

            return magMsd * magPow;
        }

        public VisorInformes(Plantilla plantilla, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            InitializeComponent();

            ReportBook reportBook = new ReportBook
            {
                DocumentName =
                    string.Format(Properties.Resources.VisorInformes_VisorInformes__0_____1_, plantilla.Descripcion, fechaInforme.Year.ToString() + fechaInforme.Month.ToString().PadLeft(2, '0') + fechaInforme.Day.ToString().PadLeft(2, '0'))
            };
            //Add portada        
            AddPortada(plantilla, fechaInforme, ref reportBook);

            var secciones = plantilla.Plantillas_Secciones;

            foreach (var seccion in secciones.OrderBy(o=>o.Orden))
            {
                Report rep;                          
                
                switch (seccion.IdSeccion)
                {
                    case 1://Participes
                        #region Participes
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_Participes))
                            {
                                rep = Participes_VM.GetReportParticipes(plantilla.CodigoIc, isin.Isin, fechaInforme, plantilla);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 2://EVOLUCIÓN PATRIMONIO-VALOR LIQUIDATIVO
                        #region EVOLUCIÓN PATRIMONIO-VALOR LIQUIDATIVO
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin.ToUpper(), fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionPatrValLiq))
     
                            {
                                rep = EvolucionPatrimValorLiq_VM.GetReportEvolucionPatrimonioValorLiquidativo(plantilla.CodigoIc, isin.Isin.ToUpper(), fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                                //reportBook.Reports.Add(rep);
                            }
                        }
                        #endregion
                        break;
                    case 3://EVOLUCIÓN DE ÍNDICES/BENCHMARK
                        //#region EVOLUCIÓN DE ÍNDICES/BENCHMARK
                        //if (Report_VM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, Report_VM.TablaTemporal.Temp_EvolucionIndBench))
                        //{
                        //    var fDesde = new DateTime(fechaInforme.Year - 1, 12, 31);
                        //    reportBook.Reports.Add(EvolucionIndBench_VM.GetReportEvolucionIndBench(plantilla.CodigoIc, fechaInforme));
                        //}
                        //#endregion
                        break;
                    case 5://VARIACIÓN PATRIMONIAL A
                        //LO DESCOMENTAREMOS CUANDO LO TERMINEMOS
                        #region VARIACIÓN PATRIMONIAL A
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_VariacionPatrimonialA))
                            {
                                //string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
                                rep = VariacionPatrimonialA_VM.GetReport(plantilla, seccion.IdSeccion, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion                        
                        break;
                    case 6://DESGLOSE DE GASTOS
                        #region DESGLOSE DE GASTOS
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_DesgloseGastos))
                            {
                                //string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
                                //reportBook.Reports.Add(VariacionPatrimonialB_VM.GetReportVariacionPatrimonialB(plantilla.CodigoIc, isin.Isin, fechaInforme));
                                rep = DesgloseGastos_VM.GetReport(plantilla.CodigoIc, seccion.IdSeccion, isin.Isin, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 7://RENTABILIDAD CARTERA V1
                        #region RENTABILIDAD CARTERA V1
                        foreach (var isin in RentabilidadCarteraV1_VM.GetDistinctIndices(plantilla.CodigoIc))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin, fechaInforme, ReportVM.TablaTemporal.Temp_RentabilidadCarteraV1))
                            {
                                rep = RentabilidadCarteraV1_VM.GetReportRentabilidadCarteraV1(plantilla.CodigoIc, isin, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 8://RENTABILIDAD CARTERA V2
                        #region RENTABILIDAD CARTERA V2
                        foreach (var isin in RentabilidadCarteraV2_VM.GetDistinctIsins(plantilla.CodigoIc))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin, fechaInforme, ReportVM.TablaTemporal.Temp_RentabilidadCarteraV2))
                            {
                                rep = RentabilidadCarteraV2_VM.GetReportRentabilidadCarteraV2(plantilla.CodigoIc, isin, fechaInforme, plantilla);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 9://EVOLUCIÓN DE LOS MERCADOS
                        #region EVOLUCIÓN DE LOS MERCADOS
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionMercados))
                        {
                            //var fDesde = new DateTime(fechaInforme.Year - 1, 12, 31);
                            var fDesde = Utils.GetFechaInicio(plantilla, fechaInforme, typeof(Temp_EvolucionMercados));
                            rep = EvolucionMercados_VM.GetReportEvolucionMercados(plantilla.CodigoIc, fDesde, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        #endregion
                        break;
                    case 10://ÍNDICE PRECONFIGURADO (NOVAREX)
                        #region ÍNDICE PRECONFIGURADO (NOVAREX)
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_IndicePreconfiguradoNovarex))
                        {
                            //var fDesde = new DateTime(fechaInforme.Year - 1, 12, 31);
                            rep = IndicePreconfiguradoNovarex_VM.GetReportIndicePreconfiguradoNovarex(plantilla.CodigoIc);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        #endregion
                        break;
                    case 11://SUSCRIPCIONES-REEMBOLSOS
                        #region SUSCRIPCIONES-REEMBOLSOS
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_SuscripcionesReembolsos))
                            {
                                //var fDesde = new DateTime(fechaInforme.Year - 1, 12, 31);
                                rep = SuscripcionesReembolsos_VM.GetReportSubscripcionesReembolsos(plantilla.CodigoIc, null, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 12://DISTRIBUCIÓN PATRIMONIO NOVAREX
                        #region DISTRIBUCIÓN PATRIMONIO NOVAREX

                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_DistribucionPatrimonioNovarex_Cartera))
                        {
                            rep = DistribucionPatrimonioNovarex_VM.GetReport_Temp_DistribucionPatrimonioNovarex(plantilla.CodigoIc, null, fechaInforme, plantilla);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }

                        #endregion
                        break;
                    case 13://RENTA VARIABLE
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            #region RENTA VARIABLE
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_RentaVariable))
                            {
                                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme)).AddDays(-1);
                                rep = RentaVariable_VM.GetReportRentaVariable(plantilla.CodigoIc, null, fechaInforme, fechaInicio);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 14://COMPRA VENTA RESPECTO PRECIO ADQUISICIÓN 
                        #region COMPRA VENTA RESPECTO PRECIO ADQUISICIÓN
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_CompraVentaPrecAdq))
                            {
                                rep = CompraVentaPrecAdq_VM.GetReport(plantilla.CodigoIc, null);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 15://DIVERSIFICACIÓN ASSET
                        #region DIVERSIFICACIÓN ASSET
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_Diversificacion))
                            {
                                //var fDesde = new DateTime(fechaInforme.Year - 1, 12, 31);
                                rep = DiversificacionAsset_VM.GetReportDiversificacion(plantilla.CodigoIc, null);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 16://DIVIDENDOS COBRADOS                    
                        #region DIVIDENDOS COBRADOS
                        
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme,
                            ReportVM.TablaTemporal.Temp_DividendosCobrados))
                        {
                            rep = DividendosCobrados_VM.GetReportDividendosCobrados(plantilla);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        
                        //Actualizamos el parámetro "FechaUltimaReunion" después de cada generación
                        DividendosCobrados_VM.UpdateFechaUltimaReunion(plantilla.CodigoIc, fechaInforme);

                        #endregion

                        break;                    
                    case 17://PLUSVALIAS Y DIVIDENDOS
                        #region PLUSVALIAS Y DIVIDENDOS
                        
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_PlusvaliasDividendos))
                            {
                                rep = PlusvaliasDividendos_VM.GetReportPlusvaliasDividendos(plantilla.CodigoIc, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 18://RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                        #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_RvComprasRealizadasEjercicio))
                        {
                            rep = RvComprasRealizadasEjercicio_VM.GetReportRvComprasRealizadas(plantilla, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //Actualizamos el parámetro "FechaUltimaReunion" después de cada generación
                        RvComprasRealizadasEjercicio_VM.UpdateFechaUltimaReunion(plantilla.CodigoIc, fechaInforme);
                        #endregion
                        break;
                    case 19://IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                        #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                        //foreach (var isin in RentabilidadCarteraV1_VM.GetDistinctIndices(plantilla.CodigoIc))
                        //{
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_IIC_ComprasVentasEjercicio))
                        {
                            rep = IIC_ComprasVentasEjercicio_VM.GetReport_IIC_ComprasVentasEjercicio(plantilla, null, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //Actualizamos el parámetro "FechaUltimaReunion" después de cada generación
                        IIC_ComprasVentasEjercicio_VM.UpdateFechaUltimaReunion(plantilla.CodigoIc, fechaInforme);
                        //}
                        #endregion
                        break;
                    case 20://RF: COMPRAS Y VENTAS EJERCICIO
                        #region RF: COMPRAS Y VENTAS EJERCICIO
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_RFComprasVentasEjercicio))
                            {
                            //string isinDesc = isin.Descripcion;
                            string isinDesc = string.Empty;
                            var filtroFecha = plantilla.Parametros_RFComprasVentasEjercicio.Select(c => c.FechaAnterior).FirstOrDefault();

                                DateTime? fechaAnterior = null;

                                if (filtroFecha != null) fechaAnterior = plantilla.Parametros_RFComprasVentasEjercicio.Select(c => c.FechaAnterior).FirstOrDefault().Value;
                                rep = RfComprasVentasEjercicio_VM.GetReport(plantilla.CodigoIc, null, isinDesc, fechaInforme, fechaAnterior);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);

                            }
                        //}
                        #endregion
                        break;
                    case 21://RENTA FIJA                        
                            #region RENTA FIJA
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_RentaFija))
                            {
                                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme)).AddDays(-1);
                                rep = RentaFijaVM.GetReport(plantilla.CodigoIc, null, fechaInforme, fechaInicio);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 22://LISTADO RENTA FIJA NOVAREX
                        #region LISTADO RENTA FIJA NOVAREX
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_ListadoRentaFijaNovarex))
                            {
                                Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);
                                rep = ListadoRentaFijaNovarex_VM.GetReportListadoRentaFijaNovarex(plantilla.CodigoIc, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 23://CUPONES COBRADOS                            
                        #region CUPONES COBRADOS
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_CuponesCobrados))
                            {
                                rep = CuponesCobrados_VM.GetReportCuponesCobrados(plantilla.CodigoIc, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 24://CARTERA RF
                        #region CARTERA RF

                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_CarteraRF))
                        {
                            rep = Cartera_RF_VM.GetReportCarteraRF(plantilla.CodigoIc, fechaInforme, plantilla);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }

                        #endregion
                        break;
                    case 25://GRÁFICO I (BENCHMARK) 
                        #region GRÁFICO I (BENCHMARK)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoIBenchmark))
                            {
                                Reports_IICSEntities dbContext = new Reports_IICSEntities();

                                DateTime minimoFecha = dbContext.Temp_GraficoIBenchmark.Where(c => c.CodigoIc == plantilla.CodigoIc).Min(c => c.Fecha);
                               
                                DateTime maximoFecha = dbContext.Temp_GraficoIBenchmark.Where(c => c.CodigoIc == plantilla.CodigoIc).Max(c => c.Fecha);
                                
                                TimeSpan timespan = (maximoFecha - minimoFecha);

                                double days = timespan.TotalDays;

                                string isinDesc = Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);


                                rep = GraficoIBenchmark_VM.GetReport(plantilla.CodigoIc, null, fechaInforme, plantilla.Descripcion, days, isinDesc);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 26://CARTERA
                        #region CARTERA
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_PRO_11))
                            {
                            //string isinDesc = plantilla.Plantillas_Isins.Where(w => w.Isin.ToUpper() == isin.Isin.ToUpper()).FirstOrDefault().Descripcion;
                                rep = Cartera_VM.GetReportCartera(plantilla.CodigoIc, fechaInforme, plantilla);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}    
                        #endregion              
                        break;
                    case 27://RENTABILIDAD CARTERA GUISSONA
                        #region RENTABILIDAD CARTERA GUISSONA
                        //foreach (var isin in RentabilidadCarteraV2_VM.GetDistinctIsins(plantilla.CodigoIc))
                        //{
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionRentabilidadGuissona))
                        {
                            rep = EvolucionRentabilidadGuissona_VM.GetReportRentabilidadCarteraGuissona(plantilla.CodigoIc, null, fechaInforme, plantilla);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}
                        #endregion            
                        break;
                    case 28://EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        //foreach (var isin in RentabilidadCarteraV2_VM.GetDistinctIsins(plantilla.CodigoIc))
                        //{
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionPatrimonioConjuntoGuissona))
                        {
                            rep = EvolucionPatrimConjuntoGuissona_VM.GetReportEvolucionPatrimonioConjuntoGuissona(plantilla.CodigoIc, null, fechaInforme, plantilla);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}
                        #endregion
                        break;
                    case 29://EVOLUCIÓN PATRIMONIO GUISSONA
                        #region EVOLUCIÓN PATRIMONIO GUISSONA
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionPatrGuissona))
                        {
                            var fechaInicio = Utils.GetFechaInicio(plantilla, fechaInforme);
                            rep = EvolucionPatrimGuissona_VM.GetReportEvolucionPatrimonioGuissona(plantilla, fechaInicio, fechaInforme, plantilla.FechaCreacion);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}      
                        #endregion
                        break;
                    case 30://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO (TIPO DE PRODUCTO)
                        #region GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO (TIPO DE PRODUCTO)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficosExposMercTipodeProducto))
                            {

                                //Temp_GraficoCompPatrimonioTipoProducto
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                var porcentajeTotal = Report_BARS_CompPatrimonioTipodeProducto_DA.GetTotalPatrimonio(plantilla.CodigoIc, isin.Isin);
                                rep = GraficoDistrExpoMercTipoProd_VM.GetReportGraficosCompPatrimonioTipodeProducto(plantilla.CodigoIc, isin.Isin, fechaInforme, isinDesc, porcentajeTotal);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 31://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "TIPO DE ACTIVO"
                        #region GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "TIPO DE ACTIVO"
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoExposMercTipoActivo))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                var porcentajeTotal = Report_BARS_CompPatrimonioTipoActivo_DA.GetTotalPorcentaje(plantilla.CodigoIc, isin.Isin);
                                rep = GraficoDistrExpoMercTipoAct_VM.GetReportGraficosComposicionPatrimonioTipoActivo(plantilla.CodigoIc, isin.Isin, isinDesc, fechaInforme, porcentajeTotal);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 32://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "DIVISAS"
                        #region GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "DIVISAS"
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoExposMercDivisas))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                var porcentajeTotal = Report_BARS_CompPatrimonioDivisas_DA.GetTotalPorcentaje(plantilla.CodigoIc, isin.Isin);
                                rep = GraficoDistrExpoMercDivisas_VM.GetReportGraficosComposicionPatrimonioDivisas(plantilla.CodigoIc, isin.Isin, isinDesc, fechaInforme, porcentajeTotal);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 33://GRÁFICOS COMPOSICIÓN CARTERA (RV)
                        #region GRÁFICOS COMPOSICIÓN CARTERA (RV)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoCompCarteraRV))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);
                                rep = GraficoCompCartRV_VM.GetReportGraficosComposicionCarteraRV(plantilla, string.Empty, isinDesc, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 34://GRÁFICOS COMPOSICIÓN CARTERA (RF)
                        #region GRÁFICOS COMPOSICIÓN CARTERA (RF)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoCompCarteraRF))
                            {
                            //string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                            //rep = GraficoCompCartRF_VM.GetReportGraficosComposicionCarteraRF(plantilla, isin.Isin, isinDesc, fechaInforme);
                            rep = GraficoCompCartRF_VM.GetReportGraficosComposicionCarteraRF(plantilla, null, null, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 35://OPERACIONES RENTA VARIABLE (II)
                        #region OPERACIONES RENTA VARIABLE (II)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_OperacionesRentaVariable_II))
                            {
                                rep = OperacionesRV_II_VM.GetReportOperacionesRentaVariableII(plantilla.CodigoIc, null, fechaInforme, plantilla);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 36://RATIOS CARTERA RV (¿SECTORIALS?)
                        #region RATIOS CARTERA RV (¿SECTORIALS?)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_RatiosCarteraRV))
                            {
                                rep = RatiosCarteraRV_VM.GetReportRatiosCarteraRV(plantilla.CodigoIc, null, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;                    
                    case 37://CARTERA RV CCR-VOLGA-GAMAR
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_CarteraCcrVolgaGamar))
                        {
                            rep = CarteraCcrVolgaGamar_VM.GetReport(plantilla.CodigoIc);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        break;
                    case 38://GRÁFICOS BURBUJAS
                        #region GRÁFICOS BURBUJAS
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoBurbujas))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);

                                #region GetReportGraficosBurbujas
                                double minimoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionSmallBig != null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.DescuentoFundamental));
                                double maximoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionSmallBig != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.DescuentoFundamental));
                                double minEjeX = minimoEjeX;
                                double stepX;
                                double rangeStepEjeX = CalculateStepSize(maximoEjeX- minimoEjeX, 5);
                                //minimoEjeX = minimoEjeX - RangeStepEjeX;
                                stepX = rangeStepEjeX;
                                minimoEjeX = rangeStepEjeX * -1;

                                if (minEjeX>(minimoEjeX*-1/2))
                                    {
                                    minimoEjeX = 0;
                                }

                                double minimoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c=>c.PuntuacionSmallBig!=null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.PuntuacionSmallBig));
                                double maximoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionSmallBig != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.PuntuacionSmallBig));
                               
                                double minEjeY = minimoEjeY;
                                double stepY;

                                //double RangeStepEjeY = CalculateStepSize(maximoEjeY - minimoEjeY, 5);
                                double rangeStepEjeY = 1; //Force Step 1
                                stepY = rangeStepEjeY;
                                double maxEjeY = maximoEjeY + rangeStepEjeY;
                               

                                //minimoEjeY = minimoEjeY - RangeStepEjeY;
                                minimoEjeY =  rangeStepEjeY * -1;
                              
                                if (minEjeY > (minimoEjeY*-1 / 2))
                                {
                                    // minimoEjeY = 0;
                                    minimoEjeY = minEjeY- rangeStepEjeY;
                                    minimoEjeY = Math.Truncate(minimoEjeY);
                                }
                                //Force Values eje Y
                                maxEjeY = 11;
                                minimoEjeY = -0.80;
                                rep = GraficoBurbujas_VM.GetReportGraficosBurbujas(plantilla, null, isinDesc, fechaInforme, minimoEjeX, minimoEjeY, maxEjeY,stepX,stepY);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                                #endregion

                                #region GetReportGraficosBurbujasVALUE_GROWTH

                                minimoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionValueGrowth != null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.DescuentoFundamental));
                                maximoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionValueGrowth != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.DescuentoFundamental));
                                minEjeX = minimoEjeX;
                                stepX = 0;
                                 rangeStepEjeX = CalculateStepSize(maximoEjeX - minimoEjeX, 5);
                                //minimoEjeX = minimoEjeX - RangeStepEjeX;
                                stepX = rangeStepEjeX;
                                minimoEjeX = rangeStepEjeX * -1;

                                if (minEjeX > (minimoEjeX * -1 / 2))
                                {
                                    minimoEjeX = 0;
                                }

                                minimoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionValueGrowth != null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.PuntuacionValueGrowth));
                                maximoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionValueGrowth != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.PuntuacionValueGrowth));
                                minEjeY = minimoEjeY;
                                stepY = 0;

                               // RangeStepEjeY = CalculateStepSize(maximoEjeY - minimoEjeY, 5);
                                rangeStepEjeY = 1; //Force Step 1
                                stepY = rangeStepEjeY;
                                maxEjeY = maximoEjeY + rangeStepEjeY;
                                //minimoEjeY = minimoEjeY - RangeStepEjeY;
                                minimoEjeY = rangeStepEjeY * -1;

                                if (minEjeY > (minimoEjeY * -1 / 2))
                                {
                                   // minimoEjeY = 0;
                                    minimoEjeY = minEjeY- rangeStepEjeY;
                                    minimoEjeY = Math.Truncate(minimoEjeY);
                                }
                                //Force Values eje Y
                                maxEjeY = 11;
                                minimoEjeY = -0.80;
                                rep = GraficoBurbujas_VM.GetReportGráficosBurbujasVALUE_GROWTH(plantilla, null, isinDesc, fechaInforme, minimoEjeX, minimoEjeY, maxEjeY, stepX, stepY);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                                #endregion

                                #region GetReportGraficosBurbujasUTA

                                minimoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionUta != null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.DescuentoFundamental));
                                maximoEjeX = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionUta != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.DescuentoFundamental));
                                minEjeX = minimoEjeX;
                                stepX = 0;
                                rangeStepEjeX = CalculateStepSize(maximoEjeX - minimoEjeX, 5);
                                //minimoEjeX = minimoEjeX - RangeStepEjeX;
                                stepX = rangeStepEjeX;
                                minimoEjeX = rangeStepEjeX * -1;

                                if (minEjeX > (minimoEjeX * -1 / 2))
                                {
                                    minimoEjeX = 0;
                                }

                                minimoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionUta != null && c.DescuentoFundamental > -500 && c.Visible).Min(c => c.PuntuacionUta));
                                maximoEjeY = Convert.ToDouble(plantilla.Temp_Burbujas.Where(c => c.PuntuacionUta != null && c.DescuentoFundamental > -500 && c.Visible).Max(c => c.PuntuacionUta));
                                minEjeY = minimoEjeY;
                                stepY = 0;

                                //RangeStepEjeY = CalculateStepSize(maximoEjeY - minimoEjeY, 5);
                                rangeStepEjeY = 1; //Force Step 1
                                stepY = rangeStepEjeY;
                                maxEjeY = maximoEjeY + rangeStepEjeY;
                                //minimoEjeY = minimoEjeY - RangeStepEjeY;
                                minimoEjeY = rangeStepEjeY * -1;

                                if (minEjeY > (minimoEjeY * -1 / 2))
                                {
                                   // minimoEjeY = 0;
                                    minimoEjeY = minEjeY - rangeStepEjeY;
                                    minimoEjeY = Math.Truncate(minimoEjeY);
                                }
                                //Force Values eje Y
                                maxEjeY = 11;
                                minimoEjeY = 6.20;
                                rep = GraficoBurbujas_VM.GetReportGráficosBurbujasUTA(plantilla, null, isinDesc, fechaInforme, minimoEjeX, minimoEjeY, maxEjeY, stepX, stepY);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                                #endregion

                            }
                        //}
                        #endregion
                        break;
                    case 39://RENTABILIDAD CARTERA DESDE ORIGEN SOLEMEG
                        #region RENTABILIDAD CARTERA DESDE ORIGEN SOLEMEG
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_RentabilidadCarteraSolemeg))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);
                                rep = RentabilidadCarteraSolemeg_VM.GetReportGraficoRentabilidadCarteraSolemeg(plantilla.CodigoIc, null, fechaInforme, isinDesc);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        //}
                        #endregion
                        break;
                    case 41://PARTÍCIPES SALAT
                        #region PARTÍCIPES SALAT
                        //foreach (var isin in listaIsins)
                        //{
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_ParticipesSalat))
                        {
                            Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);
                            rep = ParticipesSalat_VM.GetReportParticipesSalat(plantilla.CodigoIc, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}
                        #endregion
                        break;
                    case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                        #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoCompPatrimonioTipoProducto))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                rep = GraficoDistrPatrTipoProd_VM.GetReport(plantilla.CodigoIc, isin.Isin, fechaInforme, isinDesc);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 43://GRÁFICOS DISTRIBUCIÓN PATRIMONIO "TIPO DE ACTIVO"
                        #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO "TIPO DE ACTIVO"
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {
                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoCompPatrimonioTipoActivo))
                            {
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                rep = GraficoDistrPatrTipoAct_VM.GetReport(plantilla.CodigoIc, isin.Isin, isinDesc, fechaInforme);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 44://GRÁFICOS DISTRIBUCIÓN PATRIMONIO "DIVISAS"
                        #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO "DIVISAS"
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion.Seccione))
                        {

                            if (ReportVM.TempHasValues(plantilla.CodigoIc, isin.Isin, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoCompPatrimonioDivisas))
                            {
                                
                                string isinDesc = Utils.GetIsinDescripcion(plantilla, isin.Isin, fechaGeneracion);
                                var porcentajeTotal = Report_BARS_CompPatrimonioDivisas_DA.GetTotalPorcentaje(plantilla.CodigoIc, isin.Isin);
                                rep = GraficoDistrPatrDivisas_VM.GetReportGraficosComposicionPatrimonioDivisas(plantilla.CodigoIc, isin.Isin, isinDesc, fechaInforme, porcentajeTotal);
                                AñadirReport(rep, seccion.Seccione, ref reportBook);
                            }
                        }
                        #endregion
                        break;
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        //Los datos se guardan en la tabla de la sección 2 y la 25
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_EvolucionPatrValLiq)
                            || ReportVM.TempHasValues(plantilla.CodigoIc, string.Empty, fechaInforme, ReportVM.TablaTemporal.Temp_GraficoIBenchmark))
                        {
                            Reports_IICSEntities dbContext = new Reports_IICSEntities();

                            DateTime minimoFecha = dbContext.Temp_GraficoIBenchmark.Where(c => c.CodigoIc == plantilla.CodigoIc).Min(c => c.Fecha);

                            DateTime maximoFecha = dbContext.Temp_GraficoIBenchmark.Where(c => c.CodigoIc == plantilla.CodigoIc).Max(c => c.Fecha);

                            TimeSpan timespan = (maximoFecha - minimoFecha);

                            double days = timespan.TotalDays;

                            string isinDesc = Utils.GetIsinDescripcion(plantilla, null, fechaGeneracion);


                            rep = SituacionPatrimRent_VM.GetReport(plantilla.CodigoIc, null, fechaInforme, plantilla.Descripcion, days, isinDesc);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}
                        #endregion
                        break;
                    case 46://VARIACIÓN PATRIMONIAL B
                        #region VARIACIÓN PATRIMONIAL B
                        //foreach (var isin in plantilla.Plantillas_Isins)
                        //{
                        if (ReportVM.TempHasValues(plantilla.CodigoIc, null, fechaInforme, ReportVM.TablaTemporal.Temp_VariacionPatrimonialB))
                        {
                            //Pintamos la misma sección que en la sección 5 que se mostrará diferente
                            rep = VariacionPatrimonialA_VM.GetReport(plantilla, seccion.IdSeccion, fechaInforme);
                            AñadirReport(rep, seccion.Seccione, ref reportBook);
                        }
                        //}
                        #endregion                        
                        break;
                }
            }

            //añadimos el Disclaimer, al final del informe
            AddDisclaimer(plantilla, ref reportBook);

            //this.ReportViewerGVC.Report = reportBook;
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource {ReportDocument = reportBook};
            this.ReportViewerGVC.ReportSource = instanceReportSource;            

            this.ReportViewerGVC.RefreshReport();            


        }

        private void AddPortada(Plantilla plantilla, DateTime fecha, ref ReportBook reportBook)
        {
            var rep = ReportVM.GetReportPortada(plantilla, fecha);
            //rep.TocText = "PORTADA";
            rep.DocumentMapText = "PORTADA";
            rep.Culture = new System.Globalization.CultureInfo("es-ES");
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();

            //Los reports de 3 plantillas tienen orientación Landscape
            rep.PageSettings.Landscape = true;
            setMargins(rep);
            //}

            // Assigning the Report object to the InstanceReportSource
            instanceReportSource.ReportDocument = rep;

            //reportBook.Reports.Add(rep);
            reportBook.ReportSources.Add(instanceReportSource);

        }

        private void AddDisclaimer(Plantilla plantilla, ref ReportBook reportBook)
        {
            Report rep = new ReportDisclaimer(plantilla.CodigoIc);
            rep.DocumentMapText = "DISCLAIMER";
            rep.Culture = new System.Globalization.CultureInfo("es-ES");
            var instanceReportSource = new InstanceReportSource();
            
            rep.PageSettings.Landscape = true;
            setMargins(rep);
            
            // Assigning the Report object to the InstanceReportSource
            instanceReportSource.ReportDocument = rep;

            //reportBook.Reports.Add(rep);
            reportBook.ReportSources.Add(instanceReportSource);
        }

        private void setMargins(Report rep, int? idSeccion = null)
        {
            if (idSeccion != null 
                && idSeccion != 13
                && idSeccion != 27)
            {
                rep.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            }
        }

        private void AñadirReport(Report rep, Seccione seccion, ref ReportBook reportBook)
        {
            //rep.TocText = seccion.Descripcion;            
            rep.DocumentMapText = seccion.Descripcion;
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource {ReportDocument = rep};

            // Assigning the Report object to the InstanceReportSource

            //Los reports de 3 plantillas tienen orientación Landscape
            rep.PageSettings.Landscape = true;
            rep.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(297D), Telerik.Reporting.Drawing.Unit.Cm(210D));
            setMargins(rep, seccion.Id);


            
                //Borde footer
                var pf = rep.Items.OfType<PageFooterSection>().FirstOrDefault();
                if (pf != null)
                {
                    //rep.Items.Find(PageFooterSection)
                    //this.pageFooter.Style.BorderColor.Top = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
                    //this.pageFooter.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
                    pf.Style.BorderColor.Top = System.Drawing.Color.FromArgb(228, 228, 225);
                    pf.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
                }

                //Border header
                var ph = rep.Items.OfType<PageHeaderSection>().FirstOrDefault();
                if (ph != null)
                {
                    ph.Style.BorderColor.Bottom = System.Drawing.Color.FromArgb(228, 228, 225);
                    ph.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;                    
                }

                //Padding top
                var rh = rep.Items.OfType<ReportHeaderSection>().FirstOrDefault();
                if (rh != null)
                {
                    rh.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
                }

                var gh = rep.Items.OfType<GroupHeaderSection>().FirstOrDefault();
                if (gh != null)
                {
                    gh.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Cm(5D);
                    gh.Style.BorderColor.Top = System.Drawing.Color.Transparent;
                }
                
            reportBook.ReportSources.Add(instanceReportSource);
        }
    }
}