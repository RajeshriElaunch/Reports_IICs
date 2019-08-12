using MahApps.Metro.Controls;
using Reports_IICs.DataAccess;
using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Managers;
using Reports_IICs.Pages.Informes;
using Reports_IICs.Pages.Previews;
using Reports_IICs.Reports;
using Reports_IICs.Reports.Portada;
using Reports_IICs.Resources;
using Reports_IICs.ViewModels.Reports.Secciones;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Telerik.Reporting;
using Telerik.Windows.Controls;

namespace Reports_IICs.ViewModels.Reports
{
    public static class ReportVM
    {
        private static bool _hasError = false;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="fecha"></param>
        /// <param name="actualizarCambiosPreview">Cuando se acaba de modificar la Preview de RV - Sección 13</param>
        /// <param name="actualizarSeccRV">Si borran cambios guardados en la Preview de otras generaciones, tenemos que actualizar también la sección de Renta Variable (Sección 13)</param>
        public static void CopyPlantillaToTemp(Plantilla plantilla, DateTime fecha, bool actualizarCambiosPreviewRV, bool actualizarSeccRV, bool actualizarCambiosPreviewRF, bool actualizarSeccRF)
        {
            #region show progress
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            List<TempTableBase> listaTmp = new List<TempTableBase>();

            int millisecondsTimeout = 150;
            int i = 1;

            string textoProgressDialog = actualizarCambiosPreviewRV || actualizarCambiosPreviewRF ? "Actualizando secciones dependientes" : "Procesando secciones";

            var timeout = millisecondsTimeout;
            Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, textoProgressDialog, () =>
            {
                #region process secciones                

                var secciones = plantilla.Plantillas_Secciones.OrderBy(o => o.Orden).ToList();
                //Si actualizarCambiosPreview = true sólo regeneramos las secciones dependientes de RV (Sección 13)

                #region actualizar PreviewRV
                if (actualizarCambiosPreviewRV)
                {
                    secciones = secciones.Where(w => w.Seccione.DependienteRV).ToList();
                }

                if(actualizarSeccRV && secciones.All(w => w.IdSeccion != 13))
                {
                    var secc13 = plantilla.Plantillas_Secciones.First(w => w.IdSeccion == 13);
                    if (secc13 != null)
                        secciones.Add(secc13);

                    //Nos aseguramos de eliminar los Temp_RentaVariabla de listaTmp
                    listaTmp.RemoveAll(w => w.GetType() == new Temp_RentaVariable().GetType());
                }
                #endregion

                #region actualizar PreviewRF
                if (actualizarCambiosPreviewRF)
                {
                    secciones = secciones.Where(w => w.Seccione.DependienteRF).ToList();
                }

                if (actualizarSeccRF && secciones.All(w => w.IdSeccion != 21))
                {
                    var secc21 = plantilla.Plantillas_Secciones.First(w => w.IdSeccion == 21);
                    if (secc21 != null)
                        secciones.Add(secc21);

                    //Nos aseguramos de eliminar los Temp_RentaVariabla de listaTmp
                    listaTmp.RemoveAll(w => w.GetType() == new Temp_RentaFija().GetType());
                }
                #endregion

                foreach (var seccion in secciones)
                {
                    
                    try
                    {
                        int percent = Convert.ToInt32(((double)i / plantilla.Plantillas_Secciones.Count) * 100);
                        Pages.Informes.ProgressDialog.ProgressDialog.Current.Report(percent, "Sección {0}... ({1} de {2})", seccion.Seccione.Descripcion, i, secciones.Count);

                        //Insertamos el resultado en la tablas temporales
                        switch (seccion.IdSeccion)
                        {
                            case 1://PARTÍCIPES
                                Participes_VM.Insert_Temp(plantilla, fecha, ref listaTmp, seccion.Seccione);
                                break;
                            case 2://EVOLUCIÓN PATRIMONIO-VALOR LIQUIDATIVO  
                            
                                if (listaTmp.All(w => w.GetType() != new Temp_EvolucionPatrValLiq().GetType()))
                                {                                   
                                    EvolucionPatrimValorLiq_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //Generamos la parte de los índices de referencia
                                EvolucionIndBench_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            //La sección 3 desaparece y se generará conjuntamente con la sección 2
                            //case 3://EVOLUCIÓN DE ÍNDICES/BENCHMARK
                            //    EvolucionIndBench_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                            //    break;
                            //case 4://CANCELADA
                            case 5://VARIACIÓN PATRIMONIAL A
                                   //En esta sección mostramos datos de las secciones 6, 11, 13 y 21
                                   //Si no se ha generado aún, se genera en este momento
                                   //Si no están en plantilla.Plantillas_Secciones no las mostraremos en el informe aunque hayan sido generadas
                                   //var seccImplicadas = new List<int>() { 6, 11, 13, 21 };
                                   //var seccGenerar = plantilla.Plantillas_Secciones.Where(w => !seccImplicadas.Contains(w.IdSeccion)).Select(s => s.IdSeccion);
                                //LO DESCOMENTAREMOS CUANDO ESTÉ DESARROLLADA
                                //case 6: ANTIGUA VARIACIÓN PATRIMONIAL B
                                //if (listaTmp.Where(w => w.GetType() == new Temp_VariacionPatrimonialB().GetType()).Count() == 0)
                                if (listaTmp.All(w => w.GetType() != new Temp_DesgloseGastos().GetType()))
                                {
                                    DesgloseGastos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 11:
                                if (listaTmp.All(w => w.GetType() != new Temp_SuscripcionesReembolsos().GetType()))
                                {
                                    SuscripcionesReembolsos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 13:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaVariable().GetType()))
                                {
                                    RentaVariable_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 21:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaFija().GetType()))
                                {
                                    RentaFijaVM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 23:
                                if (listaTmp.All(w => w.GetType() != new Temp_CuponesCobrados().GetType()))
                                {
                                    CuponesCobrados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 46:
                                if (listaTmp.All(w => w.GetType() != new Temp_VariacionPatrimonialB().GetType()))
                                {
                                    VariacionPatrimonialB_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 5:
                                VariacionPatrimonialA_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 6://DESGLOSE DE GASTOS
                                   //Está sección también forma parte de la sección 5. Si la sección 5 es parte de 
                                   //este informe y tienen un orden prioritario, ya habrá sido generada
                                   //en ese caso no volvemos a generarla
                                if (listaTmp.All(w => w.GetType() != new Temp_DesgloseGastos().GetType()))
                                {
                                    DesgloseGastos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 7://RENTABILIDAD CARTERA [VERSIÓN 1]
                                RentabilidadCarteraV1_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 8://RENTABILIDAD CARTERA [VERSIÓN 2]
                                RentabilidadCarteraV2_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 9://EVOLUCIÓN DE LOS MERCADOS
                                EvolucionMercados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 10://ÍNDICE PRECONFIGURADO (NOVAREX)
                                IndicePreconfiguradoNovarex_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 11://SUSCRIPCIONES-REEMBOLSOS
                                    //Está sección también forma parte de la sección 5. Si la sección 5 es parte de 
                                    //este informe y tienen un orden prioritario, ya habrá sido generada
                                    //en ese caso no volvemos a generarla
                                if (listaTmp.All(w => w.GetType() != new Temp_SuscripcionesReembolsos().GetType()))
                                {
                                    SuscripcionesReembolsos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 12://DISTRIBUCIÓN PATRIMONIO
                                DistribucionPatrimonioNovarex_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 13://RENTA VARIABLE
                                    //Está sección también forma parte de la sección 5. Si la sección 5 es parte de 
                                    //este informe y tienen un orden prioritario, ya habrá sido generada
                                    //en ese caso no volvemos a generarla
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaVariable().GetType()))
                                {
                                    RentaVariable_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                CompraVentaPrecAdq_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 15://DIVERSIFICACIÓN ASSET
                                DiversificacionAsset_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 16://DIVIDENDOS COBRADOS
                                //case 16:
                                if (listaTmp.All(w => w.GetType() != new Temp_DividendosCobrados().GetType()))
                                {
                                    DividendosCobrados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 17://PLUSVALÍAS Y DIVIDENDOS
                                //Para esta sección necesitamos que se haya generado previamente la sección 13
                                //Si no se ha generado aún, se genera en este momento
                                //case 13:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaVariable().GetType()))
                                {
                                    RentaVariable_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //lo mismo pasa con la sección 16
                                //case 16:
                                if (listaTmp.All(w => w.GetType() != new Temp_DividendosCobrados().GetType()))
                                {
                                    DividendosCobrados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                PlusvaliasDividendos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 18://RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                                //Si no se ha generado aún, se genera en este momento
                                //case 13:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaVariable().GetType()))
                                {
                                    RentaVariable_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                RvComprasRealizadasEjercicio_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 19://IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                                IIC_ComprasVentasEjercicio_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 20://RF: COMPRAS Y VENTAS EJERCICIO
                                RfComprasVentasEjercicio_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 21://RENTA FIJA
                                    //Está sección también forma parte de la sección 5. Si la sección 5 es parte de 
                                    //este informe y tienen un orden prioritario, ya habrá sido generada
                                    //en ese caso no volvemos a generarla
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaFija().GetType()))
                                {
                                    RentaFijaVM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 22://LISTADO RENTA FIJA NOVAREX
                                ListadoRentaFijaNovarex_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 23://CUPONES COBRADOS
                                if (listaTmp.All(w => w.GetType() != new Temp_CuponesCobrados().GetType()))
                                {
                                    CuponesCobrados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                break;
                            case 24://CARTERA RF
                                Cartera_RF_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 25://GRÁFICO I (BENCHMARK)
                                GraficoIBenchmark_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 26://CARTERA
                                Cartera_VM_Prueba.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 27://EVOLUCIÓN RENTABILIDAD (GUISSONA)
                                EvolucionRentabilidadGuissona_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 28://EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                EvolucionPatrimConjuntoGuissona_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 29://EVOLUCIÓN PATRIMONIO GUISSONA
                                EvolucionPatrimGuissona_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 30://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO (TIPO DE PRODUCTO)
                                GraficoDistrExpoMercTipoProd_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 31://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "TIPO DE ACTIVO"
                                GraficoDistrExpoMercTipoAct_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 32://GRÁFICO DISTRIBUCIÓN EXPOSICIÓN MERCADO "DIVISAS"
                                GraficoDistrExpoMercDivisas_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 33://GRÁFICOS COMPOSICIÓN CARTERA (RV)
                                GraficoCompCartRV_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 34://GRÁFICOS COMPOSICIÓN CARTERA (RF)
                                GraficoCompCartRF_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 35://OPERACIONES RENTA VARIABLE (II)
                                OperacionesRV_II_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 36://RATIOS CARTERA RV (¿SECTORIALS?)
                                RatiosCarteraRV_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 37://CARTERA RV CCR-VOLGA-GAMAR
                                CarteraCcrVolgaGamar_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 38://GRÁFICO BURBUJAS SMALL BIG
                                GraficoBurbujas_SmallBig_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 39://RENTABILIDAD CARTERA DESDE ORIGEN SOLEMEG
                                RentabilidadCarteraSolemeg_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 40:
                                //cancelada
                                break;
                            case 41://PARTÍCIPES SALAT
                                //Esta sección es sólo para SALAT y no tiene su tabla temporal
                                ParticipesSalat_VM.Insert_Temp(plantilla, fecha);
                                break;
                            case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                GraficoDistrPatrTipoProd_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 43://GRÁFICOS DISTRIBUCIÓN PATRIMONIO "TIPO DE ACTIVO"
                                GraficoDistrPatrTipoAct_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 44://GRÁFICOS DISTRIBUCIÓN PATRIMONIO "DIVISAS"
                                GraficoDistrPatrDivisas_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                break;
                            case 45: //SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                                if (listaTmp.All(w => w.GetType() != new Temp_EvolucionPatrValLiq().GetType()))
                                {
                                    EvolucionPatrimValorLiq_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                if (listaTmp.All(w => w.GetType() != new Temp_GraficoIBenchmark().GetType()))
                                {
                                    GraficoIBenchmark_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }                                
                                break;
                            case 46: //VARIACIÓN PATRIMONIAL B                                
                                if (listaTmp.All(w => w.GetType() != new Temp_DesgloseGastos().GetType()))
                                {
                                    DesgloseGastos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 11:
                                if (listaTmp.All(w => w.GetType() != new Temp_SuscripcionesReembolsos().GetType()))
                                {
                                    SuscripcionesReembolsos_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 13:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaVariable().GetType()))
                                {
                                    RentaVariable_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 21:
                                if (listaTmp.All(w => w.GetType() != new Temp_RentaFija().GetType()))
                                {
                                    RentaFijaVM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 23:
                                if (listaTmp.All(w => w.GetType() != new Temp_CuponesCobrados().GetType()))
                                {
                                    CuponesCobrados_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 5:
                                if (listaTmp.All(w => w.GetType() != new Temp_VariacionPatrimonialA().GetType()))
                                {
                                    VariacionPatrimonialA_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                //case 46:
                                if (listaTmp.All(w => w.GetType() != new Temp_VariacionPatrimonialB().GetType()))
                                {
                                    VariacionPatrimonialB_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                                }
                                
                                break;
                        }

                        i++;
                        Thread.Sleep(timeout);
                    }
                    catch (Exception ex)
                    {
                        _hasError = true;
                        throw new Exception(Utils.FormatErrorSeccion(seccion.Seccione.Descripcion, plantilla.Descripcion, fecha), ex);

                    }

                }

                #endregion
            }, new Pages.Informes.ProgressDialog.ProgressDialogSettings(true, false, false), plantilla.CodigoIc, fecha);


            #endregion  

            if (result.OperationFailed)
            {
                //log.Error("Error Generando Datos Temporales " + result.Error, result.Error.InnerException);
                _hasError = true;

                var mens = "Se ha producido un error al generar las secciones.";
                if (!string.IsNullOrEmpty(result.Error.Message))
                {
                    mens = result.Error.Message;
                }

                Log.Error(mens, result.Error.InnerException);

                Errores_DA.InsertError(result.Error, mens, plantilla.CodigoIc, fecha);

                //RadWindow.Alert(new TextBlock { Text = mens, TextWrapping = TextWrapping.Wrap, Width = 400 });
                Utils.ShowDialog(mens);
            }
            else
            {
                try
                {
                    millisecondsTimeout = 500;                    
                    result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Guardando datos...", () =>
                    {
                        
                        //Insertamos todos los datos temp para todas las secciones
                        Temp_Table_Manager.InsertTemp(plantilla, listaTmp, fecha, actualizarCambiosPreviewRV, actualizarCambiosPreviewRF);                        
                        Thread.Sleep(millisecondsTimeout);
                    }, plantilla.CodigoIc, fecha);

                    //Comprobamos si tenemos que mostrar alertas
                    CheckDescuadres(plantilla, fecha, true);
                    Plantillas_DA.GuardarGeneracion(plantilla, fecha);

                    //Todo ha ido correctamente
                    _hasError = false;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    _hasError = true;

                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error Report_VM/CopyPlantillaToTemp", ex);
                    // Compliance                                           
                    throw;
                }
                catch (DbUpdateException ex)
                {
                    _hasError = true;
                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error Report_VM/CopyPlantillaToTemp", ex);
                    // Compliance                                           
                    throw;
                }
                catch (Exception ex)
                {
                    _hasError = true;                    
                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error Report_VM/CopyPlantillaToTemp", ex);
                    // Compliance                                           
                    throw;
                }
            }

            //return hasError;
        }

        public static void CargarProcedimientos(Plantilla plantilla, DateTime fecha)
        {
            try
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;

                int millisecondsTimeout = 150;
                int i = 1;

                var procs = new List<string>();
                foreach (var seccion in plantilla.Plantillas_Secciones)
                {
                    foreach (var pro in seccion.Seccione.SeccionesProcedimientos)
                    {
                        if (!procs.Contains(pro.Procedimiento))
                        {
                            procs.Add(pro.Procedimiento);
                        }
                    }
                }

                Pages.Informes.ProgressDialog.ProgressDialogResult resultVentProc = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Cargando procedimientos", () =>
                {
                    //Cargamos los procs que se puedan llamar desde aquí
                    //var fechaIni = Utils.GetFechaInicio(plantilla, fecha);
                    var fechaInf = Convert.ToDateTime(fecha);
                    int contProc = 1;
                    foreach (var proc in procs)
                    {
                        int percent = Convert.ToInt32(((double)i / plantilla.Plantillas_Secciones.Count) * 100);
                        Pages.Informes.ProgressDialog.ProgressDialog.Current.Report(percent, "Procedimiento... {0} ({1} de {2})", "PRO_" + proc, contProc, procs.Count);

                        Type tipoActualizar = null;
                        switch (proc)
                        {
                            case "9":
                                tipoActualizar = typeof(usp_gestio_pro_09_Result);
                                break;
                            case "11":
                                tipoActualizar = typeof(usp_gestio_pro_11_Result);
                                break;
                            case "13":
                                tipoActualizar = typeof(usp_gestio_pro_13_Result);
                                break;
                            case "21":
                                tipoActualizar = typeof(usp_gestio_pro_21_Result);
                                break;
                            case "22":
                                tipoActualizar = typeof(usp_gestio_pro_22_Result);
                                break;
                        }

                        if (tipoActualizar != null)
                            VariablesGlobales.SetVariablesGlobales(tipoActualizar, plantilla, fechaInf);

                        contProc++;
                        i++;
                        Thread.Sleep(millisecondsTimeout);
                    }
                }, new Pages.Informes.ProgressDialog.ProgressDialogSettings(true, false, false), plantilla.CodigoIc, fecha);

                if (resultVentProc.OperationFailed)
                {
                    Log.Error("Error Generando Datos Temporales " + resultVentProc.Error, resultVentProc.Error.InnerException);
                    _hasError = true;
                    var message = !string.IsNullOrEmpty(resultVentProc.Error.Message) ? resultVentProc.Error.Message : "Se Ha producido un error al cargar los procedimientos";
                    RadWindow.Alert(new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap, Width = 400 });
                }
                else
                {
                    if (_hasError)
                    {
                        const string mens = "Se Ha producido un error al cargar los procedimientos";
                        RadWindow.Alert(new TextBlock { Text = mens, TextWrapping = TextWrapping.Wrap, Width = 400 });
                    }
                }
            }
            catch (Exception ex)
            {
                _hasError = true;
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Report_VM/CargarProcedimientos", ex);
                // Compliance                                           
                throw;
            }
        }

        /// <summary>
        /// Validaciones previas antes de lanzar el informe de las secciones de la plantilla seleccionada
        /// También revisaremos si tienen parámetros previos y si están rellenos
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="fechaInforme"></param>
        /// <param name="tareasPendientes">Se devolverá la sección, el campo y la corrección necesaria para generar el informe</param>
        /// <param name="isinsFaltan"></param>
        /// <returns></returns>
        private static bool ValidacionesPrevias(Plantilla plantilla, DateTime? fechaInforme, ref List<Tuple<string, string>> tareasPendientes, ref List<string> isinsFaltan)
        {
            //if (tareasPendientes == null) throw new ArgumentNullException(nameof(tareasPendientes));
            //Aquí es cuando inicializamos esta variable a false, justo antes de generar
            _hasError = false;

            bool valido = false;
            tareasPendientes = new List<Tuple<string, string>>();

            //Borramos las Variables Globales de los procedimientos
            VariablesGlobales.ClearVariablesProcs();
            //Cargamos los procedimientos y nos aseguramos que tenemos todos los Instrumentos y Bloomberg necesarios
            CargarProcedimientos(plantilla, Convert.ToDateTime(fechaInforme));

            if (!_hasError)
            {
                var listaIsins = new List<string>();

                if (VariablesGlobales.Pro09_Local != null)
                    listaIsins = listaIsins.Concat(VariablesGlobales.Pro09_Local.Select(s => s.isin)).ToList();

                if (VariablesGlobales.Pro11_Local != null)
                    listaIsins = listaIsins.Concat(VariablesGlobales.Pro11_Local.Select(s => s.isin)).ToList();

                //if (VariablesGlobales.Pro11_Local != null)
                //    listaIsins = listaIsins.Concat(VariablesGlobales.Pro11_Local.Select(s => s.isin)).ToList();

                if (VariablesGlobales.Pro13_Local != null)
                    listaIsins = listaIsins.Concat(VariablesGlobales.Pro13_Local.Select(s => s.Isin)).ToList();

                if (VariablesGlobales.Pro21_Local != null)
                    listaIsins = listaIsins.Concat(VariablesGlobales.Pro21_Local.Select(s => s.Isin)).ToList();

                if (VariablesGlobales.Pro22_Local != null)
                    listaIsins = listaIsins.Concat(VariablesGlobales.Pro22_Local.Select(s => s.b3001_cod)).ToList();

                //Recuperamos los no repetidos y en mayúsculas
                listaIsins = listaIsins.ConvertAll(c => c.Trim().ToUpper()).Distinct().ToList();

                valido = ValidarIsinsEnInstrumentos(plantilla, listaIsins, ref tareasPendientes, ref isinsFaltan);

                //sólo validamos los Bloomberg si se está generando la sección 36 que es la única que los utiliza
                if (plantilla.Plantillas_Secciones.FirstOrDefault(f => f.IdSeccion == 36) != null)
                {
                    valido = ValidarIsinsBloomberg(plantilla, ref tareasPendientes, ref isinsFaltan);
                }
                //Siempre validamos esto con cada generación
                var secciones = plantilla.Plantillas_Secciones.Where(s => s.Seccione.TieneValidacionesPrevias);

                var seccionesConParametros = plantilla.Plantillas_Secciones.Where(s => s.Seccione.TieneParametrosPrevios);
                var plantillasSeccioneses = seccionesConParametros as Plantillas_Secciones[] ?? seccionesConParametros.ToArray();
                if (secciones.Any() || plantillasSeccioneses.Any())
                {
                    //Validamos que todos los parámetros necesarios 
                    foreach (var seccion in plantillasSeccioneses)
                    {
                        //Insertamos el resultado en la tablas temporales
                        switch (seccion.IdSeccion)
                        {
                            case 9://EVOLUCIÓN MERCADOS
                                if (!plantilla.Parametros_EvolucionMercados.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));
                                }
                                break;
                            //Desde que se permite pintar un sólo índice este parámetro ya no será necesario
                            //case 25://GRÁFICO I (BENCHMARK)
                            //    if (plantilla.Parametros_GraficoBenchmark.Count() == 0)
                            //    {
                            //        tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));                                
                            //    }
                            //    break;
                            case 27://EVOLUCIÓN RENTABILIDAD (GUISSONA)
                                if (!plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));
                                }
                                break;
                            case 28://EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                if (!plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));
                                }
                                break;
                            case 29://EVOLUCIÓN PATRIMONIO GUISSONA
                                if (!plantilla.Parametros_EvolucionPatrimGuissona.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));
                                }
                                break;
                            case 41://PARTÍCIPES SALAT
                                if (!plantilla.Plantillas_Participes.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParticipesIncompletos));
                                }
                                break;
                            case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                    //Esta sección tiene parámetro obligatorio si la plantilla tiene alguna estrategia
                                if (plantilla.Plantillas_Estrategias.Any() && !plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.PorcEstratRaIncompleto));
                                }
                                break;
                                //case 36://RATIOS CARTERA RV (¿SECTORIALS?)

                                //    if (plantilla.Parametros_RatiosCarteraRV != null)
                                //    {
                                //        var param36 = plantilla.Parametros_RatiosCarteraRV.Where(p => p.CodigoIC == plantilla.CodigoIc);
                                //        if (param36.Count() < 1)
                                //        {
                                //            tareasPendientes.Add(new Tuple<string, string>(seccion.Seccione.Descripcion, Resource.ParametrosSeccionIncompletos));
                                //        }
                                //    }
                                //    break;
                        }
                    }

