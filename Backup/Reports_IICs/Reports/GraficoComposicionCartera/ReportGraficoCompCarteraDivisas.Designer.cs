namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    partial class ReportGraficoCompCarteraDivisas
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGraficoCompCarteraDivisas));
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.GraphTitle graphTitle1 = new Telerik.Reporting.GraphTitle();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.CategoryScale categoryScale1 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.TituloReport = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBoxISIN = new Telerik.Reporting.TextBox();
            this.graph2 = new Telerik.Reporting.Graph();
            this.polarCoordinateSystem2 = new Telerik.Reporting.PolarCoordinateSystem();
            this.graphAxis3 = new Telerik.Reporting.GraphAxis();
            this.graphAxis4 = new Telerik.Reporting.GraphAxis();
            this.sqlDataSourceCARDivisas = new Telerik.Reporting.SqlDataSource();
            this.barSeries2 = new Telerik.Reporting.BarSeries();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0001000165939331D);
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
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000013709068298D), Telerik.Reporting.Drawing.Unit.Cm(0.00019992318993899971D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.499998092651367D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "COMPOSICIÓN PATRIMONIO POR DIVISAS";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(13.699999809265137D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxISIN,
            this.graph2});
            this.detail.Name = "detail";
            // 
            // textBoxISIN
            // 
            this.textBoxISIN.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332D));
            this.textBoxISIN.Name = "textBoxISIN";
            this.textBoxISIN.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.499998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.7999998927116394D));
            this.textBoxISIN.Style.Font.Bold = true;
            this.textBoxISIN.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBoxISIN.Style.Font.Underline = false;
            this.textBoxISIN.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxISIN.Value = "";
            // 
            // graph2
            // 
            graphGroup1.Name = "categoryGroup1";
            this.graph2.CategoryGroups.Add(graphGroup1);
            this.graph2.CoordinateSystems.Add(this.polarCoordinateSystem2);
            this.graph2.DataSource = this.sqlDataSourceCARDivisas;
            this.graph2.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph2.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph2.Legend.Style.Visible = false;
            this.graph2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000013709068298D), Telerik.Reporting.Drawing.Unit.Cm(1.2998999357223511D));
            this.graph2.Name = "graph2";
            this.graph2.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph2.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph2.Series.Add(this.barSeries2);
            this.graph2.SeriesGroups.Add(graphGroup2);
            this.graph2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.5D), Telerik.Reporting.Drawing.Unit.Cm(12.100000381469727D));
            graphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle1.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle1.Style.Visible = false;
            graphTitle1.Text = "graph2";
            this.graph2.Titles.Add(graphTitle1);
            // 
            // polarCoordinateSystem2
            // 
            this.polarCoordinateSystem2.AngularAxis = this.graphAxis3;
            this.polarCoordinateSystem2.Name = "polarCoordinateSystem2";
            this.polarCoordinateSystem2.RadialAxis = this.graphAxis4;
            this.polarCoordinateSystem2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(10D);
            // 
            // graphAxis3
            // 
            this.graphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MajorGridLineStyle.Visible = false;
            this.graphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.Visible = false;
            this.graphAxis3.Name = "graphAxis3";
            this.graphAxis3.Scale = numericalScale1;
            this.graphAxis3.Style.Visible = false;
            // 
            // graphAxis4
            // 
            this.graphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MajorGridLineStyle.Visible = false;
            this.graphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.Visible = false;
            this.graphAxis4.Name = "graphAxis4";
            categoryScale1.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks;
            categoryScale1.SpacingSlotCount = 0D;
            this.graphAxis4.Scale = categoryScale1;
            this.graphAxis4.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.graphAxis4.Style.Visible = false;
            // 
            // sqlDataSourceCARDivisas
            // 
            this.sqlDataSourceCARDivisas.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceCARDivisas.Name = "sqlDataSourceCARDivisas";
            this.sqlDataSourceCARDivisas.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSourceCARDivisas.SelectCommand = "dbo.Get_Temp_GraficoComposicionCarteraDivisas";
            this.sqlDataSourceCARDivisas.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // barSeries2
            // 
            this.barSeries2.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100;
            this.barSeries2.CategoryGroup = graphGroup1;
            this.barSeries2.CoordinateSystem = this.polarCoordinateSystem2;
            this.barSeries2.DataPointLabel = "= Format(\"{0} {1:P2}\", Fields.Divisa, Sum(Fields.Cartera) /CDbl(Exec(\'graph2\', Su" +
    "m(Fields.Cartera))))";
            this.barSeries2.DataPointLabelAlignment = Telerik.Reporting.BarDataPointLabelAlignment.OutsideColumn;
            this.barSeries2.DataPointLabelConnectorStyle.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.barSeries2.DataPointLabelConnectorStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.barSeries2.DataPointLabelConnectorStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries2.DataPointLabelConnectorStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries2.DataPointLabelFormat = "{0:P12}";
            this.barSeries2.DataPointLabelOffset = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.barSeries2.DataPointLabelStyle.Font.Bold = true;
            this.barSeries2.DataPointLabelStyle.Visible = true;
            this.barSeries2.DataPointStyle.Color = System.Drawing.Color.Black;
            this.barSeries2.DataPointStyle.LineColor = System.Drawing.Color.White;
            this.barSeries2.DataPointStyle.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.barSeries2.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0.05000000074505806D);
            this.barSeries2.DataPointStyle.Visible = true;
            this.barSeries2.LegendItem.Value = "= Fields.Divisa";
            this.barSeries2.Name = "barSeries2";
            graphGroup2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.Divisa"));
            graphGroup2.Name = "divisaGroup1";
            graphGroup2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Divisa", Telerik.Reporting.SortDirection.Asc));
            this.barSeries2.SeriesGroup = graphGroup2;
            this.barSeries2.X = "= Sum(Fields.Cartera)";
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
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1899995803833D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2001999616622925D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // ReportGraficoCompCarteraDivisas
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportGraficoCompCarteraDivisas";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter1.Text = "CodigoIC";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(19.999900817871094D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlDataSourceCARDivisas;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox textBoxISIN;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.Graph graph2;
        private Telerik.Reporting.PolarCoordinateSystem polarCoordinateSystem2;
        private Telerik.Reporting.GraphAxis graphAxis3;
        private Telerik.Reporting.GraphAxis graphAxis4;
        private Telerik.Reporting.BarSeries barSeries2;
    }
}