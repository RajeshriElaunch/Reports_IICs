namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    partial class ReportRentabilidadCarteraIndiceV2_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table5 = new Telerik.Reporting.Table();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.sqlDataSource5 = new Telerik.Reporting.SqlDataSource();
            this.table4 = new Telerik.Reporting.Table();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.sqlDataSource4 = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873492240905762D), Telerik.Reporting.Drawing.Unit.Cm(0.68500000238418579D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "Rentabilidad periodo(anual/mensual)";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873492240905762D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.Font.Name = "Tahoma";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.StyleName = "";
            this.textBox14.Value = "= First(Fields.DescripcionIndice)";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.3553001880645752D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table5,
            this.table4});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // table5
            // 
            this.table5.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.7873492240905762D)));
            this.table5.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D)));
            this.table5.Body.SetCellContent(0, 0, this.textBox6);
            tableGroup2.Name = "group";
            tableGroup2.ReportItem = this.textBox12;
            tableGroup1.ChildGroups.Add(tableGroup2);
            tableGroup1.Name = "tableGroup";
            tableGroup1.ReportItem = this.textBox14;
            this.table5.ColumnGroups.Add(tableGroup1);
            this.table5.DataSource = this.sqlDataSource5;
            this.table5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox6,
            this.textBox14,
            this.textBox12});
            this.table5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012650552205741406D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.table5.Name = "table5";
            tableGroup4.Name = "group2";
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup3.Name = "detailTableGroup";
            this.table5.RowGroups.Add(tableGroup3);
            this.table5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873492240905762D), Telerik.Reporting.Drawing.Unit.Cm(1.8549998998641968D));
            // 
            // textBox6
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= (Fields.Fecha.Month=1) And (Fields.Fecha.Year= Parameters.FechaInforme.Value.Ye" +
            "ar)", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= Fields.BackGroundColor", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox6.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1,
            formattingRule2});
            this.textBox6.Format = "{0:P2}";
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873492240905762D), Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D));
            this.textBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.Font.Name = "Tahoma";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= CDbl( Fields.RentabilidadPeriodo/100)\r\n";
            // 
            // sqlDataSource5
            // 
            this.sqlDataSource5.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource5.Name = "sqlDataSource5";
            this.sqlDataSource5.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource5.SelectCommand = "dbo.Get_Temp_RentabilidadCarteraIndiceV2";
            this.sqlDataSource5.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // table4
            // 
            this.table4.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.7873489856719971D)));
            this.table4.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table4.Body.SetCellContent(0, 0, this.textBox10);
            tableGroup5.Name = "tableGroup3";
            this.table4.ColumnGroups.Add(tableGroup5);
            this.table4.DataSource = this.sqlDataSource4;
            this.table4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox10});
            this.table4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012650552205741406D), Telerik.Reporting.Drawing.Unit.Cm(1.8553001880645752D));
            this.table4.Name = "table4";
            tableGroup6.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup6.Name = "detailTableGroup1";
            this.table4.RowGroups.Add(tableGroup6);
            this.table4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873489856719971D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:P2}";
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7873489856719971D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Name = "Tahoma";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox10.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= (Fields.V2/Fields.V1)-1";
            // 
            // sqlDataSource4
            // 
            this.sqlDataSource4.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource4.Name = "sqlDataSource4";
            this.sqlDataSource4.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Fecha", System.Data.DbType.DateTime, "= Parameters.FechaInforme.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Esindice", System.Data.DbType.Boolean, "= Parameters.Esindice.Value")});
            this.sqlDataSource4.SelectCommand = "dbo.Get_Temp_RentabilidadCarteraLastRowV2";
            this.sqlDataSource4.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // ReportRentabilidadCarteraIndiceV2_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "ReportRentabilidadCarteraIndiceV2_SUB";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "FechaInforme";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.Value = "30/09/2015";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "Esindice";
            reportParameter4.Text = "Esindice";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Boolean;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Table table5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.SqlDataSource sqlDataSource5;
        private Telerik.Reporting.Table table4;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.SqlDataSource sqlDataSource4;
    }
}