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
            this.tabControlProvider = new System.Windows.Forms.TabControl();
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
            this.lblVendor = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.lblCodePO = new System.Windows.Forms.Label();
            this.tbCodePo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblFormerEmail = new System.Windows.Forms.Label();
            this.tbFormerEmail = new System.Windows.Forms.TextBox();
            this.lblFormerTel = new System.Windows.Forms.Label();
            this.lblFormer = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblEmailProvider = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.tabControl_Education_FormationAndCertificationsOfUser = new System.Windows.Forms.TabControl();
            this.tabPageEducation_FormationsAgent = new System.Windows.Forms.TabPage();
            this.dg_TABFormationsOfAgent = new System.Windows.Forms.DataGridView();
            this.tabPageCertificationsAgent = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelFournisseur = new System.Windows.Forms.TextBox();
            this.tbNumContact = new System.Windows.Forms.TextBox();
            this.comboPersonneContact = new System.Windows.Forms.ComboBox();
            this.cbProviderCountry = new System.Windows.Forms.ComboBox();
            this.labelRemarksProvider = new System.Windows.Forms.Label();
            this.rtbRemarksProvider = new System.Windows.Forms.RichTextBox();
            this.labelActif = new System.Windows.Forms.Label();
            this.labelMatricule = new System.Windows.Forms.Label();
            this.tabControlProvider.SuspendLayout();
            this.tbListeAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Providers)).BeginInit();
            this.tbFicheAgent.SuspendLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.SuspendLayout();
            this.tabPageEducation_FormationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).BeginInit();
            this.tabPageCertificationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlProvider
            // 
            this.tabControlProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlProvider.Controls.Add(this.tbListeAgents);
            this.tabControlProvider.Controls.Add(this.tbFicheAgent);
            this.tabControlProvider.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabControlProvider.Location = new System.Drawing.Point(0, 0);
            this.tabControlProvider.Name = "tabControlProvider";
            this.tabControlProvider.SelectedIndex = 0;
            this.tabControlProvider.Size = new System.Drawing.Size(1067, 555);
            this.tabControlProvider.TabIndex = 1;
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
            this.dG_Providers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dG_Providers_MouseClick);
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
            this.lblTiteLstAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
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
            this.tbFicheAgent.Controls.Add(this.lblVendor);
            this.tbFicheAgent.Controls.Add(this.tbVendor);
            this.tbFicheAgent.Controls.Add(this.lblCodePO);
            this.tbFicheAgent.Controls.Add(this.tbCodePo);
            this.tbFicheAgent.Controls.Add(this.label3);
            this.tbFicheAgent.Controls.Add(this.textBox4);
            this.tbFicheAgent.Controls.Add(this.label2);
            this.tbFicheAgent.Controls.Add(this.textBox2);
            this.tbFicheAgent.Controls.Add(this.lblFormerEmail);
            this.tbFicheAgent.Controls.Add(this.tbFormerEmail);
            this.tbFicheAgent.Controls.Add(this.lblFormerTel);
            this.tbFicheAgent.Controls.Add(this.lblFormer);
            this.tbFicheAgent.Controls.Add(this.textBox3);
            this.tbFicheAgent.Controls.Add(this.comboBox1);
            this.tbFicheAgent.Controls.Add(this.lblEmailProvider);
            this.tbFicheAgent.Controls.Add(this.textBox1);
            this.tbFicheAgent.Controls.Add(this.label1);
            this.tbFicheAgent.Controls.Add(this.lblCountry);
            this.tbFicheAgent.Controls.Add(this.lblContactPerson);
            this.tbFicheAgent.Controls.Add(this.tabControl_Education_FormationAndCertificationsOfUser);
            this.tbFicheAgent.Controls.Add(this.labelFournisseur);
            this.tbFicheAgent.Controls.Add(this.tbNumContact);
            this.tbFicheAgent.Controls.Add(this.comboPersonneContact);
            this.tbFicheAgent.Controls.Add(this.cbProviderCountry);
            this.tbFicheAgent.Controls.Add(this.labelRemarksProvider);
            this.tbFicheAgent.Controls.Add(this.rtbRemarksProvider);
            this.tbFicheAgent.Controls.Add(this.labelActif);
            this.tbFicheAgent.Controls.Add(this.labelMatricule);
            this.tbFicheAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbFicheAgent.Location = new System.Drawing.Point(4, 23);
            this.tbFicheAgent.Name = "tbFicheAgent";
            this.tbFicheAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tbFicheAgent.Size = new System.Drawing.Size(1059, 528);
            this.tbFicheAgent.TabIndex = 1;
            this.tbFicheAgent.Text = "Fiche";
            this.tbFicheAgent.UseVisualStyleBackColor = true;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblVendor.Location = new System.Drawing.Point(223, 218);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(48, 14);
            this.lblVendor.TabIndex = 107;
            this.lblVendor.Text = "Vendeur";
            // 
            // tbVendor
            // 
            this.tbVendor.Location = new System.Drawing.Point(223, 235);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.Size = new System.Drawing.Size(185, 20);
            this.tbVendor.TabIndex = 106;
            // 
            // lblCodePO
            // 
            this.lblCodePO.AutoSize = true;
            this.lblCodePO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblCodePO.Location = new System.Drawing.Point(223, 179);
            this.lblCodePO.Name = "lblCodePO";
            this.lblCodePO.Size = new System.Drawing.Size(49, 14);
            this.lblCodePO.TabIndex = 105;
            this.lblCodePO.Text = "Code PO";
            // 
            // tbCodePo
            // 
            this.tbCodePo.Location = new System.Drawing.Point(223, 196);
            this.tbCodePo.Name = "tbCodePo";
            this.tbCodePo.Size = new System.Drawing.Size(185, 20);
            this.tbCodePo.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(16, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 103;
            this.label3.Text = "Accès Formateur";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 285);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(185, 20);
            this.textBox4.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(16, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "Matériel";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 235);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(185, 20);
            this.textBox2.TabIndex = 100;
            // 
            // lblFormerEmail
            // 
            this.lblFormerEmail.AutoSize = true;
            this.lblFormerEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormerEmail.Location = new System.Drawing.Point(226, 130);
            this.lblFormerEmail.Name = "lblFormerEmail";
            this.lblFormerEmail.Size = new System.Drawing.Size(83, 14);
            this.lblFormerEmail.TabIndex = 99;
            this.lblFormerEmail.Text = "Email Formateur";
            // 
            // tbFormerEmail
            // 
            this.tbFormerEmail.Location = new System.Drawing.Point(226, 147);
            this.tbFormerEmail.Name = "tbFormerEmail";
            this.tbFormerEmail.Size = new System.Drawing.Size(185, 20);
            this.tbFormerEmail.TabIndex = 98;
            // 
            // lblFormerTel
            // 
            this.lblFormerTel.AutoSize = true;
            this.lblFormerTel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormerTel.Location = new System.Drawing.Point(226, 87);
            this.lblFormerTel.Name = "lblFormerTel";
            this.lblFormerTel.Size = new System.Drawing.Size(72, 14);
            this.lblFormerTel.TabIndex = 97;
            this.lblFormerTel.Text = "Tel Formateur";
            // 
            // lblFormer
            // 
            this.lblFormer.AutoSize = true;
            this.lblFormer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFormer.Location = new System.Drawing.Point(226, 45);
            this.lblFormer.Name = "lblFormer";
            this.lblFormer.Size = new System.Drawing.Size(56, 14);
            this.lblFormer.TabIndex = 96;
            this.lblFormer.Text = "Formateur";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(226, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(185, 20);
            this.textBox3.TabIndex = 95;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(226, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 22);
            this.comboBox1.TabIndex = 94;
            // 
            // lblEmailProvider
            // 
            this.lblEmailProvider.AutoSize = true;
            this.lblEmailProvider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblEmailProvider.Location = new System.Drawing.Point(16, 130);
            this.lblEmailProvider.Name = "lblEmailProvider";
            this.lblEmailProvider.Size = new System.Drawing.Size(85, 14);
            this.lblEmailProvider.TabIndex = 93;
            this.lblEmailProvider.Text = "Email de contact";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(16, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 91;
            this.label1.Text = "Numéro de contact";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblCountry.Location = new System.Drawing.Point(16, 179);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(74, 14);
            this.lblCountry.TabIndex = 88;
            this.lblCountry.Text = "Pays d\'origine";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblContactPerson.Location = new System.Drawing.Point(16, 45);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(107, 14);
            this.lblContactPerson.TabIndex = 84;
            this.lblContactPerson.Text = "Personne de contact";
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
            this.tabControl_Education_FormationAndCertificationsOfUser.Visible = false;
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
            this.dg_TABFormationsOfAgent.Visible = false;
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
            // labelFournisseur
            // 
            this.labelFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelFournisseur.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelFournisseur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelFournisseur.Location = new System.Drawing.Point(15, 17);
            this.labelFournisseur.Name = "labelFournisseur";
            this.labelFournisseur.Size = new System.Drawing.Size(261, 25);
            this.labelFournisseur.TabIndex = 1;
            this.labelFournisseur.Text = "Fournisseur";
            // 
            // tbNumContact
            // 
            this.tbNumContact.Location = new System.Drawing.Point(16, 104);
            this.tbNumContact.Name = "tbNumContact";
            this.tbNumContact.Size = new System.Drawing.Size(185, 20);
            this.tbNumContact.TabIndex = 11;
            // 
            // comboPersonneContact
            // 
            this.comboPersonneContact.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboPersonneContact.FormattingEnabled = true;
            this.comboPersonneContact.Location = new System.Drawing.Point(16, 60);
            this.comboPersonneContact.Name = "comboPersonneContact";
            this.comboPersonneContact.Size = new System.Drawing.Size(185, 22);
            this.comboPersonneContact.TabIndex = 2;
            // 
            // cbProviderCountry
            // 
            this.cbProviderCountry.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbProviderCountry.FormattingEnabled = true;
            this.cbProviderCountry.Location = new System.Drawing.Point(16, 193);
            this.cbProviderCountry.Name = "cbProviderCountry";
            this.cbProviderCountry.Size = new System.Drawing.Size(185, 22);
            this.cbProviderCountry.TabIndex = 3;
            // 
            // labelRemarksProvider
            // 
            this.labelRemarksProvider.AutoSize = true;
            this.labelRemarksProvider.Font = new System.Drawing.Font("Arial", 10F);
            this.labelRemarksProvider.Location = new System.Drawing.Point(9, 327);
            this.labelRemarksProvider.Name = "labelRemarksProvider";
            this.labelRemarksProvider.Size = new System.Drawing.Size(81, 16);
            this.labelRemarksProvider.TabIndex = 16;
            this.labelRemarksProvider.Text = "Remarques";
            // 
            // rtbRemarksProvider
            // 
            this.rtbRemarksProvider.AutoWordSelection = true;
            this.rtbRemarksProvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.rtbRemarksProvider.Font = new System.Drawing.Font("Arial", 8.25F);
            this.rtbRemarksProvider.Location = new System.Drawing.Point(12, 346);
            this.rtbRemarksProvider.Name = "rtbRemarksProvider";
            this.rtbRemarksProvider.Size = new System.Drawing.Size(330, 42);
            this.rtbRemarksProvider.TabIndex = 15;
            this.rtbRemarksProvider.Text = "";
            // 
            // labelActif
            // 
            this.labelActif.AutoSize = true;
            this.labelActif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActif.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelActif.Location = new System.Drawing.Point(677, 17);
            this.labelActif.Name = "labelActif";
            this.labelActif.Size = new System.Drawing.Size(113, 19);
            this.labelActif.TabIndex = 5;
            this.labelActif.Text = "Actif/NonActif";
            this.labelActif.Visible = false;
            // 
            // labelMatricule
            // 
            this.labelMatricule.AutoSize = true;
            this.labelMatricule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricule.Location = new System.Drawing.Point(353, 17);
            this.labelMatricule.Name = "labelMatricule";
            this.labelMatricule.Size = new System.Drawing.Size(71, 18);
            this.labelMatricule.TabIndex = 3;
            this.labelMatricule.Text = "Matricule";
            // 
            // UC_Provider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlProvider);
            this.Name = "UC_Provider";
            this.Size = new System.Drawing.Size(1067, 602);
            this.tabControlProvider.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlProvider;
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
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.TabControl tabControl_Education_FormationAndCertificationsOfUser;
        private System.Windows.Forms.TabPage tabPageEducation_FormationsAgent;
        private System.Windows.Forms.DataGridView dg_TABFormationsOfAgent;
        private System.Windows.Forms.TabPage tabPageCertificationsAgent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox labelFournisseur;
        private System.Windows.Forms.TextBox tbNumContact;
        private System.Windows.Forms.ComboBox comboPersonneContact;
        private System.Windows.Forms.ComboBox cbProviderCountry;
        private System.Windows.Forms.Label labelRemarksProvider;
        private System.Windows.Forms.RichTextBox rtbRemarksProvider;
        private System.Windows.Forms.Label labelActif;
        private System.Windows.Forms.Label labelMatricule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFormerEmail;
        private System.Windows.Forms.TextBox tbFormerEmail;
        private System.Windows.Forms.Label lblFormerTel;
        private System.Windows.Forms.Label lblFormer;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblEmailProvider;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.Label lblCodePO;
        private System.Windows.Forms.TextBox tbCodePo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}
