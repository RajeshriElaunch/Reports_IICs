namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Valor_Liquidativo
{
    using DataAccess.Reports;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportEvolPatrValLiq.
    /// </summary>
    public partial class ReportEvolPatrValLiq : Telerik.Reporting.Report
    {
        public ReportEvolPatrValLiq(string codigoIC, string isin)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            this.DataSource = EvolPatrValLiq_DA.GetTemp(codigoIC, isin);

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}