using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseReport.Entities
{
    public class Field : SynapseEntity<Field>
    {
        private static string _query = "SELECT * FROM [SynapseReport_FIELDS]";
        private static string _tableName = "[SynapseReport_FIELDS]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "ALIAS||";

        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _FIELDNAME;
        public string FIELDNAME
        {
            get { return _FIELDNAME; }
            set { _FIELDNAME = value; }
        }

        private LabelBag _Alias;
        [LabelId("ALIASID")]
        public LabelBag ALIAS
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        private Int64 _ALIASID;
        public Int64 ALIASID
        {
            get { return _ALIASID; }
            set { _ALIASID = value; }
        }

        private string _FORMAT;
        public string FORMAT
        {
            get { return _FORMAT; }
            set { _FORMAT = value; }
        }

        private Int64 _FK_REPORT;
        public Int64 FK_REPORT
        {
            get { return _FK_REPORT; }
            set { _FK_REPORT = value; }
        }

        private Int32 _POSITION;
        public Int32 POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
        }

        private Int32 _WIDTH;
        public Int32 WIDTH
        {
            get { return _WIDTH; }
            set { _WIDTH = value; }
        }

        private string _SORTING;
        public string SORTING
        {
            get { return _SORTING; }
            set { _SORTING = value; }
        }

        private Int32? _SORTING_ORDER;
        public Int32? SORTING_ORDER
        {
            get { return _SORTING_ORDER; }
            set { _SORTING_ORDER = value; }
        }

        private string _COLORWHAT;
        public string COLORWHAT
        {
            get { return _COLORWHAT; }
            set { _COLORWHAT = value; }
        }

        private string _COLORNAME;
        public string COLORNAME
        {
            get { return _COLORNAME; }
            set { _COLORNAME = value; }
        }

        private string _COLORCONDITION;
        public string COLORCONDITION
        {
            get { return _COLORCONDITION; }
            set { _COLORCONDITION = value; }
        }

        private string _COLORCONVERTION;
        public string COLORCONVERTION
        {
            get { return _COLORCONVERTION; }
            set { _COLORCONVERTION = value; }
        }

        private string _COLORVALUE;
        public string COLORVALUE
        {
            get { return _COLORVALUE; }
            set { _COLORVALUE = value; }
        }
    }
}
