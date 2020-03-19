using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;

namespace Synapse
{
    public partial class frmAdministration : SynapseForm
    {
        public frmAdministration()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            this.WindowState = FormWindowState.Maximized;
            tssUser.Text = string.Format("{0} {1} ({2})", FormUser.FirstName, FormUser.LastName, FormUser.UserID);
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAccessRights_Click(object sender, EventArgs e)
        {
            if (!formAlreadyOpen("frmAccessRights"))
            {
                frmAccessRights fAccessRights = new frmAccessRights();
                fAccessRights.MdiParent = this;
                fAccessRights.Show();
            }
        }

        private void mnuOverview_Click(object sender, EventArgs e)
        {
            if (!formAlreadyOpen("frmSecurityOverView"))
            {
                frmSecurityOverView fSecurityOverView = new frmSecurityOverView();
                fSecurityOverView.MdiParent = this;
                fSecurityOverView.Show();
            }
        }

        private void mnuPermissions_Click(object sender, EventArgs e)
        {
            if (!formAlreadyOpen("SecurityEdit"))
            {
                SecurityEdit fSecurityEdit = new SecurityEdit();
                fSecurityEdit.MdiParent = this;
                fSecurityEdit.Show();
            }
        }

        private void mnuModules_Click(object sender, EventArgs e)
        {
            if (!formAlreadyOpen("frm_ModulesEdit"))
            {
                frm_ModulesEdit fModulesEdit = new frm_ModulesEdit();
                fModulesEdit.MdiParent = this;
                fModulesEdit.Show();
            }
        }

        private Boolean formAlreadyOpen(string formName)
        {
            foreach (Form childForm in ((frmAdministration)Application.OpenForms["frmAdministration"]).MdiChildren)
            {
                if (childForm.Name.ToUpper() == formName.ToUpper())
                {
                    childForm.Activate();
                    childForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    return true;
                }
            }
            return false;
        }
    }
}
