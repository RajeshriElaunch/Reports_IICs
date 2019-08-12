namespace Reports_IICs.Reports.Portada
{
    using System;

    /// <summary>
    /// Summary description for Report_Portada.
    /// </summary>
    public partial class Report_Portada2 : Telerik.Reporting.Report
    {
        /// <summary>
        /// Portada para CCR, VOLGA y GAMAR
        /// </summary>
        /// <param name="NombreEmpresa"></param>
        /// <param name="Fecha"></param>
        public Report_Portada2(string NombreEmpresa, DateTime Fecha)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            this.txtB_Name.Value = NombreEmpresa;
            this.txtB_Fecha.Value= String.Format("{0:dd 'de' MMMM 'de' yyyy }", Fecha);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}