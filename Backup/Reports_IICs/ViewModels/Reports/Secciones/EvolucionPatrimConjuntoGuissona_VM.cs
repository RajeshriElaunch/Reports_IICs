using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Managers;
using Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Conjunto_Guissona;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionPatrimConjuntoGuissona_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var titulo = EvolucionPatrimConjuntoGuissona_DA.GetTituloInforme(plantilla.CodigoIc);
                var fondos = EvolucionPatrimConjuntoGuissona_DA.GetFondos(plantilla.CodigoIc);


                //var listaTmp = new List<Temp_EvolucionPatrimonioConjuntoGuissona>();
                //var listaDatosFondos = new List<Temp_EvolucionPatrimonioConjuntoGuissona_Fondos>();

                if (fondos.Count() > 0)
                {
                    var minFechaConst = fondos.Min(f => f.FechaConstitucion);
                    var fechas = Utils.GetFechasEvolucionRentabilidadGuissona(minFechaConst, Convert.ToDateTime(fecha));
                    //El orden que quieren coincide con la ordenación por CodigoICFondo
                    foreach (var fondo in fondos.OrderBy(o => o.CodigoICFondo))
                    {
                        try
                        {
                            //Guardamos los datos del Fondo
                            //var datosFondo = getNuevoTemp_EvolucionPatrimonioConjuntoGuissona_Fondos(plantilla.CodigoIc, isinFondo, descrip, fechaConst);
                            var datosFondo = getNuevoTemp_EvolucionPatrimonioConjuntoGuissona_Fondos(fondo.CodigoIC, fondo.CodigoICFondo, fondo.IsinFondo, fondo.Descripcion, fondo.FechaConstitucion);
                            //listaDatosFondos.Add(datosFondo);
                            //listaTmp.Add(datosFondo);

                            foreach (var fechaProc in fechas)
                            {
                                try
                                {

                                    var proc = Reports_DA.GetPRO02(fondo.CodigoICFondo, fondo.IsinFondo, fechaProc).FirstOrDefault();
                                    //var proc = Reports_DA.GetPRO02(codigoIc, isinFondo, fechaProc).FirstOrDefault();

                                    decimal? tmpPatrimonio = null;
                                    if (proc != null)
                                    {
                                        //utilizamos esta variable para insertar nulos en las fechas anteriores a la fecha de constitución del fondo en caso que
                                        //el resto de fondos del informe tengan una fecha de constitución anterior. Nos será muy útil para pintar en report
                                        tmpPatrimonio = proc.patrimonio;
                                    }

                                    //añadir el % a la tabla temp
                                    var tmp = getNuevoTemp_EvolucionPatrimonioConjuntoGuissona(plantilla, fondo.IsinFondo, fechaProc, tmpPatrimonio);
                                    //var tmp = getNuevoTemp_EvolucionPatrimonioConjuntoGuissona(plantilla, isinFondo, fechaProc, tmpPatrimonio);
                                    listaTmp.Add(tmp);
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    #region Eliminar Temp
                    Temp_EvolucionPatrimonioConjuntoGuissona tmp = new Temp_EvolucionPatrimonioConjuntoGuissona();
                    Temp_Table_Manager.DeleteTemp(plantilla.CodigoIc, tmp.GetType());
                    #endregion
                }
                //try
                //{
                //    EvolucionPatrimConjuntoGuissona_DA.Insert_Temp(plantilla.CodigoIc, listaTmp, listaDatosFondos);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_EvolucionPatrimonioConjuntoGuissona getNuevoTemp_EvolucionPatrimonioConjuntoGuissona(Plantilla plantilla, string isinFondo, DateTime fecha, decimal? patrimonio)
        {
            Temp_EvolucionPatrimonioConjuntoGuissona tmp = new Temp_EvolucionPatrimonioConjuntoGuissona();

            tmp.CodigoIC = plantilla.CodigoIc;
            tmp.IsinFondo = isinFondo;
            tmp.Fecha = fecha;
            tmp.Patrimonio = patrimonio;

            return tmp;
        }

        private static Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos getNuevoTemp_EvolucionPatrimonioConjuntoGuissona_Fondos(string codigoIC, string codigoICFondo, string isinFondo, string descripcion, DateTime fechaConstitucion)
        {
            var tmp = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();

            tmp.CodigoIC = codigoIC;
            tmp.CodigoICFondo = codigoICFondo;
            tmp.IsinFondo = isinFondo;
            tmp.Descripcion = descripcion;
            tmp.FechaConstitucion = fechaConstitucion;

            return tmp;
        }


        public static Report GetReportEvolucionPatrimonioConjuntoGuissona(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónPatrimonioConjuntoGuissona(isin, codigoIC, fecha, plantilla);
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


        public static Report GetReportEvoluciónPatrimonioConjuntoGuissona_SUB(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónPatrimonioConjuntoGuissona_SUB(isin, codigoIC, fecha);

            return rep;
        }

        public static Report GetReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónPatrimonioConjuntoGuissonaTotal_SUB(isin, codigoIC, fecha);

            return rep;
        }

        public static Report GetReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB(string codigoIC, string isin, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportEvoluciónPatrimonioConjuntoGuissonaVariacio_SUB(isin, codigoIC, fecha);

            return rep;
        }


    }
}
