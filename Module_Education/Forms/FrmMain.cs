using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Models;
using Module_Education.Repositories;
using Module_Education.UserControls;
//using Synapse;
using SynapseCore.Controls;


namespace Module_Education
{
    public partial class FrmMain : SynapseForm
    {
        private delegate void SafeCallDelegate(string text);
        private Button button1;
        private TextBox textBox1;
        public static List<Education_Formation> globalListEducation_Formations;
        public static List<Education_Agent> globalListAgents;
        private Button bouttonMenuPressed;
        private Thread thread2 = null;
        bool IsMenuShown = true;

        #region size Management
        private FormWindowState prevState;
        private Size panel1Size;
        private Size panelMainSize;
        private Size flowPanelMenuSize;
        #endregion

        #region UCEducation_Formation
        public delegate void controlcall(object sender, EventArgs e);
        public delegate void functioncall(long message);
        public delegate void refreshForm();


        private event controlcall ReceiverClickButton;
        private event refreshForm ReceiverRefreshListeAgent;
        private event functioncall ReceiverFromFicheFormation;

        public int UserIDSelected;
        #endregion

        public FrmMain()
        {
            //panelMain.Controls.Add(UC_Education_Formation.Instance);
            //panelMain.Controls.Add(UC_Agent.Instance);

            InitializeComponent();
            this.Size = new Size(1286, 639);

            prevState = this.WindowState;
            panel1Size = panel1.Size;
            panelMainSize = panelMain.Size;
            //flowPanelMenuSize = flowPanelMenu.Size;

            Thread y = new Thread(LoadEducation_FormationsThread);
            y.Start();
            LoadMainWindow();
            //MenuBtnEducation_Formation.PerformClick();
        }

        private void LoadMainWindow()
        {
            lblHelloUsername.Text = "Hello " + Environment.UserName;

        }
        #region Event

        protected override void OnResize(EventArgs e)
        {
            if (prevState != this.WindowState)
            {
                prevState = this.WindowState;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    //this.FormBorderStyle = FormBorderStyle.None;
                    //panel1.Size = this.ClientSize;
                    panelMain.Size = this.ClientSize;
                    // flowPanelMenuSize.Height = this.Height;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    panel1.Size = panel1Size;
                    panelMain.Size = panelMainSize;
                    // flowPanelMenuSize.Height = flowPanelMenuSize.Height;
                }
            }
            base.OnResize(e);
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            //UC_Education_Formation.LoadDatagriEducation_Formations();
        }


        private void test1_Load(object sender, EventArgs e)
        {

        }

        private void uc_Filtering1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Adding UC to MainPAnel

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        /// <summary>
        /// Change la couleur des autres bouttons quand l'user click sur un des bouttons du menu
        /// </summary>
        private void UnselectButtons()
        {
            foreach (Control ctrl in this.flowPanelMenu.Controls)
            {
                if (ctrl.Name != bouttonMenuPressed.Name)
                    ctrl.BackColor = Color.FromArgb(24, 26, 56);
            }
        }


        private void refreshFormAgent()
        {
            MessageBox.Show("REFRESH");
        }

        private void clickButtonAgentMenu(object sender, EventArgs e)
        {
            MenuBtnAgent.PerformClick();
        }

        private void AgentSelectedInFormationCard(long matricule)
        {
            UC_Agent.Agent_Matricule = matricule;
        }



        #endregion

        #region Timer
        #endregion

        #region Threading
        static void LoadEducation_FormationsThread()
        {
            Thread y = new Thread(LoadUsersThread);
            y.Start();
            Education_FormationDataAccess db = new Education_FormationDataAccess();
            globalListEducation_Formations = db.LoadAllEducation_Formations();

        }

        static void LoadUsersThread()
        {

            AgentDataAccess db = new AgentDataAccess();
            globalListAgents = db.LoadAllAgents();

        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Etes-vous sûr de vouloir quitter l'application?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

    }
}
