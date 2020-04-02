namespace Module_Education.Forms
{
    partial class FrmAgent
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
            this.tabControl_Education_FormationAndCertificationsOfUser.SuspendLayout();
            this.tabPageEducation_FormationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).BeginInit();
            this.tabPageCertificationsAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoleEPI
            // 
            this.lblRoleEPI.AutoSize = true;
            this.lblRoleEPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblRoleEPI.Location = new System.Drawing.Point(148, 162);
            this.lblRoleEPI.Name = "lblRoleEPI";
            this.lblRoleEPI.Size = new System.Drawing.Size(49, 13);
            this.lblRoleEPI.TabIndex = 118;
            this.lblRoleEPI.Text = "Rôle EPI";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblFunction.Location = new System.Drawing.Point(148, 120);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(48, 13);
            this.lblFunction.TabIndex = 117;
            this.lblFunction.Text = "Fonction";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblEquipe.Location = new System.Drawing.Point(148, 81);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(98, 13);
            this.lblEquipe.TabIndex = 116;
            this.lblEquipe.Text = "Equipe/Affectatiion";
            // 
            // lblSeniority
            // 
            this.lblSeniority.AutoSize = true;
            this.lblSeniority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblSeniority.Location = new System.Drawing.Point(148, 304);
            this.lblSeniority.Name = "lblSeniority";
            this.lblSeniority.Size = new System.Drawing.Size(87, 13);
            this.lblSeniority.TabIndex = 115;
            this.lblSeniority.Text = "Date de séniorité";
            // 
            // lblentrylastFunction
            // 
            this.lblentrylastFunction.AutoSize = true;
            this.lblentrylastFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblentrylastFunction.Location = new System.Drawing.Point(145, 259);
            this.lblentrylastFunction.Name = "lblentrylastFunction";
            this.lblentrylastFunction.Size = new System.Drawing.Size(152, 13);
            this.lblentrylastFunction.TabIndex = 114;
            this.lblentrylastFunction.Text = "Date dernière prise de fonction";
            // 
            // lblDateEntry
            // 
            this.lblDateEntry.AutoSize = true;
            this.lblDateEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblDateEntry.Location = new System.Drawing.Point(145, 212);
            this.lblDateEntry.Name = "lblDateEntry";
            this.lblDateEntry.Size = new System.Drawing.Size(64, 13);
            this.lblDateEntry.TabIndex = 113;
            this.lblDateEntry.Text = "Date Entrée";
            // 
            // labelDurationInDays
            // 
            this.labelDurationInDays.AutoSize = true;
            this.labelDurationInDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.labelDurationInDays.Location = new System.Drawing.Point(148, 40);
            this.labelDurationInDays.Name = "labelDurationInDays";
            this.labelDurationInDays.Size = new System.Drawing.Size(35, 13);
            this.labelDurationInDays.TabIndex = 112;
            this.labelDurationInDays.Text = "Statut";
            // 
            // cbCheck_PrimeRescuer
            // 
            this.cbCheck_PrimeRescuer.AutoSize = true;
            this.cbCheck_PrimeRescuer.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbCheck_PrimeRescuer.Location = new System.Drawing.Point(371, 247);
            this.cbCheck_PrimeRescuer.Name = "cbCheck_PrimeRescuer";
            this.cbCheck_PrimeRescuer.Size = new System.Drawing.Size(107, 18);
            this.cbCheck_PrimeRescuer.TabIndex = 110;
            this.cbCheck_PrimeRescuer.Text = "Prime Secouriste";
            this.cbCheck_PrimeRescuer.UseVisualStyleBackColor = true;
            // 
            // tabControl_Education_FormationAndCertificationsOfUser
            // 
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageEducation_FormationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Controls.Add(this.tabPageCertificationsAgent);
            this.tabControl_Education_FormationAndCertificationsOfUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl_Education_FormationAndCertificationsOfUser.Location = new System.Drawing.Point(580, 48);
            this.tabControl_Education_FormationAndCertificationsOfUser.Name = "tabControl_Education_FormationAndCertificationsOfUser";
            this.tabControl_Education_FormationAndCertificationsOfUser.SelectedIndex = 0;
            this.tabControl_Education_FormationAndCertificationsOfUser.Size = new System.Drawing.Size(457, 248);
            this.tabControl_Education_FormationAndCertificationsOfUser.TabIndex = 111;
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
            this.labelNameOfUser.Location = new System.Drawing.Point(166, 12);
            this.labelNameOfUser.Name = "labelNameOfUser";
            this.labelNameOfUser.Size = new System.Drawing.Size(261, 25);
            this.labelNameOfUser.TabIndex = 92;
            this.labelNameOfUser.Text = "Firstname LASTNAME";
            // 
            // textBoxAdmin
            // 
            this.textBoxAdmin.Location = new System.Drawing.Point(371, 55);
            this.textBoxAdmin.Name = "textBoxAdmin";
            this.textBoxAdmin.Size = new System.Drawing.Size(185, 20);
            this.textBoxAdmin.TabIndex = 102;
            this.textBoxAdmin.Text = "Admin";
            // 
            // comboBoxStatut
            // 
            this.comboBoxStatut.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxStatut.FormattingEnabled = true;
            this.comboBoxStatut.Location = new System.Drawing.Point(148, 55);
            this.comboBoxStatut.Name = "comboBoxStatut";
            this.comboBoxStatut.Size = new System.Drawing.Size(185, 22);
            this.comboBoxStatut.TabIndex = 93;
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Location = new System.Drawing.Point(148, 135);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(185, 22);
            this.comboBoxFunction.TabIndex = 96;
            this.comboBoxFunction.Text = "Function";
            // 
            // comboBoxRespHierarchique
            // 
            this.comboBoxRespHierarchique.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxRespHierarchique.FormattingEnabled = true;
            this.comboBoxRespHierarchique.Location = new System.Drawing.Point(371, 91);
            this.comboBoxRespHierarchique.Name = "comboBoxRespHierarchique";
            this.comboBoxRespHierarchique.Size = new System.Drawing.Size(185, 22);
            this.comboBoxRespHierarchique.TabIndex = 103;
            this.comboBoxRespHierarchique.Text = "Responsable Hiérarchique";
            // 
            // comboBoxEducation_Habilitation
            // 
            this.comboBoxEducation_Habilitation.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEducation_Habilitation.FormattingEnabled = true;
            this.comboBoxEducation_Habilitation.Location = new System.Drawing.Point(371, 129);
            this.comboBoxEducation_Habilitation.Name = "comboBoxEducation_Habilitation";
            this.comboBoxEducation_Habilitation.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEducation_Habilitation.TabIndex = 104;
            this.comboBoxEducation_Habilitation.Text = "Education_Habilitation";
            // 
            // comboBoxEquipe
            // 
            this.comboBoxEquipe.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comboBoxEquipe.FormattingEnabled = true;
            this.comboBoxEquipe.Location = new System.Drawing.Point(148, 95);
            this.comboBoxEquipe.Name = "comboBoxEquipe";
            this.comboBoxEquipe.Size = new System.Drawing.Size(185, 22);
            this.comboBoxEquipe.TabIndex = 94;
            this.comboBoxEquipe.Text = "Equipe/Affectation";
            // 
            // comboBoxAstreinte
            // 
            this.comboBoxAstreinte.FormattingEnabled = true;
            this.comboBoxAstreinte.Location = new System.Drawing.Point(371, 166);
            this.comboBoxAstreinte.Name = "comboBoxAstreinte";
            this.comboBoxAstreinte.Size = new System.Drawing.Size(185, 21);
            this.comboBoxAstreinte.TabIndex = 105;
            this.comboBoxAstreinte.Text = "Role d\'astreinte";
            // 
            // comboBoxEPI
            // 
            this.comboBoxEPI.FormattingEnabled = true;
            this.comboBoxEPI.Location = new System.Drawing.Point(148, 178);
            this.comboBoxEPI.Name = "comboBoxEPI";
            this.comboBoxEPI.Size = new System.Drawing.Size(185, 21);
            this.comboBoxEPI.TabIndex = 98;
            this.comboBoxEPI.Text = "Rôle EPI";
            // 
            // checkBoxSecouriste
            // 
            this.checkBoxSecouriste.AutoSize = true;
            this.checkBoxSecouriste.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBoxSecouriste.Location = new System.Drawing.Point(371, 223);
            this.checkBoxSecouriste.Name = "checkBoxSecouriste";
            this.checkBoxSecouriste.Size = new System.Drawing.Size(101, 18);
            this.checkBoxSecouriste.TabIndex = 108;
            this.checkBoxSecouriste.Text = "Rôle secouriste";
            this.checkBoxSecouriste.UseVisualStyleBackColor = true;
            // 
            // checkBox_IsWorkManager
            // 
            this.checkBox_IsWorkManager.AutoSize = true;
            this.checkBox_IsWorkManager.Font = new System.Drawing.Font("Arial", 8.25F);
            this.checkBox_IsWorkManager.Location = new System.Drawing.Point(371, 199);
            this.checkBox_IsWorkManager.Name = "checkBox_IsWorkManager";
            this.checkBox_IsWorkManager.Size = new System.Drawing.Size(116, 18);
            this.checkBox_IsWorkManager.TabIndex = 106;
            this.checkBox_IsWorkManager.Text = "Chargé de travaux";
            this.checkBox_IsWorkManager.UseVisualStyleBackColor = true;
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.labelRemarks.Location = new System.Drawing.Point(145, 358);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(81, 16);
            this.labelRemarks.TabIndex = 109;
            this.labelRemarks.Text = "Remarques";
            // 
            // richTextBoxRemarks
            // 
            this.richTextBoxRemarks.AutoWordSelection = true;
            this.richTextBoxRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(199)))), ((int)(((byte)(234)))));
            this.richTextBoxRemarks.Font = new System.Drawing.Font("Arial", 8.25F);
            this.richTextBoxRemarks.Location = new System.Drawing.Point(148, 377);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(245, 70);
            this.richTextBoxRemarks.TabIndex = 107;
            this.richTextBoxRemarks.Text = "";
            // 
            // dateTimePickerSeniority
            // 
            this.dateTimePickerSeniority.Location = new System.Drawing.Point(148, 321);
            this.dateTimePickerSeniority.Name = "dateTimePickerSeniority";
            this.dateTimePickerSeniority.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSeniority.TabIndex = 101;
            // 
            // dateTimePickerLastFunction
            // 
            this.dateTimePickerLastFunction.Location = new System.Drawing.Point(148, 276);
            this.dateTimePickerLastFunction.Name = "dateTimePickerLastFunction";
            this.dateTimePickerLastFunction.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLastFunction.TabIndex = 100;
            // 
            // dateTimePicker_DateOfEntry
            // 
            this.dateTimePicker_DateOfEntry.Location = new System.Drawing.Point(148, 228);
            this.dateTimePicker_DateOfEntry.Name = "dateTimePicker_DateOfEntry";
            this.dateTimePicker_DateOfEntry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DateOfEntry.TabIndex = 99;
            // 
            // labelActif
            // 
            this.labelActif.AutoSize = true;
            this.labelActif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActif.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelActif.Location = new System.Drawing.Point(11, 178);
            this.labelActif.Name = "labelActif";
            this.labelActif.Size = new System.Drawing.Size(113, 19);
            this.labelActif.TabIndex = 97;
            this.labelActif.Text = "Actif/NonActif";
            // 
            // labelMatricule
            // 
            this.labelMatricule.AutoSize = true;
            this.labelMatricule.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricule.Location = new System.Drawing.Point(9, 142);
            this.labelMatricule.Name = "labelMatricule";
            this.labelMatricule.Size = new System.Drawing.Size(71, 18);
            this.labelMatricule.TabIndex = 95;
            this.labelMatricule.Text = "Matricule";
            // 
            // pictureBox_ProfilePic
            // 
            this.pictureBox_ProfilePic.Image = global::Module_Education.Properties.Resources.baseline_person_black_36dp;
            this.pictureBox_ProfilePic.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_ProfilePic.Name = "pictureBox_ProfilePic";
            this.pictureBox_ProfilePic.Size = new System.Drawing.Size(112, 112);
            this.pictureBox_ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_ProfilePic.TabIndex = 91;
            this.pictureBox_ProfilePic.TabStop = false;
            // 
            // FrmAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 512);
            this.Controls.Add(this.lblRoleEPI);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblEquipe);
            this.Controls.Add(this.lblSeniority);
            this.Controls.Add(this.lblentrylastFunction);
            this.Controls.Add(this.lblDateEntry);
            this.Controls.Add(this.labelDurationInDays);
            this.Controls.Add(this.cbCheck_PrimeRescuer);
            this.Controls.Add(this.tabControl_Education_FormationAndCertificationsOfUser);
            this.Controls.Add(this.labelNameOfUser);
            this.Controls.Add(this.textBoxAdmin);
            this.Controls.Add(this.comboBoxStatut);
            this.Controls.Add(this.comboBoxFunction);
            this.Controls.Add(this.comboBoxRespHierarchique);
            this.Controls.Add(this.comboBoxEducation_Habilitation);
            this.Controls.Add(this.comboBoxEquipe);
            this.Controls.Add(this.comboBoxAstreinte);
            this.Controls.Add(this.comboBoxEPI);
            this.Controls.Add(this.checkBoxSecouriste);
            this.Controls.Add(this.checkBox_IsWorkManager);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.richTextBoxRemarks);
            this.Controls.Add(this.dateTimePickerSeniority);
            this.Controls.Add(this.dateTimePickerLastFunction);
            this.Controls.Add(this.dateTimePicker_DateOfEntry);
            this.Controls.Add(this.labelActif);
            this.Controls.Add(this.labelMatricule);
            this.Controls.Add(this.pictureBox_ProfilePic);
            this.Name = "FrmAgent";
            this.Text = "FrmAgent";
            this.tabControl_Education_FormationAndCertificationsOfUser.ResumeLayout(false);
            this.tabPageEducation_FormationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TABFormationsOfAgent)).EndInit();
            this.tabPageCertificationsAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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