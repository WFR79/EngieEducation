namespace Module_Education.Forms.UserControls
{
    partial class UC_Services
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlRoutes = new System.Windows.Forms.TabControl();
            this.tabListDepService = new System.Windows.Forms.TabPage();
            this.lblSubService = new System.Windows.Forms.Label();
            this.lblDepartement = new System.Windows.Forms.Label();
            this.dgDepartement = new Zuby.ADGV.AdvancedDataGridView();
            this.lblServices = new System.Windows.Forms.Label();
            this.panelDgServices = new System.Windows.Forms.Panel();
            this.dgSubService = new Zuby.ADGV.AdvancedDataGridView();
            this.dgService = new Zuby.ADGV.AdvancedDataGridView();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.dgAgentServices = new Zuby.ADGV.AdvancedDataGridView();
            this.lbltb = new System.Windows.Forms.Label();
            this.lblcombo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.TextBox();
            this.tbServiceDepartement = new System.Windows.Forms.TextBox();
            this.comboDep = new System.Windows.Forms.ComboBox();
            this.lblDgAgents = new System.Windows.Forms.Label();
            this.btnSaveRoutes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlRoutes.SuspendLayout();
            this.tabListDepService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartement)).BeginInit();
            this.panelDgServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgentServices)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlRoutes
            // 
            this.tabControlRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlRoutes.Controls.Add(this.tabListDepService);
            this.tabControlRoutes.Controls.Add(this.tabDetails);
            this.tabControlRoutes.Location = new System.Drawing.Point(3, 3);
            this.tabControlRoutes.Name = "tabControlRoutes";
            this.tabControlRoutes.SelectedIndex = 0;
            this.tabControlRoutes.Size = new System.Drawing.Size(979, 665);
            this.tabControlRoutes.TabIndex = 2;
            // 
            // tabListDepService
            // 
            this.tabListDepService.Controls.Add(this.panelDgServices);
            this.tabListDepService.Location = new System.Drawing.Point(4, 22);
            this.tabListDepService.Name = "tabListDepService";
            this.tabListDepService.Padding = new System.Windows.Forms.Padding(3);
            this.tabListDepService.Size = new System.Drawing.Size(971, 639);
            this.tabListDepService.TabIndex = 2;
            this.tabListDepService.Text = "Sous Services";
            this.tabListDepService.UseVisualStyleBackColor = true;
            // 
            // lblSubService
            // 
            this.lblSubService.AutoSize = true;
            this.lblSubService.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblSubService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSubService.Location = new System.Drawing.Point(511, 16);
            this.lblSubService.Name = "lblSubService";
            this.lblSubService.Size = new System.Drawing.Size(109, 16);
            this.lblSubService.TabIndex = 52;
            this.lblSubService.Text = "Sous Services";
            // 
            // lblDepartement
            // 
            this.lblDepartement.AutoSize = true;
            this.lblDepartement.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDepartement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDepartement.Location = new System.Drawing.Point(6, 385);
            this.lblDepartement.Name = "lblDepartement";
            this.lblDepartement.Size = new System.Drawing.Size(106, 16);
            this.lblDepartement.TabIndex = 50;
            this.lblDepartement.Text = "Départements";
            // 
            // dgDepartement
            // 
            this.dgDepartement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDepartement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDepartement.BackgroundColor = System.Drawing.Color.White;
            this.dgDepartement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepartement.FilterAndSortEnabled = true;
            this.dgDepartement.Location = new System.Drawing.Point(9, 404);
            this.dgDepartement.Name = "dgDepartement";
            this.dgDepartement.ReadOnly = true;
            this.dgDepartement.Size = new System.Drawing.Size(475, 215);
            this.dgDepartement.TabIndex = 0;
            this.dgDepartement.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgDepartement_MouseClick);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblServices.Location = new System.Drawing.Point(6, 16);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(70, 16);
            this.lblServices.TabIndex = 48;
            this.lblServices.Text = "Services";
            // 
            // panelDgServices
            // 
            this.panelDgServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDgServices.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDgServices.Controls.Add(this.lblDepartement);
            this.panelDgServices.Controls.Add(this.dgDepartement);
            this.panelDgServices.Controls.Add(this.lblSubService);
            this.panelDgServices.Controls.Add(this.dgSubService);
            this.panelDgServices.Controls.Add(this.lblServices);
            this.panelDgServices.Controls.Add(this.dgService);
            this.panelDgServices.Font = new System.Drawing.Font("Arial", 9.25F);
            this.panelDgServices.Location = new System.Drawing.Point(9, 6);
            this.panelDgServices.Name = "panelDgServices";
            this.panelDgServices.Size = new System.Drawing.Size(959, 627);
            this.panelDgServices.TabIndex = 47;
            // 
            // dgSubService
            // 
            this.dgSubService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgSubService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSubService.BackgroundColor = System.Drawing.Color.White;
            this.dgSubService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubService.FilterAndSortEnabled = true;
            this.dgSubService.Location = new System.Drawing.Point(484, 35);
            this.dgSubService.Name = "dgSubService";
            this.dgSubService.ReadOnly = true;
            this.dgSubService.Size = new System.Drawing.Size(459, 348);
            this.dgSubService.TabIndex = 51;
            this.dgSubService.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgSubService_MouseClick);
            // 
            // dgService
            // 
            this.dgService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgService.BackgroundColor = System.Drawing.Color.White;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.FilterAndSortEnabled = true;
            this.dgService.Location = new System.Drawing.Point(9, 35);
            this.dgService.Name = "dgService";
            this.dgService.ReadOnly = true;
            this.dgService.Size = new System.Drawing.Size(429, 348);
            this.dgService.TabIndex = 0;
            this.dgService.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgService_MouseClick);
            // 
            // tabDetails
            // 
            this.tabDetails.AutoScroll = true;
            this.tabDetails.Controls.Add(this.button1);
            this.tabDetails.Controls.Add(this.btnSaveRoutes);
            this.tabDetails.Controls.Add(this.lblDgAgents);
            this.tabDetails.Controls.Add(this.lbltb);
            this.tabDetails.Controls.Add(this.lblcombo);
            this.tabDetails.Controls.Add(this.lblTitle);
            this.tabDetails.Controls.Add(this.tbServiceDepartement);
            this.tabDetails.Controls.Add(this.comboDep);
            this.tabDetails.Controls.Add(this.dgAgentServices);
            this.tabDetails.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(971, 639);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Détails";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // dgAgentServices
            // 
            this.dgAgentServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAgentServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAgentServices.BackgroundColor = System.Drawing.Color.White;
            this.dgAgentServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAgentServices.FilterAndSortEnabled = true;
            this.dgAgentServices.Location = new System.Drawing.Point(15, 177);
            this.dgAgentServices.Name = "dgAgentServices";
            this.dgAgentServices.ReadOnly = true;
            this.dgAgentServices.Size = new System.Drawing.Size(952, 446);
            this.dgAgentServices.TabIndex = 1;
            this.dgAgentServices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgAgentServices_MouseClick);
            // 
            // lbltb
            // 
            this.lbltb.AutoSize = true;
            this.lbltb.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lbltb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lbltb.Location = new System.Drawing.Point(13, 45);
            this.lbltb.Name = "lbltb";
            this.lbltb.Size = new System.Drawing.Size(45, 16);
            this.lbltb.TabIndex = 96;
            this.lbltb.Text = "Admin";
            // 
            // lblcombo
            // 
            this.lblcombo.AutoSize = true;
            this.lblcombo.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblcombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblcombo.Location = new System.Drawing.Point(215, 45);
            this.lblcombo.Name = "lblcombo";
            this.lblcombo.Size = new System.Drawing.Size(82, 16);
            this.lblcombo.TabIndex = 95;
            this.lblcombo.Text = "Departement";
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(261, 25);
            this.lblTitle.TabIndex = 92;
            this.lblTitle.Text = "Services Departements";
            // 
            // tbServiceDepartement
            // 
            this.tbServiceDepartement.Location = new System.Drawing.Point(12, 65);
            this.tbServiceDepartement.Name = "tbServiceDepartement";
            this.tbServiceDepartement.Size = new System.Drawing.Size(185, 20);
            this.tbServiceDepartement.TabIndex = 94;
            this.tbServiceDepartement.Text = "Admin";
            // 
            // comboDep
            // 
            this.comboDep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboDep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDep.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboDep.FormattingEnabled = true;
            this.comboDep.Location = new System.Drawing.Point(215, 65);
            this.comboDep.Name = "comboDep";
            this.comboDep.Size = new System.Drawing.Size(185, 22);
            this.comboDep.TabIndex = 93;
            this.comboDep.Text = "Equipe/Affectation";
            // 
            // lblDgAgents
            // 
            this.lblDgAgents.AutoSize = true;
            this.lblDgAgents.Font = new System.Drawing.Font("Arial", 12.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblDgAgents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDgAgents.Location = new System.Drawing.Point(12, 145);
            this.lblDgAgents.Name = "lblDgAgents";
            this.lblDgAgents.Size = new System.Drawing.Size(155, 19);
            this.lblDgAgents.TabIndex = 97;
            this.lblDgAgents.Text = "Liste d\'agents liés ";
            // 
            // btnSaveRoutes
            // 
            this.btnSaveRoutes.AllowDrop = true;
            this.btnSaveRoutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnSaveRoutes.FlatAppearance.BorderSize = 0;
            this.btnSaveRoutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRoutes.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSaveRoutes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveRoutes.Location = new System.Drawing.Point(12, 95);
            this.btnSaveRoutes.Name = "btnSaveRoutes";
            this.btnSaveRoutes.Size = new System.Drawing.Size(96, 23);
            this.btnSaveRoutes.TabIndex = 98;
            this.btnSaveRoutes.Text = "Enregistrer";
            this.btnSaveRoutes.UseVisualStyleBackColor = false;
            this.btnSaveRoutes.Click += new System.EventHandler(this.btnSaveRoutes_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(123, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 99;
            this.button1.Text = "Supprimer";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // UC_Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlRoutes);
            this.Name = "UC_Services";
            this.Size = new System.Drawing.Size(986, 691);
            this.tabControlRoutes.ResumeLayout(false);
            this.tabListDepService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartement)).EndInit();
            this.panelDgServices.ResumeLayout(false);
            this.panelDgServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgentServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRoutes;
        private System.Windows.Forms.TabPage tabListDepService;
        private System.Windows.Forms.Label lblDepartement;
        private Zuby.ADGV.AdvancedDataGridView dgDepartement;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Panel panelDgServices;
        private Zuby.ADGV.AdvancedDataGridView dgService;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.Label lblSubService;
        private Zuby.ADGV.AdvancedDataGridView dgSubService;
        private Zuby.ADGV.AdvancedDataGridView dgAgentServices;
        private System.Windows.Forms.Label lbltb;
        private System.Windows.Forms.Label lblcombo;
        private System.Windows.Forms.TextBox lblTitle;
        private System.Windows.Forms.TextBox tbServiceDepartement;
        private System.Windows.Forms.ComboBox comboDep;
        private System.Windows.Forms.Label lblDgAgents;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSaveRoutes;
    }
}
