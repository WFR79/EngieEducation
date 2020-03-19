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
    public partial class frmBuildingList : SynapseForm
    {
        private IList<RoomPicker_Entity> EntityList = new List<RoomPicker_Entity>();

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

        public frmBuildingList()
        {
            InitializeComponent();

            colEntity.AspectGetter = delegate(object x)
            {
                RoomPicker_Entity _entity = EntityList.Where(e => e.ID == ((RoomPicker_Building)x).FK_ENTITY).FirstOrDefault();
                return _entity.CODE;
            };

            colAvailable.AspectGetter = delegate(object x)
            {
                return (((RoomPicker_Building)x).AVAILABLE);
            };
            colAvailable.Renderer = new MappedImageRenderer(new Object[] { true, imageList.Images["True"], false, imageList.Images["False"] });
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            EntityList = RoomPicker_Entity.Load("WHERE FK_MODULE=" + this.ModuleID + " AND SITE='" + _SiteCode + "'");

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

            IList<RoomPicker_Building> _List = RoomPicker_Building.Load("WHERE SITE='" + _SiteCode + "' AND FK_MODULE=" + this.ModuleID);
            olvBuilding.SetObjects(_List);
        }

        private void updateSearchCheckboxes()
        {
            foreach (OLVColumn col in olvBuilding.AllColumns)
            {
                if (col.Searchable)
                {
                    synapseListFilter1.Items[6 + olvBuilding.AllColumns.IndexOf(col)].Text = col.Text;
                }
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewBuilding();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            EditBuilding();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteBuilding();
        }

        private void NewBuilding()
        {
            frmBuilding fDetail = new frmBuilding();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;
            RoomPicker_Building _building = new RoomPicker_Building();
            _building.SITE = _SiteCode;

            fDetail.Entity = _building;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvBuilding.AddObject(fDetail.Entity);
            }
        }

        private void EditBuilding()
        {
            frmBuilding fDetail = new frmBuilding();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.Edit;
            fDetail.Entity = (RoomPicker_Building)olvBuilding.SelectedObject;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvBuilding.RefreshObject(fDetail.Entity);
            }
        }

        private void DeleteBuilding()
        {

        }

        private void olvBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvBuilding.SelectedItems.Count > 0)
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
