using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_Education.Repositories
{
    public class RouteAgentRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public RouteAgentRepository()
        {

        }

        public List<Education_Matrice_Agent> SaveRouteAgentProgress(List<Education_Matrice_Agent> listRouteAgent)
        {
            List<Education_Matrice_Agent> returnListMatriceAgent = new List<Education_Matrice_Agent>();
            foreach (Education_Matrice_Agent record in listRouteAgent)
            {
                var recordDb = db.Education_Matrice_Agent.Where(n => n.MatriceAgent_Id == record.MatriceAgent_Id).FirstOrDefault();
                recordDb.MatriceAgent_IsAttented = record.MatriceAgent_IsAttented;
                recordDb.MatriceAgent_DateFormationAttented = record.MatriceAgent_DateFormationAttented;
                recordDb.MatriceAgent_HasEquivalence = record.MatriceAgent_HasEquivalence;

                db.SaveChanges();
                returnListMatriceAgent.Add(recordDb);
            }

            return returnListMatriceAgent;
        }
    }
}
