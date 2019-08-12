using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reports_IICs.Pages
{
    /// <summary>
    /// Interaction logic for ventana.xaml
    /// </summary>
    public partial class ventana : MetroWindow
    {
        public string Nombre;
        public ventana()
        {
            InitializeComponent();
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            Nombre = this.textBoxNombre.Text;
            this.Close();
        }
    }
}
