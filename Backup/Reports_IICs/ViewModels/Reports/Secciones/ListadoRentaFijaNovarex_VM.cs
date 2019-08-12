using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.ListadoRentaFijaNovarex;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class ListadoRentaFijaNovarex_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var pro = VariablesGlobales.Pro11_Local.Where(p => p.tipo.Equals("RF")).ToList();

                var valact = pro.Sum(s => s.valact);
                foreach (var item in pro)
                {
                    var tmp = getNuevoTemp_ListadoRentaFijaNovarex(plantilla.CodigoIc, item.descr, item.datvto, item.efeact, item.valact);
                    listaTmp.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_ListadoRentaFijaNovarex getNuevoTemp_ListadoRentaFijaNovarex(string codigoIC, string tituloDesc, DateTime? amortizacion,  decimal efectivo, decimal tir)
        {
            var tmp = new Temp_ListadoRentaFijaNovarex();
            tmp.CodigoIC = codigoIC;
            tmp.TituloDescripcion = tituloDesc;
            tmp.Amortizacion = amortizacion;
            tmp.EfectivoEuros = efectivo;
            tmp.TIR = tir;

            return tmp;
        }

 public static Report GetReportListadoRentaFijaNovarex(string codigoIC,DateTime fecha)
        {
            Telerik.Reporting.Report rep = new Report_ListadoRentaFijaNovarex(codigoIC,fecha);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;

            return rep;
        }
    }
}
