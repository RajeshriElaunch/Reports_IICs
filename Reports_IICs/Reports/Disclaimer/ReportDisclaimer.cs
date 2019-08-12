namespace Reports_IICs.Reports.Disclaimer
{
    using DataAccess.Plantillas;
    using System.Drawing;

    /// <summary>
    /// Summary description for ReportDisclaimer.
    /// </summary>
    public partial class ReportDisclaimer : Telerik.Reporting.Report
    {
        public ReportDisclaimer(string codigoIC)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            var plantilla = Plantillas_DA.GetPlantilla(codigoIC);

            if(plantilla != null)
            {                
                this.pictureBoxPerfilRiesgo.Value = Image.FromFile(@"Images\Indicador perfil riesgo_" + plantilla.PerfilRiesgo.ToString() + ".png");
            }
        }
    }
}