using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class GrpLearnearAgentRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public GrpLearnearAgentRepository()
        {

        }

        public List<Education_Agent> GetAgentNotInTheSelectedGroup(Education_GroupLearner grpLearner)
        {
            List<Education_Agent> listAgentInGrp = db.Education_Agent
                .Where(w => w.Education_GroupLearner_Agent.Any(x => x.GroupLearnerAgent_GroupeLearner == grpLearner.GroupLearner_Id)
                 && w.Education_GroupLearner_Agent.Any(x => x.Education_GroupLearner.GroupLearner_Actif == true))
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
                .Where(w => w.GroupLearnerAgent_GroupeLearner == grpLearner.GroupLearner_Id && w.Education_GroupLearner.GroupLearner_Actif == true)
                .ToList();

        }
        public Education_GroupLearner_Agent AddGrpLearnerAgent(Education_Agent agent, Education_GroupLearner grpLearner)
        {
            Education_GroupLearner_Agent grpAgent = new Education_GroupLearner_Agent()
            {
                GroupLearnerAgent_GroupeLearner = grpLearner.GroupLearner_Id,
                GroupLearnerAgent_Agent = agent.Agent_Id

            };
            db.Education_GroupLearner_Agent.Add(grpAgent);
            db.SaveChanges();
            return grpAgent;
        }
        public List<Education_Matrice_GrLearner> GetMatriceOfGroupLearner(Education_GroupLearner grpLearner)
        {

            return db.Education_Matrice_GrLearner
                .Include("Education_Matrice")
                .Where(x => x.MatriceGrLearner_GroupeLearner == grpLearner.GroupLearner_Id && x.Education_GroupLearner.GroupLearner_Actif == true)
                .ToList();

        }

        internal List<Education_Agent> LoadAgentsNotInTheGroupSelected(Education_GroupLearner selectedGrpLearner)
        {
            throw new NotImplementedException();
        }

        internal List<Education_GroupLearner> LoadGrpAgentOfMatriceSelectezd(Education_Matrice matriceSelected)
        {
            return db.Education_GroupLearner
                            //.Include("Education_Matrice")
                            .Where(x => x.Education_Matrice_GrLearner.Any(c => c.MatriceGrLearner_Matrice == matriceSelected.Matrice_Id)
                            && x.GroupLearner_Actif == true)
                            .ToList();
        }

        internal bool DeleteGroup(Education_GroupLearner selectedGrpLearner)
        {
            var grp = db.Education_GroupLearner
                                         //.Include("Education_Matrice")
                                         .Where(x => x.GroupLearner_Id == selectedGrpLearner.GroupLearner_Id)
                                         .FirstOrDefault();
            grp.GroupLearner_Actif = false;
           
            db.SaveChanges();
            return true;
        }

        internal void RemoveAgentFromGroup(Education_Agent agent, Education_GroupLearner selectedGrpLearner)
        {
            var agentGrp = db.Education_GroupLearner_Agent
                                                     //.Include("Education_Matrice")
                                                     .Where(x => x.GroupLearnerAgent_Agent == agent.Agent_Id &&
                                                     x.GroupLearnerAgent_GroupeLearner == selectedGrpLearner.GroupLearner_Id)
                                                     .FirstOrDefault();
            db.Education_GroupLearner_Agent.Remove(agentGrp);
            db.SaveChanges();

        }
    }
}
