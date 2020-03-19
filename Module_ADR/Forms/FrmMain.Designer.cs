namespace Module_ADR.Forms
{
    partial class ADR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADR));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMesureParade = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditMP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerUneAnalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAnalyse,
            this.tsmMesureParade,
            this.tsmAdmin});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmAnalyse
            // 
            this.tsmAnalyse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewAnalyse});
            this.tsmAnalyse.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmAnalyse.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.tsmAnalyse.Name = "tsmAnalyse";
            this.tsmAnalyse.Size = new System.Drawing.Size(60, 20);
            this.tsmAnalyse.Text = "Analyse";
            this.tsmAnalyse.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.tsmAnalyse.DropDownOpened += new System.EventHandler(this.DropDownOpened);
            // 
            // tsmNewAnalyse
            // 
            this.tsmNewAnalyse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.tsmNewAnalyse.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmNewAnalyse.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsmNewAnalyse.Name = "tsmNewAnalyse";
            this.tsmNewAnalyse.Size = new System.Drawing.Size(182, 22);
            this.tsmNewAnalyse.Text = "Gestion des analyses";
            this.tsmNewAnalyse.Click += new System.EventHandler(this.tsmNewAnalyse_Click);
            this.tsmNewAnalyse.MouseEnter += new System.EventHandler(this.DropDownOpened);
            this.tsmNewAnalyse.MouseLeave += new System.EventHandler(this.DropDownClosed);
            // 
            // tsmMesureParade
            // 
            this.tsmMesureParade.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditMP});
            this.tsmMesureParade.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmMesureParade.Name = "tsmMesureParade";
            this.tsmMesureParade.Size = new System.Drawing.Size(120, 20);
            this.tsmMesureParade.Text = "Mesures et Parades";
            this.tsmMesureParade.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.tsmMesureParade.DropDownOpened += new System.EventHandler(this.DropDownOpened);
            // 
            // tsmEditMP
            // 
            this.tsmEditMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.tsmEditMP.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmEditMP.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsmEditMP.Name = "tsmEditMP";
            this.tsmEditMP.Size = new System.Drawing.Size(208, 22);
            this.tsmEditMP.Text = "Editer mesures et parades";
            this.tsmEditMP.Click += new System.EventHandler(this.tsmEditMP_Click);
            this.tsmEditMP.MouseEnter += new System.EventHandler(this.DropDownOpened);
            this.tsmEditMP.MouseLeave += new System.EventHandler(this.DropDownClosed);
            // 
            // tsmAdmin
            // 
            this.tsmAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilisateursToolStripMenuItem,
            this.historiqueToolStripMenuItem,
            this.supprimerUneAnalyseToolStripMenuItem});
            this.tsmAdmin.ForeColor = System.Drawing.SystemColors.Window;
            this.tsmAdmin.Name = "tsmAdmin";
            this.tsmAdmin.Size = new System.Drawing.Size(98, 20);
            this.tsmAdmin.Text = "Administration";
            this.tsmAdmin.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            this.tsmAdmin.DropDownOpened += new System.EventHandler(this.DropDownOpened);
            // 
            // utilisateursToolStripMenuItem
            // 
            this.utilisateursToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.utilisateursToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            this.utilisateursToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.utilisateursToolStripMenuItem.Text = "Utilisateurs";
            this.utilisateursToolStripMenuItem.Click += new System.EventHandler(this.utilisateursToolStripMenuItem_Click);
            this.utilisateursToolStripMenuItem.MouseEnter += new System.EventHandler(this.DropDownOpened);
            this.utilisateursToolStripMenuItem.MouseLeave += new System.EventHandler(this.DropDownClosed);
            // 
            // historiqueToolStripMenuItem
            // 
            this.historiqueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.historiqueToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            this.historiqueToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.historiqueToolStripMenuItem.Text = "Historique";
            this.historiqueToolStripMenuItem.Click += new System.EventHandler(this.historiqueToolStripMenuItem_Click);
            this.historiqueToolStripMenuItem.MouseEnter += new System.EventHandler(this.DropDownOpened);
            this.historiqueToolStripMenuItem.MouseLeave += new System.EventHandler(this.DropDownClosed);
            // 
            // supprimerUneAnalyseToolStripMenuItem
            // 
            this.supprimerUneAnalyseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.supprimerUneAnalyseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.supprimerUneAnalyseToolStripMenuItem.Name = "supprimerUneAnalyseToolStripMenuItem";
            this.supprimerUneAnalyseToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.supprimerUneAnalyseToolStripMenuItem.Text = "Supprimer une analyse";
            this.supprimerUneAnalyseToolStripMenuItem.Click += new System.EventHandler(this.supprimerUneAnalyseToolStripMenuItem_Click);
            this.supprimerUneAnalyseToolStripMenuItem.MouseEnter += new System.EventHandler(this.DropDownOpened);
            this.supprimerUneAnalyseToolStripMenuItem.MouseLeave += new System.EventHandler(this.DropDownClosed);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUser,
            this.tssRole,
            this.tssBlank});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssUser
            // 
            this.tssUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssUser.Image = ((System.Drawing.Image)(resources.GetObject("tssUser.Image")));
            this.tssUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssUser.Name = "tssUser";
            this.tssUser.Size = new System.Drawing.Size(20, 20);
            this.tssUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssRole
            // 
            this.tssRole.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssRole.Image = ((System.Drawing.Image)(resources.GetObject("tssRole.Image")));
            this.tssRole.Name = "tssRole";
            this.tssRole.Size = new System.Drawing.Size(20, 20);
            this.tssRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssBlank
            // 
            this.tssBlank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.tssBlank.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssBlank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssBlank.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tssBlank.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssBlank.Name = "tssBlank";
            this.tssBlank.Size = new System.Drawing.Size(577, 20);
            this.tssBlank.Spring = true;
            this.tssBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ADR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.ModuleID = 52;
            this.Name = "ADR";
            this.ShowMenu = false;
            this.Text = "ADR";
            this.UpdateControls = true;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmAnalyse;
        private System.Windows.Forms.ToolStripMenuItem tsmNewAnalyse;
        private System.Windows.Forms.ToolStripMenuItem tsmMesureParade;
        private System.Windows.Forms.ToolStripMenuItem tsmEditMP;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmin;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tssUser;
        internal System.Windows.Forms.ToolStripStatusLabel tssRole;
        internal System.Windows.Forms.ToolStripStatusLabel tssBlank;
        private System.Windows.Forms.ToolStripMenuItem utilisateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerUneAnalyseToolStripMenuItem;
    }
}



