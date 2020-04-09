using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    public class MyColumnCollectionDGProvider
    {
        private Education_Provider _obj;

        public MyColumnCollectionDGProvider(Education_Provider obj)
        {
            _obj = obj;
        }

        public Education_Provider GetModel()
        {
            return _obj;
        }
        [DisplayName("Nom")]
        public string Provider_Name { get; set; }

        [DisplayName("Contact")]
        public string Provider_Contact { get; set; }

        [DisplayName("Email Contact")]
        public string Provider_EmailContact { get; set; }

        [DisplayName("Tel Contact")]
        public string Provider_TelContact { get; set; }

        [DisplayName("Formateur")]
        public string Provider_FormerContact { get; set; }

        [DisplayName("Formateur Email")]
        public string Provider_FormerContactEmail { get; set; }

        [DisplayName("Tel Formateur")]
        public string Provider_FormerContactTel { get; set; }

        //[DisplayName("Capacité Maximale")]
        //public int? Provider_Name { get; set; }

        ////[DisplayName("Fournisseur")]
        ////public int? Formation_Provider { get; set; }

        //[DisplayName("Prix")]
        //public double? Provider_Name { get; set; }

        //[DisplayName("Interne")]
        //public Boolean? Provider_Name { get; set; }
    }
}
