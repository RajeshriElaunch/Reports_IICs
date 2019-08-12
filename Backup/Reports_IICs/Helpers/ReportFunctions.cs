using Reports_IICs.Resources;
using System;

namespace Reports_IICs.Helpers
{
    public static class ReportFunctions
    {
        public static string Prueba(string name)
        {
            return string.Format("Hello, {0}", name);
        }

        /// <summary>
        /// Ponemos un length fijo para los textos de los pie charts para que se pinten los gráficos con el mismo tamaño
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RecortarLeyenda(string texto)
        {
            int max = 12;
            if(texto.Length > max)
            {
                //Make sure that length won't exceed "texto"
                //restamos 1 porque si hay que recortar queremos poner un punto al final
                int maxLength = Math.Min(texto.Length, max-1);
                texto = texto.Substring(0, maxLength);
                //ponemos un punto al final
                texto += ".";
            }
            else if (texto.Length < max)
            {
                //Rellenamos con espacios por la izquierda
                texto = texto.PadLeft(max, ' ');
            }
            return texto;
        }

        #region Report_RvComprasRealizadasEjercicio

        public static string TituloReport_RvComprasRealizadasEjercicio(int? año)
        {
            return string.Format(Resources.Resource.TituloReport_RvComprasRealizadasEjercicio + " {0}", año.ToString());
        }

        #endregion Report_RvComprasRealizadasEjercicio

        #region ReportPatrimonio_ValorLiquidativoPRO_02
        public static string TituloReportPatrimonio_ValorLiquidativoPRO_02()
        {
            return string.Format(Resources.Resource.TituloReportPatrimonio_ValorLiquidativoPRO_02);
        }

        public static string SubtituloLiquidativoRP_ValorLiquidativo(int? año)
        {
            return string.Format(Resources.Resource.SubtituloLiquidativoRP_ValorLiquidativo + " {0}", año.ToString());
        }


        public static string SubtituloGestionadoRP_ValorLiquidativo(int? año)
        {
            return string.Format(Resources.Resource.SubtituloGestionadoRP_ValorLiquidativo + " {0}", año.ToString());
        }


        #endregion

        #region ReportEvolucionIndicesBenchMarkPRO_03
        public static string TituloReportEvolucionIndicesBenchMarkPRO_03()
        {
            return string.Format(Resources.Resource.TituloReportEvolucionIndicesBenchMarkPRO_03);
           
        }
        #endregion

        #region Report_RentaVariable

        public static string RV_TextoFechaIni(DateTime fechaAñoAnt, string grupo)
        {
            string precio = Resources.Resource.RVCabPrecio;
            string texto = fechaAñoAnt.ToShortDateString();

            //if(grupo.Contains("-03") || grupo.Contains("-04"))
            if (grupo.Contains("3") || grupo.Contains("4"))
            {
                texto = Resources.Resource.RVCabCompra;
            }

            return string.Format(precio + " {0}", texto);
        }

        #endregion

        #region ReportOperacionesRentaVariable_II
        public static string TituloReportOperacionesRentaVariable_II()
        {
            return string.Format(Resources.Resource.TituloReportOperacionesRentaVariable_II);

        }
        #endregion

        #region Report_DistribucionPatrimonioNovarex
        public static string TituloReport_DistribucionPatrimonioNovarex()
        {
            return string.Format(Resources.Resource.Report_DistribucionPatrimonioNovarex);

        }
        #endregion
        

        #region Report_IndicePreconfiguradoNovarex
        public static string TituloReport_IndicePreconfiguradoNovarex()
        {
            return string.Format(Resources.Resource.Report_IndicePreconfiguradoNovarex);

        }
        #endregion
        
        #region Report_ListadoRentaFijaNovarex
        public static string TituloReport_ListadoRentaFijaNovarex()
        { 
            return string.Format(Resources.Resource.Report_ListadoRentaFijaNovarex);

        }
        #endregion

        #region Report_IIC_VentasEjercicio
        public static string TituloReport_IIC_VentasEjercicio()
        {
            return string.Format(Resources.Resource.Report_IIC_VentasEjercicio);

        }
        #endregion

