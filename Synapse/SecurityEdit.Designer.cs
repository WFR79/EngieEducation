/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 08:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Synapse
{
	partial class SecurityEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityEdit));
            this.cb_Profiles = new System.Windows.Forms.ComboBox();
            this.lst_ListOfControl = new System.Windows.Forms.ListBox();
            this.ctxControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAddControl = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAddFalseTrue = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxAddTrueTrue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxDeleteControl = new System.Windows.Forms.ToolStripMenuItem();
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.ColForm = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ColName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ColVisible = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.ColActive = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.mnu_Delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_Profile = new System.Windows.Forms.Label();
            this.lbl_Form = new System.Windows.Forms.Label();
            this.cb_Form = new System.Windows.Forms.ComboBox();
            this.cb_Module = new System.Windows.Forms.ComboBox();
            this.lbl_Module = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbControlSelection = new System.Windows.Forms.GroupBox();
            this.ckNotAttributed = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteControl = new System.Windows.Forms.ToolStripButton();
            this.gbControlsPermissions = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbRemoveControl = new System.Windows.Forms.ToolStripButton();
            this.gbModule = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuControl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddControl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteControl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveControl = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.mnu_Delete.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbControlSelection.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbControlsPermissions.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbModule.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Profiles
            // 
            this.cb_Profiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Profiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Profiles.FormattingEnabled = true;
            this.cb_Profiles.Location = new System.Drawing.Point(90, 59);
            this.cb_Profiles.Name = "cb_Profiles";
            this.cb_Profiles.Size = new System.Drawing.Size(457, 21);
            this.cb_Profiles.Sorted = true;
            this.cb_Profiles.TabIndex = 0;
            this.cb_Profiles.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // lst_ListOfControl
            // 
            this.lst_ListOfControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_ListOfControl.ContextMenuStrip = this.ctxControl;
            this.lst_ListOfControl.FormattingEnabled = true;
            this.lst_ListOfControl.Location = new System.Drawing.Point(6, 112);
            this.lst_ListOfControl.Name = "lst_ListOfControl";
            this.lst_ListOfControl.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_ListOfControl.Size = new System.Drawing.Size(259, 316);
            this.lst_ListOfControl.Sorted = true;
            this.lst_ListOfControl.TabIndex = 1;
            this.lst_ListOfControl.SelectedIndexChanged += new System.EventHandler(this.lst_ListOfControl_SelectedIndexChanged);
            this.lst_ListOfControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox1MouseDown);
            // 
            // ctxControl
            // 
            this.ctxControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAddControl,
            this.ctxAddFalseTrue,
            this.ctxAddTrueTrue,
            this.toolStripSeparator1,
            this.ctxDeleteControl});
            this.ctxControl.Name = "ctxControl";
            this.ctxControl.Size = new System.Drawing.Size(279, 120);
            // 
            // ctxAddControl
            // 
            this.ctxAddControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ctxAddControl.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddControl.Image")));
            this.ctxAddControl.Name = "ctxAddControl";
            this.ctxAddControl.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxAddControl.Size = new System.Drawing.Size(278, 22);
            this.ctxAddControl.Text = "Add to Profile (Not Active, Not Visible)";
            this.ctxAddControl.Click += new System.EventHandler(this.ctxAddControl_Click);
            // 
            // ctxAddFalseTrue
            // 
            this.ctxAddFalseTrue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxAddFalseTrue.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddFalseTrue.Image")));
            this.ctxAddFalseTrue.Name = "ctxAddFalseTrue";
            this.ctxAddFalseTrue.Size = new System.Drawing.Size(278, 22);
            this.ctxAddFalseTrue.Text = "Add to Profile (Not Active, Visible)";
            this.ctxAddFalseTrue.Click += new System.EventHandler(this.ctxAddFalseTrue_Click);
            // 
            // ctxAddTrueTrue
            // 
            this.ctxAddTrueTrue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxAddTrueTrue.Image = ((System.Drawing.Image)(resources.GetObject("ctxAddTrueTrue.Image")));
            this.ctxAddTrueTrue.Name = "ctxAddTrueTrue";
            this.ctxAddTrueTrue.Size = new System.Drawing.Size(278, 22);
            this.ctxAddTrueTrue.Text = "Add to Profile (Active, Visible)";
            this.ctxAddTrueTrue.Click += new System.EventHandler(this.ctxAddTrueTrue_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
            // 
            // ctxDeleteControl
            // 
            this.ctxDeleteControl.Image = ((System.Drawing.Image)(resources.GetObject("ctxDeleteControl.Image")));
            this.ctxDeleteControl.Name = "ctxDeleteControl";
            this.ctxDeleteControl.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDeleteControl.Size = new System.Drawing.Size(278, 22);
            this.ctxDeleteControl.Text = "Delete";
            this.ctxDeleteControl.Click += new System.EventHandler(this.ctxDeleteControl_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.ColForm);
            this.objectListView1.AllColumns.Add(this.ColName);
            this.objectListView1.AllColumns.Add(this.ColVisible);
            this.objectListView1.AllColumns.Add(this.ColActive);
            this.objectListView1.AllowDrop = true;
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.BackColor = System.Drawing.Color.White;
            this.objectListView1.CellEditActivation = SynapseAdvancedControls.ObjectListView.CellEditActivateMode.SingleClick;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColForm,
            this.ColName,
            this.ColVisible,
            this.ColActive});
            this.objectListView1.ContextMenuStrip = this.mnu_Delete;
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.EmptyListMsg = "No Security for this profile";
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.LargeImageList = this.imageList1;
            this.objectListView1.Location = new System.Drawing.Point(6, 86);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowCommandMenuOnRightClick = true;
            this.objectListView1.Size = new System.Drawing.Size(541, 343);
            this.objectListView1.SmallImageList = this.imageList1;
            this.objectListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellEditFinishing += new SynapseAdvancedControls.CellEditEventHandler(this.objectListView1_CellEditFinishing);
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            this.objectListView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ObjectListView1DragDrop);
            this.objectListView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ObjectListView1DragEnter);
            // 
            // ColForm
            // 
            this.ColForm.CellPadding = null;
            this.ColForm.IsEditable = false;
            this.ColForm.Text = "Form";
            this.ColForm.Width = 120;
            // 
            // ColName
            // 
            this.ColName.CellPadding = null;
            this.ColName.FillsFreeSpace = true;
            this.ColName.IsEditable = false;
            this.ColName.Text = "Name";
            this.ColName.Width = 120;
            // 
            // ColVisible
            // 
            this.ColVisible.AspectName = "IS_VISIBLE";
            this.ColVisible.CellPadding = null;
            this.ColVisible.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColVisible.Text = "Visible";
            this.ColVisible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColVisible.Width = 96;
            // 
            // ColActive
            // 
            this.ColActive.AspectName = "IS_ACTIVE";
            this.ColActive.CellPadding = null;
            this.ColActive.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColActive.Text = "Active";
            this.ColActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColActive.Width = 101;
            // 
            // mnu_Delete
            // 
            this.mnu_Delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.mnu_Delete.Name = "mnu_Delete";
            this.mnu_Delete.Size = new System.Drawing.Size(211, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteToolStripMenuItem.Text = "Remove from Profile";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            this.imageList1.Images.SetKeyName(1, "NotOK.png");
            // 
            // lbl_Profile
            // 
            this.lbl_Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Profile.Location = new System.Drawing.Point(6, 62);
            this.lbl_Profile.Name = "lbl_Profile";
            this.lbl_Profile.Size = new System.Drawing.Size(78, 15);
            this.lbl_Profile.TabIndex = 4;
            this.lbl_Profile.Text = "Profile";
            // 
            // lbl_Form
            // 
            this.lbl_Form.AutoSize = true;
            this.lbl_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Form.Location = new System.Drawing.Point(6, 62);
            this.lbl_Form.Name = "lbl_Form";
            this.lbl_Form.Size = new System.Drawing.Size(30, 13);
            this.lbl_Form.TabIndex = 5;
            this.lbl_Form.Text = "Form";
            // 
            // cb_Form
            // 
            this.cb_Form.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Form.FormattingEnabled = true;
            this.cb_Form.Location = new System.Drawing.Point(105, 59);
            this.cb_Form.Name = "cb_Form";
            this.cb_Form.Size = new System.Drawing.Size(160, 21);
            this.cb_Form.Sorted = true;
            this.cb_Form.TabIndex = 6;
            this.cb_Form.SelectedIndexChanged += new System.EventHandler(this.ComboBox2SelectedIndexChanged);
            // 
            // cb_Module
            // 
            this.cb_Module.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Module.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Module.FormattingEnabled = true;
            this.cb_Module.Location = new System.Drawing.Point(105, 19);
            this.cb_Module.Name = "cb_Module";
            this.cb_Module.Size = new System.Drawing.Size(723, 21);
            this.cb_Module.Sorted = true;
            this.cb_Module.TabIndex = 9;
            this.cb_Module.SelectedIndexChanged += new System.EventHandler(this.ComboBox3SelectedIndexChanged);
            // 
            // lbl_Module
            // 
            this.lbl_Module.AutoSize = true;
            this.lbl_Module.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Module.Location = new System.Drawing.Point(6, 22);
            this.lbl_Module.Name = "lbl_Module";
            this.lbl_Module.Size = new System.Drawing.Size(42, 13);
            this.lbl_Module.TabIndex = 8;
            this.lbl_Module.Text = "Module";
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(851, 31);
            this.toolStrip4.TabIndex = 10;
            this.toolStrip4.Text = "toolStrip4";
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(5, 90);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbControlSelection);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbControlsPermissions);
            this.splitContainer1.Size = new System.Drawing.Size(840, 447);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 11;
            // 
            // gbControlSelection
            // 
            this.gbControlSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControlSelection.Controls.Add(this.ckNotAttributed);
            this.gbControlSelection.Controls.Add(this.toolStrip1);
            this.gbControlSelection.Controls.Add(this.lst_ListOfControl);
            this.gbControlSelection.Controls.Add(this.lbl_Form);
            this.gbControlSelection.Controls.Add(this.cb_Form);
            this.gbControlSelection.Location = new System.Drawing.Point(3, 6);
            this.gbControlSelection.Name = "gbControlSelection";
            this.gbControlSelection.Size = new System.Drawing.Size(271, 438);
            this.gbControlSelection.TabIndex = 10;
            this.gbControlSelection.TabStop = false;
            this.gbControlSelection.Text = "Controls Selection";
            // 
            // ckNotAttributed
            // 
            this.ckNotAttributed.AutoSize = true;
            this.ckNotAttributed.Location = new System.Drawing.Point(9, 86);
            this.ckNotAttributed.Name = "ckNotAttributed";
            this.ckNotAttributed.Size = new System.Drawing.Size(177, 17);
            this.ckNotAttributed.TabIndex = 8;
            this.ckNotAttributed.Text = "Show only not already attributed";
            this.ckNotAttributed.UseVisualStyleBackColor = true;
            this.ckNotAttributed.CheckedChanged += new System.EventHandler(this.ckNotAttributed_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddControl,
            this.toolStripSeparator3,
            this.tsbDeleteControl});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(265, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddControl
            // 
            this.tsbAddControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddControl.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddControl.Image")));
            this.tsbAddControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddControl.Name = "tsbAddControl";
            this.tsbAddControl.Size = new System.Drawing.Size(28, 28);
            this.tsbAddControl.Text = "Add Control to Profile";
            this.tsbAddControl.Click += new System.EventHandler(this.ctxAddControl_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbDeleteControl
            // 
            this.tsbDeleteControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteControl.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteControl.Image")));
            this.tsbDeleteControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteControl.Name = "tsbDeleteControl";
            this.tsbDeleteControl.Size = new System.Drawing.Size(28, 28);
            this.tsbDeleteControl.Text = "Delete Control";
            this.tsbDeleteControl.Click += new System.EventHandler(this.ctxDeleteControl_Click);
            // 
            // gbControlsPermissions
            // 
            this.gbControlsPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControlsPermissions.Controls.Add(this.toolStrip2);
            this.gbControlsPermissions.Controls.Add(this.objectListView1);
            this.gbControlsPermissions.Controls.Add(this.lbl_Profile);
            this.gbControlsPermissions.Controls.Add(this.cb_Profiles);
            this.gbControlsPermissions.Location = new System.Drawing.Point(3, 6);
            this.gbControlsPermissions.Name = "gbControlsPermissions";
            this.gbControlsPermissions.Size = new System.Drawing.Size(553, 438);
            this.gbControlsPermissions.TabIndex = 5;
            this.gbControlsPermissions.TabStop = false;
            this.gbControlsPermissions.Text = "Control\'s Permissions by Profile";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRemoveControl});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(547, 31);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbRemoveControl
            // 
            this.tsbRemoveControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveControl.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveControl.Image")));
            this.tsbRemoveControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveControl.Name = "tsbRemoveControl";
            this.tsbRemoveControl.Size = new System.Drawing.Size(28, 28);
            this.tsbRemoveControl.Text = "Remove Control from Profile";
            this.tsbRemoveControl.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // gbModule
            // 
            this.gbModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModule.Controls.Add(this.cb_Module);
            this.gbModule.Controls.Add(this.lbl_Module);
            this.gbModule.Location = new System.Drawing.Point(8, 34);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(834, 50);
            this.gbModule.TabIndex = 12;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Module Selection";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuControl,
            this.mnuPermission});
            this.menuStrip1.Location = new System.Drawing.Point(612, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuControl
            // 
            this.mnuControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddControl,
            this.toolStripSeparator2,
            this.mnuDeleteControl});
            this.mnuControl.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuControl.MergeIndex = 1;
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Size = new System.Drawing.Size(59, 20);
            this.mnuControl.Text = "Control";
            // 
            // mnuAddControl
            // 
            this.mnuAddControl.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddControl.Image")));
            this.mnuAddControl.Name = "mnuAddControl";
            this.mnuAddControl.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuAddControl.Size = new System.Drawing.Size(169, 22);
            this.mnuAddControl.Text = "Add to Profile";
            this.mnuAddControl.Click += new System.EventHandler(this.ctxAddControl_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // mnuDeleteControl
            // 
            this.mnuDeleteControl.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteControl.Image")));
            this.mnuDeleteControl.Name = "mnuDeleteControl";
            this.mnuDeleteControl.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDeleteControl.Size = new System.Drawing.Size(169, 22);
            this.mnuDeleteControl.Text = "Delete";
            this.mnuDeleteControl.Click += new System.EventHandler(this.ctxDeleteControl_Click);
            // 
            // mnuPermission
            // 
            this.mnuPermission.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveControl});
            this.mnuPermission.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuPermission.MergeIndex = 2;
            this.mnuPermission.Name = "mnuPermission";
            this.mnuPermission.Size = new System.Drawing.Size(77, 20);
            this.mnuPermission.Text = "Permission";
            // 
            // mnuRemoveControl
            // 
            this.mnuRemoveControl.Image = ((System.Drawing.Image)(resources.GetObject("mnuRemoveControl.Image")));
            this.mnuRemoveControl.Name = "mnuRemoveControl";
            this.mnuRemoveControl.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuRemoveControl.Size = new System.Drawing.Size(224, 22);
            this.mnuRemoveControl.Text = "Remove from Profile";
            this.mnuRemoveControl.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SecurityEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 549);
            this.Controls.Add(this.gbModule);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 1;
            this.Name = "SecurityEdit";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecurityEdit";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.SecurityEditLoad);
            this.ctxControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.mnu_Delete.ResumeLayout(false);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbControlSelection.ResumeLayout(false);
            this.gbControlSelection.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbControlsPermissions.ResumeLayout(false);
            this.gbControlsPermissions.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbModule.ResumeLayout(false);
            this.gbModule.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lbl_Module;
        private System.Windows.Forms.ComboBox cb_Module;
		private System.Windows.Forms.ComboBox cb_Form;
		private System.Windows.Forms.Label lbl_Form;
		private System.Windows.Forms.Label lbl_Profile;
		private SynapseAdvancedControls.OLVColumn ColName;
		private SynapseAdvancedControls.OLVColumn ColActive;
		private SynapseAdvancedControls.OLVColumn ColVisible;
		private SynapseAdvancedControls.ObjectListView objectListView1;
		private System.Windows.Forms.ListBox lst_ListOfControl;
		private System.Windows.Forms.ComboBox cb_Profiles;
        private SynapseAdvancedControls.OLVColumn ColForm;
        private System.Windows.Forms.ContextMenuStrip mnu_Delete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbControlSelection;
        private System.Windows.Forms.GroupBox gbControlsPermissions;
        private System.Windows.Forms.ContextMenuStrip ctxControl;
        private System.Windows.Forms.ToolStripMenuItem ctxAddControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxDeleteControl;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.GroupBox gbModule;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDeleteControl;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbRemoveControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuControl;
        private System.Windows.Forms.ToolStripMenuItem mnuAddControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteControl;
        private System.Windows.Forms.ToolStripMenuItem mnuPermission;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveControl;
        private System.Windows.Forms.ToolStripMenuItem ctxAddFalseTrue;
        private System.Windows.Forms.ToolStripMenuItem ctxAddTrueTrue;
        private System.Windows.Forms.CheckBox ckNotAttributed;
	}
}
