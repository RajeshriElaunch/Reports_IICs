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
    
    public partial class Plantillas_Secciones
    {
        public int Id { get; set; }
        public string CodigoIc { get; set; }
        public int IdSeccion { get; set; }
        public Nullable<int> Orden { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual Plantilla Plantilla { get; set; }
        public virtual Seccione Seccione { get; set; }
    }
}
