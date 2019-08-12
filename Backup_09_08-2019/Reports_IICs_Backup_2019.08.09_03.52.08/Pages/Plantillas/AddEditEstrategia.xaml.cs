using MahApps.Metro.Controls;
using Reports_IICs.DataModels;
using System.Windows;
using System.Linq;
using Reports_IICs.ViewModels;
using Reports_IICs.ViewModels.Instrumentos;

namespace Reports_IICs.Pages.Plantillas
{
    /// <summary>
    /// Interaction logic for AddEditTipoInstrum.xaml
    /// </summary>
    public partial class AddEditEstrategia : MetroWindow
    {
        public bool Cancel = true;
        public DataViewModelCombo Dataitems = new DataViewModelCombo();
        public AddEditEstrategia(Plantilla plantilla)
        {
            InitializeComponent();

            //var añadidas = plantilla.Plantillas_Estrategias.Select(s=>s.IdTipoInstrumento);
            //var restantes = Estrategias_VM.GetEstrategias().Where(w => !añadidas.Contains(w.Id));
            var estratPlant = plantilla.Plantillas_Estrategias.Select(s=>s.IdTipoInstrumento);
            var restantes = Estrategias_VM.GetEstrategias().Where(w=> !estratPlant.Contains(w.IdTipoInstrumento));
            
            var its = InstrumentosTipos_VM.GetAll();
            foreach (var item in restantes)
            {
                var it = its.Where(w => w.Id == item.IdTipoInstrumento).FirstOrDefault();
                var desc = it.Descripcion;

                var estrategia = new Plantillas_Estrategias();
                estrategia.CodigoIC = plantilla.CodigoIc;
                estrategia.IdTipoInstrumento = item.IdTipoInstrumento;
                estrategia.Descripcion = desc;
                
                //Utils.CopyPropertyValues(it, estrategia.Instrumentos_Tipos);

                Dataitems.DataItemsCombo.Add(new DataItemCombo()
                {
                    Text = desc,
                    Item = estrategia
                });

            }

            ComboBoxEstrategia.ItemsSource = Dataitems.DataItemsCombo;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();

            //this.HideMetroDialogAsync(this, [MetroDialogSettings settings = null]);
        }
  
        private void AddElement_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (Dataitems.DataItemsCombo.Where(w=>w.IsChecked).Count() > 0)
            {
                e.Handled = true;
                e.CanExecute = true;
            }
        }   

        private void AddElement_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Cancel = false;
            e.Handled = true;
            this.Close();
        }
    }
}
