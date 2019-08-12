namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Conjunto_Guissona
{
    using System;

    /// <summary>
    /// Summary description for ReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB.
    /// </summary>
    public partial class ReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB : Telerik.Reporting.Report
    {
        public ReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB(string isin, string codigoic, DateTime fecha)
        {
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            //this.ReportParameters["FechaInforme"].Value = fecha;
            this.ReportParameters["YearInforme"].Value = fecha.Year;

            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = isin;

        }

    }
}