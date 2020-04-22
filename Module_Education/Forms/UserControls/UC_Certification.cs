﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module_Education.Models;
using Module_Education.Repositories;
using Module_Education.DataAccessLayer;
using PagedList;
using Module_Education.Helper;
using Module_Education.Classes;
using System.Reflection;

namespace Module_Education.Forms.UserControls
{
    public partial class UC_Certification : UserControl
    {
        #region Déclarations
        private static UC_Certification _instance;

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
        private AgentPassportSafetyRepository agentPassportSafetyRepository = new AgentPassportSafetyRepository();
        private List<Education_Matrice> listMatrice;
        public Education_Matrice MatriceSelected;
        public Delegate PointerFormation;

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        public static List<Education_Matrice_Formation> listMatriceFormationSelected;
        private int pageNumber;
        private int pageSize;
        private IPagedList<Education_Agent> listUserPaged;
        private List<Education_Agent> listAgentFiltered;
        private DataTable dtAgentsCertificate;



        public List<long> ListOfMatriculeSelected { get; private set; }
        public long UserIDSelected;
        public Delegate MainWindowPointerMenuBtnAgent;
        public Delegate PointerUCAgent_Refresh;
        public Delegate PointerRefreshFicheAgent; // Edit user from fiche formation
        private string _filterString;
        #endregion

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

        //BindingSource  bindingSource;
        #endregion


        public UC_Certification()
        {
            InitializeComponent();
            LoadDatagridAgentAsync();
        }

