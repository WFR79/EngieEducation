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
    
    public partial class Education_AgentCertificatDivers
    {
        public long AgentCertificatDivers_Id { get; set; }
        public Nullable<long> AgentCertificatDivers_Agent { get; set; }
        public Nullable<System.DateTime> AgentCertificatDivers_SendingDate { get; set; }
        public Nullable<System.DateTime> AgentCertificatDivers_ReturnDate { get; set; }
        public Nullable<System.DateTime> AgentCertificatDivers_ValidityDate { get; set; }
        public Nullable<bool> AgentCertificatDivers_IsCertified { get; set; }
        public string AgentCertificatDivers_Remarks { get; set; }
        public Nullable<long> AgentCertificatDivers_Certificate { get; set; }
    
        public virtual Education_Agent Education_Agent { get; set; }
        public virtual Education_CertificatDivers Education_CertificatDivers { get; set; }
    }
}
