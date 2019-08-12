namespace Reports_IICs.Reports.DistribucionPatrimonioNovarex
{
    partial class Report_DistribucionPatrimonioNovarex_Tesoreria_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.porcentajePatrimonioSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.patrimonioSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.descripcionDataTextBox = new Telerik.Reporting.TextBox();
            this.patrimonioDataTextBox = new Telerik.Reporting.TextBox();
            this.porcentajePatrimonioDataTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.28954404592514038D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.41045588254928589D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.porcentajePatrimonioSumFunctionTextBox,
            this.patrimonioSumFunctionTextBox,
            this.textBox1});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // porcentajePatrimonioSumFunctionTextBox
            // 
            this.porcentajePatrimonioSumFunctionTextBox.CanGrow = true;
            this.porcentajePatrimonioSumFunctionTextBox.Format = "{0:P2}";
            this.porcentajePatrimonioSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.1003999710083D), Telerik.Reporting.Drawing.Unit.Cm(0.010455756448209286D));
            this.porcentajePatrimonioSumFunctionTextBox.Name = "porcentajePatrimonioSumFunctionTextBox";
            this.porcentajePatrimonioSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.porcentajePatrimonioSumFunctionTextBox.Style.Font.Bold = true;
            this.porcentajePatrimonioSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.porcentajePatrimonioSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.porcentajePatrimonioSumFunctionTextBox.StyleName = "Data";
            this.porcentajePatrimonioSumFunctionTextBox.Value = "= Sum(Fields.PorcentajePatrimonio)/100";
            // 
            // patrimonioSumFunctionTextBox
            // 
            this.patrimonioSumFunctionTextBox.CanGrow = true;
            this.patrimonioSumFunctionTextBox.Format = "{0:N0}";
            this.patrimonioSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.1002006530761719D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.patrimonioSumFunctionTextBox.Name = "patrimonioSumFunctionTextBox";
            this.patrimonioSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.patrimonioSumFunctionTextBox.Style.Font.Bold = true;
            this.patrimonioSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.patrimonioSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.patrimonioSumFunctionTextBox.StyleName = "Data";
            this.patrimonioSumFunctionTextBox.Value = "= Sum(Fields.Patrimonio)";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.1000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "TESORERÍA/DEPÓSITOS";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_DistribucionPatrimonioNovarex_Tesoreria";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40000006556510925D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionDataTextBox,
            this.patrimonioDataTextBox,
            this.porcentajePatrimonioDataTextBox});
            this.detail.Name = "detail";
            // 
            // descripcionDataTextBox
            // 
            this.descripcionDataTextBox.CanGrow = true;
            this.descripcionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.descripcionDataTextBox.Name = "descripcionDataTextBox";
            this.descripcionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.1000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionDataTextBox.StyleName = "Data";
            this.descripcionDataTextBox.Value = "= Fields.Descripcion";
            // 
            // patrimonioDataTextBox
            // 
            this.patrimonioDataTextBox.CanGrow = true;
            this.patrimonioDataTextBox.Format = "{0:N0}";
            this.patrimonioDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.1002006530761719D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.patrimonioDataTextBox.Name = "patrimonioDataTextBox";
            this.patrimonioDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.patrimonioDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.patrimonioDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.patrimonioDataTextBox.StyleName = "Data";
            this.patrimonioDataTextBox.Value = "= Fields.Patrimonio";
            // 
            // porcentajePatrimonioDataTextBox
            // 
            this.porcentajePatrimonioDataTextBox.CanGrow = true;
            this.porcentajePatrimonioDataTextBox.Format = "{0:P2}";
            this.porcentajePatrimonioDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.1003999710083D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.porcentajePatrimonioDataTextBox.Name = "porcentajePatrimonioDataTextBox";
            this.porcentajePatrimonioDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.porcentajePatrimonioDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.porcentajePatrimonioDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.porcentajePatrimonioDataTextBox.StyleName = "Data";
            this.porcentajePatrimonioDataTextBox.Value = "= Fields.PorcentajePatrimonio/100";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.32850003242492676D);
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // Report_DistribucionPatrimonioNovarex_Tesoreria_SUB
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
            this.detail});
            this.Name = "Report1_DistribucionPatrimonioNovarex_Tesoreria_SUB";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            this.ReportParameters.Add(reportParameter1);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(14.1003999710083D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox descripcionDataTextBox;
        private Telerik.Reporting.TextBox patrimonioDataTextBox;
        private Telerik.Reporting.TextBox porcentajePatrimonioDataTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox porcentajePatrimonioSumFunctionTextBox;
        private Telerik.Reporting.TextBox patrimonioSumFunctionTextBox;
        private Telerik.Reporting.TextBox textBox1;
    }
}