using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseRoomPicker.Entities;
using SynapseRoomPicker.Forms;
using SynapseRoomPicker.Functionalities;
namespace SynapseRoomPicker.Controls
{
    public partial class RoomPickerCombo : UserControl
    {
        public RoomPickerCombo()
        {
            InitializeComponent();
        }

        #region Public Properties
        private int _ModuleID=0;
        [Category("Synapse Framework"), Description("Synapse module ID")]
        public int ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }

        private string _SiteCode="";
        [Category("Synapse Framework"), Description("Site Code (CNT, KCD, ...)")]
        public string SiteCode
        {
            get { return _SiteCode; }
            set { _SiteCode = value; }
        }

        private GlobalVariables.DisplayMember _DisplayMember = GlobalVariables.DisplayMember.Code;
        [Category("Synapse Framework"), Description("Data to display in the List (Code, Name)")]
        public GlobalVariables.DisplayMember DisplayMember
        {
            get { return _DisplayMember; }
            set { _DisplayMember = value; }
        }

        private GlobalVariables.PickerType _PickerType;
        [Category("Synapse Framework"), Description("Picker Type (Entity, Building, Room)")]
        public GlobalVariables.PickerType PickerType
        {
            get { return _PickerType; }
            set 
            { 
                _PickerType = value;

                switch (_PickerType)
                {
                    case GlobalVariables.PickerType.Entity:
                        lbEntity.Visible = true;
                        cbEntity.Visible = true;
                        btNewEntity.Visible = _AllowNewEntity;

                        lbBuilding.Visible = false;
                        cbBuilding.Visible = false;
                        btNewBuilding.Visible = false;

                        lbRoom.Visible = false;
                        cbRoom.Visible = false;
                        btNewRoom.Visible = false;

                        this.Height = 21;
                        break;
                    case GlobalVariables.PickerType.Building:
                        lbEntity.Visible = true;
                        cbEntity.Visible = true;
                        btNewEntity.Visible = _AllowNewEntity;

                        lbBuilding.Visible = true;
                        cbBuilding.Visible = true;
                        btNewBuilding.Visible = _AllowNewBuilding;

                        lbRoom.Visible = false;
                        cbRoom.Visible = false;
                        btNewRoom.Visible = false;

                        this.Height = 48;
                        break;
                    case GlobalVariables.PickerType.Room:
                        lbEntity.Visible = true;
                        cbEntity.Visible = true;
                        btNewEntity.Visible = _AllowNewEntity;

                        lbBuilding.Visible = true;
                        cbBuilding.Visible = true;
                        btNewBuilding.Visible = _AllowNewBuilding;

                        lbRoom.Visible = true;
                        cbRoom.Visible = true;
                        btNewRoom.Visible = _AllowNewRoom;

                        this.Height = 73;
                        break;
                }
            }
        }

        private bool _OnlyAvailable = true;
        [Category("Synapse Framework"), Description("Show Only Available Entities, Buildings and Rooms")]
        public bool OnlyAvailable
        {
            get { return _OnlyAvailable; }
            set { _OnlyAvailable = value; }
        }

        private bool _AllowNewEntity = true;
        [Category("Synapse Framework"), Description("Show the Button to create a New Entity")]
        public bool AllowNewEntity
        {
            get { return _AllowNewEntity; }
            set 
            {
                if (_AllowNewEntity && !value)
                    cbEntity.Width += 35;
                if (!_AllowNewEntity && value)
                    cbEntity.Width -= 35;

                _AllowNewEntity = value;
                btNewEntity.Visible = _AllowNewEntity;
            }
        }

        private bool _AllowNewBuilding = true;
        [Category("Synapse Framework"), Description("Show the Button to create a New Building")]
        public bool AllowNewBuilding
        {
            get { return _AllowNewBuilding; }
            set 
            {
                if (_AllowNewBuilding && !value)
                    cbBuilding.Width += 35;
                if (!_AllowNewBuilding && value)
                    cbBuilding.Width -= 35;

                _AllowNewBuilding = value;
                btNewBuilding.Visible = _AllowNewBuilding && (_PickerType==GlobalVariables.PickerType.Building || _PickerType==GlobalVariables.PickerType.Room);
            }
        }

        private bool _AllowNewRoom = true;
        [Category("Synapse Framework"), Description("Show the Button to create a New Room")]
        public bool AllowNewRoom
        {
            get { return _AllowNewRoom; }
            set 
            {
                if (_AllowNewRoom && !value)
                    cbRoom.Width += 35;
                if (!_AllowNewRoom && value)
                    cbRoom.Width -= 35;

                _AllowNewRoom = value;
                btNewRoom.Visible = _AllowNewRoom && _PickerType == GlobalVariables.PickerType.Room;
            }
        }

