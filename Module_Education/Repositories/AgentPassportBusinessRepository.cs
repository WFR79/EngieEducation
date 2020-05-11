using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Module_Education.Repositories
{
    class AgentPassportBusinessRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentPassportBusinessRepository()
        {

        }
        public List<Education_AgentPassportBusiness> LoadPassportBusinessAgent(Education_Agent agent)
        {
            return db.Education_AgentPassportBusiness.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

        internal Education_AgentPassportBusiness SaveNewBusinessPassport(Education_AgentPassportBusiness agentPassportBusinessSelected)
        {
            throw new NotImplementedException();
        }
    }
}
