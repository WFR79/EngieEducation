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
        private AgentDataAccess dbAgent = new AgentDataAccess();
        private AgentMatriceRepository dbAgentMatrice = new AgentMatriceRepository();
        private List<Education_Matrice> listMatrice;
        public Education_Matrice MatriceSelected;
        public Delegate PointerFormation;

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        public static List<Education_Matrice_Formation> listMatriceFormationSelected;

        public UC_MatriceFormations()
        {
            InitializeComponent();
            LoadAllMatrice();
            LoadFiltercbFormation();
            LoadFiltercbMatrice();
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
            var selectedNode = treeW_Routes.SelectedNode;
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
                }
            }

            LoadComboAgent();

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
        }

        private void LoadFiltercbMatrice()
        {
            cbFilterMatrice.DataSource = dbMatrice.LoadAllMatrice();
            cbFilterMatrice.DisplayMember = "Matrice_Description";
        }

        public bool SearchRecursive(TreeNodeCollection nodes, string textboxText)
        {

            foreach (TreeNode node in nodes)
            {
                if (node.Text.ToUpper().Contains(textboxText.ToUpper()))
                {
                    treeW_Routes.SelectedNode = node;
                    node.BackColor = Color.Yellow;
                }
                else
                {
                    node.BackColor = Color.WhiteSmoke;

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
                        treeW_Routes.SelectedNode = node;
                        node.BackColor = Color.Yellow;
                    }
                    else
                    {
                        node.BackColor = Color.WhiteSmoke;

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
                        treeW_Routes.SelectedNode = node;
                        node.BackColor = Color.Yellow;
                    }
                    else
                    {
                        node.BackColor = Color.WhiteSmoke;

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
                comboAgent.DataSource = dbAgent.LoadAllAgents();
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
        }

        private void LoadDatagridAgentRoute()
        {
            List<Education_Matrice_Agent> listAgentAlreadyAssignedToMatrice = dbAgentMatrice.LoadAllTrajetAgent(MatriceSelected);

            adDG_AgentsRoute.DataSource = GetDataSource(listAgentAlreadyAssignedToMatrice);

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
            DataGridView dgv = (DataGridView)sender;
            if (e.Button == MouseButtons.Right)
            {
                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Afficher le statut du trajet de formation de l'agent", ShowAgentRouteCard));



                m.Show(adDG_AgentsRoute, new Point(e.X, e.Y));
            }
        }

        private void ShowAgentRouteCard(object sender, EventArgs e)
        {
            this.tabControlRoutes.SelectedIndex = 1;
        }
    }
}
