using MahApps.Metro.Controls;
using Reports_IICs.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows;

namespace Reports_IICs.Pages.Informes
{
    /// <summary>
    /// Lógica de interacción para ShowError.xaml
    /// </summary>
    public partial class ShowError : MetroWindow
    {
        private List<string> _lista = null;
        public ShowError()
        {
            InitializeComponent();
        }

        public ShowError(string HeaderMessage,string ErrorDescription, List<string> lista = null)
        {
            InitializeComponent();
            this.lbl_header_error.Content = HeaderMessage;
            this.TBox_Error_descript.Text = ErrorDescription;
            _lista = lista;
            if(_lista == null)
            {
                this.btn_Export.Visibility = Visibility.Hidden;
            }
        }

        private void btn_CopyClip_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.TBox_Error_descript.Text);
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            if (_lista != null)
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;

                int millisecondsTimeout = 500;
                var result = Pages.Informes.ProgressDialog.ProgressDialog.Execute(main, "Abriendo Excel", () =>
                {
                    DataTable dt = Utils.ConvertListToDataTable(_lista, "Instrumentos no importados");
                    UtilsExcel.Export2Excel(dt);
                    Thread.Sleep(millisecondsTimeout);
                });
            }
        }
    }
}
