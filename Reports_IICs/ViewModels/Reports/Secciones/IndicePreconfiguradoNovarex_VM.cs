using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Reports.IndicePreconfiguradoNovarex;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using Telerik.Reporting;
using System.Linq;
using Reports_IICs.DataAccess.Instrumentos;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public partial class CheckIndicePreconfiguradoNovarex
    {

        public string caso { get; set; }
        public decimal rentabilidadAcumulada { get; set; }
    }

    public static class IndicePreconfiguradoNovarex_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //var indices = IndicePreconfiguradoNovarex_DA.GetIndicesPlantilla(plantilla.CodigoIc);
                var indices = plantilla.Parametros_IndicePreconfiguradoNovarex.ToList();
                //var proRV = Reports_DA.GetPRO11_RV(plantilla.CodigoIc, fecha).ToList();
                //var proRF = Reports_DA.GetPRO11_RF(plantilla.CodigoIc, fecha).ToList();

                //No tenemos en cuenta los DERIVADOS para esta sección
                var proRvSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, "RVA", null, null, null, false, false, true, false).ToList();
                var proRfSinDer = Reports_DA.GetCarteraFiltrada(plantilla.CodigoIc, fecha, "RFI", null, null, null, false, false, true, false).ToList();



                var patrimonioTotal = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, Convert.ToDateTime(fecha));
                decimal rentabilidadAcumulada = 0;
                List<CheckIndicePreconfiguradoNovarex> checkList = new List<CheckIndicePreconfiguradoNovarex>();


                if (patrimonioTotal > 0)
                {
                    //Lo hacemos de la siguiente manera para insertar primero las de IdInstrumento = 1, luego 2 y por último 3

                    //RENTA VARIABLE
                    //var rvMostrado = indices.Where(i => i.Instrumento.Codigo == "RVA");

                    var rvMostrado = indices.Where(i => i.IdInstrumento == "1").ToList();
                    var totalRVMostrado = getTmp(plantilla.CodigoIc, fecha, rvMostrado, patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada, false);
                    /*****JF*/
                    CheckIndicePreconfiguradoNovarex tmpListElement = new CheckIndicePreconfiguradoNovarex();
                    tmpListElement.caso = "totalRVMostrado";
                    tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                    checkList.Add(tmpListElement);
                    /*****JF*/
                    //La RV que mostramos la filtramos por zona
                    //Es por esto que aquí tenemos que excluir la RV que pertenezca a las zonas que mostramos en el report
                    //para agrupar el resto en "RV OTROS"
                    var totalRV = proRvSinDer.Sum(v => v.efeact);
                    if (totalRVMostrado < totalRV)
                    {
                        decimal efeAct = totalRV - totalRVMostrado;
                        string descRV = "RV OTROS";
                        var indiceRV = new Parametros_IndicePreconfiguradoNovarex();
                        indiceRV.Descripcion = descRV;
                        var param = plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();
                        if (param != null && !string.IsNullOrEmpty(param.IndiceRvOtros))
                        {
                            indiceRV.IndiceReferencia = param.IndiceRvOtros;
                            string tipo = "B";//Benchmark
                            var tmp = getNuevoTemp_IndicePreconfiguradoNovarex(plantilla.CodigoIc, efeAct, patrimonioTotal, Convert.ToDateTime(fecha), ref rentabilidadAcumulada, indiceRV, null, tipo);
                            /*****JF*/
                            tmpListElement = new CheckIndicePreconfiguradoNovarex();
                            tmpListElement.caso = "RV OTROS";
                            tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                            checkList.Add(tmpListElement);
                            /*****JF*/
                            listaTmp.Add(tmp);
                        }
                    }

                    //RETORNO ABSOLUTO
                    //getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.Instrumento.Codigo == "RAB"), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada);
                    getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.IdInstrumento == "3").ToList(), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada, false);
                    /*****JF*/
                    tmpListElement = new CheckIndicePreconfiguradoNovarex();
                    tmpListElement.caso = "RETORNO ABSOLUTO";
                    tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                    checkList.Add(tmpListElement);
                    /*****JF*/
                    //RENTA FIJA
                    //var totalRFMostrado = getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.Instrumento.Codigo == "RFI"), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada);
                    var totalRFMostrado = getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.IdInstrumento == "2").ToList(), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada, true);
                    /*****JF*/
                    tmpListElement = new CheckIndicePreconfiguradoNovarex();
                    tmpListElement.caso = "RENTA FIJA";
                    tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                    checkList.Add(tmpListElement);
                    /*****JF*/
                    var totalRF = proRfSinDer.Sum(v => v.efeact);
                    if (totalRFMostrado < totalRF)
                    {
                        decimal efeAct = totalRF - totalRFMostrado;
                        string descRF = "RF OTROS";
                        var indiceRF = new Parametros_IndicePreconfiguradoNovarex();
                        indiceRF.Descripcion = descRF;
                        var param = plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();
                        if (param != null && !string.IsNullOrEmpty(param.IndiceRfOtros))
                        {
                            indiceRF.IndiceReferencia = param.IndiceRfOtros;
                            string tipo = "B";//Benchmark
                            var tmp = getNuevoTemp_IndicePreconfiguradoNovarex(plantilla.CodigoIc, efeAct, patrimonioTotal, Convert.ToDateTime(fecha), ref rentabilidadAcumulada, indiceRF, null, tipo);
                            /*****JF*/
                            tmpListElement = new CheckIndicePreconfiguradoNovarex();
                            tmpListElement.caso = "RF OTROS";
                            tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                            checkList.Add(tmpListElement);
                            /*****JF*/
                            listaTmp.Add(tmp);
                        }
                    }


                    //LOS QUE TENGAN FÓRMULA (DE MOMENTO SÓLO TESORERÍA USD)
                    //getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.IdTipoFormula == 2), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada);                    
                    getTmp(plantilla.CodigoIc, fecha, indices.Where(i => i.Descripcion.Contains("TESORERÍA USD")).ToList(), patrimonioTotal, ref listaTmp, ref rentabilidadAcumulada, false);
                    /*****JF*/
                    tmpListElement = new CheckIndicePreconfiguradoNovarex();
                    tmpListElement.caso = "TESORERÍA USD";
                    tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                    checkList.Add(tmpListElement);
                    /*****JF*/

                    var totalMostrado = listaTmp.OfType<Temp_IndicePreconfiguradoNovarex>().Sum(s => s.Euros);
                    var repo = patrimonioTotal - totalMostrado;
                    var indiceRepo = new Parametros_IndicePreconfiguradoNovarex();
                    indiceRepo.Descripcion = "REPO + TESORERÍA EURO + DEPÓSITOS + OTROS";
                    var parOtros = plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.FirstOrDefault();

                    if (parOtros != null)
                    {
                        var indRef = parOtros.IndiceRepoTesDepOtros;
                        //indiceRepo.IndiceReferencia = "EUR01W";
                        if (!string.IsNullOrEmpty(indRef))
                        {
                            indiceRepo.IndiceReferencia = indRef;
                            string tipo = "B";//Benchmark
                            //var tmpRepo = getNuevoTemp_IndicePreconfiguradoNovarex(plantilla.CodigoIc, isinRepo, "", repo, patrimonioTotal, string.Empty, Convert.ToDateTime(fecha), ref rentabilidadAcumulada);
                            var tmpRepo = getNuevoTemp_IndicePreconfiguradoNovarex(plantilla.CodigoIc, repo, patrimonioTotal, Convert.ToDateTime(fecha), ref rentabilidadAcumulada, indiceRepo, null, tipo);
                            /*****JF*/
                            tmpListElement = new CheckIndicePreconfiguradoNovarex();
                            tmpListElement.caso = "REPO";
                            tmpListElement.rentabilidadAcumulada = rentabilidadAcumulada;
                            checkList.Add(tmpListElement);
                            /*****JF*/
                            listaTmp.Add(tmpRepo);
                        }
                    }

                    //Guardamos el TOTAL del INDEX NOVAREX en la tabla RentabilidadIndiceNovarex
                    IndicePreconfiguradoNovarex_DA.InsertRentabilidadAcumulada(rentabilidadAcumulada, Convert.ToDateTime(fecha), plantilla.CodigoIc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// calculamos efeact
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fecha"></param>
        /// <param name="indices"></param>
        /// <param name="patrimonioTotal"></param>
        /// <param name="listaTmp"></param>
        /// <param name="rentabilidadAcumulada"></param>
        /// <returns></returns>
        private static decimal getTmp(string codigoIC, DateTime? fecha, List<Parametros_IndicePreconfiguradoNovarex> indices, decimal patrimonioTotal, ref List<TempTableBase> listaTmp, ref decimal rentabilidadAcumulada, bool esRF)
        {
            decimal totalMostrado = 0;
            foreach (var indice in indices)
            {
                decimal efeAct = 0;
                string idInstr = null;
                //if(indice.Instrumento != null)
                if (!string.IsNullOrEmpty(indice.IdInstrumento))
                {
                    //codInstr = indice.Instrumento.Codigo;
                    idInstr = indice.IdInstrumento;
                }
                //var cartera = Reports_DA.GetCarteraFiltrada(codigoIC, fecha, codInstr, null, indice.IdInstrumentoZona, null);
                //No tenemos en cuenta los derivados
                if (Instrumentos_DA.GetInstrumentoById(idInstr) != null)
                {
                    var codInstr = Instrumentos_DA.GetInstrumentoById(idInstr).Codigo;

                    //Filtraremos por divisa cuando sean RF
                    //En caso contrario por zona
                    var idsZona = new List<int?>();
                    if (esRF)
                        idsZona = null;
                    else
                        idsZona.Add(indice.IdInstrumentoZona);

                    var cartera = Reports_DA.GetCarteraFiltrada(codigoIC, fecha, codInstr, null, idsZona, null, false, false, true, false);                    

                    //El IdTipoFormula lo tenemos en cuenta para calcular el efeAct
                    if (indice.IdTipoFormula == 1)//Condición
                    {
                        //En este caso tendremos que recuperar los datos que cumplan las 3 condiciones
                        if (!string.IsNullOrEmpty(indice.Divisa) && esRF)
                        {
                            cartera = cartera.Where(p => p.div == indice.Divisa);
                        }

                        efeAct = cartera.Sum(c => c.efeact);
                    }
                    else//Cuenta
                    {
                        //efeAct = Utils.GetSaldoCuenta(codigoIC, string.Empty, indice.Formula, Convert.ToDateTime(fecha));
                        efeAct = Utils.CalculateFormulaCuentas(indice.Formula, codigoIC, string.Empty, Convert.ToDateTime(fecha));
                    }

                    totalMostrado = totalMostrado + efeAct;

                    string tipo = "I";//En principio serán tipo "Índice" menos en los casos de Parametros_IndicePreconfiguradoNovarex_Otros
                    var tmp = getNuevoTemp_IndicePreconfiguradoNovarex(codigoIC, efeAct, patrimonioTotal, Convert.ToDateTime(fecha), ref rentabilidadAcumulada, indice, cartera, tipo);
                    listaTmp.Add(tmp);
                }
            }

            return totalMostrado;
        }

        /// <summary>
        /// aquí es donde se calcula la columna INDEX
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="euros"></param>
        /// <param name="patrimonioTotal"></param>
        /// <param name="fechaInforme"></param>
        /// <param name="rentabilidadAcumulada"></param>
        /// <param name="indice"></param>
        /// <param name="cartera"></param>
        /// <returns></returns>
        private static Temp_IndicePreconfiguradoNovarex getNuevoTemp_IndicePreconfiguradoNovarex(string codigoIC, decimal euros, decimal patrimonioTotal, DateTime fechaInforme, ref decimal rentabilidadAcumulada, Parametros_IndicePreconfiguradoNovarex indice, IEnumerable<usp_gestio_pro_11_Result> cartera, string tipo)
        {
            Temp_IndicePreconfiguradoNovarex tmp = new Temp_IndicePreconfiguradoNovarex();

            DateTime fecha3112 = new DateTime(Convert.ToDateTime(fechaInforme).Year - 1, 12, 31);

            tmp.CodigoIC = codigoIC;
            tmp.Descripcion = indice.Descripcion;
            tmp.Euros = decimal.Round(euros, 2);
            tmp.Porcentaje = Utils.GetPorcentaje(euros, patrimonioTotal);

            if (!string.IsNullOrEmpty(indice.IndiceReferencia))
            {
                if (indice.Descripcion.Contains("TESORERÍA USD"))
                {
                    decimal varCot = 0;
                    //DateTime fecha3112 = new DateTime(Convert.ToDateTime(fechaInforme).Year - 1, 12, 31);

                    var divIni = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, "B", fecha3112).ToList();
                    var divFin = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, "B", fechaInforme).ToList();
                    if (divIni.Count() > 0 && divFin.Count() > 0)
                    {
                        var cotDivIni = divIni.FirstOrDefault().coteur;
                        var cotDivFin = divFin.FirstOrDefault().coteur;
                        //Variación de cotización del índice de referencia
                        varCot = cotDivFin/cotDivIni;
                    }
                    
                    var dias = (fechaInforme - fecha3112).TotalDays;
                    var varTipoCambio = Utils.GetVariacionTipoCambio(indice.Divisa, fecha3112, fechaInforme);
                    //( (1+Variación cot del Benchmark USD01W)*(1+ variación del tipo de cambio)-1)*peso (%) 
                    tmp.IndexNovarex = ((varCot) * (varTipoCambio) -1) * tmp.Porcentaje;
                }
                else if (indice.Descripcion.Contains("REPO + TESORERÍA"))
                {
                    //Variación cot del Benchmark EUR01W* peso (%)
                    //(126,694975 / 126,8414798 - 1) * 3,60 %
                    var varCot = getVariacionCot(indice, fechaInforme, "B", false);
                    var index = (varCot - 1) * tmp.Porcentaje;
                    tmp.IndexNovarex = index;
                }
                else
                {
                    tmp.IndexNovarex = getIndex(indice, fechaInforme, Convert.ToDecimal(tmp.Porcentaje), tipo);
                }

                
            }
            else
            {
                //TOTAL RENTA FIJA DOLAR USA
                if (Utils.EqualsIgnoreCase(indice.Descripcion, "TOTAL RENTA FIJA DÓLAR USA"))
                {
                    

                    //Tir media de la cartera en dólares: efectivo actual *tir correspondiente / sumatorio de efectivo actual de los bonos en dólares
                    decimal numerador = 0;
                    //Tir media de la cartera en dólares: efectivo actual *tir correspondiente/ sumatorio de efectivo actual de los bonos en dólares
                    var carteraRF = cartera.Where(w => w.tipo.Equals("RF"));
                    foreach(var item in carteraRF)
                    {
                        //numerador: efectivo actual *tir correspondiente
                        numerador = numerador + (item.efeact * item.valact);
                    }

                    var sumEfeAct = carteraRF.Sum(s => s.efeact);
                    decimal? tirMedia = null;

                    if(sumEfeAct != 0)
                        tirMedia = numerador / sumEfeAct;

                    var dias = (fechaInforme - fecha3112).TotalDays;
                    var varTipoCambio = Utils.GetVariacionTipoCambio(indice.Divisa, fecha3112, fechaInforme);
                    
                    //%correspondiente sobre el patrimonio*(1+tir media cartera de renta fija en dólares*(días transcurridos desde fecha fin a fecha inicio/365)/100)*(variación del tipo de cambio)-1
                    if(tirMedia != null)
                        tmp.IndexNovarex = tmp.Porcentaje * ((1 + tirMedia * Convert.ToDecimal(dias / 365) / 100) * (varTipoCambio) - 1);                        


                    /*//dias: son los días trascurridos entre el día del informe e inicio de año
                    DateTime firstDay = new DateTime(fechaInforme.Year, 1, 1);
                    decimal dias = Convert.ToDecimal(firstDay.Subtract(fechaInforme).TotalDays);

                    //variació tdc: es la variación de tipo de cambio del dólar desde fecha del 
                    //informe a inicio de año (en porcentaje por ejemplo si el tipo de cambio ha 
                    //pasado de  0,89 euros por cada dólar y al finalizar el informe acaba en 0,92 
                    //entonces el dólar se ha depreciado un 3,37% frente al dólar (0,92/0,89-1)/100)
                    var varTdc = 0;

                    //TIR USD promedio: es la tir ponderada media de la cartera de la renta fija en dólar. 
                    //es un campo que hemos calculado para otras secciones simplemente es hacer el sumatorio 
                    //del efectivo actual de los bonos en moneda dólar multiplicarlo por su respectiva tir 
                    //y luego este monto lo divides por el efectivo actual total de los bonos en dólares.

                    //Lo hacemos igual que en 22 - LISTADO RENTA FIJA NOVAREX
                    var pro = Reports_DA.GetPRO11(codigoIC, fechaInforme).Where(p => p.tipo.Equals("RF") && p.div.Equals("USD")).ToList();
                    var tirUsdProm = pro.Sum(s => s.valact * s.efeact) / pro.Sum(s => s.efeact);

                    //TOTAL RENTA FIJA DOLAR USA: (1 + TIR USD promedio)*d / 365 * (1 + variació tdc)-1
                    var totRfUsd = (1 + tirUsdProm) * dias / 365 * (1 + varTdc) - 1;
                    tmp.IndexNovarex = totRfUsd;
                    */
                }
                //TOTAL RENTA FIJA EURO
                else if (Utils.EqualsIgnoreCase(indice.Descripcion, "TOTAL RENTA FIJA EURO"))
                {
                    decimal numerador = 0;
                    //Tir media de la cartera en dólares: efectivo actual *tir correspondiente/ sumatorio de efectivo actual de los bonos en dólares
                    var carteraRF = cartera.Where(w => w.tipo.Equals("RF"));
                    foreach (var item in carteraRF)
                    {
                        //numerador: efectivo actual *tir correspondiente
                        numerador = numerador + (item.efeact * item.valact);
                    }

                    var sumEfeAct = carteraRF.Sum(s => s.efeact);
                    decimal? tirMedia = null;

                    if (sumEfeAct != 0)
                        tirMedia = numerador / sumEfeAct;
                    var dias = (fechaInforme - fecha3112).TotalDays;

                    //%correspondiente sobre el patrimonio*(tir media cartera de renta fija en euros*(días transcurridos desde fecha fin informe a fecha inicio/365)/100
                    if(tirMedia != null)
                        tmp.IndexNovarex = tmp.Porcentaje * (tirMedia * Convert.ToDecimal(dias / 365)) / 100;

                    /*//dias: son los días trascurridos entre el día del informe e inicio de año
                    DateTime firstDay = new DateTime(fechaInforme.Year, 1, 1);
                    decimal dias = Convert.ToDecimal(firstDay.Subtract(fechaInforme).TotalDays);

                    //Lo hacemos igual que en 22 - LISTADO RENTA FIJA NOVAREX
                    var pro = Reports_DA.GetPRO11(codigoIC, fechaInforme).Where(p => p.tipo.Equals("RF") && p.div.Equals("EUR")).ToList();
                    var tirEurProm = pro.Sum(s => s.valact * s.efeact) / pro.Sum(s => s.efeact);

                    //fórmula --> (1+TIR EUR promedio)*dias/365
                    var totRfEur = (1 + tirEurProm) * dias / 365;
                    tmp.IndexNovarex = totRfEur;*/


                }
                
            }

            if (tmp.IndexNovarex != null)
            {
                rentabilidadAcumulada = rentabilidadAcumulada + Convert.ToDecimal(tmp.IndexNovarex);
            }

            return tmp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="indice"></param>
        /// <param name="fecha"></param>
        /// <param name="porcentajeLinea"></param>
        /// <param name="tipo">B ó I (Benchmark o Índice)</param>
        /// <returns></returns>
        private static decimal? getIndex(Parametros_IndicePreconfiguradoNovarex indice, DateTime fecha, decimal porcentajeLinea, string tipo)
        {            
            if (!string.IsNullOrEmpty(indice.Divisa))
            {
                //Variación de cotización del índice de referencia
                var variacionCot = getVariacionCot(indice, fecha, tipo, true);

                //aquí tenemos que tener en cuenta la DIVISA 
                //debemos encontrar la rentabilidad del euro para estas monedas. Para ello necesitas el tipo 
                //de cambio a principio y fin del informe y hacer la rentabilidad, aquí tienes la formula
                //+((C10/H21)/(B10/I21)-1)*100
                //((indice a final de año/indice a inicio de año)/(divisa a final de año/divisa a inicio de año)-1)*100

                //C10 indice a final de año 
                //h21 a inicio 
                //b10 divisa a final de año 
                //i21 divisa a inicio de año 
                //ese resultado se ha de multplicar por el peso que supone respecto el total del 
                //patrimonio como ya hacíamos.

                DateTime fecha3112 = new DateTime(Convert.ToDateTime(fecha).Year - 1, 12, 31);
                var indIni = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, tipo, fecha3112).ToList();
                var indFin = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, tipo, fecha).ToList();
                var divIni = Reports_DA.GetTipoCambioDivisa(indice.Divisa, fecha3112);
                var divFin = Reports_DA.GetTipoCambioDivisa(indice.Divisa, fecha);
                if (indIni.Count() > 0 && indFin.Count() > 0 && divIni.Count() > 0 && divFin.Count() > 0)
                {
                    var cotIndIni = indIni.FirstOrDefault().cotdiv;
                    var cotIndFin = indFin.FirstOrDefault().cotdiv;
                    var tipoCambioIni = 1 / divIni.FirstOrDefault().TipoCambio;
                    var tipoCambioFin = 1 / divFin.FirstOrDefault().TipoCambio;

                    var index = ((cotIndFin / tipoCambioFin) / (cotIndIni / tipoCambioIni) - 1);
                    index = decimal.Round(index * porcentajeLinea, 3);
                    return index;
                }
                else
                {
                    return null;
                }


            }
            else
            {
                /* true
                "TOTAL RENTA VARIABLE ESPAÑOLA"
                "TOTAL RENTA VARIABLE RESTO ZONA EURO"
                false
                "TOTAL RETORNO ABSOLUTO"
                */

                decimal variacionCot = 0;
                decimal index = 0;
                if (indice.Descripcion.Contains("TOTAL RETORNO ABSOLUTO"))
                {
                    variacionCot = getVariacionCot(indice, fecha, tipo, false);
                    index = decimal.Round((variacionCot-1) * porcentajeLinea, 3);
                }
                else
                {
                    variacionCot = getVariacionCot(indice, fecha, tipo, true);
                    index = decimal.Round(variacionCot * porcentajeLinea, 3)/100;
                }

                
                
                return index;
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indice"></param>
        /// <param name="fecha"></param>
        /// <param name="tipo">B ó I (Benchmark o Índice)</param>
        /// <returns></returns>
        private static decimal getVariacionCot(Parametros_IndicePreconfiguradoNovarex indice, DateTime fecha, string tipo, bool variacionNormal)
        {
            decimal variacionCot = 0;
            DateTime fecha3112 = new DateTime(Convert.ToDateTime(fecha).Year - 1, 12, 31);

            var divIni = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, tipo, fecha3112).ToList();
            var divFin = Reports_DA.GetPRO03(indice.IndiceReferencia, string.Empty, tipo, fecha).ToList();
            if (divIni.Count() > 0 && divFin.Count() > 0)
            {
                decimal cotDivIni = 0;
                decimal cotDivFin = 0;  

                //Para el caso concreto de "TOTAL RETORNO ABSOLUTO", excepcionalmente, no hacemos cambio de divisa
                if(indice.Descripcion.Contains("TOTAL RETORNO ABSOLUTO"))
                {
                    cotDivIni = divIni.FirstOrDefault().cotdiv;
                    cotDivFin = divFin.FirstOrDefault().cotdiv;
                }
                else
                {
                    cotDivIni = divIni.FirstOrDefault().coteur;
                    cotDivFin = divFin.FirstOrDefault().coteur;
                }

                if (variacionNormal)
                {
                    variacionCot = Utils.PorcentajeVariacion(cotDivIni, cotDivFin);
                }
                else
                {
                    variacionCot = cotDivFin / cotDivIni;
                }                
            }

            return variacionCot;
        }

        private static decimal getVariacionTipoCambio(Parametros_IndicePreconfiguradoNovarex indice, DateTime fecha)
        {
            DateTime fecha3112 = new DateTime(Convert.ToDateTime(fecha).Year - 1, 12, 31);

            var proIni = Reports_DA.GetTipoCambioDivisa(indice.Divisa, fecha3112);
            var proFin = Reports_DA.GetTipoCambioDivisa(indice.Divisa, fecha);
            if (proIni.Count() > 0 && proFin.Count() > 0)
            {
                var tipoCambioIni = proIni.FirstOrDefault().TipoCambio;
                var tipoCambioFin = proFin.FirstOrDefault().TipoCambio;


                //Variación de cotización del índice de referencia
                //var variacionCot = Utils.PorcentajeVariacion(cotDivIni, cotDivFin);
                var variacionTipoCambio = tipoCambioFin / tipoCambioIni;
                return variacionTipoCambio;
            }
            else
            {
                return 0;
            }
        }


        public static Report GetReportIndicePreconfiguradoNovarex(string codigoIC)
        {
            Telerik.Reporting.Report rep = new Report_IndicePreconfiguradoNovarex(codigoIC);
            
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            
            return rep;
        }
    }
}