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
    public partial class frmGroup : SynapseForm
    {
        private string _action = "";
        private SynapseProfile _profile = new SynapseProfile();
        private IList<SynapseLanguage> languages = SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE");
        private uc_LabelBag bagDescription = new uc_LabelBag();

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public SynapseProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public frmGroup()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            ckOwner.Text = SynapseForm.GetLabel("frmGroup.ckOwner");

            fillModule();

            switch (_action)
            {
                case "NEW":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Create");

                    _profile.ID = 0;

                    cbModule.SelectedIndex = -1;
                    txTechnicalName.Text = "";
                    txLevel.Text = "";
                    ckOwner.Checked = false;

                    _profile.Description = new LabelBag();
                    _profile.Description.Labels = new List<SynapseLabel>();
                    foreach (SynapseLanguage lang in languages)
                    {
                        SynapseLabel newDescription = new SynapseLabel();
                        newDescription.LABELID = 0;
                        newDescription.LANGUAGE = lang.CODE;
                        newDescription.TEXT = "";
                        _profile.Description.Labels.Add(newDescription);
                    }
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Edit");

                    if (_profile.FK_ModuleID != null)
                        cbModule.SelectedValue = _profile.FK_ModuleID;
                    else
                        cbModule.SelectedIndex = -1;
                    txTechnicalName.Text = _profile.TECHNICALNAME;
                    txLevel.Text = _profile.LEVEL.ToString();
                    ckOwner.Checked = _profile.IS_OWNER;

                    if (_profile.Description.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (_profile.Description.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();
                                newlabel.LABELID = _profile.Description.GetLabelID();
                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                _profile.Description.Labels.Add(newlabel);
                            }
                        }
                    }
                    break;
            }
            bagDescription.FieldName = GetLabel("frmGroup.gbDescription");
            bagDescription.LblBag = _profile.Description;
            bagDescription.Visible = true;
            bagDescription.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(bagDescription);
        }

        private void fillModule()
        {
            cbModule.DataSource = SynapseModule.Load().OrderBy(x => x.FriendlyName.ToString()).ToList();
            cbModule.DisplayMember = "FriendlyName";
            cbModule.ValueMember = "ID";
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    _profile.FK_ModuleID = (Int64)cbModule.SelectedValue;
                    _profile.TECHNICALNAME = txTechnicalName.Text;
                    _profile.LEVEL = Int64.Parse("0" + txLevel.Text);
                    _profile.IS_OWNER = ckOwner.Checked;

                    Int64 lblid = 0;
                    if (bagDescription.LblBag.Labels[0].LABELID == 0)
                    {
                        lblid = SynapseLabel.GetNextID();
                        for (Int32 x = 0; x < bagDescription.LblBag.Labels.Count; x++)
                        {
                            bagDescription.LblBag.Labels[x].LABELID = lblid;
                        }
                        bagDescription.Save();
                    }
                    else
                    {
                        lblid = bagDescription.LblBag.Labels[0].LABELID;
                        bagDescription.Save();
                    }
                    _profile.FK_LABELID = lblid;
                    _profile.save();

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
            synapseErrorProvider1.SetError(cbModule, "");
            synapseErrorProvider1.SetError(txTechnicalName, "");
            synapseErrorProvider1.SetError(txLevel, "");

            IList<SynapseProfile> _profs = SynapseProfile.LoadFromPreparedQuery(@"SELECT * FROM SYNAPSE_SECURITY_PROFILE WHERE TECHNICALNAME=@nvarchar0 AND ID <> @bigint1", 
                "Default", txTechnicalName.Text, _profile.ID);
            if (_profs.Count > 0)
            {
                synapseErrorProvider1.SetError(txTechnicalName, GetLabel("Err.0004"));
                MessageBox.Show(GetLabel("Err.0004"), GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbModule.SelectedIndex < 0)
            {
                synapseErrorProvider1.SetError(cbModule, GetLabel("Err.0005"));
                MessageBox.Show(GetLabel("Err.0005"), GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            txTechnicalName.MandatoryErrorMessage = GetLabel("Err.0006");
            txLevel.MandatoryErrorMessage = GetLabel("Err.0007");
            txLevel.NotMatchErrorMessage = GetLabel("Err.0008");

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
