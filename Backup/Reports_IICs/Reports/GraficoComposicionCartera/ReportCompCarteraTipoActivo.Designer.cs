namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    partial class ReportDistrPatrTipoActivo
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDistrPatrTipoActivo));
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
            this.GCCarteratipoActivo = new Telerik.Reporting.Graph();
            this.polarCoordinateSystem1 = new Telerik.Reporting.PolarCoordinateSystem();
            this.graphAxis1 = new Telerik.Reporting.GraphAxis();
            this.graphAxis2 = new Telerik.Reporting.GraphAxis();
            this.sqlDataSourceCARtipodeActivo = new Telerik.Reporting.SqlDataSource();
            this.barSeries1 = new Telerik.Reporting.BarSeries();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.TextNumPaginaPie = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1D);
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
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.4000001847743988D), Telerik.Reporting.Drawing.Unit.Cm(0.00030012702336534858D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.200000762939453D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "DISTRIBUCIÓN DE CARTERA";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.458332061767578D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxISIN,
            this.GCCarteratipoActivo});
            this.detail.Name = "detail";
            // 
            // textBoxISIN
            // 
            this.textBoxISIN.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000006556510925D), Telerik.Reporting.Drawing.Unit.Cm(0.0002000846725422889D));
            this.textBoxISIN.Name = "textBoxISIN";
            this.textBoxISIN.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.19999885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.7999998927116394D));
            this.textBoxISIN.Style.Font.Bold = true;
            this.textBoxISIN.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBoxISIN.Style.Font.Underline = false;
            this.textBoxISIN.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBoxISIN.Value = "";
            // 
            // GCCarteratipoActivo
            // 
            graphGroup1.Name = "categoryGroup";
            this.GCCarteratipoActivo.CategoryGroups.Add(graphGroup1);
            this.GCCarteratipoActivo.CoordinateSystems.Add(this.polarCoordinateSystem1);
            this.GCCarteratipoActivo.DataSource = this.sqlDataSourceCARtipodeActivo;
            this.GCCarteratipoActivo.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.GCCarteratipoActivo.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.GCCarteratipoActivo.Legend.Style.Visible = false;
            this.GCCarteratipoActivo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000027418136597D), Telerik.Reporting.Drawing.Unit.Cm(1.3000000715255737D));
            this.GCCarteratipoActivo.Name = "GCCarteratipoActivo";
            this.GCCarteratipoActivo.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.GCCarteratipoActivo.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.GCCarteratipoActivo.Series.Add(this.barSeries1);
            this.GCCarteratipoActivo.SeriesGroups.Add(graphGroup2);
            this.GCCarteratipoActivo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.199993133544922D), Telerik.Reporting.Drawing.Unit.Cm(10.799999237060547D));
            graphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter;
            graphTitle1.Style.LineColor = System.Drawing.Color.LightGray;
            graphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            graphTitle1.Style.Visible = false;
            graphTitle1.Text = "GCCarteratipoActivo";
            this.GCCarteratipoActivo.Titles.Add(graphTitle1);
            // 
            // polarCoordinateSystem1
            // 
            this.polarCoordinateSystem1.AngularAxis = this.graphAxis1;
            this.polarCoordinateSystem1.Name = "polarCoordinateSystem1";
            this.polarCoordinateSystem1.RadialAxis = this.graphAxis2;
            // 
            // graphAxis1
            // 
            this.graphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MajorGridLineStyle.Visible = false;
            this.graphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.Visible = false;
            this.graphAxis1.Name = "graphAxis1";
            this.graphAxis1.Scale = numericalScale1;
            this.graphAxis1.Style.Visible = false;
            // 
            // graphAxis2
            // 
            this.graphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MajorGridLineStyle.Visible = false;
            this.graphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.Visible = false;
            this.graphAxis2.Name = "graphAxis2";
            categoryScale1.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks;
            categoryScale1.SpacingSlotCount = 0D;
            this.graphAxis2.Scale = categoryScale1;
            this.graphAxis2.Style.Visible = false;
            // 
            // sqlDataSourceCARtipodeActivo
            // 
            this.sqlDataSourceCARtipodeActivo.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSourceCARtipodeActivo.Name = "sqlDataSourceCARtipodeActivo";
            this.sqlDataSourceCARtipodeActivo.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "= Parameters.CodigoIC.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, "= Parameters.Isin.Value")});
            this.sqlDataSourceCARtipodeActivo.SelectCommand = "dbo.Get_Temp_GraficoExposMercTipoActivo";
            this.sqlDataSourceCARtipodeActivo.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // barSeries1
            // 
            this.barSeries1.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100;
            this.barSeries1.CategoryGroup = graphGroup1;
            this.barSeries1.CoordinateSystem = this.polarCoordinateSystem1;
            this.barSeries1.DataPointLabel = "= Format(\"{0} {1:P2}\",  Fields.TipoActivo, Sum(Fields.PorcentajeCartera) / CDbl(E" +
    "xec(\'GCCarteratipoActivo\', Sum(Fields.PorcentajeCartera))))   ";
            this.barSeries1.DataPointLabelAlignment = Telerik.Reporting.BarDataPointLabelAlignment.OutsideColumn;
            this.barSeries1.DataPointLabelConnectorStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries1.DataPointLabelConnectorStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.barSeries1.DataPointLabelFormat = "{0:P}";
            this.barSeries1.DataPointLabelOffset = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.barSeries1.DataPointLabelStyle.Font.Bold = true;
            this.barSeries1.DataPointLabelStyle.Visible = true;
            this.barSeries1.DataPointStyle.LineColor = System.Drawing.Color.White;
            this.barSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0.05000000074505806D);
            this.barSeries1.DataPointStyle.Visible = true;
            this.barSeries1.LegendItem.Value = "= Fields.TipoActivo";
            this.barSeries1.Name = "barSeries1";
            graphGroup2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.TipoActivo"));
            graphGroup2.Name = "tipoActivoGroup";
            graphGroup2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.PorcentajeCartera", Telerik.Reporting.SortDirection.Desc));
            this.barSeries1.SeriesGroup = graphGroup2;
            this.barSeries1.X = "= Sum(Fields.PorcentajeCartera)";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.557766854763031D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1899995803833D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.55766618251800537D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2003002166748047D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // ReportDistrPatrTipoActivo
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportDistrPatrTipoActivo";
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
        private Telerik.Reporting.SqlDataSource sqlDataSourceCARtipodeActivo;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox textBoxISIN;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.Graph GCCarteratipoActivo;
        private Telerik.Reporting.PolarCoordinateSystem polarCoordinateSystem1;
        private Telerik.Reporting.GraphAxis graphAxis1;
        private Telerik.Reporting.GraphAxis graphAxis2;
        private Telerik.Reporting.BarSeries barSeries1;
    }
}