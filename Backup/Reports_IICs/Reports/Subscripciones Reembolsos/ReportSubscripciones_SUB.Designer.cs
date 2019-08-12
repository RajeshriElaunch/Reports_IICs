namespace Reports_IICs.Reports.Subscripciones_Reembolsos
{
    partial class ReportSubscripciones_SUB
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
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.fechaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tipoMovimientoCaptionTextBox = new Telerik.Reporting.TextBox();
            this.importeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.importeSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fechaDataTextBox = new Telerik.Reporting.TextBox();
            this.tipoMovimientoDataTextBox = new Telerik.Reporting.TextBox();
            this.importeDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44233331084251404D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaCaptionTextBox,
            this.tipoMovimientoCaptionTextBox,
            this.importeCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelsGroupHeaderSection.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // fechaCaptionTextBox
            // 
            this.fechaCaptionTextBox.CanGrow = true;
            this.fechaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.fechaCaptionTextBox.Name = "fechaCaptionTextBox";
            this.fechaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaCaptionTextBox.Style.Font.Bold = true;
            this.fechaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaCaptionTextBox.StyleName = "Caption";
            this.fechaCaptionTextBox.Value = "F.Oper.";
            // 
            // tipoMovimientoCaptionTextBox
            // 
            this.tipoMovimientoCaptionTextBox.CanGrow = true;
            this.tipoMovimientoCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6025335788726807D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.tipoMovimientoCaptionTextBox.Name = "tipoMovimientoCaptionTextBox";
            this.tipoMovimientoCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.tipoMovimientoCaptionTextBox.Style.Font.Bold = true;
            this.tipoMovimientoCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.tipoMovimientoCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipoMovimientoCaptionTextBox.StyleName = "Caption";
            this.tipoMovimientoCaptionTextBox.Value = "Tip. Mov";
            // 
            // importeCaptionTextBox
            // 
            this.importeCaptionTextBox.CanGrow = true;
            this.importeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1027331352233887D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.importeCaptionTextBox.Name = "importeCaptionTextBox";
            this.importeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeCaptionTextBox.Style.Font.Bold = true;
            this.importeCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.importeCaptionTextBox.StyleName = "Caption";
            this.importeCaptionTextBox.Value = "Importe";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@TipoMovimiento", System.Data.DbType.String, "= Parameters.TipoMovimiento.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_SuscripcionesReembolsos";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44233331084251404D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.importeSumFunctionTextBox});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Total:";
            // 
            // importeSumFunctionTextBox
            // 
            this.importeSumFunctionTextBox.CanGrow = true;
            this.importeSumFunctionTextBox.Format = "{0:N2}";
            this.importeSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1027331352233887D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.importeSumFunctionTextBox.Name = "importeSumFunctionTextBox";
            this.importeSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1972661018371582D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeSumFunctionTextBox.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.importeSumFunctionTextBox.Style.Font.Bold = true;
            this.importeSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.importeSumFunctionTextBox.StyleName = "Data";
            this.importeSumFunctionTextBox.Value = "= Sum(Fields.Importe)";
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.47299984097480774D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaDataTextBox,
            this.tipoMovimientoDataTextBox,
            this.importeDataTextBox});
            this.detail.Name = "detail";
            // 
            // fechaDataTextBox
            // 
            this.fechaDataTextBox.CanGrow = true;
            this.fechaDataTextBox.Format = "{0:d}";
            this.fechaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.fechaDataTextBox.Name = "fechaDataTextBox";
            this.fechaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fechaDataTextBox.StyleName = "Data";
            this.fechaDataTextBox.Value = "= Fields.Fecha";
            // 
            // tipoMovimientoDataTextBox
            // 
            this.tipoMovimientoDataTextBox.CanGrow = true;
            this.tipoMovimientoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6025335788726807D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.tipoMovimientoDataTextBox.Name = "tipoMovimientoDataTextBox";
            this.tipoMovimientoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.tipoMovimientoDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.tipoMovimientoDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tipoMovimientoDataTextBox.StyleName = "Data";
            this.tipoMovimientoDataTextBox.Value = "= Fields.TipoMovimiento";
            // 
            // importeDataTextBox
            // 
            this.importeDataTextBox.CanGrow = true;
            this.importeDataTextBox.Format = "{0:N2}";
            this.importeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1027331352233887D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.importeDataTextBox.Name = "importeDataTextBox";
            this.importeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1972661018371582D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.importeDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.importeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.importeDataTextBox.StyleName = "Data";
            this.importeDataTextBox.Value = "= Fields.Importe";
            // 
            // ReportSubscripciones_SUB
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
            this.Name = "ReportSubscripciones_SUB";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "TipoMovimiento";
            reportParameter3.Text = "TipoMovimiento";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(7.7027339935302734D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox fechaCaptionTextBox;
        private Telerik.Reporting.TextBox tipoMovimientoCaptionTextBox;
        private Telerik.Reporting.TextBox importeCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox importeSumFunctionTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox fechaDataTextBox;
        private Telerik.Reporting.TextBox tipoMovimientoDataTextBox;
        private Telerik.Reporting.TextBox importeDataTextBox;
    }
}