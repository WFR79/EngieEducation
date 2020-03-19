/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 22-05-2012
 * Time: 10:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using SynapseCore.Entities;

namespace SynapseCore.Controls
{
    /// <summary>
    /// Description of SynapseForm.
    /// </summary>
    public class SynapseForm : System.Windows.Forms.Form
    {
        #region private variables

        private static List<SynapseForm> FormList = new List<SynapseForm>();
        private static SynapseCore.Security.User _formUser;
        private static IList<SynapseLanguage> _language;
        private static ResourceManager resourceManager;
        public static bool DevACK = false;
        private static IList<SynapseModule> _allModules=null;
        private ToolStripDropDownButton LanguageMenu = new ToolStripDropDownButton();
        private static SynapseModule _CurrentSynapse;
        private bool _debug;
        private int _ModuleID;
        private bool _UpdateControls;
        private bool _ShowMenu = true;
        private bool _SecurityEnabled = true;
        private bool _Securized = false;
        private Int64 _ReportModuleID = 0;
        private string _ReportTags;
        public static readonly ILog SynapseLogger = LogManager.GetLogger("SynapseLogger");
        private static SynapseLanguage _CurrentLanguage = new SynapseLanguage();
        private SynapseStatistic stat;
        private DateTime LastActivation;
        private bool Actiavted;
        SynapseModule.SynapseModuleMode Mode = SynapseModule.SynapseModuleMode.Production;
        #endregion

        #region Properties

        [Category("Synapse Framework"), Description("Enable security on form")]
        public bool SecurityEnabled
        {
            get { return _SecurityEnabled; }
            set { _SecurityEnabled = value; }
        }

        public static SynapseLanguage CurrentLanguage
        {
            get { return SynapseForm._CurrentLanguage; }
            set { SynapseForm._CurrentLanguage = value; }
        }
        [Category("Synapse Framework"), Description("Show language and about menu")]
        public bool ShowMenu
        {
            get { return _ShowMenu; }
            set { _ShowMenu = value; }
        }

        [Browsable(false)]
        public static SynapseCore.Security.User FormUser
        {
            get { return _formUser; }
            set { _formUser = value; }
        }
        [Category("Synapse Framework"), Description("Synapse module ID")]
        public int ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
        [Category("Synapse Framework"), Description("Add controls in database")]
        public bool UpdateControls
        {
            get { return _UpdateControls; }
            set { _UpdateControls = value; }
        }
        [Category("Synapse Framework"), Description("Debug mode on")]
        public bool Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }
        [Category("Synapse Framework"), Description("Report Tags")]
        public string ReportTags
        {
            get { return _ReportTags; }
            set { _ReportTags = value; }
        }
        [Browsable(false)]
        public static SynapseModule CurrentSynapse
        {
            get { return SynapseForm._CurrentSynapse; }
            set { SynapseForm._CurrentSynapse = value; }
        }

        private static SynapseModule _CurrentModule;

        [Browsable(false)]
        public static SynapseModule CurrentModule
        {
            get { return SynapseForm._CurrentModule; }
            set { SynapseForm._CurrentModule = value; }
        }

        #endregion

        #region functions

        public SynapseForm()
        {
            if (!this.DesignMode && _allModules == null)
            {
                //_allModules = SynapseModule.Load();
            }
            FormList.Add(this);

            bool showTestEnvironment = true;
            if (ConfigurationManager.AppSettings["ShowTestEnvironment"] != null)
                bool.TryParse(ConfigurationManager.AppSettings["ShowTestEnvironment"], out showTestEnvironment);

            if (Application.ExecutablePath.Contains("\\Dev\\") && showTestEnvironment)
                SynapseCore.Database.DBFunction.FormBackColor = Color.Tomato;
        }

        void AboutClick(object sender, EventArgs e)
        {
            frm_About about = new frm_About();
            about.ShowDialog();
        }

