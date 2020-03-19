using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using SynapseAdvancedControls;

namespace SynapseStatistics
{
    public partial class StartupForm : Form
    {
        SynapseStatistics.StatDataEntities db = new StatDataEntities("name=ACCStatDataEntities");
        IEnumerable<Synapse_Security_Profile> Groups;
        IEnumerable<Synapse_Security_User> Users;
        IEnumerable<Synapse_Statistics> Stats;
        List<string> Forms;
        public StartupForm()
        {
            InitializeComponent();

            col_SumUsers.AspectGetter = delegate(object x)
            { 
                return (from u in db.Synapse_Security_User
                            join up in db.Synapse_Security_User_Profile on u.ID equals up.FK_SECURITY_USER into gu
                            from g in gu 
                            where g.FK_SECURITY_PROFILE == ((Synapse_Security_Profile)x).ID 
                            select u).Count();
            };
            col_FormName.AspectGetter = delegate(object x)
            {
                return x.ToString();
            };
            Col_FormTime.AspectGetter = delegate(object x)
            {
                string formname = x.ToString();
                double min = (from s in Stats where s.FORMNAME==formname select (s.CLOSE_TIME-s.OPEN_TIME).TotalMinutes).Sum();
                return min / 60;
            };
            col_UserName.AspectGetter = delegate(object x)
            {
                return ((Synapse_Security_User)x).LASTNAME + " " + ((Synapse_Security_User)x).FIRSTNAME;
            };
            col_UserLast.AspectGetter = delegate(object x)
            {
                DateTime maxdate = Stats.Where(s => s.USERID.ToUpper() == ((Synapse_Security_User)x).USERID.ToUpper()).Select(s=>s.OPEN_TIME).DefaultIfEmpty().Max();
                return maxdate.ToString("dd/MM/yyyy");
            };
            col_UserActivity.AspectGetter = delegate(object x)
            {
                return ((double)Stats.Where(s => s.USERID.ToUpper() == ((Synapse_Security_User)x).USERID.ToUpper()).Sum(s => s.ACTIVITY_TIME) / 3600);
            };
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            cb_Modules.ValueMember = "ID";
            cb_Modules.DisplayMember = "TECHNICALNAME";
            cb_Modules.DataSource = db.Synapse_Module.ToList();

        }

        private void cb_Modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            Synapse_Module Mod = db.Synapse_Module.Single(M => M.ID == (Int64)cb_Modules.SelectedValue);
            Groups = db.Synapse_Security_Profile.Where(g => g.FK_MODULEID == Mod.ID).ToList();
            Users = (from u in db.Synapse_Security_User
                        join up in db.Synapse_Security_User_Profile on u.ID equals up.FK_SECURITY_USER 
                        join p in db.Synapse_Security_Profile on up.FK_SECURITY_PROFILE equals p.ID into gup
                        from g in gup.DefaultIfEmpty()
                        where g.FK_MODULEID == (Int64)cb_Modules.SelectedValue
                        select u).Distinct().ToList();
            DateTime fromdate = DateTime.Now.AddDays(-40);
            Forms = (from f in db.Synapse_Security_Control where f.FK_MODULE_ID == (Int64)cb_Modules.SelectedValue select f.FORM_NAME).Distinct().ToList(); ;
            Stats = (from s in db.Synapse_Statistics where s.FK_MODULE_ID == (Int64)cb_Modules.SelectedValue && s.OPEN_TIME>fromdate select s).ToList();
            objectListView1.SetObjects(Groups);
            objectListView2.SetObjects(Forms);
            objectListView3.SetObjects(Users);
            objectListView2.Sort(Col_FormTime, SortOrder.Descending);
            objectListView3.Sort(col_UserActivity, SortOrder.Descending);
            lb_UserCount.Text = string.Format("Total users for module {0}", Users.Count());

        }

        private void btn_UserReport_Click(object sender, EventArgs e)
        {
            frm_Users fu = new frm_Users(comboBox1.Text);
            fu.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new StatDataEntities("name="+comboBox1.Text+"StatDataEntities");
            StartupForm_Load(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();

        }
    }
}
