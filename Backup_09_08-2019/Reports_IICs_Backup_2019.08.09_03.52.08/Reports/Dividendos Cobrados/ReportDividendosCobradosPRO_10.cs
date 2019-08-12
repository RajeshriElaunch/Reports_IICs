namespace Reports_IICs.Reports.Dividendos_Cobrados
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportDividendosCobradosPRO_10.
    /// </summary>
    public partial class ReportDividendosCobradosPRO_10 : Telerik.Reporting.Report
    {
        public ReportDividendosCobradosPRO_10()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportDividendosCobradosPRO_10_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }
    }
}