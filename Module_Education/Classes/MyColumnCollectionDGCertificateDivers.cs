using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGCertificateDivers
    {
        [DisplayName("IdCertificateDiversAgent")]
        public long AgentPassportDiversId { get; set; }

        [DisplayName("Certificat")]
        public string AgentPassportDiversCertificate { get; set; }

        [DisplayName("Date d'envoi")]
        public DateTime? AgentPassportDiversSendingDate { get; set; }

        [DisplayName("Date de retour")]
        public DateTime? AgentPassportDiversReturnDate { get; set; }

        [DisplayName("Certifié OUI/NON")]
        public bool? AgentPassportDiversIsCertified { get; set; }

        [DisplayName("Remarques")]
        public string AgentPassportDiversRemarks { get; set; }


        private Education_AgentCertificatDivers _obj;

        public MyColumnCollectionDGCertificateDivers(Education_AgentCertificatDivers obj)
        {
            _obj = obj;
        }

        public Education_AgentCertificatDivers GetModel()
        {
            return _obj;
        }

    }
}
