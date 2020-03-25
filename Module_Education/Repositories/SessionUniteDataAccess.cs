using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace Module_Education
{
    public class SessionUniteDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public SessionUniteDataAccess()
        {

        }

        public List<Education_SessionUnite> LoadAllSessionUnite()
        {
            return db.Education_SessionUnite.ToList();
        }
    }
}