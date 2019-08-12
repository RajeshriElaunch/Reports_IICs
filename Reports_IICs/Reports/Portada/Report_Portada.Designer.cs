namespace Reports_IICs.Reports.Portada
{
    partial class Report_Portada
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_Portada));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.txtB_Info = new Telerik.Reporting.TextBox();
            this.txtB_Name = new Telerik.Reporting.TextBox();
            this.txtB_Fecha = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
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
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1.0999997854232788D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(8.8000001907348633D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtB_Info,
            this.txtB_Name,
            this.txtB_Fecha});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(4.0999999046325684D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.9000992774963379D));
            // 
            // txtB_Info
            // 
            this.txtB_Info.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.txtB_Info.Name = "txtB_Info";
            this.txtB_Info.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Info.Style.Font.Bold = true;
            this.txtB_Info.Style.Font.Name = "Tahoma";
            this.txtB_Info.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(28D);
            this.txtB_Info.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Info.Value = "INFORME DE SITUACIÓN";
            // 
            // txtB_Name
            // 
            this.txtB_Name.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D), Telerik.Reporting.Drawing.Unit.Cm(1.4001010656356812D));
            this.txtB_Name.Name = "txtB_Name";
            this.txtB_Name.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Name.Style.Font.Bold = true;
            this.txtB_Name.Style.Font.Name = "Tahoma";
            this.txtB_Name.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(28D);
            this.txtB_Name.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Name.Value = "textBox1";
            // 
            // txtB_Fecha
            // 
            this.txtB_Fecha.Format = "{0:dd \"de\" MMMM \"de\" yyyy }";
            this.txtB_Fecha.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D), Telerik.Reporting.Drawing.Unit.Cm(2.8000996112823486D));
            this.txtB_Fecha.Name = "txtB_Fecha";
            this.txtB_Fecha.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Fecha.Style.Color = System.Drawing.Color.Gray;
            this.txtB_Fecha.Style.Font.Bold = true;
            this.txtB_Fecha.Style.Font.Name = "Tahoma";
            this.txtB_Fecha.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.txtB_Fecha.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Fecha.Value = "textBox1";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // Report_Portada
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "Report_Portada";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
            this.ItemDataBinding += new System.EventHandler(this.Report_Portada_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.TextBox txtB_Info;
        private Telerik.Reporting.TextBox txtB_Name;
        private Telerik.Reporting.TextBox txtB_Fecha;
        private Telerik.Reporting.Panel panel1;
    }
}