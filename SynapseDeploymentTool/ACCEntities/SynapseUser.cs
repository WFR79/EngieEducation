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

namespace SynapseACC.Entities
{
	/// <summary>
	/// Description of SynapseUser.
	/// </summary>
    [DBConnection("Synapse ACC")]
    public class ACCSynapseUser : SynapseEntity<ACCSynapseUser>
	{
		private static string _query="SELECT * FROM [Synapse_Security_User]";
		private static string _tableName ="[Synapse_Security_User]";
		private static string _IDproperty = "ID";
		private static string _EcludeForSave = "||";
		static ACCSynapseUser()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
		public ACCSynapseUser()
		{
		}
		
		private Int64 _ID;
		
		public Int64 ID {
			get { return _ID; }
			set { _ID = value; }
		}
    	private string _UserID;
    	
		public string UserID {
			get { return _UserID; }
			set { _UserID = value; }
		}
      	private string _FIRSTNAME;
      	
		public string FIRSTNAME {
			get { return _FIRSTNAME; }
			set { _FIRSTNAME = value; }
		}
      	private string _LASTNAME;
      	
		public string LASTNAME {
			get { return _LASTNAME; }
			set { _LASTNAME = value; }
		}
        private string _CULTURE;

        [EntityFieldType(FieldType.dropdown,"SELECT [LABEL] as Text,[CULTURE] as Value FROM [SYNAPSE].[dbo].[Synapse_Language]")]
        public string CULTURE
        {
            get { return _CULTURE; }
            set { _CULTURE = value; }
        }



        //public static SynapseUser LoadByID(Int64 ID)
        //{
        //    return DBFunction.GetTableFromQuery(_query + " WHERE " + _IDproperty + " = " + ID.ToString()).ToEntity<SynapseUser>();
        //}

        public static ACCSynapseUser LoadByUserID(string ID)
        {
            return DBFunction.GetTableFromQuery(_query + " WHERE " + "USERID" + " = '" + ID.ToString()+"'").ToEntity<ACCSynapseUser>();
        }

        //public static IList<SynapseUser> Load()
        //{
        //    return Load(string.Empty);
			
        //}
        //public static IList<SynapseUser> Load(string filter)
        //{
        //    string sql=_query;
        //    if (filter!=string.Empty)
        //        sql+=" "+filter;
        //    return LoadFromQuery(sql);
			
				
        //}
        //public static IList<SynapseUser> LoadFromQuery(string query)
        //{
        //    return DBFunction.GetTableFromQuery(query).ToListOfEntities<SynapseUser>();
        //}
		
        //public void save()
        //{
        //    DBFunction.SaveEntityToDB(this,_tableName,_IDproperty,_EcludeForSave);
        //}
	}
}
