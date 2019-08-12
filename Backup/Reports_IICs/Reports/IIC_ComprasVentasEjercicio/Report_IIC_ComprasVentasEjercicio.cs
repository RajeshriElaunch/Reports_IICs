namespace Reports_IICs.Reports.IIC_ComprasVentasEjercicio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_IIC_ComprasVentasEjercicio.
    /// </summary>
    public partial class Report_IIC_ComprasVentasEjercicio : Telerik.Reporting.Report
    {
        public Report_IIC_ComprasVentasEjercicio()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_IIC_ComprasVentasEjercicio(string codigoIc, string isin, DateTime FechaUltimoInforme, DateTime FechaInforme)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            Telerik.Reporting.Report repCompras = new Report_IIC_ComprasEjercicio_SUB(isin, codigoIc, "Compra", FechaUltimoInforme, FechaInforme);
            Telerik.Reporting.Report repVentas = new Report_IIC_VentasEjercicio_SUB(isin, codigoIc, "Venta", FechaUltimoInforme);

            this.subReportCompras.ReportSource = repCompras;
            this.subReportVentas.ReportSource = repVentas;
        }

        private void Report_IIC_ComprasVentasEjercicio_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
        }
    }
}