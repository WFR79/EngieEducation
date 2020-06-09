using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Repositories;
using Module_Education.Models;
using PagedList;
using Module_Education.Classes;

namespace Module_Education
{
    public partial class UC_GrpAgents : UserControl
    {
        private static UC_GrpAgents _instance;
        public Delegate PointMenuBtnAgent;
        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();

        private Education_Agent SelectedAgent = new Education_Agent();
        private Education_GroupLearner SelectedGrpLearner = new Education_GroupLearner();
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
        private string _filterString = null;

        #endregion

        #region Repositories
        private GrpAgentRepository GrpAgentRepository = new GrpAgentRepository();
        private GrpLearnearAgentRepository grpLearnearAgentRepository = new GrpLearnearAgentRepository();
        private AgentDataAccess AgentDataAccess = new AgentDataAccess();
        private AgentMatriceRepository dbAgentMatrice = new AgentMatriceRepository();
        private List<Education_Agent> listAgentFiltered;


        #endregion
        public long UserIDSelected { get; private set; }
        public List<long> ListOfMatriculeSelected = new List<long>();
        public UC_GrpAgents()
        {
            InitializeComponent(); 
            LoadComboGrpAgents();
            LoadComboAgents();

        }
        public static UC_GrpAgents Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_GrpAgents();

                return _instance;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GrpAgentRepository.AddGrpAgent(tbGrpAgentName.Text, tbGrpAgentSAP.Text);
            LoadComboGrpAgents();
            LoadComboAgents();
        }

        private void LoadComboAgents()
        {
            Cursor.Current = Cursors.WaitCursor;
            comboAgents.DataSource = grpLearnearAgentRepository.GetAgentNotInTheSelectedGroup(SelectedGrpLearner);
            comboAgents.DisplayMember = "Agent_Fullname";
        }
        private void LoadComboGrpAgents()
        {
            comboGrpAgents.DataSource = GrpAgentRepository.LoadAllGrpAgentsActif();
            comboGrpAgents.DisplayMember = "GroupLearner_Name";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Education_GroupLearner_Agent AddedAgent = grpLearnearAgentRepository.AddGrpLearnerAgent(SelectedAgent, SelectedGrpLearner);
            List<Education_Matrice_GrLearner> listMatriceGrpAgent = grpLearnearAgentRepository.GetMatriceOfGroupLearner(SelectedGrpLearner);
            if (listMatriceGrpAgent.Count > 0)
            {
                foreach (var matriceGrpAgent in listMatriceGrpAgent)
                {
                    dbAgentMatrice.AssignAgentToRoute(matriceGrpAgent.Education_Matrice, SelectedAgent);

                }
            }
            IPagedList<Education_GroupLearner_Agent> listAgentPaged = grpLearnearAgentRepository.LoadAgentOfSelectedGroup(SelectedGrpLearner).ToPagedList(1, 50);
            dgGrpAgent.DataSource = GetDataSource(listAgentPaged);
            dgGrpAgent.Refresh();
            MessageBox.Show("Agent : " + AddedAgent.Education_Agent.Agent_FullName + " ajouté au groupe.");
            LoadComboAgents();

        }

