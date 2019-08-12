namespace Reports_IICs.Reports.GraficoComposicionPatrimonio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_BARS_CompPatrimonioTipodeProducto.
    /// </summary>
    public partial class Report_BARS_CompPatrimonioTipodeProducto : Telerik.Reporting.Report
    {
        public Report_BARS_CompPatrimonioTipodeProducto()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_BARS_CompPatrimonioTipodeProducto(string isin, string codigoic, DateTime fecha, string isinDesc)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_BARS_CompPatrimonioTipodeProducto(string isin, string codigoic, DateTime fecha, string isinDesc, decimal? porcentajeTotal)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            //this.ReportParameters["TotalPorcentaje"] = porcentajeTotal;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Report_BARS_CompPatrimonioTipodeProducto_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}