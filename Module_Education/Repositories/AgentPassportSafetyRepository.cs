using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class AgentPassportSafetyRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentPassportSafetyRepository()
        {

        }

        public List<Education_AgentPassportSafety> LoadPassportSafetyAgent(Education_Agent agent)
        {
            return db.Education_AgentPassportSafety.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

    }
}
