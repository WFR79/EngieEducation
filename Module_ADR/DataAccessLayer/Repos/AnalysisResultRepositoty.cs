using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class AnalysisResultRepositoty : RepositoryBase, IRepository<int, ADR_Analysis_Result>
    {
        public IEnumerable<ADR_Analysis_Result> Get()
        {
            return Db.ADR_Analysis_Result.ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetAnalysisNbs(string AnalysisNbs)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.AnalysisNbs == AnalysisNbs).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> Get(string Content)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.AnalysisNbs.Contains(Content)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetByFuncLocation(string Content)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.FuncLocation.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetByActivity(string Content)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.Activity.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetByOrder(string Content)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.OrderNbs.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetByContent(string Content)
        {
            return Db.ADR_Analysis_Result.Where((a) => a.OrderNbs.ToUpper().Contains(Content)
                                                    || a.FuncLocation.ToUpper().Contains(Content)
                                                    || a.Activity.ToUpper().Contains(Content)
                                                    || a.WorkCenter.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetAllByOrderNbs(string OrderNbs)
        {
            return Db.ADR_Analysis_Result.Where((sap) => sap.OrderNbs.ToUpper().Contains(OrderNbs)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetAllByOrderNbsAndWorkCenter(string OrderNbs, string WorkCenter)
        {
            return Db.ADR_Analysis_Result.Where((sap) => sap.OrderNbs.Contains(OrderNbs) && sap.WorkCenter.Contains(WorkCenter)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetAllByFuncLocation(string FuncLocation)
        {
            return Db.ADR_Analysis_Result.Where((sap) => sap.FuncLocation.ToUpper().Contains(FuncLocation)).ToList();
        }

        public IEnumerable<ADR_Analysis_Result> GetAllByActivity(string Activity)
        {
            return Db.ADR_Analysis_Result.Where((sap) => sap.Activity.ToUpper().Contains(Activity)).ToList();
        }


        public ADR_Analysis_Result Get(int ID)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_Analysis_Result GetByOrderNbs(string Order)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.OrderNbs == Order).FirstOrDefault();
        }

        public ADR_Analysis_Result GetByAnalysisNbs(string AnalysisNbs)
        {
            return Db.ADR_Analysis_Result.Where((ap) => ap.AnalysisNbs == AnalysisNbs).FirstOrDefault();
        }

        public bool Insert(ADR_Analysis_Result Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public int InsertAndReturnId(ADR_Analysis_Result Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            Db.SaveChanges();

            return Entity.Id;
        }

        public bool Update(ADR_Analysis_Result Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_Analysis_Result Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Deleted;

            return Db.SaveChanges() > 0;
        }
    }
}
