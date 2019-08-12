namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    using System;

    /// <summary>
    /// Summary description for ReportRentabilidadCarteraV2_SUB.
    /// </summary>
    public partial class ReportRentabilidadCarteraV2_SUB : Telerik.Reporting.Report
    {
        public ReportRentabilidadCarteraV2_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportRentabilidadCarteraV2_SUB(string isin, string codigoic,DateTime fecha)
        {
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["FechaInforme"].Value = fecha;
        }

    }
}