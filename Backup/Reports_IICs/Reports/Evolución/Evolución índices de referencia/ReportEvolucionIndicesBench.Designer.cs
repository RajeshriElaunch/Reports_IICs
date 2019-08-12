namespace Reports_IICs.Reports.Evolución.Evolución_índices_de_referencia
{
    partial class ReportEvolucionIndicesBench
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.fechaDesdeDataTextBox = new Telerik.Reporting.TextBox();
            this.fechaHastaDataTextBox = new Telerik.Reporting.TextBox();
            this.varCotizaDivisaCaptionTextBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.cotizaDivDesdeDataTextBox1 = new Telerik.Reporting.TextBox();
            this.cotizaDivHastaDataTextBox1 = new Telerik.Reporting.TextBox();
            this.descripcionDataTextBox1 = new Telerik.Reporting.TextBox();
            this.varCotizaDivisaDataTextBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, null)});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_EvolucionIndBench";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.9999998807907105D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.fechaDesdeDataTextBox,
            this.fechaHastaDataTextBox,
            this.varCotizaDivisaCaptionTextBox1});
            this.reportHeader.Name = "reportHeader";
            this.reportHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.titleTextBox.Style.BorderColor.Bottom = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(195)))), ((int)(((byte)(206)))));
            this.titleTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportEvolucionIndicesBenchMarkPRO_0" +
    "3()";
            // 
            // fechaDesdeDataTextBox
            // 
            this.fechaDesdeDataTextBox.CanGrow = true;
            this.fechaDesdeDataTextBox.Format = "{0:d}";
            this.fechaDesdeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.5D), Telerik.Reporting.Drawing.Unit.Cm(1.3999999761581421D));
            this.fechaDesdeDataTextBox.Name = "fechaDesdeDataTextBox";
            this.fechaDesdeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaDesdeDataTextBox.Style.Font.Bold = true;
            this.fechaDesdeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.fechaDesdeDataTextBox.StyleName = "Data";
            this.fechaDesdeDataTextBox.Value = "= Fields.FechaDesde";
            // 
            // fechaHastaDataTextBox
            // 
            this.fechaHastaDataTextBox.CanGrow = true;
            this.fechaHastaDataTextBox.Format = "{0:d}";
            this.fechaHastaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10D), Telerik.Reporting.Drawing.Unit.Cm(1.3999999761581421D));
            this.fechaHastaDataTextBox.Name = "fechaHastaDataTextBox";
            this.fechaHastaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5350551605224609D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaHastaDataTextBox.Style.Font.Bold = true;
            this.fechaHastaDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.fechaHastaDataTextBox.StyleName = "Data";
            this.fechaHastaDataTextBox.Value = "= Fields.FechaHasta";
            // 
            // varCotizaDivisaCaptionTextBox1
            // 
            this.varCotizaDivisaCaptionTextBox1.CanGrow = true;
            this.varCotizaDivisaCaptionTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(1.057666540145874D));
            this.varCotizaDivisaCaptionTextBox1.Name = "varCotizaDivisaCaptionTextBox1";
            this.varCotizaDivisaCaptionTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999985218048096D), Telerik.Reporting.Drawing.Unit.Cm(0.942333459854126D));
            this.varCotizaDivisaCaptionTextBox1.Style.Font.Bold = true;
            this.varCotizaDivisaCaptionTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.varCotizaDivisaCaptionTextBox1.StyleName = "Caption";
            this.varCotizaDivisaCaptionTextBox1.Value = "VARIACIÓN en % ";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.68466669321060181D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.cotizaDivDesdeDataTextBox1,
            this.cotizaDivHastaDataTextBox1,
            this.descripcionDataTextBox1,
            this.varCotizaDivisaDataTextBox1});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // cotizaDivDesdeDataTextBox1
            // 
            this.cotizaDivDesdeDataTextBox1.CanGrow = true;
            this.cotizaDivDesdeDataTextBox1.Format = "{0:N3}";
            this.cotizaDivDesdeDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.5D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.cotizaDivDesdeDataTextBox1.Name = "cotizaDivDesdeDataTextBox1";
            this.cotizaDivDesdeDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4500000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivDesdeDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.cotizaDivDesdeDataTextBox1.StyleName = "Data";
            this.cotizaDivDesdeDataTextBox1.Value = "= Fields.CotizaDivDesde";
            // 
            // cotizaDivHastaDataTextBox1
            // 
            this.cotizaDivHastaDataTextBox1.CanGrow = true;
            this.cotizaDivHastaDataTextBox1.Format = "{0:N3}";
            this.cotizaDivHastaDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.cotizaDivHastaDataTextBox1.Name = "cotizaDivHastaDataTextBox1";
            this.cotizaDivHastaDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivHastaDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.cotizaDivHastaDataTextBox1.StyleName = "Data";
            this.cotizaDivHastaDataTextBox1.Value = "= Fields.CotizaDivHasta";
            // 
            // descripcionDataTextBox1
            // 
            this.descripcionDataTextBox1.CanGrow = true;
            this.descripcionDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.descripcionDataTextBox1.Name = "descripcionDataTextBox1";
            this.descripcionDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.4800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.descripcionDataTextBox1.StyleName = "Data";
            this.descripcionDataTextBox1.Value = "= Fields.Descripcion";
            // 
            // varCotizaDivisaDataTextBox1
            // 
            this.varCotizaDivisaDataTextBox1.CanGrow = true;
            this.varCotizaDivisaDataTextBox1.Format = "{0:P2}";
            this.varCotizaDivisaDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.varCotizaDivisaDataTextBox1.Name = "varCotizaDivisaDataTextBox1";
            this.varCotizaDivisaDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.299999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.varCotizaDivisaDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.varCotizaDivisaDataTextBox1.StyleName = "Data";
            this.varCotizaDivisaDataTextBox1.Value = "= Fields.VarCotizaDivisa/100";
            // 
            // ReportEvolucionIndicesBench
            // 
            this.DataSource = this.sqlDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportHeader,
            this.detail});
            this.Name = "Report3";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter1.Value = "399";
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
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(14.899999618530273D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox fechaDesdeDataTextBox;
        private Telerik.Reporting.TextBox fechaHastaDataTextBox;
        private Telerik.Reporting.TextBox varCotizaDivisaCaptionTextBox1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox cotizaDivDesdeDataTextBox1;
        private Telerik.Reporting.TextBox cotizaDivHastaDataTextBox1;
        private Telerik.Reporting.TextBox descripcionDataTextBox1;
        private Telerik.Reporting.TextBox varCotizaDivisaDataTextBox1;
    }
}