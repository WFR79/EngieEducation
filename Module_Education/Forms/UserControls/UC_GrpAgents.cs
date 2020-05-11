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
        private Education_Agent SelectedAgent = new Education_Agent();
        private Education_GroupLearner SelectedGrpLearner = new Education_GroupLearner();
        #region Repositories
        private GrpAgentRepository GrpAgentRepository = new GrpAgentRepository();
        private GrpLearnearAgentRepository grpLearnearAgentRepository = new GrpLearnearAgentRepository();
        private AgentDataAccess AgentDataAccess = new AgentDataAccess();

        #endregion
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
            comboGrpAgents.DataSource = GrpAgentRepository.LoadAllGrpAgents();
            comboGrpAgents.DisplayMember = "GroupLearner_Name";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Education_GroupLearner_Agent AddedAgent = grpLearnearAgentRepository.AddGrpLearnerAgent(SelectedAgent, SelectedGrpLearner);
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

        private void dgGrpAgent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool)
            {
                bool value = (bool)e.Value;
                e.Value = (value) ? "OUI" : "NON";
                e.FormattingApplied = true;
            }
        }
    }
}
