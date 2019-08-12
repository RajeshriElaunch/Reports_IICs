using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Plusvalias_y_Dividendos;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class PlusvaliasDividendos_VM
    {
        private static List<usp_gestio_pro_10_Result> _pro10_dividendos = new List<usp_gestio_pro_10_Result>();
        private static Plantilla _plantilla;
        private static DateTime _fechaInforme;
        private static IEnumerable<Temp_DividendosCobrados> secc16;
        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                _plantilla = plantilla;
                _fechaInforme = fechaInforme;
                DateTime fechaDesde = Utils.GetFechaInicio(plantilla, fechaInforme);

                //var pro10_agrupado = Reports_DA.GetPRO_10(plantilla.CodigoIc, fechaDesde, fechaInforme, Reports_DA.TipoPro10.Dividendo.ToString()).GroupBy(g => g.isin).ToList();
                var pro10Result = Reports_DA.GetPRO10(plantilla.CodigoIc, fechaDesde, fechaInforme, Reports_DA.TipoPro10.Dividendo.ToString()).ToList();
                _pro10_dividendos = pro10Result.Where(w => w.TIPMOV.Equals("Dividendo")).ToList();
                var pro10_ajustes = pro10Result.Where(w => w.TIPMOV.Equals("Ajustes"));

                //Para la Columna PLUSVALÍAS: Primero cogeremos todos los distintos ISINS que cumplan una de las siguientes condiciones:
                //RV + IIC
                //RV + VAL

                secc16 = listaTmp.Where(w => w.GetType() == new Temp_DividendosCobrados().GetType()).Select(s => (Temp_DividendosCobrados)s);

                //Cogemos las plusvalías de la sección 13 (Temp_RentaVariable) y los dividendos de la sección 16 (Temp_DividendosCobrados)
                var obj = listaTmp.Where(w => w.GetType() == new Temp_RentaVariable().GetType()).Select(s => (Temp_RentaVariable)s)
                    .Where(w =>
                            !string.IsNullOrEmpty(w.Descripcion)
                            && w.Grupo != null
                            &&
                            (
                                w.IdInstrumento == "1" && w.IdTipoInstrumento == "1" //RVA y VAL
                                ||
                                w.IdInstrumento == "1" && w.IdTipoInstrumento == "2" //RVA e IIC
                            )
                        ).GroupBy(g => new
                        {
                            g.Isin,
                            g.Descripcion
                        }).Select(s => new 
                        {
                            CodigoIC = plantilla.CodigoIc,
                            Isin = s.Key.Isin.ToUpper(),
                            Descripcion = s.Key.Descripcion,
                            Plusvalias = s.Sum(a => a.BoPTotal),
                            //Dividendos = secc16.Where(w=>w.Isin.ToUpper() == s.Key.Isin.ToUpper()).Sum(su=>su.ImporteBruto) + 
                            Dividendos = calcularDividendos(s.Key.Isin.ToUpper())
                        });


                //Tenemos que comprobar si el título se encuentra en la tabla RentaVariable_Equivalencias (campo NewIsin)
                //var objEquiv = obj.Where(w => VariablesGlobales.RentaVariable_Equivalencias_Local.Select(s => s.NewIsin.ToUpper()).Contains(w.Isin.ToUpper())).ToList();
                //objEquiv.SelectMany((z => z);
                //objEquiv.(z => z).ToList().ForEach(f => f.Dividendos = f.Dividendos + secc16.Where(w => w.Isin.ToUpper() == f.Isin.ToUpper()).Sum(su => su.ImporteBruto));

                foreach (var item in obj)
                {
                    Temp_PlusvaliasDividendos tmp = getNuevoTemp_PlusvaliasDividendos(plantilla.CodigoIc, item.Descripcion, item.Plusvalias, item.Dividendos, item.Isin);
                    listaTmp.Add(tmp);
                }
                
                    //Añadimos un registro con la suma de todos los ajustes (cambiando el signo)
                    //Columna Dividendos
                    var divAj = -pro10_ajustes.Select(s => s.impbru).Sum();
                    //Columna Plusv./Minusv.
                    var cuentas = string.Join("+", PlusvaliasDividendos_DA.GetCuentasAjustes().Select(s => s.Cuenta));
                    var totalCtasAjPlusv = Utils.CalculateFormulaCuentasSignoCambiado(cuentas, plantilla.CodigoIc, string.Empty, fechaInforme);
                var totalPlusvInsertado = obj.Sum(s => s.Plusvalias);
                //var plusvMinusvAj = totalCtasAjPlusv - totalPlusvInsertado;
                //Dice Cristina que lo dejemos comentado y que mostremos blanco. Ponemos plusvMinusvAj=null
                decimal? plusvMinusvAj = null;
                Temp_PlusvaliasDividendos tmpAj = getNuevoTemp_PlusvaliasDividendos(plantilla.CodigoIc, Resources.Resource.PlusvaliasDividendos_VM_Ajustes, plusvMinusvAj, divAj);
                    listaTmp.Add(tmpAj);
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cuando ha habido cambios de ISIN tenemos que sumar los dividendos del ISIN antiguo y los del nuevo
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        private static decimal? calcularDividendos(string isin)
        {
            var dividendosNewIsin = secc16.Where(w => w.Isin.ToUpper() == isin.ToUpper()).Sum(su => su.ImporteBruto);

            decimal dividendosOldIsin = 0;

            var obj = VariablesGlobales.RentaVariable_Equivalencias_Local.Where(w => w.NewIsin.ToUpper() == isin.ToUpper()).FirstOrDefault();

            if (obj != null)
            {
                var oldIsin = obj.OldIsin;
                var imp = secc16.Where(w => w.Isin.ToUpper() == oldIsin.ToUpper()).Sum(su => su.ImporteBruto);
                if (imp != null)
                    dividendosOldIsin = Convert.ToDecimal(imp);
            }


            return dividendosNewIsin + dividendosOldIsin;
        }
        

        //private static decimal? getDividendoByIsin(string isin)
        //{
        //    isin = isin.ToUpper();
        //    var output = _pro10_dividendos.Where(w => w.isin.ToUpper() == isin).Sum(s => s.impbru);
        //    return output;
        //}

        private static Temp_PlusvaliasDividendos getNuevoTemp_PlusvaliasDividendos(string codigoIC, string nombreValor, decimal? plusMin, decimal? dividendosNetos, string isin = null)
        {
            Temp_PlusvaliasDividendos tmp = new Temp_PlusvaliasDividendos();

            tmp.CodigoIC = codigoIC;
            tmp.Isin = isin;
            tmp.NombreValor = nombreValor;            
            tmp.PlusvaliasMinusvalias = plusMin;



            //if (!string.IsNullOrEmpty(isin))
            //{
            //    tmp.DividendosNetos = getDividendoByIsin(isin);
            //}
            //else
            //{
            //    tmp.DividendosNetos = dividendosNetos;
            //}
            tmp.DividendosNetos = dividendosNetos;
            return tmp;
        }

        public static string Validar(Plantilla plantilla)
        {
            string resultado = null;

            //Recuperar el total de la columna PLUSVALÍAS/MINUSVALÍAS
            var totalPluMin = PlusvaliasDividendos_DA.GetTotalPlusvaliasMinusvalias(plantilla.CodigoIc);
            //Recuperar el total de RV
            var totalRV = RentaVariable_DA.GetTotalRV(plantilla.CodigoIc);

            //Examinamos la diferencia
            var diferencia = totalPluMin - totalRV;

            if(diferencia != 0)
            {
                resultado += Environment.NewLine;
                resultado += string.Format(Resource.AlertaPlusvMinusvTotalRV, diferencia);
            }

            return resultado;
        }

        public static Report GetReportPlusvaliasDividendos(string codigoIC, DateTime fecha)
        {
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            sqlDataSource.SelectCommand = "Get_Temp_PlusvaliasDividendos";
            sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);
            Report rep = new Report_PlusvaliasDividendos(fecha);
            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["FechaReporte"].Value = fecha;
            //Report_DividendosCobrados rep = new Report_DividendosCobrados();
            //rep.DataSource = sqlDataSource;

            return rep;
        }

        private struct IsinsConjuntos
        {
            public IsinsConjuntos(int? id, string isin)
            {
                Id_Parametros_PlusvaliasDividendos = id;
                ISIN = isin;
            }

            public int? Id_Parametros_PlusvaliasDividendos { get; private set; }
            public string ISIN { get; private set; }
        }
    }
}
