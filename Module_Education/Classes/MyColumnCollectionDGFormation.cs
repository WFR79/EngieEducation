using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    class MyColumnCollectionDGFormation
    {
        private Education_Formation _obj;

        public MyColumnCollectionDGFormation(Education_Formation obj)
        {
            _obj = obj;
        }

        public Education_Formation GetModel()
        {
            return _obj;
        }
        [DisplayName("Titre Court")]
        public string Column_ShortTitle { get; set; }
        
        //[DisplayName("Titre Long")]
        //public string Column_LongTitle { get; set; }

        [DisplayName("SAP")]
        public string Column_SAP { get; set; }

        [DisplayName("Durée (Jours)")]
        public double? Column_DurationInDays {get; set; }

        [DisplayName("Année Création")]
        public int?Column_YearOfCreation{ get; set; }

        [DisplayName("Capacité Minimale")]
        public int? Column_CapaciteMin { get; set; }
        [DisplayName("Capacité Optimale")]
        public int? Column_CapaciteOptimale { get; set; }
        [DisplayName("Capacité Maximale")]
        public int? Column_CapaciteMax { get; set; }
        [DisplayName("Fournisseur")]
        public int? Column_Provider { get; set; }

        //[DisplayName("Responsable")]
        //public string Column_ShortTitle { get; set; }

        //[DisplayName("Admin")]
        //public string Column_ShortTitle { get; set; }

        //[DisplayName("Education_Habilitation")]
        //public string Column_ShortTitle { get; set; }

        //[DisplayName("Chargé de travaux")]
        //public bool? Column_ShortTitle { get; set; }

        //[DisplayName("Date d'entrée")]
        //public DateTime? Column_ShortTitle { get; set; }

        //[DisplayName("Date d'ancienneté")]
        //public DateTime? Column_ShortTitle { get; set; }

        //[DisplayName("Dernière prise de fonction")]
        //public DateTime? Column_ShortTitle { get; set; }

        //[DisplayName("Statut")]
        //public string Column_ShortTitle { get; set; }

        //[DisplayName("Etat")]
        //public bool? Column_ShortTitle { get; set; }


    }
}
