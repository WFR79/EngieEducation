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

namespace Module_Education.Forms.UserControls
{
    public partial class UC_Services : UserControl
    {
        private static UC_Services _instance;
        private ServiceRepository ServiceRepository;
        private DepartementsRepository DepartementsRepository;
        public Delegate PointMenuBtnAgent;


        public UC_Services()
        {
            InitializeComponent();
            LoadDgDepartmentsServices();
            LoadDgServices();
            LoadDgSubServices();

            FormatColumnsDgs();
        }

        private void FormatColumnsDgs()
        {
            foreach (Control ctrl in this.panelDgServices.Controls)
            {
                if (ctrl is DataGridView)
                {
                    DataGridView dg = ctrl as DataGridView;
                    dg.Columns[0].Visible = false;
                }
            }
        }

        public static UC_Services Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Services();

                return _instance;
            }
        }

        public long ServiceIdSelected { get; private set; }
        public long SubServiceIdSelected { get; private set; }
        public Education_Service Currentservice { get; private set; }
        public long UserIDSelected { get; private set; }
        public Education_SousService CurrentSousService { get; private set; }
        public long DepartementIdSelected { get; private set; }
        public Education_Departement CurrentDepartement { get; private set; }

        public void LoadDgServices()
        {
            ServiceRepository = new ServiceRepository();
            dgService.DataSource = GetDataSource(ServiceRepository.LoadAllService());
        }
        public void LoadDgSubServices()
        {
            ServiceRepository = new ServiceRepository();
            dgSubService.DataSource = GetDataSource(ServiceRepository.LoadAllSousService());
        }
        public void LoadDgDepartmentsServices()
        {
            DepartementsRepository = new DepartementsRepository();
            dgDepartement.DataSource = GetDataSource(DepartementsRepository.LoadAllDepartements());
        }
        private object GetDataSource(List<Education_Departement> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGDepartement(o)
            {
                DepartementId = o.Departement_Id,
                DepartementName = o.Departement_Name

            }).OrderBy(p => p.DepartementName).ToList();
            return dataSource;
        }
        private object GetDataSource(List<Education_Service> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGServices(o)
            {
                ServiceId = o.Service_Id,
                ServiceName = o.Service_Name

            }).OrderBy(p => p.ServiceName).ToList();
            return dataSource;
        }


        private object GetDataSource(List<Education_Agent> list)
        {

            try
            {
                object dataSource = list.Select(o => new MyColumnCollectionDGAgent(o)
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
                    Agent_IsWorksManager = o.Agent_IsWorksManager,
                    Agent_DateSeniority = o.Agent_DateSeniority,
                    Agent_DateOfEntry = o.Agent_DateOfEntry,
                    Agent_DateFunction = o.Agent_DateFunction,
                    Habilitation_Name = o.Education_Habilitation == null ? null : o.Education_Habilitation.Habilitation_Name,
                    AgentStatus_Name = o.Education_AgentStatus == null ? null : o.Education_AgentStatus.AgentStatus_Name,
                    Agent_Etat = o.Agent_Etat


                }).OrderBy(p => p.Agent_Matricule).ToList();

                return dataSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private object GetDataSource(List<Education_SousService> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionDGSubServices(o)
            {
                SubServiceId = o.SousService_Id,
                SubServiceName = o.SousService_Name

            }).OrderBy(p => p.SubServiceName).ToList();
            return dataSource;
        }
        private void dgSubService_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Goto fiche du sous-service", EditSubService));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;


                        m.Show(dgv, new Point(e.X, e.Y));
                        SubServiceIdSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void dgService_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Goto fiche du service", EditService));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;


                        m.Show(dgv, new Point(e.X, e.Y));
                        ServiceIdSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void dgDepartement_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;
                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Goto fiche du département", EditSubDepartement));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;


                        m.Show(dgv, new Point(e.X, e.Y));
                        DepartementIdSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void EditService(object sender, EventArgs e)
        {
            this.tabControlRoutes.SelectedIndex = 1;
            LoadServiceDetails();
        }
        private void EditSubService(object sender, EventArgs e)
        {
            this.tabControlRoutes.SelectedIndex = 1;
            LoadSubServiceDetails();

        }
        private void EditSubDepartement(object sender, EventArgs e)
        {
            this.tabControlRoutes.SelectedIndex = 1;
            LoadDepartementDetails();

        }
        private void LoadServiceDetails()
        {
            Currentservice = ServiceRepository.LoadSingleService(ServiceIdSelected);
            lblTitle.Text = Currentservice.Service_Name;
            tbServiceDepartement.Text = Currentservice.Service_Name;
            lbltb.Text = "Service";

            lblcombo.Visible = true;
            comboDep.Visible = true;
            lblcombo.Text = "Département";
            LoadComboDepartementOfService();

            dgAgentServices.DataSource = GetDataSource(Currentservice.Education_Agent.ToList());
        }

        private void LoadSubServiceDetails()
        {
            CurrentSousService = ServiceRepository.LoadSingleSousService(SubServiceIdSelected);
            lblTitle.Text = CurrentSousService.SousService_Name;
            lbltb.Text = "Sous Service";
            tbServiceDepartement.Text = CurrentSousService.SousService_Name;

            lblcombo.Visible = true;
            comboDep.Visible = true;

            lblcombo.Text = "Service";
            LoadComboServiceOfSbService();

            dgAgentServices.DataSource = GetDataSource(CurrentSousService.Education_Agent.ToList());
        }

        private void LoadDepartementDetails()
        {
            List<Education_Agent> education_Agents = new List<Education_Agent>();
            CurrentDepartement = DepartementsRepository.LoadSingleDepartement(DepartementIdSelected);
            lblTitle.Text = CurrentDepartement.Departement_Name;
            tbServiceDepartement.Text = CurrentDepartement.Departement_Name;
            lbltb.Text = "Departement";

            lblcombo.Visible = false;
            comboDep.Visible = false;
            
            foreach(var service in CurrentDepartement.Education_Service)
            {
                foreach(var agent in service.Education_Agent)
                {
                    education_Agents.Add(agent);

                }
                
            }
            dgAgentServices.DataSource = GetDataSource(education_Agents);
        }
        private void LoadComboServiceOfSbService()
        {
            //Dep
            comboDep.DataSource = ServiceRepository.LoadAllService();
            comboDep.DisplayMember = "Service_Name";

            if (CurrentSousService.Education_Service != null)
                comboDep.SelectedIndex = comboDep.FindStringExact(CurrentSousService.Education_Service.Service_Name);
        }

        private void LoadComboDepartementOfService()
        {
            //Dep
            comboDep.DataSource = DepartementsRepository.LoadAllDepartements();
            comboDep.DisplayMember = "Departement_Name";

            if (Currentservice.Education_Departement != null)
                comboDep.SelectedIndex = comboDep.FindStringExact(Currentservice.Education_Departement.Departement_Name);
        }


        private void dgAgentServices_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                if (dgv.SelectedCells[0].Value != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Goto fiche de l'agent", EditUser_CLick));

                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                        m.Show(dgv, new Point(e.X, e.Y));
                        UserIDSelected = Convert.ToInt64(dgv.SelectedCells[0].Value);

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void EditUser_CLick(object sender, EventArgs e)
        {
            object[] arr = { UserIDSelected, null };

            PointMenuBtnAgent.DynamicInvoke(UserIDSelected);
        }

        private void btnSaveRoutes_Click(object sender, EventArgs e)
        {

        }

        private void dgService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblServices_Click(object sender, EventArgs e)
        {

        }
    }
}
