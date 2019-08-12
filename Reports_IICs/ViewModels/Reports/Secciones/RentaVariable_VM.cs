using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.Renta_Variable;
using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataAccess.Managers;
using Reports_IICs.Resources;
using static Reports_IICs.Helpers.VariablesGlobales;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class RentaVariable_VM
    {
        public static List<Seccione> DataItems => null;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static DateTime _fechaInicio;
        private static DateTime _fechaInforme;
        private static Plantilla _plantilla;
        private static List<usp_gestio_pro_13_Result> _pro13;
        private static List<usp_gestio_pro_22_Result> _pro22;
        private static IEnumerable<usp_gestio_pro_11_Result> _cart;
        private static List<RentaVariable_PrecioAjustado> _preciosAj = null;
        private static List<CuentasContablesDerivado> _ctasDerivados;
        private const string G1Text = "GRUPO-01-Valor en cartera no vendido en el periodo";
        private const string G2Text = "GRUPO-02-Valor en cartera vendido en el periodo";
        private const string G3Text = "GRUPO-03-Valor comprado y vendido en el periodo";
        private const string G4Text = "GRUPO-04-Valor comprado en el periodo y no vendido";

        public static void Insert_Temp(Plantilla plantilla, DateTime fechaInforme, ref List<TempTableBase> listaTmp)
        {
            try
            {
                _preciosAj = null;
                _fechaInforme = fechaInforme;
                _plantilla = plantilla;
                DateTime fechaInicio = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));
                _fechaInicio = fechaInicio;
                _pro13 = Utils.GetPro13SeccRv(_plantilla, _fechaInforme);

                //Tenemos que cargar Pro22_Local porque es una preview y no se ha cargado el procedimiento
                if (Pro22_Local == null)
                {
                    SetVariablesGlobales(typeof(usp_gestio_pro_22_Result), plantilla, fechaInforme);
                }
                _pro22 = Pro22_Local;
                
                //Tenemos que cargar Pro11_Local porque es una preview y no se ha cargado el procedimiento
                if (Pro11_Local == null)
                {
                    SetVariablesGlobales(typeof(usp_gestio_pro_11_Result), plantilla, fechaInforme);
                }
                _cart = Pro11_Local;
                _ctasDerivados = Reports_DA.GetCuentasDerivados();

                var precAj = RentaVariable_DA.GetPreciosAjustados(_plantilla.CodigoIc, _fechaInforme);
                if (precAj.Count() > 0)
                {
                    _preciosAj = precAj;
                }

                #region OPERACIONES CORPORATIVAS
                Tratar808();//CONTRASPLIT Y CAMBIO DE ISIN      
                tratar601();//TRASPASOS
                //tratar817();//EQUIPARACIONES
                #endregion

                try
                {
                    if (precAj.Count() > 0)
                    {
                        PrecAjG4();

                    }
                    
                    var listaFinal = AgruparProc(plantilla, string.Empty);
                    listaTmp.AddRange(listaFinal);
                }
                catch (Exception ex)
                {
                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error Utils/RecuperarDatosExcel", ex);
                    // Compliance                                           
                    throw;
                }
                
                //Quitamos los eliminados manualmente en la preview
                quitarEliminados(ref listaTmp);

                recalcularPLPct(ref listaTmp);
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error Utils/RecuperarDatosExcel", ex);
                // Compliance                                           
                throw;
            }
        }

        /// <summary>
        /// Recalculamos la columna % (PlPct)
        /// Esto tiene que ser hecho después de la agrupación
        /// </summary>
        /// <param name="listaTmp"></param>
        private static void recalcularPLPct(ref List<TempTableBase> listaTmp)
        {
            var itemsRV = listaTmp.Where(w => w.GetType() == new Temp_RentaVariable().GetType()).Select(s => (Temp_RentaVariable)s).ToList();
            foreach (var item in itemsRV)
            {
                try
                {
                    if (item.GrupoNuevo != null)
                    {
                        var precioIni = new List<int>() { 1, 2 }.Contains((int)item.GrupoNuevo) ? item.PrecioI : item.PrecioO;
                        if (item.PrecioAjustado != null)
                        {
                            precioIni = item.PrecioAjustado;
                        }
                        var cambioIni = new List<int>() { 1, 2 }.Contains((int)item.GrupoNuevo) ? item.CambioI : item.CambioO;
                        var precioFin = new List<int>() { 1, 4 }.Contains((int)item.GrupoNuevo) ? item.PrecioF : item.PrecioC;
                        var cambioFin = new List<int>() { 1, 4 }.Contains((int)item.GrupoNuevo) ? item.CambioF : item.CambioC;

                        var denom = item.NumTit * precioIni * cambioIni;
                        if (denom != 0)
                        {
                            item.BoPTotalPorcentaje = ((item.NumTit * precioFin * cambioFin) / denom) - 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error RentaVariable_VM/recalcularPLPct", ex);
                    // Compliance                                           
                    throw;
                }
            }
        }

        /// <summary>
        /// Cuando son ampliaciones de capital TipMovO = 816 las queremos en el grupo 1
        /// </summary>
        /// <summary>
        /// En el momento en el que se añade un Precio Ajustado para un isin puede que en el futuro volvamos
        /// a generar el mismo informe en una fecha futura y tengamos más número de títulos para ese ISIN.
        /// Para que se tenga en cuenta ese precio ajustado para todos los movimientos agrupados en la línea
        /// que se modificó necesitamos este procedimiento.
        /// </summary>
        private static void PrecAjG4()
        {
            var isinsAdded = new List<string>();
            try
            {
                //Nos quedaremos sólo con el más reciente para cada ISIN. Si han ajustado el precio de un ISIN
                //en varias ocasiones, es probable que el más reciente sea el que más se aproxime a lo que 
                //buscamos
                var ajG4 = _preciosAj.Where(w => w.CodigoIC == _plantilla.CodigoIc
                            //&& w.Grupo.Contains("04")
                            && w.FechaInforme <= _fechaInforme
                            && w.IsVisible)
                            .OrderBy(o => o.Isin).ThenByDescending(t => t.FechaInforme).ToList();

                foreach (var item in ajG4)
                {
                    //Esto lo necesitamos porque el Precio fin y tipo cambio fin los cogeremos siempre del PRO13
                    //En caso de que se haya añadido el item en la Preview y no venga en el PRO13, lo cogeríamos del "item" de ajG4
                    var objIsin = _pro13.FirstOrDefault(w => w.Isin.ToUpper() == item.Isin.ToUpper());

                    //Si tenemos operaciones para el ISIN del precio ajustado posteriores a la fecha de informe de dicho ajuste, tenemos que recalcular
                    //Este caso es, por ejemplo, el de las ampliaciones de capital
                    var objEquiv = RentaVariable_Equivalencias_Local.FirstOrDefault(w => w.OldIsin == item.Isin.ToUpper());
                    var operPost = _pro13.Where(w => w.Isin.ToUpper() == item.Isin.ToUpper()
                                        && (w.FechaC != null && (DateTime)w.FechaC > item.FechaInforme)
                                        ).ToList();
                    if (objEquiv != null)
                    {
                        operPost = _pro13.Where(w => w.Isin.ToUpper() == item.Isin.ToUpper()
                                            && (((w.FechaC != null && (DateTime)w.FechaC > item.FechaInforme)
                                            && w.FechaO < objEquiv.FechaEquiparacion)
                                            || (w.FechaC == null && w.FechaO < objEquiv.FechaEquiparacion))).ToList();
                    }
                    else
                    {
                        operPost = _pro13.Where(w => w.Isin.ToUpper() == item.Isin.ToUpper()
                                        && (w.FechaC != null && (DateTime)w.FechaC > item.FechaInforme)                                        
                                        ).ToList();
                    }
                    

                    if (operPost.Count > 0
                        && (item.GrupoNuevo == 1 || item.GrupoNuevo == 4))
                    {
                        //Esto afectará a NumTit de los grupos 1 (1-2)  y 4 (4-3)
                        //Si se han producido ventas posteriores al ajuste, habrá que restar ese número de títulos
                        item.NumeroTitulos -= operPost.Sum(s => s.NumTit);
                        
                        //El precio de compra de las operaciones posteriores lo modificamos para que sea el mismo que el precio ajustado
                        operPost.Where(w => w.GrupoNuevo == 2).ToList().ForEach(i => i.PrecioI = item.PrecioAjustado);                        
                        if (item.PrecioAjustado != null)
                        {
                            operPost.Where(w => w.GrupoNuevo == 3).ToList().ForEach(i =>
                            {
                                if (item.PrecioAjustado != null) i.PrecioO = (decimal) item.PrecioAjustado;
                            });
                        }
                    }

                    //Sólo tendremos en cuenta el último precio ajustado (con una fecha menor o igual a la fecha de informe actual)
                    //No podemos añadir dos ISINS iguales en el mismo grupo pero sí en grupos distintos
                    
                    //añadimos el isin a la lista para no volver a hacer esto para otros precios ajustados antiguos con el mismo ISIN
                    isinsAdded.Add(item.Isin.ToUpper());
                    var listaBorrar = new List<usp_gestio_pro_13_Result>();

                    //Sólo seguimos si todos los movimientos que conformababan este precio ajustado se encuentran
                    //en el PRO13. Puede que haya varios P.A. para el mismo movimiento (en distintas agrupaciones)
                    //tendríamos que coger la agrupación que tenga la fecha más reciente a la fecha del informe
                    var numO_precAj = item.RentaVariable_PrecioAjustado_NumO.Select(s => s.NumO).OrderBy(o => o).ToList();
                    var numO_pro13 = _pro13.Select(s => s.NumO).OrderBy(o => o).ToList();
                    bool contained = !numO_precAj.Except(numO_pro13).Any();                    

                    //Como permitimos añadir nuevos elementos en la Preview, puede que haya Precios Ajustados sin NumO
                    
                    if (contained 
                        //|| item.RentaVariable_PrecioAjustado_NumO.Count > 0 //Cambios de ISIN
                        )
                    {
                        //vamos a eliminar del _pro13 los movimientos que conformaban ese precio ajustado
                        if (item.RentaVariable_PrecioAjustado_NumO.Count > 0
                            //caso de ampliaciones de capital o cuando hay operaciones posteriores a la fecha de informe de cuando se realizó el ajuste
                            //en este caso no las borramos porque las mostraremos como ventas y acabamos de ajustar el número de títulos del precio ajustado
                            //&& !(operPost.Count > 0 && (item.GrupoNuevo == 1 || item.GrupoNuevo == 4)) 
                            && (//operPost.Count > 0 && //Creo que ya no tenemos que tener en cuenta si hay posteriores
                                (item.GrupoNuevo == 1 || item.GrupoNuevo == 4)
                                )
                            )
                        {
                            foreach (var itemNumO in item.RentaVariable_PrecioAjustado_NumO)
                            {
                                //vamos a eliminar del _pro13 los movimientos que conformaban ese precio ajustado
                                var objBorrar = _pro13.FirstOrDefault(w => w.NumO == itemNumO.NumO);

                                if (objBorrar != null)
                                {
                                    if (item.PrecioAjustado != null)
                                    {
                                        objBorrar.PrecioI = item.PrecioAjustado;
                                    }
                                    if (item.PrecioAjustado != null)
                                    {
                                        objBorrar.PrecioO = Convert.ToDecimal(item.PrecioAjustado);
                                        objBorrar.PrecioOA = Convert.ToDecimal(item.PrecioAjustado);
                                    }
                                    listaBorrar.Add(objBorrar);
                                }
                            }
                        }
                        //y vamos a añadir una única línea con su precio ajustado
                        var objAdd = new usp_gestio_pro_13_Result();
                        Utils.CopyPropertyValues(item, objAdd);

                        objAdd.IdPrecioAjustado = item.Id;
                        objAdd.Nombre = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.Nombre).First() : item.Descripcion;
                        objAdd.IdInstrumento = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.IdInstrumento).First() : InstrumentosImportados_DA.GetIdInstrumentoImportadoByIsin(item.Isin);
                        objAdd.IdTipoInstrumento = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.IdTipoInstrumento).First() : InstrumentosImportados_DA.GetIdTipoInstrumentoImportadoByIsin(item.Isin);
                        objAdd.IdCategoria = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.IdCategoria).First() : InstrumentosImportados_DA.GetIdCategoriaInstrumentoImportadoByIsin(item.Isin);
                        objAdd.IdEmpresa = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.IdEmpresa).First() : InstrumentosImportados_DA.GetIdEmpresaInstrumentoImportadoByIsin(item.Isin);
                        objAdd.Divisa = listaBorrar.Count > 0 ? listaBorrar.Select(f => f.Divisa).First() : string.Empty;
                        
                        objAdd.NumTit = item.NumeroTitulos;
                        objAdd.Dividendos = listaBorrar.Count > 0 ? listaBorrar.Sum(a => (a.Dividendos)) : 0;
                        objAdd.EfectivoFEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.EfectivoFEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada //Si listaBorrar no tiene items ponemos 0 porque este campo es autocalculado 
                        objAdd.EfectivoIAEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.EfectivoIAEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada 
                        objAdd.EfectivoIEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.EfectivoIEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada 
                        objAdd.PLDiv = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PLDiv * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada                             
                        objAdd.PLEur = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PLEur * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada                             
                        objAdd.PLPct = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PLPct * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada                             
                        objAdd.PLPrecio = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PLPrecio * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : 0;//Media ponderada                             
                        objAdd.PrecioAjustado = item.PrecioAjustado;
                        
                        if (objIsin != null)
                        {
                            objAdd.PrecioC = objIsin.PrecioC ?? objIsin.PrecioF;
                            objAdd.PrecioF = objIsin.PrecioF;
                            
                            objAdd.PrecioFEUR = objIsin.PrecioFEUR;
                            objAdd.CambioC = objIsin.CambioC ?? objIsin.CambioF;
                            objAdd.CambioF = objIsin.CambioF ?? objIsin.CambioC;
                        }
                        else
                        {
                            objAdd.PrecioC = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioC * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioFin != null ? (decimal)item.PrecioFin : 0);//Media ponderada 
                            objAdd.PrecioF = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioF * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioFin != null ? (decimal)item.PrecioFin : 0);//Media ponderada 
                            objAdd.PrecioFEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioFEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioFinEuros != null ? (decimal)item.PrecioFinEuros : 0);//Media ponderada 
                            objAdd.CambioC = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.CambioC * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : item.TipoCambioFin;//Media ponderada 
                            objAdd.CambioF = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.CambioF * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : item.TipoCambioFin;//Media ponderada                             
                        }

                        objAdd.CambioI = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.CambioI * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : item.TipoCambioIni;//Media ponderada 
                        objAdd.CambioO = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.CambioO * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : item.TipoCambioIni;//Media ponderada                         

                        //Precio Ini (PrecioI y PrecioO)
                        objAdd.PrecioI = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioI * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : item.PrecioIni;//Media ponderada 
                        objAdd.PrecioO = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioO * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioIni != null ? (decimal)item.PrecioIni : 0);//Media ponderada 
                        objAdd.PrecioOA = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioOA * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioIni != null ? (decimal)item.PrecioIni : 0);//Media ponderada 
                        objAdd.PrecioOAEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioOAEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioIni != null ? (decimal)item.PrecioIni : 0);//Media ponderada 
                        objAdd.PrecioOEUR = listaBorrar.Count > 0 ? listaBorrar.Sum(a => a.PrecioOEUR * a.NumTit) / listaBorrar.Sum(a => a.NumTit) : (item.PrecioIni != null ? (decimal)item.PrecioIni : 0);//Media ponderada 
                        
                        objAdd.Estado = Utils.GetEstadoByGrupo((int)objAdd.GrupoNuevo);
                        objAdd.TipoO = Utils.GetTipoOByGrupo((int)objAdd.GrupoNuevo);
                        

                        _pro13.Add(objAdd);

                        //Borramos los que tienen el mismo NumO y el mismo grupo. Puede que haya items con el mismo NumO en grupos distintos, por ejemplo en el caso de ampliaciones de capital
                        if (listaBorrar.Count > 0)
                        {
                            foreach (var itemBorrar in listaBorrar)
                            {
                                var obj = _pro13.FirstOrDefault(w => w.NumO == itemBorrar.NumO && w.Grupo == itemBorrar.Grupo);

                                if (obj != null)
                                {
                                    _pro13.Remove(itemBorrar);
                                }
                            }
                        }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                Log.Error("Error RentaVariable_VM/PrecAjG4", ex);
                // Compliance                                           
                throw;
            }
        }

        /// <summary>
        /// No tenemos en cuenta los items que vengan en el pro13 y los hayamos eliminado
        /// previamente en la preview
        /// </summary>
        private static void quitarEliminados(ref List<TempTableBase> listaTmp)
        {
            var lista = listaTmp.Where(w => w.GetType() == new Temp_RentaVariable().GetType()).Select(s => (Temp_RentaVariable)s).ToList();

            var listaNoMostrar = new List<Temp_RentaVariable>();
            //var eliminados = RentaVariable_DA.GetRVEliminados(_plantilla.CodigoIc);
            var eliminados = new RentaVariable_PrecioAjustado_MNG().GetDeleted(_plantilla.CodigoIc);

            //Miramos para cada uno los items RentaVariable_Deleted (eliminados en la preview)
            //para este codigoIC
            foreach (var item in eliminados)
            {
                //Recuperamos los items de pro13 que coincidan
                var obj = lista.FirstOrDefault(w => (w.Isin != null && w.Isin.ToUpper() == item.Isin.ToUpper())
                                && item.Grupo == w.Grupo
                               // && item.GrupoNuevo == w.GrupoNuevo
                                && item.Ejercicio == _fechaInforme.Year);

                if(obj != null)
                {
                    //los añadimos a esta lista 
                    listaNoMostrar.Add(obj);
                }
            }
            
            //borramos de _pro13 para no mostrar estos items en el informe
            //remove one list from another
            var common = listaTmp.Intersect(listaNoMostrar).ToList();
            listaTmp.RemoveAll(x => common.Contains(x));            
        }
        

        /// <summary>
        /// contrasplit y cambio de ISIN      
        /// </summary>
        private static void Tratar808()
        {
            #region contrasplit y cambio de ISIN            

            //var listaEquiv = RentaVariable_DA.GetOldIsins(_pro13.Select(s => s.Isin).ToList());
            var listaIsins = _pro13.Select(s => s.Isin.ToUpper()).ToList();
            var listaEquiv = RentaVariable_Equivalencias_Local.Where(w => listaIsins.Contains(w.OldIsin)).ToList(); 

            //Los que cumplan estas condiciones los borraremos
            var oldIsins = listaEquiv.Select(s => s.OldIsin.ToUpper());
            var oldMov = _pro13.Where(w => oldIsins.Contains(w.Isin.ToUpper(), StringComparer.CurrentCultureIgnoreCase)
                        && (w.TipMovO == "000" || w.TipMovO == "600")
                        && w.TipMovF == "808"
                        && (w.Grupo.Contains("02") || w.Grupo.Contains("03")));

            //Borraremos los que cumplan estas condiciones
            //a cambio añadiremos registros idénticos a _pro13 pero con el grupo correcto
            //en algún caso los duplicaremos porque puede haber alguna parte en un grupo y otras en otros
            var newIsins = listaEquiv.Select(s => s.NewIsin.ToUpper());
            var newMov = _pro13.Where(w => newIsins.Contains(w.Isin.ToUpper(), StringComparer.CurrentCultureIgnoreCase)
                        && (w.TipMovO == "818" || w.TipMovO == "816")
                        //&& w.TipMovF == null
                        );

            //aquí guardaremos los items que añadiremos a _pro13 para que posteriormente se guarden en
            //la tabla temp
            var toAdd = new List<usp_gestio_pro_13_Result>();
           
            var uspGestioPro13Results = newMov as usp_gestio_pro_13_Result[] ?? newMov.ToArray();
            var gestioPro13Results = oldMov as usp_gestio_pro_13_Result[] ?? oldMov.ToArray();
            foreach (var newItem in uspGestioPro13Results)
            {
                try
                {
                    var eqItem = listaEquiv.FirstOrDefault(w =>
                        String.Equals(w.NewIsin, newItem.Isin, StringComparison.CurrentCultureIgnoreCase));
                    var oldIsin = eqItem.OldIsin.ToUpper();
                    var oldItems = gestioPro13Results.Where(w => w.Isin.ToUpper() == oldIsin);
                    var pro13Results = oldItems;
                    var enumerable = pro13Results as usp_gestio_pro_13_Result[] ?? pro13Results.ToArray();
                    if (eqItem != null)
                    {

                        //cont: contador de oldItems. Lo utilizaremos para saber si estamos en el primero
                        int cont = 0;
                        foreach (var oldItem in enumerable)
                        {

                            if (oldItem != null)
                            {
                                var addItem = new usp_gestio_pro_13_Result();
                                //Copiamos sólo los precios ini de apertura del isin antiguo, los de cierre los cogemos del isin nuevo
                                //newItem.PrecioC = oldItem.PrecioC;
                                //newItem.PrecioF = oldItem.PrecioF;
                                //newItem.PrecioFEUR = oldItem.PrecioFEUR;
                                //Le ponemos el nuevo ISIN
                                addItem.Isin = newItem.Isin.ToUpper();
                                //Cogemos el grupo del nuevo isin porque si hay cambios de grupo será el que nos interese
                                addItem.Grupo = newItem.Grupo;
                                addItem.Nombre = newItem.Nombre;

                                var obj = listaEquiv.FirstOrDefault(w => w.OldIsin.ToUpper() == oldItem.Isin.ToUpper());

                                //Multiplicamos los precios iniciales por el Factor de ajuste
                                //Este factor de ajuste se indica al importar las equivalencias de isins
                                if (obj?.FactorAjuste != null)
                                {
                                    addItem.PrecioI = oldItem.PrecioI * (decimal) obj.FactorAjuste;
                                    addItem.PrecioO = oldItem.PrecioO * (decimal) obj.FactorAjuste;
                                    addItem.PrecioOA = oldItem.PrecioOA * (decimal) obj.FactorAjuste;
                                    addItem.PrecioOAEUR = oldItem.PrecioOAEUR * (decimal) obj.FactorAjuste;
                                    addItem.PrecioOEUR = oldItem.PrecioOEUR * (decimal) obj.FactorAjuste;
                                }

                                addItem.PrecioF = newItem.PrecioF;
                                addItem.PrecioC = newItem.PrecioC;
                                addItem.PrecioFEUR = newItem.PrecioFEUR;
                                addItem.CambioC = newItem.CambioC;
                                addItem.CambioF = newItem.CambioF;
                                addItem.CambioI = oldItem.CambioI;
                                addItem.CambioO = oldItem.CambioO;

                                //miramos los ajustes para este ISIN   
                                RentaVariable_PrecioAjustado ajuste = null;
                                if (_preciosAj != null)
                                    ajuste = _preciosAj.FirstOrDefault(w =>
                                        String.Equals(w.Isin, newItem.Isin, StringComparison.CurrentCultureIgnoreCase));
                                if (ajuste != null)
                                {
                                    var numsO = ajuste.RentaVariable_PrecioAjustado_NumO.Select(s => s.NumO).ToList();
                                    if (numsO.Contains(newItem.NumO))
                                    {
                                        addItem.PrecioAjustado = ajuste.PrecioAjustado;
                                        addItem.PrecioI = ajuste.PrecioAjustado;
                                        addItem.PrecioO = ajuste.PrecioAjustado != null
                                            ? Convert.ToDecimal(ajuste.PrecioAjustado)
                                            : 0;
                                    }
                                }


                                if (newItem.Grupo.Contains("04") && oldItem.Grupo.Contains("03"))
                                {
                                    addItem.GrupoNuevo = Utils.GetGrupoInt(G4Text);
                                }

                                else if (newItem.Grupo.Contains("03") && oldItem.Grupo.Contains("03"))
                                {
                                    addItem.GrupoNuevo = Utils.GetGrupoInt(G3Text);
                                    //addItem.Estado = "CLOSE"; //en PRO13 todos los de este grupo tienen el mismo Estado
                                    //addItem.TipoO = "M";
                                }

                                else if (newItem.Grupo.Contains("04") && oldItem.Grupo.Contains("02"))
                                {
                                    addItem.GrupoNuevo = Utils.GetGrupoInt(G1Text);
                                    //addItem.Estado = "OPEN"; //en PRO13 todos los del grupo 1 tienen estado = "OPEN"
                                    //addItem.TipoO = "C";                                
                                }

                                else if (newItem.Grupo.Contains("03") && oldItem.Grupo.Contains("02"))
                                {
                                    addItem.GrupoNuevo = Utils.GetGrupoInt(G2Text);
                                    //addItem.Estado = "CLOSE";  //en PRO13 todos los del grupo 2 tienen estado = "CLOSE"                                
                                    //addItem.TipoO = "C";                                
                                }


                                addItem.Estado = Utils.GetEstadoByGrupo((int) addItem.GrupoNuevo);
                                addItem.TipoO = Utils.GetTipoOByGrupo((int) addItem.GrupoNuevo);

                                //addItem.TipoO = "C"; //en PRO13 todos los del grupo 1 y 2 tienen TipoO = "C"
                                //addItem.TipoO = "PF";//en PRO13 todos los del grupo 1 y 2

                                //Cogemos los siguientes campos de oldItem para realizar los cálculos PlEur, PlPct, ... correctamente
                                //addItem.TipoO = newItem.TipoO;

                                if (oldItem.Divisa != newItem.Divisa)
                                    addItem.CambioO = oldItem.CambioO;
                                else
                                    addItem.CambioO = newItem.CambioO;

                                //El número de títulos total será el que trae el ISIN nuevo pero tenemos que repartirlo en proporción a lo que tenían los oldItems
                                //Vamos a redondear porque no ponemos títulos con decimales
                                //Como la diferencia del redondeo no será significativa se ha decidido añadírsela al primero (cont = 0)

                                var totalTit = newItem.NumTit; //número total de títulos que tenemos
                                var totalOldTit = enumerable.Sum(s => s.NumTit); //número total de títulos que teníamos
                                var totalRedondeado = enumerable.Sum(s =>
                                    decimal.Round(totalTit * (s.NumTit / totalOldTit), 0));

                                var porc = oldItem.NumTit / totalOldTit;
                                addItem.NumTit = decimal.Round(totalTit * porc, 0);

                                //Si hay diferencia del redondeo y es el primer item del foreach la añadimos ahora
                                var diferencia = totalRedondeado - totalTit;
                                if (diferencia != 0 && cont == 0)
                                {
                                    addItem.NumTit = addItem.NumTit + diferencia;
                                }

                                addItem.IdInstrumento = newItem.IdInstrumento;
                                addItem.CodInstrumento = newItem.CodInstrumento;
                                addItem.IdTipoInstrumento = newItem.IdTipoInstrumento;
                                addItem.CodTipoInstrumento = newItem.CodTipoInstrumento;
                                addItem.IdCategoria = newItem.IdCategoria;
                                addItem.CodCategoria = newItem.CodCategoria;
                                addItem.IdEmpresa = newItem.IdEmpresa;
                                addItem.CodEmpresa = newItem.CodEmpresa;
                                addItem.Divisa = newItem.Divisa;

                                //Siempre nos quedamos con el TipoO old porque de esta forma CalculaPLEur funciona 
                                //correctamente para estos casos
                                //newItem.TipoO = oldItem.TipoO;                    
                                //añadir el item la toAdd
                                toAdd.Add(addItem);
                            }

                            //Sumamos 1 al contador
                            cont++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    Log.Error("Error RentaVariable_VM/tratar808", ex);
                    // Compliance                                           
                    throw;
                }
            }
            //}

            //Una vez añadidas las operaciones corportativas correctamente
            //las eliminamos de _pro13 para que no vuelvan a ser añadidas en este report
            _pro13.RemoveAll(w => gestioPro13Results.Contains(w));
            _pro13.RemoveAll(w => uspGestioPro13Results.Contains(w));
            //foreach (var item in oldMov)
            //{
            //    _pro13.Remove(item);
            //}

            //foreach (var item in newMov)
            //{
            //    _pro13.Remove(item);
            //}

            //añadimos a _pro13
            _pro13.AddRange(toAdd);
                        
            #endregion
        }

 
        private static List<Temp_RentaVariable> AgruparProc(Plantilla plantilla, string isinPlantilla)
        {
            try
            {
                //obtenemos los códigos de valor del fondo/sicav
                //var codsVal = Reports_DA.GetPRO22(plantilla.CodigoIc, _fechaInicio, _fechaInforme).Select(s=>s.b3001_cod.ToUpper());
                var codsVal = _pro22.Select(s => s.b3001_cod.ToUpper());

                var enumerable = codsVal as string[] ?? codsVal.ToArray();
                var distinctIsins = _pro13.Select(s => s.Isin.ToUpper()).Union(enumerable).Distinct().ToList();
                var rest = enumerable.Except(distinctIsins);

                var instrum = InstrumentosImportados_DA.GetInstrumentosImportadosByIsin(distinctIsins);

                //decimal? numTit = null;
                //decimal? precioAj = null;

                #region Grupo 1
                //Los registros del grupo 1 no los agrupamos
                //1 - Valores que teníamos en cartera a 01/01/XXXX y no se han vendido en XXXX
                //Desde que tratamos contraslplits necesitaremos agrupar las del grupo 1 también
                var gRv1 = _pro13.Where(w =>
                                         w.GrupoNuevo == 1
                                         )
                                         .GroupBy(g => new
                                         {
                                             g.Isin,
                                             g.Nombre,
                                             g.IdInstrumento,
                                             g.CodInstrumento,
                                             g.IdTipoInstrumento,
                                             g.CodTipoInstrumento,
                                             g.IdCategoria,
                                             g.IdEmpresa,
                                             g.Grupo,
                                             g.GrupoNuevo,
                                         //g.Divisa,//La quitamos porque ni siquiera tenemos un campo Divisa en la tabla Temp_RentaVariable
                                         g.Estado,
                                             g.TipoO,
                                         //g.NumO
                                         //g.TipoC,
                                         //g.NumC
                                     }).Select(s => new Temp_RentaVariable
                                     {
                                         #region casos comunes
                                         CodigoIC = plantilla.CodigoIc,
                                         IsinPlantilla = isinPlantilla,
                                         Isin = s.Key.Isin,
                                         Descripcion = s.Key.Nombre,
                                         Grupo = s.First().Grupo,//esto no es del todo correcto en ocasiones
                                         GrupoNuevo = s.Key.GrupoNuevo != null ? s.Key.GrupoNuevo : Utils.GetGrupoInt(s.First().Grupo),
                                         Estado = s.Key.Estado,
                                         TipoO = s.Key.TipoO,
                                         NumTit = s.Sum(a => a.NumTit),
                                         //Efectivo = s.Sum(a => a.EfectivoFEUR),
                                         //Efectivo = s.Sum(a => CalcularEfectivo(a, s.Sum(aa => aa.NumTit))),
                                         Efectivo = s.Sum(a => a.PrecioFEUR * a.NumTit),
                                         BoPDividendos = s.Sum(a => (decimal?)(a.Dividendos)),
                                         BoPDivisa = s.Sum(a => calcularPLDiv(a)),
                                         BoPPrecio = s.Sum(a => CalcularPLPrecio(a)),
                                         BoPTotal = s.Sum(a => calcularPLEur(a)),
                                         //BoPTotalPorcentaje = s.Count() > 0 && s.Sum(a => a.PrecioOEUR * a.NumTit) != 0 ? s.Sum(a => a.PLEur) / s.Sum(a => a.PrecioOEUR * a.NumTit) : s.Select(a => a.PLEur).First(),//Media ponderada del Precio compra teniendo en cuenta el peso del NumTit
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => calcularPLPct(a)) : 0,
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a))) : 0, //Es la suma de los % de todos los movimientos que vienen de PRO13
                                         BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) : 0,

                                         //BoPDivisa = s.Sum(a => a.PLDiv),
                                         //BoPPrecio = s.Sum(a => a.PLPrecio),
                                         //BoPTotal = s.Sum(a => a.PLEur),
                                         IdInstrumento = s.Key.IdInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdInstrumento : string.Empty,
                                         CodInstrumento = s.Key.CodInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumento.Codigo : string.Empty,
                                         IdTipoInstrumento = s.Key.IdTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdTipoInstrumento : string.Empty,
                                         CodTipoInstrumento = s.Key.CodTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumentos_Tipos.Codigo : string.Empty,
                                         IdCategoria = s.Key.IdCategoria, //GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdCategoria : null,
                                         IdEmpresa = s.Key.IdEmpresa,// GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdEmpresa : null,
                                         #endregion

                                         //FechaVenta = s.Key.FechaC,


                                         PrecioFinEuros = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         CambioC =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioF =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioI =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioO = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         PrecioC =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioF = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada                                          
                                         PrecioFEUR = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         //PrecioIni y PrecioFin: es el que utilizaremos en el Report, cogemos el Precio en función del grupo,
                                         //como en las fórmulas para el cálculo de totales de Martí
                                         PrecioIni =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioIni =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada                                          

                                         //PrecioIni (PrecioI y PrecioO dependiendo del grupo)
                                         PrecioI =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioO =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioOA = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioOA * a.NumTit) / s.Sum(a => a.NumTit):0//Media ponderada 
                                     });

                /* COMO SE HACÍA ANTES DE AGRUPAR
                var gRv1 = _pro13.Where(w =>
                                         //isinsRV.Contains(w.Isin.ToUpper())
                                         w.GrupoNuevo == 1
                                         //w.Grupo.Contains("GRUPO-01")
                                        ).Select(s => new Temp_RentaVariable
                                        {
                                            #region casos comunes
                                            CodigoIC = plantilla.CodigoIc,
                                            IsinPlantilla = isinPlantilla,
                                            Isin = s.Isin,
                                            Descripcion = s.Nombre,
                                            Grupo = s.Grupo,
                                            GrupoNuevo = s.GrupoNuevo != null ? s.GrupoNuevo : Utils.GetGrupoInt(s.Grupo),
                                            NumTit = s.NumTit,
                                            //Efectivo = s.EfectivoFEUR,
                                            //Efectivo = CalcularEfectivo(s, s.NumTit),
                                            Efectivo = s.PrecioFEUR * s.NumTit,
                                            BoPDividendos = s.Dividendos,
                                            BoPDivisa = calcularPLDiv(s),
                                            BoPPrecio = CalcularPLPrecio(s),
                                            BoPTotal = calcularPLEur(s),
                                            //BoPTotalPorcentaje = s.PLPct / 100,
                                            BoPTotalPorcentaje = calcularPLPct(s),
                                            IdInstrumento = s.IdInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdInstrumento : string.Empty,
                                            CodInstrumento = s.CodInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumento.Codigo : string.Empty,
                                            IdTipoInstrumento = s.IdTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdTipoInstrumento : string.Empty,
                                            CodTipoInstrumento = s.CodTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumentos_Tipos.Codigo : string.Empty,
                                            IdCategoria = s.IdCategoria, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdCategoria: null,
                                            IdEmpresa = s.IdEmpresa, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdEmpresa: null,
                                            #endregion

                                            FechaCompra = s.FechaO,
                                            PrecioIni = s.PrecioI,
                                            PrecioFin = s.PrecioF,
                                            PrecioFinEuros = s.PrecioFEUR,
                                            Estado = s.Estado,
                                            CambioC = s.CambioC,
                                            CambioF = s.CambioF,
                                            CambioI = s.CambioI,
                                            CambioO = s.CambioO,
                                            PrecioC = s.PrecioC,
                                            PrecioF = s.PrecioF,
                                            PrecioFEUR = s.PrecioFEUR,
                                            PrecioI = s.PrecioI,
                                            PrecioO = s.PrecioO,
                                            PrecioOA = s.PrecioOA,
                                            TipoO = s.TipoO,
                                            NumO = s.NumO,
                                            TipoC = s.TipoC,
                                            NumC = s.NumC
                                        });

                */
                #endregion

                #region Grupo 2

                //a los registros de los grupos 2 y 3 los agrupamos por fecha de venta
                //2 - Valores que teníamos en cartera el 31/12/2015 y se han vendido en XXXX
                var gRv2 = _pro13.Where(w =>
                                         //isinsRV.Contains(w.Isin.ToUpper())
                                         //w.Grupo.Contains("GRUPO-02")
                                         w.GrupoNuevo == 2
                                         )
                                         .GroupBy(g => new
                                         {
                                             g.Isin,
                                             g.Nombre,
                                             g.IdInstrumento,
                                             g.CodInstrumento,
                                             g.IdTipoInstrumento,
                                             g.CodTipoInstrumento,
                                             g.IdCategoria,
                                             g.IdEmpresa,
                                             g.Grupo,
                                             g.GrupoNuevo,
                                         //g.Divisa,
                                         //g.FechaC,   //en el grupo 2 y 3 me fijo en la fecha venta para agrupar
                                         g.Estado,
                                             g.TipoO,
                                         //g.NumO
                                         //g.TipoC,
                                         //g.NumC
                                     }).Select(s => new Temp_RentaVariable
                                     {
                                         #region casos comunes
                                         CodigoIC = plantilla.CodigoIc,
                                         IsinPlantilla = isinPlantilla,
                                         Isin = s.Key.Isin,
                                         Descripcion = s.Key.Nombre,
                                         Grupo = s.Key.Grupo,
                                         GrupoNuevo = s.Key.GrupoNuevo != null ? s.Key.GrupoNuevo : Utils.GetGrupoInt(s.Key.Grupo),
                                         Estado = s.Key.Estado,
                                         TipoO = s.Key.TipoO,
                                         NumTit = s.Sum(a => a.NumTit),
                                         //Efectivo = s.Sum(a => a.EfectivoFEUR),
                                         //Efectivo = s.Sum(a => CalcularEfectivo(a, s.Sum(aa => aa.NumTit))),
                                         Efectivo = s.Sum(a => a.PrecioFEUR * a.NumTit),
                                         BoPDividendos = s.Sum(a => (decimal?)(a.Dividendos)),
                                         BoPDivisa = s.Sum(a => calcularPLDiv(a)),
                                         BoPPrecio = s.Sum(a => CalcularPLPrecio(a)),
                                         BoPTotal = s.Sum(a => calcularPLEur(a)),
                                         //BoPTotalPorcentaje = s.Count() > 0 && s.Sum(a => a.PrecioOEUR * a.NumTit) != 0 ? s.Sum(a => a.PLEur) / s.Sum(a => a.PrecioOEUR * a.NumTit) : s.Select(a => a.PLEur).First(),//Media ponderada del Precio compra teniendo en cuenta el peso del NumTit
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => calcularPLPct(a)) : 0,
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a))) : 0, //Es la suma de los % de todos los movimientos que vienen de PRO13
                                         BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) : 0,

                                         //BoPDivisa = s.Sum(a => a.PLDiv),
                                         //BoPPrecio = s.Sum(a => a.PLPrecio),
                                         //BoPTotal = s.Sum(a => a.PLEur),
                                         IdInstrumento = s.Key.IdInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdInstrumento : string.Empty,
                                         CodInstrumento = s.Key.CodInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumento.Codigo : string.Empty,
                                         IdTipoInstrumento = s.Key.IdTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdTipoInstrumento : string.Empty,
                                         CodTipoInstrumento = s.Key.CodTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumentos_Tipos.Codigo : string.Empty,
                                         IdCategoria = s.Key.IdCategoria, //GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdCategoria : null,
                                         IdEmpresa = s.Key.IdEmpresa,// GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdEmpresa : null,
                                         #endregion

                                         //FechaVenta = s.Key.FechaC,
                                         //PrecioIni y PrecioFin: es el que utilizaremos en el Report, cogemos el Precio en función del grupo,
                                         //como en las fórmulas para el cálculo de totales de Martí
                                         PrecioIni =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioIni =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         PrecioFinEuros = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 

                                         CambioC = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioF = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioI = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioO = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioC = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioF = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioFEUR = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioI =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioO =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioOA = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioOA * a.NumTit) / s.Sum(a => a.NumTit):0//Media ponderada 
                                     });
                #endregion
                #region Grupo 3

                //3 - Valores que se han comprado y vendido en XXXX
                var gRv3 = _pro13.Where(w =>
                                         //isinsRV.Contains(w.Isin.ToUpper())
                                         //w.Grupo.Contains("GRUPO-03")
                                         w.GrupoNuevo == 3
                                         ).GroupBy(g => new
                                         {
                                             g.Isin,
                                             g.Nombre,
                                             g.IdInstrumento,
                                             g.CodInstrumento,
                                             g.IdTipoInstrumento,
                                             g.CodTipoInstrumento,
                                             g.IdCategoria,
                                             g.IdEmpresa,
                                             g.Grupo,
                                             g.GrupoNuevo,
                                         //g.Divisa,
                                         //g.FechaC,   //en el grupo 2 y 3 me fijo en la fecha venta para agrupar
                                         g.Estado,
                                             g.TipoO,
                                         //g.NumO
                                         //g.TipoC,
                                         //g.NumC
                                     }).Select(s => new Temp_RentaVariable
                                     {
                                         #region casos comunes
                                         CodigoIC = plantilla.CodigoIc,
                                         IsinPlantilla = isinPlantilla,
                                         Isin = s.Key.Isin,
                                         Descripcion = s.Key.Nombre,
                                         Grupo = s.Key.Grupo,
                                         GrupoNuevo = s.Key.GrupoNuevo != null ? s.Key.GrupoNuevo : Utils.GetGrupoInt(s.Key.Grupo),
                                         Estado = s.Key.Estado,
                                         TipoO = s.Key.TipoO,
                                         NumTit = s.Sum(a => a.NumTit),
                                         //Efectivo = s.Sum(a => a.EfectivoFEUR),
                                         //Efectivo = s.Sum(a => CalcularEfectivo(a, s.Sum(aa => aa.NumTit))),
                                         Efectivo = s.Sum(a => a.PrecioFEUR * a.NumTit),
                                         BoPDividendos = s.Sum(a => a.Dividendos),
                                         //BoPDivisa = s.Sum(a => a.PLDiv),
                                         //BoPPrecio = s.Sum(a => a.PLPrecio),
                                         //BoPTotal = s.Sum(a => a.PLEur),
                                         BoPDivisa = s.Sum(a => calcularPLDiv(a)),
                                         BoPPrecio = s.Sum(a => CalcularPLPrecio(a)),
                                         BoPTotal = s.Sum(a => calcularPLEur(a)),
                                         //BoPTotalPorcentaje = s.Count() > 0 && s.Sum(a => a.PrecioOEUR * a.NumTit) != 0 ? s.Sum(a => a.PLEur) / s.Sum(a => a.PrecioOEUR * a.NumTit) : s.Select(a => a.PLEur).First(),//Media ponderada del Precio compra teniendo en cuenta el peso del NumTit
                                         //BoPTotalPorcentaje = s.Sum(a => calcularPLPct(a, null)),
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) :0,
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => calcularPLPct(a)) : 0,
                                         //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a))) : 0, //Es la suma de los % de todos los movimientos que vienen de PRO13
                                         BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) : 0,

                                         IdInstrumento = s.Key.IdInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdInstrumento : string.Empty,
                                         CodInstrumento = s.Key.CodInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumento.Codigo : string.Empty,
                                         IdTipoInstrumento = s.Key.IdTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdTipoInstrumento : string.Empty,
                                         CodTipoInstrumento = s.Key.CodTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumentos_Tipos.Codigo : string.Empty,
                                         IdCategoria = s.Key.IdCategoria,// GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdCategoria : null,
                                         IdEmpresa = s.Key.IdEmpresa,//GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdEmpresa : null,
                                         #endregion

                                         //FechaVenta = s.Key.FechaC,
                                         //PrecioIni y PrecioFin: es el que utilizaremos en el Report, cogemos el Precio en función del grupo,
                                         //como en las fórmulas para el cálculo de totales de Martí
                                         PrecioIni = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioIni = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         TipoCambioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         PrecioFinEuros = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         CambioC = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioF = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioI = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         CambioO = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioC = s.Sum(a => a.NumTit) != 0 ?  s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioF = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioFEUR = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioI = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioO =  s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 
                                         PrecioOA = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioOA * a.NumTit) / s.Sum(a => a.NumTit):0//Media ponderada 
                                     });
                #endregion


                #region Grupo 4
                //a los registros de los grupos 4 los agrupamos por fecha de compra
                //4 - Valores que se han comprado en 2016 y no se han vendido en XXXX            

                var gRv4 = _pro13.Where(w =>
                                         //isinsRV.Contains(w.Isin.ToUpper())
                                         //w.Grupo.Contains("GRUPO-04")
                                         w.GrupoNuevo == 4
                                         ).GroupBy(g => new
                                         {
                                             g.Isin,
                                             g.Nombre,
                                             g.IdInstrumento,
                                         //g.CodInstrumento,
                                         g.IdTipoInstrumento,
                                         //g.CodTipoInstrumento,
                                         g.IdCategoria,
                                             g.IdEmpresa,
                                             g.Grupo,
                                             g.GrupoNuevo,
                                         //g.Divisa,
                                         //g.FechaO,   //en el grupo 4 me fijo en la fecha compra para agrupar
                                         g.Estado,
                                             g.TipoO
                                         }).Select(s => new Temp_RentaVariable
                                         {
                                         #region casos comunes
                                         CodigoIC = plantilla.CodigoIc,
                                             IsinPlantilla = isinPlantilla,
                                             Isin = s.Key.Isin,
                                             Descripcion = s.Key.Nombre,
                                             Grupo = s.Key.Grupo,
                                             GrupoNuevo = s.Key.GrupoNuevo != null ? s.Key.GrupoNuevo : Utils.GetGrupoInt(s.Key.Grupo),
                                             Estado = s.Key.Estado,
                                             TipoO = s.Key.TipoO,
                                             NumTit = s.Sum(a => a.NumTit),
                                             Efectivo = s.Sum(a => a.PrecioFEUR * a.NumTit),

                                             IdInstrumento = s.Key.IdInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdInstrumento : string.Empty,
                                         CodInstrumento = Instrumentos_Local.Where(w => w.Id == s.Key.IdInstrumento).FirstOrDefault().Codigo, //Utils.GetIdInstrumentoByCod s.Key.CodInstrumento,//GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumento.Codigo : string.Empty,
                                         IdTipoInstrumento = s.Key.IdTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).IdTipoInstrumento : string.Empty,
                                         CodTipoInstrumento = InstrumentosTipos_Local.Where(w => w.Id == s.Key.IdTipoInstrumento).FirstOrDefault().Codigo,//s.Key.CodTipoInstrumento, //GetDatosIsin(instrum, s.Isin) != null ? GetDatosIsin(instrum, s.Isin).Instrumentos_Tipos.Codigo : string.Empty,
                                         IdCategoria = s.Key.IdCategoria,// GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdCategoria : null,
                                         IdEmpresa = s.Key.IdEmpresa, // GetDatosIsin(instrum, s.Key.Isin) != null ? GetDatosIsin(instrum, s.Key.Isin).IdEmpresa : null,
                                         #endregion
                                         
                                         BoPDividendos = s.Sum(a => a.Dividendos),
                                             BoPDivisa = s.Sum(a => calcularPLDiv(a)),
                                             BoPPrecio = s.Sum(a => CalcularPLPrecio(a)),
                                             BoPTotal = s.Sum(a => calcularPLEur(a)),
                                             //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) : 0,
                                             //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => calcularPLPct(a)) : 0,
                                             BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a) * a.NumTit)) / Utils.NullableSum(s.Select(a => (decimal?)a.NumTit)) : 0,
                                             //BoPTotalPorcentaje = s.Sum(a => a.NumTit) != 0 ? Utils.NullableSum(s.Select(a => calcularPLPct(a)))  : 0, //Es la suma de los % de todos los movimientos que vienen de PRO13

                                             //PrecioIni, PrecioFin, TipoCambioIni y TipoCambioFin: es el que utilizaremos en el Report, cogemos el Precio en función del grupo,
                                             //como en las fórmulas para el cálculo de totales de Martí
                                             PrecioIni = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         TipoCambioIni = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         TipoCambioFin = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 

                                         PrecioFinEuros = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit):0,//Media ponderada 

                                         CambioC = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioC * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         CambioF = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioF * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         CambioI = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioI * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         CambioO = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.CambioO * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioC = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioC * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioF = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioF * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioFEUR = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioFEUR * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioI = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioI * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada 
                                         PrecioO = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioO * a.NumTit) / s.Sum(a => a.NumTit) : 0,//Media ponderada                                                                                   
                                         PrecioOA = s.Sum(a => a.NumTit) != 0 ? s.Sum(a => a.PrecioOA * a.NumTit) / s.Sum(a => a.NumTit) : 0//Media ponderada 


                                     });


                #endregion

                //juntamos todos los registros en una lista
                var listaFinal = new List<Temp_RentaVariable>();

                //Sólo añadimos los que tienen precioAnt != 0
                //CASOS RV IdInstrumento = 1
                var instrumentosImportadoses = instrum as Instrumentos_Importados[] ?? instrum.ToArray();
                try
                {
                    //var aaa = _pro13.Where(w => w.Isin.ToUpper() == "BMG491BT1088").FirstOrDefault();
                    //var bbb = VariablesGlobales.Pro13_Local.Where(w => w.Isin.ToUpper() == "BMG491BT1088").FirstOrDefault();
                    //Antes teníamos en cuenta el PrecioIni!= null && w.PrecioIni != 0
                    //05/05/17 - Jaume - ahora ya no, a menos que empiecen a salir derechos o movimientos inesperados                
                    listaFinal.AddRange(gRv1.Where(w => w.NumTit != 0));
                    listaFinal.AddRange(gRv2.Where(w => w.NumTit != 0));
                    listaFinal.AddRange(gRv3.Where(w => w.NumTit != 0));
                    listaFinal.AddRange(gRv4.Where(w=>w.NumTit != 0));

                    //listaFinal.AddRange(gRv1.Where(w => w.PrecioIni != null && w.PrecioIni != 0));
                    //listaFinal.AddRange(gRv2.Where(w => w.PrecioIni != null && w.PrecioIni != 0));
                    //listaFinal.AddRange(gRv3.Where(w => w.PrecioIni != null && w.PrecioIni != 0));
                    //listaFinal.AddRange(gRv4.Where(w => w.PrecioIni != null && w.PrecioIni != 0));

                    //Llegados a este punto ya hemos añadido todos los ISINS que nos devuelve PRO13
                    //Ahora si hay alguno que nos devuelva el PRO22 que no haya sido añadido, lo añadimos
                    addCodsValor(ref listaFinal, instrumentosImportadoses, isinPlantilla);

                }
                catch (Exception ex)
                {
                    Log.Error("Error RentaVariable_VM/agruparProc", ex);
                    throw;
                }
                //CASOS RAB IdInstrumento = 3
                //listaFinal.AddRange(gRAB.Where(w => w.Efectivo != null && w.Efectivo != 0));

                try
                {
                    adaptarConTipo2y3(ref listaFinal, instrumentosImportadoses);
                    calculosPosiciones(ref listaFinal, isinPlantilla);
                    calculosPosicionesDerivados(ref listaFinal, isinPlantilla);
                    pintarPrecioAjustado(ref listaFinal);
                }
                catch (Exception ex)
                {
                    Log.Error("Error RentaVariable_VM/agruparProc", ex);
                    throw;
                }

                return listaFinal;
            }
            catch(Exception ex)
            {
                Log.Error("Error RentaVariable_VM/agruparProc", ex);
                throw;
            }
        }

        private static void pintarPrecioAjustado(ref List<Temp_RentaVariable> listaFinal)
        {
            //Sólo pintaremos los datos del precio ajustado cuando todos los NumO del precio 
            //ajustado se encuentren en el informe y ese isin no tenga más NumO agrupados en 
            //el grupo que se encuentre
            if (_preciosAj != null)
            {
                //Puede que haya varios precios ajustados para un mismo ISIN
                foreach (var paj in _preciosAj.Where(w => w.IsVisible))
                {
                    //Recuperamos todos los NumO que tiene agrupados este precio ajustado
                    var numO_paj = paj.RentaVariable_PrecioAjustado_NumO.Select(s => s.NumO).OrderBy(o => o).ToList();

                    //Comprobamos si ese isin para ese grupo tiene esos NumO y sólo esos
                    //sólo en ese caso pintaremos el precio ajustado en la preview
                    var numO_isinGrupo = Utils.GetPro13SeccRv(_plantilla, _fechaInforme).Where(w => w.Isin.ToUpper() == paj.Isin.ToUpper() && w.Grupo == paj.Grupo).Select(s => s.NumO).OrderBy(o => o).ToList();
                    bool contained = numO_paj.SequenceEqual(numO_isinGrupo);

                    if (contained)
                                                                                                                                                                                                                                                                                                                                                      {
                        var listaFinalAj = listaFinal.Where(w => !string.IsNullOrEmpty(w.Isin)
                                                    && w.Isin.ToUpper() == paj.Isin.ToUpper()
                                                    && !string.IsNullOrEmpty(w.Grupo)
                                                    && w.Grupo == paj.Grupo
                                                    && w.GrupoNuevo == paj.GrupoNuevo
                                                    ).ToList();

                        //Actualizamos en nuestra lista el PrecioAjustado y NumeroTitulos que teníamos almacenados                        
                        listaFinalAj.ForEach(s => s.Descripcion = paj.Descripcion);
                        listaFinalAj.ForEach(s => s.FechaCompra = paj.FechaCompra);
                        listaFinalAj.ForEach(s => s.FechaVenta = paj.FechaVenta);
                        listaFinalAj.ForEach(s => s.NumTit = paj.NumeroTitulos);


                        //Precio Ini (PrecioI y PrecioO)
                        if (paj.GrupoNuevo == 1 || paj.GrupoNuevo == 2)
                        {
                            listaFinalAj.ForEach(s => s.PrecioI = paj.PrecioIni);
                            listaFinalAj.ForEach(s => s.CambioI = paj.TipoCambioIni);

                        }
                        else if (paj.GrupoNuevo == 3 || paj.GrupoNuevo == 4)
                        {
                            listaFinalAj.ForEach(s => s.PrecioO = paj.PrecioIni);
                            listaFinalAj.ForEach(s => s.CambioO = paj.TipoCambioIni);
                        }
                        listaFinalAj.ForEach(s => s.PrecioIni = paj.PrecioIni);

                        //Precio Fin (PrecioC y PrecioF)
                        //Jaume: No modificamos Precio fin porque será el de la fecha de generación (antes lo mofificábamos, ahora no...)
                        //Entonces sólo lo cambiamos si tenemos un precio ajustado que coincide con la fecha de generación
                        //Añadimos una condición más. Si se modifica un PrecioFin para títulos del grupo (GrupoNew) 2 o 3 mantenemos el grupo
                        //que se introdujo manualmente, puesto que son títulos vendidos y su PrecioFin no cambiará.
                        if (paj.FechaInforme == _fechaInforme && paj.PrecioFin != null
                            || paj.GrupoNuevo == 2
                            || paj.GrupoNuevo == 3)
                        {
                            listaFinalAj.ForEach(s => s.PrecioF = paj.PrecioFin);
                            listaFinalAj.ForEach(s => s.PrecioC = paj.PrecioFin);
                            listaFinalAj.ForEach(s => s.PrecioFin = paj.PrecioFin);
                            listaFinalAj.ForEach(s => s.PrecioFEUR = paj.PrecioFinEuros);
                            listaFinalAj.ForEach(s => s.PrecioFinEuros = paj.PrecioFinEuros);
                        }

                        listaFinalAj.ForEach(s => s.PrecioAjustado = paj.PrecioAjustado);

                        listaFinalAj.ForEach(s => s.TipoC = paj.TipoC);
                        listaFinalAj.ForEach(s => s.Grupo = paj.Grupo);
                        listaFinalAj.ForEach(s => s.GrupoNuevo = paj.GrupoNuevo);

                        listaFinalAj.ForEach(s => s.TipoO = Utils.GetTipoOByGrupo((int)paj.GrupoNuevo));
                        listaFinalAj.ForEach(s => s.Estado = Utils.GetEstadoByGrupo((int)paj.GrupoNuevo));

                        //recalculamos los totales después de actualizar los datos modificados en la preview
                        foreach (var item in listaFinalAj)
                        {
                            var p13tmp = new usp_gestio_pro_13_Result();
                            Utils.CopyPropertyValues(item, p13tmp, "Id");

                            //CALCULAR TOTALES
                            item.Efectivo = CalcularEfectivo(p13tmp, item.NumTit, item.PrecioFEUR);
                            item.BoPDivisa = calcularPLDiv(p13tmp, item.NumTit, item.PrecioAjustado, item.PrecioF);
                            item.BoPPrecio = CalcularPLPrecio(p13tmp, item.NumTit, item.PrecioAjustado, item.PrecioF);
                            item.BoPTotal = calcularPLEur(p13tmp, item.NumTit, item.PrecioAjustado, item.PrecioF);
                            item.BoPTotalPorcentaje = calcularPLPct(p13tmp, item.NumTit, item.PrecioAjustado, item.PrecioF);
                        }
                    }
                }
            }




        }

        public static decimal? CalcularEfectivo(usp_gestio_pro_13_Result item, decimal? numeroTitulos, decimal? precioFEUR)
        {
            decimal? efectivo = null;

            decimal? numTit = numeroTitulos != null ? numeroTitulos : item.NumTit;
            decimal? pFEUR = precioFEUR != null ? precioFEUR : item.PrecioFEUR;

            efectivo = numTit * pFEUR;


            return efectivo;
        }

        //public static decimal? CalcularPLPrecio(usp_gestio_pro_13_Result item, decimal? numeroTitulos, decimal? precioAjustado)
        public static decimal? CalcularPLPrecio(usp_gestio_pro_13_Result item, decimal? numeroTitulos=null, decimal? precioAjustado=null, decimal? precioF = null)
        {
            if(precioAjustado == null && item.PrecioAjustado != null)
            {
                precioAjustado = item.PrecioAjustado;
            }
            
            decimal? precioI = precioAjustado != null ? precioAjustado : item.PrecioI;
            decimal? precioO = precioAjustado != null ? precioAjustado : item.PrecioO;
            decimal? numTit = numeroTitulos != null ? numeroTitulos : item.NumTit;
            decimal? pF = precioF != null ? precioF : item.PrecioF;
            decimal? pC = precioF != null ? precioF : item.PrecioF;

            decimal? plPrecio;
            if(item.Estado.Equals("OPEN"))
            {
                //Grupo 1 del PRO13
                if(item.TipoO.Equals("C"))
                {
                    plPrecio = numTit * (pF - precioI) * item.CambioF;
                    //plPrecio = numTit * (item.PrecioF - precioI) * item.CambioF;
                }
                //Grupo 4 del PRO13
                else
                {
                    plPrecio = numTit * (pF - precioO) * item.CambioF;
                }
            }
            else
            {
                //Grupo 2 del PRO13
                if (item.TipoO.Equals("C"))
                {
                    plPrecio = numTit * (pC - precioI) * item.CambioC;
                }
                //Grupo 3 del PRO13
                else
                {
                    plPrecio = numTit * (pC - precioO) * item.CambioC;
                }
            }

            return plPrecio;            
        }

        public static decimal? calcularPLDiv(usp_gestio_pro_13_Result item, decimal? numeroTitulos = null, decimal? precioAjustado = null, decimal? precioF = null)
        {
            try
            {
                if (precioAjustado == null && item.PrecioAjustado != null)
                {
                    precioAjustado = item.PrecioAjustado;
                }

                //var precAj = _preciosAj.Where(w => w.Isin == item.Isin).FirstOrDefault();
                decimal? precioI = precioAjustado != null ? precioAjustado : item.PrecioI;
                decimal? precioO = precioAjustado != null ? precioAjustado : item.PrecioO;
                decimal? precioOA = precioAjustado != null ? precioAjustado : item.PrecioOA;
                decimal? pF = precioF != null ? precioF : item.PrecioF;
                decimal? pC = precioF != null ? precioF : item.PrecioF;

                decimal? numTit = numeroTitulos != null ? numeroTitulos : item.NumTit;

                decimal? plDiv;

                if (item.Estado.Equals("OPEN"))
                {
                    if (item.TipoO.Equals("C"))
                    {
                        plDiv = (numTit * ((pF * item.CambioF) - (precioI * item.CambioI))) - (numTit * (pF - precioI) * item.CambioF);
                    }
                    else
                    {
                        plDiv = (numTit * ((pF * item.CambioF) - (precioOA * item.CambioO))) - (numTit * (pF - precioO) * item.CambioF);
                    }
                }
                else
                {
                    if (item.TipoO.Equals("C"))
                    {
                        plDiv = (numTit * (pC * item.CambioC - precioI * item.CambioI)) - (numTit * (pC - precioI) * item.CambioC);
                    }
                    else
                    {
                        plDiv = (numTit * (pC * item.CambioC - precioO * item.CambioO)) - (numTit * (pC - precioO) * item.CambioC);
                    }
                }

                return plDiv;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static decimal? calcularPLEur(usp_gestio_pro_13_Result item, decimal? numeroTitulos = null, decimal? precioAjustado = null, decimal? precioF = null)
        {
            if (precioAjustado == null && item.PrecioAjustado != null)
            {
                precioAjustado = item.PrecioAjustado;
            }

            //var precAj = _preciosAj.Where(w => w.Isin == item.Isin).FirstOrDefault();
            decimal? precioI = precioAjustado != null ? precioAjustado : item.PrecioI;
            decimal? precioO = precioAjustado != null ? precioAjustado : item.PrecioO;
            decimal? precioOA = precioAjustado != null ? precioAjustado : item.PrecioOA;
            decimal? numTit = numeroTitulos != null ? numeroTitulos : item.NumTit;
            decimal? pF = precioF != null ? precioF : item.PrecioF;
            decimal? pC = precioF != null ? precioF : item.PrecioF;

            decimal? plEur;

            if (item.Estado.Equals("OPEN"))
            {
                if (item.TipoO.Equals("C"))
                {
                    plEur = (numTit * ((pF * item.CambioF) - (precioI * item.CambioI)));
                    //plEur = (item.NumTit * ((item.PrecioF * item.CambioF) - (item.PrecioI * item.CambioI)));
                }
                else
                {
                    plEur = (numTit * ((pF * item.CambioF) - (precioOA * item.CambioO)));
                }
            }
            else
            {
                if (item.TipoO.Equals("C"))
                {
                    plEur = (numTit * (pC * item.CambioC - precioI * item.CambioI));
                }
                else
                {
                    plEur = (numTit * (pC * item.CambioC - precioO * item.CambioO));
                }
            }
            
            return plEur;
        }

        public static decimal? calcularPLPct(Temp_RentaVariable temp)
        {
            var p13Item = new usp_gestio_pro_13_Result();
            Utils.CopyPropertyValues(temp, p13Item);
            p13Item.PrecioI = temp.PrecioI != null ? (decimal)temp.PrecioI : 0;
            p13Item.PrecioO = temp.PrecioO != null ? (decimal)temp.PrecioO : 0;
            p13Item.PrecioC = temp.PrecioC != null ? (decimal)temp.PrecioC : 0;
            p13Item.PrecioF = temp.PrecioF != null ? (decimal)temp.PrecioF : 0;
            //p13Item.CambioI = temp.TipoCambioIni;
            //p13Item.CambioO = temp.TipoCambioIni;
            //p13Item.CambioC = temp.TipoCambioFin;
            //p13Item.CambioF = temp.TipoCambioFin;

            return calcularPLPct(p13Item);
        }

        public static decimal? calcularPLPct(usp_gestio_pro_13_Result item, decimal? numeroTitulos = null, decimal? precioAjustado = null, decimal? precioF = null)
        {
            try
            {
                if (precioAjustado == null && item.PrecioAjustado != null)
                {
                    precioAjustado = item.PrecioAjustado;
                }

                //var precAj = _preciosAj.Where(w => w.Isin == item.Isin).FirstOrDefault();
                decimal? precioI = precioAjustado != null ? precioAjustado : item.PrecioI;
                decimal? precioO = precioAjustado != null ? precioAjustado : item.PrecioO;
                decimal? pF = precioF != null ? precioF : item.PrecioF;
                decimal? pC = precioF != null ? precioF : item.PrecioF;

                decimal? plPct = null;

                if ((item.TipoO.Equals("C") && precioI == 0)
                    || (!item.TipoO.Equals("C") && precioO == 0)
                    )
                {
                    switch (item.GrupoNuevo)
                    {
                        case 1:
                            var denom = precioI * item.CambioI;
                            if (denom != 0)
                                plPct = (((pF * item.CambioF) / denom) - 1) * 100;
                            break;
                        case 2:
                            denom = precioI * item.CambioI;
                            if (denom != 0)
                                plPct = (((pC * item.CambioC) / denom) - 1) * 100;
                            break;
                        case 3:
                            denom = precioO * item.CambioO;
                            if (denom != 0)
                                plPct = (((pC * item.CambioC) / denom) - 1) * 100;
                            break;
                        case 4:
                            denom = precioO * item.CambioO;
                            if (denom != 0)
                                plPct = (((pF * item.CambioF) / denom) - 1) * 100;
                            break;
                        default:
                            plPct = 0;
                            break;
                    }
                    //plPct = null;
                }
                else if (item.Estado.Equals("OPEN"))
                {
                    if (item.TipoO.Equals("C") && (precioI * item.CambioI) != 0) //GRUPO 1
                    {
                        plPct = (((pF * item.CambioF) / (precioI * item.CambioI)) - 1) * 100;
                    }
                    else if ((precioO * item.CambioO) != 0)  //GRUPO 4
                    {
                        plPct = (((pF * item.CambioF) / (precioO * item.CambioO)) - 1) * 100;
                    }
                }
                else
                {
                    if (item.TipoO.Equals("C") && (precioI * item.CambioI) != 0) //GRUPO 2
                    {
                        plPct = (((pC * item.CambioC) / (precioI * item.CambioI)) - 1) * 100;
                    }
                    else if ((precioO * item.CambioO) != 0)  //GRUPO 3
                    {
                        plPct = (((pC * item.CambioC) / (precioO * item.CambioO)) - 1) * 100;
                    }
                }

                if (plPct != null)
                    return plPct / 100;
                else
                    return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
         }

        /// <summary>
        /// Si hay algún ISIN que nos devuelva el PRO22 que no haya sido añadido, lo añadimos
        /// </summary>
        /// <param name="listaFinal"></param>
        /// <param name="instrum"></param>
        /// <param name="isinPlantilla"></param>
        private static void addCodsValor(ref List<Temp_RentaVariable> listaFinal, IEnumerable<Instrumentos_Importados> instrum, string isinPlantilla)
        {
            var codsValor = Reports_DA.GetPRO22(_plantilla.CodigoIc, _fechaInicio, _fechaInforme);
            var restantes = codsValor.Select(s => s.b3001_cod.ToUpper()).Except(listaFinal.Select(s => s.Isin.ToUpper()));
            foreach(var isin in restantes)
            {
                var trv = new Temp_RentaVariable();
                trv.CodigoIC = _plantilla.CodigoIc;
                trv.IsinPlantilla = isinPlantilla;
                trv.Isin = isin;
                var datos = _cart.Where(w => w.isin.ToUpper().Equals(isin)).FirstOrDefault();
                if(datos != null)
                {
                    trv.Descripcion = datos.descr;
                }
                else
                {
                    
                    trv.Descripcion = string.Empty;
                }
                var inst = instrum.Where(w => w.ISIN.ToUpper().Equals(isin)).FirstOrDefault();
                if (inst != null)
                {
                    trv.IdInstrumento = inst.IdInstrumento;
                    trv.CodInstrumento = inst.Instrumento.Codigo;
                    trv.IdTipoInstrumento = inst.IdTipoInstrumento;
                    trv.CodTipoInstrumento = inst.Instrumentos_Tipos.Codigo;
                    trv.IdCategoria = inst.IdCategoria;
                    trv.IdEmpresa = inst.IdEmpresa;
                    listaFinal.Add(trv);
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="listaFinal"></param>
        /// <param name="instrum"></param>
        /// <returns></returns>
        private static List<Temp_RentaVariable> adaptarConTipo2y3(ref List<Temp_RentaVariable> listaFinal, IEnumerable<Instrumentos_Importados> instrum)
        {
            //Para los casos que la plantilla tenga definidos unos tipos de instrumento (Plantillas_InstrumentosTipos)
            //Tendremos que tener en cuenta los campos Tipo2 y Tipo3 de la plantilla de Instrumentos_Importados
            if (_plantilla.Plantillas_Estrategias.Count() > 0)            
            {
                var estrategias = _plantilla.Plantillas_Estrategias.Select(s => s.IdTipoInstrumento);

                
                //Si es instrumento importado tiene valores Tipo2 o Tipo3, tenemos que olvidarnos de la columna Tipo(1)
                foreach (var isin in instrum.Where(w=> w.IdTipoInstrumento2 != null || w.IdTipoInstrumento3 != null))
                {
                    //En caso de que sólo sea distinto de null una de las dos columnas (Tipo2 o Tipo3)
                    //tendremos que buscar en "listaFinal" los registros con ese ISIN y cambiarles el IdTipoInstrumento
                    //por el del Tipo que sea distinto de null
                    //Si los dos (Tipo2 y Tipo3) son distinto de null --> a cada registro con este ISIN 
                    //tendremos que cambiarle el tipo (al Tipo2) y añadir otro registro igual con el Tipo3
                    if (!string.IsNullOrEmpty(isin.IdTipoInstrumento2)
                        && estrategias.Contains(isin.IdTipoInstrumento2)
                        )
                    {
                        //listaFinal.Where(w => w.Isin.Equals(isin.ISIN, StringComparison.CurrentCultureIgnoreCase));
                        listaFinal.Where(w => w.Isin.Equals(isin.ISIN, StringComparison.CurrentCultureIgnoreCase)).ToList().ForEach(s => s.IdTipoInstrumento = isin.IdTipoInstrumento2);
                        //Si también tiene Tipo3 hacemos una copia del elemento de la lista 
                        //y lo añadimos a la lista con el tipo3
                        if (!string.IsNullOrEmpty(isin.IdTipoInstrumento3) 
                            && estrategias.Contains(isin.IdTipoInstrumento3)
                            )
                        {
                            var listaNuevos = new List<Temp_RentaVariable>();
                            var añadidos = listaFinal.Where(w => w.Isin.Equals(isin.ISIN, StringComparison.CurrentCultureIgnoreCase));
                            foreach(var añadido in añadidos)
                            {
                                var itemAñadir = new Temp_RentaVariable();
                                Utils.CopyPropertyValues(añadido, itemAñadir);
                                listaNuevos.Add(itemAñadir);
                            }
                            
                            listaNuevos.ForEach(f => f.IdTipoInstrumento = isin.IdTipoInstrumento3);
                            listaFinal.AddRange(listaNuevos);
                        }
                    }
                    //Si sólo tiene Tipo3 != null, actualizamos el campo idTipoinstrumento con su valor
                    else if(!string.IsNullOrEmpty(isin.IdTipoInstrumento3) 
                        && estrategias.Contains(isin.IdTipoInstrumento3)
                        )
                    {
                        listaFinal.Where(w => w.Isin.Equals(isin.ISIN, StringComparison.CurrentCultureIgnoreCase)).ToList().ForEach(s => s.IdTipoInstrumento = isin.IdTipoInstrumento3);
                    }
                }
            }

            //Id    Codigo
            //12    PER
            //5     PAT
            //11    CCP
            //4     OTR
            return listaFinal;

        }

        /// <summary>
        /// RAB & IIC(3&2), PAT (5) ó (GAR, DIV, COM cuando NO sean tipo DER)
        /// </summary>
        /// <param name="listaFinal"></param>
        /// <param name="isinPlantilla"></param>
        private static void calculosPosiciones(ref List<Temp_RentaVariable> listaFinal, string isinPlantilla)
        {
            var listaTmp = listaFinal.Where(w =>
                                            (
                                                w.IdInstrumento == "3"          //RAB
                                                && w.IdTipoInstrumento == "2"   //IIC
                                            )
                                            ||
                                            (
                                                w.IdTipoInstrumento == "5"      //PAT
                                            )
                                            ||
                                            (   
                                                (
                                                    w.IdInstrumento == "12"      //GAR
                                                    || w.IdInstrumento == "13"  //DIV
                                                    || w.IdInstrumento == "15"  //COM
                                                )
                                                && w.IdTipoInstrumento != "3"   //DER
                                            )
                                        );
            calculosRAB(ref listaFinal, listaTmp, isinPlantilla);                        
        }

        /// <summary>
        /// DERIVADOS, CCP, PER ó (GAR, DIV, COM lo calcularemos aquí cuando sean tipo DER)
        /// </summary>
        /// <param name="listaFinal"></param>
        /// <param name="isinPlantilla"></param>
        private static void calculosPosicionesDerivados(ref List<Temp_RentaVariable> listaFinal, string isinPlantilla)
        {
            try
            {
                //Tenemos que agrupar los que sean DERIVADOS y tengan el mismo código de subyacente en un sólo registro
                //POSICIÓN EN CARTERA: 
                //POSICIONES CERRADAS: 
                //TOTAL(€): 

                //Actualizamos la lista añadiendo el código de subyacente de los derivados
                var listaDer = listaFinal.Where(w =>
                                                    (w.IdTipoInstrumento == "3"
                                                    || w.IdTipoInstrumento == "11"
                                                    || w.IdTipoInstrumento == "12"
                                                    )
                                                    //y que no sea de RF
                                                    //&& w.IdInstrumento != "2"
                                                    ).ToList();
                var listaDersBorrar = new List<Temp_RentaVariable>();
                var listaDersAñadir = new List<Temp_RentaVariable>();

                //No queremos mostrar en esta sección los de RF. Los eliminamos
                var listaDerRF = listaDer.Where(w => w.IdInstrumento == "2").ToList();
                //Primero los eliminamos de listaDer para no tener que ir a buscar sus códigos subyacentes
                listaDer.RemoveAll(w => listaDerRF.Select(s => s.Isin.ToUpper()).Contains(w.Isin.ToUpper()));
                //Ahora lo añadimos a la listaDersBorrar para que no aparezcan en este informe
                listaDersBorrar.AddRange(listaDerRF);

                foreach (var itemDer in listaDer)
                {
                    var suby = Reports_DA.GetPRO20(itemDer.Isin).FirstOrDefault();
                    if (suby.b3006_cod != null)
                    {
                        itemDer.CodigoSubyacente = suby.b3006_cod;
                        itemDer.Descripcion = suby.b3006_nom;                        
                    }
                }



                //Agrupamos los derivados por codigo subyacente e ISIN
                var listaDerGroups = listaDer.GroupBy(g => new
                {
                    g.CodigoSubyacente,
                    g.IdInstrumento,
                    g.IdTipoInstrumento,
                    g.Descripcion,
                    g.CodigoIC,
                    g.IsinPlantilla,
                    g.Isin
                });

                foreach (var subyIsin in listaDerGroups)
                {
                    //Creamos un nuevo elemento que agrupe a los que tienen el mismo codigo subyacente
                    var itemRV = new Temp_RentaVariable();
                    itemRV.CodigoSubyacente = subyIsin.Key.CodigoSubyacente;
                    itemRV.Descripcion = subyIsin.Key.Descripcion;
                    //itemRV.IdInstrumento = string.Empty;
                    itemRV.IdInstrumento = subyIsin.Key.IdInstrumento;
                    itemRV.IdTipoInstrumento = subyIsin.Key.IdTipoInstrumento;
                    itemRV.CodigoIC = _plantilla.CodigoIc;
                    itemRV.IsinPlantilla = isinPlantilla;

                    foreach (var derivado in subyIsin)
                    {
                        decimal? total = 0;
                        decimal? posCart = 0;
                        var isinsDerivado = listaFinal.Where(w => w.CodigoSubyacente == derivado.CodigoSubyacente && w.IdTipoInstrumento == derivado.IdTipoInstrumento).Distinct();
                        foreach (var isinDer in isinsDerivado)
                        {
                            //POSICIÓN EN CARTERA: Es la suma del campo "plusva" de la cartera de todos los isins de ese subyacente
                            var cartIsin = _cart.Where(w => w.isin.ToUpper().Equals(isinDer.Isin.ToUpper())).FirstOrDefault();
                            if (cartIsin != null)
                            {
                                posCart += cartIsin.plusva;
                            }

                            //TOTAL(€): para cada isin del subyacente y para cada CuentaContableDerivados obtener el saldo con el PRO23
                            foreach (var cta in _ctasDerivados)
                            {
                                var saldo = Reports_DA.GetPRO23(_plantilla.CodigoIc, isinDer.Isin, cta.Cuenta, _fechaInicio, _fechaInforme).FirstOrDefault();

                                if (saldo != null)
                                {
                                    total += -saldo.impeur;//le cambiamos el signo                                                           
                                }
                            }
                            //Tenemos que borrar de listaFinal los registros de los isins que tienen subyacente
                            //listaFinal.Remove(derivado);
                            listaDersBorrar.AddRange(listaFinal.Where(w => w.Isin.ToUpper().Equals(isinDer.Isin.ToUpper())));
                        }

                        itemRV.PosicionCartera = posCart;
                        //POSICIONES CERRADAS: lo calculamos por diferencia
                        itemRV.PosicionesCerradas = total - posCart;
                        itemRV.BoPTotal = total;

                        //y añadir un registro resumen con el subyacente     
                        listaDersAñadir.Add(itemRV);
                    }
                }
                listaFinal.RemoveAll(w => listaDersBorrar.Select(s => s.Isin.ToUpper()).Contains(w.Isin.ToUpper()));
                if (listaDersAñadir.Count > 0)
                {
                    //Los agruparemos para añadir sólo uno por cada código subyacente      
                    var dersAgrupados = listaDersAñadir.GroupBy(g => new
                    {
                        g.CodigoSubyacente,
                        g.IdInstrumento,
                        g.IdTipoInstrumento,
                        g.Descripcion,
                        g.BoPTotal,
                        g.PosicionCartera,
                        g.PosicionesCerradas
                    }).Select(s => new Temp_RentaVariable
                    {
                        CodigoIC = _plantilla.CodigoIc,
                        CodigoSubyacente = s.Key.CodigoSubyacente,
                        Descripcion = s.Key.Descripcion,
                        IdInstrumento = s.Key.IdInstrumento,
                        IdTipoInstrumento = s.Key.IdTipoInstrumento,
                        BoPTotal = s.Key.BoPTotal,
                        PosicionCartera = s.Key.PosicionCartera,
                        PosicionesCerradas = s.Key.PosicionesCerradas
                    });

                    //listaFinal.AddRange(listaDersAñadir);
                    listaFinal.AddRange(dersAgrupados);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static void calculosRAB(ref List<Temp_RentaVariable> listaFinal, IEnumerable<Temp_RentaVariable> listaTemp, string isinPlantilla)
        {
            if (listaTemp != null)
            {
                var distinctIsins = listaTemp.Select(s => s.Isin.ToUpper()).Distinct();
                var listaAñadir = new List<Temp_RentaVariable>();
                var isinTemps = distinctIsins as string[] ?? distinctIsins.ToArray();
                foreach (var isinTemp in isinTemps)
                {
                    var itemRV = new Temp_RentaVariable();
                    var temp = listaFinal.Where(w => w.Isin.ToUpper().Equals(isinTemp));
                    var tempRentaVariables = temp as Temp_RentaVariable[] ?? temp.ToArray();
                    itemRV.Descripcion = tempRentaVariables.FirstOrDefault()?.Descripcion;
                    itemRV.IdInstrumento = tempRentaVariables.FirstOrDefault()?.IdInstrumento;
                    itemRV.IdTipoInstrumento = tempRentaVariables.FirstOrDefault()?.IdTipoInstrumento;
                    itemRV.IdCategoria = tempRentaVariables.FirstOrDefault()?.IdCategoria;
                    itemRV.IdEmpresa = tempRentaVariables.FirstOrDefault()?.IdEmpresa;
                    itemRV.CodigoIC = _plantilla.CodigoIc;
                    itemRV.Isin = isinTemp;
                    itemRV.IsinPlantilla = isinPlantilla;
                    itemRV.PrecioF = tempRentaVariables.FirstOrDefault()?.PrecioF;
                    itemRV.PrecioFEUR = tempRentaVariables.FirstOrDefault()?.PrecioFEUR;
                    //POSICIÓN EN CARTERA: PLEur del G1 y G4
                    decimal posCart = _pro13.Where(w =>
                                                w.Isin.ToUpper().Equals(isinTemp)
                                                && (
                                                    w.Grupo.Contains("GRUPO-01")
                                                    || w.Grupo.Contains("GRUPO-04")
                                                )
                                                ).Sum(s => s.PLEur);

                    //POSICIONES CERRADAS: PLEur del G2 y G3
                    decimal posCerr = _pro13.Where(w =>
                                                w.Isin.ToUpper().Equals(isinTemp)
                                                && (
                                                    w.Grupo.Contains("GRUPO-02")
                                                    || w.Grupo.Contains("GRUPO-03")
                                                )
                                                ).Sum(s => s.PLEur);
                    //TOTAL(€): PLEur de todos los grupos (comprobar que es la suma de POSICIÓN EN CARTERA + POSICIONES CERRADAS)
                    decimal total = _pro13.Where(w => w.Isin.ToUpper().Equals(isinTemp)).Sum(s => s.PLEur);

                    itemRV.PosicionCartera = posCart;
                    itemRV.PosicionesCerradas = posCerr;
                    itemRV.BoPTotal = total;
                    
                    //listaFinal.RemoveAll(w => w.Isin.ToUpper().Equals(isinTemp));
                    listaAñadir.Add(itemRV);                    
                }

                listaFinal.RemoveAll(w => isinTemps.Contains(w.Isin.ToUpper()));
                listaFinal.AddRange(listaAñadir);
            }
        }

        private static void tratar601()
        {
            var trG4 = _pro13.Where(w => w.TipMovO == "601" && Utils.GetGrupoInt(w.Grupo) == 4).ToList();
            trG4.ForEach(i => Utils.ChangeGroup(i, 1));
            var trG3 = _pro13.Where(w => w.TipMovO == "601" && Utils.GetGrupoInt(w.Grupo) == 3).ToList();
            trG3.ForEach(i => Utils.ChangeGroup(i, 2));
        }

        /// <summary>
        /// Tratamos la operaciones corporativas que tengan TipMovO = 817 - EQUIPARACIONES
        /// </summary>
        private static void tratar817()
        {
            var pro13_817 = _pro13.Where(w => w.TipMovO == "817").ToList();
            var equiv = RentaVariable_Equivalencias_Local;

            foreach(var itemPro13_817 in pro13_817)
            {
                var itemEquiv = equiv.FirstOrDefault(w => String.Equals(w.OldIsin, itemPro13_817.Isin, StringComparison.CurrentCultureIgnoreCase)
                                && itemPro13_817.FechaO == w.FechaEquiparacion);

                //Buscamos en _pro13 el resto de ítems que tienen el mismo ISIN (pero que no sean el ítem actual) y que cumplan las siguientes condiciones
                var itemsCambiar = _pro13.Where(w =>
                {
                    return itemEquiv != null && (w.Isin.ToUpper() == itemPro13_817.Isin.ToUpper()
                                                 && w.FechaO < itemEquiv.FechaIniDerechos
                                                 && (w.FechaC == null || (w.FechaC != null && itemEquiv.FechaIniDerechos < w.FechaC))
                                                 && w != itemPro13_817);
                });

                //REPARTIMOS TÍTULOS
                //Si todos los que hemos encontrado no pertenecen al mismo grupo, repartimos los títulos de itemPro13_817 entre los que hemos encontrado itemsCambiar
                //(si pertenecen al mismo grupo no necesitamos hacer repartición porque se agruparán en una única línea con el total de NumTit)
                //if (itemsCambiar.Select(s => s.Grupo).Distinct().Count() > 1)
                //{
                foreach (var itemCambiar in itemsCambiar)
                {
                    itemCambiar.NumTit = (itemPro13_817.NumTit / itemsCambiar.Sum(s => s.NumTit)) * itemCambiar.NumTit;

                    //ESTABLECEMOS GRUPO CORRECTO
                    changeGrupo817(itemCambiar, itemPro13_817);
                }
                //}                
            }
        }

        private static void changeGrupo817(usp_gestio_pro_13_Result itemPro13, usp_gestio_pro_13_Result itemPro13_OpCorp)
        {
            if (
                (Utils.GetGrupoInt(itemPro13.Grupo) == 1 || Utils.GetGrupoInt(itemPro13.Grupo) == 2)
                && itemPro13_OpCorp.TipMovF == "700"
              )
                Utils.ChangeGroup(itemPro13,2);

            else if (
                (Utils.GetGrupoInt(itemPro13.Grupo) == 1 || Utils.GetGrupoInt(itemPro13.Grupo) == 2)
                && string.IsNullOrEmpty(itemPro13_OpCorp.TipMovF)
              )
                Utils.ChangeGroup(itemPro13, 1);
            else if (
                (Utils.GetGrupoInt(itemPro13.Grupo) == 4 || Utils.GetGrupoInt(itemPro13.Grupo) == 4)
                && itemPro13_OpCorp.TipMovF == "700"
              )
                Utils.ChangeGroup(itemPro13, 3);
            else if (
                (Utils.GetGrupoInt(itemPro13.Grupo) == 4 || Utils.GetGrupoInt(itemPro13.Grupo) == 3)
                && string.IsNullOrEmpty(itemPro13_OpCorp.TipMovF)
              )
                Utils.ChangeGroup(itemPro13, 4);            
        }

        /// <summary>
        /// Esta alerta nos avisará de los TipMovF que no estemos teniendo en cuenta en RentaVariable_VM.tratarContraSplits
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="seccion"></param>
        /// <param name="plantilla"></param>
        /// <param name="fecha"></param>
        /// <param name="checkAntesPreview"></param>
        /// <returns></returns>
        public static string Validar(Plantilla plantilla, DateTime fecha, bool checkAntesPreview)
        {
            try
            {
                string resultado = validarCodsNoTratados(plantilla, fecha);

                //Sólo validamos que hay ampliaciones de capital antes de mostrar las Previews. Después de las previews y antes de mostrar el informe no necesitamos volver a mostrarlo
                if (checkAntesPreview)
                {
                    resultado += validarTiposOperación(plantilla, fecha);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Log.Error("Error RentaVariable_VM/Validar", ex);
                throw;
            }
        }

        private static string validarCodsNoTratados(Plantilla plantilla, DateTime fecha)
        {
            string resultado = null;

            //Validamos que todos los códigos TipMovF que vienen en el PRO13 (el PRO13 filtrado) y empiecen por 8
            //los estemos tratando en tratarContrasplits            

            if(_pro13 == null)
                _pro13 = Utils.GetPro13SeccRv(plantilla, fecha);

            var opersCorpt = _pro13.Where(w => !string.IsNullOrEmpty(w.TipMovF) && w.TipMovF.StartsWith("8")).ToList();

            //Quiero los cods que están en opersCorpt y no se encuentran en VariablesGlobales.OperacionesCorpCods
            //Agrupamos para mostrar cada ISIN una sóla vez
            var noTratadas = opersCorpt.Where(w => !OperacionesCorpCods.Contains(w.TipMovF)).GroupBy(g => new
            {
                g.Isin,
                g.Nombre,
                g.TipMovF
            });

            if (noTratadas.Any())
            {
                string mens = string.Empty;

                //Ponemos la información 
                string infoString = "{0}: {1} - {2}";
                foreach (var item in noTratadas)
                {
                    mens += string.Format(infoString, item.Key.TipMovF, item.Key.Isin, item.Key.Nombre);
                    mens += Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(mens))
                {
                    resultado += Environment.NewLine;
                    resultado += Resource.AlertaRentaVarOperCorpCods;
                    resultado += Environment.NewLine;
                    resultado += mens;
                }
            }

            return resultado;
        }        

        private static string validarTiposOperación(Plantilla plantilla, DateTime fecha)
        {
            string resultado = null;

            //Miramos si en el PRO13 (sin filtrar) ISINS que coincidan con OldIsin 

            if (RentaVariable_Equivalencias_Local == null)
            {
                SetVariablesGlobales();
            }

            if (RentaVariable_Equivalencias_Local != null)
            {
                var oldIsins = RentaVariable_Equivalencias_Local.Select(s => s.OldIsin.ToUpper()).ToList();

                if (Pro13_Local == null)
                {
                    SetVariablesGlobales(typeof(usp_gestio_pro_13_Result), plantilla, fecha);
                }

                //Agrupamos para mostrar cada ISIN una sóla vez
                //var isins = VariablesGlobales.Pro13_Local.Where(w => oldIsins.Contains(w.Isin.ToUpper())).GroupBy(g => new
                if (Pro13_Local != null)
                {
                    var isins = Pro13_Local.Where(w => oldIsins.Contains(w.Isin.ToUpper())).Select(x => new
                    {
                        x.Isin,
                        x.Nombre,
                        TipoOperacion = getTipoOperacion(x.Isin),
                        FechaIniDerechos = getFechaIniDerechos(x.Isin),
                        x.FechaO
                    }).Distinct().GroupBy(g => new
                    {
                        g.TipoOperacion
                    });

            
                    //Ponemos la información 
                    string infoString = "{0} {1}";
                    //Para cada tipo de operación
                    foreach (var item in isins)
                    {
                        //Esta variable nos hace falta porque sólo mostraremos la alerta si algún item de este tipo de operación
                        //cumple la condición que tenemos a continuación.
                        bool mostrar = false;
                        string mensItem = Environment.NewLine;
                        mensItem += item.Key.TipoOperacion.ToUpper();
                        //Para cada operación dentro de cada tipo de operación
                        foreach (var subitem in item)
                        {
                            //Si tiene fechaIniDchos la comparamos con la fechaIni del movimiento y si la fecha del movimiento es anterior a la fechaIniDchos mostramos alerta. En caso contrario no mostramos alerta.
                            //Si fechaIniDchos es NULL también mostramos alerta
                            if (subitem.FechaIniDerechos == null ||
                                (subitem.FechaIniDerechos != null && subitem.FechaO != null && subitem.FechaO < subitem.FechaIniDerechos)
                                )
                            {
                                string fechaIniDchos = subitem.FechaIniDerechos?.ToShortDateString() ?? string.Empty;
                                string mens = string.Format(infoString, fechaIniDchos, subitem.Nombre);
                                if (string.IsNullOrEmpty(mens)) continue;
                                mensItem += Environment.NewLine;
                                mensItem += mens.Trim();
                                mostrar = true;
                            }
                        }

                        if (mostrar)
                        {
                            resultado += mensItem;
                            resultado += Environment.NewLine;
                        }
                    }
                }
            }

            return resultado;
        }

        private static string getTipoOperacion(string isin)
        {
            string resultado = string.Empty;

            var obj = RentaVariable_Equivalencias_Local.Where(w => w.OldIsin.ToUpper() == isin.ToUpper()).FirstOrDefault();

            if(obj != null)
            {
                resultado = obj.TipoOperacion;
            }

            return resultado;
        }

        private static DateTime? getFechaIniDerechos(string isin)
        {
            DateTime? resultado = null;

            var obj = RentaVariable_Equivalencias_Local.FirstOrDefault(w => String.Equals(w.OldIsin, isin, StringComparison.CurrentCultureIgnoreCase));

            if (obj != null)
            {
                resultado = obj.FechaIniDerechos;
            }

            return resultado;
        }        

        public static Report GetReportRentaVariable(string codigoIC, string isin,DateTime fechaInforme, DateTime fechaInicio)
        {
            Report rep = new ReportRentabilidadVariable(isin, codigoIC, fechaInforme, fechaInicio);

            rep.ReportParameters["CodigoIC"].Value = codigoIC;
            rep.ReportParameters["Isin"].Value = isin;
            return rep;
        }

        
    }
}
