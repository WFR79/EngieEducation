using System;
using System.Collections.Generic;
using System.Linq;
using Module_Education.Models;
using System.Web;
using PagedList;
using System.Threading.Tasks;


namespace Module_Education.Repositories
{
    public class AgentMatriceRepository : RepositoryBase
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
                                .Include("Education_Matrice_Formation")

                .Where(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceAgent.Matrice_Id
                && x.MatriceAgent_Actif == true)
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
            Education_Matrice_GrLearner MatriceGrpAgent = db.Education_Matrice_GrLearner
                .Where(y => y.MatriceGrLearner_GroupeLearner == agentGrpSelected.GroupLearner_Id 
                && y.MatriceGrLearner_Matrice ==  matriceSelected.Matrice_Id).FirstOrDefault();

            if (MatriceGrpAgent == null)
            {
                Education_Matrice_GrLearner newRecord = new Education_Matrice_GrLearner()
                {
                    MatriceGrLearner_Matrice = matriceSelected.Matrice_Id,
                    MatriceGrLearner_GroupeLearner = agentGrpSelected.GroupLearner_Id

                };
                db.Education_Matrice_GrLearner.Add(newRecord);
                db.SaveChanges();
            }

        }

        public void AssignAgentToRoute(Education_Matrice matriceSelected, Education_Agent agentSelected)
        {

            foreach (var matriceformation in matriceSelected.Education_Matrice_Formation)
            {

                Education_Matrice_Agent newRecord = new Education_Matrice_Agent()
                {
                    MatriceAgent_MatriceFormation = matriceformation.MatriceFormation_Id,
                    MatriceAgent_Agent = agentSelected.Agent_Id,
                    MatriceAgent_Actif = true
                };
                db.Education_Matrice_Agent.Add(newRecord);
                db.SaveChanges();

                //var matriceFormation = db.Education_Matrice_Formation.Where(x => x.)
                Education_Agent_Formation newRecordAF = new Education_Agent_Formation()
                {
                    AgentFormation_Agent = agentSelected.Agent_Id,
                    AgentFormation_Formation = matriceformation.Education_Formation.Formation_Id
                };
                db.Education_Agent_Formation.Add(newRecordAF);
                db.SaveChanges();
            }
        }

        internal void RemoveAgentFromRoute(Education_Matrice matriceSelected, long userIDSelected)
        {
            List<Education_Matrice_Agent> ListitemDb = db.Education_Matrice_Agent
              .Where(x => x.Education_Agent.Agent_Matricule == userIDSelected 
              && x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceSelected.Matrice_Id)
              .ToList();

            foreach(Education_Matrice_Agent itemDb in ListitemDb)
            {
                itemDb.MatriceAgent_Actif = false;
                db.SaveChanges();
            }
        }
    }
}
