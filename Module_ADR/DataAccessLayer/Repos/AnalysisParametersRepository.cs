using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;
using System.Data;
using System;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class AnalysisParametersRepository : RepositoryBase, IRepository<int, ADR_Analysis_Parameters>
    {

        public IEnumerable<ADR_Analysis_Parameters> Get()
        {
            return Db.ADR_Analysis_Parameters.ToList();
        }

        public IEnumerable<ADR_Analysis_Parameters> GetByAnalysis(int AnalysisId)
        {
            return Db.ADR_Analysis_Parameters.Where((ap) => ap.AnalysisId == AnalysisId);
        }


        public ADR_Analysis_Parameters Get(int ID)
        {
            return Db.ADR_Analysis_Parameters.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_Analysis_Parameters GetByCriticality(int ID, int CriticalityId)
        {
            return Db.ADR_Analysis_Parameters.Where((ap) => ap.Id == ID && ap.CriticalityId == CriticalityId).FirstOrDefault();
        }

        public bool Insert(ADR_Analysis_Parameters Entity)
        {
            Db.Entry(Entity).State = EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public int InsertAndReturnId(ADR_Analysis_Parameters Entity)
        {
            Db.Entry(Entity).State = EntityState.Added;

            Db.SaveChanges();

            return Entity.Id;
        }

        public bool Update(ADR_Analysis_Parameters Entity)
        {
            Db.Entry(Entity).State = EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Analysis_Parameters Entity)
        {
            Db.Entry(Entity).State = EntityState.Deleted;

            return Db.SaveChanges() > 0;
        }
    }
}
