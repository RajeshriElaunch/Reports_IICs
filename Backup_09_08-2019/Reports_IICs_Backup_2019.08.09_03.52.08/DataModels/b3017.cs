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
    
    public partial class b3017
    {
        public string b3001_cod { get; set; }
        public string b3006_cod { get; set; }
        public decimal b3017_strike { get; set; }
        public System.DateTime b3017_datvto { get; set; }
        public string b3017_tipdev { get; set; }
        public string b3017_modeje { get; set; }
        public decimal b3017_multip { get; set; }
        public decimal b3017_tick { get; set; }
        public string b3017_forent { get; set; }
        public System.DateTime b3017_datliq { get; set; }
        public Nullable<System.DateTime> b3017_uldneg { get; set; }
        public string b3022_sp { get; set; }
        public string b3022_moodys { get; set; }
        public string b3022_fitibc { get; set; }
        public decimal b3017_prodef { get; set; }
        public string b3017_pagreu { get; set; }
        public string b3001_codrcg { get; set; }
        public string b3009_codrcg { get; set; }
        public string b3001_codrcv { get; set; }
        public string b3009_codrcv { get; set; }
        public Nullable<System.DateTime> b3017_datave { get; set; }
        public string b3006_subssb { get; set; }
        public string b3001_codnoc { get; set; }
        public Nullable<System.DateTime> b3017_vtonoc { get; set; }
        public string m1008_codcre { get; set; }
        public Nullable<System.DateTime> b3017_datcre { get; set; }
        public string b3017_horcre { get; set; }
        public string m1008_codmod { get; set; }
        public Nullable<System.DateTime> b3017_datmod { get; set; }
        public string b3017_hormod { get; set; }
        public Nullable<int> PROGRESS_RECID { get; set; }
        public int PROGRESS_RECID_IDENT_ { get; set; }
        public string m1015_cod { get; set; }
        public string b3006_tipsub { get; set; }
        public string b3006_tipsubssb { get; set; }
        public string b3052_cod { get; set; }
        public string b3052_codgar { get; set; }
        public string b3017_liquid { get; set; }
        public System.Guid msrepl_tran_version { get; set; }
    
        public virtual b3001 b3001 { get; set; }
        public virtual b3006 b3006 { get; set; }
    }
}
