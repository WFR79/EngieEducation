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
    
    public partial class Education_MovementStepAgent
    {
        public long MovementStepAgent_Id { get; set; }
        public Nullable<long> MovementStepAgent_Step { get; set; }
        public Nullable<long> MovementStepAgent_Status { get; set; }
        public Nullable<long> MovementStepAgent_MovementAgent { get; set; }
    
        public virtual Education_MovementAgent Education_MovementAgent { get; set; }
        public virtual Education_MovementStatusStep Education_MovementStatusStep { get; set; }
        public virtual Education_MovementStep Education_MovementStep { get; set; }
    }
}
