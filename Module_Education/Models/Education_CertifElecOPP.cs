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
    
    public partial class Education_CertifElecOPP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education_CertifElecOPP()
        {
            this.Education_AgentCertifElecOPP = new HashSet<Education_AgentCertifElecOPP>();
        }
    
        public long CertifElecOPP_Id { get; set; }
        public string CertifElecOPP_LevelR { get; set; }
        public Nullable<bool> CertifElecOPP_Actif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_AgentCertifElecOPP> Education_AgentCertifElecOPP { get; set; }
    }
}
