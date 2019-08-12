namespace Reports_IICs.Reports.RentabilidadCarteraSolemeg
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_RentabilidadCarteraSolemeg.
    /// </summary>
    public partial class Report_RentabilidadCarteraSolemeg : Telerik.Reporting.Report
    {
        public Report_RentabilidadCarteraSolemeg()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Report_RentabilidadCarteraSolemeg_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}