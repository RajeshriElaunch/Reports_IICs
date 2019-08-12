using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;
using Reports_IICs.Resources;
using Reports_IICs.ViewModels.Plantillas;


namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Interaction logic for PlantillaDetalle.xaml
    /// </summary>
    public partial class PlantillaDetalle : UserControl, IContent
    {
        private int _idPlantilla;
        private Plantilla _plantilla = new Plantilla();

        public PlantillaDetalle()
        {
            InitializeComponent();

        }


        private void ButtonAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.RadAutoCompleteBoxIsin.SearchText))
            {
                añadirIsins(this.RadAutoCompleteBoxIsin.SearchText);
            }
        }

        private void añadirIsins(string isin)
        {
            if (!string.IsNullOrEmpty(isin))
            {
                var inputText = this.RadAutoCompleteBoxIsin.SearchText;
                var itemsSource = this.RadAutoCompleteBoxIsin.ItemsSource as List<Plantillas_Isins>;
                if (itemsSource == null)
                {
                    itemsSource = new List<Plantillas_Isins>();
                }
                var newItem = new Plantillas_Isins() { Isin = isin };
                if (!itemsSource.Any(item => item.Isin == newItem.Isin))
                {
                    itemsSource.Add(newItem);
                    this.RadAutoCompleteBoxIsin.ItemsSource = itemsSource;
                    this.RadAutoCompleteBoxIsin.SelectedItem = newItem;
                }
            }
        }

        private void populateData()
        {
            this.ComboBoxTipo.SelectedValue = _plantilla.IdTipo;
            this.TextBoxCodigoIc.Text = _plantilla.CodigoIc;
            if (_plantilla.IdTipo != null)
            {
                mostrarIsin(_plantilla.IdTipo);
                //Si es un FONDO
                if (StackPanelIsin.Visibility == System.Windows.Visibility.Visible)
                {
                    foreach (Plantillas_Isins isin in _plantilla.Plantillas_Isins)
                    {
                        añadirIsins(isin.Isin);
                    }
                }
            }
            this.DatePickerFechaCreacion.SelectedDate = _plantilla.FechaCreacion;
            this.TextBoxDescripcion.Text = _plantilla.Descripcion;
        }

        private void mostrarIsin(int? codigoIc)
        {
            if (codigoIc == 2)
            {
                this.StackPanelIsin.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.StackPanelIsin.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            if (e.Fragment != "0")
            {
                 _idPlantilla = int.Parse(e.Fragment);

                //_plantilla = Plantillas_DA.GetPlantilla(_idPlantilla);
                _plantilla = Plantillas_DA.GetPlantilla(e.Fragment);
                populateData();
            }
            else
            {

            }
        }
        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBoxCodigoIc.Text))
            {
                //int? idTipo = null;
                //if (this.ComboBoxTipo.SelectedValue != null)
                //{
                //    idTipo = ((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id;
                //}

                int idTipo = Convert.ToInt32(((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id);
                _plantilla.IdTipo = idTipo;
                _plantilla.CodigoIc = this.TextBoxCodigoIc.Text;

                List<Plantillas_Isins> listaIsins = new List<Plantillas_Isins>();
                listaIsins = this.RadAutoCompleteBoxIsin.SelectedItems.Cast<Plantillas_Isins>().ToList<Plantillas_Isins>();
                ////Ponemos a todos los ISINs el mismo CodigoIC
                //listaIsins.ForEach(i => i.IdPlantilla = this.TextBoxCodigoIc.Text);

                _plantilla.Plantillas_Isins = listaIsins;
                _plantilla.FechaCreacion = Convert.ToDateTime(this.DatePickerFechaCreacion.SelectedDate);
                _plantilla.Descripcion = this.TextBoxDescripcion.Text;

                PlantillaDetalle_VM.GuardarPlantilla(_plantilla);

            }
            else
            {
                string mensaje = Resource.CodigoIcObligatorio_Mens;
                MessageBox.Show(mensaje, "Reports IICs", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ComboBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mostrarIsin(((Reports_IICs.DataModels.Tipos)(this.ComboBoxTipo.SelectedItem)).Id);
        }

    }
}
