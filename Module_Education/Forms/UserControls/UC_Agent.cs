﻿using Module_Education.Models;
using Module_Education.Helper;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Classes;
using System.Text.RegularExpressions;
using Module_Education.Forms;
using Module_Education.Classes.Extensions;
using System.Diagnostics;
using Module_Education.Repositories;

namespace Module_Education
{
    public partial class UC_Agent : UserControl
    {
        #region déclarations

        #region Public events

        public class SortEventArgs : EventArgs
        {
            public string SortString { get; set; }
            public bool Cancel { get; set; }

            public SortEventArgs()
            {
                SortString = null;
                Cancel = false;
            }
        }

        public class FilterEventArgs : EventArgs
        {
            public string FilterString { get; set; }
            public bool Cancel { get; set; }

            public FilterEventArgs()
            {
                FilterString = null;
                Cancel = false;
            }
        }

        public event EventHandler<SortEventArgs> SortStringChanged;

        public event EventHandler<FilterEventArgs> FilterStringChanged;

        #endregion

        #region Repositories
        public BindingSource ds_Agents = new BindingSource();

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        private AgentDataAccess db = new AgentDataAccess();
        private EquipeDataAccess dbEquipe = new EquipeDataAccess();
        private Education_FormationDataAccess dbEducation_Formation = new Education_FormationDataAccess();


        private UserStatusDataAccess dbUserStatus = new UserStatusDataAccess();
        private Education_HabilitationDataAccess dbEducation_Habilitation = new Education_HabilitationDataAccess();
        private FunctionDataAccess dbFunction = new FunctionDataAccess();
        private RoleEPIDataAccess dbEPI = new RoleEPIDataAccess();
        private RoleAstreinteDataAccess dbAstreinte = new RoleAstreinteDataAccess();
        private InRouteRepository dbInRoute = new InRouteRepository();
        private AgentPassportSafetyRepository dbAgentPassportSafety = new AgentPassportSafetyRepository();
        private AgentPassportBusinessRepository dbAgentPassportBusinessRep = new AgentPassportBusinessRepository();


        #endregion

        #region Pagination
        IPagedList<Education_Formation> listPagedFormation;
        List<Education_Agent> listAgentFiltered;
        IPagedList<Education_Agent> listUserPaged;
        public int pageSize;
        #endregion

        #region Datgrid Certifications

        List<Education_AgentPassportBusiness> listAgentPassportBusiness;
        List<Education_AgentPassportSafety> listAgentPassportSafety;

        Size dgPassportSafetyDynSize;
        Size dgPassportBusinessDynSize;
        Size dgCertFuncDynSize;
        Size dgCertOPPyDynSize;
        Size dgPassportDesignDynSize;

        #endregion
        List<long> ListOfMatriculeSelected = new List<long>();


        private Education_Agent CurrentUser = new Education_Agent();
        private bool isModified = false;
        private bool alreadyLoadedForm = false;

        private static UC_Agent _instance;
        public static long UserIDSelected;
        public static long Agent_Matricule;

        private event refreshForm receiverFromFormationCard;
        public event agentEditLoad ReceiverLoadEditAgent;
        public delegate void agentEditLoad(long Agent_Id);
        //public delegate void refreshForm(long userId);
        public delegate void refreshForm(long Agent_Matricle);

        public delegate void refreshFicheAgent(long UserId);
        private event refreshFicheAgent ReceiverRefreshListeAgent;


        public Delegate PointerButtonMenuFormation;
        public Delegate PointerEditAgent { get; internal set; }

        public Delegate PointerAgentMenuButton;
        public Delegate userFunctionPointer;
        int pageNumber = 1;

        #endregion

        #region class properties

        private List<string> _sortOrderList = new List<string>();
        private List<string> _filterOrderList = new List<string>();
        private List<string> _filteredColumns = new List<string>();

        private bool _loadedFilter = false;
        private string _sortString = null;
        private string _filterString = null;
        private string formationSAP;

        #endregion

