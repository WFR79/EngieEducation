namespace Module_Education.Forms.UserControls
{
    partial class UC_MatriceFormations
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
            this.components = new System.ComponentModel.Container();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle13 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle14 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle15 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle16 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle17 = new SynapseAdvancedControls.HeaderStateStyle();
            SynapseAdvancedControls.HeaderStateStyle headerStateStyle18 = new SynapseAdvancedControls.HeaderStateStyle();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Trajets");
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.headerFormatStyle1 = new SynapseAdvancedControls.HeaderFormatStyle();
            this.headerFormatStyle2 = new SynapseAdvancedControls.HeaderFormatStyle();
            this.equipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipExcel = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblFormationMAtrice = new System.Windows.Forms.Label();
            this.lblDetailsMatrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.PanelDetailsMatrice = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblrecurrenceSemaine = new System.Windows.Forms.Label();
            this.lblReccurencyMatrice = new System.Windows.Forms.Label();
            this.cbRecurrency = new System.Windows.Forms.ComboBox();
            this.btnSaveRoutes = new System.Windows.Forms.Button();
            this.lblAddMatriceFormation = new System.Windows.Forms.Label();
            this.picAddMatrice = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.treeW_Provider = new System.Windows.Forms.TreeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.equipeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.PanelDetailsMatrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMatrice)).BeginInit();
            this.SuspendLayout();
            // 
            // headerFormatStyle1
            // 
            this.headerFormatStyle1.Hot = headerStateStyle13;
            this.headerFormatStyle1.Normal = headerStateStyle14;
            this.headerFormatStyle1.Pressed = headerStateStyle15;
            // 
            // headerFormatStyle2
            // 
            this.headerFormatStyle2.Hot = headerStateStyle16;
            this.headerFormatStyle2.Normal = headerStateStyle17;
            this.headerFormatStyle2.Pressed = headerStateStyle18;
            // 
            // equipeBindingSource
            // 
            this.equipeBindingSource.DataMember = "Equipe";
            // 
            // toolTipExcel
            // 
            this.toolTipExcel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipExcel.ToolTipTitle = "Exporter le tableau vers excel";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblFormationMAtrice
            // 
            this.lblFormationMAtrice.AutoSize = true;
            this.lblFormationMAtrice.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblFormationMAtrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormationMAtrice.Location = new System.Drawing.Point(446, 278);
            this.lblFormationMAtrice.Name = "lblFormationMAtrice";
            this.lblFormationMAtrice.Size = new System.Drawing.Size(59, 16);
            this.lblFormationMAtrice.TabIndex = 29;
            this.lblFormationMAtrice.Text = "Détails ";
            // 
            // lblDetailsMatrice
            // 
            this.lblDetailsMatrice.AutoSize = true;
            this.lblDetailsMatrice.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDetailsMatrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDetailsMatrice.Location = new System.Drawing.Point(446, 60);
            this.lblDetailsMatrice.Name = "lblDetailsMatrice";
            this.lblDetailsMatrice.Size = new System.Drawing.Size(59, 16);
            this.lblDetailsMatrice.TabIndex = 28;
            this.lblDetailsMatrice.Text = "Détails ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(449, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 159);
            this.panel1.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(20, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 88;
            this.button2.Text = "Sauver ";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // PanelDetailsMatrice
            // 
            this.PanelDetailsMatrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelDetailsMatrice.Controls.Add(this.button1);
            this.PanelDetailsMatrice.Controls.Add(this.lblrecurrenceSemaine);
            this.PanelDetailsMatrice.Controls.Add(this.lblReccurencyMatrice);
            this.PanelDetailsMatrice.Controls.Add(this.cbRecurrency);
            this.PanelDetailsMatrice.Location = new System.Drawing.Point(449, 88);
            this.PanelDetailsMatrice.Name = "PanelDetailsMatrice";
            this.PanelDetailsMatrice.Size = new System.Drawing.Size(596, 159);
            this.PanelDetailsMatrice.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(20, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 87;
            this.button1.Text = "Sauver ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblrecurrenceSemaine
            // 
            this.lblrecurrenceSemaine.AutoSize = true;
            this.lblrecurrenceSemaine.Font = new System.Drawing.Font("Arial", 7.25F);
            this.lblrecurrenceSemaine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblrecurrenceSemaine.Location = new System.Drawing.Point(96, 35);
            this.lblrecurrenceSemaine.Name = "lblrecurrenceSemaine";
            this.lblrecurrenceSemaine.Size = new System.Drawing.Size(60, 13);
            this.lblrecurrenceSemaine.TabIndex = 86;
            this.lblrecurrenceSemaine.Text = "Semaine(s)";
            // 
            // lblReccurencyMatrice
            // 
            this.lblReccurencyMatrice.AutoSize = true;
            this.lblReccurencyMatrice.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblReccurencyMatrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblReccurencyMatrice.Location = new System.Drawing.Point(17, 13);
            this.lblReccurencyMatrice.Name = "lblReccurencyMatrice";
            this.lblReccurencyMatrice.Size = new System.Drawing.Size(74, 16);
            this.lblReccurencyMatrice.TabIndex = 85;
            this.lblReccurencyMatrice.Text = "Récurrence";
            // 
            // cbRecurrency
            // 
            this.cbRecurrency.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbRecurrency.FormattingEnabled = true;
            this.cbRecurrency.Location = new System.Drawing.Point(20, 31);
            this.cbRecurrency.Name = "cbRecurrency";
            this.cbRecurrency.Size = new System.Drawing.Size(72, 22);
            this.cbRecurrency.TabIndex = 84;
            // 
            // btnSaveRoutes
            // 
            this.btnSaveRoutes.AllowDrop = true;
            this.btnSaveRoutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRoutes.Location = new System.Drawing.Point(27, 509);
            this.btnSaveRoutes.Name = "btnSaveRoutes";
            this.btnSaveRoutes.Size = new System.Drawing.Size(96, 23);
            this.btnSaveRoutes.TabIndex = 25;
            this.btnSaveRoutes.Text = "Sauver ";
            this.btnSaveRoutes.UseVisualStyleBackColor = true;
            this.btnSaveRoutes.Click += new System.EventHandler(this.SaveRoutesFormation);
            // 
            // lblAddMatriceFormation
            // 
            this.lblAddMatriceFormation.AutoSize = true;
            this.lblAddMatriceFormation.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblAddMatriceFormation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblAddMatriceFormation.Location = new System.Drawing.Point(70, 60);
            this.lblAddMatriceFormation.Name = "lblAddMatriceFormation";
            this.lblAddMatriceFormation.Size = new System.Drawing.Size(224, 16);
            this.lblAddMatriceFormation.TabIndex = 24;
            this.lblAddMatriceFormation.Text = "Ajouter une trajet de formation";
            // 
            // picAddMatrice
            // 
            this.picAddMatrice.Enabled = false;
            this.picAddMatrice.Image = global::Module_Education.Properties.Resources.baseline_library_add_black_18dp;
            this.picAddMatrice.Location = new System.Drawing.Point(27, 45);
            this.picAddMatrice.Name = "picAddMatrice";
            this.picAddMatrice.Size = new System.Drawing.Size(36, 36);
            this.picAddMatrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAddMatrice.TabIndex = 23;
            this.picAddMatrice.TabStop = false;
            this.picAddMatrice.Click += new System.EventHandler(this.picAddMatrice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label4.Location = new System.Drawing.Point(23, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Trajets de formations";
            // 
            // treeW_Provider
            // 
            this.treeW_Provider.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeW_Provider.Font = new System.Drawing.Font("Arial", 10.25F);
            this.treeW_Provider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.treeW_Provider.Location = new System.Drawing.Point(27, 88);
            this.treeW_Provider.Name = "treeW_Provider";
            treeNode3.Name = "Node0";
            treeNode3.NodeFont = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            treeNode3.Text = "Trajets";
            this.treeW_Provider.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeW_Provider.Size = new System.Drawing.Size(385, 407);
            this.treeW_Provider.TabIndex = 21;
            this.treeW_Provider.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeW_Provider_MouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AllowDrop = true;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(151, 509);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 23);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Rafaichir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UC_MatriceFormations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblFormationMAtrice);
            this.Controls.Add(this.lblDetailsMatrice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelDetailsMatrice);
            this.Controls.Add(this.btnSaveRoutes);
            this.Controls.Add(this.lblAddMatriceFormation);
            this.Controls.Add(this.picAddMatrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeW_Provider);
            this.Name = "UC_MatriceFormations";
            this.Size = new System.Drawing.Size(1070, 571);
            ((System.ComponentModel.ISupportInitialize)(this.equipeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PanelDetailsMatrice.ResumeLayout(false);
            this.PanelDetailsMatrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMatrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private SynapseAdvancedControls.HeaderFormatStyle headerFormatStyle1;
        private SynapseAdvancedControls.HeaderFormatStyle headerFormatStyle2;
        private System.Windows.Forms.BindingSource equipeBindingSource;
        private System.Windows.Forms.ToolTip toolTipExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblFormationMAtrice;
        private System.Windows.Forms.Label lblDetailsMatrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelDetailsMatrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblrecurrenceSemaine;
        private System.Windows.Forms.Label lblReccurencyMatrice;
        private System.Windows.Forms.ComboBox cbRecurrency;
        private System.Windows.Forms.Button btnSaveRoutes;
        private System.Windows.Forms.Label lblAddMatriceFormation;
        private System.Windows.Forms.PictureBox picAddMatrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeW_Provider;
        private System.Windows.Forms.Button btnRefresh;
    }
}
