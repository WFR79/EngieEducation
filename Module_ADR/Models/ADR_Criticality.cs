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
    
    public partial class ADR_Criticality
    {
        public ADR_Criticality()
        {
            this.ADR_Analysis_Parameters = new HashSet<ADR_Analysis_Parameters>();
            this.ADR_Analysis_Template = new HashSet<ADR_Analysis_Template>();
            this.ADR_Analysis_Template1 = new HashSet<ADR_Analysis_Template>();
            this.ADR_Analysis_Template2 = new HashSet<ADR_Analysis_Template>();
            this.ADR_Analysis_Template3 = new HashSet<ADR_Analysis_Template>();
            this.ADR_Analysis_Template4 = new HashSet<ADR_Analysis_Template>();
            this.ADR_Analysis_Template5 = new HashSet<ADR_Analysis_Template>();
        }
    
        public int Id { get; set; }
        public string ItemText { get; set; }
        public int CriticalityHelperId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreateBy { get; set; }
        public bool IsDisabled { get; set; }
    
        public virtual ICollection<ADR_Analysis_Parameters> ADR_Analysis_Parameters { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template1 { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template2 { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template3 { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template4 { get; set; }
        public virtual ICollection<ADR_Analysis_Template> ADR_Analysis_Template5 { get; set; }
        public virtual ADR_Criticality_Helper ADR_Criticality_Helper { get; set; }
    }
}
