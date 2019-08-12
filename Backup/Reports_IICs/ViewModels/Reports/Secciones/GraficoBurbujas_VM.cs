using Reports_IICs.DataModels;
using Reports_IICs.Reports.Gráficos_Burbujas;
using System;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    class GraficoBurbujas_VM
    {

        public static Report GetReportGraficosBurbujas(Plantilla plantilla, string isin, string isinDesc, DateTime fecha,double? MinEjeX,double? MinEjeY, double? MaxEjeY, double? StepX, double? StepY)
        {
            Telerik.Reporting.Report rep = new ReportGráficosBurbujas(isin, isinDesc, plantilla.CodigoIc, MinEjeX, MinEjeY, MaxEjeY,StepX, StepY); 
            if (isin != null) rep.ReportParameters["Isin"].Value = isin;
            if (plantilla.CodigoIc != null) rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            return rep;
        }

        public static Report GetReportGráficosBurbujasVALUE_GROWTH(Plantilla plantilla, string isin, string isinDesc, DateTime fecha, double? MinEjeX, double? MinEjeY, double? MaxEjeY, double? StepX, double? StepY)
        {
            Telerik.Reporting.Report rep = new ReportGráficosBurbujasVALUE_GROWTH(isin, isinDesc, plantilla.CodigoIc, MinEjeX, MinEjeY, MaxEjeY, StepX, StepY);
            if (isin != null) rep.ReportParameters["Isin"].Value = isin;
            if (plantilla.CodigoIc != null) rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            return rep;
        }

        public static Report GetReportGráficosBurbujasUTA(Plantilla plantilla, string isin, string isinDesc, DateTime fecha, double? MinEjeX, double? MinEjeY, double? MaxEjeY, double? StepX, double? StepY)
        {
            Telerik.Reporting.Report rep = new ReportGráficosBurbujasUTA(isin, isinDesc, plantilla.CodigoIc, MinEjeX, MinEjeY, MaxEjeY, StepX, StepY);
            //if (isin != null)
                rep.ReportParameters["Isin"].Value = isin;
            //if (plantilla.CodigoIc != null)
                rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            return rep;
        }

    }
}
