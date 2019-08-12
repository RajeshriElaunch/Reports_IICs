using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.RvComprasRealizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RvComprasRealizadasEjercicio_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));


                //Obtenemos los instrumentos de RV y de tipo VAL para filtrar
                var listInst = new List<string> { "RVA" };
                var listTiposInst = new List<string> { "VAL" };
                var isinsRVyVAL = Reports_DA.FiltrarInstrumentos(listInst, listTiposInst, null, null, false, false, false, false).Select(s => s.ISIN.ToUpper());

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    try
                    {
                        //Quieren que agrupemos las compras del mismo isin y mismo día
                        //var pro = pro13.Where(w => (w.Grupo.Contains("GRUPO-03") || w.Grupo.Contains("GRUPO-04"))).ToList();
                        var pro = VariablesGlobales.Pro13_Local.Where(w => 
                            Convert.ToInt32(w.TipMovO) >= 600 
                            && Convert.ToInt32(w.TipMovO) < 700
                            && w.TipMovO != "601"//No queremos mostrar los TRASPASOS
                            ).ToList();

                        //Filramos para operar sólo con los de RV y de tipo VAL
                        pro = pro.Where(w => isinsRVyVAL.Contains(w.Isin.ToUpper())).ToList();

                        var proFiltrado = pro.GroupBy(g => new
                        {
                            g.Isin,
                            g.FechaO,
                            g.Nombre,
                            g.Grupo
                        });

                        foreach (var item in proFiltrado)
                        {

                            var itemPro13 = new usp_gestio_pro_13_Result();

                            itemPro13.Isin = item.Key.Isin;
                            itemPro13.FechaO = item.Key.FechaO;
                            itemPro13.Nombre = item.Key.Nombre;
                            itemPro13.Grupo = item.Key.Grupo;

                            itemPro13.NumTit = item.Sum(acs => acs.NumTit);
                            itemPro13.PrecioOAEUR = item.Sum(acs => acs.PrecioOAEUR * acs.NumTit) / item.Sum(acs => acs.NumTit);
                            itemPro13.Dividendos = item.Sum(acs => acs.Dividendos);
                            itemPro13.PrecioFEUR = item.Average(acs => acs.PrecioFEUR);

                            var tmp = getNuevoTemp_EvolucionMercados(plantilla.CodigoIc, itemPro13);
                            listaTmp.Add(tmp);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}



                //RvComprasRealizadasEjercicio_DA.Insert_Temp(plantilla.CodigoIc, listaTmp);
                //Temp_Table_Manager<Temp_RVComprasRealizadasEjercicio> ttm = new Temp_Table_Manager<Temp_RVComprasRealizadasEjercicio>();
                //ttm.InsertTemp(plantilla.CodigoIc, listaTmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_RVComprasRealizadasEjercicio getNuevoTemp_EvolucionMercados(string codigoIC, usp_gestio_pro_13_Result item)
        {
            Temp_RVComprasRealizadasEjercicio tmp = new Temp_RVComprasRealizadasEjercicio();

            tmp.CodigoIC = codigoIC;
            tmp.Fecha = item.FechaO;
            tmp.Grupo = item.Grupo;
            tmp.TipoMovimiento = "COMPRA";
            tmp.DescripcionValor = item.Nombre;
            tmp.Cantidad = item.NumTit;//CANTIDAD ENTRE FACTOR DE AJUSTE
            
            var precio = item.PrecioOAEUR;
            if (precio != 0)
            {
                tmp.Precio = precio;
            }
            //PRECIO * FACTOR DE AJUSTE
            if (item.Dividendos != 0)
            {
                tmp.DividendosCobrados = item.Dividendos;
            }
            var cotFechaFin = item.PrecioFEUR;

            bool vendido = (item.Grupo.Contains("GRUPO-02") || item.Grupo.Contains("GRUPO-03")) ? true : false;

            //Insertaremos valor en CotizacionFechaFin y VariacionDesdeCompra sólo si no se han vendido
            if (!vendido)
            {
                tmp.CotizacionFechaFin = cotFechaFin;

                //tenemos que tener en cuenta cuando hay cobro de dividendos
                decimal dividendos = 0;
                if (tmp.DividendosCobrados != null)
                    dividendos = item.Dividendos / item.NumTit;

                if (decimal.Round(precio, 2) != 0)
                {
                    var varDesdeCompra = (cotFechaFin + dividendos - precio) / precio;
                    //tmp.VariacionDesdeCompra = (-1) * varDesdeCompra;
                    tmp.VariacionDesdeCompra = varDesdeCompra;
                }
            }

            return tmp;
        }
        
        public static Report GetReportRvComprasRealizadas(Plantilla pl, DateTime fechaInforme)
        {
            Telerik.Reporting.Report rep = new Report_RvComprasRealizadasEjercicio();
            rep.ReportParameters["CodigoIC"].Value = pl.CodigoIc;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;

            var filtroFecha = pl.Parametros_RVComprasRealizadasEjercicio.Select(c => c.FechaUltimaReunion).FirstOrDefault();

            DateTime FechaUltimaReunion = new DateTime(1900, 1, 1);
            if (filtroFecha != null)
                FechaUltimaReunion = pl.Parametros_RVComprasRealizadasEjercicio.Select(c => c.FechaUltimaReunion).FirstOrDefault().Value;
            rep.ReportParameters["UltimaFechaInforme"].Value = FechaUltimaReunion;

            return rep;
        }

        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            RvComprasRealizadasEjercicio_DA.UpdateFechaUltimaReunion(codigoIC, fecha);
        }
    }
}
