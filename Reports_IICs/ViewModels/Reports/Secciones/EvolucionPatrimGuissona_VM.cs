using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Evolución.Evolución_Patrimonio_Guissona;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class EvolucionPatrimGuissona_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fecha), typeof(Temp_EvolucionPatrGuissonaValLiq));

                #region ValorLiquidativo
                //Tenemos que hacer dos llamadas al procedimiento. Una con fecha inicio y otra con fecha fin
                DateTime fechaFin = Convert.ToDateTime(fecha);
                //List<Temp_EvolucionPatrGuissonaValLiq> listaValLiq = new List<Temp_EvolucionPatrGuissonaValLiq>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    var pro02Fini = Reports_DA.GetPRO02(plantilla.CodigoIc, string.Empty, fechaInicio).FirstOrDefault();
                    Temp_EvolucionPatrGuissonaValLiq pro02tempIni = getNuevoTemp_EvolucionPatrGuissonaValLiq(plantilla.CodigoIc, string.Empty, fechaInicio, pro02Fini.patrimonio, pro02Fini.valliq);

                    var pro02Ffin = Reports_DA.GetPRO02(plantilla.CodigoIc, string.Empty, fechaFin).FirstOrDefault();
                    Temp_EvolucionPatrGuissonaValLiq pro02tempFfin = getNuevoTemp_EvolucionPatrGuissonaValLiq(plantilla.CodigoIc, string.Empty, fechaFin, pro02Ffin.patrimonio, pro02Ffin.valliq);

                    //listaValLiq.Add(pro02tempIni);
                    //listaValLiq.Add(pro02tempFfin);
                    listaTmp.Add(pro02tempIni);
                    listaTmp.Add(pro02tempFfin);
                //}
                #endregion ValorLiquidativo            

                #region IndBench
                List<Temp_EvolucionPatrGuissonaIndBench> listaIndBench = new List<Temp_EvolucionPatrGuissonaIndBench>();
                foreach (var indice in plantilla.Plantillas_Indices_Referencia)
                {
                    var pro03Result_ini = Reports_DA.GetPRO03(indice.Codigo, string.Empty, string.Empty, fechaInicio).FirstOrDefault();
                    var pro03Result_fin = Reports_DA.GetPRO03(indice.Codigo, string.Empty, string.Empty, fecha).FirstOrDefault();

                    if (pro03Result_ini != null && pro03Result_fin != null)
                    {
                        Temp_EvolucionPatrGuissonaIndBench tmp = getNuevoTemp_EvolucionPatrGuissonaIndBench(plantilla.CodigoIc, indice.Codigo, pro03Result_ini, pro03Result_fin);
                        //listaIndBench.Add(tmp);
                        listaTmp.Add(tmp);
                    }
                }
                #endregion IndBench

                #region Rentabilidad

                var añadidos = listaTmp.Where(w => w.GetType() == new Temp_EvolucionPatrGuissonaValLiq().GetType()).Select(s => (Temp_EvolucionPatrGuissonaValLiq)s).ToList();
                var rent = new Temp_EvolucionPatrGuissonaRentabilidad();
                //if (listaValLiq.Count > 0)
                if (añadidos.Count > 0)
                {
                    decimal? ValLiqFin = null;
                    decimal? ValLiqIni = null;

                    //var obj = listaValLiq.OrderByDescending(v => v.Fecha).FirstOrDefault();
                    var obj = añadidos.OrderByDescending(v => v.Fecha).FirstOrDefault();
                    if (obj != null)
                    {
                        ValLiqFin = obj.ValorLiquidativo;
                        //obj = listaValLiq.OrderBy(v => v.Fecha).FirstOrDefault();
                        obj = añadidos.OrderBy(v => v.Fecha).FirstOrDefault();
                        ValLiqIni = obj.ValorLiquidativo;
                    }


                    var rentabilidadNeta = Utils.GetVariacion(ValLiqIni, ValLiqFin);

                    var parametros = EvolucionPatrimGuissona_DA.GetParametrosRentabilidad(plantilla.CodigoIc);
                    if (parametros != null)
                    {
                        rent = getNuevoTemp_EvolucionPatrGuissonaRentabilidad(plantilla, Convert.ToDecimal(rentabilidadNeta), Convert.ToDecimal(parametros.TasaGestionAnual), Convert.ToDecimal(parametros.ComisionDepositaria), Convert.ToDateTime(fecha));
                        listaTmp.Add(rent);
                    }
                }

                #endregion Rentabilidad

                //try
                //{
                //    EvolucionPatrimGuissona_DA.Insert_Temp(plantilla, listaValLiq, listaIndBench, rent);
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

        private static Temp_EvolucionPatrGuissonaValLiq getNuevoTemp_EvolucionPatrGuissonaValLiq(string codigoIC, string isin, DateTime fecha, decimal? patrimonioGestionado, decimal? valorLiquidativo)
        {
            Temp_EvolucionPatrGuissonaValLiq pro02temp = new Temp_EvolucionPatrGuissonaValLiq();

            pro02temp.CodigoIc = codigoIC;
            pro02temp.Isin = isin;
            pro02temp.Fecha = fecha;
            decimal patrimonioGestionadoRounded = decimal.Round(Convert.ToDecimal(patrimonioGestionado), 0);
            pro02temp.PatrimonioGestionado = patrimonioGestionadoRounded;
            pro02temp.ValorLiquidativo = valorLiquidativo;

            return pro02temp;
        }

        private static Temp_EvolucionPatrGuissonaIndBench getNuevoTemp_EvolucionPatrGuissonaIndBench(string codigoIC, string isin, usp_gestio_pro_03_Result pro03_ini, usp_gestio_pro_03_Result pro03_fin)
        {
            Temp_EvolucionPatrGuissonaIndBench tmp = new Temp_EvolucionPatrGuissonaIndBench();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.Descripcion = pro03_fin.Descripcion;
            var cotizaDivDesde = pro03_ini.cotdiv;
            tmp.CotizaDivDesde = cotizaDivDesde;
            var cotizaDivHasta = pro03_fin.cotdiv;
            tmp.CotizaDivHasta = cotizaDivHasta;
            tmp.VarCotizaDivisa = decimal.Round(Utils.PorcentajeVariacion(cotizaDivDesde, cotizaDivHasta), 2);

            var cotizaEurDesde = Convert.ToDecimal(pro03_ini.coteur);
            var cotizaEurHasta = Convert.ToDecimal(pro03_fin.coteur);
            //tmp.VarCotizaEuros = decimal.Round(Utils.PorcentajeVariacion(cotizaEurDesde, cotizaEurHasta), 2);
            tmp.FechaDesde = pro03_ini.Fecha;
            tmp.FechaHasta = pro03_fin.Fecha;

            return tmp;
        }

        private static Temp_EvolucionPatrGuissonaRentabilidad getNuevoTemp_EvolucionPatrGuissonaRentabilidad(Plantilla plantilla, decimal rentabilidadNeta, decimal tasaGestionAnual, decimal comisionDepositaria, DateTime fechaInforme)
        {
            Temp_EvolucionPatrGuissonaRentabilidad tmp = new Temp_EvolucionPatrGuissonaRentabilidad();

            tmp.CodigoIc = plantilla.CodigoIc;
            tmp.RentabilidadNeta = rentabilidadNeta;
            //Tenemos la tasa de gestión ANUAL en los parámetros de la plantilla
            //Calculamos la parte proporcional desde la fecha de inicio
            DateTime fechaInicio = Utils.GetFechaInicio(plantilla, fechaInforme);
            var dias = (fechaInforme - fechaInicio).Days;
            var tasaGestion = dias * tasaGestionAnual / 365;
            //test
            comisionDepositaria = dias * comisionDepositaria / 365;
            //end test
            tmp.TasaGestion = tasaGestion;
            tmp.ComisionDepositaria = comisionDepositaria;

            return tmp;
        }

        public static Report GetReportEvolucionPatrimonioGuissona(Plantilla plantilla, DateTime fechaInicio, DateTime fechaInforme, DateTime fechaCreacion)
        {
            Telerik.Reporting.Report rep = new ReportEvolucionPatriOperacionesRealizadasGuissona(plantilla.CodigoIc, fechaInicio, fechaInforme);
            rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            rep.ReportParameters["FechaInicio"].Value = fechaInicio;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            rep.ReportParameters["FechaCreacion"].Value = fechaCreacion;
            rep.ReportParameters["Isin"].Value = null;//"ES0139957031";
            var valLiq = EvolucionPatrimValorLiq_DA.GetValorLiqFechaInforme(plantilla.CodigoIc, fechaInforme);
            rep.ReportParameters["TAE"].Value = Utils.GetTae(valLiq, fechaInforme, fechaCreacion, Convert.ToDecimal(plantilla.ReferenciaTAE));

            return rep;
        }

        
    }
}
