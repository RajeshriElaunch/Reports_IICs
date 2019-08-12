namespace Reports_IICs.Reports.ListadoRentaFijaNovarex
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_ListadoRentaFijaNovarex.
    /// </summary>
    public partial class Report_ListadoRentaFijaNovarex : Telerik.Reporting.Report
    {
        public Report_ListadoRentaFijaNovarex()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_ListadoRentaFijaNovarex(string codigoIC, DateTime fecha)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.ReportParameters["CodigoIC"].Value = codigoIC;
            this.ReportParameters["Fecha"].Value = fecha;
        }

        private void Report_ListadoRentaFijaNovarex_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
            Utils.CenterPanel(codigoIC, this.Report, this.panel4);
        }
    }
}