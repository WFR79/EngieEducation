using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseReport.Forms;
using SynapseReport.Functionalities;

namespace SynapseReport
{
    public partial class frmMain : SynapseForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            this.Icon = Properties.Resources.report_module;
            tssUser.Text = string.Format("{0} {1} ({2})", FormUser.FirstName, FormUser.LastName, FormUser.UserID);
            tssModule.Text = "";
            tssModule.Image = null;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            if (!GlobalFunctions.formAlreadyOpen("frmCategoryList"))
            {
                frmCategoryList fCategoryList = new frmCategoryList();
                fCategoryList.MdiParent = this;
                fCategoryList.Show();
            }
        }

        private void mnuReportList_Click(object sender, EventArgs e)
        {
            if (!GlobalFunctions.formAlreadyOpen("frmReportList"))
            {
                frmReportList fReportList = new frmReportList();
                fReportList.MdiParent = this;
                fReportList.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ChangeModule(true);
        }

        private void mnuChangeModule_Click(object sender, EventArgs e)
        {
            ChangeModule(false);
        }

        private void ChangeModule(bool startup)
        {
            frmSelectModule fSelect = new frmSelectModule();
            fSelect.ShowDialog();
            if (fSelect.DialogResult == DialogResult.OK)
            {
                tssModule.Text = GlobalVariables.selectedOrigin.FriendlyName.ToString();
                switch (GlobalVariables.selectedOrigin.ORIGIN)
                {
                    case Origin.Module:
                        tssModule.Image = Properties.Resources._module;
                        break;
                    case Origin.Interface:
                        tssModule.Image = Properties.Resources._interface;
                        break;
                }
                foreach(Form childForm in this.MdiChildren)
                {
                    ((SynapseForm)childForm).initForm(SynapseCore.Security.Tools.SecureAndTranslateMode.Secure);
                }
            }
            else
            {
                if (startup)
                    this.Close();
            }
        }

        private void OpenReports(object sender, EventArgs e)
        {
            if (!GlobalFunctions.formAlreadyOpen("frmReport"))
            {
                frmReport fReport = new frmReport();
                fReport.MdiParent = this;
                fReport.statusStrip.Visible = false;
                fReport.mnuMain.Visible = false;
                fReport.Show();
            }
        }

    }
}
