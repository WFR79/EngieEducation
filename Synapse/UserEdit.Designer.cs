/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 24-05-2012
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Synapse
{
	partial class UserEdit
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEdit));
            this.olv_Users = new SynapseAdvancedControls.ObjectListView();
            this.olvcUsers = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn3 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn4 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxmenu_Edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.olv_Groups = new SynapseAdvancedControls.ObjectListView();
            this.olvcGroups = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.cb_Modules = new System.Windows.Forms.ComboBox();
            this.olv_GroupsOfUser = new SynapseAdvancedControls.ObjectListView();
            this.olvc_GroupName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvc_Module = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxmenu_Remove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ToolBar = new System.Windows.Forms.ToolStrip();
            this.btn_NewUser = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_NewGroup = new System.Windows.Forms.ToolStripButton();
            this.btn_EditPermission = new System.Windows.Forms.ToolStripButton();
            this.btn_SecurityOverview = new System.Windows.Forms.ToolStripButton();
            this.pb_UserIcon = new System.Windows.Forms.PictureBox();
            this.lbl_SelectedUser = new System.Windows.Forms.Label();
            this.sst_Status = new System.Windows.Forms.StatusStrip();
            this.ssl_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.olv_Users)).BeginInit();
            this.ctxmenu_Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv_Groups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv_GroupsOfUser)).BeginInit();
            this.ctxmenu_Remove.SuspendLayout();
            this.menu_ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserIcon)).BeginInit();
            this.sst_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // olv_Users
            // 
            this.olv_Users.AllColumns.Add(this.olvcUsers);
            this.olv_Users.AllColumns.Add(this.olvColumn3);
            this.olv_Users.AllColumns.Add(this.olvColumn4);
            this.olv_Users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.olv_Users.BackColor = System.Drawing.Color.Lavender;
            this.olv_Users.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcUsers,
            this.olvColumn3,
            this.olvColumn4});
            this.olv_Users.ContextMenuStrip = this.ctxmenu_Edit;
            this.olv_Users.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_Users.FullRowSelect = true;
            this.olv_Users.Location = new System.Drawing.Point(13, 81);
            this.olv_Users.Name = "olv_Users";
            this.olv_Users.ShowCommandMenuOnRightClick = true;
            this.olv_Users.ShowGroups = false;
            this.olv_Users.Size = new System.Drawing.Size(458, 218);
            this.olv_Users.SmallImageList = this.imageList1;
            this.olv_Users.TabIndex = 0;
            this.olv_Users.UseCompatibleStateImageBehavior = false;
            this.olv_Users.UseFiltering = true;
            this.olv_Users.UseHotItem = true;
            this.olv_Users.View = System.Windows.Forms.View.Details;
            this.olv_Users.SelectedIndexChanged += new System.EventHandler(this.Olv_UsersSelectedIndexChanged);
            // 
            // olvcUsers
            // 
            this.olvcUsers.AspectName = "UserID";
            this.olvcUsers.Text = "UserID";
            this.olvcUsers.Width = 130;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "FIRSTNAME";
            this.olvColumn3.Text = "Firstname";
            this.olvColumn3.Width = 150;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "LASTNAME";
            this.olvColumn4.Text = "Lastname";
            this.olvColumn4.Width = 150;
            // 
            // ctxmenu_Edit
            // 
            this.ctxmenu_Edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.listUsersToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ctxmenu_Edit.Name = "ctxmenu_Edit";
            this.ctxmenu_Edit.Size = new System.Drawing.Size(153, 92);
            this.ctxmenu_Edit.Opening += new System.ComponentModel.CancelEventHandler(this.ctxmenu_Edit_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // listUsersToolStripMenuItem
            // 
            this.listUsersToolStripMenuItem.Name = "listUsersToolStripMenuItem";
            this.listUsersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listUsersToolStripMenuItem.Text = "List Users";
            this.listUsersToolStripMenuItem.Click += new System.EventHandler(this.listUsersToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "User-Group-icon.png");
            this.imageList1.Images.SetKeyName(1, "User-Administrator-Blue-icon.png");
            // 
            // olv_Groups
            // 
            this.olv_Groups.AllColumns.Add(this.olvcGroups);
            this.olv_Groups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.olv_Groups.BackColor = System.Drawing.Color.Lavender;
            this.olv_Groups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcGroups});
            this.olv_Groups.ContextMenuStrip = this.ctxmenu_Edit;
            this.olv_Groups.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_Groups.IsSimpleDragSource = true;
            this.olv_Groups.LargeImageList = this.imageList1;
            this.olv_Groups.Location = new System.Drawing.Point(12, 332);
            this.olv_Groups.Name = "olv_Groups";
            this.olv_Groups.ShowGroups = false;
            this.olv_Groups.Size = new System.Drawing.Size(458, 292);
            this.olv_Groups.SmallImageList = this.imageList1;
            this.olv_Groups.TabIndex = 1;
            this.olv_Groups.UseCompatibleStateImageBehavior = false;
            this.olv_Groups.View = System.Windows.Forms.View.Details;
            // 
            // olvcGroups
            // 
            this.olvcGroups.AspectName = "TECHNICALNAME";
            this.olvcGroups.Text = "Groups";
            this.olvcGroups.Width = 320;
            // 
            // cb_Modules
            // 
            this.cb_Modules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Modules.FormattingEnabled = true;
            this.cb_Modules.Location = new System.Drawing.Point(13, 305);
            this.cb_Modules.Name = "cb_Modules";
            this.cb_Modules.Size = new System.Drawing.Size(458, 21);
            this.cb_Modules.TabIndex = 2;
            this.cb_Modules.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // olv_GroupsOfUser
            // 
            this.olv_GroupsOfUser.AllColumns.Add(this.olvc_GroupName);
            this.olv_GroupsOfUser.AllColumns.Add(this.olvc_Module);
            this.olv_GroupsOfUser.AllColumns.Add(this.olvColumn1);
            this.olv_GroupsOfUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv_GroupsOfUser.BackColor = System.Drawing.Color.Lavender;
            this.olv_GroupsOfUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvc_GroupName,
            this.olvc_Module});
            this.olv_GroupsOfUser.ContextMenuStrip = this.ctxmenu_Remove;
            this.olv_GroupsOfUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_GroupsOfUser.EmptyListMsg = "No Groups or no user selected";
            this.olv_GroupsOfUser.IsSimpleDropSink = true;
            this.olv_GroupsOfUser.LargeImageList = this.imageList1;
            this.olv_GroupsOfUser.Location = new System.Drawing.Point(477, 97);
            this.olv_GroupsOfUser.Name = "olv_GroupsOfUser";
            this.olv_GroupsOfUser.Size = new System.Drawing.Size(436, 527);
            this.olv_GroupsOfUser.SmallImageList = this.imageList1;
            this.olv_GroupsOfUser.TabIndex = 3;
            this.olv_GroupsOfUser.UseCompatibleStateImageBehavior = false;
            this.olv_GroupsOfUser.View = System.Windows.Forms.View.Details;
            this.olv_GroupsOfUser.ModelCanDrop += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.Olv_GroupsOfUserModelCanDrop);
            this.olv_GroupsOfUser.ModelDropped += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.Olv_GroupsOfUserModelDropped);
            // 
            // olvc_GroupName
            // 
            this.olvc_GroupName.Text = "Group";
            this.olvc_GroupName.Width = 200;
            // 
            // olvc_Module
            // 
            this.olvc_Module.Text = "Module";
            this.olvc_Module.Width = 200;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "FK_SECURITY_PROFILE";
            this.olvColumn1.DisplayIndex = 2;
            this.olvColumn1.IsVisible = false;
            this.olvColumn1.Width = 5;
            // 
            // ctxmenu_Remove
            // 
            this.ctxmenu_Remove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Remove});
            this.ctxmenu_Remove.Name = "ctxmenu_Remove";
            this.ctxmenu_Remove.Size = new System.Drawing.Size(125, 26);
            this.ctxmenu_Remove.Opening += new System.ComponentModel.CancelEventHandler(this.ctxmenu_Remove_Opening);
            // 
            // menu_Remove
            // 
            this.menu_Remove.Name = "menu_Remove";
            this.menu_Remove.Size = new System.Drawing.Size(124, 22);
            this.menu_Remove.Text = "Remove";
            this.menu_Remove.Click += new System.EventHandler(this.menu_RemoveClick);
            // 
            // menu_ToolBar
            // 
            this.menu_ToolBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menu_ToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu_ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_NewUser,
            this.btn_Save,
            this.btn_NewGroup,
            this.btn_EditPermission,
            this.btn_SecurityOverview});
            this.menu_ToolBar.Location = new System.Drawing.Point(0, 0);
            this.menu_ToolBar.Name = "menu_ToolBar";
            this.menu_ToolBar.Size = new System.Drawing.Size(925, 52);
            this.menu_ToolBar.TabIndex = 5;
            this.menu_ToolBar.Text = "toolStrip1";
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewUser.Image")));
            this.btn_NewUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(57, 49);
            this.btn_NewUser.Text = "New User";
            this.btn_NewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_NewUser.Click += new System.EventHandler(this.btn_NewUserClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(36, 49);
            this.btn_Save.Text = "Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Save.Click += new System.EventHandler(this.btn_SaveClick);
            // 
            // btn_NewGroup
            // 
            this.btn_NewGroup.Image = ((System.Drawing.Image)(resources.GetObject("btn_NewGroup.Image")));
            this.btn_NewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_NewGroup.Name = "btn_NewGroup";
            this.btn_NewGroup.Size = new System.Drawing.Size(64, 49);
            this.btn_NewGroup.Text = "New Group";
            this.btn_NewGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_NewGroup.Click += new System.EventHandler(this.btn_NewGroupClick);
            // 
            // btn_EditPermission
            // 
            this.btn_EditPermission.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_EditPermission.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditPermission.Image")));
            this.btn_EditPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_EditPermission.Name = "btn_EditPermission";
            this.btn_EditPermission.Size = new System.Drawing.Size(66, 49);
            this.btn_EditPermission.Text = "Permissions";
            this.btn_EditPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_EditPermission.Click += new System.EventHandler(this.btn_EditPermissionClick);
            // 
            // btn_SecurityOverview
            // 
            this.btn_SecurityOverview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_SecurityOverview.Image = ((System.Drawing.Image)(resources.GetObject("btn_SecurityOverview.Image")));
            this.btn_SecurityOverview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SecurityOverview.Name = "btn_SecurityOverview";
            this.btn_SecurityOverview.Size = new System.Drawing.Size(99, 49);
            this.btn_SecurityOverview.Text = "Security Overview";
            this.btn_SecurityOverview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_SecurityOverview.Click += new System.EventHandler(this.btn_SecurityOverview_Click);
            // 
            // pb_UserIcon
            // 
            this.pb_UserIcon.Image = ((System.Drawing.Image)(resources.GetObject("pb_UserIcon.Image")));
            this.pb_UserIcon.Location = new System.Drawing.Point(478, 56);
            this.pb_UserIcon.Name = "pb_UserIcon";
            this.pb_UserIcon.Size = new System.Drawing.Size(35, 35);
            this.pb_UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_UserIcon.TabIndex = 6;
            this.pb_UserIcon.TabStop = false;
            // 
            // lbl_SelectedUser
            // 
            this.lbl_SelectedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectedUser.Location = new System.Drawing.Point(520, 56);
            this.lbl_SelectedUser.Name = "lbl_SelectedUser";
            this.lbl_SelectedUser.Size = new System.Drawing.Size(277, 35);
            this.lbl_SelectedUser.TabIndex = 7;
            this.lbl_SelectedUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sst_Status
            // 
            this.sst_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssl_StatusLabel});
            this.sst_Status.Location = new System.Drawing.Point(0, 627);
            this.sst_Status.Name = "sst_Status";
            this.sst_Status.Size = new System.Drawing.Size(925, 22);
            this.sst_Status.TabIndex = 8;
            this.sst_Status.Text = "statusStrip1";
            // 
            // ssl_StatusLabel
            // 
            this.ssl_StatusLabel.Name = "ssl_StatusLabel";
            this.ssl_StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_Search
            // 
            this.lbl_Search.AutoSize = true;
            this.lbl_Search.Location = new System.Drawing.Point(302, 58);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(41, 13);
            this.lbl_Search.TabIndex = 9;
            this.lbl_Search.Text = "Search";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(370, 55);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(100, 20);
            this.txt_Search.TabIndex = 10;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 649);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.sst_Status);
            this.Controls.Add(this.lbl_SelectedUser);
            this.Controls.Add(this.pb_UserIcon);
            this.Controls.Add(this.menu_ToolBar);
            this.Controls.Add(this.olv_GroupsOfUser);
            this.Controls.Add(this.olv_Users);
            this.Controls.Add(this.olv_Groups);
            this.Controls.Add(this.cb_Modules);
            this.ModuleID = 1;
            this.Name = "UserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserEdit";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.UserEditLoad);
            ((System.ComponentModel.ISupportInitialize)(this.olv_Users)).EndInit();
            this.ctxmenu_Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olv_Groups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv_GroupsOfUser)).EndInit();
            this.ctxmenu_Remove.ResumeLayout(false);
            this.menu_ToolBar.ResumeLayout(false);
            this.menu_ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserIcon)).EndInit();
            this.sst_Status.ResumeLayout(false);
            this.sst_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
		private System.Windows.Forms.ComboBox cb_Modules;
		private SynapseAdvancedControls.ObjectListView olv_GroupsOfUser;
		private SynapseAdvancedControls.ObjectListView olv_Groups;
		private SynapseAdvancedControls.ObjectListView olv_Users;
		private SynapseAdvancedControls.OLVColumn olvcUsers;
		private SynapseAdvancedControls.OLVColumn olvcGroups;
		private SynapseAdvancedControls.OLVColumn olvColumn3;
		private SynapseAdvancedControls.OLVColumn olvColumn4;
		private System.Windows.Forms.ImageList imageList1;
		private SynapseAdvancedControls.OLVColumn olvColumn1;
		private SynapseAdvancedControls.OLVColumn olvc_GroupName;
		private SynapseAdvancedControls.OLVColumn olvc_Module;
		private System.Windows.Forms.ToolStrip menu_ToolBar;
		private System.Windows.Forms.ToolStripButton btn_NewUser;
		private System.Windows.Forms.ToolStripButton btn_Save;
		private System.Windows.Forms.PictureBox pb_UserIcon;
		private System.Windows.Forms.Label lbl_SelectedUser;
		private System.Windows.Forms.ToolStripButton btn_NewGroup;
		private System.Windows.Forms.ToolStripButton btn_EditPermission;
		private System.Windows.Forms.ContextMenuStrip ctxmenu_Remove;
		private System.Windows.Forms.ToolStripMenuItem menu_Remove;
        private System.Windows.Forms.StatusStrip sst_Status;
        private System.Windows.Forms.ToolStripStatusLabel ssl_StatusLabel;
        private System.Windows.Forms.ContextMenuStrip ctxmenu_Edit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btn_SecurityOverview;
        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
}
}
