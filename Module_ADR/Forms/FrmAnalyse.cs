using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SynapseCore.Controls;
using Module_ADR.Helper;
using Module_ADR.Models;
using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.CustomController;
using System.IO;
using iTextSharp.text.pdf;
using MoreLinq;
using Module_ADR.Services;
using log4net;
using SynapseAdvancedControls;
using log4net.Config;

namespace Module_ADR.Forms
{
    public partial class FrmAnalyse : SynapseForm
    {
        #region Properties

        private IEnumerable<ADR_SAPOrders> SAPOrdersBl;
        private List<ADR_SAPOrders> SAPOrdersContains;
        private List<ADR_SAPOrders> SAPOrdersBlMulti;

        private IEnumerable<ADR_Analysis_Result> AnalysisResultsBl;
        private IEnumerable<ADR_Analysis_Result> AnalysisResultsBlModels;
        private List<ADR_Analysis_Result> AnalysisResultContains;

        private ADR_SAPOrders SAPOrderBlCurrency;
        private ADR_Analysis_Result AnalysisResultBlCurrency;
        private ADR_Analysis_Result AnalysisResultBlModel;
        private ADR_WorkCenter WorkCenter;

        private TypeAssistant TypeAssistant;

        private List<ADR_SAPOrders> SAPExclude = new List<ADR_SAPOrders>();
        private List<ADR_SAPOrders> SAPSave = new List<ADR_SAPOrders>();

        private string CurrentSearch;
        private bool IsModel;
        private bool IsMulti;
        private bool IsCreate;
        private bool IsNotSave;

        private bool IsAssistantFilter;
        private bool IsAssistantSearch;
        private bool IsAssistantSearchModel;

        private bool IsPlan;
        private bool IsOrdre;

        private ILog Log;
        private GenerateHistorique GenerateHistorique;

        #endregion

        #region Constructor

        public FrmAnalyse(ADR_WorkCenter WorkCenter)
        {
            InitializeComponent();
            SAPOrdersBlMulti = new List<ADR_SAPOrders>();
            GenerateHistorique = new GenerateHistorique();
            Log = LogManager.GetLogger(typeof(FrmAnalyse));
            XmlConfigurator.Configure();
            this.WorkCenter = WorkCenter;
            AnalysisResultContains = new List<ADR_Analysis_Result>();
            SAPOrdersContains = new List<ADR_SAPOrders>();
            TypeAssistant = new TypeAssistant();
            TypeAssistant.Idled += TypeAssistant_Idled;
        }

        #endregion

        #region InitForm

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            SetColumnHeaderOblw();
            oblwSearch.SetObjects(SAPOrdersBl);
            cbValueSearch.SelectedIndex = 0;
            LoadImage();
            ResetAll();
            GestionActive(false);
            btnLoadInPlan.Enabled = false;
            btnLoadintoOrder.Enabled = false;
            btnPrint.Enabled = false;
            btnSerarch_Click(null, null);
            lblCriticality.Text = "Criticité";
            btnCreateOrder.Text = "Analyse manuelle";
            PopulateOrderList();
        }

        #endregion

        #region Methode Private

        #region Design

        /// <summary>
        /// Charge les informations de criticité.
        /// </summary>
        private void LoadCriticalityHelperName()
        {
            ADR_Analysis_Template AnalyseTemplateBl;

            using (AnalysisTemplateRepository AnalysisTemplateRepository = new AnalysisTemplateRepository())
            {
                AnalyseTemplateBl = AnalysisTemplateRepository.Get().Where((at) => at.IsActive).FirstOrDefault();
            }

            if (AnalyseTemplateBl != null)
            {
                LabelSetName(AnalyseTemplateBl.CriticalityId1, lblCriticalityHelper1, txtCriticalityRisk1, txtCriticalityHelper1);
                LabelSetName(AnalyseTemplateBl.CriticalityId2, lblCriticalityHelper2, txtCriticalityRisk2, txtCriticalityHelper2);
                LabelSetName(AnalyseTemplateBl.CriticalityId3, lblCriticalityHelper3, txtCriticalityRisk3, txtCriticalityHelper3);
                LabelSetName(AnalyseTemplateBl.CriticalityId4, lblCriticalityHelper4, txtCriticalityRisk4, txtCriticalityHelper4);
                LabelSetName(AnalyseTemplateBl.CriticalityId5, lblCriticalityHelper5, txtCriticalityRisk5, txtCriticalityHelper5);
                LabelSetName(AnalyseTemplateBl.CriticalityId6, lblCriticalityHelper6, txtCriticalityRisk6, txtCriticalityHelper6);
            }
        }

        /// <summary>
        /// Affiche l'analyse
        /// </summary>
        /// <param name="AnalysisId"></param>
        private void LoadAnalysisResult(int AnalysisId)
        {
            GetAnalysisCriticality(AnalysisId);
        }

        /// <summary>
        /// Définis le header des colonnes
        /// </summary>
        private void SetColumnHeaderOblw()
        {
            this.oblwSearch.Clear();

            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                this.oblwSearch.AllColumns.Add(this.olvNbs);
                this.oblwSearch.AllColumns.Add(this.olvCriticality);
                this.oblwSearch.AllColumns.Add(this.olvOrderShortDesc);
                this.oblwSearch.AllColumns.Add(this.olvFuncLocation);
                this.oblwSearch.AllColumns.Add(this.olvWorkCenter);
                this.oblwSearch.AllColumns.Add(this.olvWorkSpace);
                this.oblwSearch.AllColumns.Add(this.olvPreparator);
                this.oblwSearch.AllColumns.Add(this.olvRevision);
                this.oblwSearch.AllColumns.Add(this.olvRevisionPhase);
                this.oblwSearch.AllColumns.Add(this.olvStartDate);
                this.oblwSearch.AllColumns.Add(this.olvFinishDate);
                this.oblwSearch.AllColumns.Add(this.olvExectutionDate);
                this.oblwSearch.AllColumns.Add(this.olvMaintenancePlan);
                this.oblwSearch.AllColumns.Add(this.olvMaintenanceItem);

                this.oblwSearch.Columns.AddRange(new ColumnHeader[] {
                this.olvNbs,
                this.olvCriticality,
                this.olvOrderShortDesc,
                this.olvFuncLocation,
                this.olvWorkCenter,
                this.olvWorkSpace,
                this.olvPreparator,
                this.olvRevision,
                this.olvRevisionPhase,
                this.olvStartDate,
                this.olvFinishDate,
                this.olvExectutionDate,
                this.olvMaintenancePlan,
                this.olvMaintenanceItem});

                this.oblwSearch.PrimarySortColumn = this.olvCriticality;
                this.oblwSearch.Sorting = SortOrder.Descending;
            }
            else
            {
                this.oblwSearch.AllColumns.Add(this.olvNbsAnalysis);
                this.oblwSearch.AllColumns.Add(this.olvNbs);
                this.oblwSearch.AllColumns.Add(this.olvWorkCenter);
                this.oblwSearch.AllColumns.Add(this.olvWorkSpace);
                this.oblwSearch.AllColumns.Add(this.olvPreparator);
                this.oblwSearch.AllColumns.Add(this.olvFuncLocation);
                this.oblwSearch.AllColumns.Add(this.olvCriticality);
                this.oblwSearch.AllColumns.Add(this.olvOrderShortDesc);
                this.oblwSearch.AllColumns.Add(this.olvMaintenanceItem);
                this.oblwSearch.AllColumns.Add(this.olvCreateBy);
                this.oblwSearch.AllColumns.Add(this.olvActivity);
                this.oblwSearch.AllColumns.Add(this.olvCreationDate);

                this.oblwSearch.Columns.AddRange(new ColumnHeader[] {
                this.olvNbsAnalysis,
                this.olvNbs,
                this.olvActivity,
                this.olvCriticality,
                this.olvFuncLocation,
                this.olvWorkCenter,
                this.olvWorkSpace,
                this.olvPreparator,
                this.olvMaintenanceItem,
                this.olvOrderShortDesc,
                this.olvCreateBy,
                this.olvCreationDate});

                this.oblwSearch.PrimarySortColumn = this.olvNbsAnalysis;
                this.oblwSearch.Sorting = SortOrder.Ascending;
            }

