﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_ADR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ADREntities : DbContext
    {
        public ADREntities()
            : base("name=ADREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ADR_Analysis_Parameters> ADR_Analysis_Parameters { get; set; }
        public DbSet<ADR_Analysis_Result> ADR_Analysis_Result { get; set; }
        public DbSet<ADR_Analysis_Template> ADR_Analysis_Template { get; set; }
        public DbSet<ADR_Criticality> ADR_Criticality { get; set; }
        public DbSet<ADR_Criticality_Helper> ADR_Criticality_Helper { get; set; }
        public DbSet<ADR_WorkCenter> ADR_WorkCenter { get; set; }
        public DbSet<ADR_WorkCenterUser> ADR_WorkCenterUser { get; set; }
        public DbSet<ADR_Criticality_Helper_Parameters> ADR_Criticality_Helper_Parameters { get; set; }
        public DbSet<ADR_Criticality_MesureParade> ADR_Criticality_MesureParade { get; set; }
        public DbSet<ADR_SAPOrders> ADR_SAPOrders { get; set; }
        public DbSet<ADR_Historique> ADR_Historique { get; set; }
        public DbSet<ADR_Parameter> ADR_Parameter { get; set; }
    }
}