using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class AgentCertifElecOPPRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentCertifElecOPPRepository()
        {

        }
        public List<Education_AgentCertifElecOPP> LoadPassportBusinessAgent(Education_Agent agent)
        {
            return db.Education_AgentCertifElecOPP.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }
    }
}
