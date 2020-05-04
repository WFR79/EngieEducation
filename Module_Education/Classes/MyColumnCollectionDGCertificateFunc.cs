using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGCertificateFunc
    {

        [DisplayName("IdElecFunc")]
        public long? AgentCertifElecFuncId { get; set; }

        [DisplayName("Niveau B")]
        public string AgentCertificateLevelB { get; set; }

        [DisplayName("Date d'envoi")]
        public DateTime? AgentPassportSafetySendingDate { get; set; }

        [DisplayName("Date de retour")]
        public DateTime? AgentPassportSafetyReturnDate { get; set; }

        [DisplayName("Certification hiérarchique")]
        public bool? AgentPassportSaferyIsCertifiied { get; set; }

        [DisplayName("Remarques")]
        public string AgentPassportSafetyRemark { get; set; }

        [DisplayName("Remarques payement safety")]
        public string AgentPassportSafetyRemarkPay { get; set; }


        private Education_AgentCertifElecFunc _obj;

        public MyColumnCollectionDGCertificateFunc(Education_AgentCertifElecFunc obj)
        {
            _obj = obj;
        }

        public Education_AgentCertifElecFunc GetModel()
        {
            return _obj;
        }

    }
}
