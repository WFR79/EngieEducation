
using Module_Education.Models;
using Module_Education.Classes;
using Module_Education.Helper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Module_Education.DataAccessLayer;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using Module_Education.Repositories;
using Module_Education.Classes.Extensions;
using Module_Education.Forms;

namespace Module_Education
{
    public partial class UCEducation_Formation : UserControl
    {

        #region MessageBox
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
        const UInt32 WM_CLOSE = 0x0010;
        #endregion

        #region Treeview
        TreeNode mySelectedNode;
        public List<Education_Formation> lFormationToAddToMatrice;
        string oldLabel = String.Empty;
        #endregion

        public BindingSource ds_Education_Formations = new BindingSource();
        private Education_FormationDataAccess db = new Education_FormationDataAccess();
        private SessionUniteDataAccess dbSessionUnite = new SessionUniteDataAccess();
        private ProviderDataRepository dbProvider = new ProviderDataRepository();
        private CompetenceDataAccess dbCompetence = new CompetenceDataAccess();
        private FormationResultatDataAccess dbFormationResulat = new FormationResultatDataAccess();
        private FormationDossierRepository dbFormationDossier = new FormationDossierRepository();
        private FormationDossierTypeRepository dbFormationDossierType = new FormationDossierTypeRepository();
        private UnitePriceRepository dbUnitePrice = new UnitePriceRepository();

        private RoutesFormationRepository dbMatrice = new RoutesFormationRepository();
        private InRouteFormationRepository dbMatriceFormation = new InRouteFormationRepository();


        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();


        private static UCEducation_Formation _instance;
        IPagedList<Education_Formation> listPaged;
        private List<Education_Matrice> listMatrice;

        List<Education_Formation> listFormationFiltered;

        IPagedList<Education_Agent> listUserPaged;
        int pageSize;
        public static long UserIDSelected;
        public Education_Matrice MatriceSelected;

        public static string FormationIDSelected;


        #region public events

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
        private string _filterString = null;
        Education_Formation CurrentFormation;

        public Delegate MainWindowPointerMenuBtnAgent;
        public Delegate PointerUCAgent_Refresh;
        public Delegate PointerRefreshFicheAgent; // Edit user from fiche formation
        public agentEditLoad ReceiverLoadEditAgent { get; private set; }
        public Delegate PointerProvider;
        public Delegate MainWindowPointerMenuBtnProvider;

        public delegate void providerEditLoad(long FormationProviderID);

        public Delegate PointerPointMenuBtnFormation;
        public Delegate PointerFormation;

        int pageNumber = 1;


