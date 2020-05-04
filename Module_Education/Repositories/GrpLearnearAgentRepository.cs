using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class GrpLearnearAgentRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public GrpLearnearAgentRepository()
        {
            
        }

        public List<Education_Agent> GetAgentNotInTheSelectedGroup(Education_GroupLearner grpLearner)
        {
            List<Education_Agent> listAgentInGrp = db.Education_Agent
                .Where(w => w.Education_GroupLearner_Agent.Any(x => x.GroupLearnerAgent_GroupeLearner == grpLearner.GroupLearner_Id))
                .ToList();

            List<Education_Agent> listAgent = db.Education_Agent
               .ToList();

            List<Education_Agent> listIntersect = listAgent.Except(listAgentInGrp).ToList();

            return listIntersect;

        }

        public List<Education_GroupLearner_Agent> LoadAgentOfSelectedGroup(Education_GroupLearner grpLearner)
        {
            return db.Education_GroupLearner_Agent
                .Include("Education_Agent")
                .Where(w => w.GroupLearnerAgent_GroupeLearner == grpLearner.GroupLearner_Id)
                .ToList();
         
        }
        public Education_GroupLearner_Agent AddGrpLearnerAgent(Education_Agent agent, Education_GroupLearner grpLearner)
        {
            Education_GroupLearner_Agent grpAgent = new Education_GroupLearner_Agent()
            {
                 GroupLearnerAgent_GroupeLearner= grpLearner.GroupLearner_Id,
                 GroupLearnerAgent_Agent= agent.Agent_Id

            };
            db.Education_GroupLearner_Agent.Add(grpAgent);
            db.SaveChanges();
            return grpAgent;
        }

        internal List<Education_Agent> LoadAgentsNotInTheGroupSelected(Education_GroupLearner selectedGrpLearner)
        {
            throw new NotImplementedException();
        }
    }
}
