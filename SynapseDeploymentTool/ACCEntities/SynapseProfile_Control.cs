/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace SynapseACC.Entities
{
	/// <summary>
	/// Description of SynapseProfile_Control.
	/// </summary>
    [DBConnection("Synapse ACC")]
    public class ACCSynapseProfile_Control : SynapseEntity<ACCSynapseProfile_Control>
	{
		private static string _query="SELECT * FROM [Synapse_Security_Profile Control]";
		private static string _tableName ="[Synapse_Security_Profile Control]";
		private static string _IDproperty = "ID";
		private static string _EcludeForSave = "||";
		
        static ACCSynapseProfile_Control()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }
		public ACCSynapseProfile_Control()
		{
		}
		
		private Int64 _ID;
		
		public long ID {
			get { return _ID; }
			set { _ID = value; }
		}
      	private Int64 _FK_PROFILEID;
      
		public long FK_PROFILEID {
			get { return _FK_PROFILEID; }
			set { _FK_PROFILEID = value; }
		}
	      private Int64 _FK_CONTROLID;
	      
		public long FK_CONTROLID {
			get { return _FK_CONTROLID; }
			set { _FK_CONTROLID = value; }
		}
	      private bool _IS_VISIBLE;
	      
		public bool IS_VISIBLE {
			get { return _IS_VISIBLE; }
			set { _IS_VISIBLE = value; }
		}
	      private bool _IS_ACTIVE;
	      
		public bool IS_ACTIVE {
			get { return _IS_ACTIVE; }
			set { _IS_ACTIVE = value; }
		}

        //public static SynapseProfile_Control LoadByID(Int64 ID)
        //{
        //    return DBFunction.GetTableFromQuery(_query + " WHERE " + _IDproperty + " = " + ID.ToString()).ToEntity<SynapseProfile_Control>();
        //}

        //public static IList<SynapseProfile_Control> Load()
        //{
        //    return Load(string.Empty);
			
        //}
        //public static IList<SynapseProfile_Control> Load(string filter)
        //{
        //    string sql=_query;
        //    if (filter!=string.Empty)
        //        sql+=" "+filter;
        //    return DBFunction.GetTableFromQuery(sql).ToListOfEntities<SynapseProfile_Control>();
        //}
		
        //public void save()
        //{
        //    DBFunction.SaveEntityToDB(this,_tableName,_IDproperty,_EcludeForSave);
        //}
	}
}
