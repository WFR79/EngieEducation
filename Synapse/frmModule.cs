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
    public partial class frmModule : SynapseForm
    {
        private string _action = "";
        private Int64 _moduleID = 0;
        private Int64 lblid=0;
        private SynapseModule _module = new SynapseModule();

        private IList<SynapseLanguage> languages = SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE");

        private uc_LabelBag bagName = new uc_LabelBag();
        private uc_LabelBag bagDescription = new uc_LabelBag();

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public Int64 ID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }

        public frmModule()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            switch (_action)
            {
                case "NEW":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Create");

                    _module.ID = 0;

                    txPath.Text = "";
                    txTechnicalName.Text = "";
                    txVersion.Text = "";
                    txVersionDate.Text = "";
                    txCategory.Text = "";
                    txDevSources.Text = "";
                    txProdSources.Text = "";
                    ckActive.Checked = true;
                    ckRequestable.Checked = false;

                    _module.FriendlyName = new LabelBag();
                    _module.FriendlyName.Labels = new List<SynapseLabel>();
                    _module.Description = new LabelBag();
                    _module.Description.Labels = new List<SynapseLabel>();
                    foreach (SynapseLanguage lang in languages)
                    {
                        SynapseLabel newFriendlyName = new SynapseLabel();
                        newFriendlyName.LABELID = 0;
                        newFriendlyName.LANGUAGE = lang.CODE;
                        newFriendlyName.TEXT = "";
                        _module.FriendlyName.Labels.Add(newFriendlyName);

                        SynapseLabel newDescription = new SynapseLabel();
                        newDescription.LABELID = 0;
                        newDescription.LANGUAGE = lang.CODE;
                        newDescription.TEXT = "";
                        _module.Description.Labels.Add(newDescription);
                    }
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("Label.Edit");
                    _module = SynapseModule.LoadByID(_moduleID);

                    txPath.Text = _module.PATH;
                    txTechnicalName.Text = _module.TECHNICALNAME;
                    txVersion.Text = _module.VERSION;
                    txVersionDate.Text = _module.VERSIONDATE;
                    txCategory.Text = _module.MODULECATEGORY;
                    txDevSources.Text = _module.DEVSOURCE;
                    txProdSources.Text = _module.PRODSOURCE;
                    ckActive.Checked = _module.IS_ACTIVE;
                    ckRequestable.Checked = _module.IS_REQUESTABLE;

                    if (_module.FriendlyName.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (_module.FriendlyName.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();
                                newlabel.LABELID = _module.FriendlyName.GetLabelID();
                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                _module.FriendlyName.Labels.Add(newlabel);
                            }
                        }
                    }
                    if (_module.Description.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (_module.Description.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();
                                newlabel.LABELID = _module.Description.GetLabelID();
                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                _module.Description.Labels.Add(newlabel);
                            }
                        }
                    }
                    break;
            }
            bagName.FieldName = GetLabel("frmModule.gbFiendlyName");
            bagName.LblBag = _module.FriendlyName;
            bagName.Visible = true;
            bagName.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(bagName);

            bagDescription.FieldName = GetLabel("frmModule.gbDescription");
            bagDescription.LblBag = _module.Description;
            bagDescription.Visible = true;
            bagDescription.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(bagDescription);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    _module.ID = _moduleID;
                    _module.PATH = txPath.Text;
                    _module.TECHNICALNAME = txTechnicalName.Text;
                    _module.VERSION = txVersion.Text;
                    _module.VERSIONDATE = txVersionDate.Text;
                    _module.MODULECATEGORY = txCategory.Text;
                    _module.DEVSOURCE = txDevSources.Text;
                    _module.PRODSOURCE = txProdSources.Text;
                    _module.IS_ACTIVE = ckActive.Checked;
                    _module.IS_REQUESTABLE = ckRequestable.Checked;

                    if (bagName.LblBag.Labels[0].LABELID == 0)
                    {
                        lblid = SynapseLabel.GetNextID();
                        for (Int32 x = 0; x < bagName.LblBag.Labels.Count; x++)
                        {
                            bagName.LblBag.Labels[x].LABELID = lblid;
                        }
                        bagName.Save();
                    }
                    else
                    {
                        lblid = bagName.LblBag.Labels[0].LABELID;
                        bagName.Save();
                    }
                    _module.LABELID = lblid;

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
                    _module.DESCLABELID = lblid;
                    _module.save();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    MessageBox.Show("Data not saved in Database:" + ex.Message,"Database Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private Boolean checkFields()
        {
            bool isOK = true;
            synapseErrorProvider1.SetError(txPath, "");
            synapseErrorProvider1.SetError(txTechnicalName, "");
            synapseErrorProvider1.SetError(txVersion, "");
            synapseErrorProvider1.SetError(txVersionDate, "");
            synapseErrorProvider1.SetError(txCategory, "");

            

            txPath.MandatoryErrorMessage =GetLabel("Err.0010");
            txTechnicalName.MandatoryErrorMessage =GetLabel("Err.0011");
            txVersion.MandatoryErrorMessage =GetLabel("Err.0012");
            txVersionDate.MandatoryErrorMessage =GetLabel("Err.0013");
            txCategory.MandatoryErrorMessage =GetLabel("Err.0014");

            synapseErrorProvider1.ShowMessageBox = true;
            isOK = synapseErrorProvider1.ValidateControls();

            if (isOK)
            {
                IList<SynapseModule> _mods = SynapseModule.LoadFromPreparedQuery(@"SELECT * FROM SYNAPSE_MODULE WHERE TECHNICALNAME=@nvarchar0 AND ID <> @bigint1",
                    "Default", txTechnicalName.Text, _module.ID);
                if (_mods.Count > 0)
                {
                    synapseErrorProvider1.SetError(txTechnicalName, GetLabel("Err.0009"));
                    MessageBox.Show(GetLabel("Err.0009"), GetLabel("Err"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isOK = false;
                }
            }

            return isOK;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
