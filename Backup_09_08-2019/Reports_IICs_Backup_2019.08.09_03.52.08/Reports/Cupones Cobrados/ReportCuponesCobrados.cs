namespace Reports_IICs.Reports.Cupones_Cobrados
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCuponesCobrados.
    /// </summary>
    public partial class ReportCuponesCobrados : Telerik.Reporting.Report
    {
        public ReportCuponesCobrados()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportCuponesCobrados_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }
    }
}