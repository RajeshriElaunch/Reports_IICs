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
    
    public partial class Get_Temp_ParticipesSalat_Periodos_FIRST_Result
    {
        public int Id { get; set; }
        public int IdTempParticipeSalat { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaSaldo { get; set; }
        public int Id1 { get; set; }
        public int IdParticipesSalatPeriodo { get; set; }
        public string Titular { get; set; }
        public Nullable<decimal> ImporteInvertido { get; set; }
        public decimal Valor { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public decimal Resultado { get; set; }
        public Nullable<decimal> ValorMasEfectPeriodoAnt { get; set; }
    }
}
