using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class TablesAndViews : SynapseEntity<TablesAndViews>
    {
        private static string _query = "SELECT * FROM [SYS.TABLES]";
        private static string _tableName = "[SYS.TABLES]";
        private static string _IDproperty = "OBJECT_ID";
        private static string _EcludeForSave = "||";

        private string _TABLENAME;
        public string TABLENAME
        {
            get { return _TABLENAME; }
            set { _TABLENAME = value; }
        }

        private string _TYPE;
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
    }
}
