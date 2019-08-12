namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportDistrPatrTipoActivo.
    /// </summary>
    public partial class ReportDistrPatrTipoActivo : Telerik.Reporting.Report
    {
        public ReportDistrPatrTipoActivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
           
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportDistrPatrTipoActivo(string isinDesc, string codigoic)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if(isinDesc!=null) this.textBoxISIN.Value = isinDesc;
            //this.textBoxISIN.CanGrow
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            loadTexts();
        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportCompCarteraTipoActivo;
        }

    }
}