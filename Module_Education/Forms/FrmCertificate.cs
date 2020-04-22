using Module_Education.Models;
using Module_Education.Repositories;
using SynapseCore.Controls;
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
    public partial class FrmCertificate : Form
    {

        public string typeCertificate;
        public bool isNewCertificate;

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();
        private Education_FormationDataAccess db = new Education_FormationDataAccess();
        private SessionUniteDataAccess dbSessionUnite = new SessionUniteDataAccess();
        private ProviderDataRepository dbProvider = new ProviderDataRepository();
        private CompetenceDataAccess dbCompetence = new CompetenceDataAccess();
        private FormationResultatDataAccess dbFormationResulat = new FormationResultatDataAccess();
        private FormationDossierRepository dbFormationDossier = new FormationDossierRepository();
        private FormationDossierTypeRepository dbFormationDossierType = new FormationDossierTypeRepository();
        private RoutesFormationRepository dbMatrice = new RoutesFormationRepository();
        private InRouteFormationRepository dbMatriceFormation = new InRouteFormationRepository();
        private CertificateElecFuncRepository CertificateElecFuncRepository = new CertificateElecFuncRepository();
        private CertificateElecOPPRepository CertificateElecOPPRepository = new CertificateElecOPPRepository();

        private PassportSafetyRepository PassportSafetyRepository = new PassportSafetyRepository();
        private PassportBusinessRepository PassportBusinessRepository = new PassportBusinessRepository();
        private PassportDesignRepository PassportDesignRepository = new PassportDesignRepository();

        private AgentDataAccess dbAgent = new AgentDataAccess();
        private AgentMatriceRepository dbAgentMatrice = new AgentMatriceRepository();
        private List<Education_Matrice> listMatrice;
        public Education_Matrice MatriceSelected;
        public Education_Agent AgentSelected;
        public Education_AgentPassportSafety AgentPassportSafetySelected;
        public Education_AgentPassportBusiness AgentPassportBusinessSelected;


        public FrmCertificate(string type, bool isNew, long PassportId)
        {
            InitializeComponent();
            typeCertificate = type;
            isNewCertificate = isNew;
            if (isNewCertificate)
                LoadNewForm(typeCertificate);
            else
            {
                switch (typeCertificate)
                {
                    case "Safety":
                        AgentPassportSafetySelected = PassportSafetyRepository.LoadSinglePassport(PassportId);
                        break;
                    case "Business":
                        AgentPassportBusinessSelected = PassportBusinessRepository.LoadSinglePassport(PassportId);
                        break;
                }
                LoadForm(typeCertificate);

            }
        }

        private void FillLabels(string typeCertificate)
        {
            try
            {
                switch (typeCertificate)
                {
                    case "Safety":
                        lblTitleTypePassport.Text = "Passeport Safety";
                        lblTitlePassport.Text = "Niveau PS";
                        lblSendingDate.Text = "Date d'envoi";
                        lblReturnDate.Text = "Date Retour";
                        cbCertified.Text = "Certification Hiérarchie";
                        lblRemarks.Text = "Remarque";
                        lblRemarksPayment.Text = "Remarque paiement Safety";

                        //TitlePassport
                        comboTitlePassport.DataSource = PassportSafetyRepository.LoadAllPassportSafety();
                        comboTitlePassport.DisplayMember = "PassportSafety_LevelPS";
                        //Hiérarchie checkbox
                        cbCertified.Checked = (bool)AgentPassportSafetySelected.AgentPassportSafety_HierarchyCertification;
                        //Remark
                        tbRemarks.Text = AgentPassportSafetySelected.AgentPassportSafety_Remarks;
                        tbRemarksPay.Text = AgentPassportSafetySelected.AgentPassportSafety_PayRemarks;
                        //Date Envoie
                        datePickSending.Value = (DateTime)AgentPassportSafetySelected.AgentPassportSafety_SendingDate;
                        //Date return
                        datePickReturn.Value = (DateTime)AgentPassportSafetySelected.AgentPassportSafety_ReturnDate;
                        break;

                    case "Business":
                        lblTitleTypePassport.Text = "Passeport Métier";
                        lblTitlePassport.Text = "Description";
                        lblSendingDate.Text = "Date d'envoi";
                        lblReturnDate.Text = "Date Retour";
                        cbCertified.Text = "Certification Hiérarchie";
                        lblRemarks.Text = "Remarque";
                        lblRemarksPayment.Visible = false;
                        tbRemarksPay.Visible = false;

                        //TitlePassport
                        comboTitlePassport.DataSource = PassportBusinessRepository.LoadAllPassportBusiness();
                        comboTitlePassport.DisplayMember = "PassportBusiness_Name";
                        break;
                }
            }
            catch (Exception ex)
            { 
                
            }
        }
        private void LoadForm(string typeCertificate)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    FillLabels("Safety");

                    if (AgentPassportSafetySelected.AgentPassportSafety_Passport != null)
                        comboTitlePassport.SelectedIndex = comboTitlePassport.FindStringExact(dbEntities.
                            Education_PassportSafety
                            .Where(w => w.PassportSafety_Id == AgentPassportSafetySelected.AgentPassportSafety_Passport)
                            .FirstOrDefault().PassportSafety_LevelPS.ToString());
                    break;

                case "Business":
                    FillLabels("Business");

                    if (AgentPassportBusinessSelected.Education_PassportBusiness != null)
                        comboTitlePassport.SelectedIndex = comboTitlePassport.FindStringExact(dbEntities.
                            Education_PassportBusiness
                            .Where(w => w.PassportBusiness_Id == AgentPassportBusinessSelected.AgentPassportBusiness_Id)
                            .FirstOrDefault().PassportBusiness_Name.ToString());
                    break;
            }
        }

        private void LoadNewForm(string typeCertificate)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    FillLabels("Safety");
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveCertification_Click(object sender, EventArgs e)
        {
            if (isNewCertificate)
            {

            }
            else
            {
                AgentPassportSafetySelected = PassportSafetyRepository.SaveExistingCertification(AgentPassportSafetySelected);
            }
        }

        private void comboTitlePassport_Leave(object sender, EventArgs e)
        {
            if (AgentPassportSafetySelected.AgentPassportSafety_Passport != ((Education_PassportSafety)comboTitlePassport.SelectedItem).PassportSafety_Id)
            {
                AgentPassportSafetySelected.AgentPassportSafety_Passport = ((Education_PassportSafety)comboTitlePassport.SelectedItem).PassportSafety_Id;
                //ActivateModification(true);
            }
        }

        private void datePickSending_ValueChanged(object sender, EventArgs e)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    AgentPassportSafetySelected.AgentPassportSafety_SendingDate = datePickSending.Value;
                    break;
            }
        }

        private void datePickReturn_ValueChanged(object sender, EventArgs e)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    AgentPassportSafetySelected.AgentPassportSafety_ReturnDate = datePickReturn.Value;
                    break;
            }
        }

        private void richTextBoxRemarks_TextChanged(object sender, EventArgs e)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    AgentPassportSafetySelected.AgentPassportSafety_Remarks = tbRemarks.Text;
                    break;
            }
        }

        private void tbRemarksPay_TextChanged(object sender, EventArgs e)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    AgentPassportSafetySelected.AgentPassportSafety_PayRemarks = tbRemarksPay.Text;
                    break;
            }
        }

        private void cbCertified_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (typeCertificate)
            {
                case "Safety":
                    AgentPassportSafetySelected.AgentPassportSafety_HierarchyCertification = cb.Checked; 
                    break;
            }
            
        }
    }
}
