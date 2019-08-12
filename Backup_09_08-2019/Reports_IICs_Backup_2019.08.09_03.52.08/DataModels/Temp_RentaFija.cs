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
    using System.Collections.Generic;
    
    public partial class Temp_RentaFija
    {
        public int Id { get; set; }
        public string CodigoIC { get; set; }
        public string Isin { get; set; }
        public string IsinNew { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionNew { get; set; }
        public Nullable<int> Grupo { get; set; }
        public Nullable<int> GrupoNew { get; set; }
        public decimal NumTit { get; set; }
        public decimal NumTitNew { get; set; }
        public Nullable<decimal> EfectivoIni { get; set; }
        public Nullable<decimal> EfectivoIniNew { get; set; }
        public Nullable<decimal> EfectivoFin { get; set; }
        public Nullable<decimal> EfectivoFinNew { get; set; }
        public Nullable<decimal> PrecioCompra { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public string IdInstrumento { get; set; }
        public string IdTipoInstrumento { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string CodInstrumento { get; set; }
        public string CodTipoInstrumento { get; set; }
        public Nullable<decimal> BoPDivisa { get; set; }
        public Nullable<decimal> BoPDivisaNew { get; set; }
        public Nullable<decimal> BoPPrecio { get; set; }
        public Nullable<decimal> BoPPrecioNew { get; set; }
        public Nullable<decimal> BoPTotal { get; set; }
        public Nullable<decimal> BoPTotalPorcentaje { get; set; }
        public Nullable<System.DateTime> FechaCompra { get; set; }
        public Nullable<System.DateTime> FechaVenta { get; set; }
        public Nullable<decimal> PosicionCartera { get; set; }
        public Nullable<decimal> PosicionCarteraNew { get; set; }
        public Nullable<decimal> PosicionesCerradas { get; set; }
        public Nullable<decimal> PosicionesCerradasNew { get; set; }
        public string CodigoSubyacente { get; set; }
        public string Comentario { get; set; }
        public bool Added { get; set; }
        public bool IsVisible { get; set; }
    
        public virtual Instrumento Instrumento { get; set; }
        public virtual Instrumentos_Categorias Instrumentos_Categorias { get; set; }
        public virtual Instrumentos_Empresas Instrumentos_Empresas { get; set; }
        public virtual Instrumentos_Tipos Instrumentos_Tipos { get; set; }
        public virtual Plantilla Plantilla { get; set; }
    }
}
