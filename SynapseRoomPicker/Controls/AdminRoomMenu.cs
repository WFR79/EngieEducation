﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseRoomPicker.Forms;
using System.ComponentModel;

namespace SynapseRoomPicker.Controls
{
    public partial class AdminRoomMenu : ToolStripMenuItem
    {
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

        private bool _AllowDelete = false;
        [Category("Synapse Framework"), Description("Allow Delete of Entity")]
        public bool AllowDelete
        {
            get { return _AllowDelete; }
            set { _AllowDelete = value; }
        }

        private bool _RoomNameMandatory = true;
        [Category("Synapse Framework"), Description("Room Name is Mandatory ?")]
        public bool RoomNameMandatory
        {
            get { return _RoomNameMandatory; }
            set { _RoomNameMandatory = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            frmRoomList fList = new frmRoomList();
            fList.ModuleID = _ModuleID;
            fList.SiteCode = _SiteCode;
            fList.AllowDelete = _AllowDelete;
            fList.RoomNameMandatory = _RoomNameMandatory;
            fList.MdiParent = (Form)this.OwnerItem.Owner.Parent;
            fList.Show();
        }
    }
}
