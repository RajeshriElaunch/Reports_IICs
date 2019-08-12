namespace Reports_IICs.Reports.Evolución.Evolución_índices_de_referencia
{
    partial class Report2
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.codigoICGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.codigoICGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.codigoICCaptionTextBox = new Telerik.Reporting.TextBox();
            this.codigoICDataTextBox = new Telerik.Reporting.TextBox();
            this.cotizaDivDesdeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cotizaDivDesdeDataTextBox = new Telerik.Reporting.TextBox();
            this.cotizaDivHastaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cotizaDivHastaDataTextBox = new Telerik.Reporting.TextBox();
            this.descripcionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.descripcionDataTextBox = new Telerik.Reporting.TextBox();
            this.fechaDesdeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fechaDesdeDataTextBox = new Telerik.Reporting.TextBox();
            this.fechaHastaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fechaHastaDataTextBox = new Telerik.Reporting.TextBox();
            this.idCaptionTextBox = new Telerik.Reporting.TextBox();
            this.idDataTextBox = new Telerik.Reporting.TextBox();
            this.isinCaptionTextBox = new Telerik.Reporting.TextBox();
            this.isinDataTextBox = new Telerik.Reporting.TextBox();
            this.varCotizaDivisaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.varCotizaDivisaDataTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@CodigoIC", System.Data.DbType.String, "402"),
            new Telerik.Reporting.SqlDataSourceParameter("@Isin", System.Data.DbType.String, null)});
            this.sqlDataSource1.SelectCommand = "dbo.Get_Temp_EvolucionIndBench";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // codigoICGroupHeaderSection
            // 
            this.codigoICGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.68466669321060181D);
            this.codigoICGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
            this.codigoICGroupHeaderSection.Name = "codigoICGroupHeaderSection";
            // 
            // codigoICGroupFooterSection
            // 
            this.codigoICGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.codigoICGroupFooterSection.Name = "codigoICGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Codigo IC:";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0846664905548096D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.666000366210938D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.CodigoIC";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.68466669321060181D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.750666618347168D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Report2";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.68466669321060181D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.8541665077209473D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.9388332366943359D), Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.8541665077209473D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(2.684666633605957D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.codigoICCaptionTextBox,
            this.codigoICDataTextBox,
            this.cotizaDivDesdeCaptionTextBox,
            this.cotizaDivDesdeDataTextBox,
            this.cotizaDivHastaCaptionTextBox,
            this.cotizaDivHastaDataTextBox,
            this.descripcionCaptionTextBox,
            this.descripcionDataTextBox,
            this.fechaDesdeCaptionTextBox,
            this.fechaDesdeDataTextBox,
            this.fechaHastaCaptionTextBox,
            this.fechaHastaDataTextBox,
            this.idCaptionTextBox,
            this.idDataTextBox,
            this.isinCaptionTextBox,
            this.isinDataTextBox,
            this.varCotizaDivisaCaptionTextBox,
            this.varCotizaDivisaDataTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.835333824157715D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Report2";
            // 
            // codigoICCaptionTextBox
            // 
            this.codigoICCaptionTextBox.CanGrow = true;
            this.codigoICCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.04233333095908165D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.codigoICCaptionTextBox.Name = "codigoICCaptionTextBox";
            this.codigoICCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.codigoICCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.codigoICCaptionTextBox.StyleName = "Caption";
            this.codigoICCaptionTextBox.Value = "Codigo IC:";
            // 
            // codigoICDataTextBox
            // 
            this.codigoICDataTextBox.CanGrow = true;
            this.codigoICDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.91972219944000244D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.codigoICDataTextBox.Name = "codigoICDataTextBox";
            this.codigoICDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.codigoICDataTextBox.StyleName = "Data";
            this.codigoICDataTextBox.Value = "= Fields.CodigoIC";
            // 
            // cotizaDivDesdeCaptionTextBox
            // 
            this.cotizaDivDesdeCaptionTextBox.CanGrow = true;
            this.cotizaDivDesdeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7971111536026D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.cotizaDivDesdeCaptionTextBox.Name = "cotizaDivDesdeCaptionTextBox";
            this.cotizaDivDesdeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivDesdeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.cotizaDivDesdeCaptionTextBox.StyleName = "Caption";
            this.cotizaDivDesdeCaptionTextBox.Value = "Cotiza Div Desde:";
            // 
            // cotizaDivDesdeDataTextBox
            // 
            this.cotizaDivDesdeDataTextBox.CanGrow = true;
            this.cotizaDivDesdeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6744999885559082D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.cotizaDivDesdeDataTextBox.Name = "cotizaDivDesdeDataTextBox";
            this.cotizaDivDesdeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivDesdeDataTextBox.StyleName = "Data";
            this.cotizaDivDesdeDataTextBox.Value = "= Fields.CotizaDivDesde";
            // 
            // cotizaDivHastaCaptionTextBox
            // 
            this.cotizaDivHastaCaptionTextBox.CanGrow = true;
            this.cotizaDivHastaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5518889427185059D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.cotizaDivHastaCaptionTextBox.Name = "cotizaDivHastaCaptionTextBox";
            this.cotizaDivHastaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivHastaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.cotizaDivHastaCaptionTextBox.StyleName = "Caption";
            this.cotizaDivHastaCaptionTextBox.Value = "Cotiza Div Hasta:";
            // 
            // cotizaDivHastaDataTextBox
            // 
            this.cotizaDivHastaDataTextBox.CanGrow = true;
            this.cotizaDivHastaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.4292778968811035D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.cotizaDivHastaDataTextBox.Name = "cotizaDivHastaDataTextBox";
            this.cotizaDivHastaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.cotizaDivHastaDataTextBox.StyleName = "Data";
            this.cotizaDivHastaDataTextBox.Value = "= Fields.CotizaDivHasta";
            // 
            // descripcionCaptionTextBox
            // 
            this.descripcionCaptionTextBox.CanGrow = true;
            this.descripcionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.3066668510437012D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.descripcionCaptionTextBox.Name = "descripcionCaptionTextBox";
            this.descripcionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.descripcionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.descripcionCaptionTextBox.StyleName = "Caption";
            this.descripcionCaptionTextBox.Value = "Descripcion:";
            // 
            // descripcionDataTextBox
            // 
            this.descripcionDataTextBox.CanGrow = true;
            this.descripcionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.1840558052062988D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.descripcionDataTextBox.Name = "descripcionDataTextBox";
            this.descripcionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.descripcionDataTextBox.StyleName = "Data";
            this.descripcionDataTextBox.Value = "= Fields.Descripcion";
            // 
            // fechaDesdeCaptionTextBox
            // 
            this.fechaDesdeCaptionTextBox.CanGrow = true;
            this.fechaDesdeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0614442825317383D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.fechaDesdeCaptionTextBox.Name = "fechaDesdeCaptionTextBox";
            this.fechaDesdeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaDesdeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.fechaDesdeCaptionTextBox.StyleName = "Caption";
            this.fechaDesdeCaptionTextBox.Value = "Fecha Desde:";
            // 
            // fechaDesdeDataTextBox
            // 
            this.fechaDesdeDataTextBox.CanGrow = true;
            this.fechaDesdeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.9388332366943359D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.fechaDesdeDataTextBox.Name = "fechaDesdeDataTextBox";
            this.fechaDesdeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaDesdeDataTextBox.StyleName = "Data";
            this.fechaDesdeDataTextBox.Value = "= Fields.FechaDesde";
            // 
            // fechaHastaCaptionTextBox
            // 
            this.fechaHastaCaptionTextBox.CanGrow = true;
            this.fechaHastaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.8162221908569336D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.fechaHastaCaptionTextBox.Name = "fechaHastaCaptionTextBox";
            this.fechaHastaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaHastaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.fechaHastaCaptionTextBox.StyleName = "Caption";
            this.fechaHastaCaptionTextBox.Value = "Fecha Hasta:";
            // 
            // fechaHastaDataTextBox
            // 
            this.fechaHastaDataTextBox.CanGrow = true;
            this.fechaHastaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.6936111450195312D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.fechaHastaDataTextBox.Name = "fechaHastaDataTextBox";
            this.fechaHastaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.fechaHastaDataTextBox.StyleName = "Data";
            this.fechaHastaDataTextBox.Value = "= Fields.FechaHasta";
            // 
            // idCaptionTextBox
            // 
            this.idCaptionTextBox.CanGrow = true;
            this.idCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.571000099182129D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.idCaptionTextBox.Name = "idCaptionTextBox";
            this.idCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.idCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.idCaptionTextBox.StyleName = "Caption";
            this.idCaptionTextBox.Value = "Id:";
            // 
            // idDataTextBox
            // 
            this.idDataTextBox.CanGrow = true;
            this.idDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.448389053344727D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.idDataTextBox.Name = "idDataTextBox";
            this.idDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.idDataTextBox.StyleName = "Data";
            this.idDataTextBox.Value = "= Fields.Id";
            // 
            // isinCaptionTextBox
            // 
            this.isinCaptionTextBox.CanGrow = true;
            this.isinCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.325778007507324D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.isinCaptionTextBox.Name = "isinCaptionTextBox";
            this.isinCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.isinCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.isinCaptionTextBox.StyleName = "Caption";
            this.isinCaptionTextBox.Value = "Isin:";
            // 
            // isinDataTextBox
            // 
            this.isinDataTextBox.CanGrow = true;
            this.isinDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.203166961669922D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.isinDataTextBox.Name = "isinDataTextBox";
            this.isinDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.isinDataTextBox.StyleName = "Data";
            this.isinDataTextBox.Value = "= Fields.Isin";
            // 
            // varCotizaDivisaCaptionTextBox
            // 
            this.varCotizaDivisaCaptionTextBox.CanGrow = true;
            this.varCotizaDivisaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.08055591583252D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.varCotizaDivisaCaptionTextBox.Name = "varCotizaDivisaCaptionTextBox";
            this.varCotizaDivisaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.varCotizaDivisaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.varCotizaDivisaCaptionTextBox.StyleName = "Caption";
            this.varCotizaDivisaCaptionTextBox.Value = "Var Cotiza Divisa:";
            // 
            // varCotizaDivisaDataTextBox
            // 
            this.varCotizaDivisaDataTextBox.CanGrow = true;
            this.varCotizaDivisaDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.957944869995117D), Telerik.Reporting.Drawing.Unit.Cm(2.0423333644866943D));
            this.varCotizaDivisaDataTextBox.Name = "varCotizaDivisaDataTextBox";
            this.varCotizaDivisaDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.83505558967590332D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.varCotizaDivisaDataTextBox.StyleName = "Data";
            this.varCotizaDivisaDataTextBox.Value = "= Fields.VarCotizaDivisa";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.57150000333786011D);
            this.detail.Name = "detail";
            // 
            // Report2
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.codigoICGroupFooterSection;
            group1.GroupHeader = this.codigoICGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.CodigoIC"));
            group1.Name = "codigoICGroup";
            group2.GroupFooter = this.labelsGroupFooterSection;
            group2.GroupHeader = this.labelsGroupHeaderSection;
            group2.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.codigoICGroupHeaderSection,
            this.codigoICGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "Report2";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.835333824157715D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection codigoICGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection codigoICGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox codigoICCaptionTextBox;
        private Telerik.Reporting.TextBox codigoICDataTextBox;
        private Telerik.Reporting.TextBox cotizaDivDesdeCaptionTextBox;
        private Telerik.Reporting.TextBox cotizaDivDesdeDataTextBox;
        private Telerik.Reporting.TextBox cotizaDivHastaCaptionTextBox;
        private Telerik.Reporting.TextBox cotizaDivHastaDataTextBox;
        private Telerik.Reporting.TextBox descripcionCaptionTextBox;
        private Telerik.Reporting.TextBox descripcionDataTextBox;
        private Telerik.Reporting.TextBox fechaDesdeCaptionTextBox;
        private Telerik.Reporting.TextBox fechaDesdeDataTextBox;
        private Telerik.Reporting.TextBox fechaHastaCaptionTextBox;
        private Telerik.Reporting.TextBox fechaHastaDataTextBox;
        private Telerik.Reporting.TextBox idCaptionTextBox;
        private Telerik.Reporting.TextBox idDataTextBox;
        private Telerik.Reporting.TextBox isinCaptionTextBox;
        private Telerik.Reporting.TextBox isinDataTextBox;
        private Telerik.Reporting.TextBox varCotizaDivisaCaptionTextBox;
        private Telerik.Reporting.TextBox varCotizaDivisaDataTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
    }
}