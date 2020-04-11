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

namespace Module_Education.Forms.UserControls
{
    public partial class UC_MatriceFormations : UserControl
    {

        private static UC_MatriceFormations _instance;
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
        private RoutesFormationRepository dbMatrice = new RoutesFormationRepository();
        private InRouteFormationRepository dbMatriceFormation = new InRouteFormationRepository();

        private List<Education_Matrice> listMatrice;
        public Education_Matrice MatriceSelected;



        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        public static List<Education_Matrice_Formation> listMatriceFormationSelected;

        public UC_MatriceFormations()
        {
            InitializeComponent();
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

        #region
        private void picAddMatrice_Click(object sender, EventArgs e)
        {
            treeW_Provider.BeginUpdate();
            //treeView2.Nodes.Clear();
            string yourParentNode;
            yourParentNode = "";

            treeW_Provider.SelectedNode = mySelectedNode;


            TreeNode tn1 = new TreeNode();
            tn1.Text = "Entrez le nom de la nouvelle matrices";

            if (mySelectedNode.Text == "Trajets")
                treeW_Provider.Nodes[0].Nodes.Add(tn1); // Add node1.
            else
            {

            }
            treeW_Provider.SelectedNode.Expand();
            //treeW_Provider.Nodes.Add(yourParentNode);
            //treeW_Provider.SelectedNode
            treeW_Provider.EndUpdate();
        }

        private void treeW_Provider_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            mySelectedNode = treeW_Provider.GetNodeAt(e.X, e.Y);
            treeW_Provider.SelectedNode = mySelectedNode;
            if (mySelectedNode != null && treeW_Provider.SelectedNode.Index < 2)
            {
                if (mySelectedNode.Text != "Trajets")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Modifier le nom de la matrice", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Ajouter une formation à la matrice", AddFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer la matrice à un utilisateur", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer la matrice à un groupe d'utilisateur", EditFormationToMatrice));


                        m.Show(treeW_Provider, new Point(e.X, e.Y));
                    }
                    else
                    {
                        //treeW_Provider.LabelEdit = true;

                        //treeW_Provider.SelectedNode.BeginEdit();
                    }
                }
                //mySelectedNode.BeginEdit();
            }
            picAddMatrice.Enabled = true;
        }

        private void EditFormationToMatrice(object sender, EventArgs e)
        {
            treeW_Provider.LabelEdit = true;

            treeW_Provider.SelectedNode.BeginEdit();
        }

        private void AddFormationToMatrice(object sender, EventArgs e)
        {
            //lFormationToAddToMatrice.Clear();
            listMatriceFormationSelected = dbMatriceFormation.LoadMatriceFormation(treeW_Provider.SelectedNode.Text);

            FrmFormation frmFormation = new FrmFormation();
            frmFormation.ShowDialog();
            if (lFormationToAddToMatrice != null)
            {
                if (lFormationToAddToMatrice.Count > 0)
                {
                    foreach (var formation in lFormationToAddToMatrice)
                        treeW_Provider.SelectedNode.Nodes.Add(formation.Formation_ShortTitle); // Add node1.

                }
            }
            treeW_Provider.SelectedNode.Expand();
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

        private void LoadAllMatrice()
        {
            treeW_Provider.Nodes[0].Nodes.Clear();

            LoadComboboxRecurrency();
            listMatrice = dbMatrice.LoadAllMatrice();
            treeW_Provider.SelectedNode = treeW_Provider.Nodes[0];
            for (int i = 0; i < listMatrice.Count; i++)
            {
                treeW_Provider.SelectedNode.Nodes.Add(listMatrice[i].Matrice_Description); // Add node1.
                var listMatriceFormation = dbMatriceFormation.LoadMatriceFormation(listMatrice[i].Matrice_Description);

                foreach (var formation in listMatriceFormation)
                {
                    treeW_Provider.SelectedNode.Nodes[i].Nodes.Add(formation.Education_Formation.Formation_ShortTitle);
                }
            }
            treeW_Provider.SelectedNode.Expand();
        }


        private void SaveRoutesFormation(object sender, EventArgs e)
        {
            List<Education_Matrice> newListeMatrice = new List<Education_Matrice>();
            TreeNodeCollection coll = treeW_Provider.Nodes;
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
                            else { 
                            
                            
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
            var selectedNode = treeW_Provider.SelectedNode;
            lblDetailsMatrice.Text = "Details de " + selectedNode.Text;
            MatriceSelected = dbEntities.Education_Matrice.Where(x => x.Matrice_Description == treeW_Provider.SelectedNode.Text).FirstOrDefault();

        }

        private void LoadComboboxRecurrency()
        {
            for (int i = 0; i < 112; i++)
                cbRecurrency.Items.Add(i);
        }


        private void SaveMatriceDetails(object sender, EventArgs e)
        {
            dbMatriceFormation.SaveMatriceFormation(MatriceSelected, Convert.ToInt32(cbRecurrency.Text));
        }

        #endregion

        private void treeW_Provider_MouseClick(object sender, MouseEventArgs e)
        {
            mySelectedNode = treeW_Provider.GetNodeAt(e.X, e.Y);
            treeW_Provider.SelectedNode = mySelectedNode;
            if (mySelectedNode != null && treeW_Provider.SelectedNode.Index < 2)
            {
                if (mySelectedNode.Text != "Trajets")
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Modifier le nom de la matrice", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Ajouter une formation à la matrice", AddFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer la matrice à un utilisateur", EditFormationToMatrice));
                        m.MenuItems.Add(new MenuItem("Attribuer la matrice à un groupe d'utilisateur", EditFormationToMatrice));


                        m.Show(treeW_Provider, new Point(e.X, e.Y));
                    }
                    else
                    {
                        //treeW_Provider.LabelEdit = true;

                        //treeW_Provider.SelectedNode.BeginEdit();
                    }
                }
                //mySelectedNode.BeginEdit();
            }
            picAddMatrice.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllMatrice();
        }

        
    }
}
