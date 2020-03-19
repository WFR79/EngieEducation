/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 24-05-2012
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SynapseCore.Database;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseUser.
    /// </summary>
    public class SynapseUser : SynapseEntity<SynapseUser>
    {
        private static string _query = "SELECT * FROM [Synapse_Security_User]";
        private static string _tableName = "[Synapse_Security_User]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";
        static SynapseUser()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
        public SynapseUser()
        {
        }

        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _UserID;

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _FIRSTNAME;

        public string FIRSTNAME
        {
            get { return _FIRSTNAME; }
            set { _FIRSTNAME = value; }
        }
        private string _LASTNAME;

        public string LASTNAME
        {
            get { return _LASTNAME; }
            set { _LASTNAME = value; }
        }
        private string _CULTURE;

        [EntityFieldType(FieldType.dropdown, "SELECT [LABEL] as Text,[CULTURE] as Value FROM [SYNAPSE].[dbo].[Synapse_Language]")]
        public string CULTURE
        {
            get { return _CULTURE; }
            set { _CULTURE = value; }
        }

        public static SynapseUser LoadByUserID(string ID)
        {
            return DBFunction.GetTableFromQuery(_query + " WHERE " + "USERID" + " = '" + ID.ToString() + "'").ToEntity<SynapseUser>();
        }
        public override string ToString()
        {
            return LASTNAME + " " + FIRSTNAME;
        }
    }
}
