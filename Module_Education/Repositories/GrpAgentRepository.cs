using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class GrpAgentRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public GrpAgentRepository()
        {

        }

        public List<Education_GroupLearner> LoadAllGrpAgents()
        {
            return db.Education_GroupLearner.ToList();
        }

        public Education_GroupLearner AddGrpAgent(string grpName, string SAPName)
        {
            Education_GroupLearner grpAgent = new Education_GroupLearner()
            {
                GroupLearner_Name = grpName,
                GroupLearner_SAP = SAPName

            };
            db.Education_GroupLearner.Add(grpAgent);
            db.SaveChanges();
            return grpAgent;
        }
      
    }
}
