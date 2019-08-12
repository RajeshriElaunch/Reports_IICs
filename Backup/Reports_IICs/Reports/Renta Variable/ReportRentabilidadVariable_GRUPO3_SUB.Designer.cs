namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable_GRUPO3_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource2 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource3 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource4 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportIIcs = new Telerik.Reporting.SubReport();
            this.subReportDerivados = new Telerik.Reporting.SubReport();
            this.subReportOtros = new Telerik.Reporting.SubReport();
            this.subReportAcciones = new Telerik.Reporting.SubReport();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBoxTitle = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(1.3999998569488525D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportIIcs,
            this.subReportDerivados,
            this.subReportOtros,
            this.subReportAcciones});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subReportIIcs
            // 
            this.subReportIIcs.KeepTogether = false;
            this.subReportIIcs.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.29999977350234985D));
            this.subReportIIcs.Name = "subReportIIcs";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "IICs"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("GrupoDesc", "3"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Tipo", "IIC"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodInstrumento", "RVA,GLO,RVM"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB, Reports" +
    "_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportIIcs.ReportSource = typeReportSource1;
            this.subReportIIcs.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.80000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.subReportIIcs.ItemDataBound += new System.EventHandler(this.subReportIIcs_ItemDataBound);
            // 
            // subReportDerivados
            // 
            this.subReportDerivados.KeepTogether = false;
            this.subReportDerivados.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.59999984502792358D));
            this.subReportDerivados.Name = "subReportDerivados";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "Derivados"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("GrupoDesc", "3"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Tipo", "DER"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodInstrumento", "RVA,GLO,RVM"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB, Reports" +
    "_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportDerivados.ReportSource = typeReportSource2;
            this.subReportDerivados.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.80000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.subReportDerivados.ItemDataBound += new System.EventHandler(this.subReportDerivados_ItemDataBound);
            // 
            // subReportOtros
            // 
            this.subReportOtros.KeepTogether = false;
            this.subReportOtros.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.89999979734420776D));
            this.subReportOtros.Name = "subReportOtros";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "Otros"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("GrupoDesc", "3"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Tipo", "OTR"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodInstrumento", "RVA,GLO,RVM"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB, Reports" +
    "_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportOtros.ReportSource = typeReportSource3;
            this.subReportOtros.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.80000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.subReportOtros.ItemDataBound += new System.EventHandler(this.subReportOtros_ItemDataBound);
            // 
            // subReportAcciones
            // 
            this.subReportAcciones.KeepTogether = false;
            this.subReportAcciones.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.subReportAcciones.Name = "subReportAcciones";
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("GrupoDesc", "3"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "Acciones"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("Tipo", "VAL"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("CodInstrumento", "RVA,GLO,RVM"));
            typeReportSource4.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB, Reports" +
    "_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportAcciones.ReportSource = typeReportSource4;
            this.subReportAcciones.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.80000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.subReportAcciones.ItemDataBound += new System.EventHandler(this.subReportAcciones_ItemDataBound);
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxTitle});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            this.reportHeaderSection1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(5D);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.257667541503906D), Telerik.Reporting.Drawing.Unit.Cm(0.44213318824768066D));
            this.textBoxTitle.Style.Font.Bold = true;
            this.textBoxTitle.Style.Font.Name = "Tahoma";
            this.textBoxTitle.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBoxTitle.Value = "= Parameters.Title.Value";
            // 
            // ReportRentabilidadVariable_GRUPO3_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1});
            this.Name = "ReportRentabilidadVariable_GRUPO3_SUB";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "FechaInforme";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "FechaAnterior";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter5.AllowNull = true;
            reportParameter5.Name = "Title";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(20.014499664306641D);
            this.ItemDataBound += new System.EventHandler(this.ReportRentabilidadVariable_GRUPO3_SUB_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport subReportIIcs;
        private Telerik.Reporting.SubReport subReportDerivados;
        private Telerik.Reporting.SubReport subReportOtros;
        private Telerik.Reporting.SubReport subReportAcciones;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBoxTitle;
    }
}