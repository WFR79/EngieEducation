namespace SynapseReport.Forms
{
    partial class frmCategoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoryList));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.mnuMainCategory = new System.Windows.Forms.MenuStrip();
            this.mnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMainCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.olvCategory = new SynapseAdvancedControls.ObjectListView();
            this.colCat = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.col1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip.SuspendLayout();
            this.mnuMainCategory.SuspendLayout();
            this.cxtMainCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator2,
            this.tsbNew,
            this.tsbOpen,
            this.tsbDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(454, 31);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(28, 28);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.ExitForm);
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
            this.tsbNew.Click += new System.EventHandler(this.New_Category);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(28, 28);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.Edit_Category);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.Delete_Category);
            // 
            // mnuMainCategory
            // 
            this.mnuMainCategory.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuMainCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategory});
            this.mnuMainCategory.Location = new System.Drawing.Point(237, 0);
            this.mnuMainCategory.Name = "mnuMainCategory";
            this.mnuMainCategory.Size = new System.Drawing.Size(72, 24);
            this.mnuMainCategory.TabIndex = 7;
            this.mnuMainCategory.Text = "menuStrip1";
            // 
            // mnuCategory
            // 
            this.mnuCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit,
            this.toolStripSeparator3,
            this.mnuNew,
            this.mnuOpen,
            this.mnuDelete});
            this.mnuCategory.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuCategory.MergeIndex = 2;
            this.mnuCategory.Name = "mnuCategory";
            this.mnuCategory.Size = new System.Drawing.Size(64, 20);
            this.mnuCategory.Text = "Category";
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(116, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.ExitForm);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(116, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.New_Category);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(116, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.Edit_Category);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(116, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.Delete_Category);
            // 
            // cxtMainCategory
            // 
            this.cxtMainCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNew,
            this.ctxOpen,
            this.ctxDelete});
            this.cxtMainCategory.Name = "cxtMainCampaign";
            this.cxtMainCategory.Size = new System.Drawing.Size(150, 70);
            // 
            // ctxNew
            // 
            this.ctxNew.Image = ((System.Drawing.Image)(resources.GetObject("ctxNew.Image")));
            this.ctxNew.Name = "ctxNew";
            this.ctxNew.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxNew.Size = new System.Drawing.Size(149, 22);
            this.ctxNew.Text = "New";
            this.ctxNew.Click += new System.EventHandler(this.New_Category);
            // 
            // ctxOpen
            // 
            this.ctxOpen.Image = ((System.Drawing.Image)(resources.GetObject("ctxOpen.Image")));
            this.ctxOpen.Name = "ctxOpen";
            this.ctxOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ctxOpen.Size = new System.Drawing.Size(149, 22);
            this.ctxOpen.Text = "Open";
            this.ctxOpen.Click += new System.EventHandler(this.Edit_Category);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxDelete.Image")));
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDelete.Size = new System.Drawing.Size(149, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.Delete_Category);
            // 
            // olvCategory
            // 
            this.olvCategory.AllColumns.Add(this.colCat);
            this.olvCategory.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCat});
            this.olvCategory.ContextMenuStrip = this.cxtMainCategory;
            this.olvCategory.FullRowSelect = true;
            this.olvCategory.GridLines = true;
            this.olvCategory.Location = new System.Drawing.Point(12, 34);
            this.olvCategory.MultiSelect = false;
            this.olvCategory.Name = "olvCategory";
            this.olvCategory.OwnerDraw = true;
            this.olvCategory.ShowCommandMenuOnRightClick = true;
            this.olvCategory.ShowGroups = false;
            this.olvCategory.Size = new System.Drawing.Size(430, 268);
            this.olvCategory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvCategory.TabIndex = 8;
            this.olvCategory.UseAlternatingBackColors = true;
            this.olvCategory.UseCompatibleStateImageBehavior = false;
            this.olvCategory.UseFiltering = true;
            this.olvCategory.View = System.Windows.Forms.View.Details;
            this.olvCategory.SelectedIndexChanged += new System.EventHandler(this.olvCategory_SelectedIndexChanged);
            this.olvCategory.DoubleClick += new System.EventHandler(this.Edit_Category);
            // 
            // colCat
            // 
            this.colCat.AspectName = "";
            this.colCat.Text = "Report Category";
            this.colCat.Width = 400;
            // 
            // col1
            // 
            this.col1.AspectName = "MODULE";
            this.col1.DisplayIndex = 0;
            this.col1.Text = "Module";
            this.col1.Width = 200;
            // 
            // frmCategoryList
            // 
            this.ClientSize = new System.Drawing.Size(454, 314);
            this.Controls.Add(this.olvCategory);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mnuMainCategory);
            this.ModuleID = 2;
            this.Name = "frmCategoryList";
            this.ShowInTaskbar = false;
            this.ShowMenu = false;
            this.Text = "List of Categories";
            this.UpdateControls = true;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mnuMainCategory.ResumeLayout(false);
            this.mnuMainCategory.PerformLayout();
            this.cxtMainCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.MenuStrip mnuMainCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ContextMenuStrip cxtMainCategory;
        private System.Windows.Forms.ToolStripMenuItem ctxNew;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private SynapseAdvancedControls.ObjectListView olvCategory;
        private SynapseAdvancedControls.OLVColumn colCat;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private SynapseAdvancedControls.OLVColumn col1;
    }
}
