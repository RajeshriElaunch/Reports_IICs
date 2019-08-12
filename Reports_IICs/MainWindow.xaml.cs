using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;
using Reports_IICs.Pages.Importar;
using Reports_IICs.Pages;
using Reports_IICs.Pages.Plantillas;
using Reports_IICs.ViewModels.Reports;
using Reports_IICs.DataModels;
using System.Windows.Input;
using Reports_IICs.Pages.Informes.Manager;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using log4net;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.Helpers;
using Telerik.Windows.Controls;
using Reports_IICs.Resources;

namespace Reports_IICs
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string MainMessage = "Main Loading Message";
        public string SubMessage = "Sub Loading Message";

        private bool _panelLoading;
        private string _panelMainMessage = "Main Loading Message";
        private string _panelSubMessage = "Sub Loading Message";

        public ILog Logger { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            pintarInterfazDesarrollo();      
            //Utils.PruebasExcel();

            DataContext = this;

            this.Logger = LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            log4net.Config.XmlConfigurator.Configure();

            this.Logger.Info("Inicio de la app");

            OpenFlyoutPanelCommand = new Pages.Informes.HelperClasses.DelegateCommand(OpenFlyoutPanel);            
        }

        /// <summary>
        /// Si estamos utilizando una conexión de desarrollo (pre-producción) mostraremos un diseño distinto para que el usuario
        /// sea consciente. En caso de tener las conexiones de Producción no tocamos no nada.      
        /// </summary>
        private void pintarInterfazDesarrollo()
        {
            if(Utils.EsDesarrollo())
            {
                //Pintamos de rojo el menú 
                this.RadMenuMain.Background = System.Windows.Media.Brushes.Red;
                
                foreach (var item in RadMenuMain.Items)
                {
                    var rmi = (RadMenuItem)item;
                    rmi.Background = System.Windows.Media.Brushes.Red;
                }

                //Alertamos de que estamos conectados a desarrollo
                RadWindow.Alert(new TextBlock { Text = Resource.ConexionDesarrollo, TextWrapping = TextWrapping.Wrap, Width = 400 });
            } 
        }
        #region bottonpannel
        public event PropertyChangedEventHandler PropertyChanged;

        public bool PanelLoading
        {
            get
            {
                return _panelLoading;
            }
            set
            {
                _panelLoading = value;
                RaisePropertyChanged("PanelLoading");
            }
        }

        /// <summary>
        /// Gets or sets the panel main message.
        /// </summary>
        /// <value>The panel main message.</value>
        public string PanelMainMessage
        {
            get
            {
                return _panelMainMessage;
            }
            set
            {
                _panelMainMessage = value;
                RaisePropertyChanged("PanelMainMessage");
            }
        }

        /// <summary>
        /// Gets or sets the panel sub message.
        /// </summary>
        /// <value>The panel sub message.</value>
        public string PanelSubMessage
        {
            get
            {
                return _panelSubMessage;
            }
            set
            {
                _panelSubMessage = value;
                RaisePropertyChanged("PanelSubMessage");
            }
        }

        /// <summary>
        /// Gets the panel close command.
        /// </summary>
        public ICommand PanelCloseCommand
        {
            get
            {
                return new Pages.Informes.HelperClasses.DelegateCommand(() =>
                {
                    // Your code here.
                    // You may want to terminate the running thread etc.
                    PanelLoading = false;
                });
            }
        }

        /// <summary>
        /// Gets the show panel command.
        /// </summary>
        public ICommand ShowPanelCommand
        {
            get
            {
                return new Pages.Informes.HelperClasses.DelegateCommand(() =>
                {
                    PanelLoading = true;
                });
            }
        }


        /// <summary>
        /// Gets the hide panel command.
        /// </summary>
        public ICommand HidePanelCommand
        {
            get
            {
                return new Pages.Informes.HelperClasses.DelegateCommand(() =>
                {
                    PanelLoading = false;
                });
            }
        }

        /// <summary>
        /// Gets the change sub message command.
        /// </summary>
        public ICommand ChangeSubMessageCommand
        {
            get
            {
                return new Pages.Informes.HelperClasses.DelegateCommand(() =>
                {
                    PanelSubMessage = string.Format("Message: {0}", DateTime.Now);
                });
            }
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public ICommand OpenFlyoutPanelCommand { get; private set; }

        private void OpenFlyoutPanel()
        {
            /* This is just to demostrate the loading panel.
               
               Note: When closing ('IsLoading = false') is called, it will wait for 1.0s before the loading panel slides back.
               You can change the amount of time before it close in Resources\LoadingFlyoutStyle.xaml.
            */

            LoadingPanelManager.Instance.Show(MainMessage, SubMessage);
            LoadingPanelManager.Instance.IsLoading = false;
            // this.ToggleFlyout(0); 
        }

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        private void Excel_Instrumentos_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ImportarInstrumentos());
        }

        private void Excel_Bloomberg_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ImportarBloomberg());
        }
        private void Secciones_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.Secciones));
            //LoadContent(new UserControlPrueba());
        }

        private void Sectores_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosSectores));
        }

        private void Empresas_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosEmpresas));
        }

        private void Frame_OnNavigated(object sender, NavigationEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(700))
            };
            //Frame.BeginAnimation(OpacityProperty, animation);
        }

        public void LoadContent(UserControl uc)
        {
            this.ContentControlMain.Content = null;
            this.ContentControlMain.Content = uc;
        }

        public void LoadContent(MetroWindow uc)
        {
            this.ContentControlMain.Content = uc;
        }

        public void LoadContent(Object obj)
        {
            if (obj != null)
            {
                Type tipo = obj.GetType().BaseType;
                if (tipo == typeof(UserControl))
                {
                    LoadContent((UserControl)obj);
                }
                else if (tipo == typeof(MetroWindow))
                {
                    LoadContent((MetroWindow)obj);
                }
            }
        }

        public void CloseContent()
        {
            this.ContentControlMain.Content = null;
        }
        private void RadMenuItemPlantillasInforme_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new PlantillasPage(Helpers.Utils.Elemento.Plantillas));
        }

        private void RadMenuItemMaestrosCategorias_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosCategorias));
        }

        private void RadMenuItemMaestrosInstrumentos_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.Instrumentos));
        }

        private void RadMenuItemMaestrosPaises_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosPaises));
        }

        private void RadMenuItemMaestrosTipos_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosTipos));
        }

        private void RadMenuItemMaestrosZonas_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosZonas));
        }

        private void RadMenuItemMaestrosDivisas_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosDivisas));
        }

        private void RadMenuItemVerDatosIntrumentos_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.InstrumentosImportados));
        }

        private void RadMenuItemVerDatosBloomberg_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ListadoPrueba(Helpers.Utils.Elemento.BloombergImportados));
        }



        private void RadMenuItemGenerarInforme_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            try
            {
                Plantilla plantilla = null;
                DateTime? fechaInforme = null;
                bool verUltimoGenerado = false;

                //var window = new ChooseReport(true);
                ReportVM.ChoosePlantilla(out plantilla, out fechaInforme, verUltimoGenerado);

                if (plantilla != null)
                {
                    ReportVM.ShowReportOrLastGenerated(plantilla, fechaInforme, verUltimoGenerado);
                }
            }
            catch(Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Report_VM/ShowReportOrLastGenerated", ex);
                // Compliance                                           
                throw;
            }
        }   


        private void RadMenuItemVerUltimoInforme_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            try
            {
                Plantilla plantilla = null;
                DateTime? fecha = null;
                bool verUltimoGenerado = true;

                ReportVM.ChoosePlantilla(out plantilla, out fecha, verUltimoGenerado);

                if (plantilla != null)
                {
                    //ShowPanelCommand.Execute(null);
                    //OpenFlyoutPanelCommand.Execute(null);
                    ReportVM.ShowReportOrLastGenerated(plantilla, fecha, verUltimoGenerado);
                }
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Report_VM/ShowReportOrLastGenerated", ex);
                // Compliance                                           
                throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var plantilla = Plantillas_DA.GetPlantilla("403");
            var fechaInforme = new DateTime(2016, 12, 31);
            ReportVM.ShowReportOrLastGenerated(plantilla, fechaInforme, false);
        }        

        private void Excel_EquivalenciasIsins_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            LoadContent(new ImportarEquivalenciasIsins());
        }
    }
}
