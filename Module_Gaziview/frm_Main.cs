using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Module_Gaziview.Entities;
using SynapseCore.Controls;

namespace Module_Gaziview
{
    public partial class frm_Main : SynapseForm
    {
        public frm_Main()
        {
            InitializeComponent();
            
        }
        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            tssl_User.Text = SynapseForm.FormUser.ToString();
        }

        private void tsmi_Params_Click(object sender, EventArgs e)
        {
            frm_Params f_Params = new frm_Params();
            f_Params.ShowDialog();
        }

        private void tsmi_GazDischarge_Click(object sender, EventArgs e)
        {
            frm_GasEmissions f_GazDischarge = new frm_GasEmissions();
            f_GazDischarge.MdiParent = this;
            f_GazDischarge.WindowState = FormWindowState.Maximized;
            f_GazDischarge.Show();
        }

        private void tsmi_Graphics_Click(object sender, EventArgs e)
        {
            frm_Graphics f_Graphics = new frm_Graphics(DateTime.Now);
            f_Graphics.MdiParent = this;
            f_Graphics.WindowState = FormWindowState.Maximized;
            f_Graphics.Show();
        }

        private void tsmi_Lists_Click(object sender, EventArgs e)
        {
            frm_Reports f_Reports = new frm_Reports();
            f_Reports.MdiParent = this;
            f_Reports.WindowState = FormWindowState.Maximized;
            f_Reports.Show();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.banner;
            this.BackgroundImageLayout = ImageLayout.Center;


        }

        private void tsmi_ImportOldData_Click(object sender, EventArgs e)
        {
            frm_ImportOldData f_import = new frm_ImportOldData();
            f_import.MdiParent = this;
            f_import.WindowState = FormWindowState.Maximized;
            f_import.Show();
        }

        private void historiqueBDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BDFHistory f_history = new frm_BDFHistory();
            f_history.MdiParent = this;
            f_history.WindowState = FormWindowState.Maximized;
            f_history.Show();
        }
    }
}
