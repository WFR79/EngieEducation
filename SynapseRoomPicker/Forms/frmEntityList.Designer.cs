namespace SynapseRoomPicker.Forms
{
    partial class frmEntityList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntityList));
            this.olvEntity = new SynapseAdvancedControls.ObjectListView();
            this.colCode = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colAvailable = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.cxtEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.synapseListFilter1 = new SynapseCore.Controls.SynapseListFilter();
            ((System.ComponentModel.ISupportInitialize)(this.olvEntity)).BeginInit();
            this.cxtEntity.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // olvEntity
            // 
            this.olvEntity.AllColumns.Add(this.colCode);
            this.olvEntity.AllColumns.Add(this.colName);
            this.olvEntity.AllColumns.Add(this.colAvailable);
            this.olvEntity.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvEntity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colAvailable});
            this.olvEntity.ContextMenuStrip = this.cxtEntity;
            this.olvEntity.FullRowSelect = true;
            this.olvEntity.GridLines = true;
            this.olvEntity.HeaderUsesThemes = false;
            this.olvEntity.Location = new System.Drawing.Point(12, 3);
            this.olvEntity.MultiSelect = false;
            this.olvEntity.Name = "olvEntity";
            this.olvEntity.OwnerDraw = true;
            this.olvEntity.ShowCommandMenuOnRightClick = true;
            this.olvEntity.ShowGroups = false;
            this.olvEntity.Size = new System.Drawing.Size(568, 280);
            this.olvEntity.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvEntity.TabIndex = 0;
            this.olvEntity.UseAlternatingBackColors = true;
            this.olvEntity.UseCompatibleStateImageBehavior = false;
            this.olvEntity.UseFilterIndicator = true;
            this.olvEntity.UseFiltering = true;
            this.olvEntity.View = System.Windows.Forms.View.Details;
            this.olvEntity.SelectionChanged += new System.EventHandler(this.olvEntity_SelectedIndexChanged);
            this.olvEntity.DoubleClick += new System.EventHandler(this.tsbOpen_Click);
            // 
            // colCode
            // 
            this.colCode.AspectName = "CODE";
            this.colCode.CellPadding = null;
            this.colCode.Text = "Code";
            // 
            // colName
            // 
            this.colName.AspectName = "NAME";
            this.colName.CellPadding = null;
            this.colName.FillsFreeSpace = true;
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colAvailable
            // 
            this.colAvailable.CellPadding = null;
            this.colAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAvailable.Searchable = false;
            this.colAvailable.Text = "Available";
            this.colAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAvailable.Width = 120;
            // 
            // cxtEntity
            // 
            this.cxtEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNew,
            this.ctxOpen,
            this.ctxDelete});
            this.cxtEntity.Name = "cxtMainCampaign";
            this.cxtEntity.Size = new System.Drawing.Size(157, 92);
            // 
            // ctxNew
            // 
            this.ctxNew.Image = ((System.Drawing.Image)(resources.GetObject("ctxNew.Image")));
            this.ctxNew.Name = "ctxNew";
            this.ctxNew.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxNew.Size = new System.Drawing.Size(156, 22);
            this.ctxNew.Text = "New";
            this.ctxNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // ctxOpen
            // 
            this.ctxOpen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctxOpen.Image = ((System.Drawing.Image)(resources.GetObject("ctxOpen.Image")));
            this.ctxOpen.Name = "ctxOpen";
            this.ctxOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ctxOpen.Size = new System.Drawing.Size(156, 22);
            this.ctxOpen.Text = "Open";
            this.ctxOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxDelete.Image")));
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxDelete.Size = new System.Drawing.Size(156, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "True");
            this.imageList.Images.SetKeyName(1, "False");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator5,
            this.tsbNew,
            this.tsbOpen,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(130, 31);
            this.toolStrip1.TabIndex = 4;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(28, 28);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(28, 28);
            this.tsbOpen.Text = "Edit";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.olvEntity);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(592, 295);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(592, 326);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.synapseListFilter1);
            // 
            // synapseListFilter1
            // 
            this.synapseListFilter1.Dock = System.Windows.Forms.DockStyle.None;
            this.synapseListFilter1.FilterOnTheFly = true;
            this.synapseListFilter1.HideExport = true;
            this.synapseListFilter1.HideFilter = false;
            this.synapseListFilter1.HidePrint = true;
            this.synapseListFilter1.HideSaveConfig = true;
            this.synapseListFilter1.HideSearch = false;
            this.synapseListFilter1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.synapseListFilter1.ListID = "frmEntityList#olvEntity";
            this.synapseListFilter1.ListView = this.olvEntity;
            this.synapseListFilter1.Location = new System.Drawing.Point(133, 0);
            this.synapseListFilter1.Name = "synapseListFilter1";
            this.synapseListFilter1.Size = new System.Drawing.Size(323, 31);
            this.synapseListFilter1.TabIndex = 5;
            // 
            // frmEntityList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 326);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmEntityList";
            this.ShowMenu = false;
            this.Text = "frmEnittyList";
            this.UpdateControls = true;
            ((System.ComponentModel.ISupportInitialize)(this.olvEntity)).EndInit();
            this.cxtEntity.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView olvEntity;
        private SynapseAdvancedControls.OLVColumn colName;
        private SynapseAdvancedControls.OLVColumn colAvailable;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private SynapseAdvancedControls.OLVColumn colCode;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private SynapseCore.Controls.SynapseListFilter synapseListFilter1;
        private System.Windows.Forms.ContextMenuStrip cxtEntity;
        private System.Windows.Forms.ToolStripMenuItem ctxNew;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
    }
}