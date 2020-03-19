using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseReport.Functionalities;
namespace SynapseReport.Forms
{
    public partial class frmSelectModule : SynapseForm
    {
        public frmSelectModule()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            var Modules = FormUser.Modules;
            var Interfaces = SynapseInterface.LoadAvailable();

            if (Modules.Count > 1 || Interfaces.Count > 1)
            {
                cb_Module.Items.Clear();
                foreach (SynapseModule Mod in Modules)
                {
                    cb_Module.Items.Add(Mod);
                }
                foreach (SynapseInterface Interf in Interfaces)
                {
                    cb_Module.Items.Add(Interf);
                }

                cb_Module.DisplayMember = "FriendlyName";
                //cb_Module.DisplayMember = "TECHNICALNAME";
                cb_Module.ValueMember = "ID";
                cb_Module.SelectedItem = cb_Module.Items[0];
            }
            else
            {
                if (Modules.Count == 1)
                {
                    ReportOrigin.setTo(Modules[0]);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (Interfaces.Count == 1)
                {
                    ReportOrigin.setTo(Interfaces[0]);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ReportOrigin.setTo(cb_Module.SelectedItem);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
