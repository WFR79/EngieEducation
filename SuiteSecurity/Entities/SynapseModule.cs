/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using GenInstaller;
using SynapseCore.Database;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseModule.
    /// </summary>
    public class SynapseModule : SynapseEntity<SynapseModule>
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

        static SynapseModule()
        {
            Zquery = _query;
            ZtableName = _tableName;
            ZIDproperty = _IDproperty;
            ZEcludeForSave = _EcludeForSave;
        }

        public SynapseModule()
        {
            // Empty
        }

        private LabelBag _FriendlyName;

        [LabelId("LABELID", "TECHNICALNAME")]
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

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private Int64 _LABELID;

        public long LABELID
        {
            get { return _LABELID; }
            set { _LABELID = value; }
        }
        private string _PATH;

        public string PATH
        {
            get { return _PATH; }
            set { _PATH = value; }
        }
        private string _TECHNICALNAME;

        public string TECHNICALNAME
        {
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
                    {
                        sourceVersionDate = fi.LastWriteTime;
                    }
                }
            }
            // DONE: Catch more specific exception
            catch (ArgumentNullException)
            { 
                // TODO: Handle exception e.g. Log it
            }
            catch (SecurityException)
            {
                // TODO: Handle exception e.g. Log it
            }
            catch (ArgumentException)
            {
                // TODO: Handle exception e.g. Log it
            }
            catch (PathTooLongException)
            {
                // TODO: Handle exception e.g. Log it
            }
            catch (DirectoryNotFoundException)
            {
                // TODO: Handle exception e.g. Log it
            }

            return sourceVersionDate;
        }

        public void set_gvf_Version(string date, string uid, string notes, SynapseModuleMode Mode)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            DateTime sourceVersionDate = DateTime.MinValue;
            try
            {
                foreach (FileInfo fi in new DirectoryInfo(sourceDir).GetFiles("*.gvf"))
                {
                    StreamWriter fs = fi.AppendText();
                    fs.WriteLine(string.Format("{0} {1} {2}", date, uid, notes));
                    fs.Close();
                }
            }
            // DONE: Catch more specific exception
            catch (ArgumentNullException)
            {
                // TODO: Handle exception e.g. Log it & throw
            }
            catch (SecurityException)
            {
                // TODO: Handle exception e.g. Log it & throw
            }
            catch (ArgumentException)
            {
                // TODO: Handle exception e.g. Log it & throw
            }
            catch (PathTooLongException)
            {
                // TODO: Handle exception e.g. Log it & throw
            }
            catch (DirectoryNotFoundException)
            {
                // TODO: Handle exception e.g. Log it & throw
            }
        }

        public bool is_uptodate(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {

            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            string targetDir = string.Empty;
            if (startupPath.Contains("\\Dev\\") || startupPath.Contains("\\Prod\\"))
                targetDir = startupPath;
            else
                targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;

            DateTime sourceVersionDate = DateTime.MinValue;
            DateTime targerVersionDate = DateTime.MinValue;

            SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Start checking Is UpToDate for: " + sourceDir);

            try
            {
                foreach (FileInfo fi in new DirectoryInfo(sourceDir).GetFiles("*.gvf"))
                {
                    if (fi.LastWriteTime > sourceVersionDate)
                    {
                        sourceVersionDate = fi.LastWriteTime;
                    }
                }

                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Source last write time: " + sourceVersionDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            // DONE: Catch more specific exception
            catch (Exception ex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty));
            }
            

            try
            {
                foreach (FileInfo fi in new DirectoryInfo(targetDir).GetFiles("*.gvf"))
                {
                    if (fi.LastWriteTime > targerVersionDate)
                        targerVersionDate = fi.LastWriteTime;
                }

                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Target last write time: " + targerVersionDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            // DONE: Catch more specific exception
            catch (Exception ex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty));
            }

            if (sourceVersionDate > targerVersionDate)
            {
                if (targerVersionDate == DateTime.MinValue)
                    SynapseCore.Controls.SynapseForm.SynapseLogger.Info("IS NOT INSTALLED - startuppath:" + startupPath + " - " +
                                                                        "mode:" + Mode.ToString() + " - " +
                                                                        "source:" + sourceDir + " - " +
                                                                        "target:" + targetDir + " - " +
                                                                        "sourceversion:" + sourceVersionDate.ToString() + " - " +
                                                                        "targetversion:" + targerVersionDate.ToString());
                else
                    SynapseCore.Controls.SynapseForm.SynapseLogger.Info("IS NOT UP TO DATE - startuppath:" + startupPath + " - " +
                                                                        "mode:" + Mode.ToString() + " - " +
                                                                        "source:" + sourceDir + " - " +
                                                                        "target:" + targetDir + " - " +
                                                                        "sourceversion:" + sourceVersionDate.ToString() + " - " +
                                                                        "targetversion:" + targerVersionDate.ToString());
                return false;
            }
            else
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("IS UP TO DATE - startuppath:" + startupPath + " - " +
                                                                    "mode:" + Mode.ToString() + " - " +
                                                                    "source:" + sourceDir + " - " +
                                                                    "target:" + targetDir + " - " +
                                                                    "sourceversion:" + sourceVersionDate.ToString() + " - " +
                                                                    "targetversion:" + targerVersionDate.ToString());

                return true;
            }
        }

        public void Update(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;

            SynapseCore.Controls.SynapseForm.SynapseLogger.Info("Normal Install or Update Module: " + targetDir);
            try
            {
                GenInstaller.Installer.Install("Module " + TECHNICALNAME, sourceDir, targetDir, InstallOptions.Normal);
            }
            catch (Exception ex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty));
            }
        }

        public void ForceUpdate(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string sourceDir = Mode == SynapseModuleMode.Production ? PRODSOURCE : DEVSOURCE;
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;

            SynapseCore.Controls.SynapseForm.SynapseLogger.Info("Force Install or Update Module: " + targetDir);

            try
            {
                GenInstaller.Installer.Install("Module " + TECHNICALNAME, sourceDir, targetDir, InstallOptions.Force);
            }
            catch (Exception ex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty));
            }
        }

        public void UnInstall(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string targetDir = Mode == SynapseModuleMode.Production ? startupPath + "\\Prod\\" + TECHNICALNAME : startupPath + "\\Dev\\" + TECHNICALNAME;
            DirectoryInfo dir = null;

            SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Start uninstall directrories");

            try
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Uninstall directrory: " + targetDir);

                dir = new DirectoryInfo(targetDir);
                if (dir.Exists)
                    dir.Delete(true);

                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("End uninstall directrories");
            }
            // DONE: Catch more specific exception
            catch (ArgumentNullException anex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(anex.Message + (anex.InnerException != null ? " - " + anex.InnerException.Message : string.Empty));
            }
            catch (SecurityException sex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(sex.Message + (sex.InnerException != null ? " - " + sex.InnerException.Message : string.Empty));
            }
            catch (ArgumentException aex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(aex.Message + (aex.InnerException != null ? " - " + aex.InnerException.Message : string.Empty));
            }
            catch (PathTooLongException ptlex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ptlex.Message + (ptlex.InnerException != null ? " - " + ptlex.InnerException.Message : string.Empty));
            }
            catch (DirectoryNotFoundException dnfex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(dnfex.Message + (dnfex.InnerException != null ? " - " + dnfex.InnerException.Message : string.Empty));
            }
            catch (UnauthorizedAccessException uaex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(uaex.Message + (uaex.InnerException != null ? " - " + uaex.InnerException.Message : string.Empty));
            }
            catch (IOException ioex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ioex.Message + (ioex.InnerException != null ? " - " + ioex.InnerException.Message : string.Empty));
            }
            catch (Exception ex)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Error(ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty));
            }
        }

        public void start(string startupPath, string args = "", SynapseModuleMode Mode = SynapseModuleMode.Production)
        {
            string file = getModuleExecutablePath(startupPath, Mode);
            if (file != null)
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("starting " + file + " " + args);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                proc.StartInfo.FileName = file;
                proc.StartInfo.WorkingDirectory = Path.GetFullPath(file);
                proc.StartInfo.Arguments = args;
                proc.Start();
            }
            else
            {
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Not exist " + startupPath + "\\" + PATH);
            }
        }

        public string getModuleExecutablePath(string startupPath, SynapseModuleMode Mode = SynapseModuleMode.Production)
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
                SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Not exist " + targetDir + "\\" + PATH);

            return file;
        }

        public IList<SynapseUser> GetOwners()
        {
            return SynapseUser.LoadFromQuery("SELECT     DISTINCT dbo.Synapse_Security_User.* FROM         dbo.Synapse_Security_Profile INNER JOIN dbo.[Synapse_Security_User Profile] ON dbo.Synapse_Security_Profile.ID = dbo.[Synapse_Security_User Profile].FK_SECURITY_PROFILE INNER JOIN dbo.Synapse_Security_User ON dbo.[Synapse_Security_User Profile].FK_SECURITY_USER = dbo.Synapse_Security_User.ID WHERE     (dbo.Synapse_Security_Profile.IS_OWNER = 1) and dbo.Synapse_Security_Profile.FK_MODULEID=" + this.ID.ToString());
        }
    }
}
