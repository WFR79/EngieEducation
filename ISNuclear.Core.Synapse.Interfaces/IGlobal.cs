using System;
using System.Resources;
using System.Windows.Forms;
using ISNuclear.Core.Synapse.Enums.ISNuclear.Data.Enums;

namespace ISNuclear.Data.Interfaces
{
    public interface IGlobal<T>
    {
        T Container { get; }
        ResourceManager ResourceManager { get; }
        void ResetContainer();
        void flp_resize(object sender, EventArgs e);
        int InnerWidth(Control ctrl);
        int OuterHeight(Control ctrl);
        int OuterBottom(Control ctrl);
        DialogResult ShowMessage(ErrorCode TYPE, String CODE = "", String PARAM1 = "", String PARAM2 = "");
        int ModuleID { get; }
        bool UpdateControls { get; }
    }
}
