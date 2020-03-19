using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class ReportType : SynapseEntity<ReportType>
    {
        private static string _query = "SELECT * FROM [SynapseReport_TYPE]";
        private static string _tableName = "[SynapseReport_TYPE]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TYPENAME;
        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }

        private LabelBag _LABEL;
        [LabelId("LABELID")]
        public LabelBag LABEL
        {
            get { return _LABEL; }
            set { _LABEL = value; }
        }

        private Int64 _LABELID;
        public Int64 LABELID
        {
            get { return _LABELID; }
            set { _LABELID = value; }
        }

        private bool _ISGRAPH;
        public bool ISGRAPH
        {
            get { return _ISGRAPH; }
            set { _ISGRAPH = value; }
        }
    }
}
