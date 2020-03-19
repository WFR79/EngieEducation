using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace SynapseACC.Entities
{
    [DBConnection("Synapse ACC")]
    public class ACCSynapseLabel : SynapseEntity<ACCSynapseLabel>
    {
        private static string _query = "SELECT * FROM [Synapse_Label]";
        private static string _tableName = "[Synapse_Label]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";
        
        static ACCSynapseLabel()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
        public ACCSynapseLabel()
        {

        }

        public static Int64 GetNextID()
        {
            return (Int64)DBFunction.ExecuteScalarQuery("Select max(LABELID) from " + _tableName)+1;
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

        //public static SynapseLabel LoadByID(Int64 ID)
        //{
        //    return DBFunction.GetTableFromQuery(_query + " WHERE " + _IDproperty + " = " + ID.ToString()).ToEntity<SynapseLabel>();
        //}

        //public static IList<SynapseLabel> Load()
        //{
        //    return Load(string.Empty);

        //}
        //public static IList<SynapseLabel> Load(string filter)
        //{
        //    string sql = _query;
        //    if (filter != string.Empty)
        //        sql += " " + filter;
        //    return LoadFromQuery(sql);


        //}
        //public static IList<SynapseLabel> LoadFromQuery(string query)
        //{
        //    return DBFunction.GetTableFromQuery(query).ToListOfEntities<SynapseLabel>();
        //}

        //public void save()
        //{
        //    DBFunction.SaveEntityToDB(this, _tableName, _IDproperty, _EcludeForSave);
        //}

    }

    
}
