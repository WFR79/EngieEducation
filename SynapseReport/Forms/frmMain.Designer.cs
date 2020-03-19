namespace SynapseReport
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeModule = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssModule = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReport,
            this.mnuAdministration,
            this.mnuWindows});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.mnuWindows;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(890, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuListReport,
            this.mnuChangeModule,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(52, 20);
            this.mnuReport.Text = "Report";
            // 
            // mnuListReport
            // 
            this.mnuListReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuListReport.Image")));
            this.mnuListReport.Name = "mnuListReport";
            this.mnuListReport.Size = new System.Drawing.Size(159, 22);
            this.mnuListReport.Text = "List";
            this.mnuListReport.Click += new System.EventHandler(this.OpenReports);
            // 
            // mnuChangeModule
            // 
            this.mnuChangeModule.Image = ((System.Drawing.Image)(resources.GetObject("mnuChangeModule.Image")));
            this.mnuChangeModule.Name = "mnuChangeModule";
            this.mnuChangeModule.Size = new System.Drawing.Size(159, 22);
            this.mnuChangeModule.Text = "Change Module";
            this.mnuChangeModule.Click += new System.EventHandler(this.mnuChangeModule_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.ExitApplication);
            // 
            // mnuAdministration
            // 
            this.mnuAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategories,
            this.mnuReportAdmin});
            this.mnuAdministration.Name = "mnuAdministration";
            this.mnuAdministration.Size = new System.Drawing.Size(87, 20);
            this.mnuAdministration.Text = "Administration";
            // 
            // mnuCategories
            // 
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new System.Drawing.Size(137, 22);
            this.mnuCategories.Text = "Categories";
            this.mnuCategories.Click += new System.EventHandler(this.mnuCategories_Click);
            // 
            // mnuReportAdmin
            // 
            this.mnuReportAdmin.Name = "mnuReportAdmin";
            this.mnuReportAdmin.Size = new System.Drawing.Size(137, 22);
            this.mnuReportAdmin.Text = "Report";
            this.mnuReportAdmin.Click += new System.EventHandler(this.mnuReportList_Click);
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArrange,
            this.toolStripSeparator2});
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(62, 20);
            this.mnuWindows.Text = "Windows";
            // 
            // mnuArrange
            // 
            this.mnuArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHorizontally,
            this.mnuVertically,
            this.mnuCascade});
            this.mnuArrange.Image = ((System.Drawing.Image)(resources.GetObject("mnuArrange.Image")));
            this.mnuArrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuArrange.Name = "mnuArrange";
            this.mnuArrange.Size = new System.Drawing.Size(124, 22);
            this.mnuArrange.Text = "Arrange";
            // 
            // mnuHorizontally
            // 
            this.mnuHorizontally.Image = ((System.Drawing.Image)(resources.GetObject("mnuHorizontally.Image")));
            this.mnuHorizontally.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuHorizontally.Name = "mnuHorizontally";
            this.mnuHorizontally.Size = new System.Drawing.Size(145, 22);
            this.mnuHorizontally.Text = "Horizonttally";
            // 
            // mnuVertically
            // 
            this.mnuVertically.Image = ((System.Drawing.Image)(resources.GetObject("mnuVertically.Image")));
            this.mnuVertically.Name = "mnuVertically";
            this.mnuVertically.Size = new System.Drawing.Size(145, 22);
            this.mnuVertically.Text = "Vertically";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Image = ((System.Drawing.Image)(resources.GetObject("mnuCascade.Image")));
            this.mnuCascade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(145, 22);
            this.mnuCascade.Text = "Cascade";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUser,
            this.tssModule});
            this.statusStrip.Location = new System.Drawing.Point(0, 573);
            this.statusStrip.Margin = new System.Windows.Forms.Padding(5);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(890, 26);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // tssUser
            // 
            this.tssUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssUser.Image = ((System.Drawing.Image)(resources.GetObject("tssUser.Image")));
            this.tssUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssUser.Name = "tssUser";
            this.tssUser.Size = new System.Drawing.Size(89, 21);
            this.tssUser.Text = "Current User";
            this.tssUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssModule
            // 
            this.tssModule.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssModule.Image = ((System.Drawing.Image)(resources.GetObject("tssModule.Image")));
            this.tssModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssModule.Margin = new System.Windows.Forms.Padding(3);
            this.tssModule.Name = "tssModule";
            this.tssModule.Size = new System.Drawing.Size(780, 20);
            this.tssModule.Spring = true;
            this.tssModule.Text = "Current Module";
            this.tssModule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 599);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.ModuleID = 2;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.UpdateControls = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministration;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuArrange;
        private System.Windows.Forms.ToolStripMenuItem mnuHorizontally;
        private System.Windows.Forms.ToolStripMenuItem mnuVertically;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssUser;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeModule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssModule;
        private System.Windows.Forms.ToolStripMenuItem mnuReportAdmin;
        private System.Windows.Forms.ToolStripMenuItem mnuListReport;
    }
}

