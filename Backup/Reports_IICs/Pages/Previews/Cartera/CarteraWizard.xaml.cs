using Reports_IICs.DataModels;
using System.Windows.Controls;
using System.Linq;
using System;
using System.Collections.Generic;
using Reports_IICs.DataAccess.Reports;
using Telerik.Windows.Controls;
using System.Windows.Threading;
using System.Windows;

namespace Reports_IICs.Pages.Previews.Cartera
{
    /// <summary>
    /// Interaction logic for CarteraWizard.xaml
    /// </summary>
    public partial class CarteraWizard : WizardPage
    {
        private Plantilla _plantilla;
        private DateTime _fecha;
        MainWindow main = (MainWindow)Application.Current.MainWindow;
        public CarteraWizard(Plantilla plantilla, DateTime fecha)
        {

            _plantilla = plantilla;
            _fecha = fecha;
            InitializeComponent();
            this.labelTitulo.Content = "CARTERA A " + fecha.ToShortDateString();
            //Al entrar recuperamos los datos del procedimiento PRO_11 y los copiamos en
            //Temp_PRO_11
            //A partir de aquí sólo seguimos con Temp_PRO_11
            //var pro11Result = Cartera_DA.GetPRO11(plantilla.CodigoIc).ToList();
            var pro11Temp = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc, string.Empty).ToList();


            if (pro11Temp.Count > 0)
            {
                //Insertamos el resultado en la tabla temporal Temp_PRO_11
                //Cartera_VM.Insert_Temp_PRO_11(pro11Result, plantilla.CodigoIc, fecha);

                //Pintamos la preview de PRO_11
                populatePreviewPRO_11(plantilla.CodigoIc, pro11Temp);

                //Pintamos la preview de PRO_12. Permitimos 3 PRO_12_UC por línea            
                populatePreviewPRO_12(plantilla.CodigoIc, plantilla.Plantillas_Isins.ToList(), fecha);
            }            
        }        

        private void populatePreviewPRO_11(string codigoIC, List<Temp_PRO_11> tempPro11Result)
        {
            var distinctTipos = tempPro11Result.Select(p => p.Tipo).Distinct().ToList();
            for (int i = 0; i < distinctTipos.Count; i++)
            {
                this.MyStackPanelVertical.Children.Add(new PRO_11_UC(codigoIC, distinctTipos[i]));
            }
        }
        private void populatePreviewPRO_12(string codigoIC, List<Plantillas_Isins> isins, DateTime fecha)
        {
            StackPanel myStackPanelHorizontal = new StackPanel();
            int cont = 1;
            foreach (var isin in isins)
            {
                if (cont == 1 || cont % 3 == 1)
                {
                    myStackPanelHorizontal = new StackPanel();
                    myStackPanelHorizontal.Orientation = Orientation.Horizontal;
                }

                var tempPro12 = Cartera_DA.GetTemp_PRO_12(codigoIC, isin.Isin).FirstOrDefault();

                if (tempPro12 != null)
                {
                    myStackPanelHorizontal.Children.Add(new PRO_12_UC(codigoIC, isin.Isin, fecha, tempPro12));
                }

                if (cont % 3 == 0 || cont == isins.Count)
                {
                    this.MyStackPanelVertical.Children.Add(myStackPanelHorizontal);
                }

                cont++;
            }
        }

        private void MyStackPanelVertical_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
          
            Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => main.PanelCloseCommand.Execute(null)));

            //Action StartLoop;
            //StartLoop = () => DoLongRunningProcess();

            //Thread t;

            //t = new Thread(StartLoop.Invoke);
            //t.Start();
        }

        private void DoLongRunningProcess()
        {
            Dispatcher.Invoke(DispatcherPriority.Send, (Action)(() => main.ShowPanelCommand.Execute(null)));

        }
    }
}
