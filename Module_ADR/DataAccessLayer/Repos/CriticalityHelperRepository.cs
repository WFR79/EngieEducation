using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class CriticalityHelperRepository : RepositoryBase, IRepository<int, ADR_Criticality_Helper>
    {
        public IEnumerable<ADR_Criticality_Helper> Get()
        {
            return Db.ADR_Criticality_Helper.ToList();
        }

        public ADR_Criticality_Helper Get(int ID)
        {
            return Db.ADR_Criticality_Helper.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public bool Insert(ADR_Criticality_Helper Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Criticality_Helper Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Criticality_Helper Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
