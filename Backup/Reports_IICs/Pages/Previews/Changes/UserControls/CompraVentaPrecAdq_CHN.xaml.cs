using Reports_IICs.DataAccess.Reports;
using System;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace Reports_IICs.Pages.Previews.Changes.UserControls
{
    /// <summary>
    /// Interaction logic for RentaFija_CHN.xaml
    /// </summary>
    public partial class CompraVentaPrecAdq_CHN : UserControl
    {
        public CompraVentaPrecAdq_CHN(string codigoIC, DateTime fechaInforme)
        {
            InitializeComponent();            

            try
            {
                var source = CompraVentaRespectoPrecioAdquisicion_DA.GetPreviewChanges(codigoIC, fechaInforme);
                this.RadGridView1.ItemsSource = source;

                var descriptor = new GroupDescriptor();
                descriptor.Member = "Modificacion";
                RadGridView1.GroupDescriptors.Add(descriptor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
