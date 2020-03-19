using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Database
{
    public class BaseLogAttribute : Attribute
    { }

    public class LogEntryAttributeKey : BaseLogAttribute
    { }
    public class LogEntryAttributeValue : BaseLogAttribute
    { }
    public class DBLoggingAttribute:Attribute
    {
        private string _EntityName;

        public string EntityName
        {
            get { return _EntityName; }
            set { _EntityName = value; }
        }
        public DBLoggingAttribute(string EntityName)
        {
            _EntityName = EntityName;
        }
    }
    public class LogAttributes : BaseLogAttribute
    {
        private bool _LogMe;
        private bool _OnNew;
        private bool _OnEdit;
        private bool _OnDelete;
        private string _QueryValue;

        public bool LogMe
        {
            get { return _LogMe; }
            set { _LogMe = value; }
        }

        public bool OnNew
        {
            get { return _OnNew; }
            set { _OnNew = value; }
        }

        public bool OnEdit
        {
            get { return _OnEdit; }
            set { _OnEdit = value; }
        }

        public bool OnDelete
        {
            get { return _OnDelete; }
            set { _OnDelete = value; }
        }

        public string QueryValue
        {
            get { return _QueryValue; }
            set { _QueryValue = value; }
        }

        public LogAttributes(bool logme, bool onnew, bool onedit, bool ondelete, string queryvalue = "")
        {
            _LogMe = logme;
            _OnNew = onnew;
            _OnEdit = onedit;
            _OnDelete = ondelete;
            _QueryValue = queryvalue;
        }
    }
}
