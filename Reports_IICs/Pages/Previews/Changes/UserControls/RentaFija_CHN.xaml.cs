using Reports_IICs.DataAccess.Secciones;
using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace Reports_IICs.Pages.Previews.Changes.UserControls
{
    /// <summary>
    /// Interaction logic for RentaFija_CHN.xaml
    /// </summary>
    public partial class RentaFija_CHN : UserControl
    {
        public RentaFija_CHN(string codigoIC, DateTime fechaInforme)
        {
            InitializeComponent();            

            try
            {
                var source = RentaFija_DA.GetPreviewChanges(codigoIC, fechaInforme).ToList();
                //IEnumerable<object> source = new Preview_RentaFija_MNG().GetByCodigoIC(codigoIC, true).ToList();
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
