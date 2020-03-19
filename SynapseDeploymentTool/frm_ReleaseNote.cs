using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SynapseDeploymentTool
{
    public partial class frm_ReleaseNote : Form
    {
        public frm_ReleaseNote()
        {
            InitializeComponent();
        }

        private void frm_ReleaseNote_Load(object sender, EventArgs e)
        {

        }

        public string UID
        {
            get
            { return txt_UID.Text; }
            set { txt_UID.Text = value; }
        }
        public string Rdate
        {
            get
            { return txt_DATE.Text; }
            set { txt_DATE.Text = value; }
        }
        public string Notes
        {
            get {
                return txt_NOTES.Text;
            }
            set { txt_DATE.Text = value; }
        }
        public string Version
        {
            get {
                return txt_VERSION.Text;
            }
            set { txt_VERSION.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
