namespace SynapseRoomPicker.Forms
{
    partial class frmRoomList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomList));
            this.cxtRoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.olvRoom = new SynapseAdvancedControls.ObjectListView();
            this.colEntity = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colBuilding = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colCode = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colName = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.colAvailable = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.synapseListFilter1 = new SynapseCore.Controls.SynapseListFilter();
            this.cxtRoom.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvRoom)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cxtRoom
            // 
            this.cxtRoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNew,
            this.ctxOpen,
            this.ctxDelete});
            this.cxtRoom.Name = "cxtMainCampaign";
            this.cxtRoom.Size = new System.Drawing.Size(157, 70);
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.olvRoom);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(592, 295);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(592, 326);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.synapseListFilter1);
            // 
            // olvRoom
            // 
            this.olvRoom.AllColumns.Add(this.colEntity);
            this.olvRoom.AllColumns.Add(this.colBuilding);
            this.olvRoom.AllColumns.Add(this.colCode);
            this.olvRoom.AllColumns.Add(this.colName);
            this.olvRoom.AllColumns.Add(this.colAvailable);
            this.olvRoom.AlternateRowBackColor = System.Drawing.Color.Lavender;
            this.olvRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEntity,
            this.colBuilding,
            this.colCode,
            this.colName,
            this.colAvailable});
            this.olvRoom.ContextMenuStrip = this.cxtRoom;
            this.olvRoom.FullRowSelect = true;
            this.olvRoom.GridLines = true;
            this.olvRoom.HeaderUsesThemes = false;
            this.olvRoom.Location = new System.Drawing.Point(12, 3);
            this.olvRoom.MultiSelect = false;
            this.olvRoom.Name = "olvRoom";
            this.olvRoom.OwnerDraw = true;
            this.olvRoom.ShowCommandMenuOnRightClick = true;
            this.olvRoom.ShowGroups = false;
            this.olvRoom.Size = new System.Drawing.Size(568, 280);
            this.olvRoom.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvRoom.TabIndex = 0;
            this.olvRoom.UseAlternatingBackColors = true;
            this.olvRoom.UseCompatibleStateImageBehavior = false;
            this.olvRoom.UseFilterIndicator = true;
            this.olvRoom.UseFiltering = true;
            this.olvRoom.View = System.Windows.Forms.View.Details;
            this.olvRoom.SelectedIndexChanged += new System.EventHandler(this.olvRoom_SelectedIndexChanged);
            this.olvRoom.DoubleClick += new System.EventHandler(this.tsbOpen_Click);
            // 
            // colEntity
            // 
            this.colEntity.CellPadding = null;
            this.colEntity.Text = "Entity";
            this.colEntity.Width = 100;
            // 
            // colBuilding
            // 
            this.colBuilding.CellPadding = null;
            this.colBuilding.Text = "Building";
            this.colBuilding.Width = 100;
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
            this.colName.Searchable = false;
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
            this.synapseListFilter1.ListView = this.olvRoom;
            this.synapseListFilter1.Location = new System.Drawing.Point(133, 0);
            this.synapseListFilter1.Name = "synapseListFilter1";
            this.synapseListFilter1.Size = new System.Drawing.Size(455, 31);
            this.synapseListFilter1.TabIndex = 5;
            // 
            // frmRoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 326);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmRoomList";
            this.ShowMenu = false;
            this.Text = "frmRoomList";
            this.UpdateControls = true;
            this.cxtRoom.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvRoom)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cxtRoom;
        private System.Windows.Forms.ToolStripMenuItem ctxNew;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private SynapseAdvancedControls.ObjectListView olvRoom;
        private SynapseAdvancedControls.OLVColumn colEntity;
        private SynapseAdvancedControls.OLVColumn colCode;
        private SynapseAdvancedControls.OLVColumn colName;
        private SynapseAdvancedControls.OLVColumn colAvailable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private SynapseCore.Controls.SynapseListFilter synapseListFilter1;
        private SynapseAdvancedControls.OLVColumn colBuilding;
    }
}