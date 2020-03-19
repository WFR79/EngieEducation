namespace ProofOfConcept
{
    partial class Demo
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
            this.objectListView1 = new SynapseAdvancedControls.ObjectListView();
            this.olvColumn1 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn2 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn3 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.olvColumn4 = ((SynapseAdvancedControls.OLVColumn)(new SynapseAdvancedControls.OLVColumn()));
            this.synapseListFilter1 = new SynapseCore.Controls.SynapseListFilter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnu_Base = new System.Windows.Forms.ToolStripMenuItem();
            this.loadUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AccessibleName = "Grid title";
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllowColumnReorder = true;
            this.objectListView1.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.HeaderUsesThemes = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(792, 389);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFilterIndicator = true;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "ID";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "ID";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "UserID";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Text = "User";
            this.olvColumn2.Width = 163;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "FIRSTNAME";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Text = "Firstname";
            this.olvColumn3.Width = 178;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "LASTNAME";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Text = "Lastname";
            this.olvColumn4.Width = 189;
            // 
            // synapseListFilter1
            // 
            this.synapseListFilter1.Dock = System.Windows.Forms.DockStyle.None;
            this.synapseListFilter1.FilterOnTheFly = true;
            this.synapseListFilter1.HideExport = false;
            this.synapseListFilter1.HideFilter = false;
            this.synapseListFilter1.HidePrint = false;
            this.synapseListFilter1.HideSaveConfig = false;
            this.synapseListFilter1.HideSearch = false;
            this.synapseListFilter1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.synapseListFilter1.ListID = "Demo#objectListView1";
            this.synapseListFilter1.ListView = this.objectListView1;
            this.synapseListFilter1.Location = new System.Drawing.Point(3, 0);
            this.synapseListFilter1.Name = "synapseListFilter1";
            this.synapseListFilter1.Size = new System.Drawing.Size(625, 31);
            this.synapseListFilter1.TabIndex = 1;
            this.synapseListFilter1.Text = "synapseListFilter1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_User});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_User
            // 
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Base});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnu_Base
            // 
            this.mnu_Base.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadUsersToolStripMenuItem,
            this.showHistoryToolStripMenuItem});
            this.mnu_Base.Name = "mnu_Base";
            this.mnu_Base.Size = new System.Drawing.Size(42, 20);
            this.mnu_Base.Text = "Base";
            // 
            // loadUsersToolStripMenuItem
            // 
            this.loadUsersToolStripMenuItem.Name = "loadUsersToolStripMenuItem";
            this.loadUsersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadUsersToolStripMenuItem.Text = "Load Users";
            this.loadUsersToolStripMenuItem.Click += new System.EventHandler(this.loadUsersToolStripMenuItem_Click);
            // 
            // showHistoryToolStripMenuItem
            // 
            this.showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
            this.showHistoryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.showHistoryToolStripMenuItem.Text = "Show History";
            this.showHistoryToolStripMenuItem.Click += new System.EventHandler(this.showHistoryToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.objectListView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(792, 389);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(792, 420);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.synapseListFilter1);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Debug = true;
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 12;
            this.Name = "Demo";
            this.Text = "Demo";
            this.UpdateControls = true;
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SynapseAdvancedControls.ObjectListView objectListView1;
        private SynapseAdvancedControls.OLVColumn olvColumn1;
        private SynapseCore.Controls.SynapseListFilter synapseListFilter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_User;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Base;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem loadUsersToolStripMenuItem;
        private SynapseAdvancedControls.OLVColumn olvColumn2;
        private SynapseAdvancedControls.OLVColumn olvColumn3;
        private SynapseAdvancedControls.OLVColumn olvColumn4;
        private System.Windows.Forms.ToolStripMenuItem showHistoryToolStripMenuItem;
    }
}