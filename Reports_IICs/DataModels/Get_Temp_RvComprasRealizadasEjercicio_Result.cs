//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reports_IICs.DataModels
{
    using System;
    
    public partial class Get_Temp_RvComprasRealizadasEjercicio_Result
    {
        public int Id { get; set; }
        public string CodigoIC { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public string DescripcionValor { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> DividendosCobrados { get; set; }
        public Nullable<decimal> CotizacionFechaFin { get; set; }
        public Nullable<bool> PAINTLINE { get; set; }
        public Nullable<decimal> VariacionDesdeCompra { get; set; }
    }
}
