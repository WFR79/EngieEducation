using System;

namespace SynapseCore.Entities
{
    public class SynapseLanguage : SynapseEntity<SynapseLanguage>
    {
        private static string _query = "SELECT * FROM [Synapse_Language]";
        private static string _tableName = "[Synapse_Security_Language]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";
        static SynapseLanguage()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
        public SynapseLanguage()
        {
        }
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _CODE;

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        private string _LABEL;

        public string LABEL
        {
            get { return _LABEL; }
            set { _LABEL = value; }
        }
        private string _CULTURE;

        public string CULTURE
        {
            get { return _CULTURE; }
            set { _CULTURE = value; }
        }
    }
}
