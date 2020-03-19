using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore;
using SynapseCore.Database;
using System.Diagnostics;
using SynapseCore.Database;

namespace ProofOfConcept
{
    public partial class Form1 : SynapseCore.Controls.SynapseForm
    {
       o_SynapseUser testuser;
        public Form1()
        {
            InitializeComponent();
        }
        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(SynapseCore.Security.Tools.SecureAndTranslateMode.Secure);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start(); 
            IList<SynapseCore.Entities.SynapseUser> Users = SynapseCore.Entities.SynapseUser.Load();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed; 
            button1.Text = Users.Count.ToString("00 Users")+ " en "+ts.TotalMilliseconds.ToString("0 ms");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            IList<o_IMDBSTATUS> Entities = o_IMDBSTATUS.Load();
            stopWatch.Stop();
            //o_IMDBSTATUS newE = new o_IMDBSTATUS();
            //newE.STATUSNAME = "Test xxx_xx";
            //newE.TYPEID = 1;
            //newE.save();
            TimeSpan ts = stopWatch.Elapsed;
            button2.Text = Entities.Count.ToString("00 Entities") + " en " + ts.TotalMilliseconds.ToString("0 ms");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            IList<o_Agent> agents = o_Agent.Load().ToList();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed; 

            objectListView1.SetObjects(from a in agents select a);
            objectListView1.AutoResizeColumns();
            button3.Text = agents.Count.ToString("00 Agents") + " en " + ts.TotalMilliseconds.ToString("0 ms");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DBFunction.ConnectionManager.ActiveConnections.ToString("0 / ") + DBFunction.ConnectionManager.Connections.Count.ToString("0 DB Connections");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "TECHNICALNAME";
            comboBox1.DataSource = SynapseCore.Entities.SynapseInterface.LoadAvailable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            testuser = o_SynapseUser.LoadByUserID(@"CORP\HCE339");
            richTextBoxExtended1.RichTextBox.AppendText("User Loaded\n");
            richTextBoxExtended1.RichTextBox.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            testuser.dump();
            testuser.LASTNAME += "_X"; 
            richTextBoxExtended1.RichTextBox.AppendText("LastName modified : "+testuser.LASTNAME+"\n");
            richTextBoxExtended1.RichTextBox.ScrollToCaret();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBoxExtended1.RichTextBox.AppendText("Dirty: " + testuser.IsDirty.ToString() + "\n");
            richTextBoxExtended1.RichTextBox.ScrollToCaret();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            testuser.save();
            richTextBoxExtended1.RichTextBox.AppendText("User Saved\n");
            richTextBoxExtended1.RichTextBox.ScrollToCaret();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            testuser.rollback();
            richTextBoxExtended1.RichTextBox.AppendText("User rollback : " + testuser.LASTNAME + "\n");
            richTextBoxExtended1.RichTextBox.ScrollToCaret();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frm_history frm2 = new frm_history();
            frm2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SYNAPSEEntities db = new SYNAPSEEntities())
            {
                db.SwicthEFAppRole("SynapseMain");
                var user = db.Synapse_Security_User.ToList();

            }
        }
    }
}
