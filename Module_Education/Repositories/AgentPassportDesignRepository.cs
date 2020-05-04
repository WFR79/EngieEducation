
using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Module_Education.Repositories
{
    class AgentPassportDesignRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentPassportDesignRepository()
        {

        }
        public List<Education_AgentPassportDesign> LoadPassportDesignAgent(Education_Agent agent)
        {
            return db.Education_AgentPassportDesign.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

        internal Education_AgentPassportDesign SaveExistingPs(Education_AgentPassportDesign agentPassportDesignSelected)
        {
            var certif = db.Education_AgentPassportDesign
                          .Where(w => w.AgentPassportDesign_Id == agentPassportDesignSelected.AgentPassportDesign_Id).FirstOrDefault();

            certif = agentPassportDesignSelected;

            db.SaveChanges();
            return certif;
        }
    }
}
