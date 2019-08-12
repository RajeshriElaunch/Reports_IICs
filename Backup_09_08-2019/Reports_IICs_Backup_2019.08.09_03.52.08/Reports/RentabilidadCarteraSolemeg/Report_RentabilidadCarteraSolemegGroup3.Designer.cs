namespace Reports_IICs.Reports.RentabilidadCarteraSolemeg
{
    partial class Report_RentabilidadCarteraSolemegGroup3
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
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportGroup3_SPAINRV_SUB = new Telerik.Reporting.SubReport();
            this.subReportGroup3_NOTSPAINRV_SUB = new Telerik.Reporting.SubReport();
            this.subReportGroup3_NOTRV_SUB = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583338141441345D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(4.5005011558532715D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportGroup3_SPAINRV_SUB,
            this.subReportGroup3_NOTSPAINRV_SUB,
            this.subReportGroup3_NOTRV_SUB});
            this.detail.Name = "detail";
            // 
            // subReportGroup3_SPAINRV_SUB
            // 
            this.subReportGroup3_SPAINRV_SUB.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9800105090253055E-05D), Telerik.Reporting.Drawing.Unit.Cm(0.00010004234354710206D));
            this.subReportGroup3_SPAINRV_SUB.Name = "subReportGroup3_SPAINRV_SUB";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "= Parameters.Grupo.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "= Parameters.NombreGrupo.Value"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "Group3_SPAINRV_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyTok" +
    "en=null";
            this.subReportGroup3_SPAINRV_SUB.ReportSource = typeReportSource1;
            this.subReportGroup3_SPAINRV_SUB.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.999800682067871D), Telerik.Reporting.Drawing.Unit.Cm(1.5000001192092896D));
            this.subReportGroup3_SPAINRV_SUB.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Dashed;
            // 
            // subReportGroup3_NOTSPAINRV_SUB
            // 
            this.subReportGroup3_NOTSPAINRV_SUB.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.5003005266189575D));
            this.subReportGroup3_NOTSPAINRV_SUB.Name = "subReportGroup3_NOTSPAINRV_SUB";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "= Parameters.Grupo.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "= Parameters.NombreGrupo.Value"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "Group3_NOTSPAINRV_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKey" +
    "Token=null";
            this.subReportGroup3_NOTSPAINRV_SUB.ReportSource = typeReportSource2;
            this.subReportGroup3_NOTSPAINRV_SUB.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.999800682067871D), Telerik.Reporting.Drawing.Unit.Cm(1.5000001192092896D));
            this.subReportGroup3_NOTSPAINRV_SUB.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Dashed;
            this.subReportGroup3_NOTSPAINRV_SUB.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // subReportGroup3_NOTRV_SUB
            // 
            this.subReportGroup3_NOTRV_SUB.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.0005009174346924D));
            this.subReportGroup3_NOTRV_SUB.Name = "subReportGroup3_NOTRV_SUB";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "= Parameters.Grupo.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("NombreGrupo", "= Parameters.NombreGrupo.Value"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.RentabilidadCarteraSolemeg.Report_RentabilidadCarteraSolemeg" +
    "Group3_NOTRV_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken" +
    "=null";
            this.subReportGroup3_NOTRV_SUB.ReportSource = typeReportSource3;
            this.subReportGroup3_NOTRV_SUB.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.999800682067871D), Telerik.Reporting.Drawing.Unit.Cm(1.5000001192092896D));
            this.subReportGroup3_NOTRV_SUB.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.10583338141441345D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // Report_RentabilidadCarteraSolemegGroup3
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "Report_RentabilidadCarteraSolemegGroup3";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "Isin";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "Grupo";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "NombreGrupo";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SubReport subReportGroup3_SPAINRV_SUB;
        private Telerik.Reporting.SubReport subReportGroup3_NOTSPAINRV_SUB;
        private Telerik.Reporting.SubReport subReportGroup3_NOTRV_SUB;
    }
}