using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoComposicionCarteraRF;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{    
    public static class GraficoCompCartRF_VM
    {
        private static List<RatingsEquivalencia> _ratingsEq = new List<RatingsEquivalencia>();
        private enum ratings
        {
            SP,
            Fitch,
            Moodys
        };
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                _ratingsEq = GraficoCompCartRF_DA.GetRatingsEquivalencias();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    var pro11Result = Reports_DA.GetPRO11_RF_VAL();
                    if (pro11Result != null)
                    {
                        foreach (var item in pro11Result)
                        {
                            //var datosIsin = dbContext.Instrumentos_Importados.Where(i => i.ISIN == item.isin).FirstOrDefault();
                            var datosIsin = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(item.isin);
                            if (datosIsin != null && item.efeact > 0)
                            {
                                Temp_GraficoCompCarteraRF graficoCompCarteraRFTemp = new Temp_GraficoCompCarteraRF();
                                //Copiamos el contenido de pro04Result en pro04temp
                                //Para este caso buscamos la categoría que tengamos asignada a este sector en la tabla 
                                graficoCompCarteraRFTemp.Categoria = GraficoCompCartRF_DA.GetCategoriaBySector(datosIsin.Instrumentos_Sectores.Descripcion);
                                graficoCompCarteraRFTemp.CodigoIC = plantilla.CodigoIc;
                                graficoCompCarteraRFTemp.Divisa = item.div;
                                graficoCompCarteraRFTemp.Empresa = datosIsin.Instrumentos_Empresas.Descripcion;
                                //graficoCompCarteraRFTemp.Isin = isin.Isin;
                                graficoCompCarteraRFTemp.Isin = item.isin;
                                graficoCompCarteraRFTemp.Patrimonio = item.efeact;
                                graficoCompCarteraRFTemp.Pais = datosIsin.Instrumentos_Paises.Descripcion;
                                graficoCompCarteraRFTemp.Sector = datosIsin.Instrumentos_Sectores.Descripcion;

                                //vencimiento
                                var vto = item.diasvto;
                                //if(vto == null || vto < 30)
                                if (vto == null)
                                {
                                    //IIC's RF
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.VtoIIC;
                                }
                                else if (vto < 360)
                                {
                                    //< 1 año
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto1Año;
                                }
                                else if (vto < 720)
                                {
                                    //1-2 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto2Años;
                                }
                                else if (vto < 1080)
                                {
                                    //2-3 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto3Años;
                                }
                                else if (vto < 1800)
                                {
                                    //3-5 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto5Años;
                                }
                                else if (vto < 2520)
                                {
                                    //5-7 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto7Años;
                                }
                                else if (vto < 3600)
                                {
                                    //7-10 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.Vto10Años;
                                }
                                else
                                {
                                    //>10 años
                                    graficoCompCarteraRFTemp.Vencimiento = Resources.Resource.VtoMas10Años;
                                }


                                graficoCompCarteraRFTemp.Rating = getRating(datosIsin.ISIN);

                                listaTmp.Add(graficoCompCarteraRFTemp);
                            }
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Con el ISIN proporcionado recuperaremos de la tabla de Bloomberg la información de los ratings
        /// y lo parsearemos con la tabla RatingsEquivalencias para devolver un rating válido
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        private static string getRating(string isin)
        {
            //Si no tiene ninguno de los 3 ratings informados lo clasificamos como "SIN RATING"
            string output = string.Empty;

            var bloom = VariablesGlobales.Bloomberg_Local.Where(w => Utils.EqualsIgnoreCase(w.ISIN, isin)).FirstOrDefault();

            if(bloom != null)
            {
                var fechas = new List<DateTime?>() { bloom.SPDate, bloom.FitchDate, bloom.MoodyDate};
                //fechas = fechas.Where(w => w.Value != null).OrderByDescending(o => o.Value);
                fechas = fechas.Where(w => w.HasValue).OrderByDescending(o => o.Value).ToList();
                //fechas = fechas.Where(w => w.Value != null).OrderByDescending(o => o.Value).ToList();
                //En vez de coger la máxima fecha las ordenamos y vamos recorriendo desde la más reciente
                //hasta que encontremos una con rating                

                //Cogeremos el rating que tenga la fecha más reciente
                //en caso de que varios tengan la misma fecha tendremos en cuenta las prioridades
                if (fechas.Count() > 0)
                {
                    foreach (var fecha in fechas)
                    {
                        //Lo hacemos hasta que uno de los 3 ratings esté informado (puede que ninguno lo esté
                        if (string.IsNullOrEmpty(output))
                        {
                            //la prioridad de ratings es: S&P, Fitch y Moody's
                            if (fecha == bloom.SPDate && !string.IsNullOrEmpty(bloom.SPRating))
                                output = getEquivalenciaRating(ratings.SP, bloom.SPRating);
                            else if (fecha == bloom.FitchDate && !string.IsNullOrEmpty(bloom.FitchRating))
                                output = getEquivalenciaRating(ratings.Fitch, bloom.FitchRating);
                            else if (fecha == bloom.MoodyDate && !string.IsNullOrEmpty(bloom.MoodyRating))
                                output = getEquivalenciaRating(ratings.Moodys, bloom.MoodyRating);
                        }
                    }

                    //En algunos casos tiene fecha pero no tiene rating. 
                    //Si llegados a este punto seguimos sin rating
                    //Buscamos por prioridad
                    if(string.IsNullOrEmpty(output))
                        output = getPrioritario(bloom);
                }
                //Si no tiene fechas cogemos el rating prioritario (el primero que no sea null)
                else
                {
                    output = getPrioritario(bloom);
                }
            }

            //Si no tiene ninguno de los 3 ratings informados lo clasificamos como "SIN RATING"
            if(string.IsNullOrEmpty(output))
                output = Resources.Resource.SinRating;

            return output;
        }

        private static string getPrioritario(DataModels.Bloomberg bloom)
        {
            string output = string.Empty;

            //la prioridad de ratings es: S&P, Fitch y Moody's
            if (!string.IsNullOrEmpty(bloom.SPRating))
                output = getEquivalenciaRating(ratings.SP, bloom.SPRating);
            else if (!string.IsNullOrEmpty(bloom.FitchRating))
                output = getEquivalenciaRating(ratings.Fitch, bloom.FitchRating);
            else if (!string.IsNullOrEmpty(bloom.MoodyRating))
                output = getEquivalenciaRating(ratings.Moodys, bloom.MoodyRating);

            return output;
        }

        private static string getEquivalenciaRating(ratings rating, string equivalencia)
        {
            var output = string.Empty;
            var obj = new RatingsEquivalencia();

            if (!string.IsNullOrEmpty(equivalencia))
            {
                switch (rating)
                {
                    case ratings.SP:
                        obj = _ratingsEq.Where(w => Utils.Equals(w.SP, equivalencia)).FirstOrDefault();
                        
                        break;
                    case ratings.Fitch:
                        obj = _ratingsEq.Where(w => Utils.Equals(w.Fitch, equivalencia)).FirstOrDefault();

                        break;
                    case ratings.Moodys:
                        obj = _ratingsEq.Where(w => Utils.Equals(w.Moody, equivalencia)).FirstOrDefault();

                        break;
                }
            }

            if (obj != null)
                output = obj.Rating;

            return output;
        }




        public static Report GetReportGraficosComposicionCarteraRF(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportCompCartRF(isin, isinDesc, plantilla.CodigoIc);
            //if (isin != null)
            rep.ReportParameters["Isin"].Value = isin;
            //if (plantilla.CodigoIc != null)
                rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            return rep;
        }
    }
}
