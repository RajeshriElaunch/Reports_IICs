using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;

namespace Reports_IICs.DataAccess.Reports
{
    public class Reports_DA
    {        
        public static Plantillas_Generaciones GetLastGeneration(string codigoIC)
        {
            var output = new Plantillas_Generaciones();
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Plantillas_Generaciones.Where(p => p.CodigoIC == codigoIC).FirstOrDefault();                
            }

            return output;
        }

        /// <summary>
        /// Guarda la fecha para la que se ha generado el informe y las secciones que tenía la plantilla en el momento de ser generado
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="fecha"></param>
        public static void GuardarDatosGeneracion(Plantilla plantilla, DateTime? fecha)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                try
                {
                    dbContext.Guardar_Datos_Generacion(fecha, plantilla.CodigoIc);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<Temp_EvolucionPatrValLiq> GetTemp_EvolucionPatrValLiq(string codigoIC, string isin, DateTime fecha)
        {
            var output = new List<Temp_EvolucionPatrValLiq>();
            using (var dbContext = new Reports_IICSEntities())
            {
                if (!string.IsNullOrEmpty(isin))
                {
                    output = dbContext.Temp_EvolucionPatrValLiq.Where(p => p.CodigoIc == codigoIC && p.Isin.ToUpper() == isin.ToUpper()).ToList();
                }
                else
                {
                    output = dbContext.Temp_EvolucionPatrValLiq.Where(p => p.CodigoIc == codigoIC).ToList();
                }
            }

            return output;
        }
        public static Instrumentos_Importados GetDatosIsin(string isin)
        {
            var output = new Instrumentos_Importados();
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Instrumentos_Importados.Where(i => i.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();
            }

            return output;
        }

        public static List<Temp_GraficoCompCarteraRV> GetTemp_GraficoCompCarteraRV(string codigoIC, string isin, DateTime fecha)
        {
            var output = new List<Temp_GraficoCompCarteraRV>();
            using (var dbContext = new Reports_IICSEntities())
            {
                //if (string.IsNullOrEmpty(isin))
                //{
                    output = dbContext.Temp_GraficoCompCarteraRV.Where(p => p.CodigoIC == codigoIC).ToList();
                //}
                //else
                //{
                //    output = dbContext.Temp_GraficoCompCarteraRV.Where(p => p.CodigoIC == codigoIC && p.Isin.ToUpper() == isin.ToUpper()).ToList();
                //}
            }

            return output;
        }
        
        public enum TiposComposicionCartera
        {
            Instrumento
        };

        public enum TipoPro10
        {
            Dividendo,
            Cupón
        };

        /// <summary>
        /// Consulta de partícipes. El procedimiento decide ir por cuenta si y solo si el pb1001_cod esta sin datos o es nulo. En cualquier otro caso, hace lo de siempre aunque informaseis la cuenta.
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="dni"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_01_Result> GetPRO01(string codigoIC, string isin, string dni, string tipoCuenta, string codCuenta, DateTime? fecha)
        {
            //El procedimiento decide ir por cuenta si y solo si el pb1001_cod esta sin datos o es nulo. 
            //En cualquier otro caso, va por DNI
            try
            {
                if (isin == null)
                {
                    isin = string.Empty;
                }

                if(string.IsNullOrEmpty(dni))
                {
                    dni = string.Empty;
                }

                if (tipoCuenta == null)
                    tipoCuenta = string.Empty;

                if (codCuenta == null)
                    codCuenta = string.Empty;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pb1001_cod", dni));
                listaParametros.Add(new SqlParameter("@pb2050_cod", tipoCuenta));   //No acepta null
                listaParametros.Add(new SqlParameter("@pb2001_cod ", codCuenta));   //No acepta null
                listaParametros.Add(new SqlParameter("@pb5006_dati", fecha));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_01", listaParametros);
                }

                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_01_Result>(dt);

                return pro;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patrimonio y Valor liquidativo a fecha
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_02_Result> GetPRO02(string codigoIC, string isin, DateTime? fecha)
        {
            List<usp_gestio_pro_02_Result> output = null;

            try
            {                
                using (var dbContextBia = new BASEEntities())
                {
                    while (output == null)
                    {
                        output = dbContextBia.usp_gestio_pro_02(codigoIC, isin, fecha).ToList();
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO02(codigoIC, isin, fecha);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }

            
        }

        /// <summary>
        /// Cotización/Valor liquidativo a fecha
        /// </summary>
        /// <param name="isin"></param>
        /// <param name="mercado"></param>
        /// <param name="tipo"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_03_Result> GetPRO03(string isin, string mercado, string tipo, DateTime? fecha)
        {
            List<usp_gestio_pro_03_Result> output = null;
            try
            {
                //var proc = dbContextBia.usp_gestio_pro_03(isin, mercado, tipo, fecha);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pb3052_cod", mercado));
                listaParametros.Add(new SqlParameter("@ptipo", tipo));
                listaParametros.Add(new SqlParameter("@pdat", fecha));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_03", listaParametros);
                }
                //El procedimiento a veces devuelve "Cotdiv" y otras "cotdiv"
                //Lo normalizamos aquí para que siempre sea "cotdiv" 
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName == "Cotdiv")
                        column.ColumnName = "cotdiv";
                }


                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                output = ConvertFromDataTable<usp_gestio_pro_03_Result>(dt);

                return output;

                //Este proc también se puede utilizar para pedir el tipo de cambio de una divisa
                //procedure[gestio].[usp_gestio_pro_03]
                //@pb3001_cod varchar(500), -> poniendo el codigo de la divisa USD, CHF, …
                //@pb3052_cod varchar(500), -> en blanco
                //@ptipo varchar(500),       -> ‘D’ de divisa
                //@pdat datetime -> a la fecha que querais.

            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO03(isin, mercado, tipo, fecha);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Devuelve el tipo de cambio de una divisa con el euro a una fecha
        /// </summary>
        /// <param name="codDivisa"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_03_TCD_Result> GetTipoCambioDivisa(string codDivisa, DateTime fecha)
        {
            try
            {
                //var dbContextBia = new BASEEntities();
                //return GetPRO03(codDivisa, string.Empty, "D", fecha);
                //var proc = dbContextBia.usp_gestio_pro_03(codDivisa, null, "D", fecha);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb3001_cod", codDivisa));
                listaParametros.Add(new SqlParameter("@pb3052_cod", string.Empty));
                listaParametros.Add(new SqlParameter("@ptipo", "D"));
                listaParametros.Add(new SqlParameter("@pdat", fecha));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_03", listaParametros);
                }
                //Cambiamos el nombre al valor que devuelve para poner un nombre que lo identifique mejor
                dt.Columns["Column1"].ColumnName = "TipoCambio";

                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_03_TCD_Result>(dt);

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cuenta contable a fecha
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="cuentaContable"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DataTable GetPRO06(string codigoIC, string isin, string cuentaContable, DateTime? fecha)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            DataTable dt = null;

            try
            {
                
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                if (string.IsNullOrEmpty(isin))
                {
                    isin = string.Empty;
                }
                listaParametros.Add(new SqlParameter("@PB3001_COD", isin));
                listaParametros.Add(new SqlParameter("@PA1001_COD", cuentaContable));
                listaParametros.Add(new SqlParameter("@pb5006_dat", fecha));
                
                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_06", listaParametros);
                }
                return dt;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    dt = RunStoredProcParams("usp_gestio_pro_12", listaParametros);
                }

                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Suscripciones y reembolsos
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_07_Result> GetPRO07(string codigoIC, string isin, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            try
            {
                //var dbContextBia = new BASEEntities();
                //var proc = dbContextBia.usp_gestio_pro_07(codigoIC, isin, fechaDesde, fechaHasta);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@pb3001_codfon", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaDesde));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaHasta));

                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_07", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_07_Result>(dt);

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patrimonio instrumento a fecha
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isinFondo"></param>
        /// <param name="isinInstrumento"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<decimal?> GetPRO08(string codigoIC, string isinFondo, string isinInstrumento, DateTime? fecha)
        {
            try
            {
                var output = new List<decimal?>();
                using (var dbContextBia = new BASEEntities())
                {
                    output = dbContextBia.usp_gestio_pro_08(codigoIC, isinFondo, isinInstrumento, fecha).ToList();                 
                }
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<usp_gestio_pro_09_Result> GetPRO09(Plantilla plantilla, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var output = new List<usp_gestio_pro_09_Result>();
                using (var dbContextBia = new BASEEntities())
                {
                    output = dbContextBia.usp_gestio_pro_09(plantilla.CodigoIc, fechaDesde, fechaHasta).ToList();

                    //Hacemos esto porque tenemos un campo "Isin" por ser un GenericProcs
                    //y el nombre del campo es diferente al que trae del procedimiento "isin"
                    output.Select(c => { c.Isin = c.isin; return c; }).ToList();
                    //Excluimos como siempre los ISINS de la plantilla, no queremos mostrarlos en el informe
                    output = new List<usp_gestio_pro_09_Result>(Utils.ExcluirIsinsPlantilla(plantilla, output).Cast<usp_gestio_pro_09_Result>());                    
                    //dbContext = new Reports_IICSEntities();
                    //return dbContext.PRO_09(codigoIC, fechaDesde, fechaHasta);
                }
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Petición por tipo entre fechas
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="tipo">"Dividendo" o "Cupon"</param>
        /// <returns></returns>
        public static List<usp_gestio_pro_10_Result> GetPRO10(string codigoIC, DateTime fechaDesde, DateTime fechaHasta, string tipo)
        {
            List<usp_gestio_pro_10_Result> output = null;
            try
            {
                while (output == null)
                {
                    using (var dbContextBia = new BASEEntities())
                    {
                        output = dbContextBia.usp_gestio_pro_10(codigoIC, fechaDesde, fechaHasta, tipo).ToList();
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO10(codigoIC, fechaDesde, fechaHasta, tipo);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Cartera Gala por IC
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_11_Result> GetPRO11(Plantilla plantilla, DateTime? fecha)
        {
            try
            {
                List<usp_gestio_pro_11_Result> output = null;

                while (output == null)
                {
                    using (var dbContextBia = new BASEEntities())
                    {
                        output = dbContextBia.usp_gestio_pro_11(plantilla.CodigoIc, fecha).ToList();
                    }
                }
                //Hacemos esto porque tenemos un campo "Isin" por ser un GenericProcs
                //y el nombre del campo es diferente al que trae del procedimiento "isin"
                output.Select(c => { c.Isin = c.isin; return c; }).ToList();
                //Excluimos como siempre los ISINS de la plantilla, no queremos mostrarlos en el informe
                output = new List<usp_gestio_pro_11_Result>(Utils.ExcluirIsinsPlantilla(plantilla, output).Cast<usp_gestio_pro_11_Result>());

                //Buscamos cada instrumento del procedimiento en los Instrumentos_Importados y añadimos:
                //IdInstrumento
                //IdTipoInstrumento
                foreach (var inst in output)
                {
                    try
                    {
                        var isin = inst.isin.ToUpper().Trim();

                        //Lo ponemos siempre en mayúsculas
                        inst.isin = isin;

                        var obj = VariablesGlobales.InstrumentosImportados_Local.Where(w => w.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                        if (obj != null)
                        {
                            inst.IdInstrumento = obj.IdInstrumento;
                            inst.CodInstrumento = obj.Instrumento.Codigo;
                            inst.IdTipoInstrumento = obj.IdTipoInstrumento;
                            inst.CodTipoInstrumento = obj.Instrumentos_Tipos.Codigo;
                            inst.IdTipoInstrumento2 = obj.IdTipoInstrumento2;
                            inst.CodTipoInstrumento2 = obj.Instrumentos_Tipos1 != null ? obj.Instrumentos_Tipos1.Codigo : null;
                            inst.IdTipoInstrumento3 = obj.IdTipoInstrumento3;
                            inst.CodTipoInstrumento3 = obj.Instrumentos_Tipos2 != null ? obj.Instrumentos_Tipos2.Codigo : null;
                            if (obj.IdCategoria != null)
                            {
                                inst.IdCategoria = obj.IdCategoria;
                                inst.CodCategoria = VariablesGlobales.InstrumentosCategorias_Local.Where(w => w.Id == obj.IdCategoria).First().Codigo;
                            }
                            if (obj.IdEmpresa != null)
                            {
                                inst.IdEmpresa = obj.IdEmpresa;
                                inst.CodEmpresa = VariablesGlobales.InstrumentosEmpresas_Local.Where(w => w.Id == obj.IdEmpresa).First().Codigo;
                            }
                            if (obj.IdZona != null)
                            {
                                inst.IdZona = obj.IdZona;
                                inst.CodZona = VariablesGlobales.InstrumentosZonas_Local.Where(w => w.Id == obj.IdZona).First().Codigo;
                            }
                            inst.Emergente = obj.Emergente;
                            inst.CoreTrading = obj.CoreTrading;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return output;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cartera Gala por IC - RF
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static IEnumerable<usp_gestio_pro_11_Result> GetPRO11_RF(string codigoIC, DateTime? fecha)
        {
            try
            {
                //using (var dbContextBia = new BASEEntities())
                //{

                    var pro11_RF = VariablesGlobales.Pro11_Local.Where(p =>
                    VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RFI")).Select(s => s.ISIN.ToUpper()).Contains(p.isin.ToUpper())).ToList();
                    return pro11_RF;
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetPRO11_RF_VAL()
        {
            try
            {
                //using (var dbContextBia = new BASEEntities())
                //{

                    var instrumentosRvVal = VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RFI") && i.Instrumentos_Tipos.Codigo.Equals("VAL")).Select(s => s.ISIN.ToUpper());
                    var pro11RF_VAL = VariablesGlobales.Pro11_Local.Where(p => instrumentosRvVal.Contains(p.isin.ToUpper())).ToList();
                    return pro11RF_VAL;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetPRO11_RV_VAL()
        {
            try
            {
                //using (var dbContextBia = new BASEEntities())
                //{

                    var instrumentosRvVal = VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RVA") && i.Instrumentos_Tipos.Codigo.Equals("VAL")).Select(s => s.ISIN.ToUpper());
                    var pro11RV_VAL = VariablesGlobales.Pro11_Local.Where(p => instrumentosRvVal.Contains(p.isin.ToUpper())).ToList();
                    return pro11RV_VAL;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cartera Gala por IC - RV
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static IEnumerable<usp_gestio_pro_11_Result> GetPRO11_RV(string codigoIC, DateTime? fecha)
        {
            try
            {
                //using (var dbContextBia = new BASEEntities())
                //{
                    /*
                    var pro11 = dbContextBia.usp_gestio_pro_11(codigoIC, fecha);

                    var isinsPro11 = pro11.Select(s => s.isin).ToList();

                    dbContext = new Reports_IICSEntities();
                    //var isinsRv = dbContext.Instrumentos_Importados.Where(i => pro11.Select(p => p.isin).Contains(i.ISIN) && i.Instrumento.Codigo.Equals("RVA")).Select(s => s.ISIN).ToList();
                    var isinsRv = dbContext.Instrumentos_Importados.Where(i => isinsPro11.Contains(i.ISIN) && i.Instrumento.Codigo.Equals("RVA")).Select(s => s.ISIN).ToList();

                    var pro11RV = dbContextBia.usp_gestio_pro_11(codigoIC, fecha).Where(p => (dbContext.Instrumentos_Importados.Where(i => isinsPro11.Contains(i.ISIN) && i.Instrumento.Codigo.Equals("RVA")).Select(s => s.ISIN)).Contains(p.isin));
                    //var pro11RV = pro11.Where(p => isinsRv.Contains(p.isin));
                    //return pro11RV;*/
                    var pro11_RV = VariablesGlobales.Pro11_Local.Where(p => VariablesGlobales.InstrumentosImportados_Local.Where(i => i.Instrumento.Codigo.Equals("RVA")).Select(s => s.ISIN.ToUpper()).Contains(p.isin.ToUpper())).ToList();
                    return pro11_RV;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetCartera(Plantilla plantilla, DateTime? fecha)
        {
            try
            {
                return GetPRO11(plantilla, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetCarteraFiltrada(string codigoIC, DateTime? fecha, string codInstrumento, string codTipoInstrumento, List<int?> idsZona, string divisa, bool excluirEmergentes, bool soloEmergentes, bool excluirDerivados, bool excluirMMO)
        {
            
            try
            {
                //var dbContextBia = new BASEEntities();
                //dbContext = new Reports_IICSEntities();                
                
                var pro11 = VariablesGlobales.Pro11_Local.ToList();                                

                if (!string.IsNullOrEmpty(codInstrumento))
                {
                    pro11 = pro11.Where(i => i.CodInstrumento == codInstrumento).ToList();
                }

                if (!string.IsNullOrEmpty(codTipoInstrumento))
                {
                    pro11 = pro11.Where(i => i.CodTipoInstrumento == codTipoInstrumento).ToList();
                }

                if (idsZona != null)
                {
                    //pro11 = pro11.Where(i => i.IdZona == idZona).ToList();
                    pro11 = pro11.Where(i => idsZona.Contains(i.IdZona)).ToList();
                }

                if (excluirEmergentes)
                {
                    pro11 = pro11.Where(w => w.Emergente == false).ToList();
                }

                if (soloEmergentes)
                {
                    pro11 = pro11.Where(w => w.Emergente == true).ToList();
                }

                if (excluirDerivados)
                {
                    pro11 = pro11.Where(w => w.CodTipoInstrumento != "DER").ToList();
                }

                if (excluirMMO)
                {
                    pro11 = pro11.Where(i => i.CodInstrumento != "MMO").ToList();
                }
                

                if (!string.IsNullOrEmpty(divisa))
                {
                    pro11 = pro11.Where(w => w.div == divisa).ToList();
                }

                return pro11;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Instrumentos_Importados> FiltrarInstrumentos(List<string> codsInstrumento, List<string> codsTipoInstrumento, int? idZona, string divisa, bool excluirEmergentes, bool soloEmergentes, bool excluirDerivados, bool excluirMMO)
        {

            try
            {
                //using (var dbContext = new Reports_IICSEntities())
                //{
                    List<Instrumentos_Importados> instrImp = VariablesGlobales.InstrumentosImportados_Local;

                    if (codsInstrumento != null)
                    {
                        instrImp = instrImp.Where(i => codsInstrumento.Contains(i.Instrumento.Codigo)).ToList();
                    }

                    if (codsTipoInstrumento != null)
                    {
                        instrImp = instrImp.Where(i => codsTipoInstrumento.Contains(i.Instrumentos_Tipos.Codigo)).ToList();
                    }

                    if (idZona != null)
                    {
                        instrImp = instrImp.Where(i => i.IdZona == idZona).ToList();
                    }

                    if (excluirEmergentes)
                    {
                        instrImp = instrImp.Where(w => w.Emergente == false).ToList();
                    }

                    if (soloEmergentes)
                    {
                        instrImp = instrImp.Where(w => w.Emergente == true).ToList();
                    }

                    if (excluirDerivados)
                    {
                        instrImp = instrImp.Where(w => w.Instrumentos_Tipos.Codigo != "DER").ToList();
                    }

                    if (excluirMMO)
                    {
                        instrImp = instrImp.Where(i => i.Instrumento.Codigo != "MMO").ToList();
                    }

                    return instrImp;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// La diferencia con GetCarteraFiltrada es que permite pasar una lista con codsInstrumento
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fecha"></param>
        /// <param name="codsInstrumento"></param>
        /// <param name="idZona"></param>
        /// <param name="divisa"></param>
        /// <param name="excluirEmergentes"></param>
        /// <param name="soloEmergentes"></param>
        /// <param name="excluirDerivados"></param>
        /// <returns></returns>
        public static IEnumerable<usp_gestio_pro_11_Result> GetCarteraFiltrada2(Plantilla plantilla, DateTime? fecha, List<string> codsInstrumento = null, int? idZona = null, string divisa = null, bool excluirEmergentes = false, bool soloEmergentes = false, bool excluirDerivados = false, bool excluirIsinsPlantilla = false)
        {
            try
            {
                //var dbContextBia = new BASEEntities();
                //dbContext = new Reports_IICSEntities();
                var instrImp = VariablesGlobales.InstrumentosImportados_Local;
                //instrImp = dbContext.Instrumentos_Importados;

                if (codsInstrumento != null)
                {

                    instrImp = instrImp.Where(i => codsInstrumento.Contains(i.Instrumento.Codigo)).ToList();
                }

                if (idZona != null)
                {
                    instrImp = instrImp.Where(i => i.IdZona == idZona).ToList();
                }

                if (excluirEmergentes)
                {
                    instrImp = instrImp.Where(w => w.Emergente == false).ToList();
                }

                if (soloEmergentes)
                {
                    instrImp = instrImp.Where(w => w.Emergente == true).ToList();
                }

                if (excluirDerivados)
                {
                    instrImp = instrImp.Where(w => w.Instrumentos_Tipos.Codigo != "DER").ToList();
                }

                if (excluirIsinsPlantilla)
                {
                    var isins = plantilla.Plantillas_Isins.Select(s => s.Isin.ToUpper());
                    instrImp = instrImp.Where(i => !isins.Contains(i.ISIN.ToUpper())).ToList();
                }

                var pro11 = VariablesGlobales.Pro11_Local.Where(p => instrImp.Select(s => s.ISIN.ToUpper()).Contains(p.isin.ToUpper())).ToList();

                if (!string.IsNullOrEmpty(divisa))
                {
                    pro11 = pro11.Where(w => w.div == divisa).ToList();
                }



                return pro11;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetCarteraFiltrada(string codigoIC, DateTime? fecha, string codInstrumento, string codTipoInstrumento, List<int?> idsZona, string divisa)
        {
            try
            {
                return GetCarteraFiltrada(codigoIC, fecha, codInstrumento, codTipoInstrumento, idsZona, divisa, false, false, false, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<usp_gestio_pro_11_Result> GetCarteraFiltrada(string codigoIC, DateTime? fecha, string codInstrumento, string codTipoInstrumento, bool soloEmergentes)
        {
            try
            {
                return GetCarteraFiltrada(codigoIC, fecha, codInstrumento, codTipoInstrumento, null, null, false, soloEmergentes, false, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Resumen Cartera Gala por IC+ISIn
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DataTable GetPRO12(string codigoIC, string isin, DateTime fecha)
        {
            DataTable dt = null;
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            try
            {                
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fecha));                

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_12", listaParametros);
                }

                return dt;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    dt = RunStoredProcParams("usp_gestio_pro_12", listaParametros);
                }

                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static List<usp_gestio_pro_13_Result> GetPRO13(Plantilla plantilla, DateTime fechaInicio, DateTime fechaFin)
        {
            List<usp_gestio_pro_13_Result> pro = null;
            try
            {
                //var dbContextBia = new BASEEntities();
                //var pro13 = dbContextBia.usp_gestio_pro_13(codigoIC, isin, fechaInicio, fechaFin);

                //dbContext = new Reports_IICSEntities();
                //var proc = dbContext.PRO_13(codigoIC, fechaInicio, fechaFin);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", plantilla.CodigoIc));
                //listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_13", listaParametros);
                }


                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                pro = ConvertFromDataTable<usp_gestio_pro_13_Result>(dt);

                //Excluimos como siempre los ISINS de la plantilla, no queremos mostrarlos en el informe
                pro = new List<usp_gestio_pro_13_Result>(Utils.ExcluirIsinsPlantilla(plantilla, pro).Cast<usp_gestio_pro_13_Result>());

                //Buscamos cada instrumento del procedimiento en los Instrumentos_Importados y añadimos:
                //IdInstrumento
                //IdTipoInstrumento
                foreach (var inst in pro)
                {
                    try
                    {
                        var isin = inst.Isin.ToUpper().Trim();
                        
                        var obj = VariablesGlobales.InstrumentosImportados_Local.Where(w => w.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                        if (obj != null)
                        {
                            inst.IdInstrumento = obj.IdInstrumento;
                            inst.CodInstrumento = obj.Instrumento.Codigo;
                            inst.IdTipoInstrumento = obj.IdTipoInstrumento;
                            inst.CodTipoInstrumento = obj.Instrumentos_Tipos.Codigo;
                            if (obj.IdCategoria != null)
                            {
                                inst.IdCategoria = obj.IdCategoria;
                                inst.CodCategoria = VariablesGlobales.InstrumentosCategorias_Local.Where(w => w.Id == obj.IdCategoria).First().Codigo;
                            }
                            if (obj.IdEmpresa != null)
                            {
                                inst.IdEmpresa = obj.IdEmpresa;
                                inst.CodEmpresa = VariablesGlobales.InstrumentosEmpresas_Local.Where(w => w.Id == obj.IdEmpresa).First().Codigo;
                            }
                            //Al recuperar los datos le pondremos por defecto el que trae
                            inst.GrupoNuevo = Utils.GetGrupoInt(inst.Grupo);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //Formateamos algunos campos
                pro.ForEach(f => f.Isin = f.Isin.ToUpper());
                pro.ForEach(f => f.Grupo = f.Grupo.Trim());

                ////Si hay PrecioAjustado guardado en la sección de RentaVariable, actualizamos los resultados con estos
                //var precAj = RentaVariable_DA.GetPreciosAjustados(_plantilla.CodigoIc);

                //if (precAj.Count() > 0)
                //{
                //    _preciosAj = precAj;
                //}

                /*****************CUANDO QUERAMOS FILTRAR LOS DATOS Y EXPORTARLOS A EXCEL*****************************/
                //IEnumerable<DataRow> query =
                //    from row in dt.AsEnumerable()
                //    let isin = row.Field<string>("Isin")
                //    where isin.Equals("DE0007664039", StringComparison.CurrentCultureIgnoreCase)
                //    select row;

                //DataTable tempTable = query.CopyToDataTable(); // throws an exception if no rows available
                //UtilsExcel.Export2Excel(tempTable);

                /***************************************************/

                //dt = ConvertToDataTable(pro);
                //UtilsExcel.Export2Excel(dt);

                return pro;
            }            
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    pro = GetPRO13(plantilla, fechaInicio, fechaFin);
                }

                if (pro != null)
                {
                    return pro;
                }
                else
                {
                    throw ex;
                }
            }
        }



        /// <summary>
        /// Compras y ventas (Renta Fija)
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_14_Result> GetPRO14(string codigoIC, string isin, DateTime fechaInicio, DateTime fechaFin)
        {
            List<usp_gestio_pro_14_Result> output = null;
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@PB3001_COD", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));

                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_14", listaParametros);
                }

                output = ConvertFromDataTable<usp_gestio_pro_14_Result>(dt);
                return output;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO14(codigoIC, isin, fechaInicio, fechaFin);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }
            /*
            var dbContextBia = new BASEEntities();
            var proc = dbContextBia.usp_gestio_pro_14(codigoIC, isin, fechaInicio, fechaFin);            

            return proc;
            */
        }

        /// <summary>
        /// Gráfico Valor Liquidativo
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_15_Result> GetPRO15(string codigoIC, string isin, DateTime fechaInicio, DateTime fechaFin)
        {
            List<usp_gestio_pro_15_Result> output = null;
            try
            {
                //to call the query recursively till we get a desired result.
                while (output == null)
                {
                    using (var dbContextBia = new BASEEntities())
                    {
                        output = dbContextBia.usp_gestio_pro_15(codigoIC, isin, fechaInicio, fechaFin).ToList();
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO15(codigoIC, isin, fechaInicio, fechaFin);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gráfico de Benchmark
        /// </summary>
        /// <param name="codigoBenchmark"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_16_Result> GetPRO16(string codigoBenchmark, DateTime fechaInicio, DateTime fechaFin)
        {
            List<usp_gestio_pro_16_Result> output = null;

            try
            {
                //to call the query recursively till we get a desired result.
                while (output == null)
                {
                    using (var dbContextBia = new BASEEntities())
                    {
                        //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                        Utils.Sleep(2000); //2 segs
                        output = dbContextBia.usp_gestio_pro_16(codigoBenchmark, fechaInicio, fechaFin).ToList();
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //Estamos teniendo muchos problemas de conexión. Esperamos y volvemos a intentar
                    Utils.Sleep(2000); //2 segs
                    output = GetPRO16(codigoBenchmark, fechaInicio, fechaFin);
                }

                if (output != null)
                {
                    return output;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static List<usp_gestio_pro_17_Result> GetPRO17(string codigoIC, string isin, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                //var dbContextBia = new BASEEntities();
                //var pro13 = dbContextBia.usp_gestio_pro_13(codigoIC, isin, fechaInicio, fechaFin);

                //dbContext = new Reports_IICSEntities();
                //var pro = dbContext.PRO_17(codigoIC, isin, fechaInicio, fechaFin);

                //var dbContextBia = new BASEEntities();
                //var pro = dbContextBia.usp_gestio_pro_17(codigoIC, isin, fechaInicio, fechaFin);

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@PB3001_COD", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_17", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_17_Result>(dt);

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<usp_gestio_pro_19_Result> GetPRO19(string isin, DateTime fechaDesde, DateTime fechaHasta, string tipoCta, string codigoCta)
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaDesde));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaHasta));
                listaParametros.Add(new SqlParameter("@pb2050_cod", tipoCta));
                listaParametros.Add(new SqlParameter("@pb2001_cod", codigoCta));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_19", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_19_Result>(dt);

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Procedimiento para obtener el subyacente de un determinado valor de tipo derivado.
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_20_Result> GetPRO20(string isin)
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_20", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_20_Result>(dt);

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// informació de la Renda fixa. Paràmetres d’entrada iguals que la 13 i els outputs també, PERÒ, la columna NumTit conté el nominal aparellat.
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_21_Result> GetPRO21(Plantilla plantilla, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", plantilla.CodigoIc));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_21", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_21_Result>(dt);

                //Excluimos como siempre los ISINS de la plantilla, no queremos mostrarlos en el informe
                pro = new List<usp_gestio_pro_21_Result>(Utils.ExcluirIsinsPlantilla(plantilla, pro).Cast<usp_gestio_pro_21_Result>());

                /*****************CUANDO QUERAMOS FILTRAR LOS DATOS Y EXPORTARLOS A EXCEL*****************************/
                //IEnumerable<DataRow> query =
                //    from row in dt.AsEnumerable()
                //    let isin = row.Field<string>("Isin")
                //    where isin.Equals("DE0007664039", StringComparison.CurrentCultureIgnoreCase)
                //    select row;

                //DataTable tempTable = query.CopyToDataTable(); // throws an exception if no rows available
                //UtilsExcel.Export2Excel(tempTable);

                //UtilsExcel.Export2Excel(dt);
                /***************************************************/

                //Buscamos cada instrumento del procedimiento en los Instrumentos_Importados y añadimos:
                //IdInstrumento
                //IdTipoInstrumento
                //...
                foreach (var inst in pro)
                {
                    try
                    {
                        var isin = inst.Isin.ToUpper().Trim();
                        var obj = VariablesGlobales.InstrumentosImportados_Local.Where(w => w.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                        if (obj != null)
                        {
                            inst.IdInstrumento = obj.IdInstrumento;
                            inst.CodInstrumento = obj.Instrumento.Codigo;
                            inst.IdTipoInstrumento = obj.IdTipoInstrumento;

                            inst.CodTipoInstrumento = obj.Instrumentos_Tipos.Codigo;
                            if (obj.IdCategoria != null)
                            {
                                inst.IdCategoria = obj.IdCategoria;
                                inst.CodCategoria = VariablesGlobales.InstrumentosCategorias_Local.Where(w => w.Id == obj.IdCategoria).First().Codigo;
                            }
                            if (obj.IdEmpresa != null)
                            {
                                inst.IdEmpresa = obj.IdEmpresa;
                                inst.CodEmpresa = VariablesGlobales.InstrumentosEmpresas_Local.Where(w => w.Id == obj.IdEmpresa).First().Codigo;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Procedimiento para obtener todos los códigos de valor de un fondo/sicav de un periodo determinado.
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public static List<usp_gestio_pro_22_Result> GetPRO22(string codigoIC, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_22", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_22_Result>(dt);

                //Buscamos cada instrumento del procedimiento en los Instrumentos_Importados y añadimos:
                //IdInstrumento
                //IdTipoInstrumento
                //...
                foreach (var inst in pro)
                {
                    try
                    {
                        var isin = inst.b3001_cod.ToUpper().Trim();

                        var obj = VariablesGlobales.InstrumentosImportados_Local.Where(w => w.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                        if (obj != null)
                        {
                            inst.IdInstrumento = obj.IdInstrumento;
                            inst.CodInstrumento = obj.Instrumento.Codigo;
                            inst.IdTipoInstrumento = obj.IdTipoInstrumento;
                            inst.CodTipoInstrumento = obj.Instrumentos_Tipos.Codigo;
                            if (obj.IdCategoria != null)
                            {
                                inst.IdCategoria = obj.IdCategoria;
                                inst.CodCategoria = VariablesGlobales.InstrumentosCategorias_Local.Where(w => w.Id == obj.IdCategoria).First().Codigo;
                            }
                            if (obj.IdEmpresa != null)
                            {
                                inst.IdEmpresa = obj.IdEmpresa;
                                inst.CodEmpresa = VariablesGlobales.InstrumentosEmpresas_Local.Where(w => w.Id == obj.IdEmpresa).First().Codigo;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return pro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Procedimiento para obtener el saldo contable de un fondo/sicav, un valor determinado que ha operado, y un periodo.
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <param name="ctaContable"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        //public static ObjectResult<usp_gestio_pro_23_Result> GetPRO23(string codigoIC, string isin, string ctaContable, DateTime fechaInicio, DateTime fechaFin)
        public static List<usp_gestio_pro_23_Result> GetPRO23(string codigoIC, string isin, string ctaContable, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {   
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(new SqlParameter("@pb4051_cod", codigoIC));
                if (isin == null)
                    isin = string.Empty;
                listaParametros.Add(new SqlParameter("@pb3001_cod", isin));
                listaParametros.Add(new SqlParameter("@pa1001_cod", ctaContable));
                listaParametros.Add(new SqlParameter("@pb5006_dati", fechaInicio));
                listaParametros.Add(new SqlParameter("@pb5006_datf", fechaFin));
                DataTable dt = null;

                //to call the query recursively till we get a desired result.
                while (dt == null)
                {
                    dt = RunStoredProcParams("usp_gestio_pro_23", listaParametros);
                }
                //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
                var pro = ConvertFromDataTable<usp_gestio_pro_23_Result>(dt);
                return pro;
                /*
                var dbContextBia = new BASEEntities();
                var proc = dbContextBia.usp_gestio_pro_23(Convert.ToInt32(codigoIC), isin, ctaContable, fechaInicio, fechaFin);

                return proc;
                */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static List<RatingsEquivalencia> GetRatingsEquivalencias()
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            DataTable dt = RunStoredProcParams_Reports_IICS("Get_RatingsEquivalencias", listaParametros);
            //Utilizamos esto porque EF no reconoce el resultado del proc en nuestro modelo de datos
            var pro = ConvertFromDataTable<RatingsEquivalencia>(dt);
            return pro;            
        }

        public static List<T> ConvertFromDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (!dr.IsNull(column.ColumnName))
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                            else
                            {
                                pro.SetValue(obj, null, null);
                            }
                        
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        //public static void ValidarIsinsInstrumBloomberg(Plantilla plantilla, DateTime? fecha, ref List<string> isinsNotInInstrum, ref List<string> isinsNotInBloomb, List<usp_gestio_pro_11_Result> pro11)
        public static void ValidarIsinsInstrumBloomberg(Plantilla plantilla, ref List<string> isinsNotInBloomb)
        {
            try
            {
                //Ahora vamos a validar que tengamos importados todos los Bloombergs de (RF y VAL) y todos los RV y VAL)
                var inst = GetPRO11_RF_VAL().Select(s => s.isin.ToUpper()).ToList();
                inst.AddRange(GetPRO11_RV_VAL().Select(s => s.isin.ToUpper()).ToList());
                inst = inst.Distinct().ToList();
                var bloom = new List<string>();
                using (var dbContext = new Reports_IICSEntities())
                {
                    bloom = dbContext.Bloombergs.Select(b => b.ISIN.ToUpper()).ToList();
                }
                isinsNotInBloomb = inst.Where(b => !bloom.Any(p => p == b)).ToList();
                isinsNotInBloomb = Utils.ExcluirIsinsPlantilla(plantilla, isinsNotInBloomb);
                /*
                var pro11 = VariablesGlobales.Pro11_Local;

                if (pro11 != null)
                {
                    var pro11Isins = pro11.Select(p => p.isin.ToUpper());
                    var pro11IsinsRV = pro11.Where(w => w.tipo.Equals("RV") || w.tipo.Equals("RF")).Select(p => p.isin.ToUpper());
                    var instr = dbContext.Instrumentos_Importados.Select(i => i.ISIN.ToUpper()).ToList();
                    var bloom = dbContext.Bloombergs.Select(b => b.ISIN.ToUpper()).ToList();

                    //dbContext = new Reports_IICSEntities();
                    //isinsNotInInstrum = pro11Isins.Where(i => !instr.Any(p => p == i)).ToList();
                    //Sólo hay Bloomberg de RV
                    isinsNotInBloomb = pro11IsinsRV.Where(b => !bloom.Any(p => p == b)).ToList();
                    isinsNotInBloomb = Utils.ExcluirIsinsPlantilla(plantilla, isinsNotInBloomb);
                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<int> GetSeccionesConPreviews()
        {
            var output = new List<int>();
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Secciones.Where(s => s.TienePreview).Select(s => s.Id).ToList();                
            }

            return output;
        }

        /// <summary>
        /// run a stored procedure in BIA that takes a parameter
        /// </summary>
        public static DataTable RunStoredProcParams(string nombreProcedimiento, List<SqlParameter> listaParametros)
        {
            try
            {
                //DataTable table = new DataTable();
                var table = new DataTable();
                using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BIA"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(nombreProcedimiento, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            foreach (var param in listaParametros)
                            {
                                cmd.Parameters.Add(param);
                            }
                            cmd.CommandTimeout = 300000; //The time in seconds to wait for the command to execute. The default is 30 seconds.
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(table);
                        }
                    }   // sqlCmd will be properly disposed here
                }       // sqlConn will be properly disposed here
                return table;
            }
            catch (Exception ex)
            {
                //Error en el nivel del transporte al recibir los resultados del servidor. (provider: Session Provider, error: 19 - No se puede utilizar la conexión física)
                if (ex.HResult == -2146232004 || (ex.InnerException != null && ex.InnerException.HResult == -2146232060))
                {
                    //En este caso devolvemos null para que se vuelva a intentar.
                    //Hacemos esto porque el servidor nos da muchos problemas y nos da muchos errores de espera
                    return null;
                }
                else
                {
                    //Recuperamos los procedimientos y sus parámetros
                    throw new Exception(Utils.GetErrorProcAndParams(nombreProcedimiento, listaParametros), ex);
                }
            }
        }
       
        public static DataTable RunStoredProcParams_Reports_IICS(string nombreProcedimiento, List<SqlParameter> listaParametros)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Reports_IICs.Properties.Settings.ReportsIICS_Reports"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(nombreProcedimiento, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            foreach (var param in listaParametros)
                            {
                                cmd.Parameters.Add(param);
                            }
                            cmd.CommandTimeout = 3000; //The time in seconds to wait for the command to execute. The default is 30 seconds.
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(table);
                        }
                    }
                }
                return table;
            }
            catch(Exception ex)
            {
                throw new Exception(Utils.GetErrorProcAndParams(nombreProcedimiento, listaParametros), ex);
            }
        }

        public static Plantillas_Generaciones_Plantilla GetPlantillaGeneracion(string codigoIC)
        {
            var output = new Plantillas_Generaciones_Plantilla();
            //var dbContext = new Reports_IICSEntities();
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Plantillas_Generaciones_Plantilla.Where(p => p.CodigoIc == codigoIC).FirstOrDefault();                
            }

            return output;
        }
        
        public static void GetTemp(Plantilla plantilla, Type ent)
        {
            if(ent == typeof(Temp_RentaVariable))
            {

            }            
        }

        public static int GetTemp_EvolucionPatrGuissona_Count(string codigoIC)
        {
            int output = 0;
            using (var dbContext = new Reports_IICSEntities())
            {
                output += dbContext.Temp_EvolucionPatrGuissonaValLiq.Where(p => p.CodigoIc == codigoIC).Count();
                output += dbContext.Temp_EvolucionPatrGuissonaIndBench.Where(p => p.CodigoIC == codigoIC).Count();
                output += dbContext.Temp_EvolucionPatrGuissonaRentabilidad.Where(p => p.CodigoIc == codigoIC).Count();                
            }

            return output;
        }

        public static int GetTemp_GraficoBurbujas_Count(string codigoIC)
        {
            int output;
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Temp_Burbujas.Where(p => p.CodigoIC == codigoIC).Count();
            }

            return output;
        }      

        public static int GetTemp_Count(string codigoIC, Type tabla)
        {
            return GetTemp_Count(codigoIC, null, tabla);
        }        

        public static int GetTemp_Count(string codigoIC, string isin, Type tabla)
        {
            int cont = 0;
            if(!string.IsNullOrEmpty(isin))
                isin = isin.ToUpper();

            using (var dbContext = new Reports_IICSEntities())
            {
                var where = string.Format("CodigoIC = \"{0}\"", codigoIC);
                if(!string.IsNullOrEmpty(isin))
                {
                    //hay que ir corrigiendo para cuando se coge Isin en vez de IsinPlantilla
                    string literalIsin = "ISIN";
                    if(tabla.Name == "Temp_RentabilidadCarteraSolemeg"
                        || tabla.Name == "Temp_VariacionPatrimonialA")
                    {
                        literalIsin = "IsinPlantilla";
                    }
                    if(tabla.Name!= "Temp_PlusvaliasDividendos" && tabla.Name != "Temp_ListadoRentaFijaNovarex")
                    {
                        //where = where + string.Format(" AND ISIN = \"{0}\"", isin);
                        where = where + string.Format(" AND " + literalIsin + " = \"{0}\"", isin);
                    }
                    
                }
                // Since your DbSet isn't generic, you can can't use this:
                // db.Set("Namespace.EntityName").AsQueryable().Where(a=> a.HasSomeValue...
                // Your queries should also be string based.
                // Use the System.Linq.Dynamic nuget package/namespace
                cont = dbContext.Set(tabla.FullName)
                  .AsQueryable()
                  .Where(where).Count();
                
            }
            
            return cont;
        }

        public static int GetTemp_GraficosExposMercTipodeProducto_Count(string codigoIC)
        {
            int output;
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Temp_GraficoExposMercTipoProducto.Where(p => p.CodigoIC == codigoIC).Count();
            }

            return output;
        }


        public static int GetTemp_GraficosCompPatrimonioTipodeProducto_Count(string codigoIC)
        {
            int output;
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.Temp_GraficoCompPatrimonioTipoProducto.Where(p => p.CodigoIC == codigoIC).Count();
            }

            return output;
        }

        public static List<CuentasContablesDerivado> GetCuentasDerivados()
        {
            var output = new List<CuentasContablesDerivado>();
            using (var dbContext = new Reports_IICSEntities())
            {
                output = dbContext.CuentasContablesDerivados.ToList();
            }

            return output;
        }   
    }
}
