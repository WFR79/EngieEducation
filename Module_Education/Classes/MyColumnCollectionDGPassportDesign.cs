using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGPassportDesign
    {
        [DisplayName("Type Passport")]
        public int? AgentPassportDesign { get; set; }

        [DisplayName("Date d'envoi")]
        public DateTime? AgentPassportSafetySendingDate { get; set; }

        [DisplayName("Date de retour")]
        public DateTime? AgentPassportSafetyReturnDate { get; set; }

        [DisplayName("Certifié OUI/NON")]
        public bool? AgentPassportSaferyIsCertifiied { get; set; }

        [DisplayName("Remarques")]
        public string AgentPassportSafetyRemark { get; set; }


        private Education_AgentPassportDesign _obj;

        public MyColumnCollectionDGPassportDesign(Education_AgentPassportDesign obj)
        {
            _obj = obj;
        }

        public Education_AgentPassportDesign GetModel()
        {
            return _obj;
        }

    }
}
