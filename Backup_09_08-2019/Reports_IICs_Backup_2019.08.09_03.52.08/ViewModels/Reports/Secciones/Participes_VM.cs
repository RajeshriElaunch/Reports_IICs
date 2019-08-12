using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Reports.Participes;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class Participes_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp, Seccione seccion)
        {
            //List<Temp_Participes> listaTmp = new List<Temp_Participes>();
            try
            {
                foreach (var isin in plantilla.Plantillas_Isins)
                {
                    foreach (var dni in plantilla.Plantillas_Participes.Select(p => p.Identificador))
                    {
                        //var pro01 = Reports_DA.GetPRO01(plantilla.CodigoIc, isin, dni, fecha).FirstOrDefault();

                        var pro = Reports_DA.GetPRO01(plantilla.CodigoIc, !string.IsNullOrEmpty(isin.Isin) ? isin.Isin : string.Empty, dni, null, null, fecha);
                        //var pro = Reports_DA.GetPRO01(plantilla.CodigoIc, string.Empty, dni, null, null, fecha);
                        foreach (var item in pro)
                        {
                            //Temp_Participes tmp = getNuevoTemp_Participes(plantilla.CodigoIc, isin.Isin, dni, item.nom, item.participaciones, item.tpc);
                            Temp_Participes tmp = getNuevoTemp_Participes(plantilla.CodigoIc, null, dni, item.nom, item.participaciones, item.tpc);
                            listaTmp.Add(tmp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Participes_DA.Insert_Temp(plantilla, listaTmp); 
            //Temp_Table_Manager<Temp_Participes> ttm = new Temp_Table_Manager<Temp_Participes>();
            //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
        }

        private static Temp_Participes getNuevoTemp_Participes(string codigoIC, string isin, string dni, string nombreApellidos, decimal numeroParticipaciones, decimal? porcentajeParticipacion)
        {
            Temp_Participes tmp = new Temp_Participes();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.DNI = dni;
            tmp.NombreApellidos = nombreApellidos;
            tmp.NumeroParticipaciones = numeroParticipaciones/100;
            if (porcentajeParticipacion != null)
            {
                tmp.PorcentajeParticipacion = porcentajeParticipacion/100;
            }

            return tmp;
        } 

        public static Report GetReportParticipes(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new Report_Participes(plantilla, isin, codigoIC);            
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;            
            return rep;
        }
    }
}
