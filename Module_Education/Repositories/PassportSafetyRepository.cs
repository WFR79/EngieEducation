using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class PassportSafetyRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public PassportSafetyRepository()
        {

        }
        public List<Education_PassportSafety> LoadAllPassportSafety()
        {
            return db.Education_PassportSafety.Where(x => x.PassportSafety_Actif == true)
                    .ToList();
        }

        public Education_AgentPassportSafety LoadSinglePassport(long passportId)
        {
            return db.Education_AgentPassportSafety
                .Include("Education_PassportSafety")
                .Where(w => w.AgentPassportSafety_Id == passportId)
                   .FirstOrDefault()
                   ;
        }

        public Education_AgentPassportSafety SaveExistingCertification(Education_AgentPassportSafety education_AgentPassportSafety)
        {
            var certif = db.Education_AgentPassportSafety
                 .Where(w => w.AgentPassportSafety_Id == education_AgentPassportSafety.AgentPassportSafety_Id).FirstOrDefault();

            certif.AgentPassportSafety_Passport = education_AgentPassportSafety.AgentPassportSafety_Passport;

            db.SaveChanges();
            return certif;
        }

        public Education_PassportSafety SaveNewPs(int lvlPs)
        {
            Education_PassportSafety education_PassportSafety = new Education_PassportSafety
            {

                PassportSafety_LevelPS = lvlPs,
            };
            db.Education_PassportSafety.Add(education_PassportSafety);
            db.SaveChanges();
            return education_PassportSafety;
        }


    }
}
