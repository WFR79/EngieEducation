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
    public partial class FrmChoosCriticality : SynapseForm
    {
        #region Constructor

        public FrmChoosCriticality()
        {
            InitializeComponent();
        }

        #endregion

        #region Init

        public override void initForm(Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            btnValidate.Enabled = false;
        }

        #endregion

        #region Event

        /// <summary>
        /// Active le bouton validé si la valeur rentrée est égal à 2, 3 ou 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCriticalityLevel_TextChanged(object sender, EventArgs e)
        {
            TextBox TextBox = (TextBox)sender;

            if (TextBox.Text == "2" || TextBox.Text == "3" || TextBox.Text == "4")
                btnValidate.Enabled = true;
            else
                btnValidate.Enabled = false;
        }

        #endregion

        #region MyRegion

        /// <summary>
        /// Retourne la valeur de la criticité si elle est correct
        /// </summary>
        /// <returns></returns>
        public string SendCriticalityLevel()
        {
            if (txtCriticalityLevel.Text == "2" || txtCriticalityLevel.Text == "3" || txtCriticalityLevel.Text == "4")
                return txtCriticalityLevel.Text;
            else
                return string.Empty;
        }

        #endregion
    }
}
