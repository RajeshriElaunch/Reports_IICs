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
    
    public partial class b5040
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public b5040()
        {
            this.b5042 = new HashSet<b5042>();
        }
    
        public int b3050_cod { get; set; }
        public int b5040_num { get; set; }
        public int b5040_codsus { get; set; }
        public System.DateTime b5040_datape { get; set; }
        public Nullable<System.DateTime> b5040_datcan { get; set; }
        public string b1001_cod { get; set; }
        public Nullable<int> b1003_num { get; set; }
        public string b1001_liscdt { get; set; }
        public string m1008_codcre { get; set; }
        public Nullable<System.DateTime> b5040_datcre { get; set; }
        public string b5040_horcre { get; set; }
        public string m1008_codmod { get; set; }
        public Nullable<System.DateTime> b5040_datmod { get; set; }
        public string b5040_hormod { get; set; }
        public Nullable<int> PROGRESS_RECID { get; set; }
        public int PROGRESS_RECID_IDENT_ { get; set; }
        public string m1015_cod { get; set; }
        public Nullable<int> m1006_cod { get; set; }
        public string b2001_cod { get; set; }
        public string b2050_cod { get; set; }
        public string b5040_indinv { get; set; }
        public Nullable<int> b1003_numema { get; set; }
        public string b5040_tipinv { get; set; }
    
        public virtual b2001 b2001 { get; set; }
        public virtual b5040 b50401 { get; set; }
        public virtual b5040 b50402 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<b5042> b5042 { get; set; }
    }
}
