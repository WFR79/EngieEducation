﻿using Module_Education.Models;
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
        public List<Education_CertifElecOPP> LoadAllPassportSafety()
        {
            return db.Education_CertifElecOPP
                    .ToList();
        }
    }
}
