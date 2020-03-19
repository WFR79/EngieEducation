using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynapseCore.Entities
{
    public class SynapseInterface:SynapseEntity<SynapseInterface>
    {
        private static string _query = "SELECT * FROM [Synapse_Interface]";
        private static string _tableName = "[Synapse_Interface]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|TEXT|";

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TECHNICALNAME;

        public string TECHNICALNAME
        {
            get { return _TECHNICALNAME; }
            set { _TECHNICALNAME = value; }
        }

        public string FriendlyName
        {
            get { return _TECHNICALNAME; }
        }

        private int _TYPE;

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private string _CONNECTIONSTRING;

        public string CONNECTIONSTRING
        {
            get { return _CONNECTIONSTRING; }
            set { _CONNECTIONSTRING = value; }
        }

        private string _DBTYPE;

        public string DBTYPE
        {
            get { return _DBTYPE; }
            set { _DBTYPE = value; }
        }

        private string _TABLESQUERY;

        public string TABLESQUERY
        {
            get { return _TABLESQUERY; }
            set { _TABLESQUERY = value; }
        }
        private string _VIEWSQUERY;

        public string VIEWSQUERY
        {
            get { return _VIEWSQUERY; }
            set { _VIEWSQUERY = value; }
        }
        private string _FIELDSQUERY;

        public string FIELDSQUERY
        {
            get { return _FIELDSQUERY; }
            set { _FIELDSQUERY = value; }
        }

        private string _ORACLE_HOME;

        public string ORACLE_HOME
        {
            get { return _ORACLE_HOME; }
            set { _ORACLE_HOME = value; }
        }

        public static IList<SynapseInterface> LoadAvailable()
        {
            return Load("WHERE SYNAPSEPROFILE in ('"+string.Join("','",(from g in SynapseCore.Controls.SynapseForm.FormUser.Groups select g.TECHNICALNAME).ToArray())+"') OR SYNAPSEPROFILE = 'Everybody'");
        }
    }
}
