using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class PassportDesignRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public PassportDesignRepository()
        {

        }
        public List<Education_PassportDesign> LoadAllPassportDesign()
        {
            return db.Education_PassportDesign
                    .ToList();
        }
    }
}
