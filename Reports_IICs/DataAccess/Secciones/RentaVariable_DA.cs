using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public class T_RentaVariable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    this.OnPropertyChanged("ID");
                }
            }
        }

        private string codigoIC;
        public string CodigoIC
        {
            get
            {
                return this.codigoIC;
            }
            set
            {
                if (value != this.codigoIC)
                {
                    this.codigoIC = value;
                    this.OnPropertyChanged("CodigoIC");
                }
            }
        }

        private string isinPlantilla;
        public string IsinPlantilla
        {
            get
            {
                return this.isinPlantilla;
            }
            set
            {
                if (value != this.isinPlantilla)
                {
                    this.isinPlantilla = value;
                    this.OnPropertyChanged("IsinPlantilla");
                }
            }
        }

        private string isin;
        public string Isin
        {
            get
            {
                return this.isin;
            }
            set
            {
                if (value != this.isin)
                {
                    this.isin = value;
                    this.OnPropertyChanged("Isin");
                }
            }
        }

        private string grupo;
        public string Grupo
        {
            get
            {
                return this.grupo;
            }
            set
            {
                if (value != this.grupo)
                {
                    this.grupo = value;
                    this.OnPropertyChanged("Grupo");
                }
            }
        }

        private Nullable<int> grupoNuevo;
        public Nullable<int> GrupoNuevo
        {
            get
            {
                return this.grupoNuevo;
            }
            set
            {
                if (value != this.grupoNuevo)
                {
                    this.grupoNuevo = value;
                    this.OnPropertyChanged("GrupoNuevo");
                }
            }
        }

        private DateTime? fechaCompra;
        public DateTime? FechaCompra
        {
            get
            {
                return this.fechaCompra;
            }
            set
            {
                if (value != this.fechaCompra)
                {
                    this.fechaCompra = value;
                    this.OnPropertyChanged("FechaCompra");
                }
            }
        }

        private DateTime? fechaVenta;
        public DateTime? FechaVenta
        {
            get
            {
                return this.fechaVenta;
            }
            set
            {
                if (value != this.fechaVenta)
                {
                    this.fechaVenta = value;
                    this.OnPropertyChanged("FechaVenta");
                }
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                if (value != this.descripcion)
                {
                    this.descripcion = value;
                    this.OnPropertyChanged("Descripcion");
                }
            }
        }

        private Nullable<decimal> numTit;
        public Nullable<decimal> NumTit
        {
            get
            {
                return this.numTit;
            }
            set
            {
                if (value != this.numTit)
                {
                    this.numTit = value;
                    this.OnPropertyChanged("NumTit");
                }
            }
        }

        private Nullable<decimal> precioIni;
        public Nullable<decimal> PrecioIni
        {
            get
            {
                return this.precioIni;
            }
            set
            {
                if (value != this.precioIni)
                {
                    this.precioIni = value;
                    this.OnPropertyChanged("PrecioIni");
                }
            }
        }

        private Nullable<decimal> tipoCambioIni;
        public Nullable<decimal> TipoCambioIni
        {
            get
            {
                return this.tipoCambioIni;
            }
            set
            {
                if (value != this.tipoCambioIni)
                {
                    this.tipoCambioIni = value;
                    this.OnPropertyChanged("TipoCambioIni");
                }
            }
        }

        private Nullable<decimal> precioAjustado;
        public Nullable<decimal> PrecioAjustado
        {
            get
            {
                return this.precioAjustado;
            }
            set
            {
                if (value != this.precioAjustado)
                {
                    this.precioAjustado = value;
                    this.OnPropertyChanged("PrecioAjustado");
                }
            }
        }

        private Nullable<decimal> precioFin;
        public Nullable<decimal> PrecioFin
        {
            get
            {
                return this.precioFin;
            }
            set
            {
                if (value != this.precioFin)
                {
                    this.precioFin = value;
                    this.OnPropertyChanged("PrecioFin");
                }
            }
        }

        private Nullable<decimal> tipoCambioFin;
        public Nullable<decimal> TipoCambioFin
        {
            get
            {
                return this.tipoCambioFin;
            }
            set
            {
                if (value != this.tipoCambioFin)
                {
                    this.tipoCambioFin = value;
                    this.OnPropertyChanged("TipoCambioFin");
                }
            }
        }

        private Nullable<decimal> precioFinEuros;
        public Nullable<decimal> PrecioFinEuros
        {
            get
            {
                return this.precioFinEuros;
            }
            set
            {
                if (value != this.precioFinEuros)
                {
                    this.precioFinEuros = value;
                    this.OnPropertyChanged("precioFinEuros");
                }
            }
        }

        private Nullable<decimal> efectivo;
        public Nullable<decimal> Efectivo
        {
            get
            {
                return this.efectivo;
            }
            set
            {
                if (value != this.efectivo)
                {
                    this.efectivo = value;
                    this.OnPropertyChanged("Efectivo");
                }
            }
        }

        private Nullable<decimal> boPdivisa;
        public Nullable<decimal> BoPDivisa
        {
            get
            {
                return this.boPdivisa;
            }
            set
            {
                if (value != this.boPdivisa)
                {
                    this.boPdivisa = value;
                    this.OnPropertyChanged("BoPDivisa");
                }
            }
        }

        private Nullable<decimal> boPPrecio;
        public Nullable<decimal> BoPPrecio
        {
            get
            {
                return this.boPPrecio;
            }
            set
            {
                if (value != this.boPPrecio)
                {
                    this.boPPrecio = value;
                    this.OnPropertyChanged("BoPPrecio");
                }
            }
        }

        private Nullable<decimal> boPTotal;
        public Nullable<decimal> BoPTotal
        {
            get
            {
                return this.boPTotal;
            }
            set
            {
                if (value != this.boPTotal)
                {
                    this.boPTotal = value;
                    this.OnPropertyChanged("BoPTotal");
                }
            }
        }

        private Nullable<decimal> boPTotalPorcentaje;
        public Nullable<decimal> BoPTotalPorcentaje
        {
            get
            {
                return this.boPTotalPorcentaje;
            }
            set
            {
                if (value != this.boPTotalPorcentaje)
                {
                    this.boPTotalPorcentaje = value;
                    this.OnPropertyChanged("BoPTotalPorcentaje");
                }
            }
        }

        private Nullable<decimal> posicionCartera;
        public Nullable<decimal> PosicionCartera
        {
            get
            {
                return this.posicionCartera;
            }
            set
            {
                if (value != this.posicionCartera)
                {
                    this.posicionCartera = value;
                    this.OnPropertyChanged("PosicionCartera");
                }
            }
        }

        private Nullable<decimal> posicionesCerradas;
        public Nullable<decimal> PosicionesCerradas
        {
            get
            {
                return this.posicionesCerradas;
            }
            set
            {
                if (value != this.posicionesCerradas)
                {
                    this.posicionesCerradas = value;
                    this.OnPropertyChanged("PosicionesCerradas");
                }
            }
        }

        private Nullable<long> numO;
        public Nullable<long> NumO
        {
            get
            {
                return this.numO;
            }
            set
            {
                if (value != this.numO)
                {
                    this.numO = value;
                    this.OnPropertyChanged("NumO");
                }
            }
        }

        private string tipoO;
        public string TipoO
        {
            get
            {
                return this.tipoO;
            }
            set
            {
                if (value != this.tipoO)
                {
                    this.tipoO = value;
                    this.OnPropertyChanged("TipoO");
                }
            }
        }

        private string estado;
        public string Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                if (value != this.estado)
                {
                    this.estado = value;
                    this.OnPropertyChanged("Estado");
                }
            }
        }

        private Nullable<long> numC;
        public Nullable<long> NumC
        {
            get
            {
                return this.numC;
            }
            set
            {
                if (value != this.numC)
                {
                    this.numC = value;
                    this.OnPropertyChanged("NumC");
                }
            }
        }

        private string tipoC;
        public string TipoC
        {
            get
            {
                return this.tipoC;
            }
            set
            {
                if (value != this.tipoC)
                {
                    this.tipoC = value;
                    this.OnPropertyChanged("TipoC");
                }
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

    }
    public class RentaVariable_DA : INotifyPropertyChanged
    {
        public static IEnumerable<Temp_RentaVariable> GetTemp(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentaVariable.Where(w => w.CodigoIC == codigoIC);
        }

        public static Temp_RentaVariable GetTempById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentaVariable.AsNoTracking().Where(w => w.Id == id).FirstOrDefault();
        }
        public static List<RentaVariable_PrecioAjustado> GetPreciosAjustados(string codigoIC, DateTime fechaInforme, string isin = null)
        {
            var año = fechaInforme.Year;
            var dbContext = new Reports_IICSEntities();
            try
            {
                var query = dbContext.RentaVariable_PrecioAjustado.Where(w =>
                                                                w.CodigoIC == codigoIC
                                                                && w.FechaInforme.Year == fechaInforme.Year
                                                                && w.FechaInforme <= fechaInforme
                                                                && w.FechaInforme.Year == fechaInforme.Year
                                                                );

                if (!string.IsNullOrEmpty(isin))
                {
                    query = query.Where(w => w.Isin.ToUpper() == isin.ToUpper());
                }

                var grupos = query.GroupBy(g => new
                {
                    g.Isin,
                    g.GrupoNuevo
                });
                var output = new List<RentaVariable_PrecioAjustado>();

                //tenemos que devolver sólo el primero de cada grupo, el más reciente (FechaInforme)

                foreach (var item in grupos)
                {
                    var obj = item.OrderByDescending(o=>o.FechaInforme).First();
                    output.Add(obj);
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Si lo dejan a null lo eliminamos de RentaVariable_PrecioAjustado
        /// o si el grupo es el mismo que viene del pro13 (Grupo)
        /// GrupoNuevo es donde almacenaremos el nuevo grupo que establezcan en la Preview
        /// </summary>
        /// <param name="sel"></param>
        /// <param name="temp"></param>
        //public static void SavePrecioAjustado(T_RentaVariable sel, Temp_RentaVariable temp, DateTime fecha)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    var objPrecAj = dbContext.RentaVariable_PrecioAjustado.Where(w =>
        //                        w.CodigoIC == sel.CodigoIC
        //                        && w.Isin == sel.Isin                                
        //                        //&& w.NumO == sel.NumO
        //                        //&& w.TipoO == sel.TipoO
        //                        //&& w.NumC == sel.NumC
        //                        //&& w.TipoC == sel.TipoC
        //                        ).FirstOrDefault();

        //    //Puede ser que el movimiento nos venga del PRO13
        //    //o se haya añadido manualmente
        //    var objAdded = dbContext.RentaVariable_Added.Where(w => w.CodigoIC == sel.CodigoIC
        //                                                        && w.Isin.ToUpper() == sel.Isin.ToUpper()
        //                                                        && w.Ejercicio == fecha.Year).FirstOrDefault();

        //    //Si viene del PRO
        //    if (objAdded == null)
        //    {
        //        //ya no se utiliza sólo para el precio ajustado
        //        //if ((sel.NumTit.HasValue && sel.PrecioAjustado.HasValue) 
        //        //    || sel.GrupoNuevo != Utils.GetGrupoInt(temp.Grupo)
        //        //    )
        //        //{
        //            var newPrecAj = new RentaVariable_PrecioAjustado();

        //            Utils.CopyPropertyValues(sel, newPrecAj, "Id");
        //            newPrecAj.NumeroTitulos = Convert.ToDecimal(sel.NumTit);
        //            newPrecAj.PrecioIni = sel.PrecioIni;
        //            newPrecAj.PrecioAjustado = sel.PrecioAjustado;
        //            newPrecAj.PrecioFin = sel.PrecioFin;
        //            newPrecAj.PrecioFinEuros = sel.PrecioFinEuros;
        //            newPrecAj.Grupo = sel.Grupo;
        //            newPrecAj.GrupoNuevo  = temp.GrupoNuevo;
        //            newPrecAj.Ejercicio = fecha.Year;

        //            if (objPrecAj != null)
        //            {
        //                dbContext.RentaVariable_PrecioAjustado.Remove(objPrecAj);
        //            }

        //            dbContext.RentaVariable_PrecioAjustado.Add(newPrecAj);

        //        //}
        //        //else if (!sel.PrecioAjustado.HasValue)
        //        //else
        //        //{
        //        //    if (objPrecAj != null)
        //        //    {
        //        //        dbContext.RentaVariable_PrecioAjustado.Remove(objPrecAj);
        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        Utils.CopyPropertyValues(sel, objAdded);
        //        Insert_or_Update_RentaVariable_Added(objAdded);
        //    }


        //    //Tenemos que actualizar los datos que se acaban de generar en la tabla Temp
        //    //para que en el report salga este cambio
        //    var objTemp = dbContext.Temp_RentaVariable.Where(w =>
        //                        w.CodigoIC == sel.CodigoIC
        //                        && w.Isin == sel.Isin
        //                        && (
        //                            //!string.IsNullOrEmpty(w.Grupo)
        //                            //&& !string.IsNullOrEmpty(temp.Grupo) &&
        //                            w.Grupo == temp.Grupo
        //                            )
        //                            ).FirstOrDefault();

        //    if(objTemp != null)
        //    {
        //        Utils.CopyPropertyValues(sel, objTemp, "Id");
        //        objTemp.GrupoNuevo = sel.GrupoNuevo;
        //        objTemp.PrecioAjustado = sel.PrecioAjustado;
        //    }

        //    //Si este título tiene PrecioAjustado de la sección de RV 
        //    //tendremos que recuperar tendremos PlusvaliasMinusvalias de la sección de RV
        //    //sumar el Total € (BoPTotal)
        //    //En caso de no tener PrecioAjustado no es necesario porque recuperaremos la información del PRO13
        //    var objPl = dbContext.Temp_PlusvaliasDividendos.Where(r => r.CodigoIC == sel.CodigoIC
        //                                                    && r.Isin.ToUpper() == sel.Isin.ToUpper()).FirstOrDefault();

        //    if (objPl != null)
        //    {
        //        var objRv = dbContext.Temp_RentaVariable.Where(w => w.CodigoIC == sel.CodigoIC
        //                                                    && w.Isin.ToUpper() == sel.Isin.ToUpper()).ToList();

        //        objPl.PlusvaliasMinusvalias = objRv.Sum(s => s.BoPTotal);
        //    }

        //    try
        //    {
        //        dbContext.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private static bool modificado(object obj1, object obj2, List<string> propiedadesNoComparar)
        //private static bool modificado(T_RentaVariable obj1, Temp_RentaVariable obj2)
        //{
        //    bool output = false;

        //    output = obj1.NumTit != obj2.NumTit;
        //    output = obj1.PrecioIni != obj2.PrecioIni;
        //    output = obj1.PrecioAjustado != obj2.PrecioAjustado;
        //    output = obj1.PrecioFin != obj2.PrecioFin;
        //    output = obj1.PrecioFinEuros != obj2.PrecioFinEuros;
        //    output = obj1.Efectivo != obj2.Efectivo;

        //    /*
        //     * No funciona correctamente de momento
        //    var props1 = obj1.GetType().GetProperties(
        //    BindingFlags.DeclaredOnly |
        //    BindingFlags.Public |
        //    BindingFlags.Instance)
        //    .Where(p => !p.PropertyType.IsClass)
        //    ;


        //    foreach (PropertyInfo item1 in props1)
        //    {
        //        if (propiedadesNoComparar.Contains(item1.Name) //Que no sea una de las propiedades que no queremos comparar
        //            || item1.PropertyType.Name.Contains("ICollection")
        //            || !item1.PropertyType.FullName.Contains("System."))
        //        {
        //            continue;
        //        }

        //        //Buscamos en el objeto 2 la propiedad con el mismo nombre
        //        PropertyInfo item2 = obj2.GetType().GetProperty(item1.Name, BindingFlags.Public | BindingFlags.Instance);

        //        //Si tiene valores distintos es que ha cambiado
        //        if (item2 != null && item1.GetValue(obj1, null) != item2.GetValue(obj2, null))
        //        {
        //            output = true;
        //        }
        //    }
        //    */

        //    return output;
        //}


        public static ObservableCollection<T_RentaVariable> GetGrupoRV(string codigoIC, string isinPlantilla, List<string> instrumentosIds, List<string> tiposInstrumentoIds, string grupo = null)
        {
            var lista = new ObservableCollection<T_RentaVariable>();
            var obj = new List<Temp_RentaVariable>();
            using (var dbContext = new Reports_IICSEntities())
            {
                obj = dbContext.Temp_RentaVariable.AsNoTracking().Where(w => w.CodigoIC == codigoIC).ToList();
            }
            if (!string.IsNullOrEmpty(isinPlantilla))
            {
                obj = obj.Where(w => w.IsinPlantilla == isinPlantilla).ToList();
            }

            if (instrumentosIds != null)
            {
                obj = obj.Where(w => instrumentosIds.Contains(w.IdInstrumento)).ToList();
            }

            if (tiposInstrumentoIds != null)
            {
                obj = obj.Where(w => tiposInstrumentoIds.Contains(w.IdTipoInstrumento)).ToList();
            }

            if (!string.IsNullOrEmpty(grupo))
            {
                var gr = Utils.GetGrupoInt(grupo);
                //obj = obj.Where(w => w.Grupo.Contains(grupo));
                obj = obj.Where(w => w.GrupoNuevo == gr).ToList();

                //Ordenar
                //Grupo 1 por Descripción
                if (grupo.Contains("1"))
                {
                    obj = obj.OrderBy(o => o.Descripcion).ToList();
                }
                //Grupo 2 y 3 por FechaVenta
                else if (grupo.Contains("2") || grupo.Contains("3"))
                {
                    obj = obj.OrderBy(o => o.FechaVenta).ToList();
                }
                //Grupo 4 y 5 por FechaCompra
                else if (grupo.Contains("4") || grupo.Contains("5"))
                {
                    obj = obj.OrderBy(o => o.FechaCompra).ToList();
                }
            }

            foreach (var item in obj)
            {
                
                var tmp = new T_RentaVariable();
                Utils.CopyPropertyValues(item, tmp);
                //tmp.TipoCambioFin = item.CambioF != 0 ? item.CambioF : item.CambioC;
                //tmp.TipoCambioIni = item.CambioI != 0 ? item.CambioI : item.CambioO;
                tmp.PrecioFinEuros = tmp.PrecioFin * tmp.TipoCambioFin;
                //tmp.PrecioIni = item.PrecioIni;// item.PrecioI != 0 ? item.PrecioI : item.PrecioO;
                //tmp.PrecioFin = item.PrecioF != 0 ? item.PrecioF : item.PrecioO;
                //tmp.Id = item.Id;
                //tmp.CodigoIC = item.CodigoIC;
                //tmp.IsinPlantilla = item.IsinPlantilla;
                //tmp.Isin = item.Isin;
                //tmp.Grupo = item.Grupo;
                //tmp.GrupoNuevo = item.GrupoNuevo;
                //tmp.FechaCompra = item.FechaCompra;
                //tmp.FechaVenta = item.FechaVenta;
                //tmp.Descripcion = item.Descripcion;
                //tmp.NumTit = item.NumTit;
                //tmp.PrecioIni = item.PrecioIni;
                //tmp.PrecioAjustado = item.PrecioAjustado;
                //tmp.PrecioFin = item.PrecioFin;
                //tmp.PrecioFinEuros = item.PrecioFinEuros;
                //tmp.Efectivo = item.Efectivo;
                //tmp.BoPDivisa = item.BoPDivisa;
                //tmp.BoPPrecio = item.BoPPrecio;
                //tmp.BoPTotal = item.BoPTotal;
                //tmp.BoPTotalPorcentaje = item.BoPTotalPorcentaje;
                //tmp.PosicionCartera = item.PosicionCartera;
                //tmp.PosicionesCerradas = item.PosicionesCerradas;
                //tmp.NumO = item.NumO;
                //tmp.TipoO = item.TipoO;
                //tmp.NumC = item.NumC;
                //tmp.TipoC = item.TipoC;


                lista.Add(tmp);
            }
            return lista;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        //public static List<RentaVariable_Equivalencias> GetOldIsins(List<string> listaIsins)
        //{
        //    Reports_IICSEntities dbContext = new Reports_IICSEntities();

        //    listaIsins = listaIsins.Select(s => s.ToUpper()).ToList();

        //    var oldIsins = dbContext.RentaVariable_Equivalencias.Where(w => listaIsins.Contains(w.OldIsin)).ToList();

        //    return oldIsins;
        //}

        /// <summary>
        /// Si existe actualizamos y si no insertamos
        /// </summary>
        /// <param name="rva"></param>
        //public static void Insert_or_Update_RentaVariable_Added(RentaVariable_Added rva)
        //{
        //    try
        //    {
        //        var dbContext = new Reports_IICSEntities();
        //        var obj = dbContext.RentaVariable_Added.Where(w =>
        //                                    w.CodigoIC == rva.CodigoIC
        //                                    && w.Isin.ToUpper() == rva.Isin.ToUpper()
        //                                    && w.Grupo == rva.Grupo
        //                                    && w.Ejercicio == rva.Ejercicio
        //                                    ).FirstOrDefault();

        //        var objTemp = new Temp_RentaVariable();

        //        if (obj == null)
        //        {
        //            //Añadimos a la tabla added
        //            dbContext.RentaVariable_Added.Add(rva);

        //            //Cuando añadimos una, si está en la tabla de Deleted, la eliminamos
        //            var objDel = dbContext.RentaVariable_Deleted.Where(w =>
        //                                    w.CodigoIC == rva.CodigoIC
        //                                    && w.Isin.ToUpper() == rva.Isin.ToUpper()
        //                                    && w.Grupo == rva.Grupo
        //                                    && w.Ejercicio == rva.Ejercicio
        //                                    ).FirstOrDefault();
        //            dbContext.RentaVariable_Deleted.Remove(objDel);

        //            //Tenemos que añadirlo también a la tabla temporal para que se vea en el informe 
        //            //que hemos generado
        //            Utils.CopyPropertyValues(rva, objTemp);
        //            objTemp.GrupoNuevo = rva.Grupo;
        //            //La opción de añadir un registro en la Preview está pensada sólo para Acciones: RVA y VAL
        //            objTemp.IdInstrumento = VariablesGlobales.Instrumentos_Local.Where(w => w.Codigo == "RVA").FirstOrDefault().Id;
        //            objTemp.IdTipoInstrumento = VariablesGlobales.InstrumentosTipos_Local.Where(w => w.Codigo == "VAL").FirstOrDefault().Id;
        //            dbContext.Temp_RentaVariable.Add(objTemp);

        //        }
        //        //actualizar
        //        else
        //        {
        //            //No hacemos Utils.CopyPropertyValues(rva, obj, "Id") porque son dos entidades distintas y al
        //            //hacer SaveChanges nos lanzaría una excepción
        //            obj.Descripcion = rva.Descripcion;
        //            obj.NumTit = rva.NumTit;
        //            obj.PrecioIni = rva.PrecioIni;
        //            obj.PrecioAjustado = rva.PrecioAjustado;
        //            obj.PrecioFin = rva.PrecioFin;
        //            obj.PrecioFinEuros = rva.PrecioFinEuros;
        //            obj.Efectivo = rva.Efectivo;
        //            obj.BoPDivisa = rva.BoPDivisa;

        //            objTemp = dbContext.Temp_RentaVariable.Where(w =>
        //                                    w.CodigoIC == rva.CodigoIC
        //                                    && w.Isin.ToUpper() == rva.Isin.ToUpper()
        //                                    && w.GrupoNuevo == rva.Grupo
        //                                    ).FirstOrDefault();
        //            //if (objTemp == null)
        //            //{

        //            //    Utils.CopyPropertyValues(rva, objTemp, "Id");
        //            //}

        //            //No hacemos Utils.CopyPropertyValues(rva, objTemp) porque son dos entidades distintas y al
        //            //hacer SaveChanges nos lanzaría una excepción

        //            if (objTemp != null)
        //            {
        //                objTemp.Descripcion = rva.Descripcion;
        //                objTemp.Isin = rva.Isin;
        //                objTemp.GrupoNuevo = rva.Grupo;
        //                objTemp.NumTit = rva.NumTit;
        //                objTemp.PrecioIni = rva.PrecioIni;
        //                objTemp.PrecioAjustado = rva.PrecioAjustado;
        //                objTemp.PrecioFin = rva.PrecioFin;
        //                objTemp.PrecioFinEuros = rva.PrecioFinEuros;
        //                objTemp.Efectivo = rva.Efectivo;
        //                objTemp.BoPDivisa = rva.BoPDivisa;
        //                objTemp.BoPPrecio = rva.BoPPrecio;
        //                objTemp.BoPTotal = rva.BoPTotal;
        //                objTemp.BoPTotalPorcentaje = rva.BoPTotalPorcentaje;
        //                //La opción de añadir un registro en la Preview está pensada sólo para Acciones: RVA y VAL
        //                objTemp.IdInstrumento = VariablesGlobales.Instrumentos_Local.Where(w => w.Codigo == "RVA").FirstOrDefault().Id;
        //                objTemp.IdTipoInstrumento = VariablesGlobales.InstrumentosTipos_Local.Where(w => w.Codigo == "VAL").FirstOrDefault().Id;
        //            }

        //        }

        //        dbContext.SaveChanges();                
        //    }
        //    //duplicate record
        //    catch (DuplicateKeyException ex)
        //    {
        //        throw new Exception(Resources.Resource.DuplicateKeyExceptionMessage, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Clave duplicada
        //        if (ex.HResult == -2146233087)
        //        {
        //            throw new Exception(Resources.Resource.DuplicateKeyExceptionMessage, ex);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}        

        //public static void DeleteRVItems(RentaVariable_Deleted item)
        //{
        //    try
        //    {
        //        var dbContext = new Reports_IICSEntities();

        //            //lo añadimos a la tabla RentaVariable_Deleted para no volver a mostrarlo
        //            //en posteriores generaciones
        //            dbContext.RentaVariable_Deleted.Add(item);

        //        //Si en su día fue añadido a RentaVariable_Added pero ahora lo estamos eliminando
        //        //tenemos que borrarlo de RentaVariable_Added
        //        var objAdded = dbContext.RentaVariable_Added.Where(w =>
        //                                    w.CodigoIC == item.CodigoIC
        //                                    && w.Isin.ToUpper() == item.Isin.ToUpper()
        //                                    && w.Grupo == item.Grupo
        //                                    && w.Ejercicio == item.Ejercicio
        //                                    ).FirstOrDefault();
        //        if (objAdded != null)
        //        {
        //            dbContext.RentaVariable_Added.Remove(objAdded);
        //        }



        //        //Lo borramos de Temp_RentaVariable para no mostrarlo tampoco en este informe
        //        var obj = dbContext.Temp_RentaVariable.Where(w =>
        //                        w.Isin.ToUpper() == item.Isin.ToUpper()
        //                        && w.GrupoNuevo == item.Grupo
        //                        ).FirstOrDefault();

        //        if (obj != null)
        //        {
        //            //Necesitamos Attach porque en este caso no funcionaba sólo con Remove
        //            //dbContext.Temp_RentaVariable.Attach(obj);
        //            //dbContext.Temp_RentaVariable.Remove(obj);

        //            dbContext.Entry(obj).State = EntityState.Deleted;
        //        }

        //        dbContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void DeleteTemp_RentaVariable(RentaVariable_Deleted item)
        //{
        //    try
        //    {
        //        var dbContext = new Reports_IICSEntities();
        //        var obj = dbContext.Temp_RentaVariable.Where(w =>
        //                        Utils.EqualsIgnoreCase(w.Isin, item.Isin)
        //                        && Utils.GetGrupoInt(w.Grupo) == item.Grupo
        //                        //&& w.NumO == item.NumO
        //                        && w.TipoO == item.TipoO
        //                        //&& w.NumC == item.NumC
        //                        //&& w.TipoC == item.TipoC
        //                        ).FirstOrDefault();

        //        if (obj != null)
        //        {
        //            dbContext.Temp_RentaVariable.Remove(obj);
        //            dbContext.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static List<RentaVariable_Deleted> GetRVEliminados(string codigoIC)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    var items = dbContext.RentaVariable_Deleted.Where(w => w.CodigoIC == codigoIC).ToList();
        //    return items;
        //}

        //public static List<RentaVariable_Added> GetRVAñadidos(string codigoIC)
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    //AsNoTracking porque queremos copiar sus datos a otra entidad distinta
        //    //así evitaremos: An entity object cannot be referenced by multiple instances of IEntityChangeTracker.
        //    var items = dbContext.RentaVariable_Added.AsNoTracking().Where(w => w.CodigoIC == codigoIC).ToList();
        //    return items;
        //}

        public static List<Get_PreviewChanges_RentaVariable_Result> GetPreviewChanges(string codigoIC, DateTime fechaInforme)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //var output = dbContext.RentaVariable_PrecioAjustado.Where(w => w.CodigoIC == codigoIC && w.FechaInforme <= fechaInforme).ToList();
            var output = dbContext.Get_PreviewChanges_RentaVariable(codigoIC, fechaInforme).ToList();

            return output;
        }

        public static int SavePrecioAjustado(RentaVariable_PrecioAjustado rvpa, Temp_RentaVariable temp)
        {
            var dbContext = new Reports_IICSEntities();
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Guardamos en la tabla RentaVariable_PrecioAjustado
                    //y recuperamos el id insertado (objPa)
                    var obj = dbContext.RentaVariable_PrecioAjustado.Where(w => w.CodigoIC == rvpa.CodigoIC
                                                                    && w.Isin.ToUpper() == rvpa.Isin.ToUpper()
                                                                    && w.Grupo == rvpa.Grupo
                                                                    && w.FechaInforme == rvpa.FechaInforme).FirstOrDefault();
                    int? idPrecioAjustado = null;
                    if (obj != null)
                    {
                        idPrecioAjustado = obj.Id;
                    }
                    var objPa = dbContext.Save_RentaVariable_PrecioAjustado(idPrecioAjustado, rvpa.CodigoIC, rvpa.Isin, rvpa.Descripcion, rvpa.FechaCompra, rvpa.FechaVenta, rvpa.NumeroTitulos, rvpa.PrecioIni, rvpa.PrecioAjustado, rvpa.PrecioFin, rvpa.PrecioFinEuros, rvpa.TipoCambioIni, rvpa.TipoCambioFin, rvpa.NumO, rvpa.TipoO, rvpa.NumC, rvpa.TipoC, rvpa.GrupoNuevo, rvpa.Grupo, rvpa.Estado, rvpa.Ejercicio, rvpa.FechaInforme, rvpa.IsVisible, rvpa.Added).ToList();
                    if (idPrecioAjustado == null && objPa.Count > 0)
                    {
                        idPrecioAjustado = objPa.FirstOrDefault().Value;
                    }

                    //idPrecioAjustado = objPa;

                    //Guardamos los NumO asociados a ese precio ajustado
                    foreach (var itemNumO in rvpa.RentaVariable_PrecioAjustado_NumO)
                    {
                        //if (objPa != null && objPa.FirstOrDefault() != null)
                        //{
                        dbContext.Save_RentaVariable_PrecioAjustado_NumO(idPrecioAjustado, itemNumO.NumO);
                        //}
                    }

                    //Guardamos el dato en la tabla temporal
                    var objTemp = dbContext.Temp_RentaVariable.Where(w =>
                        w.CodigoIC == temp.CodigoIC
                        && w.Isin.ToUpper() == temp.Isin.ToUpper()
                        && w.Grupo == temp.Grupo).FirstOrDefault();

                    if (objTemp == null)
                    {
                        objTemp = new Temp_RentaVariable();
                    }

                    Utils.CopyPropertyValues(temp, objTemp, "Id");

                    if (objTemp.Id == 0)
                    {
                        objTemp = dbContext.Temp_RentaVariable.Add(objTemp);
                    }

                    objTemp.IdPrecioAjustado = idPrecioAjustado;

                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();

                    return objTemp.Id;
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
                catch (DbUpdateException ex)
                {
                    //comprobamos en qué tabla/s se está produciendo el error
                    var entidades = ex.Entries;
                    throw ex;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static decimal GetTotalRV(string codigoIC)
        {
            decimal output = 0;

            var dbContext = new Reports_IICSEntities();
            try
            {
                var obj = dbContext.Get_Temp_Rentabilidad_Variable_Totales(codigoIC, 1).ToList();
                if(obj != null && obj.Sum(s => s.Valor) != null)
                {
                    output = (decimal)obj.Sum(s => s.Valor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }
    }
}
