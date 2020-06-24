
using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education
{
    public class CompetenceDataAccess : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public CompetenceDataAccess()
        {

        }
        public List<Education_Competence> LoadAllCompetences()
        {
            return db.Education_Competence.ToList();
        }
    }
}