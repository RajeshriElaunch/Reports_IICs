namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    using DataModels;
    using ViewModels.Reports.Secciones;
    using System;
    using System.Collections.Generic;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Linq;
    using Helpers;

    /// <summary>
    /// Summary description for ReportRentabilidadCarteraV2.
    /// </summary>
    public partial class ReportRentabilidadCarteraV2 : Telerik.Reporting.Report
    {
        public ReportRentabilidadCarteraV2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

       

        public ReportRentabilidadCarteraV2(string isin, string codigoic, DateTime fecha, Plantilla plantilla)
        {

            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["Fecha"].Value = fecha;
            this.ReportParameters["Esindice"].Value = 0;
            //prueba cambio nombre
            this.textBox12.Value = "ÍNDICE " + plantilla.Descripcion;
            //fin prueba
            List <Report> detailReports = new List<Report>();
            List<string> isins = new List<string>();
           

            //var indices = RentabilidadCarteraV2_DA.GetDistinctIndices(codigoic);
            var renta = DataAccess.Reports.RentabilidadCartera_DA.GetTemp_RentabilidadCarteraV2(plantilla.CodigoIc, null);

            //var ListaIsin = renta.Where(r => r.CodigoIC == plantilla.CodigoIc && !r.EsIndice.Value).Select(s => s.Isin).Distinct();


            //foreach (var item in ListaIsin)
            //{
            //    isins.Add(item);
            //}

            //isins.Add(isin);

            var indices = renta.Where(r => r.CodigoIC == plantilla.CodigoIc && r.EsIndice.Value).Select(s => s.Isin).Distinct();


            foreach (var item in indices)
            {
                isins.Add(item);
            }

            float subReportAncho = 0;

            foreach (var cisin in isins)
            {
                this.ReportParameters["Isin"].Value = cisin;
                Report rep = RentabilidadCarteraV2_VM.GetReportRentabilidadCarteraV2_SUB(codigoic, cisin, fecha);
                subReportAncho = subReportAncho + rep.Width.Value;

                detailReports.Add(rep);
            }
            
            //subReportAncho = subReportAncho + (float)6.9;

            this.sqlDataSource1.Parameters[0].Value = codigoic;
            //this.sqlDataSource1.Parameters[1].Value =  this.ReportParameters["Isin"].Value;
            this.sqlDataSource1.Parameters[1].Value = isin;
            Report report = GetCombinedReport(detailReports);
            //this.subReportRentCart.ReportSource = report;

            //if (subReportAncho == 0) subReportAncho = (float)2.85;
            report.Width = new Unit(subReportAncho, UnitType.Cm);
             this.subReportRentCartIndice.ReportSource = report;

           // subReportAncho = subReportAncho + subReportRentCart.Width.Value;


            //this.textBoxTitle.Width = this.table1.Width + this.subReportRentCart.Width;
            var tableFechaAncho = this.tableFecha.Width.Value;
            //var subReportAncho = this.subReportRentCart.Width.Value;
            var anchoContenido = tableFechaAncho + table1.Width.Value + table3.Width.Value + subReportAncho;
            //Dividimos entre 10 por que estamos haciendo todos los cálculos en cms
            var anchoMargenes = this.PageSettings.Margins.Left.Value/10 + this.PageSettings.Margins.Right.Value/10;

            //var anchoDetailSection = 25.89;
            var anchoPag = 29.7;

            var locationX = ((anchoPag - (anchoContenido + anchoMargenes)) / 2);
           
            var locationY = this.panel1.Location.Y.Value;
             //this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4D), Telerik.Reporting.Drawing.Unit.Cm(1.02D));
             this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(locationX), Telerik.Reporting.Drawing.Unit.Cm(1.02D));            
            //this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(locationX), Telerik.Reporting.Drawing.Unit.Cm(locationY));
        }

        private static Report GetCombinedReport(List<Report> detailReports)
        {
            Report report = new Report();
            DetailSection detail = new DetailSection();
            report.Items.Add(detail);

            Unit unitX = Unit.Cm(0.0);
            Unit unitY = Unit.Cm(0.0);
            SizeU size = new SizeU(Unit.Cm(1), Unit.Cm(0.1));
            //sólo nos caben 3 por línea. Después de 3 pasamos a la siguiente línea
            int añadidos = 0;
            foreach (Report detailReport in detailReports)
            {
                SubReport subReport;

                subReport = new SubReport();
                if (añadidos > 0 && añadidos % 6 == 0)
                {
                    unitX = Unit.Cm(0.0);
                    unitY = unitY.Add(Unit.Cm(2.87));
                }
                subReport.Location = new PointU(unitX, unitY);
                subReport.Size = size;
                //unitY = unitY.Add(Unit.Inch(1));

                unitX = unitX.Add(Unit.Cm(1));
                
                subReport.ReportSource = detailReport;
                detail.Items.Add(subReport);
                añadidos++;
            }
            //detail.Height = Unit.Inch(detailReports.Count + 1);
            return report;
        }

        private void ReportRentabilidadCarteraV2_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}