        private bool _RoomNameMandatory = true;
        [Category("Synapse Framework"), Description("Room Name is Mandatory ?")]
        public bool RoomNameMandatory
        {
            get { return _RoomNameMandatory; }
            set { _RoomNameMandatory = value; }
        }

        private string _EmptyMemberLabel="";
        [Category("Synapse Framework"), Description("Label of first Member in the List (default=empty)")]
        public string EmptyMemberLabel
        {
            get { return _EmptyMemberLabel; }
            set 
            { 
                _EmptyMemberLabel = value;
            }
        }

        private bool _SelectNewAfterCreation=true;
        [Category("Synapse Framework"), Description("Automatically Select the newly created Item after New")]
        public bool SelectNewAfterCreation
        {
            get { return _SelectNewAfterCreation; }
            set { _SelectNewAfterCreation = value; }
        }

        [Category("Synapse Framework"), Description("Occurs when at least one selection has changed")]
        public event EventHandler SelectionChanged;

        private Int64 _EntityID=0;
        public Int64 EntityID
        {
            get { return _EntityID; }
        }
        private RoomPicker_Entity _Entity;
        public RoomPicker_Entity Entity
        {
            get { return _Entity; }
        }
        
        private Int64 _BuildingID=0;
        public Int64 BuildingID
        {
            get { return _BuildingID; }
        }
        private RoomPicker_Building _Building;
        public RoomPicker_Building Building
        {
            get { return _Building; }
        }

        private Int64 _RoomID=0;
        public Int64 RoomID
        {
            get { return _RoomID; }
        }
        private RoomPicker_Room _Room;
        public RoomPicker_Room Room
        {
            get { return _Room; }
        }
        #endregion

