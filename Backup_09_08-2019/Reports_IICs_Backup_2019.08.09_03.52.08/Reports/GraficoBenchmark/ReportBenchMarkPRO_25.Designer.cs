namespace Reports_IICs.Reports.GraficoBenchmark
{
    partial class ReportBenchMarkPRO_25
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportBenchMarkPRO_25));
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.Drawing.ColorPalette colorPalette1 = new Telerik.Reporting.Drawing.ColorPalette();
            Telerik.Reporting.GraphTitle graphTitle1 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.DateTimeScale dateTimeScale1 = new Telerik.Reporting.DateTimeScale();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.DateTimeScale dateTimeScale2 = new Telerik.Reporting.DateTimeScale();
            Telerik.Reporting.NumericalScale numericalScale2 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.GraphGroup graphGroup3 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphGroup graphGroup4 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.TituloReport = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBPeriod = new Telerik.Reporting.TextBox();
            this.textBoxISIN = new Telerik.Reporting.TextBox();
            this.panel1 = new Telerik.Reporting.Panel();
            this.RYS2009 = new Telerik.Reporting.Graph();
            this.cartesianCoordinateSystem2 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis4 = new Telerik.Reporting.GraphAxis();
            this.graphAxis3 = new Telerik.Reporting.GraphAxis();
            this.sqlDataSourceGraph = new Telerik.Reporting.SqlDataSource();
            this.lineSeries2 = new Telerik.Reporting.LineSeries();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.cartesianCoordinateSystem1 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis2 = new Telerik.Reporting.GraphAxis();
            this.graphAxis1 = new Telerik.Reporting.GraphAxis();
            this.lineSeries1 = new Telerik.Reporting.LineSeries();
            this.sqlDataSourceGeneral = new Telerik.Reporting.SqlDataSource();
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
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010004233627114445D), Telerik.Reporting.Drawing.Unit.Cm(0.00030012702336534858D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.999799728393555D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportBenchMarkPRO_25()";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.599699974060059D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBPeriod,
            this.textBoxISIN,
            this.panel1});
            this.detail.Name = "detail";
            // 
            // textBPeriod
            // 
            this.textBPeriod.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBPeriod.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(1.0997000932693481D));
            this.textBPeriod.Name = "textBPeriod";
            this.textBPeriod.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.000201225280762D), Telerik.Reporting.Drawing.Unit.Cm(0.49969977140426636D));
            this.textBPeriod.Style.Font.Bold = true;
            this.textBPeriod.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBPeriod.Value = "= Format(\"PERIODO {0} - {1}\", ToUpper(Format(\"{0:Y}\", Fields.MinDate)) , ToUpper(" +
    "Format(\"{0:Y}\", Fields.MaxDate )) )  \r\n";
            // 
            // textBoxISIN
            // 
            this.textBoxISIN.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBoxISIN.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000050961971283D), Telerik.Reporting.Drawing.Unit.Cm(0.0002000846725422889D));
            this.textBoxISIN.Name = "textBoxISIN";
            this.textBoxISIN.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.799898147583008D), Telerik.Reporting.Drawing.Unit.Cm(0.7999998927116394D));
            this.textBoxISIN.Style.Font.Bold = true;
            this.textBoxISIN.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBoxISIN.Style.Font.Underline = false;
            this.textBoxISIN.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxISIN.Value = "";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.RYS2009});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.1000000536441803D), Telerik.Reporting.Drawing.Unit.Cm(2.8996996879577637D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.90009880065918D), Telerik.Reporting.Drawing.Unit.Cm(9.09999942779541D));
            // 
            // RYS2009
            // 
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
            this.RYS2009.DataSource = this.sqlDataSourceGraph;
            this.RYS2009.Legend.Position = Telerik.Reporting.GraphItemPosition.BottomCenter;
            this.RYS2009.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.RYS2009.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.RYS2009.Legend.TitleStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.RYS2009.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10010048002004623D), Telerik.Reporting.Drawing.Unit.Cm(0.299999862909317D));
            this.RYS2009.Name = "RYS2009";
            this.RYS2009.PlotAreaStyle.BackgroundColor = System.Drawing.Color.White;
            this.RYS2009.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.RYS2009.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.RYS2009.Series.Add(this.lineSeries2);
            this.RYS2009.SeriesGroups.Add(graphGroup2);
            this.RYS2009.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.499898910522461D), Telerik.Reporting.Drawing.Unit.Cm(8.6000003814697266D));
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
            // sqlDataSourceGraph
            // 
            this.sqlDataSourceGraph.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceGraph.Name = "sqlDataSourceGraph";
            this.sqlDataSourceGraph.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSourceGraph.SelectCommand = "dbo.Get_Temp_GraficoBenchmark";
            this.sqlDataSourceGraph.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
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
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.400100708007812D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TextNumPaginaPie.Value = "=Format(\"Página {0} de {1}\",  PageNumber-1, PageCount-1 )";
            // 
            // cartesianCoordinateSystem1
            // 
            this.cartesianCoordinateSystem1.Name = "cartesianCoordinateSystem1";
            this.cartesianCoordinateSystem1.XAxis = this.graphAxis2;
            this.cartesianCoordinateSystem1.YAxis = this.graphAxis1;
            // 
            // graphAxis2
            // 
            this.graphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.Visible = false;
            this.graphAxis2.Name = "graphAxis2";
            this.graphAxis2.Scale = dateTimeScale2;
            // 
            // graphAxis1
            // 
            this.graphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.Visible = false;
            this.graphAxis1.Name = "graphAxis1";
            this.graphAxis1.Scale = numericalScale2;
            // 
            // lineSeries1
            // 
            graphGroup3.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.Fecha"));
            graphGroup3.Name = "fechaGroup";
            graphGroup3.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Fecha", Telerik.Reporting.SortDirection.Asc));
            this.lineSeries1.CategoryGroup = graphGroup3;
            this.lineSeries1.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.lineSeries1.DataPointLabel = "= (Fields.ValorLiquidativo)";
            this.lineSeries1.DataPointLabelStyle.Visible = false;
            this.lineSeries1.DataPointStyle.Visible = false;
            this.lineSeries1.LegendItem.Value = "ValorLiquidativo";
            this.lineSeries1.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries1.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50D);
            this.lineSeries1.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries1.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries1.Name = "lineSeries1";
            graphGroup4.Name = "seriesGroup";
            this.lineSeries1.SeriesGroup = graphGroup4;
            this.lineSeries1.Size = null;
            this.lineSeries1.X = "= Fields.Fecha";
            this.lineSeries1.Y = "= (Fields.ValorLiquidativo)";
            // 
            // sqlDataSourceGeneral
            // 
            this.sqlDataSourceGeneral.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceGeneral.Name = "sqlDataSourceGeneral";
            this.sqlDataSourceGeneral.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value")});
            this.sqlDataSourceGeneral.SelectCommand = "SELECT MIN ( [Fecha]) AS \"MinDate\" , MAX ( [Fecha]) AS \"MaxDate\"\r\n      \r\n  FROM " +
    "[Reports_IICS].[dbo].[Temp_GraficoIBenchmark]\r\n   where Codigoic= @CodigoIC";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2003000974655151D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // ReportBenchMarkPRO_25
            // 
            this.DataSource = this.sqlDataSourceGeneral;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportBenchMarkPRO_25";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "NombrePlantilla";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "CodigoIC";
            reportParameter2.Text = "CodigoIC";
            reportParameter2.Value = "275";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(20.000099182128906D);
            this.ItemDataBinding += new System.EventHandler(this.ReportBenchMarkPRO_25_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlDataSourceGraph;
        private Telerik.Reporting.Graph RYS2009;
        private Telerik.Reporting.CartesianCoordinateSystem cartesianCoordinateSystem2;
        private Telerik.Reporting.GraphAxis graphAxis4;
        private Telerik.Reporting.GraphAxis graphAxis3;
        private Telerik.Reporting.LineSeries lineSeries2;
        private Telerik.Reporting.CartesianCoordinateSystem cartesianCoordinateSystem1;
        private Telerik.Reporting.GraphAxis graphAxis2;
        private Telerik.Reporting.GraphAxis graphAxis1;
        private Telerik.Reporting.LineSeries lineSeries1;
        private Telerik.Reporting.TextBox textBPeriod;
        private Telerik.Reporting.SqlDataSource sqlDataSourceGeneral;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox textBoxISIN;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.Panel panel1;
    }
}