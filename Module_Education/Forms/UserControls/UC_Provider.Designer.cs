namespace Module_Education
{
    partial class UC_Provider
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
            this.tabControlAgentList = new System.Windows.Forms.TabControl();
            this.tbListeAgents = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblNbrProviders = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.tbNbrRowsProviders = new System.Windows.Forms.TextBox();
            this.lblNbrRows = new System.Windows.Forms.Label();
            this.picExportExcel = new System.Windows.Forms.PictureBox();
            this.dG_Providers = new Zuby.ADGV.AdvancedDataGridView();
            this.progressBarDgAgent = new System.Windows.Forms.ProgressBar();
            this.btn_NextAgent = new System.Windows.Forms.Button();
            this.btn_PreviousAgent = new System.Windows.Forms.Button();
            this.lblTiteLstAgent = new System.Windows.Forms.Label();
            this.tbFiltre = new System.Windows.Forms.TextBox();
            this.tbFicheAgent = new System.Windows.Forms.TabPage();
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
            this.tabPageCertificationsAgent = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelNameOfUser = new System.Windows.Forms.TextBox();
            this.textBoxAdmin = new System.Windows.Forms.TextBox();
            this.comboBoxStatut = new System.Windows.Forms.ComboBox();
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
            this.tabControlAgentList.SuspendLayout();
            this.tbListeAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Providers)).BeginInit();
            this.tbFicheAgent.SuspendLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.SuspendLayout();
            this.tabPageEducation_FormationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).BeginInit();
            this.tabPageCertificationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.tabControlAgentList.Location = new System.Drawing.Point(0, 0);
            this.tabControlAgentList.Name = "tabControlAgentList";
            this.tabControlAgentList.SelectedIndex = 0;
            this.tabControlAgentList.Size = new System.Drawing.Size(1067, 555);
            this.tabControlAgentList.TabIndex = 1;
            // 
            // tbListeAgents
            // 
            this.tbListeAgents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbListeAgents.Controls.Add(this.label4);
            this.tbListeAgents.Controls.Add(this.lblMax);
            this.tbListeAgents.Controls.Add(this.lblMin);
            this.tbListeAgents.Controls.Add(this.lblNbrProviders);
            this.tbListeAgents.Controls.Add(this.btnClearFilters);
            this.tbListeAgents.Controls.Add(this.tbNbrRowsProviders);
            this.tbListeAgents.Controls.Add(this.lblNbrRows);
            this.tbListeAgents.Controls.Add(this.picExportExcel);
            this.tbListeAgents.Controls.Add(this.dG_Providers);
            this.tbListeAgents.Controls.Add(this.progressBarDgAgent);
            this.tbListeAgents.Controls.Add(this.btn_NextAgent);
            this.tbListeAgents.Controls.Add(this.btn_PreviousAgent);
            this.tbListeAgents.Controls.Add(this.lblTiteLstAgent);
            this.tbListeAgents.Controls.Add(this.tbFiltre);
            this.tbListeAgents.Location = new System.Drawing.Point(4, 23);
            this.tbListeAgents.Name = "tbListeAgents";
            this.tbListeAgents.Padding = new System.Windows.Forms.Padding(3);
            this.tbListeAgents.Size = new System.Drawing.Size(1059, 528);
            this.tbListeAgents.TabIndex = 0;
            this.tbListeAgents.Text = "Liste";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 483);
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
            this.lblMax.Location = new System.Drawing.Point(467, 483);
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
            this.lblMin.Location = new System.Drawing.Point(422, 483);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(35, 14);
            this.lblMin.TabIndex = 24;
            this.lblMin.Text = "label2";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbrProviders
            // 
            this.lblNbrProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNbrProviders.AutoSize = true;
            this.lblNbrProviders.Enabled = false;
            this.lblNbrProviders.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrProviders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrProviders.Location = new System.Drawing.Point(13, 473);
            this.lblNbrProviders.Name = "lblNbrProviders";
            this.lblNbrProviders.Size = new System.Drawing.Size(42, 16);
            this.lblNbrProviders.TabIndex = 23;
            this.lblNbrProviders.Text = "label1";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Enabled = false;
            this.btnClearFilters.Location = new System.Drawing.Point(251, 15);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(110, 23);
            this.btnClearFilters.TabIndex = 22;
            this.btnClearFilters.Text = "Effacer filtres";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // tbNbrRowsProviders
            // 
            this.tbNbrRowsProviders.Location = new System.Drawing.Point(904, 15);
            this.tbNbrRowsProviders.Name = "tbNbrRowsProviders";
            this.tbNbrRowsProviders.Size = new System.Drawing.Size(36, 20);
            this.tbNbrRowsProviders.TabIndex = 21;
            this.tbNbrRowsProviders.Text = "50";
            // 
            // lblNbrRows
            // 
            this.lblNbrRows.AutoSize = true;
            this.lblNbrRows.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblNbrRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.lblNbrRows.Location = new System.Drawing.Point(735, 17);
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
            // 
            // dG_Providers
            // 
            this.dG_Providers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dG_Providers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dG_Providers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_Providers.FilterAndSortEnabled = true;
            this.dG_Providers.Location = new System.Drawing.Point(13, 47);
            this.dG_Providers.Name = "dG_Providers";
            this.dG_Providers.ReadOnly = true;
            this.dG_Providers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dG_Providers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_Providers.Size = new System.Drawing.Size(1040, 419);
            this.dG_Providers.TabIndex = 18;
            // 
            // progressBarDgAgent
            // 
            this.progressBarDgAgent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarDgAgent.Location = new System.Drawing.Point(969, 483);
            this.progressBarDgAgent.Name = "progressBarDgAgent";
            this.progressBarDgAgent.Size = new System.Drawing.Size(55, 23);
            this.progressBarDgAgent.TabIndex = 17;
            this.progressBarDgAgent.Visible = false;
            // 
            // btn_NextAgent
            // 
            this.btn_NextAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_NextAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_NextAgent.Location = new System.Drawing.Point(505, 479);
            this.btn_NextAgent.Name = "btn_NextAgent";
            this.btn_NextAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_NextAgent.TabIndex = 16;
            this.btn_NextAgent.Text = "Suivant";
            this.btn_NextAgent.UseVisualStyleBackColor = true;
            // 
            // btn_PreviousAgent
            // 
            this.btn_PreviousAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PreviousAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_PreviousAgent.Location = new System.Drawing.Point(345, 479);
            this.btn_PreviousAgent.Name = "btn_PreviousAgent";
            this.btn_PreviousAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_PreviousAgent.TabIndex = 15;
            this.btn_PreviousAgent.Text = "Précédent";
            this.btn_PreviousAgent.UseVisualStyleBackColor = true;
            // 
            // lblTiteLstAgent
            // 
            this.lblTiteLstAgent.AutoSize = true;
            this.lblTiteLstAgent.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiteLstAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.lblTiteLstAgent.Location = new System.Drawing.Point(9, 11);
            this.lblTiteLstAgent.Name = "lblTiteLstAgent";
            this.lblTiteLstAgent.Size = new System.Drawing.Size(236, 24);
            this.lblTiteLstAgent.TabIndex = 8;
            this.lblTiteLstAgent.Text = "Liste des fournisseurs";
            // 
            // tbFiltre
            // 
            this.tbFiltre.Location = new System.Drawing.Point(386, 17);
            this.tbFiltre.Name = "tbFiltre";
            this.tbFiltre.Size = new System.Drawing.Size(261, 20);
            this.tbFiltre.TabIndex = 7;
            // 
            // tbFicheAgent
            // 
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
            this.tbFicheAgent.Controls.Add(this.comboBoxStatut);
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
            this.tbFicheAgent.Size = new System.Drawing.Size(1059, 528);
            this.tbFicheAgent.TabIndex = 1;
            this.tbFicheAgent.Text = "Fiche";
            this.tbFicheAgent.UseVisualStyleBackColor = true;
            // 
            // lblRoleEPI
            // 
            this.lblRoleEPI.AutoSize = true;
            this.lblRoleEPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRoleEPI.Location = new System.Drawing.Point(147, 161);
            this.lblRoleEPI.Name = "lblRoleEPI";
            this.lblRoleEPI.Size = new System.Drawing.Size(45, 14);
            this.lblRoleEPI.TabIndex = 90;
            this.lblRoleEPI.Text = "Rôle EPI";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFunction.Location = new System.Drawing.Point(147, 119);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(48, 14);
            this.lblFunction.TabIndex = 89;
            this.lblFunction.Text = "Fonction";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblEquipe.Location = new System.Drawing.Point(147, 80);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(98, 14);
            this.lblEquipe.TabIndex = 88;
            this.lblEquipe.Text = "Equipe/Affectatiion";
            // 
            // lblSeniority
            // 
            this.lblSeniority.AutoSize = true;
            this.lblSeniority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSeniority.Location = new System.Drawing.Point(147, 303);
            this.lblSeniority.Name = "lblSeniority";
            this.lblSeniority.Size = new System.Drawing.Size(88, 14);
            this.lblSeniority.TabIndex = 87;
            this.lblSeniority.Text = "Date de séniorité";
            // 
            // lblentrylastFunction
            // 
            this.lblentrylastFunction.AutoSize = true;
            this.lblentrylastFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblentrylastFunction.Location = new System.Drawing.Point(144, 258);
            this.lblentrylastFunction.Name = "lblentrylastFunction";
            this.lblentrylastFunction.Size = new System.Drawing.Size(156, 14);
            this.lblentrylastFunction.TabIndex = 86;
            this.lblentrylastFunction.Text = "Date dernière prise de fonction";
            // 
            // lblDateEntry
            // 
            this.lblDateEntry.AutoSize = true;
            this.lblDateEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDateEntry.Location = new System.Drawing.Point(144, 211);
            this.lblDateEntry.Name = "lblDateEntry";
            this.lblDateEntry.Size = new System.Drawing.Size(63, 14);
            this.lblDateEntry.TabIndex = 85;
            this.lblDateEntry.Text = "Date Entrée";
            // 
            // labelDurationInDays
            // 
            this.labelDurationInDays.AutoSize = true;
            this.labelDurationInDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelDurationInDays.Location = new System.Drawing.Point(147, 39);
            this.labelDurationInDays.Name = "labelDurationInDays";
            this.labelDurationInDays.Size = new System.Drawing.Size(35, 14);
            this.labelDurationInDays.TabIndex = 84;
            this.labelDurationInDays.Text = "Statut";
            // 
            // cbCheck_PrimeRescuer
            // 
            this.cbCheck_PrimeRescuer.AutoSize = true;
            this.cbCheck_PrimeRescuer.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbCheck_PrimeRescuer.Location = new System.Drawing.Point(370, 246);
            this.cbCheck_PrimeRescuer.Name = "cbCheck_PrimeRescuer";
            this.cbCheck_PrimeRescuer.Size = new System.Drawing.Size(107, 18);
            this.cbCheck_PrimeRescuer.TabIndex = 17;
            this.cbCheck_PrimeRescuer.Text = "Prime Secouriste";
            this.cbCheck_PrimeRescuer.UseVisualStyleBackColor = true;
            // 
            // tabControl_Education_FormationAndCertificationsOfUser
            // 
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageEducation_FormationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageCertificationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl_Education_FormationAndCertificationsOfUser.Location = new System.Drawing.Point(579, 47);
            this.tabControl_Education_FormationAndCertificationsOfUser.Name = "tabControl_Education_FormationAndCertificationsOfUser";
            this.tabControl_Education_FormationAndCertificationsOfUser.SelectedIndex = 0;
            this.tabControl_Education_FormationAndCertificationsOfUser.Size = new System.Drawing.Size(457, 248);
            this.tabControl_Education_FormationAndCertificationsOfUser.TabIndex = 35;
            // 
            // tabPageEducation_FormationsAgent
            // 
            this.tabPageEducation_FormationsAgent.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageEducation_FormationsAgent.Controls.Add(this.dg_TABFormationsOfAgent);
            this.tabPageEducation_FormationsAgent.Font = new System.Drawing.Font("Arial", 10F);
            this.tabPageEducation_FormationsAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.tabPageEducation_FormationsAgent.Location = new System.Drawing.Point(4, 28);
            this.tabPageEducation_FormationsAgent.Name = "tabPageEducation_FormationsAgent";
            this.tabPageEducation_FormationsAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEducation_FormationsAgent.Size = new System.Drawing.Size(449, 216);
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
            this.dg_TABFormationsOfAgent.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dg_TABFormationsOfAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_TABFormationsOfAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_TABFormationsOfAgent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.dg_TABFormationsOfAgent.Location = new System.Drawing.Point(6, 10);
            this.dg_TABFormationsOfAgent.Name = "dg_TABFormationsOfAgent";
            this.dg_TABFormationsOfAgent.ReadOnly = true;
            this.dg_TABFormationsOfAgent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_TABFormationsOfAgent.Size = new System.Drawing.Size(437, 197);
            this.dg_TABFormationsOfAgent.TabIndex = 18;
            // 
            // tabPageCertificationsAgent
            // 
            this.tabPageCertificationsAgent.BackColor = System.Drawing.Color.LightGray;
            this.tabPageCertificationsAgent.Controls.Add(this.dataGridView1);
            this.tabPageCertificationsAgent.Font = new System.Drawing.Font("Arial", 10F);
            this.tabPageCertificationsAgent.Location = new System.Drawing.Point(4, 28);
            this.tabPageCertificationsAgent.Name = "tabPageCertificationsAgent";
            this.tabPageCertificationsAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCertificationsAgent.Size = new System.Drawing.Size(449, 216);
            this.tabPageCertificationsAgent.TabIndex = 1;
            this.tabPageCertificationsAgent.Text = "Certifications";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.dataGridView1.Location = new System.Drawing.Point(6, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(437, 197);
            this.dataGridView1.TabIndex = 20;
            // 
            // labelNameOfUser
            // 
            this.labelNameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelNameOfUser.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelNameOfUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelNameOfUser.Location = new System.Drawing.Point(146, 11);
            this.labelNameOfUser.Name = "labelNameOfUser";
            this.labelNameOfUser.Size = new System.Drawing.Size(261, 25);
            this.labelNameOfUser.TabIndex = 1;
            this.labelNameOfUser.Text = "Firstname LASTNAME";
            // 
            // textBoxAdmin
            // 
            this.textBoxAdmin.Location = new System.Drawing.Point(370, 54);
            this.textBoxAdmin.Name = "textBoxAdmin";
            this.textBoxAdmin.Size = new System.Drawing.Size(185, 20);
            this.textBoxAdmin.TabIndex = 11;
            this.textBoxAdmin.Text = "Admin";
            // 
            // comboBoxStatut
            // 
            this.comboBoxStatut.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxStatut.FormattingEnabled = true;
            this.comboBoxStatut.Location = new System.Drawing.Point(147, 54);
            this.comboBoxStatut.Name = "comboBoxStatut";
            this.comboBoxStatut.Size = new System.Drawing.Size(185, 22);
            this.comboBoxStatut.TabIndex = 2;
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Location = new System.Drawing.Point(147, 134);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(185, 22);
            this.comboBoxFunction.TabIndex = 4;
            this.comboBoxFunction.Text = "Function";
            // 
            // comboBoxRespHierarchique
            // 
            this.comboBoxRespHierarchique.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxRespHierarchique.FormattingEnabled = true;
            this.comboBoxRespHierarchique.Location = new System.Drawing.Point(370, 90);
            this.comboBoxRespHierarchique.Name = "comboBoxRespHierarchique";
            this.comboBoxRespHierarchique.Size = new System.Drawing.Size(185, 22);
            this.comboBoxRespHierarchique.TabIndex = 12;
            this.comboBoxRespHierarchique.Text = "Responsable Hiérarchique";
            // 
            // comboBoxEducation_Habilitation
            // 
            this.comboBoxEducation_Habilitation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEducation_Habilitation.FormattingEnabled = true;
            this.comboBoxEducation_Habilitation.Location = new System.Drawing.Point(370, 128);
            this.comboBoxEducation_Habilitation.Name = "comboBoxEducation_Habilitation";
            this.comboBoxEducation_Habilitation.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEducation_Habilitation.TabIndex = 13;
            this.comboBoxEducation_Habilitation.Text = "Education_Habilitation";
            // 
            // comboBoxEquipe
            // 
            this.comboBoxEquipe.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEquipe.FormattingEnabled = true;
            this.comboBoxEquipe.Location = new System.Drawing.Point(147, 94);
            this.comboBoxEquipe.Name = "comboBoxEquipe";
            this.comboBoxEquipe.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEquipe.TabIndex = 3;
            this.comboBoxEquipe.Text = "Equipe/Affectation";
            // 
            // comboBoxAstreinte
            // 
            this.comboBoxAstreinte.FormattingEnabled = true;
            this.comboBoxAstreinte.Location = new System.Drawing.Point(370, 165);
            this.comboBoxAstreinte.Name = "comboBoxAstreinte";
            this.comboBoxAstreinte.Size = new System.Drawing.Size(185, 22);
            this.comboBoxAstreinte.TabIndex = 14;
            this.comboBoxAstreinte.Text = "Role d\'astreinte";
            // 
            // comboBoxEPI
            // 
            this.comboBoxEPI.FormattingEnabled = true;
            this.comboBoxEPI.Location = new System.Drawing.Point(147, 177);
            this.comboBoxEPI.Name = "comboBoxEPI";
            this.comboBoxEPI.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEPI.TabIndex = 5;
            this.comboBoxEPI.Text = "Rôle EPI";
            // 
            // checkBoxSecouriste
            // 
            this.checkBoxSecouriste.AutoSize = true;
            this.checkBoxSecouriste.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBoxSecouriste.Location = new System.Drawing.Point(370, 222);
            this.checkBoxSecouriste.Name = "checkBoxSecouriste";
            this.checkBoxSecouriste.Size = new System.Drawing.Size(101, 18);
            this.checkBoxSecouriste.TabIndex = 16;
            this.checkBoxSecouriste.Text = "Rôle secouriste";
            this.checkBoxSecouriste.UseVisualStyleBackColor = true;
            // 
            // checkBox_IsWorkManager
            // 
            this.checkBox_IsWorkManager.AutoSize = true;
            this.checkBox_IsWorkManager.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBox_IsWorkManager.Location = new System.Drawing.Point(370, 198);
            this.checkBox_IsWorkManager.Name = "checkBox_IsWorkManager";
            this.checkBox_IsWorkManager.Size = new System.Drawing.Size(116, 18);
            this.checkBox_IsWorkManager.TabIndex = 15;
            this.checkBox_IsWorkManager.Text = "Chargé de travaux";
            this.checkBox_IsWorkManager.UseVisualStyleBackColor = true;
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.labelRemarks.Location = new System.Drawing.Point(144, 357);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(81, 16);
            this.labelRemarks.TabIndex = 16;
            this.labelRemarks.Text = "Remarques";
            // 
            // richTextBoxRemarks
            // 
            this.richTextBoxRemarks.AutoWordSelection = true;
            this.richTextBoxRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.richTextBoxRemarks.Font = new System.Drawing.Font("Arial", 8.25F);
            this.richTextBoxRemarks.Location = new System.Drawing.Point(147, 376);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(330, 42);
            this.richTextBoxRemarks.TabIndex = 15;
            this.richTextBoxRemarks.Text = "";
            // 
            // dateTimePickerSeniority
            // 
            this.dateTimePickerSeniority.Location = new System.Drawing.Point(147, 320);
            this.dateTimePickerSeniority.Name = "dateTimePickerSeniority";
            this.dateTimePickerSeniority.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSeniority.TabIndex = 9;
            // 
            // dateTimePickerLastFunction
            // 
            this.dateTimePickerLastFunction.Location = new System.Drawing.Point(147, 275);
            this.dateTimePickerLastFunction.Name = "dateTimePickerLastFunction";
            this.dateTimePickerLastFunction.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLastFunction.TabIndex = 8;
            // 
            // dateTimePicker_DateOfEntry
            // 
            this.dateTimePicker_DateOfEntry.Location = new System.Drawing.Point(147, 227);
            this.dateTimePicker_DateOfEntry.Name = "dateTimePicker_DateOfEntry";
            this.dateTimePicker_DateOfEntry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DateOfEntry.TabIndex = 6;
            // 
            // labelActif
            // 
            this.labelActif.AutoSize = true;
            this.labelActif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActif.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelActif.Location = new System.Drawing.Point(10, 177);
            this.labelActif.Name = "labelActif";
            this.labelActif.Size = new System.Drawing.Size(113, 19);
            this.labelActif.TabIndex = 5;
            this.labelActif.Text = "Actif/NonActif";
            // 
            // labelMatricule
            // 
            this.labelMatricule.AutoSize = true;
            this.labelMatricule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricule.Location = new System.Drawing.Point(8, 141);
            this.labelMatricule.Name = "labelMatricule";
            this.labelMatricule.Size = new System.Drawing.Size(71, 18);
            this.labelMatricule.TabIndex = 3;
            this.labelMatricule.Text = "Matricule";
            // 
            // pictureBox_ProfilePic
            // 
            this.pictureBox_ProfilePic.Image = global::Module_Education.Properties.Resources.baseline_person_black_36dp;
            this.pictureBox_ProfilePic.Location = new System.Drawing.Point(11, 11);
            this.pictureBox_ProfilePic.Name = "pictureBox_ProfilePic";
            this.pictureBox_ProfilePic.Size = new System.Drawing.Size(112, 112);
            this.pictureBox_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_ProfilePic.TabIndex = 0;
            this.pictureBox_ProfilePic.TabStop = false;
            // 
            // UC_Provider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlAgentList);
            this.Name = "UC_Provider";
            this.Size = new System.Drawing.Size(1067, 602);
            this.tabControlAgentList.ResumeLayout(false);
            this.tbListeAgents.ResumeLayout(false);
            this.tbListeAgents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Providers)).EndInit();
            this.tbFicheAgent.ResumeLayout(false);
            this.tbFicheAgent.PerformLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.ResumeLayout(false);
            this.tabPageEducation_FormationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).EndInit();
            this.tabPageCertificationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAgentList;
        private System.Windows.Forms.TabPage tbListeAgents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblNbrProviders;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.TextBox tbNbrRowsProviders;
        private System.Windows.Forms.Label lblNbrRows;
        private System.Windows.Forms.PictureBox picExportExcel;
        private Zuby.ADGV.AdvancedDataGridView dG_Providers;
        private System.Windows.Forms.ProgressBar progressBarDgAgent;
        private System.Windows.Forms.Button btn_NextAgent;
        private System.Windows.Forms.Button btn_PreviousAgent;
        private System.Windows.Forms.Label lblTiteLstAgent;
        private System.Windows.Forms.TextBox tbFiltre;
        private System.Windows.Forms.TabPage tbFicheAgent;
        private System.Windows.Forms.Label lblRoleEPI;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Label lblSeniority;
        private System.Windows.Forms.Label lblentrylastFunction;
        private System.Windows.Forms.Label lblDateEntry;
        private System.Windows.Forms.Label labelDurationInDays;
        private System.Windows.Forms.CheckBox cbCheck_PrimeRescuer;
        private System.Windows.Forms.TabControl tabControl_Education_FormationAndCertificationsOfUser;
        private System.Windows.Forms.TabPage tabPageEducation_FormationsAgent;
        private System.Windows.Forms.DataGridView dg_TABFormationsOfAgent;
        private System.Windows.Forms.TabPage tabPageCertificationsAgent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox labelNameOfUser;
        private System.Windows.Forms.TextBox textBoxAdmin;
        private System.Windows.Forms.ComboBox comboBoxStatut;
        private System.Windows.Forms.ComboBox comboBoxFunction;
        private System.Windows.Forms.ComboBox comboBoxRespHierarchique;
        private System.Windows.Forms.ComboBox comboBoxEducation_Habilitation;
        private System.Windows.Forms.ComboBox comboBoxEquipe;
        private System.Windows.Forms.ComboBox comboBoxAstreinte;
        private System.Windows.Forms.ComboBox comboBoxEPI;
        private System.Windows.Forms.CheckBox checkBoxSecouriste;
        private System.Windows.Forms.CheckBox checkBox_IsWorkManager;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.RichTextBox richTextBoxRemarks;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeniority;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastFunction;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateOfEntry;
        private System.Windows.Forms.Label labelActif;
        private System.Windows.Forms.Label labelMatricule;
        private System.Windows.Forms.PictureBox pictureBox_ProfilePic;
    }
}
