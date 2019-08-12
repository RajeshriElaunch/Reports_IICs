namespace Reports_IICs.Reports.Gráficos_Burbujas
{
    partial class ReportGráficosBurbujasVALUE_GROWTH
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGráficosBurbujasVALUE_GROWTH));
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphTitle graphTitle1 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.NumericalScale numericalScale2 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.Drawing.ColorPalette colorPalette1 = new Telerik.Reporting.Drawing.ColorPalette();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.graph1 = new Telerik.Reporting.Graph();
            this.cartesianCoordinateSystem4 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis7 = new Telerik.Reporting.GraphAxis();
            this.graphAxis8 = new Telerik.Reporting.GraphAxis();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.lineSeries2 = new Telerik.Reporting.LineSeries();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.TituloReport = new Telerik.Reporting.TextBox();
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
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9477132607717067E-05D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(14.699999809265137D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.graph1});
            this.detail.Name = "detail";
            // 
            // graph1
            // 
            this.graph1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            graphGroup1.Groupings.Add(new Telerik.Reporting.Grouping(""));
            graphGroup1.Name = "categoryGroup";
            this.graph1.CategoryGroups.Add(graphGroup1);
            this.graph1.CoordinateSystems.Add(this.cartesianCoordinateSystem4);
            this.graph1.DataSource = this.sqlDataSource1;
            this.graph1.Legend.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Legend.Style.Visible = true;
            this.graph1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.graph1.Name = "graph1";
            this.graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Series.Add(this.lineSeries2);
            this.graph1.SeriesGroups.Add(graphGroup2);
            this.graph1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(13.100000381469727D));
            graphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle1.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle1.Text = "VALUE-GROWTH";
            this.graph1.Titles.Add(graphTitle1);
            // 
            // cartesianCoordinateSystem4
            // 
            this.cartesianCoordinateSystem4.Name = "cartesianCoordinateSystem4";
            this.cartesianCoordinateSystem4.XAxis = this.graphAxis7;
            this.cartesianCoordinateSystem4.YAxis = this.graphAxis8;
            // 
            // graphAxis7
            // 
            this.graphAxis7.LabelFormat = "{0:P0}";
            this.graphAxis7.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis7.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis7.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis7.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis7.MinorGridLineStyle.Visible = false;
            this.graphAxis7.Name = "graphAxis7";
            this.graphAxis7.Scale = numericalScale1;
            this.graphAxis7.Title = "DESCUENTO FUNDAMENTAL (€)";
            // 
            // graphAxis8
            // 
            this.graphAxis8.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis8.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis8.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis8.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis8.MinorGridLineStyle.Visible = false;
            this.graphAxis8.Name = "graphAxis8";
            this.graphAxis8.Scale = numericalScale2;
            this.graphAxis8.Title = "VALUE-GROWTH";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIc.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.Get_GraficoBurbujas_ValueGrowth";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // lineSeries2
            // 
            this.lineSeries2.CategoryGroup = graphGroup1;
            colorPalette1.Colors.Add(System.Drawing.Color.DodgerBlue);
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))));
            colorPalette1.Colors.Add(System.Drawing.Color.Green);
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            colorPalette1.Colors.Add(System.Drawing.Color.Yellow);
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))));
            colorPalette1.Colors.Add(System.Drawing.Color.Teal);
            colorPalette1.Colors.Add(System.Drawing.Color.Silver);
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))));
            colorPalette1.Colors.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))));
            colorPalette1.Colors.Add(System.Drawing.Color.Tomato);
            colorPalette1.Colors.Add(System.Drawing.Color.BurlyWood);
            colorPalette1.Colors.Add(System.Drawing.Color.MediumSpringGreen);
            colorPalette1.Colors.Add(System.Drawing.Color.BlueViolet);
            colorPalette1.Colors.Add(System.Drawing.Color.DarkGray);
            colorPalette1.Colors.Add(System.Drawing.Color.IndianRed);
            colorPalette1.Colors.Add(System.Drawing.Color.Chocolate);
            colorPalette1.Colors.Add(System.Drawing.Color.Moccasin);
            colorPalette1.Colors.Add(System.Drawing.Color.OliveDrab);
            colorPalette1.Colors.Add(System.Drawing.Color.Turquoise);
            colorPalette1.Colors.Add(System.Drawing.Color.DarkTurquoise);
            colorPalette1.Colors.Add(System.Drawing.Color.Thistle);
            colorPalette1.Colors.Add(System.Drawing.Color.MediumVioletRed);
            this.lineSeries2.ColorPalette = colorPalette1;
            this.lineSeries2.CoordinateSystem = this.cartesianCoordinateSystem4;
            this.lineSeries2.DataPointLabel = "=Format(\"{0}\", Fields.DescripcionInstrumento)";
            this.lineSeries2.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.lineSeries2.DataPointLabelStyle.Visible = false;
            this.lineSeries2.DataPointStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.lineSeries2.DataPointStyle.Visible = true;
            this.lineSeries2.LegendItem.Value = "= Fields.DescripcionInstrumento";
            this.lineSeries2.LineStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6D);
            this.lineSeries2.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries2.LineStyle.Visible = false;
            this.lineSeries2.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50D);
            this.lineSeries2.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries2.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries2.MarkerType = Telerik.Reporting.DataPointMarkerType.Circle;
            this.lineSeries2.Name = "lineSeries2";
            graphGroup2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.DescripcionInstrumento"));
            graphGroup2.Name = "descripcionInstrumentoGroup";
            graphGroup2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.DescripcionInstrumento", Telerik.Reporting.SortDirection.Asc));
            this.lineSeries2.SeriesGroup = graphGroup2;
            this.lineSeries2.Size = "= Sum(Fields.PorcentajeCartera)";
            this.lineSeries2.X = "= Sum(Fields.DescuentoFundamental)";
            this.lineSeries2.Y = "= Sum(Fields.CAPIMILLONES)";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.55776596069335938D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.55766618251800537D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2002003192901611D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // TituloReport
            // 
            this.TituloReport.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010004233627114445D), Telerik.Reporting.Drawing.Unit.Cm(0.0002000846725422889D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.199799537658691D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReport_GraficoBurbujas()";
            // 
            // ReportGráficosBurbujasVALUE_GROWTH
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportGráficosBurbujasVALUE_GROWTH";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIc";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.199999809265137D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.Graph graph1;
        private Telerik.Reporting.CartesianCoordinateSystem cartesianCoordinateSystem4;
        private Telerik.Reporting.GraphAxis graphAxis7;
        private Telerik.Reporting.GraphAxis graphAxis8;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.LineSeries lineSeries2;
    }
}