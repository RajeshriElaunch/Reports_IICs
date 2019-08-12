namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Conjunto_Guissona
{
    using ViewModels.Reports.Secciones;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataModels;

    /// <summary>
    /// Summary description for ReportEvoluciónPatrimonioConjuntoGuissona.
    /// </summary>
    public partial class ReportEvoluciónPatrimonioConjuntoGuissona : Telerik.Reporting.Report
    {
        public ReportEvoluciónPatrimonioConjuntoGuissona()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportEvoluciónPatrimonioConjuntoGuissona(string isin, string codigoic, DateTime fecha, Plantilla plantilla)
        {

            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["Fecha"].Value = fecha;
            this.ReportParameters["YearInforme"].Value = fecha.Year;

            List<Report> detailReports = new List<Report>();
            List<string> isins = new List<string>();


            //var indices = RentabilidadCarteraV2_DA.GetDistinctIndices(codigoic);
            var renta = DataAccess.Reports.EvolucionPatrimonioConjuntoGuissona.GetTemp_EvolucionPatrimonioConjuntoGuissona(plantilla.CodigoIc, isin);

            //var ListaIsin = renta.Where(r => r.CodigoIC == plantilla.CodigoIc && !r.EsIndice.Value).Select(s => s.Isin).Distinct();


            //foreach (var item in ListaIsin)
            //{
            //    isins.Add(item);
            //}

            // isins.Add(isin);

            var indices = renta.Where(r => r.CodigoIC == plantilla.CodigoIc).Select(s => s.IsinFondo).Distinct();


            foreach (var item in indices)
            {
                isins.Add(item);
            }

            float subReportAncho = 0;

            foreach (var cisin in isins)
            {
                this.ReportParameters["Isin"].Value = cisin;
                Report rep = EvolucionPatrimConjuntoGuissona_VM.GetReportEvoluciónPatrimonioConjuntoGuissona_SUB(codigoic, cisin, fecha);
                subReportAncho = subReportAncho + rep.Width.Value;

                detailReports.Add(rep);
            }
            
            Report repTotal = EvolucionPatrimConjuntoGuissona_VM.GetReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB(codigoic, isin, fecha);
            subReportAncho = subReportAncho + repTotal.Width.Value;

            detailReports.Add(repTotal);
            
            Report repVariacio = EvolucionPatrimConjuntoGuissona_VM.GetReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB(codigoic, isin, fecha);
            subReportAncho = subReportAncho + repVariacio.Width.Value;

            detailReports.Add(repVariacio);
            
            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = this.ReportParameters["Isin"].Value;
            Report report = GetCombinedReport(detailReports);
            this.subReportPatrimonioConjuntoGuissona.ReportSource = report;

            //this.textBoxTitle.Width = this.table1.Width + this.subReportRentCart.Width;
            var tableFechaAncho = this.tableFecha.Width.Value;
            //var subReportAncho = this.subReportRentCart.Width.Value;
            var anchoContenido = tableFechaAncho + subReportAncho + textBox3.Width.Value; // + table1.Width.Value;
            //Dividimos entre 10 por que estamos haciendo todos los cálculos en cms
            var anchoMargenes = this.PageSettings.Margins.Left.Value / 10 + this.PageSettings.Margins.Right.Value / 10;

            //var anchoDetailSection = 25.89;
            var anchoPag = 29.7;

            var locationX = (anchoPag - (anchoContenido + anchoMargenes)) / 2;
            
            var locationY = this.panel1.Location.Y;
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(locationX), Telerik.Reporting.Drawing.Unit.Cm(1.02D));


        }


        private static Report GetCombinedReport(List<Report> detailReports)
        {
            Report report = new Report();
            DetailSection detail = new DetailSection();
            report.Items.Add(detail);

            Unit unitX = Unit.Cm(0.0);
            Unit unitY = Unit.Cm(0.0);
            SizeU size = new SizeU(Unit.Cm(1), Unit.Cm(0.1));
            //sólo nos caben 5 por línea. Después de 3 pasamos a la siguiente línea
            int añadidos = 0;
            foreach (Report detailReport in detailReports)
            {
                SubReport subReport;

                subReport = new SubReport();
                if (añadidos > 0 && añadidos % 7 == 0)
                {
                    unitX = Unit.Cm(0.0);
                    unitY = unitY.Add(Unit.Cm(2.5));
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
    }
}