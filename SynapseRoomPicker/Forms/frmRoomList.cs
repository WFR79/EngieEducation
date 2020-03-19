using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseAdvancedControls;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseRoomPicker.Entities;
using SynapseRoomPicker.Functionalities;

namespace SynapseRoomPicker.Forms
{
    public partial class frmRoomList : SynapseForm
    {
        private IList<RoomPicker_Entity> EntityList = new List<RoomPicker_Entity>();
        private IList<RoomPicker_Building> BuildingList = new List<RoomPicker_Building>();

        private string _SiteCode;
        public string SiteCode
        {
            get { return _SiteCode; }
            set { _SiteCode = value; }
        }

        private bool _AllowDelete;
        public bool AllowDelete
        {
            get { return _AllowDelete; }
            set { _AllowDelete = value; }
        }


        private bool _RoomNameMandatory = true;
        public bool RoomNameMandatory
        {
            get { return _RoomNameMandatory; }
            set { _RoomNameMandatory = value; }
        }

        public frmRoomList()
        {
            InitializeComponent();

            colEntity.AspectGetter = delegate(object x)
            {
                RoomPicker_Building _building = BuildingList.Where(b => b.ID == ((RoomPicker_Room)x).FK_BUILDING).FirstOrDefault();
                RoomPicker_Entity _entity = EntityList.Where(e => e.ID == _building.FK_ENTITY).FirstOrDefault();
                return _entity.CODE;
            };

            colBuilding.AspectGetter = delegate(object x)
            {
                RoomPicker_Building _building = BuildingList.Where(b => b.ID == ((RoomPicker_Room)x).FK_BUILDING).FirstOrDefault();
                return _building.CODE;
            };

            colAvailable.AspectGetter = delegate(object x)
            {
                return (((RoomPicker_Room)x).AVAILABLE);
            };
            colAvailable.Renderer = new MappedImageRenderer(new Object[] { true, imageList.Images["True"], false, imageList.Images["False"] });
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            EntityList = RoomPicker_Entity.Load("WHERE FK_MODULE=" + this.ModuleID + " AND SITE='" + _SiteCode + "'");
            BuildingList = RoomPicker_Building.Load("WHERE FK_MODULE=" + this.ModuleID + " AND SITE='" + _SiteCode + "'");

            if (!_RoomNameMandatory)
            {
                colName.FillsFreeSpace = false;
                colName.Searchable = false;
                colName.IsVisible = false;
                colCode.FillsFreeSpace = true;

                olvRoom.RebuildColumns();
            }

            updateSearchCheckboxes();

            tsbOpen.Enabled = false;
            tsbDelete.Enabled = false;
            ctxOpen.Enabled = false;
            ctxDelete.Enabled = false;

            if (!AllowDelete)
            {
                tsbDelete.Enabled = false;
                ctxDelete.Enabled = false;
                tsbDelete.Visible = false;
                ctxDelete.Visible = false;
            }

            IList<RoomPicker_Room> _List = RoomPicker_Room.Load("WHERE SITE='" + _SiteCode + "' AND FK_MODULE=" + this.ModuleID);
            olvRoom.SetObjects(_List);
        }

        private void updateSearchCheckboxes()
        {
            foreach (OLVColumn col in olvRoom.AllColumns)
            {
                if (col.Searchable)
                    synapseListFilter1.Items[6 + olvRoom.AllColumns.IndexOf(col)].Text = col.Text;
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewRoom();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            EditRoom();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteRoom();
        }

        private void NewRoom()
        {
            frmRoom fDetail = new frmRoom();
            fDetail.ModuleID = this.ModuleID;
            fDetail.RoomNameMandatory = _RoomNameMandatory;
            fDetail.Mode = GlobalVariables.EditMode.New;
            RoomPicker_Room _room = new RoomPicker_Room();
            _room.SITE = _SiteCode;

            fDetail.Entity = _room;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvRoom.AddObject(fDetail.Entity);
            }
        }

        private void EditRoom()
        {
            frmRoom fDetail = new frmRoom();
            fDetail.ModuleID = this.ModuleID;
            fDetail.RoomNameMandatory = _RoomNameMandatory;
            fDetail.Mode = GlobalVariables.EditMode.Edit;
            fDetail.Entity = (RoomPicker_Room)olvRoom.SelectedObject;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvRoom.RefreshObject(fDetail.Entity);
            }
        }

        private void DeleteRoom()
        {

        }

        private void olvRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvRoom.SelectedItems.Count > 0)
            {
                tsbOpen.Enabled = true;
                ctxOpen.Enabled = true;
                tsbDelete.Enabled = true;
                ctxDelete.Enabled = true;

                if (!AllowDelete)
                {
                    tsbDelete.Enabled = false;
                    ctxDelete.Enabled = false;
                    tsbDelete.Visible = false;
                    ctxDelete.Visible = false;
                }
            }
            else
            {
                tsbOpen.Enabled = false;
                ctxOpen.Enabled = false;
                tsbDelete.Enabled = false;
                ctxDelete.Enabled = false;
            }
        }
    }
}
