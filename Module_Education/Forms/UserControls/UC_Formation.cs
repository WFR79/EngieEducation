
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

namespace Module_Education
{
    public partial class UCEducation_Formation : UserControl
    {
        public BindingSource ds_Education_Formations = new BindingSource();
        private Education_FormationDataAccess db = new Education_FormationDataAccess();
        private SessionUniteDataAccess dbSessionUnite = new SessionUniteDataAccess();
        private ProviderDataAccess dbProvider = new ProviderDataAccess();
        private CompetenceDataAccess dbCompetence = new CompetenceDataAccess();
        private FormationResultatDataAccess dbFormationResulat = new FormationResultatDataAccess();

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();


        private static UCEducation_Formation _instance;
        IPagedList<Education_Formation> listPaged;
        IPagedList<Education_Agent> listUserPaged;
        public static long UserIDSelected;
        public static string Education_FormationIDSelected;

        Education_Formation CurrentFormation;

        public Delegate MainWindowPointerMenuBtnAgent;
        public Delegate PointerUCAgent_Refresh;

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

        public UCEducation_Formation()
        {
            InitializeComponent();
            //
            LoadComboboxs();
            this.ActiveControl = this.comboBoxDurationhours;   
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
            comboBoxUnite.DataSource = dbSessionUnite.LoadAllSessionUnite();
            comboBoxUnite.DisplayMember = "SessionUnite_Name";

            // YearOfCreation

            

            //Education_Habilitation
            comboBoxProvider.DataSource = dbProvider.AllProviders();
            comboBoxProvider.ValueMember = "Provider_Name";

            //Compétence
            comboBoxCompetence.DataSource = dbCompetence.LoadAllCompetences();
            comboBoxCompetence.ValueMember = "Competence_Name";

            ////EPI
            //comboBoxEPI.DataSource = dbEPI.LoadAllRoleEPI();
            //comboBoxEPI.ValueMember = "RoleEPI_Name";

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
                    cb_FiltreDgEducation_Formations.Items.Add(columns[i].HeaderText);
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
            StylingDatagrid(dG_Education_Formations);

        }

        private void tbFiltre_TextChanged(object sender, EventArgs e)
        {
            LoadDatagriEducation_FormationsFiltered(tbFiltre.Text, cb_FiltreDgEducation_Formations.SelectedItem.ToString());
        }

        private async Task<IPagedList<Education_Formation>> LoadDatagriEducation_Formations(int pagNumber = 1, int pageSize = 100)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    {
                        if (MainWindow.globalListEducation_Formations == null)
                        {

                            return dbList.Education_Formation
                            .Include("Education_CategorieFormation")
                            .Include("Education_FormationProvider")
                            .Include("Education_FormationResultat")
                            .Include("Education_FormationSession")
                            .Include("Education_Matrice_Formation")
                            .Include("Education_UnitePrice")

                            .OrderBy(p => p.Formation_Id).ToPagedList(pagNumber, pageSize);
                            //dG_Education_Formations.DataSource = lEducation_Formations.ToPagedList(1, 100); ;
                        }
                        else
                        {
                            return MainWindow.globalListEducation_Formations.ToPagedList(pagNumber, pageSize); ;
                            //dG_Education_Formations.DataSource = MainWindow.globalListEducation_Formations.ToPagedList(1, 100); 
                        }
                    }


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
            LoadCbListColumnsToFilter(dG_Education_Formations.Columns, dG_Education_Formations);
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async void UC_Education_Formation_Load(object sender, EventArgs e)
        {
            AdvDg_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.
            //dG_Education_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.

            listPaged = await LoadDatagriEducation_Formations();
            AdvDg_Formations.DataSource = GetDataSource(listPaged);
            AdvDg_Formations.Refresh();
            AdvDg_Formations.SelectionChanged += dG_Education_Formations_SelectionChanged; // ReAdd the handler.
            LoadCbListColumnsToFilter(AdvDg_Formations.Columns, AdvDg_Formations);

            StylingDatagrid(dG_Education_Formations);
        }

        private object GetDataSource(IPagedList<Education_Formation> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_DurationInDays = o.Formation_DurationInDays,
                Formation_SAP = o.Formation_SAP,
                //Column_LongTitle = o.Education_Formation_LongTitle,
                Formation_YearOfCreation = o.Formation_YearOfCreation,
                Formation_CapaciteMin = o.Formation_MinCapacity,
                Formation_CapaciteMax= o.Formation_MaxCapacity,

                Formation_CapaciteOptimale = o.Formation_OptimalCapacity,


            }).ToList();

