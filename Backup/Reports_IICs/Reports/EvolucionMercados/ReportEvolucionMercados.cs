namespace Reports_IICs.Reports.EvolucionMercados
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportEvolucionMercados.
    /// </summary>
    public partial class ReportEvolucionMercados : Telerik.Reporting.Report
    {
        public ReportEvolucionMercados()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportEvolucionMercados_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
        }
    }
}