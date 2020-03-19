using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Database;

namespace ProofOfConcept
{
    //[DBConnectionAttribute("Dosiview (Production2)")]
    //[DBConnectionAttribute("Dosiview (Test)")]
    [DBConnectionAttribute("Dosiview")]
    public class o_Agent:SynapseCore.Entities.SynapseEntity<o_Agent>
    {
        private static string _query = "SELECT * FROM Agent";
        private static string _tableName = "Agent";
        private static string _IDproperty = "NUMAGT";
        private static string _EcludeForSave = "||";

        private Decimal _NUMAGT;

        public Decimal NUMAGT
        {
            get { return _NUMAGT; }
            set { _NUMAGT = value; }
        }

        private string _NOM;

        public string NOM
        {
            get { return _NOM; }
            set { _NOM = value; }
        }
        private string _ADRESSE;

        public string ADRESSE
        {
            get { return _ADRESSE; }
            set { _ADRESSE = value; }
        }
        private string _CODPOST;

        public string CODPOST
        {
            get { return _CODPOST; }
            set { _CODPOST = value; }
        }
        private string _VILLE;

        public string VILLE
        {
            get { return _VILLE; }
            set { _VILLE = value; }
        }
        private DateTime _D_NAI;

        public DateTime D_NAI
        {
            get { return _D_NAI; }
            set { _D_NAI = value; }
        }

        public Int64 AGE
        {
            get { return (Int64)(DateTime.Now - _D_NAI).TotalDays / 365; }
        }

        
        private Decimal _SEXE;


        public Decimal SEXE
        {
            get { return _SEXE; }
            set { _SEXE = value; }
        }
        private string _PRENOM;

        public string PRENOM
        {
            get { return _PRENOM; }
            set { _PRENOM = value; }
        }

        private Decimal _typ_emp;

        public Decimal Typ_emp
        {
            get { return _typ_emp; }
            set { _typ_emp = value; }
        }

    }
}
