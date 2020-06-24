using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.DataAccessLayer
{
    public class FormationProviderRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationProviderRepository()
        {

        }

        public List<Education_FormationProvider> LoadFormationProviderByFormation(Education_Formation formation)
        {
            return db.Education_FormationProvider
                .Where(x => x.FormationProvider_Formation == formation.Formation_Id)
                .ToList();
        }

        public Education_FormationProvider LoadFormationProvider(Education_Provider provider)
        {
            return db.Education_FormationProvider
                .Where(x => x.FormationProvider_Provider == provider.Provider_Id)
                .FirstOrDefault();
        }
        public Education_FormationProvider LoadFormationProviderById(long providerId)
        {
            return db.Education_FormationProvider
                .Where(x => x.Education_Provider.Provider_Id == providerId)
                .FirstOrDefault();
        }

        public List<Education_FormationProvider> LoadAllFormationProvider(Education_Provider provider)
        {
            return db.Education_FormationProvider
                .Where(x => x.FormationProvider_Provider == provider.Provider_Id)
                .ToList();
        }

        //public List<Education_FormationProvider> LoadAllFormationProvider(Education_Provider provider)
        //{
        //    return db.Education_FormationProvider
        //        .Where(x => x.FormationProvider_Provider == provider.Provider_Id)
        //        .ToList();
        //}
    }
}
