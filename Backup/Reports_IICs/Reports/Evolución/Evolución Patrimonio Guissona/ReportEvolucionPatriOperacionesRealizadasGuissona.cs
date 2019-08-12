namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Guissona
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportEvolucionPatriOperacionesRealizadasGuissona.
    /// </summary>
    public partial class ReportEvolucionPatriOperacionesRealizadasGuissona : Telerik.Reporting.Report
    {
        public ReportEvolucionPatriOperacionesRealizadasGuissona()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportEvolucionPatriOperacionesRealizadasGuissona(string codigoIC,DateTime fechaInicio,DateTime fechaInforme)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.ReportParameters["FechaInicio"].Value = fechaInicio;
            this.ReportParameters["FechaInforme"].Value = fechaInforme;
            this.ReportParameters["CodigoIC"].Value = codigoIC;
            this.ReportParameters["Isin"].Value = null;
            
            this.sqlTemp_EvolucionPatrGuissonaIndBench.Parameters[0].Value = codigoIC;
            this.sqlTemp_EvolucionPatrGuissonaIndBench.Parameters[1].Value = null;


            loadTexts();
        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportEvolucionPatriOperacionesRealizadasGuissona;            
        }

        private void ReportEvolucionPatriOperacionesRealizadasGuissona_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}