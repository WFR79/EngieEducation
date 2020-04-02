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

        //[DisplayName("Titre Long")]
        //public string Column_LongTitle { get; set; }

        //[DisplayName("SAP")]
        //public string Provider_Name { get; set; }

        //[DisplayName("Durée (Jours)")]
        //public double? Provider_Name { get; set; }

        //[DisplayName("Année Création")]
        //public int? Provider_Name { get; set; }

        //[DisplayName("Capacité Minimale")]
        //public int? Provider_Name { get; set; }

        //[DisplayName("Capacité Optimale")]
        //public int? Provider_Name { get; set; }

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
