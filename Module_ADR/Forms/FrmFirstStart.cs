using SynapseCore.Controls;
using SynapseCore.Security;
using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Module_ADR.Helper;

namespace Module_ADR.Forms
{
    public partial class FrmFirstStart : SynapseForm
    {
        #region Properties

        private ADR_WorkCenterUser WorkCenterUser;

        private readonly GenerateHistorique GenerateHistorique;

        private readonly ADR ADR;

        #endregion

        #region Constructor

        public FrmFirstStart(ADR_WorkCenterUser WorkCenterUser, ADR ADR)
        {
            InitializeComponent();
            btnSave.Enabled = false;
            GenerateHistorique = new GenerateHistorique();
            this.WorkCenterUser = WorkCenterUser;
            this.ADR = ADR;
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            GetWorkCenter();
        }

        #endregion

        #region Methode Private

        /// <summary>
        /// Va chercher tout les workcenter présent en db et les ajoutes à la combobox
        /// </summary>
        private void GetWorkCenter()
        {
            lblName.Text = $"Bonjour {FormUser.ToString()}";
            lblMessage.Text = "Merci de sélectionner une section.";

            List<ADR_WorkCenter> WorkCenters;

            using (WorkCenterRepository WorkCenterRepository = new WorkCenterRepository())
            {
                WorkCenters = WorkCenterRepository.Get().ToList();
            }

            cbWorkCenter.DataSource = WorkCenters;
            cbWorkCenter.DisplayMember = "WorkCenter";
            cbWorkCenter.ValueMember = "Id";

            if (WorkCenterUser != null)
                cbWorkCenter.Text = WorkCenters.Where((wk) => wk.Id == WorkCenterUser.WorkCenterId).Select((wk) => wk.WorkCenter).FirstOrDefault();
        }

        /// <summary>
        /// Sauvegarde le choix de la section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            ADR_WorkCenter WorkCenter = (ADR_WorkCenter)cbWorkCenter.SelectedItem;
            bool IsInserted = false;
            bool IsUpdated = false;

            if (WorkCenterUser == null)
            {
                WorkCenterUser = new ADR_WorkCenterUser()
                {
                    UserId = FormUser.UserID.ToUpper(),
                    WorkCenterId = WorkCenter.Id
                };

                using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
                {
                    IsInserted = WorkCenterUserRepository.Insert(WorkCenterUser);
                }

                GenerateHistorique.CreateHistorique(FormUser.UserID, "Choix du WorkCenter (Création de l'utilisateur)", WorkCenter.WorkCenter);
            }
            else
            {
                string Origine;

                using (WorkCenterRepository WorkCenterRepository = new WorkCenterRepository())
                {
                    Origine = WorkCenterRepository.Get(WorkCenter.Id).WorkCenter;
                }

                WorkCenterUser.WorkCenterId = WorkCenter.Id;

                using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
                {
                    IsUpdated = WorkCenterUserRepository.Update(WorkCenterUser);
                }

                if (IsUpdated)
                    GenerateHistorique.CreateHistorique(FormUser.UserID, "Choix du WorkCenter", Origine, WorkCenter.WorkCenter);
            }

            ADR.tssUser.Text = $"{SynapseForm.FormUser.ToString()} / {WorkCenter.WorkCenter}";
            ADR.ADRWorkCenter = WorkCenter;
            ADR.ADRWorkCenterUser = WorkCenterUser;

            if (IsInserted || IsUpdated)
                this.Dispose();
        }

        #endregion
    }
}
