namespace Reports_IICs.Reports.GraficoComposicionPatrimonio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCompPatrimonioTipoActivo.
    /// </summary>
    public partial class ReportCompPatrimonioTipoActivo : Telerik.Reporting.Report
    {
        public ReportCompPatrimonioTipoActivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportCompPatrimonioTipoActivo(string isinDesc, string codigoic)
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

            loadTexts();
        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportCompPatrimonioTipoActivo;
        }

        private void ReportCompPatrimonioTipoActivo_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}