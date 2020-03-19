using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    public class Definition : SynapseEntity<Definition>
    {
        private static string _query = "SELECT * FROM [SynapseReport_DEFINITION]";
        private static string _tableName = "[SynapseReport_DEFINITION]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "LABEL||CATEGORY||CATEGORYLABELID";

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

        private Int64 _FK_CATEGORY;
        public Int64 FK_CATEGORY
        {
            get { return _FK_CATEGORY; }
            set { _FK_CATEGORY = value; }
        }

        private LabelBag _Category;
        [LabelId("CATEGORYLABELID")]
        public LabelBag CATEGORY
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private Int64 _CATEGORYLABELID;
        public Int64 CATEGORYLABELID
        {
            get { return _CATEGORYLABELID; }
            set { _CATEGORYLABELID = value; }
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

        private bool _AVAILABLE;
        public bool AVAILABLE
        {
            get { return _AVAILABLE; }
            set { _AVAILABLE = value; }
        }

        private string _QRY_JOIN;
        public string QRY_JOIN
        {
            get { return _QRY_JOIN; }
            set { _QRY_JOIN = value; }
        }

        private string _QRY_CONDITION;
        public string QRY_CONDITION
        {
            get { return _QRY_CONDITION; }
            set { _QRY_CONDITION = value; }
        }

        private string _QRY_GROUP;
        public string QRY_GROUP
        {
            get { return _QRY_GROUP; }
            set { _QRY_GROUP = value; }
        }

        private Int64 _FK_TYPE;
        public Int64 FK_TYPE
        {
            get { return _FK_TYPE; }
            set { _FK_TYPE = value; }
        }

        private bool _ADDCATEGORY;
        public bool ADDCATEGORY
        {
            get { return _ADDCATEGORY; }
            set { _ADDCATEGORY = value; }
        }
    }
}
