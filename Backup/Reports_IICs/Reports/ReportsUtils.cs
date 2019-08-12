namespace Reports_IICs.Reports
{
    public static class ReportsUtils
    {
        public static bool HideSubReportIfNoRecords(object sender)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
            bool visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, "detail", true).Length > 0;
            subReport.Visible = visible;
            return visible;
        }
    }
}
