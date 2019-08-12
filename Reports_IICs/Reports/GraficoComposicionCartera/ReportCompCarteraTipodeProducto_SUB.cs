namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportCompCarteraTipodeProducto_SUB.
    /// </summary>
    public partial class ReportCompCarteraTipodeProducto_SUB : Telerik.Reporting.Report
    {
        public ReportCompCarteraTipodeProducto_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.ReportParameters["Isin"].Value = "ES0139957031";
            this.ReportParameters["CodigoIC"].Value = "214";
            this.ReportParameters["IdInstrumento"].Value = "2";
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}