                    //validaciones particulares de alguna sección
                    foreach (var seccion in plantilla.Plantillas_Secciones)
                    {
                        //Insertamos el resultado en la tablas temporales
                        switch (seccion.IdSeccion)
                        {
                            case 37://CARTERA RV CCR-VOLGA-GAMAR
                                    //Miramos que todos los instrumentos de la cartera (PRO11) que sean RVA 
                                    //en los instrumentos importados tengan el campo CORE/TRADING con “CORE” o con 
                                    //“TRADING”. En caso de que estén en blanco o tengan “SIN CLASIFICACIÓN” 
                                    //mostramos un mensaje con los ISINS que tienen que ser corregidos (exportable a Excel) 
                                    //y no continuamos con la generación.
                                var proRV = VariablesGlobales.Pro11_Local.Where(w => w.CodInstrumento == "RVA").Select(s => s.Isin).ToList();
                                var faltan = VariablesGlobales.InstrumentosImportados_Local.Where(w => proRV.Contains(w.ISIN)
                                                                    && (
                                                                        string.IsNullOrEmpty(w.CoreTrading) ||
                                                                        w.CoreTrading == "SIN CLASIFICACIÓN" ||
                                                                        (w.CoreTrading != "CORE" && w.CoreTrading != "TRADING")
                                                                        )).Select(s => s.ISIN).ToList();
                                var stringFaltan = Utils.CommaSeparatedStringFromList(faltan);

                                if (faltan.Any())
                                {
                                    tareasPendientes.Add(new Tuple<string, string>(Resource.ImportCoreTrading + stringFaltan, seccion.Seccione.Descripcion));
                                    //Añadimos este elemento para que cuando exportemos a excel todos los isins podamos
                                    //distinguir entre los que son instrumentos, los que son Bloomberg y los que son CORE/TRADING
                                    isinsFaltan.Add("");
                                    isinsFaltan.Add("CORE/TRADING no informado");
                                    isinsFaltan.AddRange(faltan);
                                }


                                break;
                        }
                    }

