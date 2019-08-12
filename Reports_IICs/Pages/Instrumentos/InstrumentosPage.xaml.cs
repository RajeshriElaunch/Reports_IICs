using System.Windows.Controls;

namespace Reports_IICs.Pages.Instrumentos
{
    /// <summary>
    /// Interaction logic for InstrumentosPage.xaml
    /// </summary>
    public partial class InstrumentosPage : UserControl
    {
        public InstrumentosPage()
        {
            InitializeComponent();
        }

        private void ModernTabInstrucciones_SelectedSourceChanged(object sender, FirstFloor.ModernUI.Windows.Controls.SourceEventArgs e)
        {
            if (e.Source.OriginalString.EndsWith("ListadoPrueba.xaml"))
            {
                

            }
        }
    }
}
