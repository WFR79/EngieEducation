using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace SynapseCore.Entities
{
    public class LogEntry : SynapseEntity<LogEntry>
    {
        private static string _tableName = "[Lofc_LOGENTRY]";

        public static string TableName
        {
            get { return LogEntry._tableName; }
            set {
                _query = "SELECT * FROM " + value;
                LogEntry._tableName = value; }
        }
        private static string _query = "SELECT * FROM "+TableName;
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|TableName|";

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private DateTime _TIMESTAMP;

        public DateTime TIMESTAMP
        {
            get { return _TIMESTAMP; }
            set { _TIMESTAMP = value; }
        }

        private String _USERID;

        public String USERID
        {
            get { return _USERID; }
            set { _USERID = value; }
        }

        private String _ACTION_CODE;

        public String ACTION_CODE
        {
            get { return _ACTION_CODE; }
            set { _ACTION_CODE = value; }
        }

        private String _OBJECT_NAME;

        public String OBJECT_NAME
        {
            get { return _OBJECT_NAME; }
            set { _OBJECT_NAME = value; }
        }

        private String _OBJECT_VALUE;

        public String OBJECT_VALUE
        {
            get { return _OBJECT_VALUE; }
            set { _OBJECT_VALUE = value; }
        }

        private string _LOGKEY;

        public string LOGKEY
        {
            get { return _LOGKEY; }
            set { _LOGKEY = value; }
        }
    }
}
