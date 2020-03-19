namespace Synapse
{
    partial class frm_ModulesEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ModulesEdit));
            this.ctxmenu_Edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.olvModules = new SynapseAdvancedControls.ObjectListView();
            this.olvModules_FriendlyName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_Id = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_Description = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_Version = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_VersionDate = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_Category = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvModules_Usage = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.gbModules = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmenu_Edit.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvModules)).BeginInit();
            this.gbModules.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxmenu_Edit
            // 
            this.ctxmenu_Edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNew,
            this.ctxEdit,
            this.ctxDelete});
            this.ctxmenu_Edit.Name = "ctxmenu_Edit";
            this.ctxmenu_Edit.Size = new System.Drawing.Size(153, 92);
            // 
            // ctxNew
            // 
            this.ctxNew.Image = ((System.Drawing.Image)(resources.GetObject("ctxNew.Image")));
            this.ctxNew.Name = "ctxNew";
            this.ctxNew.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxNew.Size = new System.Drawing.Size(152, 22);
            this.ctxNew.Text = "New";
            this.ctxNew.Click += new System.EventHandler(this.New_Module);
            // 
            // ctxEdit
            // 
            this.ctxEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctxEdit.Image = ((System.Drawing.Image)(resources.GetObject("ctxEdit.Image")));
            this.ctxEdit.Name = "ctxEdit";
            this.ctxEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ctxEdit.Size = new System.Drawing.Size(152, 22);
            this.ctxEdit.Text = "Edit";
            this.ctxEdit.Click += new System.EventHandler(this.Edit_Module);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxDelete.Image")));
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDelete.Size = new System.Drawing.Size(152, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.Delete_Module);
            // 
            // LargeImageList
            // 
            this.LargeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.LargeImageList.ImageSize = new System.Drawing.Size(24, 24);
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator2,
            this.tsbNew,
            this.tsbEdit,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1145, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(28, 28);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.New_Module);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(28, 28);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.Edit_Module);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.Delete_Module);
            // 
            // olvModules
            // 
            this.olvModules.AllColumns.Add(this.olvModules_FriendlyName);
            this.olvModules.AllColumns.Add(this.olvModules_Id);
            this.olvModules.AllColumns.Add(this.olvModules_Description);
            this.olvModules.AllColumns.Add(this.olvModules_Version);
            this.olvModules.AllColumns.Add(this.olvModules_VersionDate);
            this.olvModules.AllColumns.Add(this.olvModules_Category);
            this.olvModules.AllColumns.Add(this.olvModules_Usage);
            this.olvModules.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvModules_FriendlyName,
            this.olvModules_Id,
            this.olvModules_Description,
            this.olvModules_Version,
            this.olvModules_VersionDate,
            this.olvModules_Category,
            this.olvModules_Usage});
            this.olvModules.ContextMenuStrip = this.ctxmenu_Edit;
            this.olvModules.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvModules.FullRowSelect = true;
            this.olvModules.GridLines = true;
            this.olvModules.HideSelection = false;
            this.olvModules.LargeImageList = this.LargeImageList;
            this.olvModules.Location = new System.Drawing.Point(6, 19);
            this.olvModules.MultiSelect = false;
            this.olvModules.Name = "olvModules";
            this.olvModules.ShowCommandMenuOnRightClick = true;
            this.olvModules.ShowGroups = false;
            this.olvModules.Size = new System.Drawing.Size(1109, 460);
            this.olvModules.SmallImageList = this.LargeImageList;
            this.olvModules.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvModules.TabIndex = 2;
            this.olvModules.UseAlternatingBackColors = true;
            this.olvModules.UseCompatibleStateImageBehavior = false;
            this.olvModules.UseFiltering = true;
            this.olvModules.UseHotItem = true;
            this.olvModules.View = System.Windows.Forms.View.Details;
            this.olvModules.SelectedIndexChanged += new System.EventHandler(this.olvModules_SelectedIndexChanged);
            this.olvModules.DoubleClick += new System.EventHandler(this.Edit_Module);
            // 
            // olvModules_FriendlyName
            // 
            this.olvModules_FriendlyName.AspectName = "";
            this.olvModules_FriendlyName.Text = "Module";
            this.olvModules_FriendlyName.Width = 200;
            // 
            // olvModules_Id
            // 
            this.olvModules_Id.AspectName = "ID";
            this.olvModules_Id.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvModules_Id.Text = "Id";
            this.olvModules_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvModules_Description
            // 
            this.olvModules_Description.AspectName = "";
            this.olvModules_Description.FillsFreeSpace = true;
            this.olvModules_Description.Text = "Description";
            this.olvModules_Description.Width = 300;
            // 
            // olvModules_Version
            // 
            this.olvModules_Version.AspectName = "VERSION";
            this.olvModules_Version.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvModules_Version.Text = "Version";
            this.olvModules_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvModules_VersionDate
            // 
            this.olvModules_VersionDate.AspectName = "VERSIONDATE";
            this.olvModules_VersionDate.AspectToStringFormat = "{0:dd/MM/yyyy}";
            this.olvModules_VersionDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvModules_VersionDate.Text = "Version Date";
            this.olvModules_VersionDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvModules_VersionDate.Width = 100;
            // 
            // olvModules_Category
            // 
            this.olvModules_Category.AspectName = "MODULECATEGORY";
            this.olvModules_Category.Text = "Category";
            this.olvModules_Category.Width = 100;
            // 
            // olvModules_Usage
            // 
            this.olvModules_Usage.Text = "Usage";
            this.olvModules_Usage.Width = 284;
            // 
            // gbModules
            // 
            this.gbModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModules.Controls.Add(this.olvModules);
            this.gbModules.Location = new System.Drawing.Point(12, 34);
            this.gbModules.Name = "gbModules";
            this.gbModules.Size = new System.Drawing.Size(1121, 485);
            this.gbModules.TabIndex = 3;
            this.gbModules.TabStop = false;
            this.gbModules.Text = "Module\'s List";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(605, 7);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(61, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuEdit,
            this.mnuDelete});
            this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem1.MergeIndex = 1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem1.Text = "Module";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuNew.Size = new System.Drawing.Size(152, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.New_Module);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.Edit_Module);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.Delete_Module);
            // 
            // frm_ModulesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 531);
            this.Controls.Add(this.gbModules);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 1;
            this.Name = "frm_ModulesEdit";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ModulesEdit";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_ModulesEdit_Load);
            this.ctxmenu_Edit.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvModules)).EndInit();
            this.gbModules.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList LargeImageList;
        private System.Windows.Forms.ContextMenuStrip ctxmenu_Edit;
        private System.Windows.Forms.ToolStripMenuItem ctxEdit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripMenuItem ctxNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private SynapseAdvancedControls.ObjectListView olvModules;
        private SynapseAdvancedControls.OLVColumn olvModules_FriendlyName;
        private SynapseAdvancedControls.OLVColumn olvModules_Description;
        private SynapseAdvancedControls.OLVColumn olvModules_Version;
        private SynapseAdvancedControls.OLVColumn olvModules_Usage;
        private SynapseAdvancedControls.OLVColumn olvModules_VersionDate;
        private SynapseAdvancedControls.OLVColumn olvModules_Category;
        private System.Windows.Forms.GroupBox gbModules;
        private SynapseAdvancedControls.OLVColumn olvModules_Id;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}