using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoBurbujas_SmallBig_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    var pro11RV = Reports_DA.GetPRO11_RV(plantilla.CodigoIc, fecha).ToList();

                    decimal numTitulosCartera = pro11RV.Select(p => p.cantid).Sum();

                    foreach (var item in pro11RV)
                    {
                        try
                        {
                            var dbContext = new Reports_IICSEntities();
                            var datosBloomberg = dbContext.Bloombergs.Where(b => b.ISIN == item.isin).FirstOrDefault();
                            if (datosBloomberg != null)
                            {
                                var datosInstrumento = dbContext.Instrumentos_Importados.Where(i => i.ISIN == item.isin).FirstOrDefault();
                                var pro03Result = Reports_DA.GetPRO03(item.isin, item.mercado, item.tipo, fecha).FirstOrDefault();
                                var tmp = getTemp(plantilla.CodigoIc, item, datosBloomberg, datosInstrumento, pro03Result.Fecha);
                                listaTmp.Add(tmp);
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

        public static Temp_Burbujas getTemp(string codigoIC, usp_gestio_pro_11_Result item, DataModels.Bloomberg datosBloomberg, Instrumentos_Importados datosInstr, DateTime fechaCotizacion)
        {
            var tmp = new Temp_Burbujas();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = datosInstr.ISIN;
            tmp.DescripcionInstrumento = item.descr;
            tmp.CapitalizacionBursatilEuros = datosBloomberg.Capitalizacion;
            tmp.PorcentajeCartera = item.TPC1;
            tmp.DescuentoFundamental = datosBloomberg.DescuentoFundamental;
            tmp.FechaCotizacion = fechaCotizacion;
            tmp.TickerBloomberg = datosInstr.TickerBloomberg;
            tmp.PuntuacionSmallBig = datosInstr.PuntuacionSmallBig;
            tmp.PuntuacionUta = datosInstr.PuntuacionUta;
            tmp.PuntuacionValueGrowth = datosInstr.PuntaucionValueGrowth;
            tmp.Visible = true; //por defecto siempre True

            return tmp;
        }
    }
}