        #region ReportRentabilidadCarteraV1
        public static string TituloReportRentabilidadCarteraV1()
        {
            return string.Format(Resources.Resource.TituloReportRentabilidadCarteraV1);

        }
        #endregion

        #region ReportEvolucionMercados
        public static string TituloReportEvolucionMercados()
        {
            return string.Format(Resources.Resource.TituloReportEvolucionMercados);

        }
        #endregion


        #region ReportEvolucionRentabilidadGuissona
        public static string TituloReportEvolucionRentabilidadGuissona()
        {
            return string.Format(Resources.Resource.TituloReportEvolucionRentabilidadGuissona);

        }
        #endregion

        #region ReportEvolucionPatrimonioGuissona
        public static string TituloReportEvolucionPatrimonioGuissona()
        {
            return string.Format(Resources.Resource.TituloReportEvolucionPatrimonioGuissona);

        }
        #endregion

        public static string TituloReportPlusvaliasDividendos(DateTime fecha)
        {
            return string.Format(Resources.Resource.TituloReportPlusvaliasDividendos + " " + fecha.Year.ToString());
        }

        public static string TituloReportCarteraRF(DateTime fecha)
        {
            return string.Format(Resources.Resource.TituloReportCarteraRF + " A " + fecha.Year.ToString());
        }

        public static string TituloReportCarteraRF()
        {
            return string.Format(Resources.Resource.TituloReportCarteraRF);
        }

        public static string TituloReportCarteraCcrVolgaGamar()
        {
            return string.Format(Resources.Resource.TituloReportCarteraCcrVolgaGamar);
        }

        #region ReportDividendosCobradosPRO_10

        public static string TituloReportDividendosCobradosPRO_10()
        {
            return string.Format(Resources.Resource.TituloReportDividendosCobradosPRO_10);
        }

        public static string TituloReportCuponesCobrados(int year)
        {
            return string.Format(Resources.Resource.TituloReportCuponesCobrados + " " + year.ToString());
        }

        #endregion

        #region ReportBenchMarkPRO_25
        public static string TituloReportBenchMarkPRO_25()
        {
            return string.Format(Resources.Resource.TituloReportBenchMarkPRO_25);
        }

        #endregion

        #region ReportRentabilidadVariable
        public static string TituloReportRentabilidadVariable()
        {
            return string.Format(Resources.Resource.TituloReportRentabilidadVariable);
        }
        #endregion

        #region ReportRentaFija
        public static string TituloReportRentaFija()
        {
            return string.Format(Resources.Resource.TituloReportRentaFija);
        }

        public static string CabeceraEfectivoIni(Int64 grupo, DateTime fechaIni)
        {
            string textoCab = string.Empty;

            switch(grupo)
            {
                case 1:
                case 2:
                case 3:
                    textoCab = string.Format(Resources.Resource.TextCabeceraEfectivoIniFecha, fechaIni.ToShortDateString());
                    break;

                case 4:
                case 5:
                    textoCab = Resources.Resource.TextCabeceraEfectivoIniNoFecha;
                    break;
            }

            return textoCab;
        }

        public static string CabeceraEfectivoFin(Int64 grupo, DateTime fechaFin)
        {
            string textoCab = string.Empty;

            switch (grupo)
            {
                case 1:
                case 2:
                case 4:
                    textoCab = string.Format(Resources.Resource.TextCabeceraEfectivoFinFechaSinCup, fechaFin.ToShortDateString());
                    break;

                case 3:
                case 5:
                    textoCab = Resources.Resource.TextCabeceraEfectivoFinVtaSinCup;
                    break;
            }

            return textoCab;
        }

        public static string TituloGrupoRF(Int64 grupo, DateTime fechaIni, DateTime fechaFin)
        {
            string output = string.Empty;

            switch(grupo)
            {
                case 1:
                    output = string.Format(Resource.RfGrupo01, fechaIni, fechaFin);
                    break;
                case 2:
                    output = string.Format(Resource.RfGrupo02, fechaIni, fechaFin);
                    break;
                case 3:
                    output = string.Format(Resource.RfGrupo03, fechaIni, fechaFin);
                    break;
                case 4:
                    output = string.Format(Resource.RfGrupo04, fechaIni, fechaFin);
                    break;
                case 5:
                    output = string.Format(Resource.RfGrupo05, fechaFin);
                    break;
                case 6:
                    output = Resource.RfGrupo06;
                    break;
                case 7:
                    output = Resource.RfGrupo07;
                    break;
            }

            return output;
        }
        #endregion

