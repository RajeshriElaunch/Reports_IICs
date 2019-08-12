using Reports_IICs.DataAccess.Instrumentos;
using System.Windows.Controls;
using Reports_IICs.Helpers;

namespace Reports_IICs.Pages
{
    /// <summary>
    /// Interaction logic for Listado.xaml
    /// </summary>
    public partial class Listado : UserControl
    {
        private Utils.Elemento _elemento;

        public Listado()
        {
            InitializeComponent();
            _elemento = Utils.Elemento.Instrumentos_Categorias;
            populateData();
        }

        private void populateData()
        {
            switch(_elemento)
            {
                case Utils.Elemento.Instrumentos_Categorias:
                    this.DataGridListado.ItemsSource = InstrumentosCategorias_DA.GetAll();
                    
                    break;
            }
        }
    }
}
