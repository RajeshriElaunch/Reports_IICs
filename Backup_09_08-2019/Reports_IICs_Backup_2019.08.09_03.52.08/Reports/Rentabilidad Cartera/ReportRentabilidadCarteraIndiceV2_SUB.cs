namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    using System;

    /// <summary>
    /// Summary description for ReportRentabilidadCarteraIndiceV2_SUB.
    /// </summary>
    public partial class ReportRentabilidadCarteraIndiceV2_SUB : Telerik.Reporting.Report
    {
        public ReportRentabilidadCarteraIndiceV2_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportRentabilidadCarteraIndiceV2_SUB(string isin, string codigoic, DateTime fecha)
        {
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["FechaInforme"].Value = fecha;
            this.ReportParameters["Esindice"].Value = 1;
        }
    }
}