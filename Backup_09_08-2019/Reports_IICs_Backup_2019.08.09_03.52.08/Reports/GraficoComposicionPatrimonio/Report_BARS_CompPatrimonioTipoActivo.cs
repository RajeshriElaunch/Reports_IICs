namespace Reports_IICs.Reports.GraficoComposicionPatrimonio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_BARS_CompPatrimonioTipoActivo.
    /// </summary>
    public partial class Report_BARS_CompPatrimonioTipoActivo : Telerik.Reporting.Report
    {
        public Report_BARS_CompPatrimonioTipoActivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_BARS_CompPatrimonioTipoActivo(string isinDesc, string codigoic, decimal? porcentajeTotal)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            this.ReportParameters["TotalPorcentaje"].Value = porcentajeTotal;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //loadTexts();
        }

        private void Report_BARS_CompPatrimonioTipoActivo_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
        //private void loadTexts()
        //{
        //    this.TituloReport.Value = string.Format(Resources.Resource.TituloReportCompPatrimonioTipoActivo + " {0:P2}", Convert.ToDecimal(this.ReportParameters["TotalPorcentaje"].Value) / 100); 

        //}
    }
}