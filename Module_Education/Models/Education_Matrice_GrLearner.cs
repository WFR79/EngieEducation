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
    
    public partial class Education_Matrice_GrLearner
    {
        public long MatriceGrLearner_Id { get; set; }
        public Nullable<long> MatriceGrLearner_Matrice { get; set; }
        public Nullable<long> MatriceGrLearner_GroupeLearner { get; set; }
        public Nullable<int> MatriceGrLearner_Recurrency { get; set; }
        public Nullable<bool> MatriceGrLearner_Actif { get; set; }
    
        public virtual Education_GroupLearner Education_GroupLearner { get; set; }
        public virtual Education_Matrice Education_Matrice { get; set; }
    }
}
