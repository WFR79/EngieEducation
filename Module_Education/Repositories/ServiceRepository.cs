using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class ServiceRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public ServiceRepository()
        {

        }
        public List<Education_Service> LoadAllService()
        {
            return db.Education_Service
                    .ToList();
        }

        public Education_Service LoadSingleService(long? idService)
        {
            return db.Education_Service
                .Where(x => x.Service_Id == idService)
                    .FirstOrDefault();
        }


        public List<Education_SousService> LoadAllSousService()
        {
            return db.Education_SousService
                    .ToList();
        }

        public Education_SousService LoadSingleSousService(long? idSousService)
        {
            return db.Education_SousService
                .Where(x => x.SousService_Id == idSousService)
                    .FirstOrDefault();
        }
    }
}
