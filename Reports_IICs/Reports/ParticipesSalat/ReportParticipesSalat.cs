namespace Reports_IICs.Reports.ParticipesSalat
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportParticipesSalat.
    /// </summary>
    public partial class ReportParticipesSalat : Telerik.Reporting.Report
    {
        public ReportParticipesSalat()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportParticipesSalat(string codigoIC)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //this.ReportParameters["CodigoIC"].Value = codigoIC;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportParticipesSalat_ItemDataBinding(object sender, EventArgs e)
        {
            //Esta sección es sólo para SALAT (380)
            string codigoIC = "380";
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
            Utils.CenterPanel(codigoIC, this.Report, this.panel4);
            Utils.CenterPanel(codigoIC, this.Report, this.panel5);
        }
    }
}