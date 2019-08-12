using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Valor_Liquidativo;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionPatrimValorLiq_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //Tenemos que hacer dos llamadas al procedimiento. Una con fecha inicio y otra con fecha fin
                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fecha), typeof(Temp_EvolucionPatrValLiq));
                DateTime fechaFin = Convert.ToDateTime(fecha);
                //List<Temp_EvolucionPatrValLiq> listaTmp = new List<Temp_EvolucionPatrValLiq>();

                //Parece que aquí no lo necesitamos porque el patrimonio nos viene del procedimiento
                //foreach (var isin in Utils.GetPlantillasIsinsClases(plantilla, seccion))
                foreach (var isin in plantilla.Plantillas_Isins)
                {
                    var pro02Fini = Reports_DA.GetPRO02(plantilla.CodigoIc, isin.Isin, fechaInicio).FirstOrDefault();

                    var pro02Ffin = Reports_DA.GetPRO02(plantilla.CodigoIc, isin.Isin, fechaFin).FirstOrDefault();
                    if (pro02Fini != null && pro02Ffin != null)
                    {
                        Temp_EvolucionPatrValLiq pro02tempIni = getNuevoTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin.Isin, fechaInicio, pro02Fini.patrimonio, pro02Fini.valliq);
                        Temp_EvolucionPatrValLiq pro02tempFfin = getNuevoTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin.Isin, fechaFin, pro02Ffin.patrimonio, pro02Ffin.valliq);

                        listaTmp.Add(pro02tempIni);
                        listaTmp.Add(pro02tempFfin);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_EvolucionPatrValLiq getNuevoTemp_EvolucionPatrValLiq(string codigoIC, string isin, DateTime fecha, decimal? patrimonioGestionado, decimal? valorLiquidativo)
        {
            Temp_EvolucionPatrValLiq pro02temp = new Temp_EvolucionPatrValLiq();

            pro02temp.CodigoIc = codigoIC;
            pro02temp.Isin = isin;
            pro02temp.Fecha = fecha;
            decimal patrimonioGestionadoRounded = decimal.Round(Convert.ToDecimal(patrimonioGestionado), 0);
            pro02temp.PatrimonioGestionado = patrimonioGestionadoRounded;
            pro02temp.ValorLiquidativo = valorLiquidativo;

            return pro02temp;
        }

        public static double? GetTAE(string codigoIC, DateTime fechaInforme, DateTime fechaInicio)
        {
            double? valLiqFechaInf = EvolucionPatrimValorLiq_DA.GetValorLiqFechaInforme(codigoIC, fechaInforme);
            double dias = fechaInforme.Subtract(fechaInicio).Days;

            if (valLiqFechaInf != null)
            {
                double tae = Convert.ToDouble(valLiqFechaInf) / 6.01;
                double exp = (365 / dias);
                tae = Math.Pow(tae, exp) - 1;

                return tae;
            }
            else
                return null;
        }

        public static Report GetReportEvolucionPatrimonioValorLiquidativo(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportPatrimonio_ValorLiquidativoPRO_02(codigoIC, isin);
            //Telerik.Reporting.Report rep = new ReportEvolPatrValLiq(codigoIC, isin);
            //rep.DataSource = Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            // var hasvalues= Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            return rep;
        }

    }
}
