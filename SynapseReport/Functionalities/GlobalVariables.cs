using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using SynapseCore.Database;
using SynapseReport.Functionalities;

namespace SynapseReport.Functionalities
{
    public enum Origin
    {
        Module=1,
        Interface=2
    }

    public enum DatabaseType
    {
        SQLServer = 1,
        Oracle = 2,
        Access = 3
    }

    class GlobalVariables
    {
        public static ReportOrigin selectedOrigin;
        public static Dictionary<string, string> XtraVariables = new Dictionary<string,string>();

        public static void setXtraVariables(string variables)
        {
            XtraVariables = variables.Split(',').Select(part => part.Split('=')).Where(part => part.Length == 2).ToDictionary(sp => sp[0], sp => sp[1]);
        }

        public static void setDefaultXtraVariables()
        {
           // XtraVariables.Add("[#currentsite#]","1");
        }
    }

    class ReportOrigin
    {
        // Common Properties between Module and Interface
        private string _DBCONNECTION;
        public string DBCONNECTION
        {
            get { return _DBCONNECTION; }
            set { _DBCONNECTION = value; }
        }

        private DatabaseType _DBTYPE;
        public DatabaseType DBTYPE
        {
            get { return _DBTYPE; }
            set { _DBTYPE = value; }
        }

        private string _TECHNICALNAME;
        public string TECHNICALNAME
        {
            get { return _TECHNICALNAME; }
            set { _TECHNICALNAME = value; }
        }

        private LabelBag _FriendlyName;

        [LabelId("LABELID", "TECHNICALNAME")]
        public LabelBag FriendlyName
        {
            get { return _FriendlyName; }
            set { _FriendlyName = value; }
        }

        private Origin _ORIGIN;
        public Origin ORIGIN
        {
            get { return _ORIGIN; }
            set { _ORIGIN = value; }
        }

        //Specific Properties of a Module
        private Int64 _MODULEID;
        public long MODULEID
        {
            get { return _MODULEID; }
            set { _MODULEID = value; }
        }

        //Specific Properties of an Interface
        private Int64 _INTERFACEID;
        public Int64 INTERFACEID
        {
            get { return _INTERFACEID; }
            set { _INTERFACEID = value; }
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

        public static void setTo(object obj)
        {
            if (obj.GetType().ToString() == "SynapseCore.Entities.SynapseModule")
                setTo((SynapseModule)obj);
            else
                setTo((SynapseInterface)obj);

        }

        private static void setTo(SynapseModule Mod)
        {
            ReportOrigin _reportOrigin = new ReportOrigin();
            _reportOrigin.ORIGIN = Origin.Module;
            _reportOrigin.TECHNICALNAME = Mod.TECHNICALNAME;
            _reportOrigin.DBTYPE = DatabaseType.SQLServer;
            _reportOrigin.DBCONNECTION = "Default";
            _reportOrigin.FriendlyName = Mod.FriendlyName;
            _reportOrigin._MODULEID = Mod.ID;
            _reportOrigin.INTERFACEID = 0;
            _reportOrigin._TYPE = 0;
            _reportOrigin.CONNECTIONSTRING = "";
            _reportOrigin.TABLESQUERY = "";
            _reportOrigin.VIEWSQUERY = "";
            _reportOrigin.FIELDSQUERY = "";
            _reportOrigin.ORACLE_HOME = "";

            GlobalVariables.selectedOrigin = _reportOrigin;
        }

        private static void setTo(SynapseInterface Int)
        {
            ReportOrigin _reportOrigin = new ReportOrigin();
            _reportOrigin.ORIGIN = Origin.Interface;
            _reportOrigin.TECHNICALNAME = Int.TECHNICALNAME;
            _reportOrigin.DBTYPE = (DatabaseType)Enum.Parse(typeof(DatabaseType), Int.DBTYPE, true);
            _reportOrigin.DBCONNECTION = Int.TECHNICALNAME;
            _reportOrigin.FriendlyName = new LabelBag();
            _reportOrigin.FriendlyName.Labels = new List<SynapseLabel>();

            foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
            {
                SynapseLabel newlabel = new SynapseLabel();

                newlabel.LABELID = 0;
                newlabel.LANGUAGE = lang.CODE;
                newlabel.TEXT = Int.TECHNICALNAME;
                _reportOrigin.FriendlyName.Labels.Add(newlabel);
            }

            _reportOrigin._MODULEID = 0;
            _reportOrigin.INTERFACEID = Int.ID;
            _reportOrigin._TYPE = Int.TYPE;
            _reportOrigin.CONNECTIONSTRING = Int.CONNECTIONSTRING;
            _reportOrigin.TABLESQUERY = Int.TABLESQUERY;
            _reportOrigin.VIEWSQUERY = Int.VIEWSQUERY;
            _reportOrigin.FIELDSQUERY = Int.FIELDSQUERY;
            _reportOrigin.ORACLE_HOME = Int.ORACLE_HOME;

            GlobalVariables.selectedOrigin = _reportOrigin;
        }
    }
}
