using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Models;
using Module_Education.DataAccessLayer;
using Module_Education.Repositories;
using Module_Education.Classes;
using Module_Education.Classes.Extensions;
using System.Threading;

namespace Module_Education.Forms.UserControls
{
    public partial class UC_MatriceFormations : UserControl
    {

        private static UC_MatriceFormations _instance;
        #region Treeview
        TreeNode mySelectedNode;
        string CurrentMatriceName = string.Empty;
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
        private RoutesFormationRepository dbMatrice = new RoutesFormationRepository();
        private InRouteFormationRepository dbMatriceFormation = new InRouteFormationRepository();
        private RouteAgentRepository routeAgentRepository = new RouteAgentRepository();
        private AgentDataAccess dbAgent = new AgentDataAccess();
        private AgentMatriceRepository dbAgentMatrice = new AgentMatriceRepository();
        private List<Education_Matrice> listMatrice;
        public Education_Matrice MatriceSelected;
        public Delegate PointerFormation;

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        public static List<Education_Matrice_Formation> listMatriceFormationSelected;
        private long UserIDSelected;
        private List<Education_Matrice_Formation> ListFormationMatriceSelected;
        public List<Education_Matrice_Agent> matriceAgentList;
        public Education_Matrice_Agent SelectedMatriceAgent;
        public List<Panel> listPanelRoutesFormation = new List<Panel>();

        private ControlCollection liscontrolOfPanel;

        public UC_MatriceFormations()
        {
            InitializeComponent();
            LoadFiltercbFormation();
            LoadFiltercbMatrice();
            LoadAllMatrice();

        }

