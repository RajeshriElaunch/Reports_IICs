namespace Reports_IICs.Reports.Cartera
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using ViewModels.Reports.Secciones;

    /// <summary>
    /// Summary description for Report_Cartera.
    /// </summary>
    public partial class Report_Cartera : Telerik.Reporting.Report
    {
        public Report_Cartera()
        {
            InitializeComponent();
        }
        public Report_Cartera(string codigoIc, DateTime fecha, Plantilla plantilla)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //string desc = (plantilla.Plantillas_Generaciones_Plantilla.FirstOrDefault()).Descripcion;
            string desc = "CARTERA";
            this.titleTextBox.Value = desc + " a " + fecha.ToShortDateString();

            //List<Plantillas_Isins> listaIsins = Plantillas_DA.GetIsinsByIdPlantilla(codigoIc);
            List<Report> detailReports = new List<Report>();

            //Plantilla plan = Plantillas_DA.GetPlantilla(plantilla.CodigoIc);

            foreach (var isin in plantilla.Plantillas_Isins)
            {
                Report rep = Cartera_VM.GetReportPro12(plantilla, isin.Isin, isin.Descripcion, fecha);
                //if (((System.Collections.Generic.List<Reports_IICs.DataModels.Temp_PRO_12>)rep.DataSource).Count > 0)
                //if(plantilla.Plantillas_Isins.Count > 1)
                //{
                //    rep.ReportParameters["IsinDesc"].Value = isin.Descripcion;
                    detailReports.Add(rep);
                //}
                //else
                //{
                //    rep.ReportParameters["IsinDesc"].Value = string.Empty;
                //}
            }

            if (detailReports.Count > 0)
            {
                var instanceReportSource = new Telerik.Reporting.InstanceReportSource();                
                Report report = GetCombinedReport(detailReports);
                instanceReportSource.ReportDocument = report;
                //this.subReport_PRO_12.ReportSource = report;
                this.subReport_PRO_12.ReportSource = instanceReportSource;
            }
            else
            {
                this.subReport_PRO_12.Visible = false;
            }
        }

        private static Report GetCombinedReport(List<Report> detailReports)
        {
            Report report = new Report();
            DetailSection detail = new DetailSection();
            report.Items.Add(detail);

            Unit unitX = Unit.Cm(0.7);
            Unit unitY = Unit.Cm(0.1);
            SizeU size = new SizeU(Unit.Cm(1), Unit.Cm(0.1));
            //sólo nos caben 3 por línea. Después de 3 pasamos a la siguiente línea
            int añadidos = 0;
            foreach (Report detailReport in detailReports)
            {
                SubReport subReport;
                
                subReport = new SubReport();
                if (añadidos > 0 && añadidos % 3 == 0)
                {
                    unitX = Unit.Cm(0.7);
                    unitY = unitY.Add(Unit.Cm(2.5));
                }
                subReport.Location = new PointU(unitX, unitY);
                subReport.Size = size;
                //unitY = unitY.Add(Unit.Inch(1));
                
                    unitX = unitX.Add(Unit.Cm(5));

                var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument = detailReport;
                //subReport.ReportSource = detailReport;
                subReport.ReportSource = instanceReportSource;

                detail.Items.Add(subReport);
                añadidos++;
            }
            //detail.Height = Unit.Inch(detailReports.Count + 1);
            return report;
        }
    }
}