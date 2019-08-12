namespace Reports_IICs.Reports.Diversificacion
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportDiversificacion.
    /// </summary>
    public partial class ReportDiversificacion : Telerik.Reporting.Report
    {
        public ReportDiversificacion()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportDiversificacion_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
            Utils.CenterPanel(codigoIC, this.Report, this.panel4);
            Utils.CenterPanel(codigoIC, this.Report, this.panel5);
            Utils.CenterPanel(codigoIC, this.Report, this.panel6);
            Utils.CenterPanel(codigoIC, this.Report, this.panel7);
            Utils.CenterPanel(codigoIC, this.Report, this.panel8);            
        }
    }
}