using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class WorkCenterRepository : RepositoryBase, IRepository<int, ADR_WorkCenter>
    {
        public IEnumerable<ADR_WorkCenter> Get()
        {
            return Db.ADR_WorkCenter.Where((wk) => !wk.IsDisabled).ToList();
        }

        public ADR_WorkCenter Get(int ID)
        {
            return Db.ADR_WorkCenter.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_WorkCenter GetByName(string WorkCenter)
        {
            return Db.ADR_WorkCenter.Where((ap) => ap.WorkCenter.ToUpper() == WorkCenter.ToUpper()).FirstOrDefault();
        }

        public bool Insert(ADR_WorkCenter Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_WorkCenter Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_WorkCenter Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
