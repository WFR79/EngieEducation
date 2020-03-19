using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using SynapseRoomPicker.Functionalities;
using SynapseCore.Controls;

namespace SynapseRoomPickerDemo
{
    public partial class frmPickerDemo :SynapseForm
    {
        public frmPickerDemo()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            txSiteCode.Text = "KCD";
            txModuleID.Text = this.ModuleID.ToString();

            roomPickerCombo.ModuleID = int.Parse(txModuleID.Text);
            roomPickerTree.ModuleID = int.Parse(txModuleID.Text);
            roomPickerFree.ModuleID = int.Parse(txModuleID.Text);

            roomPickerCombo.Initialize(txSiteCode.Text);
            roomPickerTree.Initialize(txSiteCode.Text);
            roomPickerFree.Initialize(txSiteCode.Text);

            rbEntity.Checked = (roomPickerCombo.PickerType == SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Entity);
            rbBuilding.Checked = (roomPickerCombo.PickerType == SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Building);
            rbRoom.Checked = (roomPickerCombo.PickerType == SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room);

            ckNewEntity.Checked = roomPickerCombo.AllowNewEntity;
            ckNewBuilding.Checked = roomPickerCombo.AllowNewBuilding;
            ckNewRoom.Checked = roomPickerCombo.AllowNewRoom;
            ckNameMandatory.Checked = roomPickerCombo.RoomNameMandatory;

            if (ckNewRoom.Checked)
                ckNameMandatory.Visible = true;
            else
            {
                ckNameMandatory.Checked = true;
                ckNameMandatory.Visible = false;
            }

            ckSelectNew.Checked = roomPickerCombo.SelectNewAfterCreation;
            ckAvailable.Checked = roomPickerCombo.OnlyAvailable;
            ckImage.Checked = roomPickerTree.ShowImage;

            txEmptyLabel.Text = roomPickerCombo.EmptyMemberLabel;

            rbCode.Checked = (roomPickerCombo.DisplayMember == SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Code);
            rbName.Checked = (roomPickerCombo.DisplayMember == SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Name);

            //set same properties for roomPickerFree as for roomPickerTree as for roomPickerCombo
            roomPickerFree.PickerType = roomPickerCombo.PickerType;
            roomPickerFree.AllowNewEntity = roomPickerCombo.AllowNewEntity;
            roomPickerFree.AllowNewBuilding = roomPickerCombo.AllowNewBuilding;
            roomPickerFree.AllowNewRoom = roomPickerCombo.AllowNewRoom;
            roomPickerFree.RoomNameMandatory = roomPickerCombo.RoomNameMandatory;
            roomPickerFree.SelectNewAfterCreation = roomPickerCombo.SelectNewAfterCreation;
            roomPickerFree.OnlyAvailable = roomPickerCombo.OnlyAvailable;