                    if (tareasPendientes.Count == 0)
                    {
                        valido = true;
                    }
                }
                else
                {
                    valido = true;
                }


                if (tareasPendientes.Count > 0)
                {
                    valido = false;
                }
            }
            
            return valido;
        }

        private static bool ValidarIsinsBloomberg(Plantilla plantilla, ref List<Tuple<string, string>> tareasPendientes, ref List<string> listaIsinsFaltan)
        {
            //Sólo realizamos la comprobación si la plantilla tiene la sección 36
            //que es la única que necesita datos de Bloomberg
            if (plantilla.Plantillas_Secciones.Any(w => w.IdSeccion == 36))
            {
                bool valido;

                List<string> isinsNotInBloomb = new List<string>();
                //Reports_DA.ValidarIsinsInstrumBloomberg(plantilla, fecha, ref isinsNotInBloomb, VariablesGlobales.Pro11_Local);
                Reports_DA.ValidarIsinsInstrumBloomberg(plantilla, ref isinsNotInBloomb);

                if (isinsNotInBloomb.Any())
                {
                    //Añadimos este elemento para que cuando exportemos a excel todos los isins podamos
                    //distinguir entre los que son instrumentos y los que son Bloomberg
                    listaIsinsFaltan.Add("");
                    listaIsinsFaltan.Add("Bloomberg");
                }
                listaIsinsFaltan.AddRange(isinsNotInBloomb);

                if (isinsNotInBloomb.Any())
                {
                    string correccion = Resource.NoBloomImp_Men;
                    var isins = string.Join(", ", isinsNotInBloomb);
                    tareasPendientes.Add(new Tuple<string, string>(isins, correccion));
                }

                if (!isinsNotInBloomb.Any() && !isinsNotInBloomb.Any())
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }

                return valido;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que los isins que pasamos se encuentren en Instrumentos Importados
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="listaIsins"></param>
        /// <param name="tareasPendientes"></param>
        /// <param name="listaIsinsFaltan"></param>
        /// <returns></returns>
        private static bool ValidarIsinsEnInstrumentos(Plantilla plantilla, List<string> listaIsins, ref List<Tuple<string, string>> tareasPendientes, ref List<string> listaIsinsFaltan)
        {
            //if (listaIsinsFaltan == null) throw new ArgumentNullException(nameof(listaIsinsFaltan));
            bool valido = false;

            var noImportados = InstrumentosImportados_DA.GetInstrumentosNoImportados(plantilla, listaIsins);
            listaIsinsFaltan = noImportados;

            if (noImportados.Any())
            {
                string correccion = Resource.NoInstrImp_Mens;
                var isins = string.Join(", ", noImportados);
                tareasPendientes.Add(new Tuple<string, string>(isins, correccion));
            }
            else
            {
                valido = true;
            }

            return valido;
        }

        public static void ShowReportOrLastGenerated(Plantilla plantilla, DateTime? fechaInforme, bool verUltimoGenerado)
        {
            try
            {
                var lastGeneration = Reports_DA.GetLastGeneration(plantilla.CodigoIc);
                DateTime fechaGeneracion = verUltimoGenerado ? lastGeneration.FechaGeneracion : DateTime.Now;
                bool tienePreviews = Utils.TienePreviews(plantilla);
                if (verUltimoGenerado)
                {
                    fechaInforme = lastGeneration.FechaInforme;
                }
                if (verUltimoGenerado)
                {
                    MostrarInforme(tienePreviews, plantilla, Convert.ToDateTime(fechaInforme), fechaGeneracion);
                }
                else
                {
                    //Comprobamos que se cumplen los requisitos de las secciones que formarán parte del informe
                    List<Tuple<string, string>> tareasPendientes = null;
                    List<string> isinsFaltan = null;
                    if (ValidacionesPrevias(plantilla, fechaInforme, ref tareasPendientes, ref isinsFaltan))
                    {
                        try
                        {
                            //Primero copiamos los datos de las secciones en nuestras tablas temporales
                            //hasError = Report_VM.CopyPlantillaToTemp(plantilla, Convert.ToDateTime(fechaInforme));
                            CopyPlantillaToTemp(plantilla, Convert.ToDateTime(fechaInforme), false, false, false, false);
                        }
                        catch (Exception ex)
                        {
                            _hasError = true;
                            //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                            //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                            Log.Error("Error Report_VM/ShowReportOrLastGenerated", ex);
                            // Compliance                                           
                            throw;
                        }

                        //Guardamos la fecha de generación
                        if (_hasError == false)
                        {
                            Reports_DA.GuardarDatosGeneracion(plantilla, fechaInforme);
                            MostrarInforme(tienePreviews, plantilla, Convert.ToDateTime(fechaInforme), fechaGeneracion);
                        }
                    }
                    else
                    {
                        if (tareasPendientes.Count > 0)
                        {
                            string mensaje = Resource.ReviseValidaciones_Mens;
                            mensaje += Environment.NewLine;
                            mensaje += Environment.NewLine;
                            foreach (var tarea in tareasPendientes)
                            {
                                //mensaje += Resource.Campo_SubMens + tarea.Item1 +
                                mensaje += tarea.Item2 +
                                    Environment.NewLine +
                                    "   " + tarea.Item1 +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            //RadWindow.Alert(new DialogParameters { Content = mensaje, Header = Resource.HeaderGVC_MessageBox });

                            ShowErrorWindow(Resource.HeaderGVC_MessageBox, mensaje, isinsFaltan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _hasError = true;
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Report_VM/ShowReportOrLastGenerated", ex);
                // Compliance                                           
                throw;
            }
        }

        private static void MostrarInforme(bool tienePreviews, Plantilla plantilla, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            //CheckDescuadres(plantilla, fechaInforme, true);

            MainWindow main = (MainWindow)Application.Current.MainWindow;
            if (main != null)
            {
                if (tienePreviews)
                {
                    main.LoadContent(new PreviewWizard(plantilla, Convert.ToDateTime(fechaInforme),
                        Convert.ToDateTime(fechaGeneracion)));
                }
                else
                {
                    main.LoadContent(new VisorInformes(plantilla, fechaInforme, fechaGeneracion));
                }
            }
        }

        /// <summary>
        /// Realizamos las comprobaciones definidas para ver si hay descuadres entre secciones o cualquier otra validación de control.
        /// Si no pasa alguna validación mostramos el mensaje para que el usuario pueda investigar qué está sucediendo.</summary>
        /// <param name="plantilla"></param>
        /// <param name="fecha"></param>
        /// <param name="checkAntesPreview">La alerta de "CheckDescuadres" la mostramos antes de mostrar las Previews y justo antes de mostrar el informe. Con este parámetro indicamos si es la de antes de mostrar las previews. Esto lo hacemos porque no queremos mostrar la alerta de validarAmpliacionesCapital dos veces</param>
        public static void CheckDescuadres(Plantilla plantilla, DateTime fecha, bool checkAntesPreview)
        {
            try
            {

                string[] mens = {string.Empty};
                string mensTmp = string.Empty;

                int millisecondsTimeout = 150;
                int i = 1;

                var seccAlertas = plantilla.Plantillas_Secciones.Where(w => w.Seccione.TieneAlertas);
                string textoProgressDialog = "Comprobando alertas";

                MainWindow main = (MainWindow)Application.Current.MainWindow;
                Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, textoProgressDialog, () =>
                {
                    var plantillasSeccioneses = seccAlertas as Plantillas_Secciones[] ?? seccAlertas.ToArray();
                    foreach (var secc in plantillasSeccioneses)
                    {
                        int percent = Convert.ToInt32(((double)i / plantillasSeccioneses.Count()) * 100);
                        Pages.Informes.ProgressDialog.ProgressDialog.Current.Report(percent, "Sección {0}... ({1} de {2})", secc.Seccione.Descripcion, i, plantillasSeccioneses.Count());
                    switch (secc.IdSeccion)
                        {
                            case 5:
                                mensTmp = VariacionPatrimonialA_VM.Validar(plantilla.CodigoIc, secc.Seccione, fecha);
                                break;
                            case 6:
                                mensTmp = DesgloseGastos_VM.Validar(plantilla.CodigoIc);
                                break;
                            case 13:
                                mensTmp = RentaVariable_VM.Validar(plantilla, fecha, checkAntesPreview);
                                break;
                            case 16:
                                mensTmp = DividendosCobrados_VM.Validar(plantilla, fecha);
                                break;
                            case 17:
                                mensTmp = PlusvaliasDividendos_VM.Validar(plantilla);
                                break;
                            case 46:
                                mensTmp = VariacionPatrimonialB_VM.Validar(plantilla.CodigoIc, secc.Seccione, fecha);
                                break;
                        }

                        i++;
                        Thread.Sleep(millisecondsTimeout);

                    //El formato para el espaciado entre líneas es distinto para la primera fila
                    bool isFirst = plantilla.Plantillas_Secciones.FirstOrDefault(w => w.Seccione.TieneAlertas) == secc;

                        AddTituloSeccion(ref mensTmp, secc.Seccione, isFirst);
                        mens[0] += mensTmp;
                        if (!string.IsNullOrEmpty(mensTmp))
                            mens[0] += Environment.NewLine;
                    }
                }, new Pages.Informes.ProgressDialog.ProgressDialogSettings(true, false, false), plantilla.CodigoIc, fecha);


                if (result.OperationFailed)
                {
                    _hasError = true;

                    mens[0] = "Se ha producido un error comprobando las alertas";
                    if (!string.IsNullOrEmpty(result.Error.Message))
                    {
                        mens[0] = result.Error.Message;
                    }

                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error Report_VM/CheckDescuadres", result.Error);
                    // Compliance                                           
                    throw result.Error;
                }
                else if (!string.IsNullOrEmpty(mens[0]))
                {
                    Utils.ShowDialog(mens[0]);
                }
            }
            catch(Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Report_VM/CheckDescuadres", ex);
                // Compliance                                           
                throw;
            }
        }

        private static void AddTituloSeccion(ref string mens, Seccione secc, bool isFirst)
        {
            //Añadimos el título de la sección al principio del mensaje. 
            //Lo añadimos en este momento porque podemos tener varias validaciones
            if (!string.IsNullOrEmpty(mens))
            {
                string mensTmp = string.Empty;
                //Si hay alertas para varias secciones hacemos una separación entre los mensajes de las distintas secciones
                if(!isFirst)
                {
                    //mensTmp += Environment.NewLine;
                    //mensTmp += Environment.NewLine;
                }

                mensTmp += secc.Descripcion 
                    + mens;

                mens = mensTmp;
            }
        }

        public static void ChoosePlantilla(out Plantilla plantilla, out DateTime? fecha, bool verUltimoGenerado)
        {
            plantilla = null;
            fecha = null;

            #region showWindow

            //Cuando mostramos el último informe generado no pasamos fecha
            var window = new ChooseReport(!verUltimoGenerado);

            {
                if (!Equals(Application.Current.MainWindow, window))
                {
                    window.Owner = Application.Current.MainWindow;
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    var ownerMetroWindow = (window.Owner as MetroWindow);
                    if (ownerMetroWindow != null)
                    {
                        ownerMetroWindow.Height = window.Height;
                        ownerMetroWindow.Width = window.Width;
                        ownerMetroWindow.MinHeight = window.MinHeight;
                        ownerMetroWindow.MinWidth = window.MinWidth;

                        if (!ownerMetroWindow.IsOverlayVisible())
                            ownerMetroWindow.ShowOverlayAsync();
                    }
                }

                window.ShowDialog();

                window.Owner = Application.Current.MainWindow;
                var ownerMetroWindow2 = (window.Owner as MetroWindow);

                if (ownerMetroWindow2 != null && ownerMetroWindow2.IsOverlayVisible())
                    ownerMetroWindow2.HideOverlayAsync();

                if (!window.Aceptar)
                {
                    #region Retrieve Values from window

                    plantilla = window.Plantilla;
                    if (verUltimoGenerado)
                    {
                        fecha = null;
                    }
                    else
                    {
                        fecha = window.Fecha;
                    }
                    #endregion

                    if (plantilla.Plantillas_Isins != null && plantilla.Plantillas_Isins.Any())
                    {
                        //Mostramos la ventana para que seleccione Isin
                    }
                    else
                    {
                        VariablesGlobales.IsinPlantillaSel = null;
                    }

                }
            }

            #endregion
        }

        public static void ShowErrorWindow(string headerMessage, string errorDescription, List<string> listaIsins = null)
        {
            #region showWindow

            var window = new ShowError(headerMessage, errorDescription, listaIsins);
            if (!Equals(Application.Current.MainWindow, window))
            {
                window.Owner = Application.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                var ownerMetroWindow = (window.Owner as MetroWindow);
                if (ownerMetroWindow != null)
                {
                    ownerMetroWindow.Height = window.Height;
                    ownerMetroWindow.Width = window.Width;
                    ownerMetroWindow.MinHeight = window.MinHeight;
                    ownerMetroWindow.MinWidth = window.MinWidth;

                    if (!ownerMetroWindow.IsOverlayVisible())
                        ownerMetroWindow.ShowOverlayAsync();
                }
            }

            window.ShowDialog();

            window.Owner = Application.Current.MainWindow;
            var ownerMetroWindow2 = (window.Owner as MetroWindow);

            if (ownerMetroWindow2 != null && ownerMetroWindow2.IsOverlayVisible())
                ownerMetroWindow2.HideOverlayAsync();

            #endregion
        }


        public enum TablaTemporal
        {
            Temp_CarteraCcrVolgaGamar,
            Temp_CarteraRF,
            Temp_CompraVentaPrecAdq,
            Temp_CuponesCobrados,
            Temp_DistribucionPatrimonioNovarex_Cartera,
            Temp_Diversificacion,
            Temp_DividendosCobrados,
            Temp_EvolucionIndBench,
            Temp_EvolucionPatrValLiq,
            Temp_EvolucionMercados,
            Temp_EvolucionPatrGuissona,
            Temp_EvolucionPatrimonioConjuntoGuissona,
            Temp_EvolucionRentabilidadGuissona,
            Temp_GraficoBurbujas,
            Temp_GraficoExposMercDivisas,
            Temp_GraficoCompPatrimonioDivisas,
            Temp_GraficoCompCarteraRV,
            Temp_GraficosExposMercTipodeProducto,
            Temp_GraficoCompPatrimonioTipoProducto,
            Temp_GraficoCompCarteraRF,
            Temp_GraficoExposMercTipoActivo,
            Temp_GraficoCompPatrimonioTipoActivo,
            Temp_GraficoIBenchmark,
            Temp_IIC_ComprasVentasEjercicio,
            Temp_IndicePreconfiguradoNovarex,
            Temp_OperacionesRentaVariable_II,
            Temp_Participes,
            Temp_ParticipesSalat,
            Temp_PlusvaliasDividendos,
            Temp_PRO_11,
            Temp_RatiosCarteraRV,
            Temp_RentabilidadCarteraV1,
            Temp_RentabilidadCarteraV2,
            Temp_ListadoRentaFijaNovarex,
            Temp_RentabilidadCarteraSolemeg,
            Temp_RentaFija,
            Temp_RentaVariable,
            Temp_RFComprasVentasEjercicio,
            Temp_RvComprasRealizadasEjercicio,
            Temp_SuscripcionesReembolsos,
            Temp_VariacionPatrimonialA,
            Temp_VariacionPatrimonialB,
            Temp_DesgloseGastos
        };

        public static bool TempHasValues(string codigoIC, string isin, DateTime fecha, TablaTemporal tablaTemp)
        {
            bool hasValues = false;

            switch (tablaTemp)
            {
                case TablaTemporal.Temp_CarteraCcrVolgaGamar:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_CarteraCcrVolgaGamar)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_CarteraRF:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_CarteraRF)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_Diversificacion:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_Diversificacion)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_DividendosCobrados:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_DividendosCobrados)) > 0)
                    {
                        hasValues = true;
                    }
                    break;

                case TablaTemporal.Temp_PlusvaliasDividendos:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_PlusvaliasDividendos)) > 0)
                    {
                        hasValues = true;
                    }
                    break;

                case TablaTemporal.Temp_VariacionPatrimonialA:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_VariacionPatrimonialA)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_VariacionPatrimonialB:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_VariacionPatrimonialB)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_DesgloseGastos:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_DesgloseGastos)) > 0)
                    {
                        hasValues = true;
                    }
                    break;

                case TablaTemporal.Temp_IndicePreconfiguradoNovarex:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_IndicePreconfiguradoNovarex)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionMercados:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_EvolucionMercados)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RentaFija:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_RentaFija)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RentaVariable:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_RentaVariable)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionPatrGuissona:
                    if (Reports_DA.GetTemp_EvolucionPatrGuissona_Count(codigoIC) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoBurbujas:
                    if (Reports_DA.GetTemp_GraficoBurbujas_Count(codigoIC) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_CompraVentaPrecAdq:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_CompraVentaPrecAdq)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_CuponesCobrados:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_CuponesCobrados)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionPatrValLiq:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_EvolucionPatrValLiq)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoExposMercDivisas:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoExposMercDivisas)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoCompPatrimonioDivisas:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoCompPatrimonioDivisas)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoCompCarteraRV:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoCompCarteraRV)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_ListadoRentaFijaNovarex:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_ListadoRentaFijaNovarex)) > 0)
                    {
                        hasValues = true;
                    }
                    break;

                case TablaTemporal.Temp_RentabilidadCarteraSolemeg:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_RentabilidadCarteraSolemeg)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoCompCarteraRF:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoCompCarteraRF)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoExposMercTipoActivo:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoExposMercTipoActivo)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoCompPatrimonioTipoActivo:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoCompPatrimonioTipoActivo)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoIBenchmark:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_GraficoIBenchmark)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_PRO_11:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_PRO_11)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RatiosCarteraRV:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_RatiosCarteraRV)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_OperacionesRentaVariable_II:
                    if (Reports_DA.GetTemp_Count(codigoIC, null, typeof(Temp_OperacionesRentaVariable_II)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_IIC_ComprasVentasEjercicio:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_IIC_ComprasVentasEjercicio)) > 0)
                    {
                        hasValues = true;
                    }
                    break;

                case TablaTemporal.Temp_RentabilidadCarteraV1:
                    if (Reports_DA.GetTemp_Count(codigoIC, isin, typeof(Temp_RentabilidadCarteraV1)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RentabilidadCarteraV2:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_RentabilidadCarteraV2)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionIndBench:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_EvolucionIndBench)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficosExposMercTipodeProducto:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_GraficoExposMercTipoProducto)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_GraficoCompPatrimonioTipoProducto:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_GraficoCompPatrimonioTipoProducto)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_Participes:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_Participes)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_ParticipesSalat:
                    if (new ParticipesSalat_MNG().Get() != null)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RFComprasVentasEjercicio:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_RFComprasVentasEjercicio)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_RvComprasRealizadasEjercicio:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_RVComprasRealizadasEjercicio)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionRentabilidadGuissona:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_EvolucionRentabilidadGuissona)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_EvolucionPatrimonioConjuntoGuissona:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_EvolucionPatrimonioConjuntoGuissona)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_SuscripcionesReembolsos:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_SuscripcionesReembolsos)) > 0)
                    {
                        hasValues = true;
                    }
                    break;
                case TablaTemporal.Temp_DistribucionPatrimonioNovarex_Cartera:
                    if (Reports_DA.GetTemp_Count(codigoIC, typeof(Temp_DistribucionPatrimonioNovarex_Cartera)) > 0)
                    {
                        hasValues = true;
                    }
                    break;


            }

            return hasValues;
        }       
        public static Report GetReportPortada(Plantilla plantilla, DateTime fecha)
        {
            Report rep = new Report();            

            if(!string.IsNullOrEmpty(plantilla.CodigoIc))
            {
                //Las plantillas de CCR, VOLGA y GAMAR tienen una portada diferente
                if (Utils.EsCCR_Volga_Gamar(plantilla.CodigoIc))
                {
                    rep = new Report_Portada2(plantilla.Descripcion, fecha);
                }
                else
                {
                    rep = new Report_Portada(plantilla, fecha);
                }
            }            
            
            return rep;
        }
    }
}
