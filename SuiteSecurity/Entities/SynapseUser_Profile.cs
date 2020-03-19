/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 08:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseUser_Profile.
    /// </summary>
    public class SynapseUser_Profile : SynapseEntity<SynapseUser_Profile>
    {
        private static string _query = "SELECT * FROM [Synapse_Security_User Profile]";
        private static string _tableName = "[Synapse_Security_User Profile]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        static SynapseUser_Profile()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

        public SynapseUser_Profile()
        {
        }

        private Int64 _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Int64 _FK_SECURITY_PROFILE;

        public long FK_SECURITY_PROFILE
        {
            get { return _FK_SECURITY_PROFILE; }
            set { _FK_SECURITY_PROFILE = value; }
        }
        private Int64 _FK_SECURITY_USER;

        public long FK_SECURITY_USER
        {
            get { return _FK_SECURITY_USER; }
            set { _FK_SECURITY_USER = value; }
        }
    }
}
