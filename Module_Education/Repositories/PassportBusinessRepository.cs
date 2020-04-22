using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class PassportBusinessRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public PassportBusinessRepository()
        {

        }
        public List<Education_PassportBusiness> LoadAllPassportBusiness()
        {
            return db.Education_PassportBusiness
                    .ToList();
        }

        public Education_AgentPassportBusiness LoadSinglePassport(long passportId)
        {
            return db.Education_AgentPassportBusiness
                .Where(w => w.AgentPassportBusiness_Id == passportId)
                   .FirstOrDefault()
                   ;
        }
    }
}
