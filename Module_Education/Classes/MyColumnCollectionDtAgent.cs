using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    class MyColumnCollectionDtAgent
    {
            [DisplayName("Matricule")]
            public int? Agent_Matricule { get; set; }

            [DisplayName("Nom Prénom")]
            public string Agent_Fullname { get; internal set; }

            [DisplayName("Prénom")]
            public string Agent_FirstName { get; set; }

            [DisplayName("Nom")]
            public string Agent_Name { get; set; }

            [DisplayName("Fonction")]
            public string Function_Name { get; set; }

            [DisplayName("Responsable")]
            public string Agent_Responsable { get; set; }

            [DisplayName("Admin")]
            public string Agent_Admin { get; set; }

            [DisplayName("Habilitation")]
            public string Agent_Habilitation { get; set; }

            [DisplayName("Chargé de travaux")]
            public bool? Agent_IsWorkManager { get; set; }

            [DisplayName("Date d'entrée")]
            public DateTime? Agent_DateOfEntry { get; set; }

            [DisplayName("Date d'ancienneté")]
            public DateTime? Agent_DateSeniority { get; set; }

            [DisplayName("Dernière prise de fonction")]
            public DateTime? Agent_DateFunction { get; set; }

            [DisplayName("Statut")]
            public string Agent_Status { get; set; }

            [DisplayName("Etat")]
            public bool? Agent_Etat { get; set; }

            [DisplayName("En trajet")]
            public bool? Agent_InRoute { get; set; }



            private DataTable _obj;

            public MyColumnCollectionDtAgent(DataTable obj)
            {
                _obj = obj;
            }

            public DataTable GetModel()
            {
                return _obj;
            }
        }
}
