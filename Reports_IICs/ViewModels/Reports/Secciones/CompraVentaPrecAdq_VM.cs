using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.COMPRA_VENTA;
using System;
using System.Collections.Generic;
using Telerik.Reporting;
using System.Linq;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class CompraVentaPrecAdq_VM
    {
        private static DateTime _fechaInforme;
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            _fechaInforme = fecha;

            try
            {                
                //foreach (var isinPlantilla in plantilla.Plantillas_Isins)
                //{
                    // List<Temp_CompraVentaPrecAdq> listaTmp = new List<Temp_CompraVentaPrecAdq>();

                    var fechaDesde = Utils.GetFechaInicio(plantilla, fecha);

                //var pro09_porIsin = Reports_DA.GetPRO_09(plantilla.CodigoIc, fechaDesde, fecha).OrderByDescending(p=>p.fecha).GroupBy(p=>p.isin);
                //Reunión 2016-07-15-1100 --> tratamos AMPLIACION y EQUIPARACION como las COMPRA
                if (VariablesGlobales.Pro09_Local == null)
                {
                    VariablesGlobales.SetVariablesGlobales(typeof(usp_gestio_pro_09_Result), plantilla, fecha);
                }
                var pro09 = VariablesGlobales.Pro09_Local.ToList();


                    //Filtramos para no mostrar los instrumentos RAB
                    //ó cuando tengamos la estrategia PAT seleccionada y tengan Tipo2 = PAT
                    var estPAT = plantilla.Plantillas_Estrategias.Where(w => w.IdTipoInstrumento == "5").FirstOrDefault(); //PAT
                    var listaOcultar = new List<string>();
                    foreach (var item in pro09)
                    {
                        var instr = VariablesGlobales.InstrumentosImportados_Local.Where(w => Utils.EqualsIgnoreCase(w.ISIN, item.isin)).FirstOrDefault();
                        if (
                            //08/05/2017 - Jaume: Antes teníamos en cuenta esta condición. Ahora deberían salir todas las IICS de RV sin discriminación.
                            //instr.Instrumento.Codigo == "RAB" || 
                            (estPAT != null && instr.Instrumentos_Tipos1 != null && instr.Instrumentos_Tipos1.Codigo == "PAT")
                            )
                        {
                            listaOcultar.Add(item.isin.ToUpper());
                        }
                    }

                    //Los quitamos el objeto pro09 para no mostrarlos
                    pro09.RemoveAll(w => listaOcultar.Contains(w.isin.ToUpper()));

                    decimal efectMin = 0;
                    if (plantilla.Parametros_CompraVentaPrecAdq.FirstOrDefault() != null)
                    {
                        efectMin = plantilla.Parametros_CompraVentaPrecAdq.FirstOrDefault().EfectivoMinimo;
                    }

                    //Si las ventas no superan el valor del parámetro "EfectivoMinimo", no mostramos el grupo
                    var ventas = pro09.Where(w => w.tipo.Equals("VENTA") && Math.Abs(Convert.ToDecimal(w.efectivo)) >= efectMin).GroupBy(g => g.isin.ToUpper()).ToList();

                    //Lo ordenamos por fecha para poder hacer los cálculos necesarios
                    var noVentas = pro09.Where(w => w.tipo.Equals("Cartera") ||
                                                w.tipo.Equals("COMPRA") ||
                                                w.tipo.Equals("AMPLIACION") ||
                                                w.tipo.Equals("EQUIPARACION") ||
                                                w.tipo.Equals("TRASPASO")
                                                ).OrderBy(o => o.fecha).ToList();

                //Cuando son traspasos Actualizamos el campo Adquisición cogiendo el PrecioI del PRO13
                actualizarPrecioTraspasos(noVentas.Where(w => w.tipo.Equals("TRASPASO")).ToList());

                foreach (var group in ventas)
                    {
                        var isin = group.Key.ToUpper();                        


                        var totalTitulosVenta = group.Sum(s => s.titulos);
                        //Tenemos que descontar el totalTitulosVenta de las noVentas
                        var titulosPtesDescontar = -totalTitulosVenta; //viene en negativo
                        var noVentasTemp = noVentas.Where(w => w.isin.ToUpper().Equals(isin));

                        //Insertamos las NO ventas primero para que cuando recuperemos los datos
                        //siempre se muestren antes que las ventas en caso de que tengan la misma fecha
                        foreach (var noVenta in noVentasTemp)
                        {
                            if (titulosPtesDescontar > 0)
                            {
                                //Si la noVenta tiene más títulos que los que tenemos ptes de descontar
                                //descontamos sólo los que nos faltaban
                                if (noVenta.titulos > titulosPtesDescontar)
                                {
                                    noVenta.titulos = titulosPtesDescontar;
                                }

                                var tmp = getNuevoTemp_CompraVentaPrecAdq(plantilla.CodigoIc, null, noVenta);
                                listaTmp.Add(tmp);

                                titulosPtesDescontar = titulosPtesDescontar - noVenta.titulos;
                            }
                        }

                        //Insertamos las ventas
                        foreach (var venta in group)
                        {
                            //Primero insertamos las ventas (que siempre se van a visualizarse en la sección)
                            var tmp = getNuevoTemp_CompraVentaPrecAdq(plantilla.CodigoIc, null, venta);
                            listaTmp.Add(tmp);
                        }

                        //Si nos quedan titulos por descontar y no hay más operaciones
                        //se lo quitamos a Cartera
                        if (titulosPtesDescontar > 0)
                        {
                            var pro09Temp = new usp_gestio_pro_09_Result();
                            pro09Temp.isin = isin.ToUpper();
                            pro09Temp.titulos = titulosPtesDescontar;
                            pro09Temp.tipo = "Cartera";
                            pro09Temp.descrvalor = group.Select(s => s.descrvalor).FirstOrDefault();
                            var temp = getNuevoTemp_CompraVentaPrecAdq(plantilla.CodigoIc, null, pro09Temp);
                            listaTmp.Add(temp);
                        }
                    }

                

                
                //Tenemos que hacer una comprobación final
                //Con cada venta, si el elemento superior (la fecha anterior de algún movimiento con ese mismo isin)
                //es compra ==> lo mostramos. En caso contrario no mostramos ninguno de los dos elementos. Los 
                //eliminamos de la lista

                var listacv = listaTmp.Where(w => w.GetType() == new Temp_CompraVentaPrecAdq().GetType()).Select(s => (Temp_CompraVentaPrecAdq)s);
                    //Creamos esta variable para no modificar la colección mientras realizamos cálculos en foreach
                    var listaEliminar = new List<Temp_CompraVentaPrecAdq>();

                    foreach (var venta in listacv.Where(w => Utils.EqualsIgnoreCase(w.Tipo, "VENTA")))
                    {
                        //Buscamos las operaciones (el resto, las que no sean ventas) para el mismo ISIN
                        //No tenemos en cuenta los que tienen Fecha = null (estos casos son los que mostramos como "Cartera")
                        var oper = listacv.Where(w => !Utils.EqualsIgnoreCase(w.Tipo, "VENTA")
                                                    && Utils.EqualsIgnoreCase(w.Isin, venta.Isin)
                                                    && w.Fecha != null
                                                    && w.Fecha < venta.Fecha).FirstOrDefault();

                        //Si no es compra ==> no lo mostramos
                        if (oper != null
                            && !Utils.EqualsIgnoreCase(oper.Tipo, "Cartera")
                            && !Utils.EqualsIgnoreCase(oper.Tipo, "COMPRA")
                            && !Utils.EqualsIgnoreCase(oper.Tipo, "AMPLIACION")
                            && !Utils.EqualsIgnoreCase(oper.Tipo, "EQUIPARACION")
                            && !Utils.EqualsIgnoreCase(oper.Tipo, "TRASPASO")
                            )
                        {
                            listaEliminar.Add(oper);
                            //y tampoco mostramos la VENTA
                            listaEliminar.Add(venta);
                        }
                    }

                    foreach (var itemElim in listaEliminar)
                    {
                        listaTmp.Remove(itemElim);
                    }

                    //Actualizamos con los datos que se hayan modificado alguna vez en la preview
                    //Los datos que se modifiquen en la preview de esta sección deben mantenerse 
                    actualizarConPreview(plantilla, ref listaTmp);

                
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void actualizarPrecioTraspasos(List<usp_gestio_pro_09_Result> traspasos)
        {
            if (traspasos.Count() > 0)
            {
                foreach (var trasp in traspasos)
                {
                    var item = VariablesGlobales.Pro13_Local.Where(w =>
                        w.Isin.ToUpper() == trasp.isin.ToUpper()
                        && w.TipMovO == "601" //TRASPASOS
                        ).FirstOrDefault();

                    if (item != null)
                    {
                        trasp.adquisicion = item.PrecioI * item.CambioI;
                    }
                }
            }
        }

        /// <summary>
        /// Actualizamos con los datos que se hayan modificado alguna vez en la preview. Los datos que se modifiquen en la preview de esta sección deben mantenerse.
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="listaTmp"></param>
        private static void actualizarConPreview(Plantilla plantilla, ref List<TempTableBase> listaTmp)
        {
            var itemsInforme = listaTmp.Where(w => w.GetType() == new Temp_CompraVentaPrecAdq().GetType()).Select(s => (Temp_CompraVentaPrecAdq)s).ToList();
            //var itemsPrev = plantilla.Preview_CompraVentaPrecAdq.ToList();
            var itemsPrev = CompraVentaRespectoPrecioAdquisicion_DA.GetPreviewChanges(plantilla.CodigoIc, _fechaInforme);

            var listaEliminar = new List<Temp_CompraVentaPrecAdq> ();
            var listaAñadir = new List<Temp_CompraVentaPrecAdq>();

            foreach (var itemPrev in itemsPrev)
            {
                var query = itemsInforme.Where(w =>
                    w.Isin.ToUpper() == itemPrev.Isin.ToUpper()
                    && w.Fecha == itemPrev.Fecha
                    && w.Tipo == itemPrev.Tipo                    
                    && w.DescripcionValor == itemPrev.DescripcionValor
                    && w.Adquisicion == itemPrev.Adquisicion
                    ).ToList();

                //La cartera puede venir con un número de títulos para cada fecha
                //es por esto que no tenemos en cuenta el número de títulos para la comparación
                if(itemPrev.Tipo.ToUpper() != "CARTERA")
                {
                    query = query.Where(w => w.Titulos == itemPrev.Titulos).ToList();
                }

                var itemInforme = query.FirstOrDefault();

                if (itemInforme == null)
                {
                    itemInforme = new DataModels.Temp_CompraVentaPrecAdq();
                }

                if (itemPrev.IsVisible)
                {
                    decimal? titulosNew = null;
                    //CASO: se ha modificado el número de títulos en un ítem CARTERA
                    //No cogeremos el número de títulos que se modificó, cogeremos 
                    //la diferencia entre los que había y los que pusimos manualmente
                    //y se lo añadiremos a los títulos que nos vienen del PROC para este ítem
                    if (itemPrev.Tipo.ToUpper() == "CARTERA")
                    {
                        var diferencia = itemPrev.TitulosNew - itemPrev.Titulos;
                        if(diferencia != null)
                        {
                            //Cogemos itemPrev.Titulos, porque si los títulos se modificaron, no habremos encontrado ninguna coincidencia
                            titulosNew = itemInforme.Titulos + diferencia;
                        }
                    }

                    //Actualizamos nuestro resultado con lo que teníamos almacenado de alguna vez en la preview
                    //Vale para el caso de que hubiera sido un item modificado o añadido en la Preview
                    Utils.CopyPropertyValues(itemPrev, itemInforme);

                    if (titulosNew != null)
                    {
                        itemInforme.TitulosNew = titulosNew;
                    }
                    //itemPrev.CodigoIC
                    //itemInforme.IsinNew = itemPrev.IsinNew;
                    //itemInforme.FechaNew = itemPrev.FechaNew;
                    //itemInforme.TipoNew = itemPrev.TipoNew;
                    //itemInforme.TitulosNew = itemPrev.TitulosNew;
                    //itemInforme.DescripcionValorNew = itemPrev.DescripcionValorNew;
                    //itemInforme.AdquisicionNew = itemPrev.AdquisicionNew;

                    if (itemPrev.Added)
                    {
                        listaAñadir.Add(itemInforme);
                    }
                }
                else
                {
                    listaEliminar.Add(itemInforme);
                }
            }
            //Borramos de la lista que se va a mostrar en el informe (listaTmp)
            //los que se han eliminado en la Preview
            listaTmp.RemoveAll(w => listaEliminar.Contains(w));
            //Añadimos los que se insertaron nuevos desde la Preview
            listaTmp.AddRange(listaAñadir);
        }

        private static Temp_CompraVentaPrecAdq getNuevoTemp_CompraVentaPrecAdq(string codigoIC, string isinPlantilla, usp_gestio_pro_09_Result item)
        {
            Temp_CompraVentaPrecAdq tmp = new Temp_CompraVentaPrecAdq();

            //Como esta sección almacena los cambios que se realizan en la Preview tenemos que rellenar los campos New también.
            //Cuando tengamos listaTmp completa para esta sección actualizaremos los campos New con los que tengamos guardados en su tabla
            tmp.CodigoIC = codigoIC;
            //tmp.IsinPlantilla = isinPlantilla.ToUpper();
            tmp.Isin = item.isin.ToUpper();
            tmp.IsinNew = item.isin.ToUpper();
            //Fecha es NULL cuando sea Cartera
            if (!item.tipo.Equals("Cartera"))
            {
                tmp.Fecha = item.fecha;
                tmp.FechaNew = item.fecha;
            }
            tmp.Tipo = item.tipo;
            tmp.TipoNew = item.tipo;
            tmp.Titulos = item.titulos;
            tmp.TitulosNew = item.titulos;
            tmp.DescripcionValor = item.descrvalor;
            tmp.DescripcionValorNew = item.descrvalor;
            tmp.Adquisicion = item.adquisicion;
            tmp.AdquisicionNew = item.adquisicion;
            //Este cálculo ahora lo hacemos en los procedimientos de la base de datos que utilizamos en el Report
            //No cogemos el efectivo del procedimiento, lo calculamos
            //if (item.adquisicion != null)
            //{
            //    tmp.Efectivo = item.titulos * item.adquisicion * (-1);
            //    if (tmp.Efectivo != null)
            //    {
            //        tmp.Efectivo = decimal.Round(Common.ToDecimal(tmp.Efectivo), 0);
            //    }
            //}
             
            return tmp;
        }

        public static Report GetReport(string codigoIC, string isin)
        {
            //Report rep = new ReportCompraVentaRespectoPrecioAdquisicion(isin, codigoIC);
            Report rep = new ReportCompraVenta();
            
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            //rep.ReportParameters["Fecha"].Value = fecha;

            return rep;
        }

    }
}
