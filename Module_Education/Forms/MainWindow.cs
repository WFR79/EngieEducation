using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Forms.UserControls;
using Module_Education.Helper;
using Module_Education.Models;
using Module_Education.Repositories;
using Module_Education.UserControls;
using SynapseCore.Controls;

namespace Module_Education
{


    public partial class MainWindow : Form
    {

        private delegate void SafeCallDelegate(string text);
        private Button button1;
        private TextBox textBox1;
        public static List<Education_Formation> globalListEducation_Formations;
        public static List<Education_Agent> globalListAgents;
        public static List<Education_Provider> globalListProviders;
        public static List<Education_Agent> globalListCertificateAgents;
        public static AgentDataAccess dbAgent = new AgentDataAccess();

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();

        private Button bouttonMenuPressed;
        private Thread thread2 = null;
        bool IsMenuShown = true;

        #region size Management
        private FormWindowState prevState;
        private long AgentIdSeleted;
        private Size panel1Size;
        private Size panelMainSize;
        private Size flowPanelMenuSize;

        public UserControl ActiveUserControl;
        #endregion

        #region UCEducation_Formation
        public delegate void controlcall(object sender, EventArgs e);
        public delegate void menuAgentClick(string formationSAPNum);
        public delegate void menuProviderClick(long providerId);


        public delegate void functioncall(long message);
        public delegate void refreshFicheAgent(long UserId);
        public delegate void ClickOnFormationMenuBtn(string sapFormation);


        private event menuProviderClick ReceiverClickButtonProvider;

        private event menuAgentClick ReceiverClickButtonFormation;

        private event controlcall ReceiverClickButton;
        private event refreshFicheAgent ReceiverRefreshListeAgent;
        private event functioncall ReceiverFromFicheFormation;

        private event ClickOnFormationMenuBtn ReceiverFromMatriceFormation;

        private event menuProviderClick ReceiverClickProvider;


        public long UserIDSelected;
        #endregion

        public MainWindow()
        {
            //panelMain.Controls.Add(UC_Education_Formation.Instance);
            //panelMain.Controls.Add(UC_Agent.Instance);

            InitializeComponent();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment cd = ApplicationDeployment.CurrentDeployment;
                this.Text = "Module Education Version : " + cd.CurrentVersion.ToString();



            }
            this.Size = new Size(1366, 768);

            prevState = this.WindowState;
            panel1Size = panel1.Size;
            panelMainSize = panelMain.Size;
            //flowPanelMenuSize = flowPanelMenu.Size;

            Thread y = new Thread(LoadEducation_FormationsThread);
            y.Start();
            LoadMainWindow();
            //lblNoticeBeta.Left = (this.ClientSize.Width - lblNoticeBeta.Width) / 2;
            //lblNoticeBeta.Top = (this.ClientSize.Height - lblNoticeBeta.Height) / 2;
            //lblBetaVersion.Left = (this.ClientSize.Width - lblBetaVersion.Width) / 2;
            //lblBetaVersion.Top = (this.ClientSize.Height - lblBetaVersion.Height) / 2;
            //lblTitleApp.Left = (this.ClientSize.Width - lblTitleApp.Width) / 2;
            //lblTitleApp.Top = (this.ClientSize.Height - lblTitleApp.Height) / 2;
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

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        public void MenuBtnEducation_Formation_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            //Add module1 to panel control
            //flowPanelMenu.Hide();
            ActiveUserControl = UCEducation_Formation.Instance;
            if (!panelMain.Controls.Contains(UCEducation_Formation.Instance))
            {
                panelMain.Controls.Add(UCEducation_Formation.Instance);
                UCEducation_Formation.Instance.Dock = DockStyle.Fill;
                UCEducation_Formation.Instance.BringToFront();

                ReceiverClickButton += new controlcall(clickButtonAgentMenu);
                UCEducation_Formation.Instance.MainWindowPointerMenuBtnAgent = ReceiverClickButton;

                ReceiverClickButtonFormation += new menuAgentClick(clickButtonFormationMenu);
                UC_Agent.Instance.PointerButtonMenuFormation = ReceiverClickButtonFormation;

                ReceiverFromFicheFormation += new functioncall(AgentSelectedInFormationCard);
                UCEducation_Formation.Instance.PointerFormation = ReceiverFromFicheFormation;



                ReceiverRefreshListeAgent += new refreshFicheAgent(refreshFormAgent);
                UCEducation_Formation.Instance.PointerRefreshFicheAgent = ReceiverRefreshListeAgent;


                ReceiverClickProvider += new menuProviderClick(clickProviderMenuButton);
                UCEducation_Formation.Instance.MainWindowPointerMenuBtnProvider = ReceiverClickProvider;
            }
            else
            {
                UCEducation_Formation.Instance.BringToFront();
            }

            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
            // Add the control to the panel  
        }

