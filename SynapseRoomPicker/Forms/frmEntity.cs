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
using SynapseRoomPicker.Entities;
using SynapseRoomPicker.Functionalities;

namespace SynapseRoomPicker.Forms
{
    public partial class frmEntity : SynapseForm
    {
        private GlobalVariables.EditMode _Mode;
        internal GlobalVariables.EditMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private RoomPicker_Entity _entity;
        internal RoomPicker_Entity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public frmEntity()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            ckAvailable.Text = GetLabel("frmEntity.ckAvailable");

            switch (_Mode)
            {
                case GlobalVariables.EditMode.New:
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Create");
                    txCode.Text = "";
                    txName.Text = "";
                    ckAvailable.Checked = true;
                    break;
                case GlobalVariables.EditMode.Edit:
                    _entity.dump();
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                    txCode.Text = _entity.CODE;
                    txName.Text = _entity.NAME;
                    ckAvailable.Checked = _entity.AVAILABLE;
                    break;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private Boolean Save()
        {
            GlobalFunctions.resetError();

            if (checkFields())
            {
                fillEntity();

                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    _entity.save();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    GlobalFunctions.showMessage("ERR", "RoomPicker.Err.9999", ex.Message);
                    return false;
                }
            }
            else
            {
                GlobalFunctions.showError();
                return false;
            }
        }

        private Boolean checkFields()
        {
            Boolean check = true;
            synapseErrorProvider1.SetError(txCode, "");
            synapseErrorProvider1.SetError(txName, "");

            if (txCode.Text == "")
            {
                GlobalFunctions.addError("RoomPicker.Err.0001");
                synapseErrorProvider1.SetError(txCode, SynapseForm.GetLabel("RoomPicker.Err.0001"));
                check = false;
            }

            if (txName.Text == "")
            {
                GlobalFunctions.addError("RoomPicker.Err.0002");
                synapseErrorProvider1.SetError(txName, SynapseForm.GetLabel("RoomPicker.Err.0002"));
                check = false;
            }

            return check;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            _entity.rollback();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                fillEntity();

                if (_entity.IsDirty)
                {
                    DialogResult _result = GlobalFunctions.showMessage("QUEST&CANCEL", "RoomPicker.Quest.0001");
                    switch (_result)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            if (Save())
                            {
                                return;
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        default:
                            _entity.rollback();
                            break;
                    }
                }
            }
        }

        private void fillEntity()
        {
            _entity.CODE = txCode.Text;
            _entity.NAME = txName.Text;
            _entity.FK_MODULE = this.ModuleID;
            _entity.AVAILABLE = ckAvailable.Checked;
        }
    }
}
