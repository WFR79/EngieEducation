namespace SynapseCore.Controls
{
    partial class frm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_About));
            this.lbl_Suite = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_ModuleVersion = new System.Windows.Forms.Label();
            this.lbl_module = new System.Windows.Forms.Label();
            this.lbl_CurrentUser = new System.Windows.Forms.Label();
            this.lbl_CurrentUserLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxList = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.colGroups = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Suite
            // 
            this.lbl_Suite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Suite.AutoSize = true;
            this.lbl_Suite.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Suite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Suite.Location = new System.Drawing.Point(191, 144);
            this.lbl_Suite.Name = "lbl_Suite";
            this.lbl_Suite.Size = new System.Drawing.Size(115, 17);
            this.lbl_Suite.TabIndex = 1;
            this.lbl_Suite.Text = "Generation Suite";
            // 
            // lbl_Version
            // 
            this.lbl_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.Location = new System.Drawing.Point(320, 144);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(52, 17);
            this.lbl_Version.TabIndex = 2;
            this.lbl_Version.Text = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 302);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.lbl_ModuleVersion);
            this.tabPage1.Controls.Add(this.lbl_module);
            this.tabPage1.Controls.Add(this.lbl_CurrentUser);
            this.tabPage1.Controls.Add(this.lbl_CurrentUserLabel);
            this.tabPage1.Controls.Add(this.lbl_Version);
            this.tabPage1.Controls.Add(this.lbl_Suite);
            this.tabPage1.ImageKey = "Synapse_Logo_transparent128.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(415, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // lbl_ModuleVersion
            // 
            this.lbl_ModuleVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ModuleVersion.AutoSize = true;
            this.lbl_ModuleVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ModuleVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ModuleVersion.Location = new System.Drawing.Point(320, 165);
            this.lbl_ModuleVersion.Name = "lbl_ModuleVersion";
            this.lbl_ModuleVersion.Size = new System.Drawing.Size(52, 17);
            this.lbl_ModuleVersion.TabIndex = 6;
            this.lbl_ModuleVersion.Text = "label2";
            // 
            // lbl_module
            // 
            this.lbl_module.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_module.AutoSize = true;
            this.lbl_module.BackColor = System.Drawing.Color.Transparent;
            this.lbl_module.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_module.Location = new System.Drawing.Point(191, 165);
            this.lbl_module.Name = "lbl_module";
            this.lbl_module.Size = new System.Drawing.Size(54, 17);
            this.lbl_module.TabIndex = 5;
            this.lbl_module.Text = "Module";
            // 
            // lbl_CurrentUser
            // 
            this.lbl_CurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CurrentUser.AutoSize = true;
            this.lbl_CurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentUser.Location = new System.Drawing.Point(320, 241);
            this.lbl_CurrentUser.Name = "lbl_CurrentUser";
            this.lbl_CurrentUser.Size = new System.Drawing.Size(35, 13);
            this.lbl_CurrentUser.TabIndex = 4;
            this.lbl_CurrentUser.Text = "label1";
            // 
            // lbl_CurrentUserLabel
            // 
            this.lbl_CurrentUserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CurrentUserLabel.AutoSize = true;
            this.lbl_CurrentUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentUserLabel.Location = new System.Drawing.Point(252, 241);
            this.lbl_CurrentUserLabel.Name = "lbl_CurrentUserLabel";
            this.lbl_CurrentUserLabel.Size = new System.Drawing.Size(29, 13);
            this.lbl_CurrentUserLabel.TabIndex = 3;
            this.lbl_CurrentUserLabel.Text = "User";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.ImageKey = "module";
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(415, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modules";
            // 
            // listView1
            // 
            this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colModule});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(415, 259);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // colModule
            // 
            this.colModule.Text = "Modules";
            this.colModule.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTiles,
            this.ctxIcons,
            this.ctxList,
            this.ctxDetail});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ctxTiles
            // 
            this.ctxTiles.Name = "ctxTiles";
            this.ctxTiles.Size = new System.Drawing.Size(112, 22);
            this.ctxTiles.Text = "Tiles";
            this.ctxTiles.Click += new System.EventHandler(this.Change_Views);
            // 
            // ctxIcons
            // 
            this.ctxIcons.Checked = true;
            this.ctxIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctxIcons.Name = "ctxIcons";
            this.ctxIcons.Size = new System.Drawing.Size(112, 22);
            this.ctxIcons.Text = "Icons";
            this.ctxIcons.Click += new System.EventHandler(this.Change_Views);
            // 
            // ctxList
            // 
            this.ctxList.Name = "ctxList";
            this.ctxList.Size = new System.Drawing.Size(112, 22);
            this.ctxList.Text = "List";
            this.ctxList.Click += new System.EventHandler(this.Change_Views);
            // 
            // ctxDetail
            // 
            this.ctxDetail.Name = "ctxDetail";
            this.ctxDetail.Size = new System.Drawing.Size(112, 22);
            this.ctxDetail.Text = "Detail";
            this.ctxDetail.Click += new System.EventHandler(this.Change_Views);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "module");
            this.imageList1.Images.SetKeyName(1, "group");
            this.imageList1.Images.SetKeyName(2, "Synapse_Logo_transparent128.png");
            this.imageList1.Images.SetKeyName(3, "connection");
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.ImageKey = "group";
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(415, 259);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Groups";
            // 
            // listView2
            // 
            this.listView2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView2.BackgroundImage")));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroups});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(415, 259);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // colGroups
            // 
            this.colGroups.Text = "Groups";
            this.colGroups.Width = 200;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView3);
            this.tabPage4.ImageKey = "connection";
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(415, 259);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Interfaces";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView3.BackgroundImage")));
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView3.ContextMenuStrip = this.contextMenuStrip1;
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView3.LargeImageList = this.imageList1;
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(415, 259);
            this.listView3.SmallImageList = this.imageList1;
            this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Tile;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Connections";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Idle";
            // 
            // frm_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(423, 302);
            this.Controls.Add(this.tabControl1);
            this.ModuleID = 1;
            this.Name = "frm_About";
            this.SecurityEnabled = false;
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutBox";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frm_About_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Suite;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl_CurrentUser;
        private System.Windows.Forms.Label lbl_CurrentUserLabel;
        private System.Windows.Forms.Label lbl_module;
        private System.Windows.Forms.Label lbl_ModuleVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxTiles;
        private System.Windows.Forms.ToolStripMenuItem ctxIcons;
        private System.Windows.Forms.ToolStripMenuItem ctxList;
        private System.Windows.Forms.ToolStripMenuItem ctxDetail;
        private System.Windows.Forms.ColumnHeader colModule;
        private System.Windows.Forms.ColumnHeader colGroups;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}