        private void clickProviderMenuButton(long providerId)
        {
            UC_Provider.Instance.providerSelected = dbEntities.Education_Provider.Where(w => w.Provider_Id == providerId).FirstOrDefault();
            btnMenu_Provider.PerformClick();
        }

        private void MenuAgenClick(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            ActiveUserControl = UC_Agent.Instance;

            //Add module1 to panel control
            if (!panelMain.Controls.Contains(UC_Agent.Instance))
            {
                panelMain.Controls.Add(UC_Agent.Instance);
                UC_Agent.Instance.Dock = DockStyle.Fill;
                UC_Agent.Instance.BringToFront();
                UC_Agent.UserIDSelected = UserIDSelected;

                ReceiverClickButtonFormation += new menuAgentClick(clickButtonFormationMenu);
                UC_Agent.Instance.PointerButtonMenuFormation = ReceiverClickButtonFormation;

                ReceiverRefreshListeAgent += new refreshFicheAgent(refreshFormAgent);
                UCEducation_Formation.Instance.PointerUCAgent_Refresh = ReceiverRefreshListeAgent;


            }
            else
            {
                UC_Agent.Instance.BringToFront();
            }
            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        private void btnMenu_Provider_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);

            //Add module1 to panel control
            if (!panelMain.Controls.Contains(UC_Provider.Instance))
            {
                panelMain.Controls.Add(UC_Provider.Instance);
                UC_Provider.Instance.Dock = DockStyle.Fill;
                UC_Provider.Instance.BringToFront();

                //ReceiverClickButtonFormation += new menuAgentClick(clickButtonFormationMenu);
                //UC_Provider.Instance.PointerButtonMenuFormation = ReceiverClickButtonFormation;

                //ReceiverRefreshListeAgent += new refreshFicheAgent(refreshFormAgent);
                //UC_Provider.Instance.PointerUCAgent_Refresh = ReceiverRefreshListeAgent;

                ReceiverClickProvider += new menuProviderClick(clickProviderMenuButton);
                UC_Provider.Instance.MainWindowPointerMenuBtnProvider = ReceiverClickProvider;

            }
            else
            {
                UC_Provider.Instance.BringToFront();
            }
            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        private void MenuBtnAuthentification_Click(object sender, EventArgs e)
        {
            ActiveUserControl = UC_GrpAgents.Instance;
            Button button = ((Button)sender);

            if (!panelMain.Controls.Contains(UC_GrpAgents.Instance))
            {
                panelMain.Controls.Add(UC_GrpAgents.Instance);
                UC_GrpAgents.Instance.Dock = DockStyle.Fill;
                UC_GrpAgents.Instance.BringToFront();
            }
            else
                UC_GrpAgents.Instance.BringToFront();

            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        private void btnMatriceFormation_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);

