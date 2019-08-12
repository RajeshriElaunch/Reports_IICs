namespace Reports_IICs.Reports.IndicePreconfiguradoNovarex
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_IndicePreconfiguradoNovarex.
    /// </summary>
    public partial class Report_IndicePreconfiguradoNovarex : Telerik.Reporting.Report
    {
        public Report_IndicePreconfiguradoNovarex()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_IndicePreconfiguradoNovarex(string codigoIC)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.ReportParameters["CodigoIC"].Value = codigoIC;
        }

        private void Report_IndicePreconfiguradoNovarex_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }
    }
}