        #region Public Methods
        //-------------------------------------------------------------------
        // Initialize the Control with the Site Code & fill the Entities List
        //-------------------------------------------------------------------
        public void Initialize(string SiteCode="")
        {
            if (SiteCode !="")
                _SiteCode = SiteCode;

            lbEntity.Text = SynapseForm.GetLabel("RoomPicker.Entity");
            lbBuilding.Text = SynapseForm.GetLabel("RoomPicker.Building");
            lbRoom.Text = SynapseForm.GetLabel("RoomPicker.Room");

            fillEntity();
        }
        //-------------------------------------------------------------------
        // Deselect all the selected Items
        //-------------------------------------------------------------------
        public void Reset()
        {
            cbEntity.SelectedIndex = 0;
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity List with the Entity ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithEntity(Int64 ID)
        {
            fillEntity();
            _EntityID = ID;
            cbEntity.SelectedValue = _EntityID;
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity & Building List with the Building ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithBuilding(Int64 ID)
        {
            RoomPicker_Building _bd = RoomPicker_Building.LoadByID(ID);

            fillEntity();
            _EntityID = _bd.FK_ENTITY;
            cbEntity.SelectedValue = _EntityID;

            fillBuilding();
            _BuildingID = ID;
            cbBuilding.SelectedValue = _BuildingID;
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity, Building & Room List with the Room ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithRoom(Int64 ID)
        {
            RoomPicker_Room _rm = RoomPicker_Room.LoadByID(ID);
            RoomPicker_Building _bd = RoomPicker_Building.LoadByID(_rm.FK_BUILDING);

            fillEntity();
            _EntityID = _bd.FK_ENTITY;
            cbEntity.SelectedValue = _EntityID;

            fillBuilding();
            _BuildingID = _bd.ID;
            cbBuilding.SelectedValue = _BuildingID;

            fillRoom();
            _RoomID = ID;
            cbRoom.SelectedValue = _RoomID;
        }
        //-------------------------------------------------------------------
        // Reset the Error Provider for each control
        //-------------------------------------------------------------------
        public void ResetError()
        {
            synapseErrorProvider1.SetError(cbEntity, "");
            synapseErrorProvider1.SetError(cbBuilding, "");
            synapseErrorProvider1.SetError(cbRoom, "");
        }
        //-------------------------------------------------------------------
        // Display the Error Message on Entity combobox
        //-------------------------------------------------------------------
        public void SetErrorOnEntity(string msg)
        {
            synapseErrorProvider1.SetError(cbEntity, msg);
            cbEntity.Select();
        }
        //-------------------------------------------------------------------
        // Display the Error Message on Building combobox
        //-------------------------------------------------------------------
        public void SetErrorOnBuilding(string msg)
        {
            synapseErrorProvider1.SetError(cbBuilding, msg);
            cbBuilding.Select();
        }
        //-------------------------------------------------------------------
        // Display the Error Message on Room combobox
        //-------------------------------------------------------------------
        public void SetErrorOnRoom(string msg)
        {
            synapseErrorProvider1.SetError(cbRoom, msg);
            cbRoom.Select();
        }
        #endregion

        #region Public Events
        //-------------------------------------------------------------------
        // This Event is raised when the selection change on a combobox
        //-------------------------------------------------------------------
        protected virtual void OnSelectionChanged(object sender, EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(sender, e);
        }
        #endregion

        #region Private Methods
        //--------------------------------------------------------------------------------------------------------
        // Fill the Entity combobox based on properties: SiteCode, OnlyAvailable, EmptyMemberLabel & DisplayMember
        //--------------------------------------------------------------------------------------------------------
        private void fillEntity()
        {
            IList<RoomPicker_Entity> _list = new List<RoomPicker_Entity>();

            if (_OnlyAvailable)
                _list = RoomPicker_Entity.Load("WHERE AVAILABLE='True' AND SITE='" + _SiteCode + "' AND FK_MODULE=" + _ModuleID);
            else
                _list = RoomPicker_Entity.Load("WHERE SITE='" + _SiteCode + "' AND FK_MODULE=" + _ModuleID);

            RoomPicker_Entity _empty = new RoomPicker_Entity();
            _empty.CODE = " " + _EmptyMemberLabel;
            _empty.NAME = " " + _EmptyMemberLabel;
            _list.Add(_empty);

            cbEntity.ValueMember = "ID";
            if (_DisplayMember == GlobalVariables.DisplayMember.Code)
            {
                cbEntity.DisplayMember = "CODE";
                cbEntity.DataSource = _list.OrderBy(x => x.CODE).ToList();
            }
            else
            {
                cbEntity.DisplayMember = "NAME";
                cbEntity.DataSource = _list.OrderBy(x => x.NAME).ToList();
            }

            cbEntity.SelectedValue = _EntityID;
        }
        //--------------------------------------------------------------------------------------------------------
        // Fill the Building combobox for the selected Entity based on properties: SiteCode, OnlyAvailable, EmptyMemberLabel & DisplayMember
        //--------------------------------------------------------------------------------------------------------
        private void fillBuilding()
        {
            IList<RoomPicker_Building> _list = new List<RoomPicker_Building>();
            if (cbEntity.SelectedItem != null && ((RoomPicker_Entity)cbEntity.SelectedItem).ID != 0)
            {
                if (_OnlyAvailable)
                    _list = RoomPicker_Building.Load("WHERE AVAILABLE='True' AND SITE='" + _SiteCode + "' AND FK_ENTITY=" + cbEntity.SelectedValue + " AND FK_MODULE=" + _ModuleID);
                else
                    _list = RoomPicker_Building.Load("WHERE SITE='" + _SiteCode + "' AND FK_ENTITY=" + cbEntity.SelectedValue + " AND FK_MODULE=" + _ModuleID);
            }
            RoomPicker_Building _empty = new RoomPicker_Building();
            _empty.CODE = " " + _EmptyMemberLabel;
            _empty.NAME = " " + _EmptyMemberLabel;
            _list.Add(_empty);

            cbBuilding.ValueMember = "ID";
            if (_DisplayMember == GlobalVariables.DisplayMember.Code)
            {
                cbBuilding.DisplayMember = "CODE";
                cbBuilding.DataSource = _list.OrderBy(x => x.CODE).ToList();
            }
            else
            {
                cbBuilding.DisplayMember = "NAME";
                cbBuilding.DataSource = _list.OrderBy(x => x.NAME).ToList();
            }

            cbBuilding.SelectedValue = _BuildingID;
        }
        //--------------------------------------------------------------------------------------------------------
        // Fill the Room combobox for the selected BNuilding based on properties: SiteCode, OnlyAvailable, EmptyMemberLabel & DisplayMember
        //--------------------------------------------------------------------------------------------------------
        private void fillRoom()
        {
            IList<RoomPicker_Room> _list = new List<RoomPicker_Room>();
            if (cbBuilding.SelectedItem != null && ((RoomPicker_Building)cbBuilding.SelectedItem).ID != 0)
            {
                if (_OnlyAvailable)
                    _list = RoomPicker_Room.Load("WHERE AVAILABLE='True' AND SITE='" + _SiteCode + "' AND FK_BUILDING=" + cbBuilding.SelectedValue + " AND FK_MODULE=" + _ModuleID);
                else
                    _list = RoomPicker_Room.Load("WHERE SITE='" + _SiteCode + "' AND FK_BUILDING=" + cbBuilding.SelectedValue + " AND FK_MODULE=" + _ModuleID);
            }
            RoomPicker_Room _empty = new RoomPicker_Room();
            _empty.CODE = " " + _EmptyMemberLabel;
            _empty.NAME = " " + _EmptyMemberLabel;
            _list.Add(_empty);

            cbRoom.ValueMember = "ID";
            if (_DisplayMember == GlobalVariables.DisplayMember.Code)
            {
                cbRoom.DisplayMember = "CODE";
                cbRoom.DataSource = _list.OrderBy(x => x.CODE).ToList();
            }
            else
            {
                cbRoom.DisplayMember = "NAME";
                cbRoom.DataSource = _list.OrderBy(x => x.NAME).ToList();
            }

            cbRoom.SelectedValue = _RoomID;
        }
        #endregion

        #region Private Events
        //---------------------------------------------------------------------------------------------
        // On Entity Selection, Fill the corresponding Building List & Raise the SelectionChanged Event
        //---------------------------------------------------------------------------------------------
        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEntity.SelectedItem != null)
            {
                _EntityID = ((RoomPicker_Entity)cbEntity.SelectedItem).ID;
                _Entity = (RoomPicker_Entity)cbEntity.SelectedItem;
            }

            _BuildingID = 0;
            fillBuilding();

            OnSelectionChanged(cbEntity, EventArgs.Empty);
        }
        //---------------------------------------------------------------------------------------------
        // On Building Selection, Fill the corresponding Room List & Raise the SelectionChanged Event
        //---------------------------------------------------------------------------------------------
        private void cbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuilding.SelectedItem != null)
            {
                _BuildingID = ((RoomPicker_Building)cbBuilding.SelectedItem).ID;
                _Building = (RoomPicker_Building)cbBuilding.SelectedItem;
            }

