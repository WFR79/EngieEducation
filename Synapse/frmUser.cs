using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseCore.Database;
namespace Synapse
{
    public partial class frmUser : SynapseForm
    {
        private string _action = "";
        private SynapseUser _user = new SynapseUser();

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public SynapseUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        public frmUser()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);
            fillCulture();

            switch (_action)
            {
                case "NEW":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Create");

                    _user.ID = 0;

                    txUserid.Text = "";
                    txFirstName.Text = "";
                    txLastName.Text = "";
                    cbCulture.SelectedIndex = -1;
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Edit");

                    txUserid.Text = _user.UserID;
                    txFirstName.Text = _user.FIRSTNAME;
                    txLastName.Text = _user.LASTNAME;
                    if (_user.CULTURE != null)
                        cbCulture.SelectedValue = _user.CULTURE;
                    else
                        cbCulture.SelectedIndex = -1;
                    break;
            }
        }

        private void fillCulture()
        {
            cbCulture.DataSource = SynapseLanguage.Load().OrderBy(x => x.LABEL).ToList();
            cbCulture.DisplayMember = "LABEL";
            cbCulture.ValueMember = "CULTURE";
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    _user.UserID = txUserid.Text;
                    _user.FIRSTNAME = txFirstName.Text;
                    _user.LASTNAME = txLastName.Text;
                    if (cbCulture.SelectedValue != null)
                        _user.CULTURE = cbCulture.SelectedValue.ToString();
                    _user.save();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    MessageBox.Show("Data not saved in Database:" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean checkFields()
        {
            synapseErrorProvider1.SetError(txUserid, "");
            synapseErrorProvider1.SetError(txFirstName, "");
            synapseErrorProvider1.SetError(txLastName, "");

            IList<SynapseUser> _users = SynapseUser.Load("WHERE USERID='" + txUserid.Text + "' AND ID <> " + _user.ID);
            if (_users.Count > 0)
            {
                synapseErrorProvider1.SetError(txUserid, GetLabel("Err.0015"));
                MessageBox.Show(GetLabel("Err.0015"), GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            txUserid.MandatoryErrorMessage = GetLabel("Err.0016");
            txFirstName.MandatoryErrorMessage = GetLabel("Err.0017");
            txLastName.MandatoryErrorMessage = GetLabel("Err.0018");

            synapseErrorProvider1.ShowMessageBox = true;
            return synapseErrorProvider1.ValidateControls();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
