using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class TableField : SynapseEntity<TableField>
    {
        private static string _query = "SELECT * FROM [SYS.ALL_COLUMNS]";
        private static string _tableName = "[SYS.ALL_COLUMNS]";
        private static string _IDproperty = "OBJECT_ID";
        private static string _EcludeForSave = "||";

        private string _TABLENAME;
        public string TABLENAME
        {
            get { return _TABLENAME; }
            set { _TABLENAME = value; }
        }

        private string _FIELDNAME;
        public string FIELDNAME
        {
            get { return _FIELDNAME; }
            set { _FIELDNAME = value; }
        }

        private string _FIELDTYPE;
        public string FIELDTYPE
        {
            get { return _FIELDTYPE; }
            set { _FIELDTYPE = value; }
        }
    }
}
