/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 08:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SynapseCore.Database;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseProfile.
    /// </summary>
    public class SynapseProfile : SynapseEntity<SynapseProfile>
    {
        private static string _query = "SELECT * FROM [Synapse_Security_Profile]";
        private static string _tableName = "[Synapse_Security_Profile]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|TEXT|Description|";

        static SynapseProfile()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

        public SynapseProfile()
        {

        }
        private Int64 _ID;

        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Int64 _FK_ModuleID;

        [EntityFieldType(FieldType.dropdown, "SELECT [TECHNICALNAME] as Text,[ID] as Value FROM [SYNAPSE].[dbo].[Synapse_Module]")]
        public long FK_ModuleID
        {
            get { return _FK_ModuleID; }
            set { _FK_ModuleID = value; }
        }

        private string _TECHNICALNAME;

        public string TECHNICALNAME
        {
            get { return _TECHNICALNAME; }
            set { _TECHNICALNAME = value; }
        }
        private bool _IS_OWNER;

        [EntityFieldType(FieldType.checkbox, "")]
        public bool IS_OWNER
        {
            get { return _IS_OWNER; }
            set { _IS_OWNER = value; }
        }
        private Int64 _LEVEL;

        public Int64 LEVEL
        {
            get { return _LEVEL; }
            set { _LEVEL = value; }
        }

        private Int64 _FK_LABELID;

        public Int64 FK_LABELID
        {
            get { return _FK_LABELID; }
            set { _FK_LABELID = value; }
        }

        private LabelBag _Description;

        [LabelId("FK_LABELID")]
        public LabelBag Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}
