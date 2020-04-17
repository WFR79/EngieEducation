using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGPassportSafety
    {
        [DisplayName("Niveau PS")]
        public int? AgentPassportSafetyLevelPS { get; set; }

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


        private Education_AgentPassportSafety _obj;

        public MyColumnCollectionDGPassportSafety(Education_AgentPassportSafety obj)
        {
            _obj = obj;
        }

        public Education_AgentPassportSafety GetModel()
        {
            return _obj;
        }

    }
}