        public static UCEducation_Formation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCEducation_Formation();
                return _instance;
            }
        }

        public string FileToProcess { get; private set; }

        public delegate void agentEditLoad(string formationSAPNum);

        public UCEducation_Formation()
        {
            InitializeComponent();
            LoadComboboxs();

            this.ActiveControl = this.comboBoxDurationhours;
            InitVertScrollBarPanelDoc();
            tabControl_Education_Formations.SelectedIndex = 2;
            InitReceiverEventFromOtherUCs();
        }

        private void InitReceiverEventFromOtherUCs()
        {



        }

        private void InitVertScrollBarPanelDoc()
        {
            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender, e) => { panelDossierPedagogique.VerticalScroll.Value = vScrollBar1.Value; };
            panelDossierPedagogique.Controls.Add(vScrollBar1);
            panelDossierPedagogique.Height = 200;
        }

        public void LoadComboboxs()
        {
            //Equipe
            for (int x = 1; x < 25; x += 1)
            {
                comboBoxDurationhours.Items.Add(x);
            }
            for (int y = 1; y < 151; y += 1)
            {
                comboBoxDurationInDays.Items.Add(y);
            }
            for (int capMax = 1; capMax < 201; capMax += 1)
            {
                comboBoxMaxCapacity.Items.Add(capMax);
            }
            for (int optMax = 1; optMax < 201; optMax += 1)
            {
                comboBoxCapaciteOptimale.Items.Add(optMax);
            }
            for (int capMin = 1; capMin < 25; capMin += 1)
            {
                comboBoxMinCapacity.Items.Add(capMin);
            }
            //Unite
            comboBoxUnite.DataSource = dbUnitePrice.LoadUnitePrice();
            comboBoxUnite.DisplayMember = "UnitePrice_Name";

            // YearOfCreation



            //Education_Habilitation
            comboBoxProvider.DataSource = dbProvider.AllProviders();
            comboBoxProvider.ValueMember = "Provider_Name";

            //Compétence
            comboBoxCompetence.DataSource = dbCompetence.LoadAllCompetences();
            comboBoxCompetence.ValueMember = "Competence_Name";

            //Type Dossier
            cbTypeDossier.DataSource = dbFormationDossierType.LoadAllTypeDossier();
            cbTypeDossier.ValueMember = "FormationDossierType_Name";

            ////Astreinte
            //comboBoxAstreinte.DataSource = dbAstreinte.LoadAllRoleAstreinte();
            //comboBoxAstreinte.ValueMember = "RoleAstreinte_Name";
        }

        #region Onglet Liste Education_Formations

        public void StylingDatagrid(DataGridView datagrid)
        {
            DataGridViewCellStyle cell_style = new DataGridViewCellStyle();
            Color blueEngie = ColorTranslator.FromHtml("#00AAFF");
            cell_style.BackColor = blueEngie;
            cell_style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cell_style.Font = new Font(datagrid.Font, FontStyle.Bold);


            //cell_style.Font.Bold = true;
            //cell_style.Format = "C2";
            //datagrid.Columns["Education_Formation_SAP"].DefaultCellStyle = cell_style;
            //datagrid.Columns["Education_Formation_SAP"].DefaultCellStyle = cell_style;


            //datagrid.Columns[0].Visible = false;
            datagrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            datagrid.AutoSizeRowsMode =
        DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            datagrid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Raised;
            datagrid.GridColor = Color.AliceBlue;
            datagrid.BorderStyle = BorderStyle.Fixed3D;
            datagrid.CellBorderStyle =
                DataGridViewCellBorderStyle.None;
            datagrid.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            datagrid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            datagrid.ColumnHeadersHeight = 30;
        }

        public void LoadCbListColumnsToFilter(System.Windows.Forms.DataGridViewColumnCollection columns, DataGridView datagrid)
        {
            if (columns != null)
            {

                for (int i = 0; i < columns.Count; i++)
                {
                    //cb_FiltreDgEducation_Formations.Items.Add(columns[i].HeaderText);
                }
            }
        }

        public void LoadDatagriEducation_FormationsFiltered(string filter, string columnToFilter)
        {
            List<Education_Formation> lEducation_Formations = db.LoadAllEducation_FormationsFiltered(filter, columnToFilter);
            listPaged = lEducation_Formations.OrderBy(p => p.Formation_Id).ToPagedList(1, 100);

            //source.ResetBindings(true);
            AdvDg_Formations.DataSource = GetDataSource(listPaged);
            AdvDg_Formations.Refresh();
            StylingDatagrid(advDv_AgentsOfFormation);

        }

        private void tbFiltre_TextChanged(object sender, EventArgs e)
        {
            //LoadDatagriEducation_FormationsFiltered(tbFiltre.Text, cb_FiltreDgEducation_Formations.SelectedItem.ToString());
        }

        private async Task<IPagedList<Education_Formation>> LoadDatagriEducation_Formations(int pagNumber = 1, int pageSize = 100)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    //using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    //{
                        pageSize = Int32.Parse(tbNbrRows.Text);

                        if (MainWindow.globalListEducation_Formations == null)
                        {

                            return dbEntities.Education_Formation
                            .Include("Education_CategorieFormation")
                            .Include("Education_FormationProvider")
                            .Include("Education_FormationResultat")
                            .Include("Education_FormationSession")
                            .Include("Education_Matrice_Formation")
                            .Include("Education_UnitePrice")
                            .Include("Education_FormationDossier")

                            .OrderBy(p => p.Formation_Id).ToPagedList(pagNumber, pageSize);
                            //dG_Education_Formations.DataSource = lEducation_Formations.ToPagedList(1, 100); ;
                        }
                        else
                        {
                            return MainWindow.globalListEducation_Formations.ToPagedList(pagNumber, pageSize); ;
                            //dG_Education_Formations.DataSource = MainWindow.globalListEducation_Formations.ToPagedList(1, 100); 
                        }
                    //}


                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC Education_Formation");
                throw;
            }
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async Task<IPagedList<Education_Agent>> LoadDatagriUsers(string selectedEducation_FormationSAP, int pagNumber = 1, int pageSize = 100)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    {
                        List<Education_Agent> tempUserList = new List<Education_Agent>();

                        var selectedEducation_FormationId = dbList.Education_Formation.Where(x => x.Formation_SAP.Equals(selectedEducation_FormationSAP)).FirstOrDefault();


                        var listUsersEducation_Formation = dbList.Education_Agent_Formation
                        .Where(p => p.AgentFormation_Formation == selectedEducation_FormationId.Formation_Id).ToList();

                        foreach (var itemUserEducation_Formation in listUsersEducation_Formation)
                        {
                            tempUserList.Add(dbList.Education_Agent
                                 .Include("Education_Equipe")
                            .Include("Education_Function")
                            .Include("Education_Habilitation")
                            .Include("Education_GroupLearner_Agent")
                            .Include("Education_Matrice_Agent")
                            .Include("Education_MovementAgent")
                            .Include("Education_MovementAgent1")
                            .Include("Education_Role")
                            .Include("Education_RoleAstreinte")

                            .Include("Education_RoleEPI")
                            //.Include("User1")
                            //.Include("User2")
                            .Include("Education_AgentStatus")
                            .Include("Education_Agent_Formation")


                                .Where(w => w.Agent_Id == itemUserEducation_Formation.AgentFormation_Agent).FirstOrDefault());
                        }
                        return tempUserList.OrderByDescending(p => p.Agent_Id).ToPagedList(pagNumber, pageSize);

                        //dG_Education_Formations.DataSource = lEducation_Formations.ToPagedList(1, 100); ;
                    }





                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC Education_Formation");
                throw;
            }
            //LoadCbListColumnsToFilter(dG_Education_Formations.Columns, dG_Education_Formations);
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async void UC_Education_Formation_Load(object sender, EventArgs e)
        {
            AdvDg_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.
            //dG_Education_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.

            listPaged = await LoadDatagriEducation_Formations(1, pageSize);
            AdvDg_Formations.DataSource = GetDataSource(listPaged);
            AdvDg_Formations.Refresh();
            AdvDg_Formations.SelectionChanged += dG_Education_Formations_SelectionChanged; // ReAdd the handler.
            lblNbrRowsFormations.Text = "Nombre total de formations : " + listPaged.TotalItemCount.ToString();

            LoadCbListColumnsToFilter(AdvDg_Formations.Columns, AdvDg_Formations);

            //StylingDatagrid(dG_Education_Formations);
        }

        private object GetDataSource(IPagedList<Education_Formation> listPaged)
        {
            //using (CFNEducation_FormationEntities dbTemp = new CFNEducation_FormationEntities())
            //{
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_DurationInDays = o.Formation_DurationInDays,
                Formation_SAP = o.Formation_SAP,
                Formation_IsInterne = o.Formation_IsInterne,
                Formation_Price = o.Formation_Price,
                Formation_YearOfCreation = o.Formation_YearOfCreation,
                Formation_CapaciteMin = o.Formation_MinCapacity,
                Formation_CapaciteMax = o.Formation_MaxCapacity,
                FormationDossier = o.Education_FormationDossier.Count < 1 ? "" : dbEntities.Education_FormationDossier
                    .Where(x => x.FormationDossier_Formation == o.Formation_Id).FirstOrDefault().FormationDossier_InfoFicheHyperLink,// If (o.Function == null) { null } else {o.Function.Function_Name}
                Formation_CapaciteOptimale = o.Formation_OptimalCapacity,


            }).ToList();

            lblMin.Text = listPaged.FirstItemOnPage.ToString();
            lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
            //}
        }

        private object GetDataSource(IPagedList<Education_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o)
            {
                Agent_Matricule = o.Agent_Matricule,
                Agent_FirstName = o.Agent_FirstName,
                Agent_Name = o.Agent_Name,

                Function_Name = o.Education_Function == null ? null : o.Education_Function.Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                Agent_Admin = o.Agent_Admin,
                Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,

                Agent_IsWorkManager = o.Agent_IsWorksManager,
                Agent_DateSeniority = o.Agent_DateSeniority,
                Agent_DateOfEntry = o.Agent_DateOfEntry,
                Agent_DateFunction = o.Agent_DateFunction,
                Agent_Habilitation = o.Education_Habilitation == null ? null : o.Education_Habilitation.Habilitation_Name,
                Agent_Status = o.Education_AgentStatus == null ? null : o.Education_AgentStatus.AgentStatus_Name,
                Agent_Etat = o.Agent_Etat


            }).ToList();

            return dataSource;
        }

        private async void dG_Education_Formations_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                var selectedSAPEducation_Formation = dgv.SelectedCells[1].Value;

                listUserPaged = await LoadDatagriUsers(selectedSAPEducation_Formation.ToString());
                BindingSource source = new BindingSource
                {
                    DataSource = listUserPaged.ToList()
                };
                //source.ResetBindings(true);
                //dG_Agents.DataSource = source;
                AdvDg_Formations.Refresh();
                //dG_Agents.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void Refresh_Datagrid(object sender, EventArgs e)
        {
            AdvDg_Formations.Refresh();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dG_Agents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                var userIdAgent = dgv.Rows[e.RowIndex].Cells[0].Value;
                Form parentForm = this.Parent.FindForm() as Form;
                var matches = parentForm.Controls.Find("flowPanelMenu", true);

                Console.WriteLine(matches);

                object[] arr = { userIdAgent, null };
                PointerFormation.DynamicInvoke(userIdAgent.ToString());
                MainWindowPointerMenuBtnAgent.DynamicInvoke(arr);
                PointerUCAgent_Refresh.DynamicInvoke(Convert.ToInt64(userIdAgent));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC_Education_FormationS");

            }
        }

        private void dG_Agents_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            // foreach (DataGridViewCell elem in dgv.SelectedCells)
            // {
            //     Console.WriteLine(elem.Value);
            //}
            if (e.Button == MouseButtons.Right)
            {
                dgv.ClearSelection();
                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Modifier l'agent", EditUser_CLick));

                int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(dgv, new Point(e.X, e.Y));
                UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

            }
        }

        private void EditUser_CLick(Object sender, System.EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;

            object[] arr = { UserIDSelected, null };

            PointerFormation.DynamicInvoke(UserIDSelected);
            MainWindowPointerMenuBtnAgent.DynamicInvoke(arr);
            PointerRefreshFicheAgent.DynamicInvoke(Convert.ToInt64(UserIDSelected));

            //PointerRefreshFicheAgent.DynamicInvoke(UserIDSelected);
        }

        private void labelSAPEducation_Formation_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Onglet Fiche Education_Formation

        public void LoadFicheEducation_Formation(string Education_FormationSAPSelected)
        {
            try
            {
                //DeleteButtonSavingAgent();
                TabPage page = (TabPage)this.tabControl_Education_Formations.Controls[1];
                this.tabControl_Education_Formations.SelectedTab = page;
                this.EnableTab(page, true);

                CurrentFormation = db.LoadSingleEducation_Formation(FormationIDSelected);
                if (CurrentFormation != null)
                {
                    Education_FormationRecord_FillLabels(CurrentFormation);
                    Education_FormationRecord_FillLabelsActif(CurrentFormation);

                    Education_FormationRecord_FillSAP(CurrentFormation);
                    Education_FormationRecord_SelectCompetence(CurrentFormation);
                    Education_FormationRecord_PickDateOfCreation(CurrentFormation);
                    //Education_FormationRecord_PickDateOfEntry(CurrentEducation_Formation);
                    //Education_FormationRecord_PickUser_DateSeniority(CurrentEducation_Formation);
                    //Education_FormationRecord_PickDateFunction(CurrentEducation_Formation);
                    Education_FormationRecord_FillRemarks(CurrentFormation);
                    Education_FormationRecord_FillResulats(CurrentFormation);
                    Education_FormationRecord_SelectUnitePrice(CurrentFormation);
                    Education_FormationRecord_FillFormationPrice(CurrentFormation);
                    Education_FormationRecord_FillVendor(CurrentFormation);

                    Education_FormationRecord_SelectDurationInDays(CurrentFormation);
                    Education_FormationRecord_SelectMinCapacity(CurrentFormation);
                    Education_FormationRecord_SelectMaxCapacity(CurrentFormation);
                    Education_FormationRecord_SelectOptCapacity(CurrentFormation);

                    Education_FormationRecord_FillCbListPRoviders(CurrentFormation);
                    //Doc
                    Education_FormationRecord_LoadDocInfoFiche(CurrentFormation);
                    Education_FormationRecord_LoadDocSyllabus(CurrentFormation);
                    Education_FormationRecord_LoadDocTest(CurrentFormation);
                    Education_FormationRecord_LoadDocScenario(CurrentFormation);
                    Education_FormationRecord_SelectPriority(CurrentFormation);
                    Education_FormationRecord_InOrder(CurrentFormation);
                    Education_FormationRecord_Hubbel(CurrentFormation);
                    Education_FormationRecord_SelectDossierType(CurrentFormation);
                    //
                    LoadDatagriAgentsOfCurrentFormation();
                    //Education_FormationRecord_SelectRoleEPI(CurrentEducation_Formation);
                    //Education_FormationRecord_SelectRoleAstreinte(userReCurrentEducation_Formationcord);


                    //Education_FormationRecord_SelectEducation_Habilitation(CurrentEducation_Formation);
                    //UserRecord_LoadEducation_FormationsOfUser(userRecord);
                    CreateButtonSavingAgent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Education_FormationRecord_FillDurationDays(Education_Formation currentFormation)
        {
            throw new NotImplementedException();
        }

        private void Education_FormationRecord_FillVendor(Education_Formation currentFormation)
        {
            if (currentFormation.Education_FormationProvider != null)
                foreach (Education_FormationProvider formationProvider in currentFormation.Education_FormationProvider)
                {
                    cbListProvider.Items.Add(formationProvider.Education_Provider.Provider_Name);
                    if (formationProvider.FormationProvider_IsActual == true)
                    {
                        tbVendor.Text = formationProvider.FormationProvider_Vendor.ToString(); ;
                    }
                }
        }

        private void dG_Education_Formations_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.ClearSelection();
                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[1].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Fiche de la formation", EditEducation_Formation_CLick));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                        //if (currentMouseOverRow >= 0)
                        //{
                        //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                        //}

                        m.Show(dgv, new Point(e.X, e.Y));
                        FormationIDSelected = dgv.SelectedCells[1].Value.ToString();

                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void EditEducation_Formation_CLick(object sender, EventArgs e)
        {
            tabControl_Education_Formations.SelectedIndex = 1;
            LoadFicheEducation_Formation(FormationIDSelected);
        }

        private void Education_FormationRecord_FillResulats(Education_Formation currentFormation)
        {
            comboBoxResultatByYear.Items.Clear();
            comboBoxResultatYear.Items.Clear();

            if (currentFormation.Education_FormationResultat != null)
                foreach (Education_FormationResultat formationResult in currentFormation.Education_FormationResultat)
                {
                    comboBoxResultatByYear.Items.Add(formationResult.FormationResultat_Resultat);
                    comboBoxResultatYear.Items.Add(formationResult.FormationResultat_Year);
                }
            comboBoxResultatByYear.SelectedIndex = comboBoxResultatByYear.Items.Count - 1;
            comboBoxResultatYear.SelectedIndex = comboBoxResultatYear.Items.Count - 1;

        }

        private async void LoadDatagriAgentsOfCurrentFormation()
        {
            try
            {
                listUserPaged = await LoadDatagriUsers(CurrentFormation.Formation_SAP.ToString());
                BindingSource source = new BindingSource
                {
                    DataSource = listUserPaged.ToList()
                };
                //source.ResetBindings(true);
                advDv_AgentsOfFormation.DataSource = GetDataSource(listUserPaged);
                advDv_AgentsOfFormation.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void Education_FormationRecord_PickDateOfCreation(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_YearOfCreation != null)
            {
                txtYearOfCreation.Text = currentEducation_Formation.Formation_YearOfCreation.ToString();
            }
            else
            {
                txtYearOfCreation.Text = "";
            }
        }

        private void Education_FormationRecord_SelectCompetence(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Education_Competence != null)
                comboBoxCompetence.SelectedIndex = comboBoxCompetence.FindStringExact(currentEducation_Formation.Education_Competence.Competence_Name);
        }

        private void Education_FormationRecord_SelectDossierType(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Education_FormationDossier.Count > 0)
            {
                var formationDossier = currentEducation_Formation.Education_FormationDossier
                     .Where(w => w.FormationDossier_Formation == currentEducation_Formation.Formation_Id).FirstOrDefault();
                if (formationDossier.Education_FormationDossierType != null)
                {
                    cbTypeDossier.SelectedIndex = cbTypeDossier.FindStringExact(currentEducation_Formation.Education_FormationDossier
                        .FirstOrDefault().Education_FormationDossierType.FormationDossierType_Name);


                }
            }
        }

        private void Education_FormationRecord_FillCbListPRoviders(Education_Formation currentEducation_Formation)
        {
            cbListProvider.ItemCheck -= cbListProvider_ItemCheck;
            cbListProvider.Items.Clear();
            if (currentEducation_Formation.Education_FormationProvider != null)
            {
                foreach (Education_FormationProvider formationProvider in currentEducation_Formation.Education_FormationProvider)
                {
                    cbListProvider.Items.Add(formationProvider.Education_Provider.Provider_Name);
                    if (formationProvider.FormationProvider_IsActual == true)
                    {
                        int indexTrue = cbListProvider.Items.IndexOf(formationProvider.Education_Provider.Provider_Name);
                        cbListProvider.ItemCheck += cbListProvider_ItemCheck;

                        cbListProvider.SetItemChecked(indexTrue, true);
                    }
                    else
                    {
                        int indexFalse = cbListProvider.Items.IndexOf(formationProvider.Education_Provider.Provider_Name);
                        cbListProvider.ItemCheck += cbListProvider_ItemCheck;

                        cbListProvider.SetItemChecked(indexFalse, false);

                    }
                }
            }
            else
            {
                cbListProvider.ItemCheck += cbListProvider_ItemCheck;

            }

        }

        private void cbListProvider_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                for (int ix = 0; ix < cbListProvider.Items.Count; ++ix)
                {
                    if (ix != e.Index)
                    {
                        cbListProvider.SetItemChecked(ix, false);
                        var itemChecked = cbListProvider.Items[e.Index];
                        foreach (Education_FormationProvider formationProvider in CurrentFormation.Education_FormationProvider)
                        {
                            if (formationProvider.Education_Provider.Provider_Name == itemChecked)
                            {
                                formationProvider.FormationProvider_IsActual = true;
                                tbVendor.Text = formationProvider.FormationProvider_Vendor.ToString();
                            }

                            else
                                formationProvider.FormationProvider_IsActual = false;
                        }
                    }
                    else
                    {
                        //cbListProvider.SetItemChecked(ix, true);

                    }
                }
                ActivateModification(true);

            }
            catch (Exception ex)
            {

            }
        }

        private void Education_FormationRecord_SelectDurationInDays(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_DurationInDays != null)
            {
                var float_number = (decimal)currentEducation_Formation.Formation_DurationInDays;
                var result = float_number - Math.Truncate(float_number);
                int hours = (int)Math.Ceiling(8 * result);

                comboBoxDurationhours.SelectedIndex = comboBoxDurationhours
                    .FindStringExact(hours.ToString());

                int days = (int)Math.Truncate(float_number);
                comboBoxDurationInDays.SelectedIndex = comboBoxDurationInDays
                  .FindStringExact(days.ToString());
            }

        }

        private void Education_FormationRecord_SelectMinCapacity(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_MinCapacity != null)
                comboBoxMinCapacity.SelectedIndex = comboBoxMinCapacity
                    .FindStringExact(currentEducation_Formation.Formation_MinCapacity.ToString());
        }

        private void Education_FormationRecord_SelectUnitePrice(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Education_UnitePrice != null)
                comboBoxUnite.SelectedIndex = comboBoxUnite
                    .FindStringExact(currentEducation_Formation.Education_UnitePrice.UnitePrice_Name.ToString());
        }


        private void Education_FormationRecord_FillFormationPrice(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_Price != null)
                textBoxPrice.Text = currentEducation_Formation.Formation_Price.ToString(); ;
        }

        private void Education_FormationRecord_SelectMaxCapacity(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_MinCapacity != null)
                comboBoxMaxCapacity.SelectedIndex = comboBoxMaxCapacity
                    .FindStringExact(currentEducation_Formation.Formation_MinCapacity.ToString());
        }

        private void Education_FormationRecord_SelectOptCapacity(Education_Formation currentFormation)
        {
            if (currentFormation.Formation_OptimalCapacity != null)
                comboBoxCapaciteOptimale.SelectedIndex = comboBoxCapaciteOptimale
                    .FindStringExact(currentFormation.Formation_OptimalCapacity.ToString());
        }

        public void Education_FormationRecord_FillRemarks(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_Remarks != null)
                richTextBoxRemarks.Text = currentEducation_Formation.Formation_Remarks;
            else
            {
                richTextBoxRemarks.Text = "";

            }
        }

        private void Education_FormationRecord_FillLabelsActif(Education_Formation currentEducation_Formation)
        {
        }

        private void Education_FormationRecord_FillSAP(Education_Formation currentEducation_Formation)
        {
            if (CurrentFormation.Formation_SAP != null)
            {
                labelSAPEducation_Formation.Text = CurrentFormation.Formation_SAP;
            }
        }

        private void Education_FormationRecord_FillLabels(Education_Formation Education_FormationRecord)
        {

            if (Education_FormationRecord.Formation_ShortTitle != null)
            {
                tbShortTitleEducation_Formation.Text = Education_FormationRecord.Formation_ShortTitle;
            }
            if (Education_FormationRecord.Formation_LongTitle != null)
            {
                tbLongTitle.Text = Education_FormationRecord.Formation_LongTitle;

            }
            SizeF stringSize = ResizeTextBox(tbShortTitleEducation_Formation);
            this.tbShortTitleEducation_Formation.Width = (int)Math.Round(stringSize.Width, 0);

            stringSize = ResizeTextBox(tbLongTitle);
            this.tbLongTitle.Width = (int)Math.Round(stringSize.Width, 0);

        }

        private void Education_FormationRecord_LoadDocInfoFiche(Education_Formation Education_FormationRecord)
        {
            if (Education_FormationRecord.Education_FormationDossier.Count > 0)
            {
                tbInfoFiche.Text = Education_FormationRecord.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == Education_FormationRecord.Formation_Id).FirstOrDefault().FormationDossier_InfoFicheHyperLink;
            }
            else
            {
                tbInfoFiche.Text = "";


            }
        }

        private void Education_FormationRecord_LoadDocScenario(Education_Formation Education_FormationRecord)
        {
            if (Education_FormationRecord.Education_FormationDossier.Count > 0)
            {
                tbScenario.Text = Education_FormationRecord.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == Education_FormationRecord.Formation_Id).FirstOrDefault().FormationDossier_ScenarioHyperLink;
            }
            else
            {
                tbScenario.Text = "";
            }
        }

        private void Education_FormationRecord_LoadDocTest(Education_Formation Education_FormationRecord)
        {
            if (Education_FormationRecord.Education_FormationDossier.Count > 0)
            {
                tbTest.Text = Education_FormationRecord.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == Education_FormationRecord.Formation_Id).FirstOrDefault().FormationDossier_TestHyperLink;
            }
            else
            {
                tbTest.Text = "";
            }
        }

        private void Education_FormationRecord_LoadDocSyllabus(Education_Formation Education_FormationRecord)
        {
            if (Education_FormationRecord.Education_FormationDossier.Count > 0)
            {
                tbSyllabus.Text = Education_FormationRecord.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == Education_FormationRecord.Formation_Id).FirstOrDefault().FormationDossier_SyllabusHyperLink;
            }
            else
            {
                tbSyllabus.Text = "";
            }
        }

        private void Education_FormationRecord_SelectPriority(Education_Formation currentFormation)
        {
            if (currentFormation.Education_FormationDossier.Count > 0)
            {
                cbPriority.Text = currentFormation.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == currentFormation.Formation_Id).FirstOrDefault().FormationDossier_Priority;
            }
            else
            {
                cbPriority.Text = "";
            }
        }

        private void Education_FormationRecord_InOrder(Education_Formation currentFormation)
        {
            if (currentFormation.Education_FormationDossier.Count > 0)
            {
                var formationDossier = currentFormation.Education_FormationDossier
                     .Where(w => w.FormationDossier_Formation == currentFormation.Formation_Id).FirstOrDefault();
                if (formationDossier.FormationDossier_InOrder != null)
                {
                    checkDossierOk.Checked = (bool)currentFormation.Education_FormationDossier
                        .Where(w => w.FormationDossier_Formation == currentFormation.Formation_Id).FirstOrDefault().FormationDossier_InOrder;
                }
            }
            else
            {
                checkDossierOk.Checked = false;
            }
        }

        private void Education_FormationRecord_Hubbel(Education_Formation currentFormation)
        {
            if (currentFormation.Education_FormationDossier.Count > 0)
            {
                var formationDossier = currentFormation.Education_FormationDossier
                    .Where(w => w.FormationDossier_Formation == currentFormation.Formation_Id).FirstOrDefault();
                if (formationDossier.FormationDossier_Hubbel != null)
                {
                    checkHubbel.Checked = (bool)currentFormation.Education_FormationDossier
                     .Where(w => w.FormationDossier_Formation == currentFormation.Formation_Id).FirstOrDefault().FormationDossier_Hubbel;
                }


            }
        }


        private void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls)
                ctl.Enabled = enable;
        }

        /// <summary>
        /// Creation bouton annuler et sauvegarde
        /// </summary>
        private void CreateButtonSavingAgent()
        {
            Button ButtonSaveAgent = new Button();
            ButtonSaveAgent.Location = new Point(16, 489);
            ButtonSaveAgent.Text = "Sauver";
            ButtonSaveAgent.Name = "ButtonSaveAgent";

            ButtonSaveAgent.FlatAppearance.BorderSize = 0;
            ButtonSaveAgent.AutoSize = true;
            ButtonSaveAgent.FlatStyle = FlatStyle.Flat;
            ButtonSaveAgent.Enabled = false;
            ButtonSaveAgent.TabIndex = 90;
            ButtonSaveAgent.BackColor = Color.LightGray;
            ButtonSaveAgent.Click += new System.EventHandler(this.SaveEducation_FormationAsync);

            //
            ButtonSaveAgent.Font = new Font("Arial", 18);
            ButtonSaveAgent.ForeColor = Color.White;

            this.tabControl_Education_Formations.Controls[1].Controls.Add(ButtonSaveAgent);

            // 
            Button ButtonCancelModificationAgent = new Button();
            ButtonCancelModificationAgent.Location = new Point(116, 489);
            ButtonCancelModificationAgent.Text = "Annuler";
            ButtonCancelModificationAgent.Name = "ButtonCancel";
            ButtonCancelModificationAgent.TabIndex = 91;
            ButtonCancelModificationAgent.FlatStyle = FlatStyle.Flat;
            ButtonCancelModificationAgent.FlatAppearance.BorderSize = 0;

            ButtonCancelModificationAgent.AutoSize = true;
            ButtonCancelModificationAgent.Enabled = false;
            ButtonCancelModificationAgent.BackColor = Color.LightGray;
            ButtonSaveAgent.ForeColor = Color.White;
            ButtonCancelModificationAgent.Font = new Font("Arial", 18);

            //
            this.tabControl_Education_Formations.Controls[1].Controls.Add(ButtonCancelModificationAgent);
        }

        private async void SaveEducation_FormationAsync(object sender, EventArgs e)
        {
            db.SaveEducation_Formation(CurrentFormation);
            ActivateModification(false);
            //MainWindow.globalListEducation_Formations = await db.LoadAllEducation_FormationsAsync();

            listPaged = await LoadDatagriEducation_Formations();
            AdvDg_Formations.DataSource = GetDataSource(listPaged);
            AdvDg_Formations.Refresh();

        }

        private SizeF ResizeTextBox(TextBox tb)
        {
            SizeF stringSize; using (Graphics gfx = this.CreateGraphics())
            {
                // Get the size given the string and the font
                stringSize = gfx.MeasureString(tb.Text, tb.Font);
            }
            return stringSize;
        }

        #endregion

        private void labelDateOfEntry_Click(object sender, EventArgs e)
        {

        }

        private void tabPageEducation_FormationFiche_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxDurationInDays_Leave(object sender, EventArgs e)
        {
            try
            {

                int days = 0;
                if (comboBoxDurationInDays.SelectedItem != null | comboBoxDurationInDays.Text != "")
                {
                    if (comboBoxDurationInDays.SelectedItem != null)
                        days = Convert.ToInt32(comboBoxDurationInDays.SelectedItem.ToString());
                    else
                        days = Convert.ToInt32(comboBoxDurationInDays.Text.ToString());
                }
                int hours = 0;
                double hoursFloat = 0;
                if (comboBoxDurationhours.Text != "")
                {
                    hours = Convert.ToInt32(comboBoxDurationhours.SelectedItem.ToString());
                    hoursFloat = (double)hours * 0.125;

                }


                double durationFloat = days + hoursFloat;
                if (durationFloat != CurrentFormation.Formation_DurationInDays)
                {
                    CurrentFormation.Formation_DurationInDays = durationFloat;
                    ActivateModification(true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBoxDurationhours_Leave(object sender, EventArgs e)
        {
            if (CurrentFormation != null)
            {
                int days = 0;
                int hours = 0;
                if (comboBoxDurationInDays.SelectedItem != null | comboBoxDurationInDays.Text != "")
                {
                    if (comboBoxDurationhours.SelectedItem != null)
                        days = Convert.ToInt32(comboBoxDurationhours.SelectedItem.ToString());
                    else
                        days = Convert.ToInt32(comboBoxDurationInDays.Text.ToString());
                }



                //int hoursFloat = 0;
                double hoursFloat = 0;
                if (comboBoxDurationhours.SelectedItem != null | comboBoxDurationhours.Text != "")
                {
                    if (comboBoxDurationhours.SelectedItem != null)
                        hours = Convert.ToInt32(comboBoxDurationhours.SelectedItem.ToString());
                    else
                        hours = Convert.ToInt32(comboBoxDurationhours.Text.ToString());

                    hoursFloat = (double)hours * 0.125;
                }


                double durationFloat = days + hoursFloat;
                if (durationFloat != CurrentFormation.Formation_DurationInDays)
                {
                    CurrentFormation.Formation_DurationInDays = durationFloat;
                    ActivateModification(true);
                }
            }

        }

        private void comboBoxCompetence_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CurrentFormation.Formation_Competence != ((Education_Competence)comboBoxCompetence.SelectedItem).Competence_Id)
                {
                    CurrentFormation.Formation_Competence = ((Education_Competence)comboBoxCompetence.SelectedItem).Competence_Id;
                    ActivateModification(true);
                }
            }
            catch { }
        }

        private void comboBoxCapaciteOptimale_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxCapaciteOptimale.Text) != CurrentFormation.Formation_OptimalCapacity)
            {
                CurrentFormation.Formation_OptimalCapacity = Convert.ToInt32(comboBoxCapaciteOptimale.Text);
                ActivateModification(true);
            }
        }

        private void comboBoxCapaciteMax_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxMaxCapacity.Text) != CurrentFormation.Formation_MaxCapacity)
            {
                CurrentFormation.Formation_MaxCapacity = Convert.ToInt32(comboBoxMaxCapacity.Text);
                ActivateModification(true);
            }
        }

        private void comboBoxCapaciteMin_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxMinCapacity.Text) != CurrentFormation.Formation_MinCapacity)
            {
                CurrentFormation.Formation_MinCapacity = Convert.ToInt32(comboBoxMinCapacity.Text);
                ActivateModification(true);
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            var price = comboBoxResultatYear.SelectedItem;

            if (Regex.IsMatch(textBoxPrice.Text, @"[0-9a-z]+"))
                if (Convert.ToInt32(textBoxPrice.Text) != CurrentFormation.Formation_Price && comboBoxUnite.SelectedItem != null)
                {
                    CurrentFormation.Formation_Price = Convert.ToInt32(textBoxPrice.Text);

                    CurrentFormation.Education_UnitePrice.UnitePrice_Id = ((Education_UnitePrice)comboBoxUnite.SelectedItem).UnitePrice_Id;

                    ActivateModification(true);
                }
            ActivateModification(true);

        }

        private void comboBoxUnite_Leave(object sender, EventArgs e)
        {

            if (CurrentFormation.Education_UnitePrice.UnitePrice_Name != comboBoxUnite.Text)
            {
                CurrentFormation.Formation_UnitePrice = ((Education_UnitePrice)comboBoxUnite.SelectedItem).UnitePrice_Id;
                ActivateModification(true);
            }
        }

        private void comboBoxUnite_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxResultatByYear_Leave(object sender, EventArgs e)
        {

        }

        private void tbVendor_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentFormation.Education_FormationProvider.Count > 0)
            {
                var currentActifProvider = CurrentFormation.Education_FormationProvider
                    .Where(w => w.FormationProvider_IsActual == true).FirstOrDefault();

                if (currentActifProvider != null)
                {
                    if (currentActifProvider.FormationProvider_Vendor != null)
                    {
                        if (tbVendor.Text != "")
                        {
                            if (Convert.ToInt32(tbVendor.Text) != currentActifProvider.FormationProvider_Vendor)
                            {
                                currentActifProvider.FormationProvider_Vendor = Convert.ToInt32(tbVendor.Text);
                                ActivateModification(true);
                            }
                        }
                    }
                    else
                    {
                        if (tbVendor.Text == "")
                            currentActifProvider.FormationProvider_Vendor = 0;
                        else
                            currentActifProvider.FormationProvider_Vendor = Convert.ToInt32(tbVendor.Text);
                        ActivateModification(true);
                    }
                }
            }
        }

        private void ActivateModification(bool enable)
        {
            Button buttonSave = GetSaveButton();
            Button buttonCancel = GetCancelButton();

            if (enable)
            {
                buttonSave.Enabled = enable;
                buttonSave.Visible = Visible;

                buttonSave.BackColor = Color.FromArgb(106, 199, 234);
                buttonSave.ForeColor = Color.White;

                buttonCancel.Enabled = enable;
                buttonCancel.Visible = Visible;

                buttonCancel.BackColor = Color.FromArgb(195, 29, 29);
                buttonCancel.ForeColor = Color.White;
            }
            else
            {
                buttonSave.Enabled = enable;
                buttonSave.BackColor = Color.Gray;
                buttonSave.ForeColor = Color.LightGray;

                buttonCancel.Enabled = enable;
                buttonCancel.BackColor = Color.Gray;
                buttonCancel.ForeColor = Color.LightGray;


            }
        }

        private Button GetCancelButton()
        {
            Button buttonCancel = new Button();
            foreach (Control ctrl in this.tabControl_Education_Formations.Controls[1].Controls)
            {
                if (ctrl.Name == "ButtonCancel")
                    buttonCancel = (Button)ctrl;
            }
            return buttonCancel;
        }

        private Button GetSaveButton()
        {
            Button buttonSave = new Button();
            foreach (Control ctrl in this.tabControl_Education_Formations.Controls[1].Controls)
            {
                if (ctrl.Name == "ButtonSaveAgent")
                    buttonSave = (Button)ctrl;
            }
            return buttonSave;
        }

        private void txtYearOfCreation_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox tbSender = (TextBox)sender;
                if (CurrentFormation.Formation_YearOfCreation != Convert.ToInt32(txtYearOfCreation.Text))
                {
                    //if (!Regex.Match(txtYearOfCreation.Text, @"\(\d{4}\)").Success)
                    if (Regex.Match(txtYearOfCreation.Text, @"^(19|20)\d{2}$").Success)

                    {
                        CurrentFormation.Formation_YearOfCreation = Convert.ToInt32(txtYearOfCreation.Text);
                        ActivateModification(true);
                    }
                    else
                    {
                        MessageBox.Show("Mauvais format pour l'année de la date de création");
                        txtYearOfCreation.Text = CurrentFormation.Formation_YearOfCreation.ToString();
                        tbSender.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mauvais format pour l'année de la date de création");
                txtYearOfCreation.Text = CurrentFormation.Formation_YearOfCreation.ToString();
                TextBox tbSender = (TextBox)sender;

                tbSender.Focus();

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AdvDg_Formations_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.ClearSelection();
                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[1].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Fiche de la formation", EditEducation_Formation_CLick));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                        //if (currentMouseOverRow >= 0)
                        //{
                        //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                        //}

                        m.Show(dgv, new Point(e.X, e.Y));
                        FormationIDSelected = dgv.SelectedCells[1].Value.ToString();

                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AdvDg_Formations_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void AdvDg_Formations_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
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
                //listUserPaged = await LoadDatagridAgentAsync();
                var listAgentFiltered = db.LoadFormationFiltered(_filterString, MainWindow.globalListEducation_Formations);
                pageSize = Convert.ToInt32(tbNbrRows.Text);
                AdvDg_Formations.DataSource = GetDataSource(listAgentFiltered.ToPagedList(1, pageSize));
                BindingSource datasource = new BindingSource()
                {
                    DataSource = listUserPaged

                };
                if (datasource != null)
                    datasource.Filter = filterEventArgs.FilterString;

                AdvDg_Formations.Refresh();
            }
        }

        private void advDv_AgentsOfFormation_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.ClearSelection();
                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Modifier l'agent", EditUser_CLick));

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
            catch (Exception ex)
            {

            }
        }

        private async void AddNewProviderToList(object sender, EventArgs e)
        {
            var elementSelected = (Education_Provider)comboBoxProvider.SelectedItem;

            var itemFound = CurrentFormation.Education_FormationProvider
                .Where(w => w.FormationProvider_Formation == CurrentFormation.Formation_Id && w.FormationProvider_Provider == elementSelected.Provider_Id).FirstOrDefault();
            if (itemFound == null)
            {
                Education_FormationProvider newRecord = new Education_FormationProvider()
                {
                    Education_Provider = elementSelected,
                    FormationProvider_Provider = elementSelected.Provider_Id,
                    FormationProvider_Formation = CurrentFormation.Formation_Id,
                    FormationProvider_IsActual = false,
                };

                CurrentFormation.Education_FormationProvider.Add(newRecord);
                db.SaveEducation_FormationAsync(CurrentFormation);


                cbListProvider.Items.Add(elementSelected.Provider_Name);
                CurrentFormation = await db.LoadSingleEducation_FormationAsync(FormationIDSelected);
            }
            else
            {
                MessageBox.Show("Fournisseur est déja présent dans la liste", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void btnBrowseDoc_Click(object sender, EventArgs e)
        {


        }

        private void comboBoxResultatYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = comboBoxResultatYear.SelectedIndex;
                comboBoxResultatByYear.SelectedIndex = index;
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBoxResultatByYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index = comboBoxResultatByYear.SelectedIndex;
                if (index <= comboBoxResultatByYear.Items.Count)

                    comboBoxResultatYear.SelectedIndex = index;
            }
            catch (Exception ex)
            {

            }
        }

        private void cbListProvider_MouseHover(object sender, EventArgs e)
        {
            Point pos = cbListProvider.PointToClient(MousePosition);
            int tIndex = cbListProvider.IndexFromPoint(pos);

            if (tIndex > -1)
            {
                pos = this.PointToClient(MousePosition);
                toolTipListProvider.ToolTipTitle = "Informations";
                toolTipListProvider.SetToolTip(cbListProvider, cbListProvider.Items[tIndex].ToString());
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Point pos = picAddProvider.PointToClient(MousePosition);


            pos = this.PointToClient(MousePosition);
            toolTipAddProvider.ToolTipTitle = "Ajout d'un fournisseur";
            toolTipAddProvider.SetToolTip(picAddProvider, "Sélectionnez un fournisseur à ajouter à la liste.");

        }

        private void UCEducation_Formation_MouseHover(object sender, EventArgs e)
        {

        }

        private void cbListProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbListProvider_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void picExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                AutoClosingMessageBox messagebox = new AutoClosingMessageBox("Export vers le ficher excel en cours...", "Export Excel", 5000, MessageBoxIcon.Information);
                ExportToExcel exportExcel = new ExportToExcel();

                var fileExportedParth = exportExcel.Export(AdvDg_Formations);

                AutoClosingMessageBox messageboxEndExport = new AutoClosingMessageBox("Export Terminé", "Export Excel", 1000, MessageBoxIcon.Information);
                Process.Start(fileExportedParth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private static void CloseMessageBox()
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Export Excel");

            hWnd = FindWindowByCaption(IntPtr.Zero, "Export Excel");
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, 0);

        }

        private void lblShowHidePanelDossierPed_Click(object sender, EventArgs e)
        {
            if (tabControl_Education_FormationAndCertificationsOfUser.Visible == true)
            {

                tabControl_Education_FormationAndCertificationsOfUser.Visible = false;
            }
            else
            {
                tabControl_Education_FormationAndCertificationsOfUser.Visible = true;

            }
        }

        private void tbNbrRows_TextChanged(object sender, EventArgs e)
        {
            if (tbNbrRows.Text != "")
                pageSize = Convert.ToInt32(tbNbrRows.Text);

        }

        private async void btn_NextAgent_Click(object sender, EventArgs e)
        {
            if (listPaged.HasNextPage)
            {
                listPaged = await LoadDatagriEducation_Formations(++pageNumber, pageSize);
                btn_Previous.Enabled = listPaged.HasPreviousPage;
                btn_Next.Enabled = listPaged.HasNextPage;
                AdvDg_Formations.DataSource = GetDataSource(listPaged);
                AdvDg_Formations.Refresh();
            }
        }

        private async void btn_PreviousAgent_Click(object sender, EventArgs e)
        {
            if (listPaged.HasPreviousPage)
            {
                listPaged = await LoadDatagriEducation_Formations(--pageNumber, pageSize);
                btn_Next.Enabled = listPaged.HasNextPage;
                btn_Previous.Enabled = listPaged.HasPreviousPage;
                AdvDg_Formations.DataSource = GetDataSource(listPaged);
                AdvDg_Formations.Refresh();
            }
        }

        private void tbNbrRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (Regex.IsMatch(tbNbrRows.Text, @"[0-9]"))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (listFormationFiltered == null)
                        listFormationFiltered = MainWindow.globalListEducation_Formations;

                    pageSize = Convert.ToInt32(tbNbrRows.Text);

                    AdvDg_Formations.DataSource = GetDataSource(listFormationFiltered.ToPagedList(1, pageSize));
                    BindingSource datasource = new BindingSource()
                    {
                        DataSource = listFormationFiltered

                    };

                    AdvDg_Formations.Refresh();
                }
            }
        }

        #region Documents
        private void btnScenario_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "Scénario";
            openFileDialog1.AddExtension = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt| PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    Process.Start(fileName);
                    tbScenario.Text = fileName;

                    FileExtensions fileExtensions = new FileExtensions();
                    string fileSavedPath = fileExtensions.SaveFile(fileName, CurrentFormation.Formation_SAP);
                    dbFormationDossier.SaveScenario(CurrentFormation, fileSavedPath);


                }
            }
        }

        private void btnSyllabus_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.AddExtension = true;
            openFileDialog1.Title = "Syllabus";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt| PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    Process.Start(fileName);
                    tbSyllabus.Text = fileName;

                    FileExtensions fileExtensions = new FileExtensions();
                    string fileSavedPath = fileExtensions.SaveFile(fileName, CurrentFormation.Formation_SAP);
                    dbFormationDossier.SaveSyllabus(CurrentFormation, fileSavedPath);


                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.AddExtension = true; openFileDialog1.Title = "Test";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt| PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    Process.Start(fileName);
                    tbTest.Text = fileName;

                    FileExtensions fileExtensions = new FileExtensions();
                    string fileSavedPath = fileExtensions.SaveFile(fileName, CurrentFormation.Formation_SAP);
                    dbFormationDossier.SaveTestDoc(CurrentFormation, fileSavedPath);


                }
            }
        }

        private void btnBrowseDoc_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.AddExtension = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt| PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    Process.Start(fileName);
                    tbInfoFiche.Text = fileName;

                    FileExtensions fileExtensions = new FileExtensions();
                    string fileSavedPath = fileExtensions.SaveFile(fileName, CurrentFormation.Formation_SAP);
                    dbFormationDossier.SaveInfoFiche(CurrentFormation, fileSavedPath);

                    tbInfoFiche.Text = fileSavedPath;
                }
            }
        }

        private void cbTypeDossier_Leave(object sender, EventArgs e)
        {
            if (CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault().FormationDossier_TypeDossier
            != ((Education_FormationDossierType)cbTypeDossier.SelectedItem).FormationDossierType_Id)
            {
                var DossierOfFormation = CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault();

                DossierOfFormation.FormationDossier_TypeDossier = ((Education_FormationDossierType)cbTypeDossier.SelectedItem).FormationDossierType_Id;
                ActivateModification(true);
            }
        }

        private void tabControl_Education_Formations_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {

                AdvDg_Formations.DataSource = GetDataSource(listPaged);
            }
        }

        private void cbInfoFiche_Leave(object sender, EventArgs e)
        {
            if (CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault().FormationDossier_Priority
           != cbPriority.Text)
            {
                var DossierOfFormation = CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault();

                DossierOfFormation.FormationDossier_Priority = cbPriority.Text;
                ActivateModification(true);
            }
        }

        private void checkDossierOk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var DossierOfFormation = CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault();
                if (checkDossierOk.Checked)
                {
                    DossierOfFormation.FormationDossier_InOrder = true;
                    ActivateModification(true);
                }
                else
                {
                    DossierOfFormation.FormationDossier_InOrder = false;
                    ActivateModification(true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void checkHubbel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var DossierOfFormation = CurrentFormation.Education_FormationDossier.Where(x => x.FormationDossier_Formation == CurrentFormation.Formation_Id).FirstOrDefault();
                if (checkHubbel.Checked)
                {
                    DossierOfFormation.FormationDossier_Hubbel = true;
                    ActivateModification(true);
                }
                else
                {
                    DossierOfFormation.FormationDossier_Hubbel = false;
                    ActivateModification(true);
                }


            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        private void tbInfoFiche_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbInfoFiche_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                FileToProcess = tbInfoFiche.Text;
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Ouvrir le ficher", ShowFile, Shortcut.AltF9));

            }
        }

        private void ShowFile(object sender, EventArgs e)
        {
            if (FileToProcess != "")
            {
                Process.Start(FileToProcess);

            }
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbInfoFiche.Text != "")
            {
                Process.Start(tbInfoFiche.Text);
            }
            else
            {
                AutoClosingMessageBox.Show("Aucun fichier à afficher", "Error", 1000, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (tbScenario.Text != "")
            {
                Process.Start(tbScenario.Text);
            }
            else
            {
                AutoClosingMessageBox.Show("Aucun fichier à afficher", "Error", 1000, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbSyllabus.Text != "")
            {
                Process.Start(tbSyllabus.Text);
            }
            else
            {
                AutoClosingMessageBox.Show("Aucun fichier à afficher", "Error", 1000, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (tbTest.Text != "")
            {
                Process.Start(tbTest.Text);
            }
            else
            {
                AutoClosingMessageBox.Show("Aucun fichier à afficher", "Error", 1000, MessageBoxIcon.Error);
            }
        }

        private void cbListProvider_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Rectangle r = cbListProvider.GetItemRectangle(e.X);
                TextBox newAmountTextBox = new TextBox();
                newAmountTextBox.Location = new Point(r.Left, r.Top);

                ContextMenu m = new ContextMenu();

                Point currentMouseOverRow = e.Location;


                m.MenuItems.Add(new MenuItem("Visualiser le fournisseur", EditProvider_CLick));


                //m.Show(dgv, new Point(e.X, e.Y));
            }


        }

        private void EditProvider_CLick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void picViewProvider_Click(object sender, EventArgs e)
        {
            var itemChecked = cbListProvider.CheckedItems[0];
            var ProviderChecked = dbProvider.GetProvider(itemChecked.ToString());


            MainWindowPointerMenuBtnProvider.DynamicInvoke(ProviderChecked.Provider_Id);
            PointerProvider.DynamicInvoke(ProviderChecked.Provider_Id);

        }

        #region Tab Matrice


        #endregion


    }
}

