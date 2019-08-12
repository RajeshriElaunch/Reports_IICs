namespace Reports_IICs.Reports.DistribucionPatrimonioNovarex
{
    partial class Report_DistribucionPatrimonioNovarex
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_DistribucionPatrimonioNovarex));
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource3 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.report_DistribucionPatrimonioNovarex_Cartera_SUB1 = new Reports_IICs.Reports.DistribucionPatrimonioNovarex.Report_DistribucionPatrimonioNovarex_Cartera_SUB();
            this.report_DistribucionPatrimonioNovarex_Tesoreria_SUB1 = new Reports_IICs.Reports.DistribucionPatrimonioNovarex.Report_DistribucionPatrimonioNovarex_Tesoreria_SUB();
            this.report_DistribucionPatrimonioNovarex_Total_SUB1 = new Reports_IICs.Reports.DistribucionPatrimonioNovarex.Report_DistribucionPatrimonioNovarex_Total_SUB();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.subReportCartera = new Telerik.Reporting.SubReport();
            this.subReportTesoreria = new Telerik.Reporting.SubReport();
            this.subReportTotal = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.TituloReport = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Cartera_SUB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Tesoreria_SUB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Total_SUB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // report_DistribucionPatrimonioNovarex_Cartera_SUB1
            // 
            this.report_DistribucionPatrimonioNovarex_Cartera_SUB1.Name = "Report_DistribucionPatrimonioNovarex_Cartera_SUB";
            // 
            // report_DistribucionPatrimonioNovarex_Tesoreria_SUB1
            // 
            this.report_DistribucionPatrimonioNovarex_Tesoreria_SUB1.Name = "Report1_DistribucionPatrimonioNovarex_Tesoreria_SUB";
            // 
            // report_DistribucionPatrimonioNovarex_Total_SUB1
            // 
            this.report_DistribucionPatrimonioNovarex_Total_SUB1.Name = "Report_DistribucionPatrimonioNovarex_Total_SUB";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.LogoPortada});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // LogoPortada
            // 
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(5.8999009132385254D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportCartera,
            this.subReportTesoreria,
            this.subReportTotal});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.5D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(5.0001006126403809D));
            // 
            // subReportCartera
            // 
            this.subReportCartera.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9719363788608462E-05D), Telerik.Reporting.Drawing.Unit.Cm(9.9719363788608462E-05D));
            this.subReportCartera.Name = "subReportCartera";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            instanceReportSource1.ReportDocument = this.report_DistribucionPatrimonioNovarex_Cartera_SUB1;
            this.subReportCartera.ReportSource = instanceReportSource1;
            this.subReportCartera.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0000002384185791D));
            this.subReportCartera.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // subReportTesoreria
            // 
            this.subReportTesoreria.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9719363788608462E-05D), Telerik.Reporting.Drawing.Unit.Cm(1.0001000165939331D));
            this.subReportTesoreria.Name = "subReportTesoreria";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            instanceReportSource2.ReportDocument = this.report_DistribucionPatrimonioNovarex_Tesoreria_SUB1;
            this.subReportTesoreria.ReportSource = instanceReportSource2;
            this.subReportTesoreria.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.5999997854232788D));
            // 
            // subReportTotal
            // 
            this.subReportTotal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9719363788608462E-05D), Telerik.Reporting.Drawing.Unit.Cm(3.4001009464263916D));
            this.subReportTotal.Name = "subReportTotal";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            instanceReportSource3.ReportDocument = this.report_DistribucionPatrimonioNovarex_Total_SUB1;
            this.subReportTotal.ReportSource = instanceReportSource3;
            this.subReportTotal.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.5999997854232788D));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.56010019779205322D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1899995803833D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // TituloReport
            // 
            this.TituloReport.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.789799690246582D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReport_DistribucionPatrimonioNovarex" +
    "()";
            // 
            // Report_DistribucionPatrimonioNovarex
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "Report_DistribucionPatrimonioNovarex";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            this.ReportParameters.Add(reportParameter1);
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.789999961853027D);
            this.ItemDataBinding += new System.EventHandler(this.Report_DistribucionPatrimonioNovarex_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Cartera_SUB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Tesoreria_SUB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DistribucionPatrimonioNovarex_Total_SUB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.SubReport subReportCartera;
        private Telerik.Reporting.SubReport subReportTesoreria;
        private Telerik.Reporting.SubReport subReportTotal;
        private Telerik.Reporting.Panel panel1;
        private Report_DistribucionPatrimonioNovarex_Cartera_SUB report_DistribucionPatrimonioNovarex_Cartera_SUB1;
        private Report_DistribucionPatrimonioNovarex_Tesoreria_SUB report_DistribucionPatrimonioNovarex_Tesoreria_SUB1;
        private Report_DistribucionPatrimonioNovarex_Total_SUB report_DistribucionPatrimonioNovarex_Total_SUB1;
    }
}