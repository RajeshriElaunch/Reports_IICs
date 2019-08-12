using Reports_IICs.DataModels;
using Reports_IICs.Pages.Previews.Cartera;
using Reports_IICs.Reports;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Linq;
using Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV;
using System.Threading;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados;
using Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV1;
using Reports_IICs.Pages.Previews.RENTABILIDAD_CARTERA.RENTABILIDAD_CARTERAV2;
using Reports_IICs.Pages.Previews.Participes;
using Reports_IICs.Pages.Previews.COMPRA_VENTA;
using Reports_IICs.Helpers;
using Reports_IICs.Pages.Previews.RVCOMPRAS_REALIZADAS_DURANTE_EL_EJERCICIO;
using Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO;
using Reports_IICs.Pages.Previews.Evolución.Evolución_Rentabilidad_Guissona;
using Reports_IICs.Pages.Previews.Evolución.Evolución_Patrimonio_Guissona;
using Reports_IICs.Pages.Previews.Dividendos_Cobrados;
using Reports_IICs.Pages.Previews.Cupones_Cobrados;
using Reports_IICs.Pages.Previews.SUSCRIPCIONES_REEMBOLSOS;
using Reports_IICs.Pages.Previews.OPERACIONES_RENTA_VARIABLE__II_;
using Reports_IICs.Pages.Previews.IIC_ComprasVentasEjercicio;
using Reports_IICs.Pages.Previews.Plusvalias_y_Dividendos;
using Reports_IICs.Pages.Previews.Distribucion_Patrimonio_Novarex;
using Reports_IICs.Pages.Previews.Variacion_Patrimonial_B;
using Reports_IICs.Pages.Previews.ParticipesSalat;
using Reports_IICs.Pages.Previews.Indice_Preconfigurado_NOVAREX;
using Reports_IICs.Pages.Previews.ListadoRentaFijaNovarex;
using Reports_IICs.Pages.Previews.CARTERA_RF;
using Reports_IICs.Pages.Previews.Gráficos_Burbujas;
using Reports_IICs.Pages.Previews.RentabilidadCarteraSolemeg;
using Reports_IICs.Pages.Previews.RentaVariable;
using Reports_IICs.Pages.Previews.RentaFija;
using Reports_IICs.ViewModels.Reports;

namespace Reports_IICs.Pages.Previews
{
    /// <summary>
    /// Interaction logic for PreviewWizard.xaml
    /// </summary>
    public partial class PreviewWizard : UserControl
    {
        //private ObservableItemCollection<WizardPage> collection;
        private Plantilla _plantilla;
        private DateTime _fechaInforme;
        private DateTime _fechaGeneracion;

        private RadWizard m_RadWizard;

        MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        //ADD Element RadWizard
        private void AddWizardPage(WizardPage item)
        {
            // Add Item
            m_RadWizard.WizardPages.Add(item);
        }

        public delegate void AddWizardPageCallback(WizardPage item);

