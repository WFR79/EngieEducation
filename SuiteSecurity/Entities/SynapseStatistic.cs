using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
namespace SynapseCore.Entities
{
    class SynapseStatistic:SynapseEntity<SynapseStatistic>
    {
        private static string _query = "SELECT * FROM [Synapse_Statistics]";
        private static string _tableName = "[Synapse_Statistics]";
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
        private Int64 _FK_MODULE_ID;

        public Int64 FK_MODULE_ID
        {
            get { return _FK_MODULE_ID; }
            set { _FK_MODULE_ID = value; }
        }
        private string _FORMNAME;

        public string FORMNAME
        {
            get { return _FORMNAME; }
            set { _FORMNAME = value; }
        }
        private DateTime _OPEN_TIME;

        public DateTime OPEN_TIME
        {
            get { return _OPEN_TIME; }
            set { _OPEN_TIME = value; }
        }
        private DateTime _CLOSE_TIME;

        public DateTime CLOSE_TIME
        {
            get { return _CLOSE_TIME; }
            set { _CLOSE_TIME = value; }
        }
        private Int64 _ACTIVITY_TIME;

        public Int64 ACTIVITY_TIME
        {
            get { return _ACTIVITY_TIME; }
            set { _ACTIVITY_TIME = value; }
        }
        private Int64 _OPENED_TIME;

        public Int64 OPENED_TIME
        {
            get { return _OPENED_TIME; }
            set { _OPENED_TIME = value; }
        }


    }
}
