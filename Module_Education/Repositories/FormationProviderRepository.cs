using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.DataAccessLayer
{
    public class FormationProviderRepository
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
    }
}
