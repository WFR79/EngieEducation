using SynapseCore.Controls;
using SynapseCore.Security;
using System;
using Module_ADR.DataAccessLayer.Repos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Module_ADR.Models;
using Module_ADR.Helper;
using MoreLinq;
using SynapseAdvancedControls;

namespace Module_ADR.Forms
{
    public partial class FrmDeleteAnalyse : SynapseForm
    {
        #region Properties

        private IEnumerable<ADR_Analysis_Result> AnalysisResults;
        private ADR_Analysis_Result SelectedAnalysis;

        private GenerateHistorique GenerateHistorique;

        #endregion

        #region Constructor

        public FrmDeleteAnalyse()
        {
            InitializeComponent();
            GenerateHistorique = new GenerateHistorique();
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            btnDelete.Enabled = false;

            this.oblvAnalysis.PrimarySortColumn = this.olvWorkCenter;
            this.oblvAnalysis.Sorting = SortOrder.Ascending;
        }

        #endregion

        #region Method

        #region Event

        /// <summary>
        /// Charge les analyses et les workcenter au démarrage de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDeleteAnalyse_Load(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Chargement des analyses en cours.");

            AnalysisResults = GetAnalysis();

            SetObjectListView(AnalysisResults);

            SetComboBoxWk(AnalysisResults);

            FrmWait.CloseForm();
        }

        /// <summary>
        /// Change le style du button en fonction de son état
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_EnabledChanged(object sender, EventArgs e)
        {
            ADRHelper.ChangeColorDiabled((Button)sender);
        }

        /// <summary>
        /// Filtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (AnalysisResults.Count() > 0)
            {
                SetObjectListView(AnalysisResults.Where((a) => a.OrderNbs.Contains(txtFilter.Text)
                                                            || a.WorkCenter.ToUpper().Contains(txtFilter.Text.ToUpper())
                                                            || !string.IsNullOrEmpty(a.RevisionPhase) && a.RevisionPhase.ToUpper().Contains(txtFilter.Text.ToUpper())
                                                            || !string.IsNullOrEmpty(a.Preparator) && a.Preparator.ToUpper().Contains(txtFilter.Text.ToUpper())));
            }
        }

        /// <summary>
        /// Défini l'élément sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oblvAnalysis_Click(object sender, EventArgs e)
        {
            SelectedAnalysis = (ADR_Analysis_Result)((ObjectListView)sender).SelectedObject;

            if (SelectedAnalysis != null)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        /// <summary>
        /// Recherche les analyses avec un numéro d'ordre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerarch_Click(object sender, EventArgs e)
        {
            FrmWait.ShowWatingForms("Chargement des analyses en cours.");

            if (string.IsNullOrEmpty(txtOrderNumber.Text) && string.IsNullOrEmpty(cbWorkCenter.SelectedValue.ToString()))
                AnalysisResults = GetAnalysis();
            else
                AnalysisResults = GetAnalysis(txtOrderNumber.Text, cbWorkCenter.SelectedValue.ToString());

            SetObjectListView(AnalysisResults);

            FrmWait.CloseForm();
        }

        /// <summary>
        /// Delete Analysis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedAnalysis != null)
            {
                if (MessageBox.Show("Voulez-vous supprimer l'analyse ?", "Supprimer une analyse", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FrmWait.ShowWatingForms("Suppression de l'analyse en cours.");

                    List<ADR_Analysis_Parameters> Parameters;

                    using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                    {
                        Parameters = AnalysisParametersRepository.GetByAnalysis(SelectedAnalysis.Id).ToList();
                    }

                    foreach (ADR_Analysis_Parameters parameter in Parameters)
                    {
                        using (AnalysisParametersRepository AnalysisParametersRepository = new AnalysisParametersRepository())
                        {
                            AnalysisParametersRepository.Delete(parameter);
                        }
                    }

                    using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
                    {
                        AnalysisResultRepositoty.Delete(SelectedAnalysis);
                    }

                    using (SAPOrdersRepository SAPOrdersRepository = new SAPOrdersRepository())
                    {
                        ADR_SAPOrders SAPOrder = SAPOrdersRepository.GetByOrderNbs(SelectedAnalysis.OrderNbs);
                        SAPOrder.AnalysisNbs = null;
                        SAPOrdersRepository.Update(SAPOrder);
                    }



                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Deleted", $"Suppression d'une analyse {SelectedAnalysis.AnalysisNbs}");

                    btnDelete.Enabled = false;
                    SelectedAnalysis = null;

                    FrmWait.CloseForm();

                    FrmDeleteAnalyse_Load(null, null);
                }
            }
        }

        #endregion

        #region Utils

        /// <summary>
        /// Set l'objectlistview avec une collection
        /// </summary>
        /// <param name="AnalysisResults"></param>
        private void SetObjectListView(IEnumerable<ADR_Analysis_Result> AnalysisResults)
        {
            oblvAnalysis.SetObjects(AnalysisResults);
        }

        /// <summary>
        /// Set la combobox avec une collection
        /// </summary>
        /// <param name="AnalysisResults"></param>
        private void SetComboBoxWk(IEnumerable<ADR_Analysis_Result> AnalysisResults)
        {
            List<string> WorkCenters = new List<string>();

            WorkCenters.Add("");
            WorkCenters.AddRange(GetWorkcenter(AnalysisResults));

            cbWorkCenter.DataSource = WorkCenters;
            cbWorkCenter.DisplayMember = "WorkCenter";
        }

        /// <summary>
        /// Va chercher toute les analyses
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ADR_Analysis_Result> GetAnalysis()
        {
            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                return AnalysisResultRepositoty.Get();
            }
        }

        /// <summary>
        /// Va chercher toute les analyses avec le numéro d'ordre
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ADR_Analysis_Result> GetAnalysis(string OrderNbs, string WorkCenter)
        {
            using (AnalysisResultRepositoty AnalysisResultRepositoty = new AnalysisResultRepositoty())
            {
                return AnalysisResultRepositoty.GetAllByOrderNbsAndWorkCenter(OrderNbs, WorkCenter);
            }
        }

        /// <summary>
        /// Va chercher les workcenter des analyses
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetWorkcenter(IEnumerable<ADR_Analysis_Result> AnalysisResults)
        {
            return AnalysisResults.OrderBy((w) => w.WorkCenter).DistinctBy((w) => w.WorkCenter).Select((w) => w.WorkCenter);
        }

        #endregion

        #endregion
    }
}
