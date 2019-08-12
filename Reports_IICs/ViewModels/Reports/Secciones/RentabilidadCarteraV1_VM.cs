using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Rentabilidad_Cartera;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RentabilidadCarteraV1_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_RentabilidadCarteraV1> listaTmp = new List<Temp_RentabilidadCarteraV1>();

                foreach (var isin in plantilla.Plantillas_Isins)
                {
                    List<DateTime> fechas = getFechasRentabilidad(plantilla.FechaCreacion, Convert.ToDateTime(fechaInforme));

                    decimal? valorLiqAnterior = null;
                    foreach (var fecha in fechas)
                    {

                        //Pasamos como isin el indice
                        var pro02Result = Reports_DA.GetPRO02(plantilla.CodigoIc, isin.Isin, fecha).FirstOrDefault();
                        if (pro02Result != null)
                        {
                            Temp_RentabilidadCarteraV1 tmp = new Temp_RentabilidadCarteraV1();
                            tmp.CodigoIC = plantilla.CodigoIc;
                            tmp.Isin = isin.Isin;
                            tmp.DescripcionIsin = isin.Descripcion;
                            tmp.ValorLiquidativo = pro02Result.valliq;
                            tmp.Fecha = fecha;
                            if (valorLiqAnterior != null)
                            {
                                var variacion = Utils.GetVariacion(valorLiqAnterior, pro02Result.valliq);
                                tmp.RentabilidadPeriodo = decimal.Round(Convert.ToDecimal(variacion), 1);
                            }

                            listaTmp.Add(tmp);

                            //Almacenamos el valliq para calcular la variación con el siguiente elemento de la iteración
                            valorLiqAnterior = pro02Result.valliq;
                        }
                    }
                }


                //RentabilidadCarteraV1_DA.Insert_Temp_RentabilidadCarteraV1(plantilla.CodigoIc, lista);
                //Temp_Table_Manager<Temp_RentabilidadCarteraV1> ttm = new Temp_Table_Manager<Temp_RentabilidadCarteraV1>();
                //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<DateTime> getFechasRentabilidad(DateTime fechaCreacion, DateTime fechaInforme)
        {
            List<DateTime> fechas = new List<DateTime>();

            int year = fechaCreacion.Year;
            while (year < fechaInforme.Year)
            {
                fechas.Add(new DateTime(year, 12, 31));
                year++;
            }

            //Para el caso que coincida que la fecha de creación es 31/12
            bool tieneFechaCreacion = fechas.Where(f => f.Date == fechaCreacion).Count() > 0 ? true : false;
            if (!tieneFechaCreacion)
            {
                fechas.Add(fechaCreacion);
            }

            int month = fechaInforme.Month - 1;

            while (month > 0)
            {
                //Insertamos el último día del mes anterior para los meses del año de fecha informe
                DateTime lastDayMonth = new DateTime(fechaInforme.Year, month, DateTime.DaysInMonth(fechaInforme.Year, month));
                fechas.Add(lastDayMonth);
                month--;
            }

            fechas.Add(fechaInforme);

            //Devolvemos las fechas ordenadas
            var list = fechas.OrderBy(f => f.Date).ToList();

            return list;
        }

        public static IQueryable<string> GetDistinctIndices(string codigoIC)
        {
            return RentabilidadCarteraV1_DA.GetDistinctIndices(codigoIC);
        }

        public static Report GetReportRentabilidadCarteraV1(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportRentabilidadCarteraV1(isin, codigoIC, fecha);
            //rep.DataSource = Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            // var hasvalues= Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["FechaInforme"].Value = fecha;
            return rep;
        }

    }
}
