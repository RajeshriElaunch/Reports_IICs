using Reports_IICs.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Secciones
{
    /// <summary>
    /// Interaction logic for SeccionesPage.xaml
    /// </summary>
    public partial class SeccionesPage : UserControl
    {
        public SeccionesPage()
        {
            InitializeComponent();
        }

        private void ModernTabSecciones_SelectedSourceChanged(object sender, FirstFloor.ModernUI.Windows.Controls.SourceEventArgs e)
        {
            if (e.Source.OriginalString.EndsWith("ListadoPrueba.xaml"))
            {
                NavigationCommands.GoToPage.Execute("/Pages/ListadoPrueba.xaml#" + Utils.Elemento.Secciones, this);
                
            }
        }
    }
}
