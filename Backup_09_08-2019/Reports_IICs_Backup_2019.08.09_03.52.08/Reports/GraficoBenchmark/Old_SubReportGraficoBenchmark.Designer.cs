namespace Reports_IICs.Reports.GraficoBenchmark
{
    partial class Old_SubReportGraficoBenchmark
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.Drawing.ColorPalette colorPalette1 = new Telerik.Reporting.Drawing.ColorPalette();
            Telerik.Reporting.GraphTitle graphTitle1 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.DateTimeScale dateTimeScale1 = new Telerik.Reporting.DateTimeScale();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSourceGeneral = new Telerik.Reporting.SqlDataSource();
            this.sqlDataSourceGraph = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBoxISIN = new Telerik.Reporting.TextBox();
            this.textBReportTitle = new Telerik.Reporting.TextBox();
            this.textBPeriod = new Telerik.Reporting.TextBox();
            this.RYS2009 = new Telerik.Reporting.Graph();
            this.cartesianCoordinateSystem2 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis4 = new Telerik.Reporting.GraphAxis();
            this.graphAxis3 = new Telerik.Reporting.GraphAxis();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.lineSeries2 = new Telerik.Reporting.LineSeries();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSourceGeneral
            // 
            this.sqlDataSourceGeneral.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceGeneral.Name = "sqlDataSourceGeneral";
            this.sqlDataSourceGeneral.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "384")});
            this.sqlDataSourceGeneral.SelectCommand = "SELECT MIN ( [Fecha]) AS \"MinDate\" , MAX ( [Fecha]) AS \"MaxDate\"      \r\nFROM [Rep" +
    "orts_IICS].[dbo].[Temp_GraficoIBenchmark]\r\nWHERE Codigoic= @CodigoIC";
            // 
            // sqlDataSourceGraph
            // 
            this.sqlDataSourceGraph.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceGraph.Name = "sqlDataSourceGraph";
            this.sqlDataSourceGraph.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, null)});
            this.sqlDataSourceGraph.SelectCommand = "dbo.Get_Temp_GraficoBenchmark";
            this.sqlDataSourceGraph.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.90000057220459D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.RYS2009});
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxISIN,
            this.textBReportTitle,
            this.textBPeriod});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.510000228881836D), Telerik.Reporting.Drawing.Unit.Cm(2.6000003814697266D));
            this.panel1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(1D);
            // 
            // textBoxISIN
            // 
            this.textBoxISIN.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBoxISIN.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBoxISIN.Name = "textBoxISIN";
            this.textBoxISIN.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.510000228881836D), Telerik.Reporting.Drawing.Unit.Cm(0.7999998927116394D));
            this.textBoxISIN.Style.Font.Bold = true;
            this.textBoxISIN.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBoxISIN.Style.Font.Underline = false;
            this.textBoxISIN.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxISIN.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxISIN.Value = "";
            // 
            // textBReportTitle
            // 
            this.textBReportTitle.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBReportTitle.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.97895830869674683D));
            this.textBReportTitle.Name = "textBReportTitle";
            this.textBReportTitle.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.510000228881836D), Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D));
            this.textBReportTitle.Style.Font.Bold = true;
            this.textBReportTitle.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBReportTitle.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBReportTitle.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBReportTitle.Value = "= Parameters.NombrePlantilla.Value";
            // 
            // textBPeriod
            // 
            this.textBPeriod.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBPeriod.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.8785400390625D));
            this.textBPeriod.Name = "textBPeriod";
            this.textBPeriod.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.510000228881836D), Telerik.Reporting.Drawing.Unit.Cm(0.49969977140426636D));
            this.textBPeriod.Style.Font.Bold = true;
            this.textBPeriod.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBPeriod.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBPeriod.Value = "= Format(\"PERIODO {0} - {1}\", ToUpper(Format(\"{0:Y}\", Fields.MinDate)) , ToUpper(" +
    "Format(\"{0:Y}\", Fields.MaxDate )) )  \r\n";
            // 
            // RYS2009
            // 
            this.RYS2009.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            graphGroup1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.Fecha"));
            graphGroup1.Name = "fechaDateGroup";
            graphGroup1.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Fecha", Telerik.Reporting.SortDirection.Asc));
            this.RYS2009.CategoryGroups.Add(graphGroup1);
            colorPalette1.Colors.Add(System.Drawing.Color.DarkGreen);
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            this.RYS2009.ColorPalette = colorPalette1;
            this.RYS2009.CoordinateSystems.Add(this.cartesianCoordinateSystem2);
            this.RYS2009.DataSource = this.sqlDataSource1;
            this.RYS2009.Legend.Position = Telerik.Reporting.GraphItemPosition.BottomCenter;
            this.RYS2009.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.RYS2009.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.RYS2009.Legend.TitleStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.RYS2009.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(3.8000001907348633D));
            this.RYS2009.Name = "RYS2009";
            this.RYS2009.PlotAreaStyle.BackgroundColor = System.Drawing.Color.White;
            this.RYS2009.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.RYS2009.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.RYS2009.Series.Add(this.lineSeries2);
            this.RYS2009.SeriesGroups.Add(graphGroup2);
            this.RYS2009.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.510000228881836D), Telerik.Reporting.Drawing.Unit.Cm(8.6000003814697266D));
            this.RYS2009.Style.BackgroundColor = System.Drawing.Color.White;
            graphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle1.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle1.Text = "";
            this.RYS2009.Titles.Add(graphTitle1);
            // 
            // cartesianCoordinateSystem2
            // 
            this.cartesianCoordinateSystem2.Name = "cartesianCoordinateSystem2";
            this.cartesianCoordinateSystem2.XAxis = this.graphAxis4;
            this.cartesianCoordinateSystem2.YAxis = this.graphAxis3;
            // 
            // graphAxis4
            // 
            this.graphAxis4.LabelAngle = -30;
            this.graphAxis4.LabelFormat = "{0:d}";
            this.graphAxis4.LabelPlacement = Telerik.Reporting.GraphAxisLabelPlacement.NextToAxis;
            this.graphAxis4.MajorGridLineStyle.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.graphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.White;
            this.graphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MajorGridLineStyle.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.graphAxis4.MajorTickMarkDisplayType = Telerik.Reporting.GraphAxisTickMarkDisplayType.None;
            this.graphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.Visible = false;
            this.graphAxis4.MinorTickMarkDisplayType = Telerik.Reporting.GraphAxisTickMarkDisplayType.Cross;
            this.graphAxis4.MultiLevelCategoryLabels = true;
            this.graphAxis4.Name = "graphAxis4";
            dateTimeScale1.BaseUnit = Telerik.Reporting.DateTimeScaleUnits.Days;
            dateTimeScale1.LabelUnit = Telerik.Reporting.DateTimeScaleUnits.Months;
            dateTimeScale1.MinorUnit = Telerik.Reporting.DateTimeScaleUnits.Months;
            this.graphAxis4.Scale = dateTimeScale1;
            this.graphAxis4.Style.Font.Name = "Arial";
            this.graphAxis4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.graphAxis4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.graphAxis4.TitlePlacement = Telerik.Reporting.GraphAxisTitlePlacement.Centered;
            // 
            // graphAxis3
            // 
            this.graphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.Black;
            this.graphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.Visible = false;
            this.graphAxis3.Name = "graphAxis3";
            this.graphAxis3.Scale = numericalScale1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_GraficoBenchmark";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // lineSeries2
            // 
            this.lineSeries2.CategoryGroup = graphGroup1;
            this.lineSeries2.CoordinateSystem = this.cartesianCoordinateSystem2;
            this.lineSeries2.DataPointLabel = "= (Fields.ValorLiquidativo)";
            this.lineSeries2.DataPointLabelStyle.Visible = false;
            this.lineSeries2.DataPointStyle.Visible = false;
            this.lineSeries2.LegendItem.MarkStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.lineSeries2.LegendItem.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.lineSeries2.LegendItem.Value = "=IIf(Fields.EsReferencia = True,Format(\"{0}  {1:N2}%\", Fields.DescripPGI , Fields" +
    ".Porcentaje),  Format(\"{0}  {1:N2}%\", Fields.DescripPlantilla ,Fields.Porcentaje" +
    " ))";
            this.lineSeries2.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries2.LineStyle.Visible = true;
            this.lineSeries2.LineType = Telerik.Reporting.LineSeries.LineTypes.Smooth;
            this.lineSeries2.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50D);
            this.lineSeries2.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries2.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries2.Name = "lineSeries2";
            graphGroup2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.Isin"));
            graphGroup2.Name = "esReferenciaGroup";
            graphGroup2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Isin", Telerik.Reporting.SortDirection.Asc));
            this.lineSeries2.SeriesGroup = graphGroup2;
            this.lineSeries2.Size = null;
            this.lineSeries2.X = "= Fields.Fecha.Date";
            this.lineSeries2.Y = "= (Fields.ValorLiquidativo)";
            // 
            // Old_SubReportGraficoBenchmark
            // 
            this.DataSource = this.sqlDataSourceGeneral;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "SubReportGraficoBenchmark";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(24.5141658782959D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSourceGeneral;
        private Telerik.Reporting.SqlDataSource sqlDataSourceGraph;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBoxISIN;
        private Telerik.Reporting.TextBox textBReportTitle;
        private Telerik.Reporting.TextBox textBPeriod;
        private Telerik.Reporting.Graph RYS2009;
        private Telerik.Reporting.CartesianCoordinateSystem cartesianCoordinateSystem2;
        private Telerik.Reporting.GraphAxis graphAxis4;
        private Telerik.Reporting.GraphAxis graphAxis3;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.LineSeries lineSeries2;
    }
}