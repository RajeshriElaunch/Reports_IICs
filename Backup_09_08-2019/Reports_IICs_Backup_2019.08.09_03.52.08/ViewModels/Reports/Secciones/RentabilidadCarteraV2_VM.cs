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
    public static class RentabilidadCarteraV2_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_RentabilidadCarteraV2> listaTmp = new List<Temp_RentabilidadCarteraV2>();
                
                var ParamRv2 = RentabilidadCarteraV2_DA.GetParametroPlantillaRentabilidadCarteraII(plantilla.CodigoIc);
                DateTime? fechainicio = plantilla.FechaCreacion;

                if(ParamRv2!=null)
                {
                    if(ParamRv2.FechaInicio!=null)
                    {
                        fechainicio = ParamRv2.FechaInicio;
                    }
                    
                }

                List<DateTime> fechas = getFechasRentabilidad(fechainicio.Value, Convert.ToDateTime(fechaInforme));

                //Una tabla para cada isin
                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    decimal? valorLiqAnterior = null;
                    bool backgroundColor = false;
                    foreach (var fecha in fechas)
                    {
                        Temp_RentabilidadCarteraV2 tmp = getTemp_RentabilidadCarteraV2Item(plantilla.CodigoIc, string.Empty, string.Empty, ref valorLiqAnterior, false, fecha, backgroundColor);

                        if (tmp != null)
                        {
                            listaTmp.Add(tmp);
                            backgroundColor = !backgroundColor;
                        }
                    }
                //}

                //08/05/2017 - Antes se hacía una tabla por cada índice, ahora dicen que es una por cada isin
                //foreach (var indice in plantilla.Plantillas_Indices_Referencia.Where(w => w.IdTipoIndiceReferencia.Equals(2)))
                //foreach (var indice in plantilla.Plantillas_Isins)
                //{
                    valorLiqAnterior = null;

                    backgroundColor = false;
                    foreach (var fecha in fechas)
                    {
                        //Temp_RentabilidadCarteraV2 tmp = getTemp_RentabilidadCarteraV2Item(codIc, indice.Codigo, indice.DescripcionCodigo, ref valorLiqAnterior, true, fecha, backgroundColor);
                        Temp_RentabilidadCarteraV2 tmp = getTemp_RentabilidadCarteraV2Item(plantilla.CodigoIc, "","", ref valorLiqAnterior, true, fecha, backgroundColor);

                        if (tmp != null)
                        {
                            listaTmp.Add(tmp);
                            backgroundColor = !backgroundColor;
                        }
                    }
                /*
                 * Ens falta calcular la rentabilidad acumulada del dia que calculem el report
                 */
                List<TempTableBase> listaTmpAux = new List<TempTableBase>();
                IndicePreconfiguradoNovarex_VM.Insert_Temp(plantilla, fechaInforme, ref listaTmpAux);

                //List<TempTableBase> listaTmpAux = new List<TempTableBase>();
                //foreach (var fecha in fechas)
                //{
                //    //if (fecha.Year >2012) 
                //    if (fecha.Year > 2014)
                //    {
                //       IndicePreconfiguradoNovarex_VM.Insert_Temp(plantilla, fecha, ref listaTmpAux);
                //        //opció dos, prova temporal
                //       // IndicePreconfiguradoNovarex_VM.Insert_Temp(plantilla, fecha, ref listaTmp);
                //    }

                //}

                //Por último calculamos la columna "INDEX NOVAREX SEGÚN MERCADOS Y DIVISAS"
                //los cálculos los guardaremos en la tabla RentabilidadIndiceNovarex, que es la que utilizará el report         
                DateTime? fechaAnterior = null;

                    List<RentabilidadIndiceNovarex> listRentAcum = new List<RentabilidadIndiceNovarex>();
                    foreach (var fecha in fechas)
                    {
                        //Se empieza a partir de la segunda fecha
                        if (fechaAnterior != null)
                        {
                            //la rentabilidad de la fecha actual: ((1 + RentAcumFechaActual)/(1 + RentAcumFechaAnterior))-1
                            var rAcumFecha = RentabilidadCarteraV2_DA.GetRentabilidadAcumuladaByFecha(Convert.ToDateTime(fecha),plantilla.CodigoIc);
                            var rAcumAnterior = RentabilidadCarteraV2_DA.GetRentabilidadAcumuladaByFecha(Convert.ToDateTime(fechaAnterior),plantilla.CodigoIc);

                            decimal? rAcum = null;
                            //Si es la primera fecha del año dentro de "fechas" no hay que hacer ningún cálculo, 
                            //devolvemos el valor de GetRentabilidadAcumuladaByFecha
                            //Hacemos lo mismo si es la segunda fecha de todas
                            bool esPrimeraFechaAño = fechas.Where(w => w.Year == fecha.Year).Min() == fecha;
                            bool esSegundaFecha = false;
                            if(fechas.Count() > 2 && fechas[1] == fecha)
                            {
                                esSegundaFecha = true;
                            }
                            if(esPrimeraFechaAño || esSegundaFecha)
                            {
                                rAcum = rAcumFecha/100;
                            }
                            else if (rAcumFecha != null && rAcumAnterior != null)
                            {
                                //como en la tabla está almacenado el % dividimos entre 100 para los cálculos
                                rAcum = (((1 + (rAcumFecha/100)) / (1 + (rAcumAnterior/100))) - 1);
                            }

                            if (rAcum != null)
                            {
                                //Añadimos la rentabilidad acumulada calculada para ser insertada en la tabla RentabilidadIndiceNovarex posteriormente
                                var obj = new RentabilidadIndiceNovarex();
                                obj.Fecha = fecha;
                                obj.RentabilidadAcumulada = Convert.ToDecimal(rAcum);
                                listRentAcum.Add(obj);
                            }
                        }

                        
                        fechaAnterior = fecha;
                    }

                    //Hacemos el insert. En algún momento deberíamos cambiar el nombre de la tabla RentabilidadIndiceNovarex a Temp_RentabilidadCarteraV2_Acum
                    //e incluir esta nueva tabla en ModelUpdates como otra TempTableBase para no necesitar este Insert y que se haga con el InsertTemp como el resto
                    //Tendríamos que tener en cuenta que en el report esta columna se coge específicamente de esta tabla (RentabilidadIndiceNovarex)
                    RentabilidadCarteraV2_DA.InsertRentabilidadAcumulada(listRentAcum);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_RentabilidadCarteraV2 getTemp_RentabilidadCarteraV2Item(string codigoIC, string codigoIndice, string descripcionIndice, ref decimal? valorLiqAnterior, bool esIndice, DateTime fecha, bool backgroundColor)
        {
            Temp_RentabilidadCarteraV2 tmp = null;

            //Utilizamos PRO02 y si es índice PRO03
            if (!esIndice)
            {
                //Pasamos como isin el indice
                var pro02Result = Reports_DA.GetPRO02(codigoIC, codigoIndice, fecha).FirstOrDefault();

                if (pro02Result != null)
                {
                    tmp = new Temp_RentabilidadCarteraV2();
                    tmp.CodigoIC = codigoIC;
                    tmp.Isin = codigoIndice;
                    tmp.DescripcionIndice = descripcionIndice;
                    tmp.ValorLiquidativo = pro02Result.valliq;
                    tmp.Fecha = fecha;
                    tmp.EsIndice = esIndice;
                    tmp.BackGroundColor = backgroundColor;                    

                    if (valorLiqAnterior != null)
                    {
                        var variacion = Utils.GetVariacion(valorLiqAnterior, pro02Result.valliq);
                        tmp.RentabilidadPeriodo = decimal.Round(Convert.ToDecimal(variacion), 4);
                    }

                    //Almacenamos el valliq para calcular la variación con el siguiente elemento de la iteración
                    valorLiqAnterior = pro02Result.valliq;
                }
            }
            else if(esIndice)
            {
                var pro03_prueba = Reports_DA.GetPRO03(codigoIndice, string.Empty, string.Empty, fecha).FirstOrDefault();

                if (pro03_prueba != null)
                {
                    tmp = new Temp_RentabilidadCarteraV2();
                    tmp.CodigoIC = codigoIC;
                    tmp.Isin = codigoIndice;
                    tmp.DescripcionIndice = descripcionIndice;
                    if (pro03_prueba.coteur != null)
                    {
                        tmp.ValorLiquidativo = Convert.ToDecimal(pro03_prueba.coteur);
                    }
                    tmp.Fecha = fecha;
                    tmp.EsIndice = esIndice;
                    tmp.BackGroundColor = backgroundColor;

                    if (valorLiqAnterior != null)
                    {
                        var variacion = Utils.GetVariacion(valorLiqAnterior, pro03_prueba.coteur);
                        tmp.RentabilidadPeriodo = decimal.Round(Convert.ToDecimal(variacion), 4);
                    }

                    //Almacenamos el valliq para calcular la variación con el siguiente elemento de la iteración
                    valorLiqAnterior = pro03_prueba.coteur;
                }
            }

            return tmp;
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

        public static IQueryable<string> GetDistinctIsins(string codigoIC)
        {
            return RentabilidadCarteraV2_DA.GetDistinctIsins(codigoIC);
        }

        public static Report GetReportRentabilidadCarteraV2(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new ReportRentabilidadCarteraV2(isin, codigoIC, fecha, plantilla);
            //rep.DataSource = Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            // var hasvalues= Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Fecha"].Value = fecha;
            return rep;
        }


        public static Report GetReportRentabilidadCarteraV2_SUB(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportRentabilidadCarteraIndiceV2_SUB(isin, codigoIC, fecha);

            return rep;
        }

    }
}
