namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportGarantizados = new Telerik.Reporting.SubReport();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBoxTitle = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5577664375305176D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportGarantizados});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subReportGarantizados
            // 
            this.subReportGarantizados.KeepTogether = false;
            this.subReportGarantizados.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(0.1575666069984436D));
            this.subReportGarantizados.Name = "subReportGarantizados";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "12"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "11) Garantizados / Estructurados"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGarantizados.ReportSource = typeReportSource1;
            this.subReportGarantizados.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.subReportGarantizados.ItemDataBound += new System.EventHandler(this.subReportIICS_ItemDataBound);
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.442233145236969D);
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
            // ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1});
            this.Name = "ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Mm(0.40000000596046448D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "Title";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(27.899999618530273D);
            this.ItemDataBound += new System.EventHandler(this.ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBoxTitle;
        private Telerik.Reporting.SubReport subReportGarantizados;
    }
}