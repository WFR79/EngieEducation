/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 10:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseControl.
    /// </summary>
    public class SynapseControl : SynapseEntity<SynapseControl>
    {
        private static string _query = "SELECT * FROM [Synapse_Security_Control]";
        private static string _tableName = "[Synapse_Security_Control]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        static SynapseControl()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

        public SynapseControl()
        {
        }
        private Int64 _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _FORM_NAME;

        public string FORM_NAME
        {
            get { return _FORM_NAME; }
            set { _FORM_NAME = value; }
        }
        private string _CTRL_NAME;

        public string CTRL_NAME
        {
            get { return _CTRL_NAME; }
            set { _CTRL_NAME = value; }
        }
        private string _CTRL_TYPE;

        public string CTRL_TYPE
        {
            get { return _CTRL_TYPE; }
            set { _CTRL_TYPE = value; }
        }
        private Int64 _FK_MODULE_ID;

        public long FK_MODULE_ID
        {
            get { return _FK_MODULE_ID; }
            set { _FK_MODULE_ID = value; }
        }
    }
}
