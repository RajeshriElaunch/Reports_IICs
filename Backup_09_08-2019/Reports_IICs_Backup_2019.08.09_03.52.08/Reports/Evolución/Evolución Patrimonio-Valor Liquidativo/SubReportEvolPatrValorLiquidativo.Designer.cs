namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Valor_Liquidativo
{
    partial class SubReportEvolPatrValorLiquidativo
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
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBoxTituloEvolucion = new Telerik.Reporting.TextBox();
            this.textBoxEvoPatriFechaFin = new Telerik.Reporting.TextBox();
            this.textBoxVarEur = new Telerik.Reporting.TextBox();
            this.textBoxVarPorcentage = new Telerik.Reporting.TextBox();
            this.textBoxPatriGestionadoIni = new Telerik.Reporting.TextBox();
            this.textBoxPatriGestionadoFin = new Telerik.Reporting.TextBox();
            this.textBoxVarEurValue = new Telerik.Reporting.TextBox();
            this.textBoxVarPorcentageValue = new Telerik.Reporting.TextBox();
            this.textBoxEvoPatriFechaIni = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBoxTituloLiquidativo = new Telerik.Reporting.TextBox();
            this.textBoxEvoLiquiFechaFin = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBoxValorliquiIni = new Telerik.Reporting.TextBox();
            this.textBoxValorliquiFin = new Telerik.Reporting.TextBox();
            this.textBoxVarLiquiPorcentageValue = new Telerik.Reporting.TextBox();
            this.textBoxEvoLiquiFechaIni = new Telerik.Reporting.TextBox();
            this.shape2 = new Telerik.Reporting.Shape();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.shape3 = new Telerik.Reporting.Shape();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.ReportPatrimonio_ValorLiquidativo";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(37.900001525878906D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2,
            this.panel1,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.shape3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9});
            this.detail.Name = "detail";
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxTituloEvolucion,
            this.textBoxEvoPatriFechaFin,
            this.textBoxVarEur,
            this.textBoxVarPorcentage,
            this.textBoxPatriGestionadoIni,
            this.textBoxPatriGestionadoFin,
            this.textBoxVarEurValue,
            this.textBoxVarPorcentageValue,
            this.textBoxEvoPatriFechaIni,
            this.shape1});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.8999996185302734D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.9999990463256836D));
            this.panel2.Style.Visible = false;
            // 
            // textBoxTituloEvolucion
            // 
            this.textBoxTituloEvolucion.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.50000035762786865D));
            this.textBoxTituloEvolucion.Name = "textBoxTituloEvolucion";
            this.textBoxTituloEvolucion.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxTituloEvolucion.Style.Font.Bold = true;
            this.textBoxTituloEvolucion.Value = "= Reports_IICs.Helpers.ReportFunctions.SubtituloGestionadoRP_ValorLiquidativo(Fie" +
    "lds.FechaFin.Year)";
            // 
            // textBoxEvoPatriFechaFin
            // 
            this.textBoxEvoPatriFechaFin.Format = "{0:d}";
            this.textBoxEvoPatriFechaFin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(1.6000003814697266D));
            this.textBoxEvoPatriFechaFin.Name = "textBoxEvoPatriFechaFin";
            this.textBoxEvoPatriFechaFin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxEvoPatriFechaFin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxEvoPatriFechaFin.Value = "= Fields.FechaFin";
            // 
            // textBoxVarEur
            // 
            this.textBoxVarEur.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(1.3708337545394898D));
            this.textBoxVarEur.Name = "textBoxVarEur";
            this.textBoxVarEur.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3999993801116943D), Telerik.Reporting.Drawing.Unit.Cm(0.89999926090240479D));
            this.textBoxVarEur.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxVarEur.Value = "VARIACIÓN en euros";
            // 
            // textBoxVarPorcentage
            // 
            this.textBoxVarPorcentage.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.755670547485352D), Telerik.Reporting.Drawing.Unit.Cm(1.3708337545394898D));
            this.textBoxVarPorcentage.Name = "textBoxVarPorcentage";
            this.textBoxVarPorcentage.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999002456665039D), Telerik.Reporting.Drawing.Unit.Cm(0.89999926090240479D));
            this.textBoxVarPorcentage.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxVarPorcentage.Value = "VARIACIÓN en %";
            // 
            // textBoxPatriGestionadoIni
            // 
            this.textBoxPatriGestionadoIni.Format = "{0:N0}";
            this.textBoxPatriGestionadoIni.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxPatriGestionadoIni.Name = "textBoxPatriGestionadoIni";
            this.textBoxPatriGestionadoIni.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxPatriGestionadoIni.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxPatriGestionadoIni.Value = "= Fields.PatrimonioGestionadoIni";
            // 
            // textBoxPatriGestionadoFin
            // 
            this.textBoxPatriGestionadoFin.Format = "{0:N0}";
            this.textBoxPatriGestionadoFin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxPatriGestionadoFin.Name = "textBoxPatriGestionadoFin";
            this.textBoxPatriGestionadoFin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxPatriGestionadoFin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxPatriGestionadoFin.Value = "= Fields.PatrimonioGestionadoFin";
            // 
            // textBoxVarEurValue
            // 
            this.textBoxVarEurValue.Format = "{0:N0}";
            this.textBoxVarEurValue.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxVarEurValue.Name = "textBoxVarEurValue";
            this.textBoxVarEurValue.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxVarEurValue.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxVarEurValue.Value = "= Fields.PatrimonioGestionadoFin- Fields.PatrimonioGestionadoIni";
            // 
            // textBoxVarPorcentageValue
            // 
            this.textBoxVarPorcentageValue.Format = "{0:N2}";
            this.textBoxVarPorcentageValue.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.800004005432129D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxVarPorcentageValue.Name = "textBoxVarPorcentageValue";
            this.textBoxVarPorcentageValue.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1000010967254639D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxVarPorcentageValue.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxVarPorcentageValue.Value = "=IIF(Fields.PatrimonioGestionadoIni <> 0,\r\nCDbl((Fields.PatrimonioGestionadoFin-F" +
    "ields.PatrimonioGestionadoIni)/CDbl(Fields.PatrimonioGestionadoIni))*100,\r\n\'-\')";
            // 
            // textBoxEvoPatriFechaIni
            // 
            this.textBoxEvoPatriFechaIni.Format = "{0:d}";
            this.textBoxEvoPatriFechaIni.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(1.6000003814697266D));
            this.textBoxEvoPatriFechaIni.Name = "textBoxEvoPatriFechaIni";
            this.textBoxEvoPatriFechaIni.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxEvoPatriFechaIni.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxEvoPatriFechaIni.Value = "= Fields.Fechaini";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(2.2998001575469971D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.655569076538086D), Telerik.Reporting.Drawing.Unit.Cm(0.3999994695186615D));
            this.shape1.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxTituloLiquidativo,
            this.textBoxEvoLiquiFechaFin,
            this.textBox11,
            this.textBoxValorliquiIni,
            this.textBoxValorliquiFin,
            this.textBoxVarLiquiPorcentageValue,
            this.textBoxEvoLiquiFechaIni,
            this.shape2});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(13.999999046325684D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.9999990463256836D));
            this.panel1.Style.Visible = false;
            // 
            // textBoxTituloLiquidativo
            // 
            this.textBoxTituloLiquidativo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.49999973177909851D));
            this.textBoxTituloLiquidativo.Name = "textBoxTituloLiquidativo";
            this.textBoxTituloLiquidativo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxTituloLiquidativo.Style.Font.Bold = true;
            this.textBoxTituloLiquidativo.Value = "= Reports_IICs.Helpers.ReportFunctions.SubtituloLiquidativoRP_ValorLiquidativo(Fi" +
    "elds.FechaFin.Year)";
            // 
            // textBoxEvoLiquiFechaFin
            // 
            this.textBoxEvoLiquiFechaFin.Format = "{0:d}";
            this.textBoxEvoLiquiFechaFin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.7635002136230469D), Telerik.Reporting.Drawing.Unit.Cm(1.5999991893768311D));
            this.textBoxEvoLiquiFechaFin.Name = "textBoxEvoLiquiFechaFin";
            this.textBoxEvoLiquiFechaFin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxEvoLiquiFechaFin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxEvoLiquiFechaFin.Value = "= Fields.FechaFin";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.800002098083496D), Telerik.Reporting.Drawing.Unit.Cm(1.3999992609024048D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.099902868270874D), Telerik.Reporting.Drawing.Unit.Cm(0.89999991655349731D));
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "VARIACIÓN en %";
            // 
            // textBoxValorliquiIni
            // 
            this.textBoxValorliquiIni.Format = "{0:N3}";
            this.textBoxValorliquiIni.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxValorliquiIni.Name = "textBoxValorliquiIni";
            this.textBoxValorliquiIni.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxValorliquiIni.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxValorliquiIni.Value = "= Fields.ValorLiquidativoIni";
            // 
            // textBoxValorliquiFin
            // 
            this.textBoxValorliquiFin.Format = "{0:N3}";
            this.textBoxValorliquiFin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.7635002136230469D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxValorliquiFin.Name = "textBoxValorliquiFin";
            this.textBoxValorliquiFin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxValorliquiFin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxValorliquiFin.Value = "= Fields.ValorLiquidativofin";
            // 
            // textBoxVarLiquiPorcentageValue
            // 
            this.textBoxVarLiquiPorcentageValue.Format = "{0:N2}";
            this.textBoxVarLiquiPorcentageValue.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.800004005432129D), Telerik.Reporting.Drawing.Unit.Cm(2.7999997138977051D));
            this.textBoxVarLiquiPorcentageValue.Name = "textBoxVarLiquiPorcentageValue";
            this.textBoxVarLiquiPorcentageValue.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999984741210938D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxVarLiquiPorcentageValue.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxVarLiquiPorcentageValue.Value = "= ((Fields.ValorLiquidativofin- Fields.ValorLiquidativoIni)/Fields.ValorLiquidati" +
    "voIni)*100";
            // 
            // textBoxEvoLiquiFechaIni
            // 
            this.textBoxEvoLiquiFechaIni.Format = "{0:d}";
            this.textBoxEvoLiquiFechaIni.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(1.5999991893768311D));
            this.textBoxEvoLiquiFechaIni.Name = "textBoxEvoLiquiFechaIni";
            this.textBoxEvoLiquiFechaIni.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBoxEvoLiquiFechaIni.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxEvoLiquiFechaIni.Value = "= Fields.Fechaini";
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(2.3002009391784668D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.655569076538086D), Telerik.Reporting.Drawing.Unit.Cm(0.3999994695186615D));
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.69999986886978149D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Value = "= Reports_IICs.Helpers.ReportFunctions.SubtituloGestionadoRP_ValorLiquidativo(Fie" +
    "lds.FechaFin.Year)";
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:d}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.2000001072883606D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999993324279785D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Value = "= Fields.Fechaini.Date";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:N0}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6999993324279785D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Value = "= Fields.PatrimonioGestionadoIni";
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20999999344348908D), Telerik.Reporting.Drawing.Unit.Cm(2.2000000476837158D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.655569076538086D), Telerik.Reporting.Drawing.Unit.Cm(0.3999994695186615D));
            this.shape3.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox4.Value = "textBox2";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox5.Value = "textBox2";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3999981880187988D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox6.Value = "textBox2";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.800003051757813D), Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0555667877197266D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox8.Value = "textBox2";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3999981880187988D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox9.Value = "textBox2";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.755670547485352D), Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0998988151550293D), Telerik.Reporting.Drawing.Unit.Cm(0.599999725818634D));
            this.textBox7.Value = "textBox2";
            // 
            // SubReportEvolPatrValorLiquidativo
            // 
            this.DataSource = this.sqlDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "SubReportEvolPatrValorLiquidativo";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "Isin";
            reportParameter1.Text = "Isin";
            reportParameter2.Name = "CodigoIC";
            reportParameter2.Text = "CodigoIC";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBoxTituloEvolucion;
        private Telerik.Reporting.TextBox textBoxEvoPatriFechaFin;
        private Telerik.Reporting.TextBox textBoxVarEur;
        private Telerik.Reporting.TextBox textBoxVarPorcentage;
        private Telerik.Reporting.TextBox textBoxPatriGestionadoIni;
        private Telerik.Reporting.TextBox textBoxPatriGestionadoFin;
        private Telerik.Reporting.TextBox textBoxVarEurValue;
        private Telerik.Reporting.TextBox textBoxVarPorcentageValue;
        private Telerik.Reporting.TextBox textBoxEvoPatriFechaIni;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBoxTituloLiquidativo;
        private Telerik.Reporting.TextBox textBoxEvoLiquiFechaFin;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBoxValorliquiIni;
        private Telerik.Reporting.TextBox textBoxValorliquiFin;
        private Telerik.Reporting.TextBox textBoxVarLiquiPorcentageValue;
        private Telerik.Reporting.TextBox textBoxEvoLiquiFechaIni;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
    }
}