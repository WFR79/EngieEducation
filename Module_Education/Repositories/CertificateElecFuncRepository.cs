using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class CertificateElecFuncRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public CertificateElecFuncRepository()
        {

        }
        public List<Education_CertifElecFunc> LoadAllCertificateFunc()
        {
            return db.Education_CertifElecFunc
                    .ToList();
        }

        public Education_AgentCertifElecFunc LoadSinglePassport(long passportId)
        {
            return db.Education_AgentCertifElecFunc
                .Where(w => w.AgentCertifElecFunc_Id == passportId)
                   .FirstOrDefault()
                   ;
        }

        internal Education_AgentCertifElecFunc SaveExistingCertification(Education_AgentCertifElecFunc agentCertifElecFuncSelected)
        {
            throw new NotImplementedException();
        }

        public Education_CertifElecFunc SaveNewCertificatFunc(string lvlB)
        {
            Education_CertifElecFunc education_PassportSafety = new Education_CertifElecFunc
            {

                CertifElecFunc_LevelB = lvlB,
            };
            db.Education_CertifElecFunc.Add(education_PassportSafety);
            db.SaveChanges();
            return education_PassportSafety;
        }
    }
}