            return dataSource;
        }

        private object GetDataSource(IPagedList<Education_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o)
            {
                ColumnUser_Matricule = o.Agent_Matricule,
                ColumnFirstName = o.Agent_FirstName,
                ColumnUser_Name = o.Agent_Name,

                ColumnFunction = o.Education_Function == null ? null : o.Education_Function.Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                ColumnAdmin = o.Agent_Admin,
                ColumnResponsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,

                ColumnChargeTravaux = o.Agent_IsWorksManager,
                ColumnDateSenioritiy = o.Agent_DateSeniority,
                ColumnDateEntry = o.Agent_DateOfEntry,
                ColumnDateFunction = o.Agent_DateFunction,
                ColumnEducation_Habilitation = o.Education_Habilitation == null ? null : o.Education_Habilitation.Habilitation_Name,
                ColumnStatut = o.Education_AgentStatus == null ? null : o.Education_AgentStatus.AgentStatus_Name,
                ColumnEtat = o.Agent_Etat


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
                dG_Agents.DataSource = source;
                AdvDg_Formations.Refresh();
                dG_Agents.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void Refresh_Datagrid(object sender, EventArgs e)
        {
            AdvDg_Formations.Refresh();

        }

        private async void btn_Next_Click(object sender, EventArgs e)
        {
            if (listPaged.HasNextPage)
            {
                listPaged = await LoadDatagriEducation_Formations(++pageNumber);
                btn_Previous.Enabled = listPaged.HasPreviousPage;
                btn_Next.Enabled = listPaged.HasNextPage;
                AdvDg_Formations.DataSource = GetDataSource(listPaged);
                AdvDg_Formations.Refresh();
            }

        }

        private async void btn_Previous_Click(object sender, EventArgs e)
        {
            if (listPaged.HasPreviousPage)
            {
                listPaged = await LoadDatagriEducation_Formations(--pageNumber);
                btn_Next.Enabled = listPaged.HasNextPage;
                btn_Previous.Enabled = listPaged.HasPreviousPage;
                AdvDg_Formations.DataSource = GetDataSource(listPaged);
                AdvDg_Formations.Refresh();
            }
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
            PointerUCAgent_Refresh.DynamicInvoke(UserIDSelected);
        }

        private void labelSAPEducation_Formation_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Onglet Fiche Education_Formation
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
                        Education_FormationIDSelected = dgv.SelectedCells[1].Value.ToString();

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
            LoadFicheEducation_Formation(Education_FormationIDSelected);
        }

        private void LoadFicheEducation_Formation(string Education_FormationSAPSelected)
        {
            //DeleteButtonSavingAgent();
            TabPage page = (TabPage)this.tabControl_Education_Formations.Controls[1];
            this.EnableTab(page, true);

            CurrentFormation = db.LoadSingleEducation_Formation(Education_FormationIDSelected);
            if (CurrentFormation != null)
            {
                Education_FormationRecord_FillLabels(CurrentFormation);
                Education_FormationRecord_FillLabelsActif(CurrentFormation);

                Education_FormationRecord_FillSAP(CurrentFormation);
                //Education_FormationRecord_FillAdmin(CurrentEducation_Formation);
                Education_FormationRecord_SelectCompetence(CurrentFormation);
                Education_FormationRecord_PickDateOfCreation(CurrentFormation);
                //Education_FormationRecord_PickDateOfEntry(CurrentEducation_Formation);
                //Education_FormationRecord_PickUser_DateSeniority(CurrentEducation_Formation);
                //Education_FormationRecord_PickDateFunction(CurrentEducation_Formation);
                Education_FormationRecord_FillRemarks(CurrentFormation);
                Education_FormationRecord_FillResulats(CurrentFormation);
                Education_FormationRecord_FillPrice(CurrentFormation);

                Education_FormationRecord_SelectDurationInDays(CurrentFormation);
                Education_FormationRecord_SelectMinCapacity(CurrentFormation);
                Education_FormationRecord_SelectMaxCapacity(CurrentFormation);
                Education_FormationRecord_FillCbListPRoviders(CurrentFormation);
                LoadDatagriAgentsOfCurrentFormation();
                //Education_FormationRecord_SelectRoleEPI(CurrentEducation_Formation);
                //Education_FormationRecord_SelectRoleAstreinte(userReCurrentEducation_Formationcord);


                //Education_FormationRecord_SelectEducation_Habilitation(CurrentEducation_Formation);
                //UserRecord_LoadEducation_FormationsOfUser(userRecord);
                CreateButtonSavingAgent();
            }
        }

        private void Education_FormationRecord_FillPrice(Education_Formation currentFormation)
        {
            comboBoxResultatByYear.Items.Clear();
            if (currentFormation.Education_UnitePrice != null)
                foreach (Education_FormationResultat formationResult in currentFormation.Education_FormationResultat)
                {
                    comboBoxResultatByYear.Items.Add(formationResult.FormationResultat_Resultat);
                    comboBoxResultatYear.Items.Add(formationResult.FormationResultat_Year);
                }
            comboBoxResultatByYear.SelectedIndex = comboBoxResultatByYear.Items.Count - 1;
            comboBoxResultatYear.SelectedIndex = comboBoxResultatYear.Items.Count - 1;
        }

        private void Education_FormationRecord_FillResulats(Education_Formation currentFormation)
        {
            comboBoxResultatByYear.Items.Clear();
            if (currentFormation.Education_FormationResultat != null)
                foreach (Education_FormationResultat formationResult in currentFormation.Education_FormationResultat)
                {
                    comboBoxResultatByYear.Items.Add(formationResult.FormationResultat_Resultat);
                    comboBoxResultatYear.Items.Add(formationResult.FormationResultat_Year);
                }
            comboBoxResultatByYear.SelectedIndex = comboBoxResultatByYear.Items.Count -1 ;
            comboBoxResultatYear.SelectedIndex = comboBoxResultatYear.Items.Count - 1 ;

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
                txtYearOfCreation.Text =currentEducation_Formation.Formation_YearOfCreation.ToString();

            }
        }

        private void Education_FormationRecord_SelectCompetence(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Education_Competence != null)
                comboBoxCompetence.SelectedIndex = comboBoxCompetence.FindStringExact(currentEducation_Formation.Education_Competence.Competence_Name);
        }

        private void Education_FormationRecord_FillCbListPRoviders(Education_Formation currentEducation_Formation)
        {
            cbListProvider.Items.Clear();
            if (currentEducation_Formation.Education_FormationProvider != null)
                foreach (Education_FormationProvider formationProvider in currentEducation_Formation.Education_FormationProvider)
                {
                    cbListProvider.Items.Add(formationProvider.Education_Provider.Provider_Name);
                    if (formationProvider.FormationProvider_IsActual == true)
                    {
                        int index = cbListProvider.Items.IndexOf(formationProvider.Education_Provider.Provider_Name);
                        cbListProvider.SetItemChecked(index, true);
                    }
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

        private void Education_FormationRecord_SelectMaxCapacity(Education_Formation currentEducation_Formation)
        {
            if (currentEducation_Formation.Formation_MinCapacity != null)
                comboBoxMaxCapacity.SelectedIndex = comboBoxMaxCapacity
                    .FindStringExact(currentEducation_Formation.Formation_MinCapacity.ToString());
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
            ButtonSaveAgent.Location = new Point(482, 397);
            ButtonSaveAgent.Text = "Sauver";
            ButtonSaveAgent.Name = "ButtonSaveAgent";

            ButtonSaveAgent.FlatAppearance.BorderSize = 0;
            ButtonSaveAgent.AutoSize = true;
            ButtonSaveAgent.FlatStyle = FlatStyle.Flat;
            ButtonSaveAgent.Enabled = false;
            ButtonSaveAgent.TabIndex = 90;
            ButtonSaveAgent.BackColor = Color.FromArgb(106, 199, 234);
            ButtonSaveAgent.BackColor = Color.Gray;
            ButtonSaveAgent.Click += new System.EventHandler(this.SaveEducation_FormationAsync);

            //
            ButtonSaveAgent.Font = new Font("Arial", 18);
            ButtonSaveAgent.ForeColor = Color.LightGray;

            this.tabControl_Education_Formations.Controls[1].Controls.Add(ButtonSaveAgent);

            // 
            Button ButtonCancelModificationAgent = new Button();
            ButtonCancelModificationAgent.Location = new Point(582, 397);
            ButtonCancelModificationAgent.Text = "Annuler";
            ButtonCancelModificationAgent.Name = "ButtonCancel";
            ButtonCancelModificationAgent.TabIndex = 91;
            ButtonCancelModificationAgent.FlatStyle = FlatStyle.Flat;

            ButtonCancelModificationAgent.AutoSize = true;
            ButtonCancelModificationAgent.Enabled = false;
            ButtonCancelModificationAgent.BackColor = Color.OrangeRed;
            ButtonCancelModificationAgent.BackColor = Color.Gray;
            ButtonSaveAgent.ForeColor = Color.LightGray;
            ButtonCancelModificationAgent.Font = new Font("Arial", 18);

            //
            this.tabControl_Education_Formations.Controls[1].Controls.Add(ButtonCancelModificationAgent);
        }

        private async void SaveEducation_FormationAsync(object sender, EventArgs e)
        {
            db.SaveEducation_Formation(CurrentFormation);
            ActivateModification(false);

            MainWindow.globalListEducation_Formations = await db.LoadAllEducation_FormationsAsync();

            AdvDg_Formations.Refresh();
            listPaged = await LoadDatagriEducation_Formations();
            AdvDg_Formations.DataSource = GetDataSource(listPaged);

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
            int days = 0;
            if (comboBoxDurationInDays.SelectedItem != null | comboBoxDurationInDays.Text != "")
            {
                if(comboBoxDurationInDays.SelectedItem != null)
                    days = Convert.ToInt32(comboBoxDurationInDays.SelectedItem.ToString());
                else
                    days = Convert.ToInt32(comboBoxDurationInDays.Text.ToString());
            }
            int hours = 0;
            double hoursFloat = 0;
            if (comboBoxDurationhours.SelectedItem != null)
            {
                hours = Convert.ToInt32(comboBoxDurationhours.SelectedItem.ToString());
                hoursFloat = 8 / hours;
            }


            double durationFloat = days + hoursFloat;
            if (durationFloat != CurrentFormation.Formation_DurationInDays)
            {
                CurrentFormation.Formation_DurationInDays = durationFloat;
                ActivateModification(true);
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
                    if(comboBoxDurationhours.SelectedItem != null)
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
            if (CurrentFormation.Formation_Competence != ((Education_Competence)comboBoxCompetence.SelectedItem).Competence_Id)
            {
                CurrentFormation.Formation_Competence = ((Education_Competence)comboBoxCompetence.SelectedItem).Competence_Id;
                ActivateModification(true);
            }
        }

        private void ActivateModification(bool enable)
        {
            Button buttonSave = GetSaveButton();
            Button buttonCancel = GetCancelButton();

            if (enable)
            {
                buttonSave.Enabled = enable;
                buttonSave.BackColor = Color.FromArgb(106, 199, 234);
                buttonSave.ForeColor = Color.White;

                buttonCancel.Enabled = enable;
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
                txtYearOfCreation.Text = CurrentFormation.Formation_YearOfCreation.ToString() ;
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
                        Education_FormationIDSelected = dgv.SelectedCells[1].Value.ToString();

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
            var filter = e.FilterString;
            LoadDatagriEducation_FormationsFiltered(filter, "");


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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var elementSelected = (Education_Provider) comboBoxProvider.SelectedItem;

            var itemFound = CurrentFormation.Education_FormationProvider
                .Where(w => w.FormationProvider_Formation == CurrentFormation.Formation_Id && w.FormationProvider_Provider == elementSelected.Provider_Id).FirstOrDefault();
            if (itemFound == null)
            {
                Education_FormationProvider newRecord = new Education_FormationProvider()
                {
                    FormationProvider_Provider = elementSelected.Provider_Id,
                    FormationProvider_Formation = CurrentFormation.Formation_Id,
                    FormationProvider_IsActual = false

                };
                CurrentFormation.Education_FormationProvider.Add(newRecord);
                ActivateModification(true);
                cbListProvider.Items.Add(elementSelected.Provider_Name);
            }
            else
            {
                MessageBox.Show("Fournisseur est déja présent dans la liste","", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ;
            
            }
        }

        private void btnBrowseDoc_Click(object sender, EventArgs e)
        {

            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog1.ShowDialog();
        }

        private void comboBoxResultatYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxResultatYear.SelectedIndex;
            comboBoxResultatByYear.SelectedIndex = index;
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            var price = comboBoxResultatYear.SelectedItem;

        }

        private void comboBoxResultatByYear_Leave(object sender, EventArgs e)
        {

        }

        private void comboBoxResultatByYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxResultatByYear.SelectedIndex;
            comboBoxResultatYear.SelectedIndex = index;
        }

    }
}
}
