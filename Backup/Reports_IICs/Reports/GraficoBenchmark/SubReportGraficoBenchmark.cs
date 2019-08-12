namespace Reports_IICs.Reports.GraficoBenchmark
{
    using DataAccess.Secciones;
    using System;
    using Telerik.Reporting;
    using System.Linq;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class SubReportGraficoBenchmark : Telerik.Reporting.Report
    {
        public SubReportGraficoBenchmark()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            

        }

        public SubReportGraficoBenchmark(string codigoIC, string isin, string isinDesc, double days)
        {
            InitializeComponent();
            //Telerik.Reporting.Processing.Report processingReport = (Telerik.Reporting.Processing.Report)sender;
            //object processingParameterValue = processingReport.Parameters["CodigoIC"].Value;

            //Telerik.Reporting.Processing.Report processingReport = (Telerik.Reporting.Processing.Report)sender;

            //this.ReportParameters["CodigoIC"].Value = codigoIC;
            //sqlDataSourceGraph.Parameters["@CodigoIC"].Value = codigoIC;

            #region estilos > 5000 líneas
            //con más de 5000 hay que graphAxis4.MajorGridLineStyle.Visible = false porque si no no lo pinta
            //string codigoIC = processingReport.Parameters["CodigoIC"].Value.ToString();
            //string isinDesc = processingReport.Parameters["IsinDesc"].Value.ToString();
            //double days = Convert.ToDouble(processingReport.Parameters["CodigoIC"].Value);

            /*if (isinDesc != null) this.textBoxISIN.Value = isinDesc;*/

            var numIndices = GraficoIBenchmark_DA.GetTemp(codigoIC).GroupBy(g => new
            {
                g.Isin
            }).Select(s => new
            {
                Cont = s.Count()
            });

            var max = numIndices.Max(m => m.Cont);

            if (max > 5000)
            {
                graphAxis4.MajorGridLineStyle.Visible = false;
            }
            #endregion

            #region Correct SCALE Fecha
            DateTimeScale escalaFecha = new DateTimeScale();

            if (days <= 365) //One Year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 1;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 365 && days <= 730) //two year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 3;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 730 && days <= 1095) // three year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 3;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 1095 && days <= 1460) // four year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 3;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 1460 && days <= 1825) // five year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 3;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 1825 && days <= 2190) // six year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 6;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 2190 && days <= 2555) // seven year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 6;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 2555 && days <= 2920) // 8 years
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 6;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }
            if (days > 2920 && days <= 3285) // 9 years
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 6;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }
            if (days > 3285 && days <= 3650) // 10 years
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 6;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }

            if (days > 3650) // +10 years
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 1;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Years;
            }

            escalaFecha.MajorUnit = DateTimeScaleUnits.Auto;
            if (days > 3650)
            {
                escalaFecha.MinorUnit = DateTimeScaleUnits.Years;
            }
            else
            {
                escalaFecha.MinorUnit = DateTimeScaleUnits.Months;
            }

            graphAxis4.Scale = escalaFecha;
            //graphAxis4.MajorTickMarkDisplayType = GraphAxisTickMarkDisplayType.None;
            //graphAxis4.MinorTickMarkDisplayType = GraphAxisTickMarkDisplayType.Outside;

            //graphAxis4.MajorGridLineStyle.Visible = false;

            #endregion
        }

        private void SubReportGraficoBenchmark_NeedDataSource(object sender, EventArgs e)
        {
            //Telerik.Reporting.Processing.Report processingReport = (Telerik.Reporting.Processing.Report)sender;
            //object processingParameterValue = processingReport.Parameters["parameter1"].Value;
            //processingReport.DataSource = GetData(processingParameterValue);
        }

        private void SubReportGraficoBenchmark_ItemDataBinding(object sender, EventArgs e)
        {
            //Telerik.Reporting.Processing.Report processingReport = (Telerik.Reporting.Processing.Report)sender;
            //string processingParameterValue = processingReport.Parameters["CodigoIC"].Value.ToString();
            //sqlDataSourceGraph.Parameters["@CodigoIC"].Value = processingParameterValue;


            //processingReport.DataSource = sqlDataSourceGraph
            //processingReport.DataSource = GetData(processingParameterValue);
        }
    }
}