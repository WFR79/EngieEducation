using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenInstaller
{
    public partial class StatusDialog : Form
    {
        public StatusDialog()
        {
            InitializeComponent();
        }

        
        private void StatusDialog_Load(object sender, EventArgs e)
        {

        }

        public string Title
        {
            set
            {
                this.Text = value;
                pictureBox1.Refresh();
            }
        }
        public void WriteText(string text)
        {
            richTextBox1.AppendText(text+"\n");
            richTextBox1.Refresh();
            pictureBox1.Refresh();
            richTextBox1.ScrollToCaret();
        }
        public int FilesCount
        {
            set { progressBar1.Maximum = value; }
        }
        public void Progress()
        {
            progressBar1.PerformStep();
        }
        public void Clear()
        {
            progressBar1.Value = 0;
            richTextBox1.Clear();
        }
        public void Complete()
        {
            progressBar1.Value = progressBar1.Maximum;
        }
    }
}
