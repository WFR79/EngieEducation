using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class PassportDesignRepository : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public PassportDesignRepository()
        {

        }
        public List<Education_PassportDesign> LoadAllPassportDesign()
        {
            return db.Education_PassportDesign.Where(w => w.PassportDesign_Actif == true)
                    .ToList();
        }

        public Education_AgentPassportDesign LoadSinglePassport(long passportId)
        {
            return db.Education_AgentPassportDesign
                            .Where(w => w.AgentPassportDesign_Passport == passportId)
                               .FirstOrDefault()
                               ;
        }

        internal Education_AgentPassportDesign SaveExistingPs(Education_AgentPassportDesign agentPassportDesignSelected)
        {
            var certif = db.Education_AgentPassportDesign
                          .Where(w => w.AgentPassportDesign_Id == agentPassportDesignSelected.AgentPassportDesign_Id).FirstOrDefault();

            certif = agentPassportDesignSelected;

            db.SaveChanges();
            return certif;
        }

        public Education_PassportDesign SaveNewPs(string description)
        {
            Education_PassportDesign education_PassportSafety = new Education_PassportDesign
            {
                PassportDesign_Name = description,
            };
            db.Education_PassportDesign.Add(education_PassportSafety);
            db.SaveChanges();
            return education_PassportSafety;
        }
    }
}
