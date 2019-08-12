using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Reports.RentabilidadCarteraSolemeg;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RentabilidadCarteraSolemeg_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                List<string> codsInstrumento = new List<string>();
                codsInstrumento.Add("RAB");
                codsInstrumento.Add("RVA");
                var cart = Reports_DA.GetCarteraFiltrada2(plantilla, fecha, codsInstrumento, null, null, false, false, false, false);
                //Recuperamos datos anteriores guardados en nuestra tabla RentabilidadCarteraSolemeg
                var cartOld = RentabilidadCarteraSolemeg_DA.Get_RentabilidadCarteraSolemeg(plantilla.CodigoIc);

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{

                    //Insertamos todos los que tenemos en la tabla RentabilidadCarteraSolemegs
                    foreach (var itemOld in cartOld)
                    {
                        try
                        {
                            var tmpOld = getTempOld(plantilla.CodigoIc, string.Empty, itemOld, null, cart, true);
                            listaTmp.Add(tmpOld);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    //Ahora recorremos todos los elementos de cartera
                    foreach (var item in cart)
                    {
                        try
                        {
                            //miramos si ya pertenece a cartOld uno con el mismo ISIN y MERCADO
                            var itemInsertado = cartOld.Where(w => w.ISIN.ToUpper() == item.isin.ToUpper() && w.Mercado == item.mercado).FirstOrDefault();
                            bool existia = itemInsertado != null ? true : false;
                            //Insertamos el que viene de cartera restando los títulos que tenemos en RentabilidadCarteraSolemegs
                            if (itemInsertado != null)
                            {
                                item.cantid = item.cantid - itemInsertado.NumeroTitulos;
                                //(Número total de acciones * Coste medio según cartera – Acciones antiguas * Precio compra antiguas ) / Número acciones nuevas
                                //(6500*4,83-5200*3,99)/1300= 8,20
                                var totalAcciones = item.cantid + itemInsertado.NumeroTitulos;
                                if (item.cantid != 0)
                                {
                                    var precioCompra = (totalAcciones * item.cosmed - itemInsertado.NumeroTitulos * itemInsertado.PrecioCompraSolemeg) / item.cantid;
                                    item.cosmed = Convert.ToDecimal(precioCompra); //PrecioCompraSolemeg
                                }
                            }

                            if (item.cantid != 0)
                            {
                                listaTmp.Add(getTemp(plantilla.CodigoIc, string.Empty, item, existia));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Temp_RentabilidadCarteraSolemeg getTemp(string codigoIC, string isinPlantilla, usp_gestio_pro_11_Result item, bool existia)
        {
            Temp_RentabilidadCarteraSolemeg tmp = new Temp_RentabilidadCarteraSolemeg();

            tmp.CodigoIC = codigoIC;
            tmp.IsinPlantilla = isinPlantilla;
            tmp.ISIN = item.isin;
            tmp.Descripcion = item.descr;
            tmp.NumeroTitulos = item.cantid;
            tmp.PrecioCompraOriginal = null;
            tmp.PrecioCompraSolemeg = item.cosmed;
            
            if(existia)
            {
                tmp.PrecioActual = item.valact;
            }
            else
            {
                tmp.PrecioActual = item.efeact / item.cantid;
            }


            //tmp.Vendido = vendido; //los del grupo 4 no están vendidos
            tmp.Grupo = 4;
            tmp.Mercado = item.mercado;
            tmp.CodInstrumento = item.tipo;

            //Recuperamos el pais
            tmp.Pais = InstrumentosImportados_DA.GetPaisInstrumento(item.isin);

            return tmp;
        }

        private static Temp_RentabilidadCarteraSolemeg getTempOld(string codigoIC, string isinPlantilla, RentabilidadCarteraSolemeg item, decimal? efectAct, IEnumerable<usp_gestio_pro_11_Result> cart, bool existia)
        {
            try
            {

                Temp_RentabilidadCarteraSolemeg tmp = new Temp_RentabilidadCarteraSolemeg();

                tmp.CodigoIC = codigoIC;
                tmp.IsinPlantilla = isinPlantilla;
                tmp.ISIN = item.ISIN;
                tmp.Descripcion = item.Descripcion;
                tmp.NumeroTitulos = item.NumeroTitulos;
                tmp.PrecioCompraOriginal = item.PrecioCompraOriginal;
                tmp.PrecioCompraSolemeg = item.PrecioCompraSolemeg;

                var itemActual = cart.Where(w => w.isin.ToUpper().Equals(item.ISIN.ToUpper())
                                        && item.Mercado == w.mercado
                                        ).FirstOrDefault();

                
                //Cuando no esté vendido PrecioActual = efeact/num titulos
                if (!item.Vendido)
                {
                    if (itemActual != null)
                    {
                        if (existia)
                        {
                            //tmp.PrecioActual = itemActual.efeact / item.NumeroTitulos;
                            //Cogemos el número de titulos de la cartera a fecha informe
                            //tmp.PrecioActual = itemActual.efeact / itemActual.cantid;
                            tmp.PrecioActual = itemActual.valact;
                        }
                        else
                        {
                            tmp.PrecioActual = itemActual.efeact / itemActual.cantid;
                        }
                    }
                }
                else
                {
                    tmp.PrecioActual = Convert.ToDecimal(item.PrecioActual);
                }
                tmp.Vendido = item.Vendido;
                tmp.Grupo = item.Grupo;
                tmp.Mercado = item.Mercado;
                var itemCart = cart.Where(w => w.isin.ToUpper().Equals(item.ISIN.ToUpper()) && w.mercado.Equals(item.Mercado)).FirstOrDefault();
                if (itemCart != null)
                {
                    tmp.CodInstrumento = itemCart.tipo;
                }
                //Recuperamos el pais
                tmp.Pais = InstrumentosImportados_DA.GetPaisInstrumento(item.ISIN);

                return tmp;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Report GetReportGraficoRentabilidadCarteraSolemeg(string codigoIC, string isin, DateTime fecha, string isinDesc)
        {
            Telerik.Reporting.Report rep = new Report_RentabilidadCarteraSolemeg();

            //if (isin != null)
                rep.ReportParameters["Isin"].Value = isin;
            //if (codigoIC != null)
                rep.ReportParameters["CodigoIC"].Value = codigoIC;
            return rep;
        }

    }
}
