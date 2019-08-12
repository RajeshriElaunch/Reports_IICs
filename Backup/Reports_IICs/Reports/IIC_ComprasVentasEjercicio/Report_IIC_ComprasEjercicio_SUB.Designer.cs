namespace Reports_IICs.Reports.IIC_ComprasVentasEjercicio
{
    partial class Report_IIC_ComprasEjercicio_SUB
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
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.fechaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.descripcionValorCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cantidadCaptionTextBox = new Telerik.Reporting.TextBox();
            this.precioCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fechaDataTextBox = new Telerik.Reporting.TextBox();
            this.descripcionValorDataTextBox = new Telerik.Reporting.TextBox();
            this.cantidadDataTextBox = new Telerik.Reporting.TextBox();
            this.precioDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.2997000515460968D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaCaptionTextBox,
            this.descripcionValorCaptionTextBox,
            this.cantidadCaptionTextBox,
            this.precioCaptionTextBox,
            this.textBox3,
            this.textBox8,
            this.textBox2});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelsGroupHeaderSection.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // fechaCaptionTextBox
            // 
            this.fechaCaptionTextBox.CanGrow = true;
            this.fechaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.fechaCaptionTextBox.Name = "fechaCaptionTextBox";
            this.fechaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8576666116714478D), Telerik.Reporting.Drawing.Unit.Cm(0.69970005750656128D));
            this.fechaCaptionTextBox.Style.Font.Bold = true;
            this.fechaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fechaCaptionTextBox.StyleName = "Caption";
            this.fechaCaptionTextBox.Value = "Oper.";
            // 
            // descripcionValorCaptionTextBox
            // 
            this.descripcionValorCaptionTextBox.CanGrow = true;
            this.descripcionValorCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.7407634258270264D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.descripcionValorCaptionTextBox.Name = "descripcionValorCaptionTextBox";
            this.descripcionValorCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.355903148651123D), Telerik.Reporting.Drawing.Unit.Cm(0.69979995489120483D));
            this.descripcionValorCaptionTextBox.Style.Font.Bold = true;
            this.descripcionValorCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionValorCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.descripcionValorCaptionTextBox.StyleName = "Caption";
            this.descripcionValorCaptionTextBox.Value = "Nombre Valor";
            // 
            // cantidadCaptionTextBox
            // 
            this.cantidadCaptionTextBox.CanGrow = true;
            this.cantidadCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.100001335144043D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.cantidadCaptionTextBox.Name = "cantidadCaptionTextBox";
            this.cantidadCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.69979995489120483D));
            this.cantidadCaptionTextBox.Style.Font.Bold = true;
            this.cantidadCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.cantidadCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cantidadCaptionTextBox.StyleName = "Caption";
            this.cantidadCaptionTextBox.Value = "Cantidad";
            // 
            // precioCaptionTextBox
            // 
            this.precioCaptionTextBox.CanGrow = true;
            this.precioCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.precioCaptionTextBox.Name = "precioCaptionTextBox";
            this.precioCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0589320659637451D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.precioCaptionTextBox.Style.Font.Bold = true;
            this.precioCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.precioCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.precioCaptionTextBox.StyleName = "Caption";
            this.precioCaptionTextBox.Value = "Precio";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.8578668832778931D), Telerik.Reporting.Drawing.Unit.Cm(0.0003000462893396616D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8826968669891357D), Telerik.Reporting.Drawing.Unit.Cm(0.69949996471405029D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.StyleName = "Normal.TableHeader";
            this.textBox3.Value = "T. Mov.";
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0:d}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.25913143157959D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8408699035644531D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.StyleName = "Normal.TableHeader";
            this.textBox8.Value = "Cotización Cierre (€)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.100200653076172D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9329236745834351D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.StyleName = "Normal.TableHeader";
            this.textBox2.Value = "Variación desde compra";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@TipoMovimiento", System.Data.DbType.String, "= Parameters.TipoMovimiento.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@UltimaFechaInforme", System.Data.DbType.DateTime, "= Parameters.UltimaFechaInforme.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_IIC_ComprasVentasEjercicio";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= Fields.PAINTLINE", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Dotted;
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1,
            formattingRule2});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40029987692832947D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fechaDataTextBox,
            this.descripcionValorDataTextBox,
            this.cantidadDataTextBox,
            this.precioDataTextBox,
            this.textBox11,
            this.textBox16,
            this.textBox10});
            this.detail.Name = "detail";
            // 
            // fechaDataTextBox
            // 
            this.fechaDataTextBox.CanGrow = true;
            this.fechaDataTextBox.Format = "{0:d}";
            this.fechaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.fechaDataTextBox.Name = "fechaDataTextBox";
            this.fechaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8576666116714478D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.fechaDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.fechaDataTextBox.StyleName = "Data";
            this.fechaDataTextBox.Value = "= Fields.Fecha";
            // 
            // descripcionValorDataTextBox
            // 
            this.descripcionValorDataTextBox.CanGrow = true;
            this.descripcionValorDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.7407629489898682D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.descripcionValorDataTextBox.Name = "descripcionValorDataTextBox";
            this.descripcionValorDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.355903148651123D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.descripcionValorDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.descripcionValorDataTextBox.StyleName = "Data";
            this.descripcionValorDataTextBox.Value = "= Fields.DescripcionValor";
            // 
            // cantidadDataTextBox
            // 
            this.cantidadDataTextBox.CanGrow = true;
            this.cantidadDataTextBox.Format = "{0:N0}";
            this.cantidadDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.100001335144043D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.cantidadDataTextBox.Name = "cantidadDataTextBox";
            this.cantidadDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.cantidadDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.cantidadDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.cantidadDataTextBox.StyleName = "Data";
            this.cantidadDataTextBox.Value = "= Fields.Cantidad";
            // 
            // precioDataTextBox
            // 
            this.precioDataTextBox.CanGrow = true;
            this.precioDataTextBox.Format = "{0:N2}";
            this.precioDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.00029988479218445718D));
            this.precioDataTextBox.Name = "precioDataTextBox";
            this.precioDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0589320659637451D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.precioDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.precioDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.precioDataTextBox.StyleName = "Data";
            this.precioDataTextBox.Value = "= Fields.Precio";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.8578667640686035D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8826968669891357D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "Normal.TableBody";
            this.textBox11.Value = "= Fields.TipoMovimiento";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:N2}";
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.25913143157959D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8408699035644531D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox16.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.textBox16.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.StyleName = "Normal.TableBody";
            this.textBox16.Value = "=IIF(Fields.CotizaciónFechaFin IS Null, \"vendido\", Fields.CotizaciónFechaFin)";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:P2}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.100200653076172D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9329236745834351D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.textBox10.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "Normal.TableBody";
            this.textBox10.Value = "=IIF(Fields.Precio = 0 Or Fields.CotizaciónFechaFin IS NULL, \'     -     \', (-1*(" +
    "Fields.Precio- Fields.CotizaciónFechaFin)/ IIF(Fields.Precio <> 0,Fields.Precio," +
    "1)))";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.59999996423721313D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9907767435070127E-05D), Telerik.Reporting.Drawing.Unit.Cm(0.00010001542250392959D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4036668539047241D), Telerik.Reporting.Drawing.Unit.Cm(0.49999982118606567D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Tahoma";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Value = "COMPRAS";
            // 
            // Report_IIC_ComprasEjercicio_SUB
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
            this.detail,
            this.reportHeaderSection1});
            this.Name = "Report_IIC_ComprasEjercicio_SUB";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Mm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Mm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Mm(0.10000000149011612D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter1.Value = "403";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "TipoMovimiento";
            reportParameter3.Text = "TipoMovimiento";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "FechaInforme";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter5.AllowNull = true;
            reportParameter5.Name = "UltimaFechaInforme";
            reportParameter5.Text = "UltimaFechaInforme";
            reportParameter5.Type = Telerik.Reporting.ReportParameterType.DateTime;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(17.033124923706055D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox fechaCaptionTextBox;
        private Telerik.Reporting.TextBox descripcionValorCaptionTextBox;
        private Telerik.Reporting.TextBox cantidadCaptionTextBox;
        private Telerik.Reporting.TextBox precioCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox fechaDataTextBox;
        private Telerik.Reporting.TextBox descripcionValorDataTextBox;
        private Telerik.Reporting.TextBox cantidadDataTextBox;
        private Telerik.Reporting.TextBox precioDataTextBox;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
    }
}