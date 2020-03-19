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
    public partial class frmEntityList : SynapseForm
    {
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

        public frmEntityList()
        {
            InitializeComponent();

            colAvailable.AspectGetter = delegate(object x)
            {
                return (((RoomPicker_Entity)x).AVAILABLE);
            };
            colAvailable.Renderer = new MappedImageRenderer(new Object[] { true, imageList.Images["True"], false, imageList.Images["False"] });
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

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

            IList<RoomPicker_Entity> _List = RoomPicker_Entity.Load("WHERE SITE='" + _SiteCode + "' AND FK_MODULE=" + this.ModuleID);
            olvEntity.SetObjects(_List);
        }

        private void updateSearchCheckboxes()
        {
            foreach (OLVColumn col in olvEntity.AllColumns)
            {
                if (col.Searchable)
                {
                    synapseListFilter1.Items[6 + olvEntity.AllColumns.IndexOf(col)].Text = col.Text;
                }
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            EditEntity();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteEntity();
        }

        private void NewEntity()
        {
            frmEntity fDetail = new frmEntity();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.New;
            RoomPicker_Entity _entity = new RoomPicker_Entity();
            _entity.SITE = _SiteCode;

            fDetail.Entity = _entity;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvEntity.AddObject(fDetail.Entity);
            }
        }

        private void EditEntity()
        {
            frmEntity fDetail = new frmEntity();
            fDetail.ModuleID = this.ModuleID;
            fDetail.Mode = GlobalVariables.EditMode.Edit;
            fDetail.Entity = (RoomPicker_Entity)olvEntity.SelectedObject;
            if (fDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                olvEntity.RefreshObject(fDetail.Entity);
            }
        }

        private void DeleteEntity()
        {

        }

        private void olvEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvEntity.SelectedItems.Count > 0)
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
