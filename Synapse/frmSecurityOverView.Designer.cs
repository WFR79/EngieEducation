namespace Synapse
{
    partial class frmSecurityOverView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityOverView));
            this.treeListView1 = new SynapseAdvancedControls.TreeListView();
            this.olvc_GROUP = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvc_VISIBLE = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvc_ACTIVE = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvc_Text = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvc_Comment = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyControlsWithSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showImplicitGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbModule = new System.Windows.Forms.GroupBox();
            this.cbModules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExpand = new System.Windows.Forms.ToolStripButton();
            this.tsbCollapse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.gbOverview = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbModule.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.gbOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvc_GROUP);
            this.treeListView1.AllColumns.Add(this.olvc_VISIBLE);
            this.treeListView1.AllColumns.Add(this.olvc_ACTIVE);
            this.treeListView1.AllColumns.Add(this.olvc_Text);
            this.treeListView1.AllColumns.Add(this.olvc_Comment);
            this.treeListView1.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvc_GROUP,
            this.olvc_VISIBLE,
            this.olvc_ACTIVE,
            this.olvc_Text,
            this.olvc_Comment});
            this.treeListView1.EmptyListMsg = "No Security defined for this Module";
            this.treeListView1.GridLines = true;
            this.treeListView1.LargeImageList = this.imageList1;
            this.treeListView1.Location = new System.Drawing.Point(6, 19);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.SelectColumnsOnRightClick = false;
            this.treeListView1.SelectColumnsOnRightClickBehaviour = SynapseAdvancedControls.ObjectListView.ColumnSelectBehaviour.None;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(981, 394);
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseAlternatingBackColors = true;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            // 
            // olvc_GROUP
            // 
            this.olvc_GROUP.AspectName = "GROUP";
            this.olvc_GROUP.FillsFreeSpace = true;
            this.olvc_GROUP.Text = "Item";
            this.olvc_GROUP.Width = 400;
            // 
            // olvc_VISIBLE
            // 
            this.olvc_VISIBLE.AspectName = "VISIBLE";
            this.olvc_VISIBLE.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvc_VISIBLE.Text = "Visible";
            this.olvc_VISIBLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvc_ACTIVE
            // 
            this.olvc_ACTIVE.AspectName = "ACTIVE";
            this.olvc_ACTIVE.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvc_ACTIVE.Text = "Active";
            this.olvc_ACTIVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvc_Text
            // 
            this.olvc_Text.Text = "Text";
            this.olvc_Text.Width = 250;
            // 
            // olvc_Comment
            // 
            this.olvc_Comment.AspectName = "Comment";
            this.olvc_Comment.Text = "Comment";
            this.olvc_Comment.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "true");
            this.imageList1.Images.SetKeyName(1, "false");
            this.imageList1.Images.SetKeyName(2, "module");
            this.imageList1.Images.SetKeyName(3, "group");
            this.imageList1.Images.SetKeyName(4, "form");
            this.imageList1.Images.SetKeyName(5, "control");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandToolStripMenuItem,
            this.collapseToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(596, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(211, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.expandToolStripMenuItem.MergeIndex = 1;
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.collapseToolStripMenuItem.MergeIndex = 2;
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyControlsWithSecurityToolStripMenuItem,
            this.allControlsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showImplicitGroupsToolStripMenuItem});
            this.filtersToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.filtersToolStripMenuItem.MergeIndex = 3;
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // onlyControlsWithSecurityToolStripMenuItem
            // 
            this.onlyControlsWithSecurityToolStripMenuItem.Checked = true;
            this.onlyControlsWithSecurityToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlyControlsWithSecurityToolStripMenuItem.Name = "onlyControlsWithSecurityToolStripMenuItem";
            this.onlyControlsWithSecurityToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.onlyControlsWithSecurityToolStripMenuItem.Text = "Only Controls with security";
            this.onlyControlsWithSecurityToolStripMenuItem.Click += new System.EventHandler(this.onlyControlsWithSecurityToolStripMenuItem_Click);
            // 
            // allControlsToolStripMenuItem
            // 
            this.allControlsToolStripMenuItem.Name = "allControlsToolStripMenuItem";
            this.allControlsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.allControlsToolStripMenuItem.Text = "All Controls";
            this.allControlsToolStripMenuItem.Click += new System.EventHandler(this.onlyControlsWithSecurityToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // showImplicitGroupsToolStripMenuItem
            // 
            this.showImplicitGroupsToolStripMenuItem.Checked = true;
            this.showImplicitGroupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showImplicitGroupsToolStripMenuItem.Name = "showImplicitGroupsToolStripMenuItem";
            this.showImplicitGroupsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showImplicitGroupsToolStripMenuItem.Text = "Show Implicit groups";
            this.showImplicitGroupsToolStripMenuItem.Click += new System.EventHandler(this.showImplicitGroupsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.printToolStripMenuItem.MergeIndex = 4;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // gbModule
            // 
            this.gbModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModule.Controls.Add(this.cbModules);
            this.gbModule.Controls.Add(this.label1);
            this.gbModule.Location = new System.Drawing.Point(12, 34);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(993, 49);
            this.gbModule.TabIndex = 6;
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
            this.cbModules.Size = new System.Drawing.Size(933, 21);
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
            // toolStrip7
            // 
            this.toolStrip7.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator1,
            this.tsbExpand,
            this.tsbCollapse,
            this.toolStripSeparator2,
            this.tsbPrint});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(1017, 31);
            this.toolStrip7.TabIndex = 12;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExpand
            // 
            this.tsbExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExpand.Image = ((System.Drawing.Image)(resources.GetObject("tsbExpand.Image")));
            this.tsbExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpand.Name = "tsbExpand";
            this.tsbExpand.Size = new System.Drawing.Size(28, 28);
            this.tsbExpand.Text = "Expand All";
            this.tsbExpand.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // tsbCollapse
            // 
            this.tsbCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCollapse.Image = ((System.Drawing.Image)(resources.GetObject("tsbCollapse.Image")));
            this.tsbCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCollapse.Name = "tsbCollapse";
            this.tsbCollapse.Size = new System.Drawing.Size(28, 28);
            this.tsbCollapse.Text = "Collapse All";
            this.tsbCollapse.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(28, 28);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // gbOverview
            // 
            this.gbOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOverview.Controls.Add(this.treeListView1);
            this.gbOverview.Location = new System.Drawing.Point(12, 89);
            this.gbOverview.Name = "gbOverview";
            this.gbOverview.Size = new System.Drawing.Size(993, 419);
            this.gbOverview.TabIndex = 13;
            this.gbOverview.TabStop = false;
            this.gbOverview.Text = "Security Overview";
            // 
            // frmSecurityOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 520);
            this.Controls.Add(this.gbOverview);
            this.Controls.Add(this.toolStrip7);
            this.Controls.Add(this.gbModule);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 1;
            this.Name = "frmSecurityOverView";
            this.ShowMenu = false;
            this.Text = "frmSecurityOverView";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frmSecurityOverView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbModule.ResumeLayout(false);
            this.gbModule.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.gbOverview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseAdvancedControls.TreeListView treeListView1;
        private SynapseAdvancedControls.OLVColumn olvc_GROUP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private SynapseAdvancedControls.OLVColumn olvc_VISIBLE;
        private SynapseAdvancedControls.OLVColumn olvc_ACTIVE;
        private System.Windows.Forms.ImageList imageList1;
        private SynapseAdvancedControls.OLVColumn olvc_Comment;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyControlsWithSecurityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showImplicitGroupsToolStripMenuItem;
        private SynapseAdvancedControls.OLVColumn olvc_Text;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbModule;
        private System.Windows.Forms.ComboBox cbModules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.GroupBox gbOverview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExpand;
        private System.Windows.Forms.ToolStripButton tsbCollapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
    }
}