        void ReportClick(object sender, EventArgs e)
        {
            Int64 InterfaceID = 0;
            try
            { 
                InterfaceID = Int64.Parse(ConfigurationManager.AppSettings["ReportInterfaceID"]);
            }
            catch
            {
                InterfaceID = 0;
            }
            
            foreach (SynapseModule mod in FormUser.Modules)
            {
                if (mod.ID == _ReportModuleID)
                {
                    if (CurrentModule.ID == 1)
                        mod.start(Application.StartupPath, CurrentModule.ID.ToString(), Mode);
                    else
                        mod.start(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(Mode == SynapseModule.SynapseModuleMode.Production ? "\\Prod\\" : "\\Dev\\")), CurrentModule.ID.ToString() + "," + InterfaceID + (string.IsNullOrWhiteSpace(_ReportTags)?"":(" " + _ReportTags)), Mode);
                    break;
                }
            }
        }

        void LanguageClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            foreach (SynapseLanguage lang in _language)
            {
                if (lang.CULTURE == tsmi.Tag.ToString())
                    _CurrentLanguage = lang;
            }
            Security.Tools.SetCulture(_CurrentLanguage.CULTURE);
            FormUser.UserCulture = _CurrentLanguage.CULTURE;
            FormUser.SaveUser();
            foreach (SynapseForm form in FormList)
            {
                form.initForm(SynapseCore.Security.Tools.SecureAndTranslateMode.Transalte);
                if (form.LanguageMenu != null)
                {
                    form.LanguageMenu.Text = _CurrentLanguage.LABEL;
                    form.LanguageMenu.Tag = _CurrentLanguage.CULTURE;
                    form.LanguageMenu.Image = (Image)Resource1.ResourceManager.GetObject(_CurrentLanguage.CODE);
                }
            }
        }

        public void SecurizeForm()
        {
            SecurizeForm(false);
        }

        private void SecurizeForm(bool AddMenu)
        {
            bool UserHaveAccess = false;
            string UserID = string.Empty;
            bool ScanControl = false;
            bool ShowTestEnvironment = true;
            if (_allModules ==null )
                _allModules = SynapseModule.Load();
            try
            {
                ShowTestEnvironment = bool.Parse(ConfigurationManager.AppSettings["ShowTestEnvironment"]);
            }
            // TODO: Replace by more specific exception
            catch (Exception)
            {
                // TODO: Log exception
            }

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                if (log4net.LogManager.GetRepository().Configured == false)
                    XmlConfigurator.Configure();

                if (_formUser == null)
                {
                    UserID = WindowsIdentity.GetCurrent().Name;
                    FormUser = new SynapseCore.Security.User(UserID, this.ModuleID);
                }

                if (_language == null)
                {
                    string languageFilter = null;
                    try
                    {
                        languageFilter = ConfigurationManager.AppSettings["ModuleLanguages"];
                    }
                    catch
                    {
                        SynapseLogger.Debug("ModuleLanguage not defined in app.config");
                    }
                    if (languageFilter != null && languageFilter != string.Empty && languageFilter != "")
                        _language = SynapseLanguage.Load("where CODE in (" + languageFilter + ")");
                    else
                        _language = SynapseLanguage.Load();
                }

                SynapseLogger.Debug("ModuleLanguage not defined in app.config");
                if (Control.ModifierKeys == (Keys.Control | Keys.Shift) && FormUser.IsMemberOf("SYNAPSE_SECURITY_USER_IMPERSONATE"))
                {
                    frm_EnterUser UserDialog = new frm_EnterUser();
                    UserDialog.ShowDialog();
                    UserID = UserDialog.UserID;
                    if (UserID != string.Empty)
                        FormUser = new SynapseCore.Security.User(UserID, this.ModuleID);
                }

                SynapseLogger.Debug("Check key modifier");
                if (FormUser.UserCulture != string.Empty && FormUser.UserCulture != null)
                    _CurrentLanguage.CULTURE = FormUser.UserCulture;
                else
                    _CurrentLanguage.CULTURE = Thread.CurrentThread.CurrentCulture.Name;

                SynapseLogger.Debug("Set Current Language");
                foreach (SynapseLanguage lang in _language)
                {
                    if (lang.CULTURE == _CurrentLanguage.CULTURE)
                        _CurrentLanguage = lang;
                }

                SynapseLogger.Debug("Set Current Language Label");
                if (_CurrentLanguage.LABEL == null)
                {
                    _CurrentLanguage = _language[0];
                }

                Security.Tools.SetCulture(_CurrentLanguage.CULTURE);
                SynapseLogger.Debug("Configure Resource Manager");
                ConfigureResourceManager();

                SynapseLogger.Debug("Set Current Module access");
                if (FormUser != null)
                {
                    foreach (SynapseModule Module in _allModules) //FormUser.Modules
                    {

                        if (_CurrentSynapse == null && Module.ID == 1)
                            _CurrentSynapse = Module;
                        if (_CurrentModule == null && Module.ID == _ModuleID)
                            _CurrentModule = Module;
                    }                        
                    if (FormUser.Modules.Select(m=>m.ID).Contains(_CurrentModule.ID))
                            UserHaveAccess = true;
                }

                SynapseLogger.Debug("Check Module Mode");
                if (CurrentModule.ID == 1)
                    if (SynapseCore.Database.DBFunction.ConnectionName != "Default")
                        Mode = SynapseModule.SynapseModuleMode.Development;
                    else
                        Mode = SynapseModule.SynapseModuleMode.Production;
                else
                    Mode = Application.ExecutablePath.Contains("\\Dev\\") ? SynapseModule.SynapseModuleMode.Development : SynapseModule.SynapseModuleMode.Production;

                //redify
                List<Control> menupoint = Controls.OfType<ToolStrip>().Cast<Control>().ToList();
                if (menupoint.Count > 0)
                {
                    foreach (Control Ctrl in menupoint)
                    {
                        if (SynapseCore.Database.DBFunction.FormBackColor != SystemColors.Control && ShowTestEnvironment)
                        {
                            ((ToolStrip)Ctrl).BackColor = SynapseCore.Database.DBFunction.FormBackColor;
                        }
                    }
                }
                //end refify

                SynapseLogger.Debug("Add Menu");
                if (this.ShowMenu && AddMenu)
                    ConfigureMenu();

                SynapseLogger.Debug("Language Message");
                string LangMessage = "en";
                try
                {
                    LangMessage = _CurrentLanguage.CULTURE.Substring(0, 2).ToUpper();
                }
                // TODO: Replace by more specific exception
                catch (Exception)
                {
                    SynapseLogger.Error("Unable to determine language of message");
                }

                SynapseLogger.Debug("Message No Access");
                if (!UserHaveAccess && ModuleID != 1)
                {
                    MessageBox.Show(Properties.Resources.ResourceManager.GetString(LangMessage + "_NoAccess"));
                    Application.Exit();
                }

                SynapseLogger.Debug("Message Not Active");
                if (!CurrentModule.IS_ACTIVE && Mode == SynapseModule.SynapseModuleMode.Production)
                {
                    MessageBox.Show("(" + Mode.ToString() + ") " + Properties.Resources.ResourceManager.GetString(LangMessage + "_Maintenance"));
                    Application.Exit();
                }

                SynapseLogger.Debug("Message Not Up To Date");
                if (!CurrentModule.is_uptodate(Application.StartupPath, Mode) && !System.Diagnostics.Debugger.IsAttached)
                {
                    try
                    {
                        MessageBox.Show(Properties.Resources.ResourceManager.GetString(LangMessage + "_UpdateNeeded"));
                        string file = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(Mode == SynapseModule.SynapseModuleMode.Production ? "\\Prod\\" : "\\Dev\\")) + "\\Synapse.exe";
                        if (file != null)
                        {
                            SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("starting " + file);
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                            proc.StartInfo.FileName = file;
                            proc.StartInfo.WorkingDirectory = Path.GetFullPath(file);
                            proc.StartInfo.Arguments = Mode == SynapseModule.SynapseModuleMode.Production ? "" : "/con:ACC";
                            proc.Start();
                        }
                        else
                        {
                            SynapseCore.Controls.SynapseForm.SynapseLogger.Debug("Not exist " + file);
                        }
                        Application.Exit();
                    }
                    // TODO: Replace by more specific exception
                    catch (Exception)
                    {
                        if (!FormUser.IsMemberOf("SYNAPSE_SECURITY_ADMIN"))
                        {
                            MessageBox.Show("Application not in right location !");
                            Application.Exit();
                        }
                    }
                }

                SynapseLogger.Debug("Message Development");
                if (Mode == SynapseModule.SynapseModuleMode.Development && !DevACK)
                {
                    MessageBox.Show(Properties.Resources.ResourceManager.GetString(LangMessage + "_DevelopmentMode"));
                    DevACK = true;
                }
                try
                {
                    ScanControl = bool.Parse(ConfigurationManager.AppSettings["ScanControl"]);
                }
                // DONE: Replaced by more specific exception (see http://msdn.microsoft.com/en-us/library/vstudio/system.configuration.configurationmanager.appsettings(v=vs.90).aspx)
                catch (ConfigurationErrorsException)
                {
                    // TODO: Remove swallowing of Exception
                }

                if (UpdateControls && ModuleID != 0 && ScanControl)
                {
                    System.IO.TextWriter w = new System.IO.StreamWriter(Application.StartupPath + "\\" + this.Name + "_res.SynapseResource", false, System.Text.Encoding.Unicode);
                    w.Write(SynapseCore.Security.Tools.UpdateControlsInDB(this.Controls, this.ModuleID, null).ToString());

                    w.Flush();
                    w.Close();
                }

                SynapseLogger.Debug("Init Form");
                initForm(Security.Tools.SecureAndTranslateMode.Secure | Security.Tools.SecureAndTranslateMode.Transalte);
            }
        }


        private void ConfigureMenu()
        {
            try
            {
                _ReportModuleID = Int64.Parse(ConfigurationManager.AppSettings["ReportModuleID"]);
            }
            catch (ConfigurationErrorsException) // See http://msdn.microsoft.com/en-us/library/vstudio/system.configuration.configurationmanager.appsettings(v=vs.90).aspx
            {
                _ReportModuleID = 0;
            }

            SynapseLogger.Debug("Get Toolstrip list");
            List<Control> c = Controls.OfType<ToolStrip>().Cast<Control>().ToList();
            if (c.Count > 0)
            {
                SynapseLogger.Debug("Get top Menu");
                Control Menu = c[0];
                Control Status = null;
                foreach (Control Ctrl in c)
                {
                    if (Ctrl.Top < Menu.Top)
                        Menu = Ctrl;
                    if (Ctrl.GetType().ToString() == "System.Windows.Forms.StatusStrip")
                        Status = Ctrl;
                }
                ToolStripMenuItem btn_report = new ToolStripMenuItem();
                btn_report.Text = "Reports";
                btn_report.Name = "btn_Report";
                btn_report.MergeAction = MergeAction.MatchOnly;
                btn_report.MergeIndex = 1;
                btn_report.Click += ReportClick;
                if (Menu.GetType().ToString() == "System.Windows.Forms.ToolStrip")
                {
                    btn_report.TextImageRelation = TextImageRelation.ImageAboveText;
                    btn_report.Image = (Image)SynapseCore.Resource1.report;
                }
                if (_ReportModuleID != 0)
                    foreach (SynapseModule mod in FormUser.Modules)
                        if (mod.ID == _ReportModuleID)
                        {
                            bool ReportMenuAdded = false;
                            foreach (ToolStripItem tsmi in ((ToolStrip)Menu).Items)
                            {
                                if (tsmi.AccessibleName == "reports")
                                {
                                    ((ToolStripMenuItem)tsmi).DropDownItems.Add(btn_report);
                                    btn_report.TextImageRelation = TextImageRelation.ImageAboveText;
                                    btn_report.Image = (Image)SynapseCore.Resource1.report;
                                    ReportMenuAdded = true;
                                    break;
                                }
                            }
                            if (!ReportMenuAdded) ((ToolStrip)Menu).Items.Add(btn_report);
                            break;
                        }

                SynapseLogger.Debug("Create About Menu");

                ToolStripButton btn_about = new ToolStripButton();
                btn_about.Text = "About";
                btn_about.Name = "btn_About";
                btn_about.Click += AboutClick;
                if (Menu.GetType().ToString() == "System.Windows.Forms.ToolStrip")
                {
                    btn_about.TextImageRelation = TextImageRelation.ImageAboveText;
                    btn_about.Image = (Image)SynapseCore.Resource1.about;
                }

                ((ToolStrip)Menu).Items.Add(btn_about);

                SynapseLogger.Debug("Create Language Menu");

                LanguageMenu.AutoSize = true;
                LanguageMenu.Text = _CurrentLanguage.LABEL;
                LanguageMenu.Tag = _CurrentLanguage.CULTURE;
                LanguageMenu.Image = (Image)Resource1.ResourceManager.GetObject(_CurrentLanguage.CODE);
                LanguageMenu.Alignment = ToolStripItemAlignment.Right;
                LanguageMenu.Name = "mnu_Language";

                foreach (SynapseLanguage lang in _language)
                {
                    ToolStripMenuItem lng = new ToolStripMenuItem();
                    lng.AutoSize = true;
                    lng.Text = lang.LABEL;
                    lng.Name = "mnu_Language_" + lang.CODE;
                    lng.Tag = lang.CULTURE;
                    lng.Image = (Image)Resource1.ResourceManager.GetObject(lang.CODE);
                    lng.Click += LanguageClick;
                    LanguageMenu.DropDownItems.Add(lng);
                }

                SynapseLogger.Debug("Add Menu to Toolbar");
                if (Status != null)
                    ((ToolStrip)Status).Items.Add(LanguageMenu);
                else
                    ((ToolStrip)Menu).Items.Add(LanguageMenu);
            }
        }
        public virtual void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            bool DebugControl = false;
            bool ShowTestEnvironment = true;
            try
            {
                DebugControl = bool.Parse(ConfigurationManager.AppSettings["DebugControl"]);
                ShowTestEnvironment = bool.Parse(ConfigurationManager.AppSettings["ShowTestEnvironment"]);
            }
            catch (Exception ex) //ConfigurationErrorsException See http://msdn.microsoft.com/en-us/library/vstudio/system.configuration.configurationmanager.appsettings(v=vs.90).aspx 
            { 
            }
            if (SecurityEnabled)
                SynapseCore.Security.Tools.SecureAndTranslate(ModuleID, FormUser, this.Controls, ref resourceManager, _debug & DebugControl, Mode);
            else
                if ((Mode & SynapseCore.Security.Tools.SecureAndTranslateMode.Transalte) != 0)
                    SynapseCore.Security.Tools.SecureAndTranslate(ModuleID, FormUser, this.Controls, ref resourceManager, _debug & DebugControl, SynapseCore.Security.Tools.SecureAndTranslateMode.Transalte);
            if (!this.IsMdiChild)
                this.Text = "Synapse " + _CurrentSynapse.VERSION + " - " + GetLabel(this.Name);
            else
                this.Text = GetLabel(this.Name);
            this.Icon = (Icon)Resource1.Synapse;
            if (SynapseCore.Database.DBFunction.FormBackColor != SystemColors.Control && ShowTestEnvironment)
            {
                this.BackColor = SynapseCore.Database.DBFunction.FormBackColor;
            }

        }
        private void ConfigureResourceManager()
        {
            if (resourceManager == null)
                resourceManager = ResourceManager.CreateFileBasedResourceManager("formLabels", Application.StartupPath + @"/Resources", null);
        }

        public static string GetLabel(string ResourceName)
        {
            var returnValue = Security.Tools.GetLabel(ref resourceManager, ResourceName, false);
            return returnValue ?? String.Empty;
        }

        #endregion

        #region Overrides of events

        protected override void OnBindingContextChanged(EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (stat == null)
                {
                    stat = new SynapseStatistic();
                    stat.OPEN_TIME = DateTime.Now;
                }
                if (!_Securized)
                {
                    SecurizeForm(true);
                    _Securized = true;
                }
                stat.USERID = FormUser.UserID;
                stat.FORMNAME = this.Name;
                stat.FK_MODULE_ID = ModuleID;
                System.Diagnostics.Debug.WriteLine(System.ComponentModel.LicenseManager.UsageMode);
            }

            base.OnBindingContextChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!this.DesignMode && this.Name != null && this.Name != "")
                try
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.Text = GetLabel(this.Name);
                    }
                    else
                    {
                        if (!this.IsMdiChild)
                            this.Text = "Synapse " + _CurrentSynapse.VERSION + " - " + GetLabel(this.Name);
                        else
                            this.Text = GetLabel(this.Name);
                    }
                }
                // TODO: Catch more specific exception
                catch (Exception)
                {
                    // TODO: Log exception
                }
            base.OnSizeChanged(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormList.Remove(this);
                if (Actiavted)
                {
                    TimeSpan span = DateTime.Now.Subtract(LastActivation);
                    stat.ACTIVITY_TIME += (long)span.TotalSeconds;
                }
                stat.CLOSE_TIME = DateTime.Now;
                stat.OPENED_TIME = (long)stat.CLOSE_TIME.Subtract(stat.OPEN_TIME).TotalSeconds;
                stat.save();
            }
            base.OnClosed(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!this.DesignMode)
            {
                LastActivation = DateTime.Now;
                Actiavted = true;

                base.OnActivated(e);
            }
        }
        protected override void OnDeactivate(EventArgs e)
        {
            if (!this.DesignMode)
            {
                Actiavted = false;
                TimeSpan span = DateTime.Now.Subtract(LastActivation);
                stat.ACTIVITY_TIME += (long)span.TotalSeconds;
                base.OnDeactivate(e);
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SynapseForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "SynapseForm";
            this.ResumeLayout(false);
        }
    }
}
