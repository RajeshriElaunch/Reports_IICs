namespace Reports_IICs.Reports.GraficoBenchmark
{
    using DataAccess.Secciones;
    using System;
    using Telerik.Reporting;
    using System.Linq;

    /// <summary>
    /// Summary description for SubReportGraficoBenchmark.
    /// </summary>
    public partial class Old_SubReportGraficoBenchmark : Telerik.Reporting.Report
    {
        public Old_SubReportGraficoBenchmark()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            #region estilos > 5000 líneas
            //con más de 5000 hay que graphAxis4.MajorGridLineStyle.Visible = false porque si no no lo pinta
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            string isinDesc = this.ReportParameters["IsinDesc"].Value.ToString();
            double days = Convert.ToDouble(this.ReportParameters["CodigoIC"].Value);

            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;

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

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }
    }
}