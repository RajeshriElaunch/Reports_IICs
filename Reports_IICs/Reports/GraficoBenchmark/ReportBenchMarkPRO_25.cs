namespace Reports_IICs.Reports.GraficoBenchmark
{
    using DataAccess.Secciones;
    using System;
    using Telerik.Reporting;
    using System.Linq;
    using Helpers;

    /// <summary>
    /// Summary description for ReportBenchMarkPRO_25.
    /// </summary>
    public partial class ReportBenchMarkPRO_25 : Telerik.Reporting.Report
    {
        public ReportBenchMarkPRO_25()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportBenchMarkPRO_25(string codigoic, string isin, string isinDesc, double days)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //if (isin != null) this.textBoxISIN.Value = "ISIN: " + isin;
            if (isinDesc != null) this.textBoxISIN.Value = isinDesc;
            //this.textBoxISIN.CanGrow
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            #region estilos > 5000 líneas
            //con más de 5000 hay que graphAxis4.MajorGridLineStyle.Visible = false porque si no no lo pinta
            var numIndices = GraficoIBenchmark_DA.GetTemp(codigoic).GroupBy(g => new
            {
                g.Isin
            }).Select(s => new 
            {
                Cont = s.Count()
            });

            var max = numIndices.Max(m => m.Cont);

            if(max > 5000)
            {
                graphAxis4.MajorGridLineStyle.Visible = false;
            }
            #endregion

            #region Correct SCALE Fecha
            DateTimeScale escalaFecha = new DateTimeScale();

            if(days<=365) //One Year
            {
                escalaFecha.BaseUnit = DateTimeScaleUnits.Days;
                escalaFecha.LabelStep = 1;
                escalaFecha.LabelUnit = DateTimeScaleUnits.Months;
            }
            
            if(days>365 && days <=730) //two year
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

            if (days > 3650 ) // +10 years
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

        private void ReportBenchMarkPRO_25_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}