using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class CriticalityRepository : RepositoryBase, IRepository<int, ADR_Criticality>
    {
        public IEnumerable<ADR_Criticality> Get()
        {
            return Db.ADR_Criticality.ToList();
        }

        public ADR_Criticality Get(int ID)
        {
            return Db.ADR_Criticality.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public bool Insert(ADR_Criticality Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Criticality Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Criticality Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
