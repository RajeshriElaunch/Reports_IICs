namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Valor_Liquidativo
{
    using DataAccess.Reports;
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportPatrimonio_ValorLiquidativoPRO_02.
    /// </summary>
    public partial class ReportPatrimonio_ValorLiquidativoPRO_02 : Telerik.Reporting.Report
    {
        public ReportPatrimonio_ValorLiquidativoPRO_02()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //  
        }

        public ReportPatrimonio_ValorLiquidativoPRO_02(string codigoic, string isin)
        {
            InitializeComponent();
            this.DataSource = EvolPatrValLiq_DA.GetTemp(codigoic, isin);
            //this.ReportParameters["CodigoIC"].Value = codigoic;
            ////En algún momento se estaba poniendo a false así que nos aseguramos
            //this.ReportParameters["Isin"].Visible = true;
            //this.ReportParameters["Isin"].Value = isin;
        }

        private void subReport1_ItemDataBound(object sender, EventArgs e)
        {
            this.subReport1.Visible = ReportsUtils.HideSubReportIfNoRecords(sender);
        }

        private void ReportPatrimonio_ValorLiquidativoPRO_02_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }

        /// <summary>
        /// Tenemos otro método público parecido pero este es específico para este report
        /// En vez de tener en cuenta "detail" tiene en cuenta las filas de "table1"
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        //private static bool hideSubReportIfNoRecords(object sender)
        //{
        //    Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
        //    Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
        //    //bool visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, "table1", true).Length > 0;
        //    int filas = 0;
        //    if((Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, "table1", true)).Length > 0)
        //        filas = ((Telerik.Reporting.Processing.Table)(Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, "table1", true))[0]).Rows.Count;

        //    if (filas > 1)
        //        return true;
        //    else
        //        return false;
        //}
    }
}