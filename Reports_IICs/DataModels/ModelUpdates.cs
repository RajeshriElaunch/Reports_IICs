using System;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Reports_IICs.Helpers;

namespace Reports_IICs.DataModels
{
    class ModelUpdates
    {
    }

    public partial class Reports_IICSEntities : DbContext
    {
        /// <summary>
        /// Para los tests unitarios necesitamos un pequeño ajuste a nuestro contexto de Entity Framework para que soporte el uso de Effort, solo necesitamos agregar una sobrecarga que acepte una conexión.
        /// </summary>
        /// <param name="connection"></param>
        public Reports_IICSEntities(DbConnection connection)
       : base(connection, contextOwnsConnection: true)
        {
        }

        public DbSet Set(string name)
        {
            // you may need to fill in the namespace of your context
            return base.Set(Type.GetType(name));
        }
        private T CreateWithValues<T>(DbPropertyValues values)
    where T : new()
        {
            T entity = new T();
            Type type = typeof(T);

            foreach (var name in values.PropertyNames)
            {
                var property = type.GetProperty(name);
                property.SetValue(entity, values.GetValue<object>(name));
            }

            return entity;
        }

        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        var changeSetTracking = ChangeTracker.Entries<TrackingBase>();

        //        if (changeSetTracking != null)
        //        {
        //            //foreach (var entry in changeSet.Where(c => c.State != EntityState.Modified ))
        //            foreach (var entry in changeSetTracking.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified || c.State == EntityState.Deleted))
        //            {
        //                if (typeof(Plantilla).IsAssignableFrom(entry.Entity.GetType()))
        //                {
        //                    var entityBase = entry.Entity as Plantilla;
        //                    // use entry.OriginalValues
        //                    Plantilla plantilla = CreateWithValues<Plantilla>(entry.OriginalValues);
        //                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
        //                    {
        //                        #region GuardarHistorico

        //                        var hist = new Plantillas_Hist();
        //                        Utils.CopyPropertyValues(plantilla, hist);
        //                        this.Plantillas_Hist.Add(hist);

        //                        #endregion GuardarHistorico

        //                        //ChangeTracker.Entries<Plantillas_Hist>.Plantillas_Hist.a
        //                        entityBase.FechaModificacion = DateTime.Now;
        //                    }
        //                }
        //                else if (typeof(Plantillas_Secciones).IsAssignableFrom(entry.Entity.GetType()))
        //                {
        //                    //var entityBase = entry.Entity as Plantillas_Secciones;

        //                    //entityBase.FechaModificacion = DateTime.Now;

        //                    //Plantillas_Secciones plantSec = CreateWithValues<Plantillas_Secciones>(entry.OriginalValues);
        //                    //#region GuardarHistorico

        //                    //var hist = new Plantillas_Secciones_Hist();
        //                    //Utils.CopyPropertyValues(plantSec, hist);
        //                    //hist.FechaInicio = plantSec.FechaModificacion;
        //                    //this.Plantillas_Secciones_Hist.Add(hist);

        //                    //#endregion GuardarHistorico
        //                }
        //                else if (typeof(Plantillas_Isins).IsAssignableFrom(entry.Entity.GetType()))
        //                {
        //                    var entityBase = entry.Entity as Plantillas_Isins;

        //                    //Sólo ponemos fecha cuando se añade
        //                    if (entry.State == EntityState.Added)
        //                    {
        //                        entityBase.FechaModificacion = DateTime.Now;
        //                    }
        //                    else if (entry.State == EntityState.Deleted || entry.State == EntityState.Modified)
        //                    {
        //                        Plantillas_Isins plantSec = CreateWithValues<Plantillas_Isins>(entry.OriginalValues);
        //                        #region GuardarHistorico

        //                        var hist = new Plantillas_Isins_Hist();
        //                        Utils.CopyPropertyValues(plantSec, hist);
        //                        hist.FechaInicio = plantSec.FechaModificacion;
        //                        this.Plantillas_Isins_Hist.Add(hist);

