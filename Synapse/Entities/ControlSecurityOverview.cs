using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;

namespace Synapse.Entities
{
    class ControlSecurityOverview:SynapseEntity<ControlSecurityOverview>
    {
        private static string _query = "SELECT DISTINCT (CASE WHEN [Synapse_Security_Profile].TECHNICALNAME IS NULL AND [Synapse_Security_Profile].[ID] IS NULL THEN 'Everybody' ELSE Synapse_Security_Profile.TECHNICALNAME END) AS [GROUP], dbo.Synapse_Security_Control.FORM_NAME AS FORM, dbo.Synapse_Security_Control.CTRL_TYPE AS TYPE, dbo.Synapse_Security_Control.CTRL_NAME AS CONTROL, (CASE WHEN [Synapse_Security_Profile].[ID] IS NULL THEN 'True' ELSE IS_VISIBLE END) AS VISIBLE, (CASE WHEN [Synapse_Security_Profile].[ID] IS NULL THEN 'True' ELSE [Synapse_Security_Profile Control].IS_ACTIVE END) AS ACTIVE, dbo.Synapse_Module.TECHNICALNAME AS MODULE, dbo.Synapse_Module.ID AS MODULEID FROM dbo.Synapse_Security_Control INNER JOIN dbo.Synapse_Module ON dbo.Synapse_Security_Control.FK_MODULE_ID = dbo.Synapse_Module.ID LEFT OUTER JOIN dbo.[Synapse_Security_Profile Control] INNER JOIN dbo.Synapse_Security_Profile ON dbo.[Synapse_Security_Profile Control].FK_PROFILEID = dbo.Synapse_Security_Profile.ID ON dbo.Synapse_Security_Control.ID = dbo.[Synapse_Security_Profile Control].FK_CONTROLID LEFT OUTER JOIN dbo.Synapse_Security_User INNER JOIN dbo.[Synapse_Security_User Profile] ON dbo.Synapse_Security_User.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_USER ON dbo.Synapse_Security_Profile.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE";
        private static string _tableName = "[]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        private string _Comment;

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        
        private string _GROUP;

        public string GROUP
        {
            get { return _GROUP; }
            set { _GROUP = value; }
        }
        private string _FORM;

        public string FORM
        {
            get { return _FORM; }
            set { _FORM = value; }
        }
        private string _TYPE;

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private Int64 _MODULEID;

        public Int64 MODULEID
        {
            get { return _MODULEID; }
            set { _MODULEID = value; }
        }

        private string _MODULE;

        public string MODULE
        {
            get { return _MODULE; }
            set { _MODULE = value; }
        }
        private string _CONTROL;

        public string CONTROL
        {
            get { return _CONTROL; }
            set { _CONTROL = value; }
        }
        private bool _VISIBLE;

        public bool VISIBLE
        {
            get { return _VISIBLE; }
            set { _VISIBLE = value; }
        }
        private bool _ACTIVE;

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }

    }
}