            roomPickerTree.PickerType = roomPickerCombo.PickerType;
            roomPickerTree.AllowNewEntity = roomPickerCombo.AllowNewEntity;
            roomPickerTree.AllowNewBuilding = roomPickerCombo.AllowNewBuilding;
            roomPickerTree.AllowNewRoom = roomPickerCombo.AllowNewRoom;
            roomPickerTree.RoomNameMandatory = roomPickerCombo.RoomNameMandatory;
            roomPickerTree.SelectNewAfterCreation = roomPickerCombo.SelectNewAfterCreation;
            roomPickerTree.OnlyAvailable = roomPickerCombo.OnlyAvailable;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void roomPicker_SelectionChanged(object sender, EventArgs e)
        {
            txEntity.Text = roomPickerCombo.EntityID.ToString();
            txEntityObject.Text = "";
            if (roomPickerCombo.Entity != null)
            {
                foreach (PropertyInfo pty in roomPickerCombo.Entity.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerCombo.Entity, null) != null)
                        txEntityObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerCombo.Entity, null).ToString() + Environment.NewLine);
                }
            }

            txBuilding.Text = roomPickerCombo.BuildingID.ToString();
            txBuildingObject.Text = "";
            if (roomPickerCombo.Building != null)
            {
                foreach (PropertyInfo pty in roomPickerCombo.Building.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerCombo.Building, null) != null)
                        txBuildingObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerCombo.Building, null).ToString() + Environment.NewLine);
                }
            }

            txRoom.Text = roomPickerCombo.RoomID.ToString();
            txRoomObject.Text = "";
            if (roomPickerCombo.Room != null)
            {
                foreach (PropertyInfo pty in roomPickerCombo.Room.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerCombo.Room, null) != null)
                        txRoomObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerCombo.Room, null).ToString() + Environment.NewLine);
                }
            }
        }

        private void roomPickerFree_SelectionChanged(object sender, EventArgs e)
        {
            txEntity.Text = roomPickerFree.EntityID.ToString();
            txEntityObject.Text = "";
            if (roomPickerFree.Entity != null)
            {
                foreach (PropertyInfo pty in roomPickerFree.Entity.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerFree.Entity, null) != null)
                        txEntityObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerFree.Entity, null).ToString() + Environment.NewLine);
                }
            }

            txBuilding.Text = roomPickerFree.BuildingID.ToString();
            txBuildingObject.Text = "";
            if (roomPickerFree.Building != null)
            {
                foreach (PropertyInfo pty in roomPickerFree.Building.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerFree.Building, null) != null)
                        txBuildingObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerFree.Building, null).ToString() + Environment.NewLine);
                }
            }
        }

        private void ckNewEntity_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerCombo.AllowNewEntity = ckNewEntity.Checked;
            roomPickerTree.AllowNewEntity = ckNewEntity.Checked;
            roomPickerFree.AllowNewEntity = ckNewEntity.Checked;
        }

        private void ckNewBuilding_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerCombo.AllowNewBuilding = ckNewBuilding.Checked;
            roomPickerTree.AllowNewBuilding = ckNewBuilding.Checked;
            roomPickerFree.AllowNewBuilding = ckNewBuilding.Checked;
        }

        private void ckNewRoom_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerCombo.AllowNewRoom = ckNewRoom.Checked;
            roomPickerTree.AllowNewRoom = ckNewRoom.Checked;
            roomPickerFree.AllowNewRoom = ckNewRoom.Checked;
            ckNameMandatory.Visible = ckNewRoom.Checked;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            roomPickerCombo.Reset();
            roomPickerTree.Reset();
            roomPickerFree.Reset();
        }

        private void btSyncEntity_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerCombo.SynchronizeWithEntity(Int64.Parse(txSyncEntity.Text));
                roomPickerFree.SynchronizeWithEntity(Int64.Parse(txSyncEntity.Text));
            }
            catch
            { }
        }

        private void tbSyncEntityTree_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerTree.SynchronizeWithEntity(Int64.Parse(txSyncEntity.Text));
            }
            catch
            { }
        }

        private void btSyncBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerCombo.SynchronizeWithBuilding(Int64.Parse(txSyncBuilding.Text));
                roomPickerFree.SynchronizeWithBuilding(Int64.Parse(txSyncBuilding.Text));
            }
            catch
            { }
        }

        private void btSyncBuildingTree_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerTree.SynchronizeWithBuilding(Int64.Parse(txSyncBuilding.Text));
            }
            catch
            { }
        }

        private void btSyncRoom_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerCombo.SynchronizeWithRoom(Int64.Parse(txSyncRoom.Text));
                roomPickerFree.SynchronizeWithRoom(Int64.Parse(txSyncRoom.Text));
            }
            catch
            { }
        }

        private void btSyncRoomTree_Click(object sender, EventArgs e)
        {
            try
            {
                roomPickerTree.SynchronizeWithRoom(Int64.Parse(txSyncRoom.Text));
            }
            catch
            { }
        }

        private void PickerTypeChanged(object sender, EventArgs e)
        {
            if (rbEntity.Checked)
            {
                roomPickerCombo.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Entity;
                roomPickerTree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Entity;
                roomPickerFree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Entity;
            }
            if (rbBuilding.Checked)
            {
                roomPickerCombo.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Building;
                roomPickerTree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Building;
                roomPickerFree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Building;
            }
            if (rbRoom.Checked)
            {
                roomPickerCombo.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
                roomPickerTree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
                roomPickerFree.PickerType = SynapseRoomPicker.Functionalities.GlobalVariables.PickerType.Room;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txSiteCode.Text == "" || txModuleID.Text == "")
            {
                MessageBox.Show("Site Code and Module ID are mandatory fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                roomPickerCombo.ModuleID = int.Parse(txModuleID.Text);
                roomPickerTree.ModuleID = int.Parse(txModuleID.Text);
                roomPickerFree.ModuleID = int.Parse(txModuleID.Text);

                roomPickerCombo.Initialize(txSiteCode.Text);
                roomPickerTree.Initialize(txSiteCode.Text);
                roomPickerFree.Initialize(txSiteCode.Text);
            }
        }

        private void ckSelectNew_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerCombo.SelectNewAfterCreation = ckSelectNew.Checked;
            roomPickerTree.SelectNewAfterCreation = ckSelectNew.Checked;
            roomPickerFree.SelectNewAfterCreation = ckSelectNew.Checked;
        }

        private void ckAvailable_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerCombo.OnlyAvailable = ckAvailable.Checked;
            roomPickerTree.OnlyAvailable = ckAvailable.Checked;
            roomPickerFree.OnlyAvailable = ckAvailable.Checked;
        }

        private void btResetError_Click(object sender, EventArgs e)
        {
            roomPickerCombo.ResetError();
            roomPickerFree.ResetError();
        }

        private void btErrorEntity_Click(object sender, EventArgs e)
        {
            roomPickerCombo.SetErrorOnEntity(txMsgEntity.Text);
            roomPickerFree.SetErrorOnEntity(txMsgEntity.Text);
        }

        private void btErrorBuilding_Click(object sender, EventArgs e)
        {
            roomPickerCombo.SetErrorOnBuilding(txMsgBuilding.Text);
            roomPickerFree.SetErrorOnBuilding(txMsgBuilding.Text);
        }

        private void btErrorRoom_Click(object sender, EventArgs e)
        {
            roomPickerCombo.SetErrorOnRoom(txMsgRoom.Text);
            roomPickerFree.SetErrorOnRoom(txMsgRoom.Text);
        }

        private void txEmptyLabel_TextChanged(object sender, EventArgs e)
        {
            roomPickerCombo.EmptyMemberLabel = txEmptyLabel.Text;
            roomPickerFree.EmptyMemberLabel = txEmptyLabel.Text;
        }

        private void DisplayChanged(object sender, EventArgs e)
        {
            if (rbCode.Checked)
            {
                roomPickerCombo.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Code;
                roomPickerFree.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Code;
            }
            if (rbName.Checked)
            {
                roomPickerCombo.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Name;
                roomPickerFree.DisplayMember = SynapseRoomPicker.Functionalities.GlobalVariables.DisplayMember.Name;
            }
        }

        private void roomPickerTree_SelectionChanged(object sender, EventArgs e)
        {
            txEntity.Text = roomPickerTree.EntityID.ToString();
            txEntityObject.Text = "";
            if (roomPickerTree.Entity != null)
            {
                foreach (PropertyInfo pty in roomPickerTree.Entity.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerTree.Entity, null) != null)
                        txEntityObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerTree.Entity, null).ToString() + Environment.NewLine);
                }
            }

            txBuilding.Text = roomPickerTree.BuildingID.ToString();
            txBuildingObject.Text = "";
            if (roomPickerTree.Building != null)
            {
                foreach (PropertyInfo pty in roomPickerTree.Building.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerTree.Building, null) != null)
                        txBuildingObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerTree.Building, null).ToString() + Environment.NewLine);
                }
            }
            txRoom.Text = roomPickerTree.RoomID.ToString();
            txRoomObject.Text = "";
            if (roomPickerTree.Room != null)
            {
                foreach (PropertyInfo pty in roomPickerTree.Room.GetType().GetProperties())
                {
                    if (pty.GetValue(roomPickerTree.Room, null) != null)
                        txRoomObject.Text += (pty.Name + " = " + pty.GetValue(roomPickerTree.Room, null).ToString() + Environment.NewLine);
                }
            }
        }

        private void ckImage_CheckedChanged(object sender, EventArgs e)
        {
            roomPickerTree.ShowImage = ckImage.Checked;
            roomPickerTree.Reset();
        }

        private void ckNameMandatory_CheckedChanged(object sender, EventArgs e)
        {
            mnuAdminRoom.RoomNameMandatory = ckNameMandatory.Checked;
            roomPickerCombo.RoomNameMandatory = ckNameMandatory.Checked;
            roomPickerTree.RoomNameMandatory = ckNameMandatory.Checked;
            roomPickerFree.RoomNameMandatory = ckNameMandatory.Checked;
        }

        private void btGetRoomID_Click(object sender, EventArgs e)
        {
            Int64 roomID = roomPickerFree.GetRoomID();
            if (roomID != 0)
            {
                SynapseRoomPicker.Entities.RoomPicker_Room _rm = SynapseRoomPicker.Entities.RoomPicker_Room.LoadByID(roomID);

                txRoom.Text = _rm.ID.ToString();
                txRoomObject.Text = "";
                foreach (PropertyInfo pty in _rm.GetType().GetProperties())
                {
                    if (pty.GetValue(_rm, null) != null)
                        txRoomObject.Text += (pty.Name + " = " + pty.GetValue(_rm, null).ToString() + Environment.NewLine);
                }
            }
            else
                MessageBox.Show("This Room does not exists or cannot be created !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
