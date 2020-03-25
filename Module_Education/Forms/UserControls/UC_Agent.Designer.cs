namespace Module_Education
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
            this.progressBarDgAgent = new System.Windows.Forms.ProgressBar();
            this.btn_NextAgent = new System.Windows.Forms.Button();
            this.btn_PreviousAgent = new System.Windows.Forms.Button();
            this.labelEducation_Formation = new System.Windows.Forms.Label();
            this.tbFiltre = new System.Windows.Forms.TextBox();
            this.dG_Agents = new System.Windows.Forms.DataGridView();
            this.tbFicheAgent = new System.Windows.Forms.TabPage();
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
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerSeniority = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerLastFunction = new System.Windows.Forms.DateTimePicker();
            this.labelDateOfEntry = new System.Windows.Forms.Label();
            this.dateTimePicker_DateOfEntry = new System.Windows.Forms.DateTimePicker();
            this.labelActif = new System.Windows.Forms.Label();
            this.labelMatricule = new System.Windows.Forms.Label();
            this.pictureBox_ProfilePic = new System.Windows.Forms.PictureBox();
            this.equipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlAgentList.SuspendLayout();
            this.tbListeAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Agents)).BeginInit();
            this.tbFicheAgent.SuspendLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.SuspendLayout();
            this.tabPageEducation_FormationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).BeginInit();
            this.tabPageCertificationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAgentList
            // 
            this.tabControlAgentList.Controls.Add(this.tbListeAgents);
            this.tabControlAgentList.Controls.Add(this.tbFicheAgent);
            this.tabControlAgentList.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tabControlAgentList.Location = new System.Drawing.Point(3, 3);
            this.tabControlAgentList.Name = "tabControlAgentList";
            this.tabControlAgentList.SelectedIndex = 0;
            this.tabControlAgentList.Size = new System.Drawing.Size(1067, 565);
            this.tabControlAgentList.TabIndex = 0;
            // 
            // tbListeAgents
            // 
            this.tbListeAgents.Controls.Add(this.progressBarDgAgent);
            this.tbListeAgents.Controls.Add(this.btn_NextAgent);
            this.tbListeAgents.Controls.Add(this.btn_PreviousAgent);
            this.tbListeAgents.Controls.Add(this.labelEducation_Formation);
            this.tbListeAgents.Controls.Add(this.tbFiltre);
            this.tbListeAgents.Controls.Add(this.dG_Agents);
            this.tbListeAgents.Location = new System.Drawing.Point(4, 23);
            this.tbListeAgents.Name = "tbListeAgents";
            this.tbListeAgents.Padding = new System.Windows.Forms.Padding(3);
            this.tbListeAgents.Size = new System.Drawing.Size(1059, 538);
            this.tbListeAgents.TabIndex = 0;
            this.tbListeAgents.Text = "Liste";
            this.tbListeAgents.UseVisualStyleBackColor = true;
            // 
            // progressBarDgAgent
            // 
            this.progressBarDgAgent.Location = new System.Drawing.Point(343, 7);
            this.progressBarDgAgent.Name = "progressBarDgAgent";
            this.progressBarDgAgent.Size = new System.Drawing.Size(349, 23);
            this.progressBarDgAgent.TabIndex = 17;
            // 
            // btn_NextAgent
            // 
            this.btn_NextAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_NextAgent.Location = new System.Drawing.Point(505, 484);
            this.btn_NextAgent.Name = "btn_NextAgent";
            this.btn_NextAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_NextAgent.TabIndex = 16;
            this.btn_NextAgent.Text = "Suivant";
            this.btn_NextAgent.UseVisualStyleBackColor = true;
            this.btn_NextAgent.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_PreviousAgent
            // 
            this.btn_PreviousAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_PreviousAgent.Location = new System.Drawing.Point(404, 484);
            this.btn_PreviousAgent.Name = "btn_PreviousAgent";
            this.btn_PreviousAgent.Size = new System.Drawing.Size(75, 23);
            this.btn_PreviousAgent.TabIndex = 15;
            this.btn_PreviousAgent.Text = "Précédent";
            this.btn_PreviousAgent.UseVisualStyleBackColor = true;
            this.btn_PreviousAgent.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // labelEducation_Formation
            // 
            this.labelEducation_Formation.AutoSize = true;
            this.labelEducation_Formation.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEducation_Formation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.labelEducation_Formation.Location = new System.Drawing.Point(17, 3);
            this.labelEducation_Formation.Name = "labelEducation_Formation";
            this.labelEducation_Formation.Size = new System.Drawing.Size(177, 24);
            this.labelEducation_Formation.TabIndex = 8;
            this.labelEducation_Formation.Text = "Liste des agents";
            // 
            // tbFiltre
            // 
            this.tbFiltre.Location = new System.Drawing.Point(10, 484);
            this.tbFiltre.Name = "tbFiltre";
            this.tbFiltre.Size = new System.Drawing.Size(261, 20);
            this.tbFiltre.TabIndex = 7;
            this.tbFiltre.TextChanged += new System.EventHandler(this.tbFiltre_TextChanged);
            // 
            // dG_Agents
            // 
            this.dG_Agents.AllowUserToAddRows = false;
            this.dG_Agents.AllowUserToDeleteRows = false;
            this.dG_Agents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_Agents.Location = new System.Drawing.Point(10, 40);
            this.dG_Agents.Name = "dG_Agents";
            this.dG_Agents.ReadOnly = true;
            this.dG_Agents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dG_Agents.Size = new System.Drawing.Size(1014, 429);
            this.dG_Agents.TabIndex = 6;
            this.dG_Agents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dG_Agents_CellContentDoubleClick);
            this.dG_Agents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dG_Agents_MouseClick);
            // 
            // tbFicheAgent
            // 
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
            this.tbFicheAgent.Controls.Add(this.label3);
            this.tbFicheAgent.Controls.Add(this.dateTimePickerSeniority);
            this.tbFicheAgent.Controls.Add(this.label2);
            this.tbFicheAgent.Controls.Add(this.dateTimePickerLastFunction);
            this.tbFicheAgent.Controls.Add(this.labelDateOfEntry);
            this.tbFicheAgent.Controls.Add(this.dateTimePicker_DateOfEntry);
            this.tbFicheAgent.Controls.Add(this.labelActif);
            this.tbFicheAgent.Controls.Add(this.labelMatricule);
            this.tbFicheAgent.Controls.Add(this.pictureBox_ProfilePic);
            this.tbFicheAgent.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tbFicheAgent.Location = new System.Drawing.Point(4, 23);
            this.tbFicheAgent.Name = "tbFicheAgent";
            this.tbFicheAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tbFicheAgent.Size = new System.Drawing.Size(1059, 538);
            this.tbFicheAgent.TabIndex = 1;
            this.tbFicheAgent.Text = "Fiche";
            this.tbFicheAgent.UseVisualStyleBackColor = true;
            // 
            // tabControl_Education_FormationAndCertificationsOfUser
            // 
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageEducation_FormationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageCertificationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl_Education_FormationAndCertificationsOfUser.Location = new System.Drawing.Point(239, 216);
            this.tabControl_Education_FormationAndCertificationsOfUser.Name = "tabControl_Education_FormationAndCertificationsOfUser";
            this.tabControl_Education_FormationAndCertificationsOfUser.SelectedIndex = 0;
            this.tabControl_Education_FormationAndCertificationsOfUser.Size = new System.Drawing.Size(790, 379);
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
            this.tabPageEducation_FormationsAgent.Size = new System.Drawing.Size(782, 347);
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
            this.dg_TABFormationsOfAgent.Location = new System.Drawing.Point(10, 9);
            this.dg_TABFormationsOfAgent.Name = "dg_TABFormationsOfAgent";
            this.dg_TABFormationsOfAgent.ReadOnly = true;
            this.dg_TABFormationsOfAgent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_TABFormationsOfAgent.Size = new System.Drawing.Size(766, 279);
            this.dg_TABFormationsOfAgent.TabIndex = 18;
            // 
            // tabPageCertificationsAgent
            // 
            this.tabPageCertificationsAgent.Controls.Add(this.dataGridView1);
            this.tabPageCertificationsAgent.Font = new System.Drawing.Font("Arial", 10F);
            this.tabPageCertificationsAgent.Location = new System.Drawing.Point(4, 28);
            this.tabPageCertificationsAgent.Name = "tabPageCertificationsAgent";
            this.tabPageCertificationsAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCertificationsAgent.Size = new System.Drawing.Size(782, 347);
            this.tabPageCertificationsAgent.TabIndex = 1;
            this.tabPageCertificationsAgent.Text = "Certifications";
            this.tabPageCertificationsAgent.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(10, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(766, 337);
            this.dataGridView1.TabIndex = 20;
            // 
            // labelNameOfUser
            // 
            this.labelNameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelNameOfUser.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelNameOfUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelNameOfUser.Location = new System.Drawing.Point(165, 11);
            this.labelNameOfUser.Name = "labelNameOfUser";
            this.labelNameOfUser.Size = new System.Drawing.Size(261, 25);
            this.labelNameOfUser.TabIndex = 34;
            this.labelNameOfUser.Text = "Firstname LASTNAME";
            // 
            // textBoxAdmin
            // 
            this.textBoxAdmin.Location = new System.Drawing.Point(389, 54);
            this.textBoxAdmin.Name = "textBoxAdmin";
            this.textBoxAdmin.Size = new System.Drawing.Size(185, 20);
            this.textBoxAdmin.TabIndex = 33;
            this.textBoxAdmin.Text = "Admin";
            this.textBoxAdmin.Leave += new System.EventHandler(this.textBoxAdmin_Leave);
            // 
            // comboBoxStatut
            // 
            this.comboBoxStatut.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxStatut.FormattingEnabled = true;
            this.comboBoxStatut.Location = new System.Drawing.Point(166, 54);
            this.comboBoxStatut.Name = "comboBoxStatut";
            this.comboBoxStatut.Size = new System.Drawing.Size(185, 22);
            this.comboBoxStatut.TabIndex = 32;
            this.comboBoxStatut.Text = "Statut";
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Location = new System.Drawing.Point(166, 128);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(185, 22);
            this.comboBoxFunction.TabIndex = 31;
            this.comboBoxFunction.Text = "Function";
            this.comboBoxFunction.Leave += new System.EventHandler(this.comboBoxFunction_Leave);
            // 
            // comboBoxRespHierarchique
            // 
            this.comboBoxRespHierarchique.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxRespHierarchique.FormattingEnabled = true;
            this.comboBoxRespHierarchique.Location = new System.Drawing.Point(389, 90);
            this.comboBoxRespHierarchique.Name = "comboBoxRespHierarchique";
            this.comboBoxRespHierarchique.Size = new System.Drawing.Size(185, 22);
            this.comboBoxRespHierarchique.TabIndex = 30;
            this.comboBoxRespHierarchique.Text = "Responsable Hiérarchique";
            this.comboBoxRespHierarchique.Leave += new System.EventHandler(this.comboBoxRespHierarchique_Leave);
            // 
            // comboBoxEducation_Habilitation
            // 
            this.comboBoxEducation_Habilitation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEducation_Habilitation.FormattingEnabled = true;
            this.comboBoxEducation_Habilitation.Location = new System.Drawing.Point(389, 128);
            this.comboBoxEducation_Habilitation.Name = "comboBoxEducation_Habilitation";
            this.comboBoxEducation_Habilitation.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEducation_Habilitation.TabIndex = 29;
            this.comboBoxEducation_Habilitation.Text = "Education_Habilitation";
            this.comboBoxEducation_Habilitation.Leave += new System.EventHandler(this.comboBoxEducation_Habilitation_Leave);
            // 
            // comboBoxEquipe
            // 
            this.comboBoxEquipe.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEquipe.FormattingEnabled = true;
            this.comboBoxEquipe.Location = new System.Drawing.Point(166, 90);
            this.comboBoxEquipe.Name = "comboBoxEquipe";
            this.comboBoxEquipe.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEquipe.TabIndex = 28;
            this.comboBoxEquipe.Text = "Equipe/Affectation";
            // 
            // comboBoxAstreinte
            // 
            this.comboBoxAstreinte.FormattingEnabled = true;
            this.comboBoxAstreinte.Location = new System.Drawing.Point(389, 165);
            this.comboBoxAstreinte.Name = "comboBoxAstreinte";
            this.comboBoxAstreinte.Size = new System.Drawing.Size(185, 22);
            this.comboBoxAstreinte.TabIndex = 26;
            this.comboBoxAstreinte.Text = "Role d\'astreinte";
            this.comboBoxAstreinte.Leave += new System.EventHandler(this.comboBoxAstreinte_Leave);
            // 
            // comboBoxEPI
            // 
            this.comboBoxEPI.FormattingEnabled = true;
            this.comboBoxEPI.Location = new System.Drawing.Point(166, 165);
            this.comboBoxEPI.Name = "comboBoxEPI";
            this.comboBoxEPI.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEPI.TabIndex = 25;
            this.comboBoxEPI.Text = "Rôle EPI";
            this.comboBoxEPI.Leave += new System.EventHandler(this.comboBoxEPI_Leave);
            // 
            // checkBoxSecouriste
            // 
            this.checkBoxSecouriste.AutoSize = true;
            this.checkBoxSecouriste.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBoxSecouriste.Location = new System.Drawing.Point(612, 78);
            this.checkBoxSecouriste.Name = "checkBoxSecouriste";
            this.checkBoxSecouriste.Size = new System.Drawing.Size(101, 18);
            this.checkBoxSecouriste.TabIndex = 24;
            this.checkBoxSecouriste.Text = "Rôle secouriste";
            this.checkBoxSecouriste.UseVisualStyleBackColor = true;
            this.checkBoxSecouriste.Leave += new System.EventHandler(this.checkBoxSecouriste_Leave);
            // 
            // checkBox_IsWorkManager
            // 
            this.checkBox_IsWorkManager.AutoSize = true;
            this.checkBox_IsWorkManager.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBox_IsWorkManager.Location = new System.Drawing.Point(612, 54);
            this.checkBox_IsWorkManager.Name = "checkBox_IsWorkManager";
            this.checkBox_IsWorkManager.Size = new System.Drawing.Size(116, 18);
            this.checkBox_IsWorkManager.TabIndex = 21;
            this.checkBox_IsWorkManager.Text = "Chargé de travaux";
            this.checkBox_IsWorkManager.UseVisualStyleBackColor = true;
            this.checkBox_IsWorkManager.Leave += new System.EventHandler(this.checkBox_IsWorkManager_Leave);
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.labelRemarks.Location = new System.Drawing.Point(610, 107);
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
            this.richTextBoxRemarks.Location = new System.Drawing.Point(612, 126);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(417, 70);
            this.richTextBoxRemarks.TabIndex = 15;
            this.richTextBoxRemarks.Text = "";
            this.richTextBoxRemarks.TextChanged += new System.EventHandler(this.richTextBoxRemarks_TextChanged);
            this.richTextBoxRemarks.Leave += new System.EventHandler(this.richTextBoxRemarks_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.Location = new System.Drawing.Point(13, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Date d\'anciennetée";
            // 
            // dateTimePickerSeniority
            // 
            this.dateTimePickerSeniority.Location = new System.Drawing.Point(13, 318);
            this.dateTimePickerSeniority.Name = "dateTimePickerSeniority";
            this.dateTimePickerSeniority.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSeniority.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(13, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Date dernière prise de fonction";
            // 
            // dateTimePickerLastFunction
            // 
            this.dateTimePickerLastFunction.Location = new System.Drawing.Point(13, 267);
            this.dateTimePickerLastFunction.Name = "dateTimePickerLastFunction";
            this.dateTimePickerLastFunction.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLastFunction.TabIndex = 10;
            // 
            // labelDateOfEntry
            // 
            this.labelDateOfEntry.AutoSize = true;
            this.labelDateOfEntry.Font = new System.Drawing.Font("Arial", 10F);
            this.labelDateOfEntry.Location = new System.Drawing.Point(13, 197);
            this.labelDateOfEntry.Name = "labelDateOfEntry";
            this.labelDateOfEntry.Size = new System.Drawing.Size(94, 16);
            this.labelDateOfEntry.TabIndex = 9;
            this.labelDateOfEntry.Text = "Date d\'entrée";
            // 
            // dateTimePicker_DateOfEntry
            // 
            this.dateTimePicker_DateOfEntry.Location = new System.Drawing.Point(13, 216);
            this.dateTimePicker_DateOfEntry.Name = "dateTimePicker_DateOfEntry";
            this.dateTimePicker_DateOfEntry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DateOfEntry.TabIndex = 6;
            // 
            // labelActif
            // 
            this.labelActif.AutoSize = true;
            this.labelActif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActif.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelActif.Location = new System.Drawing.Point(10, 155);
            this.labelActif.Name = "labelActif";
            this.labelActif.Size = new System.Drawing.Size(113, 19);
            this.labelActif.TabIndex = 5;
            this.labelActif.Text = "Actif/NonActif";
            // 
            // labelMatricule
            // 
            this.labelMatricule.AutoSize = true;
            this.labelMatricule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricule.Location = new System.Drawing.Point(446, 14);
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
            // equipeBindingSource
            // 
            this.equipeBindingSource.DataMember = "Equipe";
            // 
            // UC_Agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.tabControlAgentList);
            this.Name = "UC_Agent";
            this.Size = new System.Drawing.Size(1067, 571);
            this.Enter += new System.EventHandler(this.UC_Agent_Enter);
            this.tabControlAgentList.ResumeLayout(false);
            this.tbListeAgents.ResumeLayout(false);
            this.tbListeAgents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG_Agents)).EndInit();
            this.tbFicheAgent.ResumeLayout(false);
            this.tbFicheAgent.PerformLayout();
            this.tabControl_Education_FormationAndCertificationsOfUser.ResumeLayout(false);
            this.tabPageEducation_FormationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).EndInit();
            this.tabPageCertificationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAgentList;
        private System.Windows.Forms.TabPage tbListeAgents;
        private System.Windows.Forms.Label labelEducation_Formation;
        private System.Windows.Forms.TextBox tbFiltre;
        private System.Windows.Forms.DataGridView dG_Agents;
        private System.Windows.Forms.TabPage tbFicheAgent;
        private System.Windows.Forms.Label labelMatricule;
        private System.Windows.Forms.PictureBox pictureBox_ProfilePic;
        private System.Windows.Forms.Label labelActif;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateOfEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeniority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastFunction;
        private System.Windows.Forms.Label labelDateOfEntry;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.RichTextBox richTextBoxRemarks;
        private System.Windows.Forms.DataGridView dg_TABFormationsOfAgent;
        private System.Windows.Forms.CheckBox checkBox_IsWorkManager;
        private System.Windows.Forms.CheckBox checkBoxSecouriste;
        private System.Windows.Forms.ComboBox comboBoxAstreinte;
        private System.Windows.Forms.ComboBox comboBoxEPI;
        private System.Windows.Forms.ComboBox comboBoxEquipe;
        private System.Windows.Forms.BindingSource equipeBindingSource;
        private System.Windows.Forms.ComboBox comboBoxEducation_Habilitation;
        private System.Windows.Forms.ComboBox comboBoxRespHierarchique;
        private System.Windows.Forms.ComboBox comboBoxFunction;
        private System.Windows.Forms.ComboBox comboBoxStatut;
        private System.Windows.Forms.TextBox textBoxAdmin;
        private System.Windows.Forms.TextBox labelNameOfUser;
        private System.Windows.Forms.TabControl tabControl_Education_FormationAndCertificationsOfUser;
        private System.Windows.Forms.TabPage tabPageEducation_FormationsAgent;
        private System.Windows.Forms.TabPage tabPageCertificationsAgent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_NextAgent;
        private System.Windows.Forms.Button btn_PreviousAgent;
        private System.Windows.Forms.ProgressBar progressBarDgAgent;
    }
}
