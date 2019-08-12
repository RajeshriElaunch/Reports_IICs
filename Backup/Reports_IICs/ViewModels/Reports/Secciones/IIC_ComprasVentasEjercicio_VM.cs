using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.IIC_ComprasVentasEjercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class IIC_ComprasVentasEjercicio_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_IIC_ComprasVentasEjercicio> listaTmp = new List<Temp_IIC_ComprasVentasEjercicio>();

                var fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));

                //Obtenemos los instrumentos de tipo IIC para filtrar
                var listTiposInst = new List<string> { "IIC" };
                var isinsIIC = Reports_DA.FiltrarInstrumentos(null, listTiposInst, null, null, false, false, false, false).Select(s => s.ISIN.ToUpper());

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    //Quieren que agrupemos las compras del mismo isin y mismo día
                    try
                    {
                        var pro = VariablesGlobales.Pro13_Local.Where(w =>
                                            (
                                                (Convert.ToInt32(w.TipMovO) >= 600 && Convert.ToInt32(w.TipMovO) < 700)   //COMPRAS
                                                 || (w.ClamovF != null && w.ClamovF.Equals("VE"))    //VENTAS
                                            )
                                            //&& w.IdInstrumento == "1" 
                                            && w.IdTipoInstrumento =="2"
                                            //&& isinsIIC.Contains(w.Isin, StringComparer.CurrentCultureIgnoreCase)//Filramos para operar sólo con los de RV y de tipo VAL                                        
                                ).ToList();

                    
                        //    var dt = Utils.ConvertIEnumerableToDT(pro13.Where(w=> (w.ClamovF != null && w.ClamovF.Equals("VE"))
                        //                                                    && isinsIIC.Contains(w.Isin, StringComparer.CurrentCultureIgnoreCase)
                        //                                                    && !plantilla.Plantillas_Isins.Select(s => s.Isin).Contains(w.Isin)
                        //                                                    ));
                        //UtilsExcel.Export2Excel(dt);

                    //Filramos para operar sólo con los de RV y de tipo VAL
                    //pro = pro.Where(w => isinsIIC.Contains(w.Isin.ToUpper())).ToList();

                    //No tenemos los ISINS que coincidan con los de la plantilla
                    //pro = pro.Where(w => !isins.Contains(w.Isin.ToUpper())).ToList();

                    var proFiltrado = pro.GroupBy(g => new
                        {
                            g.Isin,
                            g.FechaO,
                            g.FechaC,
                            g.Nombre,
                            g.TipMovO,
                            g.ClamovF
                        });

                        foreach (var item in proFiltrado)
                        {
                            var itemPro13 = new usp_gestio_pro_13_Result();

                            itemPro13.Isin = item.Key.Isin;
                            itemPro13.FechaO = item.Key.FechaO;
                            itemPro13.FechaC = item.Key.FechaC;
                            itemPro13.Nombre = item.Key.Nombre;
                            itemPro13.NumTit = item.Sum(acs => acs.NumTit);
                            itemPro13.PrecioOAEUR = item.Sum(acs => acs.PrecioOAEUR * acs.NumTit) / item.Sum(acs => acs.NumTit);
                            itemPro13.Dividendos = item.Sum(acs => acs.Dividendos);
                            itemPro13.PrecioFEUR = item.Average(acs => acs.PrecioFEUR);
                            itemPro13.TipMovO = item.Key.TipMovO;
                            itemPro13.ClamovF = item.Key.ClamovF;

                            int tipMov = Convert.ToInt32(itemPro13.TipMovO);
                            if (tipMov >= 600 && tipMov < 700)
                            {
                                var tmp = getNuevoTemp_IIC_ComprasVentasEjercicio(plantilla.CodigoIc, itemPro13, "COMPRA");
                                listaTmp.Add(tmp);
                            }
                            if (!string.IsNullOrEmpty(itemPro13.ClamovF) && itemPro13.ClamovF.Equals("VE"))
                            {
                                var tmp = getNuevoTemp_IIC_ComprasVentasEjercicio(plantilla.CodigoIc, itemPro13, "VENTA");
                                listaTmp.Add(tmp);
                            }

                        }
                    }
                    catch (Exception)
                    {

                    }
                //}

                //Si un título se ha comprado y también se ha vendido no tiene sentido que pongamos la cotización de cierre y la variación de compra, ha de salir un guion (ponemos null)
                var añadidos = listaTmp.Where(w => w.GetType() == new Temp_IIC_ComprasVentasEjercicio().GetType()).Select(s => (Temp_IIC_ComprasVentasEjercicio)s).ToList();
                try
                {
                    var compras = añadidos.Where(w => Utils.EqualsIgnoreCase(w.TipoMovimiento, "COMPRA")).ToList();
                    var isinsVentas = añadidos.Where(w => Utils.EqualsIgnoreCase(w.TipoMovimiento, "VENTA")).Select(s => s.Isin);

                    foreach (var compra in compras.Where(w => isinsVentas.Contains(w.Isin)))
                    {
                        compra.CotizaciónFechaFin = null;
                    }
                }
                catch (Exception)
                {

                }
                //IIC_ComprasVentasEjercicio_DA.Insert_Temp(plantilla, listaTmp);
                //Temp_Table_Manager<Temp_IIC_ComprasVentasEjercicio> ttm = new Temp_Table_Manager<Temp_IIC_ComprasVentasEjercicio>();
                //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_IIC_ComprasVentasEjercicio getNuevoTemp_IIC_ComprasVentasEjercicio(string codigoIC, usp_gestio_pro_13_Result item, string tipoMovimiento)
        {
            Temp_IIC_ComprasVentasEjercicio tmp = new Temp_IIC_ComprasVentasEjercicio();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = item.Isin;
            
            
            tmp.TipoMovimiento = tipoMovimiento;

            tmp.DescripcionValor = item.Nombre;
            tmp.Cantidad = item.NumTit;
            decimal precio = 0;
            if (tipoMovimiento.Equals("COMPRA"))
            {
                tmp.Fecha = Convert.ToDateTime(item.FechaO);
                precio = item.PrecioOAEUR;
            }
            else if (tipoMovimiento.Equals("VENTA"))
            {
                //FechaC. Es la fecha de la operación que cierra la posición. 
                //Cuando la posición no está cerrada el valor que devuelve es null.
                tmp.Fecha = item.FechaC != null? Convert.ToDateTime(item.FechaC) : Convert.ToDateTime(item.FechaO);
                precio = item.PrecioFEUR;
            }

            tmp.Precio = precio;
            
            tmp.CotizaciónFechaFin = item.PrecioFEUR;

            

            return tmp;
        }

        public static Report GetReport_IIC_ComprasVentasEjercicio(Plantilla pl, string isin, DateTime fecha)
        {
            

            var filtroFecha = pl.Parametros_IIC_ComprasVentasEjercicio.Select(c => c.FechaUltimaReunion).FirstOrDefault();

            DateTime FechaUltimaReunion = new DateTime(1900, 1, 1);
            if (filtroFecha != null)
                FechaUltimaReunion = pl.Parametros_IIC_ComprasVentasEjercicio.Select(c => c.FechaUltimaReunion).FirstOrDefault().Value;
            Telerik.Reporting.Report rep = new Report_IIC_ComprasVentasEjercicio(pl.CodigoIc, isin, FechaUltimaReunion,fecha);
            rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["CodigoIC"].Value = pl.CodigoIc;
            rep.ReportParameters["FechaInforme"].Value = fecha;
            rep.ReportParameters["UltimaFechaInforme"].Value = FechaUltimaReunion;

            return rep;
        }

        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            IIC_ComprasVentasEjercicio_DA.UpdateFechaUltimaReunion(codigoIC, fecha);
        }
    }
}
