
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace Synapse.Entities
{
    class SynapseFavorite:SynapseEntity<SynapseFavorite>
    {
        private static string _query = "SELECT * FROM [Synapse_Favorites]";
        private static string _tableName = "[Synapse_Favorites]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _USERID;

        public string USERID
        {
            get { return _USERID; }
            set { _USERID = value; }
        }
        private string _TEXT;

        public string TEXT
        {
            get { return _TEXT; }
            set { _TEXT = value; }
        }
        private string _PATH;

        public string PATH
        {
            get { return _PATH; }
            set { _PATH = value; }
        }
        private string _TECHNICALNAME;

        public string TECHNICALNAME
        {
            get { return _TECHNICALNAME; }
            set { _TECHNICALNAME = value; }
        }
        private Int64 _FAVTYPE;

        public Int64 FAVTYPE
        {
            get { return _FAVTYPE; }
            set { _FAVTYPE = value; }
        }

    }
}
