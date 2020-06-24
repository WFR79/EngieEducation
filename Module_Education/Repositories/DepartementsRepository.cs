using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using System.Web;
using PagedList;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class DepartementsRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public DepartementsRepository()
        {

        }
        public List<Education_Service> LoadAllService()
        {
            return db.Education_Service.
                ToList();
        }

        public List<Education_SousService> LoadAllSousService()
        {
            return db.Education_SousService
                .ToList();
        }

        public List<Education_Departement> LoadAllDepartements()
        {
            return db.Education_Departement
                .ToList();
        }

        internal Education_Departement LoadSingleDepartement(long departementIdSelected)
        {
            return db.Education_Departement
                .Where(x => x.Departement_Id == departementIdSelected)
                 .FirstOrDefault();
        }
    }
}