using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class MovementAgentRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db ;

        public MovementAgentRepository()
        {

        }

        public List<Education_MovementAgent> LoadAllMovements()
        {
            db = new CFNEducation_FormationEntities();
            return db.Education_MovementAgent
                .ToList();
        }

        public Education_MovementAgent LoadSingleMvtAgent(long agentId , long mvtTypeId)
        {
            db = new CFNEducation_FormationEntities();

            return db.Education_MovementAgent
                .Where(x => x.MovementAgent_Type == mvtTypeId && x.MovementAgent_Agent == agentId)
               .FirstOrDefault();
        }

        //public Education_MovementAgent SaveMovementStep(Education_MovementAgent MovementType, long? id, string Who, string Action, string support, bool isNewRecord)
        //{

        //    if (isNewRecord)
        //    {
        //        Education_MovementAgent newRecord = new Education_MovementAgent
        //        {
        //            MovementStep_IntituleAction = Action,
        //            MovementStep_Support = support,
        //            MovementStep_Type = MovementType.MovementType_Id,
        //            MovementStep_Who = Who
        //        };

        //        db.Education_MovementAgent.Add(newRecord);
        //        db.SaveChanges();
        //        return newRecord;
        //    }
        //    else
        //    {
        //        var itemDb = db.Education_MovementAgent.Where(x => x.MovementStep_Id == id).FirstOrDefault();

        //        itemDb.MovementStep_IntituleAction = Action;
        //        itemDb.MovementStep_Support = support;
        //        itemDb.MovementStep_Type = MovementType.MovementType_Id;
        //        itemDb.MovementStep_Who = Who;
        //        db.SaveChanges();
        //        return itemDb;
        //    }

        //}
    }
}
