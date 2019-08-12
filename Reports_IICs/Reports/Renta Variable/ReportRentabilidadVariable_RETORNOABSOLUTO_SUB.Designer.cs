namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable_RETORNOABSOLUTO_SUB
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
            Telerik.Reporting.TypeReportSource typeReportSource5 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportPatrimonialista = new Telerik.Reporting.SubReport();
            this.subReportCCCP = new Telerik.Reporting.SubReport();
            this.subReportPERSISTENCIA = new Telerik.Reporting.SubReport();
            this.subReportOTROS = new Telerik.Reporting.SubReport();
            this.subReportIICS = new Telerik.Reporting.SubReport();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBoxTitle = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(3.7577669620513916D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportPatrimonialista,
            this.subReportCCCP,
            this.subReportPERSISTENCIA,
            this.subReportOTROS,
            this.subReportIICS});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subReportPatrimonialista
            // 
            this.subReportPatrimonialista.KeepTogether = false;
            this.subReportPatrimonialista.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(0.85776692628860474D));
            this.subReportPatrimonialista.Name = "subReportPatrimonialista";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "5"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "7) PATRIMONIALISTA"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportPatrimonialista.ReportSource = typeReportSource1;
            this.subReportPatrimonialista.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.099998474121094D), Telerik.Reporting.Drawing.Unit.Cm(0.60000020265579224D));
            this.subReportPatrimonialista.ItemDataBound += new System.EventHandler(this.subReportPatrimonialista_ItemDataBound);
            // 
            // subReportCCCP
            // 
            this.subReportCCCP.KeepTogether = false;
            this.subReportCCCP.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(1.5577666759490967D));
            this.subReportCCCP.Name = "subReportCCCP";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", null));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "11"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "8) CCCP"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportCCCP.ReportSource = typeReportSource2;
            this.subReportCCCP.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.099998474121094D), Telerik.Reporting.Drawing.Unit.Cm(0.59999954700469971D));
            this.subReportCCCP.ItemDataBound += new System.EventHandler(this.subReportCCCP_ItemDataBound);
            // 
            // subReportPERSISTENCIA
            // 
            this.subReportPERSISTENCIA.KeepTogether = false;
            this.subReportPERSISTENCIA.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(2.2577667236328125D));
            this.subReportPERSISTENCIA.Name = "subReportPERSISTENCIA";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", null));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "12"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "9) PERSISTENCIA"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportPERSISTENCIA.ReportSource = typeReportSource3;
            this.subReportPERSISTENCIA.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.099998474121094D), Telerik.Reporting.Drawing.Unit.Cm(0.60000050067901611D));
            this.subReportPERSISTENCIA.ItemDataBound += new System.EventHandler(this.subReportPERSISTENCIA_ItemDataBound);
            // 
            // subReportOTROS
            // 
            this.subReportOTROS.KeepTogether = false;
            this.subReportOTROS.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(2.9577667713165283D));
            this.subReportOTROS.Name = "subReportOTROS";
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "3"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "4"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "10) OTROS"));
            typeReportSource4.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportOTROS.ReportSource = typeReportSource4;
            this.subReportOTROS.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.099998474121094D), Telerik.Reporting.Drawing.Unit.Cm(0.59999984502792358D));
            this.subReportOTROS.ItemDataBound += new System.EventHandler(this.subReportOTROS_ItemDataBound);
            // 
            // subReportIICS
            // 
            this.subReportIICS.KeepTogether = false;
            this.subReportIICS.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000070333480835D), Telerik.Reporting.Drawing.Unit.Cm(0.15776684880256653D));
            this.subReportIICS.Name = "subReportIICS";
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "3"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "2"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "6) IIC"));
            typeReportSource5.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportIICS.ReportSource = typeReportSource5;
            this.subReportIICS.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.099998474121094D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.subReportIICS.ItemDataBound += new System.EventHandler(this.subReportIICS_ItemDataBound);
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.44223320484161377D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxTitle});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            this.reportHeaderSection1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(5D);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.257667541503906D), Telerik.Reporting.Drawing.Unit.Cm(0.44213318824768066D));
            this.textBoxTitle.Style.Font.Bold = true;
            this.textBoxTitle.Style.Font.Name = "Tahoma";
            this.textBoxTitle.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBoxTitle.Value = "= Parameters.Title.Value";
            // 
            // ReportRentabilidadVariable_RETORNOABSOLUTO_SUB
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1});
            this.Name = "ReportRentabilidadVariable_RETORNOABSOLUTO_SUB";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.5D);
            this.ItemDataBound += new System.EventHandler(this.ReportRentabilidadVariable_RETORNOABSOLUTO_SUB_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBoxTitle;
        private Telerik.Reporting.SubReport subReportPatrimonialista;
        private Telerik.Reporting.SubReport subReportCCCP;
        private Telerik.Reporting.SubReport subReportPERSISTENCIA;
        private Telerik.Reporting.SubReport subReportOTROS;
        private Telerik.Reporting.SubReport subReportIICS;
    }
}