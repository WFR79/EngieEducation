using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class FormationProvider
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationProvider()
        {

        }

        public List<Education_FormationProvider> AllProviders()
        {
            return db.Education_FormationProvider.ToList();
        }

        public Education_FormationProvider GetProviderFomration(Education_Provider provider)
        {
            return db.Education_FormationProvider.Where(x => x.FormationProvider_Provider == provider.Provider_Id).FirstOrDefault();
        }
    }
}
