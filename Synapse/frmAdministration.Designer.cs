namespace Synapse
{
    partial class frmAdministration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministration));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.synapseAdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModules = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccessRights = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUser,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1138, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssUser
            // 
            this.tssUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssUser.Image = ((System.Drawing.Image)(resources.GetObject("tssUser.Image")));
            this.tssUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssUser.Name = "tssUser";
            this.tssUser.Size = new System.Drawing.Size(49, 20);
            this.tssUser.Text = "User";
            this.tssUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1074, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.synapseAdministrationToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1138, 24);
            this.mnuMain.TabIndex = 6;
            this.mnuMain.Text = "Security Overview";
            // 
            // synapseAdministrationToolStripMenuItem
            // 
            this.synapseAdministrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuModules,
            this.mnuPermissions,
            this.mnuAccessRights,
            this.mnuOverview,
            this.toolStripSeparator1,
            this.mnuQuit});
            this.synapseAdministrationToolStripMenuItem.Name = "synapseAdministrationToolStripMenuItem";
            this.synapseAdministrationToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.synapseAdministrationToolStripMenuItem.Text = "Synapse Administration";
            // 
            // mnuModules
            // 
            this.mnuModules.Name = "mnuModules";
            this.mnuModules.Size = new System.Drawing.Size(184, 22);
            this.mnuModules.Text = "Modules";
            this.mnuModules.Click += new System.EventHandler(this.mnuModules_Click);
            // 
            // mnuPermissions
            // 
            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(184, 22);
            this.mnuPermissions.Text = "Module\'s Permissions";
            this.mnuPermissions.Click += new System.EventHandler(this.mnuPermissions_Click);
            // 
            // mnuAccessRights
            // 
            this.mnuAccessRights.Name = "mnuAccessRights";
            this.mnuAccessRights.Size = new System.Drawing.Size(184, 22);
            this.mnuAccessRights.Text = "Access Rights";
            this.mnuAccessRights.Click += new System.EventHandler(this.mnuAccessRights_Click);
            // 
            // mnuOverview
            // 
            this.mnuOverview.Name = "mnuOverview";
            this.mnuOverview.Size = new System.Drawing.Size(184, 22);
            this.mnuOverview.Text = "Security Overview";
            this.mnuOverview.Click += new System.EventHandler(this.mnuOverview_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(184, 22);
            this.mnuQuit.Text = "Quit";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // frmAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 649);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.ModuleID = 1;
            this.Name = "frmAdministration";
            this.ShowMenu = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAdministration";
            this.UpdateControls = true;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem synapseAdministrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem mnuAccessRights;
        private System.Windows.Forms.ToolStripMenuItem mnuModules;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissions;
        private System.Windows.Forms.ToolStripMenuItem mnuOverview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}