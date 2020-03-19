using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class Tables : SynapseEntity<Tables>
    {
        private static string _query = "SELECT * FROM [SynapseReport_TABLES]";
        private static string _tableName = "[SynapseReport_TABLES]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

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

        private Int64 _FK_REPORT;
        public Int64 FK_REPORT
        {
            get { return _FK_REPORT; }
            set { _FK_REPORT = value; }
        }
    }
}