        //                        #endregion GuardarHistorico
        //                    }
        //                }

        //            }
        //        }
        //        var changeSetHistorical = ChangeTracker.Entries<HistoricalBase>();

        //        if (changeSetHistorical != null)
        //        {
        //            foreach (var entry in changeSetHistorical.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
        //            {
        //                if (typeof(Plantillas_Hist).IsAssignableFrom(entry.Entity.GetType()))
        //                {
        //                    var entityBase = entry.Entity as Plantillas_Hist;
        //                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
        //                    {
        //                        entityBase.FechaFin = DateTime.Now;
        //                    }
        //                }
        //                else if (typeof(Plantillas_Secciones_Hist).IsAssignableFrom(entry.Entity.GetType()))
        //                {
        //                    var entityBase = entry.Entity as Plantillas_Secciones_Hist;
        //                    if (entry.State == EntityState.Added)
        //                    {
        //                        entityBase.FechaFin = DateTime.Now;
        //                    }
        //                }
        //            }
        //        }
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        // Retrieve the error messages as a list of strings.
        //        var errorMessages = ex.EntityValidationErrors
        //                .SelectMany(x => x.ValidationErrors)
        //                .Select(x => x.ErrorMessage);

        //        // Join the list to a single string.
        //        var fullErrorMessage = string.Join("; ", errorMessages);

        //        // Combine the original exception message with the new one.
        //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        //        // Throw a new DbEntityValidationException with the improved exception message.
        //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //    }
        //}
    }

    #region ResultadosProcedimientosNoReconocidosPorEF

    public class GenericProcs
    {
        public string Isin { get; set; }
    }

    public class usp_gestio_pro_01_Result
    {
        public string nom { get; set; }
        public decimal participaciones { get; set; }
        public decimal tpc { get; set; }
    }

