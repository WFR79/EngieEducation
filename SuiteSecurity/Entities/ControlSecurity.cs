/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 22-05-2012
 * Time: 11:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SynapseCore.Entities
{
	/// <summary>
	/// Description of ControlSecurity.
	/// </summary>
	public sealed class ControlSecurity:SynapseEntity<ControlSecurity>
	{
		private static string _query="SELECT * FROM [V_Synapse_Security]";
		private static string _tableName ="[V_Synapse_Security]";
		private static string _IDproperty = "ID";
        private static string _EcludeForSave = "||";

        static ControlSecurity()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

		public ControlSecurity()
		{
		}
		private string _FORM_NAME;
		
		public string FORM_NAME {
			get { return _FORM_NAME; }
			set { _FORM_NAME = value; }
		}
		private string _CTRL_TYPE;
		
		public string CTRL_TYPE {
			get { return _CTRL_TYPE; }
			set { _CTRL_TYPE = value; }
		}
		private string _CTRL_NAME;
		
		public string CTRL_NAME {
			get { return _CTRL_NAME; }
			set { _CTRL_NAME = value; }
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
	}
}