        #region ReportCompraVentaRespectoPrecioAdquisicion
        public static string TituloReportCompraVentaRespectoPrecioAdquisicion()
        {
            return string.Format(Resources.Resource.TituloReportCompraVentaRespectoPrecioAdquisicion);
        }

        public static string ReportPageText()
        {
            return string.Format(Resources.Resource.ReportPageText);
        }

        public static string ReportFromText()
        {
            return string.Format(Resources.Resource.ReportFromText);
        }

        #endregion

        #region VariacionPatrimonialA
        public static string TituloReportVariacionPatrimonialA(DateTime fecha)
        {
            //return string.Format(Resources.Resource.TituloReportVariacionPatrimonialA + " " + fecha.ToShortDateString());
            return string.Format(Resources.Resource.TituloReportVariacionPatrimonialA );
        }

        //public static string VarPatrA_AmpliacReduccCart(string codigoIC, DateTime fechaInforme)
        //{
        //    //var codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
        //    //var fechaInforme = Convert.ToDateTime(this.ReportParameters["FechaInforme"].Value.ToString());
            
        //    var plantilla = Plantillas_DA.GetPlantilla(codigoIC);

        //    //Si es fondo haremos el cálculo con unas cuentas y si es sicav lo haremos con otras
        //    bool esFondo = plantilla.IdTipo == 2 ? true : false;

        //    //Recuperamos las cuentas
        //    var cuentas = VariacionPatrimonialA_DA.GetCuentas(esFondo);
        //    decimal saldo = 0;

        //    var formula = string.Join("] + [", cuentas.Select(s=>s.Cuenta).ToList());
        //    formula = string.Format("{0}" + formula + "{1}", "[", "]");
        //    //foreach (var isin in plantilla.Plantillas_Isins)
        //    //{
        //    foreach (var cuenta in cuentas)
        //    {
        //        DateTime fechaInicio;

        //        //Si la cuenta empieza por 6 o por 7 no tendremos que hacer la diferencia del periodo
        //        //Cogemos saldo a fechaInforme
        //        if (cuenta.Cuenta.StartsWith("6") || cuenta.Cuenta.StartsWith("7"))
        //        {
        //            //Recuperamos el saldo a fechaInforme
        //            var tmp = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInforme);
        //            saldo += tmp;
        //        }
        //        else
        //        {
        //            if (cuenta.Cuenta == "1000401")
        //            {
        //                bool flag = true;
        //            }

        //            fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme), typeof(Temp_VariacionPatrimonialA));

                    

        //            //Hacemos la diferencia entre fecha fin y fecha inicio
        //            var saldoIni = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInicio);
        //            var saldoFin = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInforme);
        //            saldo += saldoFin - saldoIni;
                    

        //            /*
        //            var pro = Reports_DA.GetPRO23(codigoIC, null, cuenta.Cuenta, fechaInicio, fechaInforme);

        //            if (pro != null && pro.Count() > 0)
        //            {
        //                var tmp = pro.FirstOrDefault().impeur != null ? Convert.ToDecimal(pro.FirstOrDefault().impeur) : 0;
        //                saldo += tmp;
        //            }
        //            */
        //        }
        //    }
        //    //}

        //    //Lo formateamos para que muestre separador de miles y no muestre decimales
        //    //Cambiamos el signo
        //    return (-1 * saldo).ToString("N0");            
        //}
        #endregion

        #region Report_VariacionPatrimonialB
        public static string TituloReport_DesgloseGastos()
        {
            return string.Format(Resources.Resource.TituloReport_VariacionPatrimonialTituloReport_DesgloseGastos);
        }

