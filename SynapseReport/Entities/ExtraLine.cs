using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class ExtraLine : SynapseEntity<ExtraLine>
    {
        private static string _query = "SELECT * FROM [SynapseReport_EXTRALINE]";
        private static string _tableName = "[SynapseReport_EXTRALINE]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "LABEL||LINEFIELDS";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _NAME;
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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

        private Int32 _POSITION;
        public Int32 POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
        }

        private Int64 _FK_REPORT;
        public Int64 FK_REPORT
        {
            get { return _FK_REPORT; }
            set { _FK_REPORT = value; }
        }

        private List<ExtraLineField> _LINEFIELDS;
        public List<ExtraLineField> LINEFIELDS
        {
            get { return _LINEFIELDS; }
            set { _LINEFIELDS = value; }
        }
    }
}
