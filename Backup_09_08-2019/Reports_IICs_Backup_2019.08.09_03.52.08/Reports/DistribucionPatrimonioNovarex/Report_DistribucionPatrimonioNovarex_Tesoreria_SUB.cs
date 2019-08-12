namespace Reports_IICs.Reports.DistribucionPatrimonioNovarex
{
    /// <summary>
    /// Summary description for Report1_DistribucionPatrimonioNovarex_Tesoreria_SUB.
    /// </summary>
    public partial class Report_DistribucionPatrimonioNovarex_Tesoreria_SUB : Telerik.Reporting.Report
    {
        public Report_DistribucionPatrimonioNovarex_Tesoreria_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public Report_DistribucionPatrimonioNovarex_Tesoreria_SUB(string CodigoIc)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

           
            this.ReportParameters["CodigoIC"].Value = CodigoIc;
           
            this.sqlDataSource1.Parameters[0].Value = CodigoIc;

        }

       
    }
}