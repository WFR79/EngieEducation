using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace SynapseCore.Entities
{
    public class LogValue : SynapseEntity<LogValue>
    {

        private static string _tableName = "[Lofc_LOGVALUE]";
        private static string _query = "SELECT * FROM "+_tableName;
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|OBJECT_NAME|TableName|";
        public static string TableName
        {
            get { return LogValue._tableName; }
            set
            {
                _query = "SELECT * FROM " + value;
                LogValue._tableName = value;
            }
        }
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private String _FIELD;

        public String FIELD
        {
            get { return _FIELD; }
            set { _FIELD = value; }
        }

        private String _OLD_VALUE;

        public String OLD_VALUE
        {
            get { return _OLD_VALUE; }
            set { _OLD_VALUE = value; }
        }

        private String _NEW_VALUE;

        public String NEW_VALUE
        {
            get { return _NEW_VALUE; }
            set { _NEW_VALUE = value; }
        }

        private Int64 _FK_LOGENTRY;

        public Int64 FK_LOGENTRY
        {
            get { return _FK_LOGENTRY; }
            set { _FK_LOGENTRY = value; }
        }

        public String OBJECT_NAME
        {
            get { return _FIELD; }
            set { _FIELD = value; }
        }
    }
}
