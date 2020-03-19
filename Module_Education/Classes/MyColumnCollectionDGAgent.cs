using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    class MyColumnCollectionDGAgent
    {
        [DisplayName("Matricule")]
        public int? ColumnUser_Matricule { get; set; }

        //[DisplayName("User ID")]
        //public long ColumnUserId { get; set; }
        [DisplayName("Prénom")]
        public string ColumnFirstName { get; set; }

        [DisplayName("Nom")]
        public string ColumnUser_Name { get; set; }

        [DisplayName("Fonction")]
        public string ColumnFunction { get; set; }

        [DisplayName("Responsable")]
        public string ColumnResponsable { get; set; }

        [DisplayName("Admin")]
        public string ColumnAdmin { get; set; }

        [DisplayName("Education_Habilitation")]
        public string ColumnEducation_Habilitation { get; set; }

        [DisplayName("Chargé de travaux")]
        public bool? ColumnChargeTravaux { get; set; }

        [DisplayName("Date d'entrée")]
        public DateTime? ColumnDateEntry { get; set; }

        [DisplayName("Date d'ancienneté")]
        public DateTime? ColumnDateSenioritiy { get; set; }

        [DisplayName("Dernière prise de fonction")]
        public DateTime? ColumnDateFunction { get; set; }

        [DisplayName("Statut")]
        public string ColumnStatut { get; set; }

        [DisplayName("Etat")]
        public bool? ColumnEtat { get; set; }

        private Education_Agent _obj;

        public MyColumnCollectionDGAgent(Education_Agent obj)
        {
            _obj = obj;
        }

        public Education_Agent GetModel()
        {
            return _obj;
        }
    }
}
