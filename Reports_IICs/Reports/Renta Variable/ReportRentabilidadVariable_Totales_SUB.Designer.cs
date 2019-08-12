namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable_Totales_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.descripcionCountFunctionTextBox = new Telerik.Reporting.TextBox();
            this.valorSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.descripcionDataTextBox = new Telerik.Reporting.TextBox();
            this.valorDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@IdInstrumento", System.Data.DbType.Int32, "= Parameters.IdInstrumento.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_Rentabilidad_Variable_Totales";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44233334064483643D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionCountFunctionTextBox,
            this.valorSumFunctionTextBox});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.reportFooter.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.reportFooter.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.reportFooter.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reportFooter.Style.Visible = true;
            // 
            // descripcionCountFunctionTextBox
            // 
            this.descripcionCountFunctionTextBox.CanGrow = true;
            this.descripcionCountFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.descripcionCountFunctionTextBox.Name = "descripcionCountFunctionTextBox";
            this.descripcionCountFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6576669216156006D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionCountFunctionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.descripcionCountFunctionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.descripcionCountFunctionTextBox.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.descripcionCountFunctionTextBox.Style.Font.Bold = true;
            this.descripcionCountFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionCountFunctionTextBox.StyleName = "Data";
            this.descripcionCountFunctionTextBox.Value = "TOTAL";
            // 
            // valorSumFunctionTextBox
            // 
            this.valorSumFunctionTextBox.CanGrow = true;
            this.valorSumFunctionTextBox.Format = "{0:N0}";
            this.valorSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.valorSumFunctionTextBox.Name = "valorSumFunctionTextBox";
            this.valorSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999001741409302D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.valorSumFunctionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.valorSumFunctionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.valorSumFunctionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.valorSumFunctionTextBox.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.valorSumFunctionTextBox.Style.Font.Bold = true;
            this.valorSumFunctionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.valorSumFunctionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.valorSumFunctionTextBox.StyleName = "Data";
            this.valorSumFunctionTextBox.Value = "= Sum(Fields.Valor)";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.54000002145767212D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            this.reportHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.reportHeader.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.reportHeader.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.reportHeader.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4999008178710938D), Telerik.Reporting.Drawing.Unit.Cm(0.54000002145767212D));
            this.titleTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.titleTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.titleTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.titleTextBox.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.titleTextBox.Style.Font.Underline = false;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "= Parameters.Subtitle.Value";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44233334064483643D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripcionDataTextBox,
            this.valorDataTextBox});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // descripcionDataTextBox
            // 
            this.descripcionDataTextBox.CanGrow = true;
            this.descripcionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.descripcionDataTextBox.Name = "descripcionDataTextBox";
            this.descripcionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6576669216156006D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionDataTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.descripcionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionDataTextBox.StyleName = "Data";
            this.descripcionDataTextBox.Value = "= Fields.Descripcion";
            // 
            // valorDataTextBox
            // 
            this.valorDataTextBox.CanGrow = true;
            this.valorDataTextBox.Format = "{0:N2}";
            this.valorDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.valorDataTextBox.Name = "valorDataTextBox";
            this.valorDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999001741409302D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.valorDataTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.valorDataTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.valorDataTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.valorDataTextBox.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.valorDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.valorDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.valorDataTextBox.StyleName = "Data";
            this.valorDataTextBox.Value = "= Fields.Valor";
            // 
            // ReportRentabilidadVariable_Totales_SUB
            // 
            this.DataSource = this.sqlDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportFooter,
            this.reportHeader,
            this.detail});
            this.Name = "ReportRentabilidadVariable_Totales";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Mm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.Name = "IdInstrumento";
            reportParameter2.Text = "IdInstrumento";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Name = "Subtitle";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(5.4999008178710938D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox descripcionCountFunctionTextBox;
        private Telerik.Reporting.TextBox valorSumFunctionTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox descripcionDataTextBox;
        private Telerik.Reporting.TextBox valorDataTextBox;
    }
}