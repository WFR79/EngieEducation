using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class ProviderDataRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public ProviderDataRepository()
        {

        }

        public List<Education_Provider> AllProviders()
        {
            return db.Education_Provider.ToList();
        }

        public Education_Provider GetProvider(string providerName)
        {
            return db.Education_Provider.Where(x => x.Provider_Name == providerName).FirstOrDefault();
        }

        public Education_Provider GetProvider(long providerId)
        {
            return db.Education_Provider.Where(x => x.Provider_Id == providerId).FirstOrDefault();
        }
    }
}
