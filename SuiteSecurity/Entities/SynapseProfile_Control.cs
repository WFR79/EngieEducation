/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseProfile_Control.
    /// </summary>
    public class SynapseProfile_Control : SynapseEntity<SynapseProfile_Control>
    {
        private static string _query = "SELECT * FROM [Synapse_Security_Profile Control]";
        private static string _tableName = "[Synapse_Security_Profile Control]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        static SynapseProfile_Control()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
        public SynapseProfile_Control()
        {
        }

        private Int64 _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Int64 _FK_PROFILEID;

        public long FK_PROFILEID
        {
            get { return _FK_PROFILEID; }
            set { _FK_PROFILEID = value; }
        }
        private Int64 _FK_CONTROLID;

        public long FK_CONTROLID
        {
            get { return _FK_CONTROLID; }
            set { _FK_CONTROLID = value; }
        }
        private bool _IS_VISIBLE;

        public bool IS_VISIBLE
        {
            get { return _IS_VISIBLE; }
            set { _IS_VISIBLE = value; }
        }
        private bool _IS_ACTIVE;

        public bool IS_ACTIVE
        {
            get { return _IS_ACTIVE; }
            set { _IS_ACTIVE = value; }
        }
    }
}
