namespace Reports_IICs.Reports.Subscripciones_Reembolsos
{
    /// <summary>
    /// Summary description for ReportSubscripciones_SUB.
    /// </summary>
    public partial class ReportSubscripciones_SUB : Telerik.Reporting.Report
    {
        public ReportSubscripciones_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportSubscripciones_SUB(string isin, string codigoic, string tipoMov)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["TipoMovimiento"].Value = tipoMov;

            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = isin;
            this.sqlDataSource1.Parameters[2].Value = tipoMov;


        }
    }
}