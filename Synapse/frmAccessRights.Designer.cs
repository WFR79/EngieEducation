namespace Synapse
{
    partial class frmAccessRights
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessRights));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbModule = new System.Windows.Forms.GroupBox();
            this.cbModules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewUser = new System.Windows.Forms.ToolStripButton();
            this.tsbEditUser = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslUserSearch = new System.Windows.Forms.ToolStripLabel();
            this.txUserSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.olvUsers = new SynapseAdvancedControls.ObjectListView();
            this.olvUsers_USERID = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUsers_FIRSTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUsers_LASTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxAddUserToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.olvGroups = new SynapseAdvancedControls.ObjectListView();
            this.olvGroups_Group = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroups_Description = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroups_Owner = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroups_Level = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxAddUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNewGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbEditGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.tsSepGroups = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddUserGroup = new System.Windows.Forms.ToolStripButton();
            this.gbUserDetail = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbDeleteUserGroup = new System.Windows.Forms.ToolStripButton();
            this.pb_UserIcon = new System.Windows.Forms.PictureBox();
            this.olvUserGroups = new SynapseAdvancedControls.ObjectListView();
            this.olvUserGroup_GroupName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUserGroup_Description = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUserGroup_Module = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxUserGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxDeleteUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSelectedUser = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbModule2 = new System.Windows.Forms.GroupBox();
            this.cbModules2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbNewGroup2 = new System.Windows.Forms.ToolStripButton();
            this.tsbEditGroup2 = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteGroup2 = new System.Windows.Forms.ToolStripButton();
            this.olvGroups2 = new SynapseAdvancedControls.ObjectListView();
            this.olvGroup2_Group = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroup2_Owner = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroup2_Level = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbNewUser2 = new System.Windows.Forms.ToolStripButton();
            this.tsbEditUser2 = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteUser2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tslSearch = new System.Windows.Forms.ToolStripLabel();
            this.txUserSearch2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddUserToGroup = new System.Windows.Forms.ToolStripButton();
            this.olvUsers2 = new SynapseAdvancedControls.ObjectListView();
            this.olvUsers2_USERID = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUsers2_FIRSTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvUsers2_LASTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.mnuMainAccessRights = new System.Windows.Forms.MenuStrip();
            this.mnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddUserToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveUserFromGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbGroupDescription = new System.Windows.Forms.Label();
            this.olvGroupUsers = new SynapseAdvancedControls.ObjectListView();
            this.olvGroupUsers_USERID = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroupUsers_FIRSTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvGroupUsers_LASTNAME = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ctxGroupUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxRemoveUserFromGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.tsbRemoveUserFromGroup = new System.Windows.Forms.ToolStripButton();
            this.lbSelectedGroup = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbModule.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbUsers.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers)).BeginInit();
            this.ctxUsers.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroups)).BeginInit();
            this.ctxGroups.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbUserDetail.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvUserGroups)).BeginInit();
            this.ctxUserGroups.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbModule2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroups2)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers2)).BeginInit();
            this.mnuMainAccessRights.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroupUsers)).BeginInit();
            this.ctxGroupUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip6.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1037, 539);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbModule);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1029, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "By User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbModule
            // 
            this.gbModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModule.Controls.Add(this.cbModules);
            this.gbModule.Controls.Add(this.label1);
            this.gbModule.Location = new System.Drawing.Point(9, 6);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(1011, 49);
            this.gbModule.TabIndex = 5;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Module Selection";
            // 
            // cbModules
            // 
            this.cbModules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModules.FormattingEnabled = true;
            this.cbModules.Location = new System.Drawing.Point(54, 19);
            this.cbModules.Name = "cbModules";
            this.cbModules.Size = new System.Drawing.Size(951, 21);
            this.cbModules.TabIndex = 3;
            this.cbModules.SelectedIndexChanged += new System.EventHandler(this.cbModules_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Module";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbUsers);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 471);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbUsers
            // 
            this.gbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUsers.Controls.Add(this.toolStrip1);
            this.gbUsers.Controls.Add(this.olvUsers);
            this.gbUsers.Location = new System.Drawing.Point(6, 3);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(360, 443);
            this.gbUsers.TabIndex = 1;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "User\'s List";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewUser,
            this.tsbEditUser,
            this.tsbDeleteUser,
            this.toolStripSeparator1,
            this.tslUserSearch,
            this.txUserSearch,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(354, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewUser
            // 
            this.tsbNewUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewUser.Image")));
            this.tsbNewUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewUser.Name = "tsbNewUser";
            this.tsbNewUser.Size = new System.Drawing.Size(28, 28);
            this.tsbNewUser.Text = "New";
            this.tsbNewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // tsbEditUser
            // 
            this.tsbEditUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditUser.Image")));
            this.tsbEditUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditUser.Name = "tsbEditUser";
            this.tsbEditUser.Size = new System.Drawing.Size(28, 28);
            this.tsbEditUser.Text = "Edit";
            this.tsbEditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // tsbDeleteUser
            // 
            this.tsbDeleteUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteUser.Image")));
            this.tsbDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteUser.Name = "tsbDeleteUser";
            this.tsbDeleteUser.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteUser.Text = "Delete";
            this.tsbDeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tslUserSearch
            // 
            this.tslUserSearch.Name = "tslUserSearch";
            this.tslUserSearch.Size = new System.Drawing.Size(40, 28);
            this.tslUserSearch.Text = "Search";
            // 
            // txUserSearch
            // 
            this.txUserSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txUserSearch.Name = "txUserSearch";
            this.txUserSearch.Size = new System.Drawing.Size(100, 31);
            this.txUserSearch.TextChanged += new System.EventHandler(this.txUserSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // olvUsers
            // 
            this.olvUsers.AllColumns.Add(this.olvUsers_USERID);
            this.olvUsers.AllColumns.Add(this.olvUsers_FIRSTNAME);
            this.olvUsers.AllColumns.Add(this.olvUsers_LASTNAME);
            this.olvUsers.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvUsers_USERID,
            this.olvUsers_FIRSTNAME,
            this.olvUsers_LASTNAME});
            this.olvUsers.ContextMenuStrip = this.ctxUsers;
            this.olvUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvUsers.FullRowSelect = true;
            this.olvUsers.GridLines = true;
            this.olvUsers.HideSelection = false;
            this.olvUsers.Location = new System.Drawing.Point(6, 50);
            this.olvUsers.MultiSelect = false;
            this.olvUsers.Name = "olvUsers";
            this.olvUsers.ShowCommandMenuOnRightClick = true;
            this.olvUsers.ShowGroups = false;
            this.olvUsers.Size = new System.Drawing.Size(348, 387);
            this.olvUsers.SmallImageList = this.imageList1;
            this.olvUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvUsers.TabIndex = 0;
            this.olvUsers.UseAlternatingBackColors = true;
            this.olvUsers.UseCompatibleStateImageBehavior = false;
            this.olvUsers.UseFiltering = true;
            this.olvUsers.UseHotItem = true;
            this.olvUsers.View = System.Windows.Forms.View.Details;
            this.olvUsers.SelectedIndexChanged += new System.EventHandler(this.olvUsers_SelectedIndexChanged);
            this.olvUsers.DoubleClick += new System.EventHandler(this.EditUser_Click);
            // 
            // olvUsers_USERID
            // 
            this.olvUsers_USERID.AspectName = "UserID";
            this.olvUsers_USERID.Text = "Userid";
            this.olvUsers_USERID.Width = 150;
            // 
            // olvUsers_FIRSTNAME
            // 
            this.olvUsers_FIRSTNAME.AspectName = "FIRSTNAME";
            this.olvUsers_FIRSTNAME.Text = "Firstname";
            this.olvUsers_FIRSTNAME.Width = 90;
            // 
            // olvUsers_LASTNAME
            // 
            this.olvUsers_LASTNAME.AspectName = "LASTNAME";
            this.olvUsers_LASTNAME.FillsFreeSpace = true;
            this.olvUsers_LASTNAME.Text = "Lastname";
            this.olvUsers_LASTNAME.Width = 100;
            // 
            // ctxUsers
            // 
            this.ctxUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNewUser,
            this.ctxEditUser,
            this.ctxDeleteUser,
            this.toolStripSeparator3,
            this.ctxAddUserToGroup});
            this.ctxUsers.Name = "ctxUsers";
            this.ctxUsers.Size = new System.Drawing.Size(214, 98);
            // 
            // ctxNewUser
            // 
            this.ctxNewUser.Image = ((System.Drawing.Image)(resources.GetObject("ctxNewUser.Image")));
            this.ctxNewUser.Name = "ctxNewUser";
            this.ctxNewUser.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxNewUser.Size = new System.Drawing.Size(213, 22);
            this.ctxNewUser.Text = "New";
            this.ctxNewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // ctxEditUser
            // 
            this.ctxEditUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctxEditUser.Image = ((System.Drawing.Image)(resources.GetObject("ctxEditUser.Image")));
            this.ctxEditUser.Name = "ctxEditUser";
            this.ctxEditUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ctxEditUser.Size = new System.Drawing.Size(213, 22);
            this.ctxEditUser.Text = "Edit";
            this.ctxEditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // ctxDeleteUser
            // 
            this.ctxDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("ctxDeleteUser.Image")));
            this.ctxDeleteUser.Name = "ctxDeleteUser";
            this.ctxDeleteUser.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDeleteUser.Size = new System.Drawing.Size(213, 22);
            this.ctxDeleteUser.Text = "Delete";
            this.ctxDeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // ctxAddUserToGroup
            // 
            this.ctxAddUserToGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddUserToGroup.Image")));
            this.ctxAddUserToGroup.Name = "ctxAddUserToGroup";
            this.ctxAddUserToGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.ctxAddUserToGroup.Size = new System.Drawing.Size(213, 22);
            this.ctxAddUserToGroup.Text = "Add User to Group";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "User-Group-icon.png");
            this.imageList1.Images.SetKeyName(1, "User-Administrator-Blue-icon.png");
            this.imageList1.Images.SetKeyName(2, "ok.png");
            this.imageList1.Images.SetKeyName(3, "NotOK.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbUserDetail);
            this.splitContainer2.Size = new System.Drawing.Size(650, 471);
            this.splitContainer2.SplitterDistance = 213;
            this.splitContainer2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.olvGroups);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group\'s List";
            // 
            // olvGroups
            // 
            this.olvGroups.AllColumns.Add(this.olvGroups_Group);
            this.olvGroups.AllColumns.Add(this.olvGroups_Description);
            this.olvGroups.AllColumns.Add(this.olvGroups_Owner);
            this.olvGroups.AllColumns.Add(this.olvGroups_Level);
            this.olvGroups.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvGroups.BackColor = System.Drawing.SystemColors.Window;
            this.olvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvGroups_Group,
            this.olvGroups_Description,
            this.olvGroups_Owner,
            this.olvGroups_Level});
            this.olvGroups.ContextMenuStrip = this.ctxGroups;
            this.olvGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvGroups.FullRowSelect = true;
            this.olvGroups.GridLines = true;
            this.olvGroups.HideSelection = false;
            this.olvGroups.IsSimpleDragSource = true;
            this.olvGroups.LargeImageList = this.imageList1;
            this.olvGroups.Location = new System.Drawing.Point(6, 50);
            this.olvGroups.MultiSelect = false;
            this.olvGroups.Name = "olvGroups";
            this.olvGroups.OwnerDraw = true;
            this.olvGroups.ShowGroups = false;
            this.olvGroups.Size = new System.Drawing.Size(629, 151);
            this.olvGroups.SmallImageList = this.imageList1;
            this.olvGroups.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvGroups.TabIndex = 2;
            this.olvGroups.UseAlternatingBackColors = true;
            this.olvGroups.UseCompatibleStateImageBehavior = false;
            this.olvGroups.View = System.Windows.Forms.View.Details;
            this.olvGroups.SelectedIndexChanged += new System.EventHandler(this.olvGroups_SelectedIndexChanged);
            this.olvGroups.DoubleClick += new System.EventHandler(this.EditGroup_Click);
            // 
            // olvGroups_Group
            // 
            this.olvGroups_Group.AspectName = "TECHNICALNAME";
            this.olvGroups_Group.Text = "Groups";
            this.olvGroups_Group.Width = 250;
            // 
            // olvGroups_Description
            // 
            this.olvGroups_Description.FillsFreeSpace = true;
            this.olvGroups_Description.Text = "Description";
            // 
            // olvGroups_Owner
            // 
            this.olvGroups_Owner.AspectName = "IS_OWNER";
            this.olvGroups_Owner.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroups_Owner.Text = "Owner";
            this.olvGroups_Owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroups_Owner.Width = 100;
            // 
            // olvGroups_Level
            // 
            this.olvGroups_Level.AspectName = "LEVEL";
            this.olvGroups_Level.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroups_Level.Text = "Level";
            this.olvGroups_Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctxGroups
            // 
            this.ctxGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNewGroup,
            this.ctxEditGroup,
            this.ctxDeleteGroup,
            this.toolStripSeparator4,
            this.ctxAddUserGroup});
            this.ctxGroups.Name = "ctxUsers";
            this.ctxGroups.Size = new System.Drawing.Size(176, 98);
            // 
            // ctxNewGroup
            // 
            this.ctxNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxNewGroup.Image")));
            this.ctxNewGroup.Name = "ctxNewGroup";
            this.ctxNewGroup.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxNewGroup.Size = new System.Drawing.Size(175, 22);
            this.ctxNewGroup.Text = "New";
            this.ctxNewGroup.Click += new System.EventHandler(this.NewGroup_Click);
            // 
            // ctxEditGroup
            // 
            this.ctxEditGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctxEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxEditGroup.Image")));
            this.ctxEditGroup.Name = "ctxEditGroup";
            this.ctxEditGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ctxEditGroup.Size = new System.Drawing.Size(175, 22);
            this.ctxEditGroup.Text = "Edit";
            this.ctxEditGroup.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // ctxDeleteGroup
            // 
            this.ctxDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxDeleteGroup.Image")));
            this.ctxDeleteGroup.Name = "ctxDeleteGroup";
            this.ctxDeleteGroup.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDeleteGroup.Size = new System.Drawing.Size(175, 22);
            this.ctxDeleteGroup.Text = "Delete";
            this.ctxDeleteGroup.Click += new System.EventHandler(this.DeleteGroup_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // ctxAddUserGroup
            // 
            this.ctxAddUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddUserGroup.Image")));
            this.ctxAddUserGroup.Name = "ctxAddUserGroup";
            this.ctxAddUserGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.ctxAddUserGroup.Size = new System.Drawing.Size(175, 22);
            this.ctxAddUserGroup.Text = "Add Group";
            this.ctxAddUserGroup.Click += new System.EventHandler(this.tsbAddUserGroup_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewGroup,
            this.tsbEditGroup,
            this.tsbDeleteGroup,
            this.tsSepGroups,
            this.tsbAddUserGroup});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(635, 31);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbNewGroup
            // 
            this.tsbNewGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewGroup.Image")));
            this.tsbNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewGroup.Name = "tsbNewGroup";
            this.tsbNewGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbNewGroup.Text = "New";
            this.tsbNewGroup.Click += new System.EventHandler(this.NewGroup_Click);
            // 
            // tsbEditGroup
            // 
            this.tsbEditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditGroup.Image")));
            this.tsbEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditGroup.Name = "tsbEditGroup";
            this.tsbEditGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbEditGroup.Text = "Edit";
            this.tsbEditGroup.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // tsbDeleteGroup
            // 
            this.tsbDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteGroup.Image")));
            this.tsbDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteGroup.Name = "tsbDeleteGroup";
            this.tsbDeleteGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteGroup.Text = "Delete";
            this.tsbDeleteGroup.Click += new System.EventHandler(this.DeleteGroup_Click);
            // 
            // tsSepGroups
            // 
            this.tsSepGroups.Name = "tsSepGroups";
            this.tsSepGroups.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbAddUserGroup
            // 
            this.tsbAddUserGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddUserGroup.Image")));
            this.tsbAddUserGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddUserGroup.Name = "tsbAddUserGroup";
            this.tsbAddUserGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbAddUserGroup.Text = "Add Group";
            this.tsbAddUserGroup.Click += new System.EventHandler(this.tsbAddUserGroup_Click);
            // 
            // gbUserDetail
            // 
            this.gbUserDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserDetail.Controls.Add(this.toolStrip3);
            this.gbUserDetail.Controls.Add(this.pb_UserIcon);
            this.gbUserDetail.Controls.Add(this.olvUserGroups);
            this.gbUserDetail.Controls.Add(this.lbSelectedUser);
            this.gbUserDetail.Location = new System.Drawing.Point(3, 3);
            this.gbUserDetail.Name = "gbUserDetail";
            this.gbUserDetail.Size = new System.Drawing.Size(641, 226);
            this.gbUserDetail.TabIndex = 10;
            this.gbUserDetail.TabStop = false;
            this.gbUserDetail.Text = "User\'s Details";
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDeleteUserGroup});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(635, 31);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbDeleteUserGroup
            // 
            this.tsbDeleteUserGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteUserGroup.Image")));
            this.tsbDeleteUserGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteUserGroup.Name = "tsbDeleteUserGroup";
            this.tsbDeleteUserGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteUserGroup.Text = "Remove Group";
            this.tsbDeleteUserGroup.Click += new System.EventHandler(this.tsbDeleteUserGroup_Click);
            // 
            // pb_UserIcon
            // 
            this.pb_UserIcon.Image = ((System.Drawing.Image)(resources.GetObject("pb_UserIcon.Image")));
            this.pb_UserIcon.Location = new System.Drawing.Point(6, 51);
            this.pb_UserIcon.Name = "pb_UserIcon";
            this.pb_UserIcon.Size = new System.Drawing.Size(35, 35);
            this.pb_UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_UserIcon.TabIndex = 8;
            this.pb_UserIcon.TabStop = false;
            // 
            // olvUserGroups
            // 
            this.olvUserGroups.AllColumns.Add(this.olvUserGroup_GroupName);
            this.olvUserGroups.AllColumns.Add(this.olvUserGroup_Description);
            this.olvUserGroups.AllColumns.Add(this.olvUserGroup_Module);
            this.olvUserGroups.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvUserGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvUserGroups.BackColor = System.Drawing.SystemColors.Window;
            this.olvUserGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvUserGroup_GroupName,
            this.olvUserGroup_Description,
            this.olvUserGroup_Module});
            this.olvUserGroups.ContextMenuStrip = this.ctxUserGroups;
            this.olvUserGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvUserGroups.EmptyListMsg = "No Groups or no user selected";
            this.olvUserGroups.FullRowSelect = true;
            this.olvUserGroups.GridLines = true;
            this.olvUserGroups.HideSelection = false;
            this.olvUserGroups.IsSimpleDropSink = true;
            this.olvUserGroups.LargeImageList = this.imageList1;
            this.olvUserGroups.Location = new System.Drawing.Point(6, 92);
            this.olvUserGroups.Name = "olvUserGroups";
            this.olvUserGroups.Size = new System.Drawing.Size(629, 128);
            this.olvUserGroups.SmallImageList = this.imageList1;
            this.olvUserGroups.TabIndex = 4;
            this.olvUserGroups.UseCompatibleStateImageBehavior = false;
            this.olvUserGroups.View = System.Windows.Forms.View.Details;
            this.olvUserGroups.ModelCanDrop += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.olvUserGroups_ModelCanDrop);
            this.olvUserGroups.ModelDropped += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.olvUserGroups_ModelDropped);
            this.olvUserGroups.SelectedIndexChanged += new System.EventHandler(this.olvUserGroups_SelectedIndexChanged);
            // 
            // olvUserGroup_GroupName
            // 
            this.olvUserGroup_GroupName.Sortable = false;
            this.olvUserGroup_GroupName.Text = "Group";
            this.olvUserGroup_GroupName.Width = 250;
            // 
            // olvUserGroup_Description
            // 
            this.olvUserGroup_Description.FillsFreeSpace = true;
            this.olvUserGroup_Description.Sortable = false;
            this.olvUserGroup_Description.Text = "Description";
            // 
            // olvUserGroup_Module
            // 
            this.olvUserGroup_Module.Text = "Module";
            this.olvUserGroup_Module.Width = 160;
            // 
            // ctxUserGroups
            // 
            this.ctxUserGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxDeleteUserGroup});
            this.ctxUserGroups.Name = "ctxUserGroups";
            this.ctxUserGroups.Size = new System.Drawing.Size(196, 26);
            this.ctxUserGroups.Opening += new System.ComponentModel.CancelEventHandler(this.checkAuthorization);
            // 
            // ctxDeleteUserGroup
            // 
            this.ctxDeleteUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxDeleteUserGroup.Image")));
            this.ctxDeleteUserGroup.Name = "ctxDeleteUserGroup";
            this.ctxDeleteUserGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ctxDeleteUserGroup.Size = new System.Drawing.Size(195, 22);
            this.ctxDeleteUserGroup.Text = "Remove Group";
            this.ctxDeleteUserGroup.Click += new System.EventHandler(this.tsbDeleteUserGroup_Click);
            // 
            // lbSelectedUser
            // 
            this.lbSelectedUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelectedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedUser.Location = new System.Drawing.Point(47, 51);
            this.lbSelectedUser.Name = "lbSelectedUser";
            this.lbSelectedUser.Size = new System.Drawing.Size(588, 35);
            this.lbSelectedUser.TabIndex = 9;
            this.lbSelectedUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbModule2);
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1029, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "By Module & Groups";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbModule2
            // 
            this.gbModule2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModule2.Controls.Add(this.cbModules2);
            this.gbModule2.Controls.Add(this.label2);
            this.gbModule2.Location = new System.Drawing.Point(9, 6);
            this.gbModule2.Name = "gbModule2";
            this.gbModule2.Size = new System.Drawing.Size(1014, 49);
            this.gbModule2.TabIndex = 8;
            this.gbModule2.TabStop = false;
            this.gbModule2.Text = "Module Selection";
            // 
            // cbModules2
            // 
            this.cbModules2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModules2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModules2.FormattingEnabled = true;
            this.cbModules2.Location = new System.Drawing.Point(54, 19);
            this.cbModules2.Name = "cbModules2";
            this.cbModules2.Size = new System.Drawing.Size(954, 21);
            this.cbModules2.TabIndex = 6;
            this.cbModules2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Module";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 61);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1023, 449);
            this.splitContainer3.SplitterDistance = 369;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.toolStrip4);
            this.groupBox2.Controls.Add(this.olvGroups2);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 443);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group\'s List";
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewGroup2,
            this.tsbEditGroup2,
            this.tsbDeleteGroup2});
            this.toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(354, 31);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsbNewGroup2
            // 
            this.tsbNewGroup2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewGroup2.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewGroup2.Image")));
            this.tsbNewGroup2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewGroup2.Name = "tsbNewGroup2";
            this.tsbNewGroup2.Size = new System.Drawing.Size(28, 28);
            this.tsbNewGroup2.Text = "New";
            this.tsbNewGroup2.Click += new System.EventHandler(this.NewGroup_Click);
            // 
            // tsbEditGroup2
            // 
            this.tsbEditGroup2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditGroup2.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditGroup2.Image")));
            this.tsbEditGroup2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditGroup2.Name = "tsbEditGroup2";
            this.tsbEditGroup2.Size = new System.Drawing.Size(28, 28);
            this.tsbEditGroup2.Text = "Edit";
            this.tsbEditGroup2.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // tsbDeleteGroup2
            // 
            this.tsbDeleteGroup2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteGroup2.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteGroup2.Image")));
            this.tsbDeleteGroup2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteGroup2.Name = "tsbDeleteGroup2";
            this.tsbDeleteGroup2.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteGroup2.Text = "Delete";
            this.tsbDeleteGroup2.Click += new System.EventHandler(this.DeleteGroup_Click);
            // 
            // olvGroups2
            // 
            this.olvGroups2.AllColumns.Add(this.olvGroup2_Group);
            this.olvGroups2.AllColumns.Add(this.olvGroup2_Owner);
            this.olvGroups2.AllColumns.Add(this.olvGroup2_Level);
            this.olvGroups2.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvGroups2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvGroups2.BackColor = System.Drawing.SystemColors.Window;
            this.olvGroups2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvGroup2_Group,
            this.olvGroup2_Owner,
            this.olvGroup2_Level});
            this.olvGroups2.ContextMenuStrip = this.ctxGroups;
            this.olvGroups2.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvGroups2.FullRowSelect = true;
            this.olvGroups2.GridLines = true;
            this.olvGroups2.HideSelection = false;
            this.olvGroups2.IsSimpleDragSource = true;
            this.olvGroups2.LargeImageList = this.imageList1;
            this.olvGroups2.Location = new System.Drawing.Point(6, 50);
            this.olvGroups2.MultiSelect = false;
            this.olvGroups2.Name = "olvGroups2";
            this.olvGroups2.OwnerDraw = true;
            this.olvGroups2.ShowGroups = false;
            this.olvGroups2.Size = new System.Drawing.Size(348, 387);
            this.olvGroups2.SmallImageList = this.imageList1;
            this.olvGroups2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvGroups2.TabIndex = 2;
            this.olvGroups2.UseAlternatingBackColors = true;
            this.olvGroups2.UseCompatibleStateImageBehavior = false;
            this.olvGroups2.View = System.Windows.Forms.View.Details;
            this.olvGroups2.SelectedIndexChanged += new System.EventHandler(this.olvGroups2_SelectedIndexChanged);
            this.olvGroups2.DoubleClick += new System.EventHandler(this.EditGroup_Click);
            // 
            // olvGroup2_Group
            // 
            this.olvGroup2_Group.AspectName = "TECHNICALNAME";
            this.olvGroup2_Group.FillsFreeSpace = true;
            this.olvGroup2_Group.Text = "Groups";
            this.olvGroup2_Group.Width = 150;
            // 
            // olvGroup2_Owner
            // 
            this.olvGroup2_Owner.AspectName = "IS_OWNER";
            this.olvGroup2_Owner.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroup2_Owner.Text = "Owner";
            this.olvGroup2_Owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroup2_Owner.Width = 100;
            // 
            // olvGroup2_Level
            // 
            this.olvGroup2_Level.AspectName = "LEVEL";
            this.olvGroup2_Level.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvGroup2_Level.Text = "Level";
            this.olvGroup2_Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer4.Size = new System.Drawing.Size(650, 449);
            this.splitContainer4.SplitterDistance = 211;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.toolStrip5);
            this.groupBox3.Controls.Add(this.olvUsers2);
            this.groupBox3.Controls.Add(this.mnuMainAccessRights);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(644, 205);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User\'s List";
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewUser2,
            this.tsbEditUser2,
            this.tsbDeleteUser2,
            this.toolStripSeparator8,
            this.tslSearch,
            this.txUserSearch2,
            this.toolStripSeparator9,
            this.tsbAddUserToGroup});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(638, 31);
            this.toolStrip5.TabIndex = 1;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tsbNewUser2
            // 
            this.tsbNewUser2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewUser2.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewUser2.Image")));
            this.tsbNewUser2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewUser2.Name = "tsbNewUser2";
            this.tsbNewUser2.Size = new System.Drawing.Size(28, 28);
            this.tsbNewUser2.Text = "New";
            this.tsbNewUser2.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // tsbEditUser2
            // 
            this.tsbEditUser2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditUser2.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditUser2.Image")));
            this.tsbEditUser2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditUser2.Name = "tsbEditUser2";
            this.tsbEditUser2.Size = new System.Drawing.Size(28, 28);
            this.tsbEditUser2.Text = "Edit";
            this.tsbEditUser2.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // tsbDeleteUser2
            // 
            this.tsbDeleteUser2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteUser2.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteUser2.Image")));
            this.tsbDeleteUser2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteUser2.Name = "tsbDeleteUser2";
            this.tsbDeleteUser2.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteUser2.Text = "Delete";
            this.tsbDeleteUser2.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // tslSearch
            // 
            this.tslSearch.Name = "tslSearch";
            this.tslSearch.Size = new System.Drawing.Size(40, 28);
            this.tslSearch.Text = "Search";
            // 
            // txUserSearch2
            // 
            this.txUserSearch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txUserSearch2.Name = "txUserSearch2";
            this.txUserSearch2.Size = new System.Drawing.Size(100, 31);
            this.txUserSearch2.TextChanged += new System.EventHandler(this.txUserSearch2_TextChanged);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbAddUserToGroup
            // 
            this.tsbAddUserToGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddUserToGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddUserToGroup.Image")));
            this.tsbAddUserToGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddUserToGroup.Name = "tsbAddUserToGroup";
            this.tsbAddUserToGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbAddUserToGroup.Text = "Add User to Group";
            this.tsbAddUserToGroup.Click += new System.EventHandler(this.tsbAddUserToGroup_Click);
            // 
            // olvUsers2
            // 
            this.olvUsers2.AllColumns.Add(this.olvUsers2_USERID);
            this.olvUsers2.AllColumns.Add(this.olvUsers2_FIRSTNAME);
            this.olvUsers2.AllColumns.Add(this.olvUsers2_LASTNAME);
            this.olvUsers2.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvUsers2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvUsers2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvUsers2_USERID,
            this.olvUsers2_FIRSTNAME,
            this.olvUsers2_LASTNAME});
            this.olvUsers2.ContextMenuStrip = this.ctxUsers;
            this.olvUsers2.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvUsers2.FullRowSelect = true;
            this.olvUsers2.GridLines = true;
            this.olvUsers2.HideSelection = false;
            this.olvUsers2.IsSimpleDragSource = true;
            this.olvUsers2.Location = new System.Drawing.Point(6, 50);
            this.olvUsers2.MultiSelect = false;
            this.olvUsers2.Name = "olvUsers2";
            this.olvUsers2.ShowCommandMenuOnRightClick = true;
            this.olvUsers2.ShowGroups = false;
            this.olvUsers2.Size = new System.Drawing.Size(632, 149);
            this.olvUsers2.SmallImageList = this.imageList1;
            this.olvUsers2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvUsers2.TabIndex = 0;
            this.olvUsers2.UseAlternatingBackColors = true;
            this.olvUsers2.UseCompatibleStateImageBehavior = false;
            this.olvUsers2.UseFiltering = true;
            this.olvUsers2.UseHotItem = true;
            this.olvUsers2.View = System.Windows.Forms.View.Details;
            this.olvUsers2.SelectedIndexChanged += new System.EventHandler(this.olvUsers2_SelectedIndexChanged);
            this.olvUsers2.DoubleClick += new System.EventHandler(this.EditUser_Click);
            // 
            // olvUsers2_USERID
            // 
            this.olvUsers2_USERID.AspectName = "UserID";
            this.olvUsers2_USERID.Text = "Userid";
            this.olvUsers2_USERID.Width = 150;
            // 
            // olvUsers2_FIRSTNAME
            // 
            this.olvUsers2_FIRSTNAME.AspectName = "FIRSTNAME";
            this.olvUsers2_FIRSTNAME.Text = "Firstname";
            this.olvUsers2_FIRSTNAME.Width = 90;
            // 
            // olvUsers2_LASTNAME
            // 
            this.olvUsers2_LASTNAME.AspectName = "LASTNAME";
            this.olvUsers2_LASTNAME.FillsFreeSpace = true;
            this.olvUsers2_LASTNAME.Text = "Lastname";
            this.olvUsers2_LASTNAME.Width = 100;
            // 
            // mnuMainAccessRights
            // 
            this.mnuMainAccessRights.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuMainAccessRights.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuMainAccessRights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsers,
            this.mnuGroups});
            this.mnuMainAccessRights.Location = new System.Drawing.Point(403, 16);
            this.mnuMainAccessRights.Name = "mnuMainAccessRights";
            this.mnuMainAccessRights.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuMainAccessRights.Size = new System.Drawing.Size(143, 24);
            this.mnuMainAccessRights.TabIndex = 2;
            this.mnuMainAccessRights.Text = "Security Overview";
            // 
            // mnuUsers
            // 
            this.mnuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewUser,
            this.mnuEditUser,
            this.mnuDeleteUser,
            this.toolStripSeparator6,
            this.mnuDeleteUserGroup,
            this.mnuAddUserToGroup});
            this.mnuUsers.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuUsers.MergeIndex = 1;
            this.mnuUsers.Name = "mnuUsers";
            this.mnuUsers.Size = new System.Drawing.Size(46, 20);
            this.mnuUsers.Text = "Users";
            this.mnuUsers.DropDownOpening += new System.EventHandler(this.checkAuthorization);
            // 
            // mnuNewUser
            // 
            this.mnuNewUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewUser.Image")));
            this.mnuNewUser.Name = "mnuNewUser";
            this.mnuNewUser.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuNewUser.Size = new System.Drawing.Size(247, 22);
            this.mnuNewUser.Text = "New";
            this.mnuNewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // mnuEditUser
            // 
            this.mnuEditUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mnuEditUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditUser.Image")));
            this.mnuEditUser.Name = "mnuEditUser";
            this.mnuEditUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditUser.Size = new System.Drawing.Size(247, 22);
            this.mnuEditUser.Text = "Edit";
            this.mnuEditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // mnuDeleteUser
            // 
            this.mnuDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteUser.Image")));
            this.mnuDeleteUser.Name = "mnuDeleteUser";
            this.mnuDeleteUser.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDeleteUser.Size = new System.Drawing.Size(247, 22);
            this.mnuDeleteUser.Text = "Delete";
            this.mnuDeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(244, 6);
            // 
            // mnuDeleteUserGroup
            // 
            this.mnuDeleteUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteUserGroup.Image")));
            this.mnuDeleteUserGroup.Name = "mnuDeleteUserGroup";
            this.mnuDeleteUserGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuDeleteUserGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuDeleteUserGroup.Text = "Remove Group From User";
            this.mnuDeleteUserGroup.Click += new System.EventHandler(this.tsbDeleteUserGroup_Click);
            // 
            // mnuAddUserToGroup
            // 
            this.mnuAddUserToGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddUserToGroup.Image")));
            this.mnuAddUserToGroup.Name = "mnuAddUserToGroup";
            this.mnuAddUserToGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuAddUserToGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuAddUserToGroup.Text = "Add User To Group";
            // 
            // mnuGroups
            // 
            this.mnuGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewGroup,
            this.mnuEditGroup,
            this.mnuDeleteGroup,
            this.toolStripSeparator5,
            this.mnuAddUserGroup,
            this.mnuRemoveUserFromGroup});
            this.mnuGroups.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuGroups.MergeIndex = 2;
            this.mnuGroups.Name = "mnuGroups";
            this.mnuGroups.Size = new System.Drawing.Size(89, 20);
            this.mnuGroups.Text = "Access Groups";
            this.mnuGroups.DropDownOpening += new System.EventHandler(this.checkAuthorization);
            // 
            // mnuNewGroup
            // 
            this.mnuNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewGroup.Image")));
            this.mnuNewGroup.Name = "mnuNewGroup";
            this.mnuNewGroup.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuNewGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuNewGroup.Text = "New";
            this.mnuNewGroup.Click += new System.EventHandler(this.NewGroup_Click);
            // 
            // mnuEditGroup
            // 
            this.mnuEditGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mnuEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditGroup.Image")));
            this.mnuEditGroup.Name = "mnuEditGroup";
            this.mnuEditGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuEditGroup.Text = "Edit";
            this.mnuEditGroup.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // mnuDeleteGroup
            // 
            this.mnuDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteGroup.Image")));
            this.mnuDeleteGroup.Name = "mnuDeleteGroup";
            this.mnuDeleteGroup.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDeleteGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuDeleteGroup.Text = "Delete";
            this.mnuDeleteGroup.Click += new System.EventHandler(this.DeleteGroup_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(244, 6);
            // 
            // mnuAddUserGroup
            // 
            this.mnuAddUserGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddUserGroup.Image")));
            this.mnuAddUserGroup.Name = "mnuAddUserGroup";
            this.mnuAddUserGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuAddUserGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuAddUserGroup.Text = "Add Group To User";
            this.mnuAddUserGroup.Click += new System.EventHandler(this.tsbAddUserGroup_Click);
            // 
            // mnuRemoveUserFromGroup
            // 
            this.mnuRemoveUserFromGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuRemoveUserFromGroup.Image")));
            this.mnuRemoveUserFromGroup.Name = "mnuRemoveUserFromGroup";
            this.mnuRemoveUserFromGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuRemoveUserFromGroup.Size = new System.Drawing.Size(247, 22);
            this.mnuRemoveUserFromGroup.Text = "Remove User From Group";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbGroupDescription);
            this.groupBox4.Controls.Add(this.olvGroupUsers);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.toolStrip6);
            this.groupBox4.Controls.Add(this.lbSelectedGroup);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(644, 230);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Group\'s Users";
            // 
            // lbGroupDescription
            // 
            this.lbGroupDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGroupDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroupDescription.Location = new System.Drawing.Point(47, 81);
            this.lbGroupDescription.Name = "lbGroupDescription";
            this.lbGroupDescription.Size = new System.Drawing.Size(591, 13);
            this.lbGroupDescription.TabIndex = 12;
            this.lbGroupDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // olvGroupUsers
            // 
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_USERID);
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_FIRSTNAME);
            this.olvGroupUsers.AllColumns.Add(this.olvGroupUsers_LASTNAME);
            this.olvGroupUsers.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvGroupUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvGroupUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvGroupUsers_USERID,
            this.olvGroupUsers_FIRSTNAME,
            this.olvGroupUsers_LASTNAME});
            this.olvGroupUsers.ContextMenuStrip = this.ctxGroupUsers;
            this.olvGroupUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvGroupUsers.FullRowSelect = true;
            this.olvGroupUsers.GridLines = true;
            this.olvGroupUsers.HideSelection = false;
            this.olvGroupUsers.IsSimpleDropSink = true;
            this.olvGroupUsers.Location = new System.Drawing.Point(6, 97);
            this.olvGroupUsers.MultiSelect = false;
            this.olvGroupUsers.Name = "olvGroupUsers";
            this.olvGroupUsers.ShowCommandMenuOnRightClick = true;
            this.olvGroupUsers.ShowGroups = false;
            this.olvGroupUsers.Size = new System.Drawing.Size(632, 127);
            this.olvGroupUsers.SmallImageList = this.imageList1;
            this.olvGroupUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvGroupUsers.TabIndex = 11;
            this.olvGroupUsers.UseAlternatingBackColors = true;
            this.olvGroupUsers.UseCompatibleStateImageBehavior = false;
            this.olvGroupUsers.UseFiltering = true;
            this.olvGroupUsers.UseHotItem = true;
            this.olvGroupUsers.View = System.Windows.Forms.View.Details;
            this.olvGroupUsers.ModelCanDrop += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.olvGroupUsers_ModelCanDrop);
            this.olvGroupUsers.ModelDropped += new System.EventHandler<SynapseAdvancedControls.ModelDropEventArgs>(this.olvGroupUsers_ModelDropped);
            this.olvGroupUsers.SelectedIndexChanged += new System.EventHandler(this.olvGroupUsers_SelectedIndexChanged);
            // 
            // olvGroupUsers_USERID
            // 
            this.olvGroupUsers_USERID.AspectName = "UserID";
            this.olvGroupUsers_USERID.Text = "Userid";
            this.olvGroupUsers_USERID.Width = 150;
            // 
            // olvGroupUsers_FIRSTNAME
            // 
            this.olvGroupUsers_FIRSTNAME.AspectName = "FIRSTNAME";
            this.olvGroupUsers_FIRSTNAME.Text = "Firstname";
            this.olvGroupUsers_FIRSTNAME.Width = 90;
            // 
            // olvGroupUsers_LASTNAME
            // 
            this.olvGroupUsers_LASTNAME.AspectName = "LASTNAME";
            this.olvGroupUsers_LASTNAME.FillsFreeSpace = true;
            this.olvGroupUsers_LASTNAME.Text = "Lastname";
            this.olvGroupUsers_LASTNAME.Width = 100;
            // 
            // ctxGroupUsers
            // 
            this.ctxGroupUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxRemoveUserFromGroup});
            this.ctxGroupUsers.Name = "ctxUserGroups";
            this.ctxGroupUsers.Size = new System.Drawing.Size(248, 26);
            this.ctxGroupUsers.Opening += new System.ComponentModel.CancelEventHandler(this.checkAuthorization);
            // 
            // ctxRemoveUserFromGroup
            // 
            this.ctxRemoveUserFromGroup.Image = ((System.Drawing.Image)(resources.GetObject("ctxRemoveUserFromGroup.Image")));
            this.ctxRemoveUserFromGroup.Name = "ctxRemoveUserFromGroup";
            this.ctxRemoveUserFromGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ctxRemoveUserFromGroup.Size = new System.Drawing.Size(247, 22);
            this.ctxRemoveUserFromGroup.Text = "Remove User From Group";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip6
            // 
            this.toolStrip6.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRemoveUserFromGroup});
            this.toolStrip6.Location = new System.Drawing.Point(3, 16);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(638, 31);
            this.toolStrip6.TabIndex = 10;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // tsbRemoveUserFromGroup
            // 
            this.tsbRemoveUserFromGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveUserFromGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveUserFromGroup.Image")));
            this.tsbRemoveUserFromGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveUserFromGroup.Name = "tsbRemoveUserFromGroup";
            this.tsbRemoveUserFromGroup.Size = new System.Drawing.Size(28, 28);
            this.tsbRemoveUserFromGroup.Text = "Remove User from Group";
            this.tsbRemoveUserFromGroup.Click += new System.EventHandler(this.tsbRemoveUserFromGroup_Click);
            // 
            // lbSelectedGroup
            // 
            this.lbSelectedGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelectedGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedGroup.Location = new System.Drawing.Point(47, 56);
            this.lbSelectedGroup.Name = "lbSelectedGroup";
            this.lbSelectedGroup.Size = new System.Drawing.Size(591, 22);
            this.lbSelectedGroup.TabIndex = 11;
            this.lbSelectedGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ok.png");
            this.imageList2.Images.SetKeyName(1, "NotOK.png");
            // 
            // toolStrip7
            // 
            this.toolStrip7.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(1061, 31);
            this.toolStrip7.TabIndex = 11;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(28, 28);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // frmAccessRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 585);
            this.Controls.Add(this.toolStrip7);
            this.Controls.Add(this.tabControl1);
            this.ModuleID = 1;
            this.Name = "frmAccessRights";
            this.ShowMenu = false;
            this.Text = "frmAccessRights";
            this.UpdateControls = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbModule.ResumeLayout(false);
            this.gbModule.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers)).EndInit();
            this.ctxUsers.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroups)).EndInit();
            this.ctxGroups.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbUserDetail.ResumeLayout(false);
            this.gbUserDetail.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvUserGroups)).EndInit();
            this.ctxUserGroups.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gbModule2.ResumeLayout(false);
            this.gbModule2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroups2)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers2)).EndInit();
            this.mnuMainAccessRights.ResumeLayout(false);
            this.mnuMainAccessRights.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvGroupUsers)).EndInit();
            this.ctxGroupUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SynapseAdvancedControls.ObjectListView olvUsers;
        private SynapseAdvancedControls.OLVColumn olvUsers_USERID;
        private SynapseAdvancedControls.OLVColumn olvUsers_FIRSTNAME;
        private SynapseAdvancedControls.OLVColumn olvUsers_LASTNAME;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewUser;
        private System.Windows.Forms.ToolStripButton tsbEditUser;
        private System.Windows.Forms.ToolStripButton tsbDeleteUser;
        private System.Windows.Forms.ToolStripLabel tslUserSearch;
        private System.Windows.Forms.ToolStripTextBox txUserSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip ctxUsers;
        private System.Windows.Forms.ToolStripMenuItem ctxNewUser;
        private System.Windows.Forms.ToolStripMenuItem ctxEditUser;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteUser;
        private System.Windows.Forms.MenuStrip mnuMainAccessRights;
        private System.Windows.Forms.ToolStripMenuItem mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuNewUser;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteUser;
        private System.Windows.Forms.PictureBox pb_UserIcon;
        private System.Windows.Forms.GroupBox gbUserDetail;
        private System.Windows.Forms.Label lbSelectedUser;
        private SynapseAdvancedControls.ObjectListView olvUserGroups;
        private SynapseAdvancedControls.OLVColumn olvUserGroup_GroupName;
        private SynapseAdvancedControls.OLVColumn olvUserGroup_Module;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNewGroup;
        private System.Windows.Forms.ToolStripButton tsbEditGroup;
        private System.Windows.Forms.ToolStripButton tsbDeleteGroup;
        private SynapseAdvancedControls.ObjectListView olvGroups;
        private SynapseAdvancedControls.OLVColumn olvGroups_Group;
        private System.Windows.Forms.ComboBox cbModules;
        private SynapseAdvancedControls.OLVColumn olvGroups_Owner;
        private SynapseAdvancedControls.OLVColumn olvGroups_Level;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip ctxGroups;
        private System.Windows.Forms.ToolStripMenuItem ctxNewGroup;
        private System.Windows.Forms.ToolStripMenuItem ctxEditGroup;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuGroups;
        private System.Windows.Forms.ToolStripMenuItem mnuNewGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuEditGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteGroup;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbDeleteUserGroup;
        private System.Windows.Forms.ToolStripSeparator tsSepGroups;
        private System.Windows.Forms.ToolStripButton tsbAddUserGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ctxAddUserGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuAddUserGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteUserGroup;
        private System.Windows.Forms.ContextMenuStrip ctxUserGroups;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteUserGroup;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox cbModules2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private SynapseAdvancedControls.ObjectListView olvGroups2;
        private SynapseAdvancedControls.OLVColumn olvGroup2_Group;
        private SynapseAdvancedControls.OLVColumn olvGroup2_Owner;
        private SynapseAdvancedControls.OLVColumn olvGroup2_Level;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbNewGroup2;
        private System.Windows.Forms.ToolStripButton tsbEditGroup2;
        private System.Windows.Forms.ToolStripButton tsbDeleteGroup2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tsbNewUser2;
        private System.Windows.Forms.ToolStripButton tsbEditUser2;
        private System.Windows.Forms.ToolStripButton tsbDeleteUser2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel tslSearch;
        private System.Windows.Forms.ToolStripTextBox txUserSearch2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private SynapseAdvancedControls.ObjectListView olvUsers2;
        private SynapseAdvancedControls.OLVColumn olvUsers2_USERID;
        private SynapseAdvancedControls.OLVColumn olvUsers2_FIRSTNAME;
        private SynapseAdvancedControls.OLVColumn olvUsers2_LASTNAME;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbSelectedGroup;
        private System.Windows.Forms.ToolStripButton tsbAddUserToGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private SynapseAdvancedControls.ObjectListView olvGroupUsers;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_USERID;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_FIRSTNAME;
        private SynapseAdvancedControls.OLVColumn olvGroupUsers_LASTNAME;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tsbRemoveUserFromGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ctxAddUserToGroup;
        private System.Windows.Forms.ContextMenuStrip ctxGroupUsers;
        private System.Windows.Forms.ToolStripMenuItem ctxRemoveUserFromGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuAddUserToGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveUserFromGroup;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.GroupBox gbModule;
        private System.Windows.Forms.GroupBox gbModule2;
        private SynapseAdvancedControls.OLVColumn olvGroups_Description;
        private SynapseAdvancedControls.OLVColumn olvUserGroup_Description;
        private System.Windows.Forms.Label lbGroupDescription;
    }
}