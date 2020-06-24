using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Module_Education.Repositories
{
    class AgentCertifElecFuncRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentCertifElecFuncRepository()
        {

        }
        public List<Education_AgentCertifElecFunc> LoadCertifElecFunc(Education_Agent agent)
        {
            return db.Education_AgentCertifElecFunc.Where(x => x.Education_Agent.Agent_Id == agent.Agent_Id)
                    .ToList();
        }

        internal Education_AgentCertifElecFunc SaveNewCertifFunc(Education_AgentCertifElecFunc agentCertifElecFuncSelected)
        {
            throw new NotImplementedException();
        }
    }
}
