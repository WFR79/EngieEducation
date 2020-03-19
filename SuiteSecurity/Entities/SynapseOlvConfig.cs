using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Entities
{
    public class SynapseOlvConfig:SynapseEntity<SynapseOlvConfig>
    {
        private static string _query = "SELECT * FROM [Synapse_OlvConfig]";
        private static string _tableName = "[Synapse_OlvConfig]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|TEXT|";

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
        private Int64 _MODULEID;

        public Int64 MODULEID
        {
            get { return _MODULEID; }
            set { _MODULEID = value; }
        }
        private string _OLVKEY;

        public string OLVKEY
        {
            get { return _OLVKEY; }
            set { _OLVKEY = value; }
        }
        private byte[] _CONFIG;

        public byte[] CONFIG
        {
            get { return _CONFIG; }
            set { _CONFIG = value; }
        }
    }
}
