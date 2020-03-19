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
using SynapseReport.Entities;

namespace SynapseReport.Forms
{
    public partial class frmLabelML : SynapseForm
    {
        private string _action = "";
        private LabelBag _lblBag;
        private string _labelName = "";

        private IList<SynapseLanguage> languages = SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE");

        private uc_LabelBag _bag = new uc_LabelBag();
        private Int64 lblid = 0;

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public LabelBag LabelBag
        {
            get { return _lblBag; }
            set { _lblBag = value; }
        }
        public string LabelName
        {
            get { return _labelName; }
            set { _labelName = value; }
        }

        public frmLabelML()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            switch (_action)
            {
                case "NEW":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Create");

                    _lblBag.Labels = new List<SynapseLabel>();

                    foreach (SynapseLanguage lang in languages)
                    {
                        SynapseLabel newlabel = new SynapseLabel();

                        newlabel.LABELID = 0;
                        newlabel.LANGUAGE = lang.CODE;
                        newlabel.TEXT = "";
                        _lblBag.Labels.Add(newlabel);
                    }
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                     lblid = _lblBag.GetLabelID();

                     if (_lblBag.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (_lblBag.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();

                                newlabel.LABELID = lblid;

                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                _lblBag.Labels.Add(newlabel);
                            }
                        }
                    }
                    break;
            }
            _bag.FieldName = _labelName;
            _bag.LblBag = _lblBag;
            _bag.Visible = true;
            _bag.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(_bag);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            GlobalFunctions.resetError();

            if (checkFields())
            {
                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    foreach (uc_LabelBag bag in flowLayoutPanel1.Controls)
                        if (bag.LblBag.Labels[0].LABELID == 0)
                        {
                            Int64 lblID = SynapseLabel.GetNextID();
                            for (Int32 x = 0; x < bag.LblBag.Labels.Count; x++)
                            {
                                bag.LblBag.Labels[x].LABELID = lblID;
                            }
                            bag.Save();
                        }
                        else
                        { 
                            bag.Save();             
                        }

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    GlobalFunctions.showMessage("ERR", "Err.9999", ex.Message);
                }
            }
            else
            {
                GlobalFunctions.showError();
            }
        }

        private Boolean checkFields()
        {
            Boolean check = true;

            foreach (uc_LabelBag bag in flowLayoutPanel1.Controls)
            {
                bag.Refresh();

                foreach (SynapseLabel lbText in bag.LblBag.Labels)
                {
                    if (lbText.TEXT == "")
                        check = false;
                }
                if (!check)
                    GlobalFunctions.addError("Err.0001");
            }

            return check;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
