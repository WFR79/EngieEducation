using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    class Category : SynapseEntity<Category>
    {
        private static string _query = "SELECT * FROM [SynapseReport_CATEGORY]";
        private static string _tableName = "[SynapseReport_CATEGORY]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "LABEL||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private Int64 _FK_MODULE;
        public Int64 FK_MODULE
        {
            get { return _FK_MODULE; }
            set { _FK_MODULE = value; }
        }

        private Int64 _FK_INTERFACE;
        public Int64 FK_INTERFACE
        {
            get { return _FK_INTERFACE; }
            set { _FK_INTERFACE = value; }
        }

        private LabelBag _Label;
        [LabelId("LABELID")]
        public LabelBag LABEL
        {
            get { return _Label; }
            set { _Label = value; }
        }

        private Int64 _LABELID;
        public Int64 LABELID
        {
            get { return _LABELID; }
            set { _LABELID = value; }
        }
    }
}
