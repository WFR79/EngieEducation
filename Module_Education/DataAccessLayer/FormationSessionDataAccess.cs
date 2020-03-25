using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.DataAccessLayer
{
    public class FormationSessionDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationSessionDataAccess()
        {

        }

        public List<Education_FormationSession> LoadAllSessionUnite()
        {
            return db.Education_FormationSession.ToList();
        }
        public Education_FormationSession LoadAllSessionUniteOfFormationByYear(Education_Formation formation, int year)
        {
            return db.Education_FormationSession
                .Where(x => x.FormationSession_Formation == formation.Formation_Id
                && x.FormationSession_Year == year).FirstOrDefault();
        }
    }
}
