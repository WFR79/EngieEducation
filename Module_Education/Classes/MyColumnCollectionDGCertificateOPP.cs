﻿using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGCertificateOPP
    {
        [DisplayName("NiveauRId")]
        public long? AgentCertificateLevelRId { get; set; }
        
        [DisplayName("Niveau R")]
        public string AgentCertificateLevelR { get; set; }

        [DisplayName("Date d'envoi")]
        public DateTime? AgentPassportSafetySendingDate { get; set; }

        [DisplayName("Date de retour")]
        public DateTime? AgentPassportSafetyReturnDate { get; set; }
        [DisplayName("Date de validité R")]
        public DateTime? AgentPassportSafetyValidityDate { get; set; }
        [DisplayName("Certification hiérarchique")]
        public bool? AgentPassportSaferyIsCertifiied { get; set; }

        [DisplayName("Remarques")]
        public string AgentPassportSafetyRemark { get; set; }

        [DisplayName("Remarques payement safety")]
        public string AgentPassportSafetyRemarkPay { get; set; }


        private Education_AgentCertifElecOPP _obj;

        public MyColumnCollectionDGCertificateOPP(Education_AgentCertifElecOPP obj)
        {
            _obj = obj;
        }

        public Education_AgentCertifElecOPP GetModel()
        {
            return _obj;
        }

    }
}