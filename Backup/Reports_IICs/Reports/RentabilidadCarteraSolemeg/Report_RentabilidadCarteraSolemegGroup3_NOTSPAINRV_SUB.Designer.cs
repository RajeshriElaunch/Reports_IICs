namespace Reports_IICs.Reports.RentabilidadCarteraSolemeg
{
    partial class Report_RentabilidadCarteraSolemegGroup3_NOTSPAINRV_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.descripcionDataTextBox = new Telerik.Reporting.TextBox();
            this.numeroTitulosDataTextBox = new Telerik.Reporting.TextBox();
            this.precioCompraOriginalDataTextBox = new Telerik.Reporting.TextBox();
            this.precioCompraSolemegDataTextBox = new Telerik.Reporting.TextBox();
            this.precioActualDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583335161209106D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583329945802689D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Grupo", System.Data.DbType.Int32, "= Parameters.Grupo.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_RentabilidadCarteraSolemeg_NOTSPAINRV";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionDataTextBox,
            this.numeroTitulosDataTextBox,
            this.precioCompraOriginalDataTextBox,
            this.precioCompraSolemegDataTextBox,
            this.precioActualDataTextBox,
            this.textBox3,
            this.textBox5});
            this.detail.Name = "detail";
            // 
            // descripcionDataTextBox
            // 
            this.descripcionDataTextBox.CanGrow = true;
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber()%2 ", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.descripcionDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.descripcionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.descripcionDataTextBox.Name = "descripcionDataTextBox";
            this.descripcionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.5573668479919434D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.descripcionDataTextBox.StyleName = "Data";
            this.descripcionDataTextBox.Value = "=IIf(Fields.Vendido=True,Fields.Descripcion + \"(VENDIDO)\",Fields.Descripcion)";
            // 
            // numeroTitulosDataTextBox
            // 
            this.numeroTitulosDataTextBox.CanGrow = true;
            this.numeroTitulosDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.numeroTitulosDataTextBox.Format = "{0:N0}";
            this.numeroTitulosDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.5999007225036621D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.numeroTitulosDataTextBox.Name = "numeroTitulosDataTextBox";
            this.numeroTitulosDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5207324028015137D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.numeroTitulosDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.numeroTitulosDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.numeroTitulosDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.numeroTitulosDataTextBox.StyleName = "Data";
            this.numeroTitulosDataTextBox.Value = "= Fields.NumeroTitulos";
            // 
            // precioCompraOriginalDataTextBox
            // 
            this.precioCompraOriginalDataTextBox.CanGrow = true;
            this.precioCompraOriginalDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.precioCompraOriginalDataTextBox.Format = "{0:N2}";
            this.precioCompraOriginalDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.1208333969116211D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.precioCompraOriginalDataTextBox.Name = "precioCompraOriginalDataTextBox";
            this.precioCompraOriginalDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9186028242111206D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.precioCompraOriginalDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.precioCompraOriginalDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.precioCompraOriginalDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.precioCompraOriginalDataTextBox.StyleName = "Data";
            this.precioCompraOriginalDataTextBox.Value = "= IsNull(Fields.PrecioCompraOriginal,\"-\")";
            // 
            // precioCompraSolemegDataTextBox
            // 
            this.precioCompraSolemegDataTextBox.CanGrow = true;
            this.precioCompraSolemegDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.precioCompraSolemegDataTextBox.Format = "{0:N2}";
            this.precioCompraSolemegDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.039637565612793D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.precioCompraSolemegDataTextBox.Name = "precioCompraSolemegDataTextBox";
            this.precioCompraSolemegDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0762667655944824D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.precioCompraSolemegDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.precioCompraSolemegDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.precioCompraSolemegDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.precioCompraSolemegDataTextBox.StyleName = "Data";
            this.precioCompraSolemegDataTextBox.Value = "= Fields.PrecioCompraSolemeg";
            // 
            // precioActualDataTextBox
            // 
            this.precioActualDataTextBox.CanGrow = true;
            this.precioActualDataTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.precioActualDataTextBox.Format = "{0:N2}";
            this.precioActualDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.116104125976563D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.precioActualDataTextBox.Name = "precioActualDataTextBox";
            this.precioActualDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3988442420959473D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.precioActualDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.precioActualDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.precioActualDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.precioActualDataTextBox.StyleName = "Data";
            this.precioActualDataTextBox.Value = "= Fields.PrecioActual";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("=RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox3.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox3.Format = "{0:P1}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.515146255493164D), Telerik.Reporting.Drawing.Unit.Cm(0.050000015646219254D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7836228609085083D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "=IIf(Fields.PrecioCompraOriginal IS Null,\"-\",((Fields.PrecioActual - Fields.Preci" +
    "oCompraOriginal)/Fields.PrecioCompraOriginal))\r\n";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox5.Format = "{0:P1}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.298966407775879D), Telerik.Reporting.Drawing.Unit.Cm(0.050000015646219254D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8801993131637573D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "Data";
            this.textBox5.Value = "= ((Fields.PrecioActual - Fields.PrecioCompraSolemeg)/Fields.PrecioCompraSolemeg)" +
    "";
            // 
            // Report_RentabilidadCarteraSolemegGroup3_NOTSPAINRV_SUB
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
            this.detail});
            this.Name = "Report_RentabilidadCarteraSolemegGroup3_NOTSPAINRV_SUB";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "Grupo";
            reportParameter3.Text = "Grupo";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "NombreGrupo";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(16.208429336547852D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox descripcionDataTextBox;
        private Telerik.Reporting.TextBox numeroTitulosDataTextBox;
        private Telerik.Reporting.TextBox precioCompraOriginalDataTextBox;
        private Telerik.Reporting.TextBox precioCompraSolemegDataTextBox;
        private Telerik.Reporting.TextBox precioActualDataTextBox;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
    }
}