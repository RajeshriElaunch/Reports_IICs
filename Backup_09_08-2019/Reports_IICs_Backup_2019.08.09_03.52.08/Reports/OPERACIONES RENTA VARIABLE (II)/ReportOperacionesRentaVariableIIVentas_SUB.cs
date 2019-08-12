namespace Reports_IICs.Reports.OPERACIONES_RENTA_VARIABLE__II_
{
    /// <summary>
    /// Summary description for ReportOperacionesRentaVariableIIVentas_SUB.
    /// </summary>
    public partial class ReportOperacionesRentaVariableIIVentas_SUB : Telerik.Reporting.Report
    {
        public ReportOperacionesRentaVariableIIVentas_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportOperacionesRentaVariableIIVentas_SUB(string isin, string codigoic, string tipoMov)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["Isin"].Value = null;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["TipoMovimiento"].Value = tipoMov;

            this.sqlDataSource1.Parameters[0].Value = codigoic;
            //this.sqlDataSource1.Parameters[1].Value = isin;
            this.sqlDataSource1.Parameters[1].Value = null;
            this.sqlDataSource1.Parameters[2].Value = tipoMov;
        }
    }
}