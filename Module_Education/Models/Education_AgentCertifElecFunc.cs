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
    
    public partial class Education_AgentCertifElecFunc
    {
        public long AgentCertifElecFunc_Id { get; set; }
        public Nullable<System.DateTime> AgentCertifElecFunc_SendingDate { get; set; }
        public Nullable<System.DateTime> AgentCertifElecFunc_ReceivedDate { get; set; }
        public Nullable<bool> AgentCertifElecFunc_IsCertified { get; set; }
        public Nullable<System.DateTime> AgentCertifElecFunc_ValidityDate { get; set; }
        public string AgentCertifElecFunc_Remark { get; set; }
        public Nullable<long> AgentCertifElecFunc_Agent { get; set; }
        public Nullable<long> AgentCertifElecFunc_Certification { get; set; }
    
        public virtual Education_Agent Education_Agent { get; set; }
        public virtual Education_CertifElecFunc Education_CertifElecFunc { get; set; }
    }
}
