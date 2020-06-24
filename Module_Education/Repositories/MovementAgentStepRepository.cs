using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class MovementAgentStepRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db ;

        public MovementAgentStepRepository()
        {
            
        }
        public List<Education_MovementStepAgent> LoadAllStepsOfAgent(long agentId, long mvtTypeId)
        {
            db = new CFNEducation_FormationEntities();
            return db.Education_MovementStepAgent
                .Where(x => x.MovementStepAgent_Agent == agentId && x.Education_MovementStep.MovementStep_Type == mvtTypeId)
                .ToList();
        }

        internal void SaveStepAgent(List<Education_MovementStepAgent> currentMovementAgentSteps)
        {
            db = new CFNEducation_FormationEntities();

            foreach (Education_MovementStepAgent item in currentMovementAgentSteps)
            {
                var itemDB = db.Education_MovementStepAgent.Where(x => x.MovementStepAgent_Id == item.MovementStepAgent_Id).FirstOrDefault();
                itemDB.MovementStepAgent_Status = item.MovementStepAgent_Status;
                itemDB.MovementStepAgent_Remarks = item.MovementStepAgent_Remarks;

                db.SaveChanges();

            }

            ObjectResult result = db.UpdateStatutMovementAgent(currentMovementAgentSteps[0].MovementStepAgent_Agent,
                currentMovementAgentSteps[0].Education_MovementStep.MovementStep_Type);
        }
    }
}