        public static UC_Agent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Agent();
                return _instance;
            }
        }


        public UC_Agent()
        {
            InitializeComponent();
            LoadComboboxs();
            LoadDatagridAgentAsync();
            receiverFromFormationCard += new refreshForm(refreshFormAgent);
          

            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            InitEventsReceiver();
            this.EnableTab(page, false);
        }

        public static void RefreshReceiver(long AgentId)
        {

        }

        private void InitEventsReceiver()
        {
            if (ReceiverRefreshListeAgent == null)
            {
                ReceiverRefreshListeAgent += new refreshFicheAgent(UserRecord_LoadUser);
                UCEducation_Formation.Instance.PointerUCAgent_Refresh = ReceiverRefreshListeAgent;

               

            }
        }

        private void refreshFormAgent(string Agent_Matricle)
        {
            throw new NotImplementedException();
        }

        public void LoadComboboxs()
        {
            //Equipe
            comboBoxEquipe.DataSource = dbEquipe.LoadAllEquipes();
            comboBoxEquipe.DisplayMember = "Equipe_Name";

            //Status
            comboBoxStatut.DataSource = dbUserStatus.LoadAllStatus();
            comboBoxStatut.DisplayMember = "AgentStatus_Name";

            //Line Manager
            comboBoxRespHierarchique.DataSource = MainWindow.globalListAgents;
            comboBoxRespHierarchique.ValueMember = "Agent_Id";
            comboBoxRespHierarchique.DisplayMember = "User_FullName";

            //Education_Habilitation
            comboBoxEducation_Habilitation.DataSource = dbEducation_Habilitation.LoadAllEducation_Habilitation();
            comboBoxEducation_Habilitation.ValueMember = "Habilitation_Name";

            //Function
            comboBoxFunction.DataSource = dbFunction.LoadAllFunctions();
            comboBoxFunction.ValueMember = "Function_Name";

            //EPI
            comboBoxEPI.DataSource = dbEPI.LoadAllRoleEPI();
            comboBoxEPI.ValueMember = "RoleEPI_Name";

            //Astreinte
            comboBoxAstreinte.DataSource = dbAstreinte.LoadAllRoleAstreinte();
            comboBoxAstreinte.ValueMember = "RoleAstreinte_Name";

            // En trajet
            comboTrajet.DataSource = dbInRoute.LoadAllInRoute();
            comboTrajet.ValueMember = "InRoute_Name";
        }

        #region Tab Liste

        public async Task LoadDatagridAgentAsync()
        {
            List<Education_Agent> listAgent = new List<Education_Agent>();
            try
            {

                //List<User> lUsers = db.LoadAllAgents();
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) =>
                {

                    progressBarDgAgent.Value = report.PercentCompleted;
                    progressBarDgAgent.Update();
                };
                pageSize = Int32.Parse(tbNbrRows.Text);
                listUserPaged = await LoadTaskDatagridAgent();


                //lblMin.Text = listUserPaged.FirstItemOnPage.ToString();
                //lblMax.Text = listUserPaged.LastItemOnPage.ToString();

                dG_Agents.DataSource = GetDataSource(listUserPaged);
                lblNbrRowsAgent.Text = "Nombre total d'Agents : " + listUserPaged.TotalItemCount.ToString();
                //dG_Agents.DataSource = listUserPaged;
                dG_Agents.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.LogError(ex, Environment.UserName);
            }

        }

        //public void LoadDatagridAgent(string filter)
        //{
        //    Education_Formation Education_Formation = new Education_Formation();
        //    List<Education_Agent> lUsersFiltetered = db.LoadAllAgentsFiltered(Education_Formation);
        //    BindingSource source = new BindingSource
        //    {
        //        DataSource = lUsersFiltetered
        //    };
        //    source.ResetBindings(true);
        //    dG_Agents.DataSource = source;

        //    dG_Agents.Refresh();
        //    lblNbrRowsAgent.Text = listUserPaged.TotalItemCount.ToString();



        //}

        private async Task<IPagedList<Education_Agent>> LoadTaskDatagridAgent(int pagNumber = 1, int pageSize = 50)
        {
            try
            {
                List<Education_Agent> tempUserList = new List<Education_Agent>();
                var progressReport = new ProgressReport();
                if (pageNumber == 0)
                {
                    pageNumber = 1;
                }
                return await Task.Factory.StartNew(() =>
                {
                    using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    {
                        if (MainWindow.globalListAgents == null)
                        {
                            progressReport.PercentCompleted = 0;
                            return dbList.Education_Agent
                            .Include("Education_Equipe")
                            .Include("Education_Function")
                            .Include("Education_GroupLearner_Agent")
                            //.Include("Education_Matrice_User")
                            .Include("Education_MovementAgent")
                            .Include("Education_MovementAgent1")
                            .Include("Education_RoleAstreinte")
                            .Include("Education_RoleEPI")
                            .Include("Education_AgentStatus")
                            .Include("Education_Agent_Formation")
                            .Include("Education_Habilitation")
                            .Include("Education_Role")
                            //.Include("User2")
                            .OrderBy(p => p.Agent_Id).ToPagedList(pagNumber, pageSize); ;
                            progressReport.PercentCompleted = 100;
                            //progress.Report(progressReport);
                        }
                        else
                        {
                            return MainWindow.globalListAgents.ToPagedList(pagNumber, pageSize); ;

                        }

                    }


                });

            }
            catch (StackOverflowException ex)
            {
                Logger.LogError(ex, "UC Education_Formation");
                throw;
            }
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async void btn_Next_Click(object sender, EventArgs e)
        {
            if (listUserPaged.HasNextPage)
            {
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) =>
                {

                    progressBarDgAgent.Value = report.PercentCompleted;
                    progressBarDgAgent.Update();
                };

                listUserPaged = await LoadTaskDatagridAgent(++pageNumber, pageSize);

                //lblMin.Text = listUserPaged.FirstItemOnPage.ToString();
                //lblMax.Text = listUserPaged.LastItemOnPage.ToString(); 


                btn_NextAgent.Enabled = listUserPaged.HasPreviousPage;
                btn_PreviousAgent.Enabled = listUserPaged.HasNextPage;

                dG_Agents.DataSource = GetDataSource(listUserPaged);
                //dG_Agents.DataSource = listUserPaged;
                dG_Agents.Refresh();
            }
        }

        private async void btn_Previous_Click(object sender, EventArgs e)
        {
            if (listUserPaged.HasPreviousPage)
            {
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) =>
                {

                    progressBarDgAgent.Value = report.PercentCompleted;
                    progressBarDgAgent.Update();
                };
                listUserPaged = await LoadTaskDatagridAgent(--pageNumber, pageSize);

                //lblMin.Text = listUserPaged.FirstItemOnPage.ToString();
                //lblMax.Text = listUserPaged.LastItemOnPage.ToString();

                btn_NextAgent.Enabled = listUserPaged.HasPreviousPage;
                btn_PreviousAgent.Enabled = listUserPaged.HasNextPage;

                dG_Agents.DataSource = GetDataSource(listUserPaged);
                dG_Agents.Refresh();
            }
        }

        private object GetDataSource(List<Education_AgentPassportBusiness> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGPassportBusiness(o)
            {
                AgentPassportBusinessDesc = o.Education_PassportBusiness.PassportBusiness_Name,
                AgentPassportBusinessIsCertifiied = o.AgentPassportBusiness_HierarchyCertification,
                AgentPassportBusinessReturnDate = o.AgentPassportBusiness_ReturnDate,
                AgentPassportBusinessSendingDate = o.AgentPassportBusiness_SendingDate,
                AgentPassportSRemark = o.AgentPassportBusiness_Remark


            }).ToList();


            return dataSource;
        }


        private object GetDataSource(List<Education_AgentPassportSafety> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGPassportSafety(o)
            {
                AgentPassportSafetyLevelPS = o.AgentPassportSafety_LevelPS,
                AgentPassportSaferyIsCertifiied = o.AgentPassportSafety_HierarchyCertification,
                AgentPassportSafetyReturnDate = o.AgentPassportSafety_ReturnDate,
                AgentPassportSafetySendingDate = o.AgentPassportSafety_SendingDate,
                AgentPassportSafetyRemark = o.AgentPassportSafety_Remarks,
                AgentPassportSafetyRemarkPay = o.AgentPassportSafety_PayRemarks,

            }).ToList();

            
            return dataSource;
        }

        private object GetDataSource(IPagedList<Education_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o)
            {
                Agent_Matricule = o.Agent_Matricule,
                Agent_FirstName = o.Agent_FirstName,
                Agent_Name = o.Agent_Name,

                Function_Name = o.Agent_Function == null ? null : dbEntities.Education_Function.Where(x => x.Function_Id == o.Agent_Function).FirstOrDefault().Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                Agent_Admin = o.Agent_Admin,
                Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,
                Agent_InRoute = o.Agent_InRoute,
                Agent_IsWorkManager = o.Agent_IsWorksManager,
                Agent_DateSeniority = o.Agent_DateSeniority,
                Agent_DateOfEntry = o.Agent_DateOfEntry,
                Agent_DateFunction = o.Agent_DateFunction,
                Agent_Habilitation = o.Education_Habilitation == null ? null : o.Education_Habilitation.Habilitation_Name,
                Agent_Status = o.Education_AgentStatus == null ? null : o.Education_AgentStatus.AgentStatus_Name,
                Agent_Etat = o.Agent_Etat


            }).ToList();

            lblMin.Text = listPaged.FirstItemOnPage.ToString();
            lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
        }

        private object GetDataSource(IPagedList<Education_Formation> listPagedFormation)
        {
            object dataSource = listPagedFormation.Select(o => new MyColumnCollectionDGFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_DurationInDays = o.Formation_DurationInDays,
                Formation_SAP = o.Formation_SAP,
                //Column_LongTitle = o.Education_Formation_LongTitle,
                Formation_YearOfCreation = o.Formation_YearOfCreation,
                Formation_CapaciteMin = o.Formation_MinCapacity,
                Formation_CapaciteMax = o.Formation_MaxCapacity,
                Formation_IsInterne = o.Formation_IsInterne,
                Formation_CapaciteOptimale = o.Formation_OptimalCapacity,


            }).ToList();

            return dataSource;
        }

        #endregion

        #region Tab Fiche
        public void UserRecord_LoadUser(long userID)
        {

            DeleteButtonSavingAgent();
            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            this.tabControlAgentList.SelectedTab = page;

            this.EnableTab(page, true);

            Education_Agent userRecord = db.LoadSingleUserWithMatricule(userID);
            CurrentUser = userRecord;
            LoadCertifications();
            if (userRecord != null)
            {
                UserRecord_FillLabels(userRecord);
                UserRecord_FillLabelsActif(userRecord);

                UserRecord_FillMatricule(userRecord);
                UserRecord_FillAdmin(userRecord);
                UserRecord_SelectEquipe(userRecord);
                UserRecord_PickDateOfEntry(userRecord);
                UserRecord_PickUser_DateSeniority(userRecord);
                UserRecord_PickDateFunction(userRecord);
                UserRecord_FillRemarks(userRecord);
                UserRecord_SelectRespHiérarchique(userRecord);
                UserRecord_SelectStatut(userRecord);
                UserRecord_SelectInRoute(userRecord);

                UserRecord_SelectFunction(userRecord);

                UserRecord_SelectRoleEPI(userRecord);
                UserRecord_SelectRoleAstreinte(userRecord);

                UserRecord_SelectEducation_Habilitation(userRecord);
                UserRecord_CheckRescueCheckBox(userRecord);
                UserRecord_CheckIsWorksManager(userRecord);

                UserRecord_LoadEducation_FormationsOfUser(userRecord);
                CreateButtonSavingAgent();
            }
        }

        private void LoadCertifications()
        {
            LoadPassportSafety();
            LoadPassportBusiness();
        }

        private void LoadPassportSafety()
        {
            DataGridView dgPassportSafetyDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportSafetyDyn.Location = new Point(155, 533);
            dgPassportSafetyDyn.BackgroundColor = Color.White;

            this.tbFicheAgent.Controls.Add(dgPassportSafetyDyn);
            dgPassportSafetyDyn.Show();
            listAgentPassportSafety = dbAgentPassportSafety.LoadPassportSafetyAgent(CurrentUser);
            dgPassportSafetyDyn.DataSource = GetDataSource(listAgentPassportSafety);

            var totalHeight = dgPassportSafetyDyn.Rows.GetRowsHeight(states) + dgPassportSafetyDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportSafetyDyn.Columns.GetColumnsWidth(states) + dgPassportSafetyDyn.RowHeadersWidth;
            dgPassportSafetyDyn.ClientSize = new Size(totalWidth, totalHeight);
            dgPassportSafetyDynSize = dgPassportSafetyDyn.Size;
        }

        private void LoadPassportBusiness()
        {
            DataGridView dgPassportBusinessDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportBusinessDyn.Location = new Point(155 , (533 + dgPassportSafetyDynSize.Height));
            dgPassportBusinessDyn.BackgroundColor = Color.White;

            this.tbFicheAgent.Controls.Add(dgPassportBusinessDyn);
            dgPassportBusinessDyn.Show();
            listAgentPassportBusiness = dbAgentPassportBusinessRep.LoadPassportBusinessAgent(CurrentUser);
            dgPassportBusinessDyn.DataSource = GetDataSource(listAgentPassportBusiness);

            var totalHeight = dgPassportBusinessDyn.Rows.GetRowsHeight(states) + dgPassportBusinessDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportBusinessDyn.Columns.GetColumnsWidth(states) + dgPassportBusinessDyn.RowHeadersWidth;
            dgPassportBusinessDyn.ClientSize = new Size(totalWidth, totalHeight);
            dgPassportBusinessDynSize = dgPassportBusinessDyn.Size;

        }

        private void LoadCertificationFunc()
        {
            DataGridView dgPassportSafetyDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportSafetyDyn.Location = new Point(155, 533);
            dgPassportSafetyDyn.BackgroundColor = Color.White;

            this.tbFicheAgent.Controls.Add(dgPassportSafetyDyn);
            dgPassportSafetyDyn.Show();
            listAgentPassportBusiness = dbAgentPassportBusinessRep.LoadPassportBusinessAgent(CurrentUser);
            dgPassportSafetyDyn.DataSource = GetDataSource(listAgentPassportSafety);

            var totalHeight = dgPassportSafetyDyn.Rows.GetRowsHeight(states) + dgPassportSafetyDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportSafetyDyn.Columns.GetColumnsWidth(states) + dgPassportSafetyDyn.RowHeadersWidth;
            dgPassportSafetyDyn.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void LoadCertificationOPP()
        {
            DataGridView dgPassportSafetyDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportSafetyDyn.Location = new Point(155, 533);
            dgPassportSafetyDyn.BackgroundColor = Color.White;

            this.tbFicheAgent.Controls.Add(dgPassportSafetyDyn);
            dgPassportSafetyDyn.Show();
            listAgentPassportSafety = dbAgentPassportSafety.LoadPassportSafetyAgent(CurrentUser);
            dgPassportSafetyDyn.DataSource = GetDataSource(listAgentPassportSafety);

            var totalHeight = dgPassportSafetyDyn.Rows.GetRowsHeight(states) + dgPassportSafetyDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportSafetyDyn.Columns.GetColumnsWidth(states) + dgPassportSafetyDyn.RowHeadersWidth;
            dgPassportSafetyDyn.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void LoadPassportDesign()
        {
            DataGridView dgPassportSafetyDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportSafetyDyn.Location = new Point(155, 533);
            dgPassportSafetyDyn.BackgroundColor = Color.White;

            this.tbFicheAgent.Controls.Add(dgPassportSafetyDyn);
            dgPassportSafetyDyn.Show();
            listAgentPassportSafety = dbAgentPassportSafety.LoadPassportSafetyAgent(CurrentUser);
            dgPassportSafetyDyn.DataSource = GetDataSource(listAgentPassportSafety);

            var totalHeight = dgPassportSafetyDyn.Rows.GetRowsHeight(states) + dgPassportSafetyDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportSafetyDyn.Columns.GetColumnsWidth(states) + dgPassportSafetyDyn.RowHeadersWidth;
            dgPassportSafetyDyn.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void UserRecord_LoadUserByMatricule(long agentMatricule)
        {
            DeleteButtonSavingAgent();
            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            this.EnableTab(page, true);

            Education_Agent userRecord = db.LoadSingleUserWithMatricule(agentMatricule);
            CurrentUser = userRecord;
            if (userRecord != null)
            {
                UserRecord_FillLabels(userRecord);
                UserRecord_FillLabelsActif(userRecord);

                UserRecord_FillMatricule(userRecord);
                UserRecord_FillAdmin(userRecord);
                UserRecord_SelectEquipe(userRecord);
                UserRecord_PickDateOfEntry(userRecord);
                UserRecord_PickUser_DateSeniority(userRecord);
                UserRecord_PickDateFunction(userRecord);
                UserRecord_FillRemarks(userRecord);
                UserRecord_SelectRespHiérarchique(userRecord);
                UserRecord_SelectStatut(userRecord);
                UserRecord_SelectFunction(userRecord);

                UserRecord_SelectRoleEPI(userRecord);
                UserRecord_SelectRoleAstreinte(userRecord);

                UserRecord_SelectEducation_Habilitation(userRecord);
                UserRecord_CheckRescueCheckBox(userRecord);
                UserRecord_CheckIsWorksManager(userRecord);

                UserRecord_LoadEducation_FormationsOfUser(userRecord);
                CreateButtonSavingAgent();
            }
        }

        private async Task<IPagedList<Education_Formation>> LoadDataGridFormationAsync(int pagNumber = 1, int pageSize = 50)
        {
            try
            {
                List<Education_Formation> List = new List<Education_Formation>();
                var progressReport = new ProgressReport();
                if (pageNumber == 0)
                {
                    pageNumber = 1;
                }
                return await Task.Factory.StartNew(() =>
                {

                    List = dbEducation_Formation.LoadAllEducation_FormationOfSingleAgent(CurrentUser);

                    return listPagedFormation.OrderBy(p => p.Formation_Id).ToPagedList(pagNumber, pageSize); ;


                });

            }
            catch (StackOverflowException ex)
            {
                Logger.LogError(ex, "UC Education_Formation");
                throw;
            }
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async Task LoadFormationDatagridAsync(Education_Agent currentAgent)
        {
            listPagedFormation = await LoadDataGridFormationAsync();
            btn_NextAgent.Enabled = listUserPaged.HasPreviousPage;
            btn_PreviousAgent.Enabled = listUserPaged.HasNextPage;

            dg_TABFormationsOfAgent.DataSource = GetDataSource(listPagedFormation);
            //dG_Agents.DataSource = listUserPaged;
            dg_TABFormationsOfAgent.Refresh();


        }

        private void SaveAgent(object sender, EventArgs e)
        {
            db.SaveAgent(CurrentUser);
            AutoClosingMessageBox messagebox = new AutoClosingMessageBox("Agent sauvegardé", "Success", 2000, MessageBoxIcon.Information);
            RefreshListAgent();
            ActivateModification(false);


        }

        private void RefreshListAgent()
        {
            MainWindow.globalListAgents = db.LoadAllAgents();
            dG_Agents.DataSource = GetDataSource(MainWindow.globalListAgents.ToPagedList(1, 100));

            dG_Agents.Refresh();
        }

        private void refreshFormAgentId(int userId)
        {
            tabControlAgentList.SelectedIndex = 1;
            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            this.EnableTab(page, true);
            UserRecord_LoadUser(userId);

        }

        private void refreshFormAgent(long AgentMatricule)
        {
            tabControlAgentList.SelectedIndex = 1;
            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            this.EnableTab(page, true);
            UserRecord_LoadUserByMatricule(AgentMatricule);

        }


        #endregion

        #region Controls Management


        private void UserRecord_CheckIsWorksManager(Education_Agent userRecord)
        {
            if (userRecord.Agent_IsWorksManager == true)
                checkBox_IsWorkManager.Checked = true;
            else
                checkBox_IsWorkManager.Checked = false;

        }

        private void UserRecord_CheckRescueCheckBox(Education_Agent userRecord)
        {
            if (userRecord.Agent_IsRescueWorker == true)
                checkBoxSecouriste.Checked = true;
            else
                checkBoxSecouriste.Checked = false;
        }

        public void UserRecord_FillLabelsActif(Education_Agent userRecord)
        {
            if (userRecord.Agent_Etat == true)
                labelActif.Text = "Actif";
            else
            {
                if (userRecord.Agent_Etat == false)
                {
                    labelActif.Text = "Inactif";

                }
            }

            labelActif.Text = userRecord.Agent_Etat == null | false ? "Inactif" : "Actif";
        }

        public void UserRecord_FillLabels(Education_Agent userRecord)
        {
            if (userRecord.Agent_FirstName != null && userRecord.Agent_Name != null)
                labelNameOfUser.Text = userRecord.Agent_FirstName + " " + userRecord.Agent_Name.ToUpper();
        }

        public void UserRecord_FillRemarks(Education_Agent userRecord)
        {
            if (userRecord.Agent_Remarks != null)
                richTextBoxRemarks.Text = userRecord.Agent_Remarks;
            else
            {
                richTextBoxRemarks.Text = "";

            }
        }

        public void UserRecord_FillMatricule(Education_Agent userRecord)
        {
            if (userRecord.Agent_Matricule != null)
                labelMatricule.Text = userRecord.Agent_Matricule.ToString();
        }

        public void UserRecord_FillAdmin(Education_Agent userRecord)
        {
            if (userRecord.Agent_Admin != null) { }
            textBoxAdmin.Text = userRecord.Agent_Admin;
        }

        public void UserRecord_SelectEquipe(Education_Agent userRecord)
        {
            if (userRecord.Education_Equipe != null)
                comboBoxEquipe.SelectedIndex = comboBoxEquipe.FindStringExact(userRecord.Education_Equipe.Equipe_Name);
        }

        private void UserRecord_SelectFunction(Education_Agent userRecord)
        {
            if (userRecord.Education_Function != null)
                comboBoxFunction.SelectedIndex = comboBoxFunction.FindStringExact(userRecord.Education_Function.Function_Name);
        }

        private void UserRecord_SelectEducation_Habilitation(Education_Agent userRecord)
        {
            if (userRecord.Education_Habilitation != null)
                comboBoxEducation_Habilitation.SelectedIndex = comboBoxEducation_Habilitation.FindStringExact(userRecord.Education_Habilitation.Habilitation_Name);
        }

        public void UserRecord_SelectStatut(Education_Agent userRecord)
        {
            if (userRecord.Education_AgentStatus != null)
                comboBoxStatut.SelectedIndex = comboBoxStatut.FindStringExact(userRecord.Education_AgentStatus.AgentStatus_Name);
        }

        public void UserRecord_SelectInRoute(Education_Agent userRecord)
        {
            if (userRecord.Education_InRoute != null)
            {
                comboTrajet.SelectedIndex = comboTrajet.FindStringExact(userRecord.Education_InRoute.InRoute_Name);
                cbTrajet.Checked = (bool)userRecord.Agent_InRoute;
            }
        }


        public void UserRecord_SelectRespHiérarchique(Education_Agent userRecord)
        {
            if (userRecord.Education_RoleEPI != null)
                comboBoxEPI.SelectedIndex = comboBoxRespHierarchique
                    .FindStringExact(userRecord.Education_RoleEPI.RoleEPI_Name);
        }

        private void UserRecord_SelectRoleAstreinte(Education_Agent userRecord)
        {
            if (userRecord.Agent_RoleAstreinte != null)
                comboBoxAstreinte.SelectedIndex = comboBoxAstreinte
                    .FindStringExact(userRecord.Education_RoleAstreinte.RoleAstreinte_Name);
        }

        private void UserRecord_SelectRoleEPI(Education_Agent userRecord)
        {
            if (userRecord.Education_RoleEPI != null)
                comboBoxEPI.SelectedIndex = comboBoxEPI
                    .FindStringExact(userRecord.Education_RoleEPI.RoleEPI_Name);
        }

        public void UserRecord_PickDateOfEntry(Education_Agent userRecord)
        {
            if (userRecord.Agent_DateOfEntry != null)
            {
                dateTimePicker_DateOfEntry.Value = Convert.ToDateTime(userRecord.Agent_DateOfEntry);
            }
        }

        public void UserRecord_PickDateFunction(Education_Agent userRecord)
        {
            if (userRecord.Education_Function != null)
            {
                dateTimePickerLastFunction.Value = Convert.ToDateTime(userRecord.Agent_DateFunction);
            }
        }

        public void UserRecord_PickUser_DateSeniority(Education_Agent userRecord)
        {
            if (userRecord.Agent_DateSeniority != null)
            {
                dateTimePickerSeniority.Value = Convert.ToDateTime(userRecord.Agent_DateSeniority);
            }
        }

        private void UserRecord_LoadEducation_FormationsOfUser(Education_Agent userRecord)
        {
            List<Education_Formation> listEducation_Formation = dbEducation_Formation.LoadAllEducation_FormationOfSingleAgent(userRecord);
            //foreach (Control ctrl in this.tabControlAgentList.Controls[1].Controls)
            //{
            //    Console.WriteLine(ctrl.Controls);
            //}
            dg_TABFormationsOfAgent.DataSource = listEducation_Formation;
        }

        public void CreateButtonSavingAgent()
        {
            // Creating and setting the properties of Button 
            Button ButtonSaveAgent = new Button();
            ButtonSaveAgent.Location = new Point(147, 426);
            ButtonSaveAgent.Text = "Sauver";
            ButtonSaveAgent.Name = "ButtonSaveAgent";
            ButtonSaveAgent.FlatStyle = FlatStyle.Flat;

            ButtonSaveAgent.FlatAppearance.BorderSize = 0;
            ButtonSaveAgent.AutoSize = true;
            ButtonSaveAgent.Enabled = false;
            //ButtonSaveAgent.BackColor = Color.FromArgb(106, 199, 234);
            ButtonSaveAgent.BackColor = Color.Gray;
            ButtonSaveAgent.ForeColor = Color.LightGray;

            ButtonSaveAgent.Click += new System.EventHandler(this.SaveAgent);

            //ButtonSaveAgent.Padding = new Padding(6);
            ButtonSaveAgent.Font = new Font("Arial", 18);
            ButtonSaveAgent.ForeColor = Color.LightGray;

            this.tabControlAgentList.Controls[1].Controls.Add(ButtonSaveAgent);

            // Creating and setting the properties of Button 
            Button ButtonCancelModificationAgent = new Button();
            ButtonCancelModificationAgent.Location = new Point(237, 426);
            ButtonCancelModificationAgent.Text = "Annuler";
            ButtonCancelModificationAgent.Name = "ButtonCancel";
            ButtonCancelModificationAgent.FlatStyle = FlatStyle.Flat;
            ButtonCancelModificationAgent.FlatAppearance.BorderSize = 0;

            ButtonCancelModificationAgent.AutoSize = true;
            ButtonCancelModificationAgent.Enabled = false;
            //ButtonCancelModificationAgent.BackColor = Color.OrangeRed;
            ButtonCancelModificationAgent.BackColor = Color.Gray;
            ButtonCancelModificationAgent.ForeColor = Color.LightGray;
            ButtonCancelModificationAgent.Font = new Font("Arial", 18);

            // Adding this button to the tab 
            this.tabControlAgentList.Controls[1].Controls.Add(ButtonCancelModificationAgent);

        }

        private void DeleteButtonSavingAgent()
        {
            Button buttonSave = new Button();
            buttonSave = GetSaveButton();
            if (buttonSave != null)
            {
                //this.tabControlAgentList.Controls[1].Controls.Remove(buttonSave);
            }

        }


        private Button GetSaveButton()
        {
            Button buttonSave = new Button();
            foreach (Control ctrl in this.tabControlAgentList.Controls[1].Controls)
            {
                if (ctrl.Name == "ButtonSaveAgent")
                    buttonSave = (Button)ctrl;
            }
            return buttonSave;
        }

        private Button GetCancelButton()
        {
            Button buttonCancel = new Button();
            foreach (Control ctrl in this.tabControlAgentList.Controls[1].Controls)
            {
                if (ctrl.Name == "ButtonCancel")
                    buttonCancel = (Button)ctrl;
            }
            return buttonCancel;
        }

        public void EnableTab(TabPage page, bool enable)
        {
            //page.Enabled = false;
            foreach (Control ctl in page.Controls)
                ctl.Enabled = enable;
        }

        private void ActivateModification(bool enable)
        {
            isModified = true;

            Button buttonSave = null;
            Button buttonCancel = null;

            if (buttonSave == null)
            {
                buttonSave = GetSaveButton();
                buttonCancel = GetCancelButton();

            }

            if (enable)
            {
                buttonSave.Enabled = enable;
                buttonSave.BackColor = Color.FromArgb(106, 199, 234);
                buttonSave.ForeColor = Color.LightGray;

                buttonCancel.Enabled = enable;
                buttonCancel.BackColor = Color.FromArgb(195, 29, 29);
                buttonCancel.ForeColor = Color.LightGray;
            }
            else
            {
                buttonSave.Enabled = enable;
                buttonSave.BackColor = Color.FromArgb(106, 199, 234);
                buttonSave.ForeColor = Color.LightGray;

                buttonCancel.Enabled = enable;
                buttonCancel.BackColor = Color.FromArgb(195, 29, 29);
                buttonCancel.ForeColor = Color.LightGray;
            }

        }

        #endregion

        private void richTextBoxRemarks_TextChanged(object sender, EventArgs e)
        {
            //ActivateModification();

        }

        private void dG_Agents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.RowIndex > 0)
                {
                    var userIdAgent = dgv.Rows[e.RowIndex].Cells[0].Value;
                    Form parentForm = this.Parent.FindForm() as Form;
                    var matches = parentForm.Controls.Find("flowPanelMenu", true);

                    Console.WriteLine(matches);

                    object[] arr = { userIdAgent, null };
                    tabControlAgentList.SelectedIndex = 1;
                    UserRecord_LoadUser(Convert.ToInt64(userIdAgent));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC_Education_FormationS");
                throw;
            }

        }

        private void dg_TABFormationsOfAgent_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                //dgv.ClearSelection();
                //if (dG_Agents.SelectedRows.Count > 1)
                //{
                //    ListOfMatriculeSelected.Clear();
                //    var selectedRows = dG_Agents.SelectedRows
                //                       .OfType<DataGridViewRow>()
                //                       .Where(row => !row.IsNewRow)
                //                       .ToArray();

                //    foreach (DataGridViewRow row in selectedRows)
                //    {
                //        ListOfMatriculeSelected.Add(Convert.ToInt64(row.Cells[0].Value));

                //    }

                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Aller à la fiche de la formation", GoToFormationCard));

                    int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                    //if (currentMouseOverRow >= 0)
                    //{
                    //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    //}

                    m.Show(dgv, new Point(e.X, e.Y));
                    formationSAP = dgv.SelectedCells[1].Value.ToString();

                }

                //

            }
            catch (Exception ex)
            { }
        }

        private void GoToFormationCard(object sender, EventArgs e)
        {
            object[] arr = { formationSAP, null };

            PointerButtonMenuFormation.DynamicInvoke(formationSAP);
            //PointerEditAgent.DynamicInvoke(formationSAP);
            //Pointer.DynamicInvoke(formationMatriculeSelected);
        }

        private void dG_Agents_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                ListOfMatriculeSelected.Clear();

                //dgv.ClearSelection();
                if (dG_Agents.SelectedRows.Count > 1)
                {
                    var selectedRows = dG_Agents.SelectedRows
                                       .OfType<DataGridViewRow>()
                                       .Where(row => !row.IsNewRow)
                                       .ToArray();

                    foreach (DataGridViewRow row in selectedRows)
                    {
                        ListOfMatriculeSelected.Add(Convert.ToInt64(row.Cells[0].Value));

                    }

                    if (e.Button == MouseButtons.Right)
                    {
                        //dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Visualisation des agents", VisualisationUser_CLick));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                        //if (currentMouseOverRow >= 0)
                        //{
                        //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                        //}

                        m.Show(dgv, new Point(e.X, e.Y));
                        UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    }

                }
                else
                {
                    dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                    if (dgv.SelectedCells[0].Value != null)
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            dgv.ClearSelection();
                            dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;
                            ListOfMatriculeSelected.Add(Convert.ToInt64(UserIDSelected));

                            ContextMenu m = new ContextMenu();
                            m.MenuItems.Add(new MenuItem("Modifier l'agent", EditUser_CLick));
                            m.MenuItems.Add(new MenuItem("Visualisation de l'agent", VisualisationUser_CLick));

                            int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                            //if (currentMouseOverRow >= 0)
                            //{
                            //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                            //}

                            m.Show(dgv, new Point(e.X, e.Y));
                            UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                        }
                    }
                    else
                    {


                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void EditUser_CLick(Object sender, System.EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            tabControlAgentList.SelectedIndex = 1;
            UserRecord_LoadUser(UserIDSelected);
        }

        private void VisualisationUser_CLick(Object sender, System.EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            foreach (var matricule in ListOfMatriculeSelected)
            {
                FrmAgent frmAgent = new FrmAgent(matricule);
                frmAgent.Show();
            }
        }

        private void UserRecord_LoadUserVisualisation(long userIDSelected)
        {
            DeleteButtonSavingAgent();
            TabPage page = (TabPage)this.tabControlAgentList.Controls[1];
            this.EnableTab(page, true);

            Education_Agent userRecord = db.LoadSingleUserWithMatricule(userIDSelected);
            CurrentUser = userRecord;
            if (userRecord != null)
            {
                UserRecord_FillLabels(userRecord);
                UserRecord_FillLabelsActif(userRecord);

                UserRecord_FillMatricule(userRecord);
                UserRecord_FillAdmin(userRecord);
                UserRecord_SelectEquipe(userRecord);
                UserRecord_PickDateOfEntry(userRecord);
                UserRecord_PickUser_DateSeniority(userRecord);
                UserRecord_PickDateFunction(userRecord);
                UserRecord_FillRemarks(userRecord);
                UserRecord_SelectRespHiérarchique(userRecord);
                UserRecord_SelectStatut(userRecord);
                UserRecord_SelectInRoute(userRecord);

                UserRecord_SelectFunction(userRecord);

                UserRecord_SelectRoleEPI(userRecord);
                UserRecord_SelectRoleAstreinte(userRecord);

                UserRecord_SelectEducation_Habilitation(userRecord);
                UserRecord_CheckRescueCheckBox(userRecord);
                UserRecord_CheckIsWorksManager(userRecord);

                UserRecord_LoadEducation_FormationsOfUser(userRecord);
                CreateButtonSavingAgent();
            }
        }

        private void UC_Agent_Enter(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void richTextBoxRemarks_Leave(object sender, EventArgs e)
        {
            if (CurrentUser.Agent_Remarks != richTextBoxRemarks.Text)
            {
                CurrentUser.Agent_Remarks = richTextBoxRemarks.Text;
                ActivateModification(true);
            }
        }

        private void comboBoxRespHierarchique_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_LineManager != ((Education_Agent)comboBoxRespHierarchique.SelectedItem).Agent_Id)
                {
                    CurrentUser.Agent_LineManager = ((Education_Agent)comboBoxRespHierarchique.SelectedItem).Agent_Id;
                    ActivateModification(true);
                }
            }
            catch (Exception ex) { }
        }

        private void comboBoxEducation_Habilitation_Leave(object sender, EventArgs e)
        {
            if (CurrentUser.Agent_Habilitation != ((Education_Habilitation)comboBoxEducation_Habilitation.SelectedItem).Habilitation_Id)
            {
                CurrentUser.Agent_Habilitation = ((Education_Habilitation)comboBoxEducation_Habilitation.SelectedItem).Habilitation_Id;
                ActivateModification(true);
            }
        }

        private void comboBoxFunction_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_Function != ((Education_Function)comboBoxFunction.SelectedItem).Function_Id)
                {
                    CurrentUser.Agent_Function = ((Education_Function)comboBoxFunction.SelectedItem).Function_Id;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void textBoxAdmin_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_Admin != textBoxAdmin.Text)
                {
                    CurrentUser.Agent_Admin = textBoxAdmin.Text;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void comboBoxEPI_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_RoleEPI != ((Education_RoleEPI)comboBoxEPI.SelectedItem).RoleEPI_Id)
                {
                    CurrentUser.Agent_RoleEPI = ((Education_RoleEPI)comboBoxEPI.SelectedItem).RoleEPI_Id;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void comboBoxAstreinte_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_RoleAstreinte != ((Education_RoleAstreinte)comboBoxAstreinte.SelectedItem).RoleAstreinte_Id)
                {
                    CurrentUser.Agent_RoleAstreinte = ((Education_RoleAstreinte)comboBoxAstreinte.SelectedItem).RoleAstreinte_Id;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void checkBoxSecouriste_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_IsRescueWorker != checkBoxSecouriste.Checked)
                {
                    CurrentUser.Agent_IsRescueWorker = checkBoxSecouriste.Checked;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void checkBox_IsWorkManager_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser.Agent_IsWorksManager != checkBox_IsWorkManager.Checked)
                {
                    CurrentUser.Agent_IsWorksManager = checkBox_IsWorkManager.Checked;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Environment.UserName);
            }
        }

        private void tbFiltre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCheck_PrimeRescuer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            CurrentUser.Agent_RescueBonus = cb.Checked;
            ActivateModification(true);
        }

        private void checkBoxSecouriste_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            CurrentUser.Agent_IsRescueWorker = cb.Checked;
            ActivateModification(true);

        }

        private void checkBox_IsWorkManager_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            CurrentUser.Agent_IsWorksManager = cb.Checked;
            ActivateModification(true);
        }

        private void checkBox_IsWorkManager_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            CurrentUser.Agent_IsWorksManager = cb.Checked;
            ActivateModification(true);

        }

        private void dG_Agents_MouseHover(object sender, EventArgs e)
        {

        }

        private void dG_Agents_FilterStringChanged_1(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            _filterString = e.FilterString;
            TriggerFilterStringChanged();
        }

        public async void TriggerFilterStringChanged()
        {
            //call event handler if one is attached
            FilterEventArgs filterEventArgs = new FilterEventArgs
            {
                FilterString = _filterString,
                Cancel = false
            };
            if (FilterStringChanged != null)
                FilterStringChanged.Invoke(this, filterEventArgs);
            //sort datasource
            if (filterEventArgs.Cancel == false)
            {
                if (listAgentFiltered == null)
                    listAgentFiltered = MainWindow.globalListAgents;
                listAgentFiltered = db.LoadAgentsFiltered(_filterString, listAgentFiltered);

                //listAgentFiltered = await LoadDatagridAgentAsync();


                dG_Agents.DataSource = GetDataSource(listAgentFiltered.ToPagedList(1, 100));
                BindingSource datasource = new BindingSource()
                {
                    DataSource = listUserPaged

                };
                if (datasource != null)
                    datasource.Filter = filterEventArgs.FilterString;

                dG_Agents.Refresh();
                btnClearFilters.Enabled = true;

            }
        }

        public void picExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                AutoClosingMessageBox messagebox = new AutoClosingMessageBox("Export vers le ficher excel en cours...", "Export Excel", 5000, MessageBoxIcon.Information);
                ExportToExcel exportExcel = new ExportToExcel();

                var fileExportedParth = exportExcel.Export(dG_Agents);
                AutoClosingMessageBox messageboxEndExport = new AutoClosingMessageBox("Export Terminé", "Export Excel", 1000, MessageBoxIcon.Information);
                Process.Start(fileExportedParth);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbNbrRows.Text, @"^\d+$"))
            {
                if (tbNbrRows.Text.Length > 0)
                {
                    tbNbrRows.Text = tbNbrRows.Text.Remove(tbNbrRows.Text.Length - 1);
                    pageSize = Convert.ToInt32(tbNbrRows.Text);
                }
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            listAgentFiltered = db.LoadAgentsFiltered("", listAgentFiltered);
            btnClearFilters.Enabled = false;

        }

        private void tbNbrRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listAgentFiltered == null)
                    listAgentFiltered = MainWindow.globalListAgents;

                pageSize = Convert.ToInt32(tbNbrRows.Text);

                dG_Agents.DataSource = GetDataSource(listAgentFiltered.ToPagedList(1, Convert.ToInt32(tbNbrRows.Text)));
                BindingSource datasource = new BindingSource()
                {
                    DataSource = listUserPaged

                };

                dG_Agents.Refresh();
            }
        }

        private void textBoxAdmin_Enter(object sender, EventArgs e)
        {
            TextBoxExtensions TbExtension = new TextBoxExtensions();
            TbExtension.OnFocusTextbox((TextBox)sender);
        }

        private void cbTrajet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrajet.Checked == true)
            {
                if (CurrentUser.Agent_InRoute != true)
                {
                    CurrentUser.Agent_InRoute = true;
                    ActivateModification(true);
                }
                comboTrajet.Visible = true;
                //CurrentUser.Education_InRoute.InRoute_Id = comboTrajet.FindStringExact(CurrentUser.Education_InRoute.InRoute_Name);
            }
            else
            {
                if (CurrentUser.Agent_InRoute == true)
                {
                    CurrentUser.Agent_InRoute = false;

                    ActivateModification(true);
                }
                comboTrajet.Visible = false;

            }
        }

        private void comboTrajet_Leave(object sender, EventArgs e)
        {
            if (CurrentUser.Agent_InRouteId != ((Education_InRoute)comboTrajet.SelectedItem).InRoute_Id)
            {
                CurrentUser.Agent_InRouteId = ((Education_InRoute)comboTrajet.SelectedItem).InRoute_Id;
                ActivateModification(true);
            }
        }

      
    }

}

