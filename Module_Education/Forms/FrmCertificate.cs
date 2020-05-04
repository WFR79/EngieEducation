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
        public Education_AgentCertifElecFunc AgentCertifElecFuncSelected;
        public Education_AgentCertifElecOPP AgentCertifElecOPPSelected;
        public Education_AgentPassportDesign AgentPassportDesignSelected;


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
                    case "Function":
                        AgentCertifElecFuncSelected = CertificateElecFuncRepository.LoadSinglePassport(PassportId);
                        break;
                    case "OPP":
                        AgentCertifElecOPPSelected = CertificateElecOPPRepository.LoadSinglePassport(PassportId);
                        break;
                    case "Design":
                        AgentPassportDesignSelected = PassportDesignRepository.LoadSinglePassport(PassportId);
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

                    case "Function":
                        lblTitleTypePassport.Text = "Certificat Electrique fonction";
                        lblTitlePassport.Text = "Niveau B";
                        lblSendingDate.Text = "Date d'envoi B";
                        lblReturnDate.Text = "Date Retour B";
                        lblValidityDate.Text = "Date Validité Certification";

                        cbCertified.Text = "Certifié : OUI/NON";
                        lblRemarks.Text = "Remarque";
                        lblRemarksPayment.Visible = false;
                        tbRemarksPay.Visible = false;

                        //TitlePassport
                        comboTitlePassport.DataSource = CertificateElecFuncRepository.LoadAllCertificateFunc();
                        comboTitlePassport.DisplayMember = "CertifElecFunc_LevelB";
                        break;
                    case "OPP":
                        lblTitleTypePassport.Text = "Certificat Electrique OPP";
                        lblTitlePassport.Text = "Niveau R";
                        lblSendingDate.Text = "Date d'envoi R";
                        lblReturnDate.Text = "Date Retour R";
                        lblValidityDate.Text = "Date Validité Certification R";

                        cbCertified.Text = "Certifié : OUI/NON R";
                        lblRemarks.Text = "Remarques R";
                        lblRemarksPayment.Visible = false;
                        tbRemarksPay.Visible = false;

                        //TitlePassport
                        comboTitlePassport.DataSource = CertificateElecOPPRepository.LoadAllPassportSafety();
                        comboTitlePassport.DisplayMember = "CertifElecOPP_LevelR";
                        break;
                    case "Design":
                        lblTitleTypePassport.Text = "Passport Design";
                        lblTitlePassport.Text = "Type Passport";
                        lblSendingDate.Text = "Date d'envoi";
                        lblReturnDate.Text = "Date Retour";
                        lblValidityDate.Visible = false;
                        datePickValidity.Visible = false;

                        cbCertified.Text = "Certifié : OUI/NON";
                        lblRemarks.Text = "Remarques";
                        lblRemarksPayment.Visible = false;
                        tbRemarksPay.Visible = false;

                        //TitlePassport
                        comboTitlePassport.DataSource = PassportDesignRepository.LoadAllPassportDesign();
                        comboTitlePassport.DisplayMember = "PassportDesign_Name";
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

                case "Function":
                    FillLabels("Function");

                    if (AgentCertifElecFuncSelected.Education_CertifElecFunc != null)
                        comboTitlePassport.SelectedIndex = comboTitlePassport.FindStringExact(dbEntities.
                            Education_CertifElecFunc
                            .Where(w => w.CertifElecFunc_Id == AgentCertifElecFuncSelected.AgentCertifElecFunc_Id)
                            .FirstOrDefault().CertifElecFunc_LevelB.ToString());
                    break;

                case "OPP":
                    FillLabels("OPP");

                    if (AgentCertifElecOPPSelected.Education_CertifElecOPP != null)
                        comboTitlePassport.SelectedIndex = comboTitlePassport.FindStringExact(dbEntities.
                            Education_CertifElecOPP
                            .Where(w => w.CertifElecOPP_Id == AgentCertifElecOPPSelected.AgentCertifElecOPP_Certification)
                            .FirstOrDefault().CertifElecOPP_LevelR.ToString());
                    break;

                case "Design":
                    FillLabels("Design");

                    if (AgentPassportDesignSelected.Education_PassportDesign != null)
                        comboTitlePassport.SelectedIndex = comboTitlePassport.FindStringExact(dbEntities.
                            Education_PassportDesign
                            .Where(w => w.PassportDesign_Id == AgentPassportDesignSelected.AgentPassportDesign_Passport)
                            .FirstOrDefault().PassportDesign_Name.ToString());
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
                switch (typeCertificate)
                {
                    case "Safety":
                        AgentPassportSafetySelected = PassportSafetyRepository.SaveExistingCertification(AgentPassportSafetySelected);
                        break;
                    case "Business":
                        AgentPassportBusinessSelected = PassportBusinessRepository.SaveExistingPs(AgentPassportBusinessSelected);
                        break;
                    case "Function":
                        AgentCertifElecFuncSelected = CertificateElecFuncRepository.SaveExistingCertification(AgentCertifElecFuncSelected);

                        break;
                    case "OPP":
                        AgentCertifElecOPPSelected = CertificateElecOPPRepository.SaveExistingPs(AgentCertifElecOPPSelected);

                        break;
                    case "Design":
                        AgentPassportDesignSelected = PassportDesignRepository.SaveExistingPs(AgentPassportDesignSelected);

                        break;
                }
            }
        }

        private void comboTitlePassport_Leave(object sender, EventArgs e)
        {
            switch (typeCertificate)
            {
                case "Safety":
                    if (AgentPassportSafetySelected.AgentPassportSafety_Passport != ((Education_PassportSafety)comboTitlePassport.SelectedItem).PassportSafety_Id)
                    {
                        AgentPassportSafetySelected.AgentPassportSafety_Passport = ((Education_PassportSafety)comboTitlePassport.SelectedItem).PassportSafety_Id;
                    }
                    break;
                case "Business":
                    if (AgentPassportBusinessSelected.AgentPassportBusiness_Business != ((Education_PassportBusiness)comboTitlePassport.SelectedItem).PassportBusiness_Id)
                    {
                        AgentPassportBusinessSelected.AgentPassportBusiness_Business = ((Education_PassportBusiness)comboTitlePassport.SelectedItem).PassportBusiness_Id;
                    }
                    break;
                case "Function":
                    if (AgentCertifElecFuncSelected.AgentCertifElecFunc_Certification != ((Education_CertifElecFunc)comboTitlePassport.SelectedItem).CertifElecFunc_Id)
                    {
                        AgentCertifElecFuncSelected.AgentCertifElecFunc_Certification = ((Education_CertifElecFunc)comboTitlePassport.SelectedItem).CertifElecFunc_Id;
                    }
                    break;
                case "OPP":
                    if (AgentCertifElecOPPSelected.AgentCertifElecOPP_Certification != ((Education_CertifElecOPP)comboTitlePassport.SelectedItem).CertifElecOPP_Id)
                    {
                        AgentCertifElecOPPSelected.AgentCertifElecOPP_Certification = ((Education_CertifElecOPP)comboTitlePassport.SelectedItem).CertifElecOPP_Id;
                    }
                    break;
                case "Design":
                    if (AgentPassportDesignSelected.AgentPassportDesign_Passport != ((Education_PassportDesign)comboTitlePassport.SelectedItem).PassportDesign_Id)
                    {
                        AgentPassportDesignSelected.AgentPassportDesign_Passport = ((Education_PassportDesign)comboTitlePassport.SelectedItem).PassportDesign_Id;
                    }
                    break;
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
