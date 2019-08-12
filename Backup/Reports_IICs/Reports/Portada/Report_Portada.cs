namespace Reports_IICs.Reports.Portada
{
    using DataModels;
    using Helpers;
    using System;

    /// <summary>
    /// Summary description for Report_Portada.
    /// </summary>
    public partial class Report_Portada : Telerik.Reporting.Report
    {
        private string _codigoIC;
        public Report_Portada(Plantilla plantilla, DateTime Fecha)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            _codigoIC = plantilla.CodigoIc;
            this.txtB_Name.Value = plantilla.Descripcion;
            this.txtB_Fecha.Value= String.Format("{0:dd 'de' MMMM 'de' yyyy }", Fecha);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Report_Portada_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = _codigoIC;
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
        }
    }
}