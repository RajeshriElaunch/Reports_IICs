namespace Reports_IICs.Reports.Portada
{
    partial class Report_Portada2
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_Portada2));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.txtB_Info = new Telerik.Reporting.TextBox();
            this.txtB_Name = new Telerik.Reporting.TextBox();
            this.txtB_Fecha = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // LogoPortada
            // 
            this.LogoPortada.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Bottom | Telerik.Reporting.AnchoringStyles.Left)));
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.9999995231628418D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(1.6299999952316284D));
            this.LogoPortada.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.500096321105957D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtB_Info,
            this.txtB_Name,
            this.txtB_Fecha});
            this.detail.Name = "detail";
            // 
            // txtB_Info
            // 
            this.txtB_Info.Anchoring = ((Telerik.Reporting.AnchoringStyles)((((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom) 
            | Telerik.Reporting.AnchoringStyles.Left) 
            | Telerik.Reporting.AnchoringStyles.Right)));
            this.txtB_Info.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.99999964237213135D), Telerik.Reporting.Drawing.Unit.Cm(4.09999942779541D));
            this.txtB_Info.Name = "txtB_Info";
            this.txtB_Info.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.260000228881836D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Info.Style.Font.Bold = true;
            this.txtB_Info.Style.Font.Name = "Tahoma";
            this.txtB_Info.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(28D);
            this.txtB_Info.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Info.Value = "INFORME DE SITUACIÓN";
            // 
            // txtB_Name
            // 
            this.txtB_Name.Anchoring = ((Telerik.Reporting.AnchoringStyles)((((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom) 
            | Telerik.Reporting.AnchoringStyles.Left) 
            | Telerik.Reporting.AnchoringStyles.Right)));
            this.txtB_Name.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.99999964237213135D), Telerik.Reporting.Drawing.Unit.Cm(5.4999995231628418D));
            this.txtB_Name.Name = "txtB_Name";
            this.txtB_Name.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.260000228881836D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Name.Style.Font.Bold = true;
            this.txtB_Name.Style.Font.Name = "Tahoma";
            this.txtB_Name.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(28D);
            this.txtB_Name.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Name.Value = "textBox1";
            // 
            // txtB_Fecha
            // 
            this.txtB_Fecha.Anchoring = ((Telerik.Reporting.AnchoringStyles)((((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom) 
            | Telerik.Reporting.AnchoringStyles.Left) 
            | Telerik.Reporting.AnchoringStyles.Right)));
            this.txtB_Fecha.Format = "{0:dd \"de\" MMMM \"de\" yyyy }";
            this.txtB_Fecha.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.99999964237213135D), Telerik.Reporting.Drawing.Unit.Cm(6.8999996185302734D));
            this.txtB_Fecha.Name = "txtB_Fecha";
            this.txtB_Fecha.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.260000228881836D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.txtB_Fecha.Style.Color = System.Drawing.Color.Gray;
            this.txtB_Fecha.Style.Font.Bold = true;
            this.txtB_Fecha.Style.Font.Name = "Tahoma";
            this.txtB_Fecha.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.txtB_Fecha.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtB_Fecha.Value = "textBox1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Bottom | Telerik.Reporting.AnchoringStyles.Right)));
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.029999732971191D), Telerik.Reporting.Drawing.Unit.Cm(0.59990036487579346D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2300000190734863D), Telerik.Reporting.Drawing.Unit.Cm(1.0299999713897705D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox1
            // 
            this.textBox1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Bottom | Telerik.Reporting.AnchoringStyles.Right)));
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.029999732971191D), Telerik.Reporting.Drawing.Unit.Cm(0.19970357418060303D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2300012111663818D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Tahoma";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Depositario";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.6299999952316284D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.LogoPortada,
            this.textBox1,
            this.pictureBox1});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // Report_Portada2
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "Report_Portada";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(15.260001182556152D);
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
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox1;
    }
}