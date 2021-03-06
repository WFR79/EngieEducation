﻿namespace Module_Education
{
    partial class UC_Agent
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
            this.tabControlAgentList = new System.Windows.Forms.TabControl();
            this.tbListeAgents = new System.Windows.Forms.TabPage();
            this.btnSaveProgressRoute = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblNbrRowsAgent = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.tbNbrRows = new System.Windows.Forms.TextBox();
            this.lblNbrRows = new System.Windows.Forms.Label();
            this.picExportExcel = new System.Windows.Forms.PictureBox();
            this.dG_Agents = new Zuby.ADGV.AdvancedDataGridView();
            this.btn_NextAgent = new System.Windows.Forms.Button();
            this.btn_PreviousAgent = new System.Windows.Forms.Button();
            this.lblTiteLstAgent = new System.Windows.Forms.Label();
            this.tbFicheAgent = new System.Windows.Forms.TabPage();
            this.labelInRoute = new System.Windows.Forms.Label();
            this.comboTrajet = new System.Windows.Forms.ComboBox();
            this.cbTrajet = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblRoleEPI = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.lblSeniority = new System.Windows.Forms.Label();
            this.lblentrylastFunction = new System.Windows.Forms.Label();
            this.lblDateEntry = new System.Windows.Forms.Label();
            this.labelDurationInDays = new System.Windows.Forms.Label();
            this.cbCheck_PrimeRescuer = new System.Windows.Forms.CheckBox();
            this.tabControl_Education_FormationAndCertificationsOfUser = new System.Windows.Forms.TabControl();
            this.tabPageEducation_FormationsAgent = new System.Windows.Forms.TabPage();
            this.dg_TABFormationsOfAgent = new System.Windows.Forms.DataGridView();
            this.labelNameOfUser = new System.Windows.Forms.TextBox();
            this.textBoxAdmin = new System.Windows.Forms.TextBox();
            this.comboBoxStatut1 = new System.Windows.Forms.ComboBox();
            this.comboBoxFunction = new System.Windows.Forms.ComboBox();
            this.comboBoxRespHierarchique = new System.Windows.Forms.ComboBox();
            this.comboBoxEducation_Habilitation = new System.Windows.Forms.ComboBox();
            this.comboBoxEquipe = new System.Windows.Forms.ComboBox();
            this.comboBoxAstreinte = new System.Windows.Forms.ComboBox();
            this.comboBoxEPI = new System.Windows.Forms.ComboBox();
            this.checkBoxSecouriste = new System.Windows.Forms.CheckBox();
            this.checkBox_IsWorkManager = new System.Windows.Forms.CheckBox();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.richTextBoxRemarks = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerSeniority = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLastFunction = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DateOfEntry = new System.Windows.Forms.DateTimePicker();
            this.labelActif = new System.Windows.Forms.Label();
            this.labelMatricule = new System.Windows.Forms.Label();
            this.pictureBox_ProfilePic = new System.Windows.Forms.PictureBox();
            this.toolTipExcel = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxExtensions1 = new Module_Education.Classes.TextBoxExtensions();
            this.comboBoxStatut11 = new Module_Education.Classes.Extensions.ComboBoxExt();
            this.tabControlAgentList.SuspendLayout();
            this.tbListeAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Agents)).BeginInit();
            this.tbFicheAgent.SuspendLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.SuspendLayout();
            this.tabPageEducation_FormationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAgentList
            // 
            this.tabControlAgentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAgentList.Controls.Add(this.tbListeAgents);
            this.tabControlAgentList.Controls.Add(this.tbFicheAgent);
            this.tabControlAgentList.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabControlAgentList.Location = new System.Drawing.Point(0, 3);
            this.tabControlAgentList.Name = "tabControlAgentList";
            this.tabControlAgentList.SelectedIndex = 0;
            this.tabControlAgentList.Size = new System.Drawing.Size(1199, 644);
            this.tabControlAgentList.TabIndex = 0;
            // 
            // tbListeAgents
            // 
            this.tbListeAgents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbListeAgents.Controls.Add(this.btnSaveProgressRoute);
            this.tbListeAgents.Controls.Add(this.btnRefresh);
            this.tbListeAgents.Controls.Add(this.label4);
            this.tbListeAgents.Controls.Add(this.lblMax);
            this.tbListeAgents.Controls.Add(this.lblMin);
            this.tbListeAgents.Controls.Add(this.lblNbrRowsAgent);
            this.tbListeAgents.Controls.Add(this.btnClearFilters);
            this.tbListeAgents.Controls.Add(this.tbNbrRows);
            this.tbListeAgents.Controls.Add(this.lblNbrRows);
            this.tbListeAgents.Controls.Add(this.picExportExcel);
            this.tbListeAgents.Controls.Add(this.dG_Agents);
            this.tbListeAgents.Controls.Add(this.btn_NextAgent);
            this.tbListeAgents.Controls.Add(this.btn_PreviousAgent);
            this.tbListeAgents.Controls.Add(this.lblTiteLstAgent);
            this.tbListeAgents.Location = new System.Drawing.Point(4, 23);
            this.tbListeAgents.Name = "tbListeAgents";
            this.tbListeAgents.Padding = new System.Windows.Forms.Padding(3);
            this.tbListeAgents.Size = new System.Drawing.Size(1191, 617);
            this.tbListeAgents.TabIndex = 0;
            this.tbListeAgents.Text = "Liste";
            // 
            // btnSaveProgressRoute
            // 
            this.btnSaveProgressRoute.AllowDrop = true;
            this.btnSaveProgressRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnSaveProgressRoute.FlatAppearance.BorderSize = 0;
            this.btnSaveProgressRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProgressRoute.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSaveProgressRoute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveProgressRoute.Location = new System.Drawing.Point(864, 9);
            this.btnSaveProgressRoute.Name = "btnSaveProgressRoute";
            this.btnSaveProgressRoute.Size = new System.Drawing.Size(135, 27);
            this.btnSaveProgressRoute.TabIndex = 96;
            this.btnSaveProgressRoute.Text = "Afficher Tout";
            this.btnSaveProgressRoute.UseVisualStyleBackColor = false;
            this.btnSaveProgressRoute.Click += new System.EventHandler(this.btnSaveProgressRoute_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnRefresh.Location = new System.Drawing.Point(962, 576);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.Text = "Rafaichir";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "-";
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMax.AutoSize = true;
            this.lblMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMax.Location = new System.Drawing.Point(557, 580);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(35, 14);
            this.lblMax.TabIndex = 25;
            this.lblMax.Text = "label3";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMin.AutoSize = true;
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblMin.Location = new System.Drawing.Point(512, 580);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(35, 14);
            this.lblMin.TabIndex = 24;
            this.lblMin.Text = "label2";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbrRowsAgent
            // 
            this.lblNbrRowsAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNbrRowsAgent.AutoSize = true;
            this.lblNbrRowsAgent.Enabled = false;
            this.lblNbrRowsAgent.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRowsAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRowsAgent.Location = new System.Drawing.Point(10, 577);
            this.lblNbrRowsAgent.Name = "lblNbrRowsAgent";
            this.lblNbrRowsAgent.Size = new System.Drawing.Size(42, 16);
            this.lblNbrRowsAgent.TabIndex = 23;
            this.lblNbrRowsAgent.Text = "label1";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Enabled = false;
            this.btnClearFilters.Location = new System.Drawing.Point(210, 15);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(110, 23);
            this.btnClearFilters.TabIndex = 22;
            this.btnClearFilters.Text = "Effacer filtres";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // tbNbrRows
            // 
            this.tbNbrRows.Location = new System.Drawing.Point(822, 13);
            this.tbNbrRows.Name = "tbNbrRows";
            this.tbNbrRows.Size = new System.Drawing.Size(36, 20);
            this.tbNbrRows.TabIndex = 21;
            this.tbNbrRows.Text = "50";
            this.tbNbrRows.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbNbrRows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNbrRows_KeyDown);
            this.tbNbrRows.ImeModeChanged += new System.EventHandler(this.tbNbrRows_ImeModeChanged);
            // 
            // lblNbrRows
            // 
            this.lblNbrRows.AutoSize = true;
            this.lblNbrRows.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRows.Location = new System.Drawing.Point(653, 15);
            this.lblNbrRows.Name = "lblNbrRows";
            this.lblNbrRows.Size = new System.Drawing.Size(169, 16);
            this.lblNbrRows.TabIndex = 20;
            this.lblNbrRows.Text = "Nombre de lignes à afficher:";
            // 
            // picExportExcel
            // 
            this.picExportExcel.Image = global::Module_Education.Properties.Resources.Excel_icon;
            this.picExportExcel.Location = new System.Drawing.Point(1005, 9);
            this.picExportExcel.Name = "picExportExcel";
            this.picExportExcel.Size = new System.Drawing.Size(32, 32);
            this.picExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExportExcel.TabIndex = 19;
            this.picExportExcel.TabStop = false;
            this.toolTipExcel.SetToolTip(this.picExportExcel, "Exportez le tableau vers un fichier Excel");
            this.picExportExcel.Click += new System.EventHandler(this.picExportExcel_Click);
            // 
            // dG_Agents
            // 
            this.dG_Agents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dG_Agents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dG_Agents.BackgroundColor = System.Drawing.Color.White;
            this.dG_Agents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_Agents.FilterAndSortEnabled = true;
            this.dG_Agents.Location = new System.Drawing.Point(14, 47);
            this.dG_Agents.Name = "dG_Agents";
            this.dG_Agents.ReadOnly = true;
            this.dG_Agents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_Agents.Size = new System.Drawing.Size(1106, 495);
            this.dG_Agents.TabIndex = 18;
            this.dG_Agents.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dG_Agents_FilterStringChanged_1);
            this.dG_Agents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dG_Agents_CellFormatting);
            this.dG_Agents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dG_Agents_MouseClick);
            // 
            // btn_NextAgent
            // 
            this.btn_NextAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_NextAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_NextAgent.Location = new System.Drawing.Point(593, 576);
            this.btn_NextAgent.Name = "btn_NextAgent";
            this.btn_NextAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_NextAgent.TabIndex = 16;
            this.btn_NextAgent.Text = "Suivant";
            this.btn_NextAgent.UseVisualStyleBackColor = true;
            this.btn_NextAgent.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_PreviousAgent
            // 
            this.btn_PreviousAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PreviousAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_PreviousAgent.Location = new System.Drawing.Point(433, 576);
            this.btn_PreviousAgent.Name = "btn_PreviousAgent";
            this.btn_PreviousAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_PreviousAgent.TabIndex = 15;
            this.btn_PreviousAgent.Text = "Précédent";
            this.btn_PreviousAgent.UseVisualStyleBackColor = true;
            this.btn_PreviousAgent.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // lblTiteLstAgent
            // 
            this.lblTiteLstAgent.AutoSize = true;
            this.lblTiteLstAgent.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiteLstAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblTiteLstAgent.Location = new System.Drawing.Point(9, 11);
            this.lblTiteLstAgent.Name = "lblTiteLstAgent";
            this.lblTiteLstAgent.Size = new System.Drawing.Size(177, 24);
            this.lblTiteLstAgent.TabIndex = 8;
            this.lblTiteLstAgent.Text = "Liste des agents";
            // 
            // tbFicheAgent
            // 
            this.tbFicheAgent.AutoScroll = true;
            this.tbFicheAgent.BackColor = System.Drawing.Color.White;
            this.tbFicheAgent.Controls.Add(this.textBoxExtensions1);
            this.tbFicheAgent.Controls.Add(this.comboBoxStatut11);
            this.tbFicheAgent.Controls.Add(this.labelInRoute);
            this.tbFicheAgent.Controls.Add(this.comboTrajet);
            this.tbFicheAgent.Controls.Add(this.cbTrajet);
            this.tbFicheAgent.Controls.Add(this.label3);
            this.tbFicheAgent.Controls.Add(this.label2);
            this.tbFicheAgent.Controls.Add(this.label1);
            this.tbFicheAgent.Controls.Add(this.lblAdmin);
            this.tbFicheAgent.Controls.Add(this.lblRoleEPI);
            this.tbFicheAgent.Controls.Add(this.lblFunction);
            this.tbFicheAgent.Controls.Add(this.lblEquipe);
            this.tbFicheAgent.Controls.Add(this.lblSeniority);
            this.tbFicheAgent.Controls.Add(this.lblentrylastFunction);
            this.tbFicheAgent.Controls.Add(this.lblDateEntry);
            this.tbFicheAgent.Controls.Add(this.labelDurationInDays);
            this.tbFicheAgent.Controls.Add(this.cbCheck_PrimeRescuer);
            this.tbFicheAgent.Controls.Add(this.tabControl_Education_FormationAndCertificationsOfUser);
            this.tbFicheAgent.Controls.Add(this.labelNameOfUser);
            this.tbFicheAgent.Controls.Add(this.textBoxAdmin);
            this.tbFicheAgent.Controls.Add(this.comboBoxStatut1);
            this.tbFicheAgent.Controls.Add(this.comboBoxFunction);
            this.tbFicheAgent.Controls.Add(this.comboBoxRespHierarchique);
            this.tbFicheAgent.Controls.Add(this.comboBoxEducation_Habilitation);
            this.tbFicheAgent.Controls.Add(this.comboBoxEquipe);
            this.tbFicheAgent.Controls.Add(this.comboBoxAstreinte);
            this.tbFicheAgent.Controls.Add(this.comboBoxEPI);
            this.tbFicheAgent.Controls.Add(this.checkBoxSecouriste);
            this.tbFicheAgent.Controls.Add(this.checkBox_IsWorkManager);
            this.tbFicheAgent.Controls.Add(this.labelRemarks);
            this.tbFicheAgent.Controls.Add(this.richTextBoxRemarks);
            this.tbFicheAgent.Controls.Add(this.dateTimePickerSeniority);
            this.tbFicheAgent.Controls.Add(this.dateTimePickerLastFunction);
            this.tbFicheAgent.Controls.Add(this.dateTimePicker_DateOfEntry);
            this.tbFicheAgent.Controls.Add(this.labelActif);
            this.tbFicheAgent.Controls.Add(this.labelMatricule);
            this.tbFicheAgent.Controls.Add(this.pictureBox_ProfilePic);
            this.tbFicheAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbFicheAgent.Location = new System.Drawing.Point(4, 23);
            this.tbFicheAgent.Name = "tbFicheAgent";
            this.tbFicheAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tbFicheAgent.Size = new System.Drawing.Size(1191, 617);
            this.tbFicheAgent.TabIndex = 1;
            this.tbFicheAgent.Text = "Fiche";
            this.tbFicheAgent.Click += new System.EventHandler(this.tbFicheAgent_Click);
            // 
            // labelInRoute
            // 
            this.labelInRoute.AutoSize = true;
            this.labelInRoute.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInRoute.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelInRoute.Location = new System.Drawing.Point(10, 224);
            this.labelInRoute.Name = "labelInRoute";
            this.labelInRoute.Size = new System.Drawing.Size(72, 19);
            this.labelInRoute.TabIndex = 97;
            this.labelInRoute.Text = "En trajet";
            this.labelInRoute.Visible = false;
            // 
            // comboTrajet
            // 
            this.comboTrajet.BackColor = System.Drawing.SystemColors.Menu;
            this.comboTrajet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTrajet.FormattingEnabled = true;
            this.comboTrajet.Location = new System.Drawing.Point(368, 249);
            this.comboTrajet.Name = "comboTrajet";
            this.comboTrajet.Size = new System.Drawing.Size(185, 22);
            this.comboTrajet.TabIndex = 14;
            this.comboTrajet.Visible = false;
            this.comboTrajet.Leave += new System.EventHandler(this.comboTrajet_Leave);
            // 
            // cbTrajet
            // 
            this.cbTrajet.AutoSize = true;
            this.cbTrajet.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbTrajet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbTrajet.Location = new System.Drawing.Point(370, 226);
            this.cbTrajet.Name = "cbTrajet";
            this.cbTrajet.Size = new System.Drawing.Size(79, 20);
            this.cbTrajet.TabIndex = 14;
            this.cbTrajet.Text = "En Trajet";
            this.cbTrajet.UseVisualStyleBackColor = true;
            this.cbTrajet.CheckedChanged += new System.EventHandler(this.cbTrajet_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(365, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 94;
            this.label3.Text = "Role d\'astreinte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(365, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 93;
            this.label2.Text = "Habilitation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(365, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "Responsable Hiérarchique";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblAdmin.Location = new System.Drawing.Point(367, 181);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(45, 16);
            this.lblAdmin.TabIndex = 91;
            this.lblAdmin.Text = "Admin";
            // 
            // lblRoleEPI
            // 
            this.lblRoleEPI.AutoSize = true;
            this.lblRoleEPI.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblRoleEPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRoleEPI.Location = new System.Drawing.Point(147, 181);
            this.lblRoleEPI.Name = "lblRoleEPI";
            this.lblRoleEPI.Size = new System.Drawing.Size(59, 16);
            this.lblRoleEPI.TabIndex = 90;
            this.lblRoleEPI.Text = "Rôle EPI";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFunction.Location = new System.Drawing.Point(147, 138);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(58, 16);
            this.lblFunction.TabIndex = 89;
            this.lblFunction.Text = "Fonction";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblEquipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblEquipe.Location = new System.Drawing.Point(147, 95);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(113, 16);
            this.lblEquipe.TabIndex = 88;
            this.lblEquipe.Text = "Equipe/Affectation";
            // 
            // lblSeniority
            // 
            this.lblSeniority.AutoSize = true;
            this.lblSeniority.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblSeniority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSeniority.Location = new System.Drawing.Point(147, 316);
            this.lblSeniority.Name = "lblSeniority";
            this.lblSeniority.Size = new System.Drawing.Size(106, 16);
            this.lblSeniority.TabIndex = 87;
            this.lblSeniority.Text = "Date de séniorité";
            // 
            // lblentrylastFunction
            // 
            this.lblentrylastFunction.AutoSize = true;
            this.lblentrylastFunction.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblentrylastFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblentrylastFunction.Location = new System.Drawing.Point(144, 271);
            this.lblentrylastFunction.Name = "lblentrylastFunction";
            this.lblentrylastFunction.Size = new System.Drawing.Size(184, 16);
            this.lblentrylastFunction.TabIndex = 86;
            this.lblentrylastFunction.Text = "Date dernière prise de fonction";
            // 
            // lblDateEntry
            // 
            this.lblDateEntry.AutoSize = true;
            this.lblDateEntry.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblDateEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDateEntry.Location = new System.Drawing.Point(144, 224);
            this.lblDateEntry.Name = "lblDateEntry";
            this.lblDateEntry.Size = new System.Drawing.Size(77, 16);
            this.lblDateEntry.TabIndex = 85;
            this.lblDateEntry.Text = "Date Entrée";
            // 
            // labelDurationInDays
            // 
            this.labelDurationInDays.AutoSize = true;
            this.labelDurationInDays.Font = new System.Drawing.Font("Arial", 9.25F);
            this.labelDurationInDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelDurationInDays.Location = new System.Drawing.Point(147, 49);
            this.labelDurationInDays.Name = "labelDurationInDays";
            this.labelDurationInDays.Size = new System.Drawing.Size(43, 16);
            this.labelDurationInDays.TabIndex = 84;
            this.labelDurationInDays.Text = "Statut";
            // 
            // cbCheck_PrimeRescuer
            // 
            this.cbCheck_PrimeRescuer.AutoSize = true;
            this.cbCheck_PrimeRescuer.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbCheck_PrimeRescuer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbCheck_PrimeRescuer.Location = new System.Drawing.Point(368, 336);
            this.cbCheck_PrimeRescuer.Name = "cbCheck_PrimeRescuer";
            this.cbCheck_PrimeRescuer.Size = new System.Drawing.Size(127, 20);
            this.cbCheck_PrimeRescuer.TabIndex = 17;
            this.cbCheck_PrimeRescuer.Text = "Prime Secouriste";
            this.cbCheck_PrimeRescuer.UseVisualStyleBackColor = true;
            this.cbCheck_PrimeRescuer.CheckedChanged += new System.EventHandler(this.cbCheck_PrimeRescuer_CheckedChanged);
            // 
            // tabControl_Education_FormationAndCertificationsOfUser
            // 
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageEducation_FormationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl_Education_FormationAndCertificationsOfUser.Location = new System.Drawing.Point(146, 384);
            this.tabControl_Education_FormationAndCertificationsOfUser.Name = "tabControl_Education_FormationAndCertificationsOfUser";
            this.tabControl_Education_FormationAndCertificationsOfUser.SelectedIndex = 0;
            this.tabControl_Education_FormationAndCertificationsOfUser.Size = new System.Drawing.Size(1015, 227);
            this.tabControl_Education_FormationAndCertificationsOfUser.TabIndex = 35;
            // 
            // tabPageEducation_FormationsAgent
            // 
            this.tabPageEducation_FormationsAgent.BackColor = System.Drawing.Color.White;
            this.tabPageEducation_FormationsAgent.Controls.Add(this.dg_TABFormationsOfAgent);
            this.tabPageEducation_FormationsAgent.Font = new System.Drawing.Font("Arial", 10F);
            this.tabPageEducation_FormationsAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.tabPageEducation_FormationsAgent.Location = new System.Drawing.Point(4, 25);
            this.tabPageEducation_FormationsAgent.Name = "tabPageEducation_FormationsAgent";
            this.tabPageEducation_FormationsAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEducation_FormationsAgent.Size = new System.Drawing.Size(1007, 198);
            this.tabPageEducation_FormationsAgent.TabIndex = 0;
            this.tabPageEducation_FormationsAgent.Text = "Formations";
            // 
            // dg_TABFormationsOfAgent
            // 
            this.dg_TABFormationsOfAgent.AllowUserToAddRows = false;
            this.dg_TABFormationsOfAgent.AllowUserToDeleteRows = false;
            this.dg_TABFormationsOfAgent.AllowUserToResizeColumns = false;
            this.dg_TABFormationsOfAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dg_TABFormationsOfAgent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_TABFormationsOfAgent.BackgroundColor = System.Drawing.Color.White;
            this.dg_TABFormationsOfAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_TABFormationsOfAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_TABFormationsOfAgent.Location = new System.Drawing.Point(6, 10);
            this.dg_TABFormationsOfAgent.Name = "dg_TABFormationsOfAgent";
            this.dg_TABFormationsOfAgent.ReadOnly = true;
            this.dg_TABFormationsOfAgent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_TABFormationsOfAgent.Size = new System.Drawing.Size(995, 182);
            this.dg_TABFormationsOfAgent.TabIndex = 18;
            this.dg_TABFormationsOfAgent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_TABFormationsOfAgent_MouseClick);
            // 
            // labelNameOfUser
            // 
            this.labelNameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelNameOfUser.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelNameOfUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelNameOfUser.Location = new System.Drawing.Point(146, 21);
            this.labelNameOfUser.Name = "labelNameOfUser";
            this.labelNameOfUser.Size = new System.Drawing.Size(261, 25);
            this.labelNameOfUser.TabIndex = 1;
            this.labelNameOfUser.Text = "Firstname LASTNAME";
            // 
            // textBoxAdmin
            // 
            this.textBoxAdmin.Location = new System.Drawing.Point(370, 199);
            this.textBoxAdmin.Name = "textBoxAdmin";
            this.textBoxAdmin.Size = new System.Drawing.Size(185, 20);
            this.textBoxAdmin.TabIndex = 13;
            this.textBoxAdmin.Text = "Admin";
            this.textBoxAdmin.Enter += new System.EventHandler(this.textBoxAdmin_Enter);
            this.textBoxAdmin.Leave += new System.EventHandler(this.textBoxAdmin_Leave);
            // 
            // comboBoxStatut1
            // 
            this.comboBoxStatut1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxStatut1.FormattingEnabled = true;
            this.comboBoxStatut1.Location = new System.Drawing.Point(582, 333);
            this.comboBoxStatut1.Name = "comboBoxStatut1";
            this.comboBoxStatut1.Size = new System.Drawing.Size(186, 22);
            this.comboBoxStatut1.TabIndex = 2;
            this.comboBoxStatut1.Visible = false;
            this.comboBoxStatut1.Enter += new System.EventHandler(this.comboBoxStatut_Enter);
            this.comboBoxStatut1.Leave += new System.EventHandler(this.comboBoxStatut_Leave);
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxFunction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFunction.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Location = new System.Drawing.Point(147, 157);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(185, 22);
            this.comboBoxFunction.TabIndex = 4;
            this.comboBoxFunction.Text = "Function";
            this.comboBoxFunction.Leave += new System.EventHandler(this.comboBoxFunction_Leave);
            // 
            // comboBoxRespHierarchique
            // 
            this.comboBoxRespHierarchique.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxRespHierarchique.FormattingEnabled = true;
            this.comboBoxRespHierarchique.Location = new System.Drawing.Point(368, 70);
            this.comboBoxRespHierarchique.Name = "comboBoxRespHierarchique";
            this.comboBoxRespHierarchique.Size = new System.Drawing.Size(185, 22);
            this.comboBoxRespHierarchique.TabIndex = 10;
            this.comboBoxRespHierarchique.Text = "Responsable Hiérarchique";
            this.comboBoxRespHierarchique.Leave += new System.EventHandler(this.comboBoxRespHierarchique_Leave);
            // 
            // comboBoxEducation_Habilitation
            // 
            this.comboBoxEducation_Habilitation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEducation_Habilitation.FormattingEnabled = true;
            this.comboBoxEducation_Habilitation.Location = new System.Drawing.Point(368, 112);
            this.comboBoxEducation_Habilitation.Name = "comboBoxEducation_Habilitation";
            this.comboBoxEducation_Habilitation.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEducation_Habilitation.TabIndex = 11;
            this.comboBoxEducation_Habilitation.Text = "Education_Habilitation";
            this.comboBoxEducation_Habilitation.Leave += new System.EventHandler(this.comboBoxEducation_Habilitation_Leave);
            // 
            // comboBoxEquipe
            // 
            this.comboBoxEquipe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEquipe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEquipe.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEquipe.FormattingEnabled = true;
            this.comboBoxEquipe.Location = new System.Drawing.Point(147, 115);
            this.comboBoxEquipe.Name = "comboBoxEquipe";
            this.comboBoxEquipe.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEquipe.TabIndex = 3;
            this.comboBoxEquipe.Text = "Equipe/Affectation";
            // 
            // comboBoxAstreinte
            // 
            this.comboBoxAstreinte.FormattingEnabled = true;
            this.comboBoxAstreinte.Location = new System.Drawing.Point(368, 153);
            this.comboBoxAstreinte.Name = "comboBoxAstreinte";
            this.comboBoxAstreinte.Size = new System.Drawing.Size(185, 22);
            this.comboBoxAstreinte.TabIndex = 12;
            this.comboBoxAstreinte.Text = "Role d\'astreinte";
            this.comboBoxAstreinte.Leave += new System.EventHandler(this.comboBoxAstreinte_Leave);
            // 
            // comboBoxEPI
            // 
            this.comboBoxEPI.FormattingEnabled = true;
            this.comboBoxEPI.Location = new System.Drawing.Point(147, 198);
            this.comboBoxEPI.Name = "comboBoxEPI";
            this.comboBoxEPI.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEPI.TabIndex = 5;
            this.comboBoxEPI.Text = "Rôle EPI";
            this.comboBoxEPI.Leave += new System.EventHandler(this.comboBoxEPI_Leave);
            // 
            // checkBoxSecouriste
            // 
            this.checkBoxSecouriste.AutoSize = true;
            this.checkBoxSecouriste.Font = new System.Drawing.Font("Arial", 9.25F);
            this.checkBoxSecouriste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.checkBoxSecouriste.Location = new System.Drawing.Point(368, 312);
            this.checkBoxSecouriste.Name = "checkBoxSecouriste";
            this.checkBoxSecouriste.Size = new System.Drawing.Size(117, 20);
            this.checkBoxSecouriste.TabIndex = 16;
            this.checkBoxSecouriste.Text = "Rôle secouriste";
            this.checkBoxSecouriste.UseVisualStyleBackColor = true;
            this.checkBoxSecouriste.CheckedChanged += new System.EventHandler(this.checkBoxSecouriste_CheckedChanged);
            this.checkBoxSecouriste.Leave += new System.EventHandler(this.checkBoxSecouriste_Leave);
            // 
            // checkBox_IsWorkManager
            // 
            this.checkBox_IsWorkManager.AutoSize = true;
            this.checkBox_IsWorkManager.Font = new System.Drawing.Font("Arial", 9.25F);
            this.checkBox_IsWorkManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.checkBox_IsWorkManager.Location = new System.Drawing.Point(368, 288);
            this.checkBox_IsWorkManager.Name = "checkBox_IsWorkManager";
            this.checkBox_IsWorkManager.Size = new System.Drawing.Size(131, 20);
            this.checkBox_IsWorkManager.TabIndex = 15;
            this.checkBox_IsWorkManager.Text = "Chargé de travaux";
            this.checkBox_IsWorkManager.UseVisualStyleBackColor = true;
            this.checkBox_IsWorkManager.CheckedChanged += new System.EventHandler(this.checkBox_IsWorkManager_CheckedChanged);
            this.checkBox_IsWorkManager.CheckStateChanged += new System.EventHandler(this.checkBox_IsWorkManager_CheckStateChanged);
            this.checkBox_IsWorkManager.Leave += new System.EventHandler(this.checkBox_IsWorkManager_Leave);
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Arial", 9.25F);
            this.labelRemarks.Location = new System.Drawing.Point(579, 50);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(74, 16);
            this.labelRemarks.TabIndex = 16;
            this.labelRemarks.Text = "Remarques";
            // 
            // richTextBoxRemarks
            // 
            this.richTextBoxRemarks.AutoWordSelection = true;
            this.richTextBoxRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.richTextBoxRemarks.Font = new System.Drawing.Font("Arial", 8.25F);
            this.richTextBoxRemarks.Location = new System.Drawing.Point(582, 69);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(338, 51);
            this.richTextBoxRemarks.TabIndex = 18;
            this.richTextBoxRemarks.Text = "";
            this.richTextBoxRemarks.TextChanged += new System.EventHandler(this.richTextBoxRemarks_TextChanged);
            this.richTextBoxRemarks.Leave += new System.EventHandler(this.richTextBoxRemarks_Leave);
            // 
            // dateTimePickerSeniority
            // 
            this.dateTimePickerSeniority.Location = new System.Drawing.Point(147, 333);
            this.dateTimePickerSeniority.Name = "dateTimePickerSeniority";
            this.dateTimePickerSeniority.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSeniority.TabIndex = 9;
            // 
            // dateTimePickerLastFunction
            // 
            this.dateTimePickerLastFunction.Location = new System.Drawing.Point(147, 288);
            this.dateTimePickerLastFunction.Name = "dateTimePickerLastFunction";
            this.dateTimePickerLastFunction.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLastFunction.TabIndex = 8;
            // 
            // dateTimePicker_DateOfEntry
            // 
            this.dateTimePicker_DateOfEntry.Location = new System.Drawing.Point(147, 240);
            this.dateTimePicker_DateOfEntry.Name = "dateTimePicker_DateOfEntry";
            this.dateTimePicker_DateOfEntry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DateOfEntry.TabIndex = 6;
            // 
            // labelActif
            // 
            this.labelActif.AutoSize = true;
            this.labelActif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActif.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelActif.Location = new System.Drawing.Point(10, 190);
            this.labelActif.Name = "labelActif";
            this.labelActif.Size = new System.Drawing.Size(113, 19);
            this.labelActif.TabIndex = 5;
            this.labelActif.Text = "Actif/NonActif";
            // 
            // labelMatricule
            // 
            this.labelMatricule.AutoSize = true;
            this.labelMatricule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricule.Location = new System.Drawing.Point(8, 154);
            this.labelMatricule.Name = "labelMatricule";
            this.labelMatricule.Size = new System.Drawing.Size(71, 18);
            this.labelMatricule.TabIndex = 3;
            this.labelMatricule.Text = "Matricule";
            // 
            // pictureBox_ProfilePic
            // 
            this.pictureBox_ProfilePic.Image = global::Module_Education.Properties.Resources.baseline_person_black_36dp;
            this.pictureBox_ProfilePic.Location = new System.Drawing.Point(11, 24);
            this.pictureBox_ProfilePic.Name = "pictureBox_ProfilePic";
            this.pictureBox_ProfilePic.Size = new System.Drawing.Size(112, 112);
            this.pictureBox_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_ProfilePic.TabIndex = 0;
            this.pictureBox_ProfilePic.TabStop = false;
            // 
            // toolTipExcel
            // 
            this.toolTipExcel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipExcel.ToolTipTitle = "Exporter le tableau vers excel";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxExtensions1
            // 
            this.textBoxExtensions1.Location = new System.Drawing.Point(664, 157);
            this.textBoxExtensions1.Name = "textBoxExtensions1";
            this.textBoxExtensions1.Size = new System.Drawing.Size(221, 20);
            this.textBoxExtensions1.TabIndex = 130;
            this.textBoxExtensions1.Visible = false;
            this.textBoxExtensions1.TextChanged += new System.EventHandler(this.textBoxExtensions1_TextChanged);
            this.textBoxExtensions1.Leave += new System.EventHandler(this.textBoxExtensions1_Leave);
            // 
            // comboBoxStatut11
            // 
            this.comboBoxStatut11.FormattingEnabled = true;
            this.comboBoxStatut11.Location = new System.Drawing.Point(148, 68);
            this.comboBoxStatut11.Name = "comboBoxStatut11";
            this.comboBoxStatut11.Size = new System.Drawing.Size(186, 22);
            this.comboBoxStatut11.TabIndex = 129;
            this.comboBoxStatut11.Leave += new System.EventHandler(this.comboBoxStatut_Leave);
            // 
            // UC_Agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlAgentList);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(0, 573);
            this.Name = "UC_Agent";
            this.Size = new System.Drawing.Size(1202, 650);
            this.Enter += new System.EventHandler(this.UC_Agent_Enter);
            this.tabControlAgentList.ResumeLayout(false);
            this.tbListeAgents.ResumeLayout(false);
            this.tbListeAgents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Agents)).EndInit();
            this.tbFicheAgent.ResumeLayout(false);
            this.tbFicheAgent.PerformLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.ResumeLayout(false);
            this.tabPageEducation_FormationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAgentList;
        private System.Windows.Forms.TabPage tbListeAgents;
        private System.Windows.Forms.Label lblTiteLstAgent;
        private System.Windows.Forms.TabPage tbFicheAgent;
        private System.Windows.Forms.Label labelMatricule;
        private System.Windows.Forms.PictureBox pictureBox_ProfilePic;
        private System.Windows.Forms.Label labelActif;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateOfEntry;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeniority;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastFunction;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.RichTextBox richTextBoxRemarks;
        private System.Windows.Forms.CheckBox checkBox_IsWorkManager;
        private System.Windows.Forms.CheckBox checkBoxSecouriste;
        private System.Windows.Forms.ComboBox comboBoxAstreinte;
        private System.Windows.Forms.ComboBox comboBoxEPI;
        private System.Windows.Forms.ComboBox comboBoxEquipe;
        private System.Windows.Forms.ComboBox comboBoxEducation_Habilitation;
        private System.Windows.Forms.ComboBox comboBoxRespHierarchique;
        private System.Windows.Forms.ComboBox comboBoxFunction;
        private System.Windows.Forms.ComboBox comboBoxStatut1;
        private System.Windows.Forms.TextBox textBoxAdmin;
        private System.Windows.Forms.TextBox labelNameOfUser;
        private System.Windows.Forms.TabControl tabControl_Education_FormationAndCertificationsOfUser;
        private System.Windows.Forms.TabPage tabPageEducation_FormationsAgent;
        private System.Windows.Forms.Button btn_NextAgent;
        private System.Windows.Forms.Button btn_PreviousAgent;
        private System.Windows.Forms.CheckBox cbCheck_PrimeRescuer;
        private System.Windows.Forms.DataGridView dg_TABFormationsOfAgent;
        private System.Windows.Forms.Label lblSeniority;
        private System.Windows.Forms.Label lblentrylastFunction;
        private System.Windows.Forms.Label lblDateEntry;
        private System.Windows.Forms.Label labelDurationInDays;
        private System.Windows.Forms.Label lblRoleEPI;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Label lblEquipe;
        private Zuby.ADGV.AdvancedDataGridView dG_Agents;
        private System.Windows.Forms.PictureBox picExportExcel;
        private System.Windows.Forms.ToolTip toolTipExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbNbrRows;
        private System.Windows.Forms.Label lblNbrRows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblNbrRowsAgent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.ComboBox comboTrajet;
        private System.Windows.Forms.CheckBox cbTrajet;
        private System.Windows.Forms.Label labelInRoute;
        private System.Windows.Forms.Button btnRefresh;
        private Classes.Extensions.ComboBoxExt comboBoxStatut11;
        private Classes.TextBoxExtensions textBoxExtensions1;
        private System.Windows.Forms.Button btnSaveProgressRoute;
    }
}
