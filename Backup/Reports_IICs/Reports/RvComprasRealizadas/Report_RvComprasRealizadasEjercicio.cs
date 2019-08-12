using Reports_IICs.Helpers;

namespace Reports_IICs.Reports.RvComprasRealizadas
{
    /// <summary>
    /// Summary description for Report_RvComprasRealizadasEjercicio.
    /// </summary>
    public partial class Report_RvComprasRealizadasEjercicio : Telerik.Reporting.Report
    {
        public Report_RvComprasRealizadasEjercicio()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            
        }

        private void Report_RvComprasRealizadasEjercicio_ItemDataBinding(object sender, System.EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }

}