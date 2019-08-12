namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable_GRUPO_SUB_Posiciones
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
            this.descripcionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.posicionCarteraCaptionTextBox = new Telerik.Reporting.TextBox();
            this.posicionesCerradasCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.posicionCarteraSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.posicionesCerradasSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.descripcionDataTextBox = new Telerik.Reporting.TextBox();
            this.posicionesCerradasDataTextBox = new Telerik.Reporting.TextBox();
            this.posicionCarteraDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.88466644287109375D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionCaptionTextBox,
            this.posicionCarteraCaptionTextBox,
            this.posicionesCerradasCaptionTextBox,
            this.textBox1,
            this.textBox2});
            this.labelsGroupHeaderSection.KeepTogether = true;
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // descripcionCaptionTextBox
            // 
            this.descripcionCaptionTextBox.CanGrow = true;
            this.descripcionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.4425332248210907D));
            this.descripcionCaptionTextBox.Name = "descripcionCaptionTextBox";
            this.descripcionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7574663162231445D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.descripcionCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.descripcionCaptionTextBox.StyleName = "Caption";
            this.descripcionCaptionTextBox.Value = "NOMBRE";
            // 
            // posicionCarteraCaptionTextBox
            // 
            this.posicionCarteraCaptionTextBox.CanGrow = true;
            this.posicionCarteraCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.4425332248210907D));
            this.posicionCarteraCaptionTextBox.Name = "posicionCarteraCaptionTextBox";
            this.posicionCarteraCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7286672592163086D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionCarteraCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.posicionCarteraCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionCarteraCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionCarteraCaptionTextBox.StyleName = "Caption";
            this.posicionCarteraCaptionTextBox.Value = "POSICIÓN CARTERA";
            // 
            // posicionesCerradasCaptionTextBox
            // 
            this.posicionesCerradasCaptionTextBox.CanGrow = true;
            this.posicionesCerradasCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.528865814208984D), Telerik.Reporting.Drawing.Unit.Cm(0.4425332248210907D));
            this.posicionesCerradasCaptionTextBox.Name = "posicionesCerradasCaptionTextBox";
            this.posicionesCerradasCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9289994239807129D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionesCerradasCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.posicionesCerradasCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionesCerradasCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.posicionesCerradasCaptionTextBox.StyleName = "Caption";
            this.posicionesCerradasCaptionTextBox.Value = "POSICIONES CERRADAS";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.9930000305175781D), Telerik.Reporting.Drawing.Unit.Cm(0.39999997615814209D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "B/P(€)";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.458064079284668D), Telerik.Reporting.Drawing.Unit.Cm(0.48466646671295166D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3349349498748779D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.StyleName = "Caption";
            this.textBox2.Value = "TOTAL (€)";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@IdInstrumento", System.Data.DbType.String, "= Parameters.IdInstrumento.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@IdTipoInstrumento", System.Data.DbType.String, "= Parameters.IdTipoInstrumento.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_Rentabilidad_Variable_SUBGrupoPosiciones";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.47999998927116394D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.posicionCarteraSumFunctionTextBox,
            this.posicionesCerradasSumFunctionTextBox,
            this.textBox4});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // posicionCarteraSumFunctionTextBox
            // 
            this.posicionCarteraSumFunctionTextBox.CanGrow = true;
            this.posicionCarteraSumFunctionTextBox.Format = "{0:N0}";
            this.posicionCarteraSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.posicionCarteraSumFunctionTextBox.Name = "posicionCarteraSumFunctionTextBox";
            this.posicionCarteraSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7286672592163086D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionCarteraSumFunctionTextBox.Style.Font.Bold = true;
            this.posicionCarteraSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionCarteraSumFunctionTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.posicionCarteraSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.posicionCarteraSumFunctionTextBox.StyleName = "Data";
            this.posicionCarteraSumFunctionTextBox.Value = "= Sum(Fields.PosicionCartera)";
            // 
            // posicionesCerradasSumFunctionTextBox
            // 
            this.posicionesCerradasSumFunctionTextBox.CanGrow = true;
            this.posicionesCerradasSumFunctionTextBox.Format = "{0:N0}";
            this.posicionesCerradasSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.528865814208984D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.posicionesCerradasSumFunctionTextBox.Name = "posicionesCerradasSumFunctionTextBox";
            this.posicionesCerradasSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9289994239807129D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionesCerradasSumFunctionTextBox.Style.Font.Bold = true;
            this.posicionesCerradasSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionesCerradasSumFunctionTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.posicionesCerradasSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.posicionesCerradasSumFunctionTextBox.StyleName = "Data";
            this.posicionesCerradasSumFunctionTextBox.Value = "=Sum(Fields.PosicionesCerradas)";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Format = "{0:N0}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.458064079284668D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3709352016448975D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "=Sum(Fields.PosicionCartera)+Sum(Fields.PosicionesCerradas)";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.KeepTogether = true;
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= Count(Fields.Id)", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.Visible = false;
            this.titleTextBox.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.835332870483398D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "= Parameters.SubTitle.Value";
            // 
            // detail
            // 
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.43999999761581421D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionDataTextBox,
            this.posicionesCerradasDataTextBox,
            this.posicionCarteraDataTextBox,
            this.textBox3});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            // 
            // descripcionDataTextBox
            // 
            this.descripcionDataTextBox.CanGrow = true;
            this.descripcionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.descripcionDataTextBox.Name = "descripcionDataTextBox";
            this.descripcionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.7574663162231445D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionDataTextBox.StyleName = "Data";
            this.descripcionDataTextBox.Value = "= Fields.Descripcion";
            // 
            // posicionesCerradasDataTextBox
            // 
            this.posicionesCerradasDataTextBox.CanGrow = true;
            this.posicionesCerradasDataTextBox.Format = "{0:N0}";
            this.posicionesCerradasDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.528865814208984D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.posicionesCerradasDataTextBox.Name = "posicionesCerradasDataTextBox";
            this.posicionesCerradasDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9289994239807129D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionesCerradasDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionesCerradasDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.posicionesCerradasDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.posicionesCerradasDataTextBox.StyleName = "Data";
            this.posicionesCerradasDataTextBox.Value = "= Fields.PosicionesCerradas";
            // 
            // posicionCarteraDataTextBox
            // 
            this.posicionCarteraDataTextBox.CanGrow = true;
            this.posicionCarteraDataTextBox.Format = "{0:N0}";
            this.posicionCarteraDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.posicionCarteraDataTextBox.Name = "posicionCarteraDataTextBox";
            this.posicionCarteraDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7286672592163086D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.posicionCarteraDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.posicionCarteraDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.posicionCarteraDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.posicionCarteraDataTextBox.StyleName = "Data";
            this.posicionCarteraDataTextBox.Value = "= Fields.PosicionCartera";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Format = "{0:N0}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.458064079284668D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3709352016448975D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "= Fields.PosicionCartera+ Fields.PosicionesCerradas";
            // 
            // ReportRentabilidadVariable_GRUPO_SUB_Posiciones
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
            this.reportHeader,
            this.detail});
            this.Name = "ReportRentabilidadVariable_GRUPO_SUB_Posiciones";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter1.Value = "446";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "IdInstrumento";
            reportParameter2.Text = "IdInstrumento";
            reportParameter2.Value = "3";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "IdTipoInstrumento";
            reportParameter3.Text = "IdTipoInstrumento";
            reportParameter3.Value = "2";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "SubTitle";
            reportParameter4.Value = "5) IICS";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.835332870483398D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox descripcionCaptionTextBox;
        private Telerik.Reporting.TextBox posicionCarteraCaptionTextBox;
        private Telerik.Reporting.TextBox posicionesCerradasCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox posicionCarteraSumFunctionTextBox;
        private Telerik.Reporting.TextBox posicionesCerradasSumFunctionTextBox;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox descripcionDataTextBox;
        private Telerik.Reporting.TextBox posicionesCerradasDataTextBox;
        private Telerik.Reporting.TextBox posicionCarteraDataTextBox;
        private Telerik.Reporting.TextBox textBox3;
    }
}