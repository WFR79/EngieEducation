using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;

namespace SynapseRoomPickerDemo
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmPickerDemo fDemo = new frmPickerDemo();
            fDemo.MdiParent = this;
            fDemo.Show();
        }
    }
}
