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
    
    public partial class Temp_EvolucionPatrGuissonaValLiq
    {
        public int Id { get; set; }
        public string CodigoIc { get; set; }
        public string Isin { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> PatrimonioGestionado { get; set; }
        public Nullable<decimal> ValorLiquidativo { get; set; }
    
        public virtual Plantilla Plantilla { get; set; }
    }
}
