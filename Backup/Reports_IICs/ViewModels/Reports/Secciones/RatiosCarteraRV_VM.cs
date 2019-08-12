using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.RatiosCarteraRV;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RatiosCarteraRV_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_RatiosCarteraRV> listaTmp = new List<Temp_RatiosCarteraRV>();

                //Esta sección tiene parámetros previos. Tendremos que comprobar que los valores se encuentren entre los rangos que marcan esos parámetros
                var dbContext = new Reports_IICSEntities();
                var param = plantilla.Parametros_RatiosCarteraRV.FirstOrDefault();

                if (param == null)
                {
                    param = new Parametros_RatiosCarteraRV();
                }
                //var pro04Result = dbContext.PRO_04(plantilla.CodigoIc, null, fecha).ToList();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    //if(isin.Descripcion.Contains("TUBO"))
                    //{
                    //    bool flag = true;
                    //}
                    //var pro11RV = Reports_DA.GetPRO11_RV(plantilla.CodigoIc, fecha);
                    //var pro11RV = VariablesGlobales.Pro11_Local.Where(p => VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RVA") && i.Instrumentos_Tipos.Codigo.Equals("VAL")).Select(s => s.ISIN).Contains(p.isin)).ToList();
                    var instrumentosRvVal = VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RVA") && i.Instrumentos_Tipos.Codigo.Equals("VAL")).Select(s => s.ISIN.ToUpper());
                    var pro11RV = VariablesGlobales.Pro11_Local.Where(p => instrumentosRvVal.Contains(p.isin.ToUpper()));
                    //dbContextBia.usp_gestio_pro_11(codigoIC, fecha).Where(p => dbContext.Instrumentos_Importados.Where(i => i.Instrumento.Codigo.Equals("RVA")).Select(s => s.ISIN).Contains(p.isin)).ToList();

                    //asignamos el pro11 en otra variable para que LINQ nos permita recorrerlo
                    var cartRV = pro11RV.ToList();
                    //var cart = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();
                    var cart = VariablesGlobales.Pro11_Local;
                    decimal numTitulosCartera = cartRV.Select(p => p.cantid).Sum();
                    var efeActTotal = cart.Sum(s => s.efeact);

                    foreach (var item in cartRV)
                    {
                     
                        try
                        {
                            var datosBloomberg = VariablesGlobales.Bloomberg_Local.Where(b => b.ISIN.ToUpper() == item.Isin.ToUpper()).FirstOrDefault();
                            if (datosBloomberg != null)
                            {

                                //var datosInstrumentos = dbContext.Instrumentos_Importados.Where(i => i.ISIN == item.isin).FirstOrDefault();
                                var datosInstrumentos = VariablesGlobales.InstrumentosImportados_Local.Where(i => i.ISIN.ToUpper() == item.isin.ToUpper()).FirstOrDefault();
                                Temp_RatiosCarteraRV ratiosCarteraRVTemp = new Temp_RatiosCarteraRV();
                                //Copiamos el contenido de pro04Result en pro04temp
                                ratiosCarteraRVTemp.DescripcionInstrumento = item.descr;

                                var pro03Result = Reports_DA.GetPRO03(item.isin, item.mercado, item.tipo, fecha).FirstOrDefault();
                                //ratiosCarteraRVTemp.Precio = pro03Result.coteur;
                                ratiosCarteraRVTemp.Precio = datosBloomberg.Precio;

                                ratiosCarteraRVTemp.CapitalizacionBursatilEuros = datosBloomberg.Capitalizacion;


                                //decimal numTitulosCartera = listaPro11.Select(p => p.cantid).Sum();
                                /*var porcentCartera = item.cantid * 100 / numTitulosCartera;
                                decimal porcentCarteraRounded = decimal.Round(porcentCartera, 2);
                                ratiosCarteraRVTemp.PorcentajeCartera = porcentCarteraRounded;*/
                                //Es el peso del EfectivoActual en el EfectivoActual Total
                                //OJO: NO COGER TPC1 --> VIENE MAL

                                //Hacemos el cálculo sobre el total de la cartera, no sobre el total de la cartera de RV                            
                                //var porcCart = (item.efeact * 100) / efeActTotal;
                                //Cogemos el total filtrando por RV la cartera del PRO11, no comparando con nuestros instrumentos
                                var totalTPC2_RV = cartRV.Sum(s => s.TPC2);
                                var porcCart = totalTPC2_RV != 0 ? (item.TPC2 * 100) / totalTPC2_RV : null;

                                ratiosCarteraRVTemp.PorcentajeCartera = Convert.ToDecimal(porcCart);

                                if (datosInstrumentos.IdSector != null)
                                {
                                    var isinsSector = InstrumentosImportados_DA.GetIsinsSector(Convert.ToInt32(datosInstrumentos.IdSector));
                                    decimal numTitulosSector = cartRV.Where(w => isinsSector.Contains(w.isin)).Select(p => p.cantid).Sum();
                                    var porcentSector = numTitulosSector != 0 ? item.cantid * 100 / numTitulosSector : 0;
                                    decimal porcentSectorRounded = porcentSector;
                                    ratiosCarteraRVTemp.PorcentajeSector = porcentSectorRounded;
                                    ratiosCarteraRVTemp.Sector = datosInstrumentos.Instrumentos_Sectores.Descripcion;
                                }

                                DateTime fUltimoDiaAñoAnterior = new DateTime(Convert.ToDateTime(fecha).Year - 1, 12, 31);

                                ratiosCarteraRVTemp.CodigoIC = plantilla.CodigoIc;
                                //ratiosCarteraRVTemp.Isin = string.Empty;


                                //var precio3112 = Reports_DA.GetPRO03(item.isin, item.mercado, item.tipo, fUltimoDiaAñoAnterior).FirstOrDefault().coteur;
                                var pro03_3112 = Reports_DA.GetPRO03(item.isin, item.mercado, item.tipo, fUltimoDiaAñoAnterior).FirstOrDefault();
                                var pro03_cotAct = Reports_DA.GetPRO03(item.isin, item.mercado, item.tipo, fecha).FirstOrDefault();
                                if (pro03_3112 != null)
                                {
                                    #region ValorAñoInforme
                                    var coteur3112 = pro03_3112.coteur;
                                    if (coteur3112 != 0)
                                    {
                                        var precioCotizActual = pro03_cotAct.coteur != null ? pro03_cotAct.coteur : 0;
                                        ratiosCarteraRVTemp.ValorAñoInforme = ((precioCotizActual * 100) / coteur3112) - 100;
                                    }
                                    #endregion ValorAñoInforme
                                }
                                if (pro03_cotAct != null)
                                {
                                    #region ValorAdquisicion
                                    if (pro03_cotAct.coteur != null)
                                    {
                                        //var precioCoste = item.efecos;
                                        //var precioCotizActual = pro03_cotAct.coteur != null ? pro03_cotAct.coteur : 0;
                                        //ratiosCarteraRVTemp.ValorAdquisicion = (precioCotizActual * 100) / precioCoste;
                                        var valorAdq = Utils.GetVariacion(item.cosmed, pro03_cotAct.coteur);
                                        ratiosCarteraRVTemp.ValorAdquisicion = valorAdq;
                                    }

                                    #endregion
                                }

                                 decimal? bpaAño = datosBloomberg.ColumnaEstimacion.Equals(1) ? Utils.GetVariacionBpa(datosBloomberg.Bpa0, datosBloomberg.BpaPrevision1) : Utils.GetVariacionBpa(datosBloomberg.BpaPrevision1, datosBloomberg.BpaPrevision2);
                                ratiosCarteraRVTemp.BpaAño = Helpers.Utils.ValidarValorEnRango(bpaAño, param.BpaAñoInformeMinimo, param.BpaAñoInformeMaximo);

                                decimal? bpaPrevision = datosBloomberg.ColumnaEstimacion.Equals(1) ? Utils.GetVariacionBpa(datosBloomberg.BpaPrevision1, datosBloomberg.BpaPrevision2) : Utils.GetVariacionBpa(datosBloomberg.BpaPrevision2, datosBloomberg.BpaPrevision3);
                                ratiosCarteraRVTemp.BpaPrevision = Utils.ValidarValorEnRango(bpaPrevision, param.BpaPrevisionMinimo, param.BpaPrevisionMaximo);

                                decimal? rentabilidadDivAño = datosBloomberg.ColumnaEstimacion.Equals(1) ? datosBloomberg.RentabilidadDividendo1 : datosBloomberg.RentabilidadDividendo2;
                                ratiosCarteraRVTemp.RentabilidadDividendoAño = Utils.ValidarValorEnRango(rentabilidadDivAño, param.RentabilidadesAñoInformeMinimo, param.RentabilidadesAñoInformeMaximo);

                                decimal? rentabilidadDivPrev = datosBloomberg.ColumnaEstimacion.Equals(1) ? datosBloomberg.RentabilidadDividendo2 : datosBloomberg.RentabilidadDividendo3;
                                ratiosCarteraRVTemp.RentabilidadDividendoPrevision = Utils.ValidarValorEnRango(rentabilidadDivPrev, param.RentabilidadesPrevisionMinimo, param.RentabilidadesPrevisionMaximo);

                                decimal? perAño = datosBloomberg.ColumnaEstimacion.Equals(1) ? datosBloomberg.Per1 : datosBloomberg.Per2;
                                ratiosCarteraRVTemp.PerAño = Utils.ValidarValorEnRango(perAño, param.PerAñoInformeMinimo, param.PerAñoInformeMaximo);

                                decimal? perPrevision = datosBloomberg.ColumnaEstimacion.Equals(1) ? datosBloomberg.Per2 : datosBloomberg.Per3;
                                ratiosCarteraRVTemp.PerPrevision = Utils.ValidarValorEnRango(perPrevision, param.PerPrevisionMinimo, param.PerPrevisionMaximo);

                                //No pintamos deuda neta para bancos y seguros (Reunión 08/07/2016)
                                if (datosInstrumentos.IdSector == null || (datosInstrumentos.Instrumentos_Sectores.Id != 1 && datosInstrumentos.Instrumentos_Sectores.Id != 2))
                                {
                                    decimal? deuda = datosBloomberg.DeudaNetaCapitalizacion;
                                    ratiosCarteraRVTemp.DeudaNeta = Utils.ValidarValorEnRango(deuda, param.DeudaNetaCapitalizacionMinimo, param.DeudaNetaCapitalizacionMaximo);
                                }

                                ratiosCarteraRVTemp.PrecioVc = Utils.ValidarValorEnRango(datosBloomberg.PrecioVc, param.PrecioVcMinimo, param.PrecioVcMaximo);
                                ratiosCarteraRVTemp.ValorFundamental = Utils.ValidarValorEnRango(datosBloomberg.ValorFundamental, param.ValorFundamentalMinimo, param.ValorFundamentalMaximo);
                                ratiosCarteraRVTemp.GvcBloomberg = datosBloomberg.GvcBloomberg;
                                var descuentoFundamental = Utils.ValidarValorEnRango(datosBloomberg.DescuentoFundamental, param.DescuentoFundamentalMinimo, param.DescuentoFundamentalMaximo);
                                ratiosCarteraRVTemp.DescuentoFundamental = Convert.ToDecimal(descuentoFundamental);
                                ratiosCarteraRVTemp.NumeroTitulos = item.cantid;

                                ratiosCarteraRVTemp.FechaCotizacion = pro03Result != null? pro03Result.Fecha : (DateTime?)null;
                            

                                #region Comprobamos que % cartera sea mayor que el valor mínimo configurado en parametros
                                var checkParamIfMinValue = plantilla.Parametros_RatiosCarteraRV.FirstOrDefault();

                                if (checkParamIfMinValue != null)
                                {
                                    if (ratiosCarteraRVTemp.PorcentajeCartera > checkParamIfMinValue.PorcentajeCarteraMinMostrar
                                        || checkParamIfMinValue.PorcentajeCarteraMinMostrar == null)
                                    {
                                        listaTmp.Add(ratiosCarteraRVTemp);
                                    }

                                }
                                else
                                {
                                    listaTmp.Add(ratiosCarteraRVTemp);
                                }
                                #endregion

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

        public static Report GetReportRatiosCarteraRV(string codigoIC, string isinPlantilla, DateTime fechaInforme)
        {
            Report rep = new Report_RatiosCarteraRV();

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isinPlantilla;
            rep.ReportParameters["Fecha"].Value = fechaInforme;
            rep.ReportParameters["AñoBloomberg"].Value = VariablesGlobales.Bloomberg_Local.FirstOrDefault().Año;
            return rep;
            /*
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            sqlDataSource.SelectCommand = "Get_Temp_RatiosCarteraRV";
            sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);
            sqlDataSource.Parameters.Add("@Isin", System.Data.DbType.String, null);
            sqlDataSource.Parameters.Add("@Fecha", System.Data.DbType.String, null);
            Report_RatiosCarteraRV rep = new Report_RatiosCarteraRV(fecha);
            rep.ReportParameters["Fecha"].Value = fecha;
            rep.DataSource = sqlDataSource;

            return rep;
            */
        }

    }
}
