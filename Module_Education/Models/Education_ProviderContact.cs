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
    
    public partial class Education_ProviderContact
    {
        public long ProviderContact_Id { get; set; }
        public string ProviderContact_FullName { get; set; }
        public string ProviderContact_Tel { get; set; }
        public string ProviderContact_Email { get; set; }
        public Nullable<long> ProviderContact_Provider { get; set; }
    
        public virtual Education_Provider Education_Provider { get; set; }
    }
}