        public static UC_MatriceFormations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_MatriceFormations();
                return _instance;
            }
        }

        public Education_Matrice_Formation Formationselected { get; private set; }

        #region

        private void LoadAllMatrice()
        {
            treeW_Routes.Nodes[0].Nodes.Clear();

            LoadComboboxRecurrency();
            listMatrice = dbMatrice.LoadAllMatrice();
            treeW_Routes.SelectedNode = treeW_Routes.Nodes[0];
            for (int i = 0; i < listMatrice.Count; i++)
            {
                TreeNode newNodeMatrice = new TreeNode()
                {
                    Text = listMatrice[i].Matrice_Description,

                };
                treeW_Routes.SelectedNode.Nodes.Add(newNodeMatrice); // Add node1.
                var listMatriceFormation = dbMatriceFormation.LoadMatriceFormation(newNodeMatrice.Text);

                foreach (var formation in listMatriceFormation)
                {
                    TreeNode newNode = new TreeNode()
                    {
                        Name = formation.Education_Formation.Formation_SAP,
                        Text = formation.Education_Formation.Formation_ShortTitle,

                    };
                    treeW_Routes.SelectedNode.Nodes[i].Nodes.Add(newNode);
                }
            }
            treeW_Routes.SelectedNode.Expand();
        }

        private void picAddMatrice_Click(object sender, EventArgs e)
        {
            treeW_Routes.BeginUpdate();
            //treeView2.Nodes.Clear();
            string yourParentNode;
            yourParentNode = "";

            if (mySelectedNode != null)
                treeW_Routes.SelectedNode = mySelectedNode;
            else
                treeW_Routes.SelectedNode = treeW_Routes.Nodes[0];


            TreeNode tn1 = new TreeNode();
            tn1.Text = "Entrez le nom de la nouvelle matrices";

            if (treeW_Routes.SelectedNode.Text == "Trajets")
                treeW_Routes.Nodes[0].Nodes.Add(tn1); // Add node1.
            else
            {

            }
            treeW_Routes.SelectedNode.Expand();
            //treeW_Provider.Nodes.Add(yourParentNode);
            //treeW_Provider.SelectedNode
            treeW_Routes.EndUpdate();
            tbTrajetName.Focus();
        }

        private void EditFormationToMatrice(object sender, EventArgs e)
        {
            treeW_Routes.LabelEdit = true;

            treeW_Routes.SelectedNode.BeginEdit();
        }

        private void AddFormationToMatrice(object sender, EventArgs e)
        {
            //lFormationToAddToMatrice.Clear();
            listMatriceFormationSelected = dbMatriceFormation.LoadMatriceFormation(treeW_Routes.SelectedNode.Text);

            FrmFormation frmFormation = new FrmFormation();
            frmFormation.ShowDialog();
            if (lFormationToAddToMatrice != null)
            {
                if (lFormationToAddToMatrice.Count > 0)
                {
                    foreach (var formation in lFormationToAddToMatrice)
                    {
                        TreeNode newNode = new TreeNode()
                        {
                            Name = formation.Formation_SAP,
                            Text = formation.Formation_ShortTitle,

                        };
                        treeW_Routes.SelectedNode.Nodes.Add(newNode);

                    }

                }
            }
            treeW_Routes.SelectedNode.Expand();
        }

        private void treeW_Provider_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeView tw = (TreeView)sender;
            if (e.Label != null && e.Label != tw.SelectedNode.Text)
                MessageBox.Show("Matrice sauvegardé", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeW_Provider_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            oldLabel = mySelectedNode.Text;
        }

        private void SaveRoutesFormation(object sender, EventArgs e)
        {
            List<Education_Matrice> newListeMatrice = new List<Education_Matrice>();
            TreeNodeCollection coll = treeW_Routes.Nodes;
            foreach (TreeNode root in coll)
            {
                foreach (TreeNode matriceDesc in root.Nodes)
                {
                    Education_Matrice matriceDb = dbEntities.Education_Matrice.Where(x => x.Matrice_Description == matriceDesc.Text).FirstOrDefault();
                    if (matriceDb != null)
                    {
                        var listFormationOfMatrice = dbMatriceFormation.LoadMatriceFormation(matriceDesc.Text);
                        foreach (TreeNode formation in matriceDesc.Nodes)
                        {
                            Education_Matrice_Formation MatriceformationDb = listFormationOfMatrice.Where(x => x.Education_Formation.Formation_ShortTitle == formation.Text && x.MatriceFormation_Matrice == matriceDb.Matrice_Id).FirstOrDefault();

                            if (MatriceformationDb == null)
                            {
                                Education_Formation formationDb = MainWindow.globalListEducation_Formations.Where(x => x.Formation_ShortTitle == formation.Text).FirstOrDefault();
                                if (formationDb != null)
                                {
                                    Education_Matrice_Formation newMatriceFormation = new Education_Matrice_Formation()
                                    {
                                        MatriceFormation_Matrice = matriceDb.Matrice_Id,
                                        MatriceFormation_Formation = formationDb.Formation_Id
                                    };

                                    dbEntities.Education_Matrice_Formation.Add(newMatriceFormation);
                                    dbEntities.SaveChanges();
                                }
                            }
                            else
                            {


                            }
                        }
                    }
                    else
                    {
                        Education_Matrice newMatrice = new Education_Matrice()
                        {
                            Matrice_Description = matriceDesc.Text,
                        };
                        listMatrice.Add(dbMatrice.SaveMatrice(newMatrice));

                        foreach (TreeNode formation in matriceDesc.Nodes)
                        {
                            var formItem = dbEntities.Education_Formation.Where(x => x.Formation_ShortTitle == formation.Text).FirstOrDefault();
                            Education_Matrice_Formation newMatriceFormation = new Education_Matrice_Formation()
                            {
                                MatriceFormation_Matrice = newMatrice.Matrice_Id,
                                MatriceFormation_Formation = formItem.Formation_Id
                            };

                            dbEntities.Education_Matrice_Formation.Add(newMatriceFormation);
                            dbEntities.SaveChanges();
                        }

                    }

                }
            }
        }

        private bool checkIfMatriceExists(TreeNode matrice)
        {
            if (listMatrice != null)
            {
                var matriceExist = listMatrice.Where(x => x.Matrice_Description == matrice.Text).FirstOrDefault();

                if (matriceExist != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private void AdvDg_Formations_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void tabControl_Education_Formations_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabcontrol = (TabControl)sender;
            if (tabcontrol.SelectedIndex == 2)
                LoadAllMatrice();

        }

        private void treeW_Provider_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var selectedNode = treeW_Routes.SelectedNode;
            if (selectedNode.Level == 0)
            {
                lblDetailsMatrice.Text = "Sélectionnez un trajet à gauche";
                btnSaveRoute.Enabled = false;
                btnSaveFormationRecurrence.Enabled = false;
                btnAssignAgent.Enabled = false;
                btnGrpAssignAgent.Enabled = false;
                tbTrajetName.Enabled = false;
                cbRecurrency.Enabled = false;
                cbRecurrencyFormation.Enabled = false;
                this.tbTrajetName.Text = "Sélectionnez un trajet à gauche";
            }
            if (selectedNode.Level == 1)
            {
                lblDetailsMatrice.Text = "Details de " + selectedNode.Text;
                MatriceSelected = dbEntities.Education_Matrice.Where(x => x.Matrice_Description == treeW_Routes.SelectedNode.Text).FirstOrDefault();
                if (MatriceSelected != null)
                {
                    if (MatriceSelected.Matrice_Recurrency != null)
                        cbRecurrency.SelectedIndex = cbRecurrency
                            .FindStringExact(MatriceSelected.Matrice_Recurrency.ToString());

                    tbTrajetName.Text = MatriceSelected.Matrice_Description;
                }
                if (selectedNode.FirstNode == null)
                {
                    btnAssignAgent.Enabled = false;
                    ToolTip toolTipAgent = new ToolTip();
                    toolTipAgent.SetToolTip(btnAssignAgent, "Impossible d'assigner");
                    btnGrpAssignAgent.Enabled = false;

                }
                else
                {
                    btnAssignAgent.Enabled = true;
                    btnGrpAssignAgent.Enabled = true;

                }
                tbTrajetName.Enabled = true;
                cbRecurrency.Enabled = true;
                btnSaveRoute.Enabled = true;
                btnSaveFormationRecurrence.Enabled = false;
                cbRecurrencyFormation.Enabled = false;
                LoadComboAgent();
                LoadComboGrpAgent();
                Blink(selectedNode.Level);

            }
            else
            {
                if (selectedNode.Level == 2)
                {
                    lblFormationMatrice.Text = "Details de " + selectedNode.Text;
                    Formationselected = dbMatriceFormation.LoadFormationOfRoute(treeW_Routes.SelectedNode.Name, selectedNode.Parent.Text);

                    if (Formationselected.MatriceFormation_Recurrency != null)
                        cbRecurrencyFormation.SelectedIndex = cbRecurrencyFormation
                            .FindStringExact(Formationselected.MatriceFormation_Recurrency.ToString());
                    else
                    {
                        cbRecurrencyFormation.SelectedIndex = 0;
                    }

                    btnSaveFormationRecurrence.Enabled = true;
                    cbRecurrencyFormation.Enabled = true;
                }
                LoadComboAgent();
                LoadComboGrpAgent();
                Blink(selectedNode.Level);

            }


        }

        private async void Blink(int level)
        {
            //timer1.Start();
            if (level == 1)
            {
                PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.FromArgb(0, 115, 204) ? Color.LightSkyBlue : Color.FromArgb(0, 115, 204);
                await Task.Delay(1000);
                PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.LightSkyBlue ? Color.FromArgb(0, 115, 204) : Color.LightSkyBlue;

                await Task.Delay(1000);
                PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.FromArgb(0, 115, 204) ? Color.LightSkyBlue : Color.FromArgb(0, 115, 204);

                await Task.Delay(1000);
                PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.LightSkyBlue ? Color.LightSkyBlue : Color.LightSkyBlue;

            }
            else
            {
                panelFormationDetails.BackColor = panelFormationDetails.BackColor == Color.FromArgb(0, 115, 204) ? Color.LightSkyBlue : Color.FromArgb(0, 115, 204);
                await Task.Delay(1000);
                panelFormationDetails.BackColor = panelFormationDetails.BackColor == Color.LightSkyBlue ? Color.FromArgb(0, 115, 204) : Color.LightSkyBlue;

                await Task.Delay(1000);
                panelFormationDetails.BackColor = panelFormationDetails.BackColor == Color.FromArgb(0, 115, 204) ? Color.LightSkyBlue : Color.FromArgb(0, 115, 204);

                await Task.Delay(1000);
                panelFormationDetails.BackColor = panelFormationDetails.BackColor == Color.LightSkyBlue ? Color.LightSkyBlue : Color.LightSkyBlue;
            }

        }

        private void LoadComboboxRecurrency()
        {
            for (int i = 0; i < 112; i++)
            {
                cbRecurrency.Items.Add(i);
                cbRecurrencyFormation.Items.Add(i);

            }
        }

        private void SaveMatriceDetails(object sender, EventArgs e)
        {
            string MatriceName = String.Empty;
            if (MatriceSelected != null)
            {
                dbMatriceFormation.SaveMatriceFormation(MatriceSelected, Convert.ToInt32(cbRecurrency.Text));
                MatriceName = MatriceSelected.Matrice_Description;
            }
            else
            {
                if (cbRecurrency.Text != "")
                {
                    dbMatrice.AddNewMatrice(tbTrajetName.Text, Convert.ToInt32(cbRecurrency.Text));
                    MatriceName = tbTrajetName.Text;
                }
                else
                {
                    cbRecurrency.CausesValidation = true;
                }
            }
            CurrentMatriceName = MatriceName;

            btnRefresh.PerformClick();

        }

        #endregion

        private void treeW_Provider_MouseClick(object sender, MouseEventArgs e)
        {
            mySelectedNode = treeW_Routes.GetNodeAt(e.X, e.Y);
            treeW_Routes.SelectedNode = mySelectedNode;

            if (mySelectedNode != null && treeW_Routes.SelectedNode.Level == 1) // Click droit sur Matrice
            {
                if (mySelectedNode.Text != "Trajets")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Modifier le nom du trajet", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Ajouter une formation au trajet", AddFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer le trajet à un utilisateur", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer le trajet à un groupe d'utilisateur", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Supprimer le trajet de formation", RemoveAllMatrice));



                        m.Show(treeW_Routes, new Point(e.X, e.Y));
                    }
                    else
                    {
                        //treeW_Provider.LabelEdit = true;

                        //treeW_Provider.SelectedNode.BeginEdit();
                    }
                }
                //mySelectedNode.BeginEdit();
            }
            else
            {
                if (mySelectedNode != null && treeW_Routes.SelectedNode.Level == 2) // Click droit sur formation
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Fiche de la formation", GoToFormationCard));
                        m.MenuItems.Add(new MenuItem("Retirer la formation du trajets", RemoveFormationFromMatrice));


                        m.Show(treeW_Routes, new Point(e.X, e.Y));
                    }
                    picAddMatrice.Enabled = true;
                }
            }
        }

        private void RemoveAllMatrice(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Etes-vous sûr de vouloir supprimer le trajets de formations?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                dbMatriceFormation.RemoveAllMatriceForamtion(mySelectedNode.Nodes, mySelectedNode.Text);
                RefreshTreeView();
            }
            else
            { }

        }

        private void GoToFormationCard(object sender, EventArgs e)
        {
            object[] arr = { mySelectedNode.Name, null };

            PointerFormation.DynamicInvoke(mySelectedNode.Name);
            //MainWindowPointerMenuBtnAgent.DynamicInvoke(arr);
        }

        private void RemoveFormationFromMatrice(object sender, EventArgs e)
        {
            dbMatriceFormation.RemoveFormationFromTrajet(mySelectedNode.Name, mySelectedNode.Parent.Text);
            RefreshTreeView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllMatrice();
            TreeNode currentSelectNode = treeW_Routes.Nodes[0].Nodes.Find(CurrentMatriceName, true).FirstOrDefault();
        }

        public void RefreshTreeView()
        {
            LoadAllMatrice();
        }

        private void LoadFiltercbFormation()
        {
            cbFilterFormation.DataSource = db.LoadAllEducation_Formations();
            cbFilterFormation.DisplayMember = "Formation_ShortTitle";
            cbFilterFormation.Text = "";
            cbFilterFormation.SelectedIndex = -1;
        }

        private void LoadFiltercbMatrice()
        {
            cbFilterMatrice.DataSource = dbMatrice.LoadAllMatrice();
            cbFilterMatrice.DisplayMember = "Matrice_Description";
            cbFilterMatrice.Text = "";
            cbFilterMatrice.SelectedIndex = -1;

        }

        public bool SearchRecursive(TreeNodeCollection nodes, string textboxText)
        {

            foreach (TreeNode node in nodes)
            {
                if (node.Text.ToUpper().Contains(textboxText.ToUpper()))
                {
                    //treeW_Routes.SelectedNode = node;
                    node.BackColor = Color.Yellow;
                    node.Parent.Expand();
                }
                else
                {
                    node.BackColor = Color.LightSkyBlue;

                }
                SearchRecursive(node.Nodes, textboxText);
                //    return true;
            }
            return true;
        }

        private void cbFilterMatrice_KeyDown(object sender, KeyEventArgs e)
        {
            cbFilterFormation.Text = "";

            if (e.KeyValue == 13)
            {
                foreach (TreeNode node in treeW_Routes.Nodes)
                {
                    if (node.Text.ToUpper().Contains(cbFilterMatrice.Text.ToUpper()))
                    {
                        //treeW_Routes.SelectedNode = node;
                        node.BackColor = Color.Yellow;

                    }
                    else
                    {
                        node.BackColor = Color.LightSkyBlue;

                    }
                    //if (SearchRecursive(node.Nodes, textBox1.Text))
                    //    return true;
                    SearchRecursive(node.Nodes, cbFilterMatrice.Text);
                }
            }
        }

        private void cbFilterFormation_KeyDown(object sender, KeyEventArgs e)
        {
            cbFilterMatrice.Text = "";
            if (e.KeyValue == 13)
            {
                foreach (TreeNode node in treeW_Routes.Nodes)
                {
                    if (node.Text.ToUpper().Contains(cbFilterFormation.Text.ToUpper()))
                    {
                        //treeW_Routes.SelectedNode = node;
                        node.BackColor = Color.Yellow;
                    }
                    else
                    {
                        node.BackColor = Color.LightSkyBlue;

                    }
                    //if (SearchRecursive(node.Nodes, textBox1.Text))
                    //    return true;
                    SearchRecursive(node.Nodes, cbFilterFormation.Text);
                }
            }
        }

        private void SaveFormationRecurrency(object sender, EventArgs e)
        {
            dbMatriceFormation.SaveCurrencyOfFormation(mySelectedNode.Name, mySelectedNode.Parent.Text, Convert.ToInt32(cbRecurrencyFormation.Text));
            AutoClosingMessageBox.Show("Récurrence de la formation enregistrée.", "Info", 2000, MessageBoxIcon.Information);
        }

        private void SaveRecurrencyMatrice(object sender, EventArgs e)
        {
            if (cbRecurrency.Text != "")
            {
                MatriceSelected = dbMatrice.SaveDetailsRoute(mySelectedNode.Text, Convert.ToInt32(cbRecurrency.Text), tbTrajetName.Text);
                treeW_Routes.SelectedNode.Text = MatriceSelected.Matrice_Description;
            }

            else
                MessageBox.Show("Spécifiez la récurrence du trajet de formation");

        }

        private void LoadComboAgent()
        {
            if (MatriceSelected != null)
            {
                tbTrajetName.Text = MatriceSelected.Matrice_Description;
                comboAgent.DataSource = dbMatrice.LoadAllAgentsExcepted(MatriceSelected);
                comboAgent.DisplayMember = "Agent_FullName";

                List<Education_Matrice_Agent> listAgentAlreadyAssignedToMatrice = dbAgentMatrice.LoadAllTrajetAgent(MatriceSelected);
                LoadDatagridAgentRoute();
                for (int i = 0; i < listAgentAlreadyAssignedToMatrice.Count; i++)
                {
                    if (listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent != null)
                    {
                        Education_Agent agent = dbAgent.LoadSingleUser(listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent);
                        int index = comboAgent.FindString(agent.Agent_FullName);

                        Font font = new System.Drawing.Font(comboAgent.Font, FontStyle.Bold);
                        SolidBrush brush = new SolidBrush(comboAgent.ForeColor);
                        this.comboAgent.DrawItem += new DrawItemEventHandler(comboAgent_DrawItem);

                    }
                }
            }
        }

        private void LoadComboGrpAgent()
        {
            if (MatriceSelected != null)
            {
                comboGrpAgent.DataSource = dbMatrice.LoadAllGrpAgentsExcepted(MatriceSelected);
                comboGrpAgent.DisplayMember = "GroupLearner_Name";

                //List<Education_Matrice_Agent> listAgentAlreadyAssignedToMatrice = dbAgentMatrice.LoadAllTrajetAgent(MatriceSelected);
                //LoadDatagridAgentRoute();
                //for (int i = 0; i < listAgentAlreadyAssignedToMatrice.Count; i++)
                //{
                //    if (listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent != null)
                //    {
                //        Education_Agent agent = dbAgent.LoadSingleUser(listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent);
                //        int index = comboAgent.FindString(agent.Agent_FullName);

                //        Font font = new System.Drawing.Font(comboAgent.Font, FontStyle.Bold);
                //        SolidBrush brush = new SolidBrush(comboAgent.ForeColor);
                //        this.comboAgent.DrawItem += new DrawItemEventHandler(comboAgent_DrawItem);

                //    }
                //}
            }
        }

        private void LoadDatagridAgentRoute()
        {
            List<Education_Matrice_Agent> listAgentAlreadyAssignedToMatrice = dbAgentMatrice.LoadAllAgentOfTheRoute(MatriceSelected);
            List<Education_Matrice_Agent> distinctList = new List<Education_Matrice_Agent>();
            foreach (Education_Matrice_Agent agent in listAgentAlreadyAssignedToMatrice)
            {
                var existAlready = distinctList.Where(x => x.MatriceAgent_Agent == agent.MatriceAgent_Agent).FirstOrDefault();
                if (existAlready == null)
                    distinctList.Add(agent);
            }

            adDG_AgentsRoute.DataSource = GetDataSource(distinctList);

        }

        private object GetDataSource(List<Education_Matrice_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgent(o.Education_Agent)
            {
                Agent_Matricule = o.Education_Agent.Agent_Matricule,
                Agent_Fullname = o.Education_Agent.Agent_FullName,
                Agent_FirstName = o.Education_Agent.Agent_FirstName,
                Agent_Name = o.Education_Agent.Agent_Name,

                Function_Name = o.Education_Agent.Agent_Function == null ? null : dbEntities.Education_Function
                .Where(x => x.Function_Id == o.Education_Agent.Agent_Function).FirstOrDefault().Function_Name,// If (o.Function == null) { null } else {o.Function.Function_Name}
                //Agent_Admin = o.Agent_Admin,
                //Agent_Responsable = o.Agent_LineManager == null ? null : dbEntities.Education_Agent.Where(x => x.Agent_Id == o.Agent_LineManager).FirstOrDefault().Agent_FullName,
                //Agent_InRoute = o.Agent_InRoute,
                //Agent_IsWorkManager = o.Agent_IsWorksManager,
                //Agent_DateSeniority = o.Agent_DateSeniority,
                //Agent_DateOfEntry = o.Agent_DateOfEntry,
                //Agent_DateFunction = o.Agent_DateFunction,
                //Agent_Habilitation = o.Education_Habilitation == null ? null : o.Education_Habilitation.Habilitation_Name,
                //Agent_Status = o.Education_AgentStatus == null ? null : o.Education_AgentStatus.AgentStatus_Name,
                //Agent_Etat = o.Agent_Etat
            }).ToList();
            return dataSource;
        }

        private void AssignRouteToAgent(object sender, EventArgs e)
        {
            Education_Agent agentSelected = (Education_Agent)comboAgent.SelectedItem;
            Education_Matrice_Agent agentMatrice = dbAgentMatrice.LoadSingleTrajetAgent(MatriceSelected, agentSelected);

            if (agentMatrice == null)
            {
                dbAgentMatrice.AssignAgentToRoute(MatriceSelected, agentSelected);
                MessageBox.Show("Trajet assigné à l'agent " + agentSelected.Agent_FullName);
                LoadDatagridAgentRoute();
            }
            else
            {

            }
        }

        private void btnGrpAssignAgent_Click(object sender, EventArgs e)
        {
            Education_GroupLearner agentGrpSelected = (Education_GroupLearner)comboGrpAgent.SelectedItem;
            //Education_Matrice_Agent agenGrptMatrice = dbAgentMatrice.LoadSingleTrajetGrpAgent(MatriceSelected, agentGrpSelected);

            if (agentGrpSelected != null)
            {
                dbAgentMatrice.AssignGrpAgentToRoute(MatriceSelected, agentGrpSelected);
                foreach (var agent in agentGrpSelected.Education_GroupLearner_Agent)
                {
                    dbAgentMatrice.AssignAgentToRoute(MatriceSelected, agent.Education_Agent);

                }
                MessageBox.Show("Trajet assigné au groupe :  " + agentGrpSelected.GroupLearner_Name);
                LoadDatagridAgentRoute();
            }
        }

        private void comboAgent_DrawItem(object sender, DrawItemEventArgs e)
        {
            List<Education_Matrice_Agent> listAgentAlreadyAssignedToMatrice = dbAgentMatrice.LoadAllTrajetAgent(MatriceSelected);
            for (int i = 0; i < listAgentAlreadyAssignedToMatrice.Count; i++)
            {
                if (listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent != null)
                {
                    Education_Agent agent = dbAgent.LoadSingleUser(listAgentAlreadyAssignedToMatrice[i].MatriceAgent_Agent);

                    int index = comboAgent.FindString(agent.Agent_FullName);

                    Font font = new System.Drawing.Font(e.Font, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(comboAgent.ForeColor);
                    e.Graphics.DrawString(comboAgent.Items[index].ToString(), font, SystemBrushes.ControlText,
                                    e.Bounds.X, e.Bounds.Y);
                }
            }


        }

        private void adDG_AgentsRoute_MouseClick(object sender, MouseEventArgs e)
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

                    m.Show(adDG_AgentsRoute, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowAgentRouteCard(object sender, EventArgs e)
        {
            this.tabControlRoutes.SelectedIndex = 1;
            if (listPanelRoutesFormation.Count > 0)
            {
                foreach (Panel itemPanel in listPanelRoutesFormation)
                {
                    itemPanel.Dispose();
                }
                listPanelRoutesFormation.Clear();
            }
            liscontrolOfPanel = this.panelFormationM.Controls;

            matriceAgentList = dbAgentMatrice.LoadAllTrajetSingleAgent(MatriceSelected, UserIDSelected);

            lblAgentM.Text = matriceAgentList[0].Education_Agent.Agent_FullName;
            lblMatriceNameM.Text = matriceAgentList[0].Education_Matrice_Formation.Education_Matrice.Matrice_Description;
            lblRecurrencyM.Text = "Récurrence : " + matriceAgentList[0].Education_Matrice_Formation.Education_Matrice.Matrice_Recurrency + " semaines";

            for (int i = 0; i < matriceAgentList.Count; i++)
            {
                //lblFormationM.Text =  ListFormationMatriceSelected[i].Education_Formation.Formation_ShortTitle;
                InsertCopyPanelFormation(i + 1, matriceAgentList[i]);
            }

            panelFormationM.Dispose();
            CreateButtonSavingAgent();
        }

        private void InsertCopyPanelFormation(int index, Education_Matrice_Agent Matriceformation)
        {
            Label newlblFormationName = new Label();
            newlblFormationName.Paint += new PaintEventHandler(this.lblFormationName_Paint);
            newlblFormationName.Name = "lblFormationM_" + index;
            newlblFormationName.Text = Matriceformation.Education_Matrice_Formation.Education_Formation.Formation_ShortTitle;
            newlblFormationName.Size = lblFormationM.Size;
            int yLAbelAxisCalculated = this.lblFormationM.Location.Y + (this.lblFormationM.Size.Height - 15);
            newlblFormationName.Location = new Point(this.lblFormationM.Location.X, yLAbelAxisCalculated);
            newlblFormationName.BackColor = Color.LightSkyBlue;
            //newlblFormationName.ForeColor = Color.FromArgb(0, 115, 204);
            newlblFormationName.Font = lblFormationM.Font;


            //Radio Button
            RadioButton newRbDone = new RadioButton();
            newRbDone.CheckedChanged += new EventHandler(this.RbDoneCheckedChanged);

            newRbDone.Name = "rbDone_" + index;
            newRbDone.Text = "Suivi";
            newRbDone.Size = rbDone.Size;
            newRbDone.Font = lblFormationM.Font;
            //newRbDone.ForeColor = Color.FromArgb(0, 115, 204);
            int yRadioBtnAxisCalculated = this.rbDone.Location.Y + (this.rbDone.Size.Height - 15);
            newRbDone.Location = new Point(this.rbDone.Location.X, yRadioBtnAxisCalculated);

            RadioButton newRbNotDone = new RadioButton();
            newRbNotDone.CheckedChanged += new EventHandler(this.RbNotDoneCheckedChanged);
            newRbNotDone.Name = "rbNoteDone_" + index;
            newRbNotDone.Text = "Non-suivi";
            newRbNotDone.Size = rbNotDone.Size;
            newRbNotDone.Font = lblFormationM.Font;
            //newRbNotDone.ForeColor = Color.FromArgb(0, 115, 204);
            int yRadioNotDOneBtnAxisCalculated = this.rbNotDone.Location.Y + (this.rbNotDone.Size.Height - 15);
            newRbNotDone.Location = new Point(this.rbNotDone.Location.X, yRadioNotDOneBtnAxisCalculated);

            if (Matriceformation.MatriceAgent_IsAttented == true)
                newRbDone.Checked = true;
            else
                newRbNotDone.Checked = true;

            //DATE
            DateTimePicker newdatePFormationM = new DateTimePicker();
            newdatePFormationM.Paint += new PaintEventHandler(this.lblFormationName_Paint);
            newdatePFormationM.Name = "datePFormationM_" + index;
            newdatePFormationM.Size = datePFormationM.Size;
            newdatePFormationM.Font = datePFormationM.Font;
            newdatePFormationM.CustomFormat = "dd MMM yyyy";
            newdatePFormationM.Format = DateTimePickerFormat.Custom;
            //newdatePFormationM.ForeColor = Color.FromArgb(0, 115, 204);
            newdatePFormationM.ValueChanged += this.datePFormationM_ValueChanged;
            int yDateAxisCalculated = this.datePFormationM.Location.Y + (this.datePFormationM.Size.Height - 15);
            newdatePFormationM.Location = new Point(this.datePFormationM.Location.X, yDateAxisCalculated);
            if (Matriceformation.MatriceAgent_DateFormationAttented != null)
                newdatePFormationM.Value = (DateTime)Matriceformation.MatriceAgent_DateFormationAttented;
            else
            {
                newdatePFormationM.CustomFormat = " ";
                newdatePFormationM.Value = Convert.ToDateTime(DateTime.Now);
            }

            //cb Equivalence


            CheckBox newCheckBoxEquivalence = new CheckBox();
            newCheckBoxEquivalence.Paint += new PaintEventHandler(this.lblFormationName_Paint);
            newCheckBoxEquivalence.Name = "newCheckBoxEquivalence_" + index;
            newCheckBoxEquivalence.Visible = Matriceformation.MatriceAgent_HasEquivalence == null ? false : true;
            newCheckBoxEquivalence.Size = cbEquivalence.Size; newCheckBoxEquivalence.Text = "Equivalence";
            newCheckBoxEquivalence.Font = cbEquivalence.Font;
            //newCheckBoxEquivalence.ForeColor = Color.FromArgb(0, 115, 204);
            newCheckBoxEquivalence.Checked = Matriceformation.MatriceAgent_HasEquivalence == null ? false : true;
            newCheckBoxEquivalence.CheckedChanged += this.cbEquivalence_CheckedChanged;
            int yCbAxisCalculated = this.cbEquivalence.Location.Y + (this.cbEquivalence.Size.Height - 15);
            newCheckBoxEquivalence.Location = new Point(this.cbEquivalence.Location.X, yDateAxisCalculated);

            // Commencs Equivalence

            //TextBox newtbCommentEquivalence = new TextBox();
            //newtbCommentEquivalence.Paint += new PaintEventHandler(this.PainttbEquivalence);
            //newtbCommentEquivalence.Name = "newtbCommentEquivalence_" + index;
            //newtbCommentEquivalence.Size = new Size(126, 20);
            //newtbCommentEquivalence.Text = "Comments";
            //newtbCommentEquivalence.ResumeLayout();
            //newtbCommentEquivalence.Font = tbEquivalence.Font;
            //newtbCommentEquivalence.BorderStyle = BorderStyle.FixedSingle;
            //newtbCommentEquivalence.BackColor = Color.White;
            //newtbCommentEquivalence.ForeColor = Color.FromArgb(0, 115, 204);
            //int yTbAxisCalculated = this.tbEquivalence.Location.Y + (this.tbEquivalence.Size.Height - 15);
            //newtbCommentEquivalence.Location = new Point(this.tbEquivalence.Location.X, yTbAxisCalculated);

            // Commencs Equivalence

            PictureBox newPicEquivalence = new PictureBox();
            newPicEquivalence.Paint += new PaintEventHandler(this.PainttbEquivalence);
            newPicEquivalence.Click += new EventHandler(this.ClickPicBoxEquivalence);
            newPicEquivalence.Name = "newPicEquivalence_" + index;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(newPicEquivalence, "Afficher les informations d'équivalence");
            newPicEquivalence.Visible = false;
            newPicEquivalence.Image = Module_Education.Properties.Resources.baseline_visibility_black_18dp;
            newPicEquivalence.SizeMode = PictureBoxSizeMode.Zoom;
            newPicEquivalence.Size = picViewEquivalence.Size;
            int yTbAxisCalculated = this.picViewEquivalence.Location.Y + (this.picViewEquivalence.Size.Height - 15);
            newPicEquivalence.Location = new Point(this.picViewEquivalence.Location.X, yTbAxisCalculated);

            Panel newPanel = new Panel();
            newPanel.Paint += new PaintEventHandler(this.panel_Paint);

            if (index % 2 == 0)
                newPanel.BackColor = Color.LightSkyBlue;
            else
                newPanel.BackColor = Color.LightSkyBlue;

            newPanel.Size = this.panelFormationM.Size;
            newPanel.Name = "panelFormationM_" + index;
            int yAxisCalculated = (this.panelFormationM.Location.Y - 35) + (this.panelFormationM.Size.Height * index);
            newPanel.Location = new Point(this.panelFormationM.Location.X, yAxisCalculated);

            newPanel.Controls.Add(newRbDone);
            newPanel.Controls.Add(newRbNotDone);
            newPanel.Controls.Add(newCheckBoxEquivalence);

            newPanel.Controls.Add(newdatePFormationM);
            newPanel.Controls.Add(newPicEquivalence);

            newPanel.Controls.Add(newlblFormationName);
            listPanelRoutesFormation.Add(newPanel);
            this.tabcontrolTrajet.Controls.Add(newPanel);
        }

        private void ClickPicBoxEquivalence(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            string[] spiltCbName = picBox.Name.Split('_').ToArray();
            for (int i = 1; i < matriceAgentList.Count + 1; i++)
            {
                if (i.ToString() == spiltCbName[1])
                {
                    SelectedMatriceAgent = matriceAgentList[i - 1];
                }
            }
            FrmEquivalenceComment frmEquivalenceComment = new FrmEquivalenceComment(SelectedMatriceAgent);
            frmEquivalenceComment.StartPosition = FormStartPosition.Manual;
            frmEquivalenceComment.Location = picBox.Location;
            frmEquivalenceComment.ShowDialog();
        }

        private void PainttbEquivalence(object sender, PaintEventArgs e)
        {
        }

        private void RbNotDoneCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string[] spiltRbName = rb.Name.Split('_').ToArray();

            for (int i = 1; i < matriceAgentList.Count - 1; i++)
            {
                if (i.ToString() == spiltRbName[1])
                {
                    matriceAgentList[i - 1].MatriceAgent_IsAttented = false;
                }
            }

            Panel currentPanel = listPanelRoutesFormation.Where(x => x.Name == "panelFormationM_" + spiltRbName[1]).FirstOrDefault();
            if (currentPanel != null)
            {
                foreach (Control ctrl in currentPanel.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        if (rb.Checked)
                        {
                            cbEquivalence = (CheckBox)ctrl;
                            cbEquivalence.Visible = true;
                        }
                    }
                }
            }

        }

        private void RbDoneCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string[] spiltRbName = rb.Name.Split('_').ToArray();
            for (int i = 1; i < matriceAgentList.Count - 1; i++)
            {
                if (i.ToString() == spiltRbName[1])
                {
                    matriceAgentList[i - 1].MatriceAgent_IsAttented = true;
                }
            }
            Panel currentPanel = listPanelRoutesFormation.Where(x => x.Name == "panelFormationM_" + spiltRbName[1]).FirstOrDefault();
            if (currentPanel != null)
            {
                foreach (Control ctrl in currentPanel.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        if (rb.Checked)
                        {
                            cbEquivalence = (CheckBox)ctrl;
                            cbEquivalence.Visible = false;
                            cbEquivalence.Checked = false;
                        }
                        else
                        {
                            

                        }
                    }
                    if (ctrl is PictureBox)
                    {
                        if (rb.Checked)
                        {
                            ctrl.Visible = false;
                        }
                    }
                }

            }
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

            ButtonSaveAgent.Click += new System.EventHandler(this.SaveRouteAgent);

            //ButtonSaveAgent.Padding = new Padding(6);
            ButtonSaveAgent.Font = new Font("Arial", 18);
            ButtonSaveAgent.ForeColor = Color.LightGray;

            this.tabcontrolTrajet.Controls[1].Controls.Add(ButtonSaveAgent);

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
            this.tabcontrolTrajet.Controls[1].Controls.Add(ButtonCancelModificationAgent);

        }

        private void SaveRouteAgent(object sender, EventArgs e)
        {
        }

        private void lblFormationName_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tbTrajetName_Enter(object sender, EventArgs e)
        {
            TextBox tb = this.tbTrajetName;
            tb.Multiline = true;

            //tb.BorderStyle = BorderStysle.None;
            Pen p = new Pen(Color.Red);
            Graphics g = tb.CreateGraphics();
            int variance = 3;
            g.DrawRectangle(p, new Rectangle(tb.Location.X - variance, tb.Location.Y - variance, tb.Width + variance, tb.Height + variance));
            ControlPaint.DrawBorder(g, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void datePFormationM_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker datePicker = (DateTimePicker)sender;
            if (datePicker.CustomFormat != "dd MMM yyyy")
                datePicker.CustomFormat = "dd MMM yyyy";

            string[] spiltRbName = datePicker.Name.Split('_').ToArray();
            for (int i = 1; i < matriceAgentList.Count + 1; i++)
            {
                if (i.ToString() == spiltRbName[1])
                {
                    DateTime date = datePicker.Value;
                    string format = "yyyy-MM-dd";
                    matriceAgentList[i - 1].MatriceAgent_DateFormationAttented = Convert.ToDateTime(date.ToString(format));
                }
            }


        }

        private void btnSaveProgressRoute_Click(object sender, EventArgs e)
        {
            matriceAgentList = routeAgentRepository.SaveRouteAgentProgress(matriceAgentList);
        }

        private void rbDone_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timerClick(object sender, EventArgs e)
        {
            PanelDetailsMatrice.BackColor = Color.FromArgb(0, 115, 225);
            timer1.Start();
            for (int i = 225; i > 204; i--)
            {

                PanelDetailsMatrice.BackColor = Color.FromArgb(0, 115, i);

                //await Task.Delay(1000);
                //PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.FromArgb(0, 115, 204) ? Color.LightSkyBlue : Color.FromArgb(0, 115, 204);

                //await Task.Delay(1000);
                //PanelDetailsMatrice.BackColor = PanelDetailsMatrice.BackColor == Color.LightSkyBlue ? Color.LightSkyBlue : Color.LightSkyBlue;
            }
        }

        private void cbEquivalence_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            PictureBox picBoxCurrent = new PictureBox(); 

            string[] spiltCbName = cb.Name.Split('_').ToArray();
            Panel currentPanel = listPanelRoutesFormation.Where(x => x.Name == "panelFormationM_" + spiltCbName[1]).FirstOrDefault();
            foreach (Control ctrl in currentPanel.Controls)
            {
                if (ctrl is PictureBox)
                {
                    picBoxCurrent = (PictureBox)ctrl;
                }
            }

            for (int i = 1; i < matriceAgentList.Count + 1; i++)
            {
                if (i.ToString() == spiltCbName[1])
                {
                    matriceAgentList[i - 1].MatriceAgent_HasEquivalence = cb.Checked;
                }
            }
            if (cb.Checked == true)
            {
                picBoxCurrent.Visible = true;
            }
            else
            {
                picBoxCurrent.Visible = false;

            }

        }

        private void picViewProvider_Click(object sender, EventArgs e)
        {

        }
    }
}
