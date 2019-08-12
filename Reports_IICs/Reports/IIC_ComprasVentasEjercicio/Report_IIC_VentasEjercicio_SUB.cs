namespace Reports_IICs.Reports.IIC_ComprasVentasEjercicio
{
    using System;

    /// <summary>
    /// Summary description for Report_IIC_VentasEjercicio_SUB.
    /// </summary>
    public partial class Report_IIC_VentasEjercicio_SUB : Telerik.Reporting.Report
    {
        public Report_IIC_VentasEjercicio_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_IIC_VentasEjercicio_SUB(string isin, string codigoic, string tipoMov, DateTime FechaUltimoInforme)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.ReportParameters["TipoMovimiento"].Value = tipoMov;

            this.ReportParameters["UltimaFechaInforme"].Value = FechaUltimoInforme;

            
            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = isin;
            this.sqlDataSource1.Parameters[2].Value = tipoMov;
            this.sqlDataSource1.Parameters[3].Value = FechaUltimoInforme;
        }
    }
}