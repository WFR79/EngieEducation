using Module_ADR.Helper;
using Module_ADR.Models;
using Module_ADR.DataAccessLayer.Repos.Interface;
using SynapseCore.Database;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class HistoriqueRepository : RepositoryBase, IRepository<int, ADR_Historique>
    {
        public IEnumerable<ADR_Historique> Get()
        {
            return Db.ADR_Historique.ToList();
        }

        public ADR_Historique Get(int ID)
        {
            return Db.ADR_Historique.Where((h) => h.Id == ID).FirstOrDefault();
        }

        public bool Insert(ADR_Historique Entity)
        {
            Db.Entry(Entity).State = EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Historique Entity)
        {
            Db.Entry(Entity).State = EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Historique Entity)
        {
            Db.Entry(Entity).State = EntityState.Deleted;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
