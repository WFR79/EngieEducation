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
    
    public partial class Education_Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Education_Agent()
        {
            this.Education_Agent_Formation = new HashSet<Education_Agent_Formation>();
            this.Education_GroupLearner_Agent = new HashSet<Education_GroupLearner_Agent>();
            this.Education_Matrice_Agent = new HashSet<Education_Matrice_Agent>();
            this.Education_MovementAgent = new HashSet<Education_MovementAgent>();
            this.Education_MovementAgent1 = new HashSet<Education_MovementAgent>();
            this.Education_Agent1 = new HashSet<Education_Agent>();
        }
    
        public long Agent_Id { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_FirstName { get; set; }
        public string Agent_FullName { get; set; }
        public Nullable<int> Agent_Matricule { get; set; }
        public Nullable<bool> Agent_Etat { get; set; }
        public Nullable<System.DateTime> Agent_DateOfEntry { get; set; }
        public Nullable<System.DateTime> Agent_DateSeniority { get; set; }
        public Nullable<long> Agent_Habilitation { get; set; }
        public Nullable<System.DateTime> Agent_DateFunction { get; set; }
        public Nullable<bool> Agent_IsWorksManager { get; set; }
        public Nullable<long> Agent_RoleAstreinte { get; set; }
        public Nullable<long> Agent_Status { get; set; }
        public string Agent_Remarks { get; set; }
        public Nullable<long> Agent_Affectation { get; set; }
        public Nullable<long> Agent_Function { get; set; }
        public Nullable<long> Agent_LineManager { get; set; }
        public Nullable<long> Agent_RoleEPI { get; set; }
        public Nullable<bool> Agent_IsRescueWorker { get; set; }
        public string Agent_UserID { get; set; }
        public string Agent_Res10 { get; set; }
        public Nullable<int> Agent_NiveauPS { get; set; }
        public string Agent_Admin { get; set; }
        public Nullable<long> Agent_Role { get; set; }
    
        public virtual Education_RoleEPI Education_RoleEPI { get; set; }
        public virtual Education_AgentStatus Education_AgentStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Agent_Formation> Education_Agent_Formation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_GroupLearner_Agent> Education_GroupLearner_Agent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Matrice_Agent> Education_Matrice_Agent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_MovementAgent> Education_MovementAgent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_MovementAgent> Education_MovementAgent1 { get; set; }
        public virtual Education_Equipe Education_Equipe { get; set; }
        public virtual Education_Function Education_Function { get; set; }
        public virtual Education_Habilitation Education_Habilitation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education_Agent> Education_Agent1 { get; set; }
        public virtual Education_Agent Education_Agent2 { get; set; }
        public virtual Education_Role Education_Role { get; set; }
        public virtual Education_RoleAstreinte Education_RoleAstreinte { get; set; }
    }
}
