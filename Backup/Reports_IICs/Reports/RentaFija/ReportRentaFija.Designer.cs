namespace Reports_IICs.Reports.RentaFija
{
    partial class ReportRentaFija
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportRentaFija));
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource2 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource3 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource4 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource5 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource6 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource7 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource8 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.subReport3 = new Telerik.Reporting.SubReport();
            this.subReport4 = new Telerik.Reporting.SubReport();
            this.subReport5 = new Telerik.Reporting.SubReport();
            this.subReport6 = new Telerik.Reporting.SubReport();
            this.subReport7 = new Telerik.Reporting.SubReport();
            this.subReport8 = new Telerik.Reporting.SubReport();
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
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(11.800000190734863D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1,
            this.subReport2,
            this.subReport3,
            this.subReport4,
            this.subReport5,
            this.subReport6,
            this.subReport7,
            this.subReport8});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subReport1
            // 
            this.subReport1.KeepTogether = true;
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332D));
            this.subReport1.Name = "subReport1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "= Format(\"1) Deuda que teníamos en cartera a {0:dd/MM/yyyy} y no se han vendido e" +
            "n {1:yyyy}\", Parameters.FechaInicio.Value, Parameters.FechaInforme.Value)"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "1"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaInicio", "= Parameters.FechaInicio.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Large, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport1.ReportSource = typeReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0997997522354126D));
            // 
            // subReport2
            // 
            this.subReport2.KeepTogether = false;
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.subReport2.Name = "subReport2";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "= Format(\"2) Deuda que teníamos en cartera el {0:dd/MM/yyyy} y se ha amortizado e" +
            "n {1:yyyy}\", Parameters.FechaInicio.Value, Parameters.FechaInforme.Value)"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "2"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaInicio", "= Parameters.FechaInicio.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Large, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport2.ReportSource = typeReportSource2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0997997522354126D));
            // 
            // subReport3
            // 
            this.subReport3.KeepTogether = false;
            this.subReport3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.4000000953674316D));
            this.subReport3.Name = "subReport3";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "= Format(\"3) Deuda que teníamos en cartera el {0:dd/MM/yyyy} y se ha vendido en {" +
            "1:yyyy}\", Parameters.FechaInicio.Value, Parameters.FechaInforme.Value)"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "3"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaInicio", "= Parameters.FechaInicio.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Large, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport3.ReportSource = typeReportSource3;
            this.subReport3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0997997522354126D));
            // 
            // subReport4
            // 
            this.subReport4.KeepTogether = false;
            this.subReport4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D));
            this.subReport4.Name = "subReport4";
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "= Format(\"4) Deuda que se ha comprado en {0:yyyy} y no se ha vendido en {0:yyyy}\"" +
            ", Parameters.FechaInforme.Value)"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "4"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaInicio", "= Parameters.FechaInicio.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource4.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Large, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport4.ReportSource = typeReportSource4;
            this.subReport4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0997997522354126D));
            // 
            // subReport5
            // 
            this.subReport5.KeepTogether = false;
            this.subReport5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D));
            this.subReport5.Name = "subReport5";
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "= Format(\"5) Deuda comprada y vendida en {0:yyyy}\", Parameters.FechaInforme.Value" +
            ")"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "5"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("FechaInicio", "= Parameters.FechaInicio.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource5.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Large, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport5.ReportSource = typeReportSource5;
            this.subReport5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.0997997522354126D));
            // 
            // subReport6
            // 
            this.subReport6.KeepTogether = false;
            this.subReport6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(6D));
            this.subReport6.Name = "subReport6";
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "6) IICs"));
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "6"));
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource6.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Short, Reports_IICs, Version=1" +
    ".0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport6.ReportSource = typeReportSource6;
            this.subReport6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.699897766113281D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.subReport6.ItemDataBound += new System.EventHandler(this.subReport6_ItemDataBound);
            // 
            // subReport7
            // 
            this.subReport7.KeepTogether = false;
            this.subReport7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(7.2000002861022949D));
            this.subReport7.Name = "subReport7";
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "7) Derivados"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("Grupo", "7"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource7.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_SUB_Short, Reports_IICs, Version=1" +
    ".1.44.0, Culture=neutral, PublicKeyToken=null";
            this.subReport7.ReportSource = typeReportSource7;
            this.subReport7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.699897766113281D), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579D));
            this.subReport7.ItemDataBound += new System.EventHandler(this.subReport7_ItemDataBound);
            // 
            // subReport8
            // 
            this.subReport8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(8.5D));
            this.subReport8.Name = "subReport8";
            typeReportSource8.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource8.Parameters.Add(new Telerik.Reporting.Parameter("IsinPlantilla", "= Parameters.IsinPlantilla.Value"));
            typeReportSource8.TypeName = "Reports_IICs.Reports.RentaFija.ReportRentaFija_Totales_SUB, Reports_IICs, Version" +
    "=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReport8.ReportSource = typeReportSource8;
            this.subReport8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9999995231628418D), Telerik.Reporting.Drawing.Unit.Cm(3.0453333854675293D));
            this.subReport8.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(1D);
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
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.100100517272949D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.56000000238418579D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TextNumPaginaPie.Value = "= Format(\"{0} {1} {2} {3}\", Reports_IICs.Helpers.ReportFunctions.ReportPageText()" +
    ", PageNumber-1,Reports_IICs.Helpers.ReportFunctions.ReportFromText(), PageCount-" +
    "1 )  \r\n";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TituloReport});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // TituloReport
            // 
            this.TituloReport.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.69999885559082D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportRentaFija()";
            // 
            // ReportRentaFija
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportRentaFija";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowBlank = false;
            reportParameter1.Name = "CodigoIC";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "IsinPlantilla";
            reportParameter3.Name = "FechaInicio";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter4.Name = "FechaInforme";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.DateTime;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(17.700099945068359D);
            this.ItemDataBound += new System.EventHandler(this.ReportRentaFija_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.SubReport subReport2;
        private Telerik.Reporting.SubReport subReport3;
        private Telerik.Reporting.SubReport subReport4;
        private Telerik.Reporting.SubReport subReport5;
        private Telerik.Reporting.SubReport subReport6;
        private Telerik.Reporting.SubReport subReport7;
        private Telerik.Reporting.SubReport subReport8;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
    }
}