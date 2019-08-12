using Reports_IICs.DataModels;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Cartera
{
    /// <summary>
    /// Interaction logic for RatiosCarteraRVWizard.xaml
    /// </summary>
    public partial class RatiosCarteraRVWizard : WizardPage
    {
        public RatiosCarteraRVWizard(Plantilla plantilla, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "Ratios Cartera RV";
        }
    }
}
