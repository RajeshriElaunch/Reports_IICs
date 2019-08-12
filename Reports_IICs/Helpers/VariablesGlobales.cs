using Reports_IICs.DataAccess.Bloomberg;
using Reports_IICs.DataAccess.Importar;
using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.Helpers
{
    public static class VariablesGlobales
    {
        /// <summary>
        /// Estos son los códigos que se tienen en cuenta en RentaVariable_VM.tratarContrasplits
        /// </summary>
        public static List<string> OperacionesCorpCods = new List<string>()
        {
            "808"   //Cambio ISIN
        };
        // public get, and private set for strict access control
        public static List<Instrumentos_Tipos> InstrumentosTipos_Local { get; private set; }
        public static List<Instrumentos_Sectores> InstrumentosSectores_Local { get; private set; }
        public static List<Instrumentos_Categorias> InstrumentosCategorias_Local { get; private set; }
        public static List<Instrumentos_Empresas> InstrumentosEmpresas_Local { get; private set; }
        public static List<Instrumentos_Equivalencias> InstrumentosEquivalencias_Local { get; private set; }
        public static List<Instrumento> Instrumentos_Local { get; private set; }
        public static List<Instrumentos_Zonas> InstrumentosZonas_Local { get; private set; }
        public static List<Instrumentos_Paises> InstrumentosPaises_Local { get; private set; }
        public static List<Instrumentos_Importados> InstrumentosImportados_Local { get; private set; }
        public static List<RentaVariable_Equivalencias> RentaVariable_Equivalencias_Local { get; private set; }
        public static List<Seccione> Secciones_Local { get; private set; }
        /// <summary>
        /// Nombre de las tablas temporales asociadas a cada sección
        /// </summary>
        public static List<Tuple<int, string>> TablasSecciones { get; private set; }
        public static List<Bloomberg> Bloomberg_Local { get; private set; }
        public static List<usp_gestio_pro_09_Result> Pro09_Local { get; private set; }
        public static List<usp_gestio_pro_11_Result> Pro11_Local { get; private set; }        
        public static List<usp_gestio_pro_13_Result> Pro13_Local { get; private set; }
        public static List<usp_gestio_pro_21_Result> Pro21_Local { get; private set; }
        public static List<usp_gestio_pro_22_Result> Pro22_Local { get; private set; }

        //public static List<Temp_RentaVariable> Temp_RentaVariable_Local { get; private set; }

        /// <summary>
        /// Cuando una plantilla tiene varios Isins se selecciona para cuál se quiere generar el informe
        /// </summary>
        public static string IsinPlantillaSel = null;


        // GlobalInt can be changed only via this method
        public static void SetVariablesGlobales(Type tipoActualizar = null, Plantilla plantilla = null, DateTime? fechaInforme = null)
        {
            try
            {
                //Si no se quiere actualizar alguno en concreto, actualizamos todos
                if (tipoActualizar == null)
                {
                    InstrumentosTipos_Local = InstrumentosTipos_DA.GetAll().ToList();
                    InstrumentosSectores_Local = InstrumentosSectores_DA.GetAll().ToList();
                    InstrumentosCategorias_Local = InstrumentosCategorias_DA.GetAll().ToList();
                    InstrumentosEmpresas_Local = InstrumentosEmpresas_DA.GetAll().ToList();
                    InstrumentosEquivalencias_Local = Instrumentos_DA.GetInstrumentosEquivalencias().ToList();
                    Instrumentos_Local = Instrumentos_DA.GetAll().ToList();
                    InstrumentosZonas_Local = InstrumentosZonas_DA.GetAll().ToList();
                    InstrumentosPaises_Local = InstrumentosPaises_DA.GetAll().ToList();
                    InstrumentosImportados_Local = InstrumentosImportados_DA.GetAll().ToList();
                    RentaVariable_Equivalencias_Local = EquivalenciasIsins_DA.GetAll().ToList();
                    Secciones_Local = Secciones_DA.GetAll().ToList();
                    TablasSecciones = cargarTablasSecciones();
                    Bloomberg_Local = ImportarBloomberg_DA.GetAll().ToList();
                }
                else
                {
                    DateTime fechaInicio = new DateTime();

                    if (fechaInforme != null)
                        fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));

                    if (tipoActualizar == typeof(Instrumentos_Tipos))
                        InstrumentosTipos_Local = InstrumentosTipos_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Sectores))
                        InstrumentosSectores_Local = InstrumentosSectores_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Categorias))
                        InstrumentosCategorias_Local = InstrumentosCategorias_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Empresas))
                        InstrumentosEmpresas_Local = InstrumentosEmpresas_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Equivalencias))
                        InstrumentosEquivalencias_Local = Instrumentos_DA.GetInstrumentosEquivalencias().ToList();
                    else if (tipoActualizar == typeof(Instrumento))
                        Instrumentos_Local = Instrumentos_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Zonas))
                        InstrumentosZonas_Local = InstrumentosZonas_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Paises))
                        InstrumentosPaises_Local = InstrumentosPaises_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Instrumentos_Importados))
                        InstrumentosImportados_Local = InstrumentosImportados_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(RentaVariable_Equivalencias))
                        RentaVariable_Equivalencias_Local = EquivalenciasIsins_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(Bloomberg))
                        Bloomberg_Local = ImportarBloomberg_DA.GetAll().ToList();
                    else if (tipoActualizar == typeof(usp_gestio_pro_09_Result)
                            && plantilla != null
                            && fechaInforme != null)
                    {
                        Pro09_Local = Reports_DA.GetPRO09(plantilla, fechaInicio, Convert.ToDateTime(fechaInforme)).ToList();
                    }
                    else if (tipoActualizar == typeof(usp_gestio_pro_11_Result)
                            && plantilla != null
                            && fechaInforme != null)
                    {
                        Pro11_Local = Reports_DA.GetPRO11(plantilla, Convert.ToDateTime(fechaInforme)).ToList();                        
                    }
                    else if (tipoActualizar == typeof(usp_gestio_pro_13_Result)
                            && plantilla != null
                            && fechaInforme != null)
                    {
                        Pro13_Local = Reports_DA.GetPRO13(plantilla, fechaInicio, Convert.ToDateTime(fechaInforme)).ToList();
                    }
                    else if (tipoActualizar == typeof(usp_gestio_pro_21_Result)
                            && plantilla != null
                            && fechaInicio != null
                            && fechaInforme != null)
                    {
                        Pro21_Local = Reports_DA.GetPRO21(plantilla, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaInforme)).ToList();
                    }
                    else if (tipoActualizar == typeof(usp_gestio_pro_22_Result)
                            && plantilla != null
                            && fechaInicio != null
                            && fechaInforme != null)
                    {
                        Pro22_Local = Reports_DA.GetPRO22(plantilla.CodigoIc, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaInforme)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ClearVariablesProcs()
        {
            Pro09_Local = new List<usp_gestio_pro_09_Result>();
            Pro11_Local = new List<usp_gestio_pro_11_Result>();
            Pro13_Local = new List<usp_gestio_pro_13_Result>();
            Pro21_Local = new List<usp_gestio_pro_21_Result>();
            Pro22_Local = new List<usp_gestio_pro_22_Result>();
        }
        public static void CargarTablasTemporales(Plantilla plantilla)
        {
            //Temp_RentaVariable_Local = Reports_DA.GetTemp(plantilla, typeof(Temp_RentaVariable));
        }

        /// <summary>
        /// Devuelve el Id pasándole la código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Tipo(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = Convert.ToInt32(VariablesGlobales.InstrumentosTipos_Local.Find(i => i.Codigo == codigo).Id);
            }
            return id;
        }

        /// <summary>
        /// Devuelve el Id pasándole la descripción
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Sector(string descripcion)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(descripcion))
            {
                id = VariablesGlobales.InstrumentosSectores_Local.Find(i => i.Descripcion == descripcion).Id;
            }
            return id;
        }

        /// <summary>
        /// Devuelve el Id pasándole el código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Categoria(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = VariablesGlobales.InstrumentosCategorias_Local.Find(i => i.Codigo == codigo).Id;
            }
            return id;
        }

        /// <summary>
        /// Devuelve el Id pasándole el código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Empresa(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = VariablesGlobales.InstrumentosEmpresas_Local.Find(i => i.Codigo == codigo).Id;
            }
            return id;
        }

        /// <summary>
        /// Devuelve el Id pasándole el código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumento(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = Convert.ToInt32(VariablesGlobales.Instrumentos_Local.Find(i => i.Codigo == codigo).Id);
            }
            return id;
        }

        public static string LookUpInstrumentoEquivalencia(string codigoNuestro)
        {
            string codigoEquivalencia = string.Empty;

            var obj = InstrumentosEquivalencias_Local.Where(w => w.CodigoNuestro == codigoNuestro).FirstOrDefault();

            if (obj != null)
                codigoEquivalencia = obj.CodigoEquivalencia;

            return codigoEquivalencia;
        }

        /// <summary>
        /// Devuelve el Id pasándole el código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Zona(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = VariablesGlobales.InstrumentosZonas_Local.Find(i => i.Codigo == codigo).Id;
            }
            return id;
        }

        /// <summary>
        /// Devuelve el Id pasándole el código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static int? LookUpInstrumentos_Pais(string codigo)
        {
            int? id = null;
            if (!string.IsNullOrEmpty(codigo))
            {
                id = VariablesGlobales.InstrumentosPaises_Local.Find(i => i.Codigo == codigo).Id;
            }
            return id;
        }

        private static List<Tuple<int, string>> cargarTablasSecciones()
        {
            var lista = new List<Tuple<int, string>>();
            lista.Add(new Tuple<int, string>(1, typeof(Temp_Participes).Name));
            lista.Add(new Tuple<int, string>(2, typeof(Temp_EvolucionPatrValLiq).Name));
            lista.Add(new Tuple<int, string>(3, typeof(Temp_EvolucionIndBench).Name));

            lista.Add(new Tuple<int, string>(5, typeof(Temp_VariacionPatrimonialA).Name));
            lista.Add(new Tuple<int, string>(5, typeof(Temp_VariacionPatrimonialA_Totales).Name));
            lista.Add(new Tuple<int, string>(6, typeof(Temp_DesgloseGastos).Name));
            lista.Add(new Tuple<int, string>(7, typeof(Temp_RentabilidadCarteraV1).Name));
            lista.Add(new Tuple<int, string>(8, typeof(Temp_RentabilidadCarteraV2).Name));
            lista.Add(new Tuple<int, string>(9, typeof(Temp_EvolucionMercados).Name));
            lista.Add(new Tuple<int, string>(10, typeof(Temp_IndicePreconfiguradoNovarex).Name));
            lista.Add(new Tuple<int, string>(11, typeof(Temp_SuscripcionesReembolsos).Name));
            
            lista.Add(new Tuple<int, string>(13, typeof(Temp_RentaVariable).Name));
            lista.Add(new Tuple<int, string>(14, typeof(Temp_CompraVentaPrecAdq).Name));
            lista.Add(new Tuple<int, string>(15, typeof(Temp_Diversificacion).Name));
            lista.Add(new Tuple<int, string>(16, typeof(Temp_DividendosCobrados).Name));
            lista.Add(new Tuple<int, string>(17, typeof(Temp_PlusvaliasDividendos).Name));
            lista.Add(new Tuple<int, string>(18, typeof(Temp_RVComprasRealizadasEjercicio).Name));
            lista.Add(new Tuple<int, string>(19, typeof(Temp_IIC_ComprasVentasEjercicio).Name));
            lista.Add(new Tuple<int, string>(20, typeof(Temp_RFComprasVentasEjercicio).Name));
            lista.Add(new Tuple<int, string>(21, typeof(Temp_RentaFija).Name));
            lista.Add(new Tuple<int, string>(22, typeof(Temp_ListadoRentaFijaNovarex).Name));
            lista.Add(new Tuple<int, string>(23, typeof(Temp_CuponesCobrados).Name));
            lista.Add(new Tuple<int, string>(24, typeof(Temp_CarteraRF).Name));
            lista.Add(new Tuple<int, string>(25, typeof(Temp_GraficoIBenchmark).Name));
            //lista.Add(new Tuple<int, string>(26, typeof(Temp_Participes).Name));
            //lista.Add(new Tuple<int, string>(27, typeof(Temp_EvolucionRentabilidadGuissona).Name));
            lista.Add(new Tuple<int, string>(28, typeof(Temp_EvolucionPatrimonioConjuntoGuissona).Name));
            lista.Add(new Tuple<int, string>(29, typeof(Temp_EvolucionPatrGuissonaValLiq).Name));
            lista.Add(new Tuple<int, string>(30, typeof(Temp_GraficoExposMercTipoProducto).Name));
            lista.Add(new Tuple<int, string>(31, typeof(Temp_GraficoExposMercTipoActivo).Name));
            lista.Add(new Tuple<int, string>(32, typeof(Temp_GraficoExposMercDivisas).Name));
            lista.Add(new Tuple<int, string>(33, typeof(Temp_GraficoCompCarteraRV).Name));
            lista.Add(new Tuple<int, string>(34, typeof(Temp_GraficoCompCarteraRF).Name));
            lista.Add(new Tuple<int, string>(35, typeof(Temp_OperacionesRentaVariable_II).Name));
            lista.Add(new Tuple<int, string>(36, typeof(Temp_RatiosCarteraRV).Name));
            lista.Add(new Tuple<int, string>(37, typeof(Temp_CarteraCcrVolgaGamar).Name));
            lista.Add(new Tuple<int, string>(38, typeof(Temp_Burbujas).Name));
            lista.Add(new Tuple<int, string>(39, typeof(Temp_RentabilidadCarteraSolemeg).Name));
            //lista.Add(new Tuple<int, string>(40, typeof(Temp_Participes).Name));
            //lista.Add(new Tuple<int, string>(41, typeof(Temp_ParticipesSalat).Name));
            lista.Add(new Tuple<int, string>(42, typeof(Temp_GraficoCompPatrimonioTipoProducto).Name));
            lista.Add(new Tuple<int, string>(43, typeof(Temp_GraficoCompPatrimonioTipoActivo).Name));
            lista.Add(new Tuple<int, string>(44, typeof(Temp_GraficoCompPatrimonioDivisas).Name));
            
            lista.Add(new Tuple<int, string>(46, typeof(Temp_VariacionPatrimonialB).Name));

            return lista;
        }

    }
}
