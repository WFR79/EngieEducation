/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 08:14
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
	/// Description of SynapseUser_Profile.
	/// </summary>
    [DBConnection("Synapse ACC")]
    public class ACCSynapseUser_Profile : SynapseEntity<ACCSynapseUser_Profile>
	{
		private static string _query="SELECT * FROM [Synapse_Security_User Profile]";
		private static string _tableName ="[Synapse_Security_User Profile]";
		private static string _IDproperty = "ID";
		private static string _EcludeForSave = "||";
		static ACCSynapseUser_Profile()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
		public ACCSynapseUser_Profile()
		{
		}
		
		private Int64 _ID;
		
		public long ID {
			get { return _ID; }
			set { _ID = value; }
		}
		private Int64 _FK_SECURITY_PROFILE;
		
		public long FK_SECURITY_PROFILE {
			get { return _FK_SECURITY_PROFILE; }
			set { _FK_SECURITY_PROFILE = value; }
		}
        private Int64 _FK_SECURITY_USER;
        
		public long FK_SECURITY_USER {
			get { return _FK_SECURITY_USER; }
			set { _FK_SECURITY_USER = value; }
		}

        //public static SynapseUser_Profile LoadByID(Int64 ID)
        //{
        //    return DBFunction.GetTableFromQuery(_query + " WHERE " + _IDproperty + " = " + ID.ToString()).ToEntity<SynapseUser_Profile>();
        //}

        //public static IList<SynapseUser_Profile> Load()
        //{
        //    return Load(string.Empty);
			
        //}
        //public static IList<SynapseUser_Profile> Load(string filter)
        //{
        //    string sql=_query;
        //    if (filter!=string.Empty)
        //        sql+=" "+filter;
        //    return LoadFromQuery(sql);
			
				
        //}
        //public static IList<SynapseUser_Profile> LoadFromQuery(string query)
        //{
        //    return DBFunction.GetTableFromQuery(query).ToListOfEntities<SynapseUser_Profile>();
        //}
		
        //public void save()
        //{
        //    DBFunction.SaveEntityToDB(this,_tableName,_IDproperty,_EcludeForSave);
        //}
        //public void delete()
        //{
        //    DBFunction.DeleteEntityFromDB(_tableName,_IDproperty,this.ID);
        //}
	}
}
