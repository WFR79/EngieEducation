namespace Module_Education.Forms
{
    partial class FrmEditCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditCertificate));
            this.lblTitlePassport = new System.Windows.Forms.Label();
            this.combotypePassport = new System.Windows.Forms.ComboBox();
            this.lblTitleTypePassport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveCertificate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbSendingDate = new System.Windows.Forms.CheckBox();
            this.cbReturnDate = new System.Windows.Forms.CheckBox();
            this.cbValidityDate = new System.Windows.Forms.CheckBox();
            this.dgListPassport = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbExt_NameCertificate = new Module_Education.Classes.TextBoxExtensions();
            ((System.ComponentModel.ISupportInitialize)(this.dgListPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitlePassport
            // 
            this.lblTitlePassport.AutoSize = true;
            this.lblTitlePassport.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblTitlePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitlePassport.Location = new System.Drawing.Point(15, 88);
            this.lblTitlePassport.Name = "lblTitlePassport";
            this.lblTitlePassport.Size = new System.Drawing.Size(146, 16);
            this.lblTitlePassport.TabIndex = 132;
            this.lblTitlePassport.Text = "Type Certificat/Passport";
            // 
            // combotypePassport
            // 
            this.combotypePassport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combotypePassport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypePassport.FormattingEnabled = true;
            this.combotypePassport.Location = new System.Drawing.Point(17, 112);
            this.combotypePassport.Name = "combotypePassport";
            this.combotypePassport.Size = new System.Drawing.Size(185, 22);
            this.combotypePassport.TabIndex = 131;
            this.combotypePassport.SelectedIndexChanged += new System.EventHandler(this.combotypePassport_SelectedIndexChanged);
            // 
            // lblTitleTypePassport
            // 
            this.lblTitleTypePassport.AutoSize = true;
            this.lblTitleTypePassport.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitleTypePassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.lblTitleTypePassport.Location = new System.Drawing.Point(21, 19);
            this.lblTitleTypePassport.Name = "lblTitleTypePassport";
            this.lblTitleTypePassport.Size = new System.Drawing.Size(193, 26);
            this.lblTitleTypePassport.TabIndex = 130;
            this.lblTitleTypePassport.Text = "Créer un certificat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(15, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 134;
            this.label1.Text = "Nom Certificat/Passport";
            // 
            // btnSaveCertificate
            // 
            this.btnSaveCertificate.AllowDrop = true;
            this.btnSaveCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.btnSaveCertificate.FlatAppearance.BorderSize = 0;
            this.btnSaveCertificate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCertificate.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSaveCertificate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveCertificate.Location = new System.Drawing.Point(37, 328);
            this.btnSaveCertificate.Name = "btnSaveCertificate";
            this.btnSaveCertificate.Size = new System.Drawing.Size(144, 48);
            this.btnSaveCertificate.TabIndex = 136;
            this.btnSaveCertificate.Text = "Enregistrer";
            this.btnSaveCertificate.UseVisualStyleBackColor = false;
            this.btnSaveCertificate.Click += new System.EventHandler(this.btnSaveCertificate_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(232, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 48);
            this.button1.TabIndex = 137;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbSendingDate
            // 
            this.cbSendingDate.AutoSize = true;
            this.cbSendingDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbSendingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbSendingDate.Location = new System.Drawing.Point(17, 222);
            this.cbSendingDate.Name = "cbSendingDate";
            this.cbSendingDate.Size = new System.Drawing.Size(176, 20);
            this.cbSendingDate.TabIndex = 138;
            this.cbSendingDate.Text = "Spécifiez une date d\'envoi";
            this.cbSendingDate.UseVisualStyleBackColor = true;
            this.cbSendingDate.Visible = false;
            // 
            // cbReturnDate
            // 
            this.cbReturnDate.AutoSize = true;
            this.cbReturnDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbReturnDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbReturnDate.Location = new System.Drawing.Point(17, 250);
            this.cbReturnDate.Name = "cbReturnDate";
            this.cbReturnDate.Size = new System.Drawing.Size(176, 20);
            this.cbReturnDate.TabIndex = 139;
            this.cbReturnDate.Text = "Spécifiez une date d\'envoi";
            this.cbReturnDate.UseVisualStyleBackColor = true;
            this.cbReturnDate.Visible = false;
            // 
            // cbValidityDate
            // 
            this.cbValidityDate.AutoSize = true;
            this.cbValidityDate.Font = new System.Drawing.Font("Arial", 9.25F);
            this.cbValidityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(167)))));
            this.cbValidityDate.Location = new System.Drawing.Point(17, 278);
            this.cbValidityDate.Name = "cbValidityDate";
            this.cbValidityDate.Size = new System.Drawing.Size(195, 20);
            this.cbValidityDate.TabIndex = 140;
            this.cbValidityDate.Text = "Spécifiez une date de validité";
            this.cbValidityDate.UseVisualStyleBackColor = true;
            this.cbValidityDate.Visible = false;
            // 
            // dgListPassport
            // 
            this.dgListPassport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgListPassport.BackgroundColor = System.Drawing.Color.White;
            this.dgListPassport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListPassport.Location = new System.Drawing.Point(224, 92);
            this.dgListPassport.Name = "dgListPassport";
            this.dgListPassport.ReadOnly = true;
            this.dgListPassport.ShowEditingIcon = false;
            this.dgListPassport.Size = new System.Drawing.Size(222, 206);
            this.dgListPassport.TabIndex = 141;
            this.dgListPassport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgListPassport_MouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // tbExt_NameCertificate
            // 
            this.tbExt_NameCertificate.Location = new System.Drawing.Point(18, 177);
            this.tbExt_NameCertificate.Name = "tbExt_NameCertificate";
            this.tbExt_NameCertificate.Size = new System.Drawing.Size(184, 20);
            this.tbExt_NameCertificate.TabIndex = 135;
            // 
            // FrmEditCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(463, 416);
            this.Controls.Add(this.dgListPassport);
            this.Controls.Add(this.cbValidityDate);
            this.Controls.Add(this.cbReturnDate);
            this.Controls.Add(this.cbSendingDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveCertificate);
            this.Controls.Add(this.tbExt_NameCertificate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitlePassport);
            this.Controls.Add(this.combotypePassport);
            this.Controls.Add(this.lblTitleTypePassport);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditCertificate";
            this.Text = "FrmEditCertificate";
            ((System.ComponentModel.ISupportInitialize)(this.dgListPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlePassport;
        private System.Windows.Forms.ComboBox combotypePassport;
        private System.Windows.Forms.Label lblTitleTypePassport;
        private System.Windows.Forms.Label label1;
        private Classes.TextBoxExtensions tbExt_NameCertificate;
        private System.Windows.Forms.Button btnSaveCertificate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbSendingDate;
        private System.Windows.Forms.CheckBox cbReturnDate;
        private System.Windows.Forms.CheckBox cbValidityDate;
        private System.Windows.Forms.DataGridView dgListPassport;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}