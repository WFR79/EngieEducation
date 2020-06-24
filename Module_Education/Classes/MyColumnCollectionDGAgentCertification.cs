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
    class MyColumnCollectionDGAgentCertification
    {
        /// <summary>
        /// Agent 
        /// </summary>
        [DisplayName("Matricule")]
        public int? Agent_Matricule { get; set; }

        [DisplayName("Nom Prénom")]
        public string Agent_Fullname { get; internal set; }

        [DisplayName("Prénom")]
        public string Agent_FirstName { get; set; }

        [DisplayName("Nom")]
        public string Agent_Name { get; set; }

        [DisplayName("Département")]
        public string Agent_Departement { get; set; }

        [DisplayName("Service")]
        public string Agent_Service { get; set; }

        [DisplayName("Affectation")]
        public string Agent_SousService { get; set; }

        [DisplayName("Etat")]
        public bool? Agent_Etat { get; set; }

        [DisplayName("Date Entrée")]
        public DateTime? Agent_EntryDate { get; set; }

        [DisplayName("Date dernière prise de fonction")]
        public DateTime? Agent_LastFunctionDate { get; set; }
        [DisplayName("Statut")]
        public string Agent_Statut { get; set; }
        [DisplayName("Fonction")]
        public string Agent_Fonction { get; set; }
        [DisplayName("Admin")]
        public string Agent_Admin { get; set; }

        /// <summary>
        /// Passport Safety
        /// </summary>
        /// 

        [DisplayName("Niveau PS")]
        public int? PassportSafety_LevelPS { get; set; }

        [DisplayName("Date envoi")]
        public DateTime? SendingDate { get; internal set; }

        [DisplayName("Date retour")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("Certification hiérarchie")]
        public bool? Certif_Hierarchie { get; set; }
        [DisplayName("Remarques ")]
        public string PassportRemarks { get; set; }
        [DisplayName("Remarque paiement safety")]
        public string PassportRemarkPay { get; set; }


        /// <summary>
        /// Passport Metier 
        /// </summary>
        [DisplayName("Description Métier")]
        public string Description { get; set; }

        [DisplayName("Date envoi")]
        public DateTime? SendingDatePassportBusiness { get; internal set; }

        [DisplayName("Date retour")]
        public DateTime? ReturnDatePassportBusiness { get; set; }

        [DisplayName("Certification hiérarchie")]
        public bool? Certif_HierarchiePassportBusiness { get; set; }
        [DisplayName("Remarques ")]
        public string PassportRemarksPassportBusiness { get; set; }

        /// <summary>
        /// Certificat Electrique fonction
        /// </summary>µ

        [DisplayName("Niveau B")]
        public string NiveauB { get; set; }

        [DisplayName("Date d'envoi B")]
        public DateTime? SendingDateCertifElecFunc { get; internal set; }

        [DisplayName("Certif reçue B")]
        public DateTime? ReturnDateCertifElecFunc { get; set; }

        [DisplayName("Certifié OUI/NON ")]
        public bool? Certif_HierarchieCertifElecFunc { get; set; }

        [DisplayName("Date Validité Certification")]
        public DateTime? ValidityDateCertifElecFunc { get; set; }
        [DisplayName("Remarques B2")]
        public string RemarksCertifElecFunc { get; set; }

        /// <summary>
        /// Certificat Electrique OPP
        /// </summary>µ

        [DisplayName("Niveau R")]
        public string NiveauR { get; set; }

        [DisplayName("Date d'envoi R")]
        public DateTime? SendingDateCertifElecOPP { get; internal set; }

        [DisplayName("Certif reçue R")]
        public DateTime? ReturnDateCertifElecOPP { get; set; }

        [DisplayName("Certifié OUI/NON ")]
        public bool? Certif_HierarchieCertifElecOPP { get; set; }

        [DisplayName("Date Validité Certification R")]
        public DateTime? ValidityDateCertifElecOPP { get; set; }
        [DisplayName("Remarques R")]
        public string RemarksCertifElecOPP { get; set; }

        /// <summary>
        /// Passport DESIGN
        /// </summary>
        /// 

        [DisplayName("Type Passport")]
        public string TypePAssport { get; set; }

        [DisplayName("Date envoi")]
        public DateTime? SendingDatePassportDesign { get; internal set; }

        [DisplayName("Date retour")]
        public DateTime? ReturnDatePassportDesign { get; set; }
        [DisplayName("Certifié OUI/NON ")]
        public bool? Certif_HierarchiePassportDesign { get; set; }
        [DisplayName("Remarques ")]
        public string RemarksPassportDesign { get; set; }


        private Education_Agent _obj;

        public MyColumnCollectionDGAgentCertification(Education_Agent obj)
        {
            try
            {
                _obj = obj;
            }
            catch (Exception ex) {
            }
        }

        public Education_Agent GetModel()
        {
            return _obj;
        }
    }
}
