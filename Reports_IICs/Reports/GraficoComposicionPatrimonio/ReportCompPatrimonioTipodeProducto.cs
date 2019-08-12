namespace Reports_IICs.Reports.GraficoComposicionPatrimonio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCompPatrimonioTipodeProducto.
    /// </summary>
    public partial class ReportCompPatrimonioTipodeProducto : Telerik.Reporting.Report
    {
        public ReportCompPatrimonioTipodeProducto()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportCompPatrimonioTipodeProducto(string isin, string codigoic, DateTime fecha, string isinDesc)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //if (isin != null) this.textBoxISIN.Value = isin;
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            //
            //this.textBoxISIN.CanGrow
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportCompPatrimonioTipodeProducto_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}