        private void comboAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAgent = (Education_Agent)comboAgents.SelectedItem;
        }

        private void comboGrpAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGrpLearner = (Education_GroupLearner)comboGrpAgents.SelectedItem;
            IPagedList<Education_GroupLearner_Agent> listAgentPaged = grpLearnearAgentRepository.LoadAgentOfSelectedGroup(SelectedGrpLearner).ToPagedList(1,50);

            List<Education_Agent> listAgentNotInTheGroupSelected = grpLearnearAgentRepository.GetAgentNotInTheSelectedGroup(SelectedGrpLearner);
            comboAgents.DataSource = listAgentNotInTheGroupSelected;

            dgGrpAgent.DataSource = GetDataSource(listAgentPaged);
            lblSelectedGrp.Text = "List d'agent du groupe " + SelectedGrpLearner.GroupLearner_Name;
        }

        private object GetDataSource(IPagedList<Education_GroupLearner_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o.Education_Agent)
            {
                Agent_Matricule = o.Education_Agent.Agent_Matricule,
                Agent_FirstName = o.Education_Agent.Agent_FirstName,
                Agent_Fullname = o.Education_Agent.Agent_FullName,
                Agent_Name = o.Education_Agent.Agent_Name,
                Function_Name = o.Education_Agent.Agent_Function == null ? null : o.Education_Agent.Education_Function.Function_Name,

                //Function_Name = o.Agent_Function == null ? null : dbEntities.Education_Function.Where(x => x.Function_Id == o.Agent_Function).FirstOrDefault().Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                Agent_Admin = o.Education_Agent.Agent_Admin,
                //Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,
                Agent_InRoute = o.Education_Agent.Education_InRoute == null ? "" : o.Education_Agent.Education_InRoute.InRoute_Name,
                Agent_IsWorksManager = o.Education_Agent.Agent_IsWorksManager,
                Agent_DateSeniority = o.Education_Agent.Agent_DateSeniority,
                Agent_DateOfEntry = o.Education_Agent.Agent_DateOfEntry,
                Agent_DateFunction = o.Education_Agent.Agent_DateFunction,
                Agent_Habilitation = o.Education_Agent.Education_Habilitation == null ? null : o.Education_Agent.Education_Habilitation.Habilitation_Name,
                Agent_Status = o.Education_Agent.Education_AgentStatus == null ? null : o.Education_Agent.Education_AgentStatus.AgentStatus_Name,
                Agent_Etat = o.Education_Agent.Agent_Etat


            }).ToList();
            return dataSource;
        }

        private object GetDataSource(List<Education_Agent> listAgentFiltered)
        {
            try
            {
                object dataSource = listAgentFiltered.Select(o => new MyColumnCollectionDGAgent(o)
                {
                    Agent_Matricule = o.Agent_Matricule,
                    Agent_FirstName = o.Agent_FirstName,
                    Agent_Name = o.Agent_Name,
                    Agent_Fullname = o.Agent_FullName,
                    Function_Name = o.Agent_Function == null ? null : dbEntities.Education_Function.Where(w => w.Function_Id == o.Agent_Function).FirstOrDefault().Function_Name,

                    ////Function_Name = o.Agent_Function == null ? null : dbEntities.Education_Function.Where(x => x.Function_Id == o.Agent_Function).FirstOrDefault().Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                    Agent_Admin = o.Agent_Admin == null ? null : o.Agent_Admin,
                    Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(w => w.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,

                    ////Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,
                    Agent_InRoute = o.Agent_InRoute == null ? "" : dbEntities.Education_InRoute.Where(w => w.InRoute_Id == o.Agent_InRouteId).FirstOrDefault().InRoute_Name,
                    Agent_IsWorksManager = o.Agent_IsWorksManager,
                    Agent_DateSeniority = o.Agent_DateSeniority,
                    Agent_DateOfEntry = o.Agent_DateOfEntry,
                    Agent_DateFunction = o.Agent_DateFunction,
                    Agent_Habilitation = o.Agent_Habilitation == null ? null : dbEntities.Education_Habilitation.Where(w => w.Habilitation_Id == o.Agent_Habilitation).FirstOrDefault().Habilitation_Name,
                    Agent_Status = o.Agent_Status == null ? null : dbEntities.Education_AgentStatus.Where(w => w.AgentStatus_Id == o.Agent_Status).FirstOrDefault().AgentStatus_Name,
                    Agent_Etat = o.Agent_Etat


                }).OrderBy(p => p.Agent_Matricule)
                    .ToList();


                return dataSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgGrpAgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool)
            {
                bool value = (bool)e.Value;
                e.Value = (value) ? "OUI" : "NON";
                e.FormattingApplied = true;
            }
        }

        private void btnDeleteGrp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Etes-vous sûr de vouloir supprimer le groupe d'agent?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(SelectedGrpLearner.GroupLearner_Name);
                bool result = grpLearnearAgentRepository.DeleteGroup(SelectedGrpLearner);
            }
        }

        internal void SelectGroup(string grpAgentName)
        {
            comboGrpAgents.SelectedIndex = comboGrpAgents.FindStringExact(grpAgentName);
        }

        private void dgGrpAgent_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.Button == MouseButtons.Right)
                {
                    dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Afficher le statut du trajet de formation de l'agent", ShowAgentRouteCard));
                  


                    UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    m.Show(dgGrpAgent, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowAgentRouteCard(object sender, EventArgs e)
        {
            object[] arr = { UserIDSelected, null };

            PointMenuBtnAgent.DynamicInvoke(UserIDSelected);
        }

        private void dgGrpAgent_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
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

                if (_filterString == "")
                {
                    if (MainWindow.globalListAgents == null)
                    {
                        listAgentFiltered = AgentDataAccess.LoadAllAgents();
                    }
                    else
                    {
                        listAgentFiltered = MainWindow.globalListAgents;
                    }
                }
                else
                {

                    if (MainWindow.globalListAgents == null)
                    {
                        listAgentFiltered = AgentDataAccess.LoadAllAgents();
                    }
                    else
                    {
                        listAgentFiltered = MainWindow.globalListAgents;
                    }

                    //listUserPaged = await LoadTaskDatagridAgent(1, listUserPaged.TotalItemCount);
                    listAgentFiltered = AgentDataAccess.LoadAgentsFiltered(_filterString, listAgentFiltered);

                    //db.LoadAgentsFiltered(_filterString, LoadTaskDatagridAgent(1, listUserPaged.TotalItemCount));
                    //dG_Agents.DataSource = bindingSource;
                }
                dgGrpAgent.DataSource = GetDataSource(listAgentFiltered);

                //btnClearFilters.Enabled = true;
            }
        }

        private void dgGrpAgent_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                ListOfMatriculeSelected.Clear();

                //dgv.ClearSelection();
                if (dgGrpAgent.SelectedRows.Count > 1)
                {
                    var selectedRows = dgGrpAgent.SelectedRows
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
                            m.MenuItems.Add(new MenuItem("Goto fiche de l'agent", EditUser_CLick));
                            //m.MenuItems.Add(new MenuItem("Visualisation de l'agent", VisualisationUser_CLick));

                            int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                            m.Show(dgv, new Point(e.X, e.Y));
                            UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                        }
                    }
                    else
                    {
                        // Todo

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void VisualisationUser_CLick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditUser_CLick(object sender, EventArgs e)
        {
            object[] arr = { UserIDSelected, null };

            PointMenuBtnAgent.DynamicInvoke(UserIDSelected);
        }
    }
}
