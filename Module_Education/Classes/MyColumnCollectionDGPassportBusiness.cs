using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGPassportBusiness
    {
        [DisplayName("IdSafetyAgent")]
        public long AgentPassportBusinessId { get; set; }
        [DisplayName("Passport Métier")]
        public string AgentPassportBusinessDesc { get; set; }

        [DisplayName("Date d'envoi")]
        public DateTime? AgentPassportBusinessSendingDate { get; set; }

        [DisplayName("Date de retour")]
        public DateTime? AgentPassportBusinessReturnDate { get; set; }

        [DisplayName("Certification hiérarchique")]
        public bool? AgentPassportBusinessIsCertifiied { get; set; }

        [DisplayName("Remarques")]
        public string AgentPassportSRemark { get; set; }



        private Education_AgentPassportBusiness _obj;

        public MyColumnCollectionDGPassportBusiness(Education_AgentPassportBusiness obj)
        {
            _obj = obj;
        }

        public Education_AgentPassportBusiness GetModel()
        {
            return _obj;
        }
    }
}
