//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_ADR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADR_Analysis_Template
    {
        public int Id { get; set; }
        public int CriticalityId1 { get; set; }
        public int CriticalityId2 { get; set; }
        public int CriticalityId3 { get; set; }
        public int CriticalityId4 { get; set; }
        public int CriticalityId5 { get; set; }
        public int CriticalityId6 { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ADR_Criticality ADR_Criticality { get; set; }
        public virtual ADR_Criticality ADR_Criticality1 { get; set; }
        public virtual ADR_Criticality ADR_Criticality2 { get; set; }
        public virtual ADR_Criticality ADR_Criticality3 { get; set; }
        public virtual ADR_Criticality ADR_Criticality4 { get; set; }
        public virtual ADR_Criticality ADR_Criticality5 { get; set; }
    }
}
