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
    
    public partial class Education_SousService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education_SousService()
        {
            this.Education_Agent = new HashSet<Education_Agent>();
        }
    
        public long SousService_Id { get; set; }
        public string SousService_Name { get; set; }
        public Nullable<long> SousService_Departement { get; set; }
        public Nullable<long> SousService_Service { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Agent> Education_Agent { get; set; }
        public virtual Education_Departement Education_Departement { get; set; }
        public virtual Education_Service Education_Service { get; set; }
    }
}
