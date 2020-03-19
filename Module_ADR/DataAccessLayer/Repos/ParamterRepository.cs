using System.Collections.Generic;
using System.Data;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class ParamterRepository : RepositoryBase, IRepository<int, ADR_Parameter>
    {
        public IEnumerable<ADR_Parameter> Get()
        {
            return Db.ADR_Parameter.ToList();
        }

        public ADR_Parameter Get(int ID)
        {
            return Db.ADR_Parameter.Where((p) => p.Id == ID).FirstOrDefault();
        }

        public string GetValue(string ParameterName, string Environment = null)
        {
            if (!string.IsNullOrEmpty(Environment))
                return Db.ADR_Parameter.Where((p) => p.ParameterName.ToUpper() == ParameterName.ToUpper() && p.Environment.ToUpper() == Environment.ToUpper()).Select((p) => p.ParameterValue).FirstOrDefault();
            else
                return Db.ADR_Parameter.Where((p) => p.ParameterName.ToUpper() == ParameterName.ToUpper()).Select((p) => p.ParameterValue).FirstOrDefault();
        }

        public bool Insert(ADR_Parameter Entity)
        {
            Db.Entry(Entity).State = EntityState.Added;

            Db.SaveChanges();

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_Parameter Entity)
        {
            Db.Entry(Entity).State = EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Parameter Entity)
        {
            Db.Entry(Entity).State = EntityState.Deleted;

            return Db.SaveChanges() > 0;
        }
    }
}
