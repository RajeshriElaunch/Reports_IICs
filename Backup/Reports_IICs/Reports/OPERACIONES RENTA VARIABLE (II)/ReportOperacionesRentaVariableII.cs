namespace Reports_IICs.Reports.OPERACIONES_RENTA_VARIABLE__II_
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportOperacionesRentaVariableII.
    /// </summary>
    public partial class ReportOperacionesRentaVariableII : Telerik.Reporting.Report
    {
        public ReportOperacionesRentaVariableII()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportOperacionesRentaVariableII(string codigoIc, string isin)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            Telerik.Reporting.Report repCompras = new ReportOperacionesRentaVariableIICompras_SUB(null, codigoIc, "Compra");
            Telerik.Reporting.Report repVentas = new ReportOperacionesRentaVariableIIVentas_SUB(null, codigoIc, "Venta");

            this.subReportCompras.ReportSource = repCompras;
            this.subReportVentas.ReportSource = repVentas;
        }

        private void ReportOperacionesRentaVariableII_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
        }
    }
}