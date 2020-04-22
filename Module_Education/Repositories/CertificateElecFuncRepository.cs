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
        public List<Education_CertifElecFunc> LoadAllPassportSafety()
        {
            return db.Education_CertifElecFunc
                    .ToList();
        }
    }
}