        public static UC_Certification Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Certification();
                return _instance;
            }
        }


        public async Task LoadDatagridAgentAsync()
        {
            List<Education_Agent> listAgent = new List<Education_Agent>();
            try
            {
                pageSize = Int32.Parse(tbNbrRows.Text);
                listUserPaged = await LoadTaskDatagridAgent();

                //lblMin.Text = listUserPaged.FirstItemOnPage.ToString();
                //lblMax.Text = listUserPaged.LastItemOnPage.ToString();

                AdvDg_Certifications.DataSource = GetDataSource(listUserPaged);
                //bindingSource = new BindingSource()
                //{
                //    DataSource = AdvDg_Certifications.DataSource
                   
                //};
                lblNbrRowsFormations.Text = "Nombre total de lignes : " + listUserPaged.TotalItemCount.ToString();
                //dG_Agents.DataSource = listUserPaged;
                PaintCellHeaders(AdvDg_Certifications);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.LogError(ex, Environment.UserName);
            }

        }

        private void PaintCellHeaders(DataGridView AdvDg_Certifications)
        {
            Font fontHeaderColumn = new Font("Arial", 12, FontStyle.Bold);

            for(int i = 0; i < AdvDg_Certifications.Columns.Count; i++) 
            {
                if (AdvDg_Certifications.Columns[i].DataPropertyName == "PassportSafety_LevelPS") // Passport SAFETY
                {
                    AdvDg_Certifications.EnableHeadersVisualStyles = false;
                    //column.HeaderCell.Style.BackColor = Color.LawnGreen;
                    for (int j = 0; j < 6; j++) {
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + j].HeaderCell.Style.BackColor = Color.MediumSeaGreen;
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + j].HeaderCell.Style.Font = fontHeaderColumn;

                    }
                }

                if (AdvDg_Certifications.Columns[i].DataPropertyName == "Description") // Passport METIER
                {
                    AdvDg_Certifications.EnableHeadersVisualStyles = false;
                    //column.HeaderCell.Style.BackColor = Color.LawnGreen;
                    for (int k = 0;k < 6; k++)
                    {
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + k].HeaderCell.Style.Font = fontHeaderColumn;
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + k].HeaderCell.Style.BackColor = Color.LimeGreen;

                    }
                }

                if (AdvDg_Certifications.Columns[i].DataPropertyName == "NiveauB") // Certificate Elec Func
                {
                    AdvDg_Certifications.EnableHeadersVisualStyles = false;
                    //column.HeaderCell.Style.BackColor = Color.LawnGreen;
                    for (int l = 0; l < 6; l++)
                    {
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + l].HeaderCell.Style.BackColor = Color.LightGray;
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + l].HeaderCell.Style.Font = fontHeaderColumn;
                    }
                }

                if (AdvDg_Certifications.Columns[i].DataPropertyName == "NiveauR") //  Certificate Elec OPP
                {
                    AdvDg_Certifications.EnableHeadersVisualStyles = false;
                    //column.HeaderCell.Style.BackColor = Color.LawnGreen;
                    for (int m = 0; m < 6; m++)
                    {
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + m].HeaderCell.Style.BackColor = Color.Thistle;
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + m].HeaderCell.Style.Font = fontHeaderColumn;

                    }
                }
                if (AdvDg_Certifications.Columns[i].DataPropertyName == "TypePAssport") // Passport DESIGN
                {
                    AdvDg_Certifications.EnableHeadersVisualStyles = false;
                    //column.HeaderCell.Style.BackColor = Color.LawnGreen;
                    for (int n = 0; n < 5; n++)
                    {
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + n].HeaderCell.Style.BackColor = Color.Gold;
                        AdvDg_Certifications.Columns[AdvDg_Certifications.Columns[i].Index + n].HeaderCell.Style.Font = fontHeaderColumn;

                    }
                }
            }
        }

        private async Task<IPagedList<Education_Agent>> LoadTaskDatagridAgent(int pagNumber = 1, int pageSize = 50)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                List<Education_Agent> tempUserList = new List<Education_Agent>();

                if (pageNumber == 0)
                {
                    pageNumber = 1;
                }
                return await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (MainWindow.globalListCertificateAgents == null)
                        {
                            return dbEntities.Education_Agent
                        .Include("Education_AgentPassportSafety")
                        .Include("Education_AgentCertifElecFunc")
                        .Include("Education_AgentCertifElecOPP")
                        .Include("Education_AgentPassportBusiness")
                        .Include("Education_AgentPassportDesign")
                        .OrderBy(p => p.Agent_Id).ToPagedList(pagNumber, pageSize);
                        }
                        else {
                            return MainWindow.globalListCertificateAgents.ToPagedList(pagNumber, pageSize); ;

                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                });

            }
            catch (StackOverflowException ex)
            {
                Logger.LogError(ex, "UC Education_Formation");
                throw;
            }
        }

        private object GetDataSource(IPagedList<Education_Agent> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGAgentCertification(o)
            {
                Agent_Matricule = o.Agent_Matricule,
                Agent_FirstName = o.Agent_FirstName,
                Agent_Name = o.Agent_Name,

                //Passport Safety
                PassportSafety_LevelPS = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_LevelPS,
                Certif_Hierarchie = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_HierarchyCertification,
                SendingDate = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_SendingDate,
                ReturnDate = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_ReturnDate,
                PassportRemarks = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_Remarks,
                PassportRemarkPay = o.Education_AgentPassportSafety.FirstOrDefault().AgentPassportSafety_PayRemarks,

                //Passport Business

                Description = o.Education_AgentPassportBusiness.FirstOrDefault().Education_PassportBusiness.PassportBusiness_Name,
                SendingDatePassportBusiness = o.Education_AgentPassportBusiness.FirstOrDefault().AgentPassportBusiness_SendingDate,
                ReturnDatePassportBusiness = o.Education_AgentPassportBusiness.FirstOrDefault().AgentPassportBusiness_ReturnDate,
                Certif_HierarchiePassportBusiness = o.Education_AgentPassportBusiness.FirstOrDefault().AgentPassportBusiness_HierarchyCertification,
                PassportRemarksPassportBusiness = o.Education_AgentPassportBusiness.FirstOrDefault().AgentPassportBusiness_Remark,


                //Certification Electrique Role Function

                NiveauB = o.Education_AgentCertifElecFunc.FirstOrDefault().Education_CertifElecFunc.CertifElecFunc_LevelB,
                SendingDateCertifElecFunc = o.Education_AgentCertifElecFunc.FirstOrDefault().AgentCertifElecFunc_SendingDate,
                ReturnDateCertifElecFunc = o.Education_AgentCertifElecFunc.FirstOrDefault().AgentCertifElecFunc_ReceivedDate,
                Certif_HierarchieCertifElecFunc = o.Education_AgentCertifElecFunc.FirstOrDefault().AgentCertifElecFunc_IsCertified,
                ValidityDateCertifElecFunc = o.Education_AgentCertifElecFunc.FirstOrDefault().AgentCertifElecFunc_ValidityDate,
                RemarksCertifElecFunc = o.Education_AgentCertifElecFunc.FirstOrDefault().AgentCertifElecFunc_Remark,

                //Certification Electrique Role OPP

                NiveauR = o.Education_AgentCertifElecOPP.FirstOrDefault().Education_CertifElecOPP.CertifElecOPP_LevelR,
                SendingDateCertifElecOPP = o.Education_AgentCertifElecOPP.FirstOrDefault().AgentCertifElecOPP_SendingDate,
                ReturnDateCertifElecOPP = o.Education_AgentCertifElecOPP.FirstOrDefault().AgentCertifElecOPP_ReceivedDate,
                Certif_HierarchieCertifElecOPP = o.Education_AgentCertifElecOPP.FirstOrDefault().AgentCertifElecOPP_IsCertified,
                ValidityDateCertifElecOPP = o.Education_AgentCertifElecOPP.FirstOrDefault().AgentCertifElecOPP_ValidityDate,
                RemarksCertifElecOPP = o.Education_AgentCertifElecOPP.FirstOrDefault().AgentCertifElecOPP_Remark,

                //Passport Design

                TypePAssport = o.Education_AgentPassportDesign.FirstOrDefault().Education_PassportDesign.PassportDesign_Name,
                SendingDatePassportDesign = o.Education_AgentPassportDesign.FirstOrDefault().AgentPassportDesign_SendingDate,
                ReturnDatePassportDesign = o.Education_AgentPassportDesign.FirstOrDefault().AgentPassportDesign_ReceivedDate,
                Certif_HierarchiePassportDesign = o.Education_AgentPassportDesign.FirstOrDefault().AgentPassportDesign_IsCertified,
                RemarksPassportDesign = o.Education_AgentPassportDesign.FirstOrDefault().AgentPassportDesign_Remark,



            }).ToList();

            lblMin.Text = listPaged.FirstItemOnPage.ToString();
            lblMax.Text = listPaged.LastItemOnPage.ToString();
            return dataSource;
        }

        private void AdvDg_Certifications_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                //dgv.ClearSelection();

                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Aller à la fiche de l'agent", GoToAgentCard));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

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

        private void GoToAgentCard(object sender, EventArgs e)
        {
            object[] arr = { UserIDSelected, null };

            PointerFormation.DynamicInvoke(UserIDSelected);
            MainWindowPointerMenuBtnAgent.DynamicInvoke(Convert.ToInt64(UserIDSelected));
            //PointerRefreshFicheAgent.DynamicInvoke(Convert.ToInt64(UserIDSelected));
        }

        private void AdvDg_Certifications_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.Default;

        }

        private void AdvDg_Certifications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool)
            {
                bool value = (bool)e.Value;
                e.Value = (value) ? "OUI" : "NON";
                e.FormattingApplied = true;
            }
        }

        private void AdvDg_Certifications_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            _filterString = e.FilterString;
            DataGridView dgv = (DataGridView)sender;
            //DataTable dt = (DataTable)AdvDg_Certifications.DataSource;
            TriggerFilterStringChanged(e);
        }

        public async void TriggerFilterStringChanged(Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
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
                    listAgentFiltered = MainWindow.globalListCertificateAgents;
                else {
                    dtAgentsCertificate = ToDataTable<Education_Agent>(listAgentFiltered);

                }
                dtAgentsCertificate = ToDataTable<Education_Agent>(listAgentFiltered);

                if (_filterString == "")
                {
                    LoadDatagridAgentAsync();
                }
                else
                {
                    BindingSource bindingSource = new BindingSource()
                    {
                        DataMember = dtAgentsCertificate.TableName,
                        DataSource = dtAgentsCertificate
                    };
                    bindingSource.Filter = _filterString;

                    AdvDg_Certifications.DataSource = bindingSource;


                }
               

                



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

        private string FilterStringconverter(string filter)
        {
            string newColFilter = "";

            // get rid of all the parenthesis 
            filter = filter.Replace("(", "").Replace(")", "");

            // now split the string on the 'and' (each grid column)
            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);

            string andOperator = "";

            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;

                // split string on the 'in'
                var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);

                // get string between square brackets
                var colName = temp1[0].Split('[', ']')[1].Trim();

                // prepare beginning of linq statement
                newColFilter += string.Format("({0} != null && (", colName);

                string orOperator = "";

                var filterValsList = temp1[1].Split(',');

                foreach (var filterVal in filterValsList)
                {
                    // remove any single quotes before testing if filter is a num or not
                    var cleanFilterVal = filterVal.Replace("'", "").Trim();

                    double tempNum = 0;
                    if (Double.TryParse(cleanFilterVal, out tempNum))
                        newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, cleanFilterVal.Trim());
                    else
                        newColFilter += string.Format("{0} {1}.Contains('{2}')", orOperator, colName, cleanFilterVal.Trim());

                    orOperator = " OR ";
                }

                newColFilter += "))";

                andOperator = " AND ";
            }

            // replace all single quotes with double quotes
            return newColFilter.Replace("'", "\"");
        }

    }
}
