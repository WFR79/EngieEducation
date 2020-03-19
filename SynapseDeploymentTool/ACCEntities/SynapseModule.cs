/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SynapseCore.Database;
using System.Collections.Generic;
using System.IO;
using SynapseCore.Entities;
using GenInstaller;

namespace SynapseACC.Entities
{
	/// <summary>
	/// Description of SynapseModule.
	/// </summary>
    [DBConnection("Synapse ACC")]
	public class ACCSynapseModule:SynapseEntity<ACCSynapseModule>
	{
        private static string _query = "SELECT * FROM [Synapse_Module]";
        private static string _tableName = "[Synapse_Module]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|FriendlyName|Description|";

        public enum SynapseModuleMode
        {
            Development,
            Production
        }

        static ACCSynapseModule()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

		
		public ACCSynapseModule()
		{

		}

        private LabelBag _FriendlyName;

        [LabelId("LABELID","TECHNICALNAME")]
        public LabelBag FriendlyName
        {
            get { return _FriendlyName; }
            set { _FriendlyName = value; }
        }

        private LabelBag _Description;

        [LabelId("DESCLABELID")]
        public LabelBag Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

		private Int64 _ID;
		
		public long ID {
			get { return _ID; }
			set { _ID = value; }
		}
      	private Int64 _LABELID;
      	
		public long LABELID {
			get { return _LABELID; }
			set { _LABELID = value; }
		}
      	private string _PATH;
      	
		public string PATH {
			get { return _PATH; }
			set { _PATH = value; }
		}
      	private string _TECHNICALNAME;
      	
		public string TECHNICALNAME {
			get { return _TECHNICALNAME; }
			set { _TECHNICALNAME = value; }
		}

        private string _VERSION;

        public string VERSION
        {
            get { return _VERSION; }
            set { _VERSION = value; }
        }

        private string _MODULECATEGORY;

        public string MODULECATEGORY
        {
            get { return _MODULECATEGORY; }
            set { _MODULECATEGORY = value; }
        }

        private string _VERSIONDATE;

        public string VERSIONDATE
        {
            get { return _VERSIONDATE; }
            set { _VERSIONDATE = value; }
        }

        private Int64 _DESCLABELID;


        public Int64 DESCLABELID
        {
            get { return _DESCLABELID; }
            set { _DESCLABELID = value; }
        }

        public string DEVSOURCE { get; set; }
        public string PRODSOURCE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public bool IS_REQUESTABLE { get; set; }
        public DateTime gvf_Version(SynapseModuleMode Mode)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            DateTime sourceVersionDate = DateTime.MinValue;
            try
            {
                foreach (FileInfo fi in new DirectoryInfo(sourceDir).GetFiles("*.gvf"))
                {
                    if (fi.LastWriteTime > sourceVersionDate)
                        sourceVersionDate = fi.LastWriteTime;
                }
            }
            catch (Exception ex)
            {
                sourceVersionDate = DateTime.MinValue;
            }
            return sourceVersionDate;
        }

        public void set_gvf_Version(string date,string uid,string notes, SynapseModuleMode Mode)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            DateTime sourceVersionDate = DateTime.MinValue;
            try
            {
                foreach (FileInfo fi in new DirectoryInfo(sourceDir).GetFiles("*.gvf"))
                {
                    StreamWriter fs = fi.AppendText();
                    fs.WriteLine(string.Format("{0} {1} {2}",date,uid,notes));
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool is_uptodate(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {

            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;
            DateTime sourceVersionDate = DateTime.MinValue;
            DateTime targerVersionDate = DateTime.MinValue;


            try
            {
                foreach (FileInfo fi in new DirectoryInfo(sourceDir).GetFiles("*.gvf"))
                {
                    if (fi.LastWriteTime > sourceVersionDate)
                        sourceVersionDate = fi.LastWriteTime;
                }
            }
            catch (Exception ex)
            {
                sourceVersionDate = DateTime.MinValue;
            }
            try
            {

                foreach (FileInfo fi in new DirectoryInfo(targetDir).GetFiles("*.gvf"))
                {
                    if (fi.LastWriteTime > targerVersionDate)
                        targerVersionDate = fi.LastWriteTime;
                }

            }
            catch (Exception ex)
            {
                targerVersionDate = DateTime.MinValue;
            }
            if (sourceVersionDate > targerVersionDate)
                return false;
            else
                return true;

        }

        public void Update(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;

            GenInstaller.Installer.Install("Module " + TECHNICALNAME, sourceDir, targetDir, InstallOptions.Normal);
        }

        public void UnInstall(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;
            DirectoryInfo dir = new DirectoryInfo(targetDir);
            if (dir.Exists)
                dir.Delete(true);

        }

        public void start(string startupPath, string args = "", SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;
            //to be removed when DB is updated
            PATH = PATH.Substring(PATH.LastIndexOf("\\"));
            string file = null;
            if (File.Exists(PATH))
                file = PATH;
            if (File.Exists(targetDir + "\\" + PATH))
                file = targetDir + "\\" + PATH;
            else
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Not exist " + startupPath + "\\" + PATH);
            if (file != null)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("starting " + file);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                proc.StartInfo.FileName = file;
                proc.StartInfo.WorkingDirectory = Path.GetFullPath(file);
                //proc.StartInfo.Arguments = filename;
                proc.StartInfo.Arguments = args;
                proc.Start();
                //proc.WaitForExit();
            }
        }
        public IList<SynapseUser> GetOwners()
        {
            return SynapseUser.LoadFromQuery("SELECT     DISTINCT dbo.Synapse_Security_User.* FROM         dbo.Synapse_Security_Profile INNER JOIN dbo.[Synapse_Security_User Profile] ON dbo.Synapse_Security_Profile.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE INNER JOIN dbo.Synapse_Security_User ON dbo.[Synapse_Security_User Profile].FK_SECURITY_USER = dbo.Synapse_Security_User.ID WHERE     (dbo.Synapse_Security_Profile.IS_OWNER = 1) and dbo.Synapse_Security_Profile.FK_MODULEID="+this.ID.ToString());
        }
	}
}
