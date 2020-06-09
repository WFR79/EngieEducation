using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class CertificateElecOPPRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public CertificateElecOPPRepository()
        {

        }
        public List<Education_CertifElecOPP> LoadAllCertificateOPP()
        {
            return db.Education_CertifElecOPP.Where(w => w.CertifElecOPP_Actif == true)
                    .ToList();
        }

        public Education_AgentCertifElecOPP LoadSinglePassport(long passportId)
        {
            return db.Education_AgentCertifElecOPP
                .Where(w => w.AgentCertifElecOPP_Certification == passportId)
                   .FirstOrDefault()
                   ;
        }

        internal Education_AgentCertifElecOPP SaveExistingPs(Education_AgentCertifElecOPP agentCertifElecOPPSelected)
        {
            throw new NotImplementedException();
        }

        public Education_CertifElecOPP SaveNewCertificatOPP(string lvlR)
        {
            Education_CertifElecOPP education_PassportSafety = new Education_CertifElecOPP
            {

                CertifElecOPP_LevelR = lvlR,
            };
            db.Education_CertifElecOPP.Add(education_PassportSafety);
            db.SaveChanges();
            return education_PassportSafety;
        }
    }
}
