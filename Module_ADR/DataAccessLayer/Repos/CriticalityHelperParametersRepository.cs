using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;


namespace Module_ADR.DataAccessLayer.Repos
{
    public class CriticalityHelperParametersRepository : RepositoryBase, IRepository<int, ADR_Criticality_Helper_Parameters>
    {
        public IEnumerable<ADR_Criticality_Helper_Parameters> Get()
        {
            return Db.ADR_Criticality_Helper_Parameters.ToList();
        }

        public ADR_Criticality_Helper_Parameters Get(int ID)
        {
            return Db.ADR_Criticality_Helper_Parameters.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public int Get(string RiskName)
        {
            return Db.ADR_Criticality_Helper_Parameters.Where((ap) => ap.ItemText == RiskName).FirstOrDefault().Id;
        }

        public bool Insert(ADR_Criticality_Helper_Parameters Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Criticality_Helper_Parameters Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Criticality_Helper_Parameters Entity)
        {
            Entity.IsDisabled = true;

            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }
    }
}
