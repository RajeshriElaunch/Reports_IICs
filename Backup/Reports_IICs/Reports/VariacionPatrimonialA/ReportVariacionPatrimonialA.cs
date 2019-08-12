namespace Reports_IICs.Reports.VariacionPatrimonialA
{
    using DesgloseGastos;
    using Helpers;
    using System;
    using VariacionPatrimonialB;

    /// <summary>
    /// Summary description for ReportVariacionPatrimonialA.
    /// </summary>
    public partial class ReportVariacionPatrimonialA : Telerik.Reporting.Report
    {
        private int _idSeccion;
        public ReportVariacionPatrimonialA()
        {
            //_idSeccion = idSeccion;
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            CargarSubReport();


            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Carga diferente subreport dependiendo del idSeccion
        /// </summary>
        private void CargarSubReport()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CodigoIC", "= Parameters.CodigoIC.Value"));

            //VARIACIÓN PATRIMONIAL A
            if (_idSeccion == 5)
            {
                var subrep = new SubReportRendimientos();                
                instanceReportSource1.ReportDocument = subrep;
                
            }
            //VARIACIÓN PATRIMONIAL B (DESGLOSE GASTOS RESUMIDO)
            else if (_idSeccion == 46)
            {
                var subrep = new SubReportVariacionPatrimonialB();
                instanceReportSource1.ReportDocument = subrep;
            }

            this.subReport1.ReportSource = instanceReportSource1;
        }

        private void ReportVariacionPatrimonialA_ItemDataBinding(object sender, EventArgs e)
        {            
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel2);
            //Utils.centerPanel(codigoIC, this.Report, this.panel3);
            Utils.CenterPanel(codigoIC, this.Report, this.panel4);
            //Utils.CenterPanel(codigoIC, this.Report, this.panel5);
            Utils.CenterPanel(codigoIC, this.Report, this.panel6);
            //Utils.centerPanel(codigoIC, this.Report, this.panel7);
            Utils.CenterPanel(codigoIC, this.Report, this.panel8);

            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            //string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            _idSeccion = Convert.ToInt32(this.ReportParameters["IdSeccion"].Value);
            var instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource1.ReportDocument = new ReportDesgloseGastos_SUB(codigoIC, _idSeccion);            
            this.subReport2.ReportSource = instanceReportSource1;

            //Cargamos el subreport superior dinámicamente
            CargarSubReport();

            //this.subReport2.Width = detail.wid
        }
    }
}