using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.ViewModels.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reports_IICs.Pages.Plantillas.ControlesParametros;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Lógica de interacción para AddEditSeccion.xaml
    /// </summary>
    public partial class AddEditSeccion : MetroWindow
    {
        public int SeccionId;
        public bool Cancel = true;
        private List<string> ListaCodigo = new List<string>();
        public Parametros_GraficoBenchmark ParamGraficoBenchmark = new Parametros_GraficoBenchmark();
        public List<Parametros_GraficoBenchmark_Indices> ParamGrafBench_Indices = new List<Parametros_GraficoBenchmark_Indices>();
        public Parametros_PlusvaliasDividendos ParamPlusvaliasDividendos;

        public Parametros_RatiosCarteraRV ParamRatioCarteraRV;
        public List<Parametros_EvolucionMercados> ParamEvolucionMercados = new List<Parametros_EvolucionMercados>();
        public Parametros_EvolucionPatrimGuissona ParamEvoPatriGuissona;
        public Parametros_EvolucionRentabilidadGuissona ParamEvoRentabiGuissona;
        public Parametros_EvolucionPatrimonioConjuntoGuissona  ParamEvoPatriConjGuissona;
        public List<Parametros_EvolucionRentabilidadGuissona_Fondos> ParamEvoRentabiGuissona_Fondos = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();
        public List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> ParamEvoPatrimConjGuissona_Fondos = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();

        private Plantilla _plantilla;

        public AddEditSeccion(List<string> listacodigo
            , int? seccionId
            ,Parametros_GraficoBenchmark paramGraficoBenchmark
            , List<Parametros_GraficoBenchmark_Indices> paramGraficoBenchmark_Indices
            , Parametros_RatiosCarteraRV paramRatioCarteraRV
            , List<Parametros_EvolucionMercados> paramEvolucionMercados
            ,Parametros_EvolucionPatrimGuissona paramEvoPatriGuissona
            , Parametros_EvolucionRentabilidadGuissona paramEvoRentabiGuissona
            , List<Parametros_EvolucionRentabilidadGuissona_Fondos> paramEvoRentabiGuissona_Fondos
            , Parametros_EvolucionPatrimonioConjuntoGuissona paramEvoPatrimConjGuissona
            , List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> paramEvoPatrimConjGuissona_Fondos
            , ref Plantilla plantilla)
        {
            InitializeComponent();
            Loaded += OnLoaded;
            ListaCodigo = listacodigo;
            _plantilla = plantilla;
            if (seccionId != null)
            {
                SeccionId = Convert.ToInt32(seccionId);
            }
            ParamEvolucionMercados = paramEvolucionMercados;
            ParamGraficoBenchmark = paramGraficoBenchmark;
            ParamGrafBench_Indices = paramGraficoBenchmark_Indices;
            ParamRatioCarteraRV = paramRatioCarteraRV;
            ParamEvoPatriGuissona = paramEvoPatriGuissona;
            ParamEvoRentabiGuissona = paramEvoRentabiGuissona;
            ParamEvoRentabiGuissona_Fondos = paramEvoRentabiGuissona_Fondos;
            ParamEvoPatriConjGuissona = paramEvoPatrimConjGuissona;
            ParamEvoPatrimConjGuissona_Fondos = paramEvoPatrimConjGuissona_Fondos;
            
            System.Windows.Controls.ItemCollection SeccionesFiltradas = ComboBoxSeccion.Items;

                foreach (Seccione item in PlantillasPage_VM.GetSecciones().OrderBy(c=>c.Descripcion))
                {
                    ComboBoxSeccion.Items.Add(item);
                }

            #region Listacodigo
            foreach (string item in ListaCodigo)
            {
                Reports_IICs.DataModels.Seccione current = PlantillasPage_VM.GetSecciones().Where(c => c.Descripcion == item).FirstOrDefault();
                try
                {
                    int i = 0;
                    foreach (Seccione itemDelete in ComboBoxSeccion.Items)
                    {
                        if (itemDelete.Id == current.Id)
                        {
                            ComboBoxSeccion.Items.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                    //var todelete = ComboBoxSeccion.Items.w
                    //ComboBoxSeccion.Items.RemoveAt(current.Id);
                }

                catch (System.Exception)
                {

                }
            }
            #endregion

            
            //foreach (var item in paramEvolucionMercados)
            //{
            //    ParamEvolucionMercados.Add(item);
            //}
            //foreach (var item in paramEvoRentabiGuissona_Fondos)
            //{
            //    ParamEvoRentabiGuissona_Fondos.Add(item);
            //}

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
            #region Parse Params values
            Seccione selectedValue = (Seccione)this.ComboBoxSeccion.SelectedItem;
            if (selectedValue != null)
            {
                switch (selectedValue.Id)
                {
                    case 9:
                        #region EVOLUCIÓN MERCADOS
                        var pEvoMerca = (Param_EvolucionMercados)this.StackConfigParam.Children[0];
                        e.CanExecute = pEvoMerca._noOfErrorsOnScreen == 0;
                        #endregion
                        break;

                    case 17:
                        #region PLUSVALÍAS Y DIVIDENDOS
                       
                        var pPlDividendos = (Param_PlusvaliasDividendos )this.StackConfigParam.Children[0];

                        e.CanExecute = pPlDividendos._noOfErrorsOnScreen == 0;
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
            }
            #endregion

           
            e.Handled = true;
        }

        private void AddElement_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SeccionId = (int)this.ComboBoxSeccion.SelectedValue;

            #region Parse Params values
            Seccione selectedValue = (Seccione)this.ComboBoxSeccion.SelectedItem;
            if (selectedValue != null)
            {
                switch (selectedValue.Id)
                {
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
                    case 17:
                        #region PLUSVALÍAS Y DIVIDENDOS

                        var pPlDividendos = (Param_PlusvaliasDividendos)this.StackConfigParam.Children[0];

                        ParamPlusvaliasDividendos.Descripcion = pPlDividendos.textBoxTitulo.Text;
                       

                        #endregion
                        break;
                    case 25://GRÁFICO I (BENCHMARK)
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region GRÁFICO I (BENCHMARK)
                        var pBenchMark = (Param_GraficoBenchMark)this.StackConfigParam.Children[0];
                        
                        ParamGraficoBenchmark.FechaInicio = pBenchMark.DpFechainicio.SelectedDate;
                        ParamGrafBench_Indices = pBenchMark.Indices;

                        #endregion
                        break;
                    case 27:
                       
                        #region EVOLUCIÓN RENTABILIDAD GUISSONA
                        var pEvoRentabiGuissona = (Param_EvolucionRentabilidadGuissona)this.StackConfigParam.Children[0];

                        ParamEvoRentabiGuissona.Titulo = pEvoRentabiGuissona.textBoxTitulo.Text;
                        //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);
                        ParamEvoRentabiGuissona_Fondos = pEvoRentabiGuissona.parametrosEvoRentabGuissona_Fondos;
                        #endregion
                        break;
                    case 28:

                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)this.StackConfigParam.Children[0];

                        ParamEvoPatriConjGuissona.Titulo = pEvoPatriConjGuissona.textBoxTitulo.Text;
                        //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);
                        ParamEvoPatrimConjGuissona_Fondos = pEvoPatriConjGuissona.parametrosEvPatrimonioConjuntoGuissona_Fondos;
                        #endregion
                        break;
                    case 29:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)this.StackConfigParam.Children[0];

                        ParamEvoPatriGuissona.ComisionDepositaria = decimal.Parse(pEvoPatriGuissona.txtBoxComisionDepositaria.Text);
                        ParamEvoPatriGuissona.TasaGestionAnual = decimal.Parse(pEvoPatriGuissona.txtBoxTasaGestionAnual.Text);

                        #endregion
                        break;
                    case 36:
                        #region RATIOS CARTERA RV (¿SECTORIALS?)
                        var pCarteraRV = (Param_RatiosCarteraRV)this.StackConfigParam.Children[0];
                        ParamRatioCarteraRV.BpaAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text);
                        ParamRatioCarteraRV.BpaAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text);
                        ParamRatioCarteraRV.BpaPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMaximo.Text);
                        ParamRatioCarteraRV.BpaPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMinimo.Text);
                        ParamRatioCarteraRV.DescuentoFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text);
                        ParamRatioCarteraRV.DescuentoFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text);
                        ParamRatioCarteraRV.DeudaNetaCapitalizacionMaximo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text);
                        ParamRatioCarteraRV.DeudaNetaCapitalizacionMinimo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text);
                        ParamRatioCarteraRV.PerAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMaximo.Text);
                        ParamRatioCarteraRV.PerAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMinimo.Text);
                        ParamRatioCarteraRV.PerPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMaximo.Text);
                        ParamRatioCarteraRV.PerPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMinimo.Text);
                        ParamRatioCarteraRV.PrecioVcMaximo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMaximo.Text);
                        ParamRatioCarteraRV.PrecioVcMinimo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMinimo.Text);
                        ParamRatioCarteraRV.RentabilidadesAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text);
                        ParamRatioCarteraRV.RentabilidadesAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text);
                        ParamRatioCarteraRV.RentabilidadesPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text);
                        ParamRatioCarteraRV.RentabilidadesPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text);
                        //ParamRatioCarteraRV.ValorFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMaximo.Text);
                        ParamRatioCarteraRV.ValorFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMinimo.Text);
                        #endregion
                        break;
                }
            }
            #endregion
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


            SeccionId = (int)this.ComboBoxSeccion.SelectedValue;

            #region Parse Params values
                Seccione selectedValue = (Seccione)this.ComboBoxSeccion.SelectedItem;
                if (selectedValue != null)
                {
                    switch (selectedValue.Id)
                    {
                    case 9:
                        #region EVOLUCIÓN MERCADO
                        var pEvoMerca = (Param_EvolucionMercados)this.StackConfigParam.Children[0];
                        
                        ParamEvolucionMercados = pEvoMerca.parametrosEvoMerca;
                        #endregion
                        break;
                    case 25://GRÁFICO I (BENCHMARK)
                    case 45://SITUACIÓN PATRIMONIAL Y RENTABILIDAD
                        #region GRÁFICO I (BENCHMARK)
                        var pBenchMark = (Param_GraficoBenchMark)this.StackConfigParam.Children[0];
                                ParamGraficoBenchmark.FechaInicio = pBenchMark.DpFechainicio.SelectedDate;
                        ParamGrafBench_Indices= pBenchMark.Indices;

                        #endregion
                        break;
                        case 27:

                        #region EVOLUCIÓN RENTABILIDAD GUISSONA
                        var pEvoRentabiGuissona = (Param_EvolucionRentabilidadGuissona)this.StackConfigParam.Children[0];

                        ParamEvoRentabiGuissona.Titulo = pEvoRentabiGuissona.textBoxTitulo.Text;
                        ParamEvoRentabiGuissona_Fondos = pEvoRentabiGuissona.parametrosEvoRentabGuissona_Fondos;
                        //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);

                        #endregion
                        break;
                    case 28:

                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        var pEvoPatriConjGuissona = (Param_EvolucionPatrimonioConjuntoGuissona)this.StackConfigParam.Children[0];

                        ParamEvoPatriConjGuissona.Titulo = pEvoPatriConjGuissona.textBoxTitulo.Text;
                        ParamEvoPatrimConjGuissona_Fondos = pEvoPatriConjGuissona.parametrosEvPatrimonioConjuntoGuissona_Fondos;
                        //ParamEvoRentabiGuissona.TasaGestionAnual = decimal.Parse(pEvoRentabiGuissona.txtBoxTasaGestionAnual.Text);

                        #endregion
                        break;
                    case 29:
                            #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                            var pEvoPatriGuissona = (Param_EvolucionPatrimGuissona)this.StackConfigParam.Children[0];
                        
                            ParamEvoPatriGuissona.ComisionDepositaria = decimal.Parse(pEvoPatriGuissona.txtBoxComisionDepositaria.Text);
                            ParamEvoPatriGuissona.TasaGestionAnual = decimal.Parse(pEvoPatriGuissona.txtBoxTasaGestionAnual.Text);


                            #endregion
                            break;
                    case 36:
                            #region RATIOS CARTERA RV (¿SECTORIALS?)
                                var pCarteraRV = (Param_RatiosCarteraRV)this.StackConfigParam.Children[0];
                                ParamRatioCarteraRV.BpaAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMaximo.Text);
                                ParamRatioCarteraRV.BpaAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxBpaAñoInformeMinimo.Text);
                                ParamRatioCarteraRV.BpaPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMaximo.Text);
                                ParamRatioCarteraRV.BpaPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxBpaPrevisionMinimo.Text);
                                ParamRatioCarteraRV.DescuentoFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMaximo.Text);
                                ParamRatioCarteraRV.DescuentoFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxDescuentoFundamentalMinimo.Text);
                                ParamRatioCarteraRV.DeudaNetaCapitalizacionMaximo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMaximo.Text);
                                ParamRatioCarteraRV.DeudaNetaCapitalizacionMinimo = decimal.Parse(pCarteraRV.txtBoxDeudaNetaCapitalizacionMinimo.Text);
                                ParamRatioCarteraRV.PerAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMaximo.Text);
                                ParamRatioCarteraRV.PerAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxPerAñoInformeMinimo.Text);
                                ParamRatioCarteraRV.PerPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMaximo.Text);
                                ParamRatioCarteraRV.PerPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxPerPrevisionMinimo.Text);
                                ParamRatioCarteraRV.PrecioVcMaximo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMaximo.Text);
                                ParamRatioCarteraRV.PrecioVcMinimo = decimal.Parse(pCarteraRV.txtBoxPrecioVcMinimo.Text);
                                ParamRatioCarteraRV.RentabilidadesAñoInformeMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMaximo.Text);
                                ParamRatioCarteraRV.RentabilidadesAñoInformeMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesAñoInformeMinimo.Text);
                                ParamRatioCarteraRV.RentabilidadesPrevisionMaximo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMaximo.Text);
                                ParamRatioCarteraRV.RentabilidadesPrevisionMinimo = decimal.Parse(pCarteraRV.txtBoxRentabilidadesPrevisionMinimo.Text);
                                //ParamRatioCarteraRV.ValorFundamentalMaximo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMaximo.Text);
                                ParamRatioCarteraRV.ValorFundamentalMinimo = decimal.Parse(pCarteraRV.txtBoxValorFundamentalMinimo.Text);
                        #endregion
                        break;
                    }
                }
            #endregion
            Cancel = false;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
        private bool Correctedtop = false;
        private void ComboBoxSeccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Seccione selectedValue = (Seccione)this.ComboBoxSeccion.SelectedItem;
            if(selectedValue!=null)
            {
                switch (selectedValue.Id)
                {
                   case 9:
                        #region EVOLUCIÓN MERCADOS
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_EvolucionMercados(ParamEvolucionMercados));
                        this.Height = 385;
                        this.Width = 502;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                      
                        this.StackConfigParam.Children.Add(new Param_GraficoBenchMark(ParamGraficoBenchmark, ParamGrafBench_Indices));
                        this.Height = 375;
                        this.Width = 502;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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

                        this.StackConfigParam.Children.Add(new Param_EvolucionRentabilidadGuissona(ParamEvoRentabiGuissona, ParamEvoRentabiGuissona_Fondos));
                        this.Height = 375;
                        this.Width = 502;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 28:

                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_EvolucionPatrimonioConjuntoGuissona (ParamEvoPatriConjGuissona, ParamEvoPatrimConjGuissona_Fondos));
                        this.Height = 375;
                        this.Width = 502;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        #endregion
                        break;
                    case 29:
                        #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                        if (this.StackConfigParam.Children.Count > 0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }

                        this.StackConfigParam.Children.Add(new Param_EvolucionPatrimGuissona(ParamEvoPatriGuissona));
                        this.Height = 375;
                        this.Width = 502;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                        this.StackConfigParam.Children.Add(new Param_RatiosCarteraRV(ParamRatioCarteraRV));
                        this.Height = 528;
                        this.Width = 680;
                        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        this.Top = this.Top - 100;
                        Correctedtop = true;
                        #endregion
                        break;
                    default:
                        if (Correctedtop)
                        {
                            this.Top = this.Top + 100;
                            Correctedtop = false;
                        }
                        if (this.StackConfigParam.Children.Count>0)
                        {
                            this.StackConfigParam.Children.RemoveAt(0);
                        }
                        this.Width = 502;
                        this.Height = 250;
                        break;

                }


            }



        }

    }

}

