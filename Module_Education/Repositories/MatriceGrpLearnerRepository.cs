using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module_Education.Repositories
{
    public class MatriceGrpLearnerRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public MatriceGrpLearnerRepository()
        {

        }

        internal List<Education_Matrice_GrLearner> LoadGrpAgentOfMatriceSelected(Education_Matrice matriceSelected)
        {
            return db.Education_Matrice_GrLearner
                            //.Include("Education_Matrice")
                            .Where(x => x.MatriceGrLearner_Matrice == matriceSelected.Matrice_Id
                            && x.Education_GroupLearner.GroupLearner_Actif == true && x.MatriceGrLearner_Actif != false)
                            .ToList();
        }

        internal void RemoveAgentFromRoute(Education_Matrice matriceSelected, string nameGrpAgentSelected)
        {
            Education_Matrice_GrLearner itemDb =  db.Education_Matrice_GrLearner
                            //.Include("Education_Matrice")
                            .Where(x => x.MatriceGrLearner_Matrice == matriceSelected.Matrice_Id
                            && x.Education_GroupLearner.GroupLearner_Actif == true && x.Education_GroupLearner.GroupLearner_Name == nameGrpAgentSelected)
                            .FirstOrDefault();

            itemDb.MatriceGrLearner_Actif = false;
            db.SaveChanges();

            List<Education_GroupLearner_Agent> ListgrpLearner = db.Education_GroupLearner_Agent.Where(x => x.Education_GroupLearner.GroupLearner_Name == nameGrpAgentSelected 
            && x.Education_GroupLearner.GroupLearner_Actif == true)
                .ToList();

            foreach (var grpagent in ListgrpLearner)
            {
               Education_Matrice_Agent agentItemDb = db.Education_Matrice_Agent
                                //.Include("Education_Matrice")
                                .Where(x => x.Education_Matrice_Formation.MatriceFormation_Matrice == matriceSelected.Matrice_Id
                                && x.MatriceAgent_Agent == grpagent.Education_Agent.Agent_Id)
                                .FirstOrDefault();

                agentItemDb.MatriceAgent_Actif = false;
                db.SaveChanges();
            }

           
        }
    }
}
