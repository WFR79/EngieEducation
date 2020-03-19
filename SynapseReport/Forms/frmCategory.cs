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
using SynapseReport.Functionalities;
namespace SynapseReport.Forms
{
    public partial class frmCategory : SynapseForm
    {
        private string _action = "";
        private Int64 _categoryID = 0;
        private Category _category = new Category();

        private IList<SynapseLanguage> languages = SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE");

        private uc_LabelBag bag = new uc_LabelBag();
        private Int64 lblid = 0;

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public Int64 CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public frmCategory()
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

                    _category.ID = 0;
                    _category.LABEL = new LabelBag();
                    _category.LABEL.Labels = new List<SynapseLabel>();

                    foreach (SynapseLanguage lang in languages)
                    {
                        SynapseLabel newlabel = new SynapseLabel();

                        newlabel.LABELID = 0;
                        newlabel.LANGUAGE = lang.CODE;
                        newlabel.TEXT = "";
                        _category.LABEL.Labels.Add(newlabel);
                    }
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                    _category = Category.LoadByID(_categoryID);

                    if (_category.LABEL.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (_category.LABEL.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();

                                newlabel.LABELID = _category.LABEL.GetLabelID();
                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                _category.LABEL.Labels.Add(newlabel);
                            }
                        }
                    }
                    break;
            }
            bag.FieldName = GetLabel("frmCategory.lblBag");
            bag.LblBag = _category.LABEL;
            bag.Visible = true;
            bag.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(bag);
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
                            lblid = SynapseLabel.GetNextID();
                            for (Int32 x = 0; x < bag.LblBag.Labels.Count; x++)
                            {
                                bag.LblBag.Labels[x].LABELID = lblid;
                            }
                            bag.Save();
                        }
                        else
                        {
                            lblid = bag.LblBag.Labels[0].LABELID;
                            bag.Save();
                        }

                    _category.ID = _categoryID;
                    switch (GlobalVariables.selectedOrigin.ORIGIN)
                    {
                        case Origin.Module:
                            _category.FK_MODULE = GlobalVariables.selectedOrigin.MODULEID;
                            _category.FK_INTERFACE = 0;
                            break;
                        case Origin.Interface:
                             _category.FK_MODULE = 0;
                             _category.FK_INTERFACE = GlobalVariables.selectedOrigin.INTERFACEID;
                            break;
                    }
                    
                    _category.LABELID = lblid;
                    _category.save();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
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
            this.Close();
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
