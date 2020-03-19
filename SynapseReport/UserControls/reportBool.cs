using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
namespace SynapseReport.UserControls
{
    public partial class reportBool : UserControl
    {
        public reportBool()
        {
            InitializeComponent();

            InitializeControl();
        }

        private void InitializeControl()
        {
            ckBoolean.CheckState = CheckState.Indeterminate;
            ckBoolean.Text = SynapseForm.GetLabel("FilterBool.Indeterminate");
        }

        private void ckBoolean_CheckStateChanged(object sender, EventArgs e)
        {
            switch (ckBoolean.CheckState)
            {
                case CheckState.Checked:
                    ckBoolean.Text = SynapseForm.GetLabel("FilterBool.Yes");
                    ckBoolean.ImageKey = "True";
                    break;
                case CheckState.Unchecked:
                    ckBoolean.Text = SynapseForm.GetLabel("FilterBool.No");
                    ckBoolean.ImageKey = "False";
                    break;
                case CheckState.Indeterminate:
                    ckBoolean.Text = SynapseForm.GetLabel("FilterBool.Indeterminate");
                    ckBoolean.ImageKey = "";
                    break;
            }
        }

        private void ckBoolean_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.ParentForm.AcceptButton.PerformClick();
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Apply_Filter(null, null);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ((reportControl)this.Parent.Parent.Parent.Parent.Parent).Reset_Filter(null, null);
                //this.ParentForm.CancelButton.PerformClick();
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                ckBoolean.CheckState = CheckState.Indeterminate;
                return;
            }
        }
    }
}
