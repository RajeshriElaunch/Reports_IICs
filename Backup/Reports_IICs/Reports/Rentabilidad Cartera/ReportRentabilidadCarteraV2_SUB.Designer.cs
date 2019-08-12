namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    partial class ReportRentabilidadCarteraV2_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.DetailSection detail;
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule3 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule4 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.table2 = new Telerik.Reporting.Table();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.sqlDataSource2 = new Telerik.Reporting.SqlDataSource();
            this.table3 = new Telerik.Reporting.Table();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.sqlDataSource3 = new Telerik.Reporting.SqlDataSource();
            this.table4 = new Telerik.Reporting.Table();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.sqlDataSource4 = new Telerik.Reporting.SqlDataSource();
            detail = new Telerik.Reporting.DetailSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.4000000953674316D);
            detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1,
            this.table2,
            this.table3,
            this.table4});
            detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2027744054794312D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.8373546600341797D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox2);
            this.table1.Body.SetCellContent(0, 1, this.textBox4);
            tableGroup2.Name = "group";
            tableGroup2.ReportItem = this.textBox1;
            tableGroup3.Name = "group1";
            tableGroup3.ReportItem = this.textBox3;
            tableGroup1.ChildGroups.Add(tableGroup2);
            tableGroup1.ChildGroups.Add(tableGroup3);
            tableGroup1.Name = "tableGroup";
            tableGroup1.ReportItem = this.textBox7;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.DataSource = this.sqlDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox4,
            this.textBox7,
            this.textBox1,
            this.textBox3});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.table1.Name = "table1";
            tableGroup5.Name = "group2";
            tableGroup4.ChildGroups.Add(tableGroup5);
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "detailTableGroup";
            this.table1.RowGroups.Add(tableGroup4);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0401291847229D), Telerik.Reporting.Drawing.Unit.Cm(1.8549998998641968D));
            // 
            // textBox2
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= (Fields.Fecha.Month=1) And (Fields.Fecha.Year= Parameters.FechaInforme.Value.Ye" +
            "ar)", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= Fields.BackGroundColor", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox2.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1,
            formattingRule2});
            this.textBox2.Format = "{0:N4}";
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2027744054794312D), Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D));
            this.textBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Font.Name = "Tahoma";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.ValorLiquidativo";
            // 
            // textBox4
            // 
            this.textBox4.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1,
            formattingRule2});
            this.textBox4.Format = "{0:P2}";
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8373541831970215D), Telerik.Reporting.Drawing.Unit.Cm(0.46999993920326233D));
            this.textBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.Font.Name = "Tahoma";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.RentabilidadPeriodo/100";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2027744054794312D), Telerik.Reporting.Drawing.Unit.Cm(0.68500000238418579D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "V.L.";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8373541831970215D), Telerik.Reporting.Drawing.Unit.Cm(0.68500000238418579D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Font.Name = "Tahoma";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Rentabilidad periodo(anual/mensual)";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0401287078857422D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Font.Name = "Tahoma";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "";
            this.textBox7.Value = "= Fields.DescripcionIndice";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_RentabilidadCarteraV2";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // table2
            // 
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2091269493103027D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.8389608860015869D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table2.Body.SetCellContent(0, 0, this.textBox9);
            this.table2.Body.SetCellContent(0, 1, this.textBox13);
            tableGroup6.Name = "tableGroup1";
            tableGroup7.Name = "tableGroup3";
            this.table2.ColumnGroups.Add(tableGroup6);
            this.table2.ColumnGroups.Add(tableGroup7);
            this.table2.DataSource = this.sqlDataSource2;
            this.table2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox13});
            this.table2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(1.8553001880645752D));
            this.table2.Name = "table2";
            tableGroup8.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup8.Name = "detailTableGroup1";
            this.table2.RowGroups.Add(tableGroup8);
            this.table2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0480875968933105D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2091268301010132D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox13
            // 
            this.textBox13.Format = "{0:P2}";
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8389606475830078D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Tahoma";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox13.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "= (Fields.V2/Fields.V1)-1";
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource2.Name = "sqlDataSource2";
            this.sqlDataSource2.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Fecha", System.Data.DbType.DateTime, "= Parameters.FechaInforme.Value")});
            this.sqlDataSource2.SelectCommand = "dbo.Get_Temp_RentabilidadCarteraLastRowV2";
            this.sqlDataSource2.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // table3
            // 
            this.table3.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.851611852645874D)));
            this.table3.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D)));
            this.table3.Body.SetCellContent(0, 0, this.textBox5);
            tableGroup10.Name = "group";
            tableGroup10.ReportItem = this.textBox8;
            tableGroup9.ChildGroups.Add(tableGroup10);
            tableGroup9.Name = "tableGroup";
            tableGroup9.ReportItem = this.textBox11;
            this.table3.ColumnGroups.Add(tableGroup9);
            this.table3.DataSource = this.sqlDataSource3;
            this.table3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox11,
            this.textBox8});
            this.table3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.0748910903930664D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.table3.Name = "table3";
            tableGroup12.Name = "group2";
            tableGroup11.ChildGroups.Add(tableGroup12);
            tableGroup11.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup11.Name = "detailTableGroup";
            this.table3.RowGroups.Add(tableGroup11);
            this.table3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.851611852645874D), Telerik.Reporting.Drawing.Unit.Cm(1.8549998998641968D));
            // 
            // textBox5
            // 
            formattingRule3.Filters.Add(new Telerik.Reporting.Filter("= (Fields.Fecha.Month=1) And (Fields.Fecha.Year= Parameters.FechaInforme.Value.Ye" +
            "ar)", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            formattingRule4.Filters.Add(new Telerik.Reporting.Filter("= Fields.BackGroundColor", Telerik.Reporting.FilterOperator.Equal, "True"));
            formattingRule4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            this.textBox5.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule3,
            formattingRule4});
            this.textBox5.Format = "{0:P2}";
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.851611852645874D), Telerik.Reporting.Drawing.Unit.Cm(0.46999990940093994D));
            this.textBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Font.Name = "Tahoma";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "= CDbl(Fields.RentabilidadAcumulada)";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.851611852645874D), Telerik.Reporting.Drawing.Unit.Cm(0.68500000238418579D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "Rentabilidad periodo(anual/mensual)";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.851611852645874D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Font.Name = "Tahoma";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "";
            this.textBox11.Value = "Rentabilidad IndiceNovarex";
            // 
            // sqlDataSource3
            // 
            this.sqlDataSource3.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource3.Name = "sqlDataSource3";
            this.sqlDataSource3.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource3.SelectCommand = "dbo.Get_RentabilidadIndiceNovarexV2";
            this.sqlDataSource3.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // table4
            // 
            this.table4.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.8514187335968018D)));
            this.table4.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table4.Body.SetCellContent(0, 0, this.textBox10);
            tableGroup13.Name = "tableGroup3";
            this.table4.ColumnGroups.Add(tableGroup13);
            this.table4.DataSource = this.sqlDataSource4;
            this.table4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox10});
            this.table4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.0750837326049805D), Telerik.Reporting.Drawing.Unit.Cm(1.8552000522613525D));
            this.table4.Name = "table4";
            tableGroup14.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup14.Name = "detailTableGroup1";
            this.table4.RowGroups.Add(tableGroup14);
            this.table4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8514187335968018D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:P2}";
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8514187335968018D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Name = "Tahoma";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox10.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= (CDbl(Fields.V2)/CDbl(Fields.V1))-1";
            // 
            // sqlDataSource4
            // 
            this.sqlDataSource4.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource4.Name = "sqlDataSource4";
            this.sqlDataSource4.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Fecha", System.Data.DbType.DateTime, "= Parameters.FechaInforme.Value")});
            this.sqlDataSource4.SelectCommand = "Get_RentabilidadIndiceNovarexLastRowV2";
            this.sqlDataSource4.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // ReportRentabilidadCarteraV2_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            detail});
            this.Name = "ReportRentabilidadCarteraV2_SUB";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(3D), Telerik.Reporting.Drawing.Unit.Mm(3D), Telerik.Reporting.Drawing.Unit.Mm(3D), Telerik.Reporting.Drawing.Unit.Mm(3D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.Name = "FechaInforme";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.Value = "30/09/2015";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(6.9265027046203613D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.Table table2;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.SqlDataSource sqlDataSource2;
        private Telerik.Reporting.SqlDataSource sqlDataSource3;
        private Telerik.Reporting.Table table3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.Table table4;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.SqlDataSource sqlDataSource4;
    }
}