using Module_Education.Models;
using Module_Education.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Forms
{
    public partial class FrmEditCertificate : Form
    {
        #region Déclarations
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
        private PassportSafetyRepository passportSafetyRepository = new PassportSafetyRepository();
        private PassportBusinessRepository PassportBusinessRepository = new PassportBusinessRepository();
        private PassportDesignRepository PassportDesignRepository = new PassportDesignRepository();
        private CertificateElecFuncRepository CertificateElecFuncRepository = new CertificateElecFuncRepository();
        private CertificateElecOPPRepository CertificateElecOPPRepository = new CertificateElecOPPRepository();

        CFNEducation_FormationEntities dbEntities = new CFNEducation_FormationEntities();

        public long PassportId { get; private set; }

        private string typeDgv;
        #endregion
        public FrmEditCertificate()
        {
            InitializeComponent();
            LoadTypes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTypes()
        {
            combotypePassport.DataSource = dbEntities.Education_PassportType.ToList();
            combotypePassport.DisplayMember = "PassportType_Name";

        }

        private void combotypePassport_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListOfExistingPassports((Education_PassportType)combotypePassport.SelectedItem);

        }

        private void LoadListOfExistingPassports(Education_PassportType selectedItem)
        {
            switch (selectedItem.PassportType_Name)
            {
                case "Passport Safety":
                    dgListPassport.DataSource = dbEntities.Education_PassportSafety.ToList();
                    dgListPassport.Name = "Passport Safety";
                    tbExt_NameCertificate.TextChanged += TextChangedSafety;
                    //tbExt_NameCertificate.Validating += ValidatingSafety;
                    break;
                case "Passport Métier":
                    dgListPassport.DataSource = dbEntities.Education_PassportBusiness.ToList();
                    dgListPassport.Name = "Passport Safety";
                    tbExt_NameCertificate.TextChanged -= TextChangedSafety;

                    tbExt_NameCertificate.TextChanged += TextChangedBusiness;

                    break;
                case "Passport Design":
                    dgListPassport.DataSource = dbEntities.Education_PassportDesign.ToList();
                    dgListPassport.Name = "Passport Design";

                    tbExt_NameCertificate.TextChanged -= TextChangedSafety;

                    tbExt_NameCertificate.TextChanged += TextChangedBusiness;
                    break;
                case "Certificat Electrique Fonction":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecFunc.ToList();

                    tbExt_NameCertificate.TextChanged -= TextChangedSafety;

                    tbExt_NameCertificate.TextChanged += TextChangedBusiness;
                    dgListPassport.Name = "Certificat Electrique Fonction";

                    break;
                case "Certificat Electrique OPP":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecOPP.ToList();

                    tbExt_NameCertificate.TextChanged -= TextChangedSafety;

                    tbExt_NameCertificate.TextChanged += TextChangedBusiness;
                    dgListPassport.Name = "Certificat Electrique OPP";

                    break;
                case "Certificat Divers":
                    dgListPassport.DataSource = dbEntities.Education_CertificatDivers.ToList();

                    tbExt_NameCertificate.TextChanged -= TextChangedSafety;

                    tbExt_NameCertificate.TextChanged += TextChangedBusiness;
                    dgListPassport.Name = "Certificat Divers";

                    break;
            }

            tbExt_NameCertificate.Text = "";

            dgListPassport.Columns[0].Visible = false;
            if (dgListPassport.Columns.Count > 2)
             dgListPassport.Columns[2].Visible = false;

        }

        private void TextChangedBusiness(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbExt_NameCertificate, "");
            btnSaveCertificate.Enabled = true;
        }

        private bool RequiredFieldIsBlank(ErrorProvider err, TextBox txt)
        {
            if (txt.Text.Length > 0)
            {
                // Clear the error.
                err.SetError(txt, "");
                return false;
            }
            else
            {
                // Set the error.
                err.SetError(txt,
                    " Test");
                return true;
            }
        }
        //private void ValidatingSafety(object sender, CancelEventArgs e)
        //{
        //    TextBox txt = sender as TextBox;
        //    e.Cancel = RequiredFieldIsBlank(errorProvider1, txt);
        //}

        private void TextChangedSafety(object sender, EventArgs e)
        {
            if (tbExt_NameCertificate.Text != "")
            {
                if (!Regex.IsMatch(tbExt_NameCertificate.Text, @"^\d+$"))
                {
                    if (tbExt_NameCertificate.Text != "")
                    {
                        tbExt_NameCertificate.Text = tbExt_NameCertificate.Text.Remove(tbExt_NameCertificate.Text.Length - 1);
                    }
                    errorProvider1.SetError(tbExt_NameCertificate, "Mauvais format du nom du certificat. /r Entrez un chiffre.");
                    btnSaveCertificate.Enabled = false;

                }
                else
                {
                    errorProvider1.SetError(tbExt_NameCertificate, "");
                    btnSaveCertificate.Enabled = true;
                }
            }
            else
            {
                errorProvider1.SetError(tbExt_NameCertificate, "");
                btnSaveCertificate.Enabled = true;
            }
        }

        private void dgListPassport_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                //dgListPassport.ClearSelection();

                //dgv.ClearSelection();

                var selectedRows = dgListPassport.SelectedRows
                                   .OfType<DataGridViewRow>()
                                   .Where(row => !row.IsNewRow)
                                   .ToArray();



                if (e.Button == MouseButtons.Right)
                {
                    //dgv.ClearSelection();
                    dgv.Rows[dgv.HitTest(e.X, e.Y).RowIndex].Selected = true;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Supprimer ce certificat", DeletePassport));

                    int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                    //if (currentMouseOverRow >= 0)
                    //{
                    //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    //}

                    m.Show(dgv, new Point(e.X, e.Y));
                    PassportId = Convert.ToInt64(dgv.SelectedCells[0].Value);
                    typeDgv = dgv.Name;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void DeletePassport(object sender, EventArgs e)
        {
            switch (typeDgv)
            {
                case "Passport Safety":
                    Education_PassportSafety item = dbEntities.Education_PassportSafety
                        .Where(x => x.PassportSafety_Id == PassportId)
                        .FirstOrDefault();

                    dbEntities.Education_PassportSafety.Remove(item);
                    dbEntities.SaveChanges();
                    break;
                case "Passport Métier":
                    dgListPassport.DataSource = dbEntities.Education_PassportBusiness.ToList();
                    dgListPassport.Name = "Passport Métier";

                    break;
                case "Passport Design":
                    dgListPassport.DataSource = dbEntities.Education_PassportDesign.ToList();
                    dgListPassport.Name = "Passport Design";

                    break;
                case "Certificat Electrique Fonction":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecFunc.ToList();
                    dgListPassport.Name = "Certificat Electrique Fonction";

                    break;
                case "Certificat Electrique OPP":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecOPP.ToList();
                    dgListPassport.Name = "Certificat Electrique OPP";

                    break;
                case "Certificat Divers":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecOPP.ToList();

                    dgListPassport.Name = "Certificat Divers";

                    break;
            }
        }

        private void btnSaveCertificate_Click(object sender, EventArgs e)
        {
            switch (dgListPassport.Name)
            {
                case "Passport Safety":

                    int levelPs = Convert.ToInt32(tbExt_NameCertificate.Text);
                    Education_PassportSafety itemDb = dbEntities.Education_PassportSafety
                        .Where(x => x.PassportSafety_LevelPS == levelPs)
                        .FirstOrDefault();
                    if (itemDb == null)
                    {
                        passportSafetyRepository.SaveNewPs(Convert.ToInt32(tbExt_NameCertificate.Text));
                        dgListPassport.DataSource = dbEntities.Education_PassportSafety.ToList();
                        tbExt_NameCertificate.Text = "";
                    }
                    else
                    {
                        errorProvider1.SetError(tbExt_NameCertificate, "Level PS déja présent.");
                        btnSaveCertificate.Enabled = false;
                    }
                    break;

                case "Passport Métier":

                    Education_PassportBusiness itemBusinessDb = dbEntities.Education_PassportBusiness
                       .Where(x => x.PassportBusiness_Name == tbExt_NameCertificate.Text)
                       .FirstOrDefault();
                    if (itemBusinessDb == null)
                    {
                        PassportBusinessRepository.SaveNewPs(tbExt_NameCertificate.Text);
                        dgListPassport.DataSource = dbEntities.Education_PassportBusiness.ToList();
                        tbExt_NameCertificate.Text = "";
                    }
                    else
                    {
                        errorProvider1.SetError(tbExt_NameCertificate, "Nom du passport déja présent");
                        btnSaveCertificate.Enabled = false;
                    }

                    break;
                case "Passport Design":
                    Education_PassportDesign itemDesignDb = dbEntities.Education_PassportDesign
                        .Where(x => x.PassportDesign_Name == tbExt_NameCertificate.Text)
                        .FirstOrDefault();
                    if (itemDesignDb == null)
                    {
                        PassportDesignRepository.SaveNewPs(tbExt_NameCertificate.Text);
                        dgListPassport.DataSource = dbEntities.Education_PassportDesign.ToList();
                        tbExt_NameCertificate.Text = "";
                    }
                    else
                    {
                        errorProvider1.SetError(tbExt_NameCertificate, "Nom du passport déja présent");
                        btnSaveCertificate.Enabled = false;
                    }

                    break;
                case "Certificat Electrique Fonction":

                    Education_CertifElecFunc itemFuncDb = dbEntities.Education_CertifElecFunc
                     .Where(x => x.CertifElecFunc_LevelB == tbExt_NameCertificate.Text)
                     .FirstOrDefault();
                    if (itemFuncDb == null)
                    {
                        CertificateElecFuncRepository.SaveNewCertificatFunc(tbExt_NameCertificate.Text);
                        dgListPassport.DataSource = dbEntities.Education_CertifElecFunc.ToList();
                        tbExt_NameCertificate.Text = "";
                    }
                    else
                    {
                        errorProvider1.SetError(tbExt_NameCertificate, "Nom du certificat déja présent");
                        btnSaveCertificate.Enabled = false;
                    }

                    break;
                case "Certificat Electrique OPP":

                    Education_CertifElecOPP itemOPPDb = dbEntities.Education_CertifElecOPP
                   .Where(x => x.CertifElecOPP_LevelR == tbExt_NameCertificate.Text)
                   .FirstOrDefault();
                    if (itemOPPDb == null)
                    {
                        CertificateElecOPPRepository.SaveNewCertificatOPP(tbExt_NameCertificate.Text);
                        dgListPassport.DataSource = dbEntities.Education_CertifElecFunc.ToList();
                        tbExt_NameCertificate.Text = "";
                    }
                    else
                    {
                        errorProvider1.SetError(tbExt_NameCertificate, "Nom du certificat déja présent");
                        btnSaveCertificate.Enabled = false;
                    }

                    break;
                case "Certificat Divers":
                    dgListPassport.DataSource = dbEntities.Education_CertifElecOPP.ToList();

                    dgListPassport.Name = "Certificat Divers";

                    break;
            }
        }
    }
}
