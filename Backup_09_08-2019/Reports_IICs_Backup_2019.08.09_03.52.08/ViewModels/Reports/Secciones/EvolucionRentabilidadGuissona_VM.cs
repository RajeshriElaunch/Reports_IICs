using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System.Linq;
using System;
using Reports_IICs.Helpers;
using System.Collections.Generic;
using Telerik.Reporting;
using Reports_IICs.Reports.Evolución.Evolución_Rentabilidad_Guissona;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionRentabilidadGuissona_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var titulo = EvolucionRentabilidadGuissona_DA.GetTituloInforme(plantilla.CodigoIc);
                var fondos = EvolucionRentabilidadGuissona_DA.GetFondos(plantilla.CodigoIc);

                if (fondos.Count() > 0)
                {
                    var minFechaConst = fondos.Min(f => f.FechaConstitucion);
                    //var fechas = Utils.GetFechasEvolucionRentabilidadGuissona(minFechaConst, Convert.ToDateTime(fecha));
                    var fechas = Utils.GetFechasEvolucionRentabilidadGuissona(minFechaConst, Convert.ToDateTime(fecha));
                    //El orden que quieren coincide con la ordenación por CodigoICFondo
                    foreach (var fondo in fondos.OrderBy(o => o.CodigoICFondo))
                    {
                        try
                        {
                            //Guardamos los datos del Fondo
                            //var datosFondo = getNuevoTemp_EvolucionRentabilidadGuissona_Fondos(plantilla.CodigoIc, fondo.Codigo, descrip, fechaConst);
                            //var datosFondo = getNuevoTemp_EvolucionRentabilidadGuissona_Fondos(plantilla.CodigoIc, fondo.CodigoICFondo, fondo.IsinFondo, fondo.Descripcion, fondo.FechaConstitucion);
                            //listaDatosFondos.Add(datosFondo);
                            //listaTmp.Add(datosFondo);

                            foreach (var fechaProc in fechas)
                            {
                                try
                                {
                                    decimal? tmpRentabilidad = null;
                                    decimal? valorLiq = null;

                                    //Los datos anteriores a 2002 los tenemos almacenados en nuestra base de datos
                                    //También hay datos de otras fechas que sólo tenemos en el histórico
                                    //Primero comprobamos si lo tenemos en el histórico y si no lo recuperamos de BIA
                                    var tmpOld = EvolucionRentabilidadGuissona_DA.GetOld(fondo.CodigoICFondo, fondo.IsinFondo, fechaProc);
                                    if (tmpOld != null)
                                    {
                                        tmpRentabilidad = tmpOld.PorcentajeRentabilidad;
                                        valorLiq = tmpOld.ValorLiquidativo;
                                    }
                                    else
                                    {
                                        var proc = Reports_DA.GetPRO02(fondo.CodigoICFondo, fondo.IsinFondo, fechaProc).FirstOrDefault();
                                        if (proc != null)
                                        {
                                            tmpRentabilidad = proc.rentabilidad;
                                            valorLiq = proc.valliq;
                                        }
                                    }

                                    //utilizamos esta variable para insertar nulos en las fechas anteriores a la fecha de constitución del fondo en caso que
                                    //el resto de fondos del informe tengan una fecha de constitución anterior. Nos será muy útil para pintar en report
                                    //tmpRentabilidad = proc.rentabilidad;

                                    //añadir el % a la tabla temp
                                    var tmp = getNuevoTemp_EvolucionRentabilidadGuissona(plantilla.CodigoIc, fondo.IsinFondo, fechaProc, tmpRentabilidad);
                                    listaTmp.Add(tmp);

                                    //Guardamos el TAE para la fecha de informe
                                    var ultimaFecha = fechas.Last();
                                    if (fechaProc.Equals(ultimaFecha))
                                    {
                                        var tae = Utils.GetTae(Convert.ToDouble(valorLiq), Convert.ToDateTime(fecha), fondo.FechaConstitucion, fondo.ReferenciaTAE);
                                        if (tae != null && !Double.IsInfinity((double)tae))
                                        {
                                            var tmpTae = getNuevoTemp_EvolucionRentabilidadGuissona_TAE(plantilla.CodigoIc, fondo.IsinFondo, tae);
                                            listaTmp.Add(tmpTae);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_EvolucionRentabilidadGuissona getNuevoTemp_EvolucionRentabilidadGuissona(string codigoIC, string isinFondo, DateTime fecha, decimal? porcentajeRentabilidad)
        {
            Temp_EvolucionRentabilidadGuissona tmp = new Temp_EvolucionRentabilidadGuissona();
            tmp.CodigoIC = codigoIC;
            tmp.IsinFondo = isinFondo;
            tmp.Fecha = fecha;
            tmp.PorcentajeRentabilidad = porcentajeRentabilidad;

            return tmp;
        }

        private static Temp_EvolucionRentabilidadGuissona_TAE getNuevoTemp_EvolucionRentabilidadGuissona_TAE(string codigoIC, string isinFondo, double? tae)
        {
            Temp_EvolucionRentabilidadGuissona_TAE tmp = new Temp_EvolucionRentabilidadGuissona_TAE();

            tmp.CodigoIC = codigoIC;
            tmp.IsinFondo = isinFondo;
            tmp.Tae = Convert.ToDecimal(tae);

            return tmp;
        }

        private static Parametros_EvolucionRentabilidadGuissona_Fondos getNuevoTemp_EvolucionRentabilidadGuissona_Fondos(string codigoIC, string codigoICFondo, string isinFondo, string descripcion, DateTime fechaConstitucion)
        {
            var tmp = new Parametros_EvolucionRentabilidadGuissona_Fondos();
            tmp.CodigoIC = codigoIC;
            tmp.CodigoICFondo = codigoICFondo;
            tmp.IsinFondo = isinFondo;
            tmp.Descripcion = descripcion;
            tmp.FechaConstitucion = fechaConstitucion;

            return tmp;
        }

        public static Report GetReportRentabilidadCarteraGuissona_SUB(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónRentabilidadGuissona_SUB(isin, codigoIC, fecha);

            return rep;
        }


        public static Report GetReportRentabilidadCarteraGuissona(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónRentabilidadGuissona(isin, codigoIC, fecha, plantilla);
            //rep.DataSource = Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            // var hasvalues= Cartera_DA.GetTemp_EvolucionPatrValLiq(plantilla.CodigoIc, isin, fecha).ToList();
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Fecha"].Value = fecha;

            //Telerik.Reporting.Table   tblFecha = rep.Items.Find("tableFecha", true)[0] as Telerik.Reporting.Table;
            //Telerik.Reporting.Table tbltable1 = rep.Items.Find("table1", true)[0] as Telerik.Reporting.Table;

            //tbltable1.Height = tblFecha.Height;

            return rep;
        }

    }
}
