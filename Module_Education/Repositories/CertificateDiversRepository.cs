using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class CertificateDiversRepository
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public CertificateDiversRepository()
        {

        }
        public List<Education_CertificatDivers> LoadAllPassportSafety()
        {
            return db.Education_CertificatDivers
                    .ToList();
        }

        public Education_CertificatDivers LoadSinglePassport(long passportId)
        {
            return db.Education_CertificatDivers
                .Where(w => w.CertificatDivers_Id == passportId)
                   .FirstOrDefault()
                   ;
        }

        internal Education_CertificatDivers SaveExistingPs(Education_AgentCertifElecOPP agentCertifElecOPPSelected)
        {
            throw new NotImplementedException();
        }

        public Education_CertificatDivers SaveNew(string nameCertif)
        {
            Education_CertificatDivers education_PassportSafety = new Education_CertificatDivers
            {

                CertificatDivers_Name = nameCertif,
            };
            db.Education_CertificatDivers.Add(education_PassportSafety);
            db.SaveChanges();
            return education_PassportSafety;
        }

        internal List<Education_CertificatDivers> LoadAllCertificateDivers()
        {
            return db.Education_CertificatDivers.Where(w => w.CertificatDivers_Actif == true)
                    .ToList();
        }
    }
}
