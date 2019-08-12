using Reports_IICs.Reports.SituacionPatrimonialRentabilidad;
using System;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class SituacionPatrimRent_VM
    {
        public static Report GetReport(string codigoIC, string isin, DateTime fecha, string descPlantilla, double days, string isinDesc)
        {
            Telerik.Reporting.Report rep = new ReportSituacionPatrimRentab(codigoIC, isinDesc, fecha, descPlantilla, days, isinDesc);

            rep.ReportParameters["NombrePlantilla"].Value = descPlantilla;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;            

            //rep.DataSource = Cartera_DA.GetTemp_GraficoIBenchmark(codigoIC, isin, fecha).ToList();
            return rep;
        }
    }
}
