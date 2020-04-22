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
                .Where(x => x.MatriceAgent_Matrice == matriceAgent.Matrice_Id)
                .ToList();
        }

        public Education_Matrice_Agent LoadSingleTrajetAgent(Education_Matrice matriceAgent, Education_Agent agent)
        {
            return db.Education_Matrice_Agent
                .Where(x => x.MatriceAgent_Matrice == matriceAgent.Matrice_Id && x.MatriceAgent_Agent == agent.Agent_Id)
                .FirstOrDefault();
        }

        public void AssignAgentToRoute(Education_Matrice matriceSelected, Education_Agent agentSelected)
        {
            Education_Matrice_Agent newRecord = new Education_Matrice_Agent(){ 
                MatriceAgent_Matrice = matriceSelected.Matrice_Id,
                MatriceAgent_Agent = agentSelected.Agent_Id
            
            };
            db.Education_Matrice_Agent.Add(newRecord);
            db.SaveChanges();
        }
    }
}
