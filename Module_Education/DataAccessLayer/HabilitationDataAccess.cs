using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class Education_HabilitationDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public Education_HabilitationDataAccess()
        {

        }

        public List<Education_Habilitation> LoadAllEducation_Habilitation()
        {
            return db.Education_Habilitation.ToList();
        }

    }
}