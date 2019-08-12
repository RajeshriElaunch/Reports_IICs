using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Subscripciones_Reembolsos;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class SuscripcionesReembolsos_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                DateTime fechaHasta = fechaInforme;
                DateTime fechaDesde = Utils.GetFechaInicio(plantilla, fechaInforme);

                //List<Temp_SuscripcionesReembolsos> listaTmp = new List<Temp_SuscripcionesReembolsos>();
                //List<Temp_SuscripcionesReembolsos> listaTmp = new List<Temp_SuscripcionesReembolsos>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                var isin = plantilla.Plantillas_Isins.FirstOrDefault();
                if (isin != null)
                {
                    var pro = Reports_DA.GetPRO07(plantilla.CodigoIc, isin.Isin, fechaDesde, fechaHasta).ToList();
                    foreach (var item in pro)
                    {
                        var tmp = getNuevoTemp_SuscripcionesReembolsos(plantilla.CodigoIc, isin.Isin, item);

                        //listaSuscripcionesReembolsos.Add(tmp);
                        listaTmp.Add(tmp);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private static Temp_SuscripcionesReembolsos getNuevoTemp_SuscripcionesReembolsos(string codigoIC, string isin, DateTime? fecha, string tipoMov, decimal? importe)
        private static Temp_SuscripcionesReembolsos getNuevoTemp_SuscripcionesReembolsos(string codigoIC, string isin, usp_gestio_pro_07_Result item)
        {
            Temp_SuscripcionesReembolsos tmp = new Temp_SuscripcionesReembolsos();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.Fecha = item.FECHA;
            string tipMov = item.TIPMOV;
            //Mostraremos los dos casos con el texto REINTEGRO
            if(tipMov.Equals("REEMBOLSO") || tipMov.Equals("TRASPASO"))
            {
                tipMov = Resources.Resource.SuscripcionesReembolsosVM_Reintegro;
            }
            tmp.TipoMovimiento = tipMov;
            tmp.Importe = item.IMPORTE;

            return tmp;
        }
        
        public static Report GetReportSubscripcionesReembolsos(string codigoIC, string isin, DateTime fechainforme)
        {
            Report rep = new ReportSubscripcionesReembolsos(codigoIC, isin);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["TipoMovimiento"].Value = null;
            rep.ReportParameters["FechaInforme"].Value = fechainforme;
            return rep;
        }


    }
}
