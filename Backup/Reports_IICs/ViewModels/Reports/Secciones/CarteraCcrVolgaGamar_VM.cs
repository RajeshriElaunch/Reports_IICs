 using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.CarteraCcrVolgaGamar;
using System;
using System.Collections.Generic;
using System.Linq;
 using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class CarteraCcrVolgaGamar_VM
    {
        private static Plantilla _plantilla;
        private static decimal _efecActInsertado = 0;
        private static decimal _tpcPatrimInsertado = 0;
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                _plantilla = plantilla;

                var pro = VariablesGlobales.Pro11_Local;
                _efecActInsertado = 0;
                _tpcPatrimInsertado = 0;

                #region CORE RVA VAL EUR
                var lista = pro.Where(w =>
                                    //w.descr.Contains("BOLSAS")
                                    //|| w.descr.Contains("CORPORAC")
                                    //|| w.descr.Contains("TELEF")
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "CORE"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "VAL"
                                    && w.div.ToUpper() == "EUR"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrCore, Resources.Resource.CcrCoreRvaEur, false, ref listaTmp);
                #endregion

                #region CORE RVA DÓLAR
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "CORE"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "VAL"
                                    && w.div.ToUpper() == "USD"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrCore, Resources.Resource.CcrCoreRvaUsd, false, ref listaTmp);
                #endregion
                //test ACC 06/05/2019 - Start
                #region CORE RVA OTROS
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "CORE"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "VAL"
                                    && w.div.ToUpper() != "USD" 
                                    && w.div.ToUpper() != "EUR"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrCore, Resources.Resource.CcrCoreRvaOtros, false, ref listaTmp);
                #endregion
                //test ACC 06/05/2019 - End
                #region CORE IIC
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "CORE"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "IIC"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrCore, Resources.Resource.CcrCoreFondos, false, ref listaTmp);
                #endregion

                #region TRADING RVA VAL DÓLAR
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "TRADING"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "VAL"
                                    && w.div.ToUpper() == "USD"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrTrading, Resources.Resource.CcrTradingRvaUsd, false, ref listaTmp);
                #endregion

                #region TRADING FONDOS EURO
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "TRADING"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "IIC"
                                    && w.div.ToUpper() == "EUR"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrTrading, Resources.Resource.CcrTradingFondosEur, false, ref listaTmp);
                #endregion

                #region TRADING RVA EURO
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CoreTrading.ToUpper() == "TRADING"
                                    && w.CodInstrumento == "RVA"
                                    && w.CodTipoInstrumento == "VAL"
                                    && w.div.ToUpper() == "EUR"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrTrading, Resources.Resource.CcrTradingRvaEur, false, ref listaTmp);
                #endregion

                #region RENTA VARIABLE MIXTA IIC
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CodInstrumento == "RVM"
                                    && w.CodTipoInstrumento == "IIC"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrRvm, Resources.Resource.CcrRvmFondos, false, ref listaTmp);
                #endregion

                #region RENTA FIJA MIXTA IIC
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)                                    
                                    && w.CodInstrumento == "RFM"
                                    && w.CodTipoInstrumento == "IIC"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrRfm, Resources.Resource.CcrRfmFondos, false, ref listaTmp);
                #endregion                

                #region RENTA FIJA IIC
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CodInstrumento == "RFI"
                                    && w.CodTipoInstrumento == "IIC"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrRfi, Resources.Resource.CcrRfiFondos, false, ref listaTmp);
                #endregion

                #region RENTA FIJA VAL (Emisiones)
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CodInstrumento == "RFI"
                                    && w.CodTipoInstrumento == "VAL"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrRfi, Resources.Resource.CcrRfiEmisiones, false, ref listaTmp);
                #endregion

                #region RETORNO ABSOLUTO IIC
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CodInstrumento == "RAB"
                                    && w.CodTipoInstrumento == "IIC"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrRab, Resources.Resource.CcrRfiFondos, false, ref listaTmp);
                #endregion

                #region LIQUIDEZ - MERCADO MONETARIO
                lista = pro.Where(w =>
                                    !string.IsNullOrEmpty(w.CoreTrading)
                                    && w.CodInstrumento == "MMO"
                                    ).ToList();

                addToTemp(lista, Resources.Resource.CcrLiquidez, Resources.Resource.CcrLiqMmo, false, ref listaTmp);
                #endregion

                #region LIQUIDEZ - TESORERÍA
                var totalPatrimonio = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, fechaInforme);

                lista.Clear();
                //Insertamos tesorería por diferencia
                var temp = new usp_gestio_pro_11_Result();                                
                temp.efeact = totalPatrimonio - _efecActInsertado;
                temp.TPC2 = (1 - _tpcPatrimInsertado)*100;
                lista.Add(temp);
                addToTemp(lista, Resources.Resource.CcrLiquidez, Resources.Resource.CcrLiqTesoreriaOtros, true, ref listaTmp);
                #endregion                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="grupo"></param>
        /// <param name="subgrupo"></param>
        /// <param name="esPatrimonio">La línea de Patrimonio tiene todos los valores nulos menos las 3 últimas columnas</param>
        /// <param name="listaTmp"></param>
        private static void addToTemp(List<usp_gestio_pro_11_Result> lista, string grupo, string subgrupo, bool esPatrimonio, ref List<TempTableBase> listaTmp)
        {
            lista = lista.OrderBy(o => o.descr).ToList();

            foreach (var item in lista)
            {
                var temp = new Temp_CarteraCcrVolgaGamar();

                temp.CodigoIC = _plantilla.CodigoIc;
                temp.Grupo = grupo;
                temp.Subgrupo = subgrupo;
                temp.Valor = esPatrimonio ? null : item.descr;
                temp.Cantidad = esPatrimonio ? (decimal?)null : item.cantid;
                temp.CosteMedio = esPatrimonio ? (decimal?)null : item.cosmed;
                temp.EfectivoCompra = esPatrimonio ? (decimal?)null : item.efecos;
                temp.ValorActual = esPatrimonio ? (decimal?)null : item.valact;
                temp.Plusvalias = esPatrimonio ? (decimal?)null : item.plusva;
                temp.EfectivoActual = item.efeact;

                //"Tesorería y otros" se calcula por diferencia, así que no necesitamos 
                //actualizar _efecActInsertado en este caso
                if (!string.IsNullOrEmpty(item.descr))
                {
                    _efecActInsertado = _efecActInsertado + item.efeact;
                }
                //Lo calculamos igual que en Cartera
                //Para el cálculo del % no tenemos en cuenta los DER
                var EfecActTotal = VariablesGlobales.Pro11_Local.Where(w => w.CodTipoInstrumento != "DER").Sum(s => s.efeact);
                //Es el peso del EfectivoActual en el EfectivoActual Total
                decimal porc = (item.efeact ) / EfecActTotal;
                temp.TPCCartera = porc;
                temp.TPCPatrimonio = item.TPC2/100;
                decimal tpcPat = item.TPC2 != null ? Convert.ToDecimal(item.TPC2/100) : Convert.ToDecimal(0);
                
                //actualizar _efecActInsertado en este caso
                if (!string.IsNullOrEmpty(item.descr))
                {
                    _tpcPatrimInsertado = Convert.ToDecimal(_tpcPatrimInsertado) + tpcPat;
                }
                listaTmp.Add(temp);
            }            
        }

        public static Report GetReport(string codigoIC)
        {
            var rep = new Report_CarteraCcrVolgaGamar();

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            return rep;            
        }
    }
}
