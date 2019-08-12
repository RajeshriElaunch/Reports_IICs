namespace Reports_IICs.Reports.COMPRA_VENTA
{
    partial class ReportCompraVentaRespectoPrecioAdquisicion_SUB
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
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fechaDataTextBox = new Telerik.Reporting.TextBox();
            this.tipoDataTextBox = new Telerik.Reporting.TextBox();
            this.titulosDataTextBox = new Telerik.Reporting.TextBox();
            this.descripcionValorDataTextBox = new Telerik.Reporting.TextBox();
            this.adquisicionDataTextBox = new Telerik.Reporting.TextBox();
            this.efectivoDataTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.titulosSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.descripcionValorCountFunctionTextBox = new Telerik.Reporting.TextBox();
            this.efectivoSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583332180976868D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583332926034927D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_CompraVentaPrecAdq";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2 ", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.49416664242744446D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaDataTextBox,
            this.tipoDataTextBox,
            this.titulosDataTextBox,
            this.descripcionValorDataTextBox,
            this.adquisicionDataTextBox,
            this.efectivoDataTextBox});
            this.detail.Name = "detail";
            // 
            // fechaDataTextBox
            // 
            this.fechaDataTextBox.CanGrow = true;
            this.fechaDataTextBox.Format = "{0:d}";
            this.fechaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.fechaDataTextBox.Name = "fechaDataTextBox";
            this.fechaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaDataTextBox.StyleName = "Data";
            this.fechaDataTextBox.Value = "= Fields.Fecha";
            // 
            // tipoDataTextBox
            // 
            this.tipoDataTextBox.CanGrow = true;
            this.tipoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.5002000331878662D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.tipoDataTextBox.Name = "tipoDataTextBox";
            this.tipoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0093986988067627D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.tipoDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.tipoDataTextBox.StyleName = "Data";
            this.tipoDataTextBox.Value = "= Fields.Tipo";
            // 
            // titulosDataTextBox
            // 
            this.titulosDataTextBox.CanGrow = true;
            this.titulosDataTextBox.Format = "{0:N0}";
            this.titulosDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5097992420196533D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.titulosDataTextBox.Name = "titulosDataTextBox";
            this.titulosDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.190000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.titulosDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.titulosDataTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.titulosDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.titulosDataTextBox.StyleName = "Data";
            this.titulosDataTextBox.Value = "= Fields.Titulos";
            // 
            // descripcionValorDataTextBox
            // 
            this.descripcionValorDataTextBox.CanGrow = true;
            this.descripcionValorDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.042333357036113739D));
            this.descripcionValorDataTextBox.Name = "descripcionValorDataTextBox";
            this.descripcionValorDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.4991021156311035D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionValorDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionValorDataTextBox.StyleName = "Data";
            this.descripcionValorDataTextBox.Value = "= Fields.DescripcionValor";
            // 
            // adquisicionDataTextBox
            // 
            this.adquisicionDataTextBox.CanGrow = true;
            this.adquisicionDataTextBox.Format = "{0:N2}";
            this.adquisicionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1993017196655273D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.adquisicionDataTextBox.Name = "adquisicionDataTextBox";
            this.adquisicionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.adquisicionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.adquisicionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.adquisicionDataTextBox.StyleName = "Data";
            this.adquisicionDataTextBox.Value = "= Fields.Adquisicion";
            // 
            // efectivoDataTextBox
            // 
            this.efectivoDataTextBox.CanGrow = true;
            this.efectivoDataTextBox.Format = "{0:N0}";
            this.efectivoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.799500465393066D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.efectivoDataTextBox.Name = "efectivoDataTextBox";
            this.efectivoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.efectivoDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.efectivoDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.efectivoDataTextBox.StyleName = "Data";
            this.efectivoDataTextBox.Value = "= Fields.Efectivo";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40010008215904236D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titulosSumFunctionTextBox,
            this.descripcionValorCountFunctionTextBox,
            this.efectivoSumFunctionTextBox,
            this.textBox1,
            this.textBox2});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = true;
            // 
            // titulosSumFunctionTextBox
            // 
            this.titulosSumFunctionTextBox.CanGrow = true;
            this.titulosSumFunctionTextBox.Format = "{0:N0}";
            this.titulosSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5097992420196533D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titulosSumFunctionTextBox.Name = "titulosSumFunctionTextBox";
            this.titulosSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.190000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.titulosSumFunctionTextBox.Style.Font.Bold = true;
            this.titulosSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.titulosSumFunctionTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.titulosSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.titulosSumFunctionTextBox.StyleName = "Data";
            this.titulosSumFunctionTextBox.Value = "= Sum(Fields.Titulos)";
            // 
            // descripcionValorCountFunctionTextBox
            // 
            this.descripcionValorCountFunctionTextBox.CanGrow = true;
            this.descripcionValorCountFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.descripcionValorCountFunctionTextBox.Name = "descripcionValorCountFunctionTextBox";
            this.descripcionValorCountFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.4991021156311035D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionValorCountFunctionTextBox.Style.Font.Bold = true;
            this.descripcionValorCountFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionValorCountFunctionTextBox.StyleName = "Data";
            this.descripcionValorCountFunctionTextBox.Value = "=  Format(\"Total {0}\", Fields.DescripcionValor)    ";
            // 
            // efectivoSumFunctionTextBox
            // 
            this.efectivoSumFunctionTextBox.CanGrow = true;
            this.efectivoSumFunctionTextBox.Format = "{0:N0}";
            this.efectivoSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.799500465393066D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012307757278904D));
            this.efectivoSumFunctionTextBox.Name = "efectivoSumFunctionTextBox";
            this.efectivoSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.efectivoSumFunctionTextBox.Style.Font.Bold = true;
            this.efectivoSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.efectivoSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.efectivoSumFunctionTextBox.StyleName = "Data";
            this.efectivoSumFunctionTextBox.Value = "= Sum(Fields.Efectivo)";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Format = "{0:N0}";
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.399700164794922D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012307757278904D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6000003814697266D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Data";
            this.textBox1.Value = "=IIf(Sum(Fields.Efectivo) >= 0,Sum(Fields.Efectivo),\"\")";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Format = "{0:N0}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.999899864196777D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012307757278904D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4001004695892334D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "=IIf(Sum(Fields.Efectivo) < 0,Sum(Fields.Efectivo),\"\")";
            // 
            // ReportCompraVentaRespectoPrecioAdquisicion_SUB
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
            this.Name = "ReportCompraVentaRespectoPrecioAdquisicion_SUB";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Fecha", Telerik.Reporting.SortDirection.Asc));
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.600000381469727D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox fechaDataTextBox;
        private Telerik.Reporting.TextBox tipoDataTextBox;
        private Telerik.Reporting.TextBox titulosDataTextBox;
        private Telerik.Reporting.TextBox descripcionValorDataTextBox;
        private Telerik.Reporting.TextBox adquisicionDataTextBox;
        private Telerik.Reporting.TextBox efectivoDataTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox titulosSumFunctionTextBox;
        private Telerik.Reporting.TextBox descripcionValorCountFunctionTextBox;
        private Telerik.Reporting.TextBox efectivoSumFunctionTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
    }
}