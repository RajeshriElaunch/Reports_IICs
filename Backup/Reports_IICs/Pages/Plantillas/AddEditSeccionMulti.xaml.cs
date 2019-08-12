using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.Pages.Plantillas.ControlesParametros;
using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Plantillas;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para AddEditSeccionMulti.xaml
    /// </summary>
    public partial class AddEditSeccionMulti : MetroWindow
    {
        
        public int? SeccionId;
        public bool Cancel = true;
        private List<string> ListaCodigo = new List<string>();
        private List<Seccione> ListaSecciones = new List<Seccione>();
        private Plantilla _plantilla;

        public Parametros_GraficoBenchmark ParamGraficoBenchmark;
        public List<Parametros_GraficoBenchmark_Indices> ParamGraficoBenchmark_Indices = new List<Parametros_GraficoBenchmark_Indices>();

        public Parametros_PlusvaliasDividendos ParamPlusvaliasDividendos;
        public List<Parametros_PlusvaliasDividendos> ParamPlusvaliasDividendosList;

        public Parametros_RFComprasVentasEjercicio ParamRFComprasVentasEjercicio;
        public Parametros_DividendosCobrados ParamDividendosCobrados;
        public Parametros_Rentabilidad_CarteraII ParamRentabilidadCarteraII;
        public Parametros_RVComprasRealizadasEjercicio ParamRVComprasRealizadasEjercicio;
        public Parametros_IIC_ComprasVentasEjercicio ParamIIC_ComprasVentasEjercicio;
        public Parametros_EvolucionPatrimGuissona ParamEvolucionPatrimGuissona;
        public Parametros_OperacionesRentaVariable_II ParamOperacionesRentaVariable_II;
        public Parametros_CarteraRF ParamCarteraRF;
        public Parametros_CompraVentaPrecAdq ParamCompraVentaPrecAdq;
        public Parametros_GraficoCompPatrimonioTipoProducto ParamGraficoCompPatrimonioTipoProducto;
        public Parametros_RatiosCarteraRV ParamRatiosCarteraRV;
        public List<Parametros_EvolucionMercados> ParamEvolucionMercados= new List<Parametros_EvolucionMercados>();
        public List<Parametros_DistribucionPatrimonioNovarex> ParamDistribPatriNovarex = new List<Parametros_DistribucionPatrimonioNovarex>();

        public Parametros_EvolucionRentabilidadGuissona ParamEvoRentabiGuissona;
        public List<Parametros_EvolucionRentabilidadGuissona_Fondos> ParamEvoRentabiGuissona_Fondos = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();

        public Parametros_EvolucionPatrimonioConjuntoGuissona ParamEvoPatriConjGuissona;
        public List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> ParamEvoPatriConjGuissona_Fondos = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();

        public Parametros_VariacionPatrimonialB ParamVariaPatrimonialB;

        public List<Parametros_IndicePreconfiguradoNovarex> ParamIndicePreconfiguradoNovarex = new List<Parametros_IndicePreconfiguradoNovarex>();
        public Parametros_IndicePreconfiguradoNovarex_Otros ParamIndicePreconfiguradoNovarexOtros;

        private PlantillasPage_VM DataSource = new PlantillasPage_VM();
        public DataViewModelComboBoxSeccion Dataitems = new DataViewModelComboBoxSeccion();


        //public AddEditSeccionMulti(List<string> listacodigo, int? seccionId, ref Plantilla plantilla , Parametros_GraficoBenchmark paramGraficoBenchmark, Parametros_RatiosCarteraRV ParamRatiosCarteraRV,List<Parametros_EvolucionMercados> paramEvolucionMercados)
        public AddEditSeccionMulti(List<string> listacodigo, int? seccionId, ref Plantilla plantilla, Parametros_GraficoBenchmark paramGraficoBenchmark)
        {
            _plantilla = plantilla;
            ParamEvolucionPatrimGuissona = plantilla.Parametros_EvolucionPatrimGuissona.FirstOrDefault();
            ParamPlusvaliasDividendosList = plantilla.Parametros_PlusvaliasDividendos.ToList();
            ParamRFComprasVentasEjercicio = plantilla.Parametros_RFComprasVentasEjercicio.FirstOrDefault();
            ParamCarteraRF = plantilla.Parametros_CarteraRF.FirstOrDefault();
            ParamCompraVentaPrecAdq = plantilla.Parametros_CompraVentaPrecAdq.FirstOrDefault();
            ParamDividendosCobrados = plantilla.Parametros_DividendosCobrados.FirstOrDefault();
            ParamRentabilidadCarteraII = plantilla.Parametros_Rentabilidad_CarteraII.FirstOrDefault();
            ParamRVComprasRealizadasEjercicio = plantilla.Parametros_RVComprasRealizadasEjercicio.FirstOrDefault();
            ParamIIC_ComprasVentasEjercicio = plantilla.Parametros_IIC_ComprasVentasEjercicio.FirstOrDefault();
            ParamIndicePreconfiguradoNovarex = plantilla.Parametros_IndicePreconfiguradoNovarex.ToList();
            ParamIndicePreconfiguradoNovarexOtros = plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();
            ParamGraficoBenchmark = plantilla.Parametros_GraficoBenchmark.FirstOrDefault();
            ParamGraficoBenchmark_Indices = plantilla.Parametros_GraficoBenchmark_Indices.ToList();
            ParamEvoRentabiGuissona = plantilla.Parametros_EvolucionRentabilidadGuissona.FirstOrDefault();
            ParamEvoRentabiGuissona_Fondos = plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.ToList();
            ParamEvoPatriConjGuissona = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.FirstOrDefault();
            ParamEvoPatriConjGuissona_Fondos = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.ToList();
            ParamDistribPatriNovarex = plantilla.Parametros_DistribucionPatrimonioNovarex.ToList();
            ParamEvolucionMercados = plantilla.Parametros_EvolucionMercados.ToList();
            ParamRatiosCarteraRV = plantilla.Parametros_RatiosCarteraRV.FirstOrDefault();
            ParamOperacionesRentaVariable_II = plantilla.Parametros_OperacionesRentaVariable_II.FirstOrDefault();
            ParamGraficoCompPatrimonioTipoProducto = plantilla.Parametros_GraficoCompPatrimonioTipoProducto.FirstOrDefault();
            InitializeComponent();
            Loaded += OnLoaded;
            ListaCodigo = listacodigo;
            SeccionId = seccionId;
            //ParamGraficoBenchmark = paramGraficoBenchmark;
            //ParamRatioCarteraRV = paramRatioCarteraRV;

            //foreach (var item in paramEvolucionMercados)
            //{
            //    ParamEvolucionMercados.Add(item);
            //}
           

            System.Windows.Controls.ItemCollection SeccionesFiltradas = ComboBoxSeccion.Items;

            foreach (Seccione item in PlantillasPage_VM.GetSecciones().OrderBy(c => c.Descripcion))
            {
                Dataitems.DataItems.Add(new DataItem()
                {
                    Text = item.Descripcion,
                    Seccion = (Seccione)item
                });

            }

            #region Listacodigo
            foreach (string item in ListaCodigo)
            {
                Reports_IICs.DataModels.Seccione current = PlantillasPage_VM.GetSecciones().Where(c => c.Descripcion == item).FirstOrDefault();
                try
                {
                    int i = 0;
                    foreach (DataItem itemDelete in Dataitems.DataItems)
                    {
                        if (itemDelete.Seccion.Id == current.Id)
                        {
                            Dataitems.DataItems.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                   
                }

                catch (System.Exception)
                {

                }
            }
            #endregion
            ComboBoxSeccion.ItemsSource = Dataitems.DataItems;
        }


        public AddEditSeccionMulti(List<string> listacodigo, int? seccionId, ref Plantilla plantilla)
        {
            _plantilla = plantilla;
            ParamCarteraRF = plantilla.Parametros_CarteraRF.FirstOrDefault();
            ParamCompraVentaPrecAdq = plantilla.Parametros_CompraVentaPrecAdq.FirstOrDefault();
            ParamEvolucionPatrimGuissona = plantilla.Parametros_EvolucionPatrimGuissona.FirstOrDefault();
            ParamEvoRentabiGuissona = plantilla.Parametros_EvolucionRentabilidadGuissona.FirstOrDefault();
            ParamEvoRentabiGuissona_Fondos = plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.ToList();
            ParamEvoPatriConjGuissona = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.FirstOrDefault();
            ParamEvoPatriConjGuissona_Fondos = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.ToList();
            ParamGraficoBenchmark = plantilla.Parametros_GraficoBenchmark.ToList().SingleOrDefault();
            ParamGraficoBenchmark_Indices = plantilla.Parametros_GraficoBenchmark_Indices.ToList();
            ParamPlusvaliasDividendosList = plantilla.Parametros_PlusvaliasDividendos.ToList();
            ParamRatiosCarteraRV = plantilla.Parametros_RatiosCarteraRV.ToList().SingleOrDefault();
            ParamEvolucionMercados = plantilla.Parametros_EvolucionMercados.ToList();
            ParamDistribPatriNovarex = plantilla.Parametros_DistribucionPatrimonioNovarex.ToList();
            //ParamEvoPatriGuissona = paramEvoPatriGuissona;
            ParamVariaPatrimonialB = plantilla.Parametros_VariacionPatrimonialB.FirstOrDefault();
            ParamRFComprasVentasEjercicio = plantilla.Parametros_RFComprasVentasEjercicio.FirstOrDefault();
            ParamDividendosCobrados = plantilla.Parametros_DividendosCobrados.FirstOrDefault();
            ParamRentabilidadCarteraII = plantilla.Parametros_Rentabilidad_CarteraII.FirstOrDefault();
            ParamRVComprasRealizadasEjercicio = plantilla.Parametros_RVComprasRealizadasEjercicio.FirstOrDefault();
            ParamIIC_ComprasVentasEjercicio = plantilla.Parametros_IIC_ComprasVentasEjercicio.FirstOrDefault();
            ParamIndicePreconfiguradoNovarex = plantilla.Parametros_IndicePreconfiguradoNovarex.ToList();
            ParamIndicePreconfiguradoNovarexOtros = plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();
            ParamOperacionesRentaVariable_II = plantilla.Parametros_OperacionesRentaVariable_II.FirstOrDefault();
            ParamGraficoCompPatrimonioTipoProducto = plantilla.Parametros_GraficoCompPatrimonioTipoProducto.FirstOrDefault();
            /*if (plantilla.Parametros_IndicePreconfiguradoNovarex!=null)
            {
                if (plantilla.Parametros_IndicePreconfiguradoNovarex.Count > 0)
                {
                    ParamIndicePreconfiguradoNovarex = plantilla.Parametros_IndicePreconfiguradoNovarex.ToList();
                }
                else
                {
                    foreach (var item in IndicePreconfiguradoNovarex_DA.GetIndicesFijos())
                    {
                        
                        Parametros_IndicePreconfiguradoNovarex temp_param = new Parametros_IndicePreconfiguradoNovarex();
                        temp_param.CodigoIC = plantilla.CodigoIc;
                        temp_param.Descripcion = item.Descripcion;
                        temp_param.Divisa = item.Divisa;
                        temp_param.Formula = item.Formula;
                        temp_param.IdInstrumento = item.IdInstrumento;
                        temp_param.IdInstrumentoZona = item.IdInstrumentoZona;
                        temp_param.IdTipoFormula = item.IdTipoFormula;
                        temp_param.IndiceReferencia = item.IndiceReferencia;
                        temp_param.IdIndicesPreconfiguradosNovarex = item.Id;
                        //temp_param.
                        plantilla.Parametros_IndicePreconfiguradoNovarex.Add(temp_param);
                    }
                    ParamIndicePreconfiguradoNovarex = plantilla.Parametros_IndicePreconfiguradoNovarex.ToList();
                }

                
            }
            */

            InitializeComponent();
           
            ListaCodigo = listacodigo;
            SeccionId = seccionId;

           // ParamGraficoBenchmark = paramGraficoBenchmark;
            //ParamRatioCarteraRV = paramRatioCarteraRV;

            //foreach (var item in paramEvolucionMercados)
            //{
            //    ParamEvolucionMercados.Add(item);
            //}


            System.Windows.Controls.ItemCollection SeccionesFiltradas = ComboBoxSeccion.Items;

            foreach (Seccione item in PlantillasPage_VM.GetSecciones().OrderBy(c => c.Descripcion))
            {
                Dataitems.DataItems.Add(new DataItem()
                {
                    Text = item.Descripcion,
                    Seccion = (Seccione)item
                   
                });

            }

            #region Listacodigo
            foreach (string item in ListaCodigo)
            {
                Reports_IICs.DataModels.Seccione current = PlantillasPage_VM.GetSecciones().Where(c => c.Descripcion == item).FirstOrDefault();
                try
                {
                    int i = 0;
                    foreach (DataItem itemDelete in Dataitems.DataItems)
                    {
                        if (itemDelete.Seccion.Id == current.Id)
                        {
                            Dataitems.DataItems.RemoveAt(i);
                            break;
                        }
                        i++;
                    }

                }

                catch (System.Exception)
                {

                }
            }
            #endregion
            Loaded += OnLoaded;
            ComboBoxSeccion.SelectedValue = SeccionId;
            ComboBoxSeccion.ItemsSource = Dataitems.DataItems;
           // ComboBoxSeccion.SelectedValue = SeccionId;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (SeccionId != null)
            {
                ComboBoxSeccion.SelectedValue = SeccionId;
            }
            Loaded -= OnLoaded;
        }

        private void AddElement_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool HasSectionWithParmam = false;

            if (Dataitems.DataItems.CheckedItems.Count > 0)
            {
                #region has Checked Items
                foreach (DataItem item in (Dataitems.DataItems.CheckedItems))
                {
                    #region Parse Params values
                    //Seccione selectedValue = this.ComboBoxSeccion.SelectedItem != null ? ((DataItem)this.ComboBoxSeccion.SelectedItem).Seccion : null;

                    Seccione selectedValue = item.Seccion;
                    if (selectedValue != null)
                    {
                        switch (selectedValue.Id)
                        {
                            //Estas dos secciones comparten parámetros
                            //Normalmente sale una o la otra
                            case 6:
                            case 46:
                                #region VARIACIÓN PATRIMONIAL B
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_VariacionPatrimonialB)
                                    {
                                        var pVariaPatrimonialB = (Param_VariacionPatrimonialB)param;
                                        if (pVariaPatrimonialB != null) e.CanExecute = pVariaPatrimonialB._noOfErrorsOnScreen == 0;
                                    }
                                }
                                #endregion
                                break;
                            case 8:
                                #region RENTABILIDAD CARTERA (II)
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_Rentabilidad_carteraII)
                                    {
                                        var pRentabilidadCarteraII = (Param_Rentabilidad_carteraII)param;
                                        if (pRentabilidadCarteraII != null) e.CanExecute = pRentabilidadCarteraII._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion
                                break;
                            case 9:
                                #region EVOLUCIÓN MERCADOS
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionMercados)
                                    {
                                        var pEvoMerca = (Param_EvolucionMercados)param;
                                        if (pEvoMerca != null) e.CanExecute = pEvoMerca._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion
                                break;
                            case 10:
                                #region ÍNDICE PRECONFIGURADO (NOVAREX)
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_IndicePreconfiguradoNovarex)
                                    {
                                        var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)param;
                                        if (pIndicePreconfiguradoNovarex != null)
                                        {
                                            e.CanExecute = pIndicePreconfiguradoNovarex._noOfErrorsOnScreen == 0;
                                        }

                                    }
                                }
                                #endregion
                                break;
                            case 12:
                                #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_DistriPatrimNovarex)
                                    {
                                        var pDistriPatrimNovarex = (Param_DistriPatrimNovarex)param;
                                        if (pDistriPatrimNovarex != null) e.CanExecute = pDistriPatrimNovarex._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion
                                break;
                            case 14:
                                #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_CompraVentaPrecAdq)
                                    {
                                        var pCV = (Param_CompraVentaPrecAdq)param;
                                        if (pCV != null) e.CanExecute = pCV._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 16:
                                #region DIVIDENDOS COBRADOS
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_DividendosCobrados)
                                    {
                                        var pRFDividendosCobrados = (Param_DividendosCobrados)param;
                                        if (pRFDividendosCobrados != null) e.CanExecute = pRFDividendosCobrados._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 17:
                                #region PLUSVALÍAS Y DIVIDENDOS
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_PlusvaliasDividendos)
                                    {
                                        var pPlDividendos = (Param_PlusvaliasDividendos)param;
                                        if (pPlDividendos != null) e.CanExecute = pPlDividendos._noOfErrorsOnScreen == 0;
                                    }
                                }



                                #endregion

                                break;
                            case 18:
                                #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RVComprasRealizadasEjercicio)
                                    {
                                        var pRVComprasRealizadasEjercicio = (Param_RVComprasRealizadasEjercicio)param;
                                        if (pRVComprasRealizadasEjercicio != null) e.CanExecute = pRVComprasRealizadasEjercicio._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 19:
                                #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_IIC_ComprasVentasEjercicio)
                                    {
                                        var pIIC_ComprasVentasEjercicio = (Param_IIC_ComprasVentasEjercicio)param;
                                        if (pIIC_ComprasVentasEjercicio != null) e.CanExecute = pIIC_ComprasVentasEjercicio._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 20:
                                #region RF: COMPRAS Y VENTAS EJERCICIO
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RFComprasVentasEjercicio)
                                    {
                                        var pRFComprasVentasEjercicio = (Param_RFComprasVentasEjercicio)param;
                                        if (pRFComprasVentasEjercicio != null) e.CanExecute = pRFComprasVentasEjercicio._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 24:
                                #region CARTERA RF
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_CarteraRF)
                                    {
                                        var pCRF = (Param_CarteraRF)param;
                                        if (pCRF != null) e.CanExecute = pCRF._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion

                                break;
                            case 25://GRÁFICO I (BENCHMARK)
                            case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                                #region GRÁFICO I (BENCHMARK)
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_GraficoBenchMark)
                                    {
                                        var pBenchMark = (Param_GraficoBenchMark)param;
                                        if (pBenchMark != null) e.CanExecute = pBenchMark._noOfErrorsOnScreen == 0;
                                    }
                                }

                                #endregion
                                break;
                            case 27:
                                #region EVOLUCIÓN RENTABILIDAD GUISSONA
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionRentabilidadGuissona)
                                    {
                                        var pEvoRentabGuissona = (Param_EvolucionRentabilidadGuissona)param;
                                        if (pEvoRentabGuissona != null) e.CanExecute = pEvoRentabGuissona._noOfErrorsOnScreen == 0;
                                    }
                                }
                                #endregion
                                break;
                            case 28:
                                #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionPatrimonioConjuntoGuissona)
                                    {
                                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)param;
                                        if (pEvoPatriConjGuissona != null) e.CanExecute = pEvoPatriConjGuissona._noOfErrorsOnScreen == 0;
                                    }
                                }
                                #endregion
                                break;
                            case 29:
                                #region EVOLUCIÓN PATRIMONIO GUISSONA
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionPatrimGuissona)
                                    {
                                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)param;
                                        if (pEvoPatriGuissona != null) e.CanExecute = pEvoPatriGuissona._noOfErrorsOnScreen == 0;
                                    }
                                }
                                #endregion
                                break;
                            case 36:
                                #region RATIOS CARTERA RV (¿SECTORIALS?)
                                HasSectionWithParmam = true;
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RatiosCarteraRV)
                                    {
                                        var pCarteraRV = (Param_RatiosCarteraRV)param;
                                        if (pCarteraRV != null) e.CanExecute = pCarteraRV._noOfErrorsOnScreen == 0;
                                    }
                                }
                                #endregion
                                break;
                            default:
                                if (!HasSectionWithParmam) e.CanExecute = true;
                                break;
                        }
                    }
                    #endregion

                }
                #endregion
            }
            else
            {
                #region Edit Mode check selecteditem

                switch (SeccionId)
                {
                    //Estas dos secciones comparten parámetros
                    //Normalmente sale una o la otra
                    case 6:
                    case 46:                        
                        #region VARIACIÓN PATRIMONIAL B
                        var pVariaPatrimonialB = (Param_VariacionPatrimonialB)this.StackConfigParam.Children[0];
                        e.CanExecute = pVariaPatrimonialB._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 8:
                        #region RENTABILIDAD CARTERA (II)
                        var pRentabilidadCarteraII = (Param_Rentabilidad_carteraII)this.StackConfigParam.Children[0];

                        e.CanExecute = pRentabilidadCarteraII._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 9:
                        #region EVOLUCIÓN MERCADOS
                        var pEvoMerca = (Param_EvolucionMercados)this.StackConfigParam.Children[0];
                        e.CanExecute = pEvoMerca._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 10:
                        #region ÍNDICE PRECONFIGURADO (NOVAREX)
                        var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)this.StackConfigParam.Children[0];
                        e.CanExecute = pIndicePreconfiguradoNovarex._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 12:
                        #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                        var pDistriPatrimNovarex = (Param_DistriPatrimNovarex)this.StackConfigParam.Children[0];
                        e.CanExecute = pDistriPatrimNovarex._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 14:
                        #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                        var pCV = (Param_CompraVentaPrecAdq)this.StackConfigParam.Children[0];

                        e.CanExecute = pCV._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 16:
                        #region DIVIDENDOS COBRADOS
                        var pDividendosCobrados = (Param_DividendosCobrados)this.StackConfigParam.Children[0];

                        e.CanExecute = pDividendosCobrados._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 17:
                        #region PLUSVALÍAS Y DIVIDENDOS

                        var pPlDividendos = (Param_PlusvaliasDividendos)this.StackConfigParam.Children[0];

                        e.CanExecute = pPlDividendos._noOfErrorsOnScreen == 0;
                        #endregion
                        break;
                    case 18:
                        #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                        var pRVComprasRealizadasEjercicio = (Param_RVComprasRealizadasEjercicio)this.StackConfigParam.Children[0];

                        e.CanExecute = pRVComprasRealizadasEjercicio._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 19:
                        #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                        var pIIC_ComprasVentasEjercicio = (Param_IIC_ComprasVentasEjercicio)this.StackConfigParam.Children[0];

                        e.CanExecute = pIIC_ComprasVentasEjercicio._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 20:
                        #region RF: COMPRAS Y VENTAS EJERCICIO
                        var pRFComprasVentasEjercicio = (Param_RFComprasVentasEjercicio)this.StackConfigParam.Children[0];

                        e.CanExecute = pRFComprasVentasEjercicio._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 24:
                        #region CARTERA RF
                        var pCRF = (Param_CarteraRF)this.StackConfigParam.Children[0];

                        e.CanExecute = pCRF._noOfErrorsOnScreen == 0;
                        #endregion

                        break;
                    case 25://GRÁFICO I (BENCHMARK)
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region GRÁFICO I (BENCHMARK)
                        var pBenchMark = (Param_GraficoBenchMark)this.StackConfigParam.Children[0];

                        e.CanExecute = pBenchMark._noOfErrorsOnScreen == 0;

                        #endregion
                        break;
                    case 27:
                        #region EVOLUCIÓN RENTABILIDAD GUISSONA
                        var pEvoRentabGuissona = (Param_EvolucionRentabilidadGuissona)this.StackConfigParam.Children[0];

                        e.CanExecute = pEvoRentabGuissona._noOfErrorsOnScreen == 0;

                        #endregion
                        break;
                    case 28:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)this.StackConfigParam.Children[0];

                        e.CanExecute = pEvoPatriConjGuissona._noOfErrorsOnScreen == 0;

                        #endregion
                        break;
                    case 29:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)this.StackConfigParam.Children[0];

                        e.CanExecute = pEvoPatriGuissona._noOfErrorsOnScreen == 0;

                        #endregion
                        break;
                    case 36:
                        var pCarteraRV = (Param_RatiosCarteraRV)this.StackConfigParam.Children[0];
                        e.CanExecute = pCarteraRV._noOfErrorsOnScreen == 0;
                        break;
                    default:
                        e.CanExecute = true;
                        break;
                }

                #endregion
            }


            e.Handled = true;
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Dataitems.DataItems.CheckedItems.Count > 0)
            {
                #region has Checked Items
                foreach (DataItem item in (Dataitems.DataItems.CheckedItems))
                {
                    SeccionId = item.Seccion.Id;

                    #region Parse Params values
                    Seccione selectedValue = item.Seccion;
                    if (selectedValue != null)
                    {
                        switch (selectedValue.Id)
                        {
                            //Estas dos secciones comparten parámetros
                            //Normalmente sale una o la otra
                            case 6:
                            case 46:                                
                                #region VARIACIÓN PATRIMONIAL B
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_VariacionPatrimonialB)
                                    {
                                        var pVariPatrimonialB = (Param_VariacionPatrimonialB)param;

                                        if (ParamVariaPatrimonialB == null) ParamVariaPatrimonialB = new Parametros_VariacionPatrimonialB();

                                        if (string.IsNullOrEmpty(pVariPatrimonialB.txtBoxComisionFijaPagada.Text))
                                        {
                                            ParamVariaPatrimonialB.ComisionFijaPagada = 0;
                                        }
                                        else
                                        {
                                            ParamVariaPatrimonialB.ComisionFijaPagada = decimal.Parse(pVariPatrimonialB.txtBoxComisionFijaPagada.Text);
                                        }
                                        

                                    }
                                }
                                #endregion
                                break;
                            case 8:
                                #region RENTABILIDAD CARTERA (II)
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_Rentabilidad_carteraII)
                                    {
                                        var pRentabilidadCarteraII = (Param_Rentabilidad_carteraII)param;
                                        if (ParamRentabilidadCarteraII == null) ParamRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                                        ParamRentabilidadCarteraII.FechaInicio = pRentabilidadCarteraII.DpFechaInicio.SelectedDate;
                                    }
                                }

                                #endregion
                                break;
                            case 9:
                                #region EVOLUCIÓN MERCADOS
                                
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionMercados)
                                    {
                                        var pEvoMercados = (Param_EvolucionMercados)param;

                                        #region update preexist elements
                                        foreach (var itemEvoMerca in pEvoMercados.parametrosEvoMerca.Where(c => c.CodigoIC != null))
                                        {
                                            var t = ParamEvolucionMercados.Where(c => c.Id == itemEvoMerca.Id).FirstOrDefault();
                                            if (t != null)
                                            {
                                                //update
                                                t.Isin = itemEvoMerca.Isin;
                                                t.Descripcion = itemEvoMerca.Descripcion;
                                            }
                                        }
                                        #endregion

                                        #region Delete items not exists now
                                        for (int i = ParamEvolucionMercados.Count - 1; i >= 0; i--)
                                        {
                                            var t = pEvoMercados.parametrosEvoMerca.Where(c => c.Id == ParamEvolucionMercados[i].Id).FirstOrDefault();
                                            if (t == null)
                                            {
                                                //remove
                                                ParamEvolucionMercados.RemoveAt(i);
                                            }
                                        }
                                        #endregion

                                        #region Add new items
                                        foreach (var itemEvoMerca in pEvoMercados.parametrosEvoMerca.Where(c => c.CodigoIC == null))
                                        {
                                            ParamEvolucionMercados.Add(itemEvoMerca);
                                        }
                                        #endregion

                                    }
                                }
                                

                                #endregion
                                break;
                            case 10:
                                #region ÍNDICE PRECONFIGURADO (NOVAREX)
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_IndicePreconfiguradoNovarex)
                                    {
                                        var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)param;


                                        if (ParamIndicePreconfiguradoNovarex == null)
                                        {
                                            ParamIndicePreconfiguradoNovarex = pIndicePreconfiguradoNovarex.parametrosIndicePreConfNovarex;
                                        }
                                        
                                    }
                                    else if (param is Parametros_IndicePreconfiguradoNovarex_Otros)
                                    {
                                        var pIndicePreconfiguradoNovarexOtros = (Param_IndicePreconfiguradoNovarex)param;


                                        if (ParamIndicePreconfiguradoNovarexOtros == null)
                                        {
                                            ParamIndicePreconfiguradoNovarexOtros = pIndicePreconfiguradoNovarexOtros.parametroOtros;
                                        }

                                    }
                                }
                                #endregion
                                break;
                            case 12:
                                #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_DistriPatrimNovarex)
                                    {
                                        var pDistriPatrimNovarex = (Param_DistriPatrimNovarex)param;
                                        //ParamEvolucionMercados

                                        #region update preexist elements
                                        //foreach (var itemEvoMerca in pEvoMercados.parametrosEvoMerca.Where(c=>c.CodigoIC!=null))
                                        //{
                                        //    var t = ParamEvolucionMercados.Where(c => c.Id == itemEvoMerca.Id).FirstOrDefault();
                                        //    if(t!=null)
                                        //    {
                                        //        //update
                                        //        t.Isin = itemEvoMerca.Isin;
                                        //        t.Descripcion = itemEvoMerca.Descripcion;
                                        //    }
                                        //}
                                        #endregion

                                        #region Delete items not exists now
                                        //for (int i = ParamEvolucionMercados.Count - 1; i >= 0; i--)
                                        //{
                                        //    var t = pEvoMercados.parametrosEvoMerca.Where(c => c.Id == ParamEvolucionMercados[i].Id).FirstOrDefault();
                                        //    if (t == null)
                                        //    {
                                        //        //remove
                                        //        ParamEvolucionMercados.RemoveAt(i);
                                        //    }
                                        //}
                                        #endregion

                                        #region Add new items
                                        //foreach (var itemEvoMerca in pEvoMercados.parametrosEvoMerca.Where(c => c.CodigoIC == null))
                                        //{
                                        //    ParamEvolucionMercados.Add(itemEvoMerca);
                                        //}
                                        #endregion

                                    }
                                }

                                #endregion
                                break;
                            case 14:
                                #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_CompraVentaPrecAdq)
                                    {
                                        var pObj = (Param_CompraVentaPrecAdq)param;
                                        if (ParamCompraVentaPrecAdq == null)
                                        {
                                            ParamCompraVentaPrecAdq = new Parametros_CompraVentaPrecAdq();
                                        }
                                        //ParamCompraVentaPrecAdq.EfectivoMinimo = decimal.Parse(pObj.TxtEfectivoMinimo.Text);
                                        //decimal efectMin = 0;
                                        if (pObj != null)
                                        {
                                            var paramEfec = Helpers.Utils.CheckDecimal(pObj.TxtEfectivoMinimo.Text);
                                            if (paramEfec != null)
                                            {
                                                ParamCompraVentaPrecAdq.EfectivoMinimo = Convert.ToDecimal(paramEfec);
                                            }
                                        }
                                    }
                                }
                                #endregion

                                break;
                            case 16:
                                #region DIVIDENDOS COBRADOS
                                 foreach (var param in this.StackConfigParam.Children)
                                    {
                                        if (param is Param_DividendosCobrados)
                                        {
                                            var pDividendosCobrados = (Param_DividendosCobrados)param;
                                            if (ParamDividendosCobrados == null) ParamDividendosCobrados = new Parametros_DividendosCobrados();
                                            ParamDividendosCobrados.FechaUltimaReunion = pDividendosCobrados.DpFechaUltimaReunion.SelectedDate;
                                        }
                                    }

                                #endregion

                                break;
                            case 17:
                                #region PLUSVALÍAS Y DIVIDENDOS
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_PlusvaliasDividendos)
                                    {
                                        var pPlDividendos = (Param_PlusvaliasDividendos)param;
                                        if (ParamPlusvaliasDividendos == null) ParamPlusvaliasDividendos = new Parametros_PlusvaliasDividendos();
                                        ParamPlusvaliasDividendos.Descripcion = pPlDividendos.textBoxTitulo.Text;
                                        
                                    }
                                }
                               
                                #endregion
                                break;
                            case 18:
                                #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RVComprasRealizadasEjercicio)
                                    {
                                        var pRVComprasRealizadasEjercicio = (Param_RVComprasRealizadasEjercicio)param;
                                        if (ParamRVComprasRealizadasEjercicio == null) ParamRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                                        ParamRVComprasRealizadasEjercicio.FechaUltimaReunion = pRVComprasRealizadasEjercicio.DpFechaUltimaReunion.SelectedDate;
                                    }
                                }

                                #endregion

                                break;
                            case 19:
                                #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_IIC_ComprasVentasEjercicio)
                                    {
                                        var pIIC_ComprasVentasEjercicio = (Param_IIC_ComprasVentasEjercicio)param;
                                        if (ParamIIC_ComprasVentasEjercicio == null) ParamIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                                        ParamIIC_ComprasVentasEjercicio.FechaUltimaReunion = pIIC_ComprasVentasEjercicio.DpFechaUltimaReunion.SelectedDate;
                                    }
                                }

                                #endregion

                                break;
                            case 20:
                                #region RF: COMPRAS Y VENTAS EJERCICIO
                                
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RFComprasVentasEjercicio)
                                    {
                                        var pRFComprasVentasEjercicio = (Param_RFComprasVentasEjercicio)param;
                                        if (ParamRFComprasVentasEjercicio == null) ParamRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();
                                        ParamRFComprasVentasEjercicio.FechaAnterior = pRFComprasVentasEjercicio.DpFechaAnterior.SelectedDate;
                                    }  
                                }
                                
                                #endregion

                                break;
                            case 24:
                                #region CARTERA RF
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_CarteraRF)
                                    {
                                        var pObj = (Param_CarteraRF)param;
                                        if (ParamCarteraRF == null) ParamCarteraRF = new Parametros_CarteraRF();
                                        ParamCarteraRF.VencimCortoMedioPlazo = !string.IsNullOrEmpty(pObj.TextBox1.Text) ?  Int32.Parse(pObj.TextBox1.Text) : 0;
                                    }
                                }
                                #endregion

                                break;
                            case 25://GRÁFICO I (BENCHMARK)
                            case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                                #region GRÁFICO I (BENCHMARK)
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_GraficoBenchMark)
                                    {
                                        var pBenchMark = (Param_GraficoBenchMark)param;
                                        if (ParamGraficoBenchmark == null) ParamGraficoBenchmark = new Parametros_GraficoBenchmark();
                                        //ParamGraficoBenchmark.Descripcion = pBenchMark.txtBoxDescripcion.Text;
                                        //ParamGraficoBenchmark.Indice = pBenchMark.txtBoxIndice.Text;
                                        if(pBenchMark.DpFechainicio.SelectedDate != null)
                                            ParamGraficoBenchmark.FechaInicio = pBenchMark.DpFechainicio.SelectedDate.Value;

                                        ParamGraficoBenchmark_Indices = pBenchMark.Indices;
                                    }
                                }

                                #endregion
                                break;
                            case 27:
                                #region EVOLUCIÓN RENTABILIDAD GUISSONA
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionRentabilidadGuissona)
                                    {
                                        var pEvoRentabGuissona = (Param_EvolucionRentabilidadGuissona)param;
                                        
                                        if (ParamEvoRentabiGuissona != null) ParamEvoRentabiGuissona.Titulo = pEvoRentabGuissona.textBoxTitulo.Text;

                                        ParamEvoRentabiGuissona_Fondos = pEvoRentabGuissona.parametrosEvoRentabGuissona_Fondos;
                                        
                                    }
                                }

                                #endregion
                                break;
                            case 28:
                                #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionPatrimonioConjuntoGuissona)
                                    {
                                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)param;

                                        if (ParamEvoPatriConjGuissona != null) ParamEvoPatriConjGuissona.Titulo = pEvoPatriConjGuissona.textBoxTitulo.Text;

                                        ParamEvoPatriConjGuissona_Fondos = pEvoPatriConjGuissona.parametrosEvPatrimonioConjuntoGuissona_Fondos;

                                    }
                                }

                                #endregion
                                break;
                            case 29:
                                #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_EvolucionPatrimGuissona)
                                    {
                                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)param;
                                        if (ParamEvolucionPatrimGuissona == null) ParamEvolucionPatrimGuissona = new Parametros_EvolucionPatrimGuissona();
                                        ParamEvolucionPatrimGuissona.ComisionDepositaria = decimal.Parse(pEvoPatriGuissona.txtBoxComisionDepositaria.Text);
                                        ParamEvolucionPatrimGuissona.TasaGestionAnual = decimal.Parse(pEvoPatriGuissona.txtBoxTasaGestionAnual.Text);
                                    }
                                }

                                #endregion
                                break;
                            case 35:
                                #region OPERACIONES RENTA VARIABLE (II)
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_OperacionesRentaVariable_II)
                                    {
                                        var pOperacionesRentaVariable_II = (Param_OperacionesRentaVariable_II)param;
                                        if (ParamOperacionesRentaVariable_II == null) ParamOperacionesRentaVariable_II = new Parametros_OperacionesRentaVariable_II();
                                        ParamOperacionesRentaVariable_II.FechaUltimoInforme = pOperacionesRentaVariable_II.DpFechaUltimaReunion.SelectedDate;
                                        if(!string.IsNullOrEmpty(pOperacionesRentaVariable_II.TxtEfectivoMinimo.Text))
                                            ParamOperacionesRentaVariable_II.EfectivoMinimo = decimal.Parse(pOperacionesRentaVariable_II.TxtEfectivoMinimo.Text);
                                    }
                                }

                                #endregion

                                break;
                            case 36:
                                #region RATIOS CARTERA RV (¿SECTORIALS?)

                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_RatiosCarteraRV)
                                    {
                                        var pCarteraRV = (Param_RatiosCarteraRV)param;
                                        #region ParamRatiosCarteraRV
                                        if (ParamRatiosCarteraRV == null) ParamRatiosCarteraRV = new Parametros_RatiosCarteraRV();
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text))
                                            ParamRatiosCarteraRV.BpaAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text);
                                        if (!string.IsNullOrEmpty(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text))
                                            ParamRatiosCarteraRV.BpaAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text);
                                        if (!string.IsNullOrEmpty(pCarteraRV.txtBoxBpaPrevisionMaximo.Text))
                                            ParamRatiosCarteraRV.BpaPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMaximo.Text);
                                        if (!string.IsNullOrEmpty(pCarteraRV.txtBoxBpaPrevisionMinimo.Text))
                                            ParamRatiosCarteraRV.BpaPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text))
                                            ParamRatiosCarteraRV.DescuentoFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text))
                                            ParamRatiosCarteraRV.DescuentoFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text))
                                            ParamRatiosCarteraRV.DeudaNetaCapitalizacionMaximo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text))
                                            ParamRatiosCarteraRV.DeudaNetaCapitalizacionMinimo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPerAñoInformeMaximo.Text))
                                            ParamRatiosCarteraRV.PerAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPerAñoInformeMinimo.Text))
                                            ParamRatiosCarteraRV.PerAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPerPrevisionMaximo.Text))
                                            ParamRatiosCarteraRV.PerPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPerPrevisionMinimo.Text))
                                            ParamRatiosCarteraRV.PerPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPrecioVcMaximo.Text))
                                            ParamRatiosCarteraRV.PrecioVcMaximo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxPrecioVcMinimo.Text))
                                            ParamRatiosCarteraRV.PrecioVcMinimo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text))
                                            ParamRatiosCarteraRV.RentabilidadesAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text))
                                            ParamRatiosCarteraRV.RentabilidadesAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text))
                                            ParamRatiosCarteraRV.RentabilidadesPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text);
                                        if(!string.IsNullOrEmpty(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text))
                                            ParamRatiosCarteraRV.RentabilidadesPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text);
                                        //if(!string.IsNullOrEmpty(pCarteraRV.txtBoxValorFundamentalMaximo.Text))
                                        //ParamRatiosCarteraRV.ValorFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMaximo.Text);
                                        if (!string.IsNullOrEmpty(pCarteraRV.txtBoxValorFundamentalMinimo.Text))
                                            ParamRatiosCarteraRV.ValorFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMinimo.Text);
                                        #endregion

                                    }
                                }

                                #endregion
                                break;
                            case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                                foreach (var param in this.StackConfigParam.Children)
                                {
                                    if (param is Param_GraficoCompPatrimonioTipoProducto)
                                    {
                                        var obj = (Param_GraficoCompPatrimonioTipoProducto)param;
                                        if (ParamGraficoCompPatrimonioTipoProducto == null) ParamGraficoCompPatrimonioTipoProducto = new Parametros_GraficoCompPatrimonioTipoProducto();
                                        ParamGraficoCompPatrimonioTipoProducto.PorcEstrategiasRA = Convert.ToDecimal(obj.TxtPorcEstrategiasRA.Number);
                                    }
                                }

                                #endregion

                                break;
                        }
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                #region Edit Mode check selecteditem
                

                #region Parse Params values
               
                    switch  (SeccionId)
                    {
                    //Estas dos secciones comparten parámetros
                    //Normalmente sale una o la otra
                    case 6:
                    case 46:
                            #region VARIACIÓN PATRIMONIAL B
                            var pVariPatrimonialB = (Param_VariacionPatrimonialB)this.StackConfigParam.Children[0];
                            if (ParamVariaPatrimonialB == null) ParamVariaPatrimonialB = new Parametros_VariacionPatrimonialB();
                            if (string.IsNullOrEmpty(pVariPatrimonialB.txtBoxComisionFijaPagada.Text))
                            {
                                ParamVariaPatrimonialB.ComisionFijaPagada = null;
                            }
                            else
                            {
                                ParamVariaPatrimonialB.ComisionFijaPagada = decimal.Parse(pVariPatrimonialB.txtBoxComisionFijaPagada.Text);
                            }
                            

                            #endregion
                            break;
                        case 8:
                            #region RENTABILIDAD CARTERA (II)
                            var pRentabilidadCarteraII = (Param_Rentabilidad_carteraII)this.StackConfigParam.Children[0];
                            if (ParamRentabilidadCarteraII == null) ParamRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                            ParamRentabilidadCarteraII.FechaInicio = pRentabilidadCarteraII.DpFechaInicio.SelectedDate;
                        
                            #endregion

                            break;
                    case 9:
                            #region EVOLUCIÓN MERCADOS
                            var pEvoMerca = (Param_EvolucionMercados)this.StackConfigParam.Children[0];

                            ParamEvolucionMercados = pEvoMerca.parametrosEvoMerca;
                            //ParamEvolucionMercados
                            //foreach (var item in pEvoMerca.parametrosEvoMerca)
                            //{
                            //    ParamEvolucionMercados.Add(item);
                            //}
                            #endregion
                            break;
                        case 10:
                            #region ÍNDICE PRECONFIGURADO (NOVAREX)
                           
                                var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)this.StackConfigParam.Children[0];
                        if (ParamIndicePreconfiguradoNovarex == null)
                        {
                            ParamIndicePreconfiguradoNovarex = pIndicePreconfiguradoNovarex.parametrosIndicePreConfNovarex;
                            ParamIndicePreconfiguradoNovarexOtros = pIndicePreconfiguradoNovarex.parametroOtros;
                        }
                            #endregion
                            break;
                        case 12:
                            #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                            var pDistriPatriNovarex = (Param_DistriPatrimNovarex)this.StackConfigParam.Children[0];

                            ParamDistribPatriNovarex = pDistriPatriNovarex.parametrosDistriPatriNovarex;
                            //ParamEvolucionMercados
                            //foreach (var item in pEvoMerca.parametrosEvoMerca)
                            //{
                            //    ParamEvolucionMercados.Add(item);
                            //}
                            #endregion
                            break;
                    case 14:
                        #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                        var pCV = (Param_CompraVentaPrecAdq)this.StackConfigParam.Children[0];
                        if (ParamCompraVentaPrecAdq == null)
                            ParamCompraVentaPrecAdq = new Parametros_CompraVentaPrecAdq();
                        if(!string.IsNullOrEmpty(pCV.TxtEfectivoMinimo.Text))
                            ParamCompraVentaPrecAdq.EfectivoMinimo = Convert.ToDecimal(pCV.TxtEfectivoMinimo.Text);
                        #endregion

                        break;
                    case 16:
                            #region DIVIDENDOS COBRADOS
                                    var pDividendosCobrados = (Param_DividendosCobrados)this.StackConfigParam.Children[0]; 
                                    if (ParamDividendosCobrados == null) ParamDividendosCobrados = new Parametros_DividendosCobrados();
                                    ParamDividendosCobrados.FechaUltimaReunion = pDividendosCobrados.DpFechaUltimaReunion.SelectedDate;
                            #endregion

                            break;
                        case 17:
                            #region PLUSVALÍAS Y DIVIDENDOS
                                var pPlDividendos = (Param_PlusvaliasDividendos)this.StackConfigParam.Children[0];
                                if (ParamPlusvaliasDividendos == null) ParamPlusvaliasDividendos = new Parametros_PlusvaliasDividendos();
                                ParamPlusvaliasDividendos.Descripcion = pPlDividendos.textBoxTitulo.Text;
                                //ParamPlusvaliasDividendos.Parametros_PlusvaliasDividendos_ISINS = pPlDividendos.parametrosPlusvaliasDividendos.ToList();
                        #endregion
                        break;
                        case 18:
                            #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                            var pRVComprasRealizadasEjercicio = (Param_RVComprasRealizadasEjercicio)this.StackConfigParam.Children[0];
                            if (ParamRVComprasRealizadasEjercicio == null) ParamRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                            ParamRVComprasRealizadasEjercicio.FechaUltimaReunion = pRVComprasRealizadasEjercicio.DpFechaUltimaReunion.SelectedDate;
                            #endregion

                            break;
                        case 19:
                            #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                            var pIIC_ComprasVentasEjercicio = (Param_IIC_ComprasVentasEjercicio)this.StackConfigParam.Children[0];
                            if (ParamIIC_ComprasVentasEjercicio == null) ParamIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                            ParamIIC_ComprasVentasEjercicio.FechaUltimaReunion = pIIC_ComprasVentasEjercicio.DpFechaUltimaReunion.SelectedDate;
                            #endregion

                            break;
                        case 20:
                             #region RF: COMPRAS Y VENTAS EJERCICIO
                                    var pRFComprasVentasEjercicio = (Param_RFComprasVentasEjercicio)this.StackConfigParam.Children[0];
                                    if (ParamRFComprasVentasEjercicio == null) ParamRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();

                                    ParamRFComprasVentasEjercicio.FechaAnterior = pRFComprasVentasEjercicio.DpFechaAnterior.SelectedDate;
                        
                                #endregion

                        break;
                    case 24:
                        #region CARTERA RF
                        var pCRF = (Param_CarteraRF)this.StackConfigParam.Children[0];
                        if (ParamCarteraRF == null)
                            ParamCarteraRF = new Parametros_CarteraRF();
                        if (!string.IsNullOrEmpty(pCRF.TextBox1.Text))
                            ParamCarteraRF.VencimCortoMedioPlazo = Convert.ToInt32(pCRF.TextBox1.Text);
                        #endregion

                        break;
                    case 25://GRÁFICO I (BENCHMARK)
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region GRÁFICO I (BENCHMARK)
                        var pBenchMark = (Param_GraficoBenchMark)this.StackConfigParam.Children[0];

                        //ParamGraficoBenchmark.Descripcion = pBenchMark.txtBoxDescripcion.Text;
                        //ParamGraficoBenchmark.Indice = pBenchMark.txtBoxIndice.Text;
                        if (ParamGraficoBenchmark == null) ParamGraficoBenchmark = new Parametros_GraficoBenchmark();

                        if(pBenchMark.DpFechainicio.SelectedDate != null)
                            ParamGraficoBenchmark.FechaInicio = pBenchMark.DpFechainicio.SelectedDate.Value;
                        //ParamGraficoBenchmark.Parametros_GraficoBenchmark_Indices = pBenchMark.parametrosGrBenchmarkInd;

                        ParamGraficoBenchmark_Indices = pBenchMark.Indices;
                        #endregion
                        break;
                        case 27:
                            #region EVOLUCIÓN RENTABILIDAD GUISSONA
                            var pEvoRentabiGuissona = (Param_EvolucionRentabilidadGuissona)this.StackConfigParam.Children[0];
                        if (ParamEvoRentabiGuissona == null)
                            ParamEvoRentabiGuissona = new Parametros_EvolucionRentabilidadGuissona();
                            ParamEvoRentabiGuissona.Titulo = pEvoRentabiGuissona.textBoxTitulo.Text;
                            //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);
                            ParamEvoRentabiGuissona_Fondos = pEvoRentabiGuissona.parametrosEvoRentabGuissona_Fondos;
                            #endregion
                            break;
                        case 28:
                            #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                            var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)this.StackConfigParam.Children[0];
                        if (ParamEvoPatriConjGuissona == null)
                            ParamEvoPatriConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();

                            ParamEvoPatriConjGuissona.Titulo = pEvoPatriConjGuissona.textBoxTitulo.Text;
                            //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);
                            ParamEvoPatriConjGuissona_Fondos = pEvoPatriConjGuissona.parametrosEvPatrimonioConjuntoGuissona_Fondos;
                            #endregion
                            break;
                        case 29://EVOLUCIÓN PATRIMONIO GUISSONA
                        #region EVOLUCIÓN PATRIMONIO GUISSONA
                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)this.StackConfigParam.Children[0];
                        
                        if (ParamEvolucionPatrimGuissona == null)
                            ParamEvolucionPatrimGuissona = new Parametros_EvolucionPatrimGuissona();

                            ParamEvolucionPatrimGuissona.ComisionDepositaria = decimal.Parse(pEvoPatriGuissona.txtBoxComisionDepositaria.Text);
                            ParamEvolucionPatrimGuissona.TasaGestionAnual = decimal.Parse(pEvoPatriGuissona.txtBoxTasaGestionAnual.Text);

                        var objPEG = _plantilla.Parametros_EvolucionPatrimGuissona.FirstOrDefault();
                        if (objPEG == null)
                            _plantilla.Parametros_EvolucionPatrimGuissona.Add(ParamEvolucionPatrimGuissona);
                        else
                        {
                            objPEG.ComisionDepositaria = ParamEvolucionPatrimGuissona.ComisionDepositaria;
                            objPEG.TasaGestionAnual = ParamEvolucionPatrimGuissona.TasaGestionAnual;
                        }

                            #endregion
                        break;
                    case 35:
                        #region OPERACIONES RENTA VARIABLE (II)
                        var pOperacionesRentaVariable_II = (Param_OperacionesRentaVariable_II)this.StackConfigParam.Children[0];
                        if (ParamOperacionesRentaVariable_II == null) ParamOperacionesRentaVariable_II = new Parametros_OperacionesRentaVariable_II();
                        ParamOperacionesRentaVariable_II.FechaUltimoInforme = pOperacionesRentaVariable_II.DpFechaUltimaReunion.SelectedDate;
                        ParamOperacionesRentaVariable_II.EfectivoMinimo = string.IsNullOrEmpty(pOperacionesRentaVariable_II.TxtEfectivoMinimo.Text) ? (decimal?)null : decimal.Parse(pOperacionesRentaVariable_II.TxtEfectivoMinimo.Text);
                        #endregion

                        break;
                    case 36:
                            #region RATIOS CARTERA RV (¿SECTORIALS?)
                            var pCarteraRV = (Param_RatiosCarteraRV)this.StackConfigParam.Children[0];
                        if (ParamRatiosCarteraRV == null)
                            ParamRatiosCarteraRV = new Parametros_RatiosCarteraRV();

                        ParamRatiosCarteraRV.PorcentajeCarteraMinMostrar = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPorcentajeCarteraMinMostrar.Text);
                        ParamRatiosCarteraRV.BpaAñoInformeMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.BpaAñoInformeMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.BpaPrevisionMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxBpaPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.BpaPrevisionMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxBpaPrevisionMinimo.Text);
                        ParamRatiosCarteraRV.DescuentoFundamentalMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text);
                        ParamRatiosCarteraRV.DescuentoFundamentalMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text);
                        ParamRatiosCarteraRV.DeudaNetaCapitalizacionMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text);
                        ParamRatiosCarteraRV.DeudaNetaCapitalizacionMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text);
                        ParamRatiosCarteraRV.PerAñoInformeMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPerAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.PerAñoInformeMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPerAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.PerPrevisionMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPerPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.PerPrevisionMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPerPrevisionMinimo.Text);
                        ParamRatiosCarteraRV.PrecioVcMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPrecioVcMaximo.Text);
                        ParamRatiosCarteraRV.PrecioVcMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxPrecioVcMinimo.Text);
                        ParamRatiosCarteraRV.RentabilidadesAñoInformeMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.RentabilidadesAñoInformeMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.RentabilidadesPrevisionMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.RentabilidadesPrevisionMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text);
                        //ParamRatiosCarteraRV.ValorFundamentalMaximo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxValorFundamentalMaximo.Text);
                        ParamRatiosCarteraRV.ValorFundamentalMinimo = Helpers.Utils.CheckDecimal(pCarteraRV.txtBoxValorFundamentalMinimo.Text);

                        _plantilla.Parametros_RatiosCarteraRV.Remove(_plantilla.Parametros_RatiosCarteraRV.FirstOrDefault());
                        _plantilla.Parametros_RatiosCarteraRV.Add(ParamRatiosCarteraRV);
                            #endregion
                        break;
                    case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                        #region OPERACIONES RENTA VARIABLE (II)
                        var obj = (Param_GraficoCompPatrimonioTipoProducto)this.StackConfigParam.Children[0];
                        if (ParamGraficoCompPatrimonioTipoProducto == null) ParamGraficoCompPatrimonioTipoProducto = new Parametros_GraficoCompPatrimonioTipoProducto();
                        ParamGraficoCompPatrimonioTipoProducto.PorcEstrategiasRA = Convert.ToDecimal(obj.TxtPorcEstrategiasRA.Number);
                        #endregion

                        break;
                }
               
                #endregion
                #endregion
            }


            Cancel = false;
            e.Handled = true;
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo = this.textBoxCodigo.Text;
            //Descripcion = this.textBoxDescription.Text;
            /*
            SeccionId = (int)this.ComboBoxSeccion.SelectedValue;
            
            #region Parse Params values
            Seccione selectedValue = ((DataItem)this.ComboBoxSeccion.SelectedItem).Seccion;
            if (selectedValue != null)
            {
                switch (selectedValue.Id)
                {
                    case 6:
                        #region VARIACIÓN PATRIMONIAL B
                        var pVariPatrimonialB = (Param_VariacionPatrimonialB)this.StackConfigParam.Children[0];

                        if (string.IsNullOrEmpty(pVariPatrimonialB.txtBoxComisionFijaPagada.Text))
                        {
                            ParamVariaPatrimonialB.ComisionFijaPagada = null;
                        }
                        else
                        {
                            ParamVariaPatrimonialB.ComisionFijaPagada = decimal.Parse(pVariPatrimonialB.txtBoxComisionFijaPagada.Text);
                        }
                        

                        #endregion
                        break;
                    case 8:
                        #region RENTABILIDAD CARTERA (II)
                        
                        var pRentabilidadCarteraII = (Param_Rentabilidad_carteraII)this.StackConfigParam.Children[0];
                        if (ParamRentabilidadCarteraII == null) ParamRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                        ParamRentabilidadCarteraII.FechaInicio = pRentabilidadCarteraII.DpFechaInicio.SelectedDate;
                        
                        #endregion
                        break;
                    case 9:
                        #region EVOLUCIÓN MERCADOS
                        var pEvoMerca = (Param_EvolucionMercados)this.StackConfigParam.Children[0];

                        ParamEvolucionMercados = pEvoMerca.parametrosEvoMerca;
                        //ParamEvolucionMercados
                        //foreach (var item in pEvoMerca.parametrosEvoMerca)
                        //{
                        //    ParamEvolucionMercados.Add(item);
                        //}
                        #endregion

                        break;
                    case 10:
                        #region ÍNDICE PRECONFIGURADO (NOVAREX)
                        var pIndicePreconfiguradoNovarex = (Param_IndicePreconfiguradoNovarex)this.StackConfigParam.Children[0];
                        ParamIndicePreconfiguradoNovarex = pIndicePreconfiguradoNovarex.parametrosIndicePreConfNovarex;
                           
                        #endregion
                        break;
                    case 12:
                        #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                        var pDistriPatriNovarex = (Param_DistriPatrimNovarex)this.StackConfigParam.Children[0];

                        ParamDistribPatriNovarex = pDistriPatriNovarex.parametrosDistriPatriNovarex;
                        //ParamEvolucionMercados
                        //foreach (var item in pEvoMerca.parametrosEvoMerca)
                        //{
                        //    ParamEvolucionMercados.Add(item);
                        //}
                        #endregion
                        break;

                    case 16:
                        #region DIVIDENDOS COBRADOS
                        
                        var pDividendosCobrados = (Param_DividendosCobrados)this.StackConfigParam.Children[0];
                        if (ParamDividendosCobrados == null) ParamDividendosCobrados = new Parametros_DividendosCobrados();
                        ParamDividendosCobrados.FechaUltimaReunion = pDividendosCobrados.DpFechaUltimaReunion.SelectedDate;
                        
                        #endregion
                        break;
                    case 17:
                        #region PLUSVALÍAS Y DIVIDENDOS
                         var pPlDividendos = (Param_PlusvaliasDividendos)this.StackConfigParam.Children[0];
                        ParamPlusvaliasDividendos.Descripcion = pPlDividendos.textBoxTitulo.Text;

                        #endregion
                        break;
                    case 18:
                        #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO

                        var pRVComprasRealizadasEjercicio = (Param_RVComprasRealizadasEjercicio)this.StackConfigParam.Children[0];
                        if (ParamRVComprasRealizadasEjercicio == null) ParamRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                        ParamRVComprasRealizadasEjercicio.FechaUltimaReunion = pRVComprasRealizadasEjercicio.DpFechaUltimaReunion.SelectedDate;

                        #endregion
                        break;
                    case 19:
                        #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO

                        var pIIC_ComprasVentasEjercicio = (Param_IIC_ComprasVentasEjercicio)this.StackConfigParam.Children[0];
                        if (ParamIIC_ComprasVentasEjercicio == null) ParamIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                        ParamIIC_ComprasVentasEjercicio.FechaUltimaReunion = pIIC_ComprasVentasEjercicio.DpFechaUltimaReunion.SelectedDate;

                        #endregion
                        break;
                    case 20:
                        #region RF: COMPRAS Y VENTAS EJERCICIO
                        var pRFComprasVentasEjercicio = (Param_RFComprasVentasEjercicio)this.StackConfigParam.Children[0];
                        if (ParamRFComprasVentasEjercicio == null) ParamRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();

                        ParamRFComprasVentasEjercicio.FechaAnterior = pRFComprasVentasEjercicio.DpFechaAnterior.SelectedDate;

                        #endregion

                        break;
                    case 25:
                        #region GRÁFICO I (BENCHMARK)
                        var pBenchMark = (Param_GraficoBenchMark)this.StackConfigParam.Children[0];
                        //ParamGraficoBenchmark.Descripcion = pBenchMark.txtBoxDescripcion.Text;
                        //ParamGraficoBenchmark.Indice = pBenchMark.txtBoxIndice.Text;
                        ParamGraficoBenchmark.FechaInicio = pBenchMark.DpFechainicio.SelectedDate.Value;
                        ParamGraficoBenchmark.Parametros_GraficoBenchmark_Indices = pBenchMark.parametrosGrBenchmarkInd;
                        #endregion
                        break;
                    case 27:
                        #region EVOLUCIÓN RENTABILIDAD GUISSONA
                        var pEvoRentabGuissona = (Param_EvolucionRentabilidadGuissona)this.StackConfigParam.Children[0];
                        ParamEvoRentabiGuissona.Titulo = pEvoRentabGuissona.textBoxTitulo.Text;
                        ParamEvoRentabiGuissona_Fondos = pEvoRentabGuissona.parametrosEvoRentabGuissona_Fondos;
                        #endregion
                        break;
                    case 28:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)this.StackConfigParam.Children[0];
                        ParamEvoPatriConjGuissona.Titulo = pEvoPatriConjGuissona.textBoxTitulo.Text;
                        ParamEvoPatriConjGuissona_Fondos = pEvoPatriConjGuissona.parametrosEvPatrimonioConjuntoGuissona_Fondos;
                        #endregion
                        break;
                    case 29:
                        #region EVOLUCIÓN PATRIMONIO GUISSONA
                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)this.StackConfigParam.Children[0];
                        ParamEvolucionPatrimGuissona.ComisionDepositaria = decimal.Parse(pEvoPatriGuissona.txtBoxComisionDepositaria.Text);
                        ParamEvolucionPatrimGuissona.TasaGestionAnual = decimal.Parse(pEvoPatriGuissona.txtBoxTasaGestionAnual.Text);

                        #endregion
                        break;
                    case 35:
                        #region OPERACIONES RENTA VARIABLE (II)

                        var pOperacionesRentaVariable_II = (Param_OperacionesRentaVariable_II)this.StackConfigParam.Children[0];
                        if (ParamOperacionesRentaVariable_II== null) ParamOperacionesRentaVariable_II = new Parametros_OperacionesRentaVariable_II();
                        ParamOperacionesRentaVariable_II.FechaUltimoInforme = pOperacionesRentaVariable_II.DpFechaUltimaReunion.SelectedDate;
                        ParamOperacionesRentaVariable_II.EfectivoMinimo = decimal.Parse(pOperacionesRentaVariable_II.TxtEfectivoMinimo.Text);

                        #endregion
                        break;
                    case 36:
                        #region RATIOS CARTERA RV (¿SECTORIALS?)
                        var pCarteraRV = (Param_RatiosCarteraRV)this.StackConfigParam.Children[0];
                        ParamRatiosCarteraRV.PorcentajeCarteraMinMostrar = decimal.Parse(pCarteraRV.txtBoxPorcentajeCarteraMinMostrar.Text);
                        ParamRatiosCarteraRV.BpaAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.BpaAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.BpaPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.BpaPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMinimo.Text);
                        ParamRatiosCarteraRV.DescuentoFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text);
                        ParamRatiosCarteraRV.DescuentoFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text);
                        ParamRatiosCarteraRV.DeudaNetaCapitalizacionMaximo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text);
                        ParamRatiosCarteraRV.DeudaNetaCapitalizacionMinimo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text);
                        ParamRatiosCarteraRV.PerAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.PerAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.PerPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.PerPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMinimo.Text);
                        ParamRatiosCarteraRV.PrecioVcMaximo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMaximo.Text);
                        ParamRatiosCarteraRV.PrecioVcMinimo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMinimo.Text);
                        ParamRatiosCarteraRV.RentabilidadesAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text);
                        ParamRatiosCarteraRV.RentabilidadesAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text);
                        ParamRatiosCarteraRV.RentabilidadesPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text);
                        ParamRatiosCarteraRV.RentabilidadesPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text);
                        ParamRatiosCarteraRV.ValorFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMaximo.Text);
                        ParamRatiosCarteraRV.ValorFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMinimo.Text);
                        #endregion
                        break;
                }
            }
            #endregion
            */

            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private bool Correctedtop = false;
        private void ComboBoxSeccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Seccione selectedValue = this.ComboBoxSeccion.SelectedItem != null ? ((DataItem)this.ComboBoxSeccion.SelectedItem).Seccion : null;
           
           // if (selectedValue != null)
            if (SeccionId != null)
            {
                //switch (selectedValue.Id)
                switch (SeccionId)
                {
                    //Estas dos secciones comparten parámetros
                    //Normalmente sale una o la otra
                    case 6:
                    case 46:
                        #region VARIACIÓN PATRIMONIAL B
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_VariacionPatrimonialB(ParamVariaPatrimonialB, _plantilla));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 8:
                        #region RENTABILIDAD CARTERA (II)
                        
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                       
                        this.StackConfigParam.Children.Add(new Param_Rentabilidad_carteraII(ParamRentabilidadCarteraII));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        
                        #endregion
                        break;
                    case 9:
                        #region EVOLUCIÓN MERCADOS
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_EvolucionMercados(ParamEvolucionMercados));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 10:
                        #region ÍNDICE PRECONFIGURADO (NOVAREX)
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_IndicePreconfiguradoNovarex(ParamIndicePreconfiguradoNovarex, ParamIndicePreconfiguradoNovarexOtros));
                        this.Height = 590;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 12:
                        #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_DistriPatrimNovarex(ParamDistribPatriNovarex));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                        #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_CompraVentaPrecAdq(ParamCompraVentaPrecAdq));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 16:
                        #region DIVIDENDOS COBRADOS


                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_DividendosCobrados(ParamDividendosCobrados));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 17:
                        #region PLUSVALÍAS Y DIVIDENDOS
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new  Param_PlusvaliasDividendos (ParamPlusvaliasDividendosList));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 18:
                        #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO


                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_RVComprasRealizadasEjercicio(ParamRVComprasRealizadasEjercicio));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 19:
                        #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO


                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_IIC_ComprasVentasEjercicio(ParamIIC_ComprasVentasEjercicio));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 20:
                        #region RF: COMPRAS Y VENTAS EJERCICIO
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_RFComprasVentasEjercicio(ParamRFComprasVentasEjercicio));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                       

                        #endregion

                        break;
                    case 24://CARTERA RF
                        #region CARTERA RF
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_CarteraRF(ParamCarteraRF));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 25://GRÁFICO I (BENCHMARK)
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region GRÁFICO I (BENCHMARK)
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_GraficoBenchMark(ParamGraficoBenchmark, ParamGraficoBenchmark_Indices));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;

                    case 27:
                        #region EVOLUCIÓN RENTABILIDAD GUISSONA
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_EvolucionRentabilidadGuissona(ParamEvoRentabiGuissona, ParamEvoRentabiGuissona_Fondos));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        //this.Top = this.Top - 100;
                        //Correctedtop = true;
                        #endregion
                        break;
                    case 28:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_EvolucionPatrimonioConjuntoGuissona(ParamEvoPatriConjGuissona,ParamEvoPatriConjGuissona_Fondos));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        //this.Top = this.Top - 100;
                        //Correctedtop = true;
                        #endregion
                        break;
                    case 29:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        this.StackConfigParam.Children.Add(new Param_EvolucionPatrimGuissona(ParamEvolucionPatrimGuissona));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 35://OPERACIONES RENTA VARIABLE (II)
                        #region OPERACIONES RENTA VARIABLE (II)


                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_OperacionesRentaVariable_II(ParamOperacionesRentaVariable_II));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;
                    case 36:
                        #region RATIOS CARTERA RV (¿SECTORIALS?)
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        //this.ComboBoxSeccion.IsDropDownOpen = false;

                        this.StackConfigParam.Children.Add(new Param_RatiosCarteraRV(ParamRatiosCarteraRV));
                        this.Height = 538;
                        this.Width = 712;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.Top = this.Top - 100;
                        Correctedtop = true;
                        #endregion
                        break;
                    case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                        #region OPERACIONES RENTA VARIABLE (II)

                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_GraficoCompPatrimonioTipoProducto(ParamGraficoCompPatrimonioTipoProducto));
                        this.Height = 375;
                        this.Width = 702;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                        this.labelSección.Visibility = Visibility.Collapsed;

                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }


                        #endregion

                        break;

                    default:
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.Width = 702;
                        this.Height = 250;
                        break;

                }


            }



        }

        private void ComboBoxSeccion_DropDownClosed(object sender, EventArgs e)
        {
            this.StackConfigParam.Children.Clear();
            bool hasparams = false;
            bool hasCorrected = false;
            foreach (DataItem item in (Dataitems.DataItems.CheckedItems))
            {
                #region Parsing values
                
                Seccione selectedValue = item.Seccion;
                if (selectedValue != null)
                {
                    switch (selectedValue.Id)
                    {
                        //Estas dos secciones comparten parámetros
                        //Normalmente sale una o la otra
                        case 6:
                        case 46:
                            #region VARIACIÓN PATRIMONIAL B
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}
                            //this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            //this.labelSección.Visibility = Visibility.Collapsed;

                            this.StackConfigParam.Children.Add(new Param_VariacionPatrimonialB(ParamVariaPatrimonialB, _plantilla));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 8:
                            #region RENTABILIDAD CARTERA (II)
                            
                            //var pDividendosCobrados = (Param_DividendosCobrados)this.StackConfigParam.Children[0];
                            //if (ParamDividendosCobrados == null) ParamDividendosCobrados = new Parametros_DividendosCobrados();
                            //ParamDividendosCobrados.FechaUltimaReunion = pDividendosCobrados.DpFechaUltimaReunion.SelectedDate;
                            this.StackConfigParam.Children.Add(new Param_Rentabilidad_carteraII(ParamRentabilidadCarteraII));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;


                            #endregion
                            break;
                        case 9:
                            #region EVOLUCIÓN MERCADOS
                            this.StackConfigParam.Children.Add(new Param_EvolucionMercados(ParamEvolucionMercados));
                            this.Height = 375;
                            this.Width = 712;
                            gridConfigParam.Height = 236;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 10:
                            #region ÍNDICE PRECONFIGURADO (NOVAREX)
                           

                            this.StackConfigParam.Children.Add(new Param_IndicePreconfiguradoNovarex(ParamIndicePreconfiguradoNovarex, ParamIndicePreconfiguradoNovarexOtros));
                            this.Height = 590;
                            this.Width = 702;
                            gridConfigParam.Height = 236;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                           

                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            #endregion
                            break;
                        case 12:
                            #region DISTRIBUCIÓN PATRIMONIO NOVAREX
                            
                            //this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            //this.labelSección.Visibility = Visibility.Collapsed;

                            this.StackConfigParam.Children.Add(new Param_DistriPatrimNovarex(ParamDistribPatriNovarex));
                            this.Height = 375;
                            this.Width = 702;
                            gridConfigParam.Height = 236;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 14://COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN
                            #region COMPRA-VENTA RESPECTO PRECIO ADQUISICIÓN

                            this.StackConfigParam.Children.Add(new Param_CompraVentaPrecAdq(ParamCompraVentaPrecAdq));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        case 16:
                            #region DIVIDENDOS COBRADOS
                            
                            //var pDividendosCobrados = (Param_DividendosCobrados)this.StackConfigParam.Children[0];
                            //if (ParamDividendosCobrados == null) ParamDividendosCobrados = new Parametros_DividendosCobrados();
                            //ParamDividendosCobrados.FechaUltimaReunion = pDividendosCobrados.DpFechaUltimaReunion.SelectedDate;
                            this.StackConfigParam.Children.Add(new Param_DividendosCobrados(ParamDividendosCobrados));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            
                            #endregion
                            break;

                        case 17:
                            #region PLUSVALÍAS Y DIVIDENDOS
                           

                            this.StackConfigParam.Children.Add(new Param_PlusvaliasDividendos(ParamPlusvaliasDividendosList));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 18:
                            #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO

                           
                            this.StackConfigParam.Children.Add(new Param_RVComprasRealizadasEjercicio(ParamRVComprasRealizadasEjercicio));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        case 19:
                            #region IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO

                           
                            this.StackConfigParam.Children.Add(new Param_IIC_ComprasVentasEjercicio(ParamIIC_ComprasVentasEjercicio));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        case 20:
                            #region RF: COMPRAS Y VENTAS EJERCICIO
                            this.StackConfigParam.Children.Add(new Param_RFComprasVentasEjercicio(ParamRFComprasVentasEjercicio));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            
                            #endregion

                            break;
                        case 24://CARTERA RF
                            #region CARTERA RF

                            this.StackConfigParam.Children.Add(new Param_CarteraRF(ParamCarteraRF));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        case 25://GRÁFICO I (BENCHMARK)
                        case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                            #region GRÁFICO I (BENCHMARK)
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}

                            this.StackConfigParam.Children.Add(new Param_GraficoBenchMark(ParamGraficoBenchmark, ParamGraficoBenchmark_Indices));
                            this.Height = 375;
                            this.Width = 712;
                            gridConfigParam.Height = 236;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            if (Correctedtop)
                            {
                                if(!hasCorrected)this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 27:
                            #region EVOLUCIÓN RENTABILIDAD GUISSONA
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}

                            this.StackConfigParam.Children.Add(new Param_EvolucionRentabilidadGuissona(ParamEvoRentabiGuissona, ParamEvoRentabiGuissona_Fondos));
                            this.Height = 375;
                            this.Width = 712;
                            gridConfigParam.Height = 236;
                           
                           
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            //this.Top = this.Top - 100;
                            //Correctedtop = true;
                            hasparams = true;
                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                            }
                            #endregion
                            break;
                        case 28:
                            #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}

                            this.StackConfigParam.Children.Add(new Param_EvolucionPatrimonioConjuntoGuissona(ParamEvoPatriConjGuissona, ParamEvoPatriConjGuissona_Fondos));
                            this.Height = 375;
                            this.Width = 712;
                            gridConfigParam.Height = 236;


                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            //this.Top = this.Top - 100;
                            //Correctedtop = true;
                            hasparams = true;
                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                            }
                            #endregion
                            break;
                        case 29:
                            #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}

                            this.StackConfigParam.Children.Add(new Param_EvolucionPatrimGuissona(ParamEvolucionPatrimGuissona));
                            this.Height = 375;
                            this.Width = 702;
                            gridConfigParam.Height = 236;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;
                            #endregion
                            break;
                        case 35://OPERACIONES RENTA VARIABLE (II)
                            #region OPERACIONES RENTA VARIABLE (II)

                            this.StackConfigParam.Children.Add(new Param_OperacionesRentaVariable_II(ParamOperacionesRentaVariable_II));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        case 36:
                            #region RATIOS CARTERA RV (¿SECTORIALS?)
                            //if (this.StackConfigParam.Children.Count > 0)
                            //{
                            //    this.StackConfigParam.Children.RemoveAt(0);
                            //}
                            this.StackConfigParam.Children.Add(new Param_RatiosCarteraRV(ParamRatiosCarteraRV));
                            this.Height = 538;
                            this.Width = 762;
                           // gridConfigParam.Height = 420;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.Top = this.Top - 100;
                            Correctedtop = true;
                            hasparams = true;
                            #endregion
                            break;
                        case 42://GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)
                            #region GRÁFICOS DISTRIBUCIÓN PATRIMONIO (TIPO DE PRODUCTO)

                            this.StackConfigParam.Children.Add(new Param_GraficoCompPatrimonioTipoProducto(ParamGraficoCompPatrimonioTipoProducto));
                            this.Height = 375;
                            this.Width = 702;
                            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            this.ComboBoxSeccion.Visibility = Visibility.Collapsed;
                            this.labelSección.Visibility = Visibility.Collapsed;

                            if (Correctedtop)
                            {
                                this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            hasparams = true;

                            #endregion
                            break;
                        default:
                            if (Correctedtop)
                            {
                                if (!hasCorrected) this.Top = this.Top + 100;
                                Correctedtop = false;
                                hasCorrected = true;
                            }
                            if(!hasparams)
                            {
                                this.Width = 702;
                                this.Height = 250;
                                //gridConfigParam.Height = 10;
                            }
                           
                            break;

                    }


                }
                #endregion
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = !Cancel;
        }
    }
}
