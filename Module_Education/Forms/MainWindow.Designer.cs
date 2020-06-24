namespace Module_Education
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblNoticeBeta = new System.Windows.Forms.Label();
            this.lblBetaVersion = new System.Windows.Forms.Label();
            this.lblTitleApp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHelloUsername = new System.Windows.Forms.Label();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.btn_ShowHideMenu = new System.Windows.Forms.PictureBox();
            this.flowPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuBtnEducation_Formation = new System.Windows.Forms.Button();
            this.MenuBtnAgent = new System.Windows.Forms.Button();
            this.MenuBtnGrpAgent = new System.Windows.Forms.Button();
            this.MenuBtnCertificate = new System.Windows.Forms.Button();
            this.btnMenu_Provider = new System.Windows.Forms.Button();
            this.btnMatriceFormation = new System.Windows.Forms.Button();
            this.MenuBtnServices = new System.Windows.Forms.Button();
            this.btnMenuMovement = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ShowHideMenu)).BeginInit();
            this.flowPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelMain.Controls.Add(this.lblNoticeBeta);
            this.panelMain.Controls.Add(this.lblBetaVersion);
            this.panelMain.Controls.Add(this.lblTitleApp);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Location = new System.Drawing.Point(188, -3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(682, 437);
            this.panelMain.TabIndex = 2;
            // 
            // lblNoticeBeta
            // 
            this.lblNoticeBeta.AccessibleName = "lblNoticeBeta";
            this.lblNoticeBeta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoticeBeta.AutoSize = true;
            this.lblNoticeBeta.Location = new System.Drawing.Point(240, 281);
            this.lblNoticeBeta.Name = "lblNoticeBeta";
            this.lblNoticeBeta.Size = new System.Drawing.Size(620, 13);
            this.lblNoticeBeta.TabIndex = 5;
            this.lblNoticeBeta.Text = "Notice : Les données représentées dans cette application sont des données de test" +
    " et non mise à jour et ne reflètent pas la réalité.";
            // 
            // lblBetaVersion
            // 
            this.lblBetaVersion.AccessibleName = "lblNoticeBeta";
            this.lblBetaVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetaVersion.AutoSize = true;
            this.lblBetaVersion.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblBetaVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblBetaVersion.Location = new System.Drawing.Point(473, 230);
            this.lblBetaVersion.Name = "lblBetaVersion";
            this.lblBetaVersion.Size = new System.Drawing.Size(130, 16);
            this.lblBetaVersion.TabIndex = 4;
            this.lblBetaVersion.Text = "Version Beta Test";
            // 
            // lblTitleApp
            // 
            this.lblTitleApp.AccessibleName = "lblNoticeBeta";
            this.lblTitleApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleApp.AutoSize = true;
            this.lblTitleApp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblTitleApp.Location = new System.Drawing.Point(434, 201);
            this.lblTitleApp.Name = "lblTitleApp";
            this.lblTitleApp.Size = new System.Drawing.Size(223, 29);
            this.lblTitleApp.TabIndex = 3;
            this.lblTitleApp.Text = "Module Education";
            this.lblTitleApp.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblHelloUsername);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.btn_ShowHideMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 48);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Module_Education.Properties.Resources.Hideshowmenu;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // lblHelloUsername
            // 
            this.lblHelloUsername.AutoSize = true;
            this.lblHelloUsername.Font = new System.Drawing.Font("Arial", 16F);
            this.lblHelloUsername.ForeColor = System.Drawing.Color.Snow;
            this.lblHelloUsername.Location = new System.Drawing.Point(45, 12);
            this.lblHelloUsername.Name = "lblHelloUsername";
            this.lblHelloUsername.Size = new System.Drawing.Size(68, 25);
            this.lblHelloUsername.TabIndex = 3;
            this.lblHelloUsername.Text = "label1";
            this.lblHelloUsername.Click += new System.EventHandler(this.lblHelloUsername_Click);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxExit.Image = global::Module_Education.Properties.Resources.outline_clear_black_24dp2;
            this.pictureBoxExit.Location = new System.Drawing.Point(618, 4);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(52, 47);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExit.TabIndex = 2;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            // 
            // btn_ShowHideMenu
            // 
            this.btn_ShowHideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowHideMenu.Enabled = false;
            this.btn_ShowHideMenu.Location = new System.Drawing.Point(426, 9);
            this.btn_ShowHideMenu.Name = "btn_ShowHideMenu";
            this.btn_ShowHideMenu.Size = new System.Drawing.Size(37, 37);
            this.btn_ShowHideMenu.TabIndex = 0;
            this.btn_ShowHideMenu.TabStop = false;
            this.btn_ShowHideMenu.Click += new System.EventHandler(this.button_ShowHideMenu_Click);
            // 
            // flowPanelMenu
            // 
            this.flowPanelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.flowPanelMenu.Controls.Add(this.MenuBtnEducation_Formation);
            this.flowPanelMenu.Controls.Add(this.MenuBtnAgent);
            this.flowPanelMenu.Controls.Add(this.MenuBtnGrpAgent);
            this.flowPanelMenu.Controls.Add(this.MenuBtnCertificate);
            this.flowPanelMenu.Controls.Add(this.btnMenu_Provider);
            this.flowPanelMenu.Controls.Add(this.btnMatriceFormation);
            this.flowPanelMenu.Controls.Add(this.MenuBtnServices);
            this.flowPanelMenu.Controls.Add(this.btnMenuMovement);
            this.flowPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelMenu.Location = new System.Drawing.Point(0, -3);
            this.flowPanelMenu.Name = "flowPanelMenu";
            this.flowPanelMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowPanelMenu.Size = new System.Drawing.Size(192, 437);
            this.flowPanelMenu.TabIndex = 1;
            // 
            // MenuBtnEducation_Formation
            // 
            this.MenuBtnEducation_Formation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.MenuBtnEducation_Formation.FlatAppearance.BorderSize = 0;
            this.MenuBtnEducation_Formation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnEducation_Formation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnEducation_Formation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnEducation_Formation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnEducation_Formation.Location = new System.Drawing.Point(-23, 60);
            this.MenuBtnEducation_Formation.Margin = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.MenuBtnEducation_Formation.Name = "MenuBtnEducation_Formation";
            this.MenuBtnEducation_Formation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnEducation_Formation.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnEducation_Formation.TabIndex = 15;
            this.MenuBtnEducation_Formation.Text = "Formations";
            this.MenuBtnEducation_Formation.UseVisualStyleBackColor = false;
            this.MenuBtnEducation_Formation.Click += new System.EventHandler(this.MenuBtnFormation_Click);
            // 
            // MenuBtnAgent
            // 
            this.MenuBtnAgent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.MenuBtnAgent.FlatAppearance.BorderSize = 0;
            this.MenuBtnAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnAgent.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnAgent.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnAgent.Location = new System.Drawing.Point(-23, 97);
            this.MenuBtnAgent.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnAgent.Name = "MenuBtnAgent";
            this.MenuBtnAgent.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnAgent.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnAgent.TabIndex = 10;
            this.MenuBtnAgent.Text = "  Agents";
            this.MenuBtnAgent.UseVisualStyleBackColor = false;
            this.MenuBtnAgent.Click += new System.EventHandler(this.MenuBtnAgent_Click);
            // 
            // MenuBtnGrpAgent
            // 
            this.MenuBtnGrpAgent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.MenuBtnGrpAgent.FlatAppearance.BorderSize = 0;
            this.MenuBtnGrpAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnGrpAgent.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnGrpAgent.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnGrpAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnGrpAgent.Location = new System.Drawing.Point(-23, 134);
            this.MenuBtnGrpAgent.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnGrpAgent.Name = "MenuBtnGrpAgent";
            this.MenuBtnGrpAgent.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnGrpAgent.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnGrpAgent.TabIndex = 16;
            this.MenuBtnGrpAgent.Text = "Groupe d\'agents";
            this.MenuBtnGrpAgent.UseVisualStyleBackColor = false;
            this.MenuBtnGrpAgent.Click += new System.EventHandler(this.MenuBtnGrpAgent_Click);
            // 
            // MenuBtnCertificate
            // 
            this.MenuBtnCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.MenuBtnCertificate.FlatAppearance.BorderSize = 0;
            this.MenuBtnCertificate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnCertificate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnCertificate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnCertificate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnCertificate.Location = new System.Drawing.Point(-23, 171);
            this.MenuBtnCertificate.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnCertificate.Name = "MenuBtnCertificate";
            this.MenuBtnCertificate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnCertificate.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnCertificate.TabIndex = 19;
            this.MenuBtnCertificate.Text = "Certifications";
            this.MenuBtnCertificate.UseVisualStyleBackColor = false;
            this.MenuBtnCertificate.Click += new System.EventHandler(this.MenuBtnCertificate_Click);
            // 
            // btnMenu_Provider
            // 
            this.btnMenu_Provider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnMenu_Provider.FlatAppearance.BorderSize = 0;
            this.btnMenu_Provider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu_Provider.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu_Provider.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenu_Provider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenu_Provider.Location = new System.Drawing.Point(-23, 208);
            this.btnMenu_Provider.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu_Provider.Name = "btnMenu_Provider";
            this.btnMenu_Provider.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMenu_Provider.Size = new System.Drawing.Size(215, 37);
            this.btnMenu_Provider.TabIndex = 17;
            this.btnMenu_Provider.Text = "Fournisseurs";
            this.btnMenu_Provider.UseVisualStyleBackColor = false;
            this.btnMenu_Provider.Click += new System.EventHandler(this.btnMenu_Provider_Click);
            // 
            // btnMatriceFormation
            // 
            this.btnMatriceFormation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnMatriceFormation.FlatAppearance.BorderSize = 0;
            this.btnMatriceFormation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatriceFormation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatriceFormation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMatriceFormation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMatriceFormation.Location = new System.Drawing.Point(-23, 245);
            this.btnMatriceFormation.Margin = new System.Windows.Forms.Padding(0);
            this.btnMatriceFormation.Name = "btnMatriceFormation";
            this.btnMatriceFormation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMatriceFormation.Size = new System.Drawing.Size(215, 59);
            this.btnMatriceFormation.TabIndex = 18;
            this.btnMatriceFormation.Text = "Trajets de formations";
            this.btnMatriceFormation.UseVisualStyleBackColor = false;
            this.btnMatriceFormation.Click += new System.EventHandler(this.btnMatriceFormation_Click);
            // 
            // MenuBtnServices
            // 
            this.MenuBtnServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.MenuBtnServices.FlatAppearance.BorderSize = 0;
            this.MenuBtnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnServices.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnServices.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnServices.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnServices.Location = new System.Drawing.Point(-23, 304);
            this.MenuBtnServices.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnServices.Name = "MenuBtnServices";
            this.MenuBtnServices.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnServices.Size = new System.Drawing.Size(215, 59);
            this.MenuBtnServices.TabIndex = 21;
            this.MenuBtnServices.Text = "Départements et services";
            this.MenuBtnServices.UseVisualStyleBackColor = false;
            this.MenuBtnServices.Click += new System.EventHandler(this.MenuBtnServices_Click);
            // 
            // btnMenuMovement
            // 
            this.btnMenuMovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnMenuMovement.FlatAppearance.BorderSize = 0;
            this.btnMenuMovement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuMovement.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMovement.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuMovement.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuMovement.Location = new System.Drawing.Point(-23, 363);
            this.btnMenuMovement.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuMovement.Name = "btnMenuMovement";
            this.btnMenuMovement.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMenuMovement.Size = new System.Drawing.Size(215, 59);
            this.btnMenuMovement.TabIndex = 20;
            this.btnMenuMovement.Text = "Mouvement du personnel";
            this.btnMenuMovement.UseVisualStyleBackColor = false;
            this.btnMenuMovement.Click += new System.EventHandler(this.btnMenuMovement_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 70;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 433);
            this.Controls.Add(this.flowPanelMenu);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module Education";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ShowHideMenu)).EndInit();
            this.flowPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowPanelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox btn_ShowHideMenu;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.Button MenuBtnAgent;
        private System.Windows.Forms.Button MenuBtnEducation_Formation;
        private System.Windows.Forms.Button MenuBtnGrpAgent;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.Label lblHelloUsername;
        private System.Windows.Forms.Button btnMenu_Provider;
        private System.Windows.Forms.Button btnMatriceFormation;
        private System.Windows.Forms.Button MenuBtnCertificate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitleApp;
        private System.Windows.Forms.Label lblNoticeBeta;
        private System.Windows.Forms.Label lblBetaVersion;
        private System.Windows.Forms.Button btnMenuMovement;
        private System.Windows.Forms.Button MenuBtnServices;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

