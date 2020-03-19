using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class ExtraLineField : SynapseEntity<ExtraLineField>
    {
        private static string _query = "SELECT * FROM [SynapseReport_EXTRALINE_FIELD]";
        private static string _tableName = "[SynapseReport_EXTRALINE_FIELD]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private Int32 _POSITION;
        public Int32 POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
        }

        private string _FUNCTIONCODE;
        public string FUNCTIONCODE
        {
            get { return _FUNCTIONCODE; }
            set { _FUNCTIONCODE = value; }
        }

        private string _FORMAT;
        public string FORMAT
        {
            get { return _FORMAT; }
            set { _FORMAT = value; }
        }

        private Int64 _FK_EXTRALINE;
        public Int64 FK_EXTRALINE
        {
            get { return _FK_EXTRALINE; }
            set { _FK_EXTRALINE = value; }
        }
    }
}
