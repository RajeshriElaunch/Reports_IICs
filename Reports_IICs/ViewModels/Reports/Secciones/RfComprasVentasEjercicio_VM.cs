using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.RfComprasVentasEjercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RfComprasVentasEjercicio_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_RFComprasVentasEjercicio> listaTmp = new List<Temp_RFComprasVentasEjercicio>();
                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));
                //var listaIsins = Utils.GetIsinsPlantillaByFecha(plantilla.CodigoIc, Convert.ToDateTime(fechaInforme));
                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    try
                    {
                        var pro14 = Reports_DA.GetPRO14(plantilla.CodigoIc, string.Empty, fechaInicio, Convert.ToDateTime(fechaInforme)).ToList();
                        foreach (var item in pro14)
                        {
                            var sit = Utils.CheckInt(item.Situacion);
                            //No mostramos los movimientos ANULADOS (>=90)
                            if (sit != null && sit < 90)
                            {
                                //var tmp = getNuevoTemp_RFComprasVentasEjercicio(plantilla.CodigoIc, isin.Isin, item.FECHA, item.TIPMOV, item.descr, item.cantid, item.PRECIO, item.EsCompra);
                                bool esCompra = item.TIPMOV.Equals("COMPRA") ? true : false;
                                var tmp = getNuevoTemp_RFComprasVentasEjercicio(plantilla.CodigoIc, string.Empty, item.FECHA, item.TIPMOV, item.descr, item.cantid, item.PRECIO, esCompra);
                                listaTmp.Add(tmp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}

                //RfComprasVentasEjercicio_DA.Insert_Temp(plantilla.CodigoIc, listaTmp);
                //Temp_Table_Manager<Temp_RFComprasVentasEjercicio> ttm = new Temp_Table_Manager<Temp_RFComprasVentasEjercicio>();
                //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_RFComprasVentasEjercicio getNuevoTemp_RFComprasVentasEjercicio(string codigoIC, string isin, DateTime fecha, string tipoMovimiento, string descValor, decimal? cantidad, decimal? precio, bool esCompra)
        {
            Temp_RFComprasVentasEjercicio tmp = new Temp_RFComprasVentasEjercicio();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.Fecha = fecha;
            tmp.TipoMovimiento = tipoMovimiento;
            tmp.DescripcionValor = descValor;
            tmp.Cantidad = cantidad;
            tmp.Precio = precio;
            tmp.EsCompra = esCompra;
           
            return tmp;
        }

        public static Report GetReport(string codigoIC, string isin, string isinDesc, DateTime fechaInforme, DateTime? fechaAnterior)
        {
            Telerik.Reporting.Report rep = new Report_RfComprasVentasEjercicio(fechaAnterior);
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["IsinDesc"].Value = isinDesc;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            rep.ReportParameters["FechaAnterior"].Value = fechaAnterior;
            return rep;
        }
    }
}
