namespace Reports_IICs.Reports.Evolución.Evolución_Rentabilidad_Guissona
{
    using System;

    /// <summary>
    /// Summary description for ReportEvoluciónRentabilidadGuissona_SUB.
    /// </summary>
    public partial class ReportEvoluciónRentabilidadGuissona_SUB : Telerik.Reporting.Report
    {
        public ReportEvoluciónRentabilidadGuissona_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportEvoluciónRentabilidadGuissona_SUB(string isin, string codigoic, DateTime fecha)
        {
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            //this.ReportParameters["FechaInforme"].Value = fecha;
            this.ReportParameters["YearInforme"].Value = fecha.Year;

            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = isin;

            this.sqlDataSource2.Parameters[0].Value = codigoic;
            this.sqlDataSource2.Parameters[1].Value = isin;

            this.sqlDataSource3.Parameters[0].Value = codigoic;
            this.sqlDataSource3.Parameters[1].Value = isin;
        }

        private void table1_NeedDataSource(object sender, EventArgs e)
        {
            if(table1.DataSource==null)
             {
                textBox3.Value = "-";
             }
        }
    }
}