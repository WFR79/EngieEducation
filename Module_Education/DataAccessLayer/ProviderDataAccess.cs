using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class ProviderDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public ProviderDataAccess()
        {

        }
        public List<Education_Provider> AllProviders()
        {
            return db.Education_Provider.ToList();
        }
    }
}
