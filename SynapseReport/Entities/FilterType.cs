using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class FilterType : SynapseEntity<FilterType>
    {
        private static string _query = "SELECT * FROM [SynapseReport_FILTER_TYPE]";
        private static string _tableName = "[SynapseReport_FILTER_TYPE]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TYPE;
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }

        private bool _HASDATA;
        public bool HASDATA
        {
            get { return _HASDATA; }
            set { _HASDATA = value; }
        }
    }
}
