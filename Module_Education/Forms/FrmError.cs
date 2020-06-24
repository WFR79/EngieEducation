using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education
{
    public partial class FrmError : Form
    {
        public FrmError(string msg, string stackTrace)
        {
            InitializeComponent();
            rTbMsg.Text = msg;
            rTbStackTrace.Text = stackTrace;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCopyError_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(rTbMsg.Text + "\r\r" + rTbStackTrace.Text);
        }
    }
}
