namespace Module_Gaziview
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_GazDischarge = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Lists = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Graphics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Administration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Params = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ImportOldData = new System.Windows.Forms.ToolStripMenuItem();
            this.ss_Status = new System.Windows.Forms.StatusStrip();
            this.tssl_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.historiqueBDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.ss_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_GazDischarge,
            this.rapportsToolStripMenuItem,
            this.tsmi_Administration});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_GazDischarge
            // 
            this.tsmi_GazDischarge.Name = "tsmi_GazDischarge";
            this.tsmi_GazDischarge.Size = new System.Drawing.Size(89, 20);
            this.tsmi_GazDischarge.Text = "Rejets gazeux";
            this.tsmi_GazDischarge.Click += new System.EventHandler(this.tsmi_GazDischarge_Click);
            // 
            // rapportsToolStripMenuItem
            // 
            this.rapportsToolStripMenuItem.AccessibleName = "reports";
            this.rapportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Lists,
            this.tsmi_Graphics});
            this.rapportsToolStripMenuItem.Name = "rapportsToolStripMenuItem";
            this.rapportsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.rapportsToolStripMenuItem.Text = "Rapports";
            // 
            // tsmi_Lists
            // 
            this.tsmi_Lists.Name = "tsmi_Lists";
            this.tsmi_Lists.Size = new System.Drawing.Size(134, 22);
            this.tsmi_Lists.Text = "Listes";
            this.tsmi_Lists.Click += new System.EventHandler(this.tsmi_Lists_Click);
            // 
            // tsmi_Graphics
            // 
            this.tsmi_Graphics.Name = "tsmi_Graphics";
            this.tsmi_Graphics.Size = new System.Drawing.Size(134, 22);
            this.tsmi_Graphics.Text = "Graphiques";
            this.tsmi_Graphics.Click += new System.EventHandler(this.tsmi_Graphics_Click);
            // 
            // tsmi_Administration
            // 
            this.tsmi_Administration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Params,
            this.tsmi_ImportOldData,
            this.historiqueBDFToolStripMenuItem});
            this.tsmi_Administration.Name = "tsmi_Administration";
            this.tsmi_Administration.Size = new System.Drawing.Size(98, 20);
            this.tsmi_Administration.Text = "Administration";
            // 
            // tsmi_Params
            // 
            this.tsmi_Params.Name = "tsmi_Params";
            this.tsmi_Params.Size = new System.Drawing.Size(156, 22);
            this.tsmi_Params.Text = "Paramètres";
            this.tsmi_Params.Click += new System.EventHandler(this.tsmi_Params_Click);
            // 
            // tsmi_ImportOldData
            // 
            this.tsmi_ImportOldData.Name = "tsmi_ImportOldData";
            this.tsmi_ImportOldData.Size = new System.Drawing.Size(156, 22);
            this.tsmi_ImportOldData.Text = "Import old data";
            this.tsmi_ImportOldData.Click += new System.EventHandler(this.tsmi_ImportOldData_Click);
            // 
            // ss_Status
            // 
            this.ss_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_User,
            this.tssl_Blank});
            this.ss_Status.Location = new System.Drawing.Point(0, 706);
            this.ss_Status.Name = "ss_Status";
            this.ss_Status.Size = new System.Drawing.Size(1008, 24);
            this.ss_Status.TabIndex = 3;
            this.ss_Status.Text = "statusStrip1";
            // 
            // tssl_User
            // 
            this.tssl_User.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssl_User.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssl_User.Name = "tssl_User";
            this.tssl_User.Size = new System.Drawing.Size(34, 19);
            this.tssl_User.Text = "User";
            // 
            // tssl_Blank
            // 
            this.tssl_Blank.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssl_Blank.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssl_Blank.Name = "tssl_Blank";
            this.tssl_Blank.Size = new System.Drawing.Size(959, 19);
            this.tssl_Blank.Spring = true;
            // 
            // historiqueBDFToolStripMenuItem
            // 
            this.historiqueBDFToolStripMenuItem.Name = "historiqueBDFToolStripMenuItem";
            this.historiqueBDFToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.historiqueBDFToolStripMenuItem.Text = "Historique BDF";
            this.historiqueBDFToolStripMenuItem.Click += new System.EventHandler(this.historiqueBDFToolStripMenuItem_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ss_Status);
            this.Controls.Add(this.menuStrip1);
            this.Debug = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.ModuleID = 28;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gaziview";
            this.UpdateControls = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ss_Status.ResumeLayout(false);
            this.ss_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GazDischarge;
        private System.Windows.Forms.ToolStripMenuItem rapportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Administration;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Params;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Lists;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Graphics;
        private System.Windows.Forms.StatusStrip ss_Status;
        private System.Windows.Forms.ToolStripStatusLabel tssl_User;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ImportOldData;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Blank;
        private System.Windows.Forms.ToolStripMenuItem historiqueBDFToolStripMenuItem;
    }
}

