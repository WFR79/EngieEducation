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
    
    public partial class Education_GroupLearner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education_GroupLearner()
        {
            this.Education_GroupLearner_Agent = new HashSet<Education_GroupLearner_Agent>();
            this.Education_Matrice_GrLearner = new HashSet<Education_Matrice_GrLearner>();
        }
    
        public long GroupLearner_Id { get; set; }
        public string GroupLearner_Name { get; set; }
        public string GroupLearner_SAP { get; set; }
        public Nullable<bool> GroupLearner_Actif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_GroupLearner_Agent> Education_GroupLearner_Agent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Matrice_GrLearner> Education_Matrice_GrLearner { get; set; }
    }
}