    public class usp_gestio_pro_03_Result
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        /// <summary>
        /// No sabemos si hay algún caso en el que viene "Cotdiv" en vez de "cotdiv"
        /// </summary>
        public decimal cotdiv { get; set; }        
        public decimal coteur { get; set; }
    }

    /// <summary>
    /// PRO_03 para el caso que devuelve el tipo de cambio de una divisa con el euro
    /// </summary>
    public class usp_gestio_pro_03_TCD_Result
    {
        public decimal TipoCambio { get; set; }
    }

        public class usp_gestio_pro_07_Result
    {
        public DateTime FECHA { get; set; }
        public string TIPMOV { get; set; }
        public decimal? IMPORTE { get; set; }
    }

    public partial class usp_gestio_pro_09_Result : GenericProcs
    {
    }

    public partial class usp_gestio_pro_11_Result : GenericProcs
    {
        public string IdInstrumento { get; set; }
        public string CodInstrumento { get; set; }
        public string IdTipoInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public string IdTipoInstrumento2 { get; set; }
        public string CodTipoInstrumento2 { get; set; }
        public string IdTipoInstrumento3 { get; set; }
        public string CodTipoInstrumento3 { get; set; }
        public int? IdCategoria { get; set; }
        public string CodCategoria { get; set; }
        public int? IdEmpresa { get; set; }
        public string CodEmpresa { get; set; }
        public int? IdZona { get; set; }
        public string CodZona { get; set; }
        public bool? Emergente { get; set; }
        public string CoreTrading { get; set; }
    }

    public class usp_gestio_pro_13_Result : GenericProcs
    {
        public string Grupo { get; set; }
        /// <summary>
        /// De momento lo utilizaremos para los contrasplits. Cuando cambiemos el grupo que viene del PRO13
        /// en este campo almacenaremos el nuevo grupo que le damos
        /// </summary>
        public int? GrupoNuevo { get; set; }
        public string IdInstrumento { get; set; }
        public string CodInstrumento { get; set; }
        public string IdTipoInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public int? IdCategoria{ get; set; }
        public string CodCategoria { get; set; }
        public int? IdEmpresa { get; set; }
        public string CodEmpresa { get; set; }
        public decimal? PrecioAjustado { get; set; }
        //public string Isin { get; set; }
        public string Nombre { get; set; }
        public decimal NumTit { get; set; }
        public string Divisa { get; set; }
        public decimal? PrecioI { get; set; }
        public decimal PrecioO { get; set; }
        public decimal PrecioOA { get; set; }
        public decimal PrecioOEUR { get; set; }
        public decimal PrecioOAEUR { get; set; }
        public decimal PrecioF { get; set; }
        public decimal EfectivoFEUR { get; set; }
        public decimal PLPrecio { get; set; }
        public decimal PLDiv { get; set; }
        public decimal PLEur { get; set; }
        public decimal PLPct { get; set; }
        public decimal Dividendos { get; set; }
        public decimal EfectivoIEUR { get; set; }
        public decimal EfectivoIAEUR { get; set; }
        public decimal PrecioFEUR { get; set; }
        public DateTime? FechaO { get; set; }
        public DateTime? FechaC { get; set; }
        public string ClamovO { get; set; }
        public string TipMovO { get; set; }
        public string ClamovF { get; set; }
        public string TipMovF { get; set; }
        public string Estado { get; set; }
        public string TipoO { get; set; }

        /// <summary>
        /// Numero de la operación de apertura
        /// </summary>
        public int NumO { get; set; }
        public decimal? PrecioC { get; set; }
        public decimal? CambioF { get; set; }
        public decimal? CambioC { get; set; }
        public decimal? CambioO { get; set; }
        public decimal? CambioI { get; set; }
        public string TipoC { get; set; }

        /// <summary>
        /// Numero de la operación de cierre.
        /// </summary>
        public int? NumC { get; set; }

        /// <summary>
        /// Aquí guardamos el id del precio ajustado de movimientos que fueron agrupados y a esa agrupación se le puso un precio ajustado o se le hizo alguna modificación.
        /// </summary>
        public int? IdPrecioAjustado { get; set; }

    }

    public class usp_gestio_pro_14_Result
    {
        public DateTime FECHA { get; set; }
        public string TIPMOV { get; set; }
        public string descr { get; set; }
        public decimal? cantid { get; set; }
        public decimal? PRECIO { get; set; }
        public string Situacion { get; set; }
    }
    public class usp_gestio_pro_17_Result
    {
        public DateTime FECHA { get; set; }
        public string TIPMOV { get; set; }
        public string descr { get; set; }
        public decimal cantid { get; set; }
        public decimal PRECIO { get; set; }
        public decimal Dividendo { get; set; }
        public string Vendido { get; set; }
        public string isin { get; set; }
        public string mercado { get; set; }
        public decimal impeur { get; set; }
    }

    //public partial class usp_gestio_pro_20_Result
    //{
    //    /// <summary>
    //    /// Código subyacente
    //    /// </summary>
    //    public string b3006_cod { get; set; }

    //    /// <summary>
    //    /// Descripción subyacente
    //    /// </summary>
    //    public string b3006_nom { get; set; }
    //}

    public class usp_gestio_pro_21_Result : GenericProcs
    {
        public string Grupo { get; set; }
        public string Isin { get; set; }
        public string Nombre { get; set; }
        public decimal NumTit { get; set; }
        public string Divisa { get; set; }
        public decimal? PrecioI { get; set; }
        public decimal? CambioI { get; set; }
        public decimal PrecioO { get; set; }
        public decimal PrecioOA { get; set; }
        public decimal PrecioOEUR { get; set; }
        public decimal PrecioOAEUR { get; set; }
        public decimal PrecioF { get; set; }
        public decimal EfectivoFEUR { get; set; }
        public decimal PLPrecio { get; set; }
        public decimal PLDiv { get; set; }
        public decimal PLEur { get; set; }
        public decimal PLPct { get; set; }
        public decimal Dividendos { get; set; }
        public decimal EfectivoIEUR { get; set; }
        public decimal EfectivoIAEUR { get; set; }
        public decimal PrecioFEUR { get; set; }
        public DateTime FechaO { get; set; }
        public DateTime? FechaC { get; set; }
        public string ClamovO { get; set; }
        public string TipMovO { get; set; }
        public string ClamovF { get; set; }
        public string TipMovF { get; set; }
        public Nullable <Decimal> CambioF { get; set; }
        public Nullable<Decimal> CambioO { get; set; }

        //Añadimos los dos siguientes campos porque nos ayudan en la filtración antes de InsertTemp
        public string IdInstrumento { get; set; }
        public string CodInstrumento { get; set; }
        public string IdTipoInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public int? IdCategoria { get; set; }
        public string CodCategoria { get; set; }
        public int? IdEmpresa { get; set; }
        public string CodEmpresa { get; set; }
    }

    public class usp_gestio_pro_22_Result
    {
        /// <summary>
        /// ISIN
        /// </summary>
        public string b3001_cod { get; set; }
        public string IdInstrumento { get; set; }
        public string CodInstrumento { get; set; }
        public string IdTipoInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public int? IdCategoria { get; set; }
        public string CodCategoria { get; set; }
        public int? IdEmpresa { get; set; }
        public string CodEmpresa { get; set; }
    }
    
    //public partial class usp_gestio_pro_19_Result
    //{
    //    public decimal SalCon { get; set; }
    //    public decimal SalVal { get; set; }
    //    public decimal ApoNet { get; set; }
    //}
    #endregion ResultadosProcedimientosNoReconocidosPorEF

    #region EntitiesToTrack
    public partial class Plantilla : TrackingBase
    {
        //public A_Prueba_Temp()
        //{
        //    this.SysEndTime = DateTime.Now;
        //}   
    }
    public partial class Plantillas_Secciones : TrackingBase
    {        
    }
    public partial class Plantillas_Isins : TrackingBase
    {
    }
    #endregion EntitiesToTrack

    #region HistoricalEntities
    public partial class Plantillas_Hist : HistoricalBase
    {
        //public A_Prueba_Temp()
        //{
        //    this.SysEndTime = DateTime.Now;
        //}
    }

    public partial class Plantillas_Secciones_Hist : HistoricalBase
    {
        
    }

    public partial class Plantillas_Isins_Hist : HistoricalBase
    {

    }
    #endregion HistoricalEntities


    /// <summary>
    /// Para las tablas que almacenan histórico
    /// </summary>
    public class HistoricalBase
    {
        //public DateTime? FechaFin { get; set; }
    }

    /// <summary>
    /// Para las tablas que se va a guardar histórico
    /// </summary>
    public class TrackingBase
    {
        //public DateTime? FechaModificacion { get; set; }
    }

    #region TempTableBase
    public class TempTableBase
    {
        public string CodigoIC { get; set; }
    }

    //public class PreviewBase
    //{
    //    public bool IsVisible { get; set; }
    //    public DateTime FechaInforme { get; set; }
    //}


    /// <summary>
    /// Para el grid de Estrategias de AddEditPlantilla.xaml necesitamos el campo Descripción
    /// </summary>
    public partial class Plantillas_Estrategias
    {
        //public string Descripcion { get; set; }
    }

    public partial class Temp_Burbujas : TempTableBase { }
    public partial class Temp_CarteraCcrVolgaGamar : TempTableBase { }
    public partial class Temp_CarteraRF : TempTableBase { }


    public partial class Temp_CompraVentaPrecAdq : TempTableBase { }
    public partial class Temp_CuponesCobrados : TempTableBase {}
    public partial class Temp_DistribucionPatrimonioNovarex_Cartera : TempTableBase { }
    public partial class Temp_DistribucionPatrimonioNovarex_Tesoreria : TempTableBase { }
    public partial class Temp_Diversificacion : TempTableBase { }
    public partial class Temp_DividendosCobrados : TempTableBase { }
    public partial class Temp_EvolucionIndBench : TempTableBase { }
    public partial class Temp_EvolucionMercados : TempTableBase { }
    public partial class Temp_EvolucionPatrGuissonaIndBench : TempTableBase { }
    public partial class Temp_EvolucionPatrGuissonaRentabilidad : TempTableBase { }
    public partial class Temp_EvolucionPatrGuissonaValLiq : TempTableBase { }
    public partial class Temp_EvolucionPatrimonioConjuntoGuissona : TempTableBase { }
    //public partial class Temp_EvolucionPatrimonioConjuntoGuissona_Fondos : TempTableBase { }
    public partial class Temp_EvolucionPatrValLiq : TempTableBase { }
    public partial class Temp_EvolucionRentabilidadGuissona : TempTableBase { }
    //public partial class Temp_EvolucionRentabilidadGuissona_Fondos : TempTableBase { }
    public partial class Temp_EvolucionRentabilidadGuissona_TAE : TempTableBase { }
    public partial class Temp_GraficoExposMercDivisas : TempTableBase { }
    public partial class Temp_GraficoCompCarteraRF : TempTableBase { }
    public partial class Temp_GraficoCompCarteraRV : TempTableBase { }
    public partial class Temp_GraficoExposMercTipoActivo : TempTableBase { }
    public partial class Temp_GraficoExposMercTipoProducto : TempTableBase { }
    public partial class Temp_GraficoCompPatrimonioDivisas : TempTableBase { }
    public partial class Temp_GraficoCompPatrimonioTipoActivo : TempTableBase { }
    public partial class Temp_GraficoCompPatrimonioTipoProducto : TempTableBase { }
    public partial class Temp_GraficoIBenchmark : TempTableBase { }
    public partial class Temp_IIC_ComprasVentasEjercicio : TempTableBase { }
    public partial class Temp_IndicePreconfiguradoNovarex : TempTableBase { }
    public partial class Temp_ListadoRentaFijaNovarex : TempTableBase { }
    public partial class Temp_OperacionesRentaVariable_II : TempTableBase { }
    public partial class Temp_Participes : TempTableBase { }
    public partial class Temp_Participes_Hist : TempTableBase { }       
    public partial class Temp_PlusvaliasDividendos : TempTableBase { }    
    public partial class Temp_PRO_11 : TempTableBase { }
    public partial class Temp_PRO_12 : TempTableBase { }
    public class Temp_Prueba : TempTableBase { }
    public partial class Temp_RatiosCarteraRV : TempTableBase { }
    public partial class Temp_RentabilidadCarteraSolemeg : TempTableBase { }
    public partial class Temp_RentabilidadCarteraV1 : TempTableBase { }
    public partial class Temp_RentabilidadCarteraV2 : TempTableBase { }
    public partial class Temp_RentaFija : TempTableBase { }
    public partial class Temp_RentaVariable : TempTableBase
    {
        public string CodInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public string CodCategoria { get; set; }
        public string CodEmpresa { get; set; }
    }
    public partial class Temp_RFComprasVentasEjercicio : TempTableBase { }
    public partial class Temp_RVComprasRealizadasEjercicio : TempTableBase { }
    public partial class Temp_SuscripcionesReembolsos : TempTableBase { }
    public partial class Temp_VariacionPatrimonialA : TempTableBase { }
    public partial class Temp_VariacionPatrimonialB : TempTableBase { }
    public partial class Temp_VariacionPatrimonialA_Totales : TempTableBase { }
    public partial class Temp_DesgloseGastos : TempTableBase { }

    #endregion TempTableBase

    public partial class Preview_CompraVentaPrecAdq : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal? _efectivo;
        public decimal? Efectivo
        {
            get { return Titulos * Adquisicion * (-1); }

            protected set
            {
                _efectivo = value;
                //Efectivo = Titulos * Adquisicion * (-1);
                OnPropertyChanged("Titulos");
                OnPropertyChanged("Adquisicion");
            }
        }

        private decimal? _efectivoNew;

        public decimal? EfectivoNew
        {
            get { return TitulosNew * AdquisicionNew * (-1); }


            protected set
            {
                _efectivoNew = value;
                //EfectivoNew = TitulosNew * AdquisicionNew * (-1);
                OnPropertyChanged("TitulosNew");
                OnPropertyChanged("AdquisicionNew");
            }
        }

        //public decimal? Efectivo
        //{
        //    get { return  Titulos * Adquisicion * (-1); }

        //    protected set
        //    {
        //        Efectivo = Titulos * Adquisicion * (-1);
        //        this.OnPropertyChanged("Titulos");
        //        this.OnPropertyChanged("Adquisicion");
        //    }
        //}
        //public decimal? EfectivoNew
        //{
        //    get { return TitulosNew * AdquisicionNew * (-1); }

        //    protected set
        //    {
        //        EfectivoNew = TitulosNew * AdquisicionNew * (-1);
        //        this.OnPropertyChanged("TitulosNew");
        //        this.OnPropertyChanged("AdquisicionNew");
        //    }
        //}

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Temp_CompraVentaPrecAdq : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal? _efectivo;
        public decimal? Efectivo
        {
            get { return Titulos * Adquisicion * (-1); }

            protected set
            {
                _efectivo = value;
                //Efectivo = Titulos * Adquisicion * (-1);
                OnPropertyChanged("Titulos");
                OnPropertyChanged("Adquisicion");
            }
        }

        private decimal? _efectivoNew;

        public decimal? EfectivoNew
        {
            get { return TitulosNew * AdquisicionNew * (-1); }


            protected set
            {
                _efectivoNew = value;
                //EfectivoNew = TitulosNew * AdquisicionNew * (-1);
                OnPropertyChanged("TitulosNew");
                OnPropertyChanged("AdquisicionNew");
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Preview_RentaFija : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public Nullable<decimal> BoPPrecio
        //{
        //    get
        //    {
        //        if (BoPDivisa != null && BoPPrecio != null)
        //            return BoPDivisa + BoPPrecio;
        //        else
        //            return PosicionCartera + PosicionesCerradas;
        //    }

        //    protected set
        //    {
        //        if (BoPDivisa != null && BoPPrecio != null)
        //            BoPTotal = BoPDivisa + BoPPrecio;
        //        else
        //            BoPTotal = PosicionCartera + PosicionesCerradas;

        //        this.OnPropertyChanged("BoPDivisa");
        //        this.OnPropertyChanged("BoPPrecio");
        //        this.OnPropertyChanged("PosicionCartera");
        //        this.OnPropertyChanged("PosicionesCerradas");
        //    }
        //}

        //public Nullable<decimal> BoPPrecioNew
        //{
        //    get
        //    {
        //        if (BoPDivisaNew != null && BoPPrecioNew != null)
        //            return BoPDivisaNew + BoPPrecioNew;
        //        else
        //            return PosicionCarteraNew + PosicionesCerradasNew;
        //    }

        //    protected set
        //    {
        //        if (BoPDivisaNew != null && BoPPrecioNew != null)
        //            BoPTotalNew = BoPDivisaNew + BoPPrecioNew;
        //        else
        //            BoPTotalNew = PosicionCarteraNew + PosicionesCerradasNew;

        //        this.OnPropertyChanged("BoPDivisaNew");
        //        this.OnPropertyChanged("BoPPrecioNew");
        //        this.OnPropertyChanged("PosicionCarteraNew");
        //        this.OnPropertyChanged("PosicionesCerradasNew");
        //    }
        //}

        public decimal? BoPTotal
        {
            get
            {
                return EfectivoFin - EfectivoIni;
            }

            protected set
            {
                BoPPrecio = EfectivoFin - EfectivoIni;

                OnPropertyChanged("EfectivoIni");
                OnPropertyChanged("EfectivoFin");
                OnPropertyChanged("PosicionCartera");
            }
            
        }

        public decimal? BoPTotalNew
        {
            get
            {
                return EfectivoFinNew - EfectivoIniNew;
            }

            protected set
            {
                BoPPrecioNew = EfectivoFinNew - EfectivoIniNew;

                OnPropertyChanged("EfectivoIniNew");
                OnPropertyChanged("EfectivoFinNew");
                OnPropertyChanged("PosicionCarteraNew");
            }
            
        }

        public decimal? BoPTotalPorcentajeNew
        {
            get
            {
                return Utils.GetVariacion(EfectivoIniNew, EfectivoFinNew);
            }

            protected set
            {
                Utils.GetVariacion(EfectivoIniNew, EfectivoFinNew);

                OnPropertyChanged("EfectivoIniNew");
                OnPropertyChanged("EfectivoFinNew");
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Temp_RentaFija : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public Nullable<decimal> BoPPrecio
        //{
        //    get
        //    {
        //        if (BoPDivisa != null && BoPPrecio != null)
        //            return BoPDivisa + BoPPrecio;
        //        else
        //            return PosicionCartera + PosicionesCerradas;
        //    }

        //    protected set
        //    {
        //        if (BoPDivisa != null && BoPPrecio != null)
        //            BoPTotal = BoPDivisa + BoPPrecio;
        //        else
        //            BoPTotal = PosicionCartera + PosicionesCerradas;

        //        this.OnPropertyChanged("BoPDivisa");
        //        this.OnPropertyChanged("BoPPrecio");
        //        this.OnPropertyChanged("PosicionCartera");
        //        this.OnPropertyChanged("PosicionesCerradas");
        //    }
        //}

        //public Nullable<decimal> BoPPrecioNew
        //{
        //    get
        //    {
        //        //if (BoPDivisaNew != null && BoPPrecioNew != null)
        //        if (GrupoNew != null)
        //        {
        //            if ((new List<int>() { 1, 2, 3, 4, 5 }).Contains((int)GrupoNew))
        //                return BoPDivisaNew + BoPPrecioNew;
        //            else
        //                return PosicionCarteraNew + PosicionesCerradasNew;
        //        }
        //        else
        //            return null;
        //    }

        //    protected set
        //    {
        //        if (BoPDivisaNew != null && BoPPrecioNew != null)
        //            BoPTotalNew = BoPDivisaNew + BoPPrecioNew;
        //        else
        //            BoPTotalNew = PosicionCarteraNew + PosicionesCerradasNew;

        //        this.OnPropertyChanged("BoPDivisaNew");
        //        this.OnPropertyChanged("BoPPrecioNew");
        //        this.OnPropertyChanged("PosicionCarteraNew");
        //        this.OnPropertyChanged("PosicionesCerradasNew");
        //    }
        //}

        //public Nullable<decimal> BoPTotal
        //{
        //    get
        //    {
        //        return EfectivoFin - EfectivoIni;
        //    }

        //    protected set
        //    {
        //        BoPTotal = EfectivoFin - EfectivoIni;

        //        this.OnPropertyChanged("EfectivoIni");
        //        this.OnPropertyChanged("EfectivoFin");
        //    }
            
        //}

        //public Nullable<decimal> BoPTotalNew
        //{
        //    get
        //    {
        //        return EfectivoFinNew - EfectivoIniNew;
        //    }

        //    protected set
        //    {
        //        BoPTotalNew = EfectivoFinNew - EfectivoIniNew;

        //        this.OnPropertyChanged("EfectivoIniNew");
        //        this.OnPropertyChanged("EfectivoFinNew");
        //    }
            
        //}

        public decimal? BoPTotalPorcentajeNew
        {
            get
            {
                return Utils.GetVariacion(EfectivoIniNew, EfectivoFinNew);
            }

            protected set
            {
                Utils.GetVariacion(EfectivoIniNew, EfectivoFinNew);

                OnPropertyChanged("EfectivoIniNew");
                OnPropertyChanged("EfectivoFinNew");
            }
        }


        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
    #region entidades serializables
    /*[Serializable]
    partial class Indices_Referencia_Tipos { }
    [Serializable]
    partial class Plantilla { }    

    [Serializable]
    partial class Plantillas_Generaciones { }

    [Serializable]
    partial class Tipos { }

    [Serializable]
    partial class Plantillas_Indices_Referencia { }
    

    [Serializable]
    partial class Plantillas_Isins { }

    [Serializable]
    partial class Plantillas_Participes { }

    [Serializable]
    partial class Plantillas_Secciones { }

    [Serializable]
    partial class Seccione { }

    [Serializable]
    partial class TrackingBase { }

    //[Serializable]
    //partial class Plantillas_Participes { }

    //[Serializable]
    //partial class Plantillas_Participes { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CompraVentaPrecAdq { }

    [Serializable]
    partial class Parametros_DistribucionPatrimonioNovarex { }

    [Serializable]
    partial class Parametros_DistribucionPatrimonioNovarex_Tipos { }

    [Serializable]
    partial class Parametros_Diversificacion { }

    [Serializable]
    partial class Parametros_Diversificacion_Instrumentos { }

    [Serializable]
    partial class Parametros_Diversificacion_Instrumentos_Divisas { }

    [Serializable]
    partial class Parametros_DividendosCobrados { }

    [Serializable]
    partial class Parametros_EvolucionMercados { }

    [Serializable]
    partial class Parametros_EvolucionPatrimGuissona { }

    [Serializable]
    partial class Parametros_EvolucionPatrimonioConjuntoGuissona { }

    [Serializable]
    partial class Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos { }

    [Serializable]
    partial class Parametros_EvolucionRentabilidadGuissona { }

    [Serializable]
    partial class Parametros_EvolucionRentabilidadGuissona_Fondos { }

    [Serializable]
    partial class Parametros_GraficoBenchmark { }

    [Serializable]
    partial class Parametros_GraficoBenchmark_Indices { }

    [Serializable]
    partial class Parametros_GraficoCompPatrimonioTipoProducto { }

    [Serializable]
    partial class Parametros_IIC_ComprasVentasEjercicio { }

    [Serializable]
    partial class Parametros_IndicePreconfiguradoNovarex { }

    [Serializable]
    partial class Parametros_IndicePreconfiguradoNovarex_Otros { }

    [Serializable]
    partial class Parametros_OperacionesRentaVariable_II { }

    [Serializable]
    partial class Parametros_Participes { }

    [Serializable]
    partial class Parametros_ParticipesSalat { }

    [Serializable]
    partial class Parametros_ParticipesSalat_Participes { }

    [Serializable]
    partial class Parametros_PlusvaliasDividendos { }

    [Serializable]
    partial class Parametros_PlusvaliasDividendos_ISINS { }

    [Serializable]
    partial class Parametros_RatiosCarteraRV { }

    [Serializable]
    partial class Parametros_Rentabilidad_CarteraII { }

    [Serializable]
    partial class Parametros_RFComprasVentasEjercicio { }

    [Serializable]
    partial class Parametros_RVComprasRealizadasEjercicio { }

    [Serializable]
    partial class Parametros_VariacionPatrimonialB { }

    [Serializable]
    partial class ParamPredet_EvolucionMercados { }
    
    [Serializable]
    partial class Parametros_RVComprasRealizadasEjercicio { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }

    [Serializable]
    partial class Parametros_CarteraRF { }
    */
    #endregion

}
