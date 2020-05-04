using Module_Education.Models;
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
using System.Data;
using System.Reflection;

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
        private AgentPassportDesignRepository dbAgentPassportDesign = new AgentPassportDesignRepository();
        private AgentCertifElecOPPRepository dbAgentCertifElecOPP = new AgentCertifElecOPPRepository();
        private AgentCertifElecFuncRepository dbAgentCerifElecFunc = new AgentCertifElecFuncRepository();


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
        List<Education_AgentPassportDesign> listAgentPassportDesign;
        List<Education_AgentCertifElecOPP> listAgentOPPCertif;
        List<Education_AgentCertifElecFunc> listAgentFuncCertif;

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
        public static DataTable dtAgents;
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
        TextBoxExtensions TbExtension = new TextBoxExtensions();
        ComboBoxExt cbExtension = new ComboBoxExt();
        public Point controlLocation = new Point();
        #endregion

        #region class properties

        private List<string> _sortOrderList = new List<string>();
        private List<string> _filterOrderList = new List<string>();
        private List<string> _filteredColumns = new List<string>();

        private bool _loadedFilter = false;
        private string _sortString = null;
        private string _filterString = null;
        private string formationSAP;
        private string typeOfCertificate;
        private bool NewCertificate;
        public long PassportId { get; private set; }

        private Size dgCertifFuncDynSize;
        private Size dgCertifOPPDynSize;

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
            comboBoxStatut11.DataSource = dbUserStatus.LoadAllStatus();
            comboBoxStatut11.DisplayMember = "AgentStatus_Name";

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
                Cursor.Current = Cursors.WaitCursor;

                //List<User> lUsers = db.LoadAllAgents();
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) =>
                {

                    //progressBarDgAgent.Value = report.PercentCompleted;
                    //progressBarDgAgent.Update();
                };
                pageSize = Int32.Parse(tbNbrRows.Text);
                listUserPaged = await LoadTaskDatagridAgent();


                //lblMin.Text = listUserPaged.FirstItemOnPage.ToString();
                //lblMax.Text = listUserPaged.LastItemOnPage.ToString();

                dG_Agents.DataSource = GetDataSource(listUserPaged);
                lblNbrRowsAgent.Text = "Nombre total d'Agents : " + listUserPaged.TotalItemCount.ToString();
                //dG_Agents.DataSource = listUserPaged;
                //dG_Agents.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.LogError(ex, Environment.UserName);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbNbrRows.Text, @"^\d+$"))
            {
                if (tbNbrRows.Text != "")
                {
                    tbNbrRows.Text = tbNbrRows.Text.Remove(tbNbrRows.Text.Length - 1);
                }
            }
            else {
                pageSize = Convert.ToInt32(tbNbrRows.Text);
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
                //var progressReport = new ProgressReport();
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
                            //progressReport.PercentCompleted = 0;
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
                            .Include("Education_Matrice_Agent")

                            //.Include("User2")
                            .OrderBy(p => p.Agent_Id).ToPagedList(pagNumber, pageSize);
                            //progressReport.PercentCompleted = 100;
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
                //var progress = new Progress<ProgressReport>();
                //progress.ProgressChanged += (o, report) =>
                //{

                //    //progressBarDgAgent.Value = report.PercentCompleted;
                //    //progressBarDgAgent.Update();
                //};

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

                    //progressBarDgAgent.Value = report.PercentCompleted;
                    //progressBarDgAgent.Update();
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
                AgentPassportBusinessId = o.Education_PassportBusiness.PassportBusiness_Id,
                AgentPassportBusinessDesc = o.Education_PassportBusiness.PassportBusiness_Name,
                AgentPassportBusinessIsCertifiied = o.AgentPassportBusiness_HierarchyCertification,
                AgentPassportBusinessReturnDate = o.AgentPassportBusiness_ReturnDate,
                AgentPassportBusinessSendingDate = o.AgentPassportBusiness_SendingDate,
                AgentPassportSRemark = o.AgentPassportBusiness_Remark


            }).ToList();


            return dataSource;
        }

        private object GetDataSource(List<Education_AgentPassportDesign> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGPassportDesign(o)
            {
                AgentPassportDesignId = o.Education_PassportDesign.PassportDesign_Id,
                AgentPassportDesign = o.Education_PassportDesign.PassportDesign_Name,
                AgentPassportSaferyIsCertifiied = o.AgentPassportDesign_IsCertified,
                AgentPassportSafetyReturnDate = o.AgentPassportDesign_ReceivedDate,
                AgentPassportSafetySendingDate = o.AgentPassportDesign_SendingDate,
                AgentPassportSafetyRemark = o.AgentPassportDesign_Remark


            }).ToList();


            return dataSource;
        }

        private object GetDataSource(List<Education_AgentCertifElecOPP> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGCertificateOPP(o)
            {
                AgentCertificateLevelRId = o.Education_CertifElecOPP.CertifElecOPP_Id,
                AgentCertificateLevelR = o.Education_CertifElecOPP.CertifElecOPP_LevelR,
                AgentPassportSaferyIsCertifiied = o.AgentCertifElecOPP_IsCertified,
                AgentPassportSafetyReturnDate = o.AgentCertifElecOPP_ReceivedDate,
                AgentPassportSafetySendingDate = o.AgentCertifElecOPP_SendingDate,
                AgentPassportSafetyValidityDate = o.AgentCertifElecOPP_ValidityDate,
                AgentPassportSafetyRemark = o.AgentCertifElecOPP_Remark


            }).ToList();


            return dataSource;
        }

        private object GetDataSource(List<Education_AgentCertifElecFunc> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGCertificateFunc(o)
            {
                AgentCertifElecFuncId = o.Education_CertifElecFunc.CertifElecFunc_Id,
                AgentCertificateLevelB = o.Education_CertifElecFunc.CertifElecFunc_LevelB,
                AgentPassportSaferyIsCertifiied = o.AgentCertifElecFunc_IsCertified,
                AgentPassportSafetyReturnDate = o.AgentCertifElecFunc_ReceivedDate,
                AgentPassportSafetySendingDate = o.AgentCertifElecFunc_SendingDate,
                AgentPassportSafetyRemark = o.AgentCertifElecFunc_Remark


            }).ToList();


            return dataSource;
        }

        private object GetDataSource(List<Education_AgentPassportSafety> listPassport)
        {
            object dataSource = listPassport.Select(o => new MyColumnCollectionDGPassportSafety(o)
            {
                AgentPassportSafetyId = o.AgentPassportSafety_Id,
                PassportSafety_LevelPS = o.Education_PassportSafety == null ? "" : o.Education_PassportSafety.PassportSafety_LevelPS.ToString(),

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
            try
            {
                object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o)
                {
                    Agent_Matricule = o.Agent_Matricule,
                    Agent_FirstName = o.Agent_FirstName,
                    Agent_Name = o.Agent_Name,
                    Agent_Fullname = o.Agent_FullName,
                    Function_Name = o.Agent_Function == null ? null : o.Education_Function.Function_Name,

                    //Function_Name = o.Agent_Function == null ? null : dbEntities.Education_Function.Where(x => x.Function_Id == o.Agent_Function).FirstOrDefault().Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                    Agent_Admin = o.Agent_Admin == null ? null : o.Agent_Admin,
                    Agent_Responsable = o.Agent_LineManager == null ? null : o.Education_Agent2.Agent_FullName,

                    //Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,
                    Agent_InRoute = o.Education_InRoute == null ? "" : o.Education_InRoute.InRoute_Name,
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
            catch (Exception ex)
            {
                throw ex;
            }
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

        private object GetDataSource(List<Education_Formation> listPagedFormation)
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
            LoadCertificationFunc();
            LoadCertificationOPP();
            LoadPassportDesign();
        }

        private void LoadPassportSafety()
        {
            DataGridView dgPassportSafetyDyn = (DataGridView)this.tbFicheAgent.Controls.Find("dgPassportSafetyDyn", true).FirstOrDefault();
            if (dgPassportSafetyDyn != null)
            {
                dgPassportSafetyDyn.Dispose();
                this.tbFicheAgent.Controls.Remove(dgPassportSafetyDyn);
            }
            dgPassportSafetyDyn = new DataGridView();
            
            DataGridViewElementStates states = DataGridViewElementStates.None;

            Label lblDgPassportSafety = (Label)this.tbFicheAgent.Controls.Find("lblDgPassportSafety", true).FirstOrDefault();
            
                lblDgPassportSafety = new Label();
            
            lblDgPassportSafety.Text = "PASSEPORT SAFETY";
            lblDgPassportSafety.Name = "lblDgPassportSafety";

            lblDgPassportSafety.Font = new Font("Arial", 14, FontStyle.Bold);
            lblDgPassportSafety.ForeColor = Color.FromArgb(0, 105, 167);

            lblDgPassportSafety.AutoSize = true;
            lblDgPassportSafety.Location = new Point(155, 533);
            lblDgPassportSafety.Show();

            dgPassportSafetyDyn.MouseClick += dgPassportSafetyDynMouseClick;
            dgPassportSafetyDyn.CellFormatting += dgPassportSafetyDynCellFormating;

            dgPassportSafetyDyn.Location = new Point(155, 560);
            dgPassportSafetyDyn.BackgroundColor = Color.White;
            dgPassportSafetyDyn.Name = "dgPassportSafetyDyn";
            dgPassportSafetyDyn.ReadOnly = true;

            this.tbFicheAgent.Controls.Add(lblDgPassportSafety);
            this.tbFicheAgent.Controls.Add(dgPassportSafetyDyn);


            dgPassportSafetyDyn.Show();
            dbAgentPassportSafety = new AgentPassportSafetyRepository();
            listAgentPassportSafety = dbAgentPassportSafety.LoadPassportSafety(CurrentUser);
            dgPassportSafetyDyn.DataSource = GetDataSource(listAgentPassportSafety);
            dgPassportSafetyDyn.Columns[0].Visible = false;

            var totalHeight = dgPassportSafetyDyn.Rows.GetRowsHeight(states) + dgPassportSafetyDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportSafetyDyn.Columns.GetColumnsWidth(states) + dgPassportSafetyDyn.RowHeadersWidth;

            dgPassportSafetyDyn.ClientSize = new Size(totalWidth, totalHeight);
            dgPassportSafetyDynSize = dgPassportSafetyDyn.Size;
        }

        private void LoadCertificationFunc()
        {
            DataGridView dgPassportBusinessDyn = this.Controls.Find("dgPassportBusinessDyn", true).FirstOrDefault() as DataGridView;

            Label lblDgCertificateFunc = new Label();
            lblDgCertificateFunc.Text = "CERTIFICAT ELECTRIQUE Fonction";
            lblDgCertificateFunc.Font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            lblDgCertificateFunc.ForeColor = Color.FromArgb(0, 105, 167);

            lblDgCertificateFunc.AutoSize = true;
            var yCalculated = dgPassportBusinessDyn.Location.Y + dgPassportBusinessDyn.Height;
            lblDgCertificateFunc.Location = new Point(155, yCalculated);


            lblDgCertificateFunc.Show();

            DataGridView dgPassportElecFunc = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportElecFunc.Location = new Point(155, (yCalculated + (lblDgCertificateFunc.Height + 10)));
            dgPassportElecFunc.BackgroundColor = Color.White;
            dgPassportElecFunc.ReadOnly = true;
            dgPassportElecFunc.Name = "dgPassportElecFunc";
            //dgPassportElecFunc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgPassportElecFunc.MouseClick += dgPassportElecFuncMouseClick;
            dgPassportElecFunc.CellFormatting += dgPassportElecFuncCellFormating;

            this.tbFicheAgent.Controls.Add(lblDgCertificateFunc);
            this.tbFicheAgent.Controls.Add(dgPassportElecFunc);
            dgPassportElecFunc.Show();
            listAgentFuncCertif = dbAgentCerifElecFunc.LoadCertifElecFunc(CurrentUser);
            dgPassportElecFunc.DataSource = GetDataSource(listAgentFuncCertif);
            dgPassportElecFunc.Columns[0].Visible = false;

            var totalHeight = dgPassportElecFunc.Rows.GetRowsHeight(states) + dgPassportElecFunc.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportElecFunc.Columns.GetColumnsWidth(states) + dgPassportElecFunc.RowHeadersWidth;
            dgPassportElecFunc.ClientSize = new Size(totalWidth, totalHeight);
            dgCertifFuncDynSize = dgPassportElecFunc.Size;

        }

        private void dgPassportElecFuncCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgPassportElecFuncMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    DataGridView dgPassportElecFunc = this.Controls.Find("dgPassportElecFunc", true).FirstOrDefault() as DataGridView;

                    ContextMenu m = new ContextMenu();

                    int currentMouseOverRow = dgPassportElecFunc.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        dgPassportElecFunc.Rows[dgPassportElecFunc.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        m.MenuItems.Add(new MenuItem(string.Format("Modifier la certification", currentMouseOverRow.ToString()),
                           ShowEditCertificationForm));
                        m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification safety", currentMouseOverRow.ToString()),
                            ShowNewCertificationForm));

                    }

                    m.Show(dgPassportElecFunc, new Point(e.X, e.Y));
                    PassportId = Convert.ToInt64(dgPassportElecFunc.SelectedCells[0].Value.ToString());
                    typeOfCertificate = "Function";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadCertificationOPP()
        {
            DataGridView dgPassportElecFunc = this.Controls.Find("dgPassportElecFunc", true).FirstOrDefault() as DataGridView;

            Label lblDgCertificateOPP = new Label();
            lblDgCertificateOPP.Text = "CERTIFICAT ELECTRIQUE OPP";
            lblDgCertificateOPP.Font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            lblDgCertificateOPP.ForeColor = Color.FromArgb(0, 105, 167);

            lblDgCertificateOPP.AutoSize = true;
            var yCalculated = dgPassportElecFunc.Location.Y + dgPassportElecFunc.Height;
            lblDgCertificateOPP.Location = new Point(155, yCalculated);
            lblDgCertificateOPP.Show();

            DataGridView dgPassportElecOPP = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;

            dgPassportElecOPP.Location = new Point(155, (yCalculated + (lblDgCertificateOPP.Height + 10)));
            dgPassportElecOPP.BackgroundColor = Color.White;
            dgPassportElecOPP.ReadOnly = true;
            dgPassportElecOPP.Name = "dgPassportElecOPP";

            dgPassportElecOPP.MouseClick += dgPassportElecOPPDynMouseClick;
            dgPassportElecOPP.CellFormatting += dgPassportElecOPPDynCellFormating;

            this.tbFicheAgent.Controls.Add(lblDgCertificateOPP);
            this.tbFicheAgent.Controls.Add(dgPassportElecOPP);
            dgPassportElecOPP.Show();
            listAgentOPPCertif = dbAgentCertifElecOPP.LoadPassportBusinessAgent(CurrentUser);
            dgPassportElecOPP.DataSource = GetDataSource(listAgentOPPCertif);

            var totalHeight = dgPassportElecOPP.Rows.GetRowsHeight(states) + dgPassportElecOPP.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportElecOPP.Columns.GetColumnsWidth(states) + dgPassportElecOPP.RowHeadersWidth;
            dgPassportElecOPP.ClientSize = new Size(totalWidth, totalHeight);
            dgCertOPPyDynSize = dgPassportElecOPP.Size;

        }

        private void dgPassportElecOPPDynCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dgPassportElecOPPDynMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    DataGridView dgPassportElecOPP = this.Controls.Find("dgPassportElecOPP", true).FirstOrDefault() as DataGridView;

                    ContextMenu m = new ContextMenu();

                    int currentMouseOverRow = dgPassportElecOPP.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        dgPassportElecOPP.Rows[dgPassportElecOPP.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        m.MenuItems.Add(new MenuItem(string.Format("Modifier la certification", currentMouseOverRow.ToString()),
                           ShowEditCertificationForm));
                        m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification safety", currentMouseOverRow.ToString()),
                            ShowNewCertificationForm));

                    }

                    m.Show(dgPassportElecOPP, new Point(e.X, e.Y));
                    PassportId = Convert.ToInt64(dgPassportElecOPP.SelectedCells[0].Value.ToString());
                    typeOfCertificate = "OPP";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPassportDesign()
        {

            DataGridView dgPassportElecOPP = this.Controls.Find("dgPassportElecOPP", true).FirstOrDefault() as DataGridView;

            Label lblDgCertificateOPP = new Label();
            lblDgCertificateOPP.Text = "PASSEPORT DESIGN";
            lblDgCertificateOPP.Font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            lblDgCertificateOPP.ForeColor = Color.FromArgb(0, 105, 167);

            lblDgCertificateOPP.AutoSize = true;
            var yCalculated = dgPassportElecOPP.Location.Y + dgPassportElecOPP.Height;
            lblDgCertificateOPP.Location = new Point(155, yCalculated);
            lblDgCertificateOPP.Show();

            DataGridView dgPassportDesignDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;
            DataGridView dgPassportSafetyDyn = this.Controls.Find("dgPassportSafetyDyn", true).FirstOrDefault() as DataGridView;

            dgPassportDesignDyn.Location = new Point(155, (yCalculated + (lblDgCertificateOPP.Height + 10)));
            dgPassportDesignDyn.BackgroundColor = Color.White;
            dgPassportDesignDyn.ReadOnly = true;
            dgPassportDesignDyn.Name = "dgPassportDesignDyn";

            dgPassportDesignDyn.MouseClick += dgPassportDesignDynMouseClick;
            dgPassportDesignDyn.CellFormatting += dgPassportDesignDynCellFormating;

            this.tbFicheAgent.Controls.Add(lblDgCertificateOPP);
            this.tbFicheAgent.Controls.Add(dgPassportDesignDyn);
            dgPassportDesignDyn.Show();
            listAgentPassportDesign = dbAgentPassportDesign.LoadPassportDesignAgent(CurrentUser);
            dgPassportDesignDyn.DataSource = GetDataSource(listAgentPassportDesign);

            var totalHeight = dgPassportDesignDyn.Rows.GetRowsHeight(states) + dgPassportDesignDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportDesignDyn.Columns.GetColumnsWidth(states) + dgPassportDesignDyn.RowHeadersWidth;
            dgPassportDesignDyn.ClientSize = new Size(totalWidth, totalHeight);
            dgPassportDesignDynSize = dgPassportDesignDyn.Size;

        }

        private void dgPassportDesignDynCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dgPassportDesignDynMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    DataGridView dgPassportDesignDyn = this.Controls.Find("dgPassportDesignDyn", true).FirstOrDefault() as DataGridView;

                    ContextMenu m = new ContextMenu();

                    int currentMouseOverRow = dgPassportDesignDyn.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        dgPassportDesignDyn.Rows[dgPassportDesignDyn.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        m.MenuItems.Add(new MenuItem(string.Format("Modifier la certification", currentMouseOverRow.ToString()),
                           ShowEditCertificationForm));
                        m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification safety", currentMouseOverRow.ToString()),
                            ShowNewCertificationForm));

                    }

                    m.Show(dgPassportDesignDyn, new Point(e.X, e.Y));
                    PassportId = Convert.ToInt64(dgPassportDesignDyn.SelectedCells[0].Value.ToString());
                    typeOfCertificate = "Design";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgPassportSafetyDynCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 5)
            //{
            if (e.Value is bool)
            {
                bool value = (bool)e.Value;
                e.Value = (value) ? "Oui" : "Non";
                e.FormattingApplied = true;
            }
            //}
        }

        private void dgPassportSafetyDynMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    DataGridView dgPassportSafetyDyn = this.Controls.Find("dgPassportSafetyDyn", true).FirstOrDefault() as DataGridView;

                    ContextMenu m = new ContextMenu();

                    int currentMouseOverRow = dgPassportSafetyDyn.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        dgPassportSafetyDyn.Rows[dgPassportSafetyDyn.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        m.MenuItems.Add(new MenuItem(string.Format("Modifier la certification", currentMouseOverRow.ToString()),
                           ShowEditCertificationForm));
                        m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification safety", currentMouseOverRow.ToString()),
                            ShowNewCertificationForm));

                    }

                    m.Show(dgPassportSafetyDyn, new Point(e.X, e.Y));
                    PassportId = Convert.ToInt64(dgPassportSafetyDyn.SelectedCells[0].Value.ToString());
                    typeOfCertificate = "Safety";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPassportBusiness()
        {
            DataGridView dgPassportSafetyDyn = this.Controls.Find("dgPassportSafetyDyn", true).FirstOrDefault() as DataGridView;

            Label lblDgPassportBusiness = new Label();
            lblDgPassportBusiness.Text = "PASSEPORT METIER";
            lblDgPassportBusiness.Font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            lblDgPassportBusiness.ForeColor = Color.FromArgb(0, 105, 167);

            lblDgPassportBusiness.AutoSize = true;
            var yCalculated = dgPassportSafetyDyn.Location.Y + dgPassportSafetyDyn.Height;
            lblDgPassportBusiness.Location = new Point(155, yCalculated);
            lblDgPassportBusiness.Show();

            DataGridView dgPassportBusinessDyn = new DataGridView();
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgPassportBusinessDyn.MouseClick += dgPassportBusinessDynMouseClick;

            dgPassportBusinessDyn.Location = new Point(155, (yCalculated + (lblDgPassportBusiness.Height + 10)));
            dgPassportBusinessDyn.BackgroundColor = Color.White;
            dgPassportBusinessDyn.ReadOnly = true;
            dgPassportBusinessDyn.Name = "dgPassportBusinessDyn";

            this.tbFicheAgent.Controls.Add(lblDgPassportBusiness);
            this.tbFicheAgent.Controls.Add(dgPassportBusinessDyn);

            dgPassportBusinessDyn.Show();

            listAgentPassportBusiness = dbAgentPassportBusinessRep.LoadPassportBusinessAgent(CurrentUser);
            dgPassportBusinessDyn.DataSource = GetDataSource(listAgentPassportBusiness);

            var totalHeight = dgPassportBusinessDyn.Rows.GetRowsHeight(states) + dgPassportBusinessDyn.ColumnHeadersHeight + 30;
            var totalWidth = dgPassportBusinessDyn.Columns.GetColumnsWidth(states) + dgPassportBusinessDyn.RowHeadersWidth;
            dgPassportBusinessDyn.ClientSize = new Size(totalWidth, totalHeight);
            dgPassportBusinessDynSize = dgPassportBusinessDyn.Size;
            if (dgPassportBusinessDyn.Columns.Count > 0)
                dgPassportBusinessDyn.Columns[0].Visible = false;



        }

        private void dgPassportBusinessDynMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dgv.ClearSelection();
                DataGridView dgPassportBusinessDyn = this.Controls.Find("dgPassportBusinessDyn", true).FirstOrDefault() as DataGridView;
                dgPassportBusinessDyn.Rows[dgPassportBusinessDyn.HitTest(e.X, e.Y).RowIndex].Selected = true;

                ContextMenu m = new ContextMenu();

                int currentMouseOverRow = dgPassportBusinessDyn.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Ajouter une certification Business", currentMouseOverRow.ToString()),
                        ShowNewCertificationForm));
                    m.MenuItems.Add(new MenuItem(string.Format("Modifier la certification", currentMouseOverRow.ToString()),
                       ShowEditCertificationForm));
                }

                m.Show(dgPassportBusinessDyn, new Point(e.X, e.Y));
                PassportId = Convert.ToInt64(dgPassportBusinessDyn.SelectedCells[0].Value.ToString());
                typeOfCertificate = "Business";

            }
        }

        private void ShowNewCertificationForm(object sender, EventArgs e)
        {
            FrmCertificate frmCertificate = new FrmCertificate(typeOfCertificate, false, PassportId);
            frmCertificate.ShowDialog();

            switch (typeOfCertificate)
            {
                case "Safety":
                    LoadPassportSafety();
                    break;
                case "Business":
                    LoadPassportBusiness();
                    break;
                case "Function":
                    LoadCertificationFunc();
                    break;
                case "OPP":
                    LoadCertificationOPP();
                    break;
                case "Design":
                    LoadPassportDesign();
                    break;
            }
        }

        private void ShowEditCertificationForm(object sender, EventArgs e)
        {
            FrmCertificate frmCertificate = new FrmCertificate(typeOfCertificate, false, PassportId);
            frmCertificate.ShowDialog();

            switch (typeOfCertificate)
            {
                case "Safety":
                    LoadPassportSafety();
                    break;
                case "Business":
                    LoadPassportBusiness();
                    break;
                case "Function":
                    LoadCertificationFunc();
                    break;
                case "OPP":
                    LoadCertificationOPP();
                    break;
                case "Design":
                    LoadPassportDesign();
                    break;
            }
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
            dg_TABFormationsOfAgent.DataSource = GetDataSource(listEducation_Formation);
            dg_TABFormationsOfAgent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


        }

        public void CreateButtonSavingAgent()
        {
            // Creating and setting the properties of Button 
            Button ButtonSaveAgent = new Button();
            ButtonSaveAgent.Location = new Point(147, 435);
            ButtonSaveAgent.Text = "Sauver";
            ButtonSaveAgent.Name = "ButtonSaveAgent";
            ButtonSaveAgent.FlatStyle = FlatStyle.Flat;
            ButtonSaveAgent.TabIndex = 19;

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
            ButtonCancelModificationAgent.Location = new Point(257, 435);
            ButtonCancelModificationAgent.Text = "Annuler";
            ButtonCancelModificationAgent.Name = "ButtonCancel";
            ButtonCancelModificationAgent.FlatStyle = FlatStyle.Flat;
            ButtonCancelModificationAgent.FlatAppearance.BorderSize = 0;
            ButtonCancelModificationAgent.TabIndex = 20;
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
                {
                    listAgentFiltered = MainWindow.globalListAgents;
                    if (dtAgents == null)
                        dtAgents = ToDataTable<Education_Agent>(listAgentFiltered);
                }
                else
                {
                    if (dtAgents == null)
                        dtAgents = ToDataTable<Education_Agent>(listAgentFiltered);
                }

                if (_filterString == "")
                {
                    LoadDatagridAgentAsync();
                }
                else
                {
                    BindingSource bindingSource = new BindingSource()
                    {
                        DataMember = dtAgents.TableName,
                        DataSource = dtAgents
                    };
                    bindingSource.Filter = _filterString;
                    dG_Agents.DataSource = bindingSource;

                    //dG_Agents.DataSource = bindingSource;
                }
                btnClearFilters.Enabled = true;
            }
        }

       

        public static DataTable ToDataTable<T>(List<T> items)
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
            TbExtension.OnFocusTextbox((TextBox)sender);
        }

        private void textBoxAdmin_Leave(object sender, EventArgs e)
        {
            try
            {
                TbExtension.DefautSizeTbFiche((TextBox)sender);

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

        private void dG_Agents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool)
            {
                bool value = (bool)e.Value;
                e.Value = (value) ? "OUI" : "NON";
                e.FormattingApplied = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDatagridAgentAsync();
        }

        private void comboBoxStatut_Enter(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            controlLocation = ctrl.Location;

            cbExtension.OnFocusTextbox((ComboBox)sender);
        }

        private void comboBoxStatut_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cbExtension.DefautSizeTbFiche((ComboBox)cb);
            cb.Location = controlLocation;

        }

        private void textBoxExtensions1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxExtensions1_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBoxExtensions tbExt = (TextBoxExtensions)sender;
                Regex regexCheckIfDigits = new Regex(@" ^[0 - 9]\d");

                decimal numberTbExt = Convert.ToDecimal(tbExt.Text);
                int countDecimal = BitConverter.GetBytes(decimal.GetBits(numberTbExt)[3])[2];
                double numberBeforeComma = Convert.ToDouble(numberTbExt);
                double numberofDigits = Math.Floor(Math.Log10(Convert.ToInt32(numberBeforeComma) + 1));

                Regex newRegex = new Regex(@"^[0-9]\d{0," + numberofDigits + @"}(\.\d{0," + countDecimal + @"})*(,\d+)?$");
                Match match = newRegex.Match(tbExt.Text.ToString());
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
            catch (Exception ex) { }
        }

        private void tbNbrRows_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void dG_Agents_MouseClick_1(object sender, EventArgs e)
        {

        }
    }

}

