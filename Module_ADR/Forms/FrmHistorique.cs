using Module_ADR.DataAccessLayer.Repos;
using Module_ADR.Models;
using SynapseCore.Controls;
using SynapseCore.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_ADR.Forms
{
    public partial class FrmHistorique : SynapseForm
    {
        #region Constructor

        public FrmHistorique()
        {
            InitializeComponent();
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            using (HistoriqueRepository HistoriqueRepository = new HistoriqueRepository())
            {
                oblvHistorique.SetObjects(HistoriqueRepository.Get());
            }
        }

        #endregion

        #region Methode

        /// <summary>
        /// Filtre les informations de la table historique
        /// </summary>
        private void SearchintoHistorique()
        {
            if (!string.IsNullOrEmpty(txtUserId.Text))
                using (HistoriqueRepository HistoriqueRepository = new HistoriqueRepository())
                {
                    oblvHistorique.SetObjects(HistoriqueRepository.Get().Where((h) => h.UserId == $"CORP\\{txtUserId.Text}"));
                }
            else
                using (HistoriqueRepository HistoriqueRepository = new HistoriqueRepository())
                {
                    oblvHistorique.SetObjects(HistoriqueRepository.Get());
                }
        }

        #endregion

        #region Event

        /// <summary>
        /// Evenement pour rechercher dans l'historique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchintoHistorique();
        }

        /// <summary>
        /// Enter redirige vers btnSrarch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        #endregion
    }
}
