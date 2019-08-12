namespace Reports_IICs.Reports.RentaFija
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for ReportRentaFija.
    /// </summary>
    public partial class ReportRentaFija : Telerik.Reporting.Report
    {
        private List<bool> subreportsVisibles = new List<bool>();
        public ReportRentaFija()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            
        }

        private void subReport6_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReport7_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void ReportRentaFija_ItemDataBound(object sender, EventArgs e)
        {
            //si no existe ningún subreport con Visible = true
            //No mostramos nada
            //if (!subreportsVisibles.Exists(ex => ex))
            //{
            //    this.Visible = false;
            //}
        }
    }
}