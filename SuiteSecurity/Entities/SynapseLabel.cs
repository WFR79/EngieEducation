using System;
using SynapseCore.Database;

namespace SynapseCore.Entities
{
    public class SynapseLabel : SynapseEntity<SynapseLabel>
    {
        private static string _query = "SELECT * FROM [Synapse_Label]";
        private static string _tableName = "[Synapse_Label]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        static SynapseLabel()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
        public SynapseLabel()
        {

        }

        public static Int64 GetNextID()
        {
            return (Int64)DBFunction.ExecuteScalarQuery("Select max(LABELID) from " + _tableName) + 1;
        }

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private Int64 _LABELID;

        public Int64 LABELID
        {
            get { return _LABELID; }
            set { _LABELID = value; }
        }


        private string _LANGUAGE;

        public string LANGUAGE
        {
            get { return _LANGUAGE; }
            set { _LANGUAGE = value; }
        }
        private string _TEXT;

        public string TEXT
        {
            get { return _TEXT; }
            set { _TEXT = value; }
        }
    }
}
