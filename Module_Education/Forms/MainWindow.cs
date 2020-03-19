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
using Module_Education.UserControls;

namespace Module_Education
{


    public partial class MainWindow : Form
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
        public delegate void functioncall(string message);
        public delegate void refreshForm();


        private event controlcall formControlPointer;
        private event refreshForm refreshFormPointer;
        private event functioncall formFunctionPointer;

        public int UserIDSelected;
        #endregion

        public MainWindow()
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

            //MenuBtnEducation_Formation.PerformClick();
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

        private void button_ShowHideMenu_Click(object sender, EventArgs e)
        {
            if (flowPanelMenu.Visible)
            {
                IsMenuShown = false;
                timerMenu.Start();
            }
            else
            {
                flowPanelMenu.Show();
                IsMenuShown = true;
                timerMenu.Start();

            }

        }
        #endregion

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Adding UC to MainPAnel
        private void MenuAgenClick(object sender, EventArgs e)
        {
            Control button = ((Control)sender);

            //Add module1 to panel control
            if (!panelMain.Controls.Contains(UC_Agent.Instance))
            {
                panelMain.Controls.Add(UC_Agent.Instance);
                UC_Agent.Instance.Dock = DockStyle.Fill;
                UC_Agent.Instance.BringToFront();
                UC_Agent.UserIDSelected = UserIDSelected;
            }
            else
            {
                UC_Agent.Instance.BringToFront();
            }
            button.BackColor = Color.FromArgb(67, 100, 214);
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        public void MenuBtnEducation_Formation_Click(object sender, EventArgs e)
        {
            Control button = ((Control)sender);
            //Add module1 to panel control
            //flowPanelMenu.Hide();
            if (!panelMain.Controls.Contains(UCEducation_Formation.Instance))
            {
                panelMain.Controls.Add(UCEducation_Formation.Instance);
                UCEducation_Formation.Instance.Dock = DockStyle.Fill;
                UCEducation_Formation.Instance.BringToFront();

                formControlPointer += new controlcall(clickButtonAgentMenu);
                UCEducation_Formation.Instance.userControlPointer = formControlPointer;
                formFunctionPointer += new functioncall(Replicate);
                UCEducation_Formation.Instance.userFunctionPointer = formFunctionPointer;

                refreshFormPointer += new refreshForm(refreshFormAgent);
                UCEducation_Formation.Instance.refreshFormPointer = refreshFormPointer;

            }
            else
            {
               
                UCEducation_Formation.Instance.BringToFront();
            }

            button.BackColor = Color.FromArgb(67, 100, 214);
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
            // Add the control to the panel  
        }

        private void MenuBtnAuthentification_Click(object sender, EventArgs e)
        {
            if (!panelMain.Controls.Contains(UC_Authentification.Instance))
            {
                panelMain.Controls.Add(UC_Authentification.Instance);
                UC_Authentification.Instance.Dock = DockStyle.Fill;
                UC_Authentification.Instance.BringToFront();
            }
            else
                UC_Authentification.Instance.BringToFront();
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

        private void Replicate(string message)
        {
            UC_Agent.UserIDSelected = Convert.ToInt32(message);

        }


        
        #endregion

        #region Timer
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (IsMenuShown)
            {
                if (flowPanelMenu.Width >= 210)
                {
                    timerMenu.Stop();
                }
                flowPanelMenu.Width += 35;
            }
            else
            {
                if (flowPanelMenu.Width <= 0)
                {
                    flowPanelMenu.Hide();
                    timerMenu.Stop();
                }
                flowPanelMenu.Width -= 35;
            }
        }
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


        private void pictureBoxExit_Click(object sender, EventArgs e)
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
