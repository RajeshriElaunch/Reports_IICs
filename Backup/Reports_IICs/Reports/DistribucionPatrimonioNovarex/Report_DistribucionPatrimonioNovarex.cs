namespace Reports_IICs.Reports.DistribucionPatrimonioNovarex
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_DistribucionPatrimonioNovarex.
    /// </summary>
    public partial class Report_DistribucionPatrimonioNovarex : Telerik.Reporting.Report
    {

       
        public Report_DistribucionPatrimonioNovarex()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            /*
            Telerik.Reporting.Report repCartera = new Report_DistribucionPatrimonioNovarex_Cartera_SUB( codigoIc);
            Telerik.Reporting.Report repTesoreria = new Report_DistribucionPatrimonioNovarex_Tesoreria_SUB(codigoIc);
            Telerik.Reporting.Report repTotal = new Report_DistribucionPatrimonioNovarex_Total_SUB(codigoIc);
            this.subReportCartera.ReportSource = repCartera;
            this.subReportTesoreria.ReportSource = repTesoreria;
            this.subReportTotal.ReportSource = repTotal;
            */
        }

        private void Report_DistribucionPatrimonioNovarex_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}