        public static string TextoSuscripcionesAmpliaciones(Int64 tipo)
        {
            string texto = string.Empty;

            if(tipo == 1)   //SICAV                                             
            {
                texto = string.Format(Resources.Resource.TextoAmpliacionesCapitalReduccionesCapitalAutocartera);
            }
            else if (tipo == 2)   //FONDO                                                                                          
            {
                texto = string.Format(Resources.Resource.TextoSuscripcionesReembolsos);
            }
            return texto;
        }

        #endregion



        #region Report_Participes
        public static string TituloReport_Participes()
        {
            return string.Format(Resources.Resource.TituloReport_Participes);
        }

        #endregion


        #region Report_Participes
        public static string TituloReport_RentabilidadCarteraSolemeg()
        {
            return string.Format(Resources.Resource.TituloReport_RentabilidadCarteraSolemeg);
        }

        #endregion

        #region Report_SuscripcionesReembolsos
        public static string TituloReport_SubscripcionesReembolsos(int? año)
        {
            // return string.Format(Resources.Resource.TituloReport_RfComprasVentasEjercicio + " {0}", año.ToString());
            return Resources.Resource.TituloReport_SubscripcionesReembolso.ToString();
        }

        public static string Subtitulo_RelacionReembolsos()
        {
            return Resources.Resource.SuscripcionesReembolsosRep_Reintegros.ToString();
        }
        #endregion Report_SuscripcionesReembolsos

        #region Report_RfComprasVentasEjercicio

        public static string TituloReport_RfComprasVentasEjercicio(int? año)
        {
            return string.Format(Resources.Resource.TituloReport_RfComprasVentasEjercicio+ " {0}", año.ToString());
        }


        


        public static string SubtituloCompras(int? año)
        {
            return string.Format(Resources.Resource.SubTituloComprasRF + " {0}", año.ToString());
        }

        
        public static string SubtituloVentas(int? año)
        {
            return string.Format(Resources.Resource.SubTituloVentasRF + " {0}", año.ToString());
        }

        #endregion Report_RfComprasVentasEjercicio

        #region ReportDistPatrTipodeProducto

        public static string TituloReport_ReportCompCarteraTipodeProducto()
        {
            return Resources.Resource.TituloReportCompCarteraTipodeProducto;
        }

        public static string TituloReport_ReportCompPatrimonioTipodeProducto(string total)
        {
            //return Resources.Resource.TituloReportCompPatrimonioTipodeProducto;
            return string.Format(Resources.Resource.TituloReportCompPatrimonioTipodeProducto + " {0:P2}",Convert.ToDecimal(total)/100);
        }

        public static string TituloReport_ReportExposMercTipoProd(string total)
        {
            //return Resources.Resource.TituloReportCompPatrimonioTipodeProducto;
            return string.Format(Resources.Resource.TituloGrafExposMercTipoProd + " {0:P2}", Convert.ToDecimal(total) / 100);
        }

        #endregion ReportDistPatrTipodeProducto


        #region ReportDistrPatrTipoActivo

        public static string TituloReport_ReportCompPatrimonioTipoActivo(string total)
        {
            return string.Format(Resources.Resource.TituloGrafExposMercTipoAct + " {0:P2}", Convert.ToDecimal(total) / 100);
        }

        public static string TituloReport_ReportExposMercTipoAct(string total)
        {
            //return Resources.Resource.TituloReportCompPatrimonioTipodeProducto;
            return string.Format(Resources.Resource.TituloGrafExposMercTipoAct + " {0:P2}", Convert.ToDecimal(total) / 100);
        }

        #endregion ReportDistrPatrTipoActivo

        public static string TituloReport_DistrPatrimonioTipoProd()
        {
            return string.Format(Resources.Resource.TituloReportCompPatrimonioTipodeProducto);
        }

        public static string TituloReport_GraficoBurbujas()
        {
            return string.Format(Resources.Resource.TituloReportBurbujas);
        }

        public static string TituloSituacionPatrimonialRentabilidad()
        {
            return string.Format(Resources.Resource.TituloSituacionPatrimonialRentabilidad);
        }

        public static string TextoDisclaimer()
        {
            return string.Format(Resources.Resource.Disclaimer);
        }
    }
}
