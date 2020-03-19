using SynapseCore.Controls;
using SynapseCore.Security;
using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using System.Linq;
using System.Collections.Generic;
using Module_ADR.CustomEntities;
using System.Windows.Forms;
using System;
using Module_ADR.Helper;

namespace Module_ADR.Forms
{
    public partial class FrmChangeWK : SynapseForm
    {
        #region Properties

        private readonly GenerateHistorique GenerateHistorique;
        private readonly ADR ADR;

        #endregion

        #region Constructor

        public FrmChangeWK(ADR ADR)
        {
            InitializeComponent();
            GenerateHistorique = new GenerateHistorique();
            this.ADR = ADR;
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            GetWorkCenter();
            GetUser();
            txtMessage.ReadOnly = true;
            txtMessage2.ReadOnly = true;
        }

        #endregion

        #region Methode

        /// <summary>
        /// Va chercher les workcenters en db
        /// </summary>
        private void GetWorkCenter()
        {
            List<ADR_WorkCenter> WorkCenters = new List<ADR_WorkCenter>();

            WorkCenters.Add(new ADR_WorkCenter() { Id = 0, WorkCenter = "" });

            using (WorkCenterRepository WorkCenterRepository = new WorkCenterRepository())
            {
                WorkCenters.AddRange(WorkCenterRepository.Get().Where((wk) => !wk.IsDisabled).OrderBy((wk) => wk.WorkCenter));
            }

            cbWorkCenter.DataSource = WorkCenters;
            cbWorkCenter.DisplayMember = "WorkCenter";
            cbWorkCenter.ValueMember = "Id";
        }

        /// <summary>
        /// Va chercher les users et leurs workcenter en db
        /// </summary>
        private void GetUser()
        {
            List<UserWorkCenter> UserWorkCenters = new List<UserWorkCenter>();
            List<ADR_WorkCenterUser> WorkCenterUsers;

            using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
            {
                WorkCenterUsers = WorkCenterUserRepository.Get().Where((u) => !u.IsDisabled).OrderBy((u) => u.UserId).ToList();
            }

            foreach (ADR_WorkCenterUser item in WorkCenterUsers)
            {
                ADR_WorkCenter WorkCenter;

                using (WorkCenterRepository WorkCenterRepository = new WorkCenterRepository())
                {
                    WorkCenter = WorkCenterRepository.Get(item.WorkCenterId);
                }

                UserWorkCenters.Add(new UserWorkCenter()
                {
                    UserId = item.Id,
                    WorkCenterId = item.WorkCenterId,
                    User = item.UserId,
                    WorkCenter = WorkCenter.WorkCenter
                });
            }

            olvUser.SetObjects(UserWorkCenters);
        }

        #endregion

        #region Event

        /// <summary>
        /// Selection d'une ligne dans l'objectlistview
        /// Permet de modifier la ligne sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void olvUser_Click(object sender, System.EventArgs e)
        {
            UserWorkCenter UserWK = (UserWorkCenter)olvUser.SelectedObject;

            if (UserWK != null)
                cbWorkCenter.SelectedIndex = cbWorkCenter.FindStringExact(UserWK.WorkCenter);
        }

        /// <summary>
        /// Sélectonne le nouveau workcenter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbWorkCenter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UserWorkCenter UserWK = (UserWorkCenter)olvUser.SelectedObject;
            ADR_WorkCenter WorkCenter = (ADR_WorkCenter)cbWorkCenter.SelectedItem;

            txtMessage.Text = string.Empty;
            txtMessage2.Text = string.Empty;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;

            if (UserWK != null && !string.IsNullOrEmpty(WorkCenter.WorkCenter))
            {
                btnRemove.Enabled = true;

                if (WorkCenter.WorkCenter != UserWK.WorkCenter)
                {
                    txtMessage.Text = $"Changement de section pour {UserWK.User}";
                    txtMessage2.Text = $"{UserWK.WorkCenter} => {WorkCenter.WorkCenter}";
                    btnModify.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Modifie en db le nouveau workcenter de l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, System.EventArgs e)
        {
            UserWorkCenter UserWK = (UserWorkCenter)olvUser.SelectedObject;
            ADR_WorkCenter WorkCenter = (ADR_WorkCenter)cbWorkCenter.SelectedItem;
            ADR_WorkCenterUser UserDb;
            bool IsUpdated;
            string Origine;
            string Destination;

            using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
            {
                UserDb = WorkCenterUserRepository.GetByUserId(UserWK.User);

                Origine = UserWK.WorkCenter;
                Destination = WorkCenter.WorkCenter;

                UserDb.WorkCenterId = WorkCenter.Id;

                IsUpdated = WorkCenterUserRepository.Update(UserDb);
            }

            if (!IsUpdated)
                GenerateMessage("Erreur lors du changement de section");
            else
            {
                cbWorkCenter.SelectedIndex = cbWorkCenter.FindStringExact("");
                txtMessage.Text = string.Empty;
                txtMessage2.Text = string.Empty;
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                GetUser();

                ADR.tssUser.Text = $"{SynapseForm.FormUser.ToString()} / {WorkCenter.WorkCenter}";
                ADR.ADRWorkCenter = WorkCenter;
                ADR.ADRWorkCenterUser = UserDb;

                GenerateHistorique.CreateHistorique(FormUser.UserID, "Changement de WorkCenter", Origine, Destination);
            }
        }

        /// <summary>
        /// Supprime un utilisateur de la db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            bool IsDeleted;
            UserWorkCenter UserWK = (UserWorkCenter)olvUser.SelectedObject;
            ADR_WorkCenterUser WorkCenterUser;

            using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
            {
                WorkCenterUser = WorkCenterUserRepository.GetByUserId(UserWK.User);
                IsDeleted = WorkCenterUserRepository.Delete(WorkCenterUser);
            }

            if (!IsDeleted)
            {
                GenerateMessage("Erreur lors de la suppression de l'utilisateur");
            }
            else
            {
                cbWorkCenter.SelectedIndex = cbWorkCenter.FindStringExact("");
                txtMessage.Text = string.Empty;
                txtMessage2.Text = string.Empty;
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                GetUser();

                GenerateHistorique.CreateHistorique(FormUser.UserID, "Suppression de l'utilisateur", UserWK.WorkCenter);
            }
        }

        private void GenerateMessage(string Message)
        {
            MessageBox.Show(Message);
        }

        #endregion
    }
}
