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
    
    public partial class Get_Temp_DividendosCobrados_Result
    {
        public int Id { get; set; }
        public string CodigoIC { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string NombreValor { get; set; }
        public Nullable<decimal> ImporteBruto { get; set; }
        public Nullable<decimal> ImporteNeto { get; set; }
        public Nullable<bool> PAINTLINE { get; set; }
    }
}
