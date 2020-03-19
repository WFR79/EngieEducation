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
    public partial class RoomPickerTree : UserControl
    {
        public RoomPickerTree()
        {
            InitializeComponent();

            colCode.ImageGetter = delegate(object x)
            {
                if (_ShowImage)
                {
                    if (x is RoomPicker_Entity)
                        return "entity";
                    else
                        if (x is RoomPicker_Building)
                            return "building";
                        else
                            if (x is RoomPicker_Room)
                                return "room2";
                }

                return null;
            };

            treeList.CanExpandGetter = delegate(object x)
            {
                if (x is Entities.RoomPicker_Entity)
                {
                    if (_PickerType == GlobalVariables.PickerType.Building || _PickerType == GlobalVariables.PickerType.Room)
                        return true;
                    else
                        return false;
                }
                if (x is Entities.RoomPicker_Building)
                {
                    if (_PickerType == GlobalVariables.PickerType.Room)
                        return true;
                    else
                        return false;
                }

                return false;
            };

            treeList.ChildrenGetter = delegate(object x)
            {
                if (x is Entities.RoomPicker_Entity)
                {
                    Entities.RoomPicker_Entity _ent = (Entities.RoomPicker_Entity)x;
                    IList<RoomPicker_Building> _list = new List<RoomPicker_Building>();
                    if (_OnlyAvailable)
                        _list = RoomPicker_Building.Load("WHERE AVAILABLE='True' AND SITE='" + _SiteCode + "' AND FK_ENTITY=" + _ent.ID + " AND FK_MODULE=" + _ModuleID);
                    else
                        _list = RoomPicker_Building.Load("WHERE SITE='" + _SiteCode + "' AND FK_ENTITY=" + _ent.ID + " AND FK_MODULE=" + _ModuleID);

                    return _list.OrderBy(y => y.CODE).ToList();
                }
                else
                {
                    Entities.RoomPicker_Building _bld = (Entities.RoomPicker_Building)x;
                    IList<RoomPicker_Room> _list = new List<RoomPicker_Room>();
                    if (_OnlyAvailable)
                        _list = RoomPicker_Room.Load("WHERE AVAILABLE='True' AND SITE='" + _SiteCode + "' AND FK_BUILDING=" + _bld.ID + " AND FK_MODULE=" + _ModuleID);
                    else
                        _list = RoomPicker_Room.Load("WHERE SITE='" + _SiteCode + "' AND FK_BUILDING=" + _bld.ID + " AND FK_MODULE=" + _ModuleID);

                    return _list.OrderBy(y => y.CODE).ToList();
                }
            };
        }

        #region Public Properties
        private int _ModuleID = 0;
        [Category("Synapse Framework"), Description("Synapse module ID")]
        public int ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }

        private string _SiteCode = "";
        [Category("Synapse Framework"), Description("Site Code (CNT, KCD, ...)")]
        public string SiteCode
        {
            get { return _SiteCode; }
            set { _SiteCode = value; }
        }

        private GlobalVariables.PickerType _PickerType;
        [Category("Synapse Framework"), Description("Picker Type (Entity, Building, Room)")]
        public GlobalVariables.PickerType PickerType
        {
            get { return _PickerType; }
            set
            {
                _PickerType = value;

                this.Initialize();
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
            set { _AllowNewEntity = value; }
        }

        private bool _AllowNewBuilding = true;
        [Category("Synapse Framework"), Description("Show the Button to create a New Building")]
        public bool AllowNewBuilding
        {
            get { return _AllowNewBuilding; }
            set { _AllowNewBuilding = value; }
        }

        private bool _AllowNewRoom = true;
        [Category("Synapse Framework"), Description("Show the Button to create a New Room")]
        public bool AllowNewRoom
        {
            get { return _AllowNewRoom; }
            set { _AllowNewRoom = value; }
        }

        private bool _RoomNameMandatory = true;
        [Category("Synapse Framework"), Description("Room Name is Mandatory ?")]
        public bool RoomNameMandatory
        {
            get { return _RoomNameMandatory; }
            set { _RoomNameMandatory = value; }
        }

        private bool _SelectNewAfterCreation = true;
        [Category("Synapse Framework"), Description("Automatically Select the newly created Item after New")]
        public bool SelectNewAfterCreation
        {
            get { return _SelectNewAfterCreation; }
            set { _SelectNewAfterCreation = value; }
        }

        private bool _ShowImage = true;
        [Category("Synapse Framework"), Description("Display an image on tree elements")]
        public bool ShowImage
        {
            get { return _ShowImage; }
            set
            {
                _ShowImage = value;

                if (_ShowImage)
                    treeList.SmallImageList = imageList1;
                else
                    treeList.SmallImageList = null;
            }
        }

        [Category("Synapse Framework"), Description("Occurs when at least one selection has changed")]
        public event EventHandler SelectionChanged;

        private Int64 _EntityID = 0;
        public Int64 EntityID
        {
            get { return _EntityID; }
        }
        private RoomPicker_Entity _Entity;
        public RoomPicker_Entity Entity
        {
            get { return _Entity; }
        }

        private Int64 _BuildingID = 0;
        public Int64 BuildingID
        {
            get { return _BuildingID; }
        }
        private RoomPicker_Building _Building;
        public RoomPicker_Building Building
        {
            get { return _Building; }
        }

        private Int64 _RoomID = 0;
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
        public void Initialize(string SiteCode = "")
        {
            if (SiteCode != "")
                _SiteCode = SiteCode;

            treeList.Items.Clear();

            fillEntity();
        }
        //-------------------------------------------------------------------
        // Deselect all the selected Items
        //-------------------------------------------------------------------
        public void Reset()
        {
            treeList.CollapseAll();
            treeList.SelectedIndex = -1;
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity List with the Entity ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithEntity(Int64 ID)
        {
            RoomPicker_Entity _en = RoomPicker_Entity.LoadByID(ID);

            treeList.Expand((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());
            treeList.SelectObject((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity & Building List with the Building ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithBuilding(Int64 ID)
        {
            RoomPicker_Building _bd = RoomPicker_Building.LoadByID(ID);
            RoomPicker_Entity _en = RoomPicker_Entity.LoadByID(_bd.FK_ENTITY);

            treeList.Expand((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());
            treeList.SelectObject((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());

            treeList.Expand((from b in treeList.GetChildren(treeList.SelectedObject).OfType<RoomPicker_Building>().ToList() where b.ID == _bd.ID select b).FirstOrDefault());
            treeList.SelectObject((from b in treeList.GetChildren(treeList.SelectedObject).OfType<RoomPicker_Building>().ToList() where b.ID == _bd.ID select b).FirstOrDefault());
        }
        //-------------------------------------------------------------------
        // Synchronize the Entity, Building & Room List with the Room ID passed in parameter
        //-------------------------------------------------------------------
        public void SynchronizeWithRoom(Int64 ID)
        {
            RoomPicker_Room _rm = RoomPicker_Room.LoadByID(ID);
            RoomPicker_Building _bd = RoomPicker_Building.LoadByID(_rm.FK_BUILDING);
            RoomPicker_Entity _en = RoomPicker_Entity.LoadByID(_bd.FK_ENTITY);

            treeList.Expand((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());
            treeList.SelectObject((from e in treeList.Objects.OfType<RoomPicker_Entity>().ToList() where e.ID == _en.ID select e).FirstOrDefault());

            treeList.Expand((from b in treeList.GetChildren(treeList.SelectedObject).OfType<RoomPicker_Building>().ToList() where b.ID == _bd.ID select b).FirstOrDefault());
            treeList.SelectObject((from b in treeList.GetChildren(treeList.SelectedObject).OfType<RoomPicker_Building>().ToList() where b.ID == _bd.ID select b).FirstOrDefault());

            treeList.SelectObject((from r in treeList.GetChildren(treeList.SelectedObject).OfType<RoomPicker_Room>().ToList() where r.ID == _rm.ID select r).FirstOrDefault());

            //OnSelectionChanged(treeList, EventArgs.Empty);
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

            treeList.SetObjects(_list.OrderBy(x => x.CODE).ToList());
        }
        #endregion

        #region private Events
        private void treeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeList.SelectedObject is Entities.RoomPicker_Entity)
            {
                _Entity = (Entities.RoomPicker_Entity)treeList.SelectedObject;
                _EntityID = _Entity.ID;

                _Building=new Entities.RoomPicker_Building();
                _BuildingID=0;

                _Room=new Entities.RoomPicker_Room();
                _RoomID=0;

                OnSelectionChanged(treeList, EventArgs.Empty);
            }

            if (treeList.SelectedObject is Entities.RoomPicker_Building)
            {
                _Entity = (Entities.RoomPicker_Entity)treeList.GetParent(treeList.SelectedObject);
                _EntityID = _Entity.ID;

                _Building=(Entities.RoomPicker_Building)treeList.SelectedObject;
                _BuildingID=_Building.ID;

                _Room=new Entities.RoomPicker_Room();
                _RoomID=0;

                OnSelectionChanged(treeList, EventArgs.Empty);
            }

            if (treeList.SelectedObject is Entities.RoomPicker_Room)
            {
                _Entity = (Entities.RoomPicker_Entity)treeList.GetParent(treeList.GetParent(treeList.SelectedObject));
                _EntityID = _Entity.ID;

                _Building = (Entities.RoomPicker_Building)treeList.GetParent(treeList.SelectedObject);
                _BuildingID = _Building.ID;

                _Room = (Entities.RoomPicker_Room)treeList.SelectedObject;
                _RoomID = _Room.ID;

                OnSelectionChanged(treeList, EventArgs.Empty);
            }
        }

        private void ctxRoomPicker_Opening(object sender, CancelEventArgs e)
        {
            ctxRoomPicker.Visible = (_AllowNewEntity || _AllowNewBuilding || _AllowNewRoom);

            ctxNewEntity.Visible = _AllowNewEntity;
            ctxNewBuilding.Visible = _AllowNewBuilding;
            ctxNewRoom.Visible = _AllowNewRoom;
        }

        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            if (treeList.SelectedObject is RoomPicker_Entity || treeList.SelectedObject is RoomPicker_Building)
                if (treeList.IsExpanded(treeList.SelectedObject))
                    treeList.Collapse(treeList.SelectedObject);
                else
                    treeList.Expand(treeList.SelectedObject);
        }

        //---------------------------------------------------------------------------------------------
        // Show the Entity Creation Form
        //---------------------------------------------------------------------------------------------
        private void ctxNewEntity_Click(object sender, EventArgs e)
        {
            frmEntity fDetail = new frmEntity();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;
            RoomPicker_Entity _entity = new RoomPicker_Entity();
            _entity.SITE = _SiteCode;

            fDetail.Entity = _entity;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeList.AddObject(fDetail.Entity);

                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithEntity(fDetail.Entity.ID);
                }
            }
        }

        //---------------------------------------------------------------------------------------------
        // Show the Building Creation Form
        //---------------------------------------------------------------------------------------------
        private void ctxNewBuilding_Click(object sender, EventArgs e)
        {
            frmBuilding fDetail = new frmBuilding();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;

            if (treeList.SelectedObject is RoomPicker_Entity)
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.SelectedObject).ID;

            if (treeList.SelectedObject is RoomPicker_Building)
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.GetParent(treeList.SelectedObject)).ID;

            if (treeList.SelectedObject is RoomPicker_Room)
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.GetParent(treeList.GetParent(treeList.SelectedObject))).ID;

            RoomPicker_Building _building = new RoomPicker_Building();
            _building.SITE = _SiteCode;

            fDetail.Entity = _building;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeList.RebuildAll(true);
                treeList.Expand(treeList.SelectedObject);

                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithBuilding(fDetail.Entity.ID);
                }
            }
        }

        //---------------------------------------------------------------------------------------------
        // Show the Room Creation Form
        //---------------------------------------------------------------------------------------------
        private void ctxNewRoom_Click(object sender, EventArgs e)
        {
            frmRoom fDetail = new frmRoom();
            fDetail.ModuleID = this.ModuleID;
            fDetail.RoomNameMandatory = _RoomNameMandatory;
            fDetail.Mode = GlobalVariables.EditMode.New;

            if (treeList.SelectedObject is RoomPicker_Entity)
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.SelectedObject).ID;

            if (treeList.SelectedObject is RoomPicker_Building)
            {
                fDetail.PreSelectedBuilding = ((Entities.RoomPicker_Building)treeList.SelectedObject).ID;
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.GetParent(treeList.SelectedObject)).ID;
            }

            if (treeList.SelectedObject is RoomPicker_Room)
            {
                fDetail.PreSelectedBuilding = ((Entities.RoomPicker_Building)treeList.GetParent(treeList.SelectedObject)).ID;
                fDetail.PreSelectedEntity = ((Entities.RoomPicker_Entity)treeList.GetParent(treeList.GetParent(treeList.SelectedObject))).ID;
            }

            RoomPicker_Room _room = new RoomPicker_Room();
            _room.SITE = _SiteCode;

            fDetail.Entity = _room;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeList.RebuildAll(true);
                treeList.Expand(treeList.SelectedObject);

                if (_SelectNewAfterCreation)
                {
                    this.SynchronizeWithRoom(fDetail.Entity.ID);
                }
            }
        }
        #endregion
    }
}
