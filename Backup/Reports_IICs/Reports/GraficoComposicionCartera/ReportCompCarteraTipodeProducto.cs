namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportDistPatrTipodeProducto.
    /// </summary>
    public partial class ReportDistPatrTipodeProducto : Telerik.Reporting.Report
    {
        public ReportDistPatrTipodeProducto()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportDistPatrTipodeProducto(string isin, string codigoic, DateTime fecha,string isinDesc)
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
    }
}