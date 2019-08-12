namespace Reports_IICs.Reports.GraficoComposicionPatrimonio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportGraficoCompPatrimonioDivisas.
    /// </summary>
    public partial class ReportGraficoCompPatrimonioDivisas : Telerik.Reporting.Report
    {
        public ReportGraficoCompPatrimonioDivisas()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportGraficoCompPatrimonioDivisas(string isinDesc, string codigoic)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            //this.textBoxISIN.CanGrow
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //loadTexts();
        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportGraficoCompPatrimonioDivisas;
        }

        private void ReportGraficoCompPatrimonioDivisas_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}