namespace Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Conjunto_Guissona
{
    using System;

    /// <summary>
    /// Summary description for ReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB.
    /// </summary>
    public partial class ReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB : Telerik.Reporting.Report
    {
        public ReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB(string isin, string codigoic, DateTime fecha)
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