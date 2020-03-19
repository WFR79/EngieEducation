using SynapseCore.Controls;
using ISNuclear.Data.Interfaces;
using System.Windows.Forms;

namespace ISNuclear.Core.Synapse.Forms
{
    public class ISNuclearForm<T> : SynapseForm where T:IContainer
    {
        #region "Fields"
        IGlobal<T> _global;
        #endregion "Fields"

        #region "Properties"
        public IGlobal<T> Global => _global; 
        #endregion "Properties"

        #region "Constructors"
        public ISNuclearForm(IGlobal<T> global)
        {
            _global = global;
            ModuleID = Global != null ? Global.ModuleID : 0;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            UpdateControls = Global != null && Global.UpdateControls;
        }
        #endregion "Constructors"

        #region "Methods"
        protected void CloseForm()
        {
            if (Parent != null) { Parent.Show(); }
            Close();
            Dispose();
        }
        #endregion "Methods"

        void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(284, 262);
            Name = "ISNuclearForm";
            ResumeLayout(false);
        }
    }
}