        public PreviewWizard(Plantilla plantilla, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            _plantilla = plantilla;
            _fechaInforme = fechaInforme;
            _fechaGeneracion = fechaGeneracion;
            InitializeComponent();

            this.myWizard.Next += myWizard_Next;
            this.myWizard.Previous += myWizard_Previous;
            this.myWizard.Cancel += myWizard_Cancel;
            this.myWizard.Finish += myWizard_Finish;

            //collection = new ObservableItemCollection<WizardPage>();
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            List<WizardPage> ListPreviews = new List<WizardPage>();
            int millisecondsTimeout = 500;
            int i = 1;
            Pages.Informes.ProgressDialog.ProgressDialogResult result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Procesando Previews", () =>
             {

                 #region Process Previews
                 //Mostramos las previews de las secciones que tengan

                 // var secciones = Secciones_DA.GetSeccionesByFecha(plantilla.CodigoIc, fechaGeneracion);
                 var secciones = plantilla.Plantillas_Secciones;
                 
                 foreach (var seccion in secciones.Where(s => s.Seccione.TienePreview).OrderBy(o => o.Orden))
                 {
                     int percent = Convert.ToInt32(((double)i / secciones.Where(s => s.Seccione.TienePreview).OrderBy(o => o.Orden).ToList().Count) * 100);
                     Pages.Informes.ProgressDialog.ProgressDialog.Current.Report(percent, "Preview {0}... ({1} de {2})", seccion.Seccione.Descripcion, i, plantilla.Plantillas_Secciones.Where(s => s.Seccione.TienePreview).OrderBy(o => o.Orden).ToList().Count);

                     WizardPage wPage = null;
                     switch (seccion.IdSeccion)
                     {
                         case 1://Participes
                             //foreach (var isin in Participes_DA.GetTempIsins(plantilla.CodigoIc))
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageParticipes_Preview(wPage, plantilla, isin.Isin, fechaInforme)));
                             }
                             break;
                         case 6://VARIACIÓN PATRIMONIAL B
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageVariacionPatrimonialB_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             break;
                         case 7://RentabilidadCarteraV1
                                //foreach (var isin in RentabilidadCarteraV1_DA.GetTempIsins(plantilla.CodigoIc))
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRentabilidadCarteraV1_Preview(wPage, plantilla, isin.Isin, fechaInforme, fechaGeneracion)));
                             }
                             break;
                         case 8://RentabilidadCarteraV2
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRentabilidadCarteraV2_Preview(wPage, plantilla, null, fechaInforme)));
                             break;
                         case 9://EVOLUCIÓN DE LOS MERCADOS
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageEvolucionMercado_Preview(wPage, plantilla, fechaInforme)));
                             //ListPreviews.Add(wPage);
                             break;
                             
                         case 10://Indice Preconfigurado Novarex
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageIndicePreconfiguradoNovarex_Preview(wPage, plantilla, fechaInforme)));
                             //ListPreviews.Add(wPage);
                             break;

                         case 11://SUSCRIPCIONES-REEMBOLSOS
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageSuscripcionesReembolsos_Preview(wPage, plantilla, isin.Isin, fechaInforme, fechaGeneracion)));
                             }
                             break;
                        
                         case 12://DISTRIBUCIÓN PATRIMONIO NOVAREX
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageDistribucionPatrimonioNovarex_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             break;
                         case 13://Renta Variable
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRentaVariable_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             }
                             break;
                         case 14://CompraVentaRespectoPrecioAdquisicion
                             //Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageCompraVentaRespectoPrecioAdquisicion_Preview(wPage, plantilla, null, fechaInforme)));
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => Page_GeneralPreview(wPage, plantilla, fechaInforme, seccion.IdSeccion)));
                             break;
                         case 16://Dividendos cobrados
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageDividendosCobrados_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             break;
                         case 17://PLUSVALÍAS Y DIVIDENDOS
                                 
                             //foreach (var isin in isins)
                             //{
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PagePlusvaliasDividendos_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             //}
                             break;
                         case 18://CompraVentaRespectoPrecioAdquisicion
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRV_ComprarRealizadasDuranteEjercicio_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             break;
                         case 19://IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                             //foreach (var isin in listaIsins)
                             //{
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageIIC_ComprasVentasEjercicio_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             //}
                             break;
                         case 20://RF: COMPRAS Y VENTAS EJERCICIO
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRF_ComprasVentasRealizadasDuranteEjercicio_Preview(wPage, plantilla, isin.Isin , fechaInforme, fechaGeneracion)));
                             }
                             break;
                         case 21://Renta Fija
                             //Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRentaFija_Preview(wPage, plantilla, fechaInforme, fechaGeneracion)));                             
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => Page_GeneralPreview(wPage, plantilla, fechaInforme, seccion.IdSeccion)));
                             break;
                         case 22://Listado Renta Fija Novarex
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageListadoRentaFijaNovarex_Preview(wPage, plantilla, fechaInforme)));
                            
                             break;
                         case 23://Cupones cobrados
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageCuponesCobrados_Preview(wPage, plantilla, null, fechaInforme, fechaGeneracion)));
                             break;
                         case 24://CARTERA RF
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageCARTERA_RF_Preview(wPage, plantilla, null, fechaInforme)));
                             break;
                         case 25://RF: COMPRAS Y VENTAS EJERCICIO
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRF_ComprasVentasRealizadasDuranteEjercicio_Preview(wPage, plantilla, isin.Isin, fechaInforme, fechaGeneracion)));
                             }
                             break;
                         case 26://CARTERA
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageCartera_Preview(wPage, plantilla, fechaInforme)));
                             //ListPreviews.Add(wPage);
                             // PageCartera_Preview(wPage, plantilla, fecha);
                             break;
                         case 27://Evolución Rentabilidad Guissona
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageEvolucionRentabilidadGuissona_Preview(wPage, plantilla, null, fechaInforme)));
                             break;
                         
                         case 28://EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageEvolucionPatrimonioGuissona_Preview(wPage, plantilla, null, fechaInforme)));
                             break;
                         case 35://OPERACIONES RENTA VARIABLE (II)
                             foreach (var isin in plantilla.Plantillas_Isins)
                             {
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageOperacionesRentaVariable_Preview(wPage, plantilla, isin.Isin, fechaInforme, fechaGeneracion)));
                             }
                             break;
                         case 36://RATIOS CARTERA RV (¿SECTORIALS?)
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRatiosCarteraRV_Preview(wPage, plantilla, fechaInforme)));
                             //ListPreviews.Add(wPage);
                             break;
                         case 37://CARTERA RV CCR-VOLGA-GAMAR
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => Page_GeneralPreview(wPage, plantilla, fechaInforme, seccion.IdSeccion)));
                             break;
                         case 38://GRÁFICO BURBUJAS SMALL BIG
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageBurbujas_SmallBig_Preview(wPage, plantilla, fechaInforme)));
                             //ListPreviews.Add(wPage);
                             break;
                         case 39://RENTABILIDAD CARTERA DESDE ORIGEN SOLEMEG
                             Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageRentabilidadCarteraSolemeg_Preview(wPage, plantilla, fechaInforme)));
                             
                             break;
                         case 41://Participes Salat
                            
                             //foreach (var isin in listaIsins)
                             //{
                                 Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => PageParticipesSalat_Preview(wPage, plantilla, null, fechaInforme)));
                             //}
                             break;
                     }
                     i++;
                     Thread.Sleep(millisecondsTimeout);
                 }

               
                    #endregion

                    
            }, new Pages.Informes.ProgressDialog.ProgressDialogSettings(true, false, false), plantilla.CodigoIc, fechaInforme);

            if (myWizard.WizardPages.Count < 1)
            {
                generarInforme();
                //myWizard_Finish(null, null);
            }
            //#region send pages to UI
            //foreach (WizardPage item in ListPreviews)
            //{
            //    this.myWizard.WizardPages.Add(item);
            //}
            //#endregion
        }

        void PageListadoRentaFijaNovarex_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new ListadoRentaFijaNovarex_Preview(plantilla, null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);
        }
        void PageParticipes_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {
            wPage = new Participes_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageParticipesSalat_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {
            wPage = new ParticipesSalat_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageRF_Grafico_BemchMark_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RF_ComprasyVentasRealizadasDuranteEjercicio_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageRF_ComprasVentasRealizadasDuranteEjercicio_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RF_ComprasyVentasRealizadasDuranteEjercicio_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageRV_ComprarRealizadasDuranteEjercicio_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RV_ComprarRealizadasDuranteEjercicio_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        
        void PageSuscripcionesReembolsos_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new SuscripcionesReembolsos_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageVariacionPatrimonialB_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new VariacionPatrimonialB_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageDividendosCobrados_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new DividendosCobrados_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageRentaFija_Preview(WizardPage wPage, Plantilla plantilla, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            //string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RentaFija_Preview(plantilla, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }
        void PageRentaVariable_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RentaVariable_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }


        void PageCuponesCobrados_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new CuponesCobrados_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        
        void PagePlusvaliasDividendos_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new PlusvaliasDividendos_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageRentabilidadCarteraV1_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);
            wPage = new RentabilidadCarteraV1_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageRentabilidadCarteraV2_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {
           
                wPage = new RentabilidadCarteraV2_Preview(plantilla, isin, fecha);
                wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
                wPage.AllowCancel = true;
                wPage.AllowFinish = true;
                this.myWizard.WizardPages.Add(wPage);
           

        }

        void PageEvolucionRentabilidadGuissona_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {

            wPage = new EvolucionRentabilidadGuissona_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
            
        }
        
        void PageEvolucionPatrimonioGuissona_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {

            wPage = new EvolucionPatrimonioGuissona_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);

        }

        void PageCompraVentaRespectoPrecioAdquisicion_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {

            wPage = new CompraVentaRespectoPrecioAdquisicion_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);


        }

        void PageCARTERA_RF_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fecha)
        {

            wPage = new CARTERA_RF_Preview(plantilla, isin, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);


        }

        void PageIndicePreconfiguradoNovarex_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new IndicePreconfiguradoNovarex_Preview(plantilla, null,null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }
        
        void PageEvolucionMercado_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new EvolucionMercado_Preview(plantilla, null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);
        }
        
        void PageOperacionesRentaVariable_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);

            wPage = new OperacionesRentaVariable_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }
        
        void PageIIC_ComprasVentasEjercicio_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);

            wPage = new IIC_ComprasVentasEjercicio_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageDistribucionPatrimonioNovarex_Preview(WizardPage wPage, Plantilla plantilla, string isin, DateTime fechaInforme, DateTime fechaGeneracion)
        {
            string isinDesc = Utils.GetIsinDescripcion(plantilla, isin, fechaGeneracion);

            wPage = new DistribucionPatrimonioNovarex_Preview(plantilla, isin, isinDesc, fechaInforme);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }

       
        void PageCartera_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new CarteraWizard(plantilla, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);

        }
        void PageRatiosCarteraRV_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new RatiosCarteraRV_Preview(plantilla, null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageBurbujas_SmallBig_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new Burbujas_SmallBig_Preview(plantilla, null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void PageRentabilidadCarteraSolemeg_Preview(WizardPage wPage, Plantilla plantilla, DateTime fecha)
        {
            wPage = new RentabilidadCarteraSolemeg_Preview(plantilla, null,null, fecha);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            this.myWizard.WizardPages.Add(wPage);
        }

        void Page_GeneralPreview(WizardPage wPage, Plantilla plantilla, DateTime fechaInforme, int idSeccion)
        {
            wPage = new PreviewGeneral(plantilla, fechaInforme, idSeccion);
            wPage.ButtonsVisibilityMode = Telerik.Windows.Controls.Wizard.WizardPageButtonsDisplayMode.All;
            wPage.AllowCancel = true;
            wPage.AllowFinish = true;
            this.myWizard.WizardPages.Add(wPage);
        }


        void myWizard_Previous(object sender, NavigationButtonsEventArgs e)
        {
            updateDatosRelacionados(sender);
            //var wizard = sender as RadWizard;

            //if (wizard.SelectedPage.Content == "My Third Page Content")
            //{
            //    e.SelectedPageIndex = 0;
            //}
        }

        /// <summary>
        /// Tenemos que regenerar las secciones dependientes de RV cuando se hayan modificado datos en su Preview
        /// </summary>
        /// <param name="sender"></param>
        private void updateDatosRelacionados(object sender)
        {
            if (((Telerik.Windows.Controls.RadWizard)sender).SelectedPage.GetType() == typeof(RentaVariable_Preview)
                && ((RentaVariable_Preview)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).HasChanged)
            {
                //Volvemos a generar las secciones dependientes de RV (14, 17, ...)
                ReportVM.CopyPlantillaToTemp(_plantilla, _fechaInforme, true, false, false, false);
                //Una vez que hemos regenerado las secciones dependientes actualizamos el valor de HasChanged porque ya no tenemos cambios pendientes
                ((RentaVariable_Preview)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).HasChanged = false;
            }
            else if (((Telerik.Windows.Controls.RadWizard)sender).SelectedPage.GetType() == typeof(PreviewGeneral)
                && ((PreviewGeneral)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).HasChanged
                )
            {
                if (((PreviewGeneral)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).IdSeccion == 21)
                {
                    //Volvemos a generar las secciones dependientes de RF (de momento sólo es la 5)
                    ReportVM.CopyPlantillaToTemp(_plantilla, _fechaInforme, false, false, true, true);
                    //Una vez que hemos regenerado las secciones dependientes actualizamos el valor de HasChanged porque ya no tenemos cambios pendientes
                    ((PreviewGeneral)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).HasChanged = false;
                }
            }

            //if (((Telerik.Windows.Controls.RadWizard)sender).SelectedPage.GetType() == typeof(RentaVariable_Preview)
            //    //|| ((Telerik.Windows.Controls.RadWizard)sender).SelectedPage.GetType() == typeof(RentaFija_Preview)
            //    )
            //{
            //    //Una vez que hemos regenerado las secciones dependientes actualizamos el valor de HasChanged porque ya no tenemos cambios pendientes
            //    ((RentaVariable_Preview)((Telerik.Windows.Controls.RadWizard)sender).SelectedPage).HasChanged = false;
            //}

        }

        void myWizard_Next(object sender, NavigationButtonsEventArgs e)
        {
            updateDatosRelacionados(sender);

            //var wizard = sender as RadWizard;

            //if (wizard.SelectedPage.Content == "My First Page Content")
            //{
            //    e.SelectedPageIndex = 2;
            //}

            //if(wizard.SelectedPage is Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados.EvolucionMercado_Preview)
            //{

            //    Action StartLoop;
            //    StartLoop = () => DoLongRunningProcess();

            //    Thread t;

            //    t = new Thread(StartLoop.Invoke);
            //    t.Start();
            //}
            //if (wizard.SelectedPage is Reports_IICs.Pages.Previews.Cartera.CarteraWizard)
            //{

            //}

        }

        private void DoLongRunningProcess()
        {
            Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => main.ShowPanelCommand.Execute(null)));
 
        }
        void myWizard_Cancel(object sender, NavigationButtonsEventArgs e)
        {
            updateDatosRelacionados(sender);
            ((MainWindow)System.Windows.Application.Current.MainWindow).CloseContent();
        }

        void myWizard_Finish(object sender, NavigationButtonsEventArgs e)
        {
            updateDatosRelacionados(sender);            
            ReportVM.CheckDescuadres(_plantilla, _fechaInforme, false);

            generarInforme();
        }

        private void generarInforme()
        {
            main.LoadContent(new VisorInformes(_plantilla, _fechaInforme, _fechaGeneracion));
        }

        
    }
}
