namespace Reports_IICs.Reports.Cartera
{
    partial class Report_PRO_12
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.DetailSection detail;
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule3 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule4 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule5 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.sqlDataSource_PRO_12 = new Telerik.Reporting.SqlDataSource();
            detail = new Telerik.Reporting.DetailSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D);
            detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox6,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox13,
            this.textBox15});
            detail.Name = "detail";
            // 
            // textBox1
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox1.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox1.Style.Font.Name = "Tahoma";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox1.Value = "Total patrimonio";
            // 
            // textBox2
            // 
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox2.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.80000007152557373D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox2.Style.Font.Name = "Tahoma";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox2.Value = "Rentabilidad";
            // 
            // textBox3
            // 
            this.textBox3.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox3.Style.Font.Name = "Tahoma";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox3.Value = "Total participaciones";
            // 
            // textBox4
            // 
            formattingRule3.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "1"));
            formattingRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox4.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule3});
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox4.Style.Font.Name = "Tahoma";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox4.Value = "Valor liquidativo";
            // 
            // textBox6
            // 
            formattingRule4.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            formattingRule5.Filters.Add(new Telerik.Reporting.Filter("Parameters.ShowTesoreria.Value", Telerik.Reporting.FilterOperator.Equal, "False"));
            formattingRule5.Style.Visible = false;
            this.textBox6.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule4,
            formattingRule5});
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(2.4000000953674316D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox6.Style.Font.Name = "Tahoma";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox6.Style.Visible = true;
            this.textBox6.Value = "Saldo Tesorería";
            // 
            // textBox8
            // 
            this.textBox8.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox8.Format = "{0:N2}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0002000331878662D), Telerik.Reporting.Drawing.Unit.Cm(0.80000007152557373D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8998000621795654D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox8.Style.Font.Name = "Tahoma";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Value = "= Fields.Rentabilidad";
            // 
            // textBox9
            // 
            this.textBox9.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.textBox9.Format = "{0:N2}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox9.Style.Font.Name = "Tahoma";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.Value = "= Fields.TotalPatrimonio";
            // 
            // textBox10
            // 
            this.textBox10.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.textBox10.Format = "{0:N4}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0002000331878662D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8998000621795654D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox10.Style.Font.Name = "Tahoma";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Value = "= Fields.TotalParticipaciones";
            // 
            // textBox11
            // 
            this.textBox11.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule3});
            this.textBox11.Format = "{0:N10}";
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0002002716064453D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8998000621795654D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox11.Style.Font.Name = "Tahoma";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.Value = "= Fields.ValorLiquidativo";
            // 
            // textBox13
            // 
            this.textBox13.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule4,
            formattingRule5});
            this.textBox13.Format = "{0:N2}";
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0002000331878662D), Telerik.Reporting.Drawing.Unit.Cm(2.4000000953674316D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8998000621795654D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.textBox13.Style.Font.Name = "Tahoma";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.Visible = true;
            this.textBox13.Value = "= Fields.SaldoTesoreria";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.29999992251396179D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.7999997138977051D), Telerik.Reporting.Drawing.Unit.Cm(0.40000012516975403D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Name = "Tahoma";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "= Parameters.IsinDesc.Value";
            // 
            // sqlDataSource_PRO_12
            // 
            this.sqlDataSource_PRO_12.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource_PRO_12.Name = "sqlDataSource_PRO_12";
            this.sqlDataSource_PRO_12.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource_PRO_12.SelectCommand = "dbo.Get_Temp_PRO_12";
            this.sqlDataSource_PRO_12.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // Report_PRO_12
            // 
            this.DataSource = this.sqlDataSource_PRO_12;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            detail});
            this.Name = "Report_PRO_12";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(80D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "IsinDesc";
            reportParameter1.Text = "IsinDesc";
            reportParameter1.Value = "A";
            reportParameter2.Name = "CodigoIC";
            reportParameter2.Text = "CodigoIC";
            reportParameter2.Value = "278";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "Isin";
            reportParameter3.Text = "Isin";
            reportParameter3.Value = "es0164837009";
            reportParameter4.Name = "ShowTesoreria";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Boolean;
            reportParameter4.Value = "False";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(5.9999995231628418D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.SqlDataSource sqlDataSource_PRO_12;
        private Telerik.Reporting.TextBox textBox15;
    }
}