            _RoomID = 0;
            fillRoom();

            OnSelectionChanged(cbBuilding, EventArgs.Empty);
        }
        //---------------------------------------------------------------------------------------------
        // On Room Selection, Raise the SelectionChanged Event
        //---------------------------------------------------------------------------------------------
        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoom.SelectedItem != null)
            {
                _RoomID = ((RoomPicker_Room)cbRoom.SelectedItem).ID;
                _Room = (RoomPicker_Room)cbRoom.SelectedItem;
            }

            OnSelectionChanged(cbRoom, EventArgs.Empty);
        }
        //---------------------------------------------------------------------------------------------
        // Show the Entity Creation Form
        //---------------------------------------------------------------------------------------------
        private void btNewEntity_Click(object sender, EventArgs e)
        {
            frmEntity fDetail = new frmEntity();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;
            RoomPicker_Entity _entity = new RoomPicker_Entity();
            _entity.SITE = _SiteCode;

            fDetail.Entity = _entity;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithEntity(fDetail.Entity.ID);
                }
                else
                {
                    _EntityID = 0;
                    fillEntity();
                }
            }
        }
        //---------------------------------------------------------------------------------------------
        // Show the Building Creation Form
        //---------------------------------------------------------------------------------------------
        private void btNewBuilding_Click(object sender, EventArgs e)
        {
            frmBuilding fDetail = new frmBuilding();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;
            fDetail.PreSelectedEntity = (Int64)cbEntity.SelectedValue;
            RoomPicker_Building _building = new RoomPicker_Building();
            _building.SITE = _SiteCode;

            fDetail.Entity = _building;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithBuilding(fDetail.Entity.ID);
                }
                else
                {
                    _BuildingID = 0;
                    fillBuilding();
                }
            }
        }
        //---------------------------------------------------------------------------------------------
        // Show the Room Creation Form
        //---------------------------------------------------------------------------------------------
        private void btNewRoom_Click(object sender, EventArgs e)
        {
            frmRoom fDetail = new frmRoom();
            fDetail.ModuleID = this.ModuleID;
            fDetail.RoomNameMandatory = _RoomNameMandatory;
            fDetail.Mode = GlobalVariables.EditMode.New;
            fDetail.PreSelectedEntity = (Int64)cbEntity.SelectedValue;
            fDetail.PreSelectedBuilding = (Int64)cbBuilding.SelectedValue;
            RoomPicker_Room _room = new RoomPicker_Room();
            _room.SITE = _SiteCode;

            fDetail.Entity = _room;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithRoom(fDetail.Entity.ID);
                }
                else
                {
                    _RoomID = 0;
                    fillRoom();
                }
            }
        }
        #endregion
    }
}
