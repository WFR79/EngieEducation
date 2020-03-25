using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Module_Education
{
    public class UserStatusDataAccess
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public UserStatusDataAccess()
        {

        }
        public List<Education_AgentStatus> LoadAllStatus()
        {
            return db.Education_AgentStatus.ToList();
        }

    }
}