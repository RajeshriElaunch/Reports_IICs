namespace Reports_IICs.Reports.Renta_Variable
{
    partial class ReportRentabilidadVariable
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportRentabilidadVariable));
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource2 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource3 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource4 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource5 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource6 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource7 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource8 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource9 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource10 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource11 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.TypeReportSource typeReportSource12 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.LogoPortada = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportGRUPO1 = new Telerik.Reporting.SubReport();
            this.subReportGRUPO2 = new Telerik.Reporting.SubReport();
            this.subReportGRUPO3 = new Telerik.Reporting.SubReport();
            this.subReportGRUPO4 = new Telerik.Reporting.SubReport();
            this.subReportRetornoAbsoluto = new Telerik.Reporting.SubReport();
            this.subReportGarantizados_Estructurados = new Telerik.Reporting.SubReport();
            this.subReportDerivados = new Telerik.Reporting.SubReport();
            this.subReportDivisas = new Telerik.Reporting.SubReport();
            this.subReportCommodities = new Telerik.Reporting.SubReport();
            this.panel1 = new Telerik.Reporting.Panel();
            this.subReportTotalRV = new Telerik.Reporting.SubReport();
            this.subReportTotalRAB = new Telerik.Reporting.SubReport();
            this.subReportTotalGAR = new Telerik.Reporting.SubReport();
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
            this.LogoPortada.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.9961594969499856E-05D));
            this.LogoPortada.MimeType = "image/jpeg";
            this.LogoPortada.Name = "LogoPortada";
            this.LogoPortada.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.LogoPortada.Value = ((object)(resources.GetObject("LogoPortada.Value")));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(12.599699974060059D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportGRUPO1,
            this.subReportGRUPO2,
            this.subReportGRUPO3,
            this.subReportGRUPO4,
            this.subReportRetornoAbsoluto,
            this.subReportGarantizados_Estructurados,
            this.subReportDerivados,
            this.subReportDivisas,
            this.subReportCommodities,
            this.panel1});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            // 
            // subReportGRUPO1
            // 
            this.subReportGRUPO1.KeepTogether = false;
            this.subReportGRUPO1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(0.19970034062862396D));
            this.subReportGRUPO1.Name = "subReportGRUPO1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Title", "= Format(\"1) Valores que teníamos en cartera a {0:dd/MM/yyyy} y no se han vendido" +
            " en {1:yyyy}\", Parameters.FechaAnterior.Value, Parameters.FechaInforme.Value)"));
            typeReportSource1.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO1_SUB, Report" +
    "s_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGRUPO1.ReportSource = typeReportSource1;
            this.subReportGRUPO1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.404750823974609D), Telerik.Reporting.Drawing.Unit.Cm(0.69999992847442627D));
            this.subReportGRUPO1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportGRUPO1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            // 
            // subReportGRUPO2
            // 
            this.subReportGRUPO2.KeepTogether = false;
            this.subReportGRUPO2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(0.99970024824142456D));
            this.subReportGRUPO2.Name = "subReportGRUPO2";
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("Title", "= Parameters.Title.Value"));
            typeReportSource2.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO2_SUB, Report" +
    "s_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGRUPO2.ReportSource = typeReportSource2;
            this.subReportGRUPO2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.80000025033950806D));
            this.subReportGRUPO2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportGRUPO2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            // 
            // subReportGRUPO3
            // 
            this.subReportGRUPO3.KeepTogether = false;
            this.subReportGRUPO3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(1.8997005224227905D));
            this.subReportGRUPO3.Name = "subReportGRUPO3";
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("Title", "= Parameters.Title.Value"));
            typeReportSource3.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO3_SUB, Report" +
    "s_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGRUPO3.ReportSource = typeReportSource3;
            this.subReportGRUPO3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.79999959468841553D));
            this.subReportGRUPO3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportGRUPO3.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            // 
            // subReportGRUPO4
            // 
            this.subReportGRUPO4.KeepTogether = false;
            this.subReportGRUPO4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000003129243851D), Telerik.Reporting.Drawing.Unit.Cm(2.7997004985809326D));
            this.subReportGRUPO4.Name = "subReportGRUPO4";
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaInforme", "= Parameters.FechaInforme.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FechaAnterior", "= Parameters.FechaAnterior.Value"));
            typeReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("Title", "= Parameters.Title.Value"));
            typeReportSource4.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO4_SUB, Report" +
    "s_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportGRUPO4.ReportSource = typeReportSource4;
            this.subReportGRUPO4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.80000025033950806D));
            this.subReportGRUPO4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportGRUPO4.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            // 
            // subReportRetornoAbsoluto
            // 
            this.subReportRetornoAbsoluto.KeepTogether = false;
            this.subReportRetornoAbsoluto.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(4.5996999740600586D));
            this.subReportRetornoAbsoluto.Name = "subReportRetornoAbsoluto";
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("Title", "RETORNO ABSOLUTO"));
            typeReportSource5.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_RETORNOABSOLUTO_SU" +
    "B, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportRetornoAbsoluto.ReportSource = typeReportSource5;
            this.subReportRetornoAbsoluto.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.80000007152557373D));
            this.subReportRetornoAbsoluto.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportRetornoAbsoluto.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.subReportRetornoAbsoluto.Style.Visible = true;
            // 
            // subReportGarantizados_Estructurados
            // 
            this.subReportGarantizados_Estructurados.KeepTogether = false;
            this.subReportGarantizados_Estructurados.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000091791152954D), Telerik.Reporting.Drawing.Unit.Cm(5.49970006942749D));
            this.subReportGarantizados_Estructurados.Name = "subReportGarantizados_Estructurados";
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource6.Parameters.Add(new Telerik.Reporting.Parameter("Title", "GARANTIZADOS/ESTRUCTURADOS"));
            typeReportSource6.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GARANTIZADOSESTRUC" +
    "TURADOS_SUB, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null" +
    "";
            this.subReportGarantizados_Estructurados.ReportSource = typeReportSource6;
            this.subReportGarantizados_Estructurados.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.90000075101852417D));
            this.subReportGarantizados_Estructurados.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportGarantizados_Estructurados.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.subReportGarantizados_Estructurados.Style.Visible = true;
            // 
            // subReportDerivados
            // 
            this.subReportDerivados.KeepTogether = false;
            this.subReportDerivados.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0846666619181633D), Telerik.Reporting.Drawing.Unit.Cm(3.699699878692627D));
            this.subReportDerivados.Name = "subReportDerivados";
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "1"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("IdTipoInstrumento", "3"));
            typeReportSource7.Parameters.Add(new Telerik.Reporting.Parameter("SubTitle", "5) Derivados"));
            typeReportSource7.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_GRUPO_SUB_Posicion" +
    "es, Reports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportDerivados.ReportSource = typeReportSource7;
            this.subReportDerivados.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.80000007152557373D));
            this.subReportDerivados.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportDerivados.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.subReportDerivados.Style.Visible = true;
            // 
            // subReportDivisas
            // 
            this.subReportDivisas.KeepTogether = false;
            this.subReportDivisas.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000188648700714D), Telerik.Reporting.Drawing.Unit.Cm(6.499699592590332D));
            this.subReportDivisas.Name = "subReportDivisas";
            typeReportSource8.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource8.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource8.Parameters.Add(new Telerik.Reporting.Parameter("Title", "DIVISAS"));
            typeReportSource8.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_DIVISAS_SUB, Repor" +
    "ts_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportDivisas.ReportSource = typeReportSource8;
            this.subReportDivisas.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.90000075101852417D));
            this.subReportDivisas.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportDivisas.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.subReportDivisas.Style.Visible = true;
            // 
            // subReportCommodities
            // 
            this.subReportCommodities.KeepTogether = false;
            this.subReportCommodities.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D), Telerik.Reporting.Drawing.Unit.Cm(7.49970006942749D));
            this.subReportCommodities.Name = "subReportCommodities";
            typeReportSource9.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource9.Parameters.Add(new Telerik.Reporting.Parameter("Isin", "= Parameters.Isin.Value"));
            typeReportSource9.Parameters.Add(new Telerik.Reporting.Parameter("Title", "COMMODITIES"));
            typeReportSource9.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_COMMODITIES_SUB, R" +
    "eports_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportCommodities.ReportSource = typeReportSource9;
            this.subReportCommodities.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.400001525878906D), Telerik.Reporting.Drawing.Unit.Cm(0.90000075101852417D));
            this.subReportCommodities.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.subReportCommodities.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.subReportCommodities.Style.Visible = true;
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportTotalRV,
            this.subReportTotalRAB,
            this.subReportTotalGAR});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000357776880264D), Telerik.Reporting.Drawing.Unit.Cm(9.3997001647949219D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.399997711181641D), Telerik.Reporting.Drawing.Unit.Cm(3.2000002861022949D));
            this.panel1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            // 
            // subReportTotalRV
            // 
            this.subReportTotalRV.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.subReportTotalRV.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.6999964714050293D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.subReportTotalRV.Name = "subReportTotalRV";
            typeReportSource10.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource10.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "1"));
            typeReportSource10.Parameters.Add(new Telerik.Reporting.Parameter("Subtitle", "RENTA VARIABLE"));
            typeReportSource10.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_Totales_SUB, Repor" +
    "ts_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportTotalRV.ReportSource = typeReportSource10;
            this.subReportTotalRV.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(3D));
            this.subReportTotalRV.ItemDataBound += new System.EventHandler(this.subReportTotalRV_ItemDataBound);
            // 
            // subReportTotalRAB
            // 
            this.subReportTotalRAB.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.subReportTotalRAB.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.6999964714050293D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.subReportTotalRAB.Name = "subReportTotalRAB";
            typeReportSource11.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource11.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "3"));
            typeReportSource11.Parameters.Add(new Telerik.Reporting.Parameter("Subtitle", "RETORNO ABSOLUTO"));
            typeReportSource11.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_Totales_SUB, Repor" +
    "ts_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportTotalRAB.ReportSource = typeReportSource11;
            this.subReportTotalRAB.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(3D));
            this.subReportTotalRAB.ItemDataBound += new System.EventHandler(this.subReportTotalRAB_ItemDataBound);
            // 
            // subReportTotalGAR
            // 
            this.subReportTotalGAR.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.subReportTotalGAR.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.699995994567871D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.subReportTotalGAR.Name = "subReportTotalGAR";
            typeReportSource12.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));
            typeReportSource12.Parameters.Add(new Telerik.Reporting.Parameter("IdInstrumento", "12"));
            typeReportSource12.Parameters.Add(new Telerik.Reporting.Parameter("Subtitle", "OTROS:"));
            typeReportSource12.TypeName = "Reports_IICs.Reports.Renta_Variable.ReportRentabilidadVariable_Totales_SUB, Repor" +
    "ts_IICs, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null";
            this.subReportTotalGAR.ReportSource = typeReportSource12;
            this.subReportTotalGAR.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(3D));
            this.subReportTotalGAR.ItemDataBound += new System.EventHandler(this.subReportTotalGAR_ItemDataBound);
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.59999942779541016D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.TextNumPaginaPie});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // TextNumPaginaPie
            // 
            this.TextNumPaginaPie.Docking = Telerik.Reporting.DockingStyle.Right;
            this.TextNumPaginaPie.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(18.904750823974609D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.TextNumPaginaPie.Name = "TextNumPaginaPie";
            this.TextNumPaginaPie.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.59999942779541016D));
            this.TextNumPaginaPie.Style.Font.Name = "Tahoma";
            this.TextNumPaginaPie.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
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
            // TituloReport
            // 
            this.TituloReport.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.TituloReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.00019992318993899971D));
            this.TituloReport.Name = "TituloReport";
            this.TituloReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(22.504751205444336D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.TituloReport.Style.Font.Bold = true;
            this.TituloReport.Style.Font.Name = "Tahoma";
            this.TituloReport.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.TituloReport.Style.Font.Underline = false;
            this.TituloReport.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TituloReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TituloReport.Value = "= Reports_IICs.Helpers.ReportFunctions.TituloReportRentabilidadVariable()";
            // 
            // ReportRentabilidadVariable
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "ReportRentabilidadVariable";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(22.504751205444336D);
            this.ItemDataBound += new System.EventHandler(this.ReportRentabilidadVariable_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox LogoPortada;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox TituloReport;
        private Telerik.Reporting.TextBox TextNumPaginaPie;
        private Telerik.Reporting.SubReport subReportGRUPO1;
        private Telerik.Reporting.SubReport subReportGRUPO2;
        private Telerik.Reporting.SubReport subReportGRUPO3;
        private Telerik.Reporting.SubReport subReportGRUPO4;
        private Telerik.Reporting.SubReport subReportRetornoAbsoluto;
        private Telerik.Reporting.SubReport subReportGarantizados_Estructurados;
        private Telerik.Reporting.SubReport subReportDerivados;
        private Telerik.Reporting.SubReport subReportDivisas;
        private Telerik.Reporting.SubReport subReportCommodities;
        private Telerik.Reporting.SubReport subReportTotalRV;
        private Telerik.Reporting.SubReport subReportTotalRAB;
        private Telerik.Reporting.SubReport subReportTotalGAR;
        private Telerik.Reporting.Panel panel1;
    }
}