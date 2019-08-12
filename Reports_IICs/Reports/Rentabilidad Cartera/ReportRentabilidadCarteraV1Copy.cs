namespace Reports_IICs.Reports.Rentabilidad_Cartera
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportRentabilidadCarteraV1.
    /// </summary>
    public partial class ReportRentabilidadCarteraV1Copy : Telerik.Reporting.Report
    {
        private string _codigoIC;
        public ReportRentabilidadCarteraV1Copy()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportRentabilidadCarteraV1Copy(string isin, string codigoic, DateTime fecha)
        {
            InitializeComponent();            

            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            this.sqlDataSource1.Parameters[0].Value = codigoic;
            this.sqlDataSource1.Parameters[1].Value = isin;
            if (fecha== null)
            {
                this.sqlDataSource3.Parameters[0].Value = codigoic;
                this.sqlDataSource3.Parameters[1].Value = isin;
                this.sqlDataSource3.Parameters[2].Value = DateTime.Now;
                this.ReportParameters["FechaInforme"].Value = DateTime.Now;
            }
            else
            {
                this.sqlDataSource3.Parameters[0].Value = codigoic;
                this.sqlDataSource3.Parameters[1].Value = isin;
                this.sqlDataSource3.Parameters[2].Value = fecha;
                this.ReportParameters["FechaInforme"].Value = fecha;
            }
        }        

        private void ReportRentabilidadCarteraV1_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);            
        }
    }

   
}