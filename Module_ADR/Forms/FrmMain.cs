using System;
using Module_ADR.DataAccessLayer.Repos;
using System.Windows.Forms;
using SynapseCore.Controls;
using Module_ADR.Models;
using Module_ADR.CustomController;
using System.Drawing;

namespace Module_ADR.Forms
{
    public partial class ADR : SynapseForm
    {
        #region Properties

        public ADR_WorkCenter ADRWorkCenter;
        public ADR_WorkCenterUser ADRWorkCenterUser;

        #endregion

        #region Constructor

        public ADR()
        {
            InitializeComponent();
        }

        #endregion

        #region Init

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.Banner;
            this.BackgroundImageLayout = ImageLayout.Center;
            FirstConnection();
        }

        #endregion

        #region Methode Private

        /// <summary>
        /// Si l'utilisateur n'existe pas en db, le créer et lui demande de choisir sa section
        /// </summary>
        private void FirstConnection()
        {
            bool IsContinued = LoadControllerName();

            if (IsContinued)
            {
                FrmFirstStart FrmFirstStart = new FrmFirstStart(ADRWorkCenterUser, this);
                DialogResult DialogResult = FrmFirstStart.ShowDialog();

                if (DialogResult != DialogResult.OK)
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("Votre compte à été désactivé, contacter un administrateur pour plus de détailles");
                Application.Exit();
            }
        }

        /// <summary>
        /// Attribue les noms aux controlleurs depuis les fichiers ressources.
        /// </summary>
        private bool LoadControllerName()
        {
            using (WorkCenterUserRepository WorkCenterUserRepository = new WorkCenterUserRepository())
            {
                ADRWorkCenterUser = WorkCenterUserRepository.GetByUserId(FormUser.UserID);
            }

            if (ADRWorkCenterUser != null)
            {
                if (!ADRWorkCenterUser.IsDisabled)
                {
                    using (WorkCenterRepository WorkCenterRepository = new WorkCenterRepository())
                    {
                        ADRWorkCenter = WorkCenterRepository.Get(ADRWorkCenterUser.WorkCenterId);
                    }
                }
                else
                {
                    return false;
                }
            }

            string WorkCenter = ADRWorkCenter != null ? ADRWorkCenter.WorkCenter : "Pas de section";

            tssUser.Text = $"{SynapseForm.FormUser.ToString()} / {WorkCenter}";
            tssRole.Text = string.Empty;
            tssBlank.Text = " ";

            return true;
        }

        #endregion

        #region Event Click

        /// <summary>
        /// Boutton nouvelle analyse
        /// Permet de créer une nouvelle analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmNewAnalyse_Click(object sender, EventArgs e)
        {
            FrmAnalyse FrmNewAnalyse = new FrmAnalyse(ADRWorkCenter);
            FrmNewAnalyse.MdiParent = this;
            FrmNewAnalyse.WindowState = FormWindowState.Maximized;
            FrmNewAnalyse.Show();
        }

        /// <summary>
        /// Boutton mesure et parade
        /// Permet de gérer les mesures et parades en fonction des risques.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmEditMP_Click(object sender, EventArgs e)
        {
            FrmMesureParade FrmMesureParade = new FrmMesureParade(ADRWorkCenter, ADRWorkCenterUser);
            FrmMesureParade.WindowState = FormWindowState.Normal;
            FrmMesureParade.StartPosition = FormStartPosition.CenterScreen;
            FrmMesureParade.ShowDialog();
        }

        /// <summary>
        /// Boutton utilisateurs
        /// Modifie le workcenter des utilisateurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangeWK FrmCahngeWK = new FrmChangeWK(this);
            FrmCahngeWK.WindowState = FormWindowState.Normal;
            FrmCahngeWK.StartPosition = FormStartPosition.CenterScreen;
            FrmCahngeWK.ShowDialog();
        }

        /// <summary>
        /// Boutton historique
        /// Afficher l'historique du programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorique FrmHistorique = new FrmHistorique();
            FrmHistorique.MdiParent = this;
            FrmHistorique.WindowState = FormWindowState.Maximized;
            FrmHistorique.Show();
        }

        private void supprimerUneAnalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeleteAnalyse FrmDeleteAnalyse = new FrmDeleteAnalyse();
            FrmDeleteAnalyse.MdiParent = this;
            FrmDeleteAnalyse.WindowState = FormWindowState.Maximized;
            FrmDeleteAnalyse.Show();
        }

        /// <summary>
        /// Change la couleur au moment de l'ouverture du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;

            Item.ForeColor = Color.Black;
        }

        /// <summary>
        /// Change la couleur au moment de la fermeture du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownClosed(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;

            Item.ForeColor = SystemColors.Window;
        }

        #endregion

    }
}