            this.olvNbs.Hyperlink = true;
        }

        /// <summary>
        /// Ajoute les différents text (risque, helper, helperDesc)
        /// </summary>
        /// <param name="CriticalityId"></param>
        /// <param name="Label"></param>
        /// <param name="CriticalityRisk"></param>
        /// <param name="CriticalityHelper"></param>
        private void LabelSetName(int CriticalityId, Label Label, RichTextBox CriticalityRisk, TextBox CriticalityHelper)
        {
            CriticalityHelper.ReadOnly = true;

            ADR_Criticality Criticality;

            using (CriticalityRepository CriticalityRepository = new CriticalityRepository())
            {
                Criticality = CriticalityRepository.Get(CriticalityId);
            }

            ADR_Criticality_Helper CriticalityHepler;

            using (CriticalityHelperRepository CriticalityHelperRepository = new CriticalityHelperRepository())
            {
                CriticalityHepler = CriticalityHelperRepository.Get(Criticality.CriticalityHelperId);
            }

            ADR_Criticality_Helper_Parameters CriticalityHelperParameter;

            using (CriticalityHelperParametersRepository CriticalityHelperParametersRepository = new CriticalityHelperParametersRepository())
            {
                CriticalityHelperParameter = CriticalityHelperParametersRepository.Get(CriticalityHepler.DescriptionId);
            }

            CriticalityRisk.Text = Criticality.ItemText;
            CriticalityRisk.Tag = CriticalityId;
            CriticalityHelper.Text = CriticalityHepler.ItemText;

            Label.Text = CriticalityHelperParameter.ItemText;
        }

        /// <summary>
        /// Si l'ordre ou l'analyse ont une criticité inférieur ou égale à 2, alors les panneaux de criticité supérieur disparaissent.
        /// </summary>
        /// <param name="IsVisible">Visible ou non</param>
        private void DisabledPanelCriticality(bool IsVisible)
        {
            criticalityRisk1.Visible = IsVisible;
            criticalityRisk2.Visible = IsVisible;
            criticalityRisk3.Visible = IsVisible;
            criticalityRisk4.Visible = IsVisible;

            criticalityHelper1.Visible = IsVisible;
            criticalityHelper2.Visible = IsVisible;
            criticalityHelper3.Visible = IsVisible;
            criticalityHelper4.Visible = IsVisible;

            lblCriticalityHelper1.Visible = IsVisible;
            lblCriticalityHelper2.Visible = IsVisible;
            lblCriticalityHelper3.Visible = IsVisible;
            lblCriticalityHelper4.Visible = IsVisible;

            cblblRisk1.Visible = IsVisible;
            cblblRisk2.Visible = IsVisible;
            cblblRisk3.Visible = IsVisible;
            cblblRisk4.Visible = IsVisible;

            CbRisk1.Visible = IsVisible;
            CbRisk2.Visible = IsVisible;
            CbRisk3.Visible = IsVisible;
            CbRisk4.Visible = IsVisible;

            panelHide.Visible = IsVisible;

            rtxtMesureParade1.Enabled = IsVisible;
            rtxtMesureParade2.Enabled = IsVisible;
            rtxtMesureParade3.Enabled = IsVisible;
            rtxtMesureParade4.Enabled = IsVisible;

            MovePanelCriticality(IsVisible);
        }

        /// <summary>
        /// Déplace les panneaux de criticité en fonction de la visibilité
        /// </summary>
        /// <param name="IsVisible">Visible ou non</param>
        private void MovePanelCriticality(bool IsVisible)
        {
            if (IsVisible)
            {
                criticalityRisk5.Location = new Point(criticalityRisk4.Location.X, criticalityRisk4.Location.Y + (criticalityRisk4.Height + 7));
                criticalityHelper5.Location = new Point(criticalityHelper4.Location.X, criticalityHelper4.Location.Y + (criticalityHelper4.Height + 7));
                lblCriticalityHelper5.Location = new Point(lblCriticalityHelper4.Location.X, lblCriticalityHelper4.Location.Y + (lblCriticalityHelper4.Height + 7));
                cblblRisk5.Location = new Point(cblblRisk4.Location.X, cblblRisk4.Location.Y + (cblblRisk4.Height + 176));
                CbRisk5.Location = new Point(CbRisk4.Location.X, CbRisk4.Location.Y + (CbRisk4.Height + 192));

                criticalityRisk6.Location = new Point(criticalityRisk5.Location.X, criticalityRisk5.Location.Y + (criticalityRisk5.Height + 7));
                criticalityHelper6.Location = new Point(criticalityHelper5.Location.X, criticalityHelper5.Location.Y + (criticalityHelper5.Height + 7));
                lblCriticalityHelper6.Location = new Point(lblCriticalityHelper5.Location.X, lblCriticalityHelper5.Location.Y + (lblCriticalityHelper5.Height + 7));
                cblblRisk6.Location = new Point(cblblRisk5.Location.X, cblblRisk5.Location.Y + (cblblRisk5.Height + 176));
                CbRisk6.Location = new Point(CbRisk5.Location.X, CbRisk5.Location.Y + (CbRisk5.Height + 192));
            }
            else
            {
                criticalityRisk5.Location = criticalityRisk1.Location;
                criticalityHelper5.Location = criticalityHelper1.Location;
                lblCriticalityHelper5.Location = lblCriticalityHelper1.Location;
                cblblRisk5.Location = cblblRisk1.Location;
                CbRisk5.Location = CbRisk1.Location;

                criticalityRisk6.Location = criticalityRisk2.Location;
                criticalityHelper6.Location = criticalityHelper2.Location;
                lblCriticalityHelper6.Location = lblCriticalityHelper2.Location;
                cblblRisk6.Location = cblblRisk2.Location;
                CbRisk6.Location = CbRisk2.Location;
            }

            gbAnalyse.Refresh();
        }

        /// <summary>
        /// Charge les différentes images
        /// </summary>
        private void LoadImage()
        {
            pbLogoEngie.BackgroundImage = Properties.Resources.logo_Engie;
            pbLogoEngie.BackgroundImageLayout = ImageLayout.Stretch;
            pbSearch.BackgroundImage = Properties.Resources.Search;
            pbSearch.BackgroundImageLayout = ImageLayout.Stretch;
            pbFilter.BackgroundImage = Properties.Resources.Filter;
            pbFilter.BackgroundImageLayout = ImageLayout.Stretch;
            pbSearchModel.BackgroundImage = Properties.Resources.Search;
            pbSearchModel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Charge les mesures et parades prédéfini en fonction des sections et de l'utilisateur
        /// </summary>
        private void LoadMesureAndParade()
        {
            SetMesureAndParade(cbMesureParade1, 1);
            SetMesureAndParade(cbMesureParade2, 2);
            SetMesureAndParade(cbMesureParade3, 3);
            SetMesureAndParade(cbMesureParade4, 4);
            SetMesureAndParade(cbMesureParade5, 5);
            SetMesureAndParade(cbMesureParade6, 6);
        }

        /// <summary>
        /// Defini les mesures et parade dans les combobox
        /// </summary>
        private void SetMesureAndParade(ComboBox ComboBox, int RiskId)
        {
            ComboBox.DataSource = GetMesureAndParade(RiskId);
            ComboBox.DisplayMember = "ItemText";
            ComboBox.ValueMember = "Id";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkCenter"></param>
        /// <returns></returns>
        private IEnumerable<ADR_Criticality_MesureParade> GetMesureAndParade(int RiskId)
        {
            List<ADR_Criticality_MesureParade> MesuresAndParades = new List<ADR_Criticality_MesureParade>();

            MesuresAndParades.Add(new ADR_Criticality_MesureParade() { ItemText = null });

            using (MesureAndParadeRepository MesureAndParadeRepository = new MesureAndParadeRepository())
            {
                MesuresAndParades.AddRange(MesureAndParadeRepository.GetById(RiskId).Where((mp) => !mp.IsDisabled && mp.WorkCenterId == WorkCenter.Id));
            }

            return MesuresAndParades;
        }

        /// <summary>
        /// Défini le titre en fonction de la criticité
        /// </summary>
        /// <param name="Criticality"></param>
        private void SetTitleCriticality(int Criticality)
        {
            nCriticality.Value = Criticality;

            switch (Criticality)
            {
                case 4:
                case 3:
                    DisabledPanelCriticality(true);
                    break;
                case 2:
                case 1:
                    DisabledPanelCriticality(false);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Charge les information d'une analyse éffectué
        /// </summary>
        /// <param name="ParameterId"></param>
        private void GetAnalysisCriticality(int AnalysisId)
        {
            List<ADR_Analysis_Parameters> AnalysisParametersBl = new List<ADR_Analysis_Parameters>();

            using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
            {
                AnalysisParametersBl.AddRange(AnalysisParametersRepository.GetByAnalysis(AnalysisId));
            }

            foreach (ADR_Analysis_Parameters parameter in AnalysisParametersBl)
            {
                switch (parameter.OrderCrit)
                {
                    case 1:
                        SetCriticalityAnalysis(txtCriticalityRisk1, txtCriticalityHelper1, lblCriticalityHelper1, rtxtMesureParade1, CbRisk1, parameter);
                        break;
                    case 2:
                        SetCriticalityAnalysis(txtCriticalityRisk2, txtCriticalityHelper2, lblCriticalityHelper2, rtxtMesureParade2, CbRisk2, parameter);
                        break;
                    case 3:
                        SetCriticalityAnalysis(txtCriticalityRisk3, txtCriticalityHelper3, lblCriticalityHelper3, rtxtMesureParade3, CbRisk3, parameter);
                        break;
                    case 4:
                        SetCriticalityAnalysis(txtCriticalityRisk4, txtCriticalityHelper4, lblCriticalityHelper4, rtxtMesureParade4, CbRisk4, parameter);
                        break;
                    case 5:
                        SetCriticalityAnalysis(txtCriticalityRisk5, txtCriticalityHelper5, lblCriticalityHelper5, rtxtMesureParade5, CbRisk5, parameter);
                        break;
                    case 6:
                        SetCriticalityAnalysis(txtCriticalityRisk6, txtCriticalityHelper6, lblCriticalityHelper6, rtxtMesureParade6, CbRisk6, parameter);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Defini les risques.
        /// </summary>
        /// <param name="TxtRisk"></param>
        /// <param name="TxtHelper"></param>
        /// <param name="LblRisk"></param>
        /// <param name="RtxMesureParade"></param>
        /// <param name="Na"></param>
        /// <param name="AnalyseParameters"></param>
        private void SetCriticalityAnalysis(RichTextBox TxtRisk, TextBox TxtHelper, OrientedTextLabel LblRisk, RichTextBox RtxMesureParade, CheckBox Na, ADR_Analysis_Parameters AnalyseParameters)
        {
            ADR_Criticality CriticalityBl;

            using (CriticalityRepository CriticalityRepository = new CriticalityRepository())
            {
                CriticalityBl = CriticalityRepository.Get(AnalyseParameters.CriticalityId);
            }

            ADR_Criticality_Helper CriticalityHelperBl;

            using (CriticalityHelperRepository CriticalityHelperRepository = new CriticalityHelperRepository())
            {
                CriticalityHelperBl = CriticalityHelperRepository.Get(CriticalityBl.CriticalityHelperId);
            }

            ADR_Criticality_Helper_Parameters CriticalityHelperParametersBl;

            using (CriticalityHelperParametersRepository CriticalityHelperParametersRepository = new CriticalityHelperParametersRepository())
            {
                CriticalityHelperParametersBl = CriticalityHelperParametersRepository.Get(CriticalityHelperBl.DescriptionId);
            }

            TxtRisk.Text = CriticalityBl.ItemText;
            TxtHelper.Text = CriticalityHelperBl.ItemText;
            LblRisk.Text = CriticalityHelperParametersBl.ItemText;

            if (!AnalyseParameters.IsNA)
            {
                if (AnalyseParameters.ParameterText.Contains('|'))
                {
                    string[] Split = AnalyseParameters.ParameterText.Split('|');

                    txtDurationRisk1.Text = Split[0].Trim();
                    RtxMesureParade.Text = Split[1].Trim();
                }
                else
                {
                    RtxMesureParade.Text = AnalyseParameters.ParameterText.Trim();
                }
            }
            else
            {
                Na.Checked = AnalyseParameters.IsNA;
                DefineRiskNA(TxtRisk, AnalyseParameters.OrderCrit, !AnalyseParameters.IsNA);
            }
        }

        private void Btn_EnabledChanged(object sender, EventArgs e)
        {
            ADRHelper.ChangeColorDiabled((Button)sender);
        }

        #endregion

        #region Event

        /// <summary>
        /// Change les nom de collone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbValueSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            SetColumnHeaderOblw();
            tbNbrSearch.Text = null;
            ResetAll();

            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                btnStartAnalyse.Text = "Commencer l'analyse";
                btnLoadModel.Visible = true;
                btnCreateOrder.Visible = true;
                SetReadonly(false);
                lblSearchType.Text = "Rechercher un ordre";
            }
            else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
            {
                btnStartAnalyse.Text = "Modifier l'analyse";
                btnLoadModel.Visible = false;
                btnCreateOrder.Visible = false;
                SetReadonly(false);
                lblSearchType.Text = "Rechercher une analyse";
            }
            else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Read)
            {
                btnStartAnalyse.Text = "Visualiser une analyse";
                btnLoadModel.Visible = false;
                btnCreateOrder.Visible = false;
                btnSave.Enabled = false;
                SetReadonly(true);
                lblSearchType.Text = "Rechercher une analyse";
            }
        }

        /// <summary>
        /// Change l'affichage de l'analyse en fonction de la criticité sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nCriticality_ValueChanged(object sender, EventArgs e)
        {
            if (nCriticality.Value >= 3)
                DisabledPanelCriticality(true);
            else if (nCriticality.Value <= 2)
                DisabledPanelCriticality(false);
        }

        /// <summary>
        /// Check si l'utilisateur à bien choisis un ordre ou une analyse
        /// Save = Création analyse, Modify = Modification analyse, Read = Lecture analyse 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oblwSearch_Click(object sender, EventArgs e)
        {
            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                var Orders = oblwSearch.SelectedObjects;

                if (Orders != null && Orders.Count != 0)
                {
                    btnStartAnalyse.Enabled = true;
                }
                else
                {
                    btnStartAnalyse.Enabled = false;
                }
            }
            else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
            {
                ADR_Analysis_Result Analysis = (ADR_Analysis_Result)oblwSearch.SelectedObject;
                if (Analysis != null)
                {
                    btnStartAnalyse.Enabled = true;
                }
                else
                {
                    btnStartAnalyse.Enabled = false;
                }
            }
            else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Read)
            {
                ADR_Analysis_Result Analysis = (ADR_Analysis_Result)oblwSearch.SelectedObject;
                if (Analysis != null)
                {
                    btnStartAnalyse.Enabled = true;
                }
                else
                {
                    btnStartAnalyse.Enabled = false;
                }
            }
            else
            {
                btnStartAnalyse.Enabled = false;
                btnCreateOrder.Enabled = true;
            }
        }

        /// <summary>
        /// Event clique boutton search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerarch_Click(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Recherche en cours, merci de patienter.");

            CurrentSearch = tbNbrSearch.Text;

            SearchOrdersAnalysis();

            FrmWait.CloseForm();
        }

        /// <summary>
        /// Event clique recherche le model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchModel_Click(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Recherche d'un model en cours.");

            if (string.IsNullOrWhiteSpace(txtModel.Text))
                AnalysisResultsBlModels = GetAnalyses();
            else
                AnalysisResultsBlModels = GetAnalyses(txtModel.Text);
            oblvModel.SetObjects(AnalysisResultsBlModels);

            txtModel.Text = null;

            FrmWait.CloseForm();
        }

        /// <summary>
        /// Permet de rechercher des Ordres ou des Analyses
        /// </summary>
        private void SearchOrdersAnalysis()
        {
            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                if (string.IsNullOrWhiteSpace(tbNbrSearch.Text))
                    SAPOrdersBl = GetOrders();
                else
                    SAPOrdersBl = GetOrders(tbNbrSearch.Text);
                oblwSearch.SetObjects(SAPOrdersBl);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbNbrSearch.Text))
                    AnalysisResultsBl = GetAnalyses();
                else
                    AnalysisResultsBl = GetAnalyses(tbNbrSearch.Text);
                oblwSearch.SetObjects(AnalysisResultsBl);
            }
        }

        /// <summary>
        /// Evenement touche enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNbrSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSerarch_Click(sender, e);
        }

        /// <summary>
        /// Préremplis la recherche d'orders ou d'analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNbrSearch_TextChanged(object sender, EventArgs e)
        {
            IsAssistantSearch = true;
            TypeAssistant.TextChanged();
        }

        /// <summary>
        /// Evenement touche enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchModel_Click(sender, e);
        }

        /// <summary>
        /// Préremplis la recherche de model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            IsAssistantSearchModel = true;
            TypeAssistant.TextChanged();
        }

        /// <summary>
        /// Charge les informations de criticité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartAnalyse(object sender, EventArgs e)
        {
            if (WorkCenter.WorkCenter != "*")
            {
                FrmWait.ShowWatingForms("Chargement de l'analyse en cours, merci de patienter.");

                ResetAll();
                GestionActive(true);
                IsNotSave = true;

                if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
                {
                    if (oblwSearch.SelectedObjects.Count > 1)
                    {
                        IsMulti = true;
                        int Criticality = 0;
                        toolTipFunc.Active = true;
                        toolTipDesc.Active = true;
                        toolTipOrders.Active = true;
                        string FuncLocation = null;
                        string Order = null;
                        string Desc = null;

                        foreach (ADR_SAPOrders item in oblwSearch.SelectedObjects)
                        {
                            SAPOrdersBlMulti.Add(item);
                            FuncLocation += $"{item.FuncLocation} \n";
                            Desc += $"{item.OrderShortDesc} \n";
                            Order += $"{item.OrderNbs} \n";

                            if (Criticality < item.Criticality)
                                Criticality = item.Criticality;
                        }

                        toolTipFunc.SetToolTip(lblMaintanceItem, FuncLocation);
                        toolTipDesc.SetToolTip(lblShortDesc, Desc);
                        toolTipOrders.SetToolTip(txtOrders, Order);

                        LoadMesureAndParade();
                        LoadCriticalityHelperName();
                        SetTitleCriticality(Criticality);
                        lblShortDesc.Text = "Sélection multiple";
                        txtOrders.Text += "Sélection multiple";
                        lblMaintanceItem.Text = "Sélection multiple";
                    }
                    else if (IsCreate)
                    {
                        LoadMesureAndParade();
                        LoadCriticalityHelperName();
                        SetTitleCriticality(4);
                        lblMaintanceItem.ReadOnly = false;
                        lblShortDesc.ReadOnly = false;
                        txtOrders.ReadOnly = false;
                        nCriticality.Enabled = true;
                    }
                    else
                    {
                        IsMulti = false;

                        SAPOrderBlCurrency = (ADR_SAPOrders)oblwSearch.SelectedObject;

                        if (SAPOrderBlCurrency != null)
                        {
                            txtOrders.Text = SAPOrderBlCurrency.OrderNbs;
                            lblShortDesc.Text = SAPOrderBlCurrency.OrderShortDesc;
                            lblMaintanceItem.Text = SAPOrderBlCurrency.FuncLocation;
                            LoadMesureAndParade();
                            LoadCriticalityHelperName();
                            SetTitleCriticality(SAPOrderBlCurrency.Criticality);
                        }
                    }

                    gbAnalyse.Visible = true;
                    btnLoadModel.Enabled = true;
                }
                else
                {
                    AnalysisResultBlCurrency = (ADR_Analysis_Result)oblwSearch.SelectedObject;

                    if (AnalysisResultBlCurrency != null)
                    {
                        txtActivity.Text = AnalysisResultBlCurrency.Activity;
                        txtOrders.Text = AnalysisResultBlCurrency.OrderNbs;
                        lblShortDesc.Text = AnalysisResultBlCurrency.OrderShortDesc;
                        lblMaintanceItem.Text = AnalysisResultBlCurrency.FuncLocation;
                        SetTitleCriticality(AnalysisResultBlCurrency.Criticality);
                        LoadAnalysisResult(AnalysisResultBlCurrency.Id);
                        lblMaintanceItem.ReadOnly = true;
                        lblShortDesc.ReadOnly = false;
                        nCriticality.Enabled = false;
                        txtOrders.ReadOnly = true;
                        gbAnalyse.Visible = true;

                        if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
                            LoadMesureAndParade();

                        if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Read)
                        {
                            IsNotSave = false;
                            btnSave.Enabled = false;
                            btnPrint.Enabled = true;
                            nCriticality.Enabled = false;
                            btnLoadInPlan.Enabled = !string.IsNullOrEmpty(AnalysisResultBlCurrency.MaintencaneItem);
                            btnLoadintoOrder.Enabled = true;
                        }
                    }
                }

                FrmWait.CloseForm();
            }
            else
            {
                GeneratError("La section * ne peut pas créer d'analyse");
            }
        }

        /// <summary>
        /// Charge les informations du model dans l'analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModel(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Ajout du model, merci de patienter.");

            AnalysisResultBlModel = (ADR_Analysis_Result)oblvModel.SelectedObject;

            if (AnalysisResultBlModel != null)
            {
                txtActivity.Text = AnalysisResultBlModel.Activity;
                LoadAnalysisResult(AnalysisResultBlModel.Id);
            }

            FrmWait.CloseForm();
        }

        /// <summary>
        /// Défini le risque en N/A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxChecked(object sender, EventArgs e)
        {
            CheckBox CheckBox = (CheckBox)sender;

            switch (CheckBox.Name.Substring(CheckBox.Name.Length - 1, 1))
            {
                case "1":
                    DefineRiskNA(txtCriticalityRisk1, 1, !CheckBox.Checked);
                    break;
                case "2":
                    DefineRiskNA(txtCriticalityRisk2, 2, !CheckBox.Checked);
                    break;
                case "3":
                    DefineRiskNA(txtCriticalityRisk3, 3, !CheckBox.Checked);
                    break;
                case "4":
                    DefineRiskNA(txtCriticalityRisk4, 4, !CheckBox.Checked);
                    break;
                case "5":
                    DefineRiskNA(txtCriticalityRisk5, 5, !CheckBox.Checked);
                    break;
                case "6":
                    DefineRiskNA(txtCriticalityRisk6, 6, !CheckBox.Checked);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Défini le risque voulus en NA
        /// </summary>
        private void DefineRiskNA(RichTextBox TextBox, int Nbs, bool IsEnable)
        {
            switch (Nbs)
            {
                case 1:
                    txtCriticalityHelper1.Enabled = IsEnable;
                    rtxtMesureParade1.Enabled = IsEnable;
                    rtxtMesureParade1.Text = null;
                    cbMesureParade1.Enabled = IsEnable;
                    txtDurationRisk1.Enabled = IsEnable;
                    cblblRisk1.Enabled = IsEnable;
                    break;
                case 2:
                    txtCriticalityHelper2.Enabled = IsEnable;
                    rtxtMesureParade2.Enabled = IsEnable;
                    rtxtMesureParade2.Text = null;
                    cbMesureParade2.Enabled = IsEnable;
                    cblblRisk2.Enabled = IsEnable;
                    break;
                case 3:
                    txtCriticalityHelper3.Enabled = IsEnable;
                    rtxtMesureParade3.Enabled = IsEnable;
                    rtxtMesureParade3.Text = null;
                    cbMesureParade3.Enabled = IsEnable;
                    cblblRisk3.Enabled = IsEnable;
                    break;
                case 4:
                    txtCriticalityHelper4.Enabled = IsEnable;
                    rtxtMesureParade4.Enabled = IsEnable;
                    rtxtMesureParade4.Text = null;
                    cbMesureParade4.Enabled = IsEnable;
                    cblblRisk4.Enabled = IsEnable;
                    break;
                case 5:
                    txtCriticalityHelper5.Enabled = IsEnable;
                    rtxtMesureParade5.Enabled = IsEnable;
                    rtxtMesureParade5.Text = null;
                    cbMesureParade5.Enabled = IsEnable;
                    cblblRisk5.Enabled = IsEnable;
                    break;
                case 6:
                    txtCriticalityHelper6.Enabled = IsEnable;
                    rtxtMesureParade6.Enabled = IsEnable;
                    rtxtMesureParade6.Text = null;
                    cbMesureParade6.Enabled = IsEnable;
                    cblblRisk6.Enabled = IsEnable;
                    break;
                default:
                    break;
            }

            if (IsEnable)
                TextBox.Font = new System.Drawing.Font(TextBox.Font, FontStyle.Regular);
            else
                TextBox.Font = new System.Drawing.Font(TextBox.Font, FontStyle.Strikeout);

            this.Refresh();
        }

        /// <summary>
        /// Sauvegarder une analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsScuccess = false;

                if (CheckIfAnalysisIsComplete())
                {
                    FrmWait.ShowWatingForms("Sauvegarde de l'analyse en cours, merci de patienter.");

                    if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
                    {
                        if (IsMulti)
                        {
                            foreach (ADR_SAPOrders order in SAPOrdersBlMulti)
                            {
                                IsScuccess = SaveAnalyse(order);
                                GenerateHistorique.CreateHistorique(FormUser.UserID, $"Sauvegarde d'une analyse, ordre {order.OrderNbs}", "Création");
                            }

                            if (IsScuccess)
                                AnalysisSuccess();
                        }
                        else
                        {
                            if (IsCreate)
                                SAPOrderBlCurrency = CreateOrder();

                            IsScuccess = SaveAnalyse(SAPOrderBlCurrency);
                            btnLoadInPlan.Enabled = !string.IsNullOrEmpty(SAPOrderBlCurrency.MaintencaneItem);

                            GenerateHistorique.CreateHistorique(FormUser.UserID, $"Sauvegarde d'une analyse, ordre {SAPOrderBlCurrency.OrderNbs}", "Création");

                            if (IsScuccess)
                                AnalysisSuccess();

                        }
                    }
                    else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
                    {
                        IsScuccess = UpdateAnalyse();
                        btnLoadInPlan.Enabled = !string.IsNullOrEmpty(AnalysisResultBlCurrency.MaintencaneItem);
                        GenerateHistorique.CreateHistorique(FormUser.UserID, $"Mise à jour de l'analyse, ordre {AnalysisResultBlCurrency.AnalysisNbs}", "Update");

                        if (IsScuccess)
                            AnalysisSuccess();
                    }

                    FrmWait.CloseForm();
                }
                else
                {
                    GeneratError($"Attention tout les champs ne sont pas remplis");
                }
            }
            catch (Exception ex)
            {
                FrmWait.CloseForm();
                GeneratError(ex.InnerException.ToString());
            }
        }

        /// <summary>
        /// Ajoute la valeur sélectionné dans la textbox mesure et parde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMesureParade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ComboBox = (ComboBox)sender;
            AddMesureAndParade(ComboBox, (ADR_Criticality_MesureParade)ComboBox.SelectedItem);
        }

        /// <summary>
        /// Ajoute la mesure/parade selectionner dans la textbox
        /// </summary>
        /// <param name="ComboBox"></param>
        /// <param name="WorkCenterParams"></param>
        private void AddMesureAndParade(ComboBox ComboBox, ADR_Criticality_MesureParade ADRMesureParde)
        {
            if (!string.IsNullOrEmpty(ADRMesureParde.ItemText))
            {
                foreach (Control control in ComboBox.Parent.Controls)
                {
                    if (control is RichTextBox && control.Name.Contains("rtxtMesureParade"))
                    {
                        RichTextBox rtxtb = (RichTextBox)control;
                        if (!string.IsNullOrEmpty(rtxtb.Text))
                            rtxtb.Text += $" {ADRMesureParde.ItemText}";
                        else
                            rtxtb.Text += $"{ADRMesureParde.ItemText}";
                    }
                }
            }
        }

        /// <summary>
        /// Evenement pour charger un model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            lblSeacrhTypeModel.Visible = true;
            txtModel.Visible = true;
            oblvModel.Visible = true;
            btnAddModel.Visible = true;
            btnSearchModel.Visible = true;
            pbSearchModel.Visible = true;
            oblwSearch.Size = new Size(oblwSearch.Width, 157);
            IsModel = true;
        }

        /// <summary>
        /// Génère un pdf et l'imprime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CheckIfAnalysisIsComplete())
            {
                FrmWait.ShowWatingForms("Impression de l'analyse en cours, merci de patienter.");

                if (!IsMulti)
                {
                    ADR_SAPOrders SAPOrderResult;

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        SAPOrderResult = SAPOrdersRepository.GetByOrderNbs(txtOrders.Text);
                    }

                    CreatePdf(SAPOrderResult);
                    StartPrint();
                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Impression", $"Analyse {SAPOrderResult.OrderNbs}");
                }
                else
                {
                    string OrderHistorique = "";

                    foreach (ADR_SAPOrders order in SAPOrdersBlMulti)
                    {
                        CreatePdf(order);
                        StartPrint();
                        OrderHistorique += $"{order.OrderNbs}, ";
                    }

                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Impressions", $"Analyses {OrderHistorique}");
                }

                FrmWait.CloseForm();

                GeneratError("Le(s) document(s) ont bien été envoyés à l'imprimante");
            }
            else
            {
                GeneratError($"Attention tout les champs ne sont pas remplis");
            }

        }

        /// <summary>
        /// Refresh les ordres depuis sap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkCenter.WorkCenter != "*")
                {
                    string Status;

                    using (ParamterRepository ParamterRepository = new ParamterRepository())
                    {
                        Status = ParamterRepository.GetValue("OrderStatus");
                    }

                    FrmWait.ShowWatingForms($"Rafraîchissement des ordres (SAP) en cours ({Status}), merci de patienter.");
                    Cursor.Current = Cursors.WaitCursor;
                    PMADRServices PMService = new PMADRServices();

                    List<ADR_SAPOrders> SapOrder = new List<ADR_SAPOrders>();

                    for (int i = 2; i != 5; i++)
                    {
                        SapOrder.AddRange(PMService.GetOrders(WorkCenter.WorkCenter, i.ToString()));
                    }

                    AddOrderDB(SapOrder);
                    PopulateOrderList();
                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Refresh des ordres avec le web service", $"Refresh Order WorkCenter {WorkCenter.WorkCenter}");

                    btnSerarch_Click(null, null);
                    Cursor.Current = Cursors.Default;

                    if (SAPExclude.Count > 0 || SAPSave.Count > 0)
                    {
                        FrmImportSap FrmImportSap = new FrmImportSap(SAPSave, SAPExclude);
                        FrmImportSap.ShowDialog();
                    }
                    else
                    {
                        GeneratError("Aucun ordre importé en base de donnée");
                    }
                }
                else
                {
                    GeneratError($"la Section {WorkCenter.WorkCenter} n'est pas valide");
                }
            }
            catch (Exception ex)
            {
                GeneratError(ex.ToString());
            }
        }

        /// <summary>
        /// Ajoute l'analyse dans le plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadInPlan_Click(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Chargment de l'analyse dans le plan de maintenance (SAP), merci de patienter.");

            string Message;
            string MessageNotOk = string.Empty;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                PMADRServices PMService = new PMADRServices();

                if (!IsMulti)
                {
                    ADR_SAPOrders SAPOrderResult;

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        SAPOrderResult = SAPOrdersRepository.GetByOrderNbs(txtOrders.Text);
                    }

                    if (!string.IsNullOrEmpty(SAPOrderResult.MaintencaneItem))
                    {
                        Dictionary<string, string> RisqueAndValue = new Dictionary<string, string>();

                        CreatePdf(SAPOrderResult, RisqueAndValue, SAPOrderResult.MaintencaneItem);

                        PMService.AddAttachementToPlan(FormUser.UserID.Substring(5, 6), SAPOrderResult.MaintencaneItem, SAPOrderResult.Criticality.ToString(), RisqueAndValue);
                        Message = $"L'analyse de risque pour l'ordre {txtOrders.Text} à bien été charger dans le plan de maintenance {SAPOrderResult.MaintenancePlant} - {SAPOrderResult.MaintencaneItem} (criticité {SAPOrderResult.Criticality}) (SAP)";

                        //using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                        //{
                        //    ADR_Analysis_Result AResult = AnalysisResultRepositoty.GetByAnalysisNbs(SAPOrderResult.AnalysisNbs);
                        //    AResult.AnalysisInPlan = true;
                        //    AnalysisResultRepositoty.Update(AResult);
                        //}

                        GenerateHistorique.CreateHistorique(FormUser.UserID, $"Charge le pdf dans dans le plan de maintenance", $"Load pdf into maitenance plan {SAPOrderResult.MaintenancePlant} - {SAPOrderResult.MaintencaneItem} (criticality {SAPOrderResult.Criticality}) for the order {txtOrders.Text} (SAP)");
                    }
                    else
                    {
                        Message = $"Le plan de maintenance de l'ordre {txtOrders.Text} est null";
                    }
                }
                else
                {
                    string Orders = string.Empty;
                    string OrdersNotOk = string.Empty;

                    foreach (ADR_SAPOrders order in SAPOrdersBlMulti)
                    {
                        if (!string.IsNullOrEmpty(order.MaintencaneItem))
                        {
                            Dictionary<string, string> RisqueAndValue = new Dictionary<string, string>();

                            CreatePdf(order, RisqueAndValue, order.MaintencaneItem);

                            PMService.AddAttachementToPlan(FormUser.UserID.Substring(5, 6), order.MaintenancePlant, order.Criticality.ToString(), RisqueAndValue);

                            Orders += $"Order : {order.OrderNbs}, Plan de maintenance : {order.MaintenancePlant}, item de maintenance : {order.MaintencaneItem}, criticité {order.Criticality} \n";

                            //using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                            //{
                            //    ADR_Analysis_Result AResult = AnalysisResultRepositoty.GetByAnalysisNbs(order.AnalysisNbs);
                            //    AResult.AnalysisInPlan = true;
                            //    AnalysisResultRepositoty.Update(AResult);
                            //}

                            GenerateHistorique.CreateHistorique(FormUser.UserID, "Charge les pdf dans le plan de maintenance", $"Load pdf into Plan Maintenance Item {order.OrderNbs} - {WorkCenter.WorkCenter} - {order.MaintenancePlant} - {order.MaintencaneItem} - {order.Criticality}");
                        }
                        else
                        {
                            OrdersNotOk += $"Order : {order.OrderNbs}, Plan de maintenance : {order.MaintenancePlant}, item de maintenance : {order.MaintencaneItem}, criticité {order.Criticality} \n";
                        }
                    }

                    if (!string.IsNullOrEmpty(OrdersNotOk))
                        MessageNotOk = $"Les analyses de riques suivante n'ont pas pus être charger dans leurs plans de maintenance respectifs (SAP) {OrdersNotOk}";

                    Message = $"Les analyses de riques ont bien été charger dans leurs plans de maintenance respectifs (SAP) {Orders}";
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Message = $"Erreur lors du cahrgement du/des document(s) pdf \n {ex}";
            }
            Cursor.Current = Cursors.Default;
            FrmWait.CloseForm();

            GeneratError(Message);

            if (!string.IsNullOrEmpty(MessageNotOk))
                GeneratError(MessageNotOk);
        }

        /// <summary>
        /// Ajoute l'analyse dans l'ordre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadintoOrder_Click(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Chargment de l'analyse dans l'ordre (SAP), merci de patienter.");
            string Message;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                PMADRServices PMService = new PMADRServices();

                if (!IsMulti)
                {
                    ADR_SAPOrders SAPOrderResult;

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        SAPOrderResult = SAPOrdersRepository.GetByOrderNbs(txtOrders.Text);
                    }

                    Dictionary<string, string> RisqueAndValue = new Dictionary<string, string>();

                    CreatePdf(SAPOrderResult, RisqueAndValue);

                    PMService.AddAttachementToOrder(SAPOrderResult.OrderNbs, FormUser.UserID.Substring(5, 6), SAPOrderResult.Criticality, RisqueAndValue);

                    Message = $"Le document pdf pour l'ordre {SAPOrderResult.OrderNbs} à bien été charger dans l'ordre (SAP)";

                    //using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                    //{
                    //    ADR_Analysis_Result AResult = AnalysisResultRepositoty.GetByAnalysisNbs(SAPOrderResult.AnalysisNbs);
                    //    AResult.AnalysisInOrder = true;
                    //    AnalysisResultRepositoty.Update(AResult);
                    //}

                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Charge le pdf dans l'ordre", $"Load pdf into order {SAPOrderResult.OrderNbs} - {WorkCenter.WorkCenter}");
                }
                else
                {
                    string Orders = string.Empty;

                    foreach (ADR_SAPOrders order in SAPOrdersBlMulti)
                    {
                        Dictionary<string, string> RisqueAndValue = new Dictionary<string, string>();

                        CreatePdf(order, RisqueAndValue);

                        PMService.AddAttachementToOrder(order.OrderNbs, FormUser.UserID.Substring(5, 6), order.Criticality, RisqueAndValue);

                        Orders += $"{order.OrderNbs}, ";

                        //using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                        //{
                        //    ADR_Analysis_Result AResult = AnalysisResultRepositoty.GetByAnalysisNbs(order.AnalysisNbs);
                        //    AResult.AnalysisInOrder = true;
                        //    AnalysisResultRepositoty.Update(AResult);
                        //}

                        GenerateHistorique.CreateHistorique(FormUser.UserID, "Charge le pdf dans l'ordre", $"Load pdf into order {order.OrderNbs} - {WorkCenter.WorkCenter}");
                    }

                    Message = $"Les documents pdf pour les ordres {Orders} ont bien été charger dans leurs ordres (SAP) respectifs";
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Message = $"Erreur lors du cahrgement du/des document(s) pdf \n {ex}";
            }

            FrmWait.CloseForm();
            Cursor.Current = Cursors.Default;

            GeneratError(Message);
        }

        /// <summary>
        /// Commence une analyse sur base d'un ordre créer à la volé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            IsCreate = true;
            btnCreateOrder.Enabled = false;
            StartAnalyse(sender, e);
        }

        /// <summary>
        /// Demande si on veut sauvegarder le travail en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnalyse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save || ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
            {
                if (CheckRiskForSave())
                {
                    if (MessageBox.Show("Voulez-vous sauvegarder l'analyse ?", "Gestion des analyses", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
                            SaveAnalyse(SAPOrderBlCurrency);
                        else if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
                            UpdateAnalyse();
                    }
                }
            }

            this.Dispose();
        }

        /// <summary>
        /// Ajoute le texte selectionne à la richtextbox en le défini en bold
        /// </summary>
        /// <param name="Rtx">La ritchtextbox à qui ajouter le text</param>
        /// <param name="Text">Le texte à ajouter</param>
        private void AppendBoldLine(RichTextBox Rtx, string Text)
        {
            int SelectionStart = Rtx.SelectionStart;
            Rtx.AppendText(Text);
            int SelectionLenght = Rtx.SelectionStart - SelectionStart + 1;

            Font bold = new Font(Rtx.Font, FontStyle.Bold);
            Rtx.Select(SelectionStart, SelectionLenght);
            Rtx.SelectionFont = bold;

            Font Regular = new Font(Rtx.Font, FontStyle.Regular);
            Rtx.Select(Rtx.Text.Length + 1, Rtx.Text.Max());
            Rtx.SelectionFont = Regular;
        }

        /// <summary>
        /// Ajoute le champ texte sélectionner au risque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCriticalityHelper_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox Selected = (TextBox)sender;

            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save || ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Modify)
            {
                if (Selected != null)
                {
                    string SelectedText = Selected.SelectedText;

                    if (!string.IsNullOrEmpty(SelectedText))
                    {
                        switch (Selected.Tag.ToString())
                        {
                            case "1":
                                if (!string.IsNullOrEmpty(rtxtMesureParade1.Text))
                                    rtxtMesureParade1.Text += "\n";
                                AppendBoldLine(rtxtMesureParade1, SelectedText);
                                break;
                            case "2":
                                if (!string.IsNullOrEmpty(rtxtMesureParade2.Text))
                                    rtxtMesureParade2.Text += "\n";
                                AppendBoldLine(rtxtMesureParade2, SelectedText);
                                break;
                            case "3":
                                if (!string.IsNullOrEmpty(rtxtMesureParade3.Text))
                                    rtxtMesureParade3.Text += "\n";
                                AppendBoldLine(rtxtMesureParade3, SelectedText);
                                break;
                            case "4":
                                if (!string.IsNullOrEmpty(rtxtMesureParade4.Text))
                                    rtxtMesureParade4.Text += "\n";
                                AppendBoldLine(rtxtMesureParade4, SelectedText);
                                break;
                            case "5":
                                if (!string.IsNullOrEmpty(rtxtMesureParade5.Text))
                                    rtxtMesureParade5.Text += "\n";
                                AppendBoldLine(rtxtMesureParade5, SelectedText);
                                break;
                            case "6":
                                if (!string.IsNullOrEmpty(rtxtMesureParade6.Text))
                                    rtxtMesureParade6.Text += "\n";
                                AppendBoldLine(rtxtMesureParade6, SelectedText);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Récupère le numéro d'ordre et l'ajoute au lien html stocké en db pour l'ouvrire dans sap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oblwSearch_HyperlinkClicked(object sender, SynapseAdvancedControls.HyperlinkClickedEventArgs e)
        {
            ObjectListView Cast = (ObjectListView)sender;
            string HyperTextSAPOrder;

            using (ParamterRepository ParamterRepository = new ParamterRepository())
            {
                HyperTextSAPOrder = ParamterRepository.GetValue("HyperTexteOrdre");
            }

            string OrderNumber = string.Empty;

            if (Cast.SelectedObject is ADR_SAPOrders)
            {
                ADR_SAPOrders CurrentOrder = (ADR_SAPOrders)Cast.SelectedObject;
                OrderNumber = CurrentOrder.OrderNbs;
            }
            else
            {
                ADR_Analysis_Result CurrentOrder = (ADR_Analysis_Result)Cast.SelectedObject;
                OrderNumber = CurrentOrder.OrderNbs;
            }

            string Link = HyperTextSAPOrder += OrderNumber;

            System.Diagnostics.Process.Start(Link);
        }

        /// <summary>
        /// Check si l'utilisateur à bien choisis une analyse comme modèle
        /// Save = Création analyse, Modify = Modification analyse, Read = Lecture analyse 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oblvModel_Click(object sender, EventArgs e)
        {
            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                ADR_Analysis_Result Analysis = (ADR_Analysis_Result)oblvModel.SelectedObject;
                if (Analysis != null)
                    btnAddModel.Enabled = true;
                else
                    btnAddModel.Enabled = false;
            }
        }

        /// <summary>
        /// Vérifie si la valeur entrée dans la textbox est un numérique ou pas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Filtre l'objectlistview des ordres ou des analyses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            IsAssistantFilter = true;
            TypeAssistant.TextChanged();
        }

        private void TypeAssistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
                if (IsAssistantFilter)
                {
                    FiltredSearch();
                    IsAssistantFilter = false;
                }
                if (IsAssistantSearch)
                {
                    SuggestSearch();
                    IsAssistantSearch = false;
                }
                if (IsAssistantSearchModel)
                {
                    SuggestSearchModel();
                    IsAssistantSearchModel = false;
                }
            }));
        }

        #endregion

        #region Utils

        /// <summary>
        /// Met à null toute les propriétées du panelScroll
        /// </summary>
        private void ResetAll()
        {
            txtActivity.Text = null;
            txtOrders.Text = null;
            txtDurationRisk1.Text = null;
            lblMaintanceItem.Text = null;
            lblShortDesc.Text = null;
            tbNbrSearch.Text = null;

            txtCriticalityRisk1.Text = null;
            txtCriticalityRisk2.Text = null;
            txtCriticalityRisk3.Text = null;
            txtCriticalityRisk4.Text = null;
            txtCriticalityRisk5.Text = null;
            txtCriticalityRisk6.Text = null;

            rtxtMesureParade1.Text = null;
            rtxtMesureParade2.Text = null;
            rtxtMesureParade3.Text = null;
            rtxtMesureParade4.Text = null;
            rtxtMesureParade5.Text = null;
            rtxtMesureParade6.Text = null;

            txtCriticalityHelper1.Text = null;
            txtCriticalityHelper2.Text = null;
            txtCriticalityHelper3.Text = null;
            txtCriticalityHelper4.Text = null;
            txtCriticalityHelper5.Text = null;
            txtCriticalityHelper6.Text = null;

            lblCriticalityHelper1.Text = null;
            lblCriticalityHelper2.Text = null;
            lblCriticalityHelper3.Text = null;
            lblCriticalityHelper4.Text = null;
            lblCriticalityHelper5.Text = null;
            lblCriticalityHelper6.Text = null;

            CbRisk1.Checked = false;
            CbRisk2.Checked = false;
            CbRisk3.Checked = false;
            CbRisk4.Checked = false;
            CbRisk5.Checked = false;
            CbRisk6.Checked = false;

            lblMaintanceItem.ReadOnly = true;
            lblShortDesc.ReadOnly = true;
            txtOrders.ReadOnly = true;

            oblwSearch.Size = new Size(oblwSearch.Width, (gbSearch.Height - oblwSearch.Location.Y) - 10);

            gbAnalyse.Visible = false;
            btnLoadModel.Enabled = false;

            lblSeacrhTypeModel.Visible = false;
            txtModel.Visible = false;
            oblvModel.Visible = false;
            btnAddModel.Visible = false;
            btnSearchModel.Visible = false;
            pbSearchModel.Visible = false;
            btnAddModel.Enabled = false;

            IsModel = false;
            btnStartAnalyse.Enabled = false;
            GestionActive(false);
            btnLoadInPlan.Enabled = false;
            btnLoadintoOrder.Enabled = false;
            btnPrint.Enabled = false;
            nCriticality.Enabled = false;
            nCriticality.Value = 0;

            toolTipFunc.Active = false;
            toolTipDesc.Active = false;
            toolTipOrders.Active = false;
        }

        /// <summary>
        /// Désactive les controlleurs du groupbox rechercher
        /// </summary>
        /// <param name="IsActive"></param>
        private void GestionActive(bool IsActive)
        {
            btnSave.Enabled = IsActive;
        }

        /// <summary>
        /// Defini les champs en readonly si on visualise une analyse
        /// </summary>
        /// <param name="IsReadOnly"></param>
        private void SetReadonly(bool IsReadOnly)
        {
            txtActivity.ReadOnly = IsReadOnly;
            txtOrders.ReadOnly = IsReadOnly;
            rtxtMesureParade1.ReadOnly = IsReadOnly;
            rtxtMesureParade2.ReadOnly = IsReadOnly;
            rtxtMesureParade3.ReadOnly = IsReadOnly;
            rtxtMesureParade4.ReadOnly = IsReadOnly;
            rtxtMesureParade5.ReadOnly = IsReadOnly;
            rtxtMesureParade6.ReadOnly = IsReadOnly;
            cbMesureParade1.Enabled = !IsReadOnly;
            cbMesureParade2.Enabled = !IsReadOnly;
            cbMesureParade3.Enabled = !IsReadOnly;
            cbMesureParade4.Enabled = !IsReadOnly;
            cbMesureParade5.Enabled = !IsReadOnly;
            cbMesureParade6.Enabled = !IsReadOnly;
            CbRisk1.Enabled = !IsReadOnly;
            CbRisk2.Enabled = !IsReadOnly;
            CbRisk3.Enabled = !IsReadOnly;
            CbRisk4.Enabled = !IsReadOnly;
            CbRisk5.Enabled = !IsReadOnly;
            CbRisk6.Enabled = !IsReadOnly;
            lblMaintanceItem.ReadOnly = IsReadOnly;
            txtDurationRisk1.ReadOnly = IsReadOnly;
            txtActivity.ReadOnly = IsReadOnly;
            txtOrders.ReadOnly = IsReadOnly;

            btnCreateOrder.Enabled = !IsReadOnly;
        }

        /// <summary>
        /// Retourne les Analyses
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ADR_Analysis_Result> GetAnalyses(string Content = null)
        {
            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                if (string.IsNullOrEmpty(Content))
                {
                    if (WorkCenter.WorkCenter != "*")
                        return AnalysisResultRepositoty.Get().Where((o) => o.WorkCenter.ToUpper().StartsWith(WorkCenter.WorkCenter.ToUpper()));
                    else
                        return AnalysisResultRepositoty.Get();
                }
                else
                {
                    if (WorkCenter.WorkCenter != "*")
                        return AnalysisResultRepositoty.GetByContent(Content.ToUpper().Trim()).Where((a) => a.WorkCenter.ToUpper().StartsWith(WorkCenter.WorkCenter.ToUpper()));
                    else
                        return AnalysisResultRepositoty.GetByContent(Content.ToUpper().Trim());
                }
            }
        }

        /// <summary>
        /// Retourne les ordres SAP
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ADR_SAPOrders> GetOrders(string Content = null)
        {
            if (string.IsNullOrEmpty(Content))
            {
                if (WorkCenter.WorkCenter != "*")
                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        return SAPOrdersRepository.Get().Where((o) => string.IsNullOrEmpty(o.AnalysisNbs) && o.WorkCenter.StartsWith(WorkCenter.WorkCenter));
                    }
                else
                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        return SAPOrdersRepository.Get().Where((o) => string.IsNullOrEmpty(o.AnalysisNbs));
                    }
            }
            else
            {
                if (WorkCenter.WorkCenter != "*")
                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        return SAPOrdersRepository.GetByContent(Content.ToUpper().Trim()).Where((o) => string.IsNullOrEmpty(o.AnalysisNbs) && o.WorkCenter.ToUpper().StartsWith(WorkCenter.WorkCenter.ToUpper())).OrderByDescending((o) => o.Criticality);
                    }
                else
                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        return SAPOrdersRepository.GetByContent(Content.ToUpper().Trim()).Where((o) => string.IsNullOrEmpty(o.AnalysisNbs)).OrderByDescending((o) => o.Criticality);
                    }
            }
        }

        /// <summary>
        /// Affiche les message avec la vue FrmMessage
        /// </summary>
        /// <param name="Message">Message à afficher</param>
        private void GeneratError(string Message)
        {
            Log.Info(Message);
            MessageBox.Show(Message);
        }

        /// <summary>
        /// Créer l'objet Analyse
        /// </summary>
        /// <param name="IsAnalyse"></param>
        /// <returns></returns>
        private ADR_Analysis_Result CreateAnalyse(ADR_SAPOrders Orders, string Activity = null)
        {

            ADR_Analysis_Result Analysis = new ADR_Analysis_Result();

            Analysis.CreationDate = DateTime.Now;
            Analysis.CreateBy = FormUser.UserID.Replace(@"CORP\", "").ToUpper();
            Analysis.OrderNbs = Orders.OrderNbs;
            Analysis.AnalysisNbs = $"AN{Orders.OrderNbs}";
            Analysis.FuncLocation = Orders.FuncLocation;
            Analysis.WorkCenter = Orders.WorkCenter;
            Analysis.MaintencaneItem = Orders.MaintencaneItem;
            Analysis.Activity = string.IsNullOrEmpty(Activity) ? txtActivity.Text : Activity;
            Analysis.Criticality = Orders.Criticality;
            Analysis.OrderShortDesc = Orders.OrderShortDesc;
            Analysis.IsManual = IsCreate;
            Analysis.Preparator = Orders.Preparator;
            Analysis.RevisionPhase = Orders.RevisionPhase;
            Analysis.Workspace = Orders.Workspace;

            if (IsModel)
                Analysis.AnalysisId = AnalysisResultBlModel.Id;

            return Analysis;
        }

        /// <summary>
        /// Update l'objet Analyse
        /// </summary>
        /// <param name="IsAnalyse"></param>
        /// <returns></returns>
        private ADR_Analysis_Result UpdateAnalyse(ADR_Analysis_Result Analysis)
        {
            Analysis.CreationDate = DateTime.Now;
            Analysis.CreateBy = FormUser.UserID;
            Analysis.Activity = txtActivity.Text;
            Analysis.Criticality = (int)nCriticality.Value;
            Analysis.FuncLocation = lblMaintanceItem.Text;
            Analysis.OrderShortDesc = lblShortDesc.Text;
            Analysis.OrderNbs = txtOrders.Text;

            return Analysis;
        }

        /// <summary>
        /// Créer les parametres de l'analyse
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ADR_Analysis_Parameters> CreateAnalyseParameters(int AnalysisId)
        {
            List<ADR_Analysis_Parameters> AnalysesParameters = new List<ADR_Analysis_Parameters>();

            //Risque 1
            if (criticalityRisk1.Visible)
            {
                ADR_Analysis_Parameters ANP1 = new ADR_Analysis_Parameters();

                if (txtCriticalityRisk1.Text.Contains("?") && !string.IsNullOrWhiteSpace(txtDurationRisk1.Text))
                {
                    ANP1.ParameterText = txtDurationRisk1.Text;
                    ANP1.ParameterText += $"| {rtxtMesureParade1.Text}";
                }
                else
                {
                    ANP1.ParameterText = rtxtMesureParade1.Text;
                }
                ANP1.OrderCrit = 1;
                ANP1.IsNA = rtxtMesureParade1.Enabled ? false : true;
                ANP1.CriticalityId = 1;
                ANP1.AnalysisId = AnalysisId;

                AnalysesParameters.Add(ANP1);
            }

            //Risque 2
            if (criticalityRisk2.Visible)
            {
                ADR_Analysis_Parameters ANP2 = new ADR_Analysis_Parameters();

                ANP2.ParameterText = rtxtMesureParade2.Text;
                ANP2.OrderCrit = 2;
                ANP2.IsNA = rtxtMesureParade2.Enabled ? false : true;
                ANP2.CriticalityId = 2;
                ANP2.AnalysisId = AnalysisId;

                AnalysesParameters.Add(ANP2);
            }

            //Risque 3
            if (criticalityRisk3.Visible)
            {
                ADR_Analysis_Parameters ANP3 = new ADR_Analysis_Parameters();

                ANP3.ParameterText = rtxtMesureParade3.Text;
                ANP3.OrderCrit = 3;
                ANP3.IsNA = rtxtMesureParade3.Enabled ? false : true;
                ANP3.CriticalityId = 3;
                ANP3.AnalysisId = AnalysisId;

                AnalysesParameters.Add(ANP3);
            }

            //Risque 4
            if (criticalityRisk4.Visible)
            {
                ADR_Analysis_Parameters ANP4 = new ADR_Analysis_Parameters();

                ANP4.ParameterText = rtxtMesureParade4.Text;
                ANP4.OrderCrit = 4;
                ANP4.IsNA = rtxtMesureParade4.Enabled ? false : true;
                ANP4.CriticalityId = 4;
                ANP4.AnalysisId = AnalysisId;

                AnalysesParameters.Add(ANP4);
            }


            //Risque 5
            ADR_Analysis_Parameters ANP5 = new ADR_Analysis_Parameters();

            ANP5.ParameterText = rtxtMesureParade5.Text;
            ANP5.OrderCrit = 5;
            ANP5.IsNA = rtxtMesureParade5.Enabled ? false : true;
            ANP5.CriticalityId = 5;
            ANP5.AnalysisId = AnalysisId;

            AnalysesParameters.Add(ANP5);

            //Risque 6
            ADR_Analysis_Parameters ANP6 = new ADR_Analysis_Parameters();

            ANP6.ParameterText = rtxtMesureParade6.Text;
            ANP6.OrderCrit = 6;
            ANP6.IsNA = rtxtMesureParade6.Enabled ? false : true;
            ANP6.CriticalityId = 6;
            ANP6.AnalysisId = AnalysisId;

            AnalysesParameters.Add(ANP6);

            return AnalysesParameters;
        }

        /// <summary>
        /// Update les parametres de l'analyse
        /// </summary>
        /// <returns></returns>
        private ADR_Analysis_Parameters UpdateAnalyseParameters(ADR_Analysis_Parameters AnalyseParameter)
        {
            switch (AnalyseParameter.OrderCrit)
            {
                case 1:
                    if (txtCriticalityRisk1.Text.Contains("?") && !string.IsNullOrWhiteSpace(txtDurationRisk1.Text))
                    {
                        AnalyseParameter.ParameterText = txtDurationRisk1.Text;
                        AnalyseParameter.ParameterText += $"| {rtxtMesureParade1.Text}";
                    }
                    else
                    {
                        AnalyseParameter.ParameterText = rtxtMesureParade1.Text;
                    }
                    AnalyseParameter.IsNA = rtxtMesureParade1.Enabled ? false : true;
                    break;
                case 2:
                    AnalyseParameter.ParameterText = rtxtMesureParade2.Text;
                    AnalyseParameter.IsNA = rtxtMesureParade2.Enabled ? false : true;
                    break;
                case 3:
                    AnalyseParameter.ParameterText = rtxtMesureParade3.Text;
                    AnalyseParameter.IsNA = rtxtMesureParade3.Enabled ? false : true;
                    break;
                case 4:
                    AnalyseParameter.ParameterText = rtxtMesureParade4.Text;
                    AnalyseParameter.IsNA = rtxtMesureParade4.Enabled ? false : true;
                    break;
                case 5:
                    AnalyseParameter.ParameterText = rtxtMesureParade5.Text;
                    AnalyseParameter.IsNA = rtxtMesureParade5.Enabled ? false : true;
                    break;
                case 6:
                    AnalyseParameter.ParameterText = rtxtMesureParade6.Text;
                    AnalyseParameter.IsNA = rtxtMesureParade6.Enabled ? false : true;
                    break;
                default:
                    break;
            }

            return AnalyseParameter;
        }

        /// <summary>
        /// Sauvegarde l'analyse en db
        /// </summary>
        /// <returns></returns>
        private bool SaveAnalyse(ADR_SAPOrders SAPOrder)
        {
            ADR_Analysis_Result Result;

            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                Result = AnalysisResultRepositoty.GetByOrderNbs(SAPOrder.OrderNbs);
            }

            if (Result == null)
            {
                ADR_SAPOrders Order;

                if (IsCreate)
                {
                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        Order = SAPOrdersRepository.GetByOrderNbs(SAPOrder.OrderNbs);
                    }

                    if (Order != null)
                    {
                        GeneratError($"L'ordre {Order.OrderNbs} existe déjà en base de donnée");
                        return false;
                    }
                }

                ADR_Analysis_Result AnalyseResultBl = CreateAnalyse(SAPOrder);

                int AnalysisInsertedId;

                using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                {
                    AnalysisInsertedId = AnalysisResultRepositoty.InsertAndReturnId(AnalyseResultBl);
                }

                if (AnalysisInsertedId != 0)
                {
                    bool AddAnalyseOrder;

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        SAPOrder.AnalysisNbs = AnalyseResultBl.AnalysisNbs;
                        if (IsCreate)
                            AddAnalyseOrder = SAPOrdersRepository.Insert(SAPOrder);
                        else
                            AddAnalyseOrder = SAPOrdersRepository.Update(SAPOrder);
                    }

                    if (AddAnalyseOrder)
                    {
                        IEnumerable<ADR_Analysis_Parameters> AnalysisParameters = CreateAnalyseParameters(AnalysisInsertedId);

                        foreach (ADR_Analysis_Parameters ap in AnalysisParameters)
                        {
                            int ParamsInserted;

                            using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                            {
                                ParamsInserted = AnalysisParametersRepository.InsertAndReturnId(ap);
                            }
                        }

                        GeneratError($"Analyse '{AnalyseResultBl.AnalysisNbs}' de l'ordre {AnalyseResultBl.OrderNbs} à bien été enregistrée.");
                        return true;
                    }
                    else
                    {
                        GeneratError($"Erreur lors de la création de l'analyse, Ordre {SAPOrder.OrderNbs}");
                    }
                }
                else
                {
                    GeneratError($"Erreur lors de la création de l'analyse, Ordre {SAPOrder.OrderNbs}");
                }
            }
            else
            {
                GeneratError($"L'analyse de l'ordre {Result.OrderNbs} existe déjà en base de donnée");
            }

            return false;
        }

        /// <summary>
        /// Modifie l'analyse en db
        /// </summary>
        /// <returns></returns>
        private bool UpdateAnalyse()
        {
            ADR_Analysis_Result AnalysisUpdate;

            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                AnalysisUpdate = UpdateAnalyse(AnalysisResultRepositoty.Get(AnalysisResultBlCurrency.Id));
            }

            if (AnalysisUpdate != (ADR_Analysis_Result)oblwSearch.SelectedObject)
            {
                bool IsUpdated;

                using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                {
                    IsUpdated = AnalysisResultRepositoty.Update(AnalysisUpdate);
                }

                if (IsUpdated)
                {
                    List<ADR_Analysis_Parameters> AnalysisParams;

                    using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                    {
                        AnalysisParams = AnalysisParametersRepository.GetByAnalysis(AnalysisUpdate.Id).ToList();
                    }

                    foreach (ADR_Analysis_Parameters result in AnalysisParams)
                    {
                        ADR_Analysis_Parameters AnalysisParam = UpdateAnalyseParameters(result);

                        using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                        {
                            AnalysisParametersRepository.Update(AnalysisParam);
                        }
                    }

                    GeneratError("Modification sauvegardée");
                    IsNotSave = false;
                    return true;
                }
                else
                {
                    GeneratError("Erreur lors de la mise à jour de l'analyse");
                }
            }
            else
            {
                GeneratError("Aucune modification n'a été effectuée");
            }

            return false;
        }

        /// <summary>
        /// Vérifie que l'analyse est complète
        /// </summary>
        /// <returns></returns>
        private bool CheckIfAnalysisIsComplete()
        {
            bool M1 = false;
            bool M2 = false;
            bool M3 = false;
            bool M4 = false;
            bool M5 = false;
            bool M6 = false;
            bool FuncLocation = false;
            bool Order = false;

            if (!string.IsNullOrEmpty(rtxtMesureParade5.Text) || CbRisk5.Checked)
                M5 = true;
            if (!string.IsNullOrEmpty(rtxtMesureParade6.Text) || CbRisk6.Checked)
                M6 = true;


            if (criticalityRisk1.Visible)
            {
                if (!string.IsNullOrEmpty(rtxtMesureParade1.Text) || CbRisk1.Checked)
                    M1 = true;
                if (!string.IsNullOrEmpty(rtxtMesureParade2.Text) || CbRisk2.Checked)
                    M2 = true;
                if (!string.IsNullOrEmpty(rtxtMesureParade3.Text) || CbRisk3.Checked)
                    M3 = true;
                if (!string.IsNullOrEmpty(rtxtMesureParade4.Text) || CbRisk4.Checked)
                    M4 = true;

                if (IsCreate)
                {
                    if (!string.IsNullOrEmpty(lblMaintanceItem.Text))
                        FuncLocation = true;
                    if (!string.IsNullOrEmpty(txtOrders.Text))
                        Order = true;

                    return M1 && M2 && M3 && M4 && M5 && M6 && FuncLocation && Order;
                }

                return M1 && M2 && M3 && M4 && M5 && M6;
            }

            return M5 && M6;
        }

        /// <summary>
        /// Créer un pdf sur base du template (Resources/Template)
        /// </summary>
        private void CreatePdf(ADR_SAPOrders SAPOrder, Dictionary<string, string> RisqueAndValue = null, string MaintenanceItem = null)
        {
            bool IsNotDictionary = RisqueAndValue == null;
            GenerateHistorique.CreateHistorique(FormUser.UserID, "Création d'un pdf", $"Pdf de l'ordre {SAPOrder.OrderNbs}");

            using (FileStream FsSave = new FileStream($"{Path.GetTempPath()}\\ADR.pdf", FileMode.Create))
            {
                // Open existing PDF
                PdfReader PdfReader;

                if (string.IsNullOrEmpty(MaintenanceItem))
                    PdfReader = new PdfReader(Properties.Resources.Template);
                else
                    PdfReader = new PdfReader(Properties.Resources.TemplatePlan);

                // PdfStamper, which will create
                PdfStamper PdfStamper = new PdfStamper(PdfReader, FsSave);

                AcroFields Field = PdfStamper.AcroFields;

                ImageConverter converter = new ImageConverter();
                byte[] Na = (byte[])converter.ConvertTo(Properties.Resources.NA, typeof(byte[]));

                if (string.IsNullOrEmpty(MaintenanceItem))
                    Field.SetField("!REPLACEDORDER", SAPOrder.OrderNbs);
                else
                    Field.SetField("!REPLACEDORDER", MaintenanceItem);

                Field.SetField("!REPLACEDPTITLE", $"{lblCriticality.Text} {SAPOrder.Criticality}");
                Field.SetField("!REPLACEDACTIVITY", txtActivity.Text);
                Field.SetField("!REPLACEDPFUNC", lblMaintanceItem.Text);
                Field.SetField("!REPLACEDPDESC", lblShortDesc.Text);

                if (rtxtMesureParade1.Enabled)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("STETime", txtDurationRisk1.Text);
                        RisqueAndValue.Add("STEText", rtxtMesureParade1.Text);
                        RisqueAndValue.Add("STEOff", "");
                    }

                    Field.SetField("!REPLACEDP1DAY", txtDurationRisk1.Text);
                    Field.SetField("!REPLACEDP1", rtxtMesureParade1.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("STEOff", "X");
                        RisqueAndValue.Add("STETime", "");
                        RisqueAndValue.Add("STEText", "");
                    }
                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa1");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa1", PButtonField.Field);
                }

                if (rtxtMesureParade2.Enabled && SAPOrder.Criticality > 2)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("PPText", rtxtMesureParade2.Text);
                        RisqueAndValue.Add("PPOff", "");
                    }

                    Field.SetField("!REPLACEDP2", rtxtMesureParade2.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("PPOff", "X");
                        RisqueAndValue.Add("PPText", "");
                    }

                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa2");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa2", PButtonField.Field);
                }

                if (rtxtMesureParade3.Enabled && SAPOrder.Criticality > 2)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("RICText", rtxtMesureParade3.Text);
                        RisqueAndValue.Add("RICOff", "");
                    }
                    Field.SetField("!REPLACEDP3", rtxtMesureParade3.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("RICOff", "X");
                        RisqueAndValue.Add("RICText", "");
                    }

                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa3");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa3", PButtonField.Field);
                }

                if (rtxtMesureParade4.Enabled && SAPOrder.Criticality > 2)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("AQText", rtxtMesureParade4.Text);
                        RisqueAndValue.Add("AQOff", "");
                    }

                    Field.SetField("!REPLACEDP4", rtxtMesureParade4.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("AQOff", "X");
                        RisqueAndValue.Add("AQText", "");
                    }

                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa4");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa4", PButtonField.Field);
                }

                if (rtxtMesureParade5.Enabled)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("ISText", rtxtMesureParade5.Text);
                        RisqueAndValue.Add("ISOff", "");
                    }

                    Field.SetField("!REPLACEDP5", rtxtMesureParade5.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("ISOff", "X");
                        RisqueAndValue.Add("ISText", "");
                    }

                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa5");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa5", PButtonField.Field);
                }

                if (rtxtMesureParade6.Enabled)
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("RPText", rtxtMesureParade6.Text);
                        RisqueAndValue.Add("RPOff", "");
                    }

                    Field.SetField("!REPLACEDP6", rtxtMesureParade6.Text, PdfFormField.MULTILINE);
                }
                else
                {
                    if (!IsNotDictionary)
                    {
                        RisqueAndValue.Add("RPOff", "X");
                        RisqueAndValue.Add("RPText", "");
                    }

                    PushbuttonField PButtonField = Field.GetNewPushbuttonFromField("!ImgNa6");
                    PButtonField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                    PButtonField.ProportionalIcon = true;
                    PButtonField.Image = iTextSharp.text.Image.GetInstance(Na);
                    Field.ReplacePushbuttonField("!ImgNa6", PButtonField.Field);
                }

                foreach (string field in Field.Fields.Keys)
                {
                    if (field.Contains("!REPLACEDP"))
                    {
                        Field.SetFieldProperty(field, "textsize", (float)9, null);
                        Field.RegenerateField(field);
                    }
                }

                // "Flatten" the form so it wont be editable/usable anymore
                PdfStamper.FormFlattening = true;

                // You can also specify fields to be flattened, which leaves the rest of the form still be editable/usable
                PdfStamper.PartialFormFlattening("ADR");

                PdfStamper.Close();
                PdfReader.Close();
            }
        }

        /// <summary>
        /// Impression
        /// </summary>
        private void StartPrint()
        {
            //Create an object of the PdfDocument class, andLoad PDF File
            Spire.Pdf.PdfDocument Document = new Spire.Pdf.PdfDocument();
            Document.LoadFromFile($"{Path.GetTempPath()}\\ADR.pdf");
            Document.PrintSettings.DocumentName = "ADR.pdf";
            //Print all pages of a document using the default printer
            Document.Print();
        }

        /// <summary>
        /// Ajoute les ordres importés depuis SAP, en db 
        /// </summary>
        /// <param name="Orders"></param>
        private void AddOrderDB(IEnumerable<ADR_SAPOrders> Orders)
        {
            SAPExclude.Clear();
            SAPSave.Clear();

            CheckOrderForDelete(Orders.ToList());

            foreach (ADR_SAPOrders order in Orders)
            {
                if (order.Revision.ToUpper().Trim() != "STANDING")
                {
                    ADR_SAPOrders OrderDb;

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        OrderDb = SAPOrdersRepository.GetByOrderNbs(order.OrderNbs);
                    }

                    if (OrderDb == null)
                        CheckAndSaveOrder(order);
                    else
                        UpdateOrderManual(OrderDb, order);
                }
            }
        }

        /// <summary>
        /// Créer un ordre manuellement
        /// </summary>
        /// <returns></returns>
        private ADR_SAPOrders CreateOrder()
        {
            GenerateHistorique.CreateHistorique(FormUser.UserID, "Création manuelle d'une analyse", $"Création manuelle d'une analyse, ordre : {txtOrders.Text}");

            return new ADR_SAPOrders()
            {
                FuncLocation = lblMaintanceItem.Text,
                OrderNbs = txtOrders.Text,
                WorkCenter = WorkCenter.WorkCenter,
                Revision = "Creation manuelle",
                OrderShortDesc = !string.IsNullOrEmpty(lblShortDesc.Text) ? lblShortDesc.Text : "Creation manuelle",
                MaintenancePlant = "Creation manuelle",
                Criticality = (int)nCriticality.Value,
                IsManual = true
            };

        }

        /// <summary>
        /// Vérifie si il y a des champs risque complétés pour sauvegarder l'analyse lors de l'event Form_Closing
        /// </summary>
        /// <returns></returns>
        private bool CheckRiskForSave()
        {
            return ((!string.IsNullOrEmpty(rtxtMesureParade1.Text) && !CbRisk1.Checked)
                || (!string.IsNullOrEmpty(rtxtMesureParade2.Text) && !CbRisk2.Checked)
                || (!string.IsNullOrEmpty(rtxtMesureParade3.Text) && !CbRisk3.Checked)
                || (!string.IsNullOrEmpty(rtxtMesureParade4.Text) && !CbRisk4.Checked)
                || (!string.IsNullOrEmpty(rtxtMesureParade5.Text) && !CbRisk5.Checked)
                || (!string.IsNullOrEmpty(rtxtMesureParade6.Text) && !CbRisk6.Checked)
                || !string.IsNullOrEmpty(txtActivity.Text)) && IsNotSave;
        }

        /// <summary>
        /// Ajoute les ordres de la section dans une liste pour la recherche
        /// </summary>
        private void PopulateOrderList()
        {
            SAPOrdersContains.Clear();
            AnalysisResultContains.Clear();

            if (WorkCenter.WorkCenter != "*")
            {
                using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                {
                    SAPOrdersContains = SAPOrdersRepository.Get().Where((o) => string.IsNullOrEmpty(o.AnalysisNbs) && o.WorkCenter.ToUpper().StartsWith(WorkCenter.WorkCenter.ToUpper())).DistinctBy((o) => o.OrderNbs).ToList();
                }
                using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                {
                    AnalysisResultContains = AnalysisResultRepositoty.Get().Where((a) => a.WorkCenter.ToUpper().StartsWith(WorkCenter.WorkCenter.ToUpper())).DistinctBy((o) => o.OrderNbs).ToList();
                }
            }
            else
            {
                using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                {
                    SAPOrdersContains = SAPOrdersRepository.Get().Where((o) => string.IsNullOrEmpty(o.AnalysisNbs)).DistinctBy((o) => o.OrderNbs).ToList();
                }
                using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                {
                    AnalysisResultContains = AnalysisResultRepositoty.Get().DistinctBy((o) => o.OrderNbs).ToList();
                }
            }

        }

        /// <summary>
        /// Met à jour les analyses créées manuellement
        /// </summary>
        /// <param name="Order"></param>
        private void UpdateAnalyseManual(ADR_SAPOrders Order)
        {
            ADR_Analysis_Result AnalysisResult;

            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                AnalysisResult = AnalysisResultRepositoty.GetByAnalysisNbs(Order.AnalysisNbs);
            }

            if (AnalysisResult != null)
            {
                if (AnalysisResult.IsManual == true)
                {
                    AnalysisResult.IsManual = false;
                    AnalysisResult.MaintencaneItem = Order.MaintencaneItem;
                    AnalysisResult.OrderShortDesc = Order.OrderShortDesc;
                }

                if (string.IsNullOrEmpty(AnalysisResult.Preparator) && !string.IsNullOrEmpty(Order.Preparator))
                {
                    AnalysisResult.Preparator = Order.Preparator;
                }

                using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                {
                    AnalysisResultRepositoty.Update(AnalysisResult);
                }
            }
        }

        /// <summary>
        /// Active les controlleurs si l'analyse est validé
        /// </summary>
        private void AnalysisSuccess()
        {
            btnLoadintoOrder.Enabled = true;
            btnPrint.Enabled = true;
            tbNbrSearch.Text = CurrentSearch;
            SearchOrdersAnalysis();
            IsCreate = false;
            IsNotSave = false;
            btnCreateOrder.Enabled = true;
            PopulateOrderList();
        }

        /// <summary>
        /// Met à jour les ordres lors d'une création manuelle
        /// </summary>
        /// <param name="OrderDb"></param>
        /// <param name="OrderSAP"></param>
        private void UpdateOrderManual(ADR_SAPOrders OrderDb, ADR_SAPOrders OrderSAP)
        {
            bool IsNeedUpdate = false;

            if (OrderDb.OrderNbs == OrderSAP.OrderNbs)
            {
                if (OrderDb.Criticality != OrderSAP.Criticality)
                {
                    OrderDb.Criticality = OrderSAP.Criticality;
                    IsNeedUpdate = true;
                }

                if (OrderDb.IsManual == true)
                {
                    OrderDb.MaintenancePlant = OrderSAP.MaintenancePlant;
                    OrderDb.Criticality = OrderSAP.Criticality;
                    OrderDb.MaintencaneItem = OrderSAP.MaintencaneItem;
                    OrderDb.OrderShortDesc = OrderSAP.OrderShortDesc;
                    OrderDb.FuncLocation = OrderSAP.FuncLocation;
                    OrderDb.Revision = OrderSAP.Revision;
                    OrderDb.StartDate = OrderSAP.StartDate;
                    OrderDb.Preparator = OrderSAP.Preparator;
                    OrderDb.RevisionPhase = OrderSAP.RevisionPhase;
                    OrderDb.Workspace = OrderSAP.Workspace;
                    OrderDb.IsManual = false;
                    IsNeedUpdate = true;
                }

                if (string.IsNullOrEmpty(OrderDb.Preparator) && !string.IsNullOrEmpty(OrderSAP.Preparator))
                {
                    OrderDb.Preparator = OrderSAP.Preparator;
                    IsNeedUpdate = true;
                }

                if (string.IsNullOrEmpty(OrderDb.RevisionPhase) && !string.IsNullOrEmpty(OrderSAP.RevisionPhase))
                {
                    OrderDb.RevisionPhase = OrderSAP.RevisionPhase;
                    IsNeedUpdate = true;
                }
            }

            UpdateAnalyseManual(OrderDb);

            if (IsNeedUpdate)
            {
                using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                {
                    if (!SAPOrdersRepository.Update(OrderDb))
                        SAPExclude.Add(OrderSAP);
                    else
                        SAPSave.Add(OrderSAP);
                }
            }
        }

        /// <summary>
        /// Supprime les ordres dont le statut à changer et qui ne sont plus importés depuis 
        /// le webservice (les ordres qui n'ont pas d'analyse)
        /// </summary>
        /// <param name="SAPOrdersWebService"></param>
        private void CheckOrderForDelete(List<ADR_SAPOrders> SAPOrdersWebService)
        {
            List<ADR_SAPOrders> SAPOrdersDb;

            using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
            {
                SAPOrdersDb = SAPOrdersRepository.GetByWorkCenter(WorkCenter.WorkCenter).Where((o) => string.IsNullOrEmpty(o.AnalysisNbs)).ToList();
            }

            List<ADR_SAPOrders> SAPOrdersDelete = SAPOrdersDb.ExceptBy(SAPOrdersWebService, (o) => o.OrderNbs).ToList();

            foreach (ADR_SAPOrders Order in SAPOrdersDelete)
            {
                using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                {
                    SAPOrdersRepository.Delete(Order);
                }
            }
        }

        /// <summary>
        /// Vérifie si les ordres sont des ordres récurent et créer l'analyse sur base de l'ancienne.
        /// </summary>
        /// <param name="OrderSAP"></param>
        private void CheckAndSaveOrder(ADR_SAPOrders OrderSAP)
        {
            ADR_SAPOrders OrderDb = OrderSAP;
            ADR_SAPOrders OrderRecurent;

            if (!string.IsNullOrEmpty(OrderSAP.MaintencaneItem))
            {
                using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                {
                    OrderRecurent = SAPOrdersRepository.GetRecurent(OrderSAP.MaintencaneItem);
                }

                if (OrderRecurent != null)
                {
                    if (OrderSAP.Criticality <= OrderRecurent.Criticality)
                    {
                        ADR_Analysis_Result AnalysisResult;

                        using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                        {
                            AnalysisResult = AnalysisResultRepositoty.GetByOrderNbs(OrderRecurent.OrderNbs);
                        }

                        if (AnalysisResult != null)
                        {
                            OrderDb.AnalysisNbs = $"AN{OrderSAP.OrderNbs}";
                            ADR_Analysis_Result AnalysisRecurent = CreateAnalyse(OrderSAP, AnalysisResult.Activity);
                            int AnalysisRecurentId;

                            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                            {
                                AnalysisRecurentId = AnalysisResultRepositoty.InsertAndReturnId(AnalysisRecurent);
                            }

                            if (AnalysisRecurentId != 0)
                            {
                                CreateAndSaveAnalysisParameters(AnalysisResult.Id, AnalysisRecurentId);
                            }
                        }
                    }
                }
            }

            using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
            {
                if (!SAPOrdersRepository.Insert(OrderDb))
                    SAPExclude.Add(OrderSAP);
                else
                    SAPSave.Add(OrderSAP);
            }
        }

        /// <summary>
        /// Créer les paramètres de l'analyse si ordre récurent
        /// </summary>
        /// <param name="AnalysisId">Id de l'analyse modèle</param>
        /// <param name="NewAnalysisId">Id de la nouvelle analyse</param>
        private void CreateAndSaveAnalysisParameters(int AnalysisId, int NewAnalysisId)
        {
            List<ADR_Analysis_Parameters> AnalysisParameters;

            using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
            {
                AnalysisParameters = AnalysisParametersRepository.GetByAnalysis(AnalysisId).ToList();
            }

            foreach (ADR_Analysis_Parameters parameter in AnalysisParameters)
            {
                ADR_Analysis_Parameters Parameter = new ADR_Analysis_Parameters()
                {
                    AnalysisId = NewAnalysisId,
                    CriticalityId = parameter.CriticalityId,
                    OrderCrit = parameter.OrderCrit,
                    IsNA = parameter.IsNA,
                    ParameterText = parameter.ParameterText
                };

                using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                {
                    AnalysisParametersRepository.Insert(Parameter);
                }
            }
        }

        private void FiltredSearch()
        {
            oblwSearch.Items.Clear();

            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                if (SAPOrdersContains != null && SAPOrdersContains.Count() > 0)
                {
                    List<ADR_SAPOrders> OrdersFilter = new List<ADR_SAPOrders>();

                    //Rechercher par numero de commande
                    //Recherhcer sur le Functional Location
                    //Rechercher par Poste d'entretien
                    OrdersFilter.AddRange(SAPOrdersContains.Where((o) => (!string.IsNullOrEmpty(o.OrderNbs) && o.OrderNbs.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.FuncLocation) && o.FuncLocation.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.MaintencaneItem) && o.MaintencaneItem.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.Revision) && o.Revision.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.RevisionPhase) && o.RevisionPhase.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.Preparator) && o.Preparator.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                      || (!string.IsNullOrEmpty(o.Workspace) && o.Workspace.ToUpper().Contains(txbFilter.Text.ToUpper()))));
                    oblwSearch.SetObjects(OrdersFilter);
                }
            }
            else
            {
                if (AnalysisResultContains != null && AnalysisResultContains.Count() > 0)
                {
                    List<ADR_Analysis_Result> AnalysisFilter = new List<ADR_Analysis_Result>();

                    //Rechercher par numero de commande
                    //Recherhcer sur le Functional Location
                    //Rechercher par activité
                    AnalysisFilter.AddRange(AnalysisResultContains.Where((a) => (!string.IsNullOrEmpty(a.OrderNbs) && a.OrderNbs.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                             || (!string.IsNullOrEmpty(a.FuncLocation) && a.FuncLocation.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                             || (!string.IsNullOrEmpty(a.Activity) && a.Activity.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                             || (!string.IsNullOrEmpty(a.RevisionPhase) && a.RevisionPhase.ToUpper().Contains(txbFilter.Text.ToUpper()))
                                                                             || (!string.IsNullOrEmpty(a.Preparator) && a.Preparator.ToUpper().Contains(txbFilter.Text.ToUpper()))));
                    oblwSearch.SetObjects(AnalysisFilter);
                }
            }
        }

        private void SuggestSearch()
        {
            AutoCompleteStringCollection AutoCompleteSource = new AutoCompleteStringCollection();

            if (ADRHelper.CheckSelectedSearch(cbValueSearch.SelectedIndex) == ModeEnum.Save)
            {
                if (tbNbrSearch.Text.Contains("0"))
                {
                    //Rechercher par numero de commande
                    AutoCompleteSource.AddRange(SAPOrdersContains.Where((o) => !string.IsNullOrEmpty(o.OrderNbs) && o.OrderNbs.Contains(tbNbrSearch.Text)).Select((o) => o.OrderNbs).ToArray());
                }
                else if (tbNbrSearch.Text.ToUpper().StartsWith("PCT"))
                {
                    //Recherhcer sur le Functional Location
                    AutoCompleteSource.AddRange(SAPOrdersContains.Where((o) => !string.IsNullOrEmpty(o.FuncLocation) && o.FuncLocation.Contains(tbNbrSearch.Text)).Select((o) => o.FuncLocation).ToArray());
                }
                else
                {
                    //Rechercher par Poste d'entretien
                    AutoCompleteSource.AddRange(SAPOrdersContains.Where((o) => !string.IsNullOrEmpty(o.MaintencaneItem) && o.MaintencaneItem.Contains(tbNbrSearch.Text)).Select((o) => o.MaintencaneItem).ToArray());
                }
            }
            else
            {
                if (tbNbrSearch.Text.Contains("0"))
                {
                    //Rechercher par numero de commande
                    AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.OrderNbs) && a.OrderNbs.Contains(tbNbrSearch.Text)).Select((o) => o.OrderNbs).ToArray());
                }
                if (tbNbrSearch.Text.ToUpper().StartsWith("PCT"))
                {
                    //Recherhcer sur le Functional Location
                    AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.FuncLocation) && a.FuncLocation.Contains(tbNbrSearch.Text)).Select((o) => o.FuncLocation).ToArray());
                }
                else
                {
                    //Rechercher par activitée
                    AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.Activity) && a.Activity.Contains(tbNbrSearch.Text)).Select((o) => o.Activity).ToArray());
                }
            }

            tbNbrSearch.AutoCompleteCustomSource = AutoCompleteSource;
        }

        private void SuggestSearchModel()
        {
            AutoCompleteStringCollection AutoCompleteSource = new AutoCompleteStringCollection();

            if (txtModel.Text.Contains("0"))
            {
                //Rechercher par numero de commande
                AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.OrderNbs) && a.OrderNbs.Contains(txtModel.Text)).Select((o) => o.OrderNbs).ToArray());
            }
            if (txtModel.Text.ToUpper().StartsWith("PCT"))
            {
                //Recherhcer sur le Functional Location
                AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.FuncLocation) && a.FuncLocation.Contains(txtModel.Text)).Select((o) => o.FuncLocation).ToArray());
            }
            else
            {
                //Rechercher par activitée
                AutoCompleteSource.AddRange(AnalysisResultContains.Where((a) => !string.IsNullOrEmpty(a.Activity) && a.Activity.Contains(txtModel.Text)).Select((o) => o.Activity).ToArray());
            }

            txtModel.AutoCompleteCustomSource = AutoCompleteSource;
        }

        #endregion

        #endregion
    }
}
