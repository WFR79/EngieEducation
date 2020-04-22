using Module_Education.Models;
using Module_Education.Repositories;
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
    public partial class FrmAgent : Form
    {
        Education_Agent CurrentAgent = new Education_Agent();
        private Education_FormationDataAccess dbEducation_Formation = new Education_FormationDataAccess();


        public FrmAgent(long AgentMatricule)
        {
            InitializeComponent();

            UserRecord_LoadUserVisualisation(AgentMatricule);

        }


        private void UserRecord_LoadUserVisualisation(long AgentMatricule)
        {

            Education_Agent userRecord = MainWindow.globalListAgents.Where(x => x.Agent_Matricule == AgentMatricule).FirstOrDefault();
            CurrentAgent = userRecord;
            if (userRecord != null)
            {
                UserRecord_FillLabels(userRecord);
                UserRecord_FillLabelsActif(userRecord);

                UserRecord_FillMatricule(userRecord);
                UserRecord_FillAdmin(userRecord);
                UserRecord_SelectEquipe(userRecord);
                UserRecord_PickDateOfEntry(userRecord);
                UserRecord_PickUser_DateSeniority(userRecord);
                UserRecord_PickDateFunction(userRecord);
                UserRecord_FillRemarks(userRecord);
                UserRecord_SelectRespHiérarchique(userRecord);
                UserRecord_SelectStatut(userRecord);
                UserRecord_SelectFunction(userRecord);

                UserRecord_SelectRoleEPI(userRecord);
                UserRecord_SelectRoleAstreinte(userRecord);

                UserRecord_SelectEducation_Habilitation(userRecord);
                UserRecord_CheckRescueCheckBox(userRecord);
                UserRecord_CheckIsWorksManager(userRecord);

                UserRecord_LoadEducation_FormationsOfUser(userRecord);
            }
        }


        private void UserRecord_CheckIsWorksManager(Education_Agent userRecord)
        {
            if (userRecord.Agent_IsWorksManager == true)
                checkBox_IsWorkManager.Checked = true;
            else
                checkBox_IsWorkManager.Checked = false;

        }

        private void UserRecord_CheckRescueCheckBox(Education_Agent userRecord)
        {
            if (userRecord.Agent_IsRescueWorker == true)
                checkBoxSecouriste.Checked = true;
            else
                checkBoxSecouriste.Checked = false;
        }

        public void UserRecord_FillLabelsActif(Education_Agent userRecord)
        {
            if (userRecord.Agent_Etat == true)
                labelActif.Text = "Actif";
            else
            {
                if (userRecord.Agent_Etat == false)
                {
                    labelActif.Text = "Inactif";

                }
            }

            labelActif.Text = userRecord.Agent_Etat == null | false ? "Inactif" : "Actif";
        }

        public void UserRecord_FillLabels(Education_Agent userRecord)
        {
            if (userRecord.Agent_FirstName != null && userRecord.Agent_Name != null)
                labelNameOfUser.Text = userRecord.Agent_FirstName + " " + userRecord.Agent_Name.ToUpper();
        }

        public void UserRecord_FillRemarks(Education_Agent userRecord)
        {
            if (userRecord.Agent_Remarks != null)
                richTextBoxRemarks.Text = userRecord.Agent_Remarks;
            else
            {
                richTextBoxRemarks.Text = "";

            }
        }

        public void UserRecord_FillMatricule(Education_Agent userRecord)
        {
            if (userRecord.Agent_Matricule != null)
                labelMatricule.Text = userRecord.Agent_Matricule.ToString();
        }

        public void UserRecord_FillAdmin(Education_Agent userRecord)
        {
            if (userRecord.Agent_Admin != null) { }
            textBoxAdmin.Text = userRecord.Agent_Admin;
        }

        public void UserRecord_SelectEquipe(Education_Agent userRecord)
        {
            if (userRecord.Education_Equipe != null)
                comboBoxEquipe.SelectedIndex = comboBoxEquipe.FindStringExact(userRecord.Education_Equipe.Equipe_Name);
        }

        private void UserRecord_SelectFunction(Education_Agent userRecord)
        {
            if (userRecord.Education_Function != null)
                comboBoxFunction.SelectedIndex = comboBoxFunction.FindStringExact(userRecord.Education_Function.Function_Name);
        }

        private void UserRecord_SelectEducation_Habilitation(Education_Agent userRecord)
        {
            if (userRecord.Education_Habilitation != null)
                comboBoxEducation_Habilitation.SelectedIndex = comboBoxEducation_Habilitation.FindStringExact(userRecord.Education_Habilitation.Habilitation_Name);
        }

        public void UserRecord_SelectStatut(Education_Agent userRecord)
        {
            if (userRecord.Education_AgentStatus != null)
                comboBoxStatut.SelectedIndex = comboBoxStatut.FindStringExact(userRecord.Education_AgentStatus.AgentStatus_Name);
        }

        public void UserRecord_SelectRespHiérarchique(Education_Agent userRecord)
        {
            if (userRecord.Education_RoleEPI != null)
                comboBoxEPI.SelectedIndex = comboBoxRespHierarchique
                    .FindStringExact(userRecord.Education_RoleEPI.RoleEPI_Name);
        }

        private void UserRecord_SelectRoleAstreinte(Education_Agent userRecord)
        {
            if (userRecord.Agent_RoleAstreinte != null)
                comboBoxAstreinte.SelectedIndex = comboBoxAstreinte
                    .FindStringExact(userRecord.Education_RoleAstreinte.RoleAstreinte_Name);
        }

        private void UserRecord_SelectRoleEPI(Education_Agent userRecord)
        {
            if (userRecord.Education_RoleEPI != null)
                comboBoxEPI.SelectedIndex = comboBoxEPI
                    .FindStringExact(userRecord.Education_RoleEPI.RoleEPI_Name);
        }

        public void UserRecord_PickDateOfEntry(Education_Agent userRecord)
        {
            if (userRecord.Agent_DateOfEntry != null)
            {
                dateTimePicker_DateOfEntry.Value = Convert.ToDateTime(userRecord.Agent_DateOfEntry);
            }
        }

        public void UserRecord_PickDateFunction(Education_Agent userRecord)
        {
            if (userRecord.Education_Function != null)
            {
                dateTimePickerLastFunction.Value = Convert.ToDateTime(userRecord.Agent_DateFunction);
            }
        }

        public void UserRecord_PickUser_DateSeniority(Education_Agent userRecord)
        {
            if (userRecord.Agent_DateSeniority != null)
            {
                dateTimePickerSeniority.Value = Convert.ToDateTime(userRecord.Agent_DateSeniority);
            }
        }

        private void UserRecord_LoadEducation_FormationsOfUser(Education_Agent userRecord)
        {
            List<Education_Formation> listEducation_Formation = dbEducation_Formation.LoadAllEducation_FormationOfSingleAgent(userRecord);
            //foreach (Control ctrl in this.tabControlAgentList.Controls[1].Controls)
            //{
            //    Console.WriteLine(ctrl.Controls);
            //}
            dg_TABFormationsOfAgent.DataSource = listEducation_Formation;
        }



    }
}
