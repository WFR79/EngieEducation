//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_Education.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education_MovementAgent
    {
        public long MovementAgent_Id { get; set; }
        public Nullable<long> MovementAgent_Type { get; set; }
        public Nullable<long> MovementAgent_Agent { get; set; }
        public string MovementAgent_Admin { get; set; }
        public Nullable<long> MovementAgent_ServiceActual { get; set; }
        public Nullable<long> MovementAgent_ServiceFutur { get; set; }
        public string MovementAgent_LHActual { get; set; }
        public string MovementAgent_LHFutur { get; set; }
        public string MovementAgent_TCAction { get; set; }
        public string MovementAgent_AdminOPP { get; set; }
        public Nullable<System.DateTime> MovementAgent_Date { get; set; }
        public Nullable<int> MovementAgent_Statut { get; set; }
    
        public virtual Education_Agent Education_Agent { get; set; }
        public virtual Education_MovementType Education_MovementType { get; set; }
        public virtual Education_Service Education_Service { get; set; }
        public virtual Education_Service Education_Service1 { get; set; }
    }
}
