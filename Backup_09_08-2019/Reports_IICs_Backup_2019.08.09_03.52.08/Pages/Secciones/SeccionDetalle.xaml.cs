using FirstFloor.ModernUI.Windows.Navigation;
using System.Windows.Controls;


namespace Reports_IICs.Pages.Secciones
{    
    /// <summary>
    /// Interaction logic for SeccionDetalle.xaml
    /// </summary>
    public partial class SeccionDetalle : UserControl
    {
        private int _id;

        public SeccionDetalle()
        {
            InitializeComponent();
            _id = (int)App.Current.Properties["IdSeccion"];
            //this.frag += OnFragmentNavigation;
            
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            //DoYourStuff(e.Fragment)
        }
    }
}
