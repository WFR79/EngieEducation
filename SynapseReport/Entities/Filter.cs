using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class Filter : SynapseEntity<Filter>
    {
        private static string _query = "SELECT * FROM [SynapseReport_FILTERS]";
        private static string _tableName = "[SynapseReport_FILTERS]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "LABEL||";

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

        private string _TYPE;
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }

        private Int32 _POSITION;
        public Int32 POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
        }

        private string _CTRL_TABLE;
        public string CTRL_TABLE
        {
            get { return _CTRL_TABLE; }
            set { _CTRL_TABLE = value; }
        }

        private string _CTRL_FIELD;
        public string CTRL_FIELD
        {
            get { return _CTRL_FIELD; }
            set { _CTRL_FIELD = value; }
        }

        private string _CTRL_TYPE;
        public string CTRL_TYPE
        {
            get { return _CTRL_TYPE; }
            set { _CTRL_TYPE = value; }
        }

        private string _CTRL_CUSTOM;
        public string CTRL_CUSTOM
        {
            get { return _CTRL_CUSTOM; }
            set { _CTRL_CUSTOM = value; }
        }

        private string _DATA_TABLE;
        public string DATA_TABLE
        {
            get { return _DATA_TABLE; }
            set { _DATA_TABLE = value; }
        }

        private string _DATA_VALUE;
        public string DATA_VALUE
        {
            get { return _DATA_VALUE; }
            set { _DATA_VALUE = value; }
        }

        private string _DATA_DISPLAY;
        public string DATA_DISPLAY
        {
            get { return _DATA_DISPLAY; }
            set { _DATA_DISPLAY = value; }
        }

        private string _DATA_QUERY;
        public string DATA_QUERY
        {
            get { return _DATA_QUERY; }
            set { _DATA_QUERY = value; }
        }

        private Int32 _WIDTH;
        public Int32 WIDTH
        {
            get { return _WIDTH; }
            set { _WIDTH = value; }
        }

        private Int64 _FK_REPORT;
        public Int64 FK_REPORT
        {
            get { return _FK_REPORT; }
            set { _FK_REPORT = value; }
        }

        private bool _IS_LINKED;
        public bool IS_LINKED
        {
            get { return _IS_LINKED; }
            set { _IS_LINKED = value; }
        }

        private Int64 _LINKED_FILTERID;
        public Int64 LINKED_FILTERID
        {
            get { return _LINKED_FILTERID; }
            set { _LINKED_FILTERID = value; }
        }

        private string _LINKED_FIELD;
        public string LINKED_FIELD
        {
            get { return _LINKED_FIELD; }
            set { _LINKED_FIELD = value; }
        }

        private bool _ADD_TO_REPORTTITLE;
        public bool ADD_TO_REPORTTITLE
        {
            get { return _ADD_TO_REPORTTITLE; }
            set { _ADD_TO_REPORTTITLE = value; }
        }
    }
}
