using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class AnalysisTemplateRepository : RepositoryBase, IRepository<int, ADR_Analysis_Template>
    {
        public IEnumerable<ADR_Analysis_Template> Get()
        {
            return Db.ADR_Analysis_Template.ToList();
        }

        public ADR_Analysis_Template Get(int ID)
        {
            return Db.ADR_Analysis_Template.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public bool Insert(ADR_Analysis_Template Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Analysis_Template Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Analysis_Template Entity)
        {
            Entity.IsActive = false;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
