using Module_ADR.DataAccessLayer.Repos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    class MesureAndParadeRepository : RepositoryBase, IRepository<int, ADR_Criticality_MesureParade>
    {

        public IEnumerable<ADR_Criticality_MesureParade> Get()
        {
            return Db.ADR_Criticality_MesureParade.ToList();
        }

        public IEnumerable<ADR_Criticality_MesureParade> GetById(int Id)
        {
            return Db.ADR_Criticality_MesureParade.Where((mp) => mp.CriticalityRiskId == Id).ToList();
        }

        public ADR_Criticality_MesureParade Get(int ID)
        {
            return Db.ADR_Criticality_MesureParade.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_Criticality_MesureParade Get(string ItemText, int RiskId)
        {
            return Db.ADR_Criticality_MesureParade.Where((ap) => ap.ItemText == ItemText && ap.CriticalityRiskId == RiskId).FirstOrDefault();
        }

        public bool Insert(ADR_Criticality_MesureParade Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public int InsertAndReturnId(ADR_Criticality_MesureParade Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Entity.Id;
        }

        public bool Update(ADR_Criticality_MesureParade Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Criticality_MesureParade Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }
    }
}
