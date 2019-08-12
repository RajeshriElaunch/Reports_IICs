namespace Reports_IICs.Reports.COMPRA_VENTA
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCompraVenta2.
    /// </summary>
    public partial class ReportCompraVenta : Telerik.Reporting.Report
    {
        public ReportCompraVenta()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportCompraVenta_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
            Utils.CenterPanel(codigoIC, this.Report, this.panel4);
        }
    }
}