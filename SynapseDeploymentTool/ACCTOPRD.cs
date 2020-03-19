using System;
using System.Collections.Generic;
using SynapseCore.Database;
using SynapseCore.Entities;

namespace SynapseDeploymentTool
{
    [DBConnection("Synapse ACC")]
    public class ACCTOPRD:SynapseEntity<ACCTOPRD>
    {
        private static string _query="SELECT * FROM [Synapse_Security_ACCTOPRD]";
		private static string _tableName="[Synapse_Security_ACCTOPRD]";
		private static string _IDproperty="ID";
		private static string _EcludeForSave = "||";

        static ACCTOPRD()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

        public ACCTOPRD()
		{
		}
        public Int64 ID { get; set; }
        public string OBJECTTYPE { get; set; }
        public Int64 ACCID { get; set; }
        public Int64 PRDID { get; set; }
    }
}
