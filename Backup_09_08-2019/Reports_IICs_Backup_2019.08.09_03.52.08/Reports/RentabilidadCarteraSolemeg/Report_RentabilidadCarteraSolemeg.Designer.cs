namespace Reports_IICs.Reports.RentabilidadCarteraSolemeg
{
    partial class Report_RentabilidadCarteraSolemeg
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_RentabilidadCarteraSolemeg));
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource2 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource3 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.report_RentabilidadCarteraSolemeg_SUB1 = new Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg_SUB();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.subReportGrupo1 = new Telerik.Reporting.SubReport();
            this.subReportGrupo2 = new Telerik.Reporting.SubReport();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.subReportGrupo3 = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.report_RentabilidadCarteraSolemeg_SUB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // report_RentabilidadCarteraSolemeg_SUB1
            // 
            this.report_RentabilidadCarteraSolemeg_SUB1.Name = "Report_RentabilidadCarteraSolemeg_SUB";
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
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(7.2000002861022949D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportGrupo1,
            this.subReportGrupo2,
            this.subReport1,
            this.subReportGrupo3});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9988508736714721E-05D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.200000762939453D), Telerik.Reporting.Drawing.Unit.Cm(7.1999998092651367D));
            // 
            // subReportGrupo1
            // 
            this.subReportGrupo1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.subReportGrupo1.Name = "subReportGrupo1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "1"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "GRUPO 1: CÁNTABRO 1"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGrupo1.ReportSource = typeReportSource1;
            this.subReportGrupo1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.180000305175781D), Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D));
            // 
            // subReportGrupo2
            // 
            this.subReportGrupo2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.7999998331069946D));
            this.subReportGrupo2.Name = "subReportGrupo2";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "2"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "GRUPO 2: CÁNTABRO 2"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGrupo2.ReportSource = typeReportSource2;
            this.subReportGrupo2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.180000305175781D), Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D));
            this.subReportGrupo2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.6000001430511475D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "3"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "GRUPO 3: VALOR"));
            instanceReportSource1.ReportDocument = this.report_RentabilidadCarteraSolemeg_SUB1;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.179901123046875D), Telerik.Reporting.Drawing.Unit.Cm(1.7991011142730713D));
            // 
            // subReportGrupo3
            // 
            this.subReportGrupo3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.3999991416931152D));
            this.subReportGrupo3.Name = "subReportGrupo3";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "4"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "GRUPO 4"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "Group3, Reports_IICs, Version=1.1.65.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGrupo3.ReportSource = typeReportSource3;
            this.subReportGrupo3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.180000305175781D), Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842D));
            this.subReportGrupo3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.55776625871658325D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.55766618251800537D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2001999616622925D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.00019992318993899971D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.180000305175781D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReport_RentabilidadCarteraSolemeg()";
            // 
            // Report_RentabilidadCarteraSolemeg
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "Report_RentabilidadCarteraSolemeg";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(20.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(20.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(10.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(10.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(16.19999885559082D);
            this.ItemDataBinding += new System.EventHandler(this.Report_RentabilidadCarteraSolemeg_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.report_RentabilidadCarteraSolemeg_SUB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.SubReport subReportGrupo1;
        private Telerik.Reporting.SubReport subReportGrupo2;
        private Telerik.Reporting.SubReport subReportGrupo3;
        private Telerik.Reporting.SubReport subReport1;
        private Report_RentabilidadCarteraSolemeg_SUB report_RentabilidadCarteraSolemeg_SUB1;
        private Telerik.Reporting.Panel panel1;
    }
}