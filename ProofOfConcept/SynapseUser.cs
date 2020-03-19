/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 24-05-2012
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace ProofOfConcept
{
	/// <summary>
	/// Description of SynapseUser.
	/// </summary>
    [DBLoggingAttribute("USER")]
	public class o_SynapseUser:SynapseEntity<o_SynapseUser>
	{
		private static string _query="SELECT * FROM [Synapse_Security_User]";
		private static string _tableName ="[Synapse_Security_User]";
		private static string _IDproperty = "ID";
		private static string _EcludeForSave = "||";

        public override string ToString()
        {
            return this.FIRSTNAME + " " + this.LASTNAME;
        }

	
		public Int64 ID {get; set; }
        public string UserID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        [EntityFieldType(FieldType.dropdown,"SELECT [LABEL] as Text,[CULTURE] as Value FROM [SYNAPSE].[dbo].[Synapse_Language]")]
        public string CULTURE { get; set; }

        public static o_SynapseUser LoadByUserID(string ID)
        {
            return DBFunction.GetTableFromQuery(_query + " WHERE " + "USERID" + " = '" + ID.ToString() + "'").ToEntity<o_SynapseUser>();
        }

 
	}
}
