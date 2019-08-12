namespace Reports_IICs.Reports.CARTERA_RF
{
    using System;

    /// <summary>
    /// Summary description for ReportCARTERA_RF.
    /// </summary>
    public partial class ReportCARTERA_RF : Telerik.Reporting.Report
    {
        public ReportCARTERA_RF()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportCARTERA_RF(string CodigoIC,DateTime FechaReporte)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //this.ReportParameters["FechaReporte"].Value = FechaReporte;
            //this.ReportParameters["CodigoIC"].Value = CodigoIC;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //Telerik.Reporting.Report repCPLAZO = new ReportCARTERA_RF_CPLAZO();
            //Telerik.Reporting.Report repLPLAZO = new ReportCARTERA_RF_LPLAZO();

            //this.subReportCPLAZO.ReportSource = repCPLAZO;
            //this.subReportCPLAZO.Parameters["FechaInforme"].Value = FechaReporte;
            //this.subReportCPLAZO.Parameters["CodigoIC"].Value = CodigoIC;

            //this.subReportLPLAZO.ReportSource = repLPLAZO;
            //this.subReportLPLAZO.Parameters["FechaInforme"].Value = FechaReporte;
            //this.subReportLPLAZO.Parameters["CodigoIC"].Value = CodigoIC;


        }
    }
}