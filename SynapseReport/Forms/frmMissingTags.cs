using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseReport.UserControls;
namespace SynapseReport.Forms
{
    public partial class frmMissingTags : SynapseForm
    {
        public frmMissingTags()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            bool Ok=true;
            foreach (missingTag tag in pnlMissingTags.Controls)
            {
                if (tag.txTagValue.Text == "")
                    Ok = false;
            }

            if (Ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please, enter a value for each Tag!", "Missing Tags Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
