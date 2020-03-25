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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHelloUsername = new System.Windows.Forms.Label();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.btn_ShowHideMenu = new System.Windows.Forms.PictureBox();
            this.flowPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuBtnEducation_Formation = new System.Windows.Forms.Button();
            this.MenuBtnAgent = new System.Windows.Forms.Button();
            this.MenuBtnAuthentification = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(211)))), ((int)(((byte)(205)))));
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Location = new System.Drawing.Point(207, -3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(659, 304);
            this.panelMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(114)))));
            this.panel1.Controls.Add(this.lblHelloUsername);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.btn_ShowHideMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 54);
            this.panel1.TabIndex = 2;
            // 
            // lblHelloUsername
            // 
            this.lblHelloUsername.AutoSize = true;
            this.lblHelloUsername.Font = new System.Drawing.Font("Arial", 16F);
            this.lblHelloUsername.ForeColor = System.Drawing.Color.Snow;
            this.lblHelloUsername.Location = new System.Drawing.Point(9, 21);
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
            this.pictureBoxExit.Location = new System.Drawing.Point(595, 4);
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
            this.btn_ShowHideMenu.Location = new System.Drawing.Point(403, 9);
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
            this.flowPanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(56)))));
            this.flowPanelMenu.Controls.Add(this.MenuBtnEducation_Formation);
            this.flowPanelMenu.Controls.Add(this.MenuBtnAgent);
            this.flowPanelMenu.Controls.Add(this.MenuBtnAuthentification);
            this.flowPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.flowPanelMenu.Name = "flowPanelMenu";
            this.flowPanelMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowPanelMenu.Size = new System.Drawing.Size(210, 301);
            this.flowPanelMenu.TabIndex = 1;
            // 
            // MenuBtnEducation_Formation
            // 
            this.MenuBtnEducation_Formation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(56)))));
            this.MenuBtnEducation_Formation.FlatAppearance.BorderSize = 0;
            this.MenuBtnEducation_Formation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnEducation_Formation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnEducation_Formation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnEducation_Formation.Image = ((System.Drawing.Image)(resources.GetObject("MenuBtnEducation_Formation.Image")));
            this.MenuBtnEducation_Formation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnEducation_Formation.Location = new System.Drawing.Point(-5, 60);
            this.MenuBtnEducation_Formation.Margin = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.MenuBtnEducation_Formation.Name = "MenuBtnEducation_Formation";
            this.MenuBtnEducation_Formation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnEducation_Formation.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnEducation_Formation.TabIndex = 15;
            this.MenuBtnEducation_Formation.Text = "Formations";
            this.MenuBtnEducation_Formation.UseVisualStyleBackColor = false;
            this.MenuBtnEducation_Formation.Click += new System.EventHandler(this.MenuBtnEducation_Formation_Click);
            // 
            // MenuBtnAgent
            // 
            this.MenuBtnAgent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(56)))));
            this.MenuBtnAgent.FlatAppearance.BorderSize = 0;
            this.MenuBtnAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnAgent.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnAgent.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnAgent.Image = ((System.Drawing.Image)(resources.GetObject("MenuBtnAgent.Image")));
            this.MenuBtnAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnAgent.Location = new System.Drawing.Point(-5, 97);
            this.MenuBtnAgent.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnAgent.Name = "MenuBtnAgent";
            this.MenuBtnAgent.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnAgent.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnAgent.TabIndex = 10;
            this.MenuBtnAgent.Text = "  Agents";
            this.MenuBtnAgent.UseVisualStyleBackColor = false;
            this.MenuBtnAgent.Click += new System.EventHandler(this.MenuAgenClick);
            // 
            // MenuBtnAuthentification
            // 
            this.MenuBtnAuthentification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(56)))));
            this.MenuBtnAuthentification.Enabled = false;
            this.MenuBtnAuthentification.FlatAppearance.BorderSize = 0;
            this.MenuBtnAuthentification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBtnAuthentification.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBtnAuthentification.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuBtnAuthentification.Image = ((System.Drawing.Image)(resources.GetObject("MenuBtnAuthentification.Image")));
            this.MenuBtnAuthentification.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuBtnAuthentification.Location = new System.Drawing.Point(-5, 134);
            this.MenuBtnAuthentification.Margin = new System.Windows.Forms.Padding(0);
            this.MenuBtnAuthentification.Name = "MenuBtnAuthentification";
            this.MenuBtnAuthentification.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuBtnAuthentification.Size = new System.Drawing.Size(215, 37);
            this.MenuBtnAuthentification.TabIndex = 16;
            this.MenuBtnAuthentification.Text = "Certifications";
            this.MenuBtnAuthentification.UseVisualStyleBackColor = false;
            this.MenuBtnAuthentification.Click += new System.EventHandler(this.MenuBtnAuthentification_Click);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(866, 300);
            this.Controls.Add(this.flowPanelMenu);
            this.Controls.Add(this.panelMain);
            this.HelpButton = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFN_Education_Formations";
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button MenuBtnAuthentification;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.Label lblHelloUsername;
    }
}

