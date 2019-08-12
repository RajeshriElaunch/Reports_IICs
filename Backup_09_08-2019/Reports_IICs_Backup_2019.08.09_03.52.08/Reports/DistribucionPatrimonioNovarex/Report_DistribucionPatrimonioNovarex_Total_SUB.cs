namespace Reports_IICs.Reports.DistribucionPatrimonioNovarex
{
    /// <summary>
    /// Summary description for Report_DistribucionPatrimonioNovarex_Total_SUB.
    /// </summary>
    public partial class Report_DistribucionPatrimonioNovarex_Total_SUB : Telerik.Reporting.Report
    {
        public Report_DistribucionPatrimonioNovarex_Total_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_DistribucionPatrimonioNovarex_Total_SUB(string CodigoIc)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            this.ReportParameters["CodigoIC"].Value = CodigoIc;

            this.sqlDataSource1.Parameters[0].Value = CodigoIc;
        }

    }
}