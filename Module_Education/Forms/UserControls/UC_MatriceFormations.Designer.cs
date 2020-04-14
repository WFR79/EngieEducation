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
            this.lblFormationMatrice = new System.Windows.Forms.Label();
            this.lblDetailsMatrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRecurrencyFormation = new System.Windows.Forms.ComboBox();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFormation = new System.Windows.Forms.Label();
            this.cbFilterFormation = new System.Windows.Forms.ComboBox();
            this.lblFilerMatrice = new System.Windows.Forms.Label();
            this.cbFilterMatrice = new System.Windows.Forms.ComboBox();
            this.tooltipFilterMatrice = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.equipeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.PanelDetailsMatrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMatrice)).BeginInit();
            this.panel2.SuspendLayout();
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
            // lblFormationMatrice
            // 
            this.lblFormationMatrice.AutoSize = true;
            this.lblFormationMatrice.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblFormationMatrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormationMatrice.Location = new System.Drawing.Point(446, 307);
            this.lblFormationMatrice.Name = "lblFormationMatrice";
            this.lblFormationMatrice.Size = new System.Drawing.Size(59, 16);
            this.lblFormationMatrice.TabIndex = 29;
            this.lblFormationMatrice.Text = "Détails ";
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbRecurrencyFormation);
            this.panel1.Location = new System.Drawing.Point(449, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 159);
            this.panel1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(96, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Semaine(s)";
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
            this.button2.Click += new System.EventHandler(this.SaveFormationRecurrency);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 88;
            this.label2.Text = "Récurrence";
            // 
            // cbRecurrencyFormation
            // 
            this.cbRecurrencyFormation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbRecurrencyFormation.FormattingEnabled = true;
            this.cbRecurrencyFormation.Location = new System.Drawing.Point(20, 34);
            this.cbRecurrencyFormation.Name = "cbRecurrencyFormation";
            this.cbRecurrencyFormation.Size = new System.Drawing.Size(72, 22);
            this.cbRecurrencyFormation.TabIndex = 87;
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
            this.button1.Click += new System.EventHandler(this.SaveRecurrencyMatrice);
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
            this.treeW_Provider.Location = new System.Drawing.Point(27, 143);
            this.treeW_Provider.Name = "treeW_Provider";
            treeNode3.Name = "Node0";
            treeNode3.NodeFont = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            treeNode3.Text = "Trajets";
            this.treeW_Provider.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeW_Provider.Size = new System.Drawing.Size(385, 352);
            this.treeW_Provider.TabIndex = 21;
            this.treeW_Provider.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeW_Provider_AfterSelect);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblFormation);
            this.panel2.Controls.Add(this.cbFilterFormation);
            this.panel2.Controls.Add(this.lblFilerMatrice);
            this.panel2.Controls.Add(this.cbFilterMatrice);
            this.panel2.Location = new System.Drawing.Point(27, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 48);
            this.panel2.TabIndex = 31;
            // 
            // lblFormation
            // 
            this.lblFormation.AutoSize = true;
            this.lblFormation.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblFormation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormation.Location = new System.Drawing.Point(193, 4);
            this.lblFormation.Name = "lblFormation";
            this.lblFormation.Size = new System.Drawing.Size(73, 16);
            this.lblFormation.TabIndex = 89;
            this.lblFormation.Text = "Formations";
            // 
            // cbFilterFormation
            // 
            this.cbFilterFormation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFilterFormation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFilterFormation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbFilterFormation.FormattingEnabled = true;
            this.cbFilterFormation.Location = new System.Drawing.Point(196, 23);
            this.cbFilterFormation.Name = "cbFilterFormation";
            this.cbFilterFormation.Size = new System.Drawing.Size(175, 22);
            this.cbFilterFormation.TabIndex = 88;
            this.tooltipFilterMatrice.SetToolTip(this.cbFilterFormation, "Tapez \'Entrer\' pour filtrer les trajets");
            this.cbFilterFormation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFilterFormation_KeyDown);
            // 
            // lblFilerMatrice
            // 
            this.lblFilerMatrice.AutoSize = true;
            this.lblFilerMatrice.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblFilerMatrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFilerMatrice.Location = new System.Drawing.Point(9, 4);
            this.lblFilerMatrice.Name = "lblFilerMatrice";
            this.lblFilerMatrice.Size = new System.Drawing.Size(58, 16);
            this.lblFilerMatrice.TabIndex = 87;
            this.lblFilerMatrice.Text = "Matrices";
            // 
            // cbFilterMatrice
            // 
            this.cbFilterMatrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFilterMatrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFilterMatrice.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbFilterMatrice.FormattingEnabled = true;
            this.cbFilterMatrice.Location = new System.Drawing.Point(8, 22);
            this.cbFilterMatrice.Name = "cbFilterMatrice";
            this.cbFilterMatrice.Size = new System.Drawing.Size(175, 22);
            this.cbFilterMatrice.TabIndex = 86;
            this.tooltipFilterMatrice.SetToolTip(this.cbFilterMatrice, "Tapez \'Entrer\' pour filtrer les trajets");
            this.cbFilterMatrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFilterMatrice_KeyDown);
            // 
            // UC_MatriceFormations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblFormationMatrice);
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
            this.panel1.PerformLayout();
            this.PanelDetailsMatrice.ResumeLayout(false);
            this.PanelDetailsMatrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMatrice)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label lblFormationMatrice;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFormation;
        private System.Windows.Forms.ComboBox cbFilterFormation;
        private System.Windows.Forms.Label lblFilerMatrice;
        private System.Windows.Forms.ComboBox cbFilterMatrice;
        private System.Windows.Forms.ToolTip tooltipFilterMatrice;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRecurrencyFormation;
    }
}
