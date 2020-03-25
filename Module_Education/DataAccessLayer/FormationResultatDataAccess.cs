using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.DataAccessLayer
{
    class FormationResultatDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationResultatDataAccess()
        {

        }
        public List<Education_FormationResultat> LoadAllResultatByFormation(Education_Formation formation)
        {
            return db.Education_FormationResultat
                    .Where(x => x.FormationResultat_Formation == formation.Formation_Id)
                    .ToList();
        }
    }
}
