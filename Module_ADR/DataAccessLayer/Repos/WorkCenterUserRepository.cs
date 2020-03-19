using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class WorkCenterUserRepository : RepositoryBase, IRepository<int, ADR_WorkCenterUser>
    {
        public IEnumerable<ADR_WorkCenterUser> Get()
        {
            return Db.ADR_WorkCenterUser.ToList();
        }

        public ADR_WorkCenterUser Get(int ID)
        {
            return Db.ADR_WorkCenterUser.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_WorkCenterUser GetByUserId(string ID)
        {
            return Db.ADR_WorkCenterUser.Where((ap) => ap.UserId.ToUpper() == ID.ToUpper()).FirstOrDefault();
        }

        public bool Insert(ADR_WorkCenterUser Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_WorkCenterUser Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_WorkCenterUser Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }
    }
}
