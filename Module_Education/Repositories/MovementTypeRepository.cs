using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    class MovementTypeRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public MovementTypeRepository()
        {

        }

        public List<Education_MovementType> LoadAllTypes()
        {
            return db.Education_MovementType.ToList();
        }

        public Education_MovementType AddType(string text)
        {
            var itemdb = db.Education_MovementType.Where(x => x.MovementType_Name == text).FirstOrDefault();
            if (itemdb == null)
            {
                Education_MovementType newRecord = new Education_MovementType()
                {
                    MovementType_Name = text,
                };
                db.Education_MovementType.Add(newRecord);
                db.SaveChanges();
                return newRecord;
            }
            else {
                return null;
            }
        }
    }
}
