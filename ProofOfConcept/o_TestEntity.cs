using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace ProofOfConcept
{
    [DBConnectionAttribute("WSS")]
    public class o_TestEntity:SynapseEntity<o_TestEntity>
    {
        private static string _query = "SELECT * FROM applications";
        private static string _tableName = "applications";
        private static string _IDproperty = "Application_id";
        private static string _EcludeForSave = "||";
        private Decimal _application_id;

        public Decimal Application_id
        {
            get { return _application_id; }
            set { _application_id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Decimal _category_id;

        public Decimal Category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }
    }
}
