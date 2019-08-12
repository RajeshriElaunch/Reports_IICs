namespace Reports_IICs.Reports.Participes
{
    using DataModels;
    using System;
    using System.Linq;
    using Helpers;

    /// <summary>
    /// Summary description for Report_Participes.
    /// </summary>
    public partial class Report_Participes : Telerik.Reporting.Report
    {
        public Report_Participes()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public Report_Participes(Plantilla plantilla,string isin, string codigoic)
        {
            InitializeComponent();
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["CodigoIC"].Value = codigoic;
            //this.sqlDataSource1.Parameters[0].Value = codigoic;
            //this.sqlDataSource1.Parameters[1].Value = isin;

            string desc = "PARTICIPACIONES:";

            var selectedIsin = plantilla.Plantillas_Isins.Where(c => c.CodigoIc == codigoic && c.Isin == isin).FirstOrDefault();


            if(selectedIsin!=null)this.titleTextBox.Value = desc + " " + selectedIsin.Descripcion;

        }

        private void Report_Participes_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            Utils.CenterPanel(codigoIC, this.Report, this.panel3);
        }
    }
}