            //Add module1 to panel control
            if (!panelMain.Controls.Contains(UC_MatriceFormations.Instance))
            {
                panelMain.Controls.Add(UC_MatriceFormations.Instance);
                UC_MatriceFormations.Instance.Dock = DockStyle.Fill;
                UC_MatriceFormations.Instance.BringToFront();

                ReceiverFromMatriceFormation += new ClickOnFormationMenuBtn(clickButtonFormationMenu);
                UC_MatriceFormations.Instance.PointerFormation = ReceiverFromMatriceFormation;


            }
            else
            {
                UC_MatriceFormations.Instance.BringToFront();
            }
            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        private void MenuBtnCertificate_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);

            //Add module1 to panel control
            if (!panelMain.Controls.Contains(UC_Certification.Instance))
            {
                panelMain.Controls.Add(UC_Certification.Instance);
                UC_Certification.Instance.Dock = DockStyle.Fill;
                UC_Certification.Instance.BringToFront();

                ReceiverFromMatriceFormation += new ClickOnFormationMenuBtn(clickButtonFormationMenu);
                UC_Certification.Instance.PointerFormation = ReceiverFromMatriceFormation;

                ReceiverFromFicheFormation += new functioncall(AgentSelectedInFormationCard);
                UC_Certification.Instance.PointerFormation = ReceiverFromFicheFormation;

                ReceiverRefreshListeAgent += new refreshFicheAgent(refreshFormAgent);
                UC_Certification.Instance.MainWindowPointerMenuBtnAgent = ReceiverRefreshListeAgent;
            }
            else
            {
                UC_Certification.Instance.BringToFront();
            }
            button.BackColor = Color.FromArgb(67, 100, 214);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            bouttonMenuPressed = (Button)button;
            UnselectButtons();
        }

        /// <summary>
        /// Change la couleur des autres bouttons quand l'user click sur un des bouttons du menu
        /// </summary>
        private void UnselectButtons()
        {
            foreach (Button btn in this.flowPanelMenu.Controls)
            {
                if (btn.Name != bouttonMenuPressed.Name)
                {
                    btn.BackColor = Color.FromArgb(0, 115, 204);
                    btn.FlatAppearance.BorderSize = 0;

                }
            }
        }

        private void refreshFormAgent(long UserId)
        {
            UserIDSelected = UserId;
            MenuBtnAgent.PerformClick();

            UC_Agent.Instance.UserRecord_LoadUser(UserId);

            //MessageBox.Show("REFRESH");
        }

        private void clickButtonAgentMenu(object sender, EventArgs e)
        {
            MenuBtnAgent.PerformClick();
        }

        private void clickButtonFormationMenu(string formationSAPNum)
        {
            UCEducation_Formation.FormationIDSelected = formationSAPNum;
            UCEducation_Formation.Instance.LoadFicheEducation_Formation(formationSAPNum);
            MenuBtnEducation_Formation.PerformClick();


        }

        private void AgentSelectedInFormationCard(long matricule)
        {
            UC_Agent.Agent_Matricule = matricule;
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
            Thread y = new Thread(LoadCertificateAgents);
            y.Start();
            AgentDataAccess db = new AgentDataAccess();
            globalListAgents = db.LoadAllAgents();
            UC_Agent.dtAgents = ToDataTable<Education_Agent>(globalListAgents);


        }

        private static void LoadCertificateAgents()
        {
            globalListCertificateAgents = dbAgent.LoadAllAgentsCertificate();

        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            try
            {
                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
                return new DataTable();
            }
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

        private void lblHelloUsername_Click(object sender, EventArgs e)
        {
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //    if (flowPanelMenu.Visible && ActiveUserControl != null)
            //    {
            //        switch (ActiveUserControl.Name)
            //        {
            //            case "UCEducation_Formation":
            //                this.panelMain.Dock = DockStyle.Fill;
            //                //ActiveUserControl.Size = newSize;
            //                UCEducation_Formation.Instance.Dock = DockStyle.Left;
            //                break;
            //        }
            //        flowPanelMenu.Visible = false;
            //    }

            //    else
            //    {
            //        if (ActiveUserControl != null)
            //        {
            //            switch (ActiveUserControl.Name)
            //            {
            //                case "UCEducation_Formation":
            //                    UCEducation_Formation.Instance.Dock = DockStyle.Right;
            //                    int xCalculated = (UCEducation_Formation.Instance.Location.X - 30);
            //                    break;
            //            }
            //        }

            //        flowPanelMenu.Visible = true;

            //    }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
