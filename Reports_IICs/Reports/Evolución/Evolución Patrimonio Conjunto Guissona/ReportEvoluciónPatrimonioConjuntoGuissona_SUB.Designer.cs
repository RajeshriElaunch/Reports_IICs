namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Conjunto_Guissona
{
    partial class ReportEvoluciónPatrimonioConjuntoGuissona_SUB
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
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table2 = new Telerik.Reporting.Table();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.tableFecha = new Telerik.Reporting.Table();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.sqlDataSource2 = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.KeepTogether = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.699999988079071D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Font.Name = "Tahoma";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "= Fields.Descripcion";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.1488981246948242D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table2,
            this.tableFecha});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // table2
            // 
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D)));
            this.table2.Body.SetCellContent(0, 0, this.textBox4);
            tableGroup1.Name = "tableGroup1";
            tableGroup1.ReportItem = this.textBox1;
            this.table2.ColumnGroups.Add(tableGroup1);
            this.table2.DataSource = this.sqlDataSource1;
            this.table2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox1});
            this.table2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.table2.Name = "table2";
            tableGroup2.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup2.Name = "detailTableGroup2";
            this.table2.RowGroups.Add(tableGroup2);
            this.table2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:d}";
            this.textBox4.KeepTogether = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.Font.Name = "Tahoma";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.FechaConstitucion";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_EvolucionPatrimonioConjuntoGuissona_Fondos";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // tableFecha
            // 
            this.tableFecha.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475D)));
            this.tableFecha.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.44859787821769714D)));
            this.tableFecha.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.tableFecha.Body.SetCellContent(0, 0, this.textBox2);
            this.tableFecha.Body.SetCellContent(1, 0, this.textBox3);
            tableGroup3.Name = "group";
            this.tableFecha.ColumnGroups.Add(tableGroup3);
            this.tableFecha.DataSource = this.sqlDataSource2;
            this.tableFecha.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3});
            this.tableFecha.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(1.2003002166748047D));
            this.tableFecha.Name = "tableFecha";
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "detailTableGroup";
            tableGroup5.Name = "group1";
            this.tableFecha.RowGroups.Add(tableGroup4);
            this.tableFecha.RowGroups.Add(tableGroup5);
            this.tableFecha.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475D), Telerik.Reporting.Drawing.Unit.Cm(0.94859790802001953D));
            // 
            // textBox2
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("= RowNumber()%2 ", Telerik.Reporting.FilterOperator.Equal, "0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(227)))));
            formattingRule2.Filters.Add(new Telerik.Reporting.Filter("= CInt(Fields.Fecha.Year)", Telerik.Reporting.FilterOperator.Equal, "= CInt(Parameters.YearInforme.Value)"));
            formattingRule2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1,
            formattingRule2});
            this.textBox2.Format = "{0:N0}";
            this.textBox2.KeepTogether = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475D), Telerik.Reporting.Drawing.Unit.Cm(0.44859787821769714D));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Font.Name = "Tahoma";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Value = "=IIf(Fields.Patrimonio = 0,\"-\",IsNull(Fields.Patrimonio,\"-\"))";
            // 
            // textBox3
            // 
            this.textBox3.KeepTogether = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Font.Name = "Tahoma";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.StyleName = "";
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource2.Name = "sqlDataSource2";
            this.sqlDataSource2.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSource2.SelectCommand = "dbo.Get_Temp_EvolucionPatrimonioConjuntoGuissona";
            this.sqlDataSource2.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // ReportEvoluciónPatrimonioConjuntoGuissona_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "ReportEvoluciónPatrimonioConjuntoGuissona_SUB";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Mm(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Mm(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Mm(5.4000000953674316D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "YearInforme";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(2.60010027885437D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Table table2;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.Table tableFecha;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.SqlDataSource sqlDataSource2;
        private Telerik.Reporting.TextBox textBox3;
    }
}