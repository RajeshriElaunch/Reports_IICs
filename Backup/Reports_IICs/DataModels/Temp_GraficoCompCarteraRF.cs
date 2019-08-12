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
    
    public partial class Temp_GraficoCompCarteraRF
    {
        public int Id { get; set; }
        public string CodigoIC { get; set; }
        public string Isin { get; set; }
        public string Mercado { get; set; }
        public string Tipo { get; set; }
        public string DescripcionValor { get; set; }
        public decimal Patrimonio { get; set; }
        public Nullable<decimal> PrecioCosteEuros { get; set; }
        public Nullable<decimal> PrecioCosteEnDivisa { get; set; }
        public string Divisa { get; set; }
        public string Pais { get; set; }
        public string Empresa { get; set; }
        public string Categoria { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Sector { get; set; }
        public string Vencimiento { get; set; }
        public string Rating { get; set; }
    
        public virtual Plantilla Plantilla { get; set; }
    }
}
