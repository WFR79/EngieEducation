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
    public partial class frmBuilding : SynapseForm
    {
        private GlobalVariables.EditMode _Mode;
        internal GlobalVariables.EditMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private RoomPicker_Building _entity;
        internal RoomPicker_Building Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        private Int64 _PreSelectedEntity=0;
        internal Int64 PreSelectedEntity
        {
            get { return _PreSelectedEntity; }
            set { _PreSelectedEntity = value; }
        }

        public frmBuilding()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            ckAvailable.Text = GetLabel("frmBuilding.ckAvailable");
            displayEntity();

            switch (_Mode)
            {
                case GlobalVariables.EditMode.New:
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Create");
                    if (_PreSelectedEntity != 0)
                    {
                        cbEntity.SelectedValue = _PreSelectedEntity;
                        txCode.Select();
                    }
                    else
                        cbEntity.SelectedIndex = -1;

                    txCode.Text = "";
                    txName.Text = "";
                    ckAvailable.Checked = true;
                    break;
                case GlobalVariables.EditMode.Edit:
                    _entity.dump();
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                    cbEntity.SelectedValue = _entity.FK_ENTITY;
                    txCode.Text = _entity.CODE;
                    txName.Text = _entity.NAME;
                    ckAvailable.Checked = _entity.AVAILABLE;
                    break;
            }
        }

        private void displayEntity()
        {
            IList<RoomPicker_Entity> _list = new List<RoomPicker_Entity>();

            if (_Mode == GlobalVariables.EditMode.New)
                _list = RoomPicker_Entity.Load("WHERE AVAILABLE='True' AND SITE='" + _entity.SITE + "' AND FK_MODULE=" + this.ModuleID);
            else
                _list = RoomPicker_Entity.Load("WHERE SITE='" + _entity.SITE + "' AND FK_MODULE=" + this.ModuleID);

            cbEntity.DisplayMember = "CODE";
            cbEntity.ValueMember = "ID";
            cbEntity.DataSource = _list.OrderBy(x => x.CODE).ToList();
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
            synapseErrorProvider1.SetError(cbEntity, "");

            if (cbEntity.SelectedIndex == -1)
            {
                GlobalFunctions.addError("RoomPicker.Err.0003");
                synapseErrorProvider1.SetError(cbEntity, SynapseForm.GetLabel("RoomPicker.Err.0003"));
                check = false;
            }

            if (txCode.Text == "")
            {
                GlobalFunctions.addError("RoomPicker.Err.0004");
                synapseErrorProvider1.SetError(txCode, SynapseForm.GetLabel("RoomPicker.Err.0004"));
                check = false;
            }

            if (txName.Text == "")
            {
                GlobalFunctions.addError("RoomPicker.Err.0005");
                synapseErrorProvider1.SetError(txName, SynapseForm.GetLabel("RoomPicker.Err.0005"));
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
            if (cbEntity.SelectedValue != null)
                _entity.FK_ENTITY = (Int64)cbEntity.SelectedValue;
            _entity.FK_MODULE = this.ModuleID;
            _entity.AVAILABLE = ckAvailable.Checked;
        }
    }
}
