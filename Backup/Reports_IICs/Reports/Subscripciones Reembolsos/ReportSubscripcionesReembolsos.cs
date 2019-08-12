namespace Reports_IICs.Reports.Subscripciones_Reembolsos
{
    using System;
    using Helpers;

    /// <summary>
    /// Summary description for ReportSubscripcionesReembolsos.
    /// </summary>
    public partial class ReportSubscripcionesReembolsos : Telerik.Reporting.Report
    {
        public ReportSubscripcionesReembolsos()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportSubscripcionesReembolsos(string codigoIc, string isin)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

           
            Telerik.Reporting.Report repRem = new ReportReembolsos_SUB(isin, codigoIc, "REINTEGRO");
            Telerik.Reporting.Report repSubs = new ReportSubscripciones_SUB(isin, codigoIc, "SUSCRIPCION");
            
            this.subReportReembolsos.ReportSource = repRem;
            this.subReportSuscripcion.ReportSource = repSubs;

        }

        private void ReportSubscripcionesReembolsos_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}