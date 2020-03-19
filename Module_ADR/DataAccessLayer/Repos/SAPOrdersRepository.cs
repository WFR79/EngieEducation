using System.Collections.Generic;
using System.Linq;
using Module_ADR.DataAccessLayer.Repos.Interface;
using Module_ADR.Models;
using SynapseCore.Database;
using Module_ADR.Helper;

namespace Module_ADR.DataAccessLayer.Repos
{
    public class SAPOrdersRepository : RepositoryBase, IRepository<int, ADR_SAPOrders>
    {
        public IEnumerable<ADR_SAPOrders> Get()
        {
            return Db.ADR_SAPOrders.ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetByContent(string Content)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.OrderNbs.ToUpper().Contains(Content)
                                                  || sap.FuncLocation.ToUpper().Contains(Content)
                                                  || sap.MaintencaneItem.ToUpper().Contains(Content)
                                                  || sap.WorkCenter.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetByWorkCenter(string WorkCenter)
        {
            return Db.ADR_SAPOrders.Where((wk) => wk.WorkCenter.StartsWith(WorkCenter)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetByCommand(string Content)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.OrderNbs.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetByFuncLocation(string Content)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.FuncLocation.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetByMaintenanceItem(string Content)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.MaintencaneItem.ToUpper().Contains(Content)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetAllByOrderNbs(string OrderNbs)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.OrderNbs.ToUpper().Contains(OrderNbs)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetAllByFuncLocation(string FuncLocation)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.FuncLocation.ToUpper().Contains(FuncLocation)).ToList();
        }

        public IEnumerable<ADR_SAPOrders> GetAllByMaintenanceItem(string Item)
        {
            return Db.ADR_SAPOrders.Where((sap) => sap.MaintencaneItem.ToUpper().Contains(Item)).ToList();
        }

        public ADR_SAPOrders Get(int ID)
        {
            return Db.ADR_SAPOrders.Where((ap) => ap.Id == ID).FirstOrDefault();
        }

        public ADR_SAPOrders GetByOrderNbs(string OrderNbs)
        {
            return Db.ADR_SAPOrders.Where((ap) => ap.OrderNbs == OrderNbs).FirstOrDefault();
        }

        public bool Insert(ADR_SAPOrders Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Added;

            return Db.SaveChanges() > 0;
        }

        public bool Update(ADR_SAPOrders Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Modified;

            return Db.SaveChanges() > 0;
        }

        public bool Delete(ADR_SAPOrders Entity)
        {
            Db.Entry(Entity).State = System.Data.EntityState.Deleted;

            return Db.SaveChanges() > 0;
        }

        public ADR_SAPOrders GetRecurent(string Poste)
        {
            return Db.ADR_SAPOrders.Where((o) => o.MaintencaneItem == Poste).FirstOrDefault();
        }
    }
}
