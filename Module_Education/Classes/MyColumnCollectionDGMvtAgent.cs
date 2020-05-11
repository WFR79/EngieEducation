using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education
{
    class MyColumnCollectionDGMvtAgent
    {
        [DisplayName("AgentId")]
        public long? mvt_AgentId { get; set; }

        [DisplayName("MvtTypeId")]
        public long? mvttypeId { get; set; }

        [DisplayName("Admin pour Action")]
        public string mvt_Admin { get; set; }

        [DisplayName("Nom Agent")]
        public string mvt_agent { get; internal set; }

        [DisplayName("Date demande")]
        public DateTime? mvt_Date { get; set; }

        [DisplayName("Mouvement à faire")]
        public string mvt_TypeName { get; set; }

        [DisplayName("Service actuel")]
        public string mvt_ServiceActual { get; set; }

        [DisplayName("LH actuel")]
        public string mvt_LHActual { get; set; }

        [DisplayName("Service futur")]
        public string mvt_ServiceFutur { get; set; }

        [DisplayName("LH Futur")]
        public string mvt_LHFutur { get; set; }

        [DisplayName("TC pour action")]
        public string mvt_TC { get; set; }

        [DisplayName("Action Admin OPP nécessaire")]
        public string mvt_OPP { get; set; }

        [DisplayName("Etat")]
        public string mvt_statut { get; set; }

        private Education_MovementAgent _obj;

        public MyColumnCollectionDGMvtAgent(Education_MovementAgent obj)
        {
            _obj = obj;
        }

        public Education_MovementAgent GetModel()
        {
            return _obj;
        }
    }
}
