using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;

namespace ProofOfConcept
{
    public partial class Demo : SynapseForm
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void loadUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList<o_SynapseUser> Users = o_SynapseUser.Load();
            SynapseForm.SynapseLogger.Debug("Users loaded");
            objectListView1.SetObjects(Users);
        }

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DemoHistory FormHistory = new DemoHistory();
            FormHistory.Show();
        }
    }
}
