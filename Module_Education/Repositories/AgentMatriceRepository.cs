using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using System.Web;
using PagedList;
using System.Threading.Tasks;


namespace Module_Education.Repositories
{
    public class AgentMatriceRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public AgentMatriceRepository()
        {

        }

        public List<Education_Matrice_Agent> LoadAllTrajetAgent(Education_Matrice matriceAgent)
        {
            return db.Education_Matrice_Agent
                .Include("Education_Agent")
                .Where(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceAgent.Matrice_Id)
                .ToList();
        }

        public List<Education_Matrice_Agent> LoadAllAgentOfTheRoute(Education_Matrice matriceAgent)
        {
            return db.Education_Matrice_Agent
                .Include("Education_Agent")
                .Where(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceAgent.Matrice_Id)
                .Distinct()
                .ToList();
        }

        public Education_Matrice_Agent LoadSingleTrajetAgent(Education_Matrice matriceAgent, Education_Agent agent)
        {
            return db.Education_Matrice_Agent
                .Where(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceAgent.Matrice_Id && x.MatriceAgent_Agent == agent.Agent_Id)
                .FirstOrDefault();
        }

        public Education_Matrice_Agent LoadSingleTrajetFormation(long matriceAgent_Id)
        {
            return db.Education_Matrice_Agent
                .Include("Education_Matrice_AgentEquivalence")
                          .Where(x => x.MatriceAgent_Id == matriceAgent_Id)
                          .FirstOrDefault();
        }

        public void AssignAgentToRoute(Education_Matrice matriceSelected, Education_Agent agentSelected)
        {
            foreach (var matriceformation in matriceSelected.Education_Matrice_Formation)
            {
                Education_Matrice_Agent newRecord = new Education_Matrice_Agent()
                {
                    MatriceAgent_MatriceFormation = matriceformation.MatriceFormation_Id,
                    MatriceAgent_Agent = agentSelected.Agent_Id

                };
                db.Education_Matrice_Agent.Add(newRecord);
                db.SaveChanges();
            }
        }

        public List<Education_Matrice_Agent> LoadAllTrajetSingleAgent(Education_Matrice matriceSelected, long userIDSelected)
        {
            return db.Education_Matrice_Agent
                .Include("Education_Matrice_Formation")
                .Include("Education_Matrice_AgentEquivalence")

               .Where(x => x.Education_Agent.Agent_Matricule == userIDSelected && x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceSelected.Matrice_Id)
               .ToList();
        }

        public List<Education_Matrice_GrLearner> LoadSingleTrajetGrpAgent(Education_Matrice matriceSelected, Education_GroupLearner agentGrpSelected)
        {
            return db.Education_Matrice_GrLearner
                .Include("Education_Matrice")
                        .Where(x => x.Education_GroupLearner.GroupLearner_Id == agentGrpSelected.GroupLearner_Id
                        && x.MatriceGrLearner_Matrice == matriceSelected.Matrice_Id)
                        .ToList();
        }

        public void AssignGrpAgentToRoute(Education_Matrice matriceSelected, Education_GroupLearner agentGrpSelected)
        {
            Education_GroupLearner GrpAgent = db.Education_GroupLearner
                .Where(y => y.GroupLearner_Id == agentGrpSelected.GroupLearner_Id).FirstOrDefault();

            if (GrpAgent == null)
            {
                Education_Matrice_GrLearner newRecord = new Education_Matrice_GrLearner()
                {
                    MatriceGrLearner_Matrice = matriceSelected.Matrice_Id,
                    MatriceGrLearner_GroupeLearner = GrpAgent.GroupLearner_Id

                };
                db.Education_Matrice_GrLearner.Add(newRecord);
                db.SaveChanges();
            }

        }
    }
}
