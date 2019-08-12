namespace Reports_IICs.Reports.GraficoComposicionCartera
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCompCartRV.
    /// </summary>
    public partial class ReportCompCartRV : Telerik.Reporting.Report
    {
        public ReportCompCartRV()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
        }
        public ReportCompCartRV(string isin, string isinDesc, string codigoic)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //this.textBoxISIN.Value =  isinDesc;
            /*this.DataSource = null;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            
            this.sqlDataSourceRvGroupbyDivisa.Parameters[0].Value = isin;
            this.sqlDataSourceRvGroupbyDivisa.Parameters[1].Value = codigoic;

            this.sqlDataSourceRvGroupbyEmpresa.Parameters[0].Value = isin;
            this.sqlDataSourceRvGroupbyEmpresa.Parameters[1].Value = codigoic;

            this.sqlDataSourceRvGroupbyPais.Parameters[0].Value = isin;
            this.sqlDataSourceRvGroupbyPais.Parameters[1].Value = codigoic;

            this.sqlDataSourceRvGroupbySector.Parameters[0].Value = isin;
            this.sqlDataSourceRvGroupbySector.Parameters[1].Value = codigoic;

            // Set the SqlDataSource component as it's DataSource
            this.RvGroupbyDivisa.DataSource = sqlDataSourceRvGroupbyDivisa;
            
            this.RvGroupbyEmpresa.DataSource = sqlDataSourceRvGroupbyEmpresa;
            this.RvGroupbyPais.DataSource = sqlDataSourceRvGroupbyPais;
            this.RvGroupbySector2.DataSource = sqlDataSourceRvGroupbySector;
            */
            loadTexts();

            
        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportCompCartRV;
        }

        private void ReportCompCartRV_NeedDataSource(object sender, EventArgs e)
        {
            //Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            //this.sqlDataSourceRvGroupbyDivisa.Parameters[0].Value = report.Parameters["Isin"].Value;
            //this.sqlDataSourceRvGroupbyDivisa.Parameters[1].Value = report.Parameters["CodigoIC"].Value;

            //this.sqlDataSourceRvGroupbyEmpresa.Parameters[0].Value = report.Parameters["Isin"].Value;
            //this.sqlDataSourceRvGroupbyEmpresa.Parameters[1].Value = report.Parameters["CodigoIC"].Value;

            //this.sqlDataSourceRvGroupbyPais.Parameters[0].Value = report.Parameters["Isin"].Value;
            //this.sqlDataSourceRvGroupbyPais.Parameters[1].Value = report.Parameters["CodigoIC"].Value;

            //this.sqlDataSourceRvGroupbySector.Parameters[0].Value = report.Parameters["Isin"].Value;
            //this.sqlDataSourceRvGroupbySector.Parameters[1].Value = report.Parameters["CodigoIC"].Value;

            //// Set the SqlDataSource component as it's DataSource
            //this.RvGroupbyDivisa.DataSource = sqlDataSourceRvGroupbyDivisa;
            //this.RvGroupbyEmpresa.DataSource = sqlDataSourceRvGroupbyEmpresa;
            //this.RvGroupbyPais.DataSource = sqlDataSourceRvGroupbyPais;
            //this.RvGroupbySector2.DataSource = sqlDataSourceRvGroupbySector;

        }

        private void ReportCompCartRV_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}