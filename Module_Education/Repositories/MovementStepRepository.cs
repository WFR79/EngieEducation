using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class MovementStepRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public MovementStepRepository()
        {

        }

        public List<Education_MovementStep> LoadAllTypes(Education_MovementType MovementType)
        {
            return db.Education_MovementStep
                .Where(x => x.MovementStep_Type == MovementType.MovementType_Id)
                .ToList();
        }

        public Education_MovementStep SaveMovementStep(Education_MovementType MovementType, long? id, string Who, string Action, string support, bool isNewRecord)
        {
           
            if (isNewRecord)
            {
                Education_MovementStep newRecord = new Education_MovementStep
                {
                    MovementStep_IntituleAction = Action,
                    MovementStep_Support = support,
                    MovementStep_Type = MovementType.MovementType_Id,
                    MovementStep_Who = Who
                };

                db.Education_MovementStep.Add(newRecord);
                db.SaveChanges();
                return newRecord;
            }
            else
            {
                var itemDb = db.Education_MovementStep.Where(x => x.MovementStep_Id == id).FirstOrDefault();

                itemDb.MovementStep_IntituleAction = Action;
                itemDb.MovementStep_Support = support;
                itemDb.MovementStep_Type = MovementType.MovementType_Id;
                itemDb.MovementStep_Who = Who;
                db.SaveChanges();
                return itemDb;
            }

        }
    }
}
