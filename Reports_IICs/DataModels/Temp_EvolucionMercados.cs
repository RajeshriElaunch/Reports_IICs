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
    
    public partial class Temp_EvolucionMercados
    {
        public int Id { get; set; }
        public string CodigoIC { get; set; }
        public string Isin { get; set; }
        public string Descripcion { get; set; }
        public decimal CotizaDivDesde { get; set; }
        public decimal CotizaDivHasta { get; set; }
        public decimal VarCotizaDivisa { get; set; }
        public Nullable<decimal> VarCotizaEuros { get; set; }
        public System.DateTime FechaCotizacionDesde { get; set; }
        public System.DateTime FechaCotizacionHasta { get; set; }
    
        public virtual Plantilla Plantilla { get; set; }
    }
}
