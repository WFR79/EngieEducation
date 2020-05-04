using Module_Education.Classes;
using Module_Education.Classes.Extensions;
using Module_Education.Models;
using Module_Education.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Forms
{
    public partial class FrmEquivalenceComment : Form
    {
        public Education_FormationDataAccess dbFormation = new Education_FormationDataAccess();
        public Education_Matrice_Agent CurrentMatriceAgent;
        public Education_Matrice_AgentEquivalence newRecord = new Education_Matrice_AgentEquivalence();

        public AgentMatriceEquivalenceRepository AgentMatriceEquivalenceRepository = new AgentMatriceEquivalenceRepository();
        public AgentMatriceRepository AgentMatriceRepository = new AgentMatriceRepository();
        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();

        public FrmEquivalenceComment(Education_Matrice_Agent selectedMatriceAgent)
        {
            CurrentMatriceAgent = AgentMatriceRepository.LoadSingleTrajetFormation(selectedMatriceAgent.MatriceAgent_Id);
            InitializeComponent();
            if(CurrentMatriceAgent.Education_Matrice_AgentEquivalence != null)
                tbCommentEquivalence.Text = CurrentMatriceAgent.Education_Matrice_AgentEquivalence.MatriceAgentEquivalence_Comments;
            LoadFormation();
            SelectFormationEquiv(CurrentMatriceAgent);

        }

        private void SelectFormationEquiv(Education_Matrice_Agent currentMatriceAgent)
        {
            int rowIndex = -1;
            if (currentMatriceAgent.Education_Matrice_AgentEquivalence != null)
            {
                Education_Formation formation = dbFormation.LoadSingleEducation_Formation(currentMatriceAgent.Education_Matrice_AgentEquivalence.MatriceAgentEquivalence_Formation);


                DataGridViewRow row = l_PopUp.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["Formation_SAP"].Value.ToString().Equals(formation.Formation_SAP))
                    .First();

                rowIndex = row.Index;
                this.l_PopUp.Rows[rowIndex].Selected = true;
                this.l_PopUp.CurrentCell = this.l_PopUp.Rows[rowIndex].Cells[0];
            }

        }

        private void LoadFormation()
        {
            List<Education_Formation> listFormations = dbFormation.LoadAllEducation_Formations();
            //foreach(var item in listFormations)

            l_PopUp.DataSource = GetDataSource(listFormations);
        }

        private object GetDataSource(List<Education_Formation> listPaged)
        {
            object dataSource = listPaged.Select(o => new MyColumnCollectionFrmFormation(o)
            {
                Formation_ShortTitle = o.Formation_ShortTitle,
                Formation_SAP = o.Formation_SAP,

            }).ToList();

            return dataSource;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddFormations_Click(object sender, EventArgs e)
        {

            if (CurrentMatriceAgent.Education_Matrice_AgentEquivalence != null)
            {
                CurrentMatriceAgent.Education_Matrice_AgentEquivalence.MatriceAgentEquivalence_Comments = tbCommentEquivalence.Text;
                if (l_PopUp.SelectedRows.Count > 0)
                {
                    var selectedRows = l_PopUp.SelectedRows
                                       .OfType<DataGridViewRow>()
                                       .Where(row => !row.IsNewRow)
                                       .ToArray();


                    foreach (DataGridViewRow row in selectedRows)
                    {
                        var item = dbFormation.LoadSingleEducation_Formation(row.Cells[1].Value.ToString());
                        CurrentMatriceAgent.Education_Matrice_AgentEquivalence.MatriceAgentEquivalence_Formation = item.Formation_Id;
                    }
                    //dbEntities.Education_Matrice_AgentEquivalence.Add(newRecord);
                    AgentMatriceEquivalenceRepository.SaveEquivalence(CurrentMatriceAgent, CurrentMatriceAgent.Education_Matrice_AgentEquivalence);
                    AutoClosingMessageBox.Show("Equivalence enregistrée", "Information", 1500, MessageBoxIcon.Information);

                }

            }
            else
            {
                newRecord.MatriceAgentEquivalence_Comments = tbCommentEquivalence.Text;
                if (l_PopUp.SelectedRows.Count > 0)
                {
                    var selectedRows = l_PopUp.SelectedRows
                                       .OfType<DataGridViewRow>()
                                       .Where(row => !row.IsNewRow)
                                       .ToArray();


                    foreach (DataGridViewRow row in selectedRows)
                    {
                        var item = dbFormation.LoadSingleEducation_Formation(row.Cells[1].Value.ToString());
                        newRecord.MatriceAgentEquivalence_Formation = item.Formation_Id;
                    }
                }
                dbEntities.Education_Matrice_AgentEquivalence.Add(newRecord);
                dbEntities.SaveChanges();
                AgentMatriceEquivalenceRepository.SaveEquivalence(CurrentMatriceAgent, newRecord);
                AutoClosingMessageBox.Show("Title", "Caption", 1500, MessageBoxIcon.Information); 
            }


        }

        private void tbCommentEquivalence_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void l_PopUp_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
