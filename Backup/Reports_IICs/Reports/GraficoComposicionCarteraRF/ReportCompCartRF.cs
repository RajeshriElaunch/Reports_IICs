namespace Reports_IICs.Reports.GraficoComposicionCarteraRF
{
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for ReportCompCartRF.
    /// </summary>
    public partial class ReportCompCartRF : Telerik.Reporting.Report
    {
        public ReportCompCartRF()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportCompCartRF(string isin, string isinDesc, string codigoic)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            /*
            this.sqlDataSource1.Parameters[0].Value = isin;
            this.sqlDataSource1.Parameters[1].Value = codigoic;

            this.sqlDataSourceSector.Parameters[0].Value = isin;
            this.sqlDataSourceSector.Parameters[1].Value = codigoic;
            */
            //this.sqlDataSourceGeo.Parameters[0].Value = isin;
            //this.sqlDataSourceGeo.Parameters[1].Value = codigoic;


            /*
            // Set the SqlDataSource component as it's DataSource
            this.RFGroupbyDivisa.DataSource = sqlDataSource1;
            //this.RFGroupbyPais.DataSource = sqlDataSourceGeo;
            //this.RFGroupbyPais.DataSource = sqlDataSourceRatings;
            this.RFGroupbySector.DataSource = sqlDataSourceSector;
            */

            this.sqlDataSource1.Parameters[0].Value = isin;
            this.sqlDataSource1.Parameters[1].Value = codigoic;
            this.RFGroupbyDivisa.DataSource = sqlDataSource1;

            this.sqlDataSourceSector.Parameters[0].Value = isin;
            this.sqlDataSourceSector.Parameters[1].Value = codigoic;
            this.RFGroupbySector.DataSource = sqlDataSourceSector;

            loadTexts();

        }

        private void loadTexts()
        {
            this.TituloReport.Value = Resources.Resource.TituloReportCompCartRF;
        }

        private void ReportCompCartRF_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}