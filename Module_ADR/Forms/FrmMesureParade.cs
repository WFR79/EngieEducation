using SynapseCore.Controls;
using SynapseCore.Security;
using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using System;
using Module_ADR.Helper;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Module_ADR.Forms
{
    public partial class FrmMesureParade : SynapseForm
    {
        #region Properties

        private int RiskId;
        private bool IsSave;
        private ADR_WorkCenterUser WorkCenterUser;
        private ADR_WorkCenter WorkCenter;
        private readonly GenerateHistorique GenerateHistorique;

        private const int CurrentLenght = 250;

        #endregion

        #region Constructor

        public FrmMesureParade(ADR_WorkCenter WorkCenter, ADR_WorkCenterUser WorkCenterUser)
        {
            InitializeComponent();
            GenerateHistorique = new GenerateHistorique();
            this.WorkCenter = WorkCenter;
            this.WorkCenterUser = WorkCenterUser;
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            AddMesureAndParade();
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
        }

        #endregion

        #region Methode

        /// <summary>
        /// Ajoute en db les nouvelles mesures et parades
        /// </summary>
        private void AddMesureAndParade()
        {
            List<ADR_Criticality_Helper_Parameters> HelperParameters;
            tvRisk.Nodes.Clear();

            using (CriticalityHelperParametersRepository CHPRepository = new CriticalityHelperParametersRepository())
            {
                HelperParameters = CHPRepository.Get().Where((r) => !r.IsDisabled).ToList();
            }

            int i = 0;
            foreach (ADR_Criticality_Helper_Parameters risk in HelperParameters.OrderBy((r) => r.Id))
            {
                tvRisk.Nodes.Add(risk.ItemText);

                if (WorkCenter.WorkCenter != "*")
                {
                    List<ADR_Criticality_MesureParade> MesureParades;

                    using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                    {
                        MesureParades = MPRepository.GetById(risk.Id).Where((p) => p.WorkCenterId == WorkCenterUser.WorkCenterId && !p.IsDisabled).ToList();
                    }

                    foreach (ADR_Criticality_MesureParade parade in MesureParades)
                    {
                        tvRisk.Nodes[i].Nodes.Add(parade.ItemText);
                    }

                    i++;
                }
                else
                {
                    List<ADR_Criticality_MesureParade> MesureParades;

                    using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                    {
                        MesureParades = MPRepository.GetById(risk.Id).Where((p) => !p.IsDisabled).ToList();
                    }

                    foreach (ADR_Criticality_MesureParade parade in MesureParades)
                    {
                        tvRisk.Nodes[i].Nodes.Add(parade.ItemText);
                    }

                    i++;
                }

            }
        }

        private void ShowMessage(string Message)
        {
            MessageBox.Show(Message);
        }

        #endregion

        #region Event

        /// <summary>
        /// Ajoute un risque
        /// Modifie un risque selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvRiskSelectedNode(object sender, TreeViewEventArgs e)
        {
            if (tvRisk.SelectedNode.Parent != null)
            {
                RiskId = ADRHelper.CheckRisk(tvRisk.SelectedNode.Parent.Text);
                txtMesureParade.Text = tvRisk.SelectedNode.Text;
                btnAdd.Text = "Modifier";
                IsSave = false;
                btnDelete.Enabled = true;
            }
            else
            {
                RiskId = ADRHelper.CheckRisk(tvRisk.SelectedNode.Text);
                btnAdd.Text = "Ajouter";
                txtMesureParade.Text = string.Empty;
                IsSave = true;
                btnDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Ajoute en db la nouvelle mesure/parade
        /// Modifier en db la mesure/parade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (RiskId != 0)
            {
                ADR_Criticality_MesureParade Parade;
                string Message;

                if (IsSave)
                {
                    Parade = new ADR_Criticality_MesureParade();

                    Parade.ItemText = txtMesureParade.Text;
                    Parade.CreationDate = DateTime.Now;
                    Parade.CreateBy = FormUser.UserID;
                    Parade.CriticalityRiskId = RiskId;
                    Parade.WorkCenterId = WorkCenterUser.WorkCenterId;

                    bool IsSave;

                    using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                    {
                        IsSave = MPRepository.Insert(Parade);
                    }

                    if (!IsSave)
                    {
                        txtMesureParade.Text = string.Empty;
                        Message = "Erreur lors de la création de la mesure/parade";
                        ShowMessage(Message);
                    }
                    else
                        GenerateHistorique.CreateHistorique(FormUser.UserID, "Ajout mesures/parades", "", txtMesureParade.Text);
                }
                else
                {
                    using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                    {
                        Parade = MPRepository.Get(tvRisk.SelectedNode.Text, RiskId);
                    }

                    string Origine = Parade.ItemText;
                    string Destination = txtMesureParade.Text;

                    Parade.ItemText = txtMesureParade.Text;
                    Parade.ModifiedDate = DateTime.Now;
                    Parade.ModifiedBy = FormUser.UserID;
                    Parade.CriticalityRiskId = RiskId;
                    Parade.WorkCenterId = WorkCenterUser.WorkCenterId;

                    bool IsUpdated;

                    using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                    {
                        IsUpdated = MPRepository.Update(Parade);
                    }

                    if (!IsUpdated)
                    {
                        Message = "Erreur lors de la modification de la mesure/parade";
                        ShowMessage(Message);
                    }
                    else
                        GenerateHistorique.CreateHistorique(FormUser.UserID, "Modification mesures/parades", Origine, Destination);
                }

                AddMesureAndParade();
            }
        }

        /// <summary>
        /// Desactive la mesure/parade en db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvRisk.SelectedNode.Parent != null)
            {
                string Message;

                ADR_Criticality_MesureParade Parade;

                using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                {
                    Parade = MPRepository.Get(tvRisk.SelectedNode.Text, RiskId);
                }

                Parade.IsDisabled = true;

                bool IsDeleted;

                using (MesureAndParadeRepository MPRepository = new MesureAndParadeRepository())
                {
                    IsDeleted = MPRepository.Delete(Parade);
                }

                if (!IsDeleted)
                {
                    Message = "Erreur lors de la suppression de la mesure/parade";
                    ShowMessage(Message);
                }
                else
                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Suppression mesures/parades", Parade.ItemText);

                AddMesureAndParade();
            }

        }

        /// <summary>
        /// Affiche le nombre de caractères restants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMesureParade_TextChanged(object sender, EventArgs e)
        {
            TextBox TextBox = (TextBox)sender;

            if (TextBox.Text.Length > 250)
                ShowMessage("Vous avez atteind le maximum de caractères autorisées (250)");
            else
                lblCurrentLength.Text = (CurrentLenght - TextBox.Text.Length).ToString();

            if (!string.IsNullOrEmpty(txtMesureParade.Text) && WorkCenter.WorkCenter != "*")
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        #endregion
    }
}


