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
    
    public partial class ADR_WorkCenter
    {
        public ADR_WorkCenter()
        {
            this.ADR_WorkCenterUser = new HashSet<ADR_WorkCenterUser>();
            this.ADR_Criticality_MesureParade = new HashSet<ADR_Criticality_MesureParade>();
        }
    
        public int Id { get; set; }
        public string WorkCenter { get; set; }
        public bool IsDisabled { get; set; }
    
        public virtual ICollection<ADR_WorkCenterUser> ADR_WorkCenterUser { get; set; }
        public virtual ICollection<ADR_Criticality_MesureParade> ADR_Criticality_MesureParade { get; set; }
    }
}
