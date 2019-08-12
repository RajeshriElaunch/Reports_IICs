using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.OPERACIONES_RENTA_VARIABLE__II_;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class OperacionesRV_II_VM
    {
        private enum TipoMovimiento
        {
            Compra,
            Venta,
            CompraVenta, //Es compra y venta
            Otro
        };

        private static Plantilla _plantilla;
        private static DateTime? _fechaInforme;
        private static Parametros_OperacionesRentaVariable_II _param;

        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_OperacionesRentaVariable_II> listaTmp = new List<Temp_OperacionesRentaVariable_II>();
                _plantilla = plantilla;
                _fechaInforme = fechaInforme;
                var fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));
                _param = new Parametros_OperacionesRentaVariable_II_MNG().GetByCodigoIC(plantilla.CodigoIc).FirstOrDefault();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{

                    //var proc = Reports_DA.GetPRO13(plantilla.CodigoIc, fechaInicio, Convert.ToDateTime(fechaInforme));
                    //var cartera = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaInforme, "RVA", null, null, null);

                    //Obtenemos los instrumentos de tipo VAL ó IIC para filtrar
                    //Ya no quieren que sean sólo los de RVA
                    //var listInst = new List<string> { "RVA" };
                    var listTiposInst = new List<string> { "VAL", "IIC" };
                    var isinsFiltrados = Reports_DA.FiltrarInstrumentos(null, listTiposInst, null, null, false, false, false, false).Select(s => s.ISIN);

                    //var proc = Reports_DA.GetPRO17(plantilla.CodigoIc, isin, fechaInicio, Convert.ToDateTime(fechaInforme)).
                    
                    var procIsins = VariablesGlobales.Pro13_Local.
                        Where(w => isinsFiltrados.Contains(w.Isin.ToUpper(), StringComparer.CurrentCultureIgnoreCase));                    

                    //fecha “común” a la que bajar la cartera para buscar el Coste Medio. Para ello, se deberá buscar la fecha de la primera venta del informe y restarle un día.
                    //DateTime? fechaComun = null;

                //Como hay compraventas puede que haya items que salgan en el apartado de compras y también en el de ventas
                //var compras = procIsins.Where(w => 
                //                Convert.ToInt32(w.TipMovO) >= 600 
                //                && Convert.ToInt32(w.TipMovO) < 700
                //                && w.TipMovO != "601"//No queremos mostrar COMPRAS que sean TRASPASOS
                //                )
                /*var compras = procIsins.Where(w => esCompra(w))
                    .GroupBy(g => new
                            {
                                g.Isin,
                                g.FechaO,
                                g.Nombre,
                                g.TipMovO,
                                g.ClamovF

                            }).Select(cl => new usp_gestio_pro_13_Result
                            {
                                Isin = cl.Key.Isin,
                                FechaO = cl.Key.FechaO, 
                                Nombre = cl.Key.Nombre,
                                NumTit = cl.Sum(c => c.NumTit),
                                PrecioI = cl.Sum(c => c.PrecioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                CambioI = cl.Sum(c => c.CambioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                EfectivoFEUR = cl.Sum(c => c.EfectivoFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                EfectivoIAEUR = cl.Sum(c => c.EfectivoIAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                EfectivoIEUR = cl.Sum(c => c.EfectivoIEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                PrecioOA = cl.Sum(c => c.PrecioOA * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                PrecioOAEUR = cl.Sum(c => c.PrecioOAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                PrecioF = cl.Sum(c => c.PrecioF * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                PrecioFEUR = cl.Sum(c => c.PrecioFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                                TipMovO = cl.Key.TipMovO,
                                ClamovF = cl.Key.ClamovF
                            }
                        );

                //var ventas = procIsins.Where(w =>
                //                        w.FechaC != null
                //                        || (w.ClamovF != null && w.ClamovF.Equals("VE"))
                //                        || (w.ClamovO != null && w.ClamovO.Equals("VE"))
                //                        )
                var ventas = procIsins.Where(w =>esVenta(w))
                    .GroupBy(g => new
                        {
                            g.Isin,
                            g.FechaC,
                            g.Nombre,
                            g.TipMovO,
                            g.ClamovF,
                            g.ClamovO

                        }).Select(cl => new usp_gestio_pro_13_Result
                        {
                            Isin = cl.Key.Isin,
                            FechaC = cl.Key.FechaC,
                            Nombre = cl.Key.Nombre,
                            NumTit = cl.Sum(c => c.NumTit),
                            EfectivoFEUR = cl.Sum(c => c.EfectivoFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            EfectivoIAEUR = cl.Sum(c => c.EfectivoIAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            EfectivoIEUR = cl.Sum(c => c.EfectivoIEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioI = cl.Sum(c => c.PrecioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            CambioI = cl.Sum(c => c.CambioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioOA = cl.Sum(c => c.PrecioOA * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioOAEUR = cl.Sum(c => c.PrecioOAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioF = cl.Sum(c => c.PrecioF * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioFEUR = cl.Sum(c => c.PrecioFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            PrecioC = cl.Sum(c => c.PrecioC * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                            
                            TipMovO = cl.Key.TipMovO,
                            ClamovF = cl.Key.ClamovF,
                            ClamovO = cl.Key.ClamovO
                        }
                        );
                        */

                var comprasOventas = procIsins.Where(w => esCompra(w) || esVenta(w))
                    .GroupBy(g => new
                    {
                        g.Isin,
                        g.FechaO,
                        g.FechaC,
                        g.Nombre,
                        g.TipMovO,
                        g.ClamovF,
                        g.ClamovO

                    }).Select(cl => new usp_gestio_pro_13_Result
                    {
                        Isin = cl.Key.Isin,
                        FechaO = cl.Key.FechaO,
                        FechaC = cl.Key.FechaC,
                        Nombre = cl.Key.Nombre,
                        NumTit = cl.Sum(c => c.NumTit),
                        PrecioI = cl.Sum(c => c.PrecioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        CambioI = cl.Sum(c => c.CambioI * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        EfectivoFEUR = cl.Sum(c => c.EfectivoFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        EfectivoIAEUR = cl.Sum(c => c.EfectivoIAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        EfectivoIEUR = cl.Sum(c => c.EfectivoIEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        PrecioOA = cl.Sum(c => c.PrecioOA * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        PrecioOAEUR = cl.Sum(c => c.PrecioOAEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        PrecioF = cl.Sum(c => c.PrecioF * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        PrecioFEUR = cl.Sum(c => c.PrecioFEUR * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        PrecioC = cl.Sum(c => c.PrecioC * c.NumTit) / cl.Sum(c => c.NumTit),//Media ponderada  
                        TipMovO = cl.Key.TipMovO,
                        ClamovF = cl.Key.ClamovF,
                        ClamovO = cl.Key.ClamovO
                    }
                        );

                //var proc = compras.ToList();
                //    proc.AddRange(ventas.ToList());

                var proc = comprasOventas.ToList();

                //List<usp_gestio_pro_11_Result> cartFechComun = new List<usp_gestio_pro_11_Result>();
                //if (ventas != null)
                //{
                //    //Comparamos la primera FechaO con la primera FechaC y nos quedamos con la más antigua
                //    //fechaComun = Convert.ToDateTime(proc.Min(p => p.FechaO > p.FechaC ? p.FechaO : p.FechaC)).AddDays(-1);
                //    //Cogemos como fechaComun la fecha más antigua de venta
                //    //fechaComun = Convert.ToDateTime(proc.Min(p => p.FechaC)).AddDays(-1);
                //    //cartFechComun = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fechaComun, null, null, false).Where(w=> isinsFiltrados.Contains(w.isin.ToUpper(), StringComparer.CurrentCultureIgnoreCase)).ToList();
                //}



                foreach (var item in proc)
                {
                    //if (Utils.EqualsIgnoreCase(item.Isin, "DE000UNSE018"))
                    //{
                    //    bool flag = true;
                    //    var aaa = VariablesGlobales.Pro13_Local.Where(w => w.Isin.ToUpper() == "DE000UNSE018");
                    //    var bbb = ventas.Where(w => w.Isin.ToUpper() == "FR0010976001");
                    //}
                    try
                    {
                        //var tmp = getNuevoTemp_OperacionesRentaVariable_II(plantilla.CodigoIc, compras, item, fechaComun, cartFechComun);

                        var tmp = getNuevoTemp_OperacionesRentaVariable_II(plantilla, item, isinsFiltrados);
                        //var param = OperacionesRV_II_DA.GetParametros(plantilla.CodigoIc);

                        //Sólo añadimos los que tengan un efectivo menor o igual al parámetro EfectivoMinimo
                        foreach (var itemTmp in tmp)
                        {
                            if
                                (
                                    _param == null
                                    ||
                                    (
                                        _param != null
                                        && (
                                                _param.EfectivoMinimo == null
                                                ||
                                                _param.EfectivoMinimo != null && _param.EfectivoMinimo <= itemTmp.EfectivoEuros
                                            )
                                    )
                                    ||
                                    itemTmp.TipoMovimiento == "VENTA"
                                )
                            {
                                //Sólo lo añadimos si el efectivo en euros de la operación es mayor o igual que el efectivo mínimo guardado como parámetro
                                if (
                                        (
                                        _param == null
                                        || _param != null && _param.EfectivoMinimo == null
                                        || (_param != null && _param.EfectivoMinimo != null && itemTmp.EfectivoEuros >= _param.EfectivoMinimo)
                                        )
                                        && item.TipMovF != "808"
                                    )
                                {
                                    //if (!itemTmp.DescripcionValor.Contains("ANTES"))
                                    //{
                                    listaTmp.Add(itemTmp);
                                    //}
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                    paintReportLine(ref listaTmp);
                    updateDateParam();
                //}                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool esCompra(usp_gestio_pro_13_Result item)
        {
            if(
                Convert.ToInt32(item.TipMovO) >= 600
                && Convert.ToInt32(item.TipMovO) < 700
                && item.TipMovO != "601"//No queremos mostrar COMPRAS que sean TRASPASOS
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool esVenta(usp_gestio_pro_13_Result item)
        {
            //Aquí si mostramos TRASPASOS
            if (
                item.FechaC != null
                || (item.ClamovF != null && item.ClamovF.Equals("VE"))
                || (item.ClamovO != null && item.ClamovO.Equals("VE"))
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void paintReportLine(ref List<TempTableBase> listaTmp)
        {             
            //En estas dos variables marcamos cuál es la primera línea después de la útlima reunión
            //así podremos utilizar para pintar una línea divisoria en el report
            if (_param != null && _param.FechaUltimoInforme != null)
            {
                var added = listaTmp.Where(w => w.GetType() == new Temp_OperacionesRentaVariable_II().GetType()).Select(s => (Temp_OperacionesRentaVariable_II)s);
                var primeraVenta = added.OrderBy(o => o.Fecha).ThenBy(o=>o.DescripcionValor).Where(w => w.TipoMovimiento == "VENTA" && w.Fecha > _param.FechaUltimoInforme).FirstOrDefault();
                var primeraCompra = added.OrderBy(o => o.Fecha).ThenBy(o => o.DescripcionValor).Where(w => w.TipoMovimiento == "COMPRA" && w.Fecha > _param.FechaUltimoInforme).FirstOrDefault();

                if (primeraVenta != null)
                    primeraVenta.PaintLine = true;

                if (primeraCompra != null)
                    primeraCompra.PaintLine = true;
            }
        }

        private static void updateDateParam()
        {
            //Actualizamos el parámetro Fecha con la fecha del informe
            //var param = new Parametros_OperacionesRentaVariable_II_MNG().GetByCodigoIC(plantilla.CodigoIc).FirstOrDefault();
            if (_param == null)
            {
                _param = new DataModels.Parametros_OperacionesRentaVariable_II();
                _param.CodigoIC = _plantilla.CodigoIc;
            }

            _param.FechaUltimoInforme = _fechaInforme;
            new Parametros_OperacionesRentaVariable_II_MNG().Save(_param, null);
        }

        private static List<Temp_OperacionesRentaVariable_II> getNuevoTemp_OperacionesRentaVariable_II(Plantilla plantilla, usp_gestio_pro_13_Result item, IEnumerable<string> isinsFiltrados)
        {
            var lista = new List<Temp_OperacionesRentaVariable_II>();

            //TipoMovimiento tipMov = esCompra(item);
            //Un registro lo podemos pintar en el bloque de COMPRAS en el de VENTAS o en los dos
            //if (tipMov == TipoMovimiento.Compra || tipMov == TipoMovimiento.CompraVenta)
            
            //if(item.FechaO != null 
            //    && item.TipMovO != "601"    //No queremos mostrar los TRASPASOS en COMPRAS
            //    )
            if(esCompra(item))
            {
                Temp_OperacionesRentaVariable_II tmp = new Temp_OperacionesRentaVariable_II();
                tmp.CodigoIC = plantilla.CodigoIc;
                tmp.IsinPlantilla = item.Isin;
                tmp.Fecha = item.FechaO;
                tmp.TipoMovimiento = "COMPRA";
                tmp.Cantidad = item.NumTit;
                tmp.Precio = item.PrecioOA;
                tmp.PrecioEuros = item.PrecioOAEUR;
                tmp.EfectivoEuros = item.EfectivoIAEUR;
                tmp.DescripcionValor = item.Nombre;
                lista.Add(tmp);
            }
            //if (tipMov == TipoMovimiento.Venta || tipMov == TipoMovimiento.CompraVenta)
            
            //if(
            //    item.FechaC != null
            //    ||(item.ClamovF != null && item.ClamovF.Equals("VE"))
            //    ||(item.ClamovO != null && item.ClamovO.Equals("VE"))                
            //  )
            if(esVenta(item))
            {
                Temp_OperacionesRentaVariable_II tmp = new Temp_OperacionesRentaVariable_II();
                tmp.CodigoIC = plantilla.CodigoIc;
                tmp.IsinPlantilla = item.Isin;
                tmp.Fecha = item.FechaC != null ? item.FechaC : item.FechaO;
                
                tmp.TipoMovimiento = "VENTA";
                tmp.Cantidad = item.NumTit;//Ahora lo quieren en positivo
                tmp.Precio = item.PrecioF;
                tmp.PrecioEuros = item.PrecioFEUR;
                tmp.EfectivoEuros = item.EfectivoFEUR;//Ahora lo quieren en positivo
                tmp.DescripcionValor = item.Nombre;

                if (item.FechaC != null
                    || (item.ClamovF != null && item.ClamovF.Equals("VE"))
                    || (item.ClamovO != null && item.ClamovO.Equals("VE")))
                {
                    //recuperamos la cartera del día anterior                    
                    DateTime fechaCart = new DateTime();
                    if (item.FechaC != null)
                        fechaCart = Core.Framework.Common.ToDateTime(item.FechaC).AddDays(-1);
                    else if (item.FechaO != null)
                        fechaCart = Core.Framework.Common.ToDateTime(item.FechaO).AddDays(-1);

                    if (item.TipMovO != "601")//NO TRASPASOS
                    {
                        var cart = Reports_DA.GetCartera(plantilla, fechaCart).Where(w => w.isin.ToUpper() == item.Isin.ToUpper()).FirstOrDefault();

                        if (cart != null)
                            tmp.CosteMedio = cart.cosmed;
                        else
                        {
                            tmp.CosteMedio = item.PrecioOAEUR;
                        }
                    }
                    //TRASPASOS
                    else
                    {
                        tmp.CosteMedio = item.PrecioI * item.CambioI;
                    }
                }
                /* Ya no tenemos en cuenta esto, ahora siempre descargaremos la cartera el día anterior de cada venta
                //Calculamos el coste medio, que sólo se muestra para las ventas
                var fechaVenta = Convert.ToDateTime(item.FechaC);
                //Para cada movimiento de venta se tendrá que comprobar que no ha habido compras para ese 
                //mismo ISIN entre el día después de la fecha “comun”
                //y el día anterior a la fecha de venta de cada operación
                var comprasEnPeriodo = compras.Where(w =>
                    string.Equals(w.Isin, item.Isin, StringComparison.CurrentCultureIgnoreCase)
                    && (fechaComun < w.FechaO && w.FechaO < fechaVenta) //FechaO cuando son compras y FechaC cuando son ventas
                ).Count();
                //Si se da el caso que no ha habido compras (que será lo más frecuente), se puede utilizar el Coste Medio que da la Cartera a la fecha “Común”.
                if (comprasEnPeriodo == 0)
                {
                    var cartTmp = cartFechComun.Where(w => string.Equals(w.isin, item.Isin, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    if (cartTmp != null)
                    {
                        tmp.CosteMedio = cartTmp.cosmed;
                    }
                    //else
                    //{
                    //    tmp.CosteMedio = 0;
                    //}
                }
                //En caso de que sí que haya compras en ese período, entonces habría que bajar la cartera a la fecha anterior a la Venta de esa operación. 
                else
                {
                    var cartAnt = Reports_DA.GetCarteraFiltrada(codigoIC, fechaVenta.AddDays(-1), "RVA", null, false).Where(w => string.Equals(w.isin, item.Isin, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    if (cartAnt != null)
                    {
                        tmp.CosteMedio = cartAnt.cosmed;
                    }
                }*/
                tmp.GanPerVsCosMed = Utils.GetVariacion(tmp.CosteMedio, tmp.PrecioEuros)/100;                

                lista.Add(tmp);
            }
                
            
            return lista;
        }

        //private static TipoMovimiento esCompra(usp_gestio_pro_13_Result item)
        //{
        //    bool compra = false;
        //    bool venta = false;
        //    if(Convert.ToInt32(item.TipMovO) >= 600 && Convert.ToInt32(item.TipMovO) < 700)
        //    {
        //        compra = true; ;
        //    }
        //    if(item.ClamovF != null && item.ClamovF.Equals("VE"))
        //    {
        //        venta = true;
        //    }

        //    if(compra && venta)
        //    {
        //        return TipoMovimiento.CompraVenta;
        //    }
        //    else if(compra)
        //    {
        //        return TipoMovimiento.Compra;
        //    }
        //    else if(venta)
        //    {
        //        return TipoMovimiento.Venta;
        //    }
        //    else
        //    {
        //        return TipoMovimiento.Otro;
        //    }
        //}

        public static Report GetReportOperacionesRentaVariableII(string codigoIC, string isin, DateTime fecha, Plantilla plantilla)
        {
            Telerik.Reporting.Report rep = new ReportOperacionesRentaVariableII(codigoIC, isin);
            //rep.ReportParameters["Isin"].Value = isin;
            rep.ReportParameters["Isin"].Value = null;
            rep.ReportParameters["CodigoIC"].Value = codigoIC;

            return rep;
        }

    }
}
