namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Valor_Liquidativo
{
    partial class ReportPatrimonio_ValorLiquidativoPRO_02
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPatrimonio_ValorLiquidativoPRO_02));
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.TituloReport = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBoxTituloLiquidativo = new Telerik.Reporting.TextBox();
            this.textBoxEvoLiquiFechaFin = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBoxValorliquiIni = new Telerik.Reporting.TextBox();
            this.textBoxValorliquiFin = new Telerik.Reporting.TextBox();
            this.textBoxVarLiquiPorcentageValue = new Telerik.Reporting.TextBox();
            this.textBoxEvoLiquiFechaIni = new Telerik.Reporting.TextBox();
            this.shape2 = new Telerik.Reporting.Shape();
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
            this.panel3 = new Telerik.Reporting.Panel();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.sqlDataSourceEvoPatri = new Telerik.Reporting.SqlDataSource();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.LogoPortada});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // LogoPortada
            // 
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.00010004233627114445D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // TituloReport
            // 
            this.TituloReport.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00030351828900165856D), Telerik.Reporting.Drawing.Unit.Cm(2.9802307288662178E-09D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.919697761535645D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportPatrimonio_ValorLiquidativoPRO" +
    "_02()";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.299901008605957D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.panel2,
            this.panel3});
            this.detail.Name = "detail";
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
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D), Telerik.Reporting.Drawing.Unit.Cm(5.299898624420166D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.9999990463256836D));
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
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D), Telerik.Reporting.Drawing.Unit.Cm(0.79989707469940186D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.9999990463256836D));
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
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D), Telerik.Reporting.Drawing.Unit.Cm(9.79990005493164D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100000381469727D), Telerik.Reporting.Drawing.Unit.Cm(1.9999998807907105D));
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(0.49999973177909851D));
            this.subReport1.Name = "subReport1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.Evolución.Evolución_índices_de_referencia.ReportEvolucionInd" +
    "icesBench, Reports_IICs, Version=1.1.48.0, Culture=neutral, PublicKeyToken=null";
            this.subReport1.ReportSource = typeReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.700005531311035D), Telerik.Reporting.Drawing.Unit.Cm(1.5000001192092896D));
            this.subReport1.ItemDataBound += new System.EventHandler(this.subReport1_ItemDataBound);
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.320001602172852D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // sqlDataSourceEvoPatri
            // 
            this.sqlDataSourceEvoPatri.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceEvoPatri.Name = "sqlDataSourceEvoPatri";
            this.sqlDataSourceEvoPatri.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSourceEvoPatri.SelectCommand = "dbo.ReportPatrimonio_ValorLiquidativo";
            this.sqlDataSourceEvoPatri.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2000001668930054D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // ReportPatrimonio_ValorLiquidativoPRO_02
            // 
            this.DataSource = this.sqlDataSourceEvoPatri;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportPatrimonio_ValorLiquidativoPRO_02";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(17D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
            reportParameter1.Value = "";
            reportParameter1.Visible = true;
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter2.Text = "Isin";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.TocText = "";
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.920001983642578D);
            this.ItemDataBinding += new System.EventHandler(this.ReportPatrimonio_ValorLiquidativoPRO_02_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlDataSourceEvoPatri;
        private Telerik.Reporting.TextBox textBoxEvoPatriFechaIni;
        private Telerik.Reporting.TextBox textBoxEvoPatriFechaFin;
        private Telerik.Reporting.TextBox textBoxVarEur;
        private Telerik.Reporting.TextBox textBoxVarPorcentage;
        private Telerik.Reporting.TextBox textBoxPatriGestionadoIni;
        private Telerik.Reporting.TextBox textBoxPatriGestionadoFin;
        private Telerik.Reporting.TextBox textBoxVarEurValue;
        private Telerik.Reporting.TextBox textBoxVarPorcentageValue;
        private Telerik.Reporting.TextBox textBoxEvoLiquiFechaIni;
        private Telerik.Reporting.TextBox textBoxEvoLiquiFechaFin;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBoxValorliquiIni;
        private Telerik.Reporting.TextBox textBoxValorliquiFin;
        private Telerik.Reporting.TextBox textBoxVarLiquiPorcentageValue;
        private Telerik.Reporting.TextBox textBoxTituloEvolucion;
        private Telerik.Reporting.TextBox textBoxTituloLiquidativo;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.Panel panel3;
    }
}