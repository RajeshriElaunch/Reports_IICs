using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.VariacionPatrimonialA;
using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class VariacionPatrimonialA_VM
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Plantilla _plantilla;
        private static DateTime _fechaInforme;
        private static DateTime _fechaInicio;
        private static bool _creadaAñoInf = false;//La plantilla ha sido creada el año de la fecha de generación del informe?
        private static List<Temp_RentaVariable> _secc13;
        private static List<Temp_RentaFija> _secc21;
        private static IEnumerable<Instrumento> _instrumentos;
        private static IEnumerable<Instrumentos_Tipos> _tipos;
        private static IEnumerable<Instrumentos_Categorias> _categorias;
        private static IEnumerable<Instrumentos_Empresas> _empresas;
        private const string g1 = "GRUPO-01-Valor en cartera no vendido en el periodo";
        private const string g2 = "GRUPO-02-Valor en cartera vendido en el periodo";
        private const string g3 = "GRUPO-03-Valor comprado y vendido en el periodo";
        private const string g4 = "GRUPO-04-Valor comprado en el periodo y no vendido";
        //private static string formulaCuentasPrecios = "[660] + [670]  + [671] + [672] + [762] + [763] + [764] + [767] - [7630002] - [6710002]";
        //private static string formulaCuentasIngresos = "[760]+[761]-[7600004]";
        //private static string formulaCuentasRVAIngresos = "[7500001]+[7600000]+[7600001]";
        //private static string formulaCuentasRVAOtros = "[6700011]+[7620010]";
        //private static string formulaCuentasRFIIngresos = "[7600010]+[7600011]+[7610001]+[7610002]+[7610008]+[7610009]";
        //private static string formulaCuentasMMOPrecios = "[6600120]+[6700000]+[6700005]+[6710120]+[6600004]+[6600005]+[7620000]+[7620005]+[7630120]+[7670120]";
        //private static string formulaCuentasMMOIngresos = "[7610000]+[7610003]+[7610004]+[7610006]+[7610014]+[7610240]+[7690000]";
        //private static string formulaCuentasOTRIngresos = "[7610007]";
        //private static string formulaCuentasTotalRendimientosPrecios = "[660]+[670]+[671]+[672]+[762]+[763]+[764]+[767]-[7620010]-[6700011]";
        //private static string formulaCuentasTotalRendimientosIngresos = "[760]+[761]+[7690000]-[7600004]+[7500001]";
        //private static string formulaCuentasTotalRendimientosOtros = "[6700011]+[7620010]+[661]+[673]+[674]+[750]-[7500001]+[7600004]+[765]+[766]+[769]-[7690000]";
        public static void Insert_Temp(Plantilla plantilla, DateTime fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                _fechaInicio = Utils.GetFechaInicio(plantilla, fecha);
                _fechaInforme = fecha;

                _creadaAñoInf = Utils.CreadaAñoInforme(plantilla, fecha);

                _plantilla = plantilla;
                _instrumentos = VariablesGlobales.Instrumentos_Local;
                _tipos = VariablesGlobales.InstrumentosTipos_Local;
                _categorias = VariablesGlobales.InstrumentosCategorias_Local;
                _empresas = VariablesGlobales.InstrumentosEmpresas_Local;

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                //RV
                _secc13 = listaTmp.Where(w => w.GetType() == new Temp_RentaVariable().GetType()).Select(s => (Temp_RentaVariable)s).ToList();

                //RF
                _secc21 = listaTmp.Where(w => w.GetType() == new Temp_RentaFija().GetType()).Select(s => (Temp_RentaFija)s).ToList();

                //Cuentas
                var cuentas = VariacionPatrimonial_DA.GetCuentas();

                #region RENTA VARIABLE

                var cuentasRV = cuentas.Where(w => w.Descripcion.Equals("RENTA VARIABLE", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var codsInstr = new List<string>() { "RVA" };
                var cobrados = getCobrados("Dividendo");
                //Cambiamos el signo
                //var totalIngresos = getSaldoCuentasRV(true, "RVA", ConfigurationManager.AppSettings["5_FormulaCuentasRVAIngresos"]);
                var totalIngresos = getSaldoCuentasRV(true, "RVA", cuentasRV != null ? cuentasRV.CuentasIngresosFinancieros : null);
                //En esta variable acumulamos los que restaremos en la última línea "OTROS"
                var totalIngresosPrevios = totalIngresos;
                //var otros = getSaldoCuentasRV(false, "RVA", ConfigurationManager.AppSettings["5_FormulaCuentasRVAOtros"]);
                var otros = getSaldoCuentasRV(false, "RVA", cuentasRV != null ? cuentasRV.CuentasOtrosRendimientos : null);
                //En esta variable acumulamos los que restaremos en la última línea "OTROS"
                var totalOtrosPrevios = otros;

                //listaTmp.Add(getTemp(string.Empty, null, null, codsInstr, otros, null, null, null, null, null, totalIngresos));
                //listaTmp.Add(getTemp(string.Empty, null, null, codsInstr, otros, null, null, null, null, null, totalIngresos));
                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstr, otros, null, null, null, null, cobrados, totalIngresos));

                #endregion

                #region RENTA VARIABLE/Valores

                //Tenemos que buscar dos cosas para este grupo
                //sección 13; Grupo: -01; Instrum: RVA,GLO; TipoInstr: VAL
                //sección 13; Grupo: -04; Instrum: RVA,GLO; TipoInstr: VAL
                var grupos = new List<string>() { g1, g4 };
                //codsInstr = new List<string>() { "RVA", "GLO" };
                codsInstr = new List<string>() { "RVA" };
                var codsTipo = new List<string>() { "VAL" };
                var codsCateg = new List<string>();
                codsCateg = null;
                var codsEmpre = new List<string>();
                codsEmpre = null;
                var cartera = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, null, null);

                //sección 13; Grupo: -02 ; Instrum: RVA,GLO ; TipoInstr: VAL
                //sección 13; Grupo: -03 ; Instrum: RVA,GLO ; TipoInstr: VAL
                grupos = new List<string>() { g2, g3 };
                var ventas = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, null, null);
                var bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, true);
                var bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, true);
                //En esta variable acumulamos los que restaremos en la última línea "OTROS"
                var totalPreciosPrevios = Utils.SumarNulos(cartera, ventas);


                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, null, null, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, null, codsTipo, codsCateg, codsEmpre, null, null, bopPrecio, bopDivisa));
                #endregion

                #region RENTA VARIABLE/Valores/Cíclicos

                grupos = null;
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "VAL" };
                codsCateg = new List<string>() { "CIC" };
                codsEmpre = null;
                cartera = null;
                ventas = null;
                var totalPrecios = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre);

                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));

                #endregion

                #region RENTA VARIABLE/Valores/Defensivos
                grupos = null;
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "VAL" };
                codsCateg = new List<string>() { "DEF" };
                codsEmpre = null;
                cartera = null;
                ventas = null;
                totalPrecios = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre);

                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));

                #endregion

                #region RENTA VARIABLE/Valores/Small-Mid

                grupos = null;
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "VAL" };
                codsCateg = null;
                codsEmpre = new List<string>() { "SMA", "MID" };
                cartera = null;
                ventas = null;
                totalPrecios = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre);

                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));

                #endregion

                #region RENTA VARIABLE/Valores/Large

                grupos = null;
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "VAL" };
                codsCateg = null;
                codsEmpre = new List<string>() { "LAR" };
                cartera = null;
                ventas = null;
                totalPrecios = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre);

                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre));

                #endregion

                #region RENTA VARIABLE/IICs

                //sección 13; Grupo: -01,-04; Instrum: RVA,GLO; TipoInstr: IIC
                grupos = new List<string>() { g1, g4 };
                //codsInstr = new List<string>() { "RVA", "GLO" };
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "IIC" };
                codsCateg = null;
                codsEmpre = null;
                totalPrecios = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre);

                //sección 13; Grupo: -02,-03; Instrum: RVA,GLO; TipoInstr: IIC
                grupos = new List<string>() { g2, g3 };
                ventas = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre);
                bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, true);
                bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, true);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                //otros = Utils.CalculateFormulaCuentas("[7600004]", _plantilla.CodigoIc, null, fecha);

                //Si descomentamos esto porque se ha encontrado la cuenta necesaria, tenemos que pasar también la variable
                //"otros" a continuación en addTemp, de momento pasamos null
                //if (_creadaAñoInf)
                //    otros = Utils.CalculateFormulaCuentasAcumulado(ConfigurationManager.AppSettings["5_FormulaCuentaOtros"], _plantilla.CodigoIc, null, _fechaInicio, _fechaInforme);
                //else
                //    otros = Utils.CalculateFormulaCuentas(ConfigurationManager.AppSettings["5_FormulaCuentaOtros"], _plantilla.CodigoIc, null, _fechaInforme);

                //totalOtrosPrevios += otros;

                //listaTmp.Add(getTemp(string.Empty, cartera, ventas, codsInstr, otros, totalPrecios, codsTipo, codsCateg, codsEmpre));
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre, null, null, bopPrecio, bopDivisa));

                #endregion

                #region RENTA VARIABLE/Derivados

                //sección 13; TipoInstr: DER
                grupos = null;
                codsInstr = new List<string>() { "RVA" };
                codsTipo = new List<string>() { "DER" };
                codsCateg = null;
                codsEmpre = null;
                totalPrecios = null;

                cartera = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre, true);

                ventas = getCalculoVarPrecios(string.Empty, 13, grupos, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, true);
                bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, true);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                //El código instrumento sólo lo tenemos en cuenta para añadir
                codsInstr = new List<string>() { "RVA" };
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, codsCateg, codsEmpre, null, null, bopPrecio, bopDivisa));

                #endregion

                #region RENTA VARIABLE/Otros
                ////Saldo de cuentas para los ISINS que cumplan RVA y OTR
                //codsInstr = new List<string>() { "RVA", };
                //codsTipo = new List<string>() { "OTR" };
                //totalPrecios = getSaldoCuentasRV(true, "RVA", formulaCuentasPrecios, "OTR");
                //listaTmp.Add(getTemp(string.Empty, null, null, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region RENTA FIJA
                var cuentasRF = cuentas.Where(w => w.Descripcion.Equals("RENTA FIJA", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                codsInstr = new List<string>() { "RFI" };
                //cobrados = getCobrados("Cupon");
                //Ponemos el total de la sección 23 - CUPONES COBRADOS (que nos hemos asegurado se haya generado antes de esta sección)
                //cobrados = listaTmp.Where(w => w.GetType() == new Temp_CuponesCobrados().GetType()).Select(s => (Temp_CuponesCobrados)s).Sum(s => s.ImporteNeto);                

                //totalIngresos = getSaldoCuentasRF(true, "RFI", ConfigurationManager.AppSettings["5_FormulaCuentasRFIIngresos"]);
                totalIngresos = getSaldoCuentasRF(true, "RFI", cuentasRF != null ? cuentasRF.CuentasIngresosFinancieros : null);
                totalIngresosPrevios += totalIngresos;

                //listaTmp.Add(getTemp(string.Empty, null, null, codsInstr, null, null, null, null, null, cobrados, totalIngresos));
                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstr, null, null, null, null, null, cobrados, totalIngresos, bopPrecio, bopDivisa));

                #endregion

                #region RENTA FIJA/Valores

                //sección 21; Grupo: 6                
                var gruposRF = new List<int>() { 1, 4 };
                codsInstr = new List<string>() { "RFI" };
                codsTipo = new List<string>() { "VAL" };

                cartera = getCalculoVarPreciosRF(string.Empty, gruposRF, null);

                gruposRF = new List<int>() { 2, 3, 5 };
                ventas = getCalculoVarPreciosRF(string.Empty, gruposRF, null);

                bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, false);
                bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, false);

                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);

                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, null, codsTipo, null, null, null, null, bopPrecio, bopDivisa));
                #endregion

                #region RENTA FIJA/IICs

                //sección 21; Grupo: 6                
                gruposRF = new List<int>() { 6 };
                codsInstr = new List<string>() { "RFI" };
                codsTipo = new List<string>() { "IIC" };

                cartera = getCalculoVarPreciosRF(string.Empty, gruposRF, true);
                ventas = getCalculoVarPreciosRF(string.Empty, gruposRF, false);

                bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, false);
                bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, false);

                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);

                //Si descomentamos esto porque se ha encontrado la cuenta necesaria, tenemos que pasar también la variable
                //"otros" a continuación en addTemp, de momento pasamos null
                //otros = Utils.CalculateFormulaCuentas(ConfigurationManager.AppSettings["5_FormulaCuentaOtros"], _plantilla.CodigoIc, null, fecha);

                //if (_creadaAñoInf)
                //    otros = Utils.CalculateFormulaCuentasAcumulado(ConfigurationManager.AppSettings["5_FormulaCuentaOtros"], _plantilla.CodigoIc, null, _fechaInicio, _fechaInforme);
                //else
                //    otros = Utils.CalculateFormulaCuentas(ConfigurationManager.AppSettings["5_FormulaCuentaOtros"], _plantilla.CodigoIc, null, _fechaInforme);

                //totalOtrosPrevios += otros;

                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, null, codsTipo, null, null, null, null, bopPrecio, bopDivisa));
                #endregion

                #region RENTA FIJA/Derivados
                //sección 21; Grupo: 7                
                gruposRF = new List<int>() { 7 };
                codsInstr = new List<string>() { "RFI" };
                codsTipo = new List<string>() { "DER" };

                cartera = getCalculoVarPreciosRF(string.Empty, gruposRF, true);
                ventas = getCalculoVarPreciosRF(string.Empty, gruposRF, false);

                bopPrecio = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, true, false);
                bopDivisa = getPrecio_o_Divisa(codsInstr, codsTipo, codsCateg, codsEmpre, false, false);

                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);

                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, null, codsTipo, null, null, null, null, bopPrecio, bopDivisa));
                #endregion

                #region RETORNO ABSOLUTO
                codsInstr = new List<string>() { "RAB" };
                //totalIngresos = getSaldoCuentasRV(true, "RAB", formulaCuentasIngresos);
                totalIngresos = getSaldoCuentasRV(true, "RAB");
                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstr, null, null, null, null, null, null, totalIngresos));

                #endregion

                #region RETORNO ABSOLUTO/IICs

                grupos = null;
                codsInstr = new List<string>() { "RAB" };
                codsTipo = new List<string>() { "IIC" };
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region RETORNO ABSOLUTO/Patrimonialista
                grupos = null;
                codsInstr = new List<string>() { "RAB" };
                codsTipo = new List<string>() { "PAT" };
                codsCateg = null;
                codsEmpre = null;
                //Ponemos null en vez de codsInstr porque aunque sea RAB, en la sección de RV se guarda como instrumento=NULL
                cartera = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region RETORNO ABSOLUTO/CCCP
                grupos = null;
                codsInstr = new List<string>() { "RAB" };
                codsTipo = new List<string>() { "CCP" };
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region RETORNO ABSOLUTO/PERSISTENCIA
                grupos = null;
                codsInstr = new List<string>() { "RAB" };
                codsTipo = new List<string>() { "PER" };
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, null, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region RETORNO ABSOLUTO/Otros
                grupos = null;
                codsInstr = new List<string>() { "RAB" };
                codsTipo = new List<string>() { "OTR" };
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo));
                #endregion

                #region GARANTIZADOS / ESTRUCTURADOS
                grupos = null;
                codsInstr = new List<string>() { "GAR" };
                codsTipo = null;
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                //totalIngresos = getSaldoCuentasRV(true, "GAR", formulaCuentasIngresos);
                totalIngresos = getSaldoCuentasRV(true, "GAR");
                totalIngresosPrevios += totalIngresos;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, null, null, null, totalIngresos));
                #endregion

                #region MERCADO MONETARIO
                var cuentasMM = cuentas.Where(w => w.Descripcion.Equals("MERCADO MONETARIO", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                //Saldo de cuentas para los ISINS que cumplan MMO
                codsInstr = new List<string>() { "MMO", };
                //totalPrecios = getSaldoCuentasRV(true, "MMO", ConfigurationManager.AppSettings["5_FormulaCuentasMMOPrecios"]);
                totalPrecios = getSaldoCuentasRV(true, "MMO", cuentasMM != null ? cuentasMM.CuentasVariacionPrecios : null);
                //totalIngresos = getSaldoCuentasRV(true, "MMO", formulaCuentasIngresos);
                //totalIngresos = getSaldoCuentasRV(true, "MMO", ConfigurationManager.AppSettings["5_FormulaCuentasMMOIngresos"]);
                totalIngresos = getSaldoCuentasRV(true, "MMO", cuentasMM != null ? cuentasMM.CuentasIngresosFinancieros : null);
                totalIngresosPrevios += totalIngresos;
                otros = getSaldoCuentasRV(true, "MMO", cuentasMM != null ? cuentasMM.CuentasOtrosRendimientos : null);
                totalOtrosPrevios += otros;

                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstr, otros, totalPrecios, null, null, null, null, totalIngresos));
                #endregion

                #region DIVISAS
                grupos = null;
                codsInstr = new List<string>() { "DIV" };
                codsTipo = null;
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                //totalIngresos = getSaldoCuentasRV(true, "DIV", formulaCuentasIngresos);
                totalIngresos = getSaldoCuentasRV(true, "DIV");
                totalIngresosPrevios += totalIngresos;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, null, null, null, totalIngresos));
                #endregion

                #region COMMODITIES
                grupos = null;
                codsInstr = new List<string>() { "COM" };
                codsTipo = null;
                codsCateg = null;
                codsEmpre = null;
                cartera = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, true);
                ventas = getCalculoVarPrecios(string.Empty, 13, null, codsInstr, codsTipo, codsCateg, codsEmpre, false);
                totalPreciosPrevios += Utils.SumarNulos(cartera, ventas);
                totalPrecios = null;
                //totalIngresos = getSaldoCuentasRV(true, "COM", formulaCuentasIngresos);
                totalIngresos = getSaldoCuentasRV(true, "COM");
                totalIngresosPrevios += totalIngresos;
                addTemp(ref listaTmp, getTemp(string.Empty, cartera, ventas, codsInstr, null, totalPrecios, codsTipo, null, null, null, totalIngresos));
                #endregion

                #region TOTAL RENDIMIENTOS
                var cuentasTR = cuentas.Where(w => w.Descripcion.Equals("TOTAL RENDIMIENTOS", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                //tenemos que restar los totales previos (columna C del excel)
                codsInstr = new List<string>() { "TOTAL RENDIMIENTOS" };
                //totalPrecios = getSaldoCuentasRV(false, "OTR", ConfigurationManager.AppSettings["5_FormulaCuentasTotalRendimientosPrecios"]);
                totalPrecios = getSaldoCuentasRV(false, "OTR", cuentasTR != null ? cuentasTR.CuentasVariacionPrecios : null);
                //totalPreciosPrevios += totalPrecios != null? Convert.ToDecimal(totalPreciosPrevios) : 0;
                //totalIngresos = getSaldoCuentasRV(false, "OTR", ConfigurationManager.AppSettings["5_FormulaCuentasTotalRendimientosIngresos"]);
                totalIngresos = getSaldoCuentasRV(false, "OTR", cuentasTR != null ? cuentasTR.CuentasIngresosFinancieros : null);
                //totalIngresosPrevios += totalIngresos;
                //otros = getSaldoCuentasRV(false, "OTR", ConfigurationManager.AppSettings["5_FormulaCuentasTotalRendimientosOtros"]);
                otros = getSaldoCuentasRV(false, "OTR", cuentasTR != null ? cuentasTR.CuentasOtrosRendimientos : null);
                //totalOtrosPrevios += otros;

                var totalRendimientosPrecios = totalPrecios;
                var totalRendimientosIngresos = totalIngresos;
                var totalRendimientosOtros = otros;
                var totalIngresosRendimientos = totalIngresos;
                var codsInstrRendimientos = codsInstr;

                //En vez de añadir esta línea ahora, la añadimos al final
                //listaTmp.Add(getTemp(string.Empty, null, null, codsInstr, otros, totalPrecios, null, null, null, null, totalIngresos));
                #endregion

                #region OTROS ACTIVOS
                //Hacemos OTROS ACTIVOS al final del todo porque necesita sumar el resto de apartados                
                codsInstr = new List<string>() { "OTR" };

                //tenemos que restar los totales previos (columna C del excel)
                totalPrecios = totalRendimientosPrecios - totalPreciosPrevios;
                totalIngresos = totalRendimientosIngresos - totalIngresosPrevios;
                otros = totalRendimientosOtros - totalOtrosPrevios;
                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstr, otros, totalPrecios, null, null, null, null, totalIngresos));
                #endregion

                //Añadimos ahora TOTAL RENDIMIENTOS
                addTemp(ref listaTmp, getTemp(string.Empty, null, null, codsInstrRendimientos, totalRendimientosOtros, totalRendimientosPrecios, null, null, null, null, totalIngresosRendimientos));

                //Calculamos los totales
                addTempTotales(ref listaTmp);

                pintarLineaCategoriaEmpresa(ref listaTmp);
                //}
            }
            catch (Exception ex)
            {
                Log.Error("Error VariacionPatrimonialA_VM/Insert_Temp", ex);
                throw;
            }
        }

        private static void addTempTotales(ref List<TempTableBase> listaTmp)
        {
            var ampl = VarPatrA_AmpliacReduccCart(_plantilla.CodigoIc, _fechaInforme);

            var fechaIni = Utils.GetFechaInicio(_plantilla, _fechaInforme, typeof(Temp_VariacionPatrimonialA));

            decimal totalPatrimonioAnt = 0;

            foreach (var isin in _plantilla.Plantillas_Isins)
            {
                totalPatrimonioAnt += Utils.GetPatrimonio(_plantilla.CodigoIc, isin.Isin.ToUpper(), fechaIni);
            }

            var tmp = new Temp_VariacionPatrimonialA_Totales();
            tmp.SuscripcionesAmpliaciones = ampl;
            tmp.TotalPatrimonioAnt = totalPatrimonioAnt;
            tmp.CodigoIC = _plantilla.CodigoIc;

            listaTmp.Add(tmp);
        }

        /// <summary>
        /// En el report queremos pintar líneas divisorias que separen categorías y empresas para dar claridad al diseño del report
        /// Buscamos el primer codEmpresa no nulo y ponemos el campo TieneBordeSuperior = true
        /// </summary>
        /// <param name="listaTmp"></param>
        private static void pintarLineaCategoriaEmpresa(ref List<TempTableBase> listaTmp)
        {
            var listaVPA = listaTmp.Where(w => w.GetType() == new Temp_VariacionPatrimonialA().GetType()).Select(s => (Temp_VariacionPatrimonialA)s);
            var obj = listaVPA.Where(w => !string.IsNullOrEmpty(w.CodsEmpresa));
            if (obj.Count() > 0)
            {
                var item = obj.First();
                if (item != null)
                    item.TieneBordeSuperior = true;
                item = listaVPA.Where(w => !string.IsNullOrEmpty(w.CodsCategoria)).First();
                if (item != null)
                    item.TieneBordeSuperior = true;
                item = listaVPA.Where(w => !string.IsNullOrEmpty(w.CodsEmpresa)).Last();
                if (item != null)
                    item.TieneBordeInferior = true;
            }
        }

        private static void addTemp(ref List<TempTableBase> listaTmp, Temp_VariacionPatrimonialA temp)
        {
            //Sólo añadimos a la lista si por lo menos hay un valor que no sea ni 0 ni null
            if(Utils.NotNullAndNotZero(temp.Cartera)
                || Utils.NotNullAndNotZero(temp.Ventas)
                || Utils.NotNullAndNotZero(temp.TotalPrecios)
                || Utils.NotNullAndNotZero(temp.Cobrados)
                || Utils.NotNullAndNotZero(temp.DevengadosPtesCobrar)
                || Utils.NotNullAndNotZero(temp.TotalIngresos)
                || Utils.NotNullAndNotZero(temp.Otros))
            {
                listaTmp.Add(temp);

            }
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isinPlantilla"></param>
        /// <param name="proc"></param>
        /// <param name="grupos"></param>
        /// <param name="codsInst"></param>
        /// <param name="codsTipo"></param>
        /// <param name="codsCateg"></param>
        /// <param name="codsEmpr"></param>
        /// <param name="cartera">sólo se utiliza para los derivados. Si es true sumamos el campo PosicionCartera. Si es false sumamos el campo PosicionesCerradas</param>
        /// <returns></returns>
        */

        /// <summary>
        /// Devuelve BoPPrecio o BoPDivisa de la sección en función del parámetro "precio"
        /// </summary>
        /// <param name="codsInst"></param>
        /// <param name="codsTipo"></param>
        /// <param name="codsCateg"></param>
        /// <param name="codsEmpr"></param>
        /// <param name="precio">Sí es true devolverá BoPPrecio, en caso contrario devolverá BoPDivisa</param>
        /// <param name="rv">si es true recuperamos la info de la sección de RV, en caso contrario de la sección de RF</param>
        /// <returns></returns>
        private static decimal? getPrecio_o_Divisa(List<string> codsInst, List<string> codsTipo, List<string> codsCateg, List<string> codsEmpr, bool precio, bool rv)
        {
            decimal? resultado = null;            

            var idsInstr = new List<string>();
            var idsTipo = new List<string>();
            var idsCateg = new List<int?>();
            var idsEmpre = new List<int?>();

            convertCodsInst(codsInst, codsTipo, codsCateg, codsEmpr, ref idsInstr, ref idsTipo, ref idsCateg, ref idsEmpre);

            if (rv)
            {
                var query13 = _secc13;

                var grupos = new List<string>() { g1, g2, g3, g4 };

                query13 = query13.Where(w => grupos.Contains(w.Grupo)).ToList();

                if (idsInstr != null && idsInstr.Count() > 0)
                {
                    query13 = query13.Where(w => idsInstr.Contains(w.IdInstrumento)).ToList();
                }
                if (idsTipo != null && idsTipo.Count() > 0)
                {
                    query13 = query13.Where(w => idsTipo.Contains(w.IdTipoInstrumento)).ToList();
                }//clause if
                if (idsCateg != null && idsCateg.Count() > 0)
                {
                    query13 = query13.Where(w => idsCateg.Contains(w.IdCategoria)).ToList();
                }//
                if (idsEmpre != null && idsEmpre.Count() > 0)
                {
                    query13 = query13.Where(w => idsEmpre.Contains(w.IdEmpresa)).ToList();
                }

                //comprobamos que tienen elementos
                if (query13.Count() > 0)
                {
                    if (precio)
                    {
                        resultado = query13.Sum(s => ((Temp_RentaVariable)s).BoPPrecio);
                    }
                    else
                    {
                        resultado = query13.Sum(s => ((Temp_RentaVariable)s).BoPDivisa);
                    }
                }
            }
            else
            {
                var query21 = _secc21;

                var grupos = new List<int>() { 1, 2, 3, 4 };

                query21 = query21.Where(w => w.Grupo != null && grupos.Contains(Convert.ToInt32(w.Grupo))).ToList();

                if (idsInstr != null && idsInstr.Count() > 0)
                {
                    query21 = query21.Where(w => idsInstr.Contains(w.IdInstrumento)).ToList();
                }
                if (idsTipo != null && idsTipo.Count() > 0)
                {
                    query21 = query21.Where(w => idsTipo.Contains(w.IdTipoInstrumento)).ToList();
                }
                if (idsCateg != null && idsCateg.Count() > 0)
                {
                    query21 = query21.Where(w => idsCateg.Contains(w.IdCategoria)).ToList();
                }
                if (idsEmpre != null && idsEmpre.Count() > 0)
                {
                    query21 = query21.Where(w => idsEmpre.Contains(w.IdEmpresa)).ToList();
                }

                //comprobamos que tienen elementos
                if (query21.Count() > 0)
                {
                    if (precio)
                    {
                        resultado = query21.Sum(s => ((Temp_RentaFija)s).BoPPrecio);
                    }
                    else
                    {
                        resultado = query21.Sum(s => ((Temp_RentaFija)s).BoPDivisa);
                    }
                }
            }
            return resultado;
        }
        private static decimal? getCalculoVarPrecios(string isinPlantilla, int proc, List<string> grupos, List<string> codsInst, List<string> codsTipo, List<string> codsCateg, List<string> codsEmpr, bool? cartera = null)
        {
            decimal? resultado = null;

            var idsInstr = new List<string>();
            var idsTipo = new List<string>();
            var idsCateg = new List<int?>();
            var idsEmpre = new List<int?>();

            convertCodsInst(codsInst, codsTipo, codsCateg, codsEmpr, ref idsInstr, ref idsTipo, ref idsCateg, ref idsEmpre);

            switch (proc)
            {
                case 13:
                    //var query13 = _secc13.Where(w => ((Temp_RentaVariable)w).IsinPlantilla == isinPlantilla);
                    var query13 = _secc13;
                    if (grupos != null && grupos.Count() > 0)
                    {
                        //query13 = query13.Where(w => grupos.Contains(((Temp_RentaVariable)w).Grupo));
                        //foreach(var grupo in grupos)
                        //{
                        query13 = query13.Where(w => grupos.Contains(w.Grupo)).ToList();
                        //}

                        //var t = fileList.Where(file => filterList.Any(folder => file.ToUpperInvariant().Contains(folder.ToUpperInvariant())));
                    }
                    if (idsInstr != null && idsInstr.Count() > 0)
                    {
                        query13 = query13.Where(w => idsInstr.Contains(w.IdInstrumento)).ToList();
                    }
                    if (idsTipo != null && idsTipo.Count() > 0)
                    {
                        query13 = query13.Where(w => idsTipo.Contains(w.IdTipoInstrumento)).ToList();
                    }
                    if (idsCateg != null && idsCateg.Count() > 0)
                    {
                        query13 = query13.Where(w => idsCateg.Contains(w.IdCategoria)).ToList();
                    }
                    if (idsEmpre != null && idsEmpre.Count() > 0)
                    {
                        query13 = query13.Where(w => idsEmpre.Contains(w.IdEmpresa)).ToList();
                    }

                    //comprobamos que tienen elementos
                    if (query13.Count() > 0)
                    {
                        if (cartera == null)
                        {
                            resultado = query13.Sum(s => ((Temp_RentaVariable)s).BoPTotal);
                        }
                        else
                        {
                            if (Convert.ToBoolean(cartera))
                            {
                                resultado = query13.Sum(s => s.PosicionCartera);
                            }
                            else
                            {
                                resultado = query13.Sum(s => s.PosicionesCerradas);
                            }
                        }
                    }

                    break;
                case 21:
                    //var query21 = _secc21.Where(w => ((Temp_RentaFija)w).IsinPlantilla == isinPlantilla);
                    var query21 = _secc21.ToList();
                    if (codsInst != null)
                    {
                        query21 = query21.Where(w => codsInst.Contains(((Temp_RentaFija)w).Instrumento.Codigo)).ToList();
                    }
                    if (codsTipo != null)
                    {
                        query21 = query21.Where(w => codsTipo.Contains(((Temp_RentaFija)w).Instrumentos_Tipos.Codigo)).ToList();
                    }

                    //resultado = query21.Sum(s => s.BoPTotal);
                    resultado = query21.Sum(s => s.EfectivoFinNew - s.EfectivoIniNew);

                    break;
            }

            return resultado;
        }

        public static decimal? getCalculoVarPreciosRF(string isinPlantilla, List<int> grupos, bool? cartera)
        {
            decimal? resultado = null;
            //var query = _secc21.Where(w => ((Temp_RentaFija)w).IsinPlantilla == isinPlantilla);
            var query = _secc21.ToList();

            if (query.Count() > 0)
            {
                if (grupos != null && grupos.Count() > 0)
                {
                    query = query.Where(w => grupos.Contains(Convert.ToInt32(w.Grupo))).ToList();
                }


                if (cartera != null)
                {
                    if (Convert.ToBoolean(cartera))
                    {
                        resultado = query.Sum(s => s.PosicionCarteraNew);
                    }
                    else
                    {
                        resultado = query.Sum(s => s.PosicionesCerradasNew);
                    }
                }
                else
                {
                    //resultado = query.Sum(s => s.BoPTotal);
                    //resultado = query.Sum(s => ((Temp_RentaFija)s).BoPTotal);
                    resultado = query.Sum(s => ((Temp_RentaFija)s).EfectivoFinNew - ((Temp_RentaFija)s).EfectivoIniNew);
                }
            }

            return resultado;
        }

        private static void convertCodsInst(
        List<string> codsInst, List<string> codsTipo, List<string> codsCateg, List<string> codsEmpr,
        ref List<string> idsInstr, ref List<string> idsTipo, ref List<int?> idsCateg, ref List<int?> idsEmpre)
        {
            if (codsInst != null)
            {
                foreach (var cod in codsInst)
                {
                    var obj = _instrumentos.Where(w => w.Codigo == cod).FirstOrDefault();
                    if (obj != null)
                    {
                        idsInstr.Add(obj.Id);
                    }
                }
            }

            if (codsTipo != null)
            {
                foreach (var cod in codsTipo)
                {
                    var obj = _tipos.Where(w => w.Codigo == cod).FirstOrDefault();
                    if (obj != null)
                    {
                        idsTipo.Add(obj.Id);
                    }
                }
            }

            if (codsCateg != null)
            {
                foreach (var cod in codsCateg)
                {
                    var obj = _categorias.Where(w => w.Codigo == cod).FirstOrDefault();
                    if (obj != null)
                    {
                        idsCateg.Add(obj.Id);
                    }
                }
            }

            if (codsEmpr != null)
            {
                foreach (var cod in codsEmpr)
                {
                    var obj = _empresas.Where(w => w.Codigo == cod).FirstOrDefault();
                    if (obj != null)
                    {
                        idsEmpre.Add(obj.Id);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtrarIsin">Indicar si tenemos que pasar como parámetro el isin para recuperar el saldo al pro06</param>
        /// <param name="codInstrumento"></param>
        /// <param name="codTipoInstrumento"></param>
        /// <returns></returns>
        private static decimal getSaldoCuentasRV(bool filtrarIsin, string codInstrumento, string formulaCuentas = null, string codTipoInstrumento = null)
        {
            decimal resultado = 0;

            //var query = _secc13;

            //string idInstr = Utils.GetIdInstrumentoByCod(codInstrumento);
            //string idTipo = Utils.GetIdInstrumentoTipoByCod(codTipoInstrumento);

            //if (!string.IsNullOrEmpty(idInstr))
            //{
            //    query = query.Where(w => w.IdInstrumento == idInstr).ToList();
            //}
            //if (!string.IsNullOrEmpty(idTipo))
            //{
            //    query = query.Where(w => w.IdTipoInstrumento == idTipo).ToList();
            //}

            //List<string> isins = new List<string>();
            //if (filtrarIsin)
            //{
            //    isins = query.Select(s => s.Isin.ToUpper()).Distinct().ToList();
            //}
            //else
            //{
            //    isins.Add(string.Empty);
            //}
            //foreach (var isin in isins)
            //{
            if (!string.IsNullOrEmpty(formulaCuentas))
            {
                //resultado += Utils.CalculateFormulaCuentas(formulaCuentas, _plantilla.CodigoIc, isin, _fechaInforme);
                if (_creadaAñoInf)
                    resultado += Utils.CalculateFormulaCuentasAcumulado(formulaCuentas, _plantilla.CodigoIc, null, _fechaInicio, _fechaInforme);
                else
                    resultado += Utils.CalculateFormulaCuentas(formulaCuentas, _plantilla.CodigoIc, null, _fechaInforme);
            }
            //}       

            //Cambiamos el signo
            return -resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtrarIsin">Indicar si tenemos que pasar como parámetro el isin para recuperar el saldo al pro06</param>
        /// <param name="codInstrumento"></param>
        /// <param name="codTipoInstrumento"></param>
        /// <returns></returns>
        private static decimal getSaldoCuentasRF(bool filtrarIsin, string codInstrumento, string formulaCuentas, string codTipoInstrumento = null)
        {
            decimal resultado = 0;

            //var query = _secc21;

            //string idInstr = Utils.GetIdInstrumentoByCod(codInstrumento);
            //string idTipo = Utils.GetIdInstrumentoTipoByCod(codTipoInstrumento);

            //if (!string.IsNullOrEmpty(idInstr))
            //{
            //    query.Where(w => w.IdInstrumento == idInstr);
            //}
            //if (!string.IsNullOrEmpty(idTipo))
            //{
            //    query.Where(w => w.IdTipoInstrumento == idTipo);
            //}

            //List<string> isins = new List<string>();
            //if (filtrarIsin)
            //{
            //    isins = query.Where(w=>!string.IsNullOrEmpty(w.Isin)).Select(s => s.Isin.ToUpper()).Distinct().ToList();
            //}
            //else
            //{
            //    isins.Add(string.Empty);
            //}
            //foreach (var isin in isins)
            //{
            //resultado += Utils.CalculateFormulaCuentas(formulaCuentas, _plantilla.CodigoIc, isin, _fechaInforme);            

            if (_creadaAñoInf)
                resultado += Utils.CalculateFormulaCuentasAcumulado(formulaCuentas, _plantilla.CodigoIc, null, _fechaInicio, _fechaInforme);
            else
                resultado += Utils.CalculateFormulaCuentas(formulaCuentas, _plantilla.CodigoIc, null, _fechaInforme);


            //}

            //Cambiamos el signo
            return -resultado;
        }

        private static decimal? getCobrados(string tipo)
        {
            var pro = Reports_DA.GetPRO10(_plantilla.CodigoIc, _fechaInicio, _fechaInforme, tipo).ToList();
            var dividendos = pro.Where(w => Utils.Equals("Dividendo", w.TIPMOV)).Sum(s => s.impbru);
            var ajustes = -pro.Where(w => Utils.Equals("Ajustes", w.TIPMOV)).Sum(s => s.impbru);
            var resultado = dividendos + ajustes;
            //var imp = pro.Sum(s => s.IMPORTE);
            return resultado;
        }

        private static List<string> getDescIntrumentos(List<string> codsInst)
        {
            if (codsInst != null)
            {
                //En vez de mostrar los códigos de instrumento mostraremos su descripción larga
                var descInstr = new List<string>();


                foreach (var inst in codsInst)
                {
                    string desc = string.Empty;

                    if (inst != "MMO")
                    {
                        desc = Utils.GetDescInstrumentoByCod(inst);
                        if (string.IsNullOrEmpty(desc))
                        {
                            desc = inst;
                        }
                    }
                    else
                    {
                        //Queremos mostrar MMO con una desc más corta, no queremos que salga "MERCADO MONETARIO / LIQUIDEZ" que es lo que tiene en la tabla Instrumentos
                        desc = "MERCADO MONETARIO";
                    }

                    descInstr.Add(desc.ToUpper());

                }
                return descInstr;
            }
            else
            {
                return null;
            }
        }

        private static List<string> getDescTipos(List<string> cods)
        {
            if (cods != null)
            {
                //En vez de mostrar los códigos mostraremos su descripción larga
                var descList = new List<string>();


                foreach (var inst in cods)
                {
                    string desc = string.Empty;

                    desc = Utils.GetDescInstrumentosTipoByCod(inst);
                    if (string.IsNullOrEmpty(desc))
                    {
                        desc = inst;
                    }

                    descList.Add(desc.ToUpper());
                }

                return descList;
            }
            else
                return null;
        }

        private static List<string> getDescCategorias(List<string> cods)
        {
            if (cods != null)
            {
                //En vez de mostrar los códigos mostraremos su descripción larga
                var descList = new List<string>();


                foreach (var inst in cods)
                {
                    string desc = string.Empty;

                    desc = Utils.GetDescInstrumentosCategoriaByCod(inst);
                    if (string.IsNullOrEmpty(desc))
                    {
                        desc = inst;
                    }

                    descList.Add(desc.ToUpper());
                }

                return descList;
            }
            else
                return null;
        }

        private static List<string> getDescEmpresas(List<string> cods)
        {
            if (cods != null)
            {
                //En vez de mostrar los códigos mostraremos su descripción larga
                var descList = new List<string>();


                foreach (var inst in cods)
                {
                    string desc = string.Empty;

                    desc = Utils.GetDescInstrumentosEmpresaByCod(inst);
                    if (string.IsNullOrEmpty(desc))
                    {
                        desc = inst;
                    }

                    descList.Add(desc.ToUpper());
                }

                return descList;
            }
            else
                return null;
        }

        public static Temp_VariacionPatrimonialA getTemp(
        string isinPlantilla,
        decimal? cartera,
        decimal? ventas,
        List<string> codsInst,
        decimal? otros = null,
        decimal? totalPrecios = null,
        List<string> codsTipo = null,
        List<string> codsCateg = null,
        List<string> codsEmpr = null,
        decimal? cobrados = null,
        decimal? totalIngresos = null,
        decimal? bopPrecio = null,
        decimal? bopDivisa = null
        )
        {
            try
            {
                //En vez de mostrar los códigos mostraremos su descripción larga
                var descInstr = getDescIntrumentos(codsInst);
                var descTipos = getDescTipos(codsTipo);
                var descCat = getDescCategorias(codsCateg);
                var descEmp = getDescEmpresas(codsEmpr);

                var temp = new Temp_VariacionPatrimonialA();
                temp.CodigoIC = _plantilla.CodigoIc;
                temp.IsinPlantilla = isinPlantilla;
                //temp.CodsInstrumento = codsInst != null ? string.Join(",", codsInst) : null;            
                temp.CodsInstrumento = codsInst != null ? string.Join(",", descInstr) : null;
                temp.CodsTipoInstrumento = descTipos != null ? string.Join(",", descTipos) : null;
                temp.CodsCategoria = descCat != null ? string.Join(",", descCat) : null;
                temp.CodsEmpresa = descEmp != null ? string.Join(",", descEmp) : null;
                temp.Cartera = cartera != null ? cartera : 0;
                temp.Ventas = ventas != null ? ventas : 0;
                temp.BoPPrecio = bopPrecio;
                temp.BoPDivisa = bopDivisa;
                temp.TotalPrecios = totalPrecios != null ? totalPrecios : temp.Cartera + temp.Ventas;

                //if (cobrados != null || totalIngresos != null)
                if (cobrados != null)
                {
                    temp.Cobrados = cobrados;
                    temp.DevengadosPtesCobrar = (totalIngresos != null ? totalIngresos : 0) - (cobrados != null ? cobrados : 0);
                }

                temp.TotalIngresos = totalIngresos;
                temp.Otros = otros;

                return temp;
            }
            catch(Exception ex)
            {
                Log.Error("Error VariacionPatrimonialA_VM/getTemp", ex);
                throw;
            }
        }

        
        public static string Validar(string codigoIC, Seccione seccion, DateTime fecha)
        {
            try
            {
                string resultado = null;

                resultado += validarCiclicoDefensivo(codigoIC, seccion);
                resultado += validarSmallLarge(codigoIC, seccion);
                resultado += validarTotalPreciosVariacion(codigoIC, seccion);
                resultado += validarTotales(codigoIC, seccion);
                resultado += validarTotalPatrimonio(codigoIC, seccion, fecha);

                ////Añadimos el título de la sección al principio del mensaje. 
                ////Lo añadimos en este momento porque podemos tener varias validaciones
                //if (!string.IsNullOrEmpty(resultado))
                //{
                //    resultado = seccion.Descripcion + resultado;
                //}

                return resultado;
            }
            catch(Exception ex)
            {
                Log.Error("Error VariacionPatrimonialA_VM/Validar", ex);
                throw;
            }
        }

        /// <summary>
        /// El campo TotalPrecios de RVA/Valores tiene que ser igual que la suma del mismo campo para RVA/VALORES/CÍCLICO y RVA/VALORES/DEFENSIVO
        /// En caso contrario mostramos alerta con la diferencia
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        private static string validarCiclicoDefensivo(string codigoIC, Seccione seccion)
        {
            string resultado = null;
            decimal rvaValTotalPrec = 0;
            decimal rvaValCicTotalPrec = 0;
            decimal rvaValDefTotalPrec = 0;

            var temp = VariacionPatrimonialA_DA.GetTemp(codigoIC);

            var rvaVal = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == null
                                            && w.CodsEmpresa == null).FirstOrDefault();

            var rvaValCic = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == "CÍCLICO"
                                            && w.CodsEmpresa == null).FirstOrDefault();

            var rvaValDef = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == "DEFENSIVO"
                                            && w.CodsEmpresa == null).FirstOrDefault();

            rvaValTotalPrec = rvaVal != null ? (rvaVal.TotalPrecios ?? 0) : 0;
            rvaValCicTotalPrec = rvaValCic != null ? (rvaValCic.TotalPrecios ?? 0) : 0;
            rvaValDefTotalPrec = rvaValDef != null ? (rvaValDef.TotalPrecios ?? 0) : 0;

            var diferencia = rvaValTotalPrec - rvaValCicTotalPrec - rvaValDefTotalPrec;

            //Si no coinciden tenemos que mostrar alerta
            if (decimal.Round(diferencia,2) != 0)
            {
                resultado += Environment.NewLine;
                resultado += string.Format(Resource.AlertaVarPatrADescuadreCicDef, Math.Abs(diferencia));
            }

            return resultado;
        }

        /// <summary>
        /// El campo TotalPrecios de RVA/Valores tiene que ser igual que la suma del mismo campo para RVA/VALORES/SMALL,MID y RVA/VALORES/LARGE
        /// En caso contrario mostramos alerta con la diferencia
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        private static string validarSmallLarge(string codigoIC, Seccione seccion)
        {
            string resultado = null;
            decimal rvaValTotalPrec = 0;
            decimal rvaValSmallMidTotalPrec = 0;
            decimal rvaValLarTotalPrec = 0;

            var temp = VariacionPatrimonialA_DA.GetTemp(codigoIC);

            var rvaVal = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == null
                                            && w.CodsEmpresa == null).FirstOrDefault();

            var rvaValSmallMid = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == null
                                            && w.CodsEmpresa == "SMALL,MID").FirstOrDefault();

            var rvaValLar = temp.Where(w => w.CodsInstrumento == "RENTA VARIABLE"
                                            && w.CodsTipoInstrumento == "VALORES"
                                            && w.CodsCategoria == null
                                            && w.CodsEmpresa == "LARGE").FirstOrDefault();

            rvaValTotalPrec = rvaVal != null ? (rvaVal.TotalPrecios ?? 0) : 0;
            rvaValSmallMidTotalPrec = rvaValSmallMid != null ? (rvaValSmallMid.TotalPrecios ?? 0) : 0;
            rvaValLarTotalPrec = rvaValLar != null ? (rvaValLar.TotalPrecios ?? 0) : 0;

            var diferencia = rvaValTotalPrec - rvaValSmallMidTotalPrec - rvaValLarTotalPrec;

            //Si no coinciden tenemos que mostrar alerta
            if (decimal.Round(diferencia, 2) != 0)
            {
                resultado += Environment.NewLine;
                resultado += string.Format(Resource.AlertaVarPatrADescuadreSmallMidLar, Math.Abs(diferencia));
            }

            return resultado;
        }

        /// <summary>
        /// La suma de la columna TOTAL tiene que coincidir con la suma de la fila TOTAL RENDIMIENTOS
        /// En caso contrario mostramos alerta con la diferencia
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        private static string validarTotales(string codigoIC, Seccione seccion)
        {
            string resultado = null;
            decimal colTotal = 0;
            decimal filaTotalRendimientos = 0;

            //Como la recuperación de datos para esta sección funciona de forma distinta para cada línea
            //Vamos a ir haciendo los cálculos por partes
            //Para calcular la colTotal tenemos que sumar TotalPrecios + TotalIngresos + Otros para cada instrumento
            //pero no todos los datos están en la misma línea siempre

            var temp = VariacionPatrimonialA_DA.GetTemp(codigoIC);

            #region colTotal            

            var rva = getTemp(temp, "RENTA VARIABLE", null, null, null);
            var rvaVal = getTemp(temp, "RENTA VARIABLE", "VALORES", null, null);
            var rvaIIC = getTemp(temp, "RENTA VARIABLE", "IIC", null, null);
            var rvaDER = getTemp(temp, "RENTA VARIABLE", "DERIVADOS", null, null);
            var rfi = getTemp(temp, "RENTA FIJA", null, null, null);
            var rfiVal = getTemp(temp, "RENTA FIJA", "VALORES", null, null);
            var rfiIIC = getTemp(temp, "RENTA FIJA", "IIC", null, null);
            var rfiDer = getTemp(temp, "RENTA FIJA", "DERIVADOS", null, null);
            var rabIIC = getTemp(temp, "RETORNO ABSOLUTO", "IIC", null, null);
            var rabPAT = getTemp(temp, "RETORNO ABSOLUTO", "PATRIMONIALISTA", null, null);
            var rabCCP = getTemp(temp, "RETORNO ABSOLUTO", "CCCP", null, null);
            //var rabPER = getTemp(temp, "RETORNO ABSOLUTO", "PER", null, null);
            var rabPER = getTemp(temp, "RETORNO ABSOLUTO", "PERSISTENCIA", null, null);
            var rabOTR = getTemp(temp, "RETORNO ABSOLUTO", "OTR", null, null);
            var mmo = getTemp(temp, "MERCADO MONETARIO", null, null, null);
            var div = getTemp(temp, "DIVISAS", null, null, null);
            var com = getTemp(temp, "COMODITIES", null, null, null);
            var otros = getTemp(temp, "OTROS", null, null, null);

            //Para cada instrumento tenemos que recuperar TotalPrecios, TotalIngresos y Otros

            #region RVA
            var totalPreciosRva = getTotalPrecios(rvaVal) + getTotalPrecios(rvaIIC) + getTotalPrecios(rvaDER);
            var rvaTotaIngresos = getTotalIngresos(rva);
            var rvaTotaOtros = getOtros(rva);
            var totalRVA = totalPreciosRva + rvaTotaIngresos + rvaTotaOtros;
            #endregion

            #region RFI
            var totalPreciosRfi = getTotalPrecios(rfiVal) + getTotalPrecios(rfiIIC) + getTotalPrecios(rfiDer);
            var rfiTotaIngresos = getTotalIngresos(rfi);
            var rfiTotaOtros = getOtros(rfi);
            var totalRFI = totalPreciosRfi + rfiTotaIngresos + rfiTotaOtros;
            #endregion

            #region RAB
            var totalPreciosRab = getTotalPrecios(rabIIC) + getTotalPrecios(rabPAT) + getTotalPrecios(rabCCP) + getTotalPrecios(rabPER) + getTotalPrecios(rabOTR);
            var rabTotaIngresos = getTotalIngresos(rabIIC) + getTotalIngresos(rabPAT) + getTotalIngresos(rabCCP) + getTotalIngresos(rabPER) + getTotalIngresos(rabOTR);
            var rabTotaOtros = getOtros(rabIIC) + getOtros(rabPAT) + getOtros(rabCCP) + getOtros(rabPER) + getOtros(rabOTR);
            var totalRAB = totalPreciosRab + rabTotaIngresos + rabTotaOtros;
            #endregion

            #region MMO
            var totalPreciosMmo = getTotalPrecios(mmo);
            var mmoTotaIngresos = getTotalIngresos(mmo);
            var mmoTotaOtros = getOtros(mmo);
            var totalMMO = totalPreciosMmo + mmoTotaIngresos + mmoTotaOtros;
            #endregion

            #region DIV            
            var totalPreciosDiv = getTotalPrecios(div);
            var divTotaIngresos = getTotalIngresos(div);
            var divTotaOtros = getOtros(div);
            var totalDiv = totalPreciosDiv + divTotaIngresos + divTotaOtros;
            #endregion

            #region COMODITIES            
            var totalPreciosCom = getTotalPrecios(com);
            var comTotaIngresos = getTotalIngresos(com);
            var comTotaOtros = getOtros(com);
            var totalCom = totalPreciosCom + comTotaIngresos + comTotaOtros;
            #endregion

            #region OTR
            var totalPreciosOtr = getTotalPrecios(otros);
            var otrTotaIngresos = getTotalIngresos(otros);
            var otrTotaOtros = getOtros(otros);
            var totalOTR = totalPreciosOtr + otrTotaIngresos + otrTotaOtros;
            #endregion

            colTotal = totalRVA + totalRFI + totalRAB + totalMMO + totalDiv + totalCom + totalOTR;

            #endregion

            #region filaTotalRendimientos
            var rend = getTemp(temp, "TOTAL RENDIMIENTOS", null, null, null);
            
            var totalPreciosRend = getTotalPrecios(rend);
            var RendTotaIngresos = getTotalIngresos(rend);
            var RendTotaOtros = getOtros(rend);

            filaTotalRendimientos = totalPreciosRend + RendTotaIngresos + RendTotaOtros;
            #endregion

            //Comprobamos si existe diferencia entre colTotal y filaTotalRendimientos
            var diferencia = colTotal - filaTotalRendimientos;

            //Si no coinciden tenemos que mostrar alerta
            if (decimal.Round(diferencia, 2) != 0)
            {
                try
                {
                    resultado += Environment.NewLine;
                    //var aaa = string.Format("aaaaa {0:N2}", diferencia);
                    resultado += string.Format(Resource.AlertaVarPatrADescuadreColTotalFilaTotal, Math.Abs(diferencia));
                }
                catch(Exception ex)
                {
                    Log.Error("Error VariacionPatrimonialA_VM/validarTotales", ex);
                    throw;
                }
            }

            return resultado;
        }

        private static string validarTotalPatrimonio(string codigoIC, Seccione seccion, DateTime fechaInforme)
        {
            string resultado = null;

            var totales = VariacionPatrimonialA_DA.Get_VariacionPatrimonialA_Totales(codigoIC);

            #region Patrimonio a 31/12 del ejercicio anterior
            var añoAnterior = new DateTime(fechaInforme.Year - 1, 12, 31);

            //Puede que nos dispongamos del objeto _plantilla si llegamos aquí a través de la opción "Ver último generado"
            if (_plantilla == null)
            {
                _plantilla = Plantillas_DA.GetPlantilla(codigoIC);
            }

            decimal patrAnt = VariacionPatrimonialA_DA.GetTotalPatrimonioAnt(codigoIC);

            //foreach (var isin in _plantilla.Plantillas_Isins)
            //{
            //  patrAnt += Utils.GetPatrimonio(_plantilla.CodigoIc, isin.Isin.ToUpper(), añoAnterior);
            //}
            #endregion

            #region Ampliaciones de capital / Reducciones de capital / Autocartera
            //var ampl = Convert.ToDecimal(ReportFunctions.VarPatrA_AmpliacReduccCart(codigoIC, fechaInforme));
            var ampl = VariacionPatrimonialA_DA.GetSuscripcionesAmpliaciones(codigoIC);
            #endregion

            #region Rendimientos
            decimal rend = totales != null && totales.TotalRendimientos != null ? (decimal)totales.TotalRendimientos : 0;
            #endregion

            #region Gastos gestión corriente y Servicios Exteriores
            decimal gest = totales != null && totales.TotalGastosGestion != null ? (decimal)totales.TotalGastosGestion : 0;
            #endregion

            #region Impuesto Sociedades
            decimal impS = totales != null && totales.TotalImpuestoSociedades != null ? (decimal)totales.TotalImpuestoSociedades : 0;
            #endregion

            #region Patrimonio a fecha informe
            decimal patrFin = totales != null && totales.TotalPatrimonioFechaInforme != null ? (decimal)totales.TotalPatrimonioFechaInforme : 0;
            #endregion

            //Comprobamos si existe diferencia entre colTotal y filaTotalRendimientos
            var diferencia = patrAnt + ampl + rend + gest + impS - patrFin;

            //Si no coinciden tenemos que mostrar alerta
            if (decimal.Round(diferencia, 0) != 0)
            {
                try
                {
                    resultado += Environment.NewLine;
                    resultado += string.Format(Resource.AlertaVarPatrADescuadrePatrimonioFinal, Math.Abs(diferencia));
                }
                catch (Exception ex)
                {
                    Log.Error("Error VariacionPatrimonialA_VM/validarTotalPatrimonio", ex);
                    throw;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Recupera el campo TotalPrecios cuando se le pasa un Temp_VariacionPatrimonialA evitando que devuelva null.
        /// En caso de null pondrá 0 para poder realizar posteriormente los cálculos correctamente
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static decimal getTotalPrecios(List<Temp_VariacionPatrimonialA> temp)
        {
            return temp != null ? (temp.Sum(s=>s.TotalPrecios) ?? 0) : 0;
        }

        private static decimal VarPatrA_AmpliacReduccCart(string codigoIC, DateTime fechaInforme)
        {
            //var codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            //var fechaInforme = Convert.ToDateTime(this.ReportParameters["FechaInforme"].Value.ToString());

            var plantilla = Plantillas_DA.GetPlantilla(codigoIC);

            //Si es fondo haremos el cálculo con unas cuentas y si es sicav lo haremos con otras
            bool esFondo = plantilla.IdTipo == 2 ? true : false;

            //Recuperamos las cuentas
            var cuentas = VariacionPatrimonialA_DA.GetCuentas(esFondo);
            decimal saldo = 0;

            var formula = string.Join("] + [", cuentas.Select(s => s.Cuenta).ToList());
            formula = string.Format("{0}" + formula + "{1}", "[", "]");
            //foreach (var isin in plantilla.Plantillas_Isins)
            //{
            foreach (var cuenta in cuentas)
            {
                DateTime fechaInicio;

                //Si la cuenta empieza por 6 o por 7 no tendremos que hacer la diferencia del periodo
                //Cogemos saldo a fechaInforme
                if (cuenta.Cuenta.StartsWith("6") || cuenta.Cuenta.StartsWith("7"))
                {
                    //Recuperamos el saldo a fechaInforme
                    var tmp = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInforme);
                    saldo += tmp;
                }
                else
                {                   
                    fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme), typeof(Temp_VariacionPatrimonialA));



                    //Hacemos la diferencia entre fecha fin y fecha inicio
                    var saldoIni = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInicio);
                    var saldoFin = Utils.CalculateFormulaCuentas(string.Format("[{0}]", cuenta.Cuenta), plantilla.CodigoIc, null, fechaInforme);
                    saldo += saldoFin - saldoIni;


                    /*
                    var pro = Reports_DA.GetPRO23(codigoIC, null, cuenta.Cuenta, fechaInicio, fechaInforme);

                    if (pro != null && pro.Count() > 0)
                    {
                        var tmp = pro.FirstOrDefault().impeur != null ? Convert.ToDecimal(pro.FirstOrDefault().impeur) : 0;
                        saldo += tmp;
                    }
                    */
                }
            }
            //}

            //Cambiamos el signo
            return (-1 * saldo);
        }

        /// <summary>
        /// Recupera el campo TotalIngresos cuando se le pasa un Temp_VariacionPatrimonialA evitando que devuelva null.
        /// En caso de null pondrá 0 para poder realizar posteriormente los cálculos correctamente
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static decimal getTotalIngresos(List<Temp_VariacionPatrimonialA> temp)
        {
            return temp != null ? (temp.Sum(s => s.TotalIngresos) ?? 0) : 0;
        }

        /// <summary>
        /// Recupera el campo Otros cuando se le pasa un Temp_VariacionPatrimonialA evitando que devuelva null.
        /// En caso de null pondrá 0 para poder realizar posteriormente los cálculos correctamente
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static decimal getOtros(List<Temp_VariacionPatrimonialA> temp)
        {
            return temp != null ? (temp.Sum(s => s.Otros) ?? 0) : 0;
        }

        public static List<Temp_VariacionPatrimonialA> getTemp(List<Temp_VariacionPatrimonialA> temp, string codsInstrumento, string codsTipoInstrumento, string codsCategoria, string codsEmpresa)
        {
            return temp.Where(w => w.CodsInstrumento == codsInstrumento
                                            && w.CodsTipoInstrumento == codsTipoInstrumento
                                            && w.CodsCategoria == codsCategoria
                                            && w.CodsEmpresa == codsEmpresa).ToList();
        }

        private static string validarTotalPreciosVariacion(string codigoIC, Seccione seccion)
        {
            string resultado = null;

            //Comprobamos que el campo TotalPrecios para la fila OTROS no supera el parámetro (en valor absoluto) establecido
            //var maxVar = Utils.CheckDecimal(ConfigurationManager.AppSettings["5_Variacion_Patrimonial_A_Alerta_Otros"]);
            //test ACC 01/04/2019 start
            var PatAnt = VariacionPatrimonialA_DA.GetPatrimonioIni(codigoIC);
            var PatAntnum = Math.Abs(Convert.ToDecimal(PatAnt));
            var RelativemaxVar = Math.Abs((PatAntnum*6/10)/100);
            //test ACC 01/04/2019 end (falta assignar al resultat per alerta i revisar quin percentatge volen)

            //if (maxVar != null)
            if (RelativemaxVar != 0) //test ACC
            {
                var descuadre = VariacionPatrimonialA_DA.GetDescuadrePrecios(codigoIC);
                if (descuadre != null)
                {
                    //Si el descuadre supera el valor del parámetro tenemos que mostrar alerta
                    //if ((Math.Abs(Convert.ToDecimal(descuadre)) > maxVar))
                    if ((Math.Abs(Convert.ToDecimal(descuadre)) > RelativemaxVar)) //test ACC
                    {
                        resultado += Environment.NewLine;
                        resultado += string.Format(Resource.AlertaVarPatrADescuadrePrecios, descuadre);
                        //RadWindow.Alert(new TextBlock { Text = mens, TextWrapping = TextWrapping.Wrap, Width = 400 });
                    }
                }
            }

            return resultado;
        }

        public static Report GetReport(Plantilla plantilla, int idSeccion, DateTime fechaInforme)
        {
            Report rep = new ReportVariacionPatrimonialA();

            //var añoAnterior = new DateTime(fechaInforme.Year - 1, 12, 31);

            ////Puede que nos dispongamos del objeto _plantilla si llegamos aquí a través
            ////de la opción "Ver último generado"


            //decimal totalPatrimonioAnt = 0;

            //foreach (var isin in _plantilla.Plantillas_Isins)
            //{
            //    totalPatrimonioAnt += Utils.GetPatrimonio(_plantilla.CodigoIc, isin.Isin.ToUpper(), añoAnterior);
            //}

            rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            //rep.ReportParameters["Isin"].Value = isinPlantilla;
            rep.ReportParameters["Isin"].Value = null;
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            rep.ReportParameters["TipoPlantilla"].Value = plantilla.IdTipo;
            rep.ReportParameters["IdSeccion"].Value = idSeccion;
            //rep.ReportParameters["TotalPatrimonioAnt"].Value = totalPatrimonioAnt;

            return rep;
        }

    }
}
 