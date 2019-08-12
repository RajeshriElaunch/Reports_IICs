namespace Reports_IICs.Reports.Cupones_Cobrados
{
    partial class ReportCuponesCobrados
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCuponesCobrados));
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.fechaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.nombreValorCaptionTextBox = new Telerik.Reporting.TextBox();
            this.importeNetoCaptionTextBox = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.panel3 = new Telerik.Reporting.Panel();
            this.importeNetoSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.fechaDataTextBox = new Telerik.Reporting.TextBox();
            this.nombreValorDataTextBox = new Telerik.Reporting.TextBox();
            this.importeNetoDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.labelsGroupFooterSection.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40009996294975281D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.labelsGroupHeaderSection.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaCaptionTextBox,
            this.nombreValorCaptionTextBox,
            this.importeNetoCaptionTextBox});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.840000152587891D), Telerik.Reporting.Drawing.Unit.Cm(0.40009993314743042D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // fechaCaptionTextBox
            // 
            this.fechaCaptionTextBox.CanGrow = true;
            this.fechaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.fechaCaptionTextBox.Name = "fechaCaptionTextBox";
            this.fechaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8576664924621582D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.fechaCaptionTextBox.Style.Font.Bold = true;
            this.fechaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaCaptionTextBox.StyleName = "Caption";
            this.fechaCaptionTextBox.Value = "Oper.";
            // 
            // nombreValorCaptionTextBox
            // 
            this.nombreValorCaptionTextBox.CanGrow = true;
            this.nombreValorCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8578667640686035D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.nombreValorCaptionTextBox.Name = "nombreValorCaptionTextBox";
            this.nombreValorCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.5996007919311523D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.nombreValorCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.nombreValorCaptionTextBox.Style.Font.Bold = true;
            this.nombreValorCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.nombreValorCaptionTextBox.StyleName = "Caption";
            this.nombreValorCaptionTextBox.Value = "Nombre Valor";
            // 
            // importeNetoCaptionTextBox
            // 
            this.importeNetoCaptionTextBox.CanGrow = true;
            this.importeNetoCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.45766544342041D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.importeNetoCaptionTextBox.Name = "importeNetoCaptionTextBox";
            this.importeNetoCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2930004596710205D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeNetoCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.importeNetoCaptionTextBox.Style.Font.Bold = true;
            this.importeNetoCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeNetoCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.importeNetoCaptionTextBox.StyleName = "Caption";
            this.importeNetoCaptionTextBox.Value = "Importe Neto";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_CuponesCobrados";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40009993314743042D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.reportFooter.Style.Visible = true;
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.importeNetoSumFunctionTextBox});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.840000152587891D), Telerik.Reporting.Drawing.Unit.Cm(0.40009993314743042D));
            this.panel3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Dotted;
            // 
            // importeNetoSumFunctionTextBox
            // 
            this.importeNetoSumFunctionTextBox.CanGrow = true;
            this.importeNetoSumFunctionTextBox.Format = "{0:N0}";
            this.importeNetoSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.528665542602539D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.importeNetoSumFunctionTextBox.Name = "importeNetoSumFunctionTextBox";
            this.importeNetoSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2220001220703125D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeNetoSumFunctionTextBox.Style.Font.Bold = true;
            this.importeNetoSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeNetoSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.importeNetoSumFunctionTextBox.StyleName = "Data";
            this.importeNetoSumFunctionTextBox.Value = "= Sum(Fields.ImporteNeto)";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.LogoPortada});
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // LogoPortada
            // 
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.56020021438598633D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Docking = Telerik.Reporting.DockingStyle.Right;
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.239999771118164D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2000001668930054D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.835332870483398D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportCuponesCobrados(Parameters.Fec" +
    "haInforme.Value.Year)";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40010035037994385D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.detail.Name = "detail";
            // 
            // panel2
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.panel2.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaDataTextBox,
            this.nombreValorDataTextBox,
            this.importeNetoDataTextBox});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.840000152587891D), Telerik.Reporting.Drawing.Unit.Cm(0.40010032057762146D));
            // 
            // fechaDataTextBox
            // 
            this.fechaDataTextBox.CanGrow = true;
            this.fechaDataTextBox.Format = "{0:d}";
            this.fechaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.7848948863938858E-08D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.fechaDataTextBox.Name = "fechaDataTextBox";
            this.fechaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8576664924621582D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaDataTextBox.StyleName = "Data";
            this.fechaDataTextBox.Value = "= Fields.Fecha";
            // 
            // nombreValorDataTextBox
            // 
            this.nombreValorDataTextBox.CanGrow = true;
            this.nombreValorDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8578670024871826D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.nombreValorDataTextBox.Name = "nombreValorDataTextBox";
            this.nombreValorDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.5996007919311523D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.nombreValorDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.nombreValorDataTextBox.StyleName = "Data";
            this.nombreValorDataTextBox.Value = "= Fields.NombreValor";
            // 
            // importeNetoDataTextBox
            // 
            this.importeNetoDataTextBox.CanGrow = true;
            this.importeNetoDataTextBox.Format = "{0:N0}";
            this.importeNetoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.457666397094727D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.importeNetoDataTextBox.Name = "importeNetoDataTextBox";
            this.importeNetoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2930004596710205D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeNetoDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeNetoDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.importeNetoDataTextBox.StyleName = "Data";
            this.importeNetoDataTextBox.Value = "= Fields.ImporteNeto";
            // 
            // ReportCuponesCobrados
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.reportFooter,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "ReportCuponesCobrados";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.Name = "FechaInforme";
            reportParameter3.Text = "FechaInforme";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Italic = false;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Style.Font.Strikeout = false;
            styleRule2.Style.Font.Underline = false;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.840000152587891D);
            this.ItemDataBinding += new System.EventHandler(this.ReportCuponesCobrados_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox fechaCaptionTextBox;
        private Telerik.Reporting.TextBox nombreValorCaptionTextBox;
        private Telerik.Reporting.TextBox importeNetoCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox importeNetoSumFunctionTextBox;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox fechaDataTextBox;
        private Telerik.Reporting.TextBox nombreValorDataTextBox;
        private Telerik.Reporting.TextBox importeNetoDataTextBox;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.Panel panel2;
    }
}