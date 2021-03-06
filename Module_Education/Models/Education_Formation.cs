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
    
    public partial class Education_Formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education_Formation()
        {
            this.Education_Agent_Formation = new HashSet<Education_Agent_Formation>();
            this.Education_CategorieFormation = new HashSet<Education_CategorieFormation>();
            this.Education_FormationDossier = new HashSet<Education_FormationDossier>();
            this.Education_FormationProvider = new HashSet<Education_FormationProvider>();
            this.Education_FormationResultat = new HashSet<Education_FormationResultat>();
            this.Education_FormationSession = new HashSet<Education_FormationSession>();
            this.Education_Matrice_Formation = new HashSet<Education_Matrice_Formation>();
        }
    
        public long Formation_Id { get; set; }
        public string Formation_SAP { get; set; }
        public Nullable<int> Formation_OldPrimaryKey { get; set; }
        public string Formation_ShortTitle { get; set; }
        public string Formation_LongTitle { get; set; }
        public Nullable<int> Formation_YearOfCreation { get; set; }
        public Nullable<double> Formation_DurationInDays { get; set; }
        public Nullable<int> Formation_MinCapacity { get; set; }
        public Nullable<int> Formation_MaxCapacity { get; set; }
        public Nullable<int> Formation_OptimalCapacity { get; set; }
        public Nullable<bool> Formation_IsInterne { get; set; }
        public Nullable<double> Formation_Price { get; set; }
        public Nullable<System.DateTime> Formation_DemandeDeDates { get; set; }
        public Nullable<bool> Formation_AnnualOrders { get; set; }
        public Nullable<bool> Formation_Actif { get; set; }
        public string Formation_Remarks { get; set; }
        public Nullable<long> Formation_Competence { get; set; }
        public Nullable<long> Formation_UnitePrice { get; set; }
        public Nullable<long> Formation_Category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Agent_Formation> Education_Agent_Formation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_CategorieFormation> Education_CategorieFormation { get; set; }
        public virtual Education_Competence Education_Competence { get; set; }
        public virtual Education_FormationCategory Education_FormationCategory { get; set; }
        public virtual Education_UnitePrice Education_UnitePrice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_FormationDossier> Education_FormationDossier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_FormationProvider> Education_FormationProvider { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_FormationResultat> Education_FormationResultat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_FormationSession> Education_FormationSession { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Matrice_Formation> Education_Matrice_Formation { get; set; }
    }
}
