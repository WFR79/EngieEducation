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
    public partial class frmRoom : SynapseForm
    {
        private GlobalVariables.EditMode _Mode;
        internal GlobalVariables.EditMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private RoomPicker_Room _entity;
        internal RoomPicker_Room Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        private Int64 _PreSelectedEntity = 0;
        internal Int64 PreSelectedEntity
        {
            get { return _PreSelectedEntity; }
            set { _PreSelectedEntity = value; }
        }

        private Int64 _PreSelectedBuilding = 0;
        internal Int64 PreSelectedBuilding
        {
            get { return _PreSelectedBuilding; }
            set { _PreSelectedBuilding = value; }
        }

        private bool _RoomNameMandatory = true;
        internal bool RoomNameMandatory
        {
            get { return _RoomNameMandatory; }
            set { _RoomNameMandatory = value; }
        }

        public frmRoom()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            ckAvailable.Text = GetLabel("frmRoom.ckAvailable");

            if (!_RoomNameMandatory)
            {
                lbName.Visible = false;
                txName.Visible = false;
            }

            displayEntity();

            switch (_Mode)
            {
                case GlobalVariables.EditMode.New:
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Create");
                    if (_PreSelectedEntity != 0)
                    {
                        cbEntity.SelectedValue = _PreSelectedEntity;
                        cbBuilding.Select();
                    }
                    else
                        cbEntity.SelectedIndex = -1;
                    if (_PreSelectedBuilding != 0)
                    {
                        cbBuilding.SelectedValue = _PreSelectedBuilding;
                        txCode.Select();
                    }
                    else
                        cbBuilding.SelectedIndex = -1;

                    txCode.Text = "";
                    txName.Text = "";
                    ckAvailable.Checked = true;
                    break;
                case GlobalVariables.EditMode.Edit:
                    _entity.dump();
                    //this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                    cbEntity.SelectedValue = RoomPicker_Building.LoadByID(_entity.FK_BUILDING).FK_ENTITY;
                    cbBuilding.SelectedValue = _entity.FK_BUILDING;
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

        private void displayBuilding()
        {
            if (cbEntity.SelectedItem != null)
            {
                IList<RoomPicker_Building> _list = new List<RoomPicker_Building>();
                _list = RoomPicker_Building.Load("WHERE SITE='" + _entity.SITE + "' AND FK_ENTITY=" + cbEntity.SelectedValue);

                cbBuilding.DisplayMember = "CODE";
                cbBuilding.ValueMember = "ID";
                cbBuilding.DataSource = _list.OrderBy(x => x.CODE).ToList();
            }
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayBuilding();
            cbBuilding.SelectedIndex = -1;
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
            synapseErrorProvider1.SetError(cbBuilding, "");

            if (cbEntity.SelectedIndex == -1)
            {
                GlobalFunctions.addError("RoomPicker.Err.0003");
                synapseErrorProvider1.SetError(cbEntity, SynapseForm.GetLabel("RoomPicker.Err.0003"));
                check = false;
            }

            if (cbBuilding.SelectedIndex == -1)
            {
                GlobalFunctions.addError("RoomPicker.Err.0006");
                synapseErrorProvider1.SetError(cbBuilding, SynapseForm.GetLabel("RoomPicker.Err.0006"));
                check = false;
            }

            if (txCode.Text == "")
            {
                GlobalFunctions.addError("RoomPicker.Err.0007");
                synapseErrorProvider1.SetError(txCode, SynapseForm.GetLabel("RoomPicker.Err.0007"));
                check = false;
            }

            if (_RoomNameMandatory)
            {
                if (txName.Text == "")
                {
                    GlobalFunctions.addError("RoomPicker.Err.0008");
                    synapseErrorProvider1.SetError(txName, SynapseForm.GetLabel("RoomPicker.Err.0008"));
                    check = false;
                }
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
            if (cbBuilding.SelectedValue != null)
                _entity.FK_BUILDING = (Int64)cbBuilding.SelectedValue;
            if (!_RoomNameMandatory)
                _entity.NAME = ((RoomPicker_Building)cbBuilding.SelectedItem).CODE + _entity.CODE;
            else
                _entity.NAME = txName.Text;
            _entity.FK_MODULE = this.ModuleID;
            _entity.AVAILABLE = ckAvailable.Checked;
        }
    }
}
