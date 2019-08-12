namespace Reports_IICs.Reports.RfComprasVentasEjercicio
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_RfComprasVentasEjercicio.
    /// </summary>
    public partial class Report_RfComprasVentasEjercicio : Telerik.Reporting.Report
    {

        public Report_RfComprasVentasEjercicio()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();


            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public Report_RfComprasVentasEjercicio(DateTime? FechaAnterior)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //this.ReportParameters["FechaAnterior"].Value = FechaAnterior;
            //this.ReportParameters["CodigoIC"].Value = codigoic;
            //this.ReportParameters["TipoMovimiento"].Value = tipoMov;

            //this.sqlDataSource1.Parameters[0].Value = codigoic;
            //this.sqlDataSource1.Parameters[1].Value = isin;
            //this.sqlDataSource1.Parameters[2].Value = tipoMov;


            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Report_RfComprasVentasEjercicio_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}