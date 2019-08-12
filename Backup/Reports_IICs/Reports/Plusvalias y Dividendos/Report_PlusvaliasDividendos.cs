namespace Reports_IICs.Reports.Plusvalias_y_Dividendos
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_PlusvaliasDividendos.
    /// </summary>
    public partial class Report_PlusvaliasDividendos : Telerik.Reporting.Report
    {
        public Report_PlusvaliasDividendos()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_PlusvaliasDividendos(DateTime FechaReporte)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.ReportParameters["FechaReporte"].Value = FechaReporte;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Report_PlusvaliasDividendos_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }
    }
}