using Module_Education.DataAccessLayer;
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
    public partial class FrmCertificateSynapse : SynapseForm
    {
        public string typeCertificate;
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

        public FrmCertificateSynapse()
        {
            InitializeComponent();
            LoadForm(typeCertificate);
        }

        private void LoadForm(string typeCertificate)
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

                    //Unite
                    comboTitlePassport.DataSource = PassportSafetyRepository.LoadAllPassportSafety();
                    comboTitlePassport.DisplayMember = "PassportSafety_LevelPS";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveCertification_Click(object sender, EventArgs e)
        {

        }
    }
}
