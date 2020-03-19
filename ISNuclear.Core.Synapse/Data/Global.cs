using System;
using System.Windows.Forms;
using System.Resources;
using System.Configuration;
using SynapseCore.Security;
using ISNuclear.Data.Interfaces;
using ISNuclear.Core.Synapse.Enums.ISNuclear.Data.Enums;
using System.IO;
using System.Diagnostics;
using SynapseCore.Database;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.EntityClient;

namespace ISNuclear.Data
{
    public class Global<Y> : IGlobal<Y> where Y : IContainer
    {
        #region "Fields"
        static readonly IGlobal<Y> _instance;
        static Y _container;
        static ResourceManager _resourceManager;
        static int _moduleID;
        static bool? _updateControls;
        #endregion "Fields"

        #region "Properties"
        public string ApplicationPath => Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        public Y Container
        {
            get => _container;
            set
            {
                _container = value;
                SwicthEFAppRole();
            }
        }

        public ResourceManager ResourceManager => _resourceManager ?? (_resourceManager = ResourceManager.CreateFileBasedResourceManager("formLabels", Application.StartupPath + @"/Resources", null));

        public int ModuleID
        {
            get
            {
                if (_moduleID <= 0) { int.TryParse(ConfigurationManager.AppSettings["ReportModuleID"], out _moduleID); }
                return _moduleID;
            }
        }

        public bool UpdateControls
        {
            get
            {
                if (_updateControls == null && bool.TryParse(ConfigurationManager.AppSettings["UpdateControls"], out bool temp)) { _updateControls = temp; }
                return _updateControls.HasValue && _updateControls.Value;
            }
        }
        #endregion "Properties"

        #region "Constructors"
        public Global(Y container) => Container = container;
        #endregion "Constructors"

        #region "Event Handlers"
        public void flp_resize(object sender, EventArgs e)
        {
            var flp = sender as FlowLayoutPanel;
            if (flp != null)
            {
                var width = InnerWidth(flp);
                foreach (Control ctrl in flp.Controls)
                {
                    ctrl.Width = width - ctrl.Margin.Horizontal;
                }
            }
        }
        #endregion "Event Handlers"

        #region "Methods"
        /// <summary>
        /// Switch the connection for the Entity framework context
        /// Warning : DO NOT USE CONNECTION POOLING
        /// </summary>
        /// <remarks>HCE339:Warning : DO NOT USE CONNECTION POOLING</remarks>
        void SwicthEFAppRole()
        {
            var entityConnection = (EntityConnection)Container.ObjectContext.Connection;
            var conn = entityConnection.StoreConnection as SqlConnection;
            var initialState = conn.State;
            if (initialState != ConnectionState.Open)
                conn.Open();

            conn.SwitchToApplicationRole(ConfigurationManager.AppSettings["ApplicationRole"]);
        }

        public void ResetContainer() => Container = default(Y);
        public int InnerWidth(Control ctrl) => ctrl != null ? ctrl.Width - ctrl.Padding.Horizontal : 0;
        public int OuterHeight(Control ctrl) => ctrl != null ? ctrl.Height + ctrl.Margin.Vertical : 0;
        public int OuterBottom(Control ctrl) => ctrl != null ? ctrl.Bottom + ctrl.Margin.Bottom : 0;

        public DialogResult ShowMessage(ErrorCode TYPE, string CODE = "", string PARAM1 = "", string PARAM2 = "")
        {
            var _message = "";

            var rm = ResourceManager;
            if (!string.IsNullOrEmpty(CODE))
            {
                _message = Tools.GetLabel(ref rm, CODE, false);
                if (!string.IsNullOrEmpty(PARAM1)) { _message = _message.Replace("#1", PARAM1); }
                if (!string.IsNullOrEmpty(PARAM2)) { _message = _message.Replace("#2", PARAM2); }
            }

            switch (TYPE)
            {
                case ErrorCode.WARN:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Warning", false), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                case ErrorCode.ERR:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Error", false), MessageBoxButtons.OK, MessageBoxIcon.Error);
                case ErrorCode.INFO:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Info", false), MessageBoxButtons.OK, MessageBoxIcon.Information);
                case ErrorCode.QUEST:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Question", false), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                case ErrorCode.QUEST_AND_CANCEL:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Warning", false), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                default:
                    return MessageBox.Show(_message, Tools.GetLabel(ref rm, "Dialog.Info", false), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected virtual void OnContainerCreated() { }
        #endregion "Methods"
    }
}
