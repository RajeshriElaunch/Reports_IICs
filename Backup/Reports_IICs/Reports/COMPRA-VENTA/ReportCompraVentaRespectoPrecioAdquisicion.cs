namespace Reports_IICs.Reports.COMPRA_VENTA
{
    /// <summary>
    /// Summary description for ReportCompraVentaRespectoPrecioAdquisicion.
    /// </summary>
    public partial class ReportCompraVentaRespectoPrecioAdquisicion : Telerik.Reporting.Report
    {
        public ReportCompraVentaRespectoPrecioAdquisicion()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportCompraVentaRespectoPrecioAdquisicion(string isin, string codigoic)
        {

            InitializeComponent();
            /*this.ReportParameters["Isin"].Value =null;
            this.ReportParameters["CodigoIC"].Value = codigoic;

            this.sqlDataSource1.Parameters[0].Value = codigoic;

            this.sqlDataSource1.Parameters[1].Value = null;
            */

        }


    }

   
}