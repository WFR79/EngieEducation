using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using Module_Education.Models;
using Module_Education.Helper;
using Module_Education.Classes;
using Module_Education.DataAccessLayer;

namespace Module_Education
{
    public partial class UC_Provider : UserControl
    {
        #region Declarations
        IPagedList<Education_Provider> listProvidersPaged;
        int pageSize = 50;

        private static UC_Provider _instance;
        private Education_Provider CurrentProvider = new Education_Provider();

        public Education_Provider providerSelected { get; set; }
        public Education_FormationProvider formationProviderSelected { get; private set; }
        private FormationProviderRepository db = new FormationProviderRepository();
        //private FormationProviderRepository db = new FormationProviderRepository();

        public CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();




        public Delegate PointerProvider;
        public Delegate MainWindowPointerMenuBtnProvider;
        public event providerEditLoad ReceiverLoadEditProvider;
        public event providerEditLoad ReceiverLoadEditProviderFromFormation;

        public delegate void providerEditLoad(long FormationProviderID);

        #endregion

        public UC_Provider()
        {
            InitializeComponent();
            LoadDataGridProdiver();
            ReceiverLoadEditProviderFromFormation += new providerEditLoad(LoadProviderCard);
            UCEducation_Formation.Instance.PointerProvider = ReceiverLoadEditProviderFromFormation;
            //InitEventsReceiver();
        }

        public void LoadComboboxs()
        {
            //Equipe
            comboPersonneContact.DataSource = db.LoadAllFormationProvider(providerSelected);
            comboPersonneContact.DisplayMember = "FormationProvider_ContactName";

        }


        public static UC_Provider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_Provider();

                }
                return _instance;
            }
        }

        private void InitEventsReceiver()
        {
            if (ReceiverLoadEditProvider == null)
            {
                ReceiverLoadEditProvider += new providerEditLoad(LoadProviderCard);
                UC_Provider.Instance.PointerProvider = ReceiverLoadEditProvider;



            }
        }

        public void LoadProviderCard(long FormationProvider)
        {
            LoadComboboxs();
            DeleteButtonSavingAgent();
            TabPage page = (TabPage)this.tabControlProvider.Controls[1];
            this.tabControlProvider.SelectedTab = page;

            this.EnableTab(page, true);

            Education_FormationProvider providerRecord = db.LoadFormationProvider(providerSelected);
            if (providerRecord != null)
            {
                ProviderRecord_FillLabels(providerRecord);
                //UserRecord_FillLabelsActif(userRecord);

                //UserRecord_FillMatricule(userRecord);
                //UserRecord_FillAdmin(userRecord);
                //UserRecord_SelectEquipe(userRecord);
                //UserRecord_PickDateOfEntry(userRecord);
                //UserRecord_PickUser_DateSeniority(userRecord);
                //UserRecord_PickDateFunction(userRecord);
                //UserRecord_FillRemarks(userRecord);
                UserRecord_SelectContactName(providerRecord);
                //UserRecord_SelectStatut(userRecord);
                //UserRecord_SelectFunction(userRecord);

                //UserRecord_SelectRoleEPI(userRecord);
                //UserRecord_SelectRoleAstreinte(userRecord);

                //UserRecord_SelectEducation_Habilitation(userRecord);
                //UserRecord_CheckRescueCheckBox(userRecord);
                //UserRecord_CheckIsWorksManager(userRecord);

                //UserRecord_LoadEducation_FormationsOfUser(userRecord);
                CreateButtonSavingAgent();
            }
        }

        private void UserRecord_SelectContactName(Education_FormationProvider providerRecord)
        {
            if (providerRecord.FormationProvider_ContactName != null)
            {
                comboPersonneContact.SelectedIndex = comboPersonneContact.FindStringExact(providerRecord.FormationProvider_ContactName);
            }
        }

        private void ProviderRecord_FillLabels(Education_FormationProvider FormationFournisseur)
        {
            labelFournisseur.Text = FormationFournisseur.Education_Provider.Provider_Name;
        }

        private void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls)
                ctl.Enabled = enable;
        }

        private void DeleteButtonSavingAgent()
        {
        }

        private void CreateButtonSavingAgent()
        {
            // Creating and setting the properties of Button 
            Button ButtonSaveAgent = new Button();
            ButtonSaveAgent.Location = new Point(16, 460);
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

            this.tabControlProvider.Controls[1].Controls.Add(ButtonSaveAgent);

            // Creating and setting the properties of Button 
            Button ButtonCancelModificationAgent = new Button();
            ButtonCancelModificationAgent.Location = new Point(126, 460);
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
            this.tabControlProvider.Controls[1].Controls.Add(ButtonCancelModificationAgent);
        }

        private void SaveAgent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async Task<IPagedList<Education_Provider>> LoadDatagriEducation_Providers(int pagNumber = 1, int pageSize = 100)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    using (CFNEducation_FormationEntities dbList = new CFNEducation_FormationEntities())
                    {
                        pageSize = Int32.Parse(tbNbrRowsProviders.Text);

                        if (MainWindow.globalListProviders == null)
                        {

                            return dbList.Education_Provider
                            .Include("Education_FormationProvider")
                            //.Include("Education_FormationProvider")
                            //.Include("Education_FormationResultat")
                            //.Include("Education_FormationSession")
                            //.Include("Education_Matrice_Formation")
                            //.Include("Education_UnitePrice")

                            .OrderBy(p => p.Provider_Id).ToPagedList(pagNumber, pageSize);
                            //dG_Education_Formations.DataSource = lEducation_Formations.ToPagedList(1, 100); ;
                        }
                        else
                        {
                            return MainWindow.globalListProviders.ToPagedList(pagNumber, pageSize); ;
                            //dG_Education_Formations.DataSource = MainWindow.globalListEducation_Formations.ToPagedList(1, 100); 
                        }
                    }


                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC Provider");
                throw;
            }
            //dG_Education_Formations.AutoGenerateColumns = false;
            //StylingDatagrid(dG_Education_Formations);
        }

        private async void LoadDataGridProdiver()
        {
            dG_Providers.SelectionChanged -= dG_Education_Provider_SelectionChanged; // Remove the handler.
            //dG_Education_Formations.SelectionChanged -= dG_Education_Formations_SelectionChanged; // Remove the handler.

            listProvidersPaged = await LoadDatagriEducation_Providers(1, pageSize);
            dG_Providers.DataSource = GetDataSource(listProvidersPaged);
            dG_Providers.Refresh();
            dG_Providers.Columns[0].Visible = false;
            dG_Providers.SelectionChanged += dG_Education_Provider_SelectionChanged; // ReAdd the handler.
            lblNbrProviders.Text = "Nombre total de formations : " + listProvidersPaged.TotalItemCount.ToString();
        }

        private object GetDataSource(IPagedList<Education_Provider> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGProvider(o)
            {
                Provider_Id = o.Provider_Id,
                
                Provider_Name = o.Provider_Name,
                Provider_Contact = o.Education_FormationProvider.Count == 0 ? null : dbEntities.Education_FormationProvider.
                Where(x => x.FormationProvider_Provider == o.Provider_Id).FirstOrDefault().FormationProvider_ContactName,
                Provider_EmailContact = o.Education_FormationProvider.Count == 0 ? null : dbEntities.Education_FormationProvider.
                Where(x => x.FormationProvider_Provider == o.Provider_Id).FirstOrDefault().FormationProvider_Contact_Email,
                Provider_TelContact = o.Education_FormationProvider.Count == 0 ? null : dbEntities.Education_FormationProvider.
                Where(x => x.FormationProvider_Provider == o.Provider_Id).FirstOrDefault().FormationProvider_ContactTel,

                Provider_FormerContact = o.Education_FormationProvider.Count == 0 ? null : dbEntities.Education_FormationProvider.
                Where(x => x.FormationProvider_Provider == o.Provider_Id).FirstOrDefault().FormationProvider_Former,
                Provider_FormerContactEmail = o.Education_FormationProvider.Count == 0 ? null : dbEntities.Education_FormationProvider.
                Where(x => x.FormationProvider_Provider == o.Provider_Id).FirstOrDefault().FormationProvider_Contact_Email,



            }).ToList();

            lblMin.Text = listPaged.FirstItemOnPage.ToString();
            lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
        }

        private void dG_Education_Provider_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void dG_Providers_MouseClick(object sender, MouseEventArgs e)
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

                int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Modifier le fournisseur", EditProvider_CLick));

                    //m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(dgv, new Point(e.X, e.Y));

                ProviderDataRepository providerRep = new ProviderDataRepository();


                providerSelected = providerRep.GetProvider(Convert.ToInt64(dgv.SelectedCells[0].Value));

            }
        }


        private void EditProvider_CLick(object sender, EventArgs e)
        {
            object[] arr = { providerSelected, null };

            this.tabControlProvider.SelectedIndex = 1;
            LoadProviderCard(providerSelected.Provider_Id);

            //ReceiverLoadEditProvider += new providerEditLoad(LoadProviderCard);
            //UC_Provider.Instance.PointerProvider = ReceiverLoadEditProvider;
            //PointerProvider.DynamicInvoke(providerSelected.Provider_Id);
        }

        private void dG_Providers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.RowIndex > 0)
                {
                    var providerId = dgv.Rows[e.RowIndex].Cells[0].Value;
                    Form parentForm = this.Parent.FindForm() as Form;
                    var matches = parentForm.Controls.Find("flowPanelMenu", true);

                    ProviderDataRepository providerRep = new ProviderDataRepository();
                    providerSelected = providerRep.GetProvider(Convert.ToInt64(dgv.SelectedCells[0].Value));

                    Console.WriteLine(matches);
                    this.tabControlProvider.SelectedIndex = 1;

                    LoadProviderCard(providerSelected.Provider_Id);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UC_Education_FormationS");
                throw ex;
            }
        }
    }
}
