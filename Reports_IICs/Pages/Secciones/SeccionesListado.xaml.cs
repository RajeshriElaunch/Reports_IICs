using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Reports_IICs.Pages.Secciones
{
    /// <summary>
    /// Interaction logic for SeccionesListado.xaml
    /// </summary>
    public partial class SeccionesListado : UserControl
    {
        public SeccionesListado()
        {
            InitializeComponent();
            populateData();
        }

        private void populateData()
        {
            this.DataGridListado.ItemsSource = Secciones_DA.GetAll();
            this.radGridViewListado.ItemsSource = Secciones_DA.GetAll();
        }

        private void DataGridListado_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new SeccionDetalle(45));
        }

        private void DataGridListado_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;

            var cellValue = grid.SelectedValue;
            int? id = ((Seccione)(cellValue)).Id;
            //NavigationCommands.GoToPage.Execute(new SeccionDetalle(id), this);
            App.Current.Properties["IdSeccion"] = id;

            //NavigationCommands.GoToPage.Execute("/Pages/Secciones/SeccionDetalle.xaml?Id=" + id, this);
            NavigationCommands.GoToPage.Execute("/Pages/Secciones/SeccionDetalle.xaml", this);

            //NavigationService.na
            
        }

        protected virtual void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            //DoYourStuff(e.Fragment